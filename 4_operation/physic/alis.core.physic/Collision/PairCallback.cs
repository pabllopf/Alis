// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PairCallback.cs
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

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// The pair callback class
    /// </summary>
    public abstract class PairCallback
    {
        // This should return the new pair user data. It is ok if the
        // user data is null.
        /// <summary>
        /// Pairs the added using the specified proxy user data 1
        /// </summary>
        /// <param name="proxyUserData1">The proxy user data</param>
        /// <param name="proxyUserData2">The proxy user data</param>
        /// <returns>The object</returns>
        public abstract object PairAdded(object proxyUserData1, object proxyUserData2);

        // This should free the pair's user data. In extreme circumstances, it is possible
        // this will be called with null pairUserData because the pair never existed.
        /// <summary>
        /// Pairs the removed using the specified proxy user data 1
        /// </summary>
        /// <param name="proxyUserData1">The proxy user data</param>
        /// <param name="proxyUserData2">The proxy user data</param>
        /// <param name="pairUserData">The pair user data</param>
        public abstract void PairRemoved(object proxyUserData1, object proxyUserData2, object pairUserData);
    }
}