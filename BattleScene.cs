using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Data.Common;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TeamProject
{
    public class BattleScene
    {
        public static void Battle()
        {
            /*  int CurrentHP = Player.player.hp;
              List<Enemy> enemies = new List<Enemy>();
              enemies = Enemy.EnemySetting();
              int Alive_count = enemies.Count;

              BattleDefualt();

              void BattleDefualt()
              {
              reBattleDefault:
                  Console.Clear();
                  Console.WriteLine("Battle!!");
                  Console.WriteLine("");
                  for (int i = 0; i < enemies.Count; i++)
                  {
                      Console.Write("Lv." + enemies[i].lv + " " + enemies[i].Name);
                      if (enemies[i].alive)
                      {
                          Console.WriteLine(" HP " + enemies[i].hp);
                      }
                      else
                      {
                          Console.WriteLine(" Dead ");
                      }
                  }
                  Console.WriteLine("\n[내정보]");
                  Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name + " (" + Player.player.Name + ")");
                  Console.WriteLine("HP " + CurrentHP + "/" + Player.player.hp);

                  Console.WriteLine("\n[1] 공격\n");
                  Console.Write("원하시는 행동을 입력해주세요.\n>>> ");
                  string index = Console.ReadLine();
                  int num;
                  bool isInt = int.TryParse(index, out num);
                  if (isInt)
                  {
                      if (num == 1)
                      {
                          BattleInCount();
                      }
                      else
                      {
                          Console.WriteLine("잘못 입력하셨습니다.");
                          Thread.Sleep(500);
                          goto reBattleDefault;
                      }
                  }
              }
              void BattleInCount()
              {
              Battleincount:
                  Console.Clear();
                  Console.WriteLine("Battle!!");
                  Console.WriteLine("");
                  for (int i = 0; i < enemies.Count; i++)
                  {
                      Console.Write((i + 1) + " - ");
                      Console.Write("Lv." + enemies[i].lv + " " + enemies[i].Name);
                      if (enemies[i].alive)
                      {
                          Console.WriteLine(" HP " + enemies[i].hp);
                      }
                      else
                      {
                          Console.WriteLine(" Dead ");
                      }
                  }
                  Console.WriteLine("\n[내정보]");
                  Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name + " (" + Player.player.Job + ")");
                  Console.WriteLine("HP " + CurrentHP + "/" + Player.player.hp);

                  Console.WriteLine("\n[0] 취소\n");
                  Console.Write("대상을 선택해주세요.\n>>> ");
                  string index = Console.ReadLine();
                  int num;
                  bool isInt = int.TryParse(index, out num);
                  if (isInt)
                  {
                      if (num == 0)
                      {

                      }
                      else if (0 < num && num <= enemies.Count)
                      {
                          if (!enemies[num - 1].alive)
                          {
                              Console.WriteLine("잘못 입력하셨습니다.");
                              Thread.Sleep(500);
                              goto Battleincount;
                          }
                          BattlePhase(num);
                      }
                      else
                      {
                          Console.WriteLine("잘못 입력하셨습니다.");
                          Thread.Sleep(500);
                          goto Battleincount;
                      }
                  }
              }

              void BattlePhase(int num)
              {
                  Console.Clear();
                  Console.WriteLine("Battle!!");
                  Console.WriteLine("");
                  Console.WriteLine(Player.player.Name + " 의 공격!");
                  Console.WriteLine("Lv." + enemies[num - 1].lv + " " + enemies[num - 1].Name + " 을(를) 맞췄습니다. [데미지 : " + Player.player.atk + "]");
                  Console.WriteLine("Lv." + enemies[num - 1].lv + " " + enemies[num - 1].Name);
                  Console.Write("HP " + enemies[num - 1].hp + " -> ");
                  enemies[num - 1].Victim(Player.player.atk);
                  if (enemies[num - 1].alive)
                  {
                      Console.WriteLine(enemies[num - 1].hp);
                  }
                  else
                  {
                      Console.WriteLine("Dead");
                      --Alive_count;
                  }
                  Console.WriteLine("\n[0] 다음\n");
                  Console.Write("원하시는 행동을 입력해주세요.\n>>> ");
                  string index = Console.ReadLine();
                  bool isInt = int.TryParse(index, out num);
                  if (isInt)
                  {
                      if (num == 0)
                      {
                          if (Alive_count == 0)
                          {
                              BattleResualt();
                          }
                          else
                          {
                              BattleInCount();
                          }
                      }
                      else
                      {
                          Console.WriteLine("잘못 입력하셨습니다.");

                      }
                  }
              }
              void EnemyPhase(int num)
              {
                  Console.Clear();
                  Console.WriteLine("Battle!!");
                  Console.WriteLine("");
                  Console.WriteLine("Lv." + enemies[num - 1].lv + " " + enemies[num - 1].Name + " 의 공격!");
                  Console.WriteLine(Player.player.Name + " 을(를) 맞췄습니다. [데미지 : " + enemies[num - 1].atk + "]");
                  Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name);
                  Console.Write("HP " + CurrentHP + " -> ");
                  CurrentHP = Player.player.victim(enemies[num - 1].atk, CurrentHP);
                  if (CurrentHP == 0)
                  {
                      BattleResualt();
                  }
                  else
                  {
                      Console.WriteLine(CurrentHP);
                  }
                  Console.WriteLine("\n[0] 다음\n");
                  Console.Write("원하시는 행동을 입력해주세요.\n>>> ");
                  string index = Console.ReadLine();
                  bool isInt = int.TryParse(index, out num);
                  if (isInt)
                  {
                      if (num == 0)
                      {
                          BattleInCount();
                      }
                      else
                      {
                          Console.WriteLine("잘못 입력하셨습니다.");
                      }
                  }
              }
              void BattleResualt()
              {
              BattleResualt:
                  string index;
                  int num;
                  bool isInt;
                  Console.Clear();
                  Console.WriteLine("Battle!! - Result");
                  Console.WriteLine("");
                  if (CurrentHP <= 0)
                  {
                      Console.WriteLine("You Lose");
                      Console.WriteLine("\nLv." + Player.player.lv + " " + Player.player.Name);
                      Console.Write("HP " + Player.player.hp + " -> " + CurrentHP);
                      Console.WriteLine("\n[0] 다음\n");
                      Console.Write("원하시는 행동을 입력해주세요.\n>>> ");
                      index = Console.ReadLine();
                      isInt = int.TryParse(index, out num);
                      if (isInt)
                      {
                          if (num == 0)
                          {

                          }
                          else
                          {
                              Console.WriteLine("잘못 입력하셨습니다.");
                              Thread.Sleep(600);
                              goto BattleResualt;
                          }
                      }
                  }
                  else
                  {
                      Console.WriteLine("Victory");
                      Console.WriteLine("\n던전에서 몬스터 " + enemies.Count + " 마리를 잡았습니다.");
                      Console.WriteLine("\nLv." + Player.player.lv + " " + Player.player.Name);
                      Console.Write("HP " + Player.player.hp + " -> " + CurrentHP);
                      Console.WriteLine("\n[0] 다음\n");
                      Console.Write("원하시는 행동을 입력해주세요.\n>>> ");
                      index = Console.ReadLine();
                      isInt = int.TryParse(index, out num);
                      if (isInt)
                      {
                          if (num == 0)
                          {
                              Scene.StartScene();
                          }
                          else
                          {
                              Console.WriteLine("잘못 입력하셨습니다.");
                              Thread.Sleep(600);
                              goto BattleResualt;
                          }
                      }

                  }
              }*/
            bool battle = false; // 배틀선택했는지
            List<Enemy> enemies = new List<Enemy>();
            DamageProcess damageProcess = new DamageProcess();
            enemies = Enemy.EnemySetting();
            int alive = enemies.Count;
            //플레이어 변수 저장
            int Current_HP = Player.player.hp;
            // 적 변수 저장.
            int Current_enemy_hp;
            // 어태커 빅팀 정보저장
            int indexHP = 0;             
            //double MinDmg = Math.Round((double)Player.player.atk * 0.9);
            //double MaxDmg = Math.Round((double)Player.player.atk * 1.1);
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
                            Current_enemy_hp = enemies[num - 1].hp;                            
                            enemies[num - 1].hp = damageProcess.Victim(enemies, num, Player.player.atk, Current_enemy_hp,out int isDamage, out bool criticalTrue, out bool avoidanceTrue);
                            if (avoidanceTrue == true && criticalTrue == false)
                            {
                                playerPhase(num, isDamage, 1);
                            }
                            else if (criticalTrue == true && avoidanceTrue == false)
                            {
                                playerPhase(num, isDamage, 2);
                            }
                            else
                            {
                                playerPhase(num, isDamage, 3);
                            }
                        }                        

                    }
                }
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(600);
                goto battlephase;
            }
            void playerPhase(int enemy_list,int atk,int avoidanceOrcri)
            {
            playerPhase:
                
                Console.Clear();
                int number = enemy_list - 1;
                Console.WriteLine("Battle!!");
                Console.WriteLine("\n" + Player.player.Name + "의 공격!");
                if(avoidanceOrcri == 1)
                {
                    Console.WriteLine("Lv." + enemies[number].lv + " " + enemies[number].Name + " 을(를) 못맞췄습니다. [데미지 : " + atk + "] - 회피");
                }
                else if(avoidanceOrcri == 2)
                {
                    Console.WriteLine("Lv." + enemies[number].lv + " " + enemies[number].Name + " 의 급소를 맞췄습니다. [데미지 : " + atk + "] - 치명타");
                }
                else if(avoidanceOrcri == 3)
                {
                    Console.WriteLine("Lv." + enemies[number].lv + " " + enemies[number].Name + " 을(를) 맞췄습니다. [데미지 : " + atk + "]");
                }                
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
                Current_HP = damageProcess.victim(enemies[number].atk, Current_HP, out int isDmg, out bool enemyAvoidanceTrue, out bool enemyCriticalTrue);
                if (isDmg < 0)
                {
                    isDmg = 0;
                }
                Console.WriteLine("Battle!!");
                Console.WriteLine("Lv." + enemies[number].lv + " " + enemies[number].Name + "의 공격!");
                if (enemyCriticalTrue == true && enemyAvoidanceTrue == false)
                {
                    Console.WriteLine(Player.player.Name + " 의 급소를 맞췄습니다. [데미지 : " + isDmg + "] - 치명타");
                }
                else if (enemyAvoidanceTrue == true && enemyCriticalTrue == false)
                {
                    Console.WriteLine(Player.player.Name + " 을(를) 못맞췄습니다. [데미지 : " + isDmg + "] - 회피");
                }
                else
                {
                    Console.WriteLine(Player.player.Name + " 을(를) 맞췄습니다. [데미지 : " + isDmg + "]");
                }                
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

        public static int Avoidance(int damage,ref bool isAvoidance)
        {
            int avoidance = new Random().Next(1, 100);
            if (avoidance >= 10)
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

        public static int Critical(int damage,ref bool isCritical)
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
