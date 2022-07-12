// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Bound.cs
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
    ///     The bound class
    /// </summary>
    public class Bound
    {
        /// <summary>
        ///     The proxy id
        /// </summary>
        public ushort ProxyId;

        /// <summary>
        ///     The stabbing count
        /// </summary>
        public ushort StabbingCount;

        /// <summary>
        ///     The value
        /// </summary>
        public ushort Value;

        /// <summary>
        ///     Gets the value of the is lower
        /// </summary>
        public bool IsLower => (Value & 1) == 0;

        /// <summary>
        ///     Gets the value of the is upper
        /// </summary>
        public bool IsUpper => (Value & 1) == 1;

        /// <summary>
        ///     Clones this instance
        /// </summary>
        /// <returns>The new bound</returns>
        public Bound Clone()
        {
            Bound newBound = new Bound();
            newBound.Value = Value;
            newBound.ProxyId = ProxyId;
            newBound.StabbingCount = StabbingCount;
            return newBound;
        }
    }
}