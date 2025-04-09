// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ListsBenchmarks.cs
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

using System.Collections.Generic;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.CustomCollections.Lists
{
    /// <summary>
    ///     The native array unsafe vs native array safe class
    /// </summary>
    [MemoryDiagnoser(false), ShortRunJob]
    public class ListsBenchmarks
    {
        /// <summary>
        ///     The array size
        /// </summary>
        [Params(10)] public int ArraySize;

        /// <summary>
        ///     The NORMAL stack
        /// </summary>
        private List<int> fastList;

        /// <summary>
        ///     The pooled list
        /// </summary>
        private PooledList<int> pooledList;

        // Inicialización
        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            fastList = new List<int>();
            for (int i = 0; i < ArraySize; i++)
            {
                fastList.Add(i);
            }

            pooledList = new PooledList<int>();
            for (int i = 0; i < ArraySize; i++)
            {
                pooledList.Add(i);
            }
        }

        /// <summary>
        ///     Fastests the stack array iterate
        /// </summary>
        [Benchmark(Description = "[NORMAL] Iterate List")]
        public void Fastest_List_ArrayIterate()
        {
            for (int i = 1; i < ArraySize - 1; i++)
            {
                _ = fastList[i];
            }
        }

        /// <summary>
        ///     Pooleds the list array iterate
        /// </summary>
        [Benchmark(Description = "[POOLED] Iterate List")]
        public void Pooled_List_ArrayIterate()
        {
            for (int i = 1; i < ArraySize - 1; i++)
            {
                _ = pooledList[i];
            }
        }

        /// <summary>
        ///     Fastests the list add
        /// </summary>
        [Benchmark(Description = "[NORMAL] Add List")]
        public void Fastest_List_Add()
        {
            for (int i = 1; i < ArraySize - 1; i++)
            {
                fastList.Add(i);
            }
        }

        /// <summary>
        ///     Pooleds the list add
        /// </summary>
        [Benchmark(Description = "[POOLED] Add List")]
        public void Pooled_List_Add()
        {
            for (int i = 1; i < ArraySize - 1; i++)
            {
                pooledList.Add(i);
            }
        }

        /// <summary>
        ///     Fastests the list remove
        /// </summary>
        [Benchmark(Description = "[NORMAL] Remove List")]
        public void Fastest_List_Remove()
        {
            for (int i = 1; i < ArraySize - 1; i++)
            {
                fastList.Add(i);
            }

            for (int i = 1; i < ArraySize - 1; i++)
            {
                fastList.RemoveAt(i);
            }
        }

        /// <summary>
        ///     Pooleds the list remove
        /// </summary>
        [Benchmark(Description = "[POOLED] Remove List")]
        public void Pooled_List_Remove()
        {
            for (int i = 1; i < ArraySize - 1; i++)
            {
                pooledList.Add(i);
            }

            for (int i = 1; i < ArraySize - 1; i++)
            {
                pooledList.RemoveAt(i);
            }
        }

        /// <summary>
        ///     Fastests the list clear
        /// </summary>
        [Benchmark(Description = "[NORMAL] Clear List")]
        public void Fastest_List_Clear()
        {
            fastList.Clear();
        }

        /// <summary>
        ///     Pooleds the list clear
        /// </summary>
        [Benchmark(Description = "[POOLED] Clear List")]
        public void Pooled_List_Clear()
        {
            pooledList.Clear();
        }

        /// <summary>
        ///     Fastests the list contains
        /// </summary>
        [Benchmark(Description = "[NORMAL] Contains List")]
        public void Fastest_List_Contains()
        {
            for (int i = 1; i < ArraySize - 1; i++)
            {
                _ = fastList.Contains(i);
            }
        }

        /// <summary>
        ///     Pooleds the list contains
        /// </summary>
        [Benchmark(Description = "[POOLED] Contains List")]
        public void Pooled_List_Contains()
        {
            for (int i = 1; i < ArraySize - 1; i++)
            {
                _ = pooledList.Contains(i);
            }
        }


        /// <summary>
        ///     Fastests the list index of
        /// </summary>
        [Benchmark(Description = "[NORMAL] IndexOf List")]
        public void Fastest_List_IndexOf()
        {
            for (int i = 1; i < ArraySize - 1; i++)
            {
                _ = fastList.IndexOf(i);
            }
        }

        /// <summary>
        ///     Pooleds the list index of
        /// </summary>
        [Benchmark(Description = "[POOLED] IndexOf List")]
        public void Pooled_List_IndexOf()
        {
            for (int i = 1; i < ArraySize - 1; i++)
            {
                _ = pooledList.IndexOf(i);
            }
        }

        /// <summary>
        ///     Fastests the list insert
        /// </summary>
        [Benchmark(Description = "[NORMAL] Insert List")]
        public void Fastest_List_Insert()
        {
            for (int i = 1; i < ArraySize - 1; i++)
            {
                fastList.Insert(i, i);
            }
        }

        /// <summary>
        ///     Pooleds the list insert
        /// </summary>
        [Benchmark(Description = "[POOLED] Insert List")]
        public void Pooled_List_Insert()
        {
            for (int i = 1; i < ArraySize - 1; i++)
            {
                pooledList.Insert(i, i);
            }
        }
    }
}