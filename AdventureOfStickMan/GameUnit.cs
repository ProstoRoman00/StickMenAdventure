using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace AdventureOfStickMan
{
    public abstract class GameUnit
    {
        protected float maxHealth;
        protected LoggerBox logger;
        protected CombatHandler combatHandler;

        public List<Skill> skills;
        public PictureBox pictureBox;
        public Label healthLabel;
        public float armor;
        public float attack;
        public float currentHealth;
        public bool isAlive;
        public bool isStunned;
        public string name;
        public bool isHuman;

        public GameUnit(bool _isHuman)
        {
            pictureBox = new PictureBox();
            pictureBox.MouseClick += new MouseEventHandler(OnClick);
            pictureBox.MouseEnter += new EventHandler(OnMouseEnter);
            pictureBox.MouseLeave += new EventHandler(OnMouseExit);

            isHuman = _isHuman;
            isAlive = true;
            isStunned = false;
            combatHandler = Game.combatHandler;

            try { logger = Game.mainLogger; }
            catch (Exception e) { MessageBox.Show(e.Message); }
        }

        protected void MakeHealthLabel(PictureBox image)
        {
            healthLabel = new Label();
            healthLabel.BringToFront();
            healthLabel.Size = new Size(image.Image.Width / 2, 25);
            healthLabel.Text = currentHealth.ToString();
            healthLabel.TextAlign = ContentAlignment.MiddleCenter;
            healthLabel.Font = new Font("Arial", 18);
            healthLabel.BackColor = Color.Black;
            healthLabel.ForeColor = Color.Crimson;
        }

        public void DepleteHealth(float amount)
        {
            if (!isAlive)
                return;

            if (currentHealth > amount)
            {
                currentHealth -= amount;
                try
                {
                    logger.LogDamage(this, amount);
                }
                catch (NullReferenceException)
                { Console.WriteLine("Logger not found."); }
            }
            else
            {
                currentHealth = 0f;
                Die();
                try
                {
                    logger.LogMessage(String.Format("{0} has taken {1} damage and died!",
                  name, amount));
                }
                catch (NullReferenceException)
                { Console.WriteLine("Logger not found."); }
            }
        }

        public virtual void Die()
        {
            if (!isAlive)
                return;

            if (currentHealth != 0)
                currentHealth = 0;
            isAlive = false;

            pictureBox.Visible = false;
            pictureBox.Enabled = false;
            healthLabel.Visible = false;
            healthLabel.Enabled = false;

            Game.combatHandler.units.Remove(this);
            if (isHuman)
                combatHandler.players.Remove(this);
            else
                combatHandler.enemies.Remove(this);
        }

        public virtual void ResetStats()
        {
            isAlive = true;
            currentHealth = maxHealth;
        }

        public void OnClick(object sender, EventArgs e)
        {
            if (Game.currentActiveSkill is SingleTargetSkill)
            {
                if (MouseState.state == InputState.Targetting &&
                    !combatHandler.players.Contains(this))
                {
                    SingleTargetSkill singleTargetSkill =
                        Game.currentActiveSkill as SingleTargetSkill;
                    singleTargetSkill.Execute(this);
                    MouseState.state = InputState.Idle;
                    UpdateHealthLabel();
                    combatHandler.hoverIndicator.Visible = false;
                    Game.combatHandler.NextTurn();
                }
            }
            else if (Game.currentActiveSkill is HealingSkill)
            {
                if (MouseState.state == InputState.Targetting &&
                    !combatHandler.enemies.Contains(this))
                {
                    HealingSkill healingSkill = Game.currentActiveSkill as HealingSkill;
                    healingSkill.Execute(this);
                    MouseState.state = InputState.Idle;
                    UpdateHealthLabel();
                    combatHandler.hoverIndicator.Visible = false;
                    Game.combatHandler.NextTurn();
                }
            }
            else if (Game.currentActiveSkill is StunSkill)
            {
                if (MouseState.state == InputState.Targetting &&
                    !combatHandler.players.Contains(this))
                {
                    StunSkill stunSkill = Game.currentActiveSkill as StunSkill;
                    stunSkill.Execute(this);
                    combatHandler.DrawStunnedStars(this);
                    MouseState.state = InputState.Idle;
                    UpdateHealthLabel();
                    combatHandler.hoverIndicator.Visible = false;
                    Game.combatHandler.NextTurn();
                }
            }
        }

        public void OnMouseEnter(object sender, EventArgs e)
        {
            if (Game.currentActiveSkill is SingleTargetSkill)
            {
                if (MouseState.state == InputState.Targetting &&
                    !combatHandler.players.Contains(this))
                {
                    combatHandler.hoverIndicator.Visible = true;
                    combatHandler.hoverIndicator.Location = new Point(pictureBox.Location.X + 50,
                        pictureBox.Location.Y + pictureBox.Size.Height + 10);
                }
            }
            else if (Game.currentActiveSkill is HealingSkill)
            {
                if (MouseState.state == InputState.Targetting &&
                    !combatHandler.enemies.Contains(this))
                {
                    combatHandler.friendlyIndicator.Visible = true;
                    combatHandler.friendlyIndicator.Location = new Point(pictureBox.Location.X + 50,
                        pictureBox.Location.Y + pictureBox.Size.Height + 10);
                }
            }
        }

        public void OnMouseExit(object sender, EventArgs e)
        {
            if (MouseState.state == InputState.Targetting &&
                !combatHandler.players.Contains(this))
            {
                combatHandler.hoverIndicator.Visible = false;
            }
            else if (Game.currentActiveSkill is HealingSkill)
            {
                combatHandler.friendlyIndicator.Visible = false;
            }
        }

        ~GameUnit()
        {
            pictureBox.Click -= new EventHandler(OnClick);
        }

        public void UpdateHealthLabel()
        {
            if (healthLabel.Parent != pictureBox.Parent)
            {
                healthLabel.Parent = pictureBox.Parent;
                healthLabel.Location = new Point(pictureBox.Location.X + 50,
                    pictureBox.Location.Y + pictureBox.Size.Height + 25);
            }

            healthLabel.BringToFront();
            healthLabel.Text = currentHealth.ToString();
        }
    }
}
