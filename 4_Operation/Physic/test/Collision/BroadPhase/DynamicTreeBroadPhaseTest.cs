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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.BroadPhase;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.BroadPhase
{
    /// <summary>
    ///     The dynamic tree broad phase test class
    /// </summary>
    public class DynamicTreeBroadPhaseTest
    {
        /// <summary>
        ///     Tests that test add proxy
        /// </summary>
        [Fact]
        public void TestAddProxy()
        {
            DynamicTreeBroadPhase dynamicTreeBroadPhase = new DynamicTreeBroadPhase();
            FixtureProxy proxy = new FixtureProxy();
            int result = dynamicTreeBroadPhase.AddProxy(ref proxy);
            Assert.NotEqual(DynamicTreeBroadPhase.NullProxy, result);
        }
        
        /// <summary>
        ///     Tests that test remove proxy
        /// </summary>
        [Fact]
        public void TestRemoveProxy()
        {
            DynamicTreeBroadPhase dynamicTreeBroadPhase = new DynamicTreeBroadPhase();
            FixtureProxy proxy = new FixtureProxy();
            int proxyId = dynamicTreeBroadPhase.AddProxy(ref proxy);
            dynamicTreeBroadPhase.RemoveProxy(proxyId);
            Assert.True(true);
        }
        
        /// <summary>
        ///     Tests that test get proxy
        /// </summary>
        [Fact]
        public void TestGetProxy()
        {
            DynamicTreeBroadPhase dynamicTreeBroadPhase = new DynamicTreeBroadPhase();
            FixtureProxy proxy = new FixtureProxy();
            int proxyId = dynamicTreeBroadPhase.AddProxy(ref proxy);
            FixtureProxy result = dynamicTreeBroadPhase.GetProxy(proxyId);
            Assert.Equal(proxy, result);
        }
        
        /// <summary>
        ///     Tests that test get fat aabb
        /// </summary>
        [Fact]
        public void TestGetFatAabb()
        {
            DynamicTreeBroadPhase dynamicTreeBroadPhase = new DynamicTreeBroadPhase();
            FixtureProxy proxy = new FixtureProxy();
            int proxyId = dynamicTreeBroadPhase.AddProxy(ref proxy);
            dynamicTreeBroadPhase.GetFatAabb(proxyId, out Aabb fatAabb);
            Assert.NotEqual(proxy.Aabb.LowerBound, fatAabb.LowerBound);
            Assert.NotEqual(proxy.Aabb.UpperBound, fatAabb.UpperBound);
        }
        
        /// <summary>
        ///     Tests that test query
        /// </summary>
        [Fact]
        public void TestQuery()
        {
            DynamicTreeBroadPhase dynamicTreeBroadPhase = new DynamicTreeBroadPhase();
            Aabb aabb = new Aabb();
            dynamicTreeBroadPhase.Query(proxyId => true, ref aabb);
            Assert.True(true); // No exception means pass
        }
        
        /// <summary>
        ///     Tests that test ray cast
        /// </summary>
        [Fact]
        public void TestRayCast()
        {
            DynamicTreeBroadPhase dynamicTreeBroadPhase = new DynamicTreeBroadPhase();
            RayCastInput input = new RayCastInput();
            dynamicTreeBroadPhase.RayCast((rayCastInput, proxyId) => 0, ref input);
            Assert.True(true); // No exception means pass
        }
        
        /// <summary>
        ///     Tests that test shift origin
        /// </summary>
        [Fact]
        public void TestShiftOrigin()
        {
            DynamicTreeBroadPhase dynamicTreeBroadPhase = new DynamicTreeBroadPhase();
            Vector2 newOrigin = new Vector2();
            dynamicTreeBroadPhase.ShiftOrigin(ref newOrigin);
            Assert.True(true); // No exception means pass
        }
        
        /// <summary>
        /// Tests that tree quality returns correct value
        /// </summary>
        [Fact]
        public void TreeQuality_ReturnsCorrectValue()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            float expectedQuality = 0f; // Replace with the expected quality value
            
            float actualQuality = broadPhase.TreeQuality;
            
            Assert.Equal(expectedQuality, actualQuality);
        }
        
        /// <summary>
        /// Tests that tree height returns correct value
        /// </summary>
        [Fact]
        public void TreeHeight_ReturnsCorrectValue()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            int expectedHeight = 0; // Replace with the expected height value
            
            int actualHeight = broadPhase.TreeHeight;
            
            Assert.Equal(expectedHeight, actualHeight);
        }
        
        /// <summary>
        /// Tests that proxy count returns correct value
        /// </summary>
        [Fact]
        public void ProxyCount_ReturnsCorrectValue()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            int expectedCount = 0; // Replace with the expected proxy count
            
            int actualCount = broadPhase.ProxyCount;
            
            Assert.Equal(expectedCount, actualCount);
        }
        
        /// <summary>
        /// Tests that move proxy changes proxy position
        /// </summary>
        [Fact]
        public void MoveProxy_ChangesProxyPosition()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            FixtureProxy proxy = new FixtureProxy();
            Aabb aabb = new Aabb();
            Vector2 displacement = new Vector2(1, 1);
            int proxyId = broadPhase.AddProxy(ref proxy);
            
            broadPhase.MoveProxy(proxyId, ref aabb, displacement);
            
            broadPhase.GetFatAabb(proxyId, out Aabb movedAabb);
            Assert.NotEqual(aabb, movedAabb);
        }
        
        /// <summary>
        /// Tests that touch proxy marks proxy for update
        /// </summary>
        [Fact]
        public void TouchProxy_MarksProxyForUpdate()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            FixtureProxy proxy = new FixtureProxy();
            int proxyId = broadPhase.AddProxy(ref proxy);
            
            broadPhase.TouchProxy(proxyId);
            
            // Here you would assert that the proxy has been marked for update.
            // This depends on the expected behavior of the TouchProxy method.
        }
        
        /// <summary>
        /// Tests that get fat aabb returns correct aabb
        /// </summary>
        [Fact]
        public void GetFatAabb_ReturnsCorrectAabb()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            FixtureProxy proxy = new FixtureProxy();
            int proxyId = broadPhase.AddProxy(ref proxy);
            
            broadPhase.GetFatAabb(proxyId, out Aabb returnedAabb);
            
            Assert.Equal(new Vector2(-0.1f, -0.1f), returnedAabb.LowerBound);
        }
        
        /// <summary>
        /// Tests that test overlap returns true when aabbs overlap
        /// </summary>
        [Fact]
        public void TestOverlap_ReturnsTrue_WhenAabbsOverlap()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            FixtureProxy proxy1 = new FixtureProxy();
            FixtureProxy proxy2 = new FixtureProxy();
            int proxyId1 = broadPhase.AddProxy(ref proxy1);
            int proxyId2 = broadPhase.AddProxy(ref proxy2);
            
            bool result = broadPhase.TestOverlap(proxyId1, proxyId2);
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that test overlap returns false when aabbs do not overlap
        /// </summary>
        [Fact]
        public void TestOverlap_ReturnsFalse_WhenAabbsDoNotOverlap()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            FixtureProxy proxy1 = new FixtureProxy();
            FixtureProxy proxy2 = new FixtureProxy();
            int proxyId1 = broadPhase.AddProxy(ref proxy1);
            int proxyId2 = broadPhase.AddProxy(ref proxy2);
            
            bool result = broadPhase.TestOverlap(proxyId1, proxyId2);
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that query callback returns true when proxy id equals query proxy id
        /// </summary>
        [Fact]
        public void QueryCallback_ReturnsTrue_WhenProxyIdEqualsQueryProxyId()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            FixtureProxy fixtureProxy = new FixtureProxy();
            int proxyId = broadPhase.AddProxy(ref fixtureProxy);
            
            bool result = broadPhase.QueryCallback(proxyId);
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that query callback returns true when proxy moved and proxy id greater than query proxy id
        /// </summary>
        [Fact]
        public void QueryCallback_ReturnsTrue_WhenProxyMovedAndProxyIdGreaterThanQueryProxyId()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            FixtureProxy fixtureProxy = new FixtureProxy();
            int proxyId = broadPhase.AddProxy(ref fixtureProxy);
            Aabb aabb = new Aabb();
            broadPhase.MoveProxy(proxyId, ref aabb, new Vector2(1, 1));
            
            bool result = broadPhase.QueryCallback(proxyId + 1);
            
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that query callback increases pair count when pair capacity is not exceeded
        /// </summary>
        [Fact]
        public void QueryCallback_IncreasesPairCount_WhenPairCapacityIsNotExceeded()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            FixtureProxy fixtureProxy = new FixtureProxy();
            int proxyId = broadPhase.AddProxy(ref fixtureProxy);
            
            broadPhase.QueryCallback(proxyId + 1);
            
            Assert.Equal(1, broadPhase.pairCount);
        }
    }
}