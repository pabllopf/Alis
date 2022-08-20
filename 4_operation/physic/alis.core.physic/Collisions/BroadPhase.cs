// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BroadPhase.cs
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

using Alis.Aspect.Logging;
using Alis.Aspect.Math;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     The broad phase class
    /// </summary>
    public class BroadPhase
    {
#if TARGET_FLOAT32_IS_FIXED
		public static readonly ushort BROADPHASE_MAX = (Common.Math.USHRT_MAX/2);
#else
        /// <summary>
        ///     The max
        /// </summary>
        private static readonly ushort BroadphaseMax = Math.UshrtMax;
#endif

        /// <summary>
        ///     The broadphase max
        /// </summary>
        public static readonly ushort Invalid = BroadphaseMax;

        /// <summary>
        ///     The broadphase max
        /// </summary>
        public static readonly ushort NullEdge = BroadphaseMax;

        /// <summary>
        ///     The pair manager
        /// </summary>
        public readonly PairManager PairManager;

        /// <summary>
        ///     The max proxies
        /// </summary>
        public readonly Proxy[] ProxyPool = new Proxy[Settings.MaxProxies];

        /// <summary>
        ///     The free proxy
        /// </summary>
        private ushort freeProxy;

        /// <summary>
        ///     The bound
        /// </summary>
        public readonly Bound[][] Bounds = new Bound[2][ /*(2 * Settings.MaxProxies)*/];

        /// <summary>
        ///     The max proxies
        /// </summary>
        public readonly ushort[] QueryResults = new ushort[Settings.MaxProxies];

        /// <summary>
        ///     The max proxies
        /// </summary>
        public readonly float[] QuerySortKeys = new float[Settings.MaxProxies];

        /// <summary>
        ///     The query result count
        /// </summary>
        public int QueryResultCount;

        /// <summary>
        ///     The world aabb
        /// </summary>
        public Aabb WorldAabb;

        /// <summary>
        ///     The quantization factor
        /// </summary>
        public Vector2 QuantizationFactor;

        /// <summary>
        ///     The proxy count
        /// </summary>
        public int ProxyCount;

        /// <summary>
        ///     The time stamp
        /// </summary>
        public ushort TimeStamp;

        /// <summary>
        ///     The is validate
        /// </summary>
        public static readonly bool IsValidate = false;

        /// <summary>
        ///     Initializes a new instance of the <see cref="BroadPhase" /> class
        /// </summary>
        /// <param name="worldAabb">The world aabb</param>
        /// <param name="callback">The callback</param>
        public BroadPhase(Aabb worldAabb, PairCallback callback)
        {
            PairManager = new PairManager();
            PairManager.Initialize(this, callback);

            Box2DxDebug.Assert(worldAabb.IsValid);
            WorldAabb = worldAabb;
            ProxyCount = 0;

            Vector2 d = worldAabb.UpperBound - worldAabb.LowerBound;
            QuantizationFactor.X = BroadphaseMax / d.X;
            QuantizationFactor.Y = BroadphaseMax / d.Y;

            for (ushort i = 0; i < Settings.MaxProxies - 1; ++i)
            {
                ProxyPool[i] = new Proxy();
                ProxyPool[i].Next = (ushort) (i + 1);
                ProxyPool[i].TimeStamp = 0;
                ProxyPool[i].OverlapCount = Invalid;
                ProxyPool[i].UserData = null;
            }

            ProxyPool[Settings.MaxProxies - 1] = new Proxy();
            ProxyPool[Settings.MaxProxies - 1].Next = PairManager.NullProxy;
            ProxyPool[Settings.MaxProxies - 1].TimeStamp = 0;
            ProxyPool[Settings.MaxProxies - 1].OverlapCount = Invalid;
            ProxyPool[Settings.MaxProxies - 1].UserData = null;
            freeProxy = 0;

            TimeStamp = 1;
            QueryResultCount = 0;

            for (int i = 0; i < 2; i++)
            {
                Bounds[i] = new Bound[2 * Settings.MaxProxies];
            }

            int bCount = 2 * Settings.MaxProxies;
            for (int j = 0; j < 2; j++)
            for (int k = 0; k < bCount; k++)
            {
                Bounds[j][k] = new Bound();
            }
        }

        // Use this to see if your proxy is in range. If it is not in range,
        // it should be destroyed. Otherwise you may get O(m^2) pairs, where m
        // is the number of proxies that are out of range.
        /// <summary>
        ///     Describes whether this instance in range
        /// </summary>
        /// <param name="aabb">The aabb</param>
        /// <returns>The bool</returns>
        public bool InRange(Aabb aabb)
        {
            Vector2 d = Math.Max(aabb.LowerBound - WorldAabb.UpperBound, WorldAabb.LowerBound - aabb.UpperBound);
            return Math.Max(d.X, d.Y) < 0.0f;
        }

        // Create and destroy proxies. These call Flush first.
        /// <summary>
        ///     Creates the proxy using the specified aabb
        /// </summary>
        /// <param name="aabb">The aabb</param>
        /// <param name="userData">The user data</param>
        /// <returns>The proxy id</returns>
        public ushort CreateProxy(Aabb aabb, object userData)
        {
            Box2DxDebug.Assert(ProxyCount < Settings.MaxProxies);
            Box2DxDebug.Assert(freeProxy != PairManager.NullProxy);

            ushort proxyId = freeProxy;
            Proxy proxy1 = ProxyPool[proxyId];
            freeProxy = proxy1.Next;

            proxy1.OverlapCount = 0;
            proxy1.UserData = userData;

            int boundCount = 2 * ProxyCount;

            ushort[] lowerValues;
            ushort[] upperValues;
            ComputeBounds(out lowerValues, out upperValues, aabb);

            for (int axis = 0; axis < 2; ++axis)
            {
                Bound[] bounds = Bounds[axis];
                int lowerIndex, upperIndex;
                Query(out lowerIndex, out upperIndex, lowerValues[axis], upperValues[axis], bounds, boundCount, axis);


                Bound[] tmp = new Bound[boundCount - upperIndex];
                for (int i = 0; i < boundCount - upperIndex; i++)
                {
                    tmp[i] = bounds[upperIndex + i].Clone();
                }

                for (int i = 0; i < boundCount - upperIndex; i++)
                {
                    bounds[upperIndex + 2 + i] = tmp[i];
                }


                tmp = new Bound[upperIndex - lowerIndex];
                for (int i = 0; i < upperIndex - lowerIndex; i++)
                {
                    tmp[i] = bounds[lowerIndex + i].Clone();
                }

                for (int i = 0; i < upperIndex - lowerIndex; i++)
                {
                    bounds[lowerIndex + 1 + i] = tmp[i];
                }

                // The upper index has increased because of the lower bound insertion.
                ++upperIndex;

                // Copy in the new bounds.
                bounds[lowerIndex].Value = lowerValues[axis];
                bounds[lowerIndex].ProxyId = proxyId;
                bounds[upperIndex].Value = upperValues[axis];
                bounds[upperIndex].ProxyId = proxyId;

                bounds[lowerIndex].StabbingCount = lowerIndex == 0 ? (ushort) 0 : bounds[lowerIndex - 1].StabbingCount;
                bounds[upperIndex].StabbingCount = bounds[upperIndex - 1].StabbingCount;

                // Adjust the stabbing count between the new bounds.
                for (int index = lowerIndex; index < upperIndex; ++index)
                {
                    ++bounds[index].StabbingCount;
                }

                // Adjust the all the affected bound indices.
                for (int index = lowerIndex; index < boundCount + 2; ++index)
                {
                    Proxy proxy = ProxyPool[bounds[index].ProxyId];
                    if (bounds[index].IsLower)
                    {
                        proxy.LowerBounds[axis] = (ushort) index;
                    }
                    else
                    {
                        proxy.UpperBounds[axis] = (ushort) index;
                    }
                }
            }

            ++ProxyCount;

            Box2DxDebug.Assert(QueryResultCount < Settings.MaxProxies);

            // Create pairs if the AABB is in range.
            for (int i = 0; i < QueryResultCount; ++i)
            {
                Box2DxDebug.Assert(QueryResults[i] < Settings.MaxProxies);
                Box2DxDebug.Assert(ProxyPool[QueryResults[i]].IsValid);

                PairManager.AddBufferedPair(proxyId, QueryResults[i]);
            }

            PairManager.Commit();

            if (IsValidate)
            {
                Validate();
            }

            // Prepare for next query.
            QueryResultCount = 0;
            IncrementTimeStamp();

            return proxyId;
        }

        /// <summary>
        ///     Destroys the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        public void DestroyProxy(int proxyId)
        {
            Box2DxDebug.Assert((0 < ProxyCount) && (ProxyCount <= Settings.MaxProxies));
            Proxy proxy1 = ProxyPool[proxyId];
            Box2DxDebug.Assert(proxy1.IsValid);

            int boundCount = 2 * ProxyCount;

            for (int axis = 0; axis < 2; ++axis)
            {
                Bound[] bounds = Bounds[axis];

                int lowerIndex = proxy1.LowerBounds[axis];
                int upperIndex = proxy1.UpperBounds[axis];
                ushort lowerValue = bounds[lowerIndex].Value;
                ushort upperValue = bounds[upperIndex].Value;


                Bound[] tmp = new Bound[upperIndex - lowerIndex - 1];
                for (int i = 0; i < upperIndex - lowerIndex - 1; i++)
                {
                    tmp[i] = bounds[lowerIndex + 1 + i].Clone();
                }

                for (int i = 0; i < upperIndex - lowerIndex - 1; i++)
                {
                    bounds[lowerIndex + i] = tmp[i];
                }


                tmp = new Bound[boundCount - upperIndex - 1];
                for (int i = 0; i < boundCount - upperIndex - 1; i++)
                {
                    tmp[i] = bounds[upperIndex + 1 + i].Clone();
                }

                for (int i = 0; i < boundCount - upperIndex - 1; i++)
                {
                    bounds[upperIndex - 1 + i] = tmp[i];
                }

                // Fix bound indices.
                for (int index = lowerIndex; index < boundCount - 2; ++index)
                {
                    Proxy proxy = ProxyPool[bounds[index].ProxyId];
                    if (bounds[index].IsLower)
                    {
                        proxy.LowerBounds[axis] = (ushort) index;
                    }
                    else
                    {
                        proxy.UpperBounds[axis] = (ushort) index;
                    }
                }

                // Fix stabbing count.
                for (int index = lowerIndex; index < upperIndex - 1; ++index)
                {
                    --bounds[index].StabbingCount;
                }

                // Query for pairs to be removed. lowerIndex and upperIndex are not needed.
                Query(out lowerIndex, out upperIndex, lowerValue, upperValue, bounds, boundCount - 2, axis);
            }

            Box2DxDebug.Assert(QueryResultCount < Settings.MaxProxies);

            for (int i = 0; i < QueryResultCount; ++i)
            {
                Box2DxDebug.Assert(ProxyPool[QueryResults[i]].IsValid);
                PairManager.RemoveBufferedPair(proxyId, QueryResults[i]);
            }

            PairManager.Commit();

            // Prepare for next query.
            QueryResultCount = 0;
            IncrementTimeStamp();

            // Return the proxy to the pool.
            proxy1.UserData = null;
            proxy1.OverlapCount = Invalid;
            proxy1.LowerBounds[0] = Invalid;
            proxy1.LowerBounds[1] = Invalid;
            proxy1.UpperBounds[0] = Invalid;
            proxy1.UpperBounds[1] = Invalid;

            proxy1.Next = freeProxy;
            freeProxy = (ushort) proxyId;
            --ProxyCount;

            if (IsValidate)
            {
                Validate();
            }
        }

        // Call MoveProxy as many times as you like, then when you are done
        // call Commit to finalized the proxy pairs (for your time step).
        /// <summary>
        ///     Moves the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <param name="aabb">The aabb</param>
        public void MoveProxy(int proxyId, Aabb aabb)
        {
            if (proxyId == PairManager.NullProxy || Settings.MaxProxies <= proxyId)
            {
                Box2DxDebug.Assert(false);
                return;
            }

            if (aabb.IsValid == false)
            {
                Box2DxDebug.Assert(false);
                return;
            }

            int boundCount = 2 * ProxyCount;

            Proxy proxy1 = ProxyPool[proxyId];

            // Get new bound values
            BoundValues newValues = new BoundValues();

            ComputeBounds(out newValues.LowerValues, out newValues.UpperValues, aabb);

            // Get old bound values
            BoundValues oldValues = new BoundValues();
            for (int axis = 0; axis < 2; ++axis)
            {
                oldValues.LowerValues[axis] = Bounds[axis][proxy1.LowerBounds[axis]].Value;
                oldValues.UpperValues[axis] = Bounds[axis][proxy1.UpperBounds[axis]].Value;
            }

            for (int axis = 0; axis < 2; ++axis)
            {
                Bound[] bounds = Bounds[axis];

                int lowerIndex = proxy1.LowerBounds[axis];
                int upperIndex = proxy1.UpperBounds[axis];

                ushort lowerValue = newValues.LowerValues[axis];
                ushort upperValue = newValues.UpperValues[axis];

                int deltaLower = lowerValue - bounds[lowerIndex].Value;
                int deltaUpper = upperValue - bounds[upperIndex].Value;

                bounds[lowerIndex].Value = lowerValue;
                bounds[upperIndex].Value = upperValue;

                //
                // Expanding adds overlaps
                //

                // Should we move the lower bound down?
                if (deltaLower < 0)
                {
                    int index = lowerIndex;
                    while ((index > 0) && (lowerValue < bounds[index - 1].Value))
                    {
                        Bound bound = bounds[index];
                        Bound prevBound = bounds[index - 1];

                        int prevProxyId = prevBound.ProxyId;
                        Proxy prevProxy = ProxyPool[prevBound.ProxyId];

                        ++prevBound.StabbingCount;

                        if (prevBound.IsUpper)
                        {
                            if (TestOverlap(newValues, prevProxy))
                            {
                                PairManager.AddBufferedPair(proxyId, prevProxyId);
                            }

                            ++prevProxy.UpperBounds[axis];
                            ++bound.StabbingCount;
                        }
                        else
                        {
                            ++prevProxy.LowerBounds[axis];
                            --bound.StabbingCount;
                        }

                        --proxy1.LowerBounds[axis];
                        Math.Swap(ref bounds[index], ref bounds[index - 1]);
                        --index;
                    }
                }

                // Should we move the upper bound up?
                if (deltaUpper > 0)
                {
                    int index = upperIndex;
                    while ((index < boundCount - 1) && (bounds[index + 1].Value <= upperValue))
                    {
                        Bound bound = bounds[index];
                        Bound nextBound = bounds[index + 1];
                        int nextProxyId = nextBound.ProxyId;
                        Proxy nextProxy = ProxyPool[nextProxyId];

                        ++nextBound.StabbingCount;

                        if (nextBound.IsLower)
                        {
                            if (TestOverlap(newValues, nextProxy))
                            {
                                PairManager.AddBufferedPair(proxyId, nextProxyId);
                            }

                            --nextProxy.LowerBounds[axis];
                            ++bound.StabbingCount;
                        }
                        else
                        {
                            --nextProxy.UpperBounds[axis];
                            --bound.StabbingCount;
                        }

                        ++proxy1.UpperBounds[axis];
                        Math.Swap(ref bounds[index], ref bounds[index + 1]);
                        ++index;
                    }
                }

                //
                // Shrinking removes overlaps
                //

                // Should we move the lower bound up?
                if (deltaLower > 0)
                {
                    int index = lowerIndex;
                    while ((index < boundCount - 1) && (bounds[index + 1].Value <= lowerValue))
                    {
                        Bound bound = bounds[index];
                        Bound nextBound = bounds[index + 1];

                        int nextProxyId = nextBound.ProxyId;
                        Proxy nextProxy = ProxyPool[nextProxyId];

                        --nextBound.StabbingCount;

                        if (nextBound.IsUpper)
                        {
                            if (TestOverlap(oldValues, nextProxy))
                            {
                                PairManager.RemoveBufferedPair(proxyId, nextProxyId);
                            }

                            --nextProxy.UpperBounds[axis];
                            --bound.StabbingCount;
                        }
                        else
                        {
                            --nextProxy.LowerBounds[axis];
                            ++bound.StabbingCount;
                        }

                        ++proxy1.LowerBounds[axis];
                        Math.Swap(ref bounds[index], ref bounds[index + 1]);
                        ++index;
                    }
                }

                // Should we move the upper bound down?
                if (deltaUpper < 0)
                {
                    int index = upperIndex;
                    while ((index > 0) && (upperValue < bounds[index - 1].Value))
                    {
                        Bound bound = bounds[index];
                        Bound prevBound = bounds[index - 1];

                        int prevProxyId = prevBound.ProxyId;
                        Proxy prevProxy = ProxyPool[prevProxyId];

                        --prevBound.StabbingCount;

                        if (prevBound.IsLower)
                        {
                            if (TestOverlap(oldValues, prevProxy))
                            {
                                PairManager.RemoveBufferedPair(proxyId, prevProxyId);
                            }

                            ++prevProxy.LowerBounds[axis];
                            --bound.StabbingCount;
                        }
                        else
                        {
                            ++prevProxy.UpperBounds[axis];
                            ++bound.StabbingCount;
                        }

                        --proxy1.UpperBounds[axis];
                        Math.Swap(ref bounds[index], ref bounds[index - 1]);
                        --index;
                    }
                }
            }

            if (IsValidate)
            {
                Validate();
            }
        }

        /// <summary>
        ///     Commits this instance
        /// </summary>
        public void Commit()
        {
            PairManager.Commit();
        }

        // Get a single proxy. Returns NULL if the id is invalid.
        /// <summary>
        ///     Gets the proxy using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <returns>The proxy</returns>
        public Proxy GetProxy(int proxyId)
        {
            if (proxyId == PairManager.NullProxy || ProxyPool[proxyId].IsValid == false)
            {
                return null;
            }

            return ProxyPool[proxyId];
        }

        // Query an AABB for overlapping proxies, returns the user data and
        // the count, up to the supplied maximum count.
        /// <summary>
        ///     Queries the aabb
        /// </summary>
        /// <param name="aabb">The aabb</param>
        /// <param name="userData">The user data</param>
        /// <param name="maxCount">The max count</param>
        /// <returns>The count</returns>
        public int Query(Aabb aabb, object[] userData, int maxCount)
        {
            ushort[] lowerValues;
            ushort[] upperValues;
            ComputeBounds(out lowerValues, out upperValues, aabb);

            int lowerIndex, upperIndex;

            Query(out lowerIndex, out upperIndex, lowerValues[0], upperValues[0], Bounds[0], 2 * ProxyCount, 0);
            Query(out lowerIndex, out upperIndex, lowerValues[1], upperValues[1], Bounds[1], 2 * ProxyCount, 1);

            Box2DxDebug.Assert(QueryResultCount < Settings.MaxProxies);

            int count = 0;
            for (int i = 0; (i < QueryResultCount) && (count < maxCount); ++i, ++count)
            {
                Box2DxDebug.Assert(QueryResults[i] < Settings.MaxProxies);
                Proxy proxy = ProxyPool[QueryResults[i]];
                Box2DxDebug.Assert(proxy.IsValid);
                userData[i] = proxy.UserData;
            }

            // Prepare for next query.
            QueryResultCount = 0;
            IncrementTimeStamp();

            return count;
        }

        /// <summary>
        ///     Query a segment for overlapping proxies, returns the user data and
        ///     the count, up to the supplied maximum count.
        ///     If sortKey is provided, then it is a function mapping from proxy user Data to distances along the segment (between
        ///     0 ans 1)
        ///     Then the returned proxies are sorted on that, before being truncated to maxCount
        ///     The sortKey of a proxy is assumed to be larger than the closest point inside the proxy along the segment, this
        ///     allows for early exits
        ///     Proxies with a negative sortKey are discarded
        /// </summary>
        /// <param name="segment"></param>
        /// <param name="userData"></param>
        /// <param name="maxCount"></param>
        /// <param name="sortKey"></param>
        /// <returns></returns>
        public
#if ALLOWUNSAFE
            unsafe
#endif //#if ALLOWUNSAFE
            int QuerySegment(Segment segment, object[] userData, int maxCount, SortKeyFunc sortKey)
        {
            float maxLambda = 1;

            float dx = (segment.P2.X - segment.P1.X) * QuantizationFactor.X;
            float dy = (segment.P2.Y - segment.P1.Y) * QuantizationFactor.Y;

            int sx = dx < -Settings.FltEpsilon ? -1 : dx > Settings.FltEpsilon ? 1 : 0;
            int sy = dy < -Settings.FltEpsilon ? -1 : dy > Settings.FltEpsilon ? 1 : 0;

            Box2DxDebug.Assert(sx != 0 || sy != 0);

            float p1X = (segment.P1.X - WorldAabb.LowerBound.X) * QuantizationFactor.X;
            float p1Y = (segment.P1.Y - WorldAabb.LowerBound.Y) * QuantizationFactor.Y;
#if ALLOWUNSAFE
            ushort* startValues = stackalloc ushort[2];
            ushort* startValues2 = stackalloc ushort[2];
#else
			ushort[] startValues = new ushort[2];
			ushort[] startValues2 = new ushort[2];
#endif

            int xIndex;
            int yIndex;

            ushort proxyId;

            // TODO_ERIN implement fast float to ushort conversion.
            startValues[0] = (ushort) ((ushort) p1X & (BroadphaseMax - 1));
            startValues2[0] = (ushort) ((ushort) p1X | 1);

            startValues[1] = (ushort) ((ushort) p1Y & (BroadphaseMax - 1));
            startValues2[1] = (ushort) ((ushort) p1Y | 1);

            //First deal with all the proxies that contain segment.p1
            int lowerIndex;
            int upperIndex;
            Query(out lowerIndex, out upperIndex, startValues[0], startValues2[0], Bounds[0], 2 * ProxyCount, 0);
            if (sx >= 0)
            {
                xIndex = upperIndex - 1;
            }
            else
            {
                xIndex = lowerIndex;
            }

            Query(out lowerIndex, out upperIndex, startValues[1], startValues2[1], Bounds[1], 2 * ProxyCount, 1);
            if (sy >= 0)
            {
                yIndex = upperIndex - 1;
            }
            else
            {
                yIndex = lowerIndex;
            }

            //If we are using sortKey, then sort what we have so far, filtering negative keys
            if (sortKey != null)
            {
                //Fill keys
                for (int j = 0; j < QueryResultCount; j++)
                {
                    QuerySortKeys[j] = sortKey(ProxyPool[QueryResults[j]].UserData);
                }

                //Bubble sort keys
                //Sorting negative values to the top, so we can easily remove them
                int i = 0;
                while (i < QueryResultCount - 1)
                {
                    float a = QuerySortKeys[i];
                    float b = QuerySortKeys[i + 1];
                    if (a < 0 ? b >= 0 : (a > b) && (b >= 0))
                    {
                        QuerySortKeys[i + 1] = a;
                        QuerySortKeys[i] = b;
                        ushort tempValue = QueryResults[i + 1];
                        QueryResults[i + 1] = QueryResults[i];
                        QueryResults[i] = tempValue;
                        i--;
                        if (i == -1)
                        {
                            i = 1;
                        }
                    }
                    else
                    {
                        i++;
                    }
                }

                //Skim off negative values
                while ((QueryResultCount > 0) && (QuerySortKeys[QueryResultCount - 1] < 0))
                {
                    QueryResultCount--;
                }
            }

            //Now work through the rest of the segment
            for (;;)
            {
                float xProgress = 0;
                float yProgress = 0;
                if (xIndex < 0 || xIndex >= ProxyCount * 2)
                {
                    break;
                }

                if (yIndex < 0 || yIndex >= ProxyCount * 2)
                {
                    break;
                }

                if (sx != 0)
                {
                    //Move on to the next bound
                    if (sx > 0)
                    {
                        xIndex++;
                        if (xIndex == ProxyCount * 2)
                        {
                            break;
                        }
                    }
                    else
                    {
                        xIndex--;
                        if (xIndex < 0)
                        {
                            break;
                        }
                    }

                    xProgress = (Bounds[0][xIndex].Value - p1X) / dx;
                }

                if (sy != 0)
                {
                    //Move on to the next bound
                    if (sy > 0)
                    {
                        yIndex++;
                        if (yIndex == ProxyCount * 2)
                        {
                            break;
                        }
                    }
                    else
                    {
                        yIndex--;
                        if (yIndex < 0)
                        {
                            break;
                        }
                    }

                    yProgress = (Bounds[1][yIndex].Value - p1Y) / dy;
                }

                for (;;)
                {
                    Proxy proxy;
                    if (sy == 0 || ((sx != 0) && (xProgress < yProgress)))
                    {
                        if (xProgress > maxLambda)
                        {
                            break;
                        }

                        //Check that we are entering a proxy, not leaving
                        if (sx > 0 ? Bounds[0][xIndex].IsLower : Bounds[0][xIndex].IsUpper)
                        {
                            //Check the other axis of the proxy
                            proxyId = Bounds[0][xIndex].ProxyId;
                            proxy = ProxyPool[proxyId];
                            if (sy >= 0)
                            {
                                if ((proxy.LowerBounds[1] <= yIndex - 1) && (proxy.UpperBounds[1] >= yIndex))
                                {
                                    //Add the proxy
                                    if (sortKey != null)
                                    {
                                        AddProxyResult(proxyId, proxy, maxCount, sortKey);
                                    }
                                    else
                                    {
                                        QueryResults[QueryResultCount] = proxyId;
                                        ++QueryResultCount;
                                    }
                                }
                            }
                            else
                            {
                                if ((proxy.LowerBounds[1] <= yIndex) && (proxy.UpperBounds[1] >= yIndex + 1))
                                {
                                    //Add the proxy
                                    if (sortKey != null)
                                    {
                                        AddProxyResult(proxyId, proxy, maxCount, sortKey);
                                    }
                                    else
                                    {
                                        QueryResults[QueryResultCount] = proxyId;
                                        ++QueryResultCount;
                                    }
                                }
                            }
                        }

                        //Early out
                        if ((sortKey != null) && (QueryResultCount == maxCount) && (QueryResultCount > 0) &&
                            (xProgress > QuerySortKeys[QueryResultCount - 1]))
                        {
                            break;
                        }

                        //Move on to the next bound
                        if (sx > 0)
                        {
                            xIndex++;
                            if (xIndex == ProxyCount * 2)
                            {
                                break;
                            }
                        }
                        else
                        {
                            xIndex--;
                            if (xIndex < 0)
                            {
                                break;
                            }
                        }

                        xProgress = (Bounds[0][xIndex].Value - p1X) / dx;
                    }
                    else
                    {
                        if (yProgress > maxLambda)
                        {
                            break;
                        }

                        //Check that we are entering a proxy, not leaving
                        if (sy > 0 ? Bounds[1][yIndex].IsLower : Bounds[1][yIndex].IsUpper)
                        {
                            //Check the other axis of the proxy
                            proxyId = Bounds[1][yIndex].ProxyId;
                            proxy = ProxyPool[proxyId];
                            if (sx >= 0)
                            {
                                if ((proxy.LowerBounds[0] <= xIndex - 1) && (proxy.UpperBounds[0] >= xIndex))
                                {
                                    //Add the proxy
                                    if (sortKey != null)
                                    {
                                        AddProxyResult(proxyId, proxy, maxCount, sortKey);
                                    }
                                    else
                                    {
                                        QueryResults[QueryResultCount] = proxyId;
                                        ++QueryResultCount;
                                    }
                                }
                            }
                            else
                            {
                                if ((proxy.LowerBounds[0] <= xIndex) && (proxy.UpperBounds[0] >= xIndex + 1))
                                {
                                    //Add the proxy
                                    if (sortKey != null)
                                    {
                                        AddProxyResult(proxyId, proxy, maxCount, sortKey);
                                    }
                                    else
                                    {
                                        QueryResults[QueryResultCount] = proxyId;
                                        ++QueryResultCount;
                                    }
                                }
                            }
                        }

                        //Early out
                        if ((sortKey != null) && (QueryResultCount == maxCount) && (QueryResultCount > 0) &&
                            (yProgress > QuerySortKeys[QueryResultCount - 1]))
                        {
                            break;
                        }

                        //Move on to the next bound
                        if (sy > 0)
                        {
                            yIndex++;
                            if (yIndex == ProxyCount * 2)
                            {
                                break;
                            }
                        }
                        else
                        {
                            yIndex--;
                            if (yIndex < 0)
                            {
                                break;
                            }
                        }

                        yProgress = (Bounds[1][yIndex].Value - p1Y) / dy;
                    }
                }

                break;
            }

            int count = 0;
            for (int i = 0; (i < QueryResultCount) && (count < maxCount); ++i, ++count)
            {
                Box2DxDebug.Assert(QueryResults[i] < Settings.MaxProxies);
                Proxy proxy = ProxyPool[QueryResults[i]];
                Box2DxDebug.Assert(proxy.IsValid);
                userData[i] = proxy.UserData;
            }

            // Prepare for next query.
            QueryResultCount = 0;
            IncrementTimeStamp();

            return count;
        }

        /// <summary>
        ///     Validates this instance
        /// </summary>
        public void Validate()
        {
            for (int axis = 0; axis < 2; ++axis)
            {
                Bound[] bounds = Bounds[axis];

                int boundCount = 2 * ProxyCount;
                ushort stabbingCount = 0;

                for (int i = 0; i < boundCount; ++i)
                {
                    Bound bound = bounds[i];
                    Box2DxDebug.Assert(i == 0 || bounds[i - 1].Value <= bound.Value);
                    Box2DxDebug.Assert(bound.ProxyId != PairManager.NullProxy);
                    Box2DxDebug.Assert(ProxyPool[bound.ProxyId].IsValid);

                    if (bound.IsLower)
                    {
                        Box2DxDebug.Assert(ProxyPool[bound.ProxyId].LowerBounds[axis] == i);
                        ++stabbingCount;
                    }
                    else
                    {
                        Box2DxDebug.Assert(ProxyPool[bound.ProxyId].UpperBounds[axis] == i);
                        --stabbingCount;
                    }

                    Box2DxDebug.Assert(bound.StabbingCount == stabbingCount);
                }
            }
        }

        /// <summary>
        ///     Computes the bounds using the specified lower values
        /// </summary>
        /// <param name="lowerValues">The lower values</param>
        /// <param name="upperValues">The upper values</param>
        /// <param name="aabb">The aabb</param>
        private void ComputeBounds(out ushort[] lowerValues, out ushort[] upperValues, Aabb aabb)
        {
            lowerValues = new ushort[2];
            upperValues = new ushort[2];

            Box2DxDebug.Assert(aabb.UpperBound.X >= aabb.LowerBound.X);
            Box2DxDebug.Assert(aabb.UpperBound.Y >= aabb.LowerBound.Y);

            Vector2 minVertex = Math.Clamp(aabb.LowerBound, WorldAabb.LowerBound, WorldAabb.UpperBound);
            Vector2 maxVertex = Math.Clamp(aabb.UpperBound, WorldAabb.LowerBound, WorldAabb.UpperBound);

            // Bump lower bounds downs and upper bounds up. This ensures correct sorting of
            // lower/upper bounds that would have equal values.
            // TODO_ERIN implement fast float to uint16 conversion.
            lowerValues[0] = (ushort) ((ushort) (QuantizationFactor.X * (minVertex.X - WorldAabb.LowerBound.X)) &
                                       (BroadphaseMax - 1));
            upperValues[0] = (ushort) ((ushort) (QuantizationFactor.X * (maxVertex.X - WorldAabb.LowerBound.X)) | 1);

            lowerValues[1] = (ushort) ((ushort) (QuantizationFactor.Y * (minVertex.Y - WorldAabb.LowerBound.Y)) &
                                       (BroadphaseMax - 1));
            upperValues[1] = (ushort) ((ushort) (QuantizationFactor.Y * (maxVertex.Y - WorldAabb.LowerBound.Y)) | 1);
        }

        // This one is only used for validation.
        /// <summary>
        ///     Describes whether this instance test overlap
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <returns>The bool</returns>
        internal bool TestOverlap(Proxy p1, Proxy p2)
        {
            for (int axis = 0; axis < 2; ++axis)
            {
                Bound[] bounds = Bounds[axis];

                Box2DxDebug.Assert(p1.LowerBounds[axis] < 2 * ProxyCount);
                Box2DxDebug.Assert(p1.UpperBounds[axis] < 2 * ProxyCount);
                Box2DxDebug.Assert(p2.LowerBounds[axis] < 2 * ProxyCount);
                Box2DxDebug.Assert(p2.UpperBounds[axis] < 2 * ProxyCount);

                if (bounds[p1.LowerBounds[axis]].Value > bounds[p2.UpperBounds[axis]].Value)
                {
                    return false;
                }

                if (bounds[p1.UpperBounds[axis]].Value < bounds[p2.LowerBounds[axis]].Value)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Describes whether this instance test overlap
        /// </summary>
        /// <param name="b">The </param>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        internal bool TestOverlap(BoundValues b, Proxy p)
        {
            for (int axis = 0; axis < 2; ++axis)
            {
                Bound[] bounds = Bounds[axis];

                Box2DxDebug.Assert(p.LowerBounds[axis] < 2 * ProxyCount);
                Box2DxDebug.Assert(p.UpperBounds[axis] < 2 * ProxyCount);

                if (b.LowerValues[axis] > bounds[p.UpperBounds[axis]].Value)
                {
                    return false;
                }

                if (b.UpperValues[axis] < bounds[p.LowerBounds[axis]].Value)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        ///     Queries the lower query out
        /// </summary>
        /// <param name="lowerQueryOut">The lower query out</param>
        /// <param name="upperQueryOut">The upper query out</param>
        /// <param name="lowerValue">The lower value</param>
        /// <param name="upperValue">The upper value</param>
        /// <param name="bounds">The bounds</param>
        /// <param name="boundCount">The bound count</param>
        /// <param name="axis">The axis</param>
        private void Query(out int lowerQueryOut, out int upperQueryOut,
            ushort lowerValue, ushort upperValue,
            Bound[] bounds, int boundCount, int axis)
        {
            int lowerQuery = BinarySearch(bounds, boundCount, lowerValue);
            int upperQuery = BinarySearch(bounds, boundCount, upperValue);

            // Easy case: lowerQuery <= lowerIndex(i) < upperQuery
            // Solution: search query range for min bounds.
            for (int i = lowerQuery; i < upperQuery; ++i)
            {
                if (bounds[i].IsLower)
                {
                    IncrementOverlapCount(bounds[i].ProxyId);
                }
            }

            // Hard case: lowerIndex(i) < lowerQuery < upperIndex(i)
            // Solution: use the stabbing count to search down the bound array.
            if (lowerQuery > 0)
            {
                int i = lowerQuery - 1;
                int s = bounds[i].StabbingCount;

                // Find the s overlaps.
                while (s != 0)
                {
                    Box2DxDebug.Assert(i >= 0);

                    if (bounds[i].IsLower)
                    {
                        Proxy proxy = ProxyPool[bounds[i].ProxyId];
                        if (lowerQuery <= proxy.UpperBounds[axis])
                        {
                            IncrementOverlapCount(bounds[i].ProxyId);
                            --s;
                        }
                    }

                    --i;
                }
            }

            lowerQueryOut = lowerQuery;
            upperQueryOut = upperQuery;
        }

        /// <summary>
        ///     Increments the overlap count using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        private void IncrementOverlapCount(int proxyId)
        {
            Proxy proxy = ProxyPool[proxyId];
            if (proxy.TimeStamp < TimeStamp)
            {
                proxy.TimeStamp = TimeStamp;
                proxy.OverlapCount = 1;
            }
            else
            {
                proxy.OverlapCount = 2;
                Box2DxDebug.Assert(QueryResultCount < Settings.MaxProxies);
                QueryResults[QueryResultCount] = (ushort) proxyId;
                ++QueryResultCount;
            }
        }

        /// <summary>
        ///     Increments the time stamp
        /// </summary>
        private void IncrementTimeStamp()
        {
            if (TimeStamp == BroadphaseMax)
            {
                for (ushort i = 0; i < Settings.MaxProxies; ++i)
                {
                    ProxyPool[i].TimeStamp = 0;
                }

                TimeStamp = 1;
            }
            else
            {
                ++TimeStamp;
            }
        }

#if ALLOWUNSAFE
        /// <summary>
        ///     Adds the proxy result using the specified proxy id
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <param name="proxy">The proxy</param>
        /// <param name="maxCount">The max count</param>
        /// <param name="sortKey">The sort key</param>
        private unsafe void AddProxyResult(ushort proxyId, Proxy proxy, int maxCount, SortKeyFunc sortKey)
        {
            float key = sortKey(proxy.UserData);
            //ContactFilter proxies on positive keys
            if (key < 0)
            {
                return;
            }

            //Merge the new key into the sorted list.
            //float32* p = std::lower_bound(m_querySortKeys,m_querySortKeys+m_queryResultCount,key);
            fixed (float* querySortKeysPtr = QuerySortKeys)
            {
                float* p = querySortKeysPtr;
                while ((*p < key) && (p < &querySortKeysPtr[QueryResultCount]))
                {
                    p++;
                }

                int i = (int) (p - &querySortKeysPtr[0]);
                if ((maxCount == QueryResultCount) && (i == QueryResultCount))
                {
                    return;
                }

                if (maxCount == QueryResultCount)
                {
                    QueryResultCount--;
                }

                //std::copy_backward
                for (int j = QueryResultCount + 1; j > i; --j)
                {
                    QuerySortKeys[j] = QuerySortKeys[j - 1];
                    QueryResults[j] = QueryResults[j - 1];
                }

                QuerySortKeys[i] = key;
                QueryResults[i] = proxyId;
                QueryResultCount++;
            }
        }
#else
		public void AddProxyResult(ushort proxyId, Proxy proxy, int maxCount, SortKeyFunc sortKey)
		{
			float key = sortKey(proxy.UserData);
			//ContactFilter proxies on positive keys
			if (key < 0)
				return;
			//Merge the new key into the sorted list.
			//float32* p = std::lower_bound(m_querySortKeys,m_querySortKeys+m_queryResultCount,key);
			float[] querySortKeysPtr = _querySortKeys;

			int ip = 0;
			float p = querySortKeysPtr[ip];
			while (p < key && ip < _queryResultCount)
			{
				p = querySortKeysPtr[ip];
				ip++;
			}
			int i = ip;
			if (maxCount == _queryResultCount && i == _queryResultCount)
				return;
			if (maxCount == _queryResultCount)
				_queryResultCount--;
			//std::copy_backward
			for (int j = _queryResultCount + 1; j > i; --j)
			{
				_querySortKeys[j] = _querySortKeys[j - 1];
				_queryResults[j] = _queryResults[j - 1];
			}
			_querySortKeys[i] = key;
			_queryResults[i] = proxyId;
			_queryResultCount++;
		}
#endif

        /// <summary>
        ///     Binaries the search using the specified bounds
        /// </summary>
        /// <param name="bounds">The bounds</param>
        /// <param name="count">The count</param>
        /// <param name="value">The value</param>
        /// <returns>The low</returns>
        private static int BinarySearch(Bound[] bounds, int count, ushort value)
        {
            int low = 0;
            int high = count - 1;
            while (low <= high)
            {
                int mid = (low + high) >> 1;
                if (bounds[mid].Value > value)
                {
                    high = mid - 1;
                }
                else if (bounds[mid].Value < value)
                {
                    low = mid + 1;
                }
                else
                {
                    return (ushort) mid;
                }
            }

            return low;
        }
    }
}