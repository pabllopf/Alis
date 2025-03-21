﻿using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Updating.Runners
{
    internal class EntityUniformUpdate<TComp, TUniform>(int len) : ComponentStorage<TComp>(len)
        where TComp : IEntityUniformComponent<TUniform>
    {
        internal override void Run(World world, Archetype b)
        {
            ref EntityIDOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();

            Entity entity = world.DefaultWorldEntity;
            TUniform uniform = world.UniformProvider.GetUniform<TUniform>();

            for (int i = b.EntityCount - 1; i >= 0; i--)
            {
                entityIds.SetEntity(ref entity);
                comp.Update(entity, uniform);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);
            }
        }

        internal override void MultithreadedRun(CountdownEvent countdown, World world, Archetype b) =>
            throw new NotImplementedException();
    }

    /// <inheritdoc cref="IComponentStorageBaseFactory"/>
    public class EntityUniformUpdateRunnerFactory<TComp, TUniform> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IEntityUniformComponent<TUniform>
    {
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new EntityUniformUpdate<TComp, TUniform>(capacity);
        IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<TComp>();
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new EntityUniformUpdate<TComp, TUniform>(capacity);
    }

    /// <inheritdoc cref="IComponentStorageBaseFactory"/>




    internal class EntityUniformUpdate<TComp, TUniform, TArg>(int capacity) : ComponentStorage<TComp>(capacity)
        where TComp : IEntityUniformComponent<TUniform, TArg>
    {
        //maybe field acsesses can be optimzed???
        internal override void Run(World world, Archetype b)
        {
            ref EntityIDOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();

            ref TArg arg = ref b.GetComponentDataReference<TArg>();

            Entity entity = world.DefaultWorldEntity;
            TUniform uniform = world.UniformProvider.GetUniform<TUniform>();

            for (int i = b.EntityCount - 1; i >= 0; i--)
            {
                entityIds.SetEntity(ref entity);
                comp.Update(entity, uniform, ref arg);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);

                arg = ref Unsafe.Add(ref arg, 1);
            }
        }

        internal override void MultithreadedRun(CountdownEvent countdown, World world, Archetype b)
            => throw new NotImplementedException();
    }

/*
         ref EntityIDOnly entityIds = ref b.GetEntityDataReference();
        ref TComp comp = ref GetComponentStorageDataReference();
        ref TArg arg = ref b.GetComponentDataReference<TArg>();

        Entity entity = world.DefaultWorldEntity;
        TUniform uniform = world.UniformProvider.GetUniform<TUniform>();

        for (int i = b.EntityCount - 1; i >= 0; i--)
        {
            entityIds.SetEntity(ref entity);
            comp.Update(entity, uniform, ref arg);

            entityIds = ref Unsafe.Add(ref entityIds, 1);
            comp = ref Unsafe.Add(ref comp, 1);
            arg = ref Unsafe.Add(ref arg, 1);
        }
 */

    /// <inheritdoc cref="IComponentStorageBaseFactory"/>

    public class EntityUniformUpdateRunnerFactory<TComp, TUniform, TArg> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IEntityUniformComponent<TUniform, TArg>
    {
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new EntityUniformUpdate<TComp, TUniform, TArg>(capacity);
        IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<TComp>();
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new EntityUniformUpdate<TComp, TUniform, TArg>(capacity);
    }
}