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
    /// <summary>
    ///     Provides all data needed by the contact and joint solvers for a single simulation step,
    ///     including the time step configuration, body position/velocity arrays, and lock indices.
    /// </summary>
    internal struct SolverData
    {
        /// <summary>
        ///     The time step configuration containing delta time, inverse delta time, and iteration counts.
        /// </summary>
        internal TimeStep Step;

        /// <summary>
        ///     The array of solver position states for all bodies in the simulation.
        /// </summary>
        internal SolverPosition[] Positions;

        /// <summary>
        ///     The array of solver velocity states for all bodies in the simulation.
        /// </summary>
        internal SolverVelocity[] Velocities;

        /// <summary>
        ///     Lock indices used to prevent duplicate processing of bodies during island solving.
        /// </summary>
        internal int[] Locks;
    }
}