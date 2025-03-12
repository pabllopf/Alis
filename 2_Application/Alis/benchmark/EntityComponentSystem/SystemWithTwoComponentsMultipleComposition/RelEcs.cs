using Alis.Benchmark.EntityComponentSystem.Contexts;
using BenchmarkDotNet.Attributes;
using RelEcs;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    /// The system with two components multiple composition class
    /// </summary>
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        /// <summary>
        /// The rel ecs context class
        /// </summary>
        /// <seealso cref="RelEcsBaseContext"/>
        private sealed class RelEcsContext : RelEcsBaseContext
        {
            /// <summary>
            /// The padding
            /// </summary>
            private sealed record Padding1();

            /// <summary>
            /// The padding
            /// </summary>
            private sealed record Padding2();

            /// <summary>
            /// The padding
            /// </summary>
            private sealed record Padding3();

            /// <summary>
            /// The padding
            /// </summary>
            private sealed record Padding4();

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
                    Query<Component1, Component2> query = world.Query<Component1, Component2>().Build();
                    foreach ((Component1 c1, Component2 c2) in query)
                    {
                        c1.Value += c2.Value;
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
            public RelEcsContext(int entityCount)
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    EntityBuilder entity = World.Spawn()
                        .Add(new Component1())
                        .Add(new Component2 { Value = 1 });

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
        }

        /// <summary>
        /// The rel ecs
        /// </summary>
        [Context] private readonly RelEcsContext _relEcs;

        /// <summary>
        /// Rels the ecs
        /// </summary>
        [BenchmarkCategory(Categories.RelEcs)]
        [Benchmark]
        public void RelEcs() => _relEcs.MonoThreadSystem.Run(_relEcs.World);
    }
}