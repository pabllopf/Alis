using Alis.Benchmark.EntityComponentSystem.Contexts;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithOneComponent
{
    /// <summary>
    /// The create entity with one component class
    /// </summary>
    public partial class CreateEntityWithOneComponent
    {
        /// <summary>
        /// The hyp ecs
        /// </summary>
        [Context] private readonly HypEcsBaseContext _hypEcs;

        /// <summary>
        /// Hyps the ecs
        /// </summary>
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