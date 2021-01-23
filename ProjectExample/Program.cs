
using Alis.Tools;
using System;
using System.Diagnostics;
using System.Reflection;

namespace ProjectExample
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigGame config = new ConfigGame("Example");
            VideoGame videoGame = new VideoGame(config);

            Scene scene = new Scene("MainMenu");

            GameObject gameObject = new GameObject("Player");

            gameObject.Add(new AudioSource(Application.ProjectPath + "/Resources/Example.wav", true));
            scene.Add(gameObject);
            videoGame.Add(scene);


     
            videoGame.Run();

            Console.ReadKey();
        }
    }
}
