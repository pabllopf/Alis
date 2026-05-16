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

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponents
{
    /// <summary>
    ///     The system with two components class
    /// </summary>
    public partial class SystemWithTwoComponents
    {
        /// <summary>
        ///     The default ecs
        /// </summary>
        [Context] private readonly DefaultEcsContext _defaultEcs;

        /// <summary>
        ///     Benchmarks EntitySetSystem mono-threaded processing with two components using DefaultEcs
        /// </summary>
        [BenchmarkCategory(Categories.DefaultEcs), Benchmark]
        public void DefaultEcs_MonoThread() => _defaultEcs.MonoThreadEntitySetSystem.Update(0);

        /// <summary>
        ///     Benchmarks EntitySetSystem multi-threaded processing with two components using DefaultEcs
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
            /// <param name="entityCount">The gameObject count</param>
            /// <param name="entityPadding">The gameObject padding</param>
            public DefaultEcsContext(int entityCount, int entityPadding)
            {
                Runner = new DefaultParallelRunner(Environment.ProcessorCount);
                MonoThreadEntitySetSystem = new EntitySetSystem(World);
                MultiThreadEntitySetSystem = new EntitySetSystem(World, Runner);

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        Entity padding = World.CreateEntity();
                        switch (j % 2)
                        {
                            case 0:
                                padding.Set<Component1>();
                                break;

                            case 1:
                                padding.Set<Component2>();
                                break;
                        }
                    }

                    Entity entity = World.CreateEntity();
                    entity.Set<Component1>();
                    entity.Set(new Component2 {Value = 1});
                }
            }

        /// <summary>
        ///     Gets the parallel runner used for multi-threaded execution
        /// </summary>
        public IParallelRunner Runner { get; }

        /// <summary>
        ///     Gets the mono-threaded entity set system
        /// </summary>
        public ISystem<int> MonoThreadEntitySetSystem { get; }

        /// <summary>
        ///     Gets the multi-threaded entity set system
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

            /// <summary>
            ///     The gameObject set system class
            /// </summary>
            /// <seealso cref="AEntitySetSystem{int}" />
            private sealed partial class EntitySetSystem : AEntitySetSystem<int>
            {
        /// <summary>
        ///     Sums the second component value into the first
        /// </summary>
        /// <param name="c1">The first component whose value will be increased</param>
        /// <param name="c2">The second component whose value is added</param>
                [Update]
                private static void Update(ref Component1 c1, in Component2 c2)
                {
                    c1.Value += c2.Value;
                }
            }
        }
    }
}