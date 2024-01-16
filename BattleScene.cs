using System;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TeamProject
{
    public class BattleScene
    {
        public static int Player_Extra_Avoide = 0;
        public static int Enemy_Extra_Avoide = 0;
        public static int Current_HP = 0;
        public static List<Enemy> enemies = new List<Enemy>();
        public static List<string> earnedList = new List<string>();
        public static int remainEXP = 0;             
        public static void Battle(int DungeonType)
        {
            
            bool battle = false; // 배틀선택했는지
            DamageProcess damageProcess = new DamageProcess();//damageProcess class 생성

            switch (DungeonType)//던전 타입에 따른 적 셋팅
            {
                case 0: enemies = Enemy.SamGuk_EnemySetting();break;
                case 1: enemies = Enemy.Josun_EnemySetting();break;
                case 2: enemies = Enemy.Korea_EnemySetting();break;
            }
            
            int alive = enemies.Count;
            //플레이어 변수 저장

            Current_HP = Player.player.hp;//던전 입장, player의 최대 체력 -> 현재 체력
            int current_EXP = Player.player.exp;            
            int num;

            int Current_Defense = Player.player.def;//던전 입장, player의 최대 방어력 -> 현재 방어력
            int Current_Attack = Player.player.atk;//던전 입장, player의 최대 공격력 -> 현재 공격력
            int existingGold = Player.player.Gold;//던전 입장, player의 골드
            
            // 적 변수 저장.
            int Current_enemy_hp;
            bool enemyItemDrop = false;            
            int selectDropItem = 0;    
            
            // 어태커 빅팀 정보저장
            int indexHP = 0;
            double MinDmg = Math.Round((double)Player.player.atk * 0.9);
            double MaxDmg = Math.Round((double)Player.player.atk * 1.1);
            Random random = new Random();
            BattleStart();

            //배틀을 진행하게 되면 첫 화면
            void BattleStart()
            { 
            battle:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[ Battle!! ]\n");
                Console.ResetColor();
                if (battle == false)
                {
                    for (int i = 0; i < enemies.Count; i++)
                    {
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
                    Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name + " (" + Player.player.job + ")");
                    Console.WriteLine("HP " + Current_HP + "/" + Player.player.hp);
                    Console.WriteLine("\n[1] 공격");
                    Console.WriteLine("[2] 스킬"); // kcw, 스킬 선택지 추가
                    Console.WriteLine("[3] 아이템 사용"); // 지훈 소모(포션) 아이템 선택지 추가
                    Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                }
                else if (battle == true)
                {
                    BattlePhase();
                }


                Console.Write(">>> ");
                string index = Console.ReadLine();
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
                        case 2://kcw 스킬 선택지 입력
                            if (!battle)
                            {
                                goto skillLook;
                            }
                            break;
                        case 3://kcw 스킬 선택지 입력
                            if (!battle)
                            {
                                goto itemLook;
                            }
                            break;
                        default:
                            Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                            Thread.Sleep(1000);
                            goto battle;
                    }
                }
                else
                {
                    Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                    Thread.Sleep(1000);
                    goto battle;
                }

                //스킬 선택 창
            skillLook:
                Console.Clear();
                indexHP = Current_HP;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[ Battle!! ]\n");
                Console.ResetColor();
                for (int i = 0; i < enemies.Count; i++)//적 정보 나열
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
                Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name + " (" + Player.player.job + ")");
                Console.WriteLine("\n[스킬 리스트]\n");

                //스킬 정보 나열
                for (int i = 0; i < Player.player.characterSkill.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{Player.player.characterSkill[i].skillname} | {Player.player.characterSkill[i].skillDamage} | {Player.player.characterSkill[i].skillInfo}");
                }
                Console.WriteLine("\n[0] 취소");
                Console.WriteLine("\n스킬을 선택해주세요.");
                Console.Write(">>> ");

                //스킬 선택
                index = Console.ReadLine();
                isInt = int.TryParse(index, out num);
                if (isInt)
                {
                    if (num == 0)
                    {
                        goto battle; //스킬창 취소 시 플레이어 페이지로 이동
                    }
                    else if (0 < num && num <= Player.player.characterSkill.Count)
                    {
                        SkillPhase(num - 1);

                    }
                }
                Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                Thread.Sleep(1000);
                goto skillLook;

            // 소모 아이템 사용
            itemLook:
                Console.Clear();
                indexHP = Current_HP;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[ Battle!! ]\n");
                Console.ResetColor();
                for (int i = 0; i < enemies.Count; i++)
                {
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
                Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name + " (" + Player.player.job + ")");
                Console.WriteLine("\n[소모 아이템 리스트]");
                Item.usePotions = Item.potions.Where(potion => potion.ConsumItem > 0).ToList();
                for (int i = 0; i < Item.usePotions.Count; i++)
                {
                    if (Item.usePotions[i].ConsumItem > 0) Item.usePotions[i].PrintItemStatus(false, true, i + 1);
                }
                Console.WriteLine("\n\n[0] 취소");
                Console.Write("\n사용할 아이템을 선택해주세요.\n>>> ");
                index = Console.ReadLine();
                isInt = int.TryParse(index, out num);
                if (isInt)
                {
                    if (num == 0)
                    {
                        BattleStart(); //스킬창 취소 시 플레이어 페이지로 이동
                    }
                    else if (0 < num && num <= Item.usePotions.Count)
                    {
                        Current_HP += Item.usePotions[num - 1].hp;
                        Item.usePotions[num - 1].ConsumItem--;
                        if (Current_HP > Player.player.hp) Current_HP = Player.player.hp;
                        ItemPhase();
                    }
                }
                Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                Thread.Sleep(1000);
                goto itemLook;
            }


            void BattlePhase()
            {
                if (alive <= 0)
                {
                    Battleresult();
                }

                //1라운마다 avoid 값 초기화(스킬에 따른 효과 초기화 설정)
                Player_Extra_Avoide = 0;
                Enemy_Extra_Avoide = 0;

        battlephase:
                Console.Clear();
                indexHP = Current_HP;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[ Battle!! ]\n");
                Console.ResetColor();
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
                Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name + " (" + Player.player.job + ")");
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
                            enemies[num - 1].hp = damageProcess.PlayerAttack(Player.player.atk, Current_enemy_hp, Enemy_Extra_Avoide, enemies[num-1].def, out float isDamage, out bool criticalTrue, out bool avoidanceTrue);
                            if (avoidanceTrue == true && criticalTrue == false)
                            {
                                playerPhase(num, (int)isDamage, 1);                                
                            }
                            else if (criticalTrue == true && avoidanceTrue == false)
                            {
                                playerPhase(num, (int)isDamage, 2);
                            }
                            else
                            {
                                playerPhase(num, (int)isDamage, 3);
                            }
                        } 

                    }
                }
                Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                Thread.Sleep(1000);
                goto battlephase;
            }
            void SkillPhase(int skillnumber) //kcw 스킬 페이지
            {
                if (Player.player.characterSkill[skillnumber].skilltype == Skill.SkillType.Attack)//공격 스킬 선택
                {
                    goto skillphaseSelectEnemy;
                }
                else if(Player.player.characterSkill[skillnumber].skilltype == Skill.SkillType.AttackPercent)//공격% 스킬 선택
                {
                    goto skillphaseSelectEnemy;
                }
                else
                {
                    goto skillResult;
                }


            skillphaseSelectEnemy:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[ Battle!! ]\n");
                Console.ResetColor();
                for (int i = 0; i < enemies.Count; i++)
                {
                    Console.Write((i + 1) + " ");
                    if (enemies[i].alive)
                    {
                        Console.WriteLine("Lv." + enemies[i].lv + " " + enemies[i].Name + " HP " + enemies[i].hp);
                    }
                    else//적이 죽으면 hp 대신 Dead 표시
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Lv." + enemies[i].lv + " " + enemies[i].Name + " Dead ");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine("");
                Console.WriteLine("[내정보]");
                Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name + " (" + Player.player.job + ")");
                Console.WriteLine("\n[선택된 스킬 정보]");
                Console.WriteLine($"{Player.player.characterSkill[skillnumber].skillname} | {Player.player.characterSkill[skillnumber].skillDamage} | {Player.player.characterSkill[skillnumber].skillInfo}");
                Console.WriteLine("\n\n[0] 취소");
                Console.WriteLine("\n스킬 공격할 대상을 선택해주세요.");
                Console.Write(">>> ");

                //공격 스킬 이용 대상 선택
                string index = Console.ReadLine();
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
                            goto skillResult;
                        }
                        else
                        {
                            goto skillphaseSelectEnemy;
                        }

                    }
                }
                Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                Thread.Sleep(1000);
                goto skillphaseSelectEnemy;


                //스킬 효과 발현 UI
            skillResult:
                Console.Clear();
                Console.WriteLine("[스킬 발현]\n");
                Console.WriteLine("");
                Console.WriteLine("\n[사용한 스킬]");
                Console.WriteLine($"{Player.player.characterSkill[skillnumber].skillname} | {Player.player.characterSkill[skillnumber].skillDamage} | {Player.player.characterSkill[skillnumber].skillInfo}\n");


                //skill 효과에 따른 적용 및 UI 표시
                if (Player.player.characterSkill[skillnumber].skilltype == Skill.SkillType.Attack || Player.player.characterSkill[skillnumber].skilltype == Skill.SkillType.AttackPercent)
                {
                    //스킬 데미지 계산 -> atk에 입력
                    int atk = DamageProcess.SkillAttackEffect(Player.player.characterSkill[skillnumber].skilltype, skillnumber);
                    Current_enemy_hp = enemies[num - 1].hp;
                    enemies[num - 1].Victim(atk);

                    //스킬 데미지 적용 표현
                    Console.WriteLine($"{Player.player.characterSkill[skillnumber].skillname}으로 공격!");
                    Console.WriteLine($"Lv.{enemies[num - 1].lv} {enemies[num - 1].Name}가 {atk} 데미지를 받았습니다");
                    if (enemies[num - 1].hp <= 0)
                    {
                        Console.Write($"HP {Current_enemy_hp} -> ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine("Dead");
                        Console.ResetColor();
                        Player.player.exp += enemies[num - 1].lv;
                        if (Player.player.exp > Player.player.fullExp)
                        {
                            int fullE = Player.player.fullExp;
                            int e = Player.player.exp;
                            remainEXP = e - fullE;
                            Player.player.exp = Player.player.fullExp;
                        }
                        Player.player.Gold += enemies[num - 1].dropGold;
                        Enemy.ItemDrop();
                    }
                    else
                    { 
                        Console.WriteLine($"HP {Current_enemy_hp} -> {enemies[num - 1].hp}");
                    }
                }
                else if (Player.player.characterSkill[skillnumber].skilltype == Skill.SkillType.Defense || Player.player.characterSkill[skillnumber].skilltype == Skill.SkillType.DefensePercent)
                {
                    DamageProcess.SkillEffect(Player.player.characterSkill[skillnumber].skilltype, skillnumber);

                    Console.WriteLine($"{Player.player.characterSkill[skillnumber].skillname}!!");
                    Console.WriteLine($"방어 스탯 변화 : {Current_Defense} ->{Player.player.def}");

                }
                else if (Player.player.characterSkill[skillnumber].skilltype == Skill.SkillType.Heal || Player.player.characterSkill[skillnumber].skilltype == Skill.SkillType.HealPercent)
                {
                    DamageProcess.SkillEffect(Player.player.characterSkill[skillnumber].skilltype, skillnumber);
                }
                else if (Player.player.characterSkill[skillnumber].skilltype == Skill.SkillType.SupportAtk || Player.player.characterSkill[skillnumber].skilltype == Skill.SkillType.SupportDef || Player.player.characterSkill[skillnumber].skilltype == Skill.SkillType.SupportHP)
                {
                    DamageProcess.SkillEffect(Player.player.characterSkill[skillnumber].skilltype, skillnumber);
                }
                else //특수 스킬
                {
                    DamageProcess.SkillEffect(Player.player.characterSkill[skillnumber].skilltype, skillnumber);
                }

                Console.WriteLine("\n[내정보]");
                Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name + " (" + Player.player.job + ")");

                //적 죽음, 변수 감소
                for(int i=0; i<enemies.Count; i++)
                {
                    if (enemies[i].hp <=0)
                    {
                        enemies[i].alive = false;
                        alive--;
                    }
                }

                Console.WriteLine("\n\n[0] 다음");
                Console.WriteLine("\n원하는 행동을 선택해주세요.");
                Console.Write(">>> ");
                index = Console.ReadLine();
                isInt = int.TryParse(index, out num);
                if(isInt)
                {
                    if(num ==0)
                    {
                        EnemyPhase();
                    }
                    else
                    {
                        Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                        Thread.Sleep(1000);
                        goto skillResult;
                    }
                }
                else
                {
                    Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                    Thread.Sleep(1000);
                    goto skillResult;
                }
            }


            // 소모 아이템 페이지
            void ItemPhase()
            {
            itemPhase:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[ Battle!! ]\n");
                Console.ResetColor();
                for (int i = 0; i < enemies.Count; i++)
                {
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
                Console.ForegroundColor= ConsoleColor.Green;
                Console.WriteLine("\n회복 아이템을 사용 하였습니다.");
                Console.ResetColor();
                Console.WriteLine("[내정보]");
                Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name + " (" + Player.player.job + ")");
                Console.WriteLine("HP " + indexHP + " -> " + Current_HP + ((Current_HP - indexHP) > 0 ? $"(+{Current_HP - indexHP})" : ""));
                Console.WriteLine("\n\n[0] 다음");
                Console.Write("\n원하는 행동을 선택해주세요.\n>>> ");
                string index = Console.ReadLine();
                bool isInt = int.TryParse(index, out num);
                if (isInt)
                {
                    switch (num)
                    {
                        case 0:
                            EnemyPhase();
                            break;
                        default:
                            Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                            Thread.Sleep(1000);
                            goto itemPhase;
                    }
                }
                Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                Thread.Sleep(1000);
                goto itemPhase;
            }


            void playerPhase(int enemy_list,int atk, int avoidanceOrcri)
            {
            playerPhase:
                Console.Clear();
                int number = enemy_list - 1;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[ Battle!! ]\n");
                Console.ResetColor();
                Console.WriteLine("\n" + Player.player.Name + "의 공격!");
                if (avoidanceOrcri == 1)
                {
                    Console.WriteLine("Lv." + enemies[number].lv + " " + enemies[number].Name + " 을(를) 못맞췄습니다. [데미지 : " + atk + "] - 회피");
                }
                else if (avoidanceOrcri == 2)
                {
                    Console.WriteLine("Lv." + enemies[number].lv + " " + enemies[number].Name + " 의 급소를 맞췄습니다. [데미지 : " + atk + "] - 치명타");
                }
                else if (avoidanceOrcri == 3)
                {
                    Console.WriteLine("Lv." + enemies[number].lv + " " + enemies[number].Name + " 을(를) 맞췄습니다. [데미지 : " + atk + "]");
                }
                Console.WriteLine("\nLv." + enemies[number].lv + " " + enemies[number].Name);
                if (enemies[number].hp == 0)
                {
                    enemies[number].alive = false;
                }

                if (enemies[number].alive)
                {
                    Console.WriteLine("HP " + Current_enemy_hp + " -> " + enemies[number].hp);
                }
                else
                {
                    Console.WriteLine("HP " + Current_enemy_hp + " -> " + "Dead");
                    Player.player.exp += enemies[number].lv;
                    if(Player.player.exp > Player.player.fullExp)
                    {
                        int fullE = Player.player.fullExp;
                        int e = Player.player.exp;
                        remainEXP = e - fullE;
                        Player.player.exp = Player.player.fullExp;
                    }                    
                    Player.player.Gold += enemies[number].dropGold;                    
                    Enemy.ItemDrop();                                        
                    alive--;
                }
                Console.WriteLine("\n[0] 다음");
                Console.WriteLine("\n원하는 행동을 입력해주세요.");
                Console.Write(">>> ");
                string index = Console.ReadLine();
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
                    Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                    Thread.Sleep(1000);
                    goto playerPhase;
                }
            }
            void EnemyPhase()
            {
                battle = false;
                if (alive <= 0)
                {
                    Battleresult();
                }

                enemy:
                Console.Clear();
                Random random = new Random();
                int number = random.Next(0, enemies.Count);
                if (!enemies[number].alive)
                {
                    goto enemy;
                }
                int lastHP = damageProcess.EnemyAttack((int)enemies[number].atk, Current_HP, Player_Extra_Avoide, out int isDmg, out bool enemyAvoidanceTrue, out bool enemyCriticalTrue);
                if (isDmg < 0)
                {
                    isDmg = 0;
                }
            enemyPhase:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[ Battle!! ]\n");
                Console.ResetColor();
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
                    Console.WriteLine("HP " + Current_HP + " -> " + lastHP);
                    
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
                Player.player.def = Current_Defense; // kcw 만약 스킬을 사용했으면 다음 플레이어 턴에 방어력 복귀
                bool isInt = int.TryParse(index, out num);
                if (isInt)
                {
                    switch (num)
                    {
                        case 0:
                            BattleStart();
                            break;
                        default:
                            Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                            Thread.Sleep(1000);
                            goto enemyPhase;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                    Thread.Sleep(1000);
                    goto enemyPhase;
                }
                Current_HP = lastHP;
            }
            void Battleresult()
            {
                

            Battleresult:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("[ Battle!! - Result ]\n");
                Console.ResetColor();
                if (alive <= 0)
                {
                    Console.WriteLine("Victory");
                    Console.WriteLine("\n던전에서 몬스터 " + enemies.Count + "마리를 잡았습니다.");
                    while (Player.player.fullExp == Player.player.exp)
                    {
                        Console.WriteLine("\nLv." + Player.player.lv + " " + Player.player.Name + " -> " + "Lv." + (Player.player.lv + 1) + " " + Player.player.Name);
                        Player.LevelUp();
                        Player.player.exp = 0;
                        Player.player.exp += remainEXP;
                        remainEXP = 0;
                        if(Player.player.exp > Player.player.fullExp)
                        {
                            int fullE = Player.player.fullExp;
                            int e = Player.player.exp;
                            remainEXP += e - fullE;
                            Player.player.exp = Player.player.fullExp;
                            if(Player.player.fullExp == Player.player.exp)
                            {
                                Console.WriteLine("\nLv." + Player.player.lv + " " + Player.player.Name + " -> " + "Lv." + (Player.player.lv + 1) + " " + Player.player.Name);
                                Player.LevelUp();
                                Player.player.exp = 0;
                                Player.player.exp += remainEXP;
                                remainEXP = 0;
                            }                            
                        }
                    }
                    if(Player.player.fullExp != Player.player.exp)
                    {
                        Console.WriteLine("\nLv." + Player.player.lv + " " + Player.player.Name);
                    }                    
                    Console.WriteLine("HP " + Player.player.hp + " -> " + Current_HP);
                    Console.WriteLine("exp " + current_EXP + " -> " + Player.player.exp);
                    Console.WriteLine();
                    Console.WriteLine("[획득 아이템]");
                    Console.WriteLine(Player.player.Gold - existingGold + " Gold");                    
                    foreach(string earnItem in earnedList)
                    {
                        Console.WriteLine(earnItem + " - 1");
                    }
                    earnedList.Clear();
                    //stage가 종료되면 스킬로 적용된 스탯 변화 다시 되돌림
                    Player.player.atk = Current_Attack;
                    Player.player.def = Current_Defense;
                }
                else if (Current_HP <= 0)
                {
                    Console.WriteLine("You Lose");
                    Console.WriteLine("\nLv." + Player.player.lv + " " + Player.player.Name);
                    Console.WriteLine("HP " + Player.player.hp + " -> " + Current_HP);
                }
                Console.WriteLine("\n[0] 다음");
                Console.Write("\n>>> ");
                string index = Console.ReadLine();
                int num;
                bool isInt = int.TryParse(index, out num);
                if (isInt)
                {
                    switch (num) { case 0: Program.dungeonSound1 = false; Program.dungeonSound2 = false; Program.dungeonSound3 = false; Scene.StartScene(); break; 
                        default:
                            Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                            Thread.Sleep(1000);
                            goto Battleresult; }
                }
                else
                {
                    Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                    Thread.Sleep(1000);
                    goto Battleresult;
                }
            }
        }
    }
}
