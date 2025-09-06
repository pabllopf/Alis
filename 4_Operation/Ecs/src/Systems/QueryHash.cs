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
    ///     The query hash
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct QueryHash
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="QueryHash" /> class
        /// </summary>
        public QueryHash()
        {
        }

        /// <summary>
        ///     The state
        /// </summary>
        private int _state = 12582917;

        /// <summary>
        ///     News
        /// </summary>
        /// <returns>The query hash</returns>
        public static QueryHash New() => new QueryHash();

        /// <summary>
        ///     News the rules
        /// </summary>
        /// <param name="rules">The rules</param>
        /// <returns>The hash</returns>
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
        ///     Adds the rule using the specified rule
        /// </summary>
        /// <param name="rule">The rule</param>
        /// <returns>The query hash</returns>
        public QueryHash AddRule(Rule rule)
        {
            _state *= rule.GetHashCode();
            return this;
        }

        /// <summary>
        ///     Returns the hash code
        /// </summary>
        /// <returns>The int</returns>
        public int ToHashCode() => _state;
    }
}