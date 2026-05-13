// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Update.cs
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

namespace Alis.Core.Ecs.Updating.Runners
{
    /// <summary>
    ///     The update loop class
    /// </summary>
    internal static class UpdateLoop
    {
        /// <summary>
        ///     Runs the entity ids
        /// </summary>
        /// <typeparam name="TComp">The comp</typeparam>
        /// <param name="entityIds">The entity ids</param>
        /// <param name="comp">The comp</param>
        /// <param name="length">The length</param>
        /// <param name="gameObject">The game object</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Run<TComp>(ref GameObjectIdOnly entityIds, ref TComp comp, int length, GameObject gameObject)
            where TComp : IOnUpdate
        {
            if (length <= 0)
            {
                return;
            }

            do
            {
                entityIds.SetEntity(ref gameObject);
                comp.OnUpdate(gameObject);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);
            } while (--length != 0);
        }

        /// <summary>
        ///     Runs the entity ids
        /// </summary>
        /// <typeparam name="TComp">The comp</typeparam>
        /// <typeparam name="TArg1">The arg</typeparam>
        /// <typeparam name="TArg2">The arg</typeparam>
        /// <param name="entityIds">The entity ids</param>
        /// <param name="comp">The comp</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="length">The length</param>
        /// <param name="gameObject">The game object</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Run<TComp, TArg1, TArg2>(
            ref GameObjectIdOnly entityIds,
            ref TComp comp,
            ref TArg1 arg1,
            ref TArg2 arg2,
            int length,
            GameObject gameObject)
            where TComp : IOnUpdate<TArg1, TArg2>
        {
            if (length <= 0)
            {
                return;
            }

            do
            {
                entityIds.SetEntity(ref gameObject);
                comp.Update(gameObject, ref arg1, ref arg2);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);
                arg1 = ref Unsafe.Add(ref arg1, 1);
                arg2 = ref Unsafe.Add(ref arg2, 1);
            } while (--length != 0);
        }

        /// <summary>
        ///     Runs the entity ids
        /// </summary>
        /// <typeparam name="TComp">The comp</typeparam>
        /// <typeparam name="TArg1">The arg</typeparam>
        /// <typeparam name="TArg2">The arg</typeparam>
        /// <typeparam name="TArg3">The arg</typeparam>
        /// <param name="entityIds">The entity ids</param>
        /// <param name="comp">The comp</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        /// <param name="length">The length</param>
        /// <param name="gameObject">The game object</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Run<TComp, TArg1, TArg2, TArg3>(
            ref GameObjectIdOnly entityIds,
            ref TComp comp,
            ref TArg1 arg1,
            ref TArg2 arg2,
            ref TArg3 arg3,
            int length,
            GameObject gameObject)
            where TComp : IOnUpdate<TArg1, TArg2, TArg3>
        {
            if (length <= 0)
            {
                return;
            }

            do
            {
                entityIds.SetEntity(ref gameObject);
                comp.Update(gameObject, ref arg1, ref arg2, ref arg3);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);
                arg1 = ref Unsafe.Add(ref arg1, 1);
                arg2 = ref Unsafe.Add(ref arg2, 1);
                arg3 = ref Unsafe.Add(ref arg3, 1);
            } while (--length != 0);
        }

        /// <summary>
        ///     Runs the entity ids
        /// </summary>
        /// <typeparam name="TComp">The comp</typeparam>
        /// <typeparam name="TArg1">The arg</typeparam>
        /// <typeparam name="TArg2">The arg</typeparam>
        /// <typeparam name="TArg3">The arg</typeparam>
        /// <typeparam name="TArg4">The arg</typeparam>
        /// <param name="entityIds">The entity ids</param>
        /// <param name="comp">The comp</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        /// <param name="arg4">The arg</param>
        /// <param name="length">The length</param>
        /// <param name="gameObject">The game object</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Run<TComp, TArg1, TArg2, TArg3, TArg4>(
            ref GameObjectIdOnly entityIds,
            ref TComp comp,
            ref TArg1 arg1,
            ref TArg2 arg2,
            ref TArg3 arg3,
            ref TArg4 arg4,
            int length,
            GameObject gameObject)
            where TComp : IOnUpdate<TArg1, TArg2, TArg3, TArg4>
        {
            if (length <= 0)
            {
                return;
            }

            do
            {
                entityIds.SetEntity(ref gameObject);
                comp.Update(gameObject, ref arg1, ref arg2, ref arg3, ref arg4);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);
                arg1 = ref Unsafe.Add(ref arg1, 1);
                arg2 = ref Unsafe.Add(ref arg2, 1);
                arg3 = ref Unsafe.Add(ref arg3, 1);
                arg4 = ref Unsafe.Add(ref arg4, 1);
            } while (--length != 0);
        }

        /// <summary>
        ///     Runs the entity ids
        /// </summary>
        /// <typeparam name="TComp">The comp</typeparam>
        /// <typeparam name="TArg1">The arg</typeparam>
        /// <typeparam name="TArg2">The arg</typeparam>
        /// <typeparam name="TArg3">The arg</typeparam>
        /// <typeparam name="TArg4">The arg</typeparam>
        /// <typeparam name="TArg5">The arg</typeparam>
        /// <typeparam name="TArg6">The arg</typeparam>
        /// <param name="entityIds">The entity ids</param>
        /// <param name="comp">The comp</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        /// <param name="arg4">The arg</param>
        /// <param name="arg5">The arg</param>
        /// <param name="arg6">The arg</param>
        /// <param name="length">The length</param>
        /// <param name="gameObject">The game object</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Run<TComp, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(
            ref GameObjectIdOnly entityIds,
            ref TComp comp,
            ref TArg1 arg1,
            ref TArg2 arg2,
            ref TArg3 arg3,
            ref TArg4 arg4,
            ref TArg5 arg5,
            ref TArg6 arg6,
            int length,
            GameObject gameObject)
            where TComp : IOnUpdate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
        {
            if (length <= 0)
            {
                return;
            }

            do
            {
                entityIds.SetEntity(ref gameObject);
                comp.Update(gameObject, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);
                arg1 = ref Unsafe.Add(ref arg1, 1);
                arg2 = ref Unsafe.Add(ref arg2, 1);
                arg3 = ref Unsafe.Add(ref arg3, 1);
                arg4 = ref Unsafe.Add(ref arg4, 1);
                arg5 = ref Unsafe.Add(ref arg5, 1);
                arg6 = ref Unsafe.Add(ref arg6, 1);
            } while (--length != 0);
        }

        /// <summary>
        ///     Runs the entity ids
        /// </summary>
        /// <typeparam name="TComp">The comp</typeparam>
        /// <typeparam name="TArg1">The arg</typeparam>
        /// <typeparam name="TArg2">The arg</typeparam>
        /// <typeparam name="TArg3">The arg</typeparam>
        /// <typeparam name="TArg4">The arg</typeparam>
        /// <typeparam name="TArg5">The arg</typeparam>
        /// <typeparam name="TArg6">The arg</typeparam>
        /// <typeparam name="TArg7">The arg</typeparam>
        /// <param name="entityIds">The entity ids</param>
        /// <param name="comp">The comp</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        /// <param name="arg4">The arg</param>
        /// <param name="arg5">The arg</param>
        /// <param name="arg6">The arg</param>
        /// <param name="arg7">The arg</param>
        /// <param name="length">The length</param>
        /// <param name="gameObject">The game object</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Run<TComp, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(
            ref GameObjectIdOnly entityIds,
            ref TComp comp,
            ref TArg1 arg1,
            ref TArg2 arg2,
            ref TArg3 arg3,
            ref TArg4 arg4,
            ref TArg5 arg5,
            ref TArg6 arg6,
            ref TArg7 arg7,
            int length,
            GameObject gameObject)
            where TComp : IOnUpdate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
        {
            if (length <= 0)
            {
                return;
            }

            do
            {
                entityIds.SetEntity(ref gameObject);
                comp.Update(gameObject, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6, ref arg7);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);
                arg1 = ref Unsafe.Add(ref arg1, 1);
                arg2 = ref Unsafe.Add(ref arg2, 1);
                arg3 = ref Unsafe.Add(ref arg3, 1);
                arg4 = ref Unsafe.Add(ref arg4, 1);
                arg5 = ref Unsafe.Add(ref arg5, 1);
                arg6 = ref Unsafe.Add(ref arg6, 1);
                arg7 = ref Unsafe.Add(ref arg7, 1);
            } while (--length != 0);
        }

        /// <summary>
        ///     Runs the entity ids
        /// </summary>
        /// <typeparam name="TComp">The comp</typeparam>
        /// <typeparam name="TArg1">The arg</typeparam>
        /// <typeparam name="TArg2">The arg</typeparam>
        /// <typeparam name="TArg3">The arg</typeparam>
        /// <typeparam name="TArg4">The arg</typeparam>
        /// <typeparam name="TArg5">The arg</typeparam>
        /// <typeparam name="TArg6">The arg</typeparam>
        /// <typeparam name="TArg7">The arg</typeparam>
        /// <typeparam name="TArg8">The arg</typeparam>
        /// <param name="entityIds">The entity ids</param>
        /// <param name="comp">The comp</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        /// <param name="arg4">The arg</param>
        /// <param name="arg5">The arg</param>
        /// <param name="arg6">The arg</param>
        /// <param name="arg7">The arg</param>
        /// <param name="arg8">The arg</param>
        /// <param name="length">The length</param>
        /// <param name="gameObject">The game object</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Run<TComp, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(
            ref GameObjectIdOnly entityIds,
            ref TComp comp,
            ref TArg1 arg1,
            ref TArg2 arg2,
            ref TArg3 arg3,
            ref TArg4 arg4,
            ref TArg5 arg5,
            ref TArg6 arg6,
            ref TArg7 arg7,
            ref TArg8 arg8,
            int length,
            GameObject gameObject)
            where TComp : IOnUpdate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
        {
            if (length <= 0)
            {
                return;
            }

            do
            {
                entityIds.SetEntity(ref gameObject);
                comp.Update(gameObject, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6, ref arg7,
                    ref arg8);

                entityIds = ref Unsafe.Add(ref entityIds, 1);
                comp = ref Unsafe.Add(ref comp, 1);
                arg1 = ref Unsafe.Add(ref arg1, 1);
                arg2 = ref Unsafe.Add(ref arg2, 1);
                arg3 = ref Unsafe.Add(ref arg3, 1);
                arg4 = ref Unsafe.Add(ref arg4, 1);
                arg5 = ref Unsafe.Add(ref arg5, 1);
                arg6 = ref Unsafe.Add(ref arg6, 1);
                arg7 = ref Unsafe.Add(ref arg7, 1);
                arg8 = ref Unsafe.Add(ref arg8, 1);
            } while (--length != 0);
        }
    }

    /// <summary>
    ///     The gameObject update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    public class Update<TComp>(int capacity) : ComponentStorage<TComp>(capacity) where TComp : IOnUpdate
    {
        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        internal override void Run(Scene scene, Archetype b)
        {
            ref GameObjectIdOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();
            UpdateLoop.Run(ref entityIds, ref comp, b.EntityCount, scene.DefaultWorldGameObject);
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
            ref GameObjectIdOnly entityIds = ref Unsafe.Add(ref b.GetEntityDataReference(), start);
            ref TComp comp = ref Unsafe.Add(ref GetComponentStorageDataReference(), start);
            UpdateLoop.Run(ref entityIds, ref comp, length, scene.DefaultWorldGameObject);
        }
    }

    /// <summary>
    ///     The gameObject update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    public class Update<TComp, TArg1, TArg2>(int capacity) : ComponentStorage<TComp>(capacity)
        where TComp : IOnUpdate<TArg1, TArg2>
    {
        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        internal override void Run(Scene scene, Archetype b)
        {
            ref GameObjectIdOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();

            ref TArg1 arg1 = ref b.GetComponentDataReference<TArg1>();
            ref TArg2 arg2 = ref b.GetComponentDataReference<TArg2>();

            UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, b.EntityCount, scene.DefaultWorldGameObject);
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
            ref GameObjectIdOnly entityIds = ref Unsafe.Add(ref b.GetEntityDataReference(), start);
            ref TComp comp = ref Unsafe.Add(ref GetComponentStorageDataReference(), start);

            ref TArg1 arg1 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg1>(), start);
            ref TArg2 arg2 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg2>(), start);

            UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, length, scene.DefaultWorldGameObject);
        }
    }

    /// <summary>
    ///     The update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    public class Update<TComp, TArg1, TArg2, TArg3>(int capacity) : ComponentStorage<TComp>(capacity)
        where TComp : IOnUpdate<TArg1, TArg2, TArg3>
    {
        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        internal override void Run(Scene scene, Archetype b)
        {
            ref GameObjectIdOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();

            ref TArg1 arg1 = ref b.GetComponentDataReference<TArg1>();
            ref TArg2 arg2 = ref b.GetComponentDataReference<TArg2>();
            ref TArg3 arg3 = ref b.GetComponentDataReference<TArg3>();


            UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, ref arg3, b.EntityCount,
                scene.DefaultWorldGameObject);
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
            ref GameObjectIdOnly entityIds = ref Unsafe.Add(ref b.GetEntityDataReference(), start);
            ref TComp comp = ref Unsafe.Add(ref GetComponentStorageDataReference(), start);

            ref TArg1 arg1 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg1>(), start);
            ref TArg2 arg2 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg2>(), start);
            ref TArg3 arg3 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg3>(), start);


            UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, ref arg3, length,
                scene.DefaultWorldGameObject);
        }
    }

    /// <summary>
    ///     The update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    public class Update<TComp, TArg1, TArg2, TArg3, TArg4>(int capacity) : ComponentStorage<TComp>(capacity)
        where TComp : IOnUpdate<TArg1, TArg2, TArg3, TArg4>
    {
        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        internal override void Run(Scene scene, Archetype b)
        {
            ref GameObjectIdOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();

            ref TArg1 arg1 = ref b.GetComponentDataReference<TArg1>();
            ref TArg2 arg2 = ref b.GetComponentDataReference<TArg2>();
            ref TArg3 arg3 = ref b.GetComponentDataReference<TArg3>();
            ref TArg4 arg4 = ref b.GetComponentDataReference<TArg4>();


            UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, ref arg3, ref arg4, b.EntityCount,
                scene.DefaultWorldGameObject);
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
            ref GameObjectIdOnly entityIds = ref Unsafe.Add(ref b.GetEntityDataReference(), start);
            ref TComp comp = ref Unsafe.Add(ref GetComponentStorageDataReference(), start);

            ref TArg1 arg1 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg1>(), start);
            ref TArg2 arg2 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg2>(), start);
            ref TArg3 arg3 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg3>(), start);
            ref TArg4 arg4 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg4>(), start);


            UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, ref arg3, ref arg4, length,
                scene.DefaultWorldGameObject);
        }
    }

    /// <summary>
    ///     The update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    public class Update<TComp, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>(int capacity)
        : ComponentStorage<TComp>(capacity)
        where TComp : IOnUpdate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6>
    {
        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        internal override void Run(Scene scene, Archetype b)
        {
            ref GameObjectIdOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();

            ref TArg1 arg1 = ref b.GetComponentDataReference<TArg1>();
            ref TArg2 arg2 = ref b.GetComponentDataReference<TArg2>();
            ref TArg3 arg3 = ref b.GetComponentDataReference<TArg3>();
            ref TArg4 arg4 = ref b.GetComponentDataReference<TArg4>();
            ref TArg5 arg5 = ref b.GetComponentDataReference<TArg5>();
            ref TArg6 arg6 = ref b.GetComponentDataReference<TArg6>();


            UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6,
                b.EntityCount, scene.DefaultWorldGameObject);
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
            ref GameObjectIdOnly entityIds = ref Unsafe.Add(ref b.GetEntityDataReference(), start);
            ref TComp comp = ref Unsafe.Add(ref GetComponentStorageDataReference(), start);

            ref TArg1 arg1 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg1>(), start);
            ref TArg2 arg2 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg2>(), start);
            ref TArg3 arg3 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg3>(), start);
            ref TArg4 arg4 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg4>(), start);
            ref TArg5 arg5 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg5>(), start);
            ref TArg6 arg6 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg6>(), start);


            UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6,
                length, scene.DefaultWorldGameObject);
        }
    }

    /// <summary>
    ///     The update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    public class Update<TComp, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>(int capacity)
        : ComponentStorage<TComp>(capacity)
        where TComp : IOnUpdate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7>
    {
        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        internal override void Run(Scene scene, Archetype b)
        {
            ref GameObjectIdOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();

            ref TArg1 arg1 = ref b.GetComponentDataReference<TArg1>();
            ref TArg2 arg2 = ref b.GetComponentDataReference<TArg2>();
            ref TArg3 arg3 = ref b.GetComponentDataReference<TArg3>();
            ref TArg4 arg4 = ref b.GetComponentDataReference<TArg4>();
            ref TArg5 arg5 = ref b.GetComponentDataReference<TArg5>();
            ref TArg6 arg6 = ref b.GetComponentDataReference<TArg6>();
            ref TArg7 arg7 = ref b.GetComponentDataReference<TArg7>();


            UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6,
                ref arg7, b.EntityCount, scene.DefaultWorldGameObject);
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
            ref GameObjectIdOnly entityIds = ref Unsafe.Add(ref b.GetEntityDataReference(), start);
            ref TComp comp = ref Unsafe.Add(ref GetComponentStorageDataReference(), start);

            ref TArg1 arg1 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg1>(), start);
            ref TArg2 arg2 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg2>(), start);
            ref TArg3 arg3 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg3>(), start);
            ref TArg4 arg4 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg4>(), start);
            ref TArg5 arg5 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg5>(), start);
            ref TArg6 arg6 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg6>(), start);
            ref TArg7 arg7 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg7>(), start);


            UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6,
                ref arg7, length, scene.DefaultWorldGameObject);
        }
    }

    /// <summary>
    ///     The update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    public class Update<TComp, TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>(int capacity)
        : ComponentStorage<TComp>(capacity)
        where TComp : IOnUpdate<TArg1, TArg2, TArg3, TArg4, TArg5, TArg6, TArg7, TArg8>
    {
        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        internal override void Run(Scene scene, Archetype b)
        {
            ref GameObjectIdOnly entityIds = ref b.GetEntityDataReference();
            ref TComp comp = ref GetComponentStorageDataReference();

            ref TArg1 arg1 = ref b.GetComponentDataReference<TArg1>();
            ref TArg2 arg2 = ref b.GetComponentDataReference<TArg2>();
            ref TArg3 arg3 = ref b.GetComponentDataReference<TArg3>();
            ref TArg4 arg4 = ref b.GetComponentDataReference<TArg4>();
            ref TArg5 arg5 = ref b.GetComponentDataReference<TArg5>();
            ref TArg6 arg6 = ref b.GetComponentDataReference<TArg6>();
            ref TArg7 arg7 = ref b.GetComponentDataReference<TArg7>();
            ref TArg8 arg8 = ref b.GetComponentDataReference<TArg8>();


            UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6,
                ref arg7, ref arg8, b.EntityCount, scene.DefaultWorldGameObject);
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
            ref GameObjectIdOnly entityIds = ref Unsafe.Add(ref b.GetEntityDataReference(), start);
            ref TComp comp = ref Unsafe.Add(ref GetComponentStorageDataReference(), start);

            ref TArg1 arg1 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg1>(), start);
            ref TArg2 arg2 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg2>(), start);
            ref TArg3 arg3 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg3>(), start);
            ref TArg4 arg4 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg4>(), start);
            ref TArg5 arg5 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg5>(), start);
            ref TArg6 arg6 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg6>(), start);
            ref TArg7 arg7 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg7>(), start);
            ref TArg8 arg8 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg8>(), start);


            UpdateLoop.Run(ref entityIds, ref comp, ref arg1, ref arg2, ref arg3, ref arg4, ref arg5, ref arg6,
                ref arg7, ref arg8, length, scene.DefaultWorldGameObject);
        }
    }
}