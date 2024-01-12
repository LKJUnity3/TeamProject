namespace TeamProject
{
    public class Item : stat
    {
        public string Info { get; }
        public int Price { get; }
        public bool PurchaseSell { get; }
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
        // 아이템 기본 정보 표시
        public void PrintStatus(int number)
        {
            if (!PurchaseSell && !Equip) Console.WriteLine("\n- ");
            else Console.WriteLine($"{number}. ");
            if (Equip)
            {
                Console.WriteLine("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("E");
                Console.ResetColor();
                Console.WriteLine("]");
            }
            Console.Write($"{Name} |");
            if (this.atk != 0) Console.Write($"공격력 +{this.atk} |");
            if (this.def != 0) Console.Write($"방어력 +{this.def} |");
            if (this.hp != 0) Console.Write($"체력 +{this.hp} |");
            Console.Write($"{Info} |");
        }
    }
}
