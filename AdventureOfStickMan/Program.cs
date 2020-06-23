using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;

namespace AdventureOfStickMan
{
    

    class Program
    {
        public static StartMenu startMenu = new StartMenu();
        public static CharacterSelection characterSelection = new CharacterSelection();
        public static Game game = new Game();

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(startMenu);
        }
    }
}
