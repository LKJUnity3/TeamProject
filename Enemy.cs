namespace TeamProject
{
    internal class Enemy : stat
    {
        public bool alive { get; set; }
        public Enemy(string name,int lv,int atk,int hp) 
        {
            this.Name = name;
            this.lv = lv;
            this.atk = atk;
            this.hp = hp;
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
                int Monster_type = random.Next(0, 3);
                switch (Monster_type)
                {
                    case 0:
                        Enemy Japanese_Military = new Enemy("왜군", 2, 5, 15);
                        enemies.Add(Japanese_Military);
                        break;
                    case 1:
                        Enemy Tang_Military = new Enemy("당나라군", 5, 10, 25);
                        enemies.Add(Tang_Military);
                        break;
                    case 2:
                        Enemy Baek_Je_Military = new Enemy("백제군", 3, 9, 10);
                        enemies.Add(Baek_Je_Military);
                        break;
                    case 3:
                        Enemy Tang_King = new Enemy("당태종", 3, 9, 10);
                        enemies.Add(Tang_King);
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
                int Monster_type = random.Next(0, 1);
                switch (Monster_type)
                {
                    case 0:
                        Enemy Hwang_Hee = new Enemy("황희 정승", 2, 5, 15);
                        enemies.Add(Hwang_Hee);
                        break;
                    case 1:
                        Enemy Jung_Yakyong = new Enemy("정약용", 5, 10, 25);
                        enemies.Add(Jung_Yakyong);
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
                int Monster_type = random.Next(0, 1);
                switch (Monster_type)
                {
                    case 0:
                        Enemy Kim_sangmu = new Enemy("김상무", 2, 5, 15);
                        enemies.Add(Kim_sangmu);
                        break;
                    case 1:
                        Enemy Kim_daeri = new Enemy("퇴사 일보직전 김대리", 5, 10, 25);
                        enemies.Add(Kim_daeri);
                        break;

                }
            }
            return enemies;
        }
        class BossMonster
        {
            public string Name { get; set; }
            public int Hp { get; set; }
            public int AtkDme { get; set; }
            public string SpAbility { get; set; }

            public string StageType { get; set; }

            public BossMonster(string name, int hp, int atkdme, string spAbility, string stageType = null)
            {
                Name = name;
                Hp = hp;
                AtkDme = atkdme;
                SpAbility = spAbility;
                StageType = stageType;
            }


        }
        class BossMonsters
        {

            void Main()
            {
                BossMonsterList();
            }

            void BossMonsterList()
            {
                List<BossMonster> bossMonsters = new List<BossMonster>();

                // 보스 몬스터 리스트에 보스 몬스터 추가
                bossMonsters.Add(new BossMonster("의자왕", 1000, 50, "백제의 분노"));
                bossMonsters.Add(new BossMonster("세종", 1200, 60, "나랏말싸미 듕귁에 달아"));
                bossMonsters.Add(new BossMonster("한효승 매니저", 1000, 70, "여러분, 열공중 인증하기 눌러주세요."));

                // 보스 몬스터 정보 출력
                foreach (var bossMonster in bossMonsters)
                {
                    Console.WriteLine($"Boss: {bossMonster.Name}");
                    Console.WriteLine($"Health: {bossMonster.Hp}");
                    Console.WriteLine($"Attack Damage: {bossMonster.AtkDme}");
                    Console.WriteLine($"Special Ability: {bossMonster.SpAbility}");
                    Console.WriteLine();
                }
            }
        }
    }
}
