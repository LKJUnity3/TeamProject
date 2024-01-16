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

        public static int SkillAttackEffect(Skill.SkillType type, int skillnumb) //attack으로 분류된 스킬 타입 데미지 계산
        {
            Random rand = new Random();

            if (type == Skill.SkillType.Attack)
            {
                //스킬 최소, 최대 데미지 계산
                skillMinDamage = Math.Round((double)(Player.player.atk + Player.player.characterSkill[skillnumb].skillDamage) * 0.9);
                skillMaxDamage = Math.Round((double)(Player.player.atk + Player.player.characterSkill[skillnumb].skillDamage) * 1.1);

                int damage;
                //캐릭터의 atk, skilldamage 합쳐서 나온 값에서 0.9~1.1 랜덤값 곱함
                damage = rand.Next((int)skillMinDamage, (int)skillMaxDamage);
                return damage;
            }
            else if (type == Skill.SkillType.AttackPercent)
            {
                //스킬 최소, 최대 데미지 계산
                skillMinDamage = Math.Round((double)(Player.player.atk * Player.player.characterSkill[skillnumb].skillDamage) * 0.9);
                skillMaxDamage = Math.Round((double)(Player.player.atk * Player.player.characterSkill[skillnumb].skillDamage) * 1.1);

                int damage;
                //캐릭터의 atk + (캐릭터 atk * 스킬 데미지) 값에서 0.9~1.1 랜덤값을 곱함
                damage = rand.Next((int)skillMinDamage, (int)skillMaxDamage);
                return damage;
            }
            

            return 0;

        }
        public static void SkillEffect(Skill.SkillType type, int skillnumb) //attack 이외에 defense,heal,special 등 스킬 타입 효과 적용
        {
            if (type == Skill.SkillType.Defense)
            {
                Player.player.def += Player.player.characterSkill[skillnumb].skillDamage;
            }
            else if (type == Skill.SkillType.DefensePercent)
            {
                Player.player.def += Player.player.def * Player.player.characterSkill[skillnumb].skillDamage / 100;
            }
            else if (type == Skill.SkillType.Heal)
            {
                int currentHp = BattleScene.Current_HP;//현재 체력
                int resultHp = currentHp;//최종 체력

                if (currentHp < Player.player.hp)//현재 체력이 player 최대 체력보다 낮을때
                {
                    resultHp += Player.player.characterSkill[skillnumb].skillDamage;//heal 계산

                    if (resultHp > Player.player.hp)
                    {
                        Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");//스킬명
                        Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{BattleScene.Current_HP}");
                    }
                    else
                    {
                        BattleScene.Current_HP = resultHp;//resultHp가 최대체력보다 작기에 현재 체력에 resultHp 값 입력
                        Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");//스킬명
                        Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{resultHp}");
                    }
                }
                else
                {
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");//스킬명
                    Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{resultHp}");
                }
            }
            else if (type == Skill.SkillType.HealPercent)
            {
                int currentHp = BattleScene.Current_HP;//현재 체력
                int resultHp = currentHp;//최종 체력

                if (currentHp < Player.player.hp)
                {
                    resultHp += currentHp * Player.player.characterSkill[skillnumb].skillDamage;//heal 계산

                    if (resultHp > Player.player.hp)
                    {
                        Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");//스킬명
                        Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{BattleScene.Current_HP}");
                    }
                    else
                    {
                        BattleScene.Current_HP = resultHp;//resultHp가 최대체력보다 작기에 현재 체력에 resultHp 값 입력
                        Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");//스킬명
                        Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{resultHp}");
                    }
                }
                else
                {
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");//스킬명
                    Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{resultHp}");
                }
            }
            else if (type == Skill.SkillType.SupportAtk)
            {
                int atk_now = Player.player.atk;
                Player.player.atk += Player.player.characterSkill[skillnumb].skillDamage;//캐릭터 공격력 상승

                Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");//스킬명
                Console.WriteLine($"공격력 스탯 변화 : {atk_now} ->{Player.player.atk}");
            }
            else if (type == Skill.SkillType.SupportDef)
            {
                int def_now = Player.player.def;
                Player.player.def += Player.player.characterSkill[skillnumb].skillDamage;//캐릭터 방어력 상승

                Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");//스킬명
                Console.WriteLine($"방어력 스탯 변화 : {def_now} ->{Player.player.def}");
            }
            else if (type == Skill.SkillType.SupportHP)
            {
                int currentHp = BattleScene.Current_HP;//현재 체력
                int resultHp = currentHp;//최종 체력
                
                if(currentHp < Player.player.hp)
                {
                    resultHp += Player.player.characterSkill[skillnumb].skillDamage; //heal 계산

                    if(resultHp > Player.player.hp)
                    {
                        Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");//스킬명
                        Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{BattleScene.Current_HP}");
                    }
                    else
                    {
                        BattleScene.Current_HP = resultHp;//resultHp가 최대체력 이하라서 resultHp를 현재 체력에 입력
                        Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");// 스킬명
                        Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{resultHp}");
                    }              
                }
                else
                {
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");// 스킬명
                    Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{resultHp}");
                }        
            }
            else //특수효과를 가진 스킬들
            {
                if (Player.player.characterSkill[skillnumb].skillname == "분신술")//회피율 100상승
                {
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                    BattleScene.Player_Extra_Avoide = 100;
                    Console.WriteLine($"회피율 100 상승");


                }
                else if (Player.player.characterSkill[skillnumb].skillname == "불패의 신화")//스탯 상승
                {
                    Program.SkillSound("bulpeasinhwa", true, 15);
                    int atk_now = Player.player.atk;
                    int hp_now = BattleScene.Current_HP;
                    BattleScene.Current_HP += 10000;
                    Player.player.atk += 10000;
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                    BattleScene.Player_Extra_Avoide = 100;
                    Console.WriteLine($"공격력,체력 10000 상승");
                    Console.WriteLine($"공격력 스탯 변화 : {atk_now} ->{Player.player.atk}");
                    Console.WriteLine($"체력 스탯 변화 : {hp_now} -> {BattleScene.Current_HP}");
                }
                else if (Player.player.characterSkill[skillnumb].skillname == "천하무적")//광범위 연속 공격
                {
                    Program.SkillSound("oraora", true, 30);
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                    BattleScene.Player_Extra_Avoide = 100;
                    Console.WriteLine($"오라오라오라~\n");

                    for(int j=0; j<BattleScene.enemies.Count; j++)//모든 적에게 공격이 가해지도록 반복문 생성
                    {
                        Console.WriteLine($"광역 스킬 천하무적으로 인하여 {BattleScene.enemies[j].Name}가 {Player.player.characterSkill[skillnumb].skillDamage}X3 만큼 피해를 입었습니다.");
                        int currentEnemyHP = BattleScene.enemies[j].hp;
                        BattleScene.enemies[j].hp -= 3 * Player.player.characterSkill[skillnumb].skillDamage;//스킬 데미지 적용

                        if (BattleScene.enemies[j].hp <=0)//적의 체력이 0이하이면
                        {
                            BattleScene.enemies[j].hp = 0;
                            Console.Write($"Lv.{BattleScene.enemies[j].lv} {BattleScene.enemies[j].Name}    HP : {currentEnemyHP} -> ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;//콘솔창 색 변경
                            Console.WriteLine("Dead\n");
                            Console.ResetColor();//콘솔창 색 리셋
                            Player.player.exp += BattleScene.enemies[j].lv;//적이 죽음에 따라 exp 획득
                            if(Player.player.exp > Player.player.fullExp)//레벨업에 따른 계산
                            {
                                int fullE = Player.player.fullExp;
                                int e = Player.player.exp;
                                BattleScene.remainEXP += e - fullE;
                                Player.player.exp = Player.player.fullExp;                                
                            }                            
                            Player.player.Gold += BattleScene.enemies[j].dropGold;//적 처지, 골드 획득
                            Enemy.ItemDrop();//적 처지, 아이템 획득
                        }
                        else
                        {
                            Console.WriteLine($"Lv.{BattleScene.enemies[j].lv} {BattleScene.enemies[j].Name}    HP : {currentEnemyHP} -> {BattleScene.enemies[j].hp}\n");
                        }
                    }
                    
                }
                else if (Player.player.characterSkill[skillnumb].skillname == "의협심")//스탯 상승
                {
                    int atk_now = Player.player.atk;
                    int hp_now = BattleScene.Current_HP;
                    BattleScene.Current_HP += 10000;
                    Player.player.atk += 10000;
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                    BattleScene.Player_Extra_Avoide = 100;
                    Console.WriteLine($"공격력,체력 10000 상승");
                    Console.WriteLine($"공격력 스탯 변화 : {atk_now} ->{Player.player.atk}");
                    Console.WriteLine($"체력 스탯 변화 : {hp_now} -> {BattleScene.Current_HP}");
                }
                else if (Player.player.characterSkill[skillnumb].skillname == "민중의 영웅")//회피율 100 상승
                {
                    Program.SkillSound("hero", true, 5);
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                    BattleScene.Player_Extra_Avoide = 100;
                    Console.WriteLine($"회피율 상승 : 0 -> 100");
                }
                else if (Player.player.characterSkill[skillnumb].skillname == "명의")//체력 회복
                {
                    Program.SkillSound("goodDoctor", true, 20);
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                    Console.WriteLine($"체력 회복 : {BattleScene.Current_HP} -> {Player.player.hp}");
                    BattleScene.Current_HP = Player.player.hp;
                }
                else if (Player.player.characterSkill[skillnumb].skillname == "인술")//체력 회복, 회피율 100 상승
                {
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                    Console.WriteLine($"체력 회복 : {BattleScene.Current_HP} -> {Player.player.hp}");
                    BattleScene.Current_HP = Player.player.hp;
                    BattleScene.Player_Extra_Avoide = 100;
                }

            }
        }

        //적의 공격 계산, 데미지 값 out, 회피여부 bool 값 out, 크리티컬 bool 값 out
        public int EnemyAttack(int atk, int hp, int ExtraAvoid, out int isDamage, out bool enemyAvoidanceTrue, out bool enemyCriticalTrue)
        {
            //데미지 측정
            isDamage = atk - Player.player.def;

            enemyAvoidanceTrue = false;
            
            //캐릭터의 회피 계산
            int enemyAvoidance = Avoidance(isDamage, ExtraAvoid, ref enemyAvoidanceTrue);

            enemyCriticalTrue = false;

            //크리티컬 계산
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
                isDamage = (int)Math.Round(atk *0.15);
            }
            hp -= isDamage;
            if (hp < 0)
            {
                hp = 0;
            }
            return hp;
        }

        //캐릭터의 공격 계산
        public int PlayerAttack(float atk, int hp, int ExtraAvoid,int def, out float isDamage, out bool criticalTrue, out bool avoidanceTrue)
        {
            //최소, 최대 데미지
            double MinDmg = Math.Round((double)Player.player.atk * 0.9);
            double MaxDmg = Math.Round((double)Player.player.atk * 1.1);

            atk = new Random().Next((int)MinDmg, (int)MaxDmg);
            isDamage = atk - def;
            criticalTrue = false;

            //크리티컬 값 계산
            int criticalAtk = Critical((int)isDamage, ref criticalTrue);

            //적 회피 계산
            avoidanceTrue = false;
            int avoidanceAtk = Avoidance((int)isDamage, ExtraAvoid, ref avoidanceTrue);

            if (isDamage <= 0)
            {
                isDamage = (int)Math.Round(atk * 0.15);
            }


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

        //회피여부
        public static int Avoidance(int damage, int extraStat, ref bool isAvoidance)
        {
            int avoidance = new Random().Next(1, 100) + extraStat;
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

        //크리티컬
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
