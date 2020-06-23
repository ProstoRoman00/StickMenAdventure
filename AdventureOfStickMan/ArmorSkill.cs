using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureOfStickMan
{
    class ArmorSkill : Skill
    {
        float armorAmount;

        public ArmorSkill(string _name, float _armorAmount, Image _icon) : base(_name, _icon)
        {
            armorAmount = _armorAmount;
        }

        public void Execute(GameUnit target)
        {
            target.armor += armorAmount;
        }
    }
}
