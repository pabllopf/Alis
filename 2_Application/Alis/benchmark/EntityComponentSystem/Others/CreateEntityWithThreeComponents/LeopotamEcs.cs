using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using Leopotam.Ecs;

namespace Alis.Benchmark.EntityComponentSystem.Others.CreateEntityWithThreeComponents
{
    /// <summary>
    /// The create entity with three components class
    /// </summary>
    public partial class CreateEntityWithThreeComponents
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
                    .Replace(new LeopotamEcsBaseContext.Component1())
                    .Replace(new LeopotamEcsBaseContext.Component2())
                    .Replace(new LeopotamEcsBaseContext.Component3());
            }
        }
    }
}
