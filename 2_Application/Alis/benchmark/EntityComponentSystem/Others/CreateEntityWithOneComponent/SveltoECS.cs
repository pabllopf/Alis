using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using Svelto.ECS;

namespace Alis.Benchmark.EntityComponentSystem.Others.CreateEntityWithOneComponent
{
    /// <summary>
    /// The create entity with one component class
    /// </summary>
    public partial class CreateEntityWithOneComponent
    {
        /// <summary>
        /// The svelto entity class
        /// </summary>
        /// <seealso cref="GenericEntityDescriptor{SveltoECSBaseContext.Component1}"/>
        private sealed class SveltoEntity : GenericEntityDescriptor<SveltoECSBaseContext.Component1>
        { }

        /// <summary>
        /// The svelto ecs
        /// </summary>
        [Context]
        private readonly SveltoECSBaseContext _sveltoECS;

        /// <summary>
        /// Sveltoes the ecs
        /// </summary>
        [BenchmarkCategory(Categories.SveltoECS)]
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
