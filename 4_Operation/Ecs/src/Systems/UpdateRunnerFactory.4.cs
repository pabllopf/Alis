using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Systems;
    public class UpdateRunnerFactory<TComp, TArg1, TArg2, TArg3, TArg4> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IComponent<TArg1, TArg2, TArg3, TArg4>
    {
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new Update<TComp, TArg1, TArg2, TArg3, TArg4>(capacity);
        IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<TComp>();
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new Update<TComp, TArg1, TArg2, TArg3, TArg4>(capacity);
    }
