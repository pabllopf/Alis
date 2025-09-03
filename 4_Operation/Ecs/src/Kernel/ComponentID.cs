// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentID.cs
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

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     A lightweight struct that represents a component type. Used for fast lookups.
    /// </summary>
    public readonly struct ComponentId : ITypeId, IEquatable<ComponentId>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentId" /> class
        /// </summary>
        /// <param name="id">The id</param>
        internal ComponentId(ushort id) => RawIndex = id;

        /// <summary>
        ///     The raw index
        /// </summary>
        internal readonly ushort RawIndex;

        /// <summary>
        ///     The type of component this <see cref="ComponentId" /> represents.
        /// </summary>
        public Type Type => Component.ComponentTable[RawIndex].Type;

        /// <summary>
        ///     Gets the value of the value
        /// </summary>
        ushort ITypeId.Value => RawIndex;

        /// <summary>
        ///     Checks if this <see cref="ComponentId" /> instance represents the same ID as <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="ComponentId" /> to compare against.</param>
        /// <returns><see langword="true" /> if they represent the same ID, <see langword="false" /> otherwise.</returns>
        public bool Equals(ComponentId other) => RawIndex == other.RawIndex;

        /// <summary>
        ///     Checks if this <see cref="ComponentId" /> instance represents the same ID as <paramref name="obj" />.
        /// </summary>
        /// <param name="obj">The object to compare against.</param>
        /// <returns><see langword="true" /> if they represent the same ID, <see langword="false" /> otherwise.</returns>
        public override bool Equals(object obj) => obj is ComponentId other && Equals(other);

        /// <summary>
        ///     Gets the hash code for this <see cref="ComponentId" />.
        /// </summary>
        /// <returns>An integer hash code representing this <see cref="ComponentId" />.</returns>
        public override int GetHashCode() => RawIndex;

        /// <summary>
        ///     Checks if two <see cref="ComponentId" /> instances represent the same ID.
        /// </summary>
        /// <param name="left">The first <see cref="ComponentId" />.</param>
        /// <param name="right">The second <see cref="ComponentId" />.</param>
        /// <returns><see langword="true" /> if they represent the same ID, <see langword="false" /> otherwise.</returns>
        public static bool operator ==(ComponentId left, ComponentId right) => left.Equals(right);

        /// <summary>
        ///     Checks if two <see cref="ComponentId" /> instances represent different IDs.
        /// </summary>
        /// <param name="left">The first <see cref="ComponentId" />.</param>
        /// <param name="right">The second <see cref="ComponentId" />.</param>
        /// <returns><see langword="true" /> if they represent different IDs, <see langword="false" /> otherwise.</returns>
        public static bool operator !=(ComponentId left, ComponentId right) => !left.Equals(right);

        /// <summary>
        ///     Gets the value of the debugger display string
        /// </summary>
        internal string DebuggerDisplayString => $"Types: {Type} ID: {RawIndex}";
    }
}