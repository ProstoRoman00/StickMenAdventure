using System.Drawing;
using System.Collections.Generic;
using System;

namespace AdventureOfStickMan
{
    class SkeletonKing : GameUnit
    {
        public SkeletonKing(bool _isHuman) : base(_isHuman)
        {
            // Stats
            maxHealth = 500;
            attack = 20;
            ResetStats();
            name = "Skeleton King";
            // Image
            pictureBox.Image = Properties.Resources.Skeleton_King;
            pictureBox.Size = new Size(Convert.ToInt32(166 * 1.5), Convert.ToInt32(194 * 1.5));
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // Health Label
            MakeHealthLabel(this.pictureBox);
            // Skills
            skills = new List<Skill>();
            skills.Add(new SingleTargetSkill("Slash", attack, Properties.Resources.saber_slash));
        }
    }
}
