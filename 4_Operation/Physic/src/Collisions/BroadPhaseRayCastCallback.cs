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
    ///     Callback delegate invoked during a ray-cast query to report intersections with the dynamic tree.
    /// </summary>
    /// <param name="input">The ray-cast input specifying the ray segment and maximum fraction.</param>
    /// <param name="proxyId">The proxy identifier of the AABB intersected by the ray.</param>
    /// <returns>
    ///     The fraction of the ray at which the hit occurred. Return a value less than or equal to 0 to terminate the ray-cast,
    ///     or a value between 0 and the input's max fraction to clip the remaining ray segment.
    /// </returns>
    public delegate float BroadPhaseRayCastCallback(ref RayCastInput input, int proxyId);
}