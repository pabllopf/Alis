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
    ///     Input parameters for <see cref="Distance.ComputeDistance"/>.
    ///     Specifies the two shape proxies, their transforms, and whether to include shape radii.
    /// </summary>
    public struct DistanceInput
    {
        /// <summary>
        ///     The distance proxy for the first shape, providing vertex data for the GJK algorithm.
        /// </summary>
        public DistanceProxy ProxyA;

        /// <summary>
        ///     The distance proxy for the second shape, providing vertex data for the GJK algorithm.
        /// </summary>
        public DistanceProxy ProxyB;

        /// <summary>
        ///     The world transform of the first shape (position and rotation).
        /// </summary>
        public ControllerTransform ControllerTransformA;

        /// <summary>
        ///     The world transform of the second shape (position and rotation).
        /// </summary>
        public ControllerTransform ControllerTransformB;

        /// <summary>
        ///     If <c>true</c>, the computed distance will account for the shape skin radii
        ///     by adjusting the witness points outward to the shape surfaces.
        /// </summary>
        public bool UseRadii;
    }
}