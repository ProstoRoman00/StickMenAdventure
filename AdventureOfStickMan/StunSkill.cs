using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureOfStickMan
{
    class StunSkill : Skill
    {
        public StunSkill(string _name, Image _icon) : base(_name, _icon)
        {
        }

        public void Execute(GameUnit target)
        {
            target.isStunned = true;
        }
    }
}
