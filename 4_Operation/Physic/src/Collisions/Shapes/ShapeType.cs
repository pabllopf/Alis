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
    ///     Identifies the concrete type of a collision shape.
    /// </summary>
    public enum ShapeType
    {
        /// <summary>
        ///     An uninitialized or undefined shape type.
        /// </summary>
        Unknown = -1,

        /// <summary>
        ///     A circular shape defined by a center point and radius.
        /// </summary>
        Circle = 0,

        /// <summary>
        ///     A line-segment edge shape with optional connectivity for smooth chains.
        /// </summary>
        Edge = 1,

        /// <summary>
        ///     A convex polygon shape defined by a set of vertices.
        /// </summary>
        Polygon = 2,

        /// <summary>
        ///     A chain shape composed of multiple connected edge segments.
        /// </summary>
        Chain = 3,

        /// <summary>
        ///     The total number of shape types (used for array sizing).
        /// </summary>
        TypeCount = 4
    }
}