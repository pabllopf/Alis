// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PreSolveDelegateTest.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The pre solve delegate test class
    /// </summary>
    public class PreSolveDelegateTest
    {
        /// <summary>
        ///     Tests that pre solve delegate should be invokable
        /// </summary>
        [Fact]
        public void PreSolveDelegate_ShouldBeInvokable()
        {
            bool invoked = false;
            PreSolveDelegate callback = (Contact contact, ref Manifold oldManifold) =>
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
            Manifold manifold = new Manifold();
            
            callback(contact, ref manifold);
            
            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that pre solve delegate should receive contact parameter
        /// </summary>
        [Fact]
        public void PreSolveDelegate_ShouldReceiveContactParameter()
        {
            Contact capturedContact = null;
            PreSolveDelegate callback = (Contact contact, ref Manifold oldManifold) =>
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
            Manifold manifold = new Manifold();
            
            callback(contact, ref manifold);
            
            Assert.Equal(contact, capturedContact);
        }

        /// <summary>
        ///     Tests that pre solve delegate should allow modifying manifold
        /// </summary>
        [Fact]
        public void PreSolveDelegate_ShouldAllowModifyingManifold()
        {
            PreSolveDelegate callback = (Contact contact, ref Manifold oldManifold) =>
            {
                oldManifold.Type = ManifoldType.FaceA;
            };
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(shapeA);
            Fixture fixtureB = bodyB.CreateFixture(shapeB);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            Manifold manifold = new Manifold();
            
            callback(contact, ref manifold);
            
            Assert.Equal(ManifoldType.FaceA, manifold.Type);
        }

        /// <summary>
        ///     Tests that pre solve delegate should be chainable
        /// </summary>
        [Fact]
        public void PreSolveDelegate_ShouldBeChainable()
        {
            int callCount = 0;
            PreSolveDelegate callback1 = (Contact contact, ref Manifold oldManifold) => callCount++;
            PreSolveDelegate callback2 = (Contact contact, ref Manifold oldManifold) => callCount++;
            
            PreSolveDelegate combined = callback1 + callback2;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(shapeA);
            Fixture fixtureB = bodyB.CreateFixture(shapeB);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            Manifold manifold = new Manifold();
            
            combined(contact, ref manifold);
            
            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that pre solve delegate should be removable
        /// </summary>
        [Fact]
        public void PreSolveDelegate_ShouldBeRemovable()
        {
            int callCount = 0;
            PreSolveDelegate callback1 = (Contact contact, ref Manifold oldManifold) => callCount++;
            PreSolveDelegate callback2 = (Contact contact, ref Manifold oldManifold) => callCount++;
            
            PreSolveDelegate combined = callback1 + callback2;
            combined -= callback1;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(shapeA);
            Fixture fixtureB = bodyB.CreateFixture(shapeB);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            Manifold manifold = new Manifold();
            
            combined(contact, ref manifold);
            
            Assert.Equal(1, callCount);
        }

        /// <summary>
        ///     Tests that pre solve delegate should handle null contact
        /// </summary>
        [Fact]
        public void PreSolveDelegate_ShouldHandleNullContact()
        {
            bool invoked = false;
            PreSolveDelegate callback = (Contact contact, ref Manifold oldManifold) =>
            {
                invoked = true;
            };
            
            Manifold manifold = new Manifold();
            callback(null, ref manifold);
            
            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that pre solve delegate should support multiple invocations
        /// </summary>
        [Fact]
        public void PreSolveDelegate_ShouldSupportMultipleInvocations()
        {
            int count = 0;
            PreSolveDelegate callback = (Contact contact, ref Manifold oldManifold) => count++;
            
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            Fixture fixtureA = bodyA.CreateFixture(shapeA);
            Fixture fixtureB = bodyB.CreateFixture(shapeB);
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);
            Manifold manifold = new Manifold();
            
            callback(contact, ref manifold);
            callback(contact, ref manifold);
            callback(contact, ref manifold);
            
            Assert.Equal(3, count);
        }
    }
}

