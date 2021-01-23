
using Alis.Tools;
using System;

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


            Input.OnPressKeyOnce += Input_OnPressKeyOnce;


            videoGame.Run();

            Console.ReadKey();
        }

        private static void Input_OnPressKeyOnce(object sender, SFML.Window.Keyboard.Key e)
        {
            Console.WriteLine("Key: " + e);
        }
    }
}
