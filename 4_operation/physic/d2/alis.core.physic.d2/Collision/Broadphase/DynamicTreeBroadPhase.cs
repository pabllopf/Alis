// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   DynamicTreeBroadPhase.cs
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
using System.Numerics;
using Alis.Core.Systems.Physics2D.Collision.Handlers;
using Alis.Core.Systems.Physics2D.Collision.RayCast;
using Alis.Core.Systems.Physics2D.Dynamics;
using Alis.Core.Systems.Physics2D.Shared;

namespace Alis.Core.Systems.Physics2D.Collision.Broadphase
{
    /// <summary>
    ///     The broad-phase is used for computing pairs and performing volume queries and ray casts. This broad-phase does
    ///     not persist pairs. Instead, this reports potentially new pairs. It is up to the client to consume the new pairs and
    ///     to
    ///     track subsequent overlap.
    /// </summary>
    public class DynamicTreeBroadPhase : IBroadPhase
    {
        /// <summary>
        ///     The null proxy
        /// </summary>
        public const int NullProxy = -1;

        /// <summary>
        ///     The query callback
        /// </summary>
        private readonly Func<int, bool> queryCallback;

        /// <summary>
        ///     The fixture proxy
        /// </summary>
        private readonly DynamicTree<FixtureProxy> tree = new DynamicTree<FixtureProxy>();

        /// <summary>
        ///     The move buffer
        /// </summary>
        private int[] moveBuffer;

        /// <summary>
        ///     The move capacity
        /// </summary>
        private int moveCapacity;

        /// <summary>
        ///     The move count
        /// </summary>
        private int moveCount;

        /// <summary>
        ///     The pair buffer
        /// </summary>
        private Pair[] pairBuffer;

        /// <summary>
        ///     The pair capacity
        /// </summary>
        private int pairCapacity;

        /// <summary>
        ///     The pair count
        /// </summary>
        private int pairCount;

        /// <summary>
        ///     The proxy count
        /// </summary>
        private int proxyCount;

        /// <summary>
        ///     The query proxy id
        /// </summary>
        private int queryProxyId;

        /// <summary>Constructs a new broad phase based on the dynamic tree implementation</summary>
        public DynamicTreeBroadPhase()
        {
            queryCallback = QueryCallback;
            proxyCount = 0;

            pairCapacity = 16;
            pairCount = 0;
            pairBuffer = new Pair[pairCapacity];

            moveCapacity = 16;
            moveCount = 0;
            moveBuffer = new int[moveCapacity];
        }

        /// <summary>Get the tree quality based on the area of the tree.</summary>
        public float TreeQuality => tree.AreaRatio;

        /// <summary>Gets the height of the tree.</summary>
        public int TreeHeight => tree.Height;

        /// <summary>Get the number of proxies.</summary>
        /// <value>The proxy count.</value>
        public int ProxyCount => proxyCount;

        /// <summary>Create a proxy with an initial AABB. Pairs are not reported until UpdatePairs is called.</summary>
        /// <param name="proxy">The user data.</param>
        /// <returns></returns>
        public int AddProxy(ref FixtureProxy proxy)
        {
            int proxyId = tree.CreateProxy(ref proxy.Aabb, proxy);
            ++proxyCount;
            BufferMove(proxyId);
            return proxyId;
        }

        /// <summary>Destroy a proxy. It is up to the client to remove any pairs.</summary>
        /// <param name="proxyId">The proxy id.</param>
        public void RemoveProxy(int proxyId)
        {
            UnBufferMove(proxyId);
            --proxyCount;
            tree.DestroyProxy(proxyId);
        }

        /// <summary>
        ///     Call MoveProxy as many times as you like, then when you are done call UpdatePairs to finalized the proxy pairs
        ///     (for your time step).
        /// </summary>
        public void MoveProxy(int proxyId, ref Aabb aabb, Vector2 displacement)
        {
            bool buffer = tree.MoveProxy(proxyId, ref aabb, displacement);
            if (buffer)
            {
                BufferMove(proxyId);
            }
        }

        /// <summary>Call to trigger a re-processing of it's pairs on the next call to UpdatePairs.</summary>
        public void TouchProxy(int proxyId)
        {
            BufferMove(proxyId);
        }

        /// <summary>Get the AABB for a proxy.</summary>
        /// <param name="proxyId">The proxy id.</param>
        /// <param name="aabb">The AABB.</param>
        public void GetFatAabb(int proxyId, out Aabb aabb)
        {
            tree.GetFatAabb(proxyId, out aabb);
        }

        /// <summary>Get user data from a proxy. Returns null if the id is invalid.</summary>
        /// <param name="proxyId">The proxy id.</param>
        /// <returns></returns>
        public FixtureProxy GetProxy(int proxyId)
        {
            return tree.GetUserData(proxyId);
        }

        /// <summary>Test overlap of fat AABBs.</summary>
        /// <param name="proxyIdA">The proxy id A.</param>
        /// <param name="proxyIdB">The proxy id B.</param>
        /// <returns></returns>
        public bool TestOverlap(int proxyIdA, int proxyIdB)
        {
            tree.GetFatAabb(proxyIdA, out Aabb aabbA);
            tree.GetFatAabb(proxyIdB, out Aabb aabbB);
            return Aabb.TestOverlap(ref aabbA, ref aabbB);
        }

        /// <summary>Update the pairs. This results in pair callbacks. This can only add pairs.</summary>
        /// <param name="callback">The callback.</param>
        public void UpdatePairs(BroadphaseHandler callback)
        {
            // Reset pair buffer
            pairCount = 0;

            // Perform tree queries for all moving proxies.
            for (int i = 0; i < moveCount; ++i)
            {
                queryProxyId = moveBuffer[i];
                if (queryProxyId == NullProxy)
                {
                    continue;
                }

                // We have to query the tree with the fat AABB so that
                // we don't fail to create a pair that may touch later.
                tree.GetFatAabb(queryProxyId, out Aabb fatAabb);

                // Query tree, create pairs and add them pair buffer.
                tree.Query(queryCallback, ref fatAabb);
            }

            for (int i = 0; i < pairCount; ++i)
            {
                Pair primaryPair = pairBuffer[i];
                FixtureProxy userDataA = tree.GetUserData(primaryPair.ProxyIdA);
                FixtureProxy userDataB = tree.GetUserData(primaryPair.ProxyIdB);

                callback(ref userDataA, ref userDataB);
            }

            // Clear move flags
            for (int i = 0; i < moveCount; ++i)
            {
                int proxyId = moveBuffer[i];
                if (proxyId == NullProxy)
                {
                    continue;
                }

                tree.ClearMoved(proxyId);
            }

            // Reset move buffer
            moveCount = 0;
        }

        /// <summary>
        ///     Query an AABB for overlapping proxies. The callback class is called for each proxy that overlaps the supplied
        ///     AABB.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="aabb">The AABB.</param>
        public void Query(Func<int, bool> callback, ref Aabb aabb)
        {
            tree.Query(callback, ref aabb);
        }

        /// <summary>
        ///     Ray-cast against the proxies in the tree. This relies on the callback to perform a exact ray-cast in the case
        ///     were the proxy contains a shape. The callback also performs the any collision filtering. This has performance
        ///     roughly
        ///     equal to k * log(n), where k is the number of collisions and n is the number of proxies in the tree.
        /// </summary>
        /// <param name="callback">A callback class that is called for each proxy that is hit by the ray.</param>
        /// <param name="input">The ray-cast input data. The ray extends from p1 to p1 + maxFraction * (p2 - p1).</param>
        public void RayCast(Func<RayCastInput, int, float> callback, ref RayCastInput input)
        {
            tree.RayCast(callback, ref input);
        }

        /// <summary>Shift the world origin. Useful for large worlds.</summary>
        public void ShiftOrigin(ref Vector2 newOrigin)
        {
            tree.ShiftOrigin(ref newOrigin);
        }

        /// <summary>
        ///     Buffers the move using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        private void BufferMove(int proxyId)
        {
            if (moveCount == moveCapacity)
            {
                int[] oldBuffer = moveBuffer;
                moveCapacity *= 2;
                moveBuffer = new int[moveCapacity];
                Array.Copy(oldBuffer, moveBuffer, moveCount);
            }

            moveBuffer[moveCount] = proxyId;
            ++moveCount;
        }

        /// <summary>
        ///     Uns the buffer move using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        private void UnBufferMove(int proxyId)
        {
            for (int i = 0; i < moveCount; ++i)
            {
                if (moveBuffer[i] == proxyId)
                {
                    moveBuffer[i] = NullProxy;
                }
            }
        }

        /// <summary>This is called from DynamicTree.Query when we are gathering pairs.</summary>
        private bool QueryCallback(int proxyId)
        {
            // A proxy cannot form a pair with itself.
            if (proxyId == queryProxyId)
            {
                return true;
            }

            bool moved = tree.WasMoved(proxyId);
            if (moved && proxyId > queryProxyId)
            {
                // Both proxies are moving. Avoid duplicate pairs.
                return true;
            }

            // Grow the pair buffer as needed.
            if (pairCount == pairCapacity)
            {
                Pair[] oldBuffer = pairBuffer;
                pairCapacity += pairCapacity >> 1;
                pairBuffer = new Pair[pairCapacity];
                Array.Copy(oldBuffer, pairBuffer, pairCount);
            }

            pairBuffer[pairCount].ProxyIdA = Math.Min(proxyId, queryProxyId);
            pairBuffer[pairCount].ProxyIdB = Math.Max(proxyId, queryProxyId);
            ++pairCount;

            return true;
        }
    }
}