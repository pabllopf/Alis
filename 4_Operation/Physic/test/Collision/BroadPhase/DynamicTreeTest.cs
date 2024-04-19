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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision.BroadPhase;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Shared;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.BroadPhase
{
    /// <summary>
    /// The dynamic tree test class
    /// </summary>
    public class DynamicTreeTest
    {
        /// <summary>
        /// Tests that test create proxy
        /// </summary>
        [Fact]
        public void TestCreateProxy()
        {
            DynamicTree<FixtureProxy> dynamicTree = new DynamicTree<FixtureProxy>();
            Aabb aabb = new Aabb();
            FixtureProxy proxy = new FixtureProxy();
            int result = dynamicTree.CreateProxy(ref aabb, proxy);
            Assert.True(result <= 0);
        }
        
        /// <summary>
        /// Tests that test destroy proxy
        /// </summary>
        [Fact]
        public void TestDestroyProxy()
        {
            DynamicTree<FixtureProxy> dynamicTree = new DynamicTree<FixtureProxy>();
            Aabb aabb = new Aabb();
            FixtureProxy proxy = new FixtureProxy();
            int proxyId = dynamicTree.CreateProxy(ref aabb, proxy);
            dynamicTree.DestroyProxy(proxyId);
            FixtureProxy result = dynamicTree.GetUserData(proxyId);
            Assert.IsType<FixtureProxy>(result);
        }
        
        /// <summary>
        /// Tests that test move proxy
        /// </summary>
        [Fact]
        public void TestMoveProxy()
        {
            DynamicTree<FixtureProxy> dynamicTree = new DynamicTree<FixtureProxy>();
            Aabb aabb = new Aabb();
            FixtureProxy proxy = new FixtureProxy();
            int proxyId = dynamicTree.CreateProxy(ref aabb, proxy);
            Vector2 displacement = new Vector2();
            bool result = dynamicTree.MoveProxy(proxyId, ref aabb, displacement);
            Assert.False(result);
        }
        
        /// <summary>
        /// Tests that test was moved
        /// </summary>
        [Fact]
        public void TestWasMoved()
        {
            DynamicTree<FixtureProxy> dynamicTree = new DynamicTree<FixtureProxy>();
            Aabb aabb = new Aabb();
            FixtureProxy proxy = new FixtureProxy();
            int proxyId = dynamicTree.CreateProxy(ref aabb, proxy);
            bool result = dynamicTree.WasMoved(proxyId);
            Assert.True(result);
        }
        
        /// <summary>
        /// Tests that test clear moved
        /// </summary>
        [Fact]
        public void TestClearMoved()
        {
            DynamicTree<FixtureProxy> dynamicTree = new DynamicTree<FixtureProxy>();
            Aabb aabb = new Aabb();
            FixtureProxy proxy = new FixtureProxy();
            int proxyId = dynamicTree.CreateProxy(ref aabb, proxy);
            dynamicTree.ClearMoved(proxyId);
            Assert.False(dynamicTree.WasMoved(proxyId));
        }
        
        /// <summary>
        /// Tests that test get user data
        /// </summary>
        [Fact]
        public void TestGetUserData()
        {
            DynamicTree<FixtureProxy> dynamicTree = new DynamicTree<FixtureProxy>();
            Aabb aabb = new Aabb();
            FixtureProxy proxy = new FixtureProxy();
            int proxyId = dynamicTree.CreateProxy(ref aabb, proxy);
            FixtureProxy result = dynamicTree.GetUserData(proxyId);
            Assert.Equal(proxy, result);
        }
        
        /// <summary>
        /// Tests that test get fat aabb
        /// </summary>
        [Fact]
        public void TestGetFatAabb()
        {
            DynamicTree<FixtureProxy> dynamicTree = new DynamicTree<FixtureProxy>();
            Aabb aabb = new Aabb();
            FixtureProxy proxy = new FixtureProxy();
            int proxyId = dynamicTree.CreateProxy(ref aabb, proxy);
            dynamicTree.GetFatAabb(proxyId, out Aabb fatAabb);
            Assert.NotEqual(aabb, fatAabb);
        }
        
        /// <summary>
        /// Tests that test query
        /// </summary>
        [Fact]
        public void TestQuery()
        {
            DynamicTree<FixtureProxy> dynamicTree = new DynamicTree<FixtureProxy>();
            Aabb aabb = new Aabb();
            dynamicTree.Query(null, ref aabb);
            Assert.True(true); // No exception means pass
        }
        
        /// <summary>
        /// Tests that test ray cast
        /// </summary>
        [Fact]
        public void TestRayCast()
        {
            DynamicTree<FixtureProxy> dynamicTree = new DynamicTree<FixtureProxy>();
            RayCastInput input = new RayCastInput();
            dynamicTree.RayCast(null, ref input);
            Assert.True(true); // No exception means pass
        }
        
        /// <summary>
        /// Tests that test shift origin
        /// </summary>
        [Fact]
        public void TestShiftOrigin()
        {
            DynamicTree<FixtureProxy> dynamicTree = new DynamicTree<FixtureProxy>();
            Vector2 newOrigin = new Vector2();
            dynamicTree.ShiftOrigin(ref newOrigin);
            Assert.True(true); // No exception means pass
        }
    }
}