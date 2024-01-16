using WMPLib;

namespace TeamProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool dataRun = false;
            Task.Run(() => SoundPlayer());//음악 제공
            Scene.StartPrintStartLogo();
            dataRun = DataStore.DataSelect();//신규 생성 선택 또는 불러오기 선택, 불러오기 데이터 없으면 신규 생성으로
            if(dataRun == false)
            {
                Player.NickName();
                Player.player.GetJob();
                Skill.SetSkill(Player.player.job);
            }            
            Item.ItemSetting();
            Item.PotionSetting();
            Scene.StartScene();
           
        }


        // 사운드 설정
        public static bool dungeonSound1 = false;
        public static bool dungeonSound2 = false;
        public static bool dungeonSound3 = false;
        static void SoundPlayer()
        {
            WindowsMediaPlayer soundMenu = new WindowsMediaPlayer();
            WindowsMediaPlayer soundDungeon1 = new WindowsMediaPlayer();
            WindowsMediaPlayer soundDungeon2 = new WindowsMediaPlayer();
            WindowsMediaPlayer soundDungeon3 = new WindowsMediaPlayer();
            string baseFolder = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName; // 현재 TeamProject 경로 
            string mainSoundFolder = baseFolder + @"\sound\mainBGM.mp3"; // 메인 사운드 경로
            string dungeonSoundFolder1 = baseFolder + @"\sound\dungeonBGM1.mp3"; // 던전 사운드 경로
            string dungeonSoundFolder2 = baseFolder + @"\sound\dungeonBGM2.mp3";
            string dungeonSoundFolder3 = baseFolder + @"\sound\dungeonBGM3.mp3";
            soundMenu.URL = mainSoundFolder;
            soundDungeon1.URL = dungeonSoundFolder1;
            soundDungeon2.URL = dungeonSoundFolder2;
            soundDungeon3.URL = dungeonSoundFolder3;
            soundMenu.settings.volume = 10;
            soundDungeon1.settings.volume = 10;
            soundDungeon2.settings.volume = 10;
            soundDungeon3.settings.volume = 10;
            while (true)
            {
                if (File.Exists(mainSoundFolder) && !dungeonSound1 && !dungeonSound2 && !dungeonSound3)
                {
                    soundDungeon1.controls.stop();
                    soundDungeon2.controls.stop();
                    soundDungeon3.controls.stop();
                    soundMenu.controls.play();
                }
                else if (File.Exists(dungeonSoundFolder1) && dungeonSound1)
                {
                    soundMenu.controls.stop();
                    soundDungeon1.controls.play();
                }
                else if (File.Exists(dungeonSoundFolder2) && dungeonSound2)
                {
                    soundMenu.controls.stop();
                    soundDungeon2.controls.play();
                }
                else if (File.Exists(dungeonSoundFolder3) && dungeonSound3)
                {
                    soundMenu.controls.stop();
                    soundDungeon3.controls.play();
                }
                Thread.Sleep(100);
            }
        }
    }
}
