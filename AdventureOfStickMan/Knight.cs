using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdventureOfStickMan
{
    public class Knight : GameUnit
    {
        public Knight(bool _isHuman) : base(_isHuman)
        {
            // Stats
            maxHealth = 200f;
            armor = 10;
            attack = 15;
            ResetStats();
            name = "Knight";
            // Image
            pictureBox.Image = Properties.Resources.Stick_Figure_Knight;
            pictureBox.Size = new Size(166, 194);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // Health Label
            MakeHealthLabel(this.pictureBox);
            // Skills
            skills = new List<Skill>();
            skills.Add(new SingleTargetSkill("Slash", attack, Properties.Resources.saber_slash));
            skills.Add(new HealingSkill("Armor Up!", armor, Properties.Resources.vibrating_shield));
            skills.Add(new StunSkill("Stunning blow", Properties.Resources.stoned_skull));
            skills.Add(new BuffSkill("Rage", Properties.Resources.confrontation, 1.25f));
        }
    }
}
