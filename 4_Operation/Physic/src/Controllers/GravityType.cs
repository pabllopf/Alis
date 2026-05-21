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
///     Specifies the type of gravity calculation to be used by controllers.
///     This enumeration defines different gravity models that can be applied
///     to simulate various gravitational behaviors in the physics simulation.
/// </summary>
    public enum GravityType
    {
        /// <summary>
        ///     Linear gravity falloff: force is proportional to 1/r.
        ///     Produces a more uniform gravitational field over distance.
        /// </summary>
        Linear,

        /// <summary>
        ///     Distance-squared gravity falloff: force is proportional to 1/r².
        ///     Follows Newton's law of universal gravitation for realistic planetary gravity simulation.
        /// </summary>
        DistanceSquared
    }
}