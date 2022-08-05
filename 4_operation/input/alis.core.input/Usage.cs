// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Usage.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using DevDecoder.HIDDevices;

namespace Alis.Core.Input
{
    /// <summary>
    ///     Class Usage. This class cannot be inherited.
    ///     Implements the <see cref="IEquatable{T}" /> interface.
    ///     A HID Usage.
    /// </summary>
    /// <seealso cref="IEquatable{T}" />
    /// <see href="https://www.usb.org/document-library/hid-usage-tables-112" />
    public sealed class Usage : IEquatable<Usage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Usage" /> class
        /// </summary>
        /// <param name="page">The page</param>
        /// <param name="id">The id</param>
        /// <param name="name">The name</param>
        /// <param name="types">The types</param>
        internal Usage(UsagePage page, ushort id, string name, UsageTypes types)
        {
            Page = page;
            Id = id;
            Name = name;
            Types = UsageType.Get(types);
        }

        /// <summary>
        ///     Gets the page.
        /// </summary>
        /// <value>The page.</value>
        public UsagePage Page { get; }

        /// <summary>
        ///     Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public ushort Id { get; }

        /// <summary>
        ///     Gets the full identifier
        /// </summary>
        /// <value>The full identifier.</value>
        public uint FullId => (uint)((Page.Id << 16) + Id);

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>
        ///     Gets the full name
        /// </summary>
        /// <value>The full name.</value>
        public string FullName => $"{Page.Name}: {Name}";

        /// <summary>
        ///     Gets the types.
        /// </summary>
        /// <value>The types.</value>
        public IReadOnlyCollection<UsageType> Types { get; }


        /// <summary>
        ///     Describes whether this instance equals
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        public bool Equals(Usage other)
        {
            return !(other is null) &&
                   (ReferenceEquals(this, other) || (Page.Equals(other.Page) && Id == other.Id));
        }


        /// <summary>
        ///     Gets the usage
        /// </summary>
        /// <param name="usage">The usage</param>
        /// <returns>The usage</returns>
        public static Usage Get(Enum usage)
        {
            return Get(Convert.ToUInt32(usage));
        }


        /// <summary>
        ///     Gets the full id
        /// </summary>
        /// <param name="fullId">The full id</param>
        /// <returns>The usage</returns>
        public static Usage Get(uint fullId)
        {
            return UsagePage.Get(fullId).GetUsage((ushort)(fullId & 0xFFFF));
        }

        /// <summary>
        ///     Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(Usage left, Usage right)
        {
            return Equals(left, right);
        }

        /// <summary>
        ///     Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(Usage left, Usage right)
        {
            return !Equals(left, right);
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="Usage" /> to <see cref="System.UInt32" />.
        /// </summary>
        /// <param name="usage">The usage.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator uint(Usage usage)
        {
            return usage.FullId;
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="System.UInt32" /> to <see cref="Usage" />.
        /// </summary>
        /// <param name="usage">The usage.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Usage(uint usage)
        {
            return Get(usage);
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="Enum" /> to <see cref="Usage" />.
        /// </summary>
        /// <param name="usage">The usage.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Usage(Enum usage)
        {
            return Get(usage);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return ReferenceEquals(this, obj) || (obj is Usage other && Equals(other));
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(Page, Id);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{Page} - {Name}";
        }
    }
}