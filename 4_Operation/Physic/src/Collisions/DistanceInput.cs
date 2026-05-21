// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceInput.cs
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

using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Input parameters for the GJK distance computation between two convex shapes.
    /// </summary>
    /// <remarks>
    ///     This struct encapsulates all data required to compute the minimum distance
    ///     between two shapes, including their proxies (shape representations),
    ///     world transforms, and whether shape radii should be factored into the result.
    /// </remarks>
    public struct DistanceInput
    {
        /// <summary>
        ///     Gets or sets the distance proxy for the first shape.
        /// </summary>
        /// <value>
        ///     A <see cref="DistanceProxy"/> providing access to the shape's vertices and radius.
        /// </value>
        public DistanceProxy ProxyA;

        /// <summary>
        ///     Gets or sets the distance proxy for the second shape.
        /// </summary>
        /// <value>
        ///     A <see cref="DistanceProxy"/> providing access to the shape's vertices and radius.
        /// </value>
        public DistanceProxy ProxyB;

        /// <summary>
        ///     Gets or sets the world transform for the first shape.
        /// </summary>
        /// <value>
        ///     A <see cref="ControllerTransform"/> representing the position, rotation, and scale of the first shape.
        /// </value>
        public ControllerTransform ControllerTransformA;

        /// <summary>
        ///     Gets or sets the world transform for the second shape.
        /// </summary>
        /// <value>
        ///     A <see cref="ControllerTransform"/> representing the position, rotation, and scale of the second shape.
        /// </value>
        public ControllerTransform ControllerTransformB;

        /// <summary>
        ///     Gets or sets a value indicating whether shape radii should be included in the distance computation.
        /// </summary>
        /// <value>
        ///     <c>true</c> to account for shape radii in the distance calculation; <c>false</c> to compute raw shape distance only.
        /// </value>
        /// <remarks>
        ///     When <c>true</c>, the output distance is adjusted by subtracting the sum of both shape radii,
        ///     and witness points are moved to the outer surface of each shape.
        /// </remarks>
        public bool UseRadii;
    }
}