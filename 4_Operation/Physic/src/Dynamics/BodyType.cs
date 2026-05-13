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
    ///     Defines the type of a physics body, which determines how it interacts with forces, collisions,
    ///     and constraints in the simulation.
    /// </summary>
    public enum BodyType
    {
        /// <summary>
        ///     A static body has zero velocity and does not respond to forces or collisions.
        ///     Static bodies are immovable and are used for terrain, walls, and other fixed geometry.
        ///     Note: even static bodies have mass for constraint calculations.
        /// </summary>
        Static,

        /// <summary>
        ///     A kinematic body has zero mass but non-zero velocity set by the user.
        ///     Kinematic bodies are moved by the solver to resolve collisions, and they can push
        ///     dynamic bodies. They are useful for moving platforms, elevators, and character controllers.
        /// </summary>
        Kinematic,

        /// <summary>
        ///     A dynamic body has positive mass determined by its shape density and area.
        ///     Its motion is determined by applied forces, gravity, and collisions.
        ///     Dynamic bodies provide the most realistic physical behavior.
        /// </summary>
        Dynamic
    }
}