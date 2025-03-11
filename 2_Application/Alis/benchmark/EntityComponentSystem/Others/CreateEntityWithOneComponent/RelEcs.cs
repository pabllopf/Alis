using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.EntityComponentSystem.Others.CreateEntityWithOneComponent
{
    /// <summary>
    /// The create entity with one component class
    /// </summary>
    public partial class CreateEntityWithOneComponent
    {
        /// <summary>
        /// The rel ecs
        /// </summary>
        [Context]
        private readonly RelEcsBaseContext _relEcs;

        /// <summary>
        /// Rels the ecs
        /// </summary>
        [BenchmarkCategory(Categories.RelEcs)]
        [Benchmark]
        public void RelEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _relEcs.World.Spawn().Add(new RelEcsBaseContext.Component1());
            }
        }
    }
}
