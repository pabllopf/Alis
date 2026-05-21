// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DynamicTreeBroadPhaseFixtureNodeTest.cs
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
    public class DynamicTreeBroadPhaseFixtureNodeTest
    {
        /// <summary>
        /// Tests that add proxy set proxy get proxy should round trip user data
        /// </summary>
        [Fact]
        public void AddProxy_SetProxy_GetProxy_ShouldRoundTripUserData()
        {
            DynamicTreeBroadPhaseFixtureNode<int> broadPhaseFixtureNode = new DynamicTreeBroadPhaseFixtureNode<int>();
            Aabb aabb = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(1.0f, 1.0f));

            int proxyId = broadPhaseFixtureNode.AddProxy(ref aabb);
            broadPhaseFixtureNode.SetProxy(proxyId, ref proxyId);

            Assert.Equal(1, broadPhaseFixtureNode.ProxyCount);
            Assert.Equal(proxyId, broadPhaseFixtureNode.GetProxy(proxyId));
        }

        /// <summary>
        /// Tests that update pairs should report overlap pair
        /// </summary>
        [Fact]
        public void UpdatePairs_ShouldReportOverlapPair()
        {
            DynamicTreeBroadPhaseFixtureNode<int> broadPhaseFixtureNode = new DynamicTreeBroadPhaseFixtureNode<int>();
            Aabb aabbA = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            Aabb aabbB = new Aabb(new Vector2F(1.0f, 1.0f), new Vector2F(3.0f, 3.0f));

            int proxyA = broadPhaseFixtureNode.AddProxy(ref aabbA);
            int proxyB = broadPhaseFixtureNode.AddProxy(ref aabbB);
            broadPhaseFixtureNode.SetProxy(proxyA, ref proxyA);
            broadPhaseFixtureNode.SetProxy(proxyB, ref proxyB);

            List<(int, int)> pairs = new List<(int, int)>();
            broadPhaseFixtureNode.UpdatePairs((idA, idB) => pairs.Add((idA, idB)));

            Assert.Contains((proxyA < proxyB ? proxyA : proxyB, proxyA < proxyB ? proxyB : proxyA), pairs);
        }

        /// <summary>
        /// Tests that query should return overlapping proxy ids
        /// </summary>
        [Fact]
        public void Query_ShouldReturnOverlappingProxyIds()
        {
            DynamicTreeBroadPhaseFixtureNode<int> broadPhaseFixtureNode = new DynamicTreeBroadPhaseFixtureNode<int>();
            Aabb aabbA = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            Aabb aabbB = new Aabb(new Vector2F(10.0f, 10.0f), new Vector2F(12.0f, 12.0f));
            int proxyA = broadPhaseFixtureNode.AddProxy(ref aabbA);
            int proxyB = broadPhaseFixtureNode.AddProxy(ref aabbB);

            Aabb query = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(3.0f, 3.0f));
            List<int> hits = new List<int>();
            broadPhaseFixtureNode.Query(id =>
            {
                hits.Add(id);
                return true;
            }, ref query);

            Assert.Contains(proxyA, hits);
            Assert.DoesNotContain(proxyB, hits);
        }
    }
}

