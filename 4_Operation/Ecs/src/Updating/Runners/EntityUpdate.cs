// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityUpdate.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Updating.Runners
{
    /// <summary>
    ///     The entity update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    internal class EntityUpdate<TComp>(int capacity) : ComponentStorage<TComp>(capacity)
        where TComp : IEntityComponent
    {
        /// <summary>
        ///     Runs the world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="b">The </param>
        internal override void Run(World world, Archetype b)
        {
            ref EntityIDOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();

            Entity entity = world.DefaultWorldEntity;

            int size = b.EntityCount;
            for (int i = size - 1; i >= 0; i--)
            {
                entityIds.SetEntity(ref entity);
                comp.Update(entity);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);
            }
        }

        /// <summary>
        ///     Multithreadeds the run using the specified countdown
        /// </summary>
        /// <param name="countdown">The countdown</param>
        /// <param name="world">The world</param>
        /// <param name="b">The </param>
        internal override void MultithreadedRun(CountdownEvent countdown, World world, Archetype b) =>
            throw new NotImplementedException();
    }


    /// <summary>
    ///     The entity update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    internal class EntityUpdate<TComp, TArg>(int capacity) : ComponentStorage<TComp>(capacity)
        where TComp : IEntityComponent<TArg>
    {
        /// <summary>
        ///     Runs the world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="b">The </param>
        internal override void Run(World world, Archetype b)
        {
            ref EntityIDOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();

            ref TArg arg = ref b.GetComponentDataReference<TArg>();

            Entity entity = world.DefaultWorldEntity;

            int size = b.EntityCount;
            for (int i = size - 1; i >= 0; i--)
            {
                entityIds.SetEntity(ref entity);
                comp.Update(entity, ref arg);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);

                arg = ref Unsafe.Add(ref arg, 1);
            }
        }

        /// <summary>
        ///     Multithreadeds the run using the specified countdown
        /// </summary>
        /// <param name="countdown">The countdown</param>
        /// <param name="world">The world</param>
        /// <param name="b">The </param>
        internal override void MultithreadedRun(CountdownEvent countdown, World world, Archetype b)
            => throw new NotImplementedException();
    }

    /// <inheritdoc cref="IComponentStorageBaseFactory" />
    public class EntityUpdateRunnerFactory<TComp, TArg> : IComponentStorageBaseFactory, IComponentStorageBaseFactory<TComp>
        where TComp : IEntityComponent<TArg>
    {
        /// <summary>
        ///     Creates the capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>The component storage base</returns>
        ComponentStorageBase IComponentStorageBaseFactory.Create(int capacity) => new EntityUpdate<TComp, TArg>(capacity);

        /// <summary>
        ///     Creates the stack
        /// </summary>
        /// <returns>The id table</returns>
        IDTable IComponentStorageBaseFactory.CreateStack() => new IDTable<TComp>();

        /// <summary>
        ///     Creates the strongly typed using the specified capacity
        /// </summary>
        /// <param name="capacity">The capacity</param>
        /// <returns>A component storage of t comp</returns>
        ComponentStorage<TComp> IComponentStorageBaseFactory<TComp>.CreateStronglyTyped(int capacity) => new EntityUpdate<TComp, TArg>(capacity);
    }
}