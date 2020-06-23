using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureOfStickMan
{
    class HealingSkill : Skill
    {
        float healingAmount;

        public HealingSkill(string _name, float _healingAmount, Image _icon) : base(_name, _icon)
        {
            healingAmount = _healingAmount;
        }

        public void Execute(GameUnit target)
        {
            target.DepleteHealth(-healingAmount);
        }
    }
}
