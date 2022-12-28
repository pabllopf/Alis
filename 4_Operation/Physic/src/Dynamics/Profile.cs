// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Profile.cs
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
    ///     The profile
    /// </summary>
    public struct Profile
    {
        /// <summary>
        ///     The time it takes to complete the full World.Step()
        /// </summary>
        public long Step;

        /// <summary>
        ///     The time it takes to find collisions in the CollisionManager
        /// </summary>
        public long Collide;

        /// <summary>
        ///     The time it takes to solve integration of velocities, constraints and integrate positions
        /// </summary>
        public long Solve;

        /// <summary>
        ///     Timings from the island solver. The time it takes to initialize velocity constraints.
        /// </summary>
        public long SolveInit;

        /// <summary>
        ///     Timings from the island solver. It includes the time it takes to solve joint velocity constraints.
        /// </summary>
        public long SolveVelocity;

        /// <summary>
        ///     Timings from the island solver. In includes the time it takes to solve join positions.
        /// </summary>
        public long SolvePosition;

        /// <summary>
        ///     The time it takes for the broad-phase to update
        /// </summary>
        public long Broadphase;

        /// <summary>
        ///     The time it takes for the time-of-impact solver
        /// </summary>
        public long SolveToi;

        /// <summary>
        ///     Time it takes to process newly added and removed bodies/joints/controllers from the world
        /// </summary>
        public long AddRemoveTime;

        /// <summary>
        ///     The time it takes for the contact manager to find new contacts in the world
        /// </summary>
        public long NewContactsTime;

        /// <summary>
        ///     The time it takes to update controller logic
        /// </summary>
        public long ControllersUpdateTime;

        /// <summary>
        ///     The time it takes to update breakable bodies
        /// </summary>
        public long BreakableBodies;
    }
}