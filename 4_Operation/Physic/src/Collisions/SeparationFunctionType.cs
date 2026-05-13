// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SeparationFunctionType.cs
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

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Defines the type of separation function used by the continuous collision detection (CCD) system to
    ///     compute the minimum separation between two shapes at a given time step. The type determines how the
    ///     separation axis and witness points are derived from the simplex cache.
    /// </summary>
    public enum SeparationFunctionType
    {
        /// <summary>
        ///     The separation is computed between two points from the simplex cache.
        ///     Used when the cache contains a single point (closest points on each shape).
        /// </summary>
        Points,

        /// <summary>
        ///     The separation is computed from a face (edge) of shape A to a point on shape B.
        ///     Used when two points on A and one on B define the simplex.
        /// </summary>
        FaceA,

        /// <summary>
        ///     The separation is computed from a face (edge) of shape B to a point on shape A.
        ///     Used when two points on B and one on A define the simplex.
        /// </summary>
        FaceB
    }
}