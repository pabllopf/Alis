// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BroadPhaseImplementation.cs
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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.BroadPhase;
using Alis.Core.Physic.Collision.Handlers;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Test.Collision.BroadPhase.Sample
{
    /// <summary>
    ///     The broad phase implementation class
    /// </summary>
    /// <seealso cref="IBroadPhase" />
    public class BroadPhaseImplementation : IBroadPhase
    {
        /// <summary>
        ///     Gets or sets the value of the proxy count
        /// </summary>
        public int ProxyCount { get; private set; }
        
        /// <summary>
        ///     Updates the pairs using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        public void UpdatePairs(BroadPhaseHandler callback)
        {
            // Implement your logic here
        }
        
        /// <summary>
        ///     Describes whether this instance test overlap
        /// </summary>
        /// <param name="proxyIdA">The proxy id</param>
        /// <param name="proxyIdB">The proxy id</param>
        /// <returns>The bool</returns>
        public bool TestOverlap(int proxyIdA, int proxyIdB) =>
            // Implement your logic here
            false;
        
        /// <summary>
        ///     Adds the proxy using the specified proxy
        /// </summary>
        /// <param name="proxy">The proxy</param>
        /// <returns>The int</returns>
        public int AddProxy(ref FixtureProxy proxy)
        {
            // Implement your logic here
            ProxyCount++;
            return ProxyCount - 1;
        }
        
        /// <summary>
        ///     Removes the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        public void RemoveProxy(int proxyId)
        {
            // Implement your logic here
            ProxyCount--;
        }
        
        /// <summary>
        ///     Moves the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <param name="aabb">The aabb</param>
        /// <param name="displacement">The displacement</param>
        public void MoveProxy(int proxyId, ref Aabb aabb, Vector2 displacement)
        {
            // Implement your logic here
        }
        
        /// <summary>
        ///     Gets the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <returns>The fixture proxy</returns>
        public FixtureProxy GetProxy(int proxyId) =>
            // Implement your logic here
            new FixtureProxy();
        
        /// <summary>
        ///     Touches the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        public void TouchProxy(int proxyId)
        {
            // Implement your logic here
        }
        
        /// <summary>
        ///     Gets the fat aabb using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <param name="aabb">The aabb</param>
        public void GetFatAabb(int proxyId, out Aabb aabb)
        {
            // Implement your logic here
            aabb = new Aabb();
        }
        
        /// <summary>
        ///     Queries the callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="aabb">The aabb</param>
        public void Query(Func<int, bool> callback, ref Aabb aabb)
        {
            // Implement your logic here
        }
        
        /// <summary>
        ///     Rays the cast using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="input">The input</param>
        public void RayCast(Func<RayCastInput, int, float> callback, ref RayCastInput input)
        {
            // Implement your logic here
        }
        
        /// <summary>
        ///     Shifts the origin using the specified new origin
        /// </summary>
        /// <param name="newOrigin">The new origin</param>
        public void ShiftOrigin(ref Vector2 newOrigin)
        {
            // Implement your logic here
        }
    }
}