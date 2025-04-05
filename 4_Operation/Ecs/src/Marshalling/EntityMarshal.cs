// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityMarshal.cs
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

using Alis.Core.Ecs.Arch;

namespace Alis.Core.Ecs.Marshalling
{
    /// <summary>
    ///     Unsafe methods to write even faster code! Users are expected to know what they are doing and improper usage can
    ///     result in corrupting world state and segfaults.
    /// </summary>
    /// <remarks>The APIs in this class are less stable, as many depend on implementation details.</remarks>
    public static class EntityMarshal
    {
        /// <summary>
        ///     Gets the world using the specified entity
        /// </summary>
        /// <param name="gameObject">The entity</param>
        /// <returns>The world</returns>
        public static Scene GetWorld(GameObject gameObject) => GlobalWorldTables.Worlds.UnsafeIndexNoResize(gameObject.EntityID);

        /// <summary>
        ///     Entities the id using the specified entity
        /// </summary>
        /// <param name="gameObject">The entity</param>
        /// <returns>The int</returns>
        public static int EntityID(GameObject gameObject) => gameObject.EntityID;
    }
}