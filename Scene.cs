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
            DUNGEON,
            BATTLE
        }

        
        public static void StartScene()
        {
            DataStore.DataSave();

            Console.Clear();
            Console.WriteLine("대한민국에 오신 여러분 환영합니다.");
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
                    case (int)SceneType.INVENTORY: Item.InvenMenu(); break;
                    case (int)SceneType.SHOP: Item.StoreMenu(); break;
                    case (int)SceneType.DUNGEON:
                        Program.dungeonSound = true;
                        Dungeon.DungeonChoiceMenu();
                        break;
                    default: StartScene(); break;
                }
            }

           
        }

        public static void StartPrintStartLogo()
        {
            Console.WriteLine("                   Z.   .          ....Z.           ");
            Console.WriteLine("         .     ....?.~:.~+++7?7++=:.:~,~....   . .  ");
            Console.WriteLine("        .,..,,,,....,::.:,..~~.~~. :,,::, ...,,,. .,");
            Console.WriteLine("        .MM,:..:.~.,:.~..:~.~.~.~:,.~.~,.~.:~.:.MN..");
            Console.WriteLine("           ,MMMMNMMMMMMMMMMMMMMMMMMMMMMMMMMM8MMMM,  ");
            Console.WriteLine("            .NMM..,:=I77$77IZZ$ZZ777777I=:,..MMM.   ");
            Console.WriteLine("            . .OZZZ:Z??:??OZ==:==$8??~?IZ:ZZOM...   ");
            Console.WriteLine("     .,...~I:.,,.=~.,.:,.,..:..:.~.~. ~.=~,.,:.7~..... ");
            Console.WriteLine("      .M8,...,:..: ,.~=.,: ,,..~,.~.,:.:.~. .~....NM.");
            Console.WriteLine("         .$ZZ7MM7MMMMMMMMMMMMMMMMMNMMMMMMMMMMMMMMMM");
            Console.WriteLine("         ::..Z:?~,?~=?=,=?~,+,,+?,,?+,~+,,I::++M:.");
            Console.WriteLine("         ,....~:~,:?=:~+:~+~..?..:~..?.~?7~,~~=~~.");
            Console.WriteLine("          ..,.+,I,,=+,:D,.~:,,D==++==N::??:,?,:..       ");
            Console.WriteLine("          :,~+~...==OOMOO==O?NOO=?OOMOZ?+. ..=.~.       ");
            Console.WriteLine("   ..  .,7:=,I,+,?:I,=:7,~I~.......~I~,I:=,I:?,+,I,~:7,.");
            Console.WriteLine("   .=.=.? = ?.~.+:~++~,?~. .. . .. .:?:~=+::+=~.?.= ?.=.=,");
            Console.WriteLine("   .... ... ....=...,... ?::::.::::?....,...=.... .........");
            Console.WriteLine("  ....................... ~~~~~~~~~~=.............  ........ ");
            Console.WriteLine("");
            Console.WriteLine("================================================================");
            Console.WriteLine("        Start :  환생의 길, 시대를 넘어서       ");
            Console.WriteLine("================================================================");
            Console.ReadKey();
        }

        public static void EndingScene()
        {
            EndingPrintStartLogo();
            Console.WriteLine("게임 종료");
            Console.ReadKey();
        }

        public static void EndingPrintStartLogo()
        {
            Console.WriteLine("....................?...................");
            Console.WriteLine("....................M...................");
            Console.WriteLine("....................D,..................");
            Console.WriteLine("...................M=+..................");
            Console.WriteLine("..................DZI.Z.................");
            Console.WriteLine(".................7:O,.:I................");
            Console.WriteLine("................,N.D.D+N................");
            Console.WriteLine("................MMZD,N.I,...............");
            Console.WriteLine("................7.ZMM,:.................");
            Console.WriteLine("..............NMO:DMM=..I?..............");
            Console.WriteLine("...........,.:MZI:.MM~..+N..............");
            Console.WriteLine(".........:.,:M?ZO,.,M=..8M+.............");
            Console.WriteLine(".......,...,$77$D, .M7..NDD7,.,.........");
            Console.WriteLine("........,::,ZDZ$D~..N=..O$8~.:..........");
            Console.WriteLine("........:~=:ZDZN~..,O,..8Z8$ ==,........");
            Console.WriteLine("......::,++?8MDM...78,..Z=?7,~~,,,......");
            Console.WriteLine(".....,~++$IINMI+?7.,M:..7Z8=7I=+~.......");
            Console.WriteLine(".....,=?=NMMIOM7:7..=O,.=OM$M.?+=:,.....");
            Console.WriteLine(".....:I??MM~I,O:=M..=D,..DM$$8I.I+,.....");
            Console.WriteLine(".....++OMZI$+?NO~M..I=.,88ZMN$.:,I=.....");
            Console.WriteLine(".....=?MNNZ8OMMZ~M,.I.:I7DNMN$I,D,=.....");
            Console.WriteLine(".....~+MMM$MDMM8=M.~7NZ7ZMNNM7N~I8~,....");
            Console.WriteLine(".....~:MMNMMNMMNIM+?DMOZONMMM$IODO+.....");
            Console.WriteLine(".......DMNNMDN8D=NZZO8OZ7DNMDNN7DI,,....");
            Console.WriteLine("........................................");
            Console.ReadKey();
        }
    }
}
