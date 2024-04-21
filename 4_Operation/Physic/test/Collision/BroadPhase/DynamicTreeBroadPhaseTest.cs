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
    }
}