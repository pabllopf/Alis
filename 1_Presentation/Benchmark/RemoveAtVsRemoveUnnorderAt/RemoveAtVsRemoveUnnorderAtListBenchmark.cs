// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RemoveAtVsRemoveUnnorderAtListBenchmark.cs
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

namespace Alis.Benchmark.RemoveAtVsRemoveUnnorderAt
{
    /// <summary>
    ///     The remove at vs remove unnorder at list benchmark class
    /// </summary>
    [ Config(typeof(CustomConfig))]
    public class RemoveAtVsRemoveUnnorderAtListBenchmark
    {
        /// <summary>
        ///     The list
        /// </summary>
        private List<int> list;

        /// <summary>
        ///     The
        /// </summary>
        [Params(100)] public int N;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            list = new List<int>(N);
        }

        /// <summary>
        ///     Removes the at
        /// </summary>
        [Benchmark]
        public void RemoveAt()
        {
            for (int i = 1; i < N - 1; i++)
            {
                list.Add(i);
            }

            for (int i = 1; i < N - 1; i++)
            {
                list.RemoveAt(i);
            }
        }

        /// <summary>
        ///     Removes the unnorder at
        /// </summary>
        [Benchmark]
        public void RemoveUnnorderAt()
        {
            for (int i = 1; i < N - 1; i++)
            {
                list.Add(i);
            }

            for (int i = 1; i < N - 1; i++)
            {
                list.RemoveUnnorderAt(i);
            }
        }
    }
}