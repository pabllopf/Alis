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

using System;
using Alis.Core.Ecs.Collections;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.CustomCollections.Tables
{
        /// <summary>
    /// The native array unsafe vs native array safe class
    /// </summary>
    [ShortRunJob]
    [MemoryDiagnoser(false)]
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
        /// The the best table
        /// </summary>
        private TheBestTable<int> theBestTable;
        
        // Inicialización
        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            tablaUnsafe = new NativeTableUnsafe<int>(ArraySize);
            theBestTable = new TheBestTable<int>(ArraySize);
        }
        
        /// <summary>
        /// Benchmarks the native array safe
        /// </summary>
        [Benchmark(Description = "[UNSAFE] get value of the native array")]
        public void BenchmarkNativeArraySafe()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = tablaUnsafe[i];
            }
        }
        
        /// <summary>
        /// Benchmarks the native array the best
        /// </summary>
        [Benchmark(Description = "[THE BEST] get value of the native array")]
        public void BenchmarkNativeArrayTheBest()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = theBestTable[i];
            }
        }
        
        /// <summary>
        /// Ensures the capacity of the unsafe table
        /// </summary>
        [Benchmark(Description = "[UNSAFE] ensure capacity")]
        public void BenchmarkEnsureCapacityUnsafe()
        {
            tablaUnsafe.EnsureCapacity(ArraySize * 2);
        }
        
        /// <summary>
        /// Benchmarks the ensure capacity the best
        /// </summary>
        [Benchmark(Description = "[THE BEST] ensure capacity")]
        public void BenchmarkEnsureCapacityTheBest()
        {
            theBestTable.EnsureCapacity(ArraySize * 2);
        }
        
        /// <summary>
        /// Converts the unsafe table to Span
        /// </summary>
        [Benchmark(Description = "[UNSAFE] convert to Span")]
        public void BenchmarkConvertToSpanUnsafe()
        {
            Span<int> span = tablaUnsafe.AsSpan();
        }
        
        /// <summary>
        /// Benchmarks the convert to span the best
        /// </summary>
        [Benchmark(Description = "[THE BEST] convert to Span")]
        public void BenchmarkConvertToSpanTheBest()
        {
            Span<int> span = theBestTable.AsSpan();
        }
        
        /// <summary>
        /// Benchmarks the unsafe index no resize
        /// </summary>
        [Benchmark(Description ="[UNSAFE] test UnsafeIndexNoResize")]
        public void BenchmarkUnsafeIndexNoResize()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = tablaUnsafe.UnsafeIndexNoResize(i);
            }
        }
        
        /// <summary>
        /// Benchmarks the unsafe index no resize the best
        /// </summary>
        [Benchmark(Description ="[THE BEST] test UnsafeIndexNoResize")]
        public void BenchmarkUnsafeIndexNoResizeTheBest()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = theBestTable.UnsafeIndexNoResize(i);
            }
        }
        
        /// <summary>
        /// Benchmarks the dispose unsafe
        /// </summary>
        [Benchmark(Description = "[UNSAFE] test dispose")]
        public void BenchmarkDisposeUnsafe()
        {
            tablaUnsafe.Dispose();
        }
        
        /// <summary>
        /// Benchmarks the dispose the best
        /// </summary>
        [Benchmark(Description = "[THE BEST] test dispose")]
        public void BenchmarkDisposeTheBest()
        {
            theBestTable.Dispose();
        }
    }
}