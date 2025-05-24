// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TablesBenchmarks.cs
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
using Alis.Benchmark.CustomCollections.Tables.Elements;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.CustomCollections.Tables
{
    /// <summary>
    ///     The native array unsafe vs native array safe class
    /// </summary>
    [ShortRunJob, MemoryDiagnoser, Config(typeof(CustomConfig))]
    public class TablesBenchmarks
    {
        /// <summary>
        ///     The array size
        /// </summary>
        [Params(32)]
        public int ArraySize;

        /// <summary>
        ///     The fast _normalTable
        /// </summary>
        private FastTable<int> fastTable;

        /// <summary>
        ///     The tabla unsafe
        /// </summary>
        private NativeTableUnsafe<int> nativeTableUnsafe;

        /// <summary>
        ///     The _normalTable
        /// </summary>
        private NormalTable<int> _normalTable;
        
        /// <summary>
        /// The fastest table
        /// </summary>
        private FastestTable<int> fastestTable;

        // Inicialización
        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            nativeTableUnsafe = new NativeTableUnsafe<int>(ArraySize);
            _normalTable = new NormalTable<int>(ArraySize);
            fastTable = new FastTable<int>(ArraySize);
            fastestTable = new FastestTable<int>(ArraySize);
        }

        /// <summary>
        ///     Benchmarks the native array safe
        /// </summary>
        [Benchmark(Description = "[UNSAFE]_Iterate")]
        public void BenchmarkNativeArraySafe()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = nativeTableUnsafe[i];
            }
        }

        /// <summary>
        ///     Benchmarks the NORMAL
        /// </summary>
        [Benchmark(Description = "[NORMAL]_Iterate")]
        public void BenchmarkCurrent()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = _normalTable[i];
            }
        }

        /// <summary>
        ///     Benchmarks the fast
        /// </summary>
        [Benchmark(Description = "[FAST]_Iterate")]
        public void BenchmarkFast()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = fastTable[i];
            }
        }
        
        /// <summary>
        /// Benchmarks the fastest
        /// </summary>
        [Benchmark(Description = "[FASTEST]_Iterate")]
        public void BenchmarkFastest()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = fastestTable[i];
            }
        }

        /// <summary>
        ///     Ensures the capacity of the unsafe _normalTable
        /// </summary>
        [Benchmark(Description = "[UNSAFE]_EnsureCapacity()")]
        public void BenchmarkEnsureCapacityUnsafe()
        {
            nativeTableUnsafe.EnsureCapacity(ArraySize * 2);
        }

        /// <summary>
        ///     Benchmarks the ensure capacity NORMAL
        /// </summary>
        [Benchmark(Description = "[NORMAL]_EnsureCapacity()")]
        public void BenchmarkEnsureCapacityCurrent()
        {
            _normalTable.EnsureCapacity(ArraySize * 2);
        }

        /// <summary>
        ///     Benchmarks the ensure capacity fast
        /// </summary>
        [Benchmark(Description = "[FAST]_EnsureCapacity()")]
        public void BenchmarkEnsureCapacityFast()
        {
            fastTable.EnsureCapacity(ArraySize * 2);
        }
        
        /// <summary>
        /// Benchmarks the ensure capacity fastest
        /// </summary>
        [Benchmark(Description = "[FASTEST]_EnsureCapacity()")]
        public void BenchmarkEnsureCapacityFastest()
        {
            fastestTable.EnsureCapacity(ArraySize * 2);
        }

        /// <summary>
        ///     Converts the unsafe _normalTable to Span
        /// </summary>
        [Benchmark(Description = "[UNSAFE]_AsSpan()")]
        public void BenchmarkConvertToSpanUnsafe()
        {
            Span<int> span = nativeTableUnsafe.AsSpan();
        }

        /// <summary>
        ///     Benchmarks the convert to span NORMAL
        /// </summary>
        [Benchmark(Description = "[NORMAL]_AsSpan()")]
        public void BenchmarkConvertToSpanCurrent()
        {
            Span<int> span = _normalTable.AsSpan();
        }

        /// <summary>
        ///     Benchmarks the convert to span fast
        /// </summary>
        [Benchmark(Description = "[FAST]_AsSpan()")]
        public void BenchmarkConvertToSpanFast()
        {
            Span<int> span = fastTable.AsSpan();
        }
        
        /// <summary>
        /// Benchmarks the convert to span fastest
        /// </summary>
        [Benchmark(Description = "[FASTEST]_AsSpan()")]
        public void BenchmarkConvertToSpanFastest()
        {
            Span<int> span = fastestTable.AsSpan();
        }

        /// <summary>
        ///     Benchmarks the unsafe index no resize
        /// </summary>
        [Benchmark(Description = "[UNSAFE]_UnsafeIndexNoResize")]
        public void BenchmarkUnsafeIndexNoResize()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = nativeTableUnsafe.UnsafeIndexNoResize(i);
            }
        }

        /// <summary>
        ///     Benchmarks the unsafe index no resize NORMAL
        /// </summary>
        [Benchmark(Description = "[NORMAL]_UnsafeIndexNoResize")]
        public void BenchmarkUnsafeIndexNoResizeCurrent()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = _normalTable.UnsafeIndexNoResize(i);
            }
        }

        /// <summary>
        ///     Benchmarks the unsafe index no resize fast
        /// </summary>
        [Benchmark(Description = "[FAST]_UnsafeIndexNoResize")]
        public void BenchmarkUnsafeIndexNoResizeFast()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = fastTable.UnsafeIndexNoResize(i);
            }
        }
        
        /// <summary>
        /// Benchmarks the unsafe index no resize fastest
        /// </summary>
        [Benchmark(Description = "[FASTEST]_UnsafeIndexNoResize")]
        public void BenchmarkUnsafeIndexNoResizeFastest()
        {
            for (int i = 0; i < ArraySize; i++)
            {
                int value = fastestTable.UnsafeIndexNoResize(i);
            }
        }
    }
}