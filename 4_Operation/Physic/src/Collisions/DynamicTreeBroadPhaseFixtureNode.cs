// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DynamicTreeBroadPhase.cs
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
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     The broad-phase is used for computing pairs and performing volume queries and ray casts.
    ///     This broad-phase does not persist pairs. Instead, this reports potentially new pairs.
    ///     It is up to the client to consume the new pairs and to track subsequent overlap.
    /// </summary>
    public class DynamicTreeBroadPhaseFixtureNode : DynamicTreeBroadPhaseFixtureNode<FixtureProxy>, IBroadPhaseFixture
    {
    }

    /// <summary>
    ///     Implements a broad-phase collision detection system using a dynamic bounding volume tree (DynamicTree).
    /// </summary>
    /// <typeparam name="TNode">The type of the proxy node. Must be a struct.</typeparam>
    /// <remarks>
    ///     This broad-phase does not persist pairs. Instead, it reports potentially new pairs during each
    ///     <see cref="UpdatePairs"/> call. It is up to the client to consume the new pairs and track
    ///     subsequent overlap state.
    ///     
    ///     The tree provides efficient spatial queries with O(log n) complexity for most operations,
    ///     where n is the number of proxies. Tree quality can be monitored via <see cref="TreeQuality"/>,
    ///     <see cref="TreeBalance"/>, and <see cref="TreeHeight"/>.
    /// </remarks>
    public class DynamicTreeBroadPhaseFixtureNode<TNode> : IBroadPhaseFixtureNode<TNode>
        where TNode : struct
    {
        /// <summary>
        ///     Gets the constant value representing an invalid/null proxy ID.
        /// </summary>
        /// <value>Always -1.</value>
        private const int NullProxy = -1;

        /// <summary>
        ///     Gets the cached query callback to avoid allocations during pair updates.
        /// </summary>
        private readonly BroadPhaseQueryCallback _queryCallbackCache;

        /// <summary>
        ///     Gets the dynamic tree used for spatial partitioning and collision queries.
        /// </summary>
        private readonly DynamicTree<TNode> _tree = new DynamicTree<TNode>();

        /// <summary>
        ///     Gets or sets the buffer of proxy IDs that have moved and need pair updates.
        /// </summary>
        private int[] _moveBuffer;

        /// <summary>
        ///     Gets or sets the current capacity of the move buffer.
        /// </summary>
        private int _moveCapacity;

        /// <summary>
        ///     Gets or sets the number of entries in the move buffer.
        /// </summary>
        private int _moveCount;

        /// <summary>
        ///     Gets or sets the buffer of pairs detected during pair updates.
        /// </summary>
        private Pair[] _pairBuffer;

        /// <summary>
        ///     Gets or sets the current capacity of the pair buffer.
        /// </summary>
        private int _pairCapacity;

        /// <summary>
        ///     Gets or sets the number of entries in the pair buffer.
        /// </summary>
        private int _pairCount;

        /// <summary>
        ///     Gets or sets the proxy ID currently being queried during pair updates.
        /// </summary>
        private int _queryProxyId;

        /// <summary>
        ///     Constructs a new broad-phase based on the dynamic tree implementation.
        /// </summary>
        /// <remarks>
        ///     Initializes the broad-phase with default buffer capacities of 16 entries
        ///     for both move and pair buffers. The proxy count starts at zero.
        /// </remarks>
        public DynamicTreeBroadPhaseFixtureNode()
        {
            _queryCallbackCache = QueryCallback;
            ProxyCount = 0;

            _pairCapacity = 16;
            _pairCount = 0;
            _pairBuffer = new Pair[_pairCapacity];

            _moveCapacity = 16;
            _moveCount = 0;
            _moveBuffer = new int[_moveCapacity];
        }

        /// <summary>
        ///     Gets the tree quality based on the area of the tree.
        /// </summary>
        /// <value>
        ///     A <see cref="float"/> representing the ratio of the total area of all leaf nodes to the area of the root node.
        ///     Lower values indicate better tree quality (closer to 1.0 is ideal).
        /// </value>
        public float TreeQuality => _tree.AreaRatio;

        /// <summary>
        ///     Gets the balance of the tree.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the maximum balance of any node in the tree.
        ///     Lower values indicate a more balanced tree (0 means perfectly balanced).
        /// </value>
        public int TreeBalance => _tree.MaxBalance;

        /// <summary>
        ///     Gets the height of the tree.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the maximum distance from the root to any leaf node.
        ///     Lower values indicate faster query performance.
        /// </value>
        public int TreeHeight => _tree.Height;

        /// <summary>
        ///     Gets the number of proxies currently managed by this broad-phase.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the count of active proxies.
        /// </value>
        public int ProxyCount { get; private set; }

        /// <summary>
        ///     Adds a new proxy with the specified axis-aligned bounding box.
        /// </summary>
        /// <param name="aabb">The axis-aligned bounding box of the proxy to add.</param>
        /// <returns>
        ///     An <see cref="int"/> representing the ID of the newly added proxy.
        /// </returns>
        public int AddProxy(ref Aabb aabb)
        {
            int proxyId = _tree.AddProxy(ref aabb);
            ++ProxyCount;
            BufferMove(proxyId);

            return proxyId;
        }

        /// <summary>
        ///     Removes a proxy from the broad-phase. It is up to the client to remove any pairs.
        /// </summary>
        /// <param name="proxyId">The ID of the proxy to remove.</param>
        public void RemoveProxy(int proxyId)
        {
            UnBufferMove(proxyId);
            --ProxyCount;
            _tree.RemoveProxy(proxyId);
        }

        /// <summary>
        ///     Moves a proxy to a new position and optionally applies displacement.
        /// </summary>
        /// <param name="proxyId">The ID of the proxy to move.</param>
        /// <param name="aabb">The new axis-aligned bounding box for the proxy.</param>
        /// <param name="displacement">The displacement vector applied to the proxy's position.</param>
        public void MoveProxy(int proxyId, ref Aabb aabb, Vector2F displacement)
        {
            bool buffer = _tree.MoveProxy(proxyId, ref aabb, displacement);
            if (buffer)
            {
                BufferMove(proxyId);
            }
        }

        /// <summary>
        ///     Marks a proxy as touched, indicating it has been modified and needs pair updates.
        /// </summary>
        /// <param name="proxyId">The ID of the proxy to touch.</param>
        public void TouchProxy(int proxyId)
        {
            BufferMove(proxyId);
        }

        /// <summary>
        ///     Gets the fat AABB (expanded bounding box) for a given proxy.
        /// </summary>
        /// <param name="proxyId">The ID of the proxy.</param>
        /// <param name="aabb">When this method returns, contains the fat AABB of the proxy.</param>
        public void GetFatAabb(int proxyId, out Aabb aabb)
        {
            _tree.GetFatAabb(proxyId, out aabb);
        }

        /// <summary>
        ///     Sets or updates the proxy node data for a given proxy ID.
        /// </summary>
        /// <param name="proxyId">The ID of the proxy to update.</param>
        /// <param name="proxy">The proxy node data to set.</param>
        public void SetProxy(int proxyId, ref TNode proxy)
        {
            _tree.SetUserData(proxyId, proxy);
        }

        /// <summary>
        ///     Gets the proxy node data for a given proxy ID.
        /// </summary>
        /// <param name="proxyId">The ID of the proxy to retrieve.</param>
        /// <returns>
        ///     The <typeparamref name="TNode"/> proxy node data, or default if the ID is invalid.
        /// </returns>
        public TNode GetProxy(int proxyId) => _tree.GetUserData(proxyId);

        /// <summary>
        ///     Tests whether two proxies overlap based on their fat AABBs.
        /// </summary>
        /// <param name="proxyIdA">The proxy ID of the first proxy.</param>
        /// <param name="proxyIdB">The proxy ID of the second proxy.</param>
        /// <returns>
        ///     <c>true</c> if the proxies' fat AABBs overlap; otherwise, <c>false</c>.
        /// </returns>
        public bool TestOverlap(int proxyIdA, int proxyIdB) => _tree.TestFatAabbOverlap(proxyIdA, proxyIdB);

        /// <summary>
        ///     Updates the pairs. This results in pair callbacks. This can only add pairs.
        /// </summary>
        /// <param name="callback">The callback to invoke for each detected pair.</param>
        public void UpdatePairs(BroadphaseDelegate callback)
        {
            // Reset pair buffer
            _pairCount = 0;

            // Perform tree queries for all moving proxies.
            for (int j = 0; j < _moveCount; ++j)
            {
                _queryProxyId = _moveBuffer[j];
                if (_queryProxyId == NullProxy)
                {
                    continue;
                }

                // We have to query the tree with the fat AABB so that
                // we don't fail to create a pair that may touch later.
                Aabb fatAabb = _tree.GetFatAabb(_queryProxyId);

                // Query tree, create pairs and add them pair buffer.
                _tree.Query(_queryCallbackCache, ref fatAabb);
            }

            // Reset move buffer
            _moveCount = 0;

            // Sort the pair buffer to expose duplicates.
            Array.Sort(_pairBuffer, 0, _pairCount);

            // Send the pairs back to the client.
            int i = 0;
            if (_pairCount <= 0)
            {
                return;
            }

            while (i < _pairCount)
            {
                Pair primaryPair = _pairBuffer[i];

                callback(primaryPair.ProxyIdA, primaryPair.ProxyIdB);
                ++i;

                // Skip any duplicate pairs.
                while (i < _pairCount)
                {
                    Pair pair = _pairBuffer[i];
                    if (pair.ProxyIdA != primaryPair.ProxyIdA || pair.ProxyIdB != primaryPair.ProxyIdB)
                    {
                        break;
                    }

                    ++i;
                }
            }
        }

        /// <summary>
        ///     Queries an AABB for overlapping proxies. The callback is called for each proxy that overlaps the supplied AABB.
        /// </summary>
        /// <param name="callback">A callback invoked for each overlapping proxy.</param>
        /// <param name="aabb">The AABB to query against all proxies.</param>
        public void Query(BroadPhaseQueryCallback callback, ref Aabb aabb)
        {
            _tree.Query(callback, ref aabb);
        }

        /// <summary>
        ///     Ray-casts against the proxies in the tree. This relies on the callback to perform an exact ray-cast
        ///     in the case where the proxy contains a shape. The callback also performs any collision filtering.
        ///     This has performance roughly equal to O(k * log(n)), where k is the number of collisions and n is
        ///     the number of proxies in the tree.
        /// </summary>
        /// <param name="callback">A callback class that is called for each proxy that is hit by the ray.</param>
        /// <param name="input">The ray-cast input data. The ray extends from p1 to p1 + maxFraction * (p2 - p1).</param>
        public void RayCast(BroadPhaseRayCastCallback callback, ref RayCastInput input)
        {
            _tree.RayCast(callback, ref input);
        }

        /// <summary>
        ///     Shifts the origin of the broad-phase coordinate system.
        /// </summary>
        /// <param name="newOrigin">The new origin vector for the coordinate system.</param>
        public void ShiftOrigin(Vector2F newOrigin)
        {
            _tree.ShiftOrigin(newOrigin);
        }

        /// <summary>
        ///     Buffers a proxy ID for pair update processing.
        /// </summary>
        /// <param name="proxyId">The proxy ID to buffer.</param>
        /// <remarks>
        ///     If the move buffer is full, it is doubled in capacity before adding the proxy ID.
        /// </remarks>
        private void BufferMove(int proxyId)
        {
            if (_moveCount == _moveCapacity)
            {
                int[] oldBuffer = _moveBuffer;
                _moveCapacity *= 2;
                _moveBuffer = new int[_moveCapacity];
                Array.Copy(oldBuffer, _moveBuffer, _moveCount);
            }

            _moveBuffer[_moveCount] = proxyId;
            ++_moveCount;
        }

        /// <summary>
        ///     Removes a proxy ID from the move buffer by marking it as null.
        /// </summary>
        /// <param name="proxyId">The proxy ID to remove from the buffer.</param>
        /// <remarks>
        ///     The proxy ID is not physically removed from the array; instead, it is marked as <see cref="NullProxy"/>
        ///     to indicate it should be skipped during pair updates.
        /// </remarks>
        private void UnBufferMove(int proxyId)
        {
            for (int i = 0; i < _moveCount; ++i)
            {
                if (_moveBuffer[i] == proxyId)
                {
                    _moveBuffer[i] = NullProxy;
                }
            }
        }

        /// <summary>
        ///     This is called from DynamicTree.Query when we are gathering pairs.
        /// </summary>
        /// <param name="proxyId">The ID of a proxy that potentially overlaps with <see cref="_queryProxyId"/>.</param>
        /// <returns>
        ///     <c>true</c> to continue the query; <c>false</c> to terminate early.
        /// </returns>
        /// <remarks>
        ///     A proxy cannot form a pair with itself. The pair buffer is grown as needed to accommodate new pairs.
        ///     Proxy IDs are stored in sorted order (min, max) to facilitate duplicate detection.
        /// </remarks>
        private bool QueryCallback(int proxyId)
        {
            // A proxy cannot form a pair with itself.
            if (proxyId == _queryProxyId)
            {
                return true;
            }

            // Grow the pair buffer as needed.
            if (_pairCount == _pairCapacity)
            {
                Pair[] oldBuffer = _pairBuffer;
                _pairCapacity *= 2;
                _pairBuffer = new Pair[_pairCapacity];
                Array.Copy(oldBuffer, _pairBuffer, _pairCount);
            }

            _pairBuffer[_pairCount].ProxyIdA = Math.Min(proxyId, _queryProxyId);
            _pairBuffer[_pairCount].ProxyIdB = Math.Max(proxyId, _queryProxyId);
            ++_pairCount;

            return true;
        }
    }
}