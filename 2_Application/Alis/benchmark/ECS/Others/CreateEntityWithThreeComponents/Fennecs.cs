using Alis.Benchmark.ECS.Others.Contexts;
using Alis.Benchmark.ECS.Others.Contexts.Fennecs_Components;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ECS.Others.CreateEntityWithThreeComponents
{
    public partial class CreateEntityWithThreeComponents
    {
        [Context]
        private readonly FennecsBaseContext _fennecs;

        [BenchmarkCategory(Categories.Fennecs)]
        [Benchmark]
        public void Fennecs()
        {
            World world = _fennecs.World;

            for (int i = 0; i < EntityCount; ++i)
            {
                world.Spawn()
                    .Add<Component1>()
                    .Add<Component2>()
                    .Add<Component3>();
            }
        }
    }
}
