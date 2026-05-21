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

using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Handles update logic for entities that have a specific component and up to five dependency arguments.
    /// </summary>
    /// <typeparam name="TComp">The component type that implements <see cref="IOnUpdate{TArg1,TArg2,TArg3,TArg4,TArg5}"/>.</typeparam>
    /// <typeparam name="TArg1">The type of the first update argument.</typeparam>
    /// <typeparam name="TArg2">The type of the second update argument.</typeparam>
    /// <typeparam name="TArg3">The type of the third update argument.</typeparam>
    /// <typeparam name="TArg4">The type of the fourth update argument.</typeparam>
    /// <typeparam name="TArg5">The type of the fifth update argument.</typeparam>
    /// <seealso cref="ComponentStorage{TComp}" />
    public class EntityUpdate<TComp, TArg1, TArg2, TArg3, TArg4, TArg5>(int capacity) : ComponentStorage<TComp>(capacity)
        where TComp : IOnUpdate<TArg1, TArg2, TArg3, TArg4, TArg5>
    {
        /// <summary>
        ///     Runs the update logic for all entities of this archetype.
        /// </summary>
        /// <param name="scene">The scene containing the entities to update.</param>
        /// <param name="b">The archetype representing the set of entities to update.</param>
        internal override void Run(Scene scene, Archetype b)
        {
            ref GameObjectIdOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();

            ref TArg1 arg1 = ref b.GetComponentDataReference<TArg1>();
            ref TArg2 arg2 = ref b.GetComponentDataReference<TArg2>();
            ref TArg3 arg3 = ref b.GetComponentDataReference<TArg3>();
            ref TArg4 arg4 = ref b.GetComponentDataReference<TArg4>();
            ref TArg5 arg5 = ref b.GetComponentDataReference<TArg5>();


            GameObject gameObject = scene.DefaultWorldGameObject;

            for (int i = b.EntityCount - 1; i >= 0; i--)
            {
                entityIds.SetEntity(ref gameObject);
                comp.Update(gameObject, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);

                arg1 = ref Unsafe.Add(ref arg1, 1);
                arg2 = ref Unsafe.Add(ref arg2, 1);
                arg3 = ref Unsafe.Add(ref arg3, 1);
                arg4 = ref Unsafe.Add(ref arg4, 1);
                arg5 = ref Unsafe.Add(ref arg5, 1);
            }
        }

        /// <summary>
        ///     Runs the update logic for a subset of entities in this archetype, starting at the specified index.
        /// </summary>
        /// <param name="scene">The scene containing the entities to update.</param>
        /// <param name="b">The archetype representing the set of entities to update.</param>
        /// <param name="start">The zero-based starting index within the archetype from which to begin updating.</param>
        /// <param name="length">The number of entities to update starting from <paramref name="start"/>.</param>
        internal override void Run(Scene scene, Archetype b, int start, int length)
        {
            ref GameObjectIdOnly entityIds = ref Unsafe.Add(ref b.GetEntityDataReference(), start);
            ref TComp comp = ref Unsafe.Add(ref GetComponentStorageDataReference(), start);

            ref TArg1 arg1 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg1>(), start);
            ref TArg2 arg2 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg2>(), start);
            ref TArg3 arg3 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg3>(), start);
            ref TArg4 arg4 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg4>(), start);
            ref TArg5 arg5 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg5>(), start);


            GameObject gameObject = scene.DefaultWorldGameObject;

            for (int i = length - 1; i >= 0; i--)
            {
                entityIds.SetEntity(ref gameObject);
                comp.Update(gameObject, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);

                arg1 = ref Unsafe.Add(ref arg1, 1);
                arg2 = ref Unsafe.Add(ref arg2, 1);
                arg3 = ref Unsafe.Add(ref arg3, 1);
                arg4 = ref Unsafe.Add(ref arg4, 1);
                arg5 = ref Unsafe.Add(ref arg5, 1);
            }
        }
    }
}