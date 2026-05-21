

using Alis.Core.Aspect.Logging;
using System;
using System.Collections.Generic;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The run example
        /// </summary>
        private static readonly IReadOnlyList<ExampleEntry> Examples = new List<ExampleEntry>
        {
            new ExampleEntry("FastPriorityQueue", FastPriorityQueueExample.RunExample),
            new ExampleEntry("SimplePriorityQueue", SimplePriorityQueueExample.RunExample),
            new ExampleEntry("SimplePriorityQueue Try*", SimplePriorityQueueTryExample.RunExample),
            new ExampleEntry("GenericPriorityQueue", GenericPriorityQueueExample.RunExample),
            new ExampleEntry("StablePriorityQueue", StablePriorityQueueExample.RunExample)
        };

        /// <summary>
        ///     Main
        /// </summary>
        public static void Main()
        {
            PrintMenu();

            string input = (Console.ReadLine() ?? string.Empty).Trim();

            if (input.Equals("all", StringComparison.OrdinalIgnoreCase))
            {
                RunAllExamples();
                return;
            }

            if (int.TryParse(input, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= Examples.Count)
            {
                RunSingleExample(selectedIndex - 1);
                Logger.Trace("End Program...");
                return;
            }

            Logger.Warning("Invalid option. Use a number from the list or 'all'.");
        }

        /// <summary>
        /// Prints the menu
        /// </summary>
        private static void PrintMenu()
        {
            Logger.Info("Select an example to run:");

            for (int i = 0; i < Examples.Count; i++)
            {
                Logger.Info($"{i + 1}. {Examples[i].Name}");
            }

            Logger.Info("Type a number or 'all' to run every example:");
        }

        /// <summary>
        /// Runs the all examples
        /// </summary>
        private static void RunAllExamples()
        {
            for (int i = 0; i < Examples.Count; i++)
            {
                RunSingleExample(i);
            }

            Logger.Trace("End Program...");
        }

        /// <summary>
        /// Runs the single example using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        private static void RunSingleExample(int index)
        {
            Logger.Trace($"Running example {index + 1}: {Examples[index].Name}");
            Examples[index].Run();
            Logger.Trace("------------------------------");
        }

        /// <summary>
        /// The example entry class
        /// </summary>
        private sealed class ExampleEntry
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ExampleEntry"/> class
            /// </summary>
            /// <param name="name">The name</param>
            /// <param name="run">The run</param>
            public ExampleEntry(string name, Action run)
            {
                Name = name;
                Run = run;
            }

            /// <summary>
            /// Gets the value of the name
            /// </summary>
            public string Name { get; }

            /// <summary>
            /// Gets the value of the run
            /// </summary>
            public Action Run { get; }
        }
    }
}