using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using RelEcs;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithThreeComponents
{
    /// <summary>
    /// The system with three components class
    /// </summary>
    public partial class SystemWithThreeComponents
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
                    Query<Component1, Component2, Component3> query = world.Query<Component1, Component2, Component3>().Build();
                    foreach ((Component1 c1, Component2 c2, Component3 c3) in query)
                    {
                        c1.Value += c2.Value + c3.Value;
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
                        EntityBuilder padding = World.Spawn();
                        switch (j % 3)
                        {
                            case 0:
                                padding.Add(new Component1());
                                break;

                            case 1:
                                padding.Add(new Component2());
                                break;

                            case 2:
                                padding.Add(new Component3());
                                break;
                        }
                    }

                    World.Spawn()
                        .Add(new Component1())
                        .Add(new Component2 { Value = 1 })
                        .Add(new Component3 { Value = 1 });
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
