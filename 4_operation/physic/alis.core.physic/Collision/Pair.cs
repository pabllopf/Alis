// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Pair.cs
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
    ///     The pair class
    /// </summary>
    public class Pair
    {
        /// <summary>
        ///     The next
        /// </summary>
        public ushort Next;

        /// <summary>
        ///     The proxy id
        /// </summary>
        public ushort ProxyId1;

        /// <summary>
        ///     The proxy id
        /// </summary>
        public ushort ProxyId2;

        /// <summary>
        ///     The status
        /// </summary>
        public PairStatus Status;

        /// <summary>
        ///     The user data
        /// </summary>
        public object UserData;

        /// <summary>
        ///     Sets the buffered
        /// </summary>
        public void SetBuffered()
        {
            Status |= PairStatus.PairBuffered;
        }

        /// <summary>
        ///     Clears the buffered
        /// </summary>
        public void ClearBuffered()
        {
            Status &= ~PairStatus.PairBuffered;
        }

        /// <summary>
        ///     Describes whether this instance is buffered
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsBuffered()
        {
            return (Status & PairStatus.PairBuffered) == PairStatus.PairBuffered;
        }

        /// <summary>
        ///     Sets the removed
        /// </summary>
        public void SetRemoved()
        {
            Status |= PairStatus.PairRemoved;
        }

        /// <summary>
        ///     Clears the removed
        /// </summary>
        public void ClearRemoved()
        {
            Status &= ~PairStatus.PairRemoved;
        }

        /// <summary>
        ///     Describes whether this instance is removed
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsRemoved()
        {
            return (Status & PairStatus.PairRemoved) == PairStatus.PairRemoved;
        }

        /// <summary>
        ///     Sets the final
        /// </summary>
        public void SetFinal()
        {
            Status |= PairStatus.PairFinal;
        }

        /// <summary>
        ///     Describes whether this instance is final
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsFinal()
        {
            return (Status & PairStatus.PairFinal) == PairStatus.PairFinal;
        }
    }
}