using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Updating.Runners;

/// <inheritdoc cref="IComponentStorageBaseFactory"/>
public class NoneUpdateRunnerFactory<T> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<T>
{
    ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new NoneUpdate<T>(capacity);
    IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<T>();
    ComponentStorage<T> IComponentStorageBaseFactory<T>.CreateStronglyTyped(int capacity) => new NoneUpdate<T>(capacity);
}