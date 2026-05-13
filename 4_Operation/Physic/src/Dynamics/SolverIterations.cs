// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SolverIterations.cs
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
    ///     Configures the number of solver iterations used by the physics engine for velocity and position
    ///     constraint resolution, including continuous collision detection (TOI) iterations.
    ///     These values directly affect simulation stability and performance.
    /// </summary>
    public struct SolverIterations
    {
        /// <summary>The number of velocity constraint iterations used in the main solver pass. More iterations improve stability at the cost of performance.</summary>
        public int VelocityIterations;

        /// <summary>The number of position constraint iterations used in the main solver pass. More iterations reduce overlap artifacts at the cost of performance.</summary>
        public int PositionIterations;

        /// <summary>The number of velocity iterations in the TOI (time of impact) continuous collision solver.</summary>
        public int ToiVelocityIterations;

        /// <summary>The number of position iterations in the TOI (time of impact) continuous collision solver.</summary>
        public int ToiPositionIterations;
    }
}