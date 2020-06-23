using System.Collections.Generic;
using System.Drawing;

namespace AdventureOfStickMan
{
    class SkeletonWizard : GameUnit
    {
        public SkeletonWizard(bool _isHuman) : base(_isHuman)
        {
            // Stats
            maxHealth = 50;
            attack = 30;
            ResetStats();
            name = "Skeleton Wizard";
            // Image
            pictureBox.Image = Properties.Resources.Skeleton_Wizard;
            pictureBox.Size = new Size(166, 194);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // Health Label
            MakeHealthLabel(this.pictureBox);
            // Skills
            skills = new List<Skill>();
            skills.Add(new SingleTargetSkill("Fireball", attack, Properties.Resources.fireball));
        }
    }
}
