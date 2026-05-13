// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BroadPhaseRayCastCallback.cs
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

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Represents a callback that is invoked for each proxy intersected by a ray during a ray cast against the broad-phase
    ///     tree. The callback reports the ray intersection input and proxy identifier, and returns the fraction of the ray
    ///     at which the intersection occurred. A return value of zero terminates the ray cast early.
    /// </summary>
    /// <param name="input">The ray-cast input data describing the ray origin, direction, and maximum fraction.</param>
    /// <param name="proxyId">The proxy identifier of the node intersected by the ray.</param>
    /// <returns>
    ///     The fraction of the ray at which the intersection occurs. A value of zero signals the client to terminate
    ///     the ray cast. Positive values update the ray casting bounds to the specified fraction.
    /// </returns>
    public delegate float BroadPhaseRayCastCallback(ref RayCastInput input, int proxyId);
}