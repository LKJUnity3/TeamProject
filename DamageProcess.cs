﻿using System;
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

        public static int SkillAttackEffect(Skill.SkillType type, int skillnumb)
        {
            Random rand = new Random();

            if (type == Skill.SkillType.Attack)
            {
                skillMinDamage = Math.Round((double)(Player.player.atk + Player.player.characterSkill[skillnumb].skillDamage) * 0.9);
                skillMaxDamage = Math.Round((double)(Player.player.atk + Player.player.characterSkill[skillnumb].skillDamage) * 1.1);

                int damage;
                damage = rand.Next((int)skillMinDamage, (int)skillMaxDamage);
                return damage;
            }
            else if (type == Skill.SkillType.AttackPercent)
            {
                skillMinDamage = Math.Round((double)(Player.player.atk * Player.player.characterSkill[skillnumb].skillDamage) * 0.9);
                skillMaxDamage = Math.Round((double)(Player.player.atk * Player.player.characterSkill[skillnumb].skillDamage) * 1.1);

                int damage;
                damage = rand.Next((int)skillMinDamage, (int)skillMaxDamage);
                return damage;
            }
            

            return 0;

        }
        public static void SkillEffect(Skill.SkillType type, int skillnumb)
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
                int currentHp = BattleScene.Current_HP;
                int resultHp = currentHp;

                if (currentHp < Player.player.hp)
                {
                    resultHp += Player.player.characterSkill[skillnumb].skillDamage;

                    if (resultHp > Player.player.hp)
                    {
                        Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                        Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{BattleScene.Current_HP}");
                    }
                    else
                    {
                        BattleScene.Current_HP = resultHp;
                        Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                        Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{resultHp}");
                    }
                }
                else
                {
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                    Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{resultHp}");
                }
            }
            else if (type == Skill.SkillType.HealPercent)
            {
                int currentHp = BattleScene.Current_HP;
                int resultHp = currentHp;

                if (currentHp < Player.player.hp)
                {
                    resultHp += currentHp * Player.player.characterSkill[skillnumb].skillDamage;

                    if (resultHp > Player.player.hp)
                    {
                        Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                        Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{BattleScene.Current_HP}");
                    }
                    else
                    {
                        BattleScene.Current_HP = resultHp;
                        Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                        Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{resultHp}");
                    }
                }
                else
                {
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                    Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{resultHp}");
                }
            }
            else if (type == Skill.SkillType.SupportAtk)
            {
                int atk_now = Player.player.atk;
                Player.player.atk += Player.player.characterSkill[skillnumb].skillDamage;

                Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                Console.WriteLine($"공격력 스탯 변화 : {atk_now} ->{Player.player.atk}");
            }
            else if (type == Skill.SkillType.SupportDef)
            {
                int def_now = Player.player.def;
                Player.player.def += Player.player.characterSkill[skillnumb].skillDamage;

                Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                Console.WriteLine($"방어력 스탯 변화 : {def_now} ->{Player.player.def}");
            }
            else if (type == Skill.SkillType.SupportHP)
            {
                int currentHp = BattleScene.Current_HP;
                int resultHp = currentHp;
                
                if(currentHp < Player.player.hp)
                {
                    resultHp += Player.player.characterSkill[skillnumb].skillDamage;

                    if(resultHp > Player.player.hp)
                    {
                        Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                        Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{BattleScene.Current_HP}");
                    }
                    else
                    {
                        BattleScene.Current_HP = resultHp;
                        Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                        Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{resultHp}");
                    }              
                }
                else
                {
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                    Console.WriteLine($"체력 스탯 변화 : {currentHp} ->{resultHp}");
                }        
            }
            else
            {
                if (Player.player.characterSkill[skillnumb].skillname == "분신술")
                {
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                    BattleScene.Player_Extra_Avoide = 100;
                    Console.WriteLine($"회피율 100 상승");


                }
                else if (Player.player.characterSkill[skillnumb].skillname == "불패의 신화")
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
                else if (Player.player.characterSkill[skillnumb].skillname == "천하무적")
                {

                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                    BattleScene.Player_Extra_Avoide = 100;
                    Console.WriteLine($"오라오라오라~\n");

                    for(int j=0; j<BattleScene.enemies.Count; j++)
                    {
                        Console.WriteLine($"광역 스킬 천하무적으로 인하여 {BattleScene.enemies[j].Name}가 {Player.player.characterSkill[skillnumb].skillDamage}X3 만큼 피해를 입었습니다.");
                        int currentEnemyHP = BattleScene.enemies[j].hp;
                        BattleScene.enemies[j].hp -= 3 * Player.player.characterSkill[skillnumb].skillDamage;

                        if (BattleScene.enemies[j].hp <=0)
                        {
                            BattleScene.enemies[j].hp = 0;
                            Console.Write($"Lv.{BattleScene.enemies[j].lv} {BattleScene.enemies[j].Name}    HP : {currentEnemyHP} -> ");
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("Dead\n");
                            Console.ResetColor();
                            Player.player.exp += BattleScene.enemies[j].lv;
                            if(Player.player.exp > Player.player.fullExp)
                            {
                                int fullE = Player.player.fullExp;
                                int e = Player.player.exp;
                                BattleScene.remainEXP += e - fullE;
                                Player.player.exp = Player.player.fullExp;                                
                            }                            
                            Player.player.Gold += BattleScene.enemies[j].dropGold;
                            Enemy.ItemDrop();
                        }
                        else
                        {
                            Console.WriteLine($"Lv.{BattleScene.enemies[j].lv} {BattleScene.enemies[j].Name}    HP : {currentEnemyHP} -> {BattleScene.enemies[j].hp}\n");
                        }
                    }
                    
                }
                else if (Player.player.characterSkill[skillnumb].skillname == "의협심")
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
                else if (Player.player.characterSkill[skillnumb].skillname == "민중의 영웅")
                {
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                    BattleScene.Player_Extra_Avoide = 100;
                    Console.WriteLine($"회피율 상승 : 0 -> 100");
                }
                else if (Player.player.characterSkill[skillnumb].skillname == "명의")
                {
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                    Console.WriteLine($"체력 회복 : {BattleScene.Current_HP} -> {Player.player.hp}");
                    BattleScene.Current_HP = Player.player.hp;
                }
                else if (Player.player.characterSkill[skillnumb].skillname == "인술")
                {
                    Console.WriteLine($"{Player.player.characterSkill[skillnumb].skillname}!!");
                    Console.WriteLine($"체력 회복 : {BattleScene.Current_HP} -> {Player.player.hp}");
                    BattleScene.Current_HP = Player.player.hp;
                    BattleScene.Player_Extra_Avoide = 100;
                }

            }
        }

        public int EnemyAttack(int atk, int hp, int ExtraAvoid, out int isDamage, out bool enemyAvoidanceTrue, out bool enemyCriticalTrue)
        {
            isDamage = atk - Player.player.def;

            enemyAvoidanceTrue = false;
            int enemyAvoidance = Avoidance(isDamage, ExtraAvoid, ref enemyAvoidanceTrue);

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

        public int PlayerAttack(float atk, int hp, int ExtraAvoid, out float isDamage, out bool criticalTrue, out bool avoidanceTrue)
        {
            double MinDmg = Math.Round((double)Player.player.atk * 0.9);
            double MaxDmg = Math.Round((double)Player.player.atk * 1.1);

            atk = new Random().Next((int)MinDmg, (int)MaxDmg);
            isDamage = atk;
            criticalTrue = false;
            int criticalAtk = Critical((int)isDamage, ref criticalTrue);

            avoidanceTrue = false;
            int avoidanceAtk = Avoidance((int)isDamage, ExtraAvoid, ref avoidanceTrue);

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
