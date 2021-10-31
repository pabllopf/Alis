using Alis.FluentApi;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alis.Core.Sfml.Example
{
    class Program
    {
        public static void Main(string[] args)
        {
            VideoGame
                .Create()
                    .Settings(setting => setting
                        .General(config => config
                            .Name("The Best Game")
                            .Author("Paco Jimenez")
                        .Build()) 
                        
                        .Window(config => config
                            .Resolution(512, 512)
                        .Build())
                    .Build())
                .Run();


            /*
            VideoGame.Builder()
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
                            .With<Sprite>(new Sprite(@"C:\\Users\\wwwam\\Documents\\Repos\\Alis\\src\\2_adaptation\\sfml\\alis.core.sfml.example\\assets\\start_button.png"))
                        .Build())
                        .With<GameObject>(obj => obj
                            .With<Name>(name => "Enemy")
                            .Is<Static>(state => false)
                            .Is<Active>(state => true)
                            .With<Sprite>(new Sprite(@"C:\\Users\\wwwam\\Documents\\Repos\\Alis\\src\\2_adaptation\\sfml\\alis.core.sfml.example\\assets\\start_button.png"))
                        .Build())
                    .Build())
                .Build())
            .Run();*/

            /*.Game.Setting.GameObject.MaxComponents = 128;
            Core.Game.Setting.GameObject.HasDuplicateComponents = true;
            Core.Game.Setting.GameObject.Reset();

            GameObject gameObject = new GameObject("Player");
            var i = new BoxCollider2D();
            gameObject.Add(new BoxCollider2D());
            //gameObject.Add(i);
            //gameObject.Remove<BoxCollider2D>();
            //gameObject.Remove<BoxCollider2D>();

            Console.WriteLine($"Name={gameObject.Name.Value}");
            Console.WriteLine($"Tag={gameObject.Tag.Value}");
            Console.WriteLine($"IsActive={gameObject.IsActive.Value}");
            Console.WriteLine($"IsStatic={gameObject.IsStatic.Value}");
            Console.WriteLine($"Size={gameObject.Size}");
            Console.WriteLine($"Count={gameObject.Count}");

            //Console.WriteLine($"Has Sprite={gameObject.Contains<Sprite>()}");
            Console.WriteLine($"Has BoxCollider2D={gameObject.Contains<BoxCollider2D>()}");

                */
            Console.WriteLine("Please press any key to close console.");
            Console.ReadKey();
        }
    }
}
