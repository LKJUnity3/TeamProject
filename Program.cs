using WMPLib;

namespace TeamProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool dataRun = false;
            Task.Run(() => SoundPlayer());
            dataRun = DataStore.DataSelect();
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


        static void SoundPlayer()
        {
            WindowsMediaPlayer soundMenu = new WindowsMediaPlayer();
            string baseFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory); // 현재 프로젝트의 경로
            string playFolder = Directory.GetParent(baseFolder).Parent.Parent.Parent.FullName + @"\sound\mainBGM.mp3"; // 해당 경로에서 불필요한 부분 제거하고 원하는 폴더 추가
            if (File.Exists(playFolder))
            {
                soundMenu.URL = playFolder;
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
