//-------------------------------------------------------------------------------------------------
// <author>Pablo Perdomo Falcón</author>
// <copyright file="Input.cs" company="Pabllopf">GNU General Public License v3.0</copyright>
//-------------------------------------------------------------------------------------------------
namespace Alis.Core
{
    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;

    /// <summary>Manage the inputs of game.</summary>
    public class Input
    {
        public Input()
        {
        }

        internal Task Start()
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                watch.Stop();
                Console.WriteLine($"  Time to Start INPUT: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        internal Task Update() 
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                watch.Stop();
                Console.WriteLine($"  Time to UPDATE: " + watch.ElapsedMilliseconds + " ms");
            });
        }

        private Task PullTask() 
        {
            return Task.Run(() =>
            {
                var watch = new Stopwatch();
                watch.Start();

                Task.Delay(1000).Wait();

                ConsoleKeyInfo key = Console.ReadKey();

                Console.WriteLine("Press:" + key.KeyChar);

                watch.Stop();
                Console.WriteLine($"  Time to PULL: " + watch.ElapsedMilliseconds + " ms");
            });
        }
    }
}