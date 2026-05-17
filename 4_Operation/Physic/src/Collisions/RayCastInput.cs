// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RayCastInput.cs
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

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Input parameters for a ray cast operation against the physics world.
    /// </summary>
    /// <remarks>
    ///     The ray is defined parametrically as: P(t) = Point1 + t * (Point2 - Point1),
    ///     where t ranges from 0 to MaxFraction. A MaxFraction of 1.0 casts the full ray
    ///     from Point1 to Point2, while values less than 1.0 cast a partial ray.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RayCastInput
    {
        /// <summary>
        ///     Gets or sets the maximum fraction along the ray to test for intersections.
        /// </summary>
        /// <value>
        ///     A <see cref="float"/> between 0.0 and 1.0. The ray extends from Point1 to
        ///     Point1 + MaxFraction * (Point2 - Point1).
        /// </value>
        /// <remarks>
        ///     A MaxFraction of 1.0 casts the full ray from Point1 to Point2.
        ///     A MaxFraction of 0.5 casts the ray from Point1 halfway to Point2.
        ///     Values greater than 1.0 extend the ray beyond Point2.
        /// </remarks>
        public float MaxFraction;

        /// <summary>
        ///     Gets or sets the starting point of the ray.
        /// </summary>
        /// <value>
        ///     A <see cref="Vector2F"/> representing the ray's origin in world coordinates.
        /// </value>
        public Vector2F Point1;

        /// <summary>
        ///     Gets or sets the ending point of the ray (used as direction reference).
        /// </summary>
        /// <value>
        ///     A <see cref="Vector2F"/> defining the ray's direction. The actual endpoint is
        ///     Point1 + MaxFraction * (Point2 - Point1).
        /// </value>
        public Vector2F Point2;
    }
}