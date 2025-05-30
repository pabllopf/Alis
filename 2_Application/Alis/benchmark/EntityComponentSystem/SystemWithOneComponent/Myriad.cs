// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Myriad.cs
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
using System.Numerics;
using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.Myriad_Components;
using BenchmarkDotNet.Attributes;
using Myriad.ECS;
using Myriad.ECS.Collections;
using Myriad.ECS.Command;
using Myriad.ECS.Queries;
using Myriad.ECS.Worlds;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithOneComponent
{
    /// <summary>
    ///     The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
    {
        /// <summary>
        ///     The myriad
        /// </summary>
        [Context] private readonly MyriadContext _myriad;

        /// <summary>
        ///     Myriads the single thread
        /// </summary>
        [BenchmarkCategory(Categories.Myriad), Benchmark]
        public void Myriad_SingleThread()
        {
            World world = _myriad.World;
            world.Execute<MyriadForEach1, Component1>(new MyriadForEach1());
        }

        /// <summary>
        ///     Myriads the multi thread
        /// </summary>
        [BenchmarkCategory(Categories.Myriad), Benchmark]
        public void Myriad_MultiThread()
        {
            World world = _myriad.World;
            world.ExecuteParallel<MyriadForEach1, Component1>(new MyriadForEach1());
        }

        /// <summary>
        ///     Myriads the single thread chunk
        /// </summary>
        [BenchmarkCategory(Categories.Myriad), Benchmark]
        public void Myriad_SingleThreadChunk()
        {
            World world = _myriad.World;
            world.ExecuteChunk<MyriadForEach1, Component1>(new MyriadForEach1());
        }

        /// <summary>
        ///     Myriads the multi thread chunk
        /// </summary>
        [BenchmarkCategory(Categories.Myriad), Benchmark]
        public void Myriad_MultiThreadChunk()
        {
            World world = _myriad.World;
            world.ExecuteChunkParallel<MyriadForEach1, Component1>(new MyriadForEach1());
        }

        /// <summary>
        ///     Myriads the enumerable
        /// </summary>
        [BenchmarkCategory(Categories.Myriad), Benchmark]
        public void Myriad_Enumerable()
        {
            World world = _myriad.World;

            foreach ((Entity _, RefT<Component1> c) in world.Query<Component1>())
            {
                c.Ref.Value++;
            }
        }

        /// <summary>
        ///     Myriads the delegate
        /// </summary>
        [BenchmarkCategory(Categories.Myriad), Benchmark]
        public void Myriad_Delegate()
        {
            World world = _myriad.World;

            world.Query((ref Component1 c) => { c.Value++; });
        }

        /// <summary>
        ///     Myriads the single thread chunk simd
        /// </summary>
        [BenchmarkCategory(Categories.Myriad), Benchmark]
        public void Myriad_SingleThreadChunk_SIMD()
        {
            World world = _myriad.World;

            world.ExecuteVectorChunk<MyriadVectorForEach1, Component1, int>(new MyriadVectorForEach1());
        }

        /// <summary>
        ///     The myriad for each
        /// </summary>
        public struct MyriadForEach1
            : IQuery<Component1>, IChunkQuery<Component1>
        {
            /// <summary>
            ///     Executes the gameObject
            /// </summary>
            /// <param name="entity">The gameObject</param>
            /// <param name="t0">The </param>
            public void Execute(Entity entity, ref Component1 t0)
            {
                ++t0.Value;
            }

            /// <summary>
            ///     Executes the chunk
            /// </summary>
            /// <param name="chunk">The chunk</param>
            /// <param name="e">The </param>
            /// <param name="t0">The </param>
            public void Execute(ChunkHandle chunk, ReadOnlySpan<Entity> e, Span<Component1> t0)
            {
                for (int i = 0; i < t0.Length; i++)
                {
                    t0[i].Value++;
                }
            }
        }

        /// <summary>
        ///     The myriad vector for each
        /// </summary>
        public struct MyriadVectorForEach1
            : IVectorChunkQuery<int>
        {
            /// <summary>
            ///     The one
            /// </summary>
            private static readonly Vector<int> _one = Vector<int>.One;

            /// <summary>
            ///     Executes the t 0
            /// </summary>
            /// <param name="t0">The </param>
            /// <param name="offset">The offset</param>
            /// <param name="padding">The padding</param>
            public void Execute(Span<Vector<int>> t0, int offset, int padding)
            {
                for (int i = 0; i < t0.Length; i++)
                {
                    t0[i] += _one;
                }
            }
        }

        /// <summary>
        ///     The myriad context class
        /// </summary>
        /// <seealso cref="MyriadBaseContext" />
        private sealed class MyriadContext : MyriadBaseContext
        {
            // Myriad stores components as arrays of structs, so all structs of the same type are 
            // always sequential in memory no matter what else is attached to the gameObject. So no need to respect
            // the padding input
            /// <summary>
            ///     Initializes a new instance of the <see cref="MyriadContext" /> class
            /// </summary>
            /// <param name="entityCount">The gameObject count</param>
            /// <param name="_">The </param>
            public MyriadContext(int entityCount, int _)
            {
                CommandBuffer cmd = new CommandBuffer(World);
                for (int i = 0; i < entityCount; i++)
                {
                    CommandBuffer.BufferedEntity e = cmd.Create().Set(new Component1());
                }

                cmd.Playback().Dispose();
            }
        }
    }
}