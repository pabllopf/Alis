using Alis.Benchmark.EntityComponentSystem.Contexts;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithThreeComponents
{
    /// <summary>
    /// The create entity with three components class
    /// </summary>
    public partial class CreateEntityWithThreeComponents
    {
        /// <summary>
        /// The hyp ecs
        /// </summary>
        [Context] private readonly HypEcsBaseContext _hypEcs;

        /// <summary>
        /// Hyps the ecs
        /// </summary>
        [BenchmarkCategory(Categories.HypEcs)]
        [Benchmark]
        public void HypEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _hypEcs.World.Spawn()
                    .Add(new HypEcsBaseContext.Component1())
                    .Add(new HypEcsBaseContext.Component2())
                    .Add(new HypEcsBaseContext.Component3());
            }
        }
    }
}