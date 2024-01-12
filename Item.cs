using static TeamProject.Player;
using static TeamProject.Scene;

namespace TeamProject
{
    // 아이템 기본 설정
    public class Item : stat
    {
        public string Info { get; }
        public int Price { get; }
        public bool PurchaseSell { get; set; }
        public bool Equip { get; }
        public Item(string name, int atk, int def, int hp, string info, int price)
        {
            Name = name;
            this.atk = atk;
            this.def = def;
            this.hp = hp;
            Info = info;
            Price = price;
        }


        // 아이템 리스트 설정
        public static List<Item> items = new List<Item>(); // 기본 아이템 리스트
        public static List<Item> equipitems = new List<Item>(); // 장착 가능한 아이템 리스트
        public static void ItemSetting()
        {
            items.Add(new Item("수련자 갑옷", 0, 5, 0, "수련에 도움을 주는 갑옷입니다.", 1000));
            items.Add(new Item("무쇠갑옷", 0, 9, 0, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000));
            items.Add(new Item("스파르타의 갑옷", 0, 15, 0, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500));
            items.Add(new Item("낡은 검", 2, 0, 0, "쉽게 볼 수 있는 낡은 검 입니다.", 600));
            items.Add(new Item("청동 도끼", 5, 0, 0, "어디선가 사용됐던거 같은 도끼입니다.", 1500));
            items.Add(new Item("스파르타의 창", 7, 0, 0, "스파르타의 전사들이 사용했다는 전설의 창입니다.", 2500));
        }

        
        // 아이템 기본 정보 표시
        public void PrintItemStatus(bool purchaseSell = false, bool equip = false, int number = 0)
        {
            if (!purchaseSell && !equip) Console.Write("\n- ");
            else Console.Write($"\n{number}.");
            if (Equip)
            {
                Console.WriteLine("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("E");
                Console.ResetColor();
                Console.WriteLine("]");
            }
            Console.Write($"{Name} | ");
            if (this.atk != 0) Console.Write($"공격력 +{this.atk} | ");
            if (this.def != 0) Console.Write($"방어력 +{this.def} | ");
            if (this.hp != 0) Console.Write($"체력 +{this.hp} | ");
            Console.Write($"{Info} | ");
        }


        // 상점 매뉴
        // 구매 및 판매 사용 X
        public static void StoreMenu()
        {
            storeMenu:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("■ 상점 ■");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G\n");
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < items.Count; i++)
            {
                items[i].PrintItemStatus();
                if (!items[i].PurchaseSell) Console.Write($"{items[i].Price}");
                else Console.Write($"구매완료");
            }
            Console.WriteLine("\n\n1. 아이템 구매");
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>>> ");
            string index = Console.ReadLine();
            bool isInt = int.TryParse(index, out int num);
            if (isInt)
            {
                switch (num)
                {
                    case (int)SceneType.Menu:
                        Scene.StartScene(); 
                        break;
                    case 1:
                        StorePurchaseMenu();
                        break;
                    default:
                        Console.WriteLine("잘못 입력하셨습니다.");
                        Thread.Sleep(1000);
                        goto storeMenu;
                }
            }
        }
        // 구매 및 판매 사용 O
        static void StorePurchaseMenu()
        {
            storePurchaseMenu:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("■ 상점 ■");
            Console.ResetColor();
            Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n");
            Console.WriteLine("[보유 골드]");
            Console.WriteLine($"{player.Gold} G\n");
            Console.WriteLine("[아이템 목록]");
            for (int i = 0; i < items.Count; i++)
            {
                items[i].PrintItemStatus(true, false, i + 1);
                if (!items[i].PurchaseSell) Console.Write($"{items[i].Price}");
                else Console.Write($"구매완료");
            }
            Console.WriteLine("\n\n0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>>> ");
            string index = Console.ReadLine();
            bool isInt = int.TryParse(index, out int num);
            if (isInt)
            {
                switch (num)
                {
                    case 0:
                        StoreMenu();
                        break;
                    default:
                        if (num <= items.Count)
                        {
                            if (!items[num - 1].PurchaseSell)
                            {
                                if (items[num - 1].Price < player.Gold)
                                {
                                    player.Gold -= items[num - 1].Price;
                                    items[num - 1].PurchaseSell = true;
                                }
                                else
                                {
                                    Console.Write($"골드가 부족합니다.");
                                    Thread.Sleep(1000);
                                }
                            }
                            else
                            {
                                Console.Write($"이미 구매하신 상품 입니다.");
                                Thread.Sleep(1000);
                            }
                        }
                        StorePurchaseMenu();
                        break;
                }
            }
        }
    }
}
