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
    public partial class CharacterSelection : Form
    {
        public PictureBox[] characters;

        ToolTip[] tooltips = new ToolTip[4];
        List<PictureBox> icons = new List<PictureBox>();
        Panel characterPanel;
        Panel framePanel;
        List<GameUnit> selectedCharacters = new List<GameUnit>();
        Point offset;
        PictureBox[] frames;
        public CharacterSelection()
        {
            #region Initialization
            InitializeComponent();
            // Fullscreen
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            // Background
            BackgroundImage = Properties.Resources.CharacterSelection_BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            // Anti-flickering
            DoubleBuffered = true;
            // On Form becomes visible
            Shown += OnShown;
            #endregion
            characters = new PictureBox[]
            {
                new PictureBox()
                {
                    Image = Properties.Resources.Stick_Figure_Knight,
                    BackColor = Color.Transparent,
                    Anchor = AnchorStyles.Left,
                    Size = Properties.Resources.Stick_Figure_Knight.Size,
                    Name = "Knight"
                },
                new PictureBox()
                {
                    Image = Properties.Resources.Stick_Figure_Thief,
                    BackColor = Color.Transparent,
                    Size = Properties.Resources.Stick_Figure_Knight.Size,
                    Anchor = AnchorStyles.Left,
                    Name = "Thief"
                },
                new PictureBox()
                {
                    Image = Properties.Resources.Stick_Figure_Healer,
                    BackColor = Color.Transparent,
                    Anchor = AnchorStyles.Left,
                    Size = Properties.Resources.Stick_Figure_Knight.Size,
                    Name = "Alchemist"
                },
                new PictureBox()
                {
                    Image = Properties.Resources.Stick_Figure_Wizard,
                    BackColor = Color.Transparent,
                    Anchor = AnchorStyles.Left,
                    Size = Properties.Resources.Stick_Figure_Knight.Size,
                    Name = "Wizard"
                }
            };
            for (int i = 0; i < characters.Length; i++)
            {
                characters[i].MouseClick += new MouseEventHandler(OnCharacterClick);
                string toolTipText = characters[i].Name + "\r\n";
                tooltips[i] = new ToolTip()
                {

                };
                switch (characters[i].Name)
                {
                    case "Knight":
                        toolTipText += "A sturdy knight with high HP and mediocre damage. \r\nCan heal himself and allies.";
                        break;
                    case "Wizard":
                        toolTipText += "Frail mage with low HP but high damage output. \r\nHas an array of spells focused on offense.";
                        break;
                    case "Thief":
                        toolTipText += "Agile rogue who utilizes chep tricks to deal \r\ndamage and survive. Good HP and average damage.";
                        break;
                    case "Alchemist":
                        toolTipText += "Mad scientist who has a potion for every \r\nsituation. Jack of all trades.";
                        break;
                    default:
                        break;
                }
                tooltips[i].SetToolTip(characters[i], toolTipText);
            }

            start_button.Enabled = false;
        }

        void OnShown(object sender, EventArgs e)
        {
            Label topText = new Label()
            {
                Parent = this,
                Size = new Size(1000, 50),
                Font = new Font("Arial", 32),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = "Assemble your party",
                Location = new Point(this.Size.Width / 8, this.Size.Height / 10)
            };
            characterPanel = new Panel()
            {
                Size = new Size(1000, 350),
                Parent = this,
                BackColor = Color.LightGray,
                Location = new Point(this.Size.Width / 8, this.Size.Height / 7)
            };
            offset = new Point(characterPanel.Size.Width / 6, characterPanel.Size.Height / 4);
            for (int i = 0; i < characters.Length; i++)
            {
                characters[i].Parent = characterPanel;
                characters[i].Location = new Point(offset.X * (i + 1), offset.Y);
                characters[i].BringToFront();
                Label name = new Label()
                {
                    Parent = characterPanel,
                    Size = new Size(130, 30),
                    Location = new Point(characters[i].Location.X + 50, characters[i].Location.Y - 45),
                    Text = characters[i].Name,
                    Font = new Font("Arial", 18)
                };
            }
            framePanel = new Panel()
            {
                Size = new Size(750, 160),
                Parent = this,
                BackColor = Color.LightGray,
                Location = new Point(this.Size.Width / 4, 500)
            };
            frames = new PictureBox[characters.Length];
            for (int i = 0; i < frames.Length; i++)
            {
                frames[i] = new PictureBox
                {
                    Parent = framePanel,
                    Image = Properties.Resources.SelectFrame,
                    BackColor = Color.Transparent,
                    Size = Properties.Resources.SelectFrame.Size,
                    Location = new Point((offset.X + 30) * i, 1)
                };
            }
        }

        void OnCharacterClick(object sender, EventArgs e)
        {
            PictureBox icon;
            if (selectedCharacters.Count < 4)
            {
                PictureBox s = (PictureBox)sender;
                switch (s.Name)
                {
                    case "Knight":
                        icon = new PictureBox()
                        {
                            Tag = selectedCharacters.Count,
                            Parent = framePanel,
                            Image = Properties.Resources.Knight_Icon,
                            Size = Properties.Resources.Knight_Icon.Size,
                            Location = new Point(frames[selectedCharacters.Count].Location.X + 17,
                                                    frames[selectedCharacters.Count].Location.Y + 15)
                        };
                        icon.MouseClick += new MouseEventHandler(OnIconClick);
                        icon.BringToFront();
                        icons.Add(icon);
                        selectedCharacters.Add(new Knight(true));
                        break;
                    case "Thief":
                        icon = new PictureBox()
                        {
                            Tag = selectedCharacters.Count,
                            Parent = framePanel,
                            Image = Properties.Resources.Thief_Icon,
                            Size = Properties.Resources.Thief_Icon.Size,
                            Location = new Point(frames[selectedCharacters.Count].Location.X + 17,
                                                    frames[selectedCharacters.Count].Location.Y + 15)
                        };
                        icon.MouseClick += new MouseEventHandler(OnIconClick);
                        icon.BringToFront();
                        icons.Add(icon);
                        selectedCharacters.Add(new Thief(true));
                        break;
                    case "Alchemist":
                        icon = new PictureBox()
                        {
                            Tag = selectedCharacters.Count,
                            Parent = framePanel,
                            Image = Properties.Resources.Alch_Icon,
                            Size = Properties.Resources.Alch_Icon.Size,
                            Location = new Point(frames[selectedCharacters.Count].Location.X + 17,
                                                    frames[selectedCharacters.Count].Location.Y + 15)
                        };
                        icon.MouseClick += new MouseEventHandler(OnIconClick);
                        icon.BringToFront();
                        icons.Add(icon);
                        selectedCharacters.Add(new Alchemist(true));
                        break;
                    case "Wizard":
                        icon = new PictureBox()
                        {
                            Tag = selectedCharacters.Count,
                            Parent = framePanel,
                            Image = Properties.Resources.Wizard_Icon,
                            Size = Properties.Resources.Wizard_Icon.Size,
                            Location = new Point(frames[selectedCharacters.Count].Location.X + 17,
                                                    frames[selectedCharacters.Count].Location.Y + 15),
                        };
                        icon.MouseClick += new MouseEventHandler(OnIconClick);
                        icon.BringToFront();
                        icons.Add(icon);
                        selectedCharacters.Add(new Wizard(true));
                        break;
                    default:
                        break;
                }
            }

            if (selectedCharacters.Count == 4)
                start_button.Enabled = true;
        }

        void OnIconClick(object sender, EventArgs e)
        {
            PictureBox temp = (PictureBox)sender;
            selectedCharacters.RemoveAt((int)temp.Tag);
            icons.Remove(temp);
            for (int i = (int)temp.Tag; i < selectedCharacters.Count; i++)
                icons[i].Tag = (int)icons[i].Tag - 1;
            ReplaceIconsAndCharacters();
            temp.Dispose();
            temp = null;
            if (selectedCharacters.Count < 4)
                start_button.Enabled = false;
        }

        void ReplaceIconsAndCharacters()
        {
            for (int i = 0; i < icons.Count; i++)
            {
                icons[i].Location = new Point(frames[i].Location.X + 17,
                                              frames[i].Location.Y + 15);
            }
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            Program.startMenu.Visible = true;
            Program.startMenu.Enabled = true;

            Visible = false;
            Enabled = false;
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            Program.game.Visible = true;
            Program.game.Enabled = true;

            Program.game.StartGame(selectedCharacters.ToArray());

            Visible = false;
            Enabled = false;
        }
    }
}
