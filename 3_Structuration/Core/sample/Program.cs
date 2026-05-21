

using System;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs;

namespace Alis.Core.Sample
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
            Logger.Info("Alis.Core.Sample with " + args.Length + " args");


            using Scene scene = new Scene();

            for (int i = 0; i < 3; i++)
            {
                scene.Create<string, ConsoleText>("Hello, Scene!", new(ConsoleColor.Blue));
            }

            scene.Update();
        }
    }
}