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
            List<Scene> scenes = Enumerable.Repeat(new Scene("name"), 100).ToList();

            string name = Test_Normal(scenes);
            string name2 = await Test_Task(scenes);

            Console.WriteLine(name);
            Console.WriteLine(name2);
            //Console.WriteLine();

            Console.ReadLine();
        }

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


    }
}
