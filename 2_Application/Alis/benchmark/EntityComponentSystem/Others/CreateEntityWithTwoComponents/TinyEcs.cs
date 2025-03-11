using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using Alis.Benchmark.EntityComponentSystem.Others.Contexts.TinyEcs_Components;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.EntityComponentSystem.Others.CreateEntityWithTwoComponents
{
    /// <summary>
    /// The create entity with two components class
    /// </summary>
    public partial class CreateEntityWithTwoComponents
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
                    .Set<Component2>();
            }
        }
    }
}
