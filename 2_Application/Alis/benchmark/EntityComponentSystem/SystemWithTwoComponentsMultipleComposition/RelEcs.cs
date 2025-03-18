// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RelEcs.cs
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
using BenchmarkDotNet.Attributes;
using RelEcs;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    ///     The system with two components multiple composition class
    /// </summary>
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        /// <summary>
        ///     The rel ecs
        /// </summary>
        [Context] private readonly RelEcsContext _relEcs;

        /// <summary>
        ///     Rels the ecs
        /// </summary>
        [BenchmarkCategory(Categories.RelEcs), Benchmark]
        public void RelEcs() => _relEcs.MonoThreadSystem.Run(_relEcs.World);

        /// <summary>
        ///     The rel ecs context class
        /// </summary>
        /// <seealso cref="RelEcsBaseContext" />
        private sealed class RelEcsContext : RelEcsBaseContext
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="RelEcsContext" /> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            public RelEcsContext(int entityCount)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    EntityBuilder entity = World.Spawn()
                        .Add(new Component1())
                        .Add(new Component2 {Value = 1});

                    switch (i % 4)
                    {
                        case 0:
                            entity.Add<Padding1>();
                            break;

                        case 1:
                            entity.Add<Padding2>();
                            break;

                        case 2:
                            entity.Add<Padding3>();
                            break;

                        case 3:
                            entity.Add<Padding4>();
                            break;
                    }
                }
            }

            /// <summary>
            ///     Gets the value of the mono thread system
            /// </summary>
            public ISystem MonoThreadSystem { get; } = new MonoThreadRunSystem();

            /// <summary>
            ///     The padding
            /// </summary>
            private sealed record Padding1;

            /// <summary>
            ///     The padding
            /// </summary>
            private sealed record Padding2;

            /// <summary>
            ///     The padding
            /// </summary>
            private sealed record Padding3;

            /// <summary>
            ///     The padding
            /// </summary>
            private sealed record Padding4;

            /// <summary>
            ///     The mono thread run system class
            /// </summary>
            /// <seealso cref="ISystem" />
            private sealed class MonoThreadRunSystem : ISystem
            {
                /// <summary>
                ///     Runs the world
                /// </summary>
                /// <param name="world">The world</param>
                public void Run(World world)
                {
                    Query<Component1, Component2> query = world.Query<Component1, Component2>().Build();
                    foreach ((Component1 c1, Component2 c2) in query)
                    {
                        c1.Value += c2.Value;
                    }
                }
            }
        }
    }
}