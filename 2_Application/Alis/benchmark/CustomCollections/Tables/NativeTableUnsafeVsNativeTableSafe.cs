// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeArrayUnsafeVsNativeArraySafe.cs
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

using Alis.Core.Ecs.Collections;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Alis.Benchmark.CustomCollections.Tables
{
    /// <summary>
    /// The native array unsafe vs native array safe class
    /// </summary>
     [MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class NativeTableUnsafeVsNativeTableSafe
    {
        /// <summary>
        /// The array size
        /// </summary>
        [Params(2)]
        public int ArraySize;

        /// <summary>
        /// The tabla unsafe
        /// </summary>
        private NativeTableUnsafe<int> tablaUnsafe;
        
        /// <summary>
        /// The table
        /// </summary>
        private Table<int> table;
        
        /// <summary>
        /// The fast table safe
        /// </summary>
        private FastTableSafe<int> fastTableSafe;
        
        // Inicialización
        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            tablaUnsafe = new NativeTableUnsafe<int>(ArraySize);
            table = new Table<int>(ArraySize);
            fastTableSafe = new FastTableSafe<int>(ArraySize);
        }
        
        /// <summary>
        /// Benchmarks the native array safe
        /// </summary>
        [Benchmark(Description = "[UNSAFE] get value of the native array")]
        public void BenchmarkNativeArraySafe()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = tablaUnsafe.AsSpan()[i];
            }
        }
        
        /// <summary>
        /// Benchmarks the native array fast
        /// </summary>
        [Benchmark(Description = "[FAST] get value of the native array")]
        public void BenchmarkNativeArrayFast()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = table[i];
            }
        }
        
        /// <summary>
        /// Benchmarks the native array fast safe
        /// </summary>
        [Benchmark(Description = "[FAST SAFE] get value of the native array")]
        public void BenchmarkNativeArrayFastSafe()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = fastTableSafe[i];
            }
        }
    }
}