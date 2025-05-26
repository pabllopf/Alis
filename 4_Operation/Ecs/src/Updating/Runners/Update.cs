using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Updating.Runners
{
    /// <summary>
    ///     The update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    public class Update<TComp>(int cap) : ComponentStorage<TComp>(cap)
        where TComp : IComponent
    {
        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        internal override void Run(Scene scene, Archetype b)
        {
            ref TComp comp = ref GetComponentStorageDataReference();

            for (int i = b.EntityCount - 1; i >= 0; i--)
            {
                comp.Update();

                comp = ref Unsafe.Add(ref comp, 1);
            }
        }

        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        internal override void Run(Scene scene, Archetype b, int start, int length)
        {
            ref TComp comp = ref Unsafe.Add(ref GetComponentStorageDataReference(), start);

            for (int i = length - 1; i >= 0; i--)
            {
                comp.Update();

                comp = ref Unsafe.Add(ref comp, 1);
            }
        }

        
    }

    /// <summary>
    ///     The update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    public class Update<TComp, TArg>(int cap) : ComponentStorage<TComp>(cap)
        where TComp : IComponent<TArg>
    {
        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        internal override void Run(Scene scene, Archetype b)
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
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        internal override void Run(Scene scene, Archetype b, int start, int length)
        {
            ref TComp comp = ref Unsafe.Add(ref GetComponentStorageDataReference(), start);

            ref TArg arg = ref Unsafe.Add(ref b.GetComponentDataReference<TArg>(), start);

            for (int i = length - 1; i >= 0; i--)
            {
                comp.Update(ref arg);

                comp = ref Unsafe.Add(ref comp, 1);
                arg = ref Unsafe.Add(ref arg, 1);
            }
        }

        
    }

    /// <inheritdoc cref="IComponentStorageBaseFactory" />
    public class UpdateRunnerFactory<TComp, TArg> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IComponent<TArg>
    {
        /// <summary>
        ///     Creates the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>The component storage base</returns>
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity)
        {
            return new Update<TComp, TArg>(capacity);
        }

        /// <summary>
        ///     Creates the stack
        /// </summary>
        /// <returns>The id table</returns>
        IdTable IComponentStorageBaseFactory.CreateStack()
        {
            return new IdTable<TComp>();
        }

        /// <summary>
        ///     Creates the strongly typed using the specified capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>A component storage of t comp</returns>
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity)
        {
            return new Update<TComp, TArg>(capacity);
        }
    }
}