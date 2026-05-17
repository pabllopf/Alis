// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TOIOutput.cs
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
    ///     Output result from continuous collision detection (Time of Impact calculation).
    /// </summary>
    /// <remarks>
    ///     Contains the state of the TOI computation and the fractional time of impact.
    ///     The state indicates whether a collision was detected, and if so, at what fraction
    ///     of the time step it occurred.
    /// </remarks>
    public struct ToiOutput
    {
        /// <summary>
        ///     Gets or sets the state of the time of impact computation.
        /// </summary>
        /// <value>
        ///     A <see cref="ToiOutputState"/> indicating whether the TOI was computed,
        ///     the shapes are already overlapping, or the sweep did not complete.
        /// </value>
        public ToiOutputState State;

        /// <summary>
        ///     Gets or sets the fractional time of impact in [0, tMax].
        /// </summary>
        /// <value>
        ///     A <see cref="float"/> representing the fraction of the time step when collision first occurs.
        /// </value>
        /// <remarks>
        ///     Valid only when <see cref="State"/> is <see cref="ToiOutputState.Collided"/>.
        ///     A value of 0 means the shapes are already overlapping at the start of the step.
        /// </remarks>
        public float T;
    }
}