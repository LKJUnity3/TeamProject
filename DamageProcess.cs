using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    public class DamageProcess
    {
        public static double skillMinDamage;
        public static double skillMaxDamage;

        public static int SkillEffect(Skill.SkillType type, int skillnumb)
        {
            Random rand = new Random();

            if (type == Skill.SkillType.Attack)
            {
                skillMinDamage = Math.Round((double)(Player.player.atk + Skill.characterSkill[skillnumb].skillDamage) * 0.9);
                skillMaxDamage = Math.Round((double)(Player.player.atk + Skill.characterSkill[skillnumb].skillDamage) * 1.1);

                int damage;
                damage = rand.Next((int)skillMinDamage, (int)skillMaxDamage);
                return damage;
            }
            else if (type == Skill.SkillType.AttackPercent)
            {
                skillMinDamage = Math.Round((double)(Player.player.atk * Skill.characterSkill[skillnumb].skillDamage) * 0.9);
                skillMaxDamage = Math.Round((double)(Player.player.atk * Skill.characterSkill[skillnumb].skillDamage) * 1.1);

                int damage;
                damage = rand.Next((int)skillMinDamage, (int)skillMaxDamage);
                return damage;
            }
            else if (type == Skill.SkillType.Defense)
            {
                Player.player.def += Skill.characterSkill[skillnumb].skillDamage;
            }
            else if (type == Skill.SkillType.DefensePercent)
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
            else if (type == Skill.SkillType.SupportAtk)
            {

            }
            else
            {
                if (Skill.characterSkill[skillnumb].skillname == "백전백승")
                {

                }

            }

            return 0;

        }
        public int Victim(int atk, int hp, out int isDamage, out bool enemyAvoidanceTrue, out bool enemyCriticalTrue)
        {
            isDamage = atk - Player.player.def;

            enemyAvoidanceTrue = false;
            int enemyAvoidance = Avoidance(isDamage, ref enemyAvoidanceTrue);

            enemyCriticalTrue = false;
            int enemyCritical = Critical(isDamage, ref enemyCriticalTrue);

            if (enemyCriticalTrue == true && enemyAvoidanceTrue == false)
            {
                isDamage = enemyCritical;
            }
            else if (enemyAvoidanceTrue == true && enemyCriticalTrue == false)
            {
                isDamage = enemyAvoidance;
            }

            if (isDamage < 0)
            {
                isDamage = 0;
            }
            hp -= isDamage;
            if (hp < 0)
            {
                hp = 0;
            }
            return hp;
        }

        public int Victim(float atk, int hp, out float isDamage, out bool criticalTrue, out bool avoidanceTrue)
        {
            double MinDmg = Math.Round((double)Player.player.atk * 0.9);
            double MaxDmg = Math.Round((double)Player.player.atk * 1.1);

            atk = new Random().Next((int)MinDmg, (int)MaxDmg);
            isDamage = atk;
            criticalTrue = false;
            int criticalAtk = Critical((int)isDamage, ref criticalTrue);

            avoidanceTrue = false;
            int avoidanceAtk = Avoidance((int)isDamage, ref avoidanceTrue);

            if (criticalTrue == true && avoidanceTrue == false)
            {
                isDamage = criticalAtk;
                hp -= (int)isDamage;
            }
            else if (avoidanceTrue == true && criticalTrue == false)
            {
                isDamage = avoidanceAtk;
                hp -= (int)isDamage;
            }
            else
            {
                hp -= (int)isDamage;
            }

            if (hp < 0)
            {
                hp = 0;
            }            

            return hp;
        }

        public static int Avoidance(int damage, ref bool isAvoidance)
        {
            int avoidance = new Random().Next(1, 100);
            if (avoidance > 10)
            {
                isAvoidance = false;
            }
            else
            {
                isAvoidance = true;
                damage = 0;
            }

            return damage;
        }

        public static int Critical(int damage, ref bool isCritical)
        {
            int critical = new Random().Next(1, 100);
            if (critical <= 15)
            {
                isCritical = true;
                double criticalDamage = damage * 1.6;
                damage = (int)Math.Round(criticalDamage);
            }
            else
            {
                isCritical = false;
            }
            return damage;
        }
    }
}
