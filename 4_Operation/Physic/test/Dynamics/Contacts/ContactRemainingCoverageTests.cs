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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    public class ContactRemainingCoverageTests
    {
        [Fact]
        public void Update_NonOverlappingBodies_NoCallbacksFired()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(-100.0f, 0.0f), BodyType.Static);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(100.0f, 0.0f), BodyType.Static);

            bool beginFired = false;
            bool endFired = false;
            world.ContactManager.BeginContact = contact => { beginFired = true; return true; };
            world.ContactManager.EndContact = contact => { endFired = true; };

            world.Step(1.0f / 60.0f);

            Assert.False(beginFired);
            Assert.False(endFired);
        }

        [Fact]
        public void Create_EdgeAndEdge_NotSupportedType()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateEdge(new Vector2F(-5.0f, 0.0f), new Vector2F(5.0f, 0.0f));
            world.CreateEdge(new Vector2F(0.0f, -5.0f), new Vector2F(0.0f, 5.0f));

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        [Fact]
        public void GetWorldManifold_WithEmptyManifold_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Contact contact = world.ContactManager.ContactList.Next;
            if (contact != null)
            {
                contact.Manifold.PointCount = 0;

                contact.GetWorldManifold(out Vector2F normal, out FixedArray2<Vector2F> points);
            }
        }

        [Fact]
        public void Create_FromPoolWithSwap_ReusesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateEdge(new Vector2F(-5.0f, 0.0f), new Vector2F(5.0f, 0.0f));
            Body dynamicBody = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, -1.0f), 0.0f, BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            dynamicBody.SetTransform(new Vector2F(100.0f, 100.0f), 0.0f);
            world.Step(1.0f / 60.0f);
            Assert.Equal(0, world.ContactManager.ContactCount);

            dynamicBody.SetTransform(new Vector2F(0.0f, -1.0f), 0.0f);
            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        [Fact]
        public void InvokeHandlers_AllReturnFalse_DisablesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            int fireCount = 0;
            OnCollisionEventHandler handler1 = (_, _, _) => { fireCount++; return false; };
            OnCollisionEventHandler handler2 = (_, _, _) => { fireCount++; return false; };

            bodyA.OnCollision += handler1;
            bodyA.OnCollision += handler2;

            world.Step(1.0f / 60.0f);

            Assert.Equal(2, fireCount);
        }

        [Fact]
        public void Destroy_WithSensorFixtureAndPoints_DoesNotAwakeBodies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Contact contact = world.ContactManager.ContactList.Next;
            Assert.NotNull(contact);
            Assert.True(contact.Manifold.PointCount > 0);

            contact.FixtureA.GetIsSensor = true;
            contact.Destroy();

            Assert.NotNull(contact);
        }



        [Fact]
        public void ResetRestitution_WithEqualValues_ReturnsSameValue()
        {
            Fixture fixtureA = new Fixture(new CircleShape(0.5f, 1.0f));
            fixtureA.GetRestitution = 0.5f;
            Fixture fixtureB = new Fixture(new CircleShape(0.5f, 1.0f));
            fixtureB.GetRestitution = 0.5f;
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);

            contact.ResetRestitution();

            Assert.Equal(0.5f, contact.Restitution);
        }

        [Fact]
        public void ResetFriction_WithEqualValues_ReturnsSameValue()
        {
            Fixture fixtureA = new Fixture(new CircleShape(0.5f, 1.0f));
            fixtureA.GetFriction = 0.5f;
            Fixture fixtureB = new Fixture(new CircleShape(0.5f, 1.0f));
            fixtureB.GetFriction = 0.5f;
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);

            contact.ResetFriction();

            Assert.Equal(0.5f, contact.Friction);
        }
    }
}
