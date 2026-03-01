// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BroadphaseDelegateTest.cs
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

using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The broadphase delegate test class
    /// </summary>
    public class BroadphaseDelegateTest
    {
        /// <summary>
        ///     Tests that broadphase delegate should be invokable
        /// </summary>
        [Fact]
        public void BroadphaseDelegate_ShouldBeInvokable()
        {
            bool invoked = false;
            BroadphaseDelegate callback = (proxyIdA, proxyIdB) =>
            {
                invoked = true;
            };
            
            callback(0, 1);
            
            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that broadphase delegate should receive proxy id a
        /// </summary>
        [Fact]
        public void BroadphaseDelegate_ShouldReceiveProxyIdA()
        {
            int capturedProxyIdA = -1;
            BroadphaseDelegate callback = (proxyIdA, proxyIdB) =>
            {
                capturedProxyIdA = proxyIdA;
            };
            
            callback(42, 0);
            
            Assert.Equal(42, capturedProxyIdA);
        }

        /// <summary>
        ///     Tests that broadphase delegate should receive proxy id b
        /// </summary>
        [Fact]
        public void BroadphaseDelegate_ShouldReceiveProxyIdB()
        {
            int capturedProxyIdB = -1;
            BroadphaseDelegate callback = (proxyIdA, proxyIdB) =>
            {
                capturedProxyIdB = proxyIdB;
            };
            
            callback(0, 99);
            
            Assert.Equal(99, capturedProxyIdB);
        }

        /// <summary>
        ///     Tests that broadphase delegate should be chainable
        /// </summary>
        [Fact]
        public void BroadphaseDelegate_ShouldBeChainable()
        {
            int callCount = 0;
            BroadphaseDelegate callback1 = (a, b) => callCount++;
            BroadphaseDelegate callback2 = (a, b) => callCount++;
            
            BroadphaseDelegate combined = callback1 + callback2;
            
            combined(0, 1);
            
            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that broadphase delegate should be removable
        /// </summary>
        [Fact]
        public void BroadphaseDelegate_ShouldBeRemovable()
        {
            int callCount = 0;
            BroadphaseDelegate callback1 = (a, b) => callCount++;
            BroadphaseDelegate callback2 = (a, b) => callCount++;
            
            BroadphaseDelegate combined = callback1 + callback2;
            combined -= callback1;
            
            combined(0, 1);
            
            Assert.Equal(1, callCount);
        }

        /// <summary>
        ///     Tests that broadphase delegate should handle negative proxy ids
        /// </summary>
        [Fact]
        public void BroadphaseDelegate_ShouldHandleNegativeProxyIds()
        {
            bool invoked = false;
            BroadphaseDelegate callback = (proxyIdA, proxyIdB) =>
            {
                invoked = true;
            };
            
            callback(-1, -1);
            
            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that broadphase delegate should handle zero proxy ids
        /// </summary>
        [Fact]
        public void BroadphaseDelegate_ShouldHandleZeroProxyIds()
        {
            bool invoked = false;
            BroadphaseDelegate callback = (proxyIdA, proxyIdB) =>
            {
                invoked = true;
            };
            
            callback(0, 0);
            
            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that broadphase delegate should support multiple invocations
        /// </summary>
        [Fact]
        public void BroadphaseDelegate_ShouldSupportMultipleInvocations()
        {
            int count = 0;
            BroadphaseDelegate callback = (a, b) => count++;
            
            callback(0, 1);
            callback(1, 2);
            callback(2, 3);
            
            Assert.Equal(3, count);
        }

        /// <summary>
        ///     Tests that broadphase delegate should capture both parameters correctly
        /// </summary>
        [Fact]
        public void BroadphaseDelegate_ShouldCaptureBothParametersCorrectly()
        {
            int capturedA = -1;
            int capturedB = -1;
            BroadphaseDelegate callback = (proxyIdA, proxyIdB) =>
            {
                capturedA = proxyIdA;
                capturedB = proxyIdB;
            };
            
            callback(10, 20);
            
            Assert.Equal(10, capturedA);
            Assert.Equal(20, capturedB);
        }

        /// <summary>
        ///     Tests that broadphase delegate should handle large proxy ids
        /// </summary>
        [Fact]
        public void BroadphaseDelegate_ShouldHandleLargeProxyIds()
        {
            bool invoked = false;
            BroadphaseDelegate callback = (proxyIdA, proxyIdB) =>
            {
                invoked = true;
            };
            
            callback(int.MaxValue, int.MaxValue);
            
            Assert.True(invoked);
        }
    }
}

