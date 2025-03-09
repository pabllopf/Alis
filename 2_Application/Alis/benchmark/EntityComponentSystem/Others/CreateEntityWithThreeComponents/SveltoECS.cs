using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using Svelto.ECS;

namespace Alis.Benchmark.EntityComponentSystem.Others.CreateEntityWithThreeComponents
{
    /// <summary>
    /// The create entity with three components class
    /// </summary>
    public partial class CreateEntityWithThreeComponents
    {
        /// <summary>
        /// The svelto entity class
        /// </summary>
        /// <seealso cref="GenericEntityDescriptor{SveltoECSBaseContext.Component1, SveltoECSBaseContext.Component2, SveltoECSBaseContext.Component3}"/>
        private sealed class SveltoEntity : GenericEntityDescriptor<SveltoECSBaseContext.Component1, SveltoECSBaseContext.Component2, SveltoECSBaseContext.Component3>
        { }

        /// <summary>
        /// The svelto ecs
        /// </summary>
        [Context]
        private readonly SveltoECSBaseContext _sveltoECS;

        /// <summary>
        /// Sveltoes the ecs
        /// </summary>
        [Benchmark]
        public void SveltoECS()
        {
            for (int i = 0; i < EntityCount; ++i)
            {
                _sveltoECS.Factory.BuildEntity<SveltoEntity>((uint)i, SveltoECSBaseContext.Group);
            }

            _sveltoECS.Scheduler.SubmitEntities();
        }
    }
}
