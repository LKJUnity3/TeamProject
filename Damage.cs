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
            else if(type == Skill.SkillType.Defense)
            {
                Player.player.def += Skill.characterSkill[skillnumb].skillDamage;
            }
            else if(type == Skill.SkillType.DefensePercent)
            {
                Player.player.def += Player.player.def * Skill.characterSkill[skillnumb].skillDamage / 100;
            }
            else if (type == Skill.SkillType.Heal)
            {
                Player.player.hp += Skill.characterSkill[skillnumb].skillDamage;
            }
            else if (type == Skill.SkillType.HealPercent)
            {
                Player.player.hp += Player.player.hp * Skill.characterSkill[skillnumb].skillDamage / 100;
            }
            else if (type == Skill.SkillType.Support)
            {
                
            }
            else
            {
                
            }

            return 0;
            
        }
    }
}
