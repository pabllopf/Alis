// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GravityType.cs
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

namespace Alis.Core.Physic.Controllers
{
    /// <summary>
    ///     Defines the gravity calculation model used by the <see cref="GravityController"/>.
    ///     Determines how gravitational force attenuates with distance between bodies.
    /// </summary>
    public enum GravityType
    {
        /// <summary>
        ///     Linear gravity applies a constant gravitational force regardless of distance.
        ///     Suitable for simple top-down or platformer gravity fields.
        /// </summary>
        Linear,

        /// <summary>
        ///     Distance-squared gravity applies an inverse-square attenuation (Newtonian gravity).
        ///     Gravitational force decreases proportionally to the square of the distance,
        ///     suitable for planetary or astrophysical simulations.
        /// </summary>
        DistanceSquared
    }
}