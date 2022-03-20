// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BroadPhase.cs
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

/*
This broad phase uses the Sweep and Prune algorithm as described in:
Collision Detection in Interactive 3D Environments by Gino van den Bergen
Also, some ideas, such as using integral values for fast compares comes from
Bullet (http:/www.bulletphysics.com).
*/

// Notes:
// - we use bound arrays instead of linked lists for cache coherence.
// - we use quantized integral values for fast compares.
// - we use short indices rather than pointers to save memory.
// - we use a stabbing count for fast overlap queries (less than order N).
// - we also use a time stamp on each proxy to speed up the registration of
//   overlap query results.
// - where possible, we compare bound indices instead of values to reduce
//   cache misses (TODO_ERIN).
// - no broadphase is perfect and neither is this one: it is not great for huge
//   worlds (use a multi-SAP instead), it is not great for large objects.

#define ALLOWUNSAFE
//#define TARGET_FLOAT32_IS_FIXED

using System;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Alis.Core.Physics2D.Collision
{
    /// <summary>
    /// The broad phase class
    /// </summary>
    internal class BroadPhase
    {
        /// <summary>
        /// The tree
        /// </summary>
        private readonly DynamicTree m_tree;
        /// <summary>
        /// The movebuffer
        /// </summary>
        private int[] m_moveBuffer;
        /// <summary>
        /// The movecapacity
        /// </summary>
        private int m_moveCapacity;
        /// <summary>
        /// The movecount
        /// </summary>
        private int m_moveCount;
        /// <summary>
        /// The pairbuffer
        /// </summary>
        private Pair[] m_pairBuffer;
        /// <summary>
        /// The paircapacity
        /// </summary>
        private int m_pairCapacity;
        /// <summary>
        /// The paircount
        /// </summary>
        private int m_pairCount;

        /// <summary>
        /// The proxycount
        /// </summary>
        private int m_proxyCount;
        /// <summary>
        /// The queryproxyid
        /// </summary>
        private int m_queryProxyId;

        /// <summary>
        /// Initializes a new instance of the <see cref="BroadPhase"/> class
        /// </summary>
        public BroadPhase()
        {
            m_proxyCount = 0;

            m_pairCapacity = 16;
            m_pairCount = 0;
            m_pairBuffer = new Pair[m_pairCapacity];

            m_moveCapacity = 16;
            m_moveCount = 0;
            m_moveBuffer = new int[m_moveCapacity];

            m_tree = new DynamicTree();
        }

        /// <summary>
        /// Gets the user data using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <returns>The object</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal object GetUserData(int proxyId) => m_tree.GetUserData(proxyId);

        /// <summary>
        /// Describes whether this instance test overlap
        /// </summary>
        /// <param name="proxyIdA">The proxy id</param>
        /// <param name="proxyIdB">The proxy id</param>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool TestOverlap(int proxyIdA, int proxyIdB)
        {
            AABB aabbA = m_tree.GetFatAABB(proxyIdA);
            AABB aabbB = m_tree.GetFatAABB(proxyIdB);
            return Collision.TestOverlap(aabbA, aabbB);
        }

        /// <summary>
        /// Gets the fat aabb using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <returns>The aabb</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public AABB GetFatAABB(int proxyId) => m_tree.GetFatAABB(proxyId);

        /// <summary>
        /// Gets the proxy count
        /// </summary>
        /// <returns>The int</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetProxyCount() => m_proxyCount;

        /// <summary>
        /// Gets the tree height
        /// </summary>
        /// <returns>The int</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int GetTreeHeight() => m_tree.Height;

        /// <summary>
        /// Updates the pairs using the specified add pair
        /// </summary>
        /// <param name="AddPair">The add pair</param>
        public void UpdatePairs(Action<object, object> AddPair)
        {
            m_pairCount = 0;

            for (int i = 0; i < m_moveCount; ++i)
            {
                m_queryProxyId = m_moveBuffer[i];
                if (m_queryProxyId == -1)
                {
                    continue;
                }

                AABB fatAABB = m_tree.GetFatAABB(m_queryProxyId);

                m_tree.Query(QueryCallback, fatAABB);
            }

            for (int i = 0; i < m_pairCount; ++i)
            {
                Pair primaryPair = m_pairBuffer[i];
                object userDataA = m_tree.GetUserData(primaryPair.proxyIdA);
                object userDataB = m_tree.GetUserData(primaryPair.proxyIdB);
                AddPair(userDataA, userDataB);
            }

            for (int i = 0; i < m_moveCount; ++i)
            {
                int proxyId = m_moveBuffer[i];
                if (proxyId == -1)
                {
                    continue;
                }

                m_tree.ClearMoved(proxyId);
            }

            m_moveCount = 0;
        }

        /// <summary>
        /// Queries the query callback
        /// </summary>
        /// <param name="queryCallback">The query callback</param>
        /// <param name="aabb">The aabb</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Query(Func<int, bool> queryCallback, in AABB aabb)
        {
            m_tree.Query(queryCallback, in aabb);
        }

        /// <summary>
        /// Rays the cast using the specified ray cast callback
        /// </summary>
        /// <param name="RayCastCallback">The ray cast callback</param>
        /// <param name="input">The input</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void RayCast(Func<RayCastInput, int, float> RayCastCallback, in RayCastInput input)
        {
            m_tree.RayCast(RayCastCallback, in input);
        }

        /// <summary>
        /// Shifts the origin using the specified new origin
        /// </summary>
        /// <param name="newOrigin">The new origin</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ShiftOrigin(in Vector2 newOrigin)
        {
            m_tree.ShiftOrigin(in newOrigin);
        }

        /// <summary>
        /// Creates the proxy using the specified aabb
        /// </summary>
        /// <param name="aabb">The aabb</param>
        /// <param name="userData">The user data</param>
        /// <returns>The proxy id</returns>
        public int CreateProxy(in AABB aabb, object userData)
        {
            int proxyId = m_tree.CreateProxy(aabb, userData);
            ++m_proxyCount;
            BufferMove(proxyId);
            return proxyId;
        }

        /// <summary>
        /// Destroys the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        public void DestroyProxy(int proxyId)
        {
            UnBufferMove(proxyId);
            --m_proxyCount;
            m_tree.DestroyProxy(proxyId);
        }

        // Call MoveProxy as many times as you like, then when you are done
        // call Commit to finalize the proxy pairs (for your time step).
        /// <summary>
        /// Moves the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <param name="aabb">The aabb</param>
        /// <param name="displacement">The displacement</param>
        public void MoveProxy(int proxyId, in AABB aabb, in Vector2 displacement)
        {
            bool buffer = m_tree.MoveProxy(proxyId, aabb, displacement);
            if (buffer)
            {
                BufferMove(proxyId);
            }
        }

        /// <summary>
        /// Touches the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        internal void TouchProxy(int proxyId)
        {
            BufferMove(proxyId);
        }


        /// <summary>
        /// Buffers the move using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        private void BufferMove(int proxyId)
        {
            if (m_moveCount == m_moveCapacity)
            {
                int[] oldBuffer = m_moveBuffer;
                m_moveCapacity *= 2;
                m_moveBuffer = new int[m_moveCapacity];
                Array.Copy(oldBuffer, m_moveBuffer, m_moveCount);
            }

            m_moveBuffer[m_moveCount] = proxyId;
            ++m_moveCount;
        }

        /// <summary>
        /// Uns the buffer move using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        private void UnBufferMove(int proxyId)
        {
            for (int i = 0; i < m_moveCount; ++i)
            {
                if (m_moveBuffer[i] == proxyId)
                {
                    m_moveBuffer[i] = -1;
                }
            }
        }

        /// <summary>
        /// Describes whether this instance query callback
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <returns>The bool</returns>
        private bool QueryCallback(int proxyId)
        {
            // A proxy cannot form a pair with itself.
            if (proxyId == m_queryProxyId)
            {
                return true;
            }

            bool moved = m_tree.WasMoved(proxyId);
            if (moved && proxyId > m_queryProxyId)
                // Both proxies are moving. Avoid duplicate pairs.
            {
                return true;
            }

            // Grow the pair buffer as needed.
            if (m_pairCount == m_pairCapacity)
            {
                Pair[] oldBuffer = m_pairBuffer;
                m_pairCapacity = m_pairCapacity + (m_pairCapacity >> 1);
                m_pairBuffer = new Pair[m_pairCapacity];
                Array.Copy(oldBuffer, m_pairBuffer, m_pairCount);
            }

            m_pairBuffer[m_pairCount].proxyIdA = Math.Min(proxyId, m_queryProxyId);
            m_pairBuffer[m_pairCount].proxyIdB = Math.Max(proxyId, m_queryProxyId);
            ++m_pairCount;

            return true;
        }
    }
}