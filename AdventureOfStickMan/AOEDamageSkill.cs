using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureOfStickMan
{
    class AOEDamageSkill : Skill
    {
        float damage;

        public AOEDamageSkill(string _name, float _damage, System.Drawing.Image _icon) : base(_name, _icon)
        {
            damage = _damage;
        }

        public void Execute(GameUnit[] targets)
        {
            foreach (GameUnit g in targets)
            {
                g.DepleteHealth(damage);
            }
        }
    }
}
