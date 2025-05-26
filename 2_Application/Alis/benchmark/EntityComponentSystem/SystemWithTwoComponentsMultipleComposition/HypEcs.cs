// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:HypEcs.cs
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
using HypEcs;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    ///     The system with two components multiple composition class
    /// </summary>
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        /// <summary>
        ///     The hyp ecs
        /// </summary>
        [Context] private readonly HypEcsContext _hypEcs;

        /// <summary>
        ///     Hyps the ecs mono thread
        /// </summary>
        [BenchmarkCategory(Categories.HypEcs), Benchmark]
        public void HypEcs_MonoThread() => _hypEcs.MonoThreadSystem.Run(_hypEcs.World);

        /// <summary>
        ///     Hyps the ecs multi thread
        /// </summary>
        [BenchmarkCategory(Categories.HypEcs), Benchmark]
        public void HypEcs_MultiThread() => _hypEcs.MultiThreadSystem.Run(_hypEcs.World);

        /// <summary>
        ///     The hyp ecs context class
        /// </summary>
        /// <seealso cref="HypEcsBaseContext" />
        private sealed class HypEcsContext : HypEcsBaseContext
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="HypEcsContext" /> class
            /// </summary>
            /// <param name="entityCount">The gameObject count</param>
            public HypEcsContext(int entityCount)
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
            ///     Gets the value of the multi thread system
            /// </summary>
            public ISystem MultiThreadSystem { get; } = new MultiThreadRunSystem();

            /// <summary>
            ///     The padding
            /// </summary>
            public struct Padding1
            {
            }

            /// <summary>
            ///     The padding
            /// </summary>
            public struct Padding2
            {
            }

            /// <summary>
            ///     The padding
            /// </summary>
            public struct Padding3
            {
            }

            /// <summary>
            ///     The padding
            /// </summary>
            public struct Padding4
            {
            }

            /// <summary>
            ///     The mono thread run system class
            /// </summary>
            /// <seealso cref="ISystem" />
            private sealed class MonoThreadRunSystem : ISystem
            {
                /// <summary>
                ///     Runs the scene
                /// </summary>
                /// <param name="world">The scene</param>
                public void Run(World world)
                {
                    Query<Component1, Component2> query = world.Query<Component1, Component2>().Build();
                    query.Run((count, s1, s2) =>
                    {
                        for (int i = 0; i < count; i++)
                        {
                            s1[i].Value += s2[i].Value;
                        }
                    });
                }
            }

            /// <summary>
            ///     The multi thread run system class
            /// </summary>
            /// <seealso cref="ISystem" />
            private sealed class MultiThreadRunSystem : ISystem
            {
                /// <summary>
                ///     Runs the scene
                /// </summary>
                /// <param name="world">The scene</param>
                public void Run(World world)
                {
                    Query<Component1, Component2> query = world.Query<Component1, Component2>().Build();
                    query.RunParallel((count, s1, s2) =>
                    {
                        for (int i = 0; i < count; i++)
                        {
                            s1[i].Value += s2[i].Value;
                        }
                    });
                }
            }
        }
    }
}