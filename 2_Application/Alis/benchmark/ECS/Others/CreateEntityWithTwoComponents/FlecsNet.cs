using Alis.Benchmark.ECS.Others.Contexts;
using Alis.Benchmark.ECS.Others.Contexts.Arch_Components;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ECS.Others.CreateEntityWithTwoComponents
{
    public partial class CreateEntityWithTwoComponents
    {
        [Context]
        private readonly FlecsNetBaseContext _flecs;

        [BenchmarkCategory(Categories.FlecsNet)]
        [Benchmark]
        public void FlecsNet()
        {
            World world = _flecs.World;

            for (int i = 0; i < EntityCount; ++i)
            {
                world.Entity()
                    .Set<Component1>(new())
                    .Set<Component2>(new());
            }
        }
    }
}
