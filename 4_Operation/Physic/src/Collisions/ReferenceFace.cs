// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ReferenceFace.cs
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
    ///     Represents a reference face used in the Sutherland-Hodgman clipping algorithm for collision manifold generation.
    /// </summary>
    /// <remarks>
    ///     During collision detection, when two polygons collide, the clipping algorithm needs a reference face
    ///     against which to clip the incident face. This struct stores all geometric data required for clipping:
    ///     the face vertices (V1, V2), the face normal, and side planes for containment tests.
    /// </remarks>
    public struct ReferenceFace
    {
        /// <summary>
        ///     Gets or sets the indices of the two vertices defining the reference face edge.
        /// </summary>
        /// <value>
        ///     Two <see cref="int"/> values representing the vertex indices in the original shape's vertex array.
        /// </value>
        public int I1, I2;

        /// <summary>
        ///     Gets or sets the world-space positions of the reference face's two endpoints.
        /// </summary>
        /// <value>
        ///     Two <see cref="Vector2F"/> values representing V1 (start) and V2 (end) of the face edge.
        /// </value>
        public Vector2F V1, V2;

        /// <summary>
        ///     Gets or sets the outward-facing normal of the reference face.
        /// </summary>
        /// <value>
        ///     A <see cref="Vector2F"/> representing the face normal in world coordinates.
        /// </value>
        public Vector2F Normal;

        /// <summary>
        ///     Gets or sets the side normal for the first side plane (left side when traversing V1 to V2).
        /// </summary>
        /// <value>
        ///     A <see cref="Vector2F"/> representing the inward-facing normal of the left side plane.
        /// </value>
        public Vector2F SideNormal1;

        /// <summary>
        ///     Gets or sets the signed distance from the origin to the first side plane.
        /// </summary>
        /// <value>
        ///     A <see cref="float"/> representing the plane offset for containment testing.
        /// </value>
        public float SideOffset1;

        /// <summary>
        ///     Gets or sets the side normal for the second side plane (right side when traversing V1 to V2).
        /// </summary>
        /// <value>
        ///     A <see cref="Vector2F"/> representing the inward-facing normal of the right side plane.
        /// </value>
        public Vector2F SideNormal2;

        /// <summary>
        ///     Gets or sets the signed distance from the origin to the second side plane.
        /// </summary>
        /// <value>
        ///     A <see cref="float"/> representing the plane offset for containment testing.
        /// </value>
        public float SideOffset2;
    }
}