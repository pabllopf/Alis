// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   For_vs_Foreach_vs_ForEach.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

#region

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Alis.Core.Entities;
using BenchmarkDotNet.Attributes;

#endregion

namespace Alis.Core.Benchmark
{
    /// <summary>
    ///     The for vs foreach vs foreach class
    /// </summary>
    public class For_vs_Foreach_vs_ForEach
    {
        /// <summary>
        ///     The gameobjects
        /// </summary>
        private List<GameObject> gameObjects_1;

        /// <summary>
        ///     The size of list
        /// </summary>
        [Params(10, 1_000, 100_000)] public int size_of_list;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            gameObjects_1 = new List<GameObject>(size_of_list);
            gameObjects_1.ForEach(i => i = new GameObject($"Obj {Array.IndexOf(gameObjects_1.ToArray(), i)}"));
        }

        /// <summary>
        ///     Tests the with for
        /// </summary>
        [Benchmark]
        public void Test_With_For()
        {
            for (var i = 0; i < gameObjects_1.Count; i++)
                if (gameObjects_1[i].Name != string.Empty)
                {
                }
        }

        /// <summary>
        ///     Tests the with foreach
        /// </summary>
        [Benchmark]
        public void Test_With_Foreach()
        {
            foreach (var gameObject in gameObjects_1)
                if (gameObject.Name != string.Empty)
                {
                }
        }

        /// <summary>
        ///     Tests the with for each
        /// </summary>
        [Benchmark]
        public void Test_With_ForEach()
        {
            gameObjects_1.ForEach(i =>
            {
                if (i.Name != string.Empty)
                {
                }
            });
        }

        /// <summary>
        ///     Tests the with parallel
        /// </summary>
        [Benchmark]
        public void Test_With_Parallel()
        {
            Parallel.ForEach(gameObjects_1, i =>
            {
                if (i.Name != string.Empty)
                {
                }
            });
        }
    }
}