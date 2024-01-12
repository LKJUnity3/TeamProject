using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using static TeamProject.Program;

namespace TeamProject
{
    internal class Program
    {
        public enum SceneType // Enum 
        {
            Menu = 0,
            STATUS,
            INVENTORY,
            SHOP,
            DUNGEON
        }


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
