// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrifloEngineEcs.cs
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
using System.Runtime.Intrinsics;
using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.FrifloEngine_Components;
using BenchmarkDotNet.Attributes;
using Friflo.Engine.ECS;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithThreeComponents
{
    /// <summary>
    ///     The system with three components class
    /// </summary>
    public partial class SystemWithThreeComponents
    {
        /// <summary>
        ///     The friflo engine ecs
        /// </summary>
        [Context] private readonly FrifloEngineEcsContext _frifloEngineEcs;

        /// <summary>
        ///     Frifloes the engine ecs mono thread
        /// </summary>
        [BenchmarkCategory(Categories.FrifloEngineEcs), Benchmark]
        public void FrifloEngineEcs_MonoThread()
        {
            foreach ((Chunk<Component1> component1, Chunk<Component2> component2, Chunk<Component3> component3, ChunkEntities _)
                     in _frifloEngineEcs.queryThree.Chunks)
            {
                Span<Component1> component1Span = component1.Span;
                Span<Component2> component2Span = component2.Span;
                Span<Component3> component3Span = component3.Span;
                for (int n = 0; n < component1Span.Length; n++)
                {
                    Update(ref component1Span[n], ref component2Span[n], ref component3Span[n]);
                }
            }
        }

        /// <summary>
        ///     Frifloes the engine ecs multi thread
        /// </summary>
        [BenchmarkCategory(Categories.FrifloEngineEcs), Benchmark]
        public void FrifloEngineEcs_MultiThread()
        {
            _frifloEngineEcs.jobThree.RunParallel();
        }

        /// <summary>
        ///     Updates the c 1
        /// </summary>
        /// <param name="c1">The </param>
        /// <param name="c2">The </param>
        /// <param name="c3">The </param>
        private static void Update(ref Component1 c1, ref Component2 c2, ref Component3 c3)
        {
            c1.Value += c2.Value + c3.Value;
        }

        /// <summary>
        ///     Frifloes the engine ecs simd mono thread
        /// </summary>
        [BenchmarkCategory(Categories.FrifloEngineEcs), Benchmark]
        public void FrifloEngineEcs_SIMD_MonoThread()
        {
            foreach ((Chunk<Component1> component1, Chunk<Component2> component2, Chunk<Component3> component3, ChunkEntities _)
                     in _frifloEngineEcs.queryThree.Chunks)
            {
                Span<int> component1Span = component1.AsSpan256<int>(); // Length - multiple of 8
                Span<int> component2Span = component2.AsSpan256<int>(); // Length - multiple of 8
                Span<int> component3Span = component3.AsSpan256<int>(); // Length - multiple of 8
                int step = component1.StepSpan256; // step = 8
                for (int n = 0; n < component1Span.Length; n += step)
                {
                    Span<int> component1Slice = component1Span.Slice(n, step);
                    Vector256<int> value1 = Vector256.Create<int>(component1Span);
                    Vector256<int> value2 = Vector256.Create<int>(component2Span.Slice(n, step));
                    Vector256<int> value3 = Vector256.Create<int>(component3Span.Slice(n, step));
                    Vector256<int> result = Vector256.Add(value1, Vector256.Add(value2, value3)); // execute 16 add instructions
                    result.CopyTo(component1Slice);
                }
            }
        }

        /// <summary>
        ///     The friflo engine ecs context class
        /// </summary>
        /// <seealso cref="FrifloEngineEcsBaseContext" />
        internal sealed class FrifloEngineEcsContext : FrifloEngineEcsBaseContext
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="FrifloEngineEcsContext" /> class
            /// </summary>
            /// <param name="entityCount">The gameObject count</param>
            /// <param name="padding">The padding</param>
            public FrifloEngineEcsContext(int entityCount, int padding)
                : base(entityCount, padding, ComponentTypes.Get<Component1, Component2, Component3>())
            {
            }

            /// <summary>
            ///     Fors the each using the specified component 1
            /// </summary>
            /// <param name="component1">The component</param>
            /// <param name="component2">The component</param>
            /// <param name="component3">The component</param>
            /// <param name="entities">The entities</param>
            internal static void ForEach(Chunk<Component1> component1, Chunk<Component2> component2, Chunk<Component3> component3, ChunkEntities entities)
            {
                Span<Component1> component1Span = component1.Span;
                Span<Component2> component2Span = component2.Span;
                Span<Component3> component3Span = component3.Span;
                for (int n = 0; n < component1Span.Length; n++)
                {
                    Update(ref component1Span[n], ref component2Span[n], ref component3Span[n]);
                }
            }
        }
    }
}