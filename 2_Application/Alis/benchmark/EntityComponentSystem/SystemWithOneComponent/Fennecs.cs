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

namespace Alis.Benchmark.EntityComponentSystem.SystemWithOneComponent
{
    /// <summary>
    ///     The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
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
            _fennecs.query.For((ref Component1 comp0) => comp0.Value++);
        }

        /// <summary>
        ///     Fennecses the job
        /// </summary>
        [BenchmarkCategory(Categories.Fennecs), Benchmark]
        public void Fennecs_Job()
        {
            _fennecs.query.Job(delegate(ref Component1 v) { v.Value++; }, 1024);
        }

        /// <summary>
        ///     Fennecses the raw
        /// </summary>
        [BenchmarkCategory(Categories.Fennecs), Benchmark]
        public void Fennecs_Raw()
        {
            _fennecs.query.Raw(delegate(Memory<Component1> vectors)
            {
                foreach (ref Component1 v in vectors.Span)
                {
                    v.Value++;
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
            public readonly Query<Component1> query;

            /// <summary>
            ///     Initializes a new instance of the <see cref="FennecsContext" /> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            /// <param name="entityPadding">The entity padding</param>
            public FennecsContext(int entityCount, int entityPadding)
            {
                query = World.Query<Component1>().Build();
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.Spawn();
                    }

                    World.Spawn().Add<Component1>();
                }
            }
        }
    }
}