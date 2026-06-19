// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DynamicTreeBroadPhaseTest.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The dynamic tree broad phase test class
    /// </summary>
    public class DynamicTreeBroadPhaseTest
    {
        /// <summary>
        /// Tests that add proxy set proxy get proxy should round trip user data
        /// </summary>
        [Fact]
        public void AddProxy_SetProxy_GetProxy_ShouldRoundTripUserData()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabb = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(1.0f, 1.0f));

            int proxyId = broadPhase.AddProxy(ref aabb);
            broadPhase.SetProxy(proxyId, ref proxyId);

            Assert.Equal(1, broadPhase.ProxyCount);
            Assert.Equal(proxyId, broadPhase.GetProxy(proxyId));
        }

        /// <summary>
        /// Tests that update pairs should report overlap pair
        /// </summary>
        [Fact]
        public void UpdatePairs_ShouldReportOverlapPair()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabbA = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            Aabb aabbB = new Aabb(new Vector2F(1.0f, 1.0f), new Vector2F(3.0f, 3.0f));

            int proxyA = broadPhase.AddProxy(ref aabbA);
            int proxyB = broadPhase.AddProxy(ref aabbB);
            broadPhase.SetProxy(proxyA, ref proxyA);
            broadPhase.SetProxy(proxyB, ref proxyB);

            List<(int, int)> pairs = new List<(int, int)>();
            broadPhase.UpdatePairs((idA, idB) => pairs.Add((idA, idB)));

            Assert.Contains((proxyA < proxyB ? proxyA : proxyB, proxyA < proxyB ? proxyB : proxyA), pairs);
        }

        /// <summary>
        /// Tests that query should return overlapping proxy ids
        /// </summary>
        [Fact]
        public void Query_ShouldReturnOverlappingProxyIds()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabbA = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            Aabb aabbB = new Aabb(new Vector2F(10.0f, 10.0f), new Vector2F(12.0f, 12.0f));
            int proxyA = broadPhase.AddProxy(ref aabbA);
            int proxyB = broadPhase.AddProxy(ref aabbB);

            Aabb query = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(3.0f, 3.0f));
            List<int> hits = new List<int>();
            broadPhase.Query(id =>
            {
                hits.Add(id);
                return true;
            }, ref query);

            Assert.Contains(proxyA, hits);
            Assert.DoesNotContain(proxyB, hits);
        }

        /// <summary>
        /// Tests that remove proxy decrements count
        /// </summary>
        [Fact]
        public void RemoveProxy_ShouldDecrementCount()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabb = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(1.0f, 1.0f));
            int proxyId = broadPhase.AddProxy(ref aabb);

            broadPhase.RemoveProxy(proxyId);

            Assert.Equal(0, broadPhase.ProxyCount);
        }

        /// <summary>
        /// Tests that move proxy buffers move and triggers overlap detection
        /// </summary>
        [Fact]
        public void MoveProxy_ShouldBufferMoveAndTriggerNewOverlap()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabbA = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            Aabb aabbB = new Aabb(new Vector2F(10.0f, 10.0f), new Vector2F(12.0f, 12.0f));
            int proxyA = broadPhase.AddProxy(ref aabbA);
            int proxyB = broadPhase.AddProxy(ref aabbB);
            broadPhase.SetProxy(proxyA, ref proxyA);
            broadPhase.SetProxy(proxyB, ref proxyB);

            // Initial update pairs should have no overlaps
            List<(int, int)> pairs = new List<(int, int)>();
            broadPhase.UpdatePairs((idA, idB) => pairs.Add((idA, idB)));
            Assert.Empty(pairs);

            // Move proxyB to overlap with proxyA
            Aabb moved = new Aabb(new Vector2F(1.0f, 1.0f), new Vector2F(3.0f, 3.0f));
            broadPhase.MoveProxy(proxyB, ref moved, Vector2F.Zero);

            broadPhase.UpdatePairs((idA, idB) => pairs.Add((idA, idB)));

            Assert.Contains((proxyA, proxyB), pairs);
        }

        /// <summary>
        /// Tests that touch proxy does not throw
        /// </summary>
        [Fact]
        public void TouchProxy_ShouldNotThrow()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabbA = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            Aabb aabbB = new Aabb(new Vector2F(10.0f, 10.0f), new Vector2F(12.0f, 12.0f));
            int proxyA = broadPhase.AddProxy(ref aabbA);
            broadPhase.AddProxy(ref aabbB);
            broadPhase.SetProxy(proxyA, ref proxyA);

            broadPhase.TouchProxy(proxyA);

            List<(int, int)> pairs = new List<(int, int)>();
            broadPhase.UpdatePairs((idA, idB) => pairs.Add((idA, idB)));
            Assert.Empty(pairs);
        }

        /// <summary>
        /// Tests that get fat aabb returns a valid AABB
        /// </summary>
        [Fact]
        public void GetFatAabb_ShouldReturnValidAabb()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb source = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(1.0f, 1.0f));
            int proxyId = broadPhase.AddProxy(ref source);

            broadPhase.GetFatAabb(proxyId, out Aabb fat);

            Assert.True(fat.LowerBound.X <= source.LowerBound.X);
            Assert.True(fat.LowerBound.Y <= source.LowerBound.Y);
            Assert.True(fat.UpperBound.X >= source.UpperBound.X);
            Assert.True(fat.UpperBound.Y >= source.UpperBound.Y);
        }

        /// <summary>
        /// Tests that test overlap returns true for overlapping proxies
        /// </summary>
        [Fact]
        public void TestOverlap_ShouldReturnTrueForOverlappingProxies()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabbA = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            Aabb aabbB = new Aabb(new Vector2F(1.0f, 1.0f), new Vector2F(3.0f, 3.0f));
            int proxyA = broadPhase.AddProxy(ref aabbA);
            int proxyB = broadPhase.AddProxy(ref aabbB);

            Assert.True(broadPhase.TestOverlap(proxyA, proxyB));
        }

        /// <summary>
        /// Tests that test overlap returns false for non overlapping proxies
        /// </summary>
        [Fact]
        public void TestOverlap_ShouldReturnFalseForNonOverlappingProxies()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabbA = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            Aabb aabbB = new Aabb(new Vector2F(10.0f, 10.0f), new Vector2F(12.0f, 12.0f));
            int proxyA = broadPhase.AddProxy(ref aabbA);
            int proxyB = broadPhase.AddProxy(ref aabbB);

            Assert.False(broadPhase.TestOverlap(proxyA, proxyB));
        }

        /// <summary>
        /// Tests that ray cast invokes callback for overlapping proxy
        /// </summary>
        [Fact]
        public void RayCast_ShouldInvokeCallback()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            int proxyId = broadPhase.AddProxy(ref aabb);
            broadPhase.SetProxy(proxyId, ref proxyId);

            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(-1.0f, 1.0f),
                Point2 = new Vector2F(3.0f, 1.0f),
                MaxFraction = 1.0f
            };

            int hitCount = 0;
            broadPhase.RayCast((ref RayCastInput ri, int id) =>
            {
                hitCount++;
                return ri.MaxFraction;
            }, ref input);

            Assert.Equal(1, hitCount);
        }

        /// <summary>
        /// Tests that shift origin does not throw
        /// </summary>
        [Fact]
        public void ShiftOrigin_ShouldNotThrow()
        {
            DynamicTreeBroadPhase<int> broadPhase = new DynamicTreeBroadPhase<int>();
            Vector2F shift = new Vector2F(10.0f, 10.0f);

            broadPhase.ShiftOrigin(shift);
        }
    }
}

