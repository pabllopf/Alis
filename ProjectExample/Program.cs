
using Alis.Tools;
using System;

namespace ProjectExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigGame config = new ConfigGame("GameExample");
            VideoGame game = new VideoGame(config);

            Scene scene1 = new Scene("MainMenu");
            Scene playScene = new Scene("Game");

            GameObject player = new GameObject("Player");


            player.Add(new AudioSource("Example.wav", true));

            //scene1.Add(player);
            scene1.Add(player);
            playScene.Add(player);


            game.Add(scene1);
            game.Add(playScene);

            LocalData.Save<VideoGame>("Alis", game);


            VideoGame.Start();



            Console.ReadKey();
        }
    }
}
