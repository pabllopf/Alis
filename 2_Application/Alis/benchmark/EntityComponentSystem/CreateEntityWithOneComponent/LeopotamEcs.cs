using Alis.Benchmark.EntityComponentSystem.Contexts;
using BenchmarkDotNet.Attributes;
using Leopotam.Ecs;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithOneComponent
{
    /// <summary>
    /// The create entity with one component class
    /// </summary>
    public partial class CreateEntityWithOneComponent
    {
        /// <summary>
        /// The leopotam ecs
        /// </summary>
        [Context]
        private readonly LeopotamEcsBaseContext _leopotamEcs;

        /// <summary>
        /// Leopotams the ecs
        /// </summary>
        [BenchmarkCategory(Categories.LeopotamEcs)]
        [Benchmark]
        public void LeopotamEcs()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _leopotamEcs.World.NewEntity()
                    .Replace(new LeopotamEcsBaseContext.Component1());
            }
        }
    }
}
