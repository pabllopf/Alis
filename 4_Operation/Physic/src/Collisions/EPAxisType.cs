// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EPAxisType.cs
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
    ///     Defines the type of separating axis identified during edge-polygon collision detection (EP algorithm).
    ///     Determines whether the best separation was found against an edge or a polygon face, or is unknown.
    /// </summary>
    public enum EpAxisType
    {
        /// <summary>
        ///     The separating axis type has not been determined or is not applicable.
        ///     This is the default state before axis computation.
        /// </summary>
        Unknown,

        /// <summary>
        ///     The best separating axis corresponds to an edge of shape A (the edge shape).
        ///     Separation is measured from the edge's reference face.
        /// </summary>
        EdgeA,

        /// <summary>
        ///     The best separating axis corresponds to an edge/face of shape B (the polygon shape).
        ///     Separation is measured from the polygon's reference face.
        /// </summary>
        EdgeB
    }
}