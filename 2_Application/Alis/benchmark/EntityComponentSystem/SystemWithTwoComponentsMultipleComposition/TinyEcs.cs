using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.TinyEcs_Components;
using BenchmarkDotNet.Attributes;
using TinyEcs;

namespace Alis.Benchmark.EntityComponentSystem.SystemWithTwoComponentsMultipleComposition
{
    /// <summary>
    /// The system with two components multiple composition class
    /// </summary>
    public partial class SystemWithTwoComponentsMultipleComposition
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
            
            private record struct Padding1();
            private record struct Padding2();
            private record struct Padding3();
            private record struct Padding4();
            /// <summary>
            /// Gets the value of the query
            /// </summary>
            public Query Query { get; }

            
            /// <summary>
            /// Initializes a new instance of the <see cref="TinyEcsContext"/> class
            /// </summary>
            /// <param name="entityCount">The entity count</param>
            public TinyEcsContext(int entityCount) : base()
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    var entity = World.Entity();
                    entity.Set<Component1>();
                    entity.Set(new Component2 { Value = 1 });

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

                Query = World.QueryBuilder().With<Component1>().With<Component2>().Build();
            }
        }

        /// <summary>
        /// Tinies the ecs each
        /// </summary>
        [BenchmarkCategory(Categories.TinyEcs)]
        [Benchmark]
        public void TinyEcs_Each()
        {
            _tinyEcs.Query.Each((ref Component1 c1, ref Component2 c2) => c1.Value += c2.Value);
        }

        /// <summary>
        /// Tinies the ecs each job
        /// </summary>
        [BenchmarkCategory(Categories.TinyEcs)]
        [Benchmark]
        public void TinyEcs_EachJob()
        {
            _tinyEcs.Query.EachJob((ref Component1 c1, ref Component2 c2) => c1.Value += c2.Value);
        }
    }
}
