using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Components;

namespace Alis.Core.Ecs.Updating.Runners;

/// <inheritdoc cref="IComponentStorageBaseFactory"/>
public class UniformUpdateRunnerFactory<TComp, TUniform> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
    where TComp : IUniformComponent<TUniform>
{
    ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new UniformUpdate<TComp, TUniform>(capacity);
    IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<TComp>();
    ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new UniformUpdate<TComp, TUniform>(capacity);
}