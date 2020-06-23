using System;
using System.Collections.Generic;
using System.Drawing;

namespace AdventureOfStickMan
{
    public class SkeletonWarrior : GameUnit
    {
        public SkeletonWarrior(bool _isHuman) : base(_isHuman)
        {
            // Stats
            maxHealth = 100;
            attack = 15;
            ResetStats();
            name = "Skeleton Warrior";
            // Image
            pictureBox.Image = Properties.Resources.Skeleton_Warrior;
            pictureBox.Size = new Size(166, 194);
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
