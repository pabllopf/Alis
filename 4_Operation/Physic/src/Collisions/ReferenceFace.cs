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
    ///     Represents a reference face used during edge-polygon collision clipping. The reference face defines
    ///     the clipping plane, side extrusion planes, and vertex indices needed to compute contact points
    ///     between an edge and a polygon shape.
    /// </summary>
    public struct ReferenceFace
    {
        /// <summary>
        ///     The indices of the two vertices that define the reference face on the reference shape.
        ///     I1 is the first vertex index, I2 is the second.
        /// </summary>
        public int I1, I2;

        /// <summary>
        ///     The world-space positions of the two vertices that define the reference face.
        ///     V1 corresponds to the vertex at index I1, V2 corresponds to I2.
        /// </summary>
        public Vector2F V1, V2;

        /// <summary>
        ///     The outward-facing normal of the reference face, pointing away from the reference shape.
        ///     Used to compute separation distances during clipping.
        /// </summary>
        public Vector2F Normal;

        /// <summary>
        ///     The first side normal vector, perpendicular to <see cref="Normal"/>, defining one side
        ///     extrusion plane for clipping the incident edge.
        /// </summary>
        public Vector2F SideNormal1;

        /// <summary>
        ///     The offset distance from the origin to the first side clipping plane along <see cref="SideNormal1"/>.
        /// </summary>
        public float SideOffset1;

        /// <summary>
        ///     The second side normal vector, opposite to <see cref="SideNormal1"/>, defining the other side
        ///     extrusion plane for clipping the incident edge.
        /// </summary>
        public Vector2F SideNormal2;

        /// <summary>
        ///     The offset distance from the origin to the second side clipping plane along <see cref="SideNormal2"/>.
        /// </summary>
        public float SideOffset2;
    }
}