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
            Console.WriteLine(Test_Normal());

            Console.WriteLine(await Test_Task());

            Console.ReadLine();
        }

        private static async Task<string> Test_Task()
        {
            var watch = new Stopwatch();
            watch.Start();

            await Task.WhenAll(
            Launch(1),
            Launch(2),
            Launch(3),
            Launch(4),
            Launch(5));



            watch.Stop();
            return $"Total Test_Normal Time: " + watch.ElapsedMilliseconds + " ms";
        }

        private static async Task Launch(int i) 
        {
            await Task.Delay(1000);
            Console.WriteLine("Run one threead" + i);
        } 


        public static string Test_Normal() 
        {
            var watch = new Stopwatch();
            string result = "";
            watch.Start();
            for (int j = 0; j < 5; j++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Run one threead" + j);
            }

            watch.Stop();
            return $"Total Test_Normal Time: " + watch.ElapsedMilliseconds + " ms";
        }


    }
}
