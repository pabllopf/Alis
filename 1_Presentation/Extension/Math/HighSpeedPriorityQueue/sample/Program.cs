using System;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Sample
{
    /// <summary>
    /// The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Main
        /// </summary>
        public static void Main()
        {
            FastPriorityQueueExample.RunExample();

            Console.WriteLine("------------------------------");

            SimplePriorityQueueExample.RunExample();
            
            Console.WriteLine("End Program...");
        }
    }
}