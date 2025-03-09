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
using BenchmarkDotNet.Running;

namespace Alis.Benchmark
{
    /// <summary>
    /// The main program class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point of the program
        /// </summary>
        /// <param name="args">Command-line arguments</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Select the benchmark to run:");
            Console.WriteLine("1 - String manipulation benchmark");
            Console.WriteLine("2 - Class vs struct benchmark");
            Console.WriteLine("3 - Run both benchmarks");
            Console.Write("Option: ");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    BenchmarkRunner.Run<StringManipulationBenchmark>();
                    break;

                case "2":
                    BenchmarkRunner.Run<ClassVsStructBenchmark>();
                    break;

                case "3":
                    BenchmarkRunner.Run<StringManipulationBenchmark>();
                    BenchmarkRunner.Run<ClassVsStructBenchmark>();
                    break;

                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}