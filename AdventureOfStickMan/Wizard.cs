using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureOfStickMan
{
    class Wizard : GameUnit
    {
        public Wizard(bool _isHuman) : base(_isHuman)
        {
            // Stats
            maxHealth = 95f;
            armor = 2;
            attack = 15;
            ResetStats();
            name = "Wizard";
            // Image
            pictureBox.Image = Properties.Resources.Stick_Figure_Wizard;
            pictureBox.Size = new Size(166, 194);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // Health Label
            MakeHealthLabel(this.pictureBox);
            // Skills
            skills = new List<Skill>();
            skills.Add(new SingleTargetSkill("Fireball", 20f, Properties.Resources.fireball));
            skills.Add(new StunSkill("Ice Bolt", Properties.Resources.ice_bolt));
            skills.Add(new AOEDamageSkill("Wind Shear", 15f, Properties.Resources.wind_slap));
            skills.Add(new AOEDamageSkill("Lightning Trio", 15f, Properties.Resources.lightning_trio));
        }
    }
}
