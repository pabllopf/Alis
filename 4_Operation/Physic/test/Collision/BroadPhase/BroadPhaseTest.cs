// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BroadPhaseTest.cs
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
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Test.Collision.BroadPhase.Sample;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.BroadPhase
{
    /// <summary>
    ///     The broad phase test class
    /// </summary>
    public class BroadPhaseTest
    {
        /// <summary>
        ///     Tests that test proxy count
        /// </summary>
        [Fact]
        public void TestProxyCount()
        {
            BroadPhaseImplementation broadPhase = new BroadPhaseImplementation();
            Assert.Equal(0, broadPhase.ProxyCount);
        }
        
        /// <summary>
        ///     Tests that test update pairs
        /// </summary>
        [Fact]
        public void TestUpdatePairs()
        {
            BroadPhaseImplementation broadPhase = new BroadPhaseImplementation();
            broadPhase.UpdatePairs(null);
            // Add your assertions here
        }
        
        /// <summary>
        ///     Tests that test test overlap
        /// </summary>
        [Fact]
        public void TestTestOverlap()
        {
            BroadPhaseImplementation broadPhase = new BroadPhaseImplementation();
            bool result = broadPhase.TestOverlap(0, 1);
            // Add your assertions here
        }
        
        /// <summary>
        ///     Tests that test add proxy
        /// </summary>
        [Fact]
        public void TestAddProxy()
        {
            BroadPhaseImplementation broadPhase = new BroadPhaseImplementation();
            FixtureProxy proxy = new FixtureProxy();
            int result = broadPhase.AddProxy(ref proxy);
            // Add your assertions here
        }
        
        /// <summary>
        ///     Tests that test remove proxy
        /// </summary>
        [Fact]
        public void TestRemoveProxy()
        {
            BroadPhaseImplementation broadPhase = new BroadPhaseImplementation();
            broadPhase.RemoveProxy(0);
            // Add your assertions here
        }
        
        /// <summary>
        ///     Tests that test move proxy
        /// </summary>
        [Fact]
        public void TestMoveProxy()
        {
            BroadPhaseImplementation broadPhase = new BroadPhaseImplementation();
            Aabb aabb = new Aabb();
            Vector2 displacement = new Vector2();
            broadPhase.MoveProxy(0, ref aabb, displacement);
            // Add your assertions here
        }
        
        /// <summary>
        ///     Tests that test get proxy
        /// </summary>
        [Fact]
        public void TestGetProxy()
        {
            BroadPhaseImplementation broadPhase = new BroadPhaseImplementation();
            FixtureProxy result = broadPhase.GetProxy(0);
            // Add your assertions here
        }
        
        /// <summary>
        ///     Tests that test touch proxy
        /// </summary>
        [Fact]
        public void TestTouchProxy()
        {
            BroadPhaseImplementation broadPhase = new BroadPhaseImplementation();
            broadPhase.TouchProxy(0);
            // Add your assertions here
        }
        
        /// <summary>
        ///     Tests that test get fat aabb
        /// </summary>
        [Fact]
        public void TestGetFatAabb()
        {
            BroadPhaseImplementation broadPhase = new BroadPhaseImplementation();
            Aabb aabb;
            broadPhase.GetFatAabb(0, out aabb);
            // Add your assertions here
        }
        
        /// <summary>
        ///     Tests that test query
        /// </summary>
        [Fact]
        public void TestQuery()
        {
            BroadPhaseImplementation broadPhase = new BroadPhaseImplementation();
            Aabb aabb = new Aabb();
            broadPhase.Query(null, ref aabb);
            // Add your assertions here
        }
        
        /// <summary>
        ///     Tests that test ray cast
        /// </summary>
        [Fact]
        public void TestRayCast()
        {
            BroadPhaseImplementation broadPhase = new BroadPhaseImplementation();
            RayCastInput input = new RayCastInput();
            broadPhase.RayCast(null, ref input);
            // Add your assertions here
        }
        
        /// <summary>
        ///     Tests that test shift origin
        /// </summary>
        [Fact]
        public void TestShiftOrigin()
        {
            BroadPhaseImplementation broadPhase = new BroadPhaseImplementation();
            Vector2 newOrigin = new Vector2();
            broadPhase.ShiftOrigin(ref newOrigin);
            // Add your assertions here
        }
    }
}