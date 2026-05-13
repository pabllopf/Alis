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
    ///     Output result from <see cref="TimeOfImpact.CalculateTimeOfImpact"/>.
    ///     Contains the time of impact state and the time fraction at which the shapes first contact.
    /// </summary>
    public struct ToiOutput
    {
        /// <summary>
        ///     The state of the TOI computation indicating the outcome (unknown, failed, overlapped, touching, separated).
        /// </summary>
        public ToiOutputState State;

        /// <summary>
        ///     The time fraction in [0, tMax] at which the shapes first contact, or the best estimate if the
        ///     computation failed. The exact meaning depends on the <see cref="State"/> value.
        /// </summary>
        public float T;
    }
}