using System;
using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main
        /// </summary>
        public static void Main()
        {
            FastPriorityQueueExample.RunExample();

            Logger.Info("------------------------------");

            SimplePriorityQueueExample.RunExample();

            Logger.Info("End Program...");
        }
    }
}