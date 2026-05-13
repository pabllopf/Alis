// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TimeStep.cs
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

/*
 * Original source Box2D:
 * Copyright (c) 2006-2011 Erin Catto http://www.box2d.org
 *
 * This software is provided 'as-is', without any express or implied
 * warranty.  In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software
 * in a product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
 */

namespace Alis.Core.Physic.Dynamics
{
/// <summary>
///     Internal structure that holds data for a single time step in the physics simulation.
///     This structure is used by the solver to manage the iteration process and
///     contains all the parameters needed for solving constraints during a time step.
///     It's marked as internal because it's only used within the Dynamics namespace.
/// </summary>
    internal struct TimeStep
    {
/// <summary>
///     Gets or sets the time step size (delta time) for this step.
///     This represents the amount of time that has passed since the last step,
///     typically measured in seconds.
/// </summary>
        public float Dt;

        /// <summary>
        ///     dt * inv_dt0
        /// </summary>
        public float DtRatio;

        /// <summary>
        ///     Inverse time step (0 if dt == 0).
        /// </summary>
        public float InvDt;

        /// <summary>
        ///     The position iterations
        /// </summary>
        public int PositionIterations;

        /// <summary>
        ///     The velocity iterations
        /// </summary>
        public int VelocityIterations;

        /// <summary>
        ///     The warm starting
        /// </summary>
        public bool WarmStarting;
    }
}