using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs;
    public class EntityUniformUpdateRunnerFactory<TComp, TUniform, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IEntityUniformComponent<TUniform, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>
    {
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new EntityUniformUpdate<TComp, TUniform, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(capacity);
        IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<TComp>();
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new EntityUniformUpdate<TComp, TUniform, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8, TArg9, TArg10, TArg11, TArg12, TArg13, TArg14, TArg15>(capacity);
    }
