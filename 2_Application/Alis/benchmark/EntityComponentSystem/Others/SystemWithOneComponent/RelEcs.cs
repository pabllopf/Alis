using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using RelEcs;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithOneComponent
{
    /// <summary>
    /// The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
    {
        /// <summary>
        /// The rel ecs context class
        /// </summary>
        /// <seealso cref="RelEcsBaseContext"/>
        private sealed class RelEcsContext : RelEcsBaseContext
        {
            /// <summary>
            /// The mono thread run system class
            /// </summary>
            /// <seealso cref="ISystem"/>
            private sealed class MonoThreadRunSystem : ISystem
            {
                /// <summary>
                /// Runs the world
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

            /// <summary>
            /// Gets the value of the mono thread system
            /// </summary>
            public ISystem MonoThreadSystem { get; } = new MonoThreadRunSystem();

            /// <summary>
            /// Initializes a new instance of the <see cref="RelEcsContext"/> class
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
        }

        /// <summary>
        /// The rel ecs
        /// </summary>
        [Context]
        private readonly RelEcsContext _relEcs;

        /// <summary>
        /// Rels the ecs
        /// </summary>
        [BenchmarkCategory(Categories.RelEcs)]
        [Benchmark]
        public void RelEcs() => _relEcs.MonoThreadSystem.Run(_relEcs.World);
    }
}
