// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AlisEcs.cs
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
using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems;
using BenchmarkDotNet.Attributes;
using static Alis.Benchmark.EntityComponentSystem.Contexts.AlisBaseContext;

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
        [Context] private readonly AlisContext _alis;


        /// <summary>
        ///     Alises the query inline
        /// </summary>
        [BenchmarkCategory(Categories.Alis), Benchmark]
        public void Alis_QueryInline()
        {
            _alis.Query.Inline<IncrementAlis, Component1>(default(IncrementAlis));
        }


        /// <summary>
        ///     Alises the query delegate
        /// </summary>
        [BenchmarkCategory(Categories.Alis), Benchmark]
        public void Alis_QueryDelegate()
        {
            _alis.Query.Delegate((ref Component1 c) => c.Value++);
        }


        /// <summary>
        ///     Alises the simd
        /// </summary>
        [BenchmarkCategory(Categories.Alis), Benchmark]
        public void Alis_Simd()
        {
            Vector256<int> sum = Vector256.Create(1);
            foreach (ChunkTuple<Component1> chunk in _alis.Query.EnumerateChunks<Component1>())
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
        /// <seealso cref="AlisBaseContext" />
        private sealed class AlisContext : AlisBaseContext
        {
            /// <summary>
            ///     The query
            /// </summary>
            public readonly Query Query;


            /// <summary>
            ///     Initializes a new instance of the <see cref="AlisContext" /> class
            /// </summary>
            /// <param name="entityCount">The gameObject count</param>
            /// <param name="entityPadding">The gameObject padding</param>
            public AlisContext(int entityCount, int entityPadding)
            {
                for (int i = 0; i < entityCount; i++)
                {
                    Scene.Create(default(Component1));
                    for (int j = 0; j < entityPadding; j++)
                    {
                        Scene.Create();
                    }
                }

                Query = Scene.Query<With<Component1>>();
            }
        }


        /// <summary>
        ///     The increment alis
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct IncrementAlis : IAction<Component1>
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