using Alis.FluentApi;
using System;
using System.Numerics;

namespace Alis.Core.Example
{
    public class Program
    {
        /// <summary>
        /// Mains the specified arguments.
        /// </summary>
        /// <param name="args">The arguments.</param>
        /// <returns></returns>
        static void Main(string[] args)
        {
            /*
            GameObject gameObject = new GameObject("Player");
            gameObject.Add(new Sprite());
            gameObject.Add(new Particle());

            Console.WriteLine($"Gameobject {gameObject.Name} has {gameObject.Components.Length} component");

            gameObject.Remove<Sprite>();
            gameObject.Remove<Sprite>();

            Console.WriteLine($"Gameobject {gameObject.Name} has {gameObject.Components.Length} component");


            Vector3 vector1 = new(1, 1, 1);
            Vector3 vector2 = new(1, 1, 1);

            Console.WriteLine(vector2 - vector1);

            var gameObject1 =
                GameObject.Create()
                    .WithName("Alfredo")
                .Build();


            GameObject gameObject2 =
                GameObject.Create()
                .Build();


            Console.WriteLine($"Player 1={gameObject1.Name.Value} tag={gameObject1.Tag.Value} Length={gameObject1.Components.Length} | Player 2 = {gameObject2.Name.Value} tag={gameObject2.Tag.Value} Length={gameObject2.Components.Length}");
            */
            /*
            Game game =
                Game.Create()
                    .Configuration()
                
                    .SceneManager()
                        .WithScene("MainScene")
                            .WithGameObject("Player")
                                .WithComponent<Sprite>()
                                .WithComponent<AudioSource>()

                .Build();

            Game game2 =
                Game.Create()
                    .Configuration()

                    .SceneManager()
                        .WithScene("MainScene")
                            .WithGameObject("Player")
                                .WithComponent<Sprite>()
                                .WithComponent<AudioSource>()
                             
                    
                .Build();
            */

            ////////////////////////////////////////
            // Game Example: Alis Game             
            ////////////////////////////////////////
            Game.Builder()
                .Configuration(config => config
                    .General(i => i
                        .With<Name>(name => "Alis Game Example")
                        .With<Author>(author => "Pablo Perdomo Falcón")
                        .Build())
                    .Time(i => i
                        .SetMax<TimeStep>(timeStep => 30.0f)
                        .SetMax<FramesPerSecond>(fps => 60.0f)
                        .Build())
                    .Build())
                
                .ManagerOf<Scene>(manager => manager
                    .Add<Scene>(scene => scene
                    .With<Name>(name => "Main Scene")
                        .With<GameObject>(obj => obj
                            .With<Name>(name => "Player")
                            .Is<Static>(state => false)
                            .Is<Active>(state => true)
                        .Build())
                    .Build())
                .Build())
             .Run();

            /*

            Configuration config = 
                Configuration.Builder()
                    .General(i => i
                        .With<Name>(name => "Alis Game Example")
                        .With<Author>(author => "Pablo Perdomo Falcón")
                        .Build())
                    .Build();

            GeneralConfig general =
                GeneralConfig.Builder()
                    .With<Name>(name => "Alis Game Example")
                    .With<Author>(author => "Pablo Perdomo Falcón")
                    .Build();

            TimeConfig time =
                TimeConfig.Builder()
                .SetMax<TimeStep>(timeStep => 1.0f)
                .SetMax<FramesPerSecond>(fps => 1.0)
                .Build();

            Scene scene =
                Scene.Builder()
                .With<Name>(name => "Main Scene")
                .Build();

            GameObject obj =
                   GameObject.Builder()
                   .With<Name>(name => "Player")
                   .Is<Static>(state => false)
                   .Is<Active>(state => true)
                   .Build();


            Console.WriteLine($"Name Game = {game.Configuration.General.Name}");
            Console.WriteLine($"Author Game = {game.Configuration.General.Author}");
            game.Run();
            */
            Console.WriteLine("Please press any key to close the windows.");
            Console.ReadKey();
        }
    }
}
