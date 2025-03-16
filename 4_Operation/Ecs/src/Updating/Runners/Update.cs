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
    /// The update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}"/>
    internal class Update<TComp>(int cap) : ComponentStorage<TComp>(cap)
        where TComp : IComponent
    {
        /// <summary>
        /// Runs the world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="b">The </param>
        internal override void Run(World world, Archetype b)
        {
            ref TComp comp = ref GetComponentStorageDataReference();

            for (int i = b.EntityCount - 1; i >= 0; i--)
            {
                comp.Update();

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
    public class UpdateRunnerFactory<TComp> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IComponent
    {
        /// <summary>
        /// Creates the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>The component storage base</returns>
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new Update<TComp>(capacity);
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
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new Update<TComp>(capacity);
    }





    /// <summary>
    /// The update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}"/>
    internal class Update<TComp, TArg>(int cap) : ComponentStorage<TComp>(cap)
        where TComp : IComponent<TArg>
    {
        /// <summary>
        /// Runs the world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="b">The </param>
        internal override void Run(World world, Archetype b)
        {
            ref TComp comp = ref GetComponentStorageDataReference();

            ref TArg arg = ref b.GetComponentDataReference<TArg>();

            for (int i = b.EntityCount - 1; i >= 0; i--)
            {
                comp.Update(ref arg);

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
        internal override void MultithreadedRun(CountdownEvent countdown, World world, Archetype b) =>
            throw new NotImplementedException();
    }

    /// <inheritdoc cref="IComponentStorageBaseFactory"/>

    public class UpdateRunnerFactory<TComp, TArg> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IComponent<TArg>
    {
        /// <summary>
        /// Creates the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>The component storage base</returns>
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new Update<TComp, TArg>(capacity);
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
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new Update<TComp, TArg>(capacity);
    }
}