// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   MassData.cs
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

namespace Alis.Core.Physic.Collision.Shapes
{
    /// <summary>
    ///     This holds the mass data computed for a shape.
    /// </summary>
    public struct MassData
    {
        /// <summary>
        ///     The mass of the shape, usually in kilograms.
        /// </summary>
        public float Mass;

        /// <summary>
        ///     The position of the shape's centroid relative to the shape's origin.
        /// </summary>
        public Vector2 Center;

        /// <summary>
        ///     The rotational inertia of the shape.
        /// </summary>
        public float I;
    }
}