namespace TeamProject
{
    public class BattleScene
    {
        public static void Battle()
        {
            bool battle = false; // 배틀선택했는지
            bool skill = false; //kcw 스킬 선택 확인 변수
            List<Enemy> enemies = new List<Enemy>();
            enemies = Enemy.EnemySetting();
            int alive = enemies.Count;
            //플레이어 변수 저장
            int Current_HP = Player.player.hp;
            int Current_Defense = Player.player.def;
            int Current_Attack = Player.player.atk;
            // 적 변수 저장.
            int Current_enemy_hp;
            // 어태커 빅팀 정보저장
            int indexHP = 0;
            double MinDmg = Math.Round((double)Player.player.atk * 0.9);
            double MaxDmg = Math.Round((double)Player.player.atk * 1.1);
            Random random = new Random();
        battle:
            Console.Clear();
            Console.WriteLine("Battle!!\n");
            if (battle == false && skill==false )
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
                Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name + " (" + Player.player.job + ")");
                Console.WriteLine("HP " + Current_HP + "/" + Player.player.hp);
                Console.WriteLine("\n[1] 공격");
                Console.WriteLine("[2] 스킬"); // kcw, 스킬 선택지 추가
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
            }
            else if(battle == true && skill == false)
            {
                BattlePhase();
            }
            else
            {
                goto skillLook;
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
                    case 2://kcw 스킬 선택지 입력
                        if(!battle)
                        {
                            battle = true;
                            skill = true;
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

        skillLook:
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
            Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name + " (" + Player.player.job + ")");
            Console.WriteLine("\n[스킬 리스트]\n");
            for (int i = 0; i < Skill.characterSkill.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{Skill.characterSkill[i].skillname} | {Skill.characterSkill[i].skillDamage} | {Skill.characterSkill[i].skillInfo}");
            }
            Console.WriteLine("\n[0] 취소");
            Console.WriteLine("\n대상을 선택해주세요.");
            Console.Write(">>> ");
            index = Console.ReadLine();
            isInt = int.TryParse(index, out num);
            if (isInt)
            {
                if (num == 0)
                {
                    goto battle; //스킬창 취소 시 플레이어 페이지로 이동
                }
                else if (0 < num && num <= Skill.characterSkill.Count)
                {
                    SkillPhase(num-1);

                }
            }
            Console.WriteLine("잘못된 입력입니다.");
            Thread.Sleep(600);
            goto skillLook;



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
            void SkillPhase(int skillnumber) //kcw 스킬 페이지
            {
            skillphaseSelectEnemy:
                Console.Clear();
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
                Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name + " (" + Player.player.job + ")");
                Console.WriteLine("\n[선택된 스킬 정보]");
                Console.WriteLine($"{Skill.characterSkill[skillnumber].skillname} | {Skill.characterSkill[skillnumber].skillDamage} | {Skill.characterSkill[skillnumber].skillInfo}");
                Console.WriteLine("\n\n[0] 취소");
                Console.WriteLine("\n스킬 공격할 대상을 선택해주세요.");
                Console.Write(">>> ");
                index = Console.ReadLine();
                isInt = int.TryParse(index, out num);
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
                Console.WriteLine("잘못된 입력입니다.");
                Thread.Sleep(600);
                goto skillphaseSelectEnemy;


            skillResult:
                Console.Clear();
                Console.WriteLine("스킬 발현\n");
                Console.WriteLine("");
                Console.WriteLine("\n[사용한 스킬]");
                Console.WriteLine($"{Skill.characterSkill[skillnumber].skillname} | {Skill.characterSkill[skillnumber].skillDamage} | {Skill.characterSkill[skillnumber].skillInfo}\n");


                //skill 효과 적용 추가
                //skill 데미지 추가 필요
                if (Skill.characterSkill[skillnumber].skilltype == Skill.SkillType.Attack || Skill.characterSkill[skillnumber].skilltype == Skill.SkillType.AttackPercent)
                {
                    int atk = Damage.SkillEffect(Skill.characterSkill[skillnumber].skilltype, skillnumber);
                    Current_enemy_hp = enemies[num - 1].hp;
                    enemies[num - 1].Victim(atk);
                    Console.WriteLine($"{Skill.characterSkill[skillnumber].skillname}으로 공격!");
                    Console.WriteLine($"Lv.{enemies[num - 1].lv} {enemies[num - 1].Name}가 데미지를 받았습니다");
                    Console.WriteLine($"HP {Current_enemy_hp} -> {enemies[num - 1].hp}");
                }
                else if (Skill.characterSkill[skillnumber].skilltype == Skill.SkillType.Defense || Skill.characterSkill[skillnumber].skilltype == Skill.SkillType.DefensePercent)
                {
                    int statUp = Damage.SkillEffect(Skill.characterSkill[skillnumber].skilltype, skillnumber);

                    Console.WriteLine($"{Skill.characterSkill[skillnumber].skillname}!!");
                    Console.WriteLine($"방어 스탯 변화 : {Current_Defense} ->{Player.player.def}");

                }
                else if (Skill.characterSkill[skillnumber].skilltype == Skill.SkillType.Heal || Skill.characterSkill[skillnumber].skilltype == Skill.SkillType.HealPercent)
                {
                    int hp_now = Player.player.hp;
                    int statUp = Damage.SkillEffect(Skill.characterSkill[skillnumber].skilltype, skillnumber);

                    Console.WriteLine($"{Skill.characterSkill[skillnumber].skillname}!!");
                    Console.WriteLine($"체력 스탯 변화 : {hp_now} ->{Player.player.hp}");
                }
                else if (Skill.characterSkill[skillnumber].skilltype == Skill.SkillType.Support)
                {
                    int hp_now = Player.player.hp;                 

                    Console.WriteLine($"{Skill.characterSkill[skillnumber].skillname}!!");
                    int statUp = Damage.SkillEffect(Skill.characterSkill[skillnumber].skilltype, skillnumber);
                }
                else //특수 스킬
                {
                    Console.WriteLine($"{Skill.characterSkill[skillnumber].skillname}!!");

                }

                Console.WriteLine("\n[내정보]");
                Console.WriteLine("Lv." + Player.player.lv + " " + Player.player.Name + " (" + Player.player.job + ")");


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
                        Console.WriteLine("잘못된 입력입니다.");
                        Thread.Sleep(600);
                        goto skillResult;
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(600);
                    goto skillResult;
                }
                
                


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
                Current_HP = Player.player.victim(enemies[number].atk,Current_HP);
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
            enemyPhase:
                Console.Write(">>> ");
                string index = Console.ReadLine();
                int num;
                Player.player.def = Current_Defense; // 만약 스킬을 사용했으면 다음 플레이어 턴에 방어력 복귀 
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
