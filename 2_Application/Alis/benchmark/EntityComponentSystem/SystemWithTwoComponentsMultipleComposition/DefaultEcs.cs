// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DefaultEcs.cs
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
using BenchmarkDotNet.Attributes;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    ///     The system with two components multiple composition class
    /// </summary>
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        /// <summary>
        ///     The default ecs
        /// </summary>
        [Context] private readonly DefaultEcsContext _defaultEcs;

        /// <summary>
        ///     Defaults the ecs mono thread
        /// </summary>
        [BenchmarkCategory(Categories.DefaultEcs), Benchmark]
        public void DefaultEcs_MonoThread() => _defaultEcs.MonoThreadEntitySetSystem.Update(0);

        /// <summary>
        ///     Defaults the ecs multi thread
        /// </summary>
        [BenchmarkCategory(Categories.DefaultEcs), Benchmark]
        public void DefaultEcs_MultiThread() => _defaultEcs.MultiThreadEntitySetSystem.Update(0);

        /// <summary>
        ///     The default ecs context class
        /// </summary>
        /// <seealso cref="DefaultEcsBaseContext" />
        private sealed partial class DefaultEcsContext : DefaultEcsBaseContext
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="DefaultEcsContext" /> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            public DefaultEcsContext(int entityCount)
            {
                Runner = new DefaultParallelRunner(Environment.ProcessorCount);
                MonoThreadEntitySetSystem = new EntitySetSystem(World);
                MultiThreadEntitySetSystem = new EntitySetSystem(World, Runner);

                for (int i = 0; i < entityCount; ++i)
                {
                    Entity entity = World.CreateEntity();
                    entity.Set<Component1>();
                    entity.Set(new Component2 {Value = 1});

                    switch (i % 4)
                    {
                        case 0:
                            entity.Set<Padding1>();
                            break;

                        case 1:
                            entity.Set<Padding2>();
                            break;

                        case 2:
                            entity.Set<Padding3>();
                            break;

                        case 3:
                            entity.Set<Padding4>();
                            break;
                    }
                }
            }

            /// <summary>
            ///     Gets the value of the runner
            /// </summary>
            public IParallelRunner Runner { get; }

            /// <summary>
            ///     Gets the value of the mono thread entity set system
            /// </summary>
            public ISystem<int> MonoThreadEntitySetSystem { get; }

            /// <summary>
            ///     Gets the value of the multi thread entity set system
            /// </summary>
            public ISystem<int> MultiThreadEntitySetSystem { get; }

            /// <summary>
            ///     Disposes this instance
            /// </summary>
            public override void Dispose()
            {
                base.Dispose();

                Runner.Dispose();
            }

            private record struct Padding1;

            private record struct Padding2;

            private record struct Padding3;

            private record struct Padding4;

            /// <summary>
            ///     The entity set system class
            /// </summary>
            /// <seealso cref="AEntitySetSystem{int}" />
            private sealed partial class EntitySetSystem : AEntitySetSystem<int>
            {
                /// <summary>
                ///     Updates the c 1
                /// </summary>
                /// <param name="c1">The </param>
                /// <param name="c2">The </param>
                [Update]
                private static void Update(ref Component1 c1, in Component2 c2)
                {
                    c1.Value += c2.Value;
                }
            }
        }
    }
}