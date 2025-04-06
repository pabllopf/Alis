using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Operations;

namespace Alis.Core.Ecs.Updating.Runners
{
    public class EntityUpdateRunnerFactory<TComp, TArg1, TArg2, TArg3, TArg4, TArg5> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IEntityComponent<TArg1, TArg2, TArg3, TArg4, TArg5>
    {
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new EntityUpdate<TComp, TArg1, TArg2, TArg3, TArg4, TArg5>(capacity);
        IdTable IComponentStorageBaseFactory.CreateStack() => new IdTable<TComp>();
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new EntityUpdate<TComp, TArg1, TArg2, TArg3, TArg4, TArg5>(capacity);
    }
}