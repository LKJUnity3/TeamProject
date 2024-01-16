using static TeamProject.Player;
using static TeamProject.Scene;

namespace TeamProject
{
    // 아이템 기본 설정
    public class Item : stat
    {
        public string Info { get; }
        public int Price { get; }
        public int ConsumItem { get; set; }
        public bool PurchaseSell { get; set; }
        public bool Equip { get; set; }
        public Item(string name, int atk, int def, int hp, string info, int price)
        {
            Name = name;
            this.atk = atk;
            this.def = def;
            this.hp = hp;
            Info = info;
            Price = price;
        }


        // 장비 아이템 리스트 설정
        public static List<Item> items = new List<Item>(); // 기본 아이템 리스트
        public static List<Item> equipItems = new List<Item>(); // 장착 가능한 아이템 리스트
        public static void ItemSetting()
        {
            items.Add(new Item("수련자 갑옷", 0, 5, 0, "수련에 도움을 주는 갑옷입니다.", 1000));
            items.Add(new Item("무쇠갑옷", 0, 9, 0, "무쇠로 만들어져 튼튼한 갑옷입니다.", 2000));
            items.Add(new Item("스파르타의 갑옷", 0, 15, 0, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500));
            items.Add(new Item("두정갑", 0, 20, 10, "최후의 갑옷", 8000));
            items.Add(new Item("곤룡포", 10000, 10000, 10000, "왕 혹은 누군가의 위엄", 1983415));
            items.Add(new Item("주먹도끼", 2, 0, 0, "이거 지금 시대가 아니지 않나?", 100));
            items.Add(new Item("허임", 10, 0, 10, "여기가 문제로군...", 3000)); // 허준 말고 허임
            items.Add(new Item("목봉", 15, 0, 0, "내가 진짜 홍...", 5000)); // 홍길동 보고 생각
            items.Add(new Item("어궁구", 30, 0, 0, "이는 사람이 쓸 수있는 물건이 아니다.", 10000)); // 태조 이성계를 보고 생각
            items.Add(new Item("신검", 20, 10, 0, "세상에 아무것도 베지 않을 수 있는 검", 10000)); // 김유신 장군을 보고 생각
        }
        // 포션 아이템 리스트 설정
        public static List<Item> potions = new List<Item>();
        public static List<Item> usePotions = new List<Item>();
        public static void PotionSetting()
        {
            potions.Add(new Item("주먹밥", 0, 0, ((int)(player.hp * 0.2f)), "어우 짜! 누가 여기 소금을 이렇게..", 300));
            potions.Add(new Item("북어", 0, 0, ((int)(player.hp * 0.4f)), "어푸어푸 아아아아", 300));
            potions.Add(new Item("미숫가루", 0, 0, player.hp, "물이 아니라 길", 7000));
        }

        
        // 아이템 기본 정보 표시
        public void PrintItemStatus(bool purchaseSell = false, bool equip = false, int number = 0)
        {
            if (!purchaseSell && !equip) Console.Write("\n- ");
            else Console.Write($"\n[{number}] ");
            if (Equip)
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("E");
                Console.ResetColor();
                Console.Write("]");
            }
            Console.Write($"{Name} | ");
            if (this.atk != 0) Console.Write($"공격력 +{this.atk} | ");
            if (this.def != 0) Console.Write($"방어력 +{this.def} | ");
            if (this.hp != 0) Console.Write($"체력 +{this.hp} | ");
            Console.Write($"{Info} | ");
            if (ConsumItem > 0) Console.Write($"{ConsumItem}EA | ");
        }


        // 인벤 매뉴
        public static void InvenMenu()
        {
        invenMenu:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[ 인벤토리 ]");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[장비 아이템 목록]");
            equipItems = items.Where(item => item.PurchaseSell).ToList();
            for (int i = 0; i < equipItems.Count; i++)
            {
                equipItems[i].PrintItemStatus();
            }
            Console.WriteLine("\n\n[소모 아이템 목록]");
            for (int i = 0; i < potions.Count; i++)
            {
                if (potions[i].ConsumItem > 0) potions[i].PrintItemStatus();
            }
            Console.WriteLine("\n\n[1] 장착 관리");
            Console.WriteLine("[0] 나가기\n");
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
                        InvenEquipMenu();
                        break;
                    default:
                        Console.WriteLine("잘못 입력하셨습니다.");
                        Thread.Sleep(1000);
                        goto invenMenu;
                }
            }
            else
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                Thread.Sleep(1000);
                goto invenMenu;
            }
        }
        // 인벤 장착 매뉴
        static void InvenEquipMenu()
        {
            invenEquipMenu:
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[ 인벤토리 - 장착관리 ]");
            Console.ResetColor();
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");
            Console.WriteLine("[장비 아이템 목록]");
            for (int i = 0; i < equipItems.Count; i++)
            {
                equipItems[i].PrintItemStatus(false, true, i + 1);
            }
            Console.WriteLine("\n\n[소모 아이템 목록]");
            for (int i = 0; i < potions.Count; i++)
            {
                if (potions[i].ConsumItem > 0) potions[i].PrintItemStatus(); // 여기서 뭐 장착하고 그런거 아니라서 그냥 표시만 하면됨
            }
            Console.WriteLine("\n\n[0] 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>>> ");
            string index = Console.ReadLine();
            bool isInt = int.TryParse(index, out int num);
            if (isInt)
            {
                switch (num)
                {
                    case 0:
                        InvenMenu();
                        break;
                    default:
                        if (num <= equipItems.Count)
                        {
                            if (!equipItems[num - 1].Equip)
                            {
                                equipItems[num - 1].Equip = true;
                                player.atk += equipItems[num - 1].atk;
                                player.def += equipItems[num - 1].def;
                                player.hp += equipItems[num - 1].hp;
                            }
                            else
                            {
                                equipItems[num - 1].Equip = false;
                                player.atk -= equipItems[num - 1].atk;
                                player.def -= equipItems[num - 1].def;
                                player.hp -= equipItems[num - 1].hp;
                            }
                        }
                        else
                        {
                            Console.WriteLine("잘못 입력하셨습니다.");
                            Thread.Sleep(1000);
                        }
                        goto invenEquipMenu;
                }
            }
            else
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                Thread.Sleep(1000);
                goto invenEquipMenu;
            }
        }
        // 아이템 장착으로 인한 스탯변경
        public static int AddStatus(Func<Item, int> addStatus) // Func 특정 스탯값을 반환한다는 소리
        {
            int sum = 0;
            if (equipItems != null)
            {
                for (int i = 0; i < equipItems.Count; i++)
                {
                    if (equipItems[i].Equip)
                    {
                        sum += addStatus(equipItems[i]);
                    }
                }
            }
            return sum;
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
            Console.WriteLine("[장비 아이템 목록]");
            for (int i = 0; i < items.Count; i++)
            {
                items[i].PrintItemStatus();
                if (!items[i].PurchaseSell) Console.Write($"{items[i].Price} G");
                else Console.Write($"구매완료");
            }
            Console.WriteLine("\n\n[소모 아이템 목록]");
            for (int i = 0; i < potions.Count; i++) 
            {
                potions[i].PrintItemStatus();
                if (!potions[i].PurchaseSell) Console.Write($"{potions[i].Price} G");
                else Console.Write($"구매완료");
            }
            Console.WriteLine("\n\n[1] 아이템 구매");
            Console.WriteLine("[0] 나가기\n");
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
            else
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                Thread.Sleep(1000);
                goto storeMenu;
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
            Console.WriteLine("[장비 아이템 목록]");
            for (int i = 0; i < items.Count; i++)
            {
                items[i].PrintItemStatus(true, false, i + 1);
                if (!items[i].PurchaseSell) Console.Write($"{items[i].Price} G");
                else Console.Write($"구매완료");
            }
            Console.WriteLine("\n\n[소모 아이템 목록]");
            for (int i = 0; i < potions.Count; i++)
            {
                potions[i].PrintItemStatus(true, false, i + items.Count + 1);
                if (!potions[i].PurchaseSell) Console.Write($"{potions[i].Price} G");
                else Console.Write($"구매완료");
            }
            Console.WriteLine("\n\n[0] 나가기\n");
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
                        if (num <= items.Count + potions.Count)
                        {
                            if (num <= items.Count) // 소모 아이템을 선택하면 장비 아이템의 범위를 벗어나기 때문에 이렇게 해줌
                            {
                                if (!items[num - 1].PurchaseSell) // 장비 아이템 구매
                                {
                                    if (items[num - 1].Price <= player.Gold)
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
                            else if (potions[num - items.Count - 1] != null) // 소모 아이템 구매
                            {
                                if (potions[num - items.Count - 1].Price <= player.Gold)
                                {
                                    player.Gold -= potions[num - items.Count - 1].Price;
                                    potions[num - items.Count - 1].ConsumItem++;
                                }
                                else
                                {
                                    Console.Write($"골드가 부족합니다.");
                                    Thread.Sleep(1000);
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("잘못 입력하셨습니다.");
                            Thread.Sleep(1000);
                        }
                        goto storePurchaseMenu;
                }
            }
            else
            {
                Console.WriteLine("잘못 입력하셨습니다.");
                Thread.Sleep(1000);
                goto storePurchaseMenu;
            }
        }
    }
}
