// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SimplexVertex.cs
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

using Alis.Aspect.Math;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     The simplex vertex
    /// </summary>
    internal struct SimplexVertex
    {
        /// <summary>
        ///     The
        /// </summary>
        internal Vector2 Wa; // support point in shapeA

        /// <summary>
        ///     The
        /// </summary>
        internal Vector2 Wb; // support point in shapeB

        /// <summary>
        ///     The
        /// </summary>
        internal Vector2 W; // wB - wA

        /// <summary>
        ///     The
        /// </summary>
        internal float A; // barycentric coordinate for closest point

        /// <summary>
        ///     The index
        /// </summary>
        internal int IndexA; // wA index

        /// <summary>
        ///     The index
        /// </summary>
        internal int IndexB; // wB index
    }
}