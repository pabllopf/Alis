using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using Leopotam.EcsLite;

namespace Alis.Benchmark.EntityComponentSystem.Others.CreateEntityWithThreeComponents
{
    /// <summary>
    /// The create entity with three components class
    /// </summary>
    public partial class CreateEntityWithThreeComponents
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
            EcsPool<LeopotamEcsLiteBaseContext.Component2> c2 = _leopotamEcsLite.World.GetPool<LeopotamEcsLiteBaseContext.Component2>();
            EcsPool<LeopotamEcsLiteBaseContext.Component3> c3 = _leopotamEcsLite.World.GetPool<LeopotamEcsLiteBaseContext.Component3>();

            for (int i = 0; i < EntityCount; ++i)
            {
                int entity = _leopotamEcsLite.World.NewEntity();
                c1.Add(entity);
                c2.Add(entity);
                c3.Add(entity);
            }
        }
    }
}
