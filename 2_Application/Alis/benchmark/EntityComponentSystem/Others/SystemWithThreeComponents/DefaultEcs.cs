using System;
using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithThreeComponents
{
    /// <summary>
    /// The system with three components class
    /// </summary>
    public partial class SystemWithThreeComponents
    {
        /// <summary>
        /// The default ecs context class
        /// </summary>
        /// <seealso cref="DefaultEcsBaseContext"/>
        private sealed partial class DefaultEcsContext : DefaultEcsBaseContext
        {
            /// <summary>
            /// The entity set system class
            /// </summary>
            /// <seealso cref="AEntitySetSystem{int}"/>
            private sealed partial class EntitySetSystem : AEntitySetSystem<int>
            {
                /// <summary>
                /// Updates the c 1
                /// </summary>
                /// <param name="c1">The </param>
                /// <param name="c2">The </param>
                /// <param name="c3">The </param>
                [Update]
                private static void Update(ref Component1 c1, in Component2 c2, in Component3 c3)
                {
                    c1.Value += c2.Value + c3.Value;
                }
            }

            /// <summary>
            /// Gets the value of the runner
            /// </summary>
            public IParallelRunner Runner { get; }

            /// <summary>
            /// Gets the value of the mono thread entity set system
            /// </summary>
            public ISystem<int> MonoThreadEntitySetSystem { get; }

            /// <summary>
            /// Gets the value of the multi thread entity set system
            /// </summary>
            public ISystem<int> MultiThreadEntitySetSystem { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="DefaultEcsContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            /// <param name="entityPadding">The entity padding</param>
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
                        switch (j % 3)
                        {
                            case 0:
                                padding.Set<Component1>();
                                break;

                            case 1:
                                padding.Set<Component2>();
                                break;

                            case 2:
                                padding.Set<Component3>();
                                break;
                        }
                    }

                    Entity entity = World.CreateEntity();
                    entity.Set<Component1>();
                    entity.Set(new Component2 { Value = 1 });
                    entity.Set(new Component3 { Value = 1 });
                }
            }

            /// <summary>
            /// Disposes this instance
            /// </summary>
            public override void Dispose()
            {
                base.Dispose();

                Runner.Dispose();
            }
        }

        /// <summary>
        /// The default ecs
        /// </summary>
        [Context]
        private readonly DefaultEcsContext _defaultEcs;

        /// <summary>
        /// Defaults the ecs mono thread
        /// </summary>
        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark]
        public void DefaultEcs_MonoThread() => _defaultEcs.MonoThreadEntitySetSystem.Update(0);

        /// <summary>
        /// Defaults the ecs multi thread
        /// </summary>
        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark]
        public void DefaultEcs_MultiThread() => _defaultEcs.MultiThreadEntitySetSystem.Update(0);
    }
}
