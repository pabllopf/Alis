using Alis.Benchmark.ECS.Others.Contexts;
using Alis.Benchmark.ECS.Others.Contexts.Arch_Components;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ECS.Others.CreateEntityWithOneComponent
{
    public partial class CreateEntityWithOneComponent
    {
        private static readonly ComponentType[] _archetype = [typeof(Component1)];

        [Context]
        private readonly ArchBaseContext _arch;

        [BenchmarkCategory(Categories.Arch)]
        [Benchmark]
        public void Arch()
        {
            World world = _arch.World;
            world.Reserve(_archetype, EntityCount);

            for (int i = 0; i < EntityCount; ++i)
            {
                world.Create(_archetype);
            }
        }
    }
}
