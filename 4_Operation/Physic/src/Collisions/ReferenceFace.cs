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
    ///     Describes a reference face used for clipping incident edges during manifold generation.
    /// </summary>
    public struct ReferenceFace
    {
        /// <summary>
        ///     Vertex indices of the reference edge on the reference polygon.
        /// </summary>
        public int I1, I2;

        /// <summary>
        ///     World-space vertex positions of the reference edge.
        /// </summary>
        public Vector2F V1, V2;

        /// <summary>
        ///     The outward-facing normal of the reference edge.
        /// </summary>
        public Vector2F Normal;

        /// <summary>
        ///     The side plane normal for the first side of the extruded reference edge.
        /// </summary>
        public Vector2F SideNormal1;

        /// <summary>
        ///     The signed distance from the origin to the first side clipping plane.
        /// </summary>
        public float SideOffset1;

        /// <summary>
        ///     The side plane normal for the second side of the extruded reference edge.
        /// </summary>
        public Vector2F SideNormal2;

        /// <summary>
        ///     The signed distance from the origin to the second side clipping plane.
        /// </summary>
        public float SideOffset2;
    }
}