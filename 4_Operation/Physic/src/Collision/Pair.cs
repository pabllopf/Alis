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

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     The pair
    /// </summary>
    internal struct Pair : IComparable<Pair>
    {
        /// <summary>
        ///     The proxy id
        /// </summary>
        public int ProxyIdA;

        /// <summary>
        ///     The proxy id
        /// </summary>
        public int ProxyIdB;

        

        /// <summary>
        ///     Compares the to using the specified other
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The int</returns>
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