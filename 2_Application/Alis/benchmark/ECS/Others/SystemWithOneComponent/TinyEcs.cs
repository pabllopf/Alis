using Alis.Benchmark.ECS.Others.Contexts;
using Alis.Benchmark.ECS.Others.Contexts.TinyEcs_Components;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ECS.Others.SystemWithOneComponent
{
    public partial class SystemWithOneComponent
    {
        [Context] private readonly TinyEcsContext _tinyEcs;

        private sealed class TinyEcsContext : TinyEcsBaseContext
        {
            public Query<Component1> Query { get; }
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

        [BenchmarkCategory(Categories.TinyEcs)]
        [Benchmark]
        public void TinyEcs_Each()
        {
            _tinyEcs.Query.Each((ref Component1 c1) => c1.Value++);
        }

        [BenchmarkCategory(Categories.TinyEcs)]
        [Benchmark]
        public void TinyEcs_EachJob()
        {
            _tinyEcs.Query.EachJob((ref Component1 c1) => c1.Value++);
        }
    }
}
