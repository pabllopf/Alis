using Alis.Benchmark.EntityComponentSystem.Contexts.FrifloEngine_Components;
using BenchmarkDotNet.Attributes;
using Friflo.Engine.ECS;

namespace Alis.Benchmark.EntityComponentSystem.CreateEntityWithTwoComponents
{
    /// <summary>
    /// The create entity with two components class
    /// </summary>
    public partial class CreateEntityWithTwoComponents
    {
        /// <summary>
        /// Frifloes the engine ecs
        /// </summary>
        [BenchmarkCategory(Categories.FrifloEngineEcs)]
        [Benchmark]
        public void FrifloEngineEcs()
        {
            EntityStore store = new EntityStore(PidType.UsePidAsId);
            store.EnsureCapacity(EntityCount);

            Archetype archetype = store.GetArchetype(ComponentTypes.Get<Component1, Component2>());
            archetype.EnsureCapacity(EntityCount);

            for (int i = 0; i < EntityCount; ++i)
            {
                archetype.CreateEntity();
            }
        }
    }
}