// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyType.cs
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
///     Defines the type of a physics body, which determines how it behaves in the simulation.
///     The body type affects how the body responds to forces, collisions, and user input.
///     There are three types: Static (fixed position), Kinematic (user-controlled motion),
///     and Dynamic (fully simulated physics).
/// </summary>
    public enum BodyType
    {
        /// <summary>
        ///     Zero velocity, may be manually moved. Note: even static bodies have mass.
        /// </summary>
        Static,

        /// <summary>
        ///     Zero mass, non-zero velocity set by user, moved by solver
        /// </summary>
        Kinematic,

        /// <summary>
        ///     Positive mass, non-zero velocity determined by forces, moved by solver
        /// </summary>
        Dynamic
    }
}