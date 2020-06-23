using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureOfStickMan
{
    public class LoggerBox
    {
        TextBox textBox;

        public LoggerBox(TextBox _textBox)
        {
            textBox = _textBox;
            textBox.Font = new System.Drawing.Font("Arial", 14);
        }

        public void LogMessage(string message)
        {
            textBox.AppendText(String.Format("\r\n" + message));
        }

        public void LogDamage(GameUnit target, float amount)
        {
            textBox.AppendText(String.Format("\r\n" +
                String.Format("{0} has taken {1} damage!",
                target.name, amount)));
        }
    }
}
