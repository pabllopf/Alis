using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Systems;
    public class UniformUpdateRunnerFactory<TComp, TUniform, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IUniformComponent<TUniform, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
    {
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new UniformUpdate<TComp, TUniform, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(capacity);
        IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<TComp>();
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new UniformUpdate<TComp, TUniform, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(capacity);
    }
