using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureOfStickMan
{
    public class Party
    {
        public Panel area;
        public GameUnit[] group;

        public Party(Panel _area, GameUnit[] _group)
        {
            area = _area;
            group = _group;
            PlaceUnits(area, group);
        }

        void PlaceUnits(Panel area, GameUnit[] group)
        {
            for (int i = 0; i < group.Length; i++)
            {
                group[i].pictureBox.Parent = area;
                group[i].pictureBox.Location =
                    new System.Drawing.Point(Convert.ToInt32(area.Width * .25f * (i)),
                                             Convert.ToInt32(area.Height * .2f));
                group[i].pictureBox.BringToFront();
            }
        }
    }
}
