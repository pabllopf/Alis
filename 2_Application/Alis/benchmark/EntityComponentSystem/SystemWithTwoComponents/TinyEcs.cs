// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TinyEcs.cs
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
using Alis.Benchmark.EntityComponentSystem.Contexts.TinyEcs_Components;
using BenchmarkDotNet.Attributes;
using TinyEcs;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponents
{
    /// <summary>
    ///     The system with two components class
    /// </summary>
    public partial class SystemWithTwoComponents
    {
        /// <summary>
        ///     The tiny ecs
        /// </summary>
        [Context] private readonly TinyEcsContext _tinyEcs;

        /// <summary>
        ///     Tinies the ecs each
        /// </summary>
        [BenchmarkCategory(Categories.TinyEcs), Benchmark]
        public void TinyEcs_Each()
        {
            _tinyEcs.Query.Each((ref Component1 c1, ref Component2 c2) => c1.Value += c2.Value);
        }

        /// <summary>
        ///     Tinies the ecs each job
        /// </summary>
        [BenchmarkCategory(Categories.TinyEcs), Benchmark]
        public void TinyEcs_EachJob()
        {
            _tinyEcs.Query.EachJob((ref Component1 c1, ref Component2 c2) => c1.Value += c2.Value);
        }

        /// <summary>
        ///     The tiny ecs context class
        /// </summary>
        /// <seealso cref="TinyEcsBaseContext" />
        private sealed class TinyEcsContext : TinyEcsBaseContext
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="TinyEcsContext" /> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            /// <param name="entityPadding">The entity padding</param>
            public TinyEcsContext(int entityCount, int entityPadding)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        EntityView padding = World.Entity();
                        switch (j % 2)
                        {
                            case 0:
                                padding.Set(new Component1());
                                break;

                            case 1:
                                padding.Set(new Component2());
                                break;
                        }
                    }

                    World.Entity()
                        .Set(new Component1())
                        .Set(new Component2 {Value = 1});
                    Query = World.QueryBuilder().With<Component1>().With<Component2>().Build();
                }
            }

            /// <summary>
            ///     Gets the value of the query
            /// </summary>
            public Query Query { get; }
        }
    }
}