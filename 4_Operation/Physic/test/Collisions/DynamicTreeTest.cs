// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DynamicTreeTest.cs
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
    /// The dynamic tree test class
    /// </summary>
    public class DynamicTreeTest
    {
        /// <summary>
        /// Tests that add proxy set user data get user data should round trip
        /// </summary>
        [Fact]
        public void AddProxy_SetUserData_GetUserData_ShouldRoundTrip()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(-1.0f, -1.0f), new Vector2F(1.0f, 1.0f));

            int proxyId = tree.AddProxy(ref aabb);
            tree.SetUserData(proxyId, 123);

            Assert.Equal(123, tree.GetUserData(proxyId));
            Assert.True(tree.Height >= 0);
        }

        /// <summary>
        /// Tests that query should return inserted proxy
        /// </summary>
        [Fact]
        public void Query_ShouldReturnInsertedProxy()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 2.0f));
            int proxyId = tree.AddProxy(ref aabb);
            tree.SetUserData(proxyId, 7);

            List<int> hits = new List<int>();
            tree.Query(id =>
            {
                hits.Add(id);
                return true;
            }, ref aabb);

            Assert.Contains(proxyId, hits);
        }

        /// <summary>
        /// Tests that move proxy should return false when new aabb is inside fat aabb
        /// </summary>
        [Fact]
        public void MoveProxy_ShouldReturnFalse_WhenNewAabbIsInsideFatAabb()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            int proxyId = tree.AddProxy(ref aabb);

            bool moved = tree.MoveProxy(proxyId, ref aabb, Vector2F.Zero);

            Assert.False(moved);
        }

        /// <summary>
        /// Tests that remove proxy should keep tree operational
        /// </summary>
        [Fact]
        public void RemoveProxy_ShouldKeepTreeOperational()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            int proxyId = tree.AddProxy(ref aabb);

            tree.RemoveProxy(proxyId);

            Assert.Equal(0, tree.Height);
        }

        /// <summary>
        /// Tests that empty tree should have zero height
        /// </summary>
        [Fact]
        public void EmptyTree_ShouldHaveZeroHeight()
        {
            DynamicTree<int> tree = new DynamicTree<int>();

            Assert.Equal(0, tree.Height);
        }

        /// <summary>
        /// Tests that empty tree should have zero area ratio
        /// </summary>
        [Fact]
        public void EmptyTree_ShouldHaveZeroAreaRatio()
        {
            DynamicTree<int> tree = new DynamicTree<int>();

            Assert.Equal(0.0f, tree.AreaRatio);
        }

        /// <summary>
        /// Tests that empty tree should have zero max balance
        /// </summary>
        [Fact]
        public void EmptyTree_ShouldHaveZeroMaxBalance()
        {
            DynamicTree<int> tree = new DynamicTree<int>();

            Assert.Equal(0, tree.MaxBalance);
        }

        /// <summary>
        /// Tests that get fat aabb should return fattened bounds
        /// </summary>
        [Fact]
        public void GetFatAabb_ShouldReturnFattenedBounds()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            int proxyId = tree.AddProxy(ref aabb);

            Aabb fatAabb = tree.GetFatAabb(proxyId);

            Assert.True(fatAabb.LowerBound.X <= aabb.LowerBound.X);
            Assert.True(fatAabb.UpperBound.X >= aabb.UpperBound.X);
        }

        /// <summary>
        /// Tests that test fat aabb overlap should return true for overlapping proxies
        /// </summary>
        [Fact]
        public void TestFatAabbOverlap_ShouldReturnTrueForOverlapping()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb1 = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            Aabb aabb2 = new Aabb(new Vector2F(0.5f, 0.5f), new Vector2F(1.5f, 1.5f));
            int proxy1 = tree.AddProxy(ref aabb1);
            int proxy2 = tree.AddProxy(ref aabb2);

            bool overlap = tree.TestFatAabbOverlap(proxy1, proxy2);

            Assert.True(overlap);
        }

        /// <summary>
        /// Tests that test fat aabb overlap should return false for distant proxies
        /// </summary>
        [Fact]
        public void TestFatAabbOverlap_ShouldReturnFalseForDistant()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb1 = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            Aabb aabb2 = new Aabb(new Vector2F(100.0f, 100.0f), new Vector2F(101.0f, 101.0f));
            int proxy1 = tree.AddProxy(ref aabb1);
            int proxy2 = tree.AddProxy(ref aabb2);

            bool overlap = tree.TestFatAabbOverlap(proxy1, proxy2);

            Assert.False(overlap);
        }

        /// <summary>
        /// Tests that ray cast should hit proxy when ray crosses it
        /// </summary>
        [Fact]
        public void RayCast_ShouldHitProxy_WhenRayCrossesIt()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            int proxyId = tree.AddProxy(ref aabb);

            List<int> hits = new List<int>();
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(-5.0f, 0.0f),
                Point2 = new Vector2F(5.0f, 0.0f),
                MaxFraction = 1.0f
            };

            tree.RayCast((ref RayCastInput ri, int id) =>
            {
                hits.Add(id);
                return 1.0f;
            }, ref input);

            Assert.Contains(proxyId, hits);
        }

        /// <summary>
        /// Tests that shift origin should translate all proxy bounds
        /// </summary>
        [Fact]
        public void ShiftOrigin_ShouldTranslateAllProxyBounds()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(5.0f, 5.0f), new Vector2F(6.0f, 6.0f));
            int proxyId = tree.AddProxy(ref aabb);

            tree.ShiftOrigin(new Vector2F(2.0f, 3.0f));

            Aabb shifted = tree.GetFatAabb(proxyId);
            Assert.True(shifted.LowerBound.X < 5.0f);
        }

        /// <summary>
        /// Tests that compute height should return zero for single node
        /// </summary>
        [Fact]
        public void ComputeHeight_ShouldReturnZeroForSingleNode()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            tree.AddProxy(ref aabb);

            int height = tree.ComputeHeight();

            Assert.Equal(0, height);
        }

        /// <summary>
        /// Tests that query should return false early when callback returns false
        /// </summary>
        [Fact]
        public void Query_ShouldReturnFalseEarly_WhenCallbackReturnsFalse()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb1 = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            Aabb aabb2 = new Aabb(new Vector2F(5.0f, 5.0f), new Vector2F(6.0f, 6.0f));
            tree.AddProxy(ref aabb1);
            tree.AddProxy(ref aabb2);

            Aabb queryArea = new Aabb(new Vector2F(-10.0f, -10.0f), new Vector2F(10.0f, 10.0f));
            int hitCount = 0;
            tree.Query(id =>
            {
                hitCount++;
                return false;
            }, ref queryArea);

            Assert.Equal(1, hitCount);
        }

        /// <summary>
        /// Tests that move proxy should return true when moving outside fat aabb
        /// </summary>
        [Fact]
        public void MoveProxy_ShouldReturnTrue_WhenMovingOutsideFatAabb()
        {
            DynamicTree<int> tree = new DynamicTree<int>();
            Aabb aabb = new Aabb(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 1.0f));
            int proxyId = tree.AddProxy(ref aabb);

            Aabb newAabb = new Aabb(new Vector2F(10.0f, 10.0f), new Vector2F(11.0f, 11.0f));
            bool moved = tree.MoveProxy(proxyId, ref newAabb, Vector2F.Zero);

            Assert.True(moved);
        }
    }
}

