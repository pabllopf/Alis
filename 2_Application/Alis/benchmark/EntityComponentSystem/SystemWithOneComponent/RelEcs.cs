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

namespace Alis.Benchmark.EntityComponentSystem.SystemWithOneComponent
{
    /// <summary>
    ///     The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
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
            /// <param name="entityPadding">The entity padding</param>
            public RelEcsContext(int entityCount, int entityPadding)
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
                    foreach (Component1 c in world.Query<Component1>().Build())
                    {
                        c.Value++;
                    }
                }
            }
        }
    }
}