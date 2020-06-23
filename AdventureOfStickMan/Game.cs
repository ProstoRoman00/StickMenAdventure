using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureOfStickMan
{
    public partial class Game : Form
    {
        Panel enemyPartyPanel;
        Panel playerPartyPanel;

        public static List<Button> mapButtons = new List<Button>();
        public static List<List<Button>> layers = new List<List<Button>>();
        public static LoggerBox mainLogger;
        public static Party playerParty;
        public static Skill currentActiveSkill;
        public static CombatHandler combatHandler;
        public static Label topText;
        private int[] button_status = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int person_type;
        int roomsNumber = 5;
        int buttonSize = 40;
        int buttonOffsetX = 85;
        public int Person_type { get => person_type; set => person_type = value; }

        public Game()
        {
            InitializeComponent();
            // Fullscreen
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            // Anti-flickering
            DoubleBuffered = true;
            // Top Victory/Defeat text
            topText = new Label
            {
                Size = new Size(Convert.ToInt32(Width * 0.85),
                Convert.ToInt32(Height * 0.1)),
                Location = new Point(Convert.ToInt32(Width * 0.5),
                Convert.ToInt32(Height * 0.05)),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 28),
                ForeColor = Color.Crimson,
                Parent = playArea
            };
            // Reference to log box
            mainLogger = new LoggerBox(loggerTextBox);
            // Skill buttons
            Button[] skillButtons = new Button[]
                { skillButton1, skillButton2, skillButton3, skillButton4 };
            playerPartyPanel = new Panel
            {
                Size = new Size(Convert.ToInt32(Width * 0.8f),
                Convert.ToInt32(Height * 0.7f)),
                Parent = playArea,
                Location = new Point(Convert.ToInt32(Width * .04f),
                Convert.ToInt32(Height * .2f))
            };
            // Combat Handler
            combatHandler =
                new CombatHandler(
                skillButtons);
            // Panels for unit pictures
            enemyPartyPanel = new Panel
            {
                Size = new Size(Convert.ToInt32(Width * 0.8f),
                Convert.ToInt32(Height * 0.7f)),
                Parent = playArea,
                Location = new Point(Convert.ToInt32(Width * (1 - .125f)),
                Convert.ToInt32(Height * .2f))
            };
        }

        List<Button> GenerateMap()
        {
            ClearMap();
            List<Button> result = new List<Button>();
            for (int i = 0; i < roomsNumber; i++)
            {
                layers.Add(new List<Button>());
                if (i == 0)
                {
                    Button b = new Button()
                    {
                        Name = i.ToString(),
                        Tag = RandomGroup(),
                        Parent = mapArea,
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point((buttonOffsetX * i) + 10, mapArea.Height / 2)
                    };
                    b.BringToFront();
                    result.Add(b);
                    layers[i].Add(b);
                }
                else if (i == roomsNumber - 1)
                {
                    Button b = new Button()
                    {
                        Name = i.ToString(),
                        Tag = new GameUnit[]
                        {
                            new SkeletonKing(false)
                        },
                        Parent = mapArea,
                        Size = new Size(buttonSize, buttonSize),
                        Location = new Point(buttonOffsetX * i, mapArea.Height / 2)
                    };
                    b.BringToFront();
                    result.Add(b);
                    layers[i].Add(b);
                }
                else
                {
                    Random rand = new Random();
                    int randNum = rand.Next(1, 4);
                    for (int j = 0; j < randNum; j++)
                    {
                        Button b = new Button()
                        {
                            Name = i.ToString(),
                            Tag = RandomGroup(),
                            Parent = mapArea,
                            Size = new Size(buttonSize, buttonSize),
                            Location = new Point(buttonOffsetX * i, (mapArea.Height / (randNum + 1)) * (j + 1))
                        };
                        b.BringToFront();
                        result.Add(b);
                        layers[i].Add(b);
                    }
                }
            }
            foreach (Button b in result)
            {
                b.Location = new Point(b.Location.X, b.Location.Y - 20);
                b.Enabled = false;
                b.BackColor = Color.LightGray;
                b.MouseClick += new MouseEventHandler(NextRoom);
                GameUnit[] temp = (GameUnit[])b.Tag;
            }
            return result;
        }

        GameUnit[] RandomGroup()
        {
            Random rand = new Random();
            string[] allUnits = { "SkeleWar", "SkeleWiz", "SkeleArch" };
            GameUnit[] result = new GameUnit[rand.Next(2, 5)];
            for (int i = 0; i < result.Length; i++)
            {
                string temp = allUnits[rand.Next(3)];
                switch (temp)
                {
                    case "SkeleWar":
                        result[i] = new SkeletonWarrior(false);
                        break;
                    case "SkeleWiz":
                        result[i] = new SkeletonWizard(false);
                        break;
                    case "SkeleArch":
                        result[i] = new SkeletonArcher(false);
                        break;
                    default:
                        break;
                }
            }
            return result;
        }

        void ClearMap()
        {
            foreach (Button b in mapButtons)
            {
                b.Visible = false;
                b.Enabled = false;
                b.Dispose();
            }

            mapButtons.Clear();
        }

        public void StartGame(GameUnit[] group)
        {
            mapButtons = GenerateMap();
            playerParty = new Party(playerPartyPanel, group);
            GameUnit[] _group = (GameUnit[])mapButtons[0].Tag;
            Party enemyParty = new Party(enemyPartyPanel, _group);
            // Start combat
            combatHandler.Start(playerParty,
                enemyParty, mapButtons[0]);
        }

        #region Skill Button Methods
        private void skillButton1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.PanSouth;
            currentActiveSkill = combatHandler.activeUnit.skills[0];
            HandleSkill(currentActiveSkill, combatHandler.activeUnit);
        }

        private void skillButton2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.PanSouth;
            currentActiveSkill = combatHandler.activeUnit.skills[1];
            HandleSkill(currentActiveSkill, combatHandler.activeUnit);
        }

        private void skillButton3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.PanSouth;
            currentActiveSkill = combatHandler.activeUnit.skills[2];
            HandleSkill(currentActiveSkill, combatHandler.activeUnit);
        }

        private void skillButton4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.PanSouth;
            currentActiveSkill = combatHandler.activeUnit.skills[3];
            HandleSkill(currentActiveSkill, combatHandler.activeUnit);
        }

        void HandleSkill(Skill currentActiveSkill, GameUnit caster)
        {
            if (currentActiveSkill is SingleTargetSkill ||
                currentActiveSkill is HealingSkill ||
                currentActiveSkill is StunSkill)
            {
                MouseState.state = InputState.Targetting;
            }
            else if (currentActiveSkill is AOEDamageSkill)
            {
                AOEDamageSkill temp = currentActiveSkill as AOEDamageSkill;
                temp.Execute(combatHandler.enemies.ToArray());
                foreach (GameUnit g in combatHandler.enemies)
                {
                    g.UpdateHealthLabel();
                }
                combatHandler.NextTurn();
            }
            else if (currentActiveSkill is BuffSkill)
            {
                BuffSkill temp = currentActiveSkill as BuffSkill;
                temp.Execute(caster);
                combatHandler.NextTurn();
            }
        }
        #endregion

        void NextRoom(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            combatHandler.Start(playerParty, new Party(enemyPartyPanel, (GameUnit[])b.Tag), b);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            playArea.Height = Convert.ToInt32(this.Height * 0.7);
            textLogArea.Width = Convert.ToInt32(this.Width * 0.6);
            textLogArea.Height = Convert.ToInt32(this.Height * 0.3);
            mapArea.Width = Convert.ToInt32(this.Width * 0.4);
            mapArea.Height = Convert.ToInt32(this.Height * 0.3);
            mapArea.Location = new Point(textLogArea.Width, (int)(this.Height * 0.7));
            textLogArea.Location = new Point(0, (int)(this.Height * 0.7));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.startMenu.Enabled = true;
            Program.startMenu.Visible = true;

            Visible = false;
            Enabled = false;
        }

        #region Map Buttons
        private void button1_Click(object sender, EventArgs e)
        {
            if (button_status[0] == 2) { MessageBox.Show("You can't fight whith this team after winning"); }
            else { MessageBox.Show("Start battle"); }
            button_status[1] = 1;
            button_status[2] = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button_status[1] == 1) { MessageBox.Show("Start battle"); }
            else if (button_status[1] == 2) { MessageBox.Show("You can't fight whith this team after winning"); }
            else { MessageBox.Show("You must won previous battles"); }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button_status[2] == 1) { MessageBox.Show("Start battle"); }
            else if (button_status[2] == 2) { MessageBox.Show("You can't fight whith this team after winning"); }
            else { MessageBox.Show("You must won previous battles"); }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (button_status[3] == 1) { MessageBox.Show("Start battle"); }
            else if (button_status[3] == 2) { MessageBox.Show("You can't fight whith this team after winning"); }
            else { MessageBox.Show("You must won previous battles"); }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (button_status[4] == 1) { MessageBox.Show("Start battle"); }
            else if (button_status[4] == 2) { MessageBox.Show("You can't fight whith this team after winning"); }
            else { MessageBox.Show("You must won previous battles"); }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (button_status[5] == 1) { MessageBox.Show("Start battle"); }
            else if (button_status[5] == 2) { MessageBox.Show("You can't fight whith this team after winning"); }
            else { MessageBox.Show("You must won previous battles"); }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button_status[6] == 1) { MessageBox.Show("Start battle"); }
            else if (button_status[6] == 2) { MessageBox.Show("You can't fight whith this team after winning"); }
            else { MessageBox.Show("You must won previous battles"); }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (button_status[7] == 1) { MessageBox.Show("Start battle"); }
            else if (button_status[7] == 2) { MessageBox.Show("You can't fight whith this team after winning"); }
            else { MessageBox.Show("You must won previous battles"); }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (button_status[8] == 1) { MessageBox.Show("Start battle"); }
            else if (button_status[8] == 2) { MessageBox.Show("You can't fight whith this team after winning"); }
            else { MessageBox.Show("You must won previous battles"); }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (button_status[10] == 1) { MessageBox.Show("Start battle"); }
            else if (button_status[10] == 2) { MessageBox.Show("You can't fight whith this team after winning"); }
            else { MessageBox.Show("You must won previous battles"); }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (button_status[11] == 1) { MessageBox.Show("Start battle"); }
            else if (button_status[11] == 2)
            {
            }
            else { MessageBox.Show("You must won previous battles"); }
        }
        #endregion
    }
}
