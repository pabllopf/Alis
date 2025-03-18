using System;
using Frent.Collections;
using Frent.Components;
using Frent.Core;

using System.Runtime.CompilerServices;
using System.Threading;
using static Frent.AttributeHelpers;

namespace Frent.Updating.Runners
{
    /// <summary>
    /// The entity update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}"/>
    internal class EntityUpdate<TComp>(int capacity) : ComponentStorage<TComp>(capacity)
        where TComp : IEntityComponent
    {
        /// <summary>
        /// Runs the world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="b">The </param>
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

        /// <summary>
        /// Multithreadeds the run using the specified countdown
        /// </summary>
        /// <param name="countdown">The countdown</param>
        /// <param name="world">The world</param>
        /// <param name="b">The </param>
        internal override void MultithreadedRun(CountdownEvent countdown, World world, Archetype b) =>
            throw new NotImplementedException();
    }

    /// <inheritdoc cref="IComponentStorageBaseFactory"/>
    public class EntityUpdateRunnerFactory<TComp> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IEntityComponent
    {
        /// <summary>
        /// Creates the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>The component storage base</returns>
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new EntityUpdate<TComp>(capacity);
        /// <summary>
        /// Creates the stack
        /// </summary>
        /// <returns>The id table</returns>
        IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<TComp>();
        /// <summary>
        /// Creates the strongly typed using the specified capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>A component storage of t comp</returns>
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new EntityUpdate<TComp>(capacity);
    }





    /// <summary>
    /// The entity update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}"/>
    internal class EntityUpdate<TComp, TArg>(int capacity) : ComponentStorage<TComp>(capacity)
        where TComp : IEntityComponent<TArg>
    {
        /// <summary>
        /// Runs the world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="b">The </param>
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

        /// <summary>
        /// Multithreadeds the run using the specified countdown
        /// </summary>
        /// <param name="countdown">The countdown</param>
        /// <param name="world">The world</param>
        /// <param name="b">The </param>
        internal override void MultithreadedRun(CountdownEvent countdown, World world, Archetype b)
            => throw new NotImplementedException();
    }

    /// <inheritdoc cref="IComponentStorageBaseFactory"/>

    public class EntityUpdateRunnerFactory<TComp, TArg> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IEntityComponent<TArg>
    {
        /// <summary>
        /// Creates the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>The component storage base</returns>
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new EntityUpdate<TComp, TArg>(capacity);
        /// <summary>
        /// Creates the stack
        /// </summary>
        /// <returns>The id table</returns>
        IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<TComp>();
        /// <summary>
        /// Creates the strongly typed using the specified capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>A component storage of t comp</returns>
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new EntityUpdate<TComp, TArg>(capacity);
    }
}