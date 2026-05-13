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
    ///     Represents a pair of proxy identifiers detected as potentially overlapping during the broad-phase
    ///     collision detection pass. Pairs are sorted and deduplicated before being reported to the collision
    ///     system for narrow-phase processing.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct Pair : IComparable<Pair>
    {
        /// <summary>
        ///     The proxy identifier of the first object in the overlapping pair.
        ///     This is always the smaller of the two proxy IDs after sorting.
        /// </summary>
        public int ProxyIdA;

        /// <summary>
        ///     The proxy identifier of the second object in the overlapping pair.
        ///     This is always the larger of the two proxy IDs after sorting.
        /// </summary>
        public int ProxyIdB;


        /// <summary>
        ///     Compares this pair to another pair for sorting and duplicate detection.
        ///     Pairs are sorted first by <see cref="ProxyIdB"/> and then by <see cref="ProxyIdA"/>.
        /// </summary>
        /// <param name="other">The other pair to compare against.</param>
        /// <returns>
        ///     A value less than zero if this instance precedes <paramref name="other"/> in sort order;
        ///     zero if they are equal; greater than zero if this follows <paramref name="other"/>.
        /// </returns>
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