// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactRemainingCoverageTests.cs
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

using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The contact remaining coverage tests class
    /// </summary>
    public class ContactRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that create from pool with equal shape types resets without swapping.
        /// </summary>
        [Fact]
        public void Create_FromPool_WithEqualShapeTypes_ResetsUnswapped()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body pooledA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body pooledB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Contact pooled = world.ContactManager.ContactList.Next;
            Assert.NotNull(pooled);
            world.ContactManager.Destroy(pooled);

            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Fixture circleA = bodyA.CreateFixture(new CircleShape(0.5f, 1.0f));
            Fixture circleB = bodyB.CreateFixture(new CircleShape(0.5f, 1.0f));
            Contact result = Contact.Create(world.ContactManager, circleA, 0, circleB, 0);

            Assert.NotNull(result);
            Assert.Equal(circleA, result.FixtureA);
            Assert.Equal(circleB, result.FixtureB);
        }

        /// <summary>
        ///     Tests that create returns null when the null override is set.
        /// </summary>
        [Fact]
        public void Create_WithNullOverride_ReturnsNull()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Body bodyB = world.CreateBody(Vector2F.Zero, 0, BodyType.Dynamic);
            Fixture circleA = bodyA.CreateFixture(new CircleShape(0.5f, 1.0f));
            Fixture circleB = bodyB.CreateFixture(new CircleShape(0.5f, 1.0f));

            FieldInfo field = typeof(Contact).GetField("ReturnNullOverride",
                BindingFlags.NonPublic | BindingFlags.Static);
            field.SetValue(null, true);
            try
            {
                Contact result = Contact.Create(world.ContactManager, circleA, 0, circleB, 0);

                Assert.Null(result);
            }
            finally
            {
                field.SetValue(null, false);
            }
        }

        /// <summary>
        ///     Tests that get world manifold computes the world space normal and points.
        /// </summary>
        [Fact]
        public void GetWorldManifold_WithTouchingFixtures_ComputesNormal()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Contact contact = world.ContactManager.ContactList.Next;
            Assert.NotNull(contact);

            contact.GetWorldManifold(out Vector2F normal, out FixedArray2<Vector2F> points);

            Assert.True(normal.Length() > 0.0f);
        }

        /// <summary>
        ///     Tests that report collision invokes every registered handler.
        /// </summary>
        [Fact]
        public void ReportCollision_WithMultipleHandlers_InvokesAll()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            int invoked = 0;
            OnCollisionEventHandler handler = (sender, other, contact) =>
            {
                invoked++;
                return true;
            };

            Fixture fixtureA = bodyA.FixtureList[0];
            fixtureA.OnCollision += handler;
            fixtureA.OnCollision += handler;

            world.Step(1.0f / 60.0f);

            Contact contact = world.ContactManager.ContactList.Next;
            Assert.NotNull(contact);
            contact.ReportCollision(bodyA, bodyB, world.ContactManager);

            Assert.True(invoked >= 2);
        }

        /// <summary>
        ///     Tests that report separation invokes the end contact callback.
        /// </summary>
        [Fact]
        public void ReportSeparation_WithEndContactHandler_InvokesCallback()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Contact contact = world.ContactManager.ContactList.Next;
            Assert.NotNull(contact);
            int invoked = 0;
            world.ContactManager.EndContact += c => invoked++;

            contact.ReportSeparation(bodyA, bodyB, world.ContactManager);

            Assert.Equal(1, invoked);
        }

        /// <summary>
        ///     Tests that process pre solve invokes the pre solve callback.
        /// </summary>
        [Fact]
        public void ProcessPreSolve_WithHandler_InvokesCallback()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);

            Contact contact = world.ContactManager.ContactList.Next;
            Assert.NotNull(contact);
            int invoked = 0;
            world.ContactManager.PreSolve += (Contact c, ref Manifold oldManifold) => invoked++;

            contact.ProcessPreSolve(world.ContactManager, new Manifold());

            Assert.Equal(1, invoked);
        }
    }
}
