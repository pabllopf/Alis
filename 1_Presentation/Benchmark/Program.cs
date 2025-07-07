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

using System.Globalization;
using Alis.Benchmark.ClassVsStruct;
using Alis.Benchmark.CustomCollections.ArrayPools;
using Alis.Benchmark.CustomCollections.Arrays;
using Alis.Benchmark.CustomCollections.Frugals;
using Alis.Benchmark.CustomCollections.Lists;
using Alis.Benchmark.CustomCollections.Stacks;
using Alis.Benchmark.CustomCollections.Tables;
using Alis.Benchmark.CustomEcs;
using Alis.Benchmark.EntityComponentSystem.CreateEntityWithOneComponent;
using Alis.Benchmark.EntityComponentSystem.CreateEntityWithThreeComponents;
using Alis.Benchmark.EntityComponentSystem.CreateEntityWithTwoComponents;
using Alis.Benchmark.IDs;
using Alis.Benchmark.InterfaceVsAbstract;
using Alis.Benchmark.Iterators;
using Alis.Benchmark.Loop;
using Alis.Benchmark.RemoveAtVsRemoveUnnorderAt;
using Alis.Benchmark.Strings;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using SystemWithOneComponent = Alis.Benchmark.EntityComponentSystem.SystemWithOneComponent.SystemWithOneComponent;
using SystemWithThreeComponents = Alis.Benchmark.EntityComponentSystem.SystemWithThreeComponents.SystemWithThreeComponents;
using SystemWithTwoComponents = Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponents.SystemWithTwoComponents;
using SystemWithTwoComponentsMultipleComposition = Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponentsMultipleComposition.SystemWithTwoComponentsMultipleComposition;

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
                typeof(InterfaceVsAbstractBenchmark),

                typeof(NativeArrayUnsafeVsNativeArraySafe),
                
                typeof(StacksBenchmarks),
                typeof(FrugalsBenchmarks),
                
                typeof(TablesBenchmarks),

                typeof(RemoveAtVsRemoveUnnorderAtListBenchmark),

                typeof(ArrayPoolsBenchmark),

                typeof(ListsBenchmarks),

                typeof(LoopBenchmark),

                typeof(AlisEcsBenchmark)
            });

            IConfig configuration = DefaultConfig.Instance;

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