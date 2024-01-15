using WMPLib;

namespace TeamProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(() => SoundPlayer());
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
            soundMenu.URL = @"D:\C\C#\TeamProject\sound\mainBGM.mp3";
            soundMenu.settings.volume = 8;
            while (true)
            {
                soundMenu.controls.play();
                Thread.Sleep(100);
            }
        }
    }
}
