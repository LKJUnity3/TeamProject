using WMPLib;
using static TeamProject.Scene;
using static TeamProject.Skill;

namespace TeamProject
{
    public class Player : stat
    {
        public JobList job;//캐릭터가 소지하고 있는 직업, enum으로 선언
        public List<Skill_DataSet> characterSkill = new List<Skill_DataSet>(); //캐릭터가 소지한 스킬 정보
        
        public int Gold { get; set; }//돈, 골드
        public int victim(int atk,int hp)//데미지 계산
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

        //스탯 설정
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

        //스탯 UI
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

        //캐릭터 생성
        public static Player player = new Player();
        
        //상태보기 화면
        public static void PlayerStatus()
        {
        playerStatus:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[ 상태 보기 ]");
            Console.ResetColor();
            Console.WriteLine("\n캐릭터의 정보가 표시됩니다.");
            player.Status();
            Console.WriteLine("\n[0] 나가기");
            Console.Write("\n원하시는 행동을 입력해주세요.\n>>> ");
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
            Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
            Thread.Sleep(1000);
            goto playerStatus;
        }

        //캐릭터 이름 설정
        public static void NickName()
        {
            Console.Clear();
            Console.WriteLine("대한민국 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("원하시는 이름을 설정해주세요.");
            Console.Write(">>> ");
            player.Name = Console.ReadLine();
            if (string.IsNullOrEmpty(player.Name))
            {
                Console.WriteLine("이름을 입력해주세요");
                Thread.Sleep(1000);
                NickName();
            }
        }


        //캐릭터 직업 설정
        public  void GetJob()
        {
            GetJob:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[ 캐 릭 터 선 택 ]\n\n");
            Console.ResetColor();
            Console.WriteLine("[1] 김유신(검사) \n 공격력 : 50 | 방어력 : 30 | 체력 : 400 | 소지골드 3000 \n");
            // 각 캐릭터를 설정할 시 , 캐릭터에 대한 소개와 넣어보고 싶어요!
            Console.WriteLine("[2] 이성계(궁수) \n 공격력 : 45 | 방어력 : 20 | 체력 : 350 | 소지골드 7000 \n");
            Console.WriteLine("[3] 홍길동(주술사) \n 공격력 : 40 | 방어력 : 30 | 체력 : 450 | 소지골드 800 \n");
            Console.WriteLine("[4] 허준(약사) \n 공격력 : 10 | 방어력 : 40 | 체력 : 600 | 소지골드 1500 \n");
            Console.WriteLine("\n원하시는 캐릭터를 선택하세요.");
            Console.Write(">>> ");


            bool IsCorrect = int.TryParse(Console.ReadLine(), out int num);
            //직업 스탯 

            if (IsCorrect && num > 0 && num <= System.Enum.GetValues(typeof(JobList)).Length)
            {
                switch (num)//캐릭터의 직업과 초기 스탯 입력
                {
                    case 1:
                        {
                            // job, lv, atck, def, hp, gold
                            setStatus(JobList.검사, 1, 50, 30, 400, 3000, 0, 10);
                            break;
                        }
                    case 2:
                        {
                            setStatus(JobList.궁수, 1, 45, 20, 350, 7000, 0, 10);
                            break;
                        }
                    case 3:
                        {
                            setStatus(JobList.주술사, 1, 40, 30, 450, 800, 0, 10);
                            break;
                        }
                    case 4:
                        {
                            setStatus(JobList.약사, 1, 10, 40, 600, 1500, 0, 10);
                            break;
                        }
                    default:
                        Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                        Thread.Sleep(1000);
                        goto GetJob;

                }

            }
            else
            {
                Console.WriteLine("잘못 입력하셨습니다.다시 입력해주세요");
                Thread.Sleep(1000);
                goto GetJob;
            }
        }

        public static void LevelUp()
        {
            player.lv += 1;
            player.atk += player.lv * (int)(player.atk * 0.02f);
            player.def += player.lv * (int)(player.def * 0.02f);
            player.fullExp += 15 + player.lv * 5;
            player.exp = 0;
            WindowsMediaPlayer soundLevelUp = new WindowsMediaPlayer();
            string baseFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory); // 현재 프로젝트의 경로
            string playFolder = Directory.GetParent(baseFolder).Parent.Parent.Parent.FullName + @"\sound\LevelUp.wav"; // 해당 경로에서 불필요한 부분 제거하고 원하는 폴더 추가
            if (File.Exists(playFolder))
            {
                soundLevelUp.URL = playFolder;
                soundLevelUp.settings.volume = 10;
                soundLevelUp.controls.play();
                Thread.Sleep(100);
            }
        }
    }
}
