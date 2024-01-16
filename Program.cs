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
        public static bool dungeonSound = false;
        static void SoundPlayer()
        {
            WindowsMediaPlayer soundMenu = new WindowsMediaPlayer();
            WindowsMediaPlayer soundDungeon = new WindowsMediaPlayer();
            string baseFolder = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent.FullName; // 현재 TeamProject 경로 
            string mainSoundFolder = baseFolder + @"\sound\mainBGM.mp3"; // 메인 사운드 경로
            string dungeonSoundFolder = baseFolder + @"\sound\dungeonBGM.mp3"; // 던전 사운드 경로
            soundMenu.URL = mainSoundFolder;
            soundDungeon.URL = dungeonSoundFolder;
            soundMenu.settings.volume = 10;
            soundDungeon.settings.volume = 10;
            while (true)
            {
                if (File.Exists(mainSoundFolder) && !dungeonSound)
                {
                    soundDungeon.controls.stop();
                    soundMenu.controls.play();
                }
                else if (File.Exists(dungeonSoundFolder) && dungeonSound)
                {
                    soundMenu.controls.stop();
                    soundDungeon.controls.play();
                }
                Thread.Sleep(100);
            }
        }
    }
}
