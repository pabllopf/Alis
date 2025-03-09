using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using HypEcs;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithOneComponent
{
    /// <summary>
    /// The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
    {
        /// <summary>
        /// The hyp ecs context class
        /// </summary>
        /// <seealso cref="HypEcsBaseContext"/>
        private sealed class HypEcsContext : HypEcsBaseContext
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
            /// <param name="entityPadding">The entity padding</param>
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