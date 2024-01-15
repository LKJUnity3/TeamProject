using static TeamProject.Scene;

namespace TeamProject
{
    public class Player : stat
    {
        public JobList job;
        public int Gold { get; set; }
        public int victim(int atk,int hp)
        {
            int isDamage = atk - def;
            if (isDamage < 0)
            {
                isDamage = 0;
                atk = isDamage;
            }
            hp -= isDamage;
            if (hp < 0)
            {
                hp = 0;
            }
            return hp;
        }

        public void setStatus(JobList job, int lv, int atk, int def, int hp, int gold, int exp, int fullExp)
        {
            player.atk = atk;
            player.hp = hp;
            player.job = job;
            player.Gold = gold;
            player.def = def;
            player.lv = lv;
            player.exp = exp;
            player.fullExp = fullExp;
        }
        public void Status()
        {
            Console.WriteLine("Lv." + lv);
            Console.WriteLine(Name + " ( " + job + " )");
            int addAtk = Item.AddStatus(item => item.atk);
            Console.WriteLine($"공격력 : {atk}" + ( addAtk > 0 ? $"(+{addAtk})" : addAtk < 0 ? $"(-{addAtk})" : ""));
            int addDef = Item.AddStatus(item => item.def);
            Console.WriteLine($"방어력 : {def}" + (addDef > 0 ? $"(+{addDef})" : addDef < 0 ? $"(-{addDef})" : ""));
            int addHp = Item.AddStatus(item => item.hp);
            Console.WriteLine($"체력 : {hp}" + (addHp > 0 ? $"(+{addHp})" : addHp < 0 ? $"(-{addHp})" : ""));
            Console.WriteLine($"경험치 : {exp} / {fullExp}");
            Console.WriteLine("Gold   : " + Gold);
        }

        public static Player player = new Player();
        public static void PlayerStatus()
        {
        playerStatus:
            Console.Clear();
            Console.WriteLine("상태 보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.");
            player.Status();
            Console.WriteLine("\n[0] 나가기");
            Console.Write("원하시는 행동을 입력해주세요.\n>>> ");
            string index = Console.ReadLine();
            int num;
            bool isInt = int.TryParse(index, out num);

            if (isInt)
            {
                switch (num)
                {
                    case (int)SceneType.Menu: Scene.StartScene(); break;
                    default: Console.WriteLine("잘못 입력하셨습니다."); Thread.Sleep(600); goto playerStatus;
                }
            }
            Console.WriteLine("잘못 입력하셨습니다."); Thread.Sleep(600); goto playerStatus;
        }
        public static void NickName()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.");
            Console.Write(">>> ");
            player.Name = Console.ReadLine();
        }


        public void GetJob()
        {
            GetJob:
            Console.Clear();
            Console.WriteLine("[ 캐 릭 터 선 택 ]\n\n");
            Console.WriteLine("[1] 김유신(검사) \n 공격력 : 180 | 방어력 : 150 | 체력 : 250 | 소지골드 2000 \n");
            // 각 캐릭터를 설정할 시 , 캐릭터에 대한 소개와 넣어보고 싶어요!
            Console.WriteLine("[2] 이성계(궁수) \n 공격력 : 150 | 방어력 : 200 | 체력 : 200 | 소지골드 2500 \n");
            Console.WriteLine("[3] 홍길동(주술사) \n 공격력 : 180 | 방어력 : 180 | 체력 : 200 | 소지골드 3000 \n");
            Console.WriteLine("[4] 허준(약사) \n 공격력 : 180 | 방어력 : 180 | 체력 : 200 | 소지골드 3000 \n");
            Console.WriteLine("\n원하시는 캐릭터를 선택하세요.");
            Console.Write(">>> ");


            bool IsCorrect = int.TryParse(Console.ReadLine(), out int num);
            //직업 스탯 

            if (IsCorrect && num > 0 && num <= System.Enum.GetValues(typeof(JobList)).Length)
            {
                switch (num)
                {
                    case 1:
                        {

                            // job, lv, atck, def, hp, gold
                            setStatus(JobList.검사, 1, 180, 150, 250, 2000, 0, 10);

                            break;
                        }
                    case 2:
                        {
                            setStatus(JobList.궁수, 1, 150, 200, 200, 2500, 0, 10);
                            break;
                        }
                    case 3:
                        {
                            setStatus(JobList.주술사, 1, 180, 180, 200, 3000, 0, 10);
                            break;
                        }
                    case 4:
                        {
                            setStatus(JobList.약사, 1, 180, 180, 200, 3000, 0, 10);
                            break;
                        }
                    default: goto GetJob;

                }

            }
            else
            {
                goto GetJob;
            }
        }

        public static void LevelUp()
        {
            player.lv += 1;
            player.atk += 1;
            player.def += 1;
            player.fullExp += 15 + player.lv * 5;
            player.exp = 0;
        }
    }
}
