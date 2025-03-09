using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using HypEcs;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    /// The system with two components multiple composition class
    /// </summary>
    public partial class SystemWithTwoComponentsMultipleComposition
    {
        /// <summary>
        /// The hyp ecs context class
        /// </summary>
        /// <seealso cref="HypEcsBaseContext"/>
        private sealed class HypEcsContext : HypEcsBaseContext
        {
            /// <summary>
            /// The padding
            /// </summary>
            private struct Padding1
            {
            }

            /// <summary>
            /// The padding
            /// </summary>
            private struct Padding2
            {
            }

            /// <summary>
            /// The padding
            /// </summary>
            private struct Padding3
            {
            }

            /// <summary>
            /// The padding
            /// </summary>
            private struct Padding4
            {
            }

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
            /// The multi thread run system class
            /// </summary>
            /// <seealso cref="ISystem"/>
            private sealed class MultiThreadRunSystem : ISystem
            {
                /// <summary>
                /// Runs the world
                /// </summary>
                /// <param name="world">The world</param>
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

            /// <summary>
            /// Gets the value of the mono thread system
            /// </summary>
            public ISystem MonoThreadSystem { get; } = new MonoThreadRunSystem();
            /// <summary>
            /// Gets the value of the multi thread system
            /// </summary>
            public ISystem MultiThreadSystem { get; } = new MultiThreadRunSystem();

            /// <summary>
            /// Initializes a new instance of the <see cref="HypEcsContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            public HypEcsContext(int entityCount)
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
        /// The hyp ecs
        /// </summary>
        [Context] private readonly HypEcsContext _hypEcs;

        /// <summary>
        /// Hyps the ecs mono thread
        /// </summary>
        [BenchmarkCategory(Categories.HypEcs)]
        [Benchmark]
        public void HypEcs_MonoThread() => _hypEcs.MonoThreadSystem.Run(_hypEcs.World);

        /// <summary>
        /// Hyps the ecs multi thread
        /// </summary>
        [BenchmarkCategory(Categories.HypEcs)]
        [Benchmark]
        public void HypEcs_MultiThread() => _hypEcs.MultiThreadSystem.Run(_hypEcs.World);
    }
}