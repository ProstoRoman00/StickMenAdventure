using System.Drawing;
using System.Collections.Generic;

namespace AdventureOfStickMan
{
    class SkeletonArcher : GameUnit
    {
        public SkeletonArcher(bool _isHuman) : base(_isHuman)
        {
            // Stats
            maxHealth = 65;
            attack = 20;
            ResetStats();
            name = "Skeleton Archer";
            // Image
            pictureBox.Image = Properties.Resources.Skeleton_Archer;
            pictureBox.Size = new Size(166, 194);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // Health Label
            MakeHealthLabel(this.pictureBox);
            // Skills
            skills = new List<Skill>();
            skills.Add(new SingleTargetSkill("Arrow", attack, Properties.Resources.fireball));
        }
    }
}
