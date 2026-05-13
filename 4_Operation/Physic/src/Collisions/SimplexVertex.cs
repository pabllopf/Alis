// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimplexVertex.cs
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
    ///     Represents a single vertex of the GJK simplex in Minkowski difference space.
    ///     Each vertex stores a support point from each shape, their difference vector,
    ///     the vertex indices, and the barycentric coefficient for closest-point computation.
    /// </summary>
    internal struct SimplexVertex
    {
        /// <summary>
        ///     The barycentric coordinate (coefficient) for this vertex in the convex combination
        ///     that yields the closest point to the origin. The sum of all A values equals 1.
        /// </summary>
        public float A;

        /// <summary>
        ///     The index of the support vertex on shape A that generated this simplex point.
        /// </summary>
        public int IndexA;

        /// <summary>
        ///     The index of the support vertex on shape B that generated this simplex point.
        /// </summary>
        public int IndexB;

        /// <summary>
        ///     The difference vector Wb - Wa in world space (Minkowski sum point).
        /// </summary>
        public Vector2F W;

        /// <summary>
        ///     The world-space support point on shape A (proxyA).
        /// </summary>
        public Vector2F Wa;

        /// <summary>
        ///     The world-space support point on shape B (proxyB).
        /// </summary>
        public Vector2F Wb;
    }
}