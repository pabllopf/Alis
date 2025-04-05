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
using Alis.Core.Ecs;
using Alis.Core.Ecs.Operations;
using BenchmarkDotNet.Attributes;
using static Alis.Benchmark.EntityComponentSystem.Contexts.AlisBaseContext;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    ///     The system with two components multiple composition class
    /// </summary>
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        /// <summary>
        ///     The frent
        /// </summary>
        [Context] private readonly AlisContext _alis;

        /// <summary>
        ///     Frents the query inline
        /// </summary>
        [BenchmarkCategory(Categories.Frent), Benchmark]
        public void Alis_QueryInline()
        {
            _alis.Query.Inline<SumAlis, Component1, Component2>(default(SumAlis));
        }

        /// <summary>
        ///     Frents the simd
        /// </summary>
        [BenchmarkCategory(Categories.Frent), Benchmark]
        public void Alis_Simd()
        {
            foreach ((Span<Component1> s1, Span<Component2> s2) in _alis.Query.EnumerateChunks<Component1, Component2>())
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
        ///     The frent context class
        /// </summary>
        /// <seealso cref="FrentBaseContext" />
        internal sealed class AlisContext : AlisBaseContext
        {
            /// <summary>
            ///     The query
            /// </summary>
            public Query Query;

            /// <summary>
            ///     Initializes a new instance of the <see cref="FrentContext" /> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            public AlisContext(int entityCount)
            {
                for (int i = 0; i < entityCount; i++)
                {
                    GameObject e = (entityCount % 4) switch
                    {
                        0 => Scene.Create<Component1, Component2, Padding1>(default(Component1), new Component2 {Value = 1}, default(Padding1)),
                        1 => Scene.Create<Component1, Component2, Padding2>(default(Component1), new Component2 {Value = 1}, default(Padding2)),
                        2 => Scene.Create<Component1, Component2, Padding3>(default(Component1), new Component2 {Value = 1}, default(Padding3)),
                        _ => Scene.Create<Component1, Component2, Padding4>(default(Component1), new Component2 {Value = 1}, default(Padding4))
                    };
                }

                Query = Scene.Query<With<Component1>, With<Component2>>();
            }

            /// <summary>
            ///     The padding
            /// </summary>
            private struct Padding1;

            /// <summary>
            ///     The padding
            /// </summary>
            private struct Padding2;

            /// <summary>
            ///     The padding
            /// </summary>
            private struct Padding3;

            /// <summary>
            ///     The padding
            /// </summary>
            private struct Padding4;
        }

        /// <summary>
        ///     The sum
        /// </summary>
        internal struct SumAlis : IAction<Component1, Component2>
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