// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityData.cs
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

using System.Runtime.InteropServices;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     A compact struct representing the core identity data of an entity in the ECS system.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     This struct holds the fundamental identifying information for any entity: its unique
    ///     ID within a scene, a version counter for detecting stale references, and the scene
    ///     it belongs to.
    ///     </para>
    ///     <para>
    ///     Memory layout: 8 bytes total (int + ushort + ushort), packed with no padding
    ///     for optimal memory efficiency in bulk storage scenarios.
    ///     </para>
    ///     <para>
    ///     The version field enables safe entity ID recycling - when an entity is deleted,
    ///     its ID may be reassigned to a new entity with an incremented version, allowing
    ///     systems to detect and reject operations on invalidated references.
    ///     </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct EntityData
    {
        /// <summary>
        ///     Gets or sets the unique identifier of the entity within its scene.
        /// </summary>
        /// <value>
        ///     An integer that uniquely identifies this entity. This ID may be recycled
        ///     after the entity is deleted.
        /// </value>
        internal int EntityID;

        /// <summary>
        ///     Gets or sets the version number of this entity.
        /// </summary>
        /// <value>
        ///     A counter that increments each time the entity is created, allowing detection
        ///     of stale references to deleted entities.
        /// </value>
        internal ushort EntityVersion;

        /// <summary>
        ///     Gets or sets the identifier of the scene that owns this entity.
        /// </summary>
        /// <value>
        ///     The ID of the <see cref="Scene"/> that contains this entity.
        /// </value>
        internal ushort WorldID;
    }
}