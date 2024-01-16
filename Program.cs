using WMPLib;

namespace TeamProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Task.Run(() => SoundPlayer());
            Player.NickName();
            Player.player.GetJob();
            Skill.SetSkill(Player.player.job);
            Item.ItemSetting();
            Item.PotionSetting();
            Scene.StartScene();
        }


        static void SoundPlayer()
        {
            WindowsMediaPlayer soundMenu = new WindowsMediaPlayer();
            // 실행 파일이 있는 디렉토리의 sound 폴더 안에 있는 mainBGM.mp3 파일을 지정
            string relativePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "sound", "mainBGM.mp3");
            if (File.Exists(relativePath))
            {
                soundMenu.URL = relativePath;
                soundMenu.settings.volume = 10;
                while (true)
                {
                    soundMenu.controls.play();
                    Thread.Sleep(100);
                }
            }
            else
            {
                Console.WriteLine("파일을 불러오지 못하였습니다. 2초 뒤 종료합니다.");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }
    }
}
