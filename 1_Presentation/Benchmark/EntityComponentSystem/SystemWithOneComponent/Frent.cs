// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Frent.cs
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
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics;
using Alis.Benchmark.EntityComponentSystem.Contexts;
using BenchmarkDotNet.Attributes;
using Frent;
using Frent.Systems;
using static Alis.Benchmark.EntityComponentSystem.Contexts.FrentBaseContext;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithOneComponent
{
    /// <summary>
    ///     The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
    {
        /// <summary>
        ///     The alis
        /// </summary>
        [Context] private readonly FrentContext _frent;

        /// <summary>
        ///     Frents the query inline
        /// </summary>
        [BenchmarkCategory(Categories.Frent), Benchmark]
        public void Frent_QueryInline()
        {
            _frent.Query.Inline<Increment, Component1>(default(Increment));
        }

        /// <summary>
        ///     Frents the query delegate
        /// </summary>
        [BenchmarkCategory(Categories.Frent), Benchmark]
        public void Frent_QueryDelegate()
        {
            _frent.Query.Delegate((ref Component1 c) => c.Value++);
        }

        /// <summary>
        ///     Frents the simd
        /// </summary>
        [BenchmarkCategory(Categories.Frent), Benchmark]
        public void Frent_Simd()
        {
            Vector256<int> sum = Vector256.Create(1);
            foreach (ChunkTuple<Component1> chunk in _frent.Query.EnumerateChunks<Component1>())
            {
                int len = chunk.Span.Length - (chunk.Span.Length & 7);
                Span<Vector256<int>> ints = MemoryMarshal.Cast<Component1, Vector256<int>>(chunk.Span.Slice(0, len));
                for (int i = 0; i < ints.Length; i++)
                {
                    ints[i] += sum;
                }

                for (int i = len; i < chunk.Span.Length; i++)
                {
                    chunk.Span[i].Value++;
                }
            }
        }

        /// <summary>
        ///     The alis context class
        /// </summary>
        /// <seealso cref="FrentBaseContext" />
        private sealed class FrentContext : FrentBaseContext
        {
            /// <summary>
            ///     The query
            /// </summary>
            public readonly Query Query;

            /// <summary>
            ///     Initializes a new instance of the <see cref="FrentContext" /> class
            /// </summary>
            /// <param name="entityCount">The gameObject count</param>
            /// <param name="entityPadding">The gameObject padding</param>
            public FrentContext(int entityCount, int entityPadding)
            {
                for (int i = 0; i < entityCount; i++)
                {
                    World.Create(default(Component1));
                    for (int j = 0; j < entityPadding; j++)
                    {
                        World.Create();
                    }
                }

                Query = World.Query<With<Component1>>();
            }
        }

        /// <summary>
        ///     The increment
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Increment : IAction<Component1>
        {
            /// <summary>
            ///     Runs the t 0
            /// </summary>
            /// <param name="t0">The </param>
            public void Run(ref Component1 t0)
            {
                t0.Value++;
            }
        }
    }
}