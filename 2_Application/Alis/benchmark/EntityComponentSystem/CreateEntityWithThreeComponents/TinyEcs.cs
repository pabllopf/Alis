using Alis.Benchmark.EntityComponentSystem.Contexts;
using Alis.Benchmark.EntityComponentSystem.Contexts.TinyEcs_Components;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithThreeComponents
{
    /// <summary>
    /// The create entity with three components class
    /// </summary>
    public partial class CreateEntityWithThreeComponents
    {
        /// <summary>
        /// The tiny ecs
        /// </summary>
        [Context]
        private readonly TinyEcsBaseContext _tinyEcs;

        /// <summary>
        /// Tinies the ecs
        /// </summary>
        [BenchmarkCategory(Categories.TinyEcs)]
        [Benchmark]
        public void TinyEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _tinyEcs.World.Entity()
                    .Set<Component1>()
                    .Set<Component2>()
                    .Set<Component3>();
            }
        }
    }
}
