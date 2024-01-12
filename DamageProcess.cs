using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    public class DamageProcess
    {        
        public int victim(int atk, int hp, out int isDamage, out bool enemyAvoidanceTrue, out bool enemyCriticalTrue)
        {
            isDamage = atk - Player.player.def;

            enemyAvoidanceTrue = false;
            int enemyAvoidance = BattleScene.Avoidance(isDamage, ref enemyAvoidanceTrue);

            enemyCriticalTrue = false;
            int enemyCritical = BattleScene.Critical(isDamage, ref enemyCriticalTrue);

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

        public int Victim(List<Enemy> enemies, int num, int atk, int hp, out int isDamage, out bool criticalTrue, out bool avoidanceTrue)
        {
            double MinDmg = Math.Round((double)Player.player.atk * 0.9);
            double MaxDmg = Math.Round((double)Player.player.atk * 1.1);

            atk = new Random().Next((int)MinDmg, (int)MaxDmg);
            isDamage = atk;
            criticalTrue = false;
            int criticalAtk = BattleScene.Critical(isDamage, ref criticalTrue);

            avoidanceTrue = false;
            int avoidanceAtk = BattleScene.Avoidance(isDamage, ref avoidanceTrue);

            if (criticalTrue == true && avoidanceTrue == false)
            {
                isDamage = criticalAtk;
                hp -= isDamage;
            }
            else if (avoidanceTrue == true && criticalTrue == false)
            {
                isDamage = avoidanceAtk;
                hp -= isDamage;                
            }
            else
            {
                hp -= isDamage;
            }

            if (hp < 0)
            {
                hp = 0;
            }

            if (hp == 0)
            {
                enemies[num - 1].alive = false;
            }

            return hp;
        }
    }
}
