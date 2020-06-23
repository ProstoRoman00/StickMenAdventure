using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureOfStickMan
{
    public class CombatHandler
    {
        public List<GameUnit> units = new List<GameUnit>();
        public List<GameUnit> enemies = new List<GameUnit>();
        public List<GameUnit> players = new List<GameUnit>();
        public PictureBox stunnedStars = new PictureBox()
        {
            Image = Properties.Resources.Stunned_Stars,
            Size = Properties.Resources.Stunned_Stars.Size,
            BackColor = System.Drawing.Color.Transparent
        };
        public PictureBox hoverIndicator = new PictureBox
        {
            Image = Properties.Resources.HoverIndicator,
            Size = Properties.Resources.HoverIndicator.Size,
            Visible = false
        };
        public PictureBox friendlyIndicator = new PictureBox
        {
            Image = Properties.Resources.HoverIndicator,
            Size = Properties.Resources.HoverIndicator.Size,
            Visible = false
        };
        Button[] skillButtons;
        public GameUnit activeUnit;
        PictureBox turnArrow = new PictureBox
        {
            Image = Properties.Resources.TurnArrow,
            Size = Properties.Resources.TurnArrow.Size,
            Visible = false
        };

        int currentLayer = 0;
        int activeUnitIndex = 0;
        bool combatActive = false;

        public CombatHandler(Button[] _skillButtons)
        {
            skillButtons = _skillButtons;
        }

        public void Start(Party playerGroup, Party enemyGroup, Button currentRoom)
        {
            units.Clear();
            enemies.Clear();
            players.Clear();

            foreach (GameUnit g in playerGroup.group) { units.Add(g); }
            foreach (GameUnit g in enemyGroup.group) { units.Add(g); }
            foreach (Button b in Game.mapButtons)
            {
                b.Enabled = false;
                b.BackColor = System.Drawing.Color.LightGray;
            }

            currentRoom.BackColor = System.Drawing.Color.Blue;

            enemies = enemyGroup.group.ToList();
            players = playerGroup.group.ToList();

            hoverIndicator.Parent = enemyGroup.group[0].pictureBox.Parent;
            friendlyIndicator.Parent = playerGroup.group[0].pictureBox.Parent;

            Game.mainLogger.LogMessage("Combat started!");
            Game.topText.Text = "";
            combatActive = true;
            Random r = new Random();
            units = Shuffle(units);
            foreach (GameUnit unit in units)
            {
                unit.UpdateHealthLabel();
                unit.pictureBox.BringToFront();
            }

            activeUnitIndex = -1;
            NextTurn();
        }

        public void End()
        {
            combatActive = false;
            turnArrow.Visible = false;

            foreach (GameUnit u in units)
            {
                try
                {
                    PictureBox temp = (PictureBox)u.pictureBox.Tag;
                    temp.Dispose();
                    temp = null;
                }
                catch { }
            }

            Game.mainLogger.LogMessage("Combat ended!");

            if (players.Count > 0)
                Game.topText.Text = "You are victorious! Select next room";
            else
                Game.topText.Text = "You have been defeated! Try again";

            Game.playerParty.group = players.ToArray();
            currentLayer++;
            foreach (Button b in Game.layers[currentLayer])
            {
                b.Enabled = true;
                b.BackColor = System.Drawing.Color.LightGreen;
            }
        }

        public void UpdateTurnArrow(GameUnit unit)
        {
            turnArrow.Parent = unit.pictureBox.Parent;
            turnArrow.BringToFront();
            turnArrow.Visible = true;
            turnArrow.Location = new System.Drawing.Point(unit.pictureBox.Location.X + 80,
                unit.pictureBox.Location.Y - 40);
        }

        List<GameUnit> Shuffle(List<GameUnit> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        public void NextTurn()
        {
            if (activeUnitIndex > 10)
                return;

            RemoveIcons();
            if (enemies.Count > 0 && players.Count > 0)
            {
                if (activeUnitIndex < units.Count - 1)
                {
                    activeUnitIndex++;
                    activeUnit = units[activeUnitIndex];
                    UpdateTurnArrow(activeUnit);
                    if (activeUnit.isStunned)
                    {
                        activeUnit.isStunned = false;
                        RemoveStars(activeUnit);
                        NextTurn();
                    }
                    else
                    {
                        try
                        {
                            if (!activeUnit.isAlive)
                            {
                                NextTurn();
                            }
                            Game.mainLogger.LogMessage("Current turn: " + activeUnit.name);
                        }
                        catch
                        {
                            NextTurn();
                        }
                        if (!activeUnit.isHuman)
                        {
                            UpdateTurnArrow(activeUnit);
                            SingleTargetSkill temp = activeUnit.skills[0] as SingleTargetSkill;
                            Random r = new Random();
                            temp.Execute(players[r.Next(players.Count)]);
                            try
                            {
                                players[0].UpdateHealthLabel();
                            }
                            catch
                            {
                                System.Diagnostics.Debug.WriteLine("No more players.");
                            }
                            NextTurn();
                        }
                        else
                        {
                            //UpdateTurnArrow(activeUnit);
                            DrawSkills(activeUnit);
                        }
                    }
                }
                else
                {
                    Game.mainLogger.LogMessage("======================================");
                    Game.mainLogger.LogMessage("Round complete!");
                    Game.mainLogger.LogMessage("======================================");
                    activeUnitIndex = -1;
                    NextTurn();
                }
            }
            else
            {
                Game.mainLogger.LogMessage("One of the groups is dead!");
                if (players.Count <= 0 || enemies.Count <= 0)
                {
                    End();
                }
            }
        }

        public void DrawSkills(GameUnit unit)
        {
            RemoveIcons();
            for (int i = 0; i < skillButtons.Length; i++)
            {
                try
                {
                    skillButtons[i].BackgroundImage = unit.skills[i].icon;
                }
                catch { }
            }
        }

        public void RemoveIcons()
        {
            for (int i = 0; i < skillButtons.Length; i++)
            {
                if (skillButtons[i].Image != null)
                {
                    skillButtons[i].Image.Dispose();
                    skillButtons[i].Image = null;
                }
            }
        }

        public void DrawStunnedStars(GameUnit target)
        {
            PictureBox temp = new PictureBox()
            {
                Image = stunnedStars.Image,
                Size = stunnedStars.Image.Size,
                BackColor = stunnedStars.BackColor
            };
            target.pictureBox.Tag = temp;
            temp.Parent = target.pictureBox.Parent;
            temp.Location = new System.Drawing.Point(target.pictureBox.Location.X + 80,
                target.pictureBox.Location.Y - 40);
            temp.BringToFront();
        }

        public void RemoveStars(GameUnit target)
        {
            PictureBox temp = (PictureBox)target.pictureBox.Tag;
            temp.Dispose();
            temp = null;
        }
    }
}
