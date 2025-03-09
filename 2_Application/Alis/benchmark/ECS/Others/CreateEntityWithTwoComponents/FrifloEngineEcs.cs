using Alis.Benchmark.ECS.Others.Contexts.FrifloEngine_Components;
using BenchmarkDotNet.Attributes;

namespace Alis.Benchmark.ECS.Others.CreateEntityWithTwoComponents
{
    public partial class CreateEntityWithTwoComponents
    {
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