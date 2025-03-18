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
    /// The uniform update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}"/>
    internal class UniformUpdate<TComp, TUniform>(int cap) : ComponentStorage<TComp>(cap)
        where TComp : IUniformComponent<TUniform>
    {
        /// <summary>
        /// Runs the world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="b">The </param>
        internal override void Run(World world, Archetype b)
        {
            ref TComp comp = ref GetComponentStorageDataReference();

            TUniform uniform = world.UniformProvider.GetUniform<TUniform>();

            for (int i = b.EntityCount - 1; i >= 0; i--)
            {
                comp.Update(uniform);

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
    public class UniformUpdateRunnerFactory<TComp, TUniform> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IUniformComponent<TUniform>
    {
        /// <summary>
        /// Creates the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>The component storage base</returns>
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new UniformUpdate<TComp, TUniform>(capacity);
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
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new UniformUpdate<TComp, TUniform>(capacity);
    }





    /// <summary>
    /// The uniform update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}"/>
    internal class UniformUpdate<TComp, TUniform, TArg>(int capacity) : ComponentStorage<TComp>(capacity)
        where TComp : IUniformComponent<TUniform, TArg>
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

            TUniform uniform = world.UniformProvider.GetUniform<TUniform>();

            for (int i = b.EntityCount - 1; i >= 0; i--)
            {
                comp.Update(uniform, ref arg);

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

    public class UniformUpdateRunnerFactory<TComp, TUniform, TArg> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IUniformComponent<TUniform, TArg>
    {
        /// <summary>
        /// Creates the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>The component storage base</returns>
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new UniformUpdate<TComp, TUniform, TArg>(capacity);
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
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new UniformUpdate<TComp, TUniform, TArg>(capacity);
    }
}