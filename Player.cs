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
        public int Gold { get; set; }
        public Player(int lv, int atk, int def, int hp)
        {
            this.lv = lv;
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
            Console.WriteLine(Name + " ( " + Job + " )");
            Console.WriteLine("공격력 : " + atk);
            Console.WriteLine("방어력 : " + def);
            Console.WriteLine("체  력 : " + hp);
            Console.WriteLine("Gold   : " + Gold);
        }

        public static Player player = new Player(1, 50, 5, 1000);
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
    }
}
