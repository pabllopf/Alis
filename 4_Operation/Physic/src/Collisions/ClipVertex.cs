// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClipVertex.cs
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
    ///     Represents a vertex used in contact manifold computation during polygon clipping operations.
    /// </summary>
    /// <remarks>
    ///     ClipVertex pairs a geometric position with a contact identifier, enabling the collision
    ///     system to track which original features resulted in each clipped contact point during
    ///     the collision detection pipeline.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ClipVertex
    {
        /// <summary>
        ///     Gets or sets the contact identifier for this vertex.
        /// </summary>
        /// <value>The <see cref="ContactId"/> identifying the geometric features that created this contact point.</value>
        public ContactId Id;

        /// <summary>
        ///     Gets or sets the position of this clipped vertex in world coordinates.
        /// </summary>
        /// <value>A 2D vector representing the vertex position.</value>
        public Vector2F V;
    }
}