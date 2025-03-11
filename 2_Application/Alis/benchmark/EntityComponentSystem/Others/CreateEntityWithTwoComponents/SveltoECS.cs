using Alis.Benchmark.EntityComponentSystem.Others.Contexts;
using BenchmarkDotNet.Attributes;
using Svelto.ECS;

namespace Alis.Benchmark.EntityComponentSystem.Others.CreateEntityWithTwoComponents
{
    /// <summary>
    /// The create entity with two components class
    /// </summary>
    public partial class CreateEntityWithTwoComponents
    {
        /// <summary>
        /// The svelto entity class
        /// </summary>
        /// <seealso cref="GenericEntityDescriptor{SveltoECSBaseContext.Component1, SveltoECSBaseContext.Component2}"/>
        private sealed class SveltoEntity : GenericEntityDescriptor<SveltoECSBaseContext.Component1, SveltoECSBaseContext.Component2>
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
