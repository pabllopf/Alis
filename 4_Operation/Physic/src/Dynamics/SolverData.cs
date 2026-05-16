// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SolverData.cs
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

namespace Alis.Core.Physic.Dynamics
{
    /// Solver Data
    internal struct SolverData
    {
        /// <summary>
        ///     The time step configuration for the current solver iteration.
        /// </summary>
        internal TimeStep Step;

        /// <summary>
        ///     Array of body positions used during constraint solving.
        /// </summary>
        internal SolverPosition[] Positions;

        /// <summary>
        ///     Array of body velocities used during constraint solving.
        /// </summary>
        internal SolverVelocity[] Velocities;

        /// <summary>
        ///     Lock flags for multi-threaded solver operations.
        /// </summary>
        internal int[] Locks;
    }
}