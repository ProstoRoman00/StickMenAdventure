using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureOfStickMan
{
    public class Scene
    {
        public string Name { get; private set; }
        public List<Panel> panels;

        public Scene(string _name)
        {
            Name = _name;
            panels = new List<Panel>();
        }

        public void Activate()
        {
            foreach (Panel panel in panels)
            {
                panel.Visible = true;
            }
        }

        public void Deactivate()
        {
            foreach (Panel panel in panels)
            {
                panel.Visible = false;
            }
        }
    }
}
