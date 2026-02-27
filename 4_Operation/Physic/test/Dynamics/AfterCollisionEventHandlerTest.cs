// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AfterCollisionEventHandlerTest.cs
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
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The after collision event handler test class
    /// </summary>
    public class AfterCollisionEventHandlerTest
    {
        /// <summary>
        ///     Tests that after collision event handler should be invokable
        /// </summary>
        [Fact]
        public void AfterCollisionEventHandler_ShouldBeInvokable()
        {
            bool invoked = false;
            AfterCollisionEventHandler handler = (sender, other, contact, impulse) =>
            {
                invoked = true;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(shapeA);
            Fixture fixtureB = bodyB.CreateFixture(shapeB);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            ContactVelocityConstraint impulse = new ContactVelocityConstraint();
            
            handler(fixtureA, fixtureB, contact, impulse);
            
            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that handler should receive sender fixture
        /// </summary>
        [Fact]
        public void Handler_ShouldReceiveSenderFixture()
        {
            Fixture capturedSender = null;
            AfterCollisionEventHandler handler = (sender, other, contact, impulse) =>
            {
                capturedSender = sender;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(shapeA);
            Fixture fixtureB = bodyB.CreateFixture(shapeB);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            ContactVelocityConstraint impulse = new ContactVelocityConstraint();
            
            handler(fixtureA, fixtureB, contact, impulse);
            
            Assert.Equal(fixtureA, capturedSender);
        }

        /// <summary>
        ///     Tests that handler should receive other fixture
        /// </summary>
        [Fact]
        public void Handler_ShouldReceiveOtherFixture()
        {
            Fixture capturedOther = null;
            AfterCollisionEventHandler handler = (sender, other, contact, impulse) =>
            {
                capturedOther = other;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(shapeA);
            Fixture fixtureB = bodyB.CreateFixture(shapeB);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            ContactVelocityConstraint impulse = new ContactVelocityConstraint();
            
            handler(fixtureA, fixtureB, contact, impulse);
            
            Assert.Equal(fixtureB, capturedOther);
        }

        /// <summary>
        ///     Tests that handler should receive contact
        /// </summary>
        [Fact]
        public void Handler_ShouldReceiveContact()
        {
            Contact capturedContact = null;
            AfterCollisionEventHandler handler = (sender, other, contact, impulse) =>
            {
                capturedContact = contact;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(shapeA);
            Fixture fixtureB = bodyB.CreateFixture(shapeB);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            ContactVelocityConstraint impulse = new ContactVelocityConstraint();
            
            handler(fixtureA, fixtureB, contact, impulse);
            
            Assert.Equal(contact, capturedContact);
        }

        /// <summary>
        ///     Tests that handler should receive impulse
        /// </summary>
        [Fact]
        public void Handler_ShouldReceiveImpulse()
        {
            ContactVelocityConstraint capturedImpulse = null;
            AfterCollisionEventHandler handler = (sender, other, contact, impulse) =>
            {
                capturedImpulse = impulse;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(shapeA);
            Fixture fixtureB = bodyB.CreateFixture(shapeB);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            ContactVelocityConstraint impulse = new ContactVelocityConstraint();
            
            handler(fixtureA, fixtureB, contact, impulse);
            
            Assert.Equal(impulse, capturedImpulse);
        }

        /// <summary>
        ///     Tests that handler should be chainable
        /// </summary>
        [Fact]
        public void Handler_ShouldBeChainable()
        {
            int callCount = 0;
            AfterCollisionEventHandler handler1 = (s, o, c, i) => callCount++;
            AfterCollisionEventHandler handler2 = (s, o, c, i) => callCount++;
            
            AfterCollisionEventHandler combined = handler1 + handler2;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(shapeA);
            Fixture fixtureB = bodyB.CreateFixture(shapeB);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            ContactVelocityConstraint impulse = new ContactVelocityConstraint();
            
            combined(fixtureA, fixtureB, contact, impulse);
            
            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that handler should be removable
        /// </summary>
        [Fact]
        public void Handler_ShouldBeRemovable()
        {
            int callCount = 0;
            AfterCollisionEventHandler handler1 = (s, o, c, i) => callCount++;
            AfterCollisionEventHandler handler2 = (s, o, c, i) => callCount++;
            
            AfterCollisionEventHandler combined = handler1 + handler2;
            combined -= handler1;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(shapeA);
            Fixture fixtureB = bodyB.CreateFixture(shapeB);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            ContactVelocityConstraint impulse = new ContactVelocityConstraint();
            
            combined(fixtureA, fixtureB, contact, impulse);
            
            Assert.Equal(1, callCount);
        }

        /// <summary>
        ///     Tests that handler should handle null parameters
        /// </summary>
        [Fact]
        public void Handler_ShouldHandleNullParameters()
        {
            bool invoked = false;
            AfterCollisionEventHandler handler = (sender, other, contact, impulse) =>
            {
                invoked = true;
            };
            
            handler(null, null, null, null);
            
            Assert.True(invoked);
        }
    }
}

