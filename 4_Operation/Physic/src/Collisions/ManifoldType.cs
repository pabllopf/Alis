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
    ///     Defines the type of contact manifold between two colliding shapes. The manifold type determines
    ///     how the local point and normal are interpreted during collision resolution.
    /// </summary>
    public enum ManifoldType
    {
        /// <summary>
        ///     The manifold represents a circle-to-circle contact. The local point represents the center of circle A,
        ///     and the local normal is not used.
        /// </summary>
        Circles,

        /// <summary>
        ///     The manifold represents a contact where shape A provides the reference face. The local point is the
        ///     center of the reference face on shape A, and the local normal is the outward normal of that face.
        /// </summary>
        FaceA,

        /// <summary>
        ///     The manifold represents a contact where shape B provides the reference face. The local point is the
        ///     center of the reference face on shape B, and the local normal is the outward normal of that face.
        /// </summary>
        FaceB
    }
}