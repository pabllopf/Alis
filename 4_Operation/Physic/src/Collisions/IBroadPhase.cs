// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IBroadPhase.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Non-generic broad-phase interface typed to <see cref="FixtureProxy"/> for convenience.
    /// </summary>
    /// <seealso cref="IBroadPhase{FixtureProxy}" />
    public interface IBroadPhase : IBroadPhase<FixtureProxy>
    {
    }

    /// <summary>
    ///     Generic interface for broad-phase collision management, providing proxy lifecycle, pair generation, and spatial queries.
    /// </summary>
    public interface IBroadPhase<TNode>
        where TNode : struct
    {
        /// <summary>
        ///     Gets the number of proxies currently registered in the broad phase.
        /// </summary>
        int ProxyCount { get; }

        /// <summary>
        ///     Updates the overlapping pair buffer and invokes the callback for each new pair.
        /// </summary>
        /// <param name="callback">The delegate invoked for each overlapping proxy pair.</param>
        void UpdatePairs(BroadphaseDelegate callback);

        /// <summary>
        ///     Tests whether the fat AABBs of two proxies overlap.
        /// </summary>
        /// <param name="proxyIdA">The first proxy identifier.</param>
        /// <param name="proxyIdB">The second proxy identifier.</param>
        /// <returns><c>true</c> if the fat AABBs intersect; otherwise <c>false</c>.</returns>
        bool TestOverlap(int proxyIdA, int proxyIdB);

        /// <summary>
        ///     Registers a new proxy with the given AABB and returns its identifier.
        /// </summary>
        /// <param name="aabb">The axis-aligned bounding box for the new proxy. This is fattened internally.</param>
        /// <returns>The proxy identifier assigned to the new entry.</returns>
        int AddProxy(ref Aabb aabb);

        /// <summary>
        ///     Removes the proxy with the specified identifier from the broad phase.
        /// </summary>
        /// <param name="proxyId">The proxy identifier to remove.</param>
        void RemoveProxy(int proxyId);

        /// <summary>
        ///     Moves a proxy to a new AABB, re-inserting it if it moved outside its fat AABB.
        /// </summary>
        /// <param name="proxyId">The proxy identifier to move.</param>
        /// <param name="aabb">The new narrow AABB of the proxy.</param>
        /// <param name="displacement">The estimated movement vector for predictive AABB expansion.</param>
        void MoveProxy(int proxyId, ref Aabb aabb, Vector2F displacement);

        /// <summary>
        ///     Associates user data with the specified proxy.
        /// </summary>
        /// <param name="proxyId">The proxy identifier.</param>
        /// <param name="proxy">The user data to store.</param>
        void SetProxy(int proxyId, ref TNode proxy);

        /// <summary>
        ///     Retrieves the user data associated with the specified proxy.
        /// </summary>
        /// <param name="proxyId">The proxy identifier.</param>
        /// <returns>The user data stored with the proxy.</returns>
        TNode GetProxy(int proxyId);

        /// <summary>
        ///     Marks a proxy as moved so it will be re-paired in the next <see cref="UpdatePairs"/> call.
        /// </summary>
        /// <param name="proxyId">The proxy identifier to touch.</param>
        void TouchProxy(int proxyId);

        /// <summary>
        ///     Gets the fat AABB (expanded bounds) for the specified proxy.
        /// </summary>
        /// <param name="proxyId">The proxy identifier.</param>
        /// <param name="aabb">Outputs the fat AABB of the proxy.</param>
        void GetFatAabb(int proxyId, out Aabb aabb);

        /// <summary>
        ///     Queries the broad phase for all proxies whose AABBs overlap the given AABB.
        /// </summary>
        /// <param name="callback">The callback invoked for each overlapping proxy. Return <c>false</c> to stop the query.</param>
        /// <param name="aabb">The query AABB in world coordinates.</param>
        void Query(BroadPhaseQueryCallback callback, ref Aabb aabb);

        /// <summary>
        ///     Ray-casts against all proxies in the broad phase, calling the callback for each intersection.
        /// </summary>
        /// <param name="callback">The callback invoked for each proxy intersected by the ray.</param>
        /// <param name="input">The ray-cast input defining the ray origin, direction, and maximum fraction.</param>
        void RayCast(BroadPhaseRayCastCallback callback, ref RayCastInput input);

        /// <summary>
        ///     Shifts all proxies' AABBs by the given displacement (used when the world origin is moved).
        /// </summary>
        /// <param name="newOrigin">The displacement vector to apply to all AABBs.</param>
        void ShiftOrigin(Vector2F newOrigin);
    }
}