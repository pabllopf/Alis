using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using DefaultEcs;

namespace Alis.Benchmark.EntityComponentSystem.Others.CreateEntityWithThreeComponents
{
    /// <summary>
    /// The create entity with three components class
    /// </summary>
    public partial class CreateEntityWithThreeComponents
    {
        /// <summary>
        /// The default ecs
        /// </summary>
        [Context]
        private readonly DefaultEcsBaseContext _defaultEcs;

        /// <summary>
        /// Defaults the ecs
        /// </summary>
        [BenchmarkCategory(Categories.DefaultEcs)]
        [Benchmark]
        public void DefaultEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                Entity entity = _defaultEcs.World.CreateEntity();
                entity.Set<DefaultEcsBaseContext.Component1>();
                entity.Set<DefaultEcsBaseContext.Component2>();
                entity.Set<DefaultEcsBaseContext.Component3>();
            }
        }
    }
}
