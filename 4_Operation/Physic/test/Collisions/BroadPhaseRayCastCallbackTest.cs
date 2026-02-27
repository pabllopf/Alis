// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BroadPhaseRayCastCallbackTest.cs
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
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The broad phase ray cast callback test class
    /// </summary>
    public class BroadPhaseRayCastCallbackTest
    {
        /// <summary>
        ///     Tests that broad phase ray cast callback should be invokable
        /// </summary>
        [Fact]
        public void BroadPhaseRayCastCallback_ShouldBeInvokable()
        {
            bool invoked = false;
            BroadPhaseRayCastCallback callback = (ref RayCastInput input, int proxyId) =>
            {
                invoked = true;
                return 1.0f;
            };
            
            RayCastInput rayCastInput = new RayCastInput
            {
                Point1 = Vector2F.Zero,
                Point2 = new Vector2F(10, 10),
                MaxFraction = 1.0f
            };
            
            float result = callback(ref rayCastInput, 0);
            
            Assert.True(invoked);
            Assert.Equal(1.0f, result);
        }

        /// <summary>
        ///     Tests that callback should receive ray cast input by reference
        /// </summary>
        [Fact]
        public void Callback_ShouldReceiveRayCastInputByReference()
        {
            RayCastInput capturedInput = default;
            BroadPhaseRayCastCallback callback = (ref RayCastInput input, int proxyId) =>
            {
                capturedInput = input;
                return 1.0f;
            };
            
            RayCastInput rayCastInput = new RayCastInput
            {
                Point1 = new Vector2F(1, 2),
                Point2 = new Vector2F(3, 4),
                MaxFraction = 0.5f
            };
            
            callback(ref rayCastInput, 0);
            
            Assert.Equal(new Vector2F(1, 2), capturedInput.Point1);
            Assert.Equal(new Vector2F(3, 4), capturedInput.Point2);
        }

        /// <summary>
        ///     Tests that callback should receive proxy id parameter
        /// </summary>
        [Fact]
        public void Callback_ShouldReceiveProxyIdParameter()
        {
            int capturedProxyId = -1;
            BroadPhaseRayCastCallback callback = (ref RayCastInput input, int proxyId) =>
            {
                capturedProxyId = proxyId;
                return 1.0f;
            };
            
            RayCastInput rayCastInput = new RayCastInput();
            callback(ref rayCastInput, 99);
            
            Assert.Equal(99, capturedProxyId);
        }

        /// <summary>
        ///     Tests that callback should return negative one to ignore proxy
        /// </summary>
        [Fact]
        public void Callback_ShouldReturnNegativeOne_ToIgnoreProxy()
        {
            BroadPhaseRayCastCallback callback = (ref RayCastInput input, int proxyId) => -1.0f;
            
            RayCastInput rayCastInput = new RayCastInput();
            float result = callback(ref rayCastInput, 0);
            
            Assert.Equal(-1.0f, result);
        }

        /// <summary>
        ///     Tests that callback should return zero to terminate ray cast
        /// </summary>
        [Fact]
        public void Callback_ShouldReturnZero_ToTerminateRayCast()
        {
            BroadPhaseRayCastCallback callback = (ref RayCastInput input, int proxyId) => 0.0f;
            
            RayCastInput rayCastInput = new RayCastInput();
            float result = callback(ref rayCastInput, 0);
            
            Assert.Equal(0.0f, result);
        }

        /// <summary>
        ///     Tests that callback should return fraction to clip ray
        /// </summary>
        [Fact]
        public void Callback_ShouldReturnFraction_ToClipRay()
        {
            BroadPhaseRayCastCallback callback = (ref RayCastInput input, int proxyId) => input.MaxFraction;
            
            RayCastInput rayCastInput = new RayCastInput { MaxFraction = 0.75f };
            float result = callback(ref rayCastInput, 0);
            
            Assert.Equal(0.75f, result);
        }

        /// <summary>
        ///     Tests that callback should be chainable
        /// </summary>
        [Fact]
        public void Callback_ShouldBeChainable()
        {
            int callCount = 0;
            BroadPhaseRayCastCallback callback1 = (ref RayCastInput input, int id) => { callCount++; return 1.0f; };
            BroadPhaseRayCastCallback callback2 = (ref RayCastInput input, int id) => { callCount++; return 1.0f; };
            
            BroadPhaseRayCastCallback combined = callback1 + callback2;
            
            RayCastInput rayCastInput = new RayCastInput();
            combined(ref rayCastInput, 0);
            
            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that callback should be removable
        /// </summary>
        [Fact]
        public void Callback_ShouldBeRemovable()
        {
            int callCount = 0;
            BroadPhaseRayCastCallback callback1 = (ref RayCastInput input, int id) => { callCount++; return 1.0f; };
            BroadPhaseRayCastCallback callback2 = (ref RayCastInput input, int id) => { callCount++; return 1.0f; };
            
            BroadPhaseRayCastCallback combined = callback1 + callback2;
            combined -= callback1;
            
            RayCastInput rayCastInput = new RayCastInput();
            combined(ref rayCastInput, 0);
            
            Assert.Equal(1, callCount);
        }

        /// <summary>
        ///     Tests that callback should handle large proxy ids
        /// </summary>
        [Fact]
        public void Callback_ShouldHandleLargeProxyIds()
        {
            int capturedId = -1;
            BroadPhaseRayCastCallback callback = (ref RayCastInput input, int proxyId) =>
            {
                capturedId = proxyId;
                return 1.0f;
            };
            
            RayCastInput rayCastInput = new RayCastInput();
            callback(ref rayCastInput, int.MaxValue);
            
            Assert.Equal(int.MaxValue, capturedId);
        }

        /// <summary>
        ///     Tests that callback should allow modifying input
        /// </summary>
        [Fact]
        public void Callback_ShouldAllowModifyingInput()
        {
            BroadPhaseRayCastCallback callback = (ref RayCastInput input, int proxyId) =>
            {
                input.MaxFraction = 0.5f;
                return 1.0f;
            };
            
            RayCastInput rayCastInput = new RayCastInput { MaxFraction = 1.0f };
            callback(ref rayCastInput, 0);
            
            Assert.Equal(0.5f, rayCastInput.MaxFraction);
        }

        /// <summary>
        ///     Tests that callback should support multiple invocations with different inputs
        /// </summary>
        [Fact]
        public void Callback_ShouldSupportMultipleInvocationsWithDifferentInputs()
        {
            int count = 0;
            BroadPhaseRayCastCallback callback = (ref RayCastInput input, int id) =>
            {
                count++;
                return 1.0f;
            };
            
            RayCastInput input1 = new RayCastInput { Point1 = Vector2F.Zero };
            RayCastInput input2 = new RayCastInput { Point1 = new Vector2F(10, 10) };
            
            callback(ref input1, 0);
            callback(ref input2, 1);
            
            Assert.Equal(2, count);
        }
    }
}

