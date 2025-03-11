using System;
using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithOneComponent
{
    /// <summary>
    /// The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
    {
        /// <summary>
        /// The default ecs context class
        /// </summary>
        /// <seealso cref="DefaultEcsBaseContext"/>
        private sealed partial class DefaultEcsContext : DefaultEcsBaseContext
        {
            /// <summary>
            /// The component system class
            /// </summary>
            /// <seealso cref="AComponentSystem{int, Component1}"/>
            private sealed class ComponentSystem : AComponentSystem<int, Component1>
            {
                /// <summary>
                /// Initializes a new instance of the <see cref="ComponentSystem"/> class
                /// </summary>
                /// <param name="world">The world</param>
                /// <param name="runner">The runner</param>
                public ComponentSystem(World world, IParallelRunner runner)
                    : base(world, runner)
                { }

                /// <summary>
                /// Initializes a new instance of the <see cref="ComponentSystem"/> class
                /// </summary>
                /// <param name="world">The world</param>
                public ComponentSystem(World world)
                    : base(world)
                { }

                /// <summary>
                /// Updates the state
                /// </summary>
                /// <param name="state">The state</param>
                /// <param name="components">The components</param>
                protected override void Update(int state, Span<Component1> components)
                {
                    foreach (ref Component1 component in components)
                    {
                        ++component.Value;
                    }
                }
            }

            /// <summary>
            /// The entity set system class
            /// </summary>
            /// <seealso cref="AEntitySetSystem{int}"/>
            private sealed partial class EntitySetSystem : AEntitySetSystem<int>
            {
                /// <summary>
                /// Updates the component
                /// </summary>
                /// <param name="component">The component</param>
                [Update]
                private static void Update(ref Component1 component)
                {
                    ++component.Value;
                }
            }

            /// <summary>
            /// Gets the value of the runner
            /// </summary>
            public IParallelRunner Runner { get; }

            /// <summary>
            /// Gets the value of the mono thread component system
            /// </summary>
            public ISystem<int> MonoThreadComponentSystem { get; }

            /// <summary>
            /// Gets the value of the multi thread component system
            /// </summary>
            public ISystem<int> MultiThreadComponentSystem { get; }

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
                MonoThreadComponentSystem = new ComponentSystem(World);
                MultiThreadComponentSystem = new ComponentSystem(World, Runner);
                MonoThreadEntitySetSystem = new EntitySetSystem(World);
                MultiThreadEntitySetSystem = new EntitySetSystem(World, Runner);

                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.CreateEntity();
                    }

                    Entity entity = World.CreateEntity();
                    entity.Set<Component1>();
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
        /// Defaults the ecs component system mono thread
        /// </summary>
        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark]
        public void DefaultEcs_ComponentSystem_MonoThread() => _defaultEcs.MonoThreadComponentSystem.Update(0);

        /// <summary>
        /// Defaults the ecs component system multi thread
        /// </summary>
        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark]
        public void DefaultEcs_ComponentSystem_MultiThread() => _defaultEcs.MultiThreadComponentSystem.Update(0);

        /// <summary>
        /// Defaults the ecs entity set system mono thread
        /// </summary>
        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark]
        public void DefaultEcs_EntitySetSystem_MonoThread() => _defaultEcs.MonoThreadEntitySetSystem.Update(0);

        /// <summary>
        /// Defaults the ecs entity set system multi thread
        /// </summary>
        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark]
        public void DefaultEcs_EntitySetSystem_MultiThread() => _defaultEcs.MultiThreadEntitySetSystem.Update(0);
    }
}
