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
    [ Config(typeof(CustomConfig))]
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
        ///     Fastests the list clear
        /// </summary>
        [Benchmark(Description = "[NORMAL] Clear List")]
        public void Fastest_List_Clear()
        {
            fastList.Clear();
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
    }
}