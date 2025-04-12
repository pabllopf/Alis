// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeTableUnsafeVsNativeTableSafe.cs
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
    ///     The native array unsafe vs native array safe class
    /// </summary>
    [ShortRunJob, MemoryDiagnoser(false)]
    public class NativeTableUnsafeVsNativeTableSafe
    {
        /// <summary>
        ///     The array size
        /// </summary>
        [Params(256)] public int ArraySize;

        /// <summary>
        ///     The fast table
        /// </summary>
        private FastTable<int> fastTable;

        /// <summary>
        ///     The tabla unsafe
        /// </summary>
        private NativeTableUnsafe<int> nativeTableUnsafe;

        /// <summary>
        ///     The table
        /// </summary>
        private Table<int> table;

        // Inicialización
        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            nativeTableUnsafe = new NativeTableUnsafe<int>(ArraySize);
            table = new Table<int>(ArraySize);
            fastTable = new FastTable<int>(ArraySize);
        }

        /// <summary>
        ///     Benchmarks the native array safe
        /// </summary>
        [Benchmark(Description = "[UNSAFE] get value of the native array")]
        public void BenchmarkNativeArraySafe()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = nativeTableUnsafe[i];
            }
        }

        /// <summary>
        ///     Benchmarks the current
        /// </summary>
        [Benchmark(Description = "[CURRENT] get value of the current array")]
        public void BenchmarkCurrent()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = table[i];
            }
        }

        /// <summary>
        ///     Benchmarks the fast
        /// </summary>
        [Benchmark(Description = "[FAST] get value of the fast array")]
        public void BenchmarkFast()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = fastTable[i];
            }
        }

        /// <summary>
        ///     Ensures the capacity of the unsafe table
        /// </summary>
        [Benchmark(Description = "[UNSAFE] ensure capacity")]
        public void BenchmarkEnsureCapacityUnsafe()
        {
            nativeTableUnsafe.EnsureCapacity(ArraySize * 2);
        }

        /// <summary>
        ///     Benchmarks the ensure capacity current
        /// </summary>
        [Benchmark(Description = "[CURRENT] ensure capacity")]
        public void BenchmarkEnsureCapacityCurrent()
        {
            table.EnsureCapacity(ArraySize * 2);
        }

        /// <summary>
        ///     Benchmarks the ensure capacity fast
        /// </summary>
        [Benchmark(Description = "[FAST] ensure capacity")]
        public void BenchmarkEnsureCapacityFast()
        {
            fastTable.EnsureCapacity(ArraySize * 2);
        }

        /// <summary>
        ///     Converts the unsafe table to Span
        /// </summary>
        [Benchmark(Description = "[UNSAFE] convert to Span")]
        public void BenchmarkConvertToSpanUnsafe()
        {
            Span<int> span = nativeTableUnsafe.AsSpan();
        }

        /// <summary>
        ///     Benchmarks the convert to span current
        /// </summary>
        [Benchmark(Description = "[CURRENT] convert to Span")]
        public void BenchmarkConvertToSpanCurrent()
        {
            Span<int> span = table.AsSpan();
        }

        /// <summary>
        ///     Benchmarks the convert to span fast
        /// </summary>
        [Benchmark(Description = "[FAST] convert to Span")]
        public void BenchmarkConvertToSpanFast()
        {
            Span<int> span = fastTable.AsSpan();
        }

        /// <summary>
        ///     Benchmarks the unsafe index no resize
        /// </summary>
        [Benchmark(Description = "[UNSAFE] test UnsafeIndexNoResize")]
        public void BenchmarkUnsafeIndexNoResize()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = nativeTableUnsafe.UnsafeIndexNoResize(i);
            }
        }

        /// <summary>
        ///     Benchmarks the unsafe index no resize current
        /// </summary>
        [Benchmark(Description = "[CURRENT] test UnsafeIndexNoResize")]
        public void BenchmarkUnsafeIndexNoResizeCurrent()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = table.UnsafeIndexNoResize(i);
            }
        }

        /// <summary>
        ///     Benchmarks the unsafe index no resize fast
        /// </summary>
        [Benchmark(Description = "[FAST] test UnsafeIndexNoResize")]
        public void BenchmarkUnsafeIndexNoResizeFast()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = fastTable.UnsafeIndexNoResize(i);
            }
        }
    }
}