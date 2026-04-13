// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

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

        private static void PrintMenu()
        {
            Logger.Info("Select an example to run:");

            for (int i = 0; i < Examples.Count; i++)
            {
                Logger.Info($"{i + 1}. {Examples[i].Name}");
            }

            Logger.Info("Type a number or 'all' to run every example:");
        }

        private static void RunAllExamples()
        {
            for (int i = 0; i < Examples.Count; i++)
            {
                RunSingleExample(i);
            }

            Logger.Trace("End Program...");
        }

        private static void RunSingleExample(int index)
        {
            Logger.Trace($"Running example {index + 1}: {Examples[index].Name}");
            Examples[index].Run();
            Logger.Trace("------------------------------");
        }

        private sealed class ExampleEntry
        {
            public ExampleEntry(string name, Action run)
            {
                Name = name;
                Run = run;
            }

            public string Name { get; }

            public Action Run { get; }
        }
    }
}