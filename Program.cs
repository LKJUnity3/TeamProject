using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using static TeamProject.Program;

namespace TeamProject
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Player.NickName();
            Player.player.GetJob();



            Scene.StartScene();

        }
    }
}
