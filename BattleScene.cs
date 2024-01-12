﻿namespace TeamProject
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
            bool Phase = false; // 배틀페이지에 들어갔는지
            bool result = false;  //결과값에 들어갔는지
            List<Enemy> enemies = new List<Enemy>();
            enemies = Enemy.EnemySetting();
            int alive = enemies.Count;
            //플레이어 변수 저장
            int Current_HP = Player.player.hp;
            // 적 변수 저장.
            int Current_enemy_hp;
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
                Console.WriteLine("\n[1] 공격");
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            }
            else
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    Console.Write((i+1) + " ");
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
                Console.WriteLine("\n[0] 취소");
                Console.WriteLine("\n대상을 선택해주세요.");
            }

        }
    }
}
