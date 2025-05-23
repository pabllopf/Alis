// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FlecsNet.cs
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

using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.Arch_Components;
using BenchmarkDotNet.Attributes;
using Flecs.NET.Core;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithOneComponent
{
    /// <summary>
    ///     The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
    {
        /// <summary>
        ///     The flecs
        /// </summary>
        [Context] private readonly FlecsContext _flecs;

        /// <summary>
        ///     Flecses the net each
        /// </summary>
        [BenchmarkCategory(Categories.FlecsNet), Benchmark]
        public void FlecsNet_Each()
        {
            _flecs.query.Each((ref Component1 c1) => { c1.Value += 1; });
        }

        /// <summary>
        ///     Flecses the net iter
        /// </summary>
        [BenchmarkCategory(Categories.FlecsNet), Benchmark]
        public void FlecsNet_Iter()
        {
            _flecs.query.Iter((Iter it, Column<Component1> c1) =>
            {
                foreach (int i in it)
                {
                    c1[i].Value += 1;
                }
            });
        }

        /// <summary>
        ///     The flecs context class
        /// </summary>
        /// <seealso cref="FlecsNetBaseContext" />
        private sealed class FlecsContext : FlecsNetBaseContext
        {
            /// <summary>
            ///     The query
            /// </summary>
            public Query query;

            /// <summary>
            ///     Initializes a new instance of the <see cref="FlecsContext" /> class
            /// </summary>
            /// <param name="entityCount">The gameObject count</param>
            /// <param name="entityPadding">The gameObject padding</param>
            public FlecsContext(int entityCount, int entityPadding)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.Entity();
                    }

                    World.Entity().Add<Component1>();
                }

                query = World.QueryBuilder().With<Component1>().Build();
            }
        }
    }
}