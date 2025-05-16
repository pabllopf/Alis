using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Components;

namespace Alis.Core.Ecs.Updating.Runners;

/// <inheritdoc cref="IComponentStorageBaseFactory"/>
public class UpdateRunnerFactory<TComp> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
    where TComp : IComponent
{
    ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new Update<TComp>(capacity);
    IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<TComp>();
    ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new Update<TComp>(capacity);
}