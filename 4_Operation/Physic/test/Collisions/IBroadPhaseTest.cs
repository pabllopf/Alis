// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IBroadPhaseTest.cs
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
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The i broad phase test class
    /// </summary>
    public class IBroadPhaseTest
    {
        /// <summary>
        ///     The test broad phase class
        /// </summary>
        /// <seealso cref="IBroadPhase" />
        private class TestBroadPhase : IBroadPhase
        {
            /// <summary>
            ///     Gets the value of the proxy count
            /// </summary>
            public int ProxyCount { get; private set; }

            /// <summary>
            ///     Updates the pairs using the specified callback
            /// </summary>
            /// <param name="callback">The callback</param>
            public void UpdatePairs(BroadphaseDelegate callback) { }

            /// <summary>
            ///     Describes whether this instance test overlap
            /// </summary>
            /// <param name="proxyIdA">The proxy id a</param>
            /// <param name="proxyIdB">The proxy id b</param>
            /// <returns>The bool</returns>
            public bool TestOverlap(int proxyIdA, int proxyIdB) => false;

            /// <summary>
            ///     Adds the proxy using the specified aabb
            /// </summary>
            /// <param name="aabb">The aabb</param>
            /// <returns>The int</returns>
            public int AddProxy(ref Aabb aabb)
            {
                ProxyCount++;
                return ProxyCount - 1;
            }

            /// <summary>
            ///     Removes the proxy using the specified proxy id
            /// </summary>
            /// <param name="proxyId">The proxy id</param>
            public void RemoveProxy(int proxyId)
            {
                ProxyCount--;
            }

            /// <summary>
            ///     Moves the proxy using the specified proxy id
            /// </summary>
            /// <param name="proxyId">The proxy id</param>
            /// <param name="aabb">The aabb</param>
            /// <param name="displacement">The displacement</param>
            public void MoveProxy(int proxyId, ref Aabb aabb, Vector2F displacement) { }

            /// <summary>
            ///     Sets the proxy using the specified proxy id
            /// </summary>
            /// <param name="proxyId">The proxy id</param>
            /// <param name="proxy">The proxy</param>
            public void SetProxy(int proxyId, ref FixtureProxy proxy) { }

            /// <summary>
            ///     Gets the proxy using the specified proxy id
            /// </summary>
            /// <param name="proxyId">The proxy id</param>
            /// <returns>The fixture proxy</returns>
            public FixtureProxy GetProxy(int proxyId) => default(FixtureProxy);

            /// <summary>
            ///     Touches the proxy using the specified proxy id
            /// </summary>
            /// <param name="proxyId">The proxy id</param>
            public void TouchProxy(int proxyId) { }

            /// <summary>
            ///     Gets the fat aabb using the specified proxy id
            /// </summary>
            /// <param name="proxyId">The proxy id</param>
            /// <param name="aabb">The aabb</param>
            public void GetFatAabb(int proxyId, out Aabb aabb)
            {
                aabb = new Aabb();
            }

            /// <summary>
            ///     Queries the callback
            /// </summary>
            /// <param name="callback">The callback</param>
            /// <param name="aabb">The aabb</param>
            public void Query(BroadPhaseQueryCallback callback, ref Aabb aabb) { }

            /// <summary>
            ///     Rays the cast using the specified callback
            /// </summary>
            /// <param name="callback">The callback</param>
            /// <param name="input">The input</param>
            public void RayCast(BroadPhaseRayCastCallback callback, ref RayCastInput input) { }

            /// <summary>
            ///     Shifts the origin using the specified new origin
            /// </summary>
            /// <param name="newOrigin">The new origin</param>
            public void ShiftOrigin(Vector2F newOrigin) { }

            /// <summary>
            ///     Gets the tree height
            /// </summary>
            /// <returns>The int</returns>
            public int GetTreeHeight() => 0;

            /// <summary>
            ///     Gets the tree balance
            /// </summary>
            /// <returns>The int</returns>
            public int GetTreeBalance() => 0;

            /// <summary>
            ///     Gets the tree quality
            /// </summary>
            /// <returns>The float</returns>
            public float GetTreeQuality() => 1.0f;
        }

        /// <summary>
        ///     Tests that i broad phase should be interface
        /// </summary>
        [Fact]
        public void IBroadPhase_ShouldBeInterface()
        {
            var type = typeof(IBroadPhase);
            
            Assert.True(type.IsInterface);
        }

        /// <summary>
        ///     Tests that test broad phase should implement i broad phase
        /// </summary>
        [Fact]
        public void TestBroadPhase_ShouldImplementIBroadPhase()
        {
            TestBroadPhase broadPhase = new TestBroadPhase();
            
            Assert.IsAssignableFrom<IBroadPhase>(broadPhase);
        }

        /// <summary>
        ///     Tests that add proxy should increase proxy count
        /// </summary>
        [Fact]
        public void AddProxy_ShouldIncreaseProxyCount()
        {
            TestBroadPhase broadPhase = new TestBroadPhase();
            Aabb aabb = new Aabb(Vector2F.Zero, new Vector2F(10, 10));
            
            broadPhase.AddProxy(ref aabb);
            
            Assert.Equal(1, broadPhase.ProxyCount);
        }

        /// <summary>
        ///     Tests that remove proxy should decrease proxy count
        /// </summary>
        [Fact]
        public void RemoveProxy_ShouldDecreaseProxyCount()
        {
            TestBroadPhase broadPhase = new TestBroadPhase();
            Aabb aabb = new Aabb(Vector2F.Zero, new Vector2F(10, 10));
            int proxyId = broadPhase.AddProxy(ref aabb);
            
            broadPhase.RemoveProxy(proxyId);
            
            Assert.Equal(0, broadPhase.ProxyCount);
        }

        /// <summary>
        ///     Tests that test overlap should be callable
        /// </summary>
        [Fact]
        public void TestOverlap_ShouldBeCallable()
        {
            TestBroadPhase broadPhase = new TestBroadPhase();
            
            bool result = broadPhase.TestOverlap(0, 1);
            
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that move proxy should be callable
        /// </summary>
        [Fact]
        public void MoveProxy_ShouldBeCallable()
        {
            TestBroadPhase broadPhase = new TestBroadPhase();
            Aabb aabb = new Aabb(Vector2F.Zero, new Vector2F(10, 10));
            Vector2F displacement = new Vector2F(1, 1);
            
            broadPhase.MoveProxy(0, ref aabb, displacement);
            
            Assert.NotNull(broadPhase);
        }

        /// <summary>
        ///     Tests that get fat aabb should be callable
        /// </summary>
        [Fact]
        public void GetFatAabb_ShouldBeCallable()
        {
            TestBroadPhase broadPhase = new TestBroadPhase();
            
            broadPhase.GetFatAabb(0, out Aabb aabb);
            
            Assert.NotNull(aabb);
        }

        /// <summary>
        ///     Tests that shift origin should be callable
        /// </summary>
        [Fact]
        public void ShiftOrigin_ShouldBeCallable()
        {
            TestBroadPhase broadPhase = new TestBroadPhase();
            Vector2F newOrigin = new Vector2F(100, 100);
            
            broadPhase.ShiftOrigin(newOrigin);
            
            Assert.NotNull(broadPhase);
        }

        /// <summary>
        ///     Tests that get tree height should return value
        /// </summary>
        [Fact]
        public void GetTreeHeight_ShouldReturnValue()
        {
            TestBroadPhase broadPhase = new TestBroadPhase();
            
            int height = broadPhase.GetTreeHeight();
            
            Assert.Equal(0, height);
        }

        /// <summary>
        ///     Tests that get tree balance should return value
        /// </summary>
        [Fact]
        public void GetTreeBalance_ShouldReturnValue()
        {
            TestBroadPhase broadPhase = new TestBroadPhase();
            
            int balance = broadPhase.GetTreeBalance();
            
            Assert.Equal(0, balance);
        }

        /// <summary>
        ///     Tests that get tree quality should return value
        /// </summary>
        [Fact]
        public void GetTreeQuality_ShouldReturnValue()
        {
            TestBroadPhase broadPhase = new TestBroadPhase();
            
            float quality = broadPhase.GetTreeQuality();
            
            Assert.Equal(1.0f, quality);
        }
    }
}

