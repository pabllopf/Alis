using Alis.Benchmark.ECS.Others.Contexts;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ECS.Others.CreateEntityWithOneComponent
{
    public partial class CreateEntityWithOneComponent
    {
        [Context]
        private readonly DefaultEcsBaseContext _defaultEcs;

        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark]
        public void DefaultEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = _defaultEcs.World.CreateEntity();
                entity.Set<DefaultEcsBaseContext.Component1>();
            }
        }
    }
}
