using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    internal class Dungeon
    {
        public int ChoiceInput(int fst, int last) // 선택지 입력 메서드
        {
            Console.WriteLine();
            int cp = Console.CursorTop;
            string input = Console.ReadLine();
            int choice;
            while (!(int.TryParse(input, out choice)) || choice < fst || choice > last)
            {
                Console.SetCursorPosition(0, cp);
                Console.WriteLine("잘못된 입력입니다.");
                Console.Write("                    \r");
                input = Console.ReadLine();
            }
            return choice;
        }

        public static void ShowHighlightedText(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public void DungeonMenu()
        {
            Console.Clear();
            ShowHighlightedText("■ 던전 입장 ■");
            Console.WriteLine("이곳에서 던전으로 들어가기 전 다음 활동을 할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("1. 상태 보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine("3. 상점");
            Console.WriteLine("4. 던전 입장");
            Console.WriteLine("0. 메인 화면으로 나가기");
            Console.WriteLine("");

            switch (ChoiceInput(0, 4))
            // Program.cs 에서 만든 메인메뉴, 상태보기, 인벤토리, 상점, 던전 난이도 선택 , 던전입장 등을 구현하고 싶음
            {
                case 0:

                    Scene.StartScene(); // 메인 메뉴로 나가기
                    break;
                case 1:
                    Player.PlayerStatus(); // 상태 보기
                    break;
                case 2:
                    Item.InvenMenu(); // 인벤토리
                    break;
                case 3:
                    Item.StoreMenu(); // 상점
                    break;
                case 4:
                    DungeonChoiceMenu(); // 던전 난이도 선택
                    break;
            }
        }



        public void DungeonChoiceMenu() // 12-1. 던전 난이도 선택
        {
            Console.Clear();
            ShowHighlightedText("■ 던전 난이도 선택 ■");
            Console.WriteLine("다양한 난이도의 던전을 선택할 수 있습니다.");
            Console.WriteLine("");
            Console.WriteLine("1. 삼국            | 체력 100 이상 권장  | ");
            Console.WriteLine("2. 조선            | 체력 250 이상 권장  | 안동김씨가 활개치던 그떄 그 시기, 진정한 헬조선의 시작 ");
            Console.WriteLine("3. 대한민국(현대)  | 체력 500 이상 권장  | 저출산,젠더갈등,취업경쟁,국채 증가 등의 각종 지옥의 문이 열린 대한민국");
            Console.WriteLine("");
            Console.WriteLine("0. 던전 입구로 돌아가기");
            Console.WriteLine("");

            switch (ChoiceInput(0, 3))
            {
                case 0:
                    //던전 입구 메서드 
                    break;
                case 1:
                    if (Player.player.hp <= 0) // 체력이 0이하인 경우 입장컷.
                    {
                        Console.WriteLine("!! 체력이 부족합니다. 회복 후에 도전해주세요 !!");
                        Console.WriteLine("");
                        Console.WriteLine("아무키나 누르면 던전 입구로 돌아갑니다.");
                        Console.ReadLine();
                        DungeonMenu();
                        return;
                    }
                    break;

            }

        }
    }
}


