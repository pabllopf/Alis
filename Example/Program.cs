using Alis.Core;
using Alis.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;

namespace SFML
{
    /// <summary>Example of videogame.</summary>
    public class Program
    {

        /// <summary>Defines the entry point of the application.</summary>
        /// <param name="args">The arguments.</param>
        public static async Task Main(string[] args)
        {
            var watch = new Stopwatch();
            watch.Start();

            var game = new VideoGame(
                new Config("Example"),
                    new Scene("First",
                        new GameObject("Player", new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f)),
                            new Sprite(),
                            new Physics(),
                            new Sprite(),
                            new Physics()
                        ),

                        new GameObject("Player2", new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f)),
                            new Sprite()
                        ),
                        new GameObject("Player23", new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f)),
                            new Sprite()
                        ),
                        new GameObject("Player214", new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f)),
                            new Sprite()
                        ),
                        new GameObject("Player224", new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f)),
                            new Sprite()
                        ),
                        new GameObject("Player234", new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f)),
                            new Sprite()
                        ),
                        new GameObject("Player244", new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f)),
                            new Sprite()
                        ),
                        new GameObject("Player2474", new Transform(new Vector3(0f), new Vector3(0f), new Vector3(1f)),
                            new Sprite()
                        )
                    )
            );

            game.Run();

            watch.Stop();
            Console.WriteLine($"Total Videogame Time: " + watch.ElapsedMilliseconds + " ms");

            Console.WriteLine("Procesesor: " + Environment.ProcessorCount);

            LocalData.Save("Example", game);

            /*string name = Test_Normal(100);
            string name2 = await Test_Task(100);

            Console.WriteLine(name);
            Console.WriteLine(name2);
            
            Console.ReadLine();*/
        }

        private static async Task<string> Test_Task(int size)
        {
            var watch = new Stopwatch();
            watch.Start();

            await Task.WhenAll(GenerateTasks(size)); 
            
            watch.Stop();
            return $"Total Test_Task Time: " + watch.ElapsedMilliseconds + " ms";
        }

        private static List<Task> GenerateTasks(int size)
        {


            List<Task> result = new List<Task>();

            for (int i = 0; i < size; i++)
            {
                result.Add(ProcessAsync(i));
            }

            return result;
        }

        private static async Task ProcessAsync(int i ) 
        {
            await Task.Delay(new Random().Next(10, 100));
            Console.WriteLine("Process: " + i);
        }

        private static string Test_Normal(int size) 
        {
            var watch = new Stopwatch();
            watch.Start();

            for (int i =0; i < size;i++) 
            {
                Thread.Sleep(new Random().Next(10, 100));
            }

            watch.Stop();
            return $"Total Test_Normal Time: " + watch.ElapsedMilliseconds + " ms";
        }


        /*
        private static async Task<string> Test_Task(List<Scene> scenes)
        {
            var watch = new Stopwatch();
            watch.Start();

            List<Task> launcher = new List<Task>();

            for (int i = 0; i < scenes.Count;i++) 
            {
                launcher.Add(Launch(scenes[i]));
            }

            await Task.WhenAll(launcher);

            watch.Stop();
            return $"Total Test_With_Task Time: " + watch.ElapsedMilliseconds + " ms";
        }

        private static async Task Launch(Scene scene) 
        {
            scene.Update();
        } 


        public static string Test_Normal(List<Scene> scenes) 
        {
            var watch = new Stopwatch();
            string result = "";
            watch.Start();

            foreach (Scene scene in scenes) 
            {
                scene.Update();
            }

            watch.Stop();
            return $"Total Test_Normal Time: " + watch.ElapsedMilliseconds + " ms";
        }
        */

    }
}
