using Alis.Benchmark.ECS.Others.Contexts;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ECS.Others.CreateEntityWithOneComponent
{
    public partial class CreateEntityWithOneComponent
    {
        [Context] private readonly HypEcsBaseContext _hypEcs;

        [BenchmarkCategory(Categories.RelEcs)]
        [Benchmark]
        public void HypEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _hypEcs.World.Spawn().Add(new HypEcsBaseContext.Component1());
            }
        }
    }
}