// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldMarshal.cs
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
using Frent.Core;
using Frent.Updating.Runners;

namespace Frent.Marshalling
{
    /// <summary>
    ///     Unsafe methods to write even faster code! Users are expected to know what they are doing and improper usage can
    ///     result in corrupting world state and segfaults.
    /// </summary>
    /// <remarks>The APIs in this class are less stable, as many depend on implementation details.</remarks>
    public static class WorldMarshal
    {
        /// <summary>
        ///     Gets the component using the specified world
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="world">The world</param>
        /// <param name="entity">The entity</param>
        /// <returns>The ref</returns>
        public static ref T GetComponent<T>(World world, Entity entity)
        {
            EntityLocation location = world.EntityTable.UnsafeIndexNoResize(entity.EntityID);
            return ref UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(location.Archetype.Components.UnsafeArrayIndex(location.Archetype.GetComponentIndex<T>()))[location.Index];
        }

        /// <summary>
        ///     Gets the raw buffer using the specified world
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="world">The world</param>
        /// <param name="entity">The entity</param>
        /// <returns>A span of t</returns>
        public static Span<T> GetRawBuffer<T>(World world, Entity entity)
        {
            EntityLocation location = world.EntityTable.UnsafeIndexNoResize(entity.EntityID);
            return UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(location.Archetype.Components.UnsafeArrayIndex(location.Archetype.GetComponentIndex<T>())).AsSpan();
        }

        /// <summary>
        ///     Gets the world
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="world">The world</param>
        /// <param name="entityID">The entity id</param>
        /// <returns>The ref</returns>
        public static ref T Get<T>(World world, int entityID)
        {
            EntityLocation location = world.EntityTable.UnsafeIndexNoResize(entityID);

            Archetype archetype = location.Archetype;

            int compIndex = archetype.GetComponentIndex<T>();

            //Components[0] null; trap
            ComponentStorage<T> storage = UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(archetype.Components.UnsafeArrayIndex(compIndex));
            return ref storage[location.Index];
        }
    }
}