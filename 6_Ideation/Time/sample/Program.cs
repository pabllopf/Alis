

using System;
using System.Threading;

namespace Alis.Core.Aspect.Time.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            Clock clock = Clock.Create();
            Thread.Sleep(150);
            clock.Stop();

            Console.WriteLine($"First measurement: {clock.ElapsedMilliseconds} ms");

            clock.Restart();
            Thread.Sleep(75);
            clock.Stop();

            Console.WriteLine($"Second measurement after restart: {clock.ElapsedMilliseconds} ms");
            Console.WriteLine($"Elapsed ticks: {clock.ElapsedTicks}");
            Console.WriteLine($"Elapsed string: {clock}");
        }
    }
}
