// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryHash.cs
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
using Alis.Core.Aspect.Math.Collections;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Computes and stores a hash value for a query based on its component rules.
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: 4 bytes total (single int).
    ///     Pack = 1 for minimal memory footprint.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct QueryHash
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="QueryHash"/> struct.
        /// </summary>
        public QueryHash()
        {
        }

        /// <summary>
        ///     The internal hash state used for computing the final hash.
        /// </summary>
        private int _state = 12582917;

        /// <summary>
        ///     Creates a new empty <see cref="QueryHash"/> instance.
        /// </summary>
        /// <returns>A new <see cref="QueryHash"/> ready for rule additions.</returns>
        public static QueryHash New() => new QueryHash();

        /// <summary>
        ///     Creates a new <see cref="QueryHash"/> pre-populated with the specified rules.
        /// </summary>
        /// <param name="rules">The rules to include in the hash computation.</param>
        /// <returns>A <see cref="QueryHash"/> containing the combined hash of all rules.</returns>
        public static QueryHash New(FastImmutableArray<Rule> rules)
        {
            QueryHash hash = new QueryHash();
            foreach (Rule rule in rules)
            {
                hash.AddRule(rule);
            }

            return hash;
        }

        /// <summary>
        ///     Adds a rule's hash code into this <see cref="QueryHash"/>.
        /// </summary>
        /// <param name="rule">The rule to incorporate into the hash.</param>
        /// <returns>This <see cref="QueryHash"/> after the rule has been added, for method chaining.</returns>
        public QueryHash AddRule(Rule rule)
        {
            _state *= rule.GetHashCode();
            return this;
        }

        /// <summary>
        ///     Produces the final hash code from the accumulated rules.
        /// </summary>
        /// <returns>The computed hash code as an integer.</returns>
        public int ToHashCode() => _state;
    }
}