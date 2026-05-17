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
    ///     Input parameters for continuous collision detection (Time of Impact calculation).
    /// </summary>
    /// <remarks>
    ///     Defines the shapes, their continuous motion (sweeps), and the time interval
    ///     over which to search for the first contact. The TOI solver uses these inputs
    ///     to determine the exact fraction of time when two moving shapes first collide.
    /// </remarks>
    public class ToiInput
    {
        /// <summary>
        ///     Gets or sets the distance proxy for shape A.
        /// </summary>
        /// <value>
        ///     A <see cref="DistanceProxy"/> providing access to shape A's vertices and radius.
        /// </value>
        public DistanceProxy ProxyA;

        /// <summary>
        ///     Gets or sets the distance proxy for shape B.
        /// </summary>
        /// <value>
        ///     A <see cref="DistanceProxy"/> providing access to shape B's vertices and radius.
        /// </value>
        public DistanceProxy ProxyB;

        /// <summary>
        ///     Gets or sets the sweep object for shape A's continuous motion.
        /// </summary>
        /// <value>
        ///     A <see cref="Sweep"/> describing the linear and angular velocity of shape A.
        /// </value>
        public Sweep SweepA;

        /// <summary>
        ///     Gets or sets the sweep object for shape B's continuous motion.
        /// </summary>
        /// <value>
        ///     A <see cref="Sweep"/> describing the linear and angular velocity of shape B.
        /// </value>
        public Sweep SweepB;

        /// <summary>
        ///     Gets or sets the maximum fraction of the time step to search for impact.
        /// </summary>
        /// <value>
        ///     A <see cref="float"/> in the range [0, 1] defining the sweep interval [0, tMax].
        /// </value>
        /// <remarks>
        ///     The TOI solver searches for the first contact within this time interval.
        ///     If no collision occurs within [0, tMax], the shapes do not collide during this step.
        /// </remarks>
        public float TMax; // defines sweep interval [0, tMax]
    }
}