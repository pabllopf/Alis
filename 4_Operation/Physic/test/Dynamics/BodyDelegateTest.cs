// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyDelegateTest.cs
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
    ///     The body delegate test class
    /// </summary>
    public class BodyDelegateTest
    {
        /// <summary>
        ///     Tests that body delegate should be invokable
        /// </summary>
        [Fact]
        public void BodyDelegate_ShouldBeInvokable()
        {
            bool invoked = false;
            BodyDelegate callback = (sender, body) =>
            {
                invoked = true;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            
            callback(world, body);
            
            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that body delegate should receive world parameter
        /// </summary>
        [Fact]
        public void BodyDelegate_ShouldReceiveWorldParameter()
        {
            WorldPhysic capturedWorld = null;
            BodyDelegate callback = (sender, body) =>
            {
                capturedWorld = sender;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            
            callback(world, body);
            
            Assert.Equal(world, capturedWorld);
        }

        /// <summary>
        ///     Tests that body delegate should receive body parameter
        /// </summary>
        [Fact]
        public void BodyDelegate_ShouldReceiveBodyParameter()
        {
            Body capturedBody = null;
            BodyDelegate callback = (sender, body) =>
            {
                capturedBody = body;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            
            callback(world, body);
            
            Assert.Equal(body, capturedBody);
        }

        /// <summary>
        ///     Tests that body delegate should be chainable
        /// </summary>
        [Fact]
        public void BodyDelegate_ShouldBeChainable()
        {
            int callCount = 0;
            BodyDelegate callback1 = (sender, body) => callCount++;
            BodyDelegate callback2 = (sender, body) => callCount++;
            
            BodyDelegate combined = callback1 + callback2;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            
            combined(world, body);
            
            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that body delegate should be removable
        /// </summary>
        [Fact]
        public void BodyDelegate_ShouldBeRemovable()
        {
            int callCount = 0;
            BodyDelegate callback1 = (sender, body) => callCount++;
            BodyDelegate callback2 = (sender, body) => callCount++;
            
            BodyDelegate combined = callback1 + callback2;
            combined -= callback1;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            
            combined(world, body);
            
            Assert.Equal(1, callCount);
        }

        /// <summary>
        ///     Tests that body delegate should handle null world
        /// </summary>
        [Fact]
        public void BodyDelegate_ShouldHandleNullWorld()
        {
            bool invoked = false;
            BodyDelegate callback = (sender, body) =>
            {
                invoked = true;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            
            callback(null, body);
            
            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that body delegate should handle null body
        /// </summary>
        [Fact]
        public void BodyDelegate_ShouldHandleNullBody()
        {
            bool invoked = false;
            BodyDelegate callback = (sender, body) =>
            {
                invoked = true;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            
            callback(world, null);
            
            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that body delegate should support multiple invocations
        /// </summary>
        [Fact]
        public void BodyDelegate_ShouldSupportMultipleInvocations()
        {
            int count = 0;
            BodyDelegate callback = (sender, body) => count++;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            
            callback(world, body);
            callback(world, body);
            callback(world, body);
            
            Assert.Equal(3, count);
        }

        /// <summary>
        ///     Tests that body delegate should allow access to body properties
        /// </summary>
        [Fact]
        public void BodyDelegate_ShouldAllowAccessToBodyProperties()
        {
            float capturedMass = 0;
            BodyDelegate callback = (sender, body) =>
            {
                capturedMass = body.Mass;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            body.CreateFixture(shape);
            
            callback(world, body);
            
            Assert.True(capturedMass >= 0);
        }
    }
}

