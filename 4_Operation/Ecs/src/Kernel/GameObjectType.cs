// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectType.cs
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

global using ArchetypeID = Alis.Core.Ecs.Kernel.GameObjectType;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Kernel
{
    //This isn't named ArchetypeID because archetypes are an implementation detail
    /// <summary>
    ///     Represents an gameObject's type, or set of component and tag types that make it up
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GameObjectType : IEquatable<ArchetypeID>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObjectType" /> class
        /// </summary>
        /// <param name="id">The id</param>
        internal GameObjectType(ushort id) => RawIndex = id;

        /// <summary>
        ///     The raw index
        /// </summary>
        internal ushort RawIndex;

        /// <summary>
        ///     The component types
        /// </summary>
        public readonly FastImmutableArray<ComponentId> Types =>
            Archetypes.Archetype.ArchetypeTable[RawIndex].ComponentTypes;
        
        /// <summary>
        ///     Checks if this <see cref="GameObjectType" /> has a component represented by a <see cref="ComponentId" />
        /// </summary>
        /// <param name="componentId">The ID of the component type to check if this <see cref="GameObjectType" /> has</param>
        /// <returns>
        ///     <see langword="true" /> if this GameObject type has a component of the specified component ID,
        ///     <see langword="false" /> otherwise
        /// </returns>
        public readonly bool HasComponent(ComponentId componentId) => GlobalWorldTables.ComponentIndex(this, componentId) != 0;
        
        /// <summary>
        ///     Checks if this <see cref="GameObjectType" /> represents the same ID as <paramref name="other" />
        /// </summary>
        /// <param name="other">The EntityType to compare against</param>
        /// <returns><see langword="true" /> if they represent the same ID, <see langword="false" /> otherwise</returns>
        public readonly bool Equals(GameObjectType other) => RawIndex == other.RawIndex;

        /// <summary>
        ///     Checks if this <see cref="GameObjectType" /> represents the same ID as <paramref name="obj" />
        /// </summary>
        /// <param name="obj">The object to compare against</param>
        /// <returns><see langword="true" /> if they represent the same ID, <see langword="false" /> otherwise</returns>
        public readonly override bool Equals(object obj) => obj is GameObjectType other && Equals(other);

        /// <summary>
        ///     Gets the hash code for this <see cref="GameObjectType" />
        /// </summary>
        /// <returns>An integer hash code representing this <see cref="GameObjectType" /></returns>
        public readonly override int GetHashCode() => RawIndex;

        /// <summary>
        ///     Checks if two <see cref="GameObjectType" /> instances represent the same ID
        /// </summary>
        /// <param name="left">The first EntityType</param>
        /// <param name="right">The second EntityType</param>
        /// <returns><see langword="true" /> if they represent the same ID, <see langword="false" /> otherwise</returns>
        public static bool operator ==(GameObjectType left, GameObjectType right) => left.Equals(right);

        /// <summary>
        ///     Checks if two <see cref="GameObjectType" /> instances represent different IDs
        /// </summary>
        /// <param name="left">The first EntityType</param>
        /// <param name="right">The second EntityType</param>
        /// <returns><see langword="true" /> if they represent different IDs, <see langword="false" /> otherwise</returns>
        public static bool operator !=(GameObjectType left, GameObjectType right) => !left.Equals(right);
        
        /// <summary>
        ///     Archetypes the context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The ref archetype archetype</returns>
        internal readonly ref Archetype Archetype(Scene context) => ref Unsafe.Add(ref context.WorldArchetypeTable[0], RawIndex).Archetype!;
    }
}