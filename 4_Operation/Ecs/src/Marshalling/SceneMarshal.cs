// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneMarshal.cs
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
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Marshalling
{
    /// <summary>
    ///     Unsafe methods to write even faster code! Users are expected to know what they are doing and improper usage can
    ///     result in corrupting scene state and segfaults.
    /// </summary>
    /// <remarks>The APIs in this class are less stable, as many depend on implementation details.</remarks>
    public static class SceneMarshal
    {
        /// <summary>
        ///     Gets a component of an gameObject, without checking if the gameObject has the component or if the scene belongs to
        ///     the
        ///     gameObject.
        /// </summary>
        /// <returns>A reference to the component in memory.</returns>
        public static ref T GetComponent<T>(Scene scene, GameObject gameObject) => ref Get<T>(scene, gameObject.EntityID);

        /// <summary>
        ///     Gets raw span over the entire buffer of a component type for an archetype.
        /// </summary>
        /// <typeparam name="T">The type of component to get.</typeparam>
        /// <param name="scene">The scene that the gameObject belongs to.</param>
        /// <param name="gameObject">The gameObject whose component buffer to get.</param>
        /// <param name="index">The index of the gameObject's component.</param>
        /// <returns>The entire sliced raw buffer. May be larger than the number of entities in an archetype.</returns>
        public static Span<T> GetRawBuffer<T>(Scene scene, GameObject gameObject, out int index)
        {
            GameObjectLocation location = scene.EntityTable.UnsafeIndexNoResize(gameObject.EntityID);
            index = location.Index;
            return Unsafe.As<ComponentStorage<T>>(
                Unsafe.Add(ref location.Archetype.Components[0], location.Archetype.GetComponentIndex<T>())).AsSpan();
        }

        /// <summary>
        ///     Gets a component of an gameObject from a raw entityID.
        /// </summary>
        /// <returns>A reference to the component in memory.</returns>
        public static ref T Get<T>(Scene scene, int entityId)
        {
            GameObjectLocation location = scene.EntityTable.UnsafeIndexNoResize(entityId);

            Archetype archetype = location.Archetype;

            int compIndex = archetype.GetComponentIndex<T>();

            //Components[0] null; trap
            ComponentStorage<T> storage =
                Unsafe.As<ComponentStorage<T>>(Unsafe.Add(ref archetype.Components[0], compIndex));
            return ref storage[location.Index];
        }
    }
}