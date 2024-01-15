namespace TeamProject
{
    public class Enemy : stat
    {
        public bool alive { get; set; }
        public int dropGold { get; set; }        
                
        public Enemy(string name, int lv, int hp, int atk, int def)
        {
            this.Name = name;
            this.lv = lv;
            this.atk = atk;
            this.hp = hp;
            dropGold = new Random().Next(10, 200);
            this.def = def;
            alive = true;
        }
        public void Victim(int atk)
        {
            hp -= atk;
            if (hp < 0)
            {
                hp = 0;
            }
            if (hp == 0)
            {
                alive = false;
            }
        }
        public static List<Enemy> SamGuk_EnemySetting()
        {
            List<Enemy> enemies = new List<Enemy>();
            Random random = new Random();
            int Monster_count = random.Next(1, 5);
            for (int i = 0; i < Monster_count; i++)
            {
                int Monster_type = random.Next(0, 4);
                switch (Monster_type)
                {
                    case 0:
                        Enemy Japanese_Military = new Enemy("왜군", 2, 20, 15, 10);
                        enemies.Add(Japanese_Military);
                        break;
                    case 1:
                        Enemy Tang_Military = new Enemy("당나라군", 3, 25, 20, 25);
                        enemies.Add(Tang_Military);
                        break;
                    case 2:
                        Enemy Baek_Je_Military = new Enemy("백제군", 4, 30, 25, 30);
                        enemies.Add(Baek_Je_Military);
                        break;
                    case 3:
                        Enemy Tang_King = new Enemy("당태종", 5, 35, 30, 40);
                        enemies.Add(Tang_King);
                        break;
                    case 4:
                        Enemy King_Chair = new Enemy("의자왕", 10, 100, 50, 60);
                        enemies.Add(King_Chair);
                        break;
                }
            }
            return enemies;
        }
        public static List<Enemy> Josun_EnemySetting()
        {
            List<Enemy> enemies = new List<Enemy>();
            Random random = new Random();
            int Monster_count = random.Next(1, 5);
            for (int i = 0; i < Monster_count; i++)
            {
                int Monster_type = random.Next(0, 4);
                switch (Monster_type)
                {
                    case 0:
                        Enemy Hwang_Hee = new Enemy("황희 정승", 6, 40, 35, 45 );
                        enemies.Add(Hwang_Hee);
                        break;
                    case 1:
                        Enemy Jung_Yakyong = new Enemy("정약용", 7, 50, 45, 50);
                        enemies.Add(Jung_Yakyong);
                        break;
                    case 2:
                        Enemy Suyang_daegun = new Enemy("수양대군", 8, 60, 50, 60);
                        enemies.Add(Suyang_daegun);
                        break;
                    case 3:
                        Enemy Yi_Sunsin = new Enemy("이순신", 9, 70, 60, 70);
                        enemies.Add(Yi_Sunsin);
                        break;
                    case 4:
                        Enemy King_sejong = new Enemy("세종대왕", 15, 90, 80, 90);
                        enemies.Add(King_sejong);
                        break;

                }
            }
            return enemies;
        }
        public static List<Enemy> Korea_EnemySetting()
        {
            List<Enemy> enemies = new List<Enemy>();
            Random random = new Random();
            int Monster_count = random.Next(1, 5);
            for (int i = 0; i < Monster_count; i++)
            {
                int Monster_type = random.Next(0, 4);
                switch (Monster_type)
                {
                    case 0:
                        Enemy Kim_sangmu = new Enemy("김상무", 10, 80, 70, 80);
                        enemies.Add(Kim_sangmu);
                        break;
                    case 1:
                        Enemy Kim_daeri = new Enemy("퇴사 일보직전 김대리", 11, 90, 80, 90);
                        enemies.Add(Kim_daeri);
                        break;
                    case 2:
                        Enemy Pak_kwacang = new Enemy("만성피로 박과장", 12, 100,90, 100);
                        enemies.Add(Pak_kwacang);
                        break;
                    case 3:
                        Enemy Cha_hyun = new Enemy("워커홀릭 차현 본부장", 13, 105,95, 105);
                        enemies.Add(Cha_hyun);
                        break;
                    case 4:
                        Enemy Han_hyoseung_Manager = new Enemy("한효승 매니저님", 25, 200,150, 150);
                        enemies.Add(Han_hyoseung_Manager);
                        break;
                }
            }
            return enemies;
        }
        
        public static void ItemDrop()
        {
            int randomItem = new Random().Next(1, 100);            
            int selectDropItem = new Random().Next(0, Item.potions.Count);            
            if (randomItem <= 100)
            {                                
                Item.potions[selectDropItem].ConsumItem++;
                BattleScene.earnedList.Add(Item.potions[selectDropItem].Name);
            }
            else
            {
                
            }                        
        }
    }
}
