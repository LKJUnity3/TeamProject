using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    internal class Enemy : stat
    {
        public bool alive { get; set; }
        public Enemy(string name,int lv,int atk,int hp) 
        {
            this.Name = name;
            this.lv = lv;
            this.atk = atk;
            this.hp = hp;
            alive = true;
        }
        public int Victim(int atk, int hp, out int isDamage, out bool criticalTrue,out bool avoidanceTrue)
        {
            double MinDmg = Math.Round((double)Player.player.atk * 0.9);
            double MaxDmg = Math.Round((double)Player.player.atk * 1.1);

            atk = new Random().Next((int)MinDmg, (int)MaxDmg);
            isDamage = atk;
            criticalTrue = false;
            int criticalAtk = BattleScene.Critical(atk, ref criticalTrue);

            avoidanceTrue = false;
            int avoidanceAtk = BattleScene.Avoidance(atk, ref avoidanceTrue);
            
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
            
            if (hp < 0)
            {
                hp = 0;
            }
            if (hp == 0)
            {
                alive = false;
            }

            return hp;
        }
        public static List<Enemy> EnemySetting()
        {
            List<Enemy> enemies = new List<Enemy>();
            Random random = new Random();
            int Monster_count = random.Next(1, 5);
            for (int i = 0; i < Monster_count; i++)
            {
                int Monster_type = random.Next(0, 3);
                switch (Monster_type)
                {
                    case 0:
                        Enemy Minion = new Enemy("미니언", 2, 5, 15);
                        enemies.Add(Minion);
                        break;
                    case 1:
                        Enemy Canon_Minion = new Enemy("대포 미니언", 5, 10, 25);
                        enemies.Add(Canon_Minion);
                        break;
                    case 2:
                        Enemy Abyss = new Enemy("공허충", 3, 9, 10);
                        enemies.Add(Abyss);
                        break;
                }
            }
            return enemies;
        }
    }
}
