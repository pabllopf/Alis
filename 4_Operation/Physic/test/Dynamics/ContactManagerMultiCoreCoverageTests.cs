// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactManagerMultiCoreCoverageTests.cs
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

using System;
using System.Threading.Tasks;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The contact manager multi core coverage tests class
    /// </summary>
    public class ContactManagerMultiCoreCoverageTests
    {
        /// <summary>
        ///     Creates a standalone contact between two bodies not attached to any world.
        /// </summary>
        private static Contact CreateStandaloneContact(ContactManager contactManager, DynamicTreeBroadPhase broadPhase, Body bodyA, Body bodyB, Vector2F positionA, Vector2F positionB)
        {
            bodyA.Position = positionA;
            bodyB.Position = positionB;
            Fixture fixtureA = new Fixture(new CircleShape(1.0f, 1.0f));
            Fixture fixtureB = new Fixture(new CircleShape(1.0f, 1.0f));
            bodyA.Add(fixtureA);
            bodyB.Add(fixtureB);
            bodyA.GetBodyType = BodyType.Dynamic;
            bodyB.GetBodyType = BodyType.Dynamic;
            fixtureA.CreateProxies(broadPhase, ref bodyA.Xf);
            fixtureB.CreateProxies(broadPhase, ref bodyB.Xf);
            contactManager.AddPair(fixtureA.Proxies[0].ProxyId, fixtureB.Proxies[0].ProxyId);
            return contactManager.ContactList.Next;
        }

        /// <summary>
        ///     Tests that collide multi core updates all overlapping contacts and releases the locks.
        /// </summary>
        [Fact]
        public void CollideMultiCore_WithOverlappingContacts_UpdatesAllContacts()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            ContactManager contactManager = new ContactManager(broadPhase);
            Body bodyA = new Body();
            Body bodyB = new Body();
            Body bodyC = new Body();
            Body bodyD = new Body();

            CreateStandaloneContact(contactManager, broadPhase, bodyA, bodyB, new Vector2F(0.0f, 0.0f), new Vector2F(0.5f, 0.0f));
            CreateStandaloneContact(contactManager, broadPhase, bodyC, bodyD, new Vector2F(10.0f, 0.0f), new Vector2F(10.5f, 0.0f));

            contactManager.CollideMultiCore();

            Assert.Equal(2, contactManager.ContactCount);
            Assert.Equal(0, bodyA.Lock);
            Assert.Equal(0, bodyB.Lock);
            Assert.Equal(0, bodyC.Lock);
            Assert.Equal(0, bodyD.Lock);
        }

        /// <summary>
        ///     Tests that collide multi core destroys contacts whose proxies no longer overlap.
        /// </summary>
        [Fact]
        public void CollideMultiCore_WithSeparatedContacts_DestroysThem()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            ContactManager contactManager = new ContactManager(broadPhase);
            Body bodyA = new Body();
            Body bodyB = new Body();

            CreateStandaloneContact(contactManager, broadPhase, bodyA, bodyB, new Vector2F(0.0f, 0.0f), new Vector2F(100.0f, 0.0f));

            contactManager.CollideMultiCore();

            Assert.Equal(0, contactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that collide multi core keeps the contact when one body is disabled.
        /// </summary>
        [Fact]
        public void CollideMultiCore_WithDisabledBody_KeepsContact()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            ContactManager contactManager = new ContactManager(broadPhase);
            Body bodyA = new Body();
            Body bodyB = new Body();

            CreateStandaloneContact(contactManager, broadPhase, bodyA, bodyB, new Vector2F(0.0f, 0.0f), new Vector2F(0.5f, 0.0f));
            bodyB.Enabled = false;

            contactManager.CollideMultiCore();

            Assert.Equal(1, contactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that collide multi core keeps the contact when both bodies are sleeping.
        /// </summary>
        [Fact]
        public void CollideMultiCore_WithSleepingBodies_KeepsContact()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            ContactManager contactManager = new ContactManager(broadPhase);
            Body bodyA = new Body();
            Body bodyB = new Body();

            CreateStandaloneContact(contactManager, broadPhase, bodyA, bodyB, new Vector2F(0.0f, 0.0f), new Vector2F(0.5f, 0.0f));
            bodyA.Awake = false;
            bodyB.Awake = false;

            contactManager.CollideMultiCore();

            Assert.Equal(1, contactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that collide skips the contact when the first body is disabled.
        /// </summary>
        [Fact]
        public void Collide_WithDisabledBodyA_ReturnsNextContact()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            ContactManager contactManager = new ContactManager(broadPhase);
            Body bodyA = new Body();
            Body bodyB = new Body();

            CreateStandaloneContact(contactManager, broadPhase, bodyA, bodyB, new Vector2F(0.0f, 0.0f), new Vector2F(0.5f, 0.0f));
            bodyA.Enabled = false;

            contactManager.Collide();

            Assert.Equal(1, contactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that collide skips the contact when the second body is disabled.
        /// </summary>
        [Fact]
        public void Collide_WithDisabledBodyB_ReturnsNextContact()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            ContactManager contactManager = new ContactManager(broadPhase);
            Body bodyA = new Body();
            Body bodyB = new Body();

            CreateStandaloneContact(contactManager, broadPhase, bodyA, bodyB, new Vector2F(0.0f, 0.0f), new Vector2F(0.5f, 0.0f));
            bodyB.Enabled = false;

            contactManager.Collide();

            Assert.Equal(1, contactManager.ContactCount);
        }

        /// <summary>
        ///     Tests that update contact with lock throws when both bodies have the same lock order.
        /// </summary>
        [Fact]
        public void UpdateContactWithLock_WhenLockOrdersAreEqual_ThrowsInvalidOperationException()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            ContactManager contactManager = new ContactManager(broadPhase);
            Body bodyA = new Body();
            Body bodyB = new Body();

            Contact contact = CreateStandaloneContact(contactManager, broadPhase, bodyA, bodyB, new Vector2F(0.0f, 0.0f), new Vector2F(0.5f, 0.0f));
            bodyA.LockOrder = 1;
            bodyB.LockOrder = 1;

            Assert.Throws<InvalidOperationException>(() => contactManager.UpdateContactWithLock(contact));
        }

        /// <summary>
        ///     Tests that update contact with lock retries when the first body is already locked.
        /// </summary>
        [Fact]
        public void UpdateContactWithLock_WhenBodyALocked_RetriesAndCompletes()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            ContactManager contactManager = new ContactManager(broadPhase);
            Body bodyA = new Body();
            Body bodyB = new Body();

            CreateStandaloneContact(contactManager, broadPhase, bodyA, bodyB, new Vector2F(0.0f, 0.0f), new Vector2F(0.5f, 0.0f));
            bodyA.LockOrder = 0;
            bodyB.LockOrder = 1;
            bodyA.Lock = 1;

            contactManager.UpdateContactWithLock(contactManager.ContactList.Next);

            Assert.Equal(0, bodyA.Lock);
            Assert.Equal(0, bodyB.Lock);
        }

        /// <summary>
        ///     Tests that update contact with lock retries when the second body is temporarily locked.
        /// </summary>
        [Fact]
        public void UpdateContactWithLock_WhenBodyBLocked_RetriesAndCompletes()
        {
            DynamicTreeBroadPhase broadPhase = new DynamicTreeBroadPhase();
            ContactManager contactManager = new ContactManager(broadPhase);
            Body bodyA = new Body();
            Body bodyB = new Body();

            CreateStandaloneContact(contactManager, broadPhase, bodyA, bodyB, new Vector2F(0.0f, 0.0f), new Vector2F(0.5f, 0.0f));
            bodyA.LockOrder = 0;
            bodyB.LockOrder = 1;
            bodyB.Lock = 1;

            Task.Run(async () =>
            {
                await Task.Delay(100);
                bodyB.Lock = 0;
            });

            contactManager.UpdateContactWithLock(contactManager.ContactList.Next);

            Assert.Equal(0, bodyA.Lock);
            Assert.Equal(0, bodyB.Lock);
        }
    }
}