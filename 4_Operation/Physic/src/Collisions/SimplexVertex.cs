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
    ///     A vertex of the GJK simplex, containing support points from both shapes and a barycentric weight.
    /// </summary>
    internal struct SimplexVertex
    {
        /// <summary>
        ///     Barycentric coordinate weight for the closest-point interpolation. Sum of all vertex weights is 1.
        /// </summary>
        public float A;

        /// <summary>
        ///     Index of the support vertex on shape A.
        /// </summary>
        public int IndexA;

        /// <summary>
        ///     Index of the support vertex on shape B.
        /// </summary>
        public int IndexB;

        /// <summary>
        ///     The Minkowski difference point: wB - wA.
        /// </summary>
        public Vector2F W;

        /// <summary>
        ///     The support point on shape A in world coordinates.
        /// </summary>
        public Vector2F Wa;

        /// <summary>
        ///     The support point on shape B in world coordinates.
        /// </summary>
        public Vector2F Wb;
    }
}