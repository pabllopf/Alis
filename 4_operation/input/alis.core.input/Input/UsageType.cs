// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UsageType.cs
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace Alis.Core.Input
{
    /// <summary>
    ///     The usage type class
    /// </summary>
    /// <seealso cref="IEquatable{UsageType}" />
    public sealed class UsageType : IEquatable<UsageType>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UsageType" /> class
        /// </summary>
        /// <param name="usageTypes">The usage types</param>
        /// <param name="usageTypeGroup">The usage type group</param>
        /// <param name="name">The name</param>
        /// <param name="description">The description</param>
        private UsageType(UsageTypes usageTypes, UsageTypeGroup usageTypeGroup, string name, string description)
        {
            UsageTypes = usageTypes;
            UsageTypeGroup = usageTypeGroup;
            Name = name;
            Description = description;
            SUsageTypes[usageTypes] = new[] {this};
        }

        /// <summary>
        ///     Gets the associated usage types enum.
        /// </summary>
        /// <value>The usage types.</value>
        public UsageTypes UsageTypes { get; }

        /// <summary>
        ///     Gets the usage type group.
        /// </summary>
        /// <value>The usage type group.</value>
        public UsageTypeGroup UsageTypeGroup { get; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>
        ///     Gets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; }

        /// <summary>
        ///     The usage type
        /// </summary>
        private static readonly ConcurrentDictionary<UsageTypes, IReadOnlyCollection<UsageType>>
            SUsageTypes = new ConcurrentDictionary<UsageTypes, IReadOnlyCollection<UsageType>>();

        /// <summary>
        ///     The Linear Control usage type.
        /// </summary>
        public static readonly UsageType Lc = new UsageType(UsageTypes.Lc, UsageTypeGroup.Controls, "LC",
            "Linear Control");

        /// <summary>
        ///     The On/Off Control usage type.
        /// </summary>
        public static readonly UsageType Ooc = new UsageType(UsageTypes.Ooc, UsageTypeGroup.Controls, "OOC",
            "On/Off Control");

        /// <summary>
        ///     The Momentary Control usage type.
        /// </summary>
        public static readonly UsageType Mc = new UsageType(UsageTypes.Mc, UsageTypeGroup.Controls, "MC",
            "Momentary Control");

        /// <summary>
        ///     The One Shot Control usage type.
        /// </summary>
        public static readonly UsageType Osc = new UsageType(UsageTypes.Osc, UsageTypeGroup.Controls, "OSC",
            "One Shot Control");

        /// <summary>
        ///     The Re-trigger Control usage type.
        /// </summary>
        public static readonly UsageType Rtc = new UsageType(UsageTypes.Rtc, UsageTypeGroup.Controls, "RTC",
            "Re-trigger Control");

        /// <summary>
        ///     The Selector usage type.
        /// </summary>
        public static readonly UsageType Sel = new UsageType(UsageTypes.Sel, UsageTypeGroup.Data, "Sel", "Selector");

        /// <summary>
        ///     The Static Value usage type.
        /// </summary>
        public static readonly UsageType Sv = new UsageType(UsageTypes.Sv, UsageTypeGroup.Data, "SV", "Static Value");

        /// <summary>
        ///     The Static Flag usage type.
        /// </summary>
        public static readonly UsageType Sf = new UsageType(UsageTypes.Sf, UsageTypeGroup.Data, "SF", "Static Flag");

        /// <summary>
        ///     The Dynamic Value usage type.
        /// </summary>
        public static readonly UsageType Dv = new UsageType(UsageTypes.Dv, UsageTypeGroup.Data, "DV", "Dynamic Value");

        /// <summary>
        ///     The Dynamic Flag usage type.
        /// </summary>
        public static readonly UsageType Df = new UsageType(UsageTypes.Df, UsageTypeGroup.Data, "DF", "Dynamic Flag");

        /// <summary>
        ///     The Named Array usage type.
        /// </summary>
        public static readonly UsageType NAry = new UsageType(UsageTypes.NAry, UsageTypeGroup.Collections, "NAry",
            "Named Array");

        /// <summary>
        ///     The Application Collection usage type.
        /// </summary>
        public static readonly UsageType Ca = new UsageType(UsageTypes.Ca, UsageTypeGroup.Collections, "CA",
            "Application Collection");

        /// <summary>
        ///     The Logical Collection usage type.
        /// </summary>
        public static readonly UsageType Cl = new UsageType(UsageTypes.Cl, UsageTypeGroup.Collections, "CL",
            "Logical Collection");

        /// <summary>
        ///     The Physical Collection usage type.
        /// </summary>
        public static readonly UsageType Cp = new UsageType(UsageTypes.Cp, UsageTypeGroup.Collections, "CP",
            "Physical Collection");

        /// <summary>
        ///     The Usage Switch usage type.
        /// </summary>
        public static readonly UsageType Us = new UsageType(UsageTypes.Us, UsageTypeGroup.Controls, "US",
            "Usage Switch");

        /// <summary>
        ///     The Usage Modifier usage type.
        /// </summary>
        public static readonly UsageType Um = new UsageType(UsageTypes.Um, UsageTypeGroup.Collections, "UM",
            "Usage Modifier");

        /// <inheritdoc />
        public bool Equals(UsageType other) => !(other is null) &&
                                               (ReferenceEquals(this, other) || UsageTypes == other.UsageTypes);

        /// <inheritdoc />
        public override bool Equals(object obj) => ReferenceEquals(this, obj) || (obj is UsageType other && Equals(other));

        /// <inheritdoc />
        public override int GetHashCode() => (int) UsageTypes;

        /// <summary>
        ///     Implements the == operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(UsageType left, UsageType right) => Equals(left, right);

        /// <summary>
        ///     Implements the != operator.
        /// </summary>
        /// <param name="left">The left.</param>
        /// <param name="right">The right.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(UsageType left, UsageType right) => !Equals(left, right);

        /// <summary>
        ///     Gets the specified usage types from the flag enum.
        /// </summary>
        /// <param name="usageTypes">The usage types.</param>
        /// <returns>A collection of <seealso cref="UsageType" />.</returns>
        public static IReadOnlyCollection<UsageType> Get(UsageTypes usageTypes)
        {
            return usageTypes > UsageTypes.None
                ? SUsageTypes.GetOrAdd(
                    usageTypes,
                    u =>
                        Enum.GetValues(typeof(UsageTypes)).Cast<UsageTypes>()
                            .Where(flag => (flag != 0) && ((u & flag) != 0))
                            .Select(ut =>
                                SUsageTypes.TryGetValue(ut, out IReadOnlyCollection<UsageType> usageType) ? usageType.SingleOrDefault() : null!)
                            .Where(ut => ut != null)
                            .ToArray())
                : Array.Empty<UsageType>();
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="UsageType" /> to <see cref="UsageTypes" />.
        /// </summary>
        /// <param name="usageType">Type of the usage.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator UsageTypes(UsageType usageType) => usageType.UsageTypes;

        /// <inheritdoc />
        public override string ToString() => Name;
    }
}