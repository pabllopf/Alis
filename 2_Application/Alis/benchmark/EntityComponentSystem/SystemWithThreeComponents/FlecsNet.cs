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

namespace Alis.Benchmark.EntityComponentSystem.SystemWithThreeComponents
{
    /// <summary>
    ///     The system with three components class
    /// </summary>
    public partial class SystemWithThreeComponents
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
            _flecs.query.Each((ref Component1 c1, ref Component2 c2, ref Component3 c3) => { c1.Value += c2.Value + c3.Value; });
        }

        /// <summary>
        ///     Flecses the net iter
        /// </summary>
        [BenchmarkCategory(Categories.FlecsNet), Benchmark]
        public void FlecsNet_Iter()
        {
            _flecs.query.Iter((Iter it, Column<Component1> c1, Column<Component2> c2, Column<Component3> c3) =>
            {
                foreach (int i in it)
                {
                    c1[i].Value += c2[i].Value + c3[i].Value;
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
            /// <param name="entityCount">The entity count</param>
            /// <param name="entityPadding">The entity padding</param>
            public FlecsContext(int entityCount, int entityPadding)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        Entity padding = World.Entity();
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

                    World.Entity().Add<Component1>()
                        .Set(new Component2
                        {
                            Value = 1
                        })
                        .Set(new Component3
                        {
                            Value = 1
                        });
                }

                query = World.QueryBuilder().With<Component1>().With<Component2>().With<Component3>().Build();
            }
        }
    }
}