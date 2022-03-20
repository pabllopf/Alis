// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   CollisionFlags.cs
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

namespace Alis.Core.Physics2D.Dynamics.Contacts
{
    /// <summary>
    /// The collision flags enum
    /// </summary>
    [Flags]
    public enum CollisionFlags
    {
        /// <summary>
        /// The island collision flags
        /// </summary>
        Island = 0x01,
        /// <summary>
        /// The touching collision flags
        /// </summary>
        Touching = 0x02,
        /// <summary>
        /// The enabled collision flags
        /// </summary>
        Enabled = 0x04,
        /// <summary>
        /// The filter collision flags
        /// </summary>
        Filter = 0x08,
        /// <summary>
        /// The bullet hit collision flags
        /// </summary>
        BulletHit = 0x10,
        /// <summary>
        /// The toi collision flags
        /// </summary>
        Toi = 0x20
    }
}