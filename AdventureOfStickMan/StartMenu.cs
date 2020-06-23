using System;
using System.Windows.Forms;

namespace AdventureOfStickMan
{
    public partial class StartMenu : Form
    {

        public StartMenu()
        {
            InitializeComponent();
            // Fullscreen
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            // Background
            BackgroundImage = Properties.Resources.StartMenu_BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            // Anti-flickering
            DoubleBuffered = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.characterSelection.Visible = true;
            Program.characterSelection.Enabled = true;

            Visible = false;
            Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
