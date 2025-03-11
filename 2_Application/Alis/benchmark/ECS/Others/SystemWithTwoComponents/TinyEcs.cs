using Alis.Benchmark.ECS.Others.Contexts;
using Alis.Benchmark.ECS.Others.Contexts.TinyEcs_Components;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ECS.Others.SystemWithTwoComponents
{
    public partial class SystemWithTwoComponents
    {
        [Context] private readonly TinyEcsContext _tinyEcs;

        private sealed class TinyEcsContext : TinyEcsBaseContext
        {
            public Query Query { get; }

            public TinyEcsContext(int entityCount, int entityPadding) : base()
            {
                for (int i = 0; i < entityCount; ++i)
                {
                    for (int j = 0; j < entityPadding; ++j)
                    {
                        var padding = World.Entity();
                        switch (j % 2)
                        {
                            case 0:
                                padding.Set(new Component1());
                                break;

                            case 1:
                                padding.Set(new Component2());
                                break;
                        }
                    }

                    World.Entity()
                        .Set(new Component1())
                        .Set(new Component2 { Value = 1 });
                    Query = World.QueryBuilder().With<Component1>().With<Component2>().Build();
                }
            }
        }

        [BenchmarkCategory(Categories.TinyEcs)]
        [Benchmark]
        public void TinyEcs_Each()
        {
            _tinyEcs.Query.Each((ref Component1 c1, ref Component2 c2) => c1.Value += c2.Value);
        }

        [BenchmarkCategory(Categories.TinyEcs)]
        [Benchmark]
        public void TinyEcs_EachJob()
        {
            _tinyEcs.Query.EachJob((ref Component1 c1, ref Component2 c2) => c1.Value += c2.Value);
        }
    }
}
