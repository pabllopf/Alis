// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Fennecs.cs
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
using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.Fennecs_Components;
using BenchmarkDotNet.Attributes;
using fennecs;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithThreeComponents
{
    /// <summary>
    ///     The system with three components class
    /// </summary>
    public partial class SystemWithThreeComponents
    {
        /// <summary>
        ///     The fennecs
        /// </summary>
        [Context] private readonly FennecsContext _fennecs;

        /// <summary>
        ///     Fennecses the for each
        /// </summary>
        [BenchmarkCategory(Categories.Fennecs), Benchmark]
        public void Fennecs_ForEach()
        {
            _fennecs.query.For((ref Component1 c1, ref Component2 c2, ref Component3 c3) => c1.Value += c2.Value + c3.Value);
        }

        /// <summary>
        ///     Fennecses the job
        /// </summary>
        [BenchmarkCategory(Categories.Fennecs), Benchmark]
        public void Fennecs_Job()
        {
            _fennecs.query.Job(delegate(ref Component1 c1, ref Component2 c2, ref Component3 c3) { c1.Value += c2.Value + c3.Value; }, 1024);
        }

        /// <summary>
        ///     Fennecses the raw
        /// </summary>
        [BenchmarkCategory(Categories.Fennecs), Benchmark]
        public void Fennecs_Raw()
        {
            _fennecs.query.Raw(delegate(Memory<Component1> c1v, Memory<Component2> c2v, Memory<Component3> c3v)
            {
                Span<Component1> c1vs = c1v.Span;
                Span<Component2> c2vs = c2v.Span;
                Span<Component3> c3vs = c3v.Span;

                for (int i = 0; i < c1vs.Length; ++i)
                {
                    ref Component1 c1 = ref c1vs[i];
                    c1.Value += c2vs[i].Value + c3vs[i].Value;
                }
            });
        }

        /// <summary>
        ///     The fennecs context class
        /// </summary>
        /// <seealso cref="FennecsBaseContext" />
        private sealed class FennecsContext : FennecsBaseContext
        {
            /// <summary>
            ///     The query
            /// </summary>
            public readonly Query<Component1, Component2, Component3> query;

            /// <summary>
            ///     Initializes a new instance of the <see cref="FennecsContext" /> class
            /// </summary>
            /// <param name="entityCount">The gameObject count</param>
            /// <param name="entityPadding">The gameObject padding</param>
            public FennecsContext(int entityCount, int entityPadding)
            {
                query = World.Query<Component1, Component2, Component3>().Build();
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        Entity padding = World.Spawn();
                        switch (j % 3)
                        {
                            case 0:
                                padding.Add<Component1>();
                                break;
                            case 1:
                                padding.Add<Component2>();
                                break;
                            case 2:
                                padding.Add<Component3>();
                                break;
                        }
                    }

                    World.Spawn().Add<Component1>()
                        .Add(new Component2 {Value = 1})
                        .Add(new Component3 {Value = 1});
                }
            }
        }
    }
}