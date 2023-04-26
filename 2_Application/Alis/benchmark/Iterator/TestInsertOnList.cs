// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TestInsertOnList.cs
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
using Alis.Core.Aspect.Memory;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.Iterator
{
    /// <summary>
    /// The test insert on list class
    /// </summary>
    public class TestInsertOnList
    {
        /// <summary>
        ///     Gets or sets the value of the n
        /// </summary>
        [Params(10)]
        // ReSharper disable once MemberCanBePrivate.Global
        public int N { get; set; }
        
        /// <summary>
        /// The list
        /// </summary>
        public List<int> bodyList = new List<int>();
        
        
        /// <summary>
        /// The fast list
        /// </summary>
        public FastList<int> bodyListFast = new FastList<int>();

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            bodyList = new List<int>(N);
            bodyListFast = new FastList<int>(N);
        }

        /// <summary>
        /// Inserts the normal list
        /// </summary>
        [Benchmark]
        public void InsertNormalList()
        {
            for (int i = 0; i < N; i++)
            {
                int value = Random.Shared.Next(0, N);
                bodyList.Insert(i, value);
            }
        }
        
        /// <summary>
        /// Inserts the fast list
        /// </summary>
        [Benchmark]
        public void InsertFastList()
        {
            for (int i = 0; i < N; i++)
            {
                int value = Random.Shared.Next(0, N);
                bodyListFast.Insert(i, value);
            }
        }
    }
}