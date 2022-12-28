// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   IBroadPhase.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.Handlers;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Collision.Broadphase
{
    /// <summary>
    ///     The broad phase interface
    /// </summary>
    public interface IBroadPhase
    {
        /// <summary>
        ///     Gets the value of the proxy count
        /// </summary>
        int ProxyCount { get; }

        /// <summary>
        ///     Updates the pairs using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        void UpdatePairs(BroadphaseHandler callback);

        /// <summary>
        ///     Describes whether this instance test overlap
        /// </summary>
        /// <param name="proxyIdA">The proxy id</param>
        /// <param name="proxyIdB">The proxy id</param>
        /// <returns>The bool</returns>
        bool TestOverlap(int proxyIdA, int proxyIdB);

        /// <summary>
        ///     Adds the proxy using the specified proxy
        /// </summary>
        /// <param name="proxy">The proxy</param>
        /// <returns>The int</returns>
        int AddProxy(ref FixtureProxy proxy);

        /// <summary>
        ///     Removes the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        void RemoveProxy(int proxyId);

        /// <summary>
        ///     Moves the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <param name="aabb">The aabb</param>
        /// <param name="displacement">The displacement</param>
        void MoveProxy(int proxyId, ref Aabb aabb, Vector2F displacement);

        /// <summary>
        ///     Gets the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <returns>The fixture proxy</returns>
        FixtureProxy GetProxy(int proxyId);

        /// <summary>
        ///     Touches the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        void TouchProxy(int proxyId);

        /// <summary>
        ///     Gets the fat aabb using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <param name="aabb">The aabb</param>
        void GetFatAabb(int proxyId, out Aabb aabb);

        /// <summary>
        ///     Queries the callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="aabb">The aabb</param>
        void Query(Func<int, bool> callback, ref Aabb aabb);

        /// <summary>
        ///     Rays the cast using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="input">The input</param>
        void RayCast(Func<RayCastInput, int, float> callback, ref RayCastInput input);

        /// <summary>
        ///     Shifts the origin using the specified new origin
        /// </summary>
        /// <param name="newOrigin">The new origin</param>
        void ShiftOrigin(ref Vector2F newOrigin);
    }
}