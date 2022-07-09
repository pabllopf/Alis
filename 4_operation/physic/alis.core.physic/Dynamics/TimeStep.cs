// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TimeStep.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The time step
    /// </summary>
    public struct TimeStep
    {
        /// <summary>
        ///     The dt
        /// </summary>
        public float Dt; // time step

        /// <summary>
        ///     The inv dt
        /// </summary>
        public float InvDt; // inverse time step (0 if dt == 0).

        /// <summary>
        ///     The dt ratio
        /// </summary>
        public float DtRatio; // dt * inv_dt0

        /// <summary>
        ///     The velocity iterations
        /// </summary>
        public int VelocityIterations;

        /// <summary>
        ///     The position iterations
        /// </summary>
        public int PositionIterations;

        /// <summary>
        ///     The warm starting
        /// </summary>
        public bool WarmStarting;
    }
}