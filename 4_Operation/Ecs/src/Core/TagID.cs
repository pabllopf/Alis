// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TagID.cs
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
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Core
{
    /// <summary>
    ///     Represents a specific type as a tag, and can be used for tag related queries
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct TagId(ushort rawData) : ITypeID, IEquatable<TagId>
    {
        /// <summary>
        ///     The raw value
        /// </summary>
        internal readonly ushort RawData = rawData;

        /// <summary>
        ///     The type that this TagID represents
        /// </summary>
        public Type Type => Tag.TagTable[RawData];

        /// <summary>
        ///     Gets the value of the value
        /// </summary>
        ushort ITypeID.Value => RawData;

        /// <summary>
        ///     Checks if this TagID instance represents the same type as <paramref name="other" />
        /// </summary>
        /// <param name="other">The tag to compare against</param>
        /// <returns><see langword="true" /> when they represent the same type, <see langword="false" /> otherwise</returns>
        public bool Equals(TagId other) => other.RawData == RawData;

        /// <summary>
        ///     Checks if this TagID instance represents the same type as <paramref name="other" />
        /// </summary>
        /// <param name="other">The tag to compare against</param>
        /// <returns><see langword="true" /> when they represent the same type, <see langword="false" /> otherwise</returns>
        public override bool Equals(object other) => other is TagId t && (RawData == t.RawData);

        /// <summary>
        ///     Checks if two <see cref="TagId" />s represent the same type
        /// </summary>
        /// <returns><see langword="true" /> when they represent the same type, <see langword="false" /> otherwise</returns>
        public static bool operator ==(TagId left, TagId right) => left.RawData == right.RawData;

        /// <summary>
        ///     Checks if two <see cref="TagId" />s represent a different type
        /// </summary>
        /// <returns><see langword="false" /> when they represent the same type, <see langword="true" /> otherwise</returns>
        public static bool operator !=(TagId left, TagId right) => left.RawData != right.RawData;

        /// <summary>
        ///     Gets the hashcode of this <see cref="TagId" />
        /// </summary>
        /// <returns>A unique code representing the <see cref="TagId" /></returns>
        public override int GetHashCode() => RawData;
    }
}