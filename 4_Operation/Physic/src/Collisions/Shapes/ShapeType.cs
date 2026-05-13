// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShapeType.cs
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

namespace Alis.Core.Physic.Collisions.Shapes
{
    /// <summary>
    ///     Defines the available types of collision shapes in the physics engine.
    ///     Each shape type has different collision properties and computational characteristics.
    /// </summary>
    public enum ShapeType
    {
        /// <summary>
        ///     The shape type has not been initialized or is unspecified.
        ///     Used as a default value before the shape is fully constructed.
        /// </summary>
        Unknown = -1,

        /// <summary>
        ///     A circle shape defined by a center position and radius.
        ///     The simplest and most efficient collision primitive.
        /// </summary>
        Circle = 0,

        /// <summary>
        ///     A line segment (edge) shape defined by two endpoints.
        ///     Can be connected to adjacent edges for smooth chain collisions.
        /// </summary>
        Edge = 1,

        /// <summary>
        ///     A convex polygon shape defined by a set of vertices.
        ///     Vertices must form a non-self-intersecting convex hull.
        /// </summary>
        Polygon = 2,

        /// <summary>
        ///     A chain shape consisting of a sequence of connected line segments.
        ///     Supports smooth collisions between adjacent edges using ghost vertices.
        /// </summary>
        Chain = 3,

        /// <summary>
        ///     The total count of distinct shape types. Not a valid shape type itself.
        ///     Used for array sizing and enumeration purposes.
        /// </summary>
        TypeCount = 4
    }
}