namespace TeamProject
{
    public class BattleScene
    {
        public static void Battle()
        {
            bool battle = false; // 배틀선택했는지
            List<Enemy> enemies = new List<Enemy>();
            enemies = Enemy.EnemySetting();
            int alive = enemies.Count;
            //플레이어 변수 저장
            int Current_HP = Player.player.hp;
            // 적 변수 저장.
            int Current_enemy_hp;
            // 어태커 빅팀 정보저장
            int indexHP = 0;
            double DmgPersent = Math.Round(((double)Player.player.atk * 0.1d));
            double MinDmg = Math.Round((double)Player.player.atk - DmgPersent);
            double MaxDmg = Math.Round((double)Player.player.atk + DmgPersent);
            Random random = new Random();
            
        battle:
            Console.Clear();
            Console.WriteLine("Battle!!\n");
            if (!battle)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].alive)
                    {
                        Console.WriteLine("Lv." + enemies[i].lv + " " + enemies[i].Name + " HP " + enemies[i].hp);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("Lv." + enemies[i].lv + " " + enemies[i].Name + " Dead ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("[내정보]");
                Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name + " (" + Player.player.Job + ")");
                Console.WriteLine("HP " + Current_HP + "/" + Player.player.hp);
                Console.WriteLine("\n[1] 공격");
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            }
            else
            {
                BattlePhase();
            }
            Console.Write(">>> ");
            string index = Console.ReadLine();
            int num;
            bool isInt = int.TryParse(index, out num);
            if (isInt)
            {
                switch (num)
                {
                    case 1:
                        if (!battle)
                        {
                            battle = true;
                            goto battle;
                        }
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(600);
                        goto battle;
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(600);
                goto battle;
            }

            void BattlePhase()
            {
                if (alive <= 0)
                {
                    Battleresult();
                }

            battlephase:
                Console.Clear();
                indexHP = Current_HP;
                Console.WriteLine("Battle!!\n");
                for (int i = 0; i < enemies.Count; i++)
                {
                    Console.Write((i + 1) + " ");
                    if (enemies[i].alive)
                    {
                        Console.WriteLine("Lv." + enemies[i].lv + " " + enemies[i].Name + " HP " + enemies[i].hp);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Lv." + enemies[i].lv + " " + enemies[i].Name + " Dead ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("[내정보]");
                Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name + " (" + Player.player.Job + ")");
                Console.WriteLine("\n[0] 취소");
                Console.WriteLine("\n대상을 선택해주세요.");
                Console.Write(">>> ");
                string index = Console.ReadLine();
                int num;
                bool isInt = int.TryParse(index, out num);
                if (isInt)
                {
                    if (num == 0)
                    {

                        EnemyPhase();
                    }
                    else if (0 < num && num <= enemies.Count)
                    {
                        if (enemies[num - 1].alive)
                        {
                            int atk = random.Next((int)MinDmg, (int)MaxDmg);
                            Current_enemy_hp = enemies[num - 1].hp;
                            enemies[num - 1].Victim(atk);
                            playerPhase(num,atk);
                        }
                        else
                        {

                        }

                    }
                }
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(600);
                goto battlephase;
            }
            void playerPhase(int enemy_list,int atk)
            {
            playerPhase:
                Console.Clear();
                int number = enemy_list - 1;
                Console.WriteLine("Battle!!");
                Console.WriteLine("\n" + Player.player.Name + "의 공격!");
                Console.WriteLine("Lv." + enemies[number].lv + " " + enemies[number].Name + " 을(를) 맞췄습니다. [데미지 : " + atk + "]");
                Console.WriteLine("\nLv." + enemies[number].lv + " " + enemies[number].Name);
                if (enemies[number].alive)
                {
                    Console.WriteLine("HP " + Current_enemy_hp + " -> " + enemies[number].hp);
                }
                else
                {
                    Console.WriteLine("HP " + Current_enemy_hp + " -> " + "Dead");
                    alive--;
                }
                Console.WriteLine("\n[0] 다음");
                Console.WriteLine("\n원하는 행동을 입력해주세요.");
                Console.Write(">>> ");
                string index = Console.ReadLine();
                int num;
                bool isInt = int.TryParse(index, out num);
                if (isInt)
                {
                    switch (num)
                    {
                        case 0:
                            EnemyPhase();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(600);
                    goto playerPhase;
                }
            }
            void EnemyPhase()
            {
            enemyPhase:
                if (alive <= 0)
                {
                    Battleresult();
                }
                Console.Clear();
                Random random = new Random();
                int number = random.Next(0, enemies.Count);
                if (!enemies[number].alive)
                {
                    goto enemyPhase;
                }
                int isDmg = enemies[number].atk - Player.player.def;
                if (isDmg < 0)
                {
                    isDmg = 0;
                }
                Current_HP = Player.player.victim(enemies[number].atk, Current_HP);
                Console.WriteLine("Battle!!");
                Console.WriteLine("Lv." + enemies[number].lv + " " + enemies[number].Name + "의 공격!");
                Console.WriteLine(Player.player.Name + " 을(를) 맞췄습니다. [데미지 : " + isDmg + "]");
                Console.WriteLine("\nLv." + Player.player.lv + " " + Player.player.Name);
                if (Current_HP > 0)
                {
                    Console.WriteLine("HP " + indexHP + " -> " + Current_HP);
                }
                else
                {
                    Console.WriteLine("HP " + Current_HP + " -> " + "Dead");
                    Battleresult();
                }
                Console.WriteLine("\n[0] 다음");
                Console.WriteLine("\n원하는 행동을 입력해주세요.");
                Console.Write(">>> ");
                string index = Console.ReadLine();
                int num;
                bool isInt = int.TryParse(index, out num);
                if (isInt)
                {
                    switch (num)
                    {
                        case 0:
                            BattlePhase();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(600);
                    goto enemyPhase;
                }
            }
            void Battleresult()
            {
                Console.Clear();

            Battleresult:
                Console.WriteLine("Battle!! - Result");
                if (alive <= 0)
                {
                    Console.WriteLine("Victory");
                    Console.WriteLine("\n던전에서 몬스터 " + enemies.Count + "마리를 잡았습니다.");
                    Console.WriteLine("\nLv." + Player.player.lv + " " + Player.player.Name);
                    Console.WriteLine("HP " + Player.player.hp + " -> " + Current_HP);
                }
                else if (Current_HP <= 0)
                {
                    Console.WriteLine("You Lose");
                    Console.WriteLine("\nLv." + Player.player.lv + " " + Player.player.Name);
                    Console.WriteLine("HP " + Player.player.hp + " -> " + Current_HP);
                }
                else { }
                Console.WriteLine("\n[0] 다음");
                Console.Write("\n>>> ");
                string index = Console.ReadLine();
                int num;
                bool isInt = int.TryParse(index, out num);
                if (isInt)
                {
                    switch (num) { case 0: Scene.StartScene(); break; default: break; }
                }
                else
                {
                    goto Battleresult;
                }
            }
        }
    }
}
