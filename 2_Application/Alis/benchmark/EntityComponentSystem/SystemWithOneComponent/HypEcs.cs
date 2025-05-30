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

namespace Alis.Benchmark.EntityComponentSystem.SystemWithOneComponent
{
    /// <summary>
    ///     The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
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
            /// <param name="entityPadding">The gameObject padding</param>
            public HypEcsContext(int entityCount, int entityPadding)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.Spawn();
                    }

                    World
                        .Spawn()
                        .Add(new Component1());
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
                    Query<Component1> query = world.Query<Component1>().Build();
                    query.Run((count, s1) =>
                    {
                        for (int i = 0; i < count; i++)
                        {
                            s1[i].Value++;
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
                    Query<Component1> query = world.Query<Component1>().Build();
                    query.RunParallel((count, s1) =>
                    {
                        for (int i = 0; i < count; i++)
                        {
                            s1[i].Value++;
                        }
                    });
                }
            }
        }
    }
}