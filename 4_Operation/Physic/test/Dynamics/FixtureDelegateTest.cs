// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixtureDelegateTest.cs
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
    ///     The fixture delegate test class
    /// </summary>
    public class FixtureDelegateTest
    {
        /// <summary>
        ///     Tests that fixture delegate should be invokable
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldBeInvokable()
        {
            bool invoked = false;
            FixtureDelegate callback = (sender, body, fixture) =>
            {
                invoked = true;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);
            
            callback(world, body, fixture);
            
            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that fixture delegate should receive world parameter
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldReceiveWorldParameter()
        {
            WorldPhysic capturedWorld = null;
            FixtureDelegate callback = (sender, body, fixture) =>
            {
                capturedWorld = sender;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);
            
            callback(world, body, fixture);
            
            Assert.Equal(world, capturedWorld);
        }

        /// <summary>
        ///     Tests that fixture delegate should receive body parameter
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldReceiveBodyParameter()
        {
            Body capturedBody = null;
            FixtureDelegate callback = (sender, body, fixture) =>
            {
                capturedBody = body;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);
            
            callback(world, body, fixture);
            
            Assert.Equal(body, capturedBody);
        }

        /// <summary>
        ///     Tests that fixture delegate should receive fixture parameter
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldReceiveFixtureParameter()
        {
            Fixture capturedFixture = null;
            FixtureDelegate callback = (sender, body, fixture) =>
            {
                capturedFixture = fixture;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);
            
            callback(world, body, fixture);
            
            Assert.Equal(fixture, capturedFixture);
        }

        /// <summary>
        ///     Tests that fixture delegate should be chainable
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldBeChainable()
        {
            int callCount = 0;
            FixtureDelegate callback1 = (sender, body, fixture) => callCount++;
            FixtureDelegate callback2 = (sender, body, fixture) => callCount++;
            
            FixtureDelegate combined = callback1 + callback2;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);
            
            combined(world, body, fixture);
            
            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that fixture delegate should be removable
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldBeRemovable()
        {
            int callCount = 0;
            FixtureDelegate callback1 = (sender, body, fixture) => callCount++;
            FixtureDelegate callback2 = (sender, body, fixture) => callCount++;
            
            FixtureDelegate combined = callback1 + callback2;
            combined -= callback1;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);
            
            combined(world, body, fixture);
            
            Assert.Equal(1, callCount);
        }

        /// <summary>
        ///     Tests that fixture delegate should handle null parameters
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldHandleNullParameters()
        {
            bool invoked = false;
            FixtureDelegate callback = (sender, body, fixture) =>
            {
                invoked = true;
            };
            
            callback(null, null, null);
            
            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that fixture delegate should support multiple invocations
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldSupportMultipleInvocations()
        {
            int count = 0;
            FixtureDelegate callback = (sender, body, fixture) => count++;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);
            
            callback(world, body, fixture);
            callback(world, body, fixture);
            callback(world, body, fixture);
            
            Assert.Equal(3, count);
        }
    }
}

