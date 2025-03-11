using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using Alis.Benchmark.EntityComponentSystem.Others.Contexts.TinyEcs_Components;
using BenchmarkDotNet.Attributes;
using TinyEcs;

namespace Alis.Benchmark.EntityComponentSystem.Others.SystemWithOneComponent
{
    /// <summary>
    /// The system with one component class
    /// </summary>
    public partial class SystemWithOneComponent
    {
        /// <summary>
        /// The tiny ecs
        /// </summary>
        [Context] private readonly TinyEcsContext _tinyEcs;

        /// <summary>
        /// The tiny ecs context class
        /// </summary>
        /// <seealso cref="TinyEcsBaseContext"/>
        private sealed class TinyEcsContext : TinyEcsBaseContext
        {
            /// <summary>
            /// Gets the value of the query
            /// </summary>
            public Query<Component1> Query { get; }
            /// <summary>
            /// Initializes a new instance of the <see cref="TinyEcsContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            /// <param name="entityPadding">The entity padding</param>
            public TinyEcsContext(int entityCount, int entityPadding) : base()
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        World.Entity();
                    }

                    World.Entity().Set<Component1>();
                }

                Query = World.Query<Component1>();
            }
        }

        /// <summary>
        /// Tinies the ecs each
        /// </summary>
        [BenchmarkCategory(Categories.TinyEcs)]
        [Benchmark]
        public void TinyEcs_Each()
        {
            _tinyEcs.Query.Each((ref Component1 c1) => c1.Value++);
        }

        /// <summary>
        /// Tinies the ecs each job
        /// </summary>
        [BenchmarkCategory(Categories.TinyEcs)]
        [Benchmark]
        public void TinyEcs_EachJob()
        {
            _tinyEcs.Query.EachJob((ref Component1 c1) => c1.Value++);
        }
    }
}
