using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureOfStickMan
{
    class Thief : GameUnit
    {
        public Thief(bool _isHuman) : base(_isHuman)
        {
            // Stats
            maxHealth = 75;
            armor = 3;
            attack = 25;
            ResetStats();
            name = "Thief";
            // Image
            pictureBox.Image = Properties.Resources.Stick_Figure_Thief;
            pictureBox.Size = new System.Drawing.Size(166, 194);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // Health Label
            MakeHealthLabel(this.pictureBox);
            // Skills
            skills = new List<Skill>();
            skills.Add(new SingleTargetSkill("Fan of Knives", 15f, Properties.Resources.daggers));
            skills.Add(new HealingSkill("Shadow Cloak", 10f, Properties.Resources.cloak_dagger));
            skills.Add(new StunSkill("Dagger and Rose", Properties.Resources.dagger_rose));
            skills.Add(new BuffSkill("Vendetta", Properties.Resources.architect_mask, 1.3f));

        }
    }
}
