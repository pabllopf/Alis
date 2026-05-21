// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ManifoldType.cs
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

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Specifies the type of contact manifold generated during collision detection.
    /// </summary>
    public enum ManifoldType
    {
        /// <summary>
        ///     Circle-to-circle contact manifold. Both shapes are circles, producing a single contact point at the midpoint.
        /// </summary>
        Circles,

        /// <summary>
        ///     Face-to-face contact manifold where shape A's face is the reference face.
        /// </summary>
        /// <remarks>
        ///     The contact normal points from shape B toward shape A. Typically used when shape A has a larger face
        ///     or more vertices than the penetrating features of shape B.
        /// </remarks>
        FaceA,

        /// <summary>
        ///     Face-to-face contact manifold where shape B's face is the reference face.
        /// </summary>
        /// <remarks>
        ///     The contact normal points from shape A toward shape B. Typically used when shape B has a larger face
        ///     or more vertices than the penetrating features of shape A.
        /// </remarks>
        FaceB
    }
}