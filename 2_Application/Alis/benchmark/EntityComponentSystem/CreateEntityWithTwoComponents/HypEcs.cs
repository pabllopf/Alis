using Alis.Benchmark.EntityComponentSystem.Contexts;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithTwoComponents
{
    /// <summary>
    /// The create entity with two components class
    /// </summary>
    public partial class CreateEntityWithTwoComponents
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
                    .Add(new HypEcsBaseContext.Component2());
            }
        }
    }
}