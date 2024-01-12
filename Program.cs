namespace TeamProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            if (Player.player.Name == null)
            {
                Player.NickName();
            }
            Scene.StartScene();
            
        }
    }
}
