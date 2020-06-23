using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureOfStickMan
{
    public abstract class Skill
    {
        public string name;
        public Image icon;

        public Skill(string _name, Image _icon)
        {
            name = _name;
            icon = _icon;
        }
    }
}
