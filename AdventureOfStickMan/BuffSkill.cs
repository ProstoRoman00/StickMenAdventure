using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureOfStickMan
{
    class BuffSkill : Skill
    {
        float amount;

        public BuffSkill(string _name, Image _icon, float _amount) : base(_name, _icon)
        {
            amount = _amount;
        }

        public void Execute(GameUnit target)
        {
            amount = (amount < 1) ? 1 : (amount > 2) ? 1.9f : amount;
            target.attack *= amount;
            Game.mainLogger.LogMessage(target.name + "'s damage has been increased!");
        }
    }
}
