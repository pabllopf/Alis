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
    public class DynamicTreeBroadPhase : DynamicTreeBroadPhase<FixtureProxy>, IBroadPhase
    {
    }

    /// <summary>
    ///     The broad-phase is used for computing pairs and performing volume queries and ray casts.
    ///     This broad-phase does not persist pairs. Instead, this reports potentially new pairs.
    ///     It is up to the client to consume the new pairs and to track subsequent overlap.
    /// </summary>
    public class DynamicTreeBroadPhase<TNode> : IBroadPhase<TNode>
        where TNode : struct
    {
        /// <summary>
        ///     The null proxy
        /// </summary>
        private const int NullProxy = -1;

        /// <summary>
        ///     The query callback cache
        /// </summary>
        private readonly BroadPhaseQueryCallback _queryCallbackCache;

        /// <summary>
        ///     The node
        /// </summary>
        private readonly DynamicTree<TNode> _tree = new DynamicTree<TNode>();

        /// <summary>
        ///     The move buffer
        /// </summary>
        private int[] _moveBuffer;

        /// <summary>
        ///     The move capacity
        /// </summary>
        private int _moveCapacity;

        /// <summary>
        ///     The move count
        /// </summary>
        private int _moveCount;

        /// <summary>
        ///     The pair buffer
        /// </summary>
        private Pair[] _pairBuffer;

        /// <summary>
        ///     The pair capacity
        /// </summary>
        private int _pairCapacity;

        /// <summary>
        ///     The pair count
        /// </summary>
        private int _pairCount;

        /// <summary>
        ///     The query proxy id
        /// </summary>
        private int _queryProxyId;

        /// <summary>
        ///     Constructs a new broad phase based on the dynamic tree implementation
        /// </summary>
        public DynamicTreeBroadPhase()
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
        ///     Gets the tree quality metric (ratio of sum of node areas to root area).
        /// </summary>
        public float TreeQuality => _tree.AreaRatio;

        /// <summary>
        ///     Gets the maximum balance (height difference between children) across all tree nodes.
        /// </summary>
        public int TreeBalance => _tree.MaxBalance;

        /// <summary>
        ///     Gets the height of the dynamic tree (root node height).
        /// </summary>
        public int TreeHeight => _tree.Height;

        /// <summary>
        ///     Gets the number of proxies currently registered in the broad phase.
        /// </summary>
        public int ProxyCount { get; private set; }

        /// <summary>
        ///     Adds a new proxy to the broad phase with the given AABB.
        /// </summary>
        /// <param name="aabb">The axis-aligned bounding box for the new proxy.</param>
        /// <returns>The proxy identifier assigned to the newly added proxy.</returns>
        public int AddProxy(ref Aabb aabb)
        {
            int proxyId = _tree.AddProxy(ref aabb);
            ++ProxyCount;
            BufferMove(proxyId);

            return proxyId;
        }

        /// <summary>
        ///     OnDestroy a proxy. It is up to the client to remove any pairs.
        /// </summary>
        /// <param name="proxyId">The proxy id.</param>
        public void RemoveProxy(int proxyId)
        {
            UnBufferMove(proxyId);
            --ProxyCount;
            _tree.RemoveProxy(proxyId);
        }

        /// <summary>
        ///     Moves the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <param name="aabb">The aabb</param>
        /// <param name="displacement">The displacement</param>
        public void MoveProxy(int proxyId, ref Aabb aabb, Vector2F displacement)
        {
            bool buffer = _tree.MoveProxy(proxyId, ref aabb, displacement);
            if (buffer)
            {
                BufferMove(proxyId);
            }
        }

        /// <summary>
        ///     Touches the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        public void TouchProxy(int proxyId)
        {
            BufferMove(proxyId);
        }

        /// <summary>
        ///     Get the AABB for a proxy.
        /// </summary>
        /// <param name="proxyId">The proxy id.</param>
        /// <param name="aabb">The aabb.</param>
        public void GetFatAabb(int proxyId, out Aabb aabb)
        {
            _tree.GetFatAabb(proxyId, out aabb);
        }

        /// <summary>
        ///     Associates user data with a proxy in the broad phase.
        /// </summary>
        /// <param name="proxyId">The proxy identifier.</param>
        /// <param name="proxy">The user data to store with the proxy.</param>
        public void SetProxy(int proxyId, ref TNode proxy)
        {
            _tree.SetUserData(proxyId, proxy);
        }

        /// <summary>
        ///     Gets the user data associated with a proxy.
        /// </summary>
        /// <param name="proxyId">The proxy identifier.</param>
        /// <returns>The user data stored with the proxy.</returns>
        public TNode GetProxy(int proxyId) => _tree.GetUserData(proxyId);

        /// <summary>
        ///     Tests whether the fat AABBs of two proxies overlap.
        /// </summary>
        /// <param name="proxyIdA">The first proxy identifier.</param>
        /// <param name="proxyIdB">The second proxy identifier.</param>
        /// <returns><c>true</c> if the fat AABBs overlap; otherwise <c>false</c>.</returns>
        public bool TestOverlap(int proxyIdA, int proxyIdB) => _tree.TestFatAabbOverlap(proxyIdA, proxyIdB);

        /// <summary>
        ///     Update the pairs. This results in pair callbacks. This can only add pairs.
        /// </summary>
        /// <param name="callback">The callback.</param>
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
        ///     Query an AABB for overlapping proxies. The callback class
        ///     is called for each proxy that overlaps the supplied AABB.
        /// </summary>
        /// <param name="callback">The callback.</param>
        /// <param name="aabb">The aabb.</param>
        public void Query(BroadPhaseQueryCallback callback, ref Aabb aabb)
        {
            _tree.Query(callback, ref aabb);
        }

        /// <summary>
        ///     Ray-cast against the proxies in the tree. This relies on the callback
        ///     to perform a exact ray-cast in the case were the proxy contains a shape.
        ///     The callback also performs the any collision filtering. This has performance
        ///     roughly equal to k * log(n), where k is the number of collisions and n is the
        ///     number of proxies in the tree.
        /// </summary>
        /// <param name="callback">A callback class that is called for each proxy that is hit by the ray.</param>
        /// <param name="input">The ray-cast input data. The ray extends from p1 to p1 + maxFraction * (p2 - p1).</param>
        public void RayCast(BroadPhaseRayCastCallback callback, ref RayCastInput input)
        {
            _tree.RayCast(callback, ref input);
        }

        /// <summary>
        ///     Shifts the origin using the specified new origin
        /// </summary>
        /// <param name="newOrigin">The new origin</param>
        public void ShiftOrigin(Vector2F newOrigin)
        {
            _tree.ShiftOrigin(newOrigin);
        }

        /// <summary>
        ///     Adds a proxy identifier to the move buffer so it will be re-paired in the next <see cref="UpdatePairs"/> call.
        ///     Grows the buffer if capacity is exceeded.
        /// </summary>
        /// <param name="proxyId">The proxy identifier to buffer for re-pairing.</param>
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
        ///     Removes a proxy from the move buffer by marking its entry as <see cref="NullProxy"/>.
        /// </summary>
        /// <param name="proxyId">The proxy identifier to remove from the move buffer.</param>
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
        ///     Internal callback invoked from the dynamic tree query during pair generation.
        ///     Adds the proxy pair to the pair buffer, skipping self-pairing.
        /// </summary>
        /// <param name="proxyId">The proxy identifier found during the tree query.</param>
        /// <returns>Always <c>true</c> to continue querying the tree.</returns>
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