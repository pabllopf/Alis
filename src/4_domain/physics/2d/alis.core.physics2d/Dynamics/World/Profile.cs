// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Profile.cs
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

namespace Alis.Core.Physics2D.Dynamics.World
{
    /// <summary>
    /// The profile
    /// </summary>
    internal struct Profile
    {
        /// <summary>
        /// The step
        /// </summary>
        internal float step;
        /// <summary>
        /// The collide
        /// </summary>
        internal float collide;
        /// <summary>
        /// The solve
        /// </summary>
        internal float solve;
        /// <summary>
        /// The solve init
        /// </summary>
        internal float solveInit;
        /// <summary>
        /// The solve velocity
        /// </summary>
        internal float solveVelocity;
        /// <summary>
        /// The solve position
        /// </summary>
        internal float solvePosition;
        /// <summary>
        /// The broadphase
        /// </summary>
        internal float broadphase;
        /// <summary>
        /// The solve toi
        /// </summary>
        internal float solveTOI;
    }
}