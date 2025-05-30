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

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponents
{
    /// <summary>
    ///     The system with two components class
    /// </summary>
    public partial class SystemWithTwoComponents
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
            _frent.Query.Inline<Sum, Component1, Component2>(default(Sum));
        }

        /// <summary>
        ///     Frents the query delegate
        /// </summary>
        [BenchmarkCategory(Categories.Frent), Benchmark]
        public void Frent_QueryDelegate()
        {
            _frent.Query.Delegate((ref Component1 c1, ref Component2 c2) => c1.Value += c2.Value);
        }

        /// <summary>
        ///     Frents the simd
        /// </summary>
        [BenchmarkCategory(Categories.Frent), Benchmark]
        public void Frent_Simd()
        {
            foreach ((Span<Component1> s1, Span<Component2> s2) in _frent.Query.EnumerateChunks<Component1, Component2>())
            {
                int len = s1.Length - (s1.Length & 7);

                Span<Vector256<int>> ints = MemoryMarshal.Cast<Component1, Vector256<int>>(s1.Slice(0, len));
                Span<Vector256<int>> a = MemoryMarshal.Cast<Component2, Vector256<int>>(s2.Slice(0, len))[..ints.Length];

                for (int i = 0; i < ints.Length; i++)
                {
                    ints[i] += a[i];
                }

                for (int i = len; i < s1.Length; i++)
                {
                    s1[i].Value += s2[i].Value;
                }
            }
        }

        /// <summary>
        ///     The alis context class
        /// </summary>
        /// <seealso cref="FrentBaseContext" />
        internal sealed class FrentContext : FrentBaseContext
        {
            /// <summary>
            ///     The query
            /// </summary>
            public Query Query;

            /// <summary>
            ///     Initializes a new instance of the <see cref="FrentContext" /> class
            /// </summary>
            /// <param name="entityCount">The gameObject count</param>
            /// <param name="padding">The padding</param>
            public FrentContext(int entityCount, int padding)
            {
                for (int i = 0; i < entityCount; i++)
                {
                    World.Create(default(Component1), new Component2 {Value = 1});
                    for (int j = 0; j < padding; j++)
                    {
                        World.Create();
                    }
                }

                Query = World.Query<With<Component1>, With<Component2>>();
            }
        }

        /// <summary>
        ///     The sum
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Sum : IAction<Component1, Component2>
        {
            /// <summary>
            ///     Runs the t 0
            /// </summary>
            /// <param name="t0">The </param>
            /// <param name="t1">The </param>
            public void Run(ref Component1 t0, ref Component2 t1)
            {
                t0.Value += t1.Value;
            }
        }
    }
}