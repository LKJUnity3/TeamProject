using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TeamProject.Scene;

namespace TeamProject
{
    public class Player : stat
    {
        public JobList job;
        public int Gold { get; set; }
        public Player(int lv, JobList job, int atk, int def, int hp)
        {
            this.lv = lv;
            this.job = job;
            this.atk = atk;
            this.def = def;
            this.hp = hp;
            Gold = 1500;
        }
        public int victim(int atk,int hp)
        {
            int isDamage = atk - def;
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
        public void Status()
        {
            Console.WriteLine("Lv." + lv);
            Console.WriteLine(Name + " ( " + job + " )");
            Console.WriteLine("공격력 : " + atk);
            Console.WriteLine("방어력 : " + def);
            Console.WriteLine("체  력 : " + hp);
            Console.WriteLine("Gold   : " + Gold);
        }

        public static Player player = new Player(1, JobList.검사, 50, 5, 1000);
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
            Console.Clear();
            Console.WriteLine("캐릭터를 선택하세요.");
            Console.WriteLine("1. 김유신(검사)");
            // 각 캐릭터를 설정할 시 , 캐릭터에 대한 소개와 넣어보고 싶어요!
            Console.WriteLine("2. 이성계(궁수)");
            Console.WriteLine("3. 홍길동(주술사)");
            Console.WriteLine("4. 허준(약사)");

            bool IsCorrect = int. TryParse(Console.ReadLine(), out int num);
            //직업 스탯 

            if(IsCorrect && num > 0 && num <= System.Enum.GetValues(typeof(JobList)).Length) 
            {

                switch(num)
                {
                    case 1:
                        {
                            job = JobList.검사;
                            lv = 1;
                            atk = 180;
                            def = 150;
                            hp = 250;
                            Gold = 2000;
                            break;
                        }
                    case 2:
                        {
                            job = JobList.궁수;
                            lv = 1;
                            atk = 150;
                            def = 200;
                            hp = 200;
                            Gold = 2500;
                            break;
                        }
                    case 3:
                        {
                            job = JobList.주술사;
                            lv = 1;
                            atk = 180;
                            def = 180;
                            hp = 200;
                            Gold = 3000;
                            break;
                        }
                    case 4:
                        {
                            job = JobList.약사;
                            lv = 1;
                            atk = 180;
                            def = 180;
                            hp = 200;
                            Gold = 3000;
                            break;
                        }

                }
            } // 코드가 깃허브에 올라와 있지는 않아서, 확인중
        }
    }
}
