using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureOfStickMan
{
    public enum ETypes
    { first=1, second, third, fourth }
    public enum characterNumb
    { first = 1, second, third, fourth }

    public enum BuffType
    {
        Damage, Armor, Health
    }

    public enum InputState
    {
        Idle, Targetting
    }
}
