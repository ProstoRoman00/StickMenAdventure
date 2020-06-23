using System.Collections.Generic;

namespace AdventureOfStickMan
{
    class Alchemist : GameUnit
    {
        public Alchemist(bool _isHuman) : base(_isHuman)
        {
            // Stats
            maxHealth = 150;
            armor = 5;
            attack = 25;
            ResetStats();
            name = "Alchemist";
            // Image
            pictureBox.Image = Properties.Resources.Stick_Figure_Healer;
            pictureBox.Size = new System.Drawing.Size(166, 194);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // Health Label
            MakeHealthLabel(this.pictureBox);
            // Skills
            skills = new List<Skill>();
            skills.Add(new SingleTargetSkill("Explosive potion", 15f, Properties.Resources.potion_ball));
            skills.Add(new HealingSkill("Health Potion", 10f, Properties.Resources.health_potion));
            skills.Add(new StunSkill("Chemical bomb", Properties.Resources.fizzing_flask));
            skills.Add(new BuffSkill("Metabolic Booster", Properties.Resources.magic_potion, 1.25f));

        }
    }
}
