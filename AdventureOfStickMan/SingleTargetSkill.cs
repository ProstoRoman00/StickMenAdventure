using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureOfStickMan
{
    class SingleTargetSkill : Skill
    {
        float damage;

        public SingleTargetSkill(string _name, float _damage, System.Drawing.Image _icon) : base(_name, _icon)
        {
            damage = _damage;
        }

        public void Execute(GameUnit target)
        {
            target.DepleteHealth(damage);
        }
    }
}
