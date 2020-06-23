using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureOfStickMan
{
    class GameMethods
    {
        private void making(int numb,int type) {
            //Do not touch
        }
        public void makeyour(int type) {
            if ((int)ETypes.first == type) {
                making((int)characterNumb.first, type);
                making((int)characterNumb.second, type);
                making((int)characterNumb.third, type);
                making((int)characterNumb.fourth, type);
            }
            else if((int)ETypes.second == type) {
                //Do not touch
            }
            else if ((int)ETypes.third == type)
            {
                //Do not touch
            }
            else if ((int)ETypes.fourth == type)
            {
                //Do not touch
            }
        }
        public void create_op(int type)
        {
            if ((int)ETypes.first == type)
            {
                making((int)characterNumb.first, type);
                making((int)characterNumb.second, type);
                making((int)characterNumb.third, type);
                making((int)characterNumb.fourth, type);
            }
            else if ((int)ETypes.second == type)
            {
                //Do not touch
            }
            else if ((int)ETypes.third == type)
            {
                //Do not touch
            }
            else if ((int)ETypes.fourth == type)
            {
                //Do not touch
            }
        }
    }
}
