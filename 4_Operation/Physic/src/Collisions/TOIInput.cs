// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TOIInput.cs
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

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Input parameters for <see cref="TimeOfImpact.CalculateTimeOfImpact"/>.
    ///     Specifies the two shape proxies, their motion sweeps, and the maximum time fraction
    ///     that defines the sweep interval [0, tMax].
    /// </summary>
    public class ToiInput
    {
        /// <summary>
        ///     The distance proxy for the first shape (A), providing vertices for GJK support queries.
        /// </summary>
        public DistanceProxy ProxyA;

        /// <summary>
        ///     The distance proxy for the second shape (B), providing vertices for GJK support queries.
        /// </summary>
        public DistanceProxy ProxyB;

        /// <summary>
        ///     The motion sweep data for shape A, defining its position and rotation over time.
        /// </summary>
        public Sweep SweepA;

        /// <summary>
        ///     The motion sweep data for shape B, defining its position and rotation over time.
        /// </summary>
        public Sweep SweepB;

        /// <summary>
        ///     The maximum time fraction defining the sweep interval [0, tMax].
        ///     The TOI algorithm searches for impacts within this range.
        /// </summary>
        public float TMax;
    }
}