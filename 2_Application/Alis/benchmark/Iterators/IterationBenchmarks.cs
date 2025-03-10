// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:d.cs
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
using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.Iterators
{

    /// <summary>
    /// The iteration benchmarks class
    /// </summary>
    [MemoryDiagnoser(true), Config(typeof(Config))]
    public class IterationBenchmarks
    {
        /// <summary>
        /// The array
        /// </summary>
        private int[] array;
        /// <summary>
        /// The list
        /// </summary>
        private List<int> list;
        /// <summary>
        /// The linked list
        /// </summary>
        private LinkedList<int> linkedList;

        /// <summary>
        /// The 
        /// </summary>
        [Params(10, 100, 1000)]
        public int N;

        /// <summary>
        /// Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            array = Enumerable.Range(0, N).ToArray();
            list = new List<int>(array);
            linkedList = new LinkedList<int>(array);
        }

        /// <summary>
        /// Iterates the array for
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
        /// Iterates the array foreach
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
        /// Iterates the list for
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public int IterateListFor()
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }

            return sum;
        }

        /// <summary>
        /// Iterates the list foreach
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public int IterateListForeach()
        {
            int sum = 0;
            foreach (int item in list)
            {
                sum += item;
            }

            return sum;
        }

        /// <summary>
        /// Iterates the linked list foreach
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public int IterateLinkedListForeach()
        {
            int sum = 0;
            foreach (int item in linkedList)
            {
                sum += item;
            }

            return sum;
        }

        /// <summary>
        /// Iterates the linked list manual
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public int IterateLinkedListManual()
        {
            int sum = 0;
            LinkedListNode<int> node = linkedList.First;
            while (node != null)
            {
                sum += node.Value;
                node = node.Next;
            }

            return sum;
        }

        /// <summary>
        /// Iterates the span
        /// </summary>
        /// <returns>The sum</returns>
        [Benchmark]
        public int IterateSpan()
        {
            int sum = 0;
            Span<int> span = array;
            ref int r = ref span[0];
            for (int i = 0; i < span.Length; i++)
            {
                sum += Unsafe.Add(ref r, i);
            }

            return sum;
        }

        /// <summary>
        /// Iterates the linq sum
        /// </summary>
        /// <returns>The int</returns>
        [Benchmark]
        public int IterateLinqSum()
        {
            return array.Sum();
        }
    }
}