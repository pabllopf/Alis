
using Alis.Fluent;
using System;

namespace Alis.Core.SFML.Example
{
    class Program
    {
        public static void Main(string[] args)
        {
            VideoGame game = VideoGame.Builder()
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
                            .Add(new Sprite())
                        .Build())
                    .Build())
                .Build())
            .Build();

            Console.WriteLine($"author={game.Configuration.General.Author}");
            Console.WriteLine($"numofobjs=");

            game.Run();

            Console.WriteLine("Please press any key to close console.");
            Console.ReadKey();
        }
    }
}
