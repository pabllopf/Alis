using Alis.Benchmark.EntityComponentSystem.Contexts;
using BenchmarkDotNet.Attributes;
using Leopotam.EcsLite;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithOneComponent
{
    /// <summary>
    /// The create entity with one component class
    /// </summary>
    public partial class CreateEntityWithOneComponent
    {
        /// <summary>
        /// The leopotam ecs lite
        /// </summary>
        [Context]
        private readonly LeopotamEcsLiteBaseContext _leopotamEcsLite;

        /// <summary>
        /// Leopotams the ecs lite
        /// </summary>
        [BenchmarkCategory(Categories.LeopotamEcsLite)]
        [Benchmark]
        public void LeopotamEcsLite()
        {
            EcsPool<LeopotamEcsLiteBaseContext.Component1> c1 = _leopotamEcsLite.World.GetPool<LeopotamEcsLiteBaseContext.Component1>();

            for (int i = 0; i < EntityCount; ++i)
            {
                c1.Add(_leopotamEcsLite.World.NewEntity());
            }
        }
    }
}
