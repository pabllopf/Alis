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
using System.Globalization;
using Alis.Benchmark.ClassVsStruct;
using Alis.Benchmark.IDs;
using Alis.Benchmark.InterfaceVsAbstract;
using Alis.Benchmark.Iterators;
using Alis.Benchmark.Strings;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using Ecs.CSharp.Benchmark;

namespace Alis.Benchmark
{
    /// <summary>
    ///     The main program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main entry point of the program
        /// </summary>
        /// <param name="args">Command-line arguments</param>
        public static void Main(string[] args)
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            BenchmarkSwitcher benchmark = BenchmarkSwitcher.FromTypes(new[]
            {
                typeof(CreateEntityWithOneComponent),
                typeof(CreateEntityWithTwoComponents),
                typeof(CreateEntityWithThreeComponents),

                typeof(SystemWithOneComponent),
                typeof(SystemWithTwoComponents),
                typeof(SystemWithThreeComponents),

                typeof(SystemWithTwoComponentsMultipleComposition),
                
                typeof(StringManipulationBenchmark),
                typeof(ClassVsStructBenchmark),
                typeof(IdStorageBenchmark),
                typeof(IterationBenchmarks),
                typeof(InterfaceVsAbstractBenchmark)
            });

            IConfig configuration = DefaultConfig.Instance
                .WithOptions(ConfigOptions.DisableOptimizationsValidator)
                .WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest));

            if (args.Length > 0)
            {
                benchmark.Run(args, configuration);
            }
            else
            {
                benchmark.Run(null, configuration);
            }
        }
    }
}