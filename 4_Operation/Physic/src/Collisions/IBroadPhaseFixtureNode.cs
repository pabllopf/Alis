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

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Defines the contract for a broad-phase collision detection system that manages proxy nodes.
    /// </summary>
    /// <typeparam name="TNode">The type of the proxy node. Must be a struct.</typeparam>
    public interface IBroadPhaseFixtureNode<TNode>
        where TNode : struct
    {
        /// <summary>
        ///     Gets the number of proxies currently managed by this broad-phase.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the count of active proxies.
        /// </value>
        int ProxyCount { get; }

        /// <summary>
        ///     Notifies the broad-phase of active proxy pairs for contact processing.
        /// </summary>
        /// <param name="callback">A <see cref="BroadphaseDelegate"/> callback invoked for each active pair.</param>
        /// <remarks>
        ///     This method is called during the collision detection phase to notify the contact manager
        ///     of pairs that may be overlapping. The callback receives the proxy IDs for each pair.
        /// </remarks>
        void UpdatePairs(BroadphaseDelegate callback);

        /// <summary>
        ///     Tests whether two proxies overlap based on their axis-aligned bounding boxes.
        /// </summary>
        /// <param name="proxyIdA">The proxy ID of the first proxy.</param>
        /// <param name="proxyIdB">The proxy ID of the second proxy.</param>
        /// <returns>
        ///     <c>true</c> if the proxies' AABBs overlap; otherwise, <c>false</c>.
        /// </returns>
        bool TestOverlap(int proxyIdA, int proxyIdB);

        /// <summary>
        ///     Adds a new proxy with the specified axis-aligned bounding box.
        /// </summary>
        /// <param name="aabb">The axis-aligned bounding box of the proxy to add.</param>
        /// <returns>
        ///     An <see cref="int"/> representing the ID of the newly added proxy.
        /// </returns>
        int AddProxy(ref Aabb aabb);

        /// <summary>
        ///     Removes a proxy from the broad-phase.
        /// </summary>
        /// <param name="proxyId">The ID of the proxy to remove.</param>
        void RemoveProxy(int proxyId);

        /// <summary>
        ///     Moves a proxy to a new position and optionally applies displacement.
        /// </summary>
        /// <param name="proxyId">The ID of the proxy to move.</param>
        /// <param name="aabb">The new axis-aligned bounding box for the proxy.</param>
        /// <param name="displacement">The displacement vector applied to the proxy's position.</param>
        void MoveProxy(int proxyId, ref Aabb aabb, Vector2F displacement);

        /// <summary>
        ///     Sets or updates the proxy node data for a given proxy ID.
        /// </summary>
        /// <param name="proxyId">The ID of the proxy to update.</param>
        /// <param name="proxy">The proxy node data to set.</param>
        void SetProxy(int proxyId, ref TNode proxy);

        /// <summary>
        ///     Gets the proxy node data for a given proxy ID.
        /// </summary>
        /// <param name="proxyId">The ID of the proxy to retrieve.</param>
        /// <returns>
        ///     The <typeparamref name="TNode"/> proxy node data.
        /// </returns>
        TNode GetProxy(int proxyId);

        /// <summary>
        ///     Marks a proxy as touched, indicating it has been modified and needs pair updates.
        /// </summary>
        /// <param name="proxyId">The ID of the proxy to touch.</param>
        void TouchProxy(int proxyId);

        /// <summary>
        ///     Gets the fat AABB (expanded bounding box) for a given proxy.
        /// </summary>
        /// <param name="proxyId">The ID of the proxy.</param>
        /// <param name="aabb">When this method returns, contains the fat AABB of the proxy.</param>
        void GetFatAabb(int proxyId, out Aabb aabb);

        /// <summary>
        ///     Queries all proxies whose AABBs overlap the specified query AABB.
        /// </summary>
        /// <param name="callback">A <see cref="BroadPhaseQueryCallback"/> invoked for each overlapping proxy.</param>
        /// <param name="aabb">The query AABB to test against all proxies.</param>
        void Query(BroadPhaseQueryCallback callback, ref Aabb aabb);

        /// <summary>
        ///     Performs a ray cast against all proxies and invokes the callback for each hit.
        /// </summary>
        /// <param name="callback">A <see cref="BroadPhaseRayCastCallback"/> invoked for each proxy hit by the ray.</param>
        /// <param name="input">The <see cref="RayCastInput"/> defining the ray's origin and direction.</param>
        void RayCast(BroadPhaseRayCastCallback callback, ref RayCastInput input);

        /// <summary>
        ///     Shifts the origin of the broad-phase coordinate system.
        /// </summary>
        /// <param name="newOrigin">The new origin vector for the coordinate system.</param>
        /// <remarks>
        ///     This is used to maintain numerical precision when the simulation world moves far from the origin.
        ///     All proxy positions and AABBs are adjusted relative to the new origin.
        /// </remarks>
        void ShiftOrigin(Vector2F newOrigin);
    }
}