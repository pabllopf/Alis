// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TestRemoveListVsHasSet.cs
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

namespace Alis.Benchmark.Iterator
{
    /// <summary>
    ///     The test remove list vs hasset class
    /// </summary>
    public class TestRemoveListVsHasSet
    {
        /// <summary>
        ///     The body set
        /// </summary>
        private HashSet<BodyTest> bodySet;

        /// <summary>
        ///     The world
        /// </summary>
        private World world;

        /// <summary>
        ///     Gets or sets the value of the n
        /// </summary>
        [Params(10, 100, 1000)]
        // ReSharper disable once MemberCanBePrivate.Global
        public int N { get; }

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            world = new World();
            bodySet = new HashSet<BodyTest>();

            for (int i = 0; i < N; i++)
            {
                BodyTest bodyTest = new BodyTest {Id = i};
                world.Bodies.Add(bodyTest);
                bodySet.Add(bodyTest);
            }
        }

        /// <summary>
        ///     Removes the body from list
        /// </summary>
        [Benchmark]
        public void RemoveBodyFromList()
        {
            for (int i = 0; i < N; i++)
            {
                world.RemoveBody(world.Bodies[i]);
            }
        }

        /// <summary>
        ///     Removes the body from set
        /// </summary>
        [Benchmark]
        public void RemoveBodyFromSet()
        {
            for (int i = 0; i < N; i++)
            {
                bodySet.Remove(world.Bodies[i]);
            }
        }


        /// <summary>
        ///     The world class
        /// </summary>
        private class World
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="World" /> class
            /// </summary>
            public World() => Bodies = new List<BodyTest>();

            /// <summary>
            ///     Gets or sets the value of the bodies
            /// </summary>
            public List<BodyTest> Bodies { get; }

            /// <summary>
            ///     Removes the body using the specified body
            /// </summary>
            /// <param name="bodyTest">The body</param>
            public void RemoveBody(BodyTest bodyTest) => Bodies.Remove(bodyTest);
        }
    }
}