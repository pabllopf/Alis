// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TestWorldClearForces.cs
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.Physics
{
    /// <summary>
    ///     The clear forces benchmark class
    /// </summary>
    public class TestWorldClearForces
    {
        /// <summary>
        ///     The
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnassignedField.Global
        [Params(10, 100, 1000)] public int N;

        /// <summary>
        ///     The world
        /// </summary>
        private World world;

        /// <summary>
        ///     Setup this instance
        /// </summary>
        [GlobalSetup]
        public void Setup()
        {
            world = new World();
            for (int i = 0; i < N; i++)
            {
                world.Bodies.Add(new Body());
            }
            
            world.Update();
        }

        /// <summary>
        ///     Originals this instance
        /// </summary>
        [Benchmark]
        public void ClearForcesOriginal() => world.ClearForcesOriginal();
        
        /// <summary>
        /// Fasts the clear force
        /// </summary>
        [Benchmark]
        public void FastClearForce() => world.FastClearForce();

        /// <summary>
        ///     Optimize this instance
        /// </summary>
        [Benchmark]
        public void ClearForcesOptimizedWithCopyTemp() => world.ClearForcesOptimizedWithCopyTemp();

        /// <summary>
        ///     Optimize this instance
        /// </summary>
        [Benchmark]
        public void ClearForcesOptimizedWithoutCopyTemp() => world.ClearForcesOptimizedWithoutCopyTemp();

        /// <summary>
        ///     Optimize this instance
        /// </summary>
        [Benchmark]
        public void ClearForcesOptimizedWithParallel() => world.ClearForcesOptimizedWithParallel();
        
        /// <summary>
        ///     The body class
        /// </summary>
        private class Body
        {
            /// <summary>
            ///     Clears the forces
            /// </summary>
            public void ClearForces()
            {
            }
        }

        /// <summary>
        ///     The world class
        /// </summary>
        private class World
        {
            /// <summary>
            ///     Gets the value of the bodies
            /// </summary>
            public List<Body> Bodies { get; } = new List<Body>();

            internal Body[] BodiesArray;
            
            /// <summary>
            ///     Clears the forces original
            /// </summary>
            internal void ClearForcesOriginal() => Bodies.ForEach(i => i.ClearForces());

            /// <summary>
            ///     Clears the forces original
            /// </summary>
            internal void ClearForcesOptimizedWithParallel() => Parallel.For(0, Bodies.Count, i => Bodies[i].ClearForces());

            /// <summary>
            ///     Clears the forces optimized
            /// </summary>
            internal void ClearForcesOptimizedWithCopyTemp()
            {
                List<Body> bodies = Bodies;
                for (int i = 0; i < bodies.Count; i++)
                {
                    bodies[i].ClearForces();
                }
            }

            /// <summary>
            ///     Clears the forces optimized v 2
            /// </summary>
            internal void ClearForcesOptimizedWithoutCopyTemp()
            {
                for (int i = 0; i < Bodies.Count; i++)
                {
                    Bodies[i].ClearForces();
                }
            }

            internal void Update()
            {
                BodiesArray = Bodies.ToArray();
            }
            
            /// <summary>
            /// Fasts the clear force
            /// </summary>
            internal void FastClearForce()
            {
                ref Body start = ref MemoryMarshal.GetArrayDataReference(BodiesArray);
                ref Body end = ref Unsafe.Add(ref start, BodiesArray.Length);
                while (Unsafe.IsAddressLessThan(ref start, ref end))
                {
                    start.ClearForces();
                    start = ref Unsafe.Add(ref start, 1);
                }
            }
        }
    }
}