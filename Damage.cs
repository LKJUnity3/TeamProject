using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    internal class Damage
    {
        public static double skillMinDamage;
        public static double skillMaxDamage;

        public static int SkillEffect(Skill.SkillType type, int skillnumb)
        {
            Random rand = new Random();

            if(type == Skill.SkillType.Attack)
            {
                skillMinDamage = Math.Round((double)(Player.player.atk + Skill.characterSkill[skillnumb].skillDamage)*0.9);
                skillMaxDamage = Math.Round((double)(Player.player.atk + Skill.characterSkill[skillnumb].skillDamage) * 1.1);

                int damage;
                damage = rand.Next((int)skillMinDamage, (int)skillMaxDamage);
                return damage;
            }
            else if(type == Skill.SkillType.AttackPercent)
            {
                skillMinDamage = Math.Round((double)(Player.player.atk * Skill.characterSkill[skillnumb].skillDamage) * 0.9);
                skillMaxDamage = Math.Round((double)(Player.player.atk * Skill.characterSkill[skillnumb].skillDamage) * 1.1);

                int damage;
                damage = rand.Next((int)skillMinDamage, (int)skillMaxDamage);
                return damage;
            }

            return 0;
            
        }
    }
}
