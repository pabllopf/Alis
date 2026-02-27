// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RayCastReportFixtureDelegateTest.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The ray cast report fixture delegate test class
    /// </summary>
    public class RayCastReportFixtureDelegateTest
    {
        /// <summary>
        ///     Tests that delegate should be invokable with fixture parameters
        /// </summary>
        [Fact]
        public void Delegate_ShouldBeInvokableWithFixtureParameters()
        {
            bool invoked = false;
            RayCastReportFixtureDelegate callback = (fixture, point, normal, fraction) =>
            {
                invoked = true;
                return 1.0f;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);
            
            float result = callback(fixture, Vector2F.Zero, Vector2F.UnitY, 0.5f);
            
            Assert.True(invoked);
            Assert.Equal(1.0f, result);
        }

        /// <summary>
        ///     Tests that delegate should return negative one to ignore fixture
        /// </summary>
        [Fact]
        public void Delegate_ShouldReturnNegativeOne_ToIgnoreFixture()
        {
            RayCastReportFixtureDelegate callback = (fixture, point, normal, fraction) => -1.0f;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);
            
            float result = callback(fixture, Vector2F.Zero, Vector2F.UnitY, 0.5f);
            
            Assert.Equal(-1.0f, result);
        }

        /// <summary>
        ///     Tests that delegate should return zero to terminate raycast
        /// </summary>
        [Fact]
        public void Delegate_ShouldReturnZero_ToTerminateRaycast()
        {
            RayCastReportFixtureDelegate callback = (fixture, point, normal, fraction) => 0.0f;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);
            
            float result = callback(fixture, Vector2F.Zero, Vector2F.UnitY, 0.5f);
            
            Assert.Equal(0.0f, result);
        }

        /// <summary>
        ///     Tests that delegate should return fraction to clip ray
        /// </summary>
        [Fact]
        public void Delegate_ShouldReturnFraction_ToClipRay()
        {
            RayCastReportFixtureDelegate callback = (fixture, point, normal, fraction) => fraction;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);
            
            float result = callback(fixture, Vector2F.Zero, Vector2F.UnitY, 0.75f);
            
            Assert.Equal(0.75f, result);
        }

        /// <summary>
        ///     Tests that delegate should handle null fixture
        /// </summary>
        [Fact]
        public void Delegate_ShouldHandleNullFixture()
        {
            RayCastReportFixtureDelegate callback = (fixture, point, normal, fraction) =>
            {
                return fixture == null ? -1.0f : 1.0f;
            };
            
            float result = callback(null, Vector2F.Zero, Vector2F.UnitY, 0.5f);
            
            Assert.Equal(-1.0f, result);
        }

        /// <summary>
        ///     Tests that delegate should be chainable
        /// </summary>
        [Fact]
        public void Delegate_ShouldBeChainable()
        {
            int callCount = 0;
            RayCastReportFixtureDelegate callback1 = (f, p, n, fr) => { callCount++; return 1.0f; };
            RayCastReportFixtureDelegate callback2 = (f, p, n, fr) => { callCount++; return 1.0f; };
            
            RayCastReportFixtureDelegate combined = callback1 + callback2;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);
            
            combined(fixture, Vector2F.Zero, Vector2F.UnitY, 0.5f);
            
            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that delegate should receive correct point parameter
        /// </summary>
        [Fact]
        public void Delegate_ShouldReceiveCorrectPointParameter()
        {
            Vector2F capturedPoint = Vector2F.Zero;
            RayCastReportFixtureDelegate callback = (fixture, point, normal, fraction) =>
            {
                capturedPoint = point;
                return 1.0f;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);
            Vector2F testPoint = new Vector2F(5, 10);
            
            callback(fixture, testPoint, Vector2F.UnitY, 0.5f);
            
            Assert.Equal(testPoint, capturedPoint);
        }

        /// <summary>
        ///     Tests that delegate should receive correct normal parameter
        /// </summary>
        [Fact]
        public void Delegate_ShouldReceiveCorrectNormalParameter()
        {
            Vector2F capturedNormal = Vector2F.Zero;
            RayCastReportFixtureDelegate callback = (fixture, point, normal, fraction) =>
            {
                capturedNormal = normal;
                return 1.0f;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);
            Vector2F testNormal = new Vector2F(0, 1);
            
            callback(fixture, Vector2F.Zero, testNormal, 0.5f);
            
            Assert.Equal(testNormal, capturedNormal);
        }

        /// <summary>
        ///     Tests that delegate should receive correct fraction parameter
        /// </summary>
        [Fact]
        public void Delegate_ShouldReceiveCorrectFractionParameter()
        {
            float capturedFraction = 0;
            RayCastReportFixtureDelegate callback = (fixture, point, normal, fraction) =>
            {
                capturedFraction = fraction;
                return 1.0f;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);
            
            callback(fixture, Vector2F.Zero, Vector2F.UnitY, 0.8f);
            
            Assert.Equal(0.8f, capturedFraction);
        }
    }
}

