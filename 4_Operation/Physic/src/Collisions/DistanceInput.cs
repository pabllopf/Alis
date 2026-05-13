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
    ///     Input parameters for the <see cref="Distance.ComputeDistance"/> GJK algorithm.
    ///     Specifies the two shape proxies, their transforms, and whether shape radii
    ///     should be included in the distance calculation.
    /// </summary>
    public struct DistanceInput
    {
        /// <summary>
        ///     The distance proxy representing the first shape's vertices and radius for GJK computation.
        /// </summary>
        public DistanceProxy ProxyA;

        /// <summary>
        ///     The distance proxy representing the second shape's vertices and radius for GJK computation.
        /// </summary>
        public DistanceProxy ProxyB;

        /// <summary>
        ///     The world transform (position and rotation) of the first shape.
        /// </summary>
        public ControllerTransform ControllerTransformA;

        /// <summary>
        ///     The world transform (position and rotation) of the second shape.
        /// </summary>
        public ControllerTransform ControllerTransformB;

        /// <summary>
        ///     If <c>true</c>, the shape radii are subtracted from the computed distance to yield the
        ///     surface-to-surface distance. If <c>false</c> (or shapes overlap), radii are handled
        ///     differently or the distance represents center-to-center proximity.
        /// </summary>
        public bool UseRadii;
    }
}