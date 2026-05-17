// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Pair.cs
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

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Represents an ordered pair of proxy IDs used for broad-phase collision detection.
    /// </summary>
    /// <remarks>
    ///     Pairs are stored with ProxyIdA &lt;= ProxyIdB to ensure consistent ordering,
    ///     enabling efficient duplicate detection through sorting. This struct is packed
    ///     to minimize memory footprint during pair buffer operations.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Pair : IComparable<Pair>
    {
        /// <summary>
        ///     Gets or sets the smaller proxy ID in the pair.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the first proxy ID (guaranteed to be &lt;= ProxyIdB).
        /// </value>
        public int ProxyIdA;

        /// <summary>
        ///     Gets or sets the larger proxy ID in the pair.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the second proxy ID (guaranteed to be &gt;= ProxyIdA).
        /// </value>
        public int ProxyIdB;


        /// <summary>
        ///     Compares this pair to another for sorting purposes.
        /// </summary>
        /// <param name="other">The other pair to compare against.</param>
        /// <returns>
        ///     A signed integer indicating the relative order: negative if this pair precedes <paramref name="other"/>,
        ///     zero if equal, positive if this pair follows <paramref name="other"/>.
        /// </returns>
        /// <remarks>
        ///     Comparison is performed first by ProxyIdB, then by ProxyIdA, enabling efficient
        ///     duplicate pair detection through <see cref="Array.Sort"/>.
        /// </remarks>
        public int CompareTo(Pair other)
        {
            if (ProxyIdB < other.ProxyIdB)
            {
                return -1;
            }

            if (ProxyIdB == other.ProxyIdB)
            {
                if (ProxyIdA < other.ProxyIdA)
                {
                    return -1;
                }

                if (ProxyIdA == other.ProxyIdA)
                {
                    return 0;
                }
            }

            return 1;
        }
    }
}