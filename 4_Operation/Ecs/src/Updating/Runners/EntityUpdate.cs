﻿using System;
using Frent.Collections;
using Frent.Components;
using Frent.Core;

using System.Runtime.CompilerServices;
using System.Threading;
using static Frent.AttributeHelpers;

namespace Frent.Updating.Runners;

internal class EntityUpdate<TComp>(int capacity) : ComponentStorage<TComp>(capacity)
    where TComp : IEntityComponent
{
    internal override void Run(World world, Archetype b)
    {
        ref EntityIDOnly entityIds = ref b.GetEntityDataReference();
        ref TComp comp = ref GetComponentStorageDataReference();

        Entity entity = world.DefaultWorldEntity;

        for (int i = b.EntityCount - 1; i >= 0; i--)
        {
            entityIds.SetEntity(ref entity);
            comp.Update(entity);

            entityIds = ref Unsafe.Add(ref entityIds, 1);
            comp = ref Unsafe.Add(ref comp, 1);
        }
    }

    internal override void MultithreadedRun(CountdownEvent countdown, World world, Archetype b) =>
        throw new NotImplementedException();
}

/// <inheritdoc cref="IComponentStorageBaseFactory"/>
public class EntityUpdateRunnerFactory<TComp> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
    where TComp : IEntityComponent
{
    ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new EntityUpdate<TComp>(capacity);
    IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<TComp>();
    ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new EntityUpdate<TComp>(capacity);
}





internal class EntityUpdate<TComp, TArg>(int capacity) : ComponentStorage<TComp>(capacity)
    where TComp : IEntityComponent<TArg>
{
    internal override void Run(World world, Archetype b)
    {
        ref EntityIDOnly entityIds = ref b.GetEntityDataReference();
        ref TComp comp = ref GetComponentStorageDataReference();

        ref TArg arg = ref b.GetComponentDataReference<TArg>();

        Entity entity = world.DefaultWorldEntity;

        for (int i = b.EntityCount - 1; i >= 0; i--)
        {
            entityIds.SetEntity(ref entity);
            comp.Update(entity, ref arg);

            entityIds = ref Unsafe.Add(ref entityIds, 1);
            comp = ref Unsafe.Add(ref comp, 1);

            arg = ref Unsafe.Add(ref arg, 1);
        }
    }

    internal override void MultithreadedRun(CountdownEvent countdown, World world, Archetype b)
        => throw new NotImplementedException();
}

/// <inheritdoc cref="IComponentStorageBaseFactory"/>

public class EntityUpdateRunnerFactory<TComp, TArg> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
    where TComp : IEntityComponent<TArg>
{
    ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new EntityUpdate<TComp, TArg>(capacity);
    IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<TComp>();
    ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new EntityUpdate<TComp, TArg>(capacity);
}