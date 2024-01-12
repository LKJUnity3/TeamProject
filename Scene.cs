using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static TeamProject.Program;

namespace TeamProject
{
    public class Scene
    {
        public enum SceneType // Enum 
        {
            Menu = 0,
            STATUS,
            INVENTORY,
            SHOP,
            DUNGEON
        }
        public static void StartScene()
        {
            Console.Clear();
            Console.WriteLine("스파르타 던전에 오신 여러분 환영합니다.");
            Console.WriteLine("이제 전투를 시작할 수 있습니다.");
            Console.WriteLine("\n[1] 상태 보기\n[2] 인벤 토리\n[3] 상점\n[4] 던전");
            Console.Write("원하시는 행동을 입력해주세요.\n>>> ");
            string index = Console.ReadLine();
            int num;
            bool isInt = int.TryParse(index, out num);
            if (isInt)
            {
                switch (num)
                {
                    case (int)SceneType.STATUS: Player.PlayerStatus(); break;
                    case (int)SceneType.INVENTORY: break;
                    case (int)SceneType.SHOP: break;
                    case (int)SceneType.DUNGEON: BattleScene.Battle(); break;
                    default: StartScene(); break;
                }
            }
        }
    }
}
