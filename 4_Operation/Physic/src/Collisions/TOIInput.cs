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
    ///     Defines the two shapes, their motion sweeps, and the time interval for CCD.
    /// </summary>
    public class ToiInput
    {
        /// <summary>
        ///     The distance proxy for the first shape used during the TOI computation.
        /// </summary>
        public DistanceProxy ProxyA;

        /// <summary>
        ///     The distance proxy for the second shape used during the TOI computation.
        /// </summary>
        public DistanceProxy ProxyB;

        /// <summary>
        ///     The motion sweep (position and rotation over time) for the first shape.
        /// </summary>
        public Sweep SweepA;

        /// <summary>
        ///     The motion sweep (position and rotation over time) for the second shape.
        /// </summary>
        public Sweep SweepB;

        /// <summary>
        ///     The upper bound of the sweep time interval. The TOI is searched within [0, TMax].
        /// </summary>
        public float TMax;
    }
}