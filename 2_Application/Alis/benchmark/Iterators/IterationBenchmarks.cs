// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IterationBenchmarks.cs
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
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace Alis.Benchmark.Iterators
{
    /// <summary>
    ///     The iteration benchmarks class
    /// </summary>
    [MemoryDiagnoser(false)]
    [ShortRunJob]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    public class IterationBenchmarks
    {
        /// <summary>
        ///     The array
        /// </summary>
        private int[] array;
        
        /// <summary>
        ///     The
        /// </summary>
        [Params(10, 1000, 10_000)] 
        public int N;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            array = Enumerable.Range(0, N).ToArray();
        }
        
        /// <summary>
        ///     Iterates the array for
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public void IterateArrayFor()
        {
            for (int i = 0; i < array.Length; i++)
            {
                DoSometring(array[i]);
            }
        }

        /// <summary>
        ///     Iterates the array foreach
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public void IterateArrayForeach()
        {
            foreach (int item in array)
            {
                DoSometring(item);
            }
        }
        
        /// <summary>
        ///     Iteración optimizada con ref y Unsafe.Add
        /// </summary>
        [Benchmark]
        public void Unsafe_For_Span_GetReference()
        {
            Span<int> asSpan = array;
            ref int searchSpace = ref MemoryMarshal.GetReference(asSpan);
            for (int i = 0; i < asSpan.Length; i++)
            {
                int item = Unsafe.Add(ref searchSpace, i);
                DoSometring(item);
            }
        }
        
        /// <summary>
        ///     Iterates the fastest
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public void IterateFastest()
        {
            ref int start = ref MemoryMarshal.GetArrayDataReference(array);
            ref int end = ref Unsafe.Add(ref start, array.Length);

            while (Unsafe.IsAddressLessThan(ref start, ref end))
            {
                DoSometring(start);
                start = ref Unsafe.Add(ref start, 1);
            }
        }
        
        /// <summary>
        ///     Bests the iterate with span and vector
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public void Best_IterateWithSpanAndVector()
        {
            array.AsSpan().FastFor(element => DoSometring(element));
        }
        
        /// <summary>
        /// Does the while
        /// </summary>
        [Benchmark]
        public void DoWhile()
        {
            int i = 0;
            do
            {
                DoSometring(array[i]);
                i++;
            } while (i <  array.Length);
        }

        /// <summary>
        /// Does the sometring using the specified i
        /// </summary>
        /// <param name="i">The </param>
        /// <returns>The </returns>
        public int DoSometring(int i)
        {
            return i;
        }
    }
}