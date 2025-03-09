using Alis.Benchmark.ECS.Others.Contexts;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ECS.Others.CreateEntityWithTwoComponents
{
    public partial class CreateEntityWithTwoComponents
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
                entity.Set<DefaultEcsBaseContext.Component2>();
            }
        }
    }
}
