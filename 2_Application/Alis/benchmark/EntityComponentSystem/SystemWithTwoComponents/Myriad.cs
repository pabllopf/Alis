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

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponents
{
    /// <summary>
    ///     The system with two components class
    /// </summary>
    public partial class SystemWithTwoComponents
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
            world.Execute<MyriadForEach2, Component1, Component2>(new MyriadForEach2());
        }

        /// <summary>
        ///     Myriads the multi thread
        /// </summary>
        [BenchmarkCategory(Categories.Myriad), Benchmark]
        public void Myriad_MultiThread()
        {
            World world = _myriad.World;
            world.ExecuteParallel<MyriadForEach2, Component1, Component2>(new MyriadForEach2());
        }

        /// <summary>
        ///     Myriads the single thread chunk
        /// </summary>
        [BenchmarkCategory(Categories.Myriad), Benchmark]
        public void Myriad_SingleThreadChunk()
        {
            World world = _myriad.World;
            world.ExecuteChunk<MyriadForEach2, Component1, Component2>(new MyriadForEach2());
        }

        /// <summary>
        ///     Myriads the multi thread chunk
        /// </summary>
        [BenchmarkCategory(Categories.Myriad), Benchmark]
        public void Myriad_MultiThreadChunk()
        {
            World world = _myriad.World;
            world.ExecuteChunkParallel<MyriadForEach2, Component1, Component2>(new MyriadForEach2());
        }

        /// <summary>
        ///     Myriads the enumerable
        /// </summary>
        [BenchmarkCategory(Categories.Myriad), Benchmark]
        public void Myriad_Enumerable()
        {
            World world = _myriad.World;

            foreach ((Entity _, RefT<Component1> c1, RefT<Component2> c2) in world.Query<Component1, Component2>())
            {
                c1.Ref.Value += c2.Ref.Value;
            }
        }

        /// <summary>
        ///     Myriads the delegate
        /// </summary>
        [BenchmarkCategory(Categories.Myriad), Benchmark]
        public void Myriad_Delegate()
        {
            World world = _myriad.World;

            world.Query((ref Component1 c1, ref Component1 c2) => { c1.Value += c2.Value; });
        }

        /// <summary>
        ///     Myriads the single thread chunk simd
        /// </summary>
        [BenchmarkCategory(Categories.Myriad), Benchmark]
        public void Myriad_SingleThreadChunk_SIMD()
        {
            World world = _myriad.World;

            world.ExecuteVectorChunk<MyriadVectorForEach2, Component1, int, Component2, int>(new MyriadVectorForEach2());
        }

        /// <summary>
        ///     The myriad for each
        /// </summary>
        public struct MyriadForEach2
            : IQuery<Component1, Component2>, IChunkQuery<Component1, Component2>
        {
            /// <summary>
            ///     Executes the gameObject
            /// </summary>
            /// <param name="entity">The gameObject</param>
            /// <param name="t0">The </param>
            /// <param name="t1">The </param>
            public void Execute(Entity entity, ref Component1 t0, ref Component2 t1)
            {
                t0.Value += t1.Value;
            }

            /// <summary>
            ///     Executes the chunk
            /// </summary>
            /// <param name="chunk">The chunk</param>
            /// <param name="e">The </param>
            /// <param name="t0">The </param>
            /// <param name="t1">The </param>
            public void Execute(ChunkHandle chunk, ReadOnlySpan<Entity> e, Span<Component1> t0, Span<Component2> t1)
            {
                for (int i = 0; i < t0.Length; i++)
                {
                    t0[i].Value += t1[i].Value;
                }
            }
        }

        /// <summary>
        ///     The myriad vector for each
        /// </summary>
        public struct MyriadVectorForEach2
            : IVectorChunkQuery<int, int>
        {
            /// <summary>
            ///     Executes the t 0
            /// </summary>
            /// <param name="t0">The </param>
            /// <param name="t1">The </param>
            /// <param name="offset">The offset</param>
            /// <param name="padding">The padding</param>
            public void Execute(Span<Vector<int>> t0, Span<Vector<int>> t1, int offset, int padding)
            {
                for (int i = 0; i < t0.Length; i++)
                {
                    t0[i] += t1[i];
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
                    CommandBuffer.BufferedEntity e = cmd.Create().Set(new Component1()).Set(new Component2());
                }

                cmd.Playback().Dispose();
            }
        }
    }
}