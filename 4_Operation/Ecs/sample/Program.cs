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

using System;
using System.Linq;
using Alis.Core.Ecs.Sample.Samples;

namespace Alis.Core.Ecs.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    internal class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        private static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                ExecuteSelection(args[0]);
                return;
            }

            PrintMenu();
            Console.Write("Choose a sample by number/key, or type 'all': ");
            string selection = Console.ReadLine()?.Trim() ?? string.Empty;

            ExecuteSelection(selection);
        }

        /// <summary>
        /// Prints the menu
        /// </summary>
        private static void PrintMenu()
        {
            Console.WriteLine("Alis ECS sample selector");
            Console.WriteLine("------------------------");

            for (int i = 0; i < SampleCatalog.All.Count; i++)
            {
                IEcsSample sample = SampleCatalog.All[i];
                Console.WriteLine($"{i + 1}. {sample.Title} ({sample.Key})");
                Console.WriteLine($"   {sample.Description}");
            }

            Console.WriteLine("A. Run all samples (all)");
        }

        /// <summary>
        /// Executes the selection using the specified selection
        /// </summary>
        /// <param name="selection">The selection</param>
        private static void ExecuteSelection(string selection)
        {
            if (string.IsNullOrWhiteSpace(selection))
            {
                Console.WriteLine("No selection provided.");
                return;
            }

            if (selection.Equals("all", StringComparison.OrdinalIgnoreCase) ||
                selection.Equals("a", StringComparison.OrdinalIgnoreCase))
            {
                RunAll();
                return;
            }

            if (int.TryParse(selection, out int index) && index >= 1 && index <= SampleCatalog.All.Count)
            {
                RunOne(SampleCatalog.All[index - 1], index);
                return;
            }

            IEcsSample sampleByKey = SampleCatalog.All.FirstOrDefault(
                sample => sample.Key.Equals(selection, StringComparison.OrdinalIgnoreCase));

            if (sampleByKey is not null)
            {
                int indexByKey = 0;
                for (int i = 0; i < SampleCatalog.All.Count; i++)
                {
                    if (ReferenceEquals(SampleCatalog.All[i], sampleByKey))
                    {
                        indexByKey = i + 1;
                        break;
                    }
                }

                RunOne(sampleByKey, indexByKey);
                return;
            }

            Console.WriteLine($"Invalid selection: '{selection}'.");
            Console.WriteLine("Use a sample number, a sample key, or 'all'.");
        }

        /// <summary>
        /// Runs the all
        /// </summary>
        private static void RunAll()
        {
            for (int i = 0; i < SampleCatalog.All.Count; i++)
            {
                RunOne(SampleCatalog.All[i], i + 1);
            }
        }

        /// <summary>
        /// Runs the one using the specified sample
        /// </summary>
        /// <param name="sample">The sample</param>
        /// <param name="index">The index</param>
        private static void RunOne(IEcsSample sample, int index)
        {
            Console.WriteLine();
            Console.WriteLine($"=== [{index}] {sample.Title} ({sample.Key}) ===");

            try
            {
                sample.Run();
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Sample failed: {exception.Message}");
            }

            Console.WriteLine("=== End ===");
        }
    }
}