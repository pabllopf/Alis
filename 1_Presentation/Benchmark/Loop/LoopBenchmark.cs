// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoopBenchmark.cs
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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.Loop
{
    /// <summary>
    ///     The loop benchmark class
    /// </summary>
    [ShortRunJob, MemoryDiagnoser(false), Config(typeof(CustomConfig))]
    public class LoopBenchmark
    {
        /// <summary>
        ///     The random
        /// </summary>
        private static readonly Random random = new Random(999999);

        /// <summary>
        ///     The items
        /// </summary>
        private List<int> items = new();

        /// <summary>
        ///     Gets or sets the value of the size
        /// </summary>
        [Params(100, 10000)]
        public int size { get; set; } = 100;

        /// <summary>
        ///     Inits the list
        /// </summary>
        [GlobalSetup]
        public void InitList()
        {
            items = Enumerable.Range(1, size).Select(x => random.Next()).ToList();
        }

        /// <summary>
        ///     Fors this instance
        /// </summary>
        [Benchmark]
        public void For()
        {
            for (int i = 0; i < items.Count; i++)
            {
                int item = items[i];
            }
        }

        /// <summary>
        ///     Whiles this instance
        /// </summary>
        [Benchmark]
        public void While()
        {
            int i = 0;
            while (i < items.Count)
            {
                int item = items[i];
                i++;
            }
        }

        /// <summary>
        ///     Fors the each
        /// </summary>
        [Benchmark]
        public void ForEach()
        {
            foreach (int item in items)
            {
            }
        }

        /// <summary>
        ///     Foreaches the linq
        /// </summary>
        [Benchmark]
        public void Foreach_Linq()
        {
            items.ForEach(item => { });
        }

        /// <summary>
        ///     Parallels the for each
        /// </summary>
        [Benchmark]
        public void Parallel_ForEach()
        {
            Parallel.ForEach(items, item => { });
        }

        /// <summary>
        ///     Parallels the linq
        /// </summary>
        [Benchmark]
        public void Parallel_Linq()
        {
            items.AsParallel().ForAll(item => { });
        }

        /// <summary>
        ///     Fors the span
        /// </summary>
        [Benchmark]
        public void For_Span()
        {
            Span<int> asSpanList = CollectionsMarshal.AsSpan(items);

            for (int i = 0; i < asSpanList.Length; i++)
            {
                int item = asSpanList[i];
            }
        }

        /// <summary>
        ///     Foreaches the span
        /// </summary>
        [Benchmark]
        public void Foreach_Span()
        {
            foreach (int item in CollectionsMarshal.AsSpan(items))
            {
            }
        }
    }
}