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
    [MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
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
        public int IterateArrayFor()
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }

            return sum;
        }

        /// <summary>
        ///     Iterates the array foreach
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public int IterateArrayForeach()
        {
            int sum = 0;
            foreach (int item in array)
            {
                sum += item;
            }

            return sum;
        }
        
        /// <summary>
        ///     Iteración optimizada con ref y Unsafe.Add
        /// </summary>
        [Benchmark]
        public int Unsafe_For_Span_GetReference()
        {
            Span<int> asSpan = array.AsSpan();
            ref int searchSpace = ref MemoryMarshal.GetReference(asSpan);
            int sum = 0;
            for (int i = 0; i < asSpan.Length; i++)
            {
                 sum = Unsafe.Add(ref searchSpace, i);
            }
            return sum;
        }
        
        /// <summary>
        ///     Iterates the fastest
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public int IterateFastest()
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }

            ref int start = ref MemoryMarshal.GetArrayDataReference(array);
            ref int end = ref Unsafe.Add(ref start, array.Length);
            int sum = 0;

            while (Unsafe.IsAddressLessThan(ref start, ref end))
            {
                sum += start;
                start = ref Unsafe.Add(ref start, 1);
            }

            return sum;
        }

        /// <summary>
        ///     Iterates the fastest with sim
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public int IterateFastestWithSIM()
        {
            if (array == null || array.Length == 0)
            {
                return 0;
            }

            ref int start = ref MemoryMarshal.GetArrayDataReference(array);
            ref int end = ref Unsafe.Add(ref start, array.Length);
            int sum = 0;

            int vectorSize = Vector<int>.Count; // Tamaño del vector SIMD
            ref int vectorEnd = ref Unsafe.Subtract(ref end, vectorSize); // Último bloque SIMD

            Vector<int> vectorSum = Vector<int>.Zero;

            // Procesar en bloques SIMD
            while (Unsafe.IsAddressLessThan(ref start, ref vectorEnd))
            {
                vectorSum += new Vector<int>(array.AsSpan((int) (Unsafe.ByteOffset(ref MemoryMarshal.GetArrayDataReference(array), ref start) / sizeof(int)), vectorSize));
                start = ref Unsafe.Add(ref start, vectorSize);
            }

            // Sumar los valores de los vectores
            for (int i = 0; i < vectorSize; i++)
            {
                sum += vectorSum[i];
            }

            // Procesar los elementos restantes (si el tamaño del array no es múltiplo de vectorSize)
            while (Unsafe.IsAddressLessThan(ref start, ref end))
            {
                sum += start;
                start = ref Unsafe.Add(ref start, 1);
            }

            return sum;
        }
        
        /// <summary>
        ///     Bests the iterate with span and vector
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public int Best_IterateWithSpanAndVector()
        {
            Span<int> span = array;
            int sum = 0;
            int i = 0;
            int vectorSize = Vector<int>.Count;

            Vector<int> vectorSum = Vector<int>.Zero;

            // Procesar en bloques de vectorSize (SIMD)
            for (; i <= span.Length - vectorSize; i += vectorSize)
            {
                vectorSum += new Vector<int>(span.Slice(i, vectorSize));
            }

            // Sumar los valores del vector
            for (int j = 0; j < vectorSize; j++)
            {
                sum += vectorSum[j];
            }

            // Procesar los elementos restantes
            for (; i < span.Length; i++)
            {
                sum += span[i];
            }

            return sum;
        }
    }
}