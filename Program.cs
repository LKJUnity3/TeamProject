namespace TeamProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Player.NickName();
            Player.player.GetJob();
            Skill.SetSkill(Player.player.job);
            Item.ItemSetting();
            Scene.StartScene();
        }
    }
}
