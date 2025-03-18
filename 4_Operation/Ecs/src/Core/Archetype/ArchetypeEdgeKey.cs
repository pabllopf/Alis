// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArchetypeEdgeKey.cs
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
using System.Runtime.InteropServices;

namespace Frent.Core.Structures
{
    /// <summary>
    ///     The archetype edge key
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct ArchetypeEdgeKey : IEquatable<ArchetypeEdgeKey>
    {
        //could be tag type or component type
        /// <summary>
        ///     The component id
        /// </summary>
        internal ComponentID ComponentID;

        /// <summary>
        ///     The tag id
        /// </summary>
        internal TagID TagID;

        /// <summary>
        ///     The archetype from
        /// </summary>
        internal ArchetypeID ArchetypeFrom;

        /// <summary>
        ///     The edge type
        /// </summary>
        internal ArchetypeEdgeType EdgeType;

        /// <summary>
        ///     Components the component id
        /// </summary>
        /// <param name="componentID">The component id</param>
        /// <param name="from">The from</param>
        /// <param name="archetypeEdgeType">The archetype edge type</param>
        /// <returns>The archetype edge key</returns>
        public static ArchetypeEdgeKey Component(ComponentID componentID, ArchetypeID from, ArchetypeEdgeType archetypeEdgeType) => new()
        {
            ComponentID = componentID,
            ArchetypeFrom = from,
            EdgeType = archetypeEdgeType
        };

        /// <summary>
        ///     Tags the tag id
        /// </summary>
        /// <param name="tagID">The tag id</param>
        /// <param name="from">The from</param>
        /// <param name="archetypeEdgeType">The archetype edge type</param>
        /// <returns>The archetype edge key</returns>
        public static ArchetypeEdgeKey Tag(TagID tagID, ArchetypeID from, ArchetypeEdgeType archetypeEdgeType) => new()
        {
            TagID = tagID,
            ArchetypeFrom = from,
            EdgeType = archetypeEdgeType
        };

#if NET8_0_OR_GREATER
        internal long Packed => Unsafe.BitCast<ArchetypeEdgeKey, long>(this);
#else
        /// <summary>
        ///     Gets the value of the packed
        /// </summary>
        internal long Packed => Unsafe.As<ArchetypeEdgeKey, long>(ref this);
#endif
        /// <summary>
        ///     Equalses the other
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        public bool Equals(ArchetypeEdgeKey other) => other.Packed == Packed;

        /// <summary>
        ///     Equalses the obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object? obj) => obj is ArchetypeEdgeKey other && Equals(other);

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode() => Packed.GetHashCode();
    }

    /// <summary>
    ///     The archetype edge type enum
    /// </summary>
    internal enum ArchetypeEdgeType : ushort
    {
        /// <summary>
        ///     The add component archetype edge type
        /// </summary>
        AddComponent = 49157,

        /// <summary>
        ///     The remove component archetype edge type
        /// </summary>
        RemoveComponent = 24593,

        /// <summary>
        ///     The add tag archetype edge type
        /// </summary>
        AddTag = 12289,

        /// <summary>
        ///     The remove tag archetype edge type
        /// </summary>
        RemoveTag = 6151
    }
}