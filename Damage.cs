using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    internal class Damage
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
    }
}
