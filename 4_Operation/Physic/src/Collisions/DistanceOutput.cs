// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceOutput.cs
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

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Output result from the <see cref="Distance.ComputeDistance"/> GJK algorithm.
    ///     Contains the minimum distance between two shapes and the closest points (witness points)
    ///     on each shape's surface.
    /// </summary>
    public struct DistanceOutput
    {
        /// <summary>
        ///     The minimum distance between the two shapes after radius consideration.
        ///     A value of zero or less indicates the shapes are overlapping or touching.
        /// </summary>
        public float Distance;

        /// <summary>
        ///     The number of GJK iterations used to compute this distance result.
        ///     Useful for performance profiling and debugging.
        /// </summary>
        public int Iterations;

        /// <summary>
        ///     The closest point on the surface of shape A (witness point A) in world coordinates.
        /// </summary>
        public Vector2F PointA;

        /// <summary>
        ///     The closest point on the surface of shape B (witness point B) in world coordinates.
        /// </summary>
        public Vector2F PointB;
    }
}