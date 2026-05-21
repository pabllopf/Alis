// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactManager.cs
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
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The contact manager class
    /// </summary>
    public class ContactManager
    {
        /// <summary>
        ///     The broad phase
        /// </summary>
        public readonly IBroadPhaseFixture BroadPhaseFixtureNode;

        /// <summary>
        ///     A threshold for activating multiple cores to solve Collide.
        ///     An World with a contact count above this threshold will use multiple threads to solve Collide.
        ///     A value of 0 will always use multithreading. A value of (int.MaxValue) will never use multithreading.
        ///     Typical values are {128 or 256}.
        /// </summary>
        public readonly int CollideMultithreadThreshold = int.MaxValue;

        /// <summary>
        ///     The contact list
        /// </summary>
        public readonly ContactListHead ContactList;

        /// <summary>
        ///     The contact pool list
        /// </summary>
        internal readonly ContactListHead ContactPoolList;

        /// <summary>
        ///     Fires when the broadphase detects that two Fixtures are close to each other.
        /// </summary>
        public readonly BroadphaseDelegate OnBroadphaseCollision;

        /// <summary>
        ///     A threshold for activating multiple cores to solve PositionConstraints.
        ///     An Island with a contact count above this threshold will use multiple threads to solve PositionConstraints.
        ///     A value of 0 will always use multithreading. A value of (int.MaxValue) will never use multithreading.
        ///     Typical values are {128 or 256}.
        /// </summary>
        public readonly int PositionConstraintsMultithreadThreshold = int.MaxValue;

        /// <summary>
        ///     A temporary list of contacts to be updated during Collide().
        /// </summary>
        private readonly List<Contact> updateList = new List<Contact>();


        /// <summary>
        ///     A threshold for activating multiple cores to solve VelocityConstraints.
        ///     An Island with a contact count above this threshold will use multiple threads to solve VelocityConstraints.
        ///     A value of 0 will always use multithreading. A value of (int.MaxValue) will never use multithreading.
        ///     Typical values are {128 or 256}.
        /// </summary>
        public readonly int VelocityConstraintsMultithreadThreshold = int.MaxValue;


        /// <summary>
        ///     Fires when a contact is created
        /// </summary>
        public BeginContactDelegate BeginContact;

        /// <summary>
        ///     The filter used by the contact manager.
        /// </summary>
        public CollisionFilterDelegate ContactFilter;


        /// <summary>
        ///     Fires when a contact is deleted
        /// </summary>
        public EndContactDelegate EndContact;

        /// <summary>
        ///     Fires after the solver has run
        /// </summary>
        public PostSolveDelegate PostSolve;

        /// <summary>
        ///     Fires before the solver runs
        /// </summary>
        public PreSolveDelegate PreSolve;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactManager" /> class
        /// </summary>
        /// <param name="broadPhaseFixtureNode">The broad phase</param>
        internal ContactManager(IBroadPhaseFixture broadPhaseFixtureNode)
        {
            ContactList = new ContactListHead();
            ContactCount = 0;
            ContactPoolList = new ContactListHead();

            BroadPhaseFixtureNode = broadPhaseFixtureNode;
            OnBroadphaseCollision += AddPair;
        }

        /// <summary>
        ///     Gets or sets the value of the contact count
        /// </summary>
        public int ContactCount { get; private set; }

        /// <summary>
        ///     Adds the pair using the specified proxy id a
        /// </summary>
        /// <param name="proxyIdA">The proxy id</param>
        /// <param name="proxyIdB">The proxy id</param>
        private void AddPair(int proxyIdA, int proxyIdB)
        {
            FixtureProxy proxyA = BroadPhaseFixtureNode.GetProxy(proxyIdA);
            FixtureProxy proxyB = BroadPhaseFixtureNode.GetProxy(proxyIdB);

            Fixture fixtureA = proxyA.Fixture;
            Fixture fixtureB = proxyB.Fixture;

            int indexA = proxyA.ChildIndex;
            int indexB = proxyB.ChildIndex;

            Body bodyA = fixtureA.GetBody;
            Body bodyB = fixtureB.GetBody;

            if (bodyA == bodyB)
            {
                return;
            }

            if (HasExistingContact(bodyA, bodyB, fixtureA, fixtureB, indexA, indexB))
            {
                return;
            }

            if (!ShouldCreateContact(bodyA, bodyB, fixtureA, fixtureB))
            {
                return;
            }

            Contact c = Contact.Create(this, fixtureA, indexA, fixtureB, indexB);

            if (c == null)
            {
                return;
            }

            fixtureA = c.FixtureA;
            fixtureB = c.FixtureB;
            bodyA = fixtureA.GetBody;
            bodyB = fixtureB.GetBody;

            c.Prev = ContactList;
            c.Next = c.Prev.Next;
            c.Prev.Next = c;
            c.Next.Prev = c;
            ContactCount++;

            ConnectContactToBody(c, bodyB);
            ConnectContactToBody(c, bodyA);

            if (!fixtureA.GetIsSensor && !fixtureB.GetIsSensor)
            {
                bodyA.Awake = true;
                bodyB.Awake = true;
            }
        }

        private bool HasExistingContact(Body bodyA, Body bodyB, Fixture fixtureA, Fixture fixtureB, int indexA, int indexB)
        {
            for (ContactEdge ceB = bodyB.ContactList; ceB != null; ceB = ceB.Next)
            {
                if (ceB.Other == bodyA)
                {
                    Fixture fA = ceB.Contact.FixtureA;
                    Fixture fB = ceB.Contact.FixtureB;
                    int iA = ceB.Contact.ChildIndexA;
                    int iB = ceB.Contact.ChildIndexB;

                    if ((fA == fixtureA && fB == fixtureB && iA == indexA && iB == indexB) ||
                        (fA == fixtureB && fB == fixtureA && iA == indexB && iB == indexA))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool ShouldCreateContact(Body bodyA, Body bodyB, Fixture fixtureA, Fixture fixtureB)
        {
            if (!bodyB.ShouldCollide(bodyA))
            {
                return false;
            }

            if (!ShouldCollide(fixtureA, fixtureB))
            {
                return false;
            }

            CollisionFilterDelegate contactFilterHandler = ContactFilter;
            if (contactFilterHandler != null && !contactFilterHandler(fixtureA, fixtureB))
            {
                return false;
            }

            BeforeCollisionEventHandler beforeCollisionHandlerA = fixtureA.BeforeCollision;
            if (beforeCollisionHandlerA != null && !beforeCollisionHandlerA(fixtureA, fixtureB))
            {
                return false;
            }

            BeforeCollisionEventHandler beforeCollisionHandlerB = fixtureB.BeforeCollision;
            if (beforeCollisionHandlerB != null && !beforeCollisionHandlerB(fixtureB, fixtureA))
            {
                return false;
            }

            return true;
        }

        private void ConnectContactToBody(Contact c, Body body)
        {
            c.NodeB.Contact = c;
            c.NodeB.Other = body;

            c.NodeB.Prev = null;
            c.NodeB.Next = body.ContactList;
            if (body.ContactList != null)
            {
                body.ContactList.Prev = c.NodeB;
            }

            body.ContactList = c.NodeB;
        }

        /// <summary>
        ///     Finds the new contacts
        /// </summary>
        internal void FindNewContacts()
        {
            BroadPhaseFixtureNode.UpdatePairs(OnBroadphaseCollision);
        }

        /// <summary>
        ///     Destroys the contact
        /// </summary>
        /// <param name="contact">The contact</param>
        internal void Destroy(Contact contact)
        {
            Fixture fixtureA = contact.FixtureA;
            Fixture fixtureB = contact.FixtureB;
            Body bodyA = fixtureA.GetBody;
            Body bodyB = fixtureB.GetBody;

            if (contact.IsTouching)
            {
                ReportSeparation(fixtureA, fixtureB, contact, bodyA, bodyB);
            }

            RemoveContactFromWorld(contact);
            RemoveContactFromBody(contact, bodyA);
            RemoveContactFromBody(contact, bodyB);

            contact.Destroy();

            ContactPoolList.Next = contact;
        }

        private void ReportSeparation(Fixture fixtureA, Fixture fixtureB, Contact contact, Body bodyA, Body bodyB)
        {
            OnSeparationEventHandler onFixtureSeparationHandlerA = fixtureA.OnSeparation;
            if (onFixtureSeparationHandlerA != null)
            {
                onFixtureSeparationHandlerA(fixtureA, fixtureB, contact);
            }

            OnSeparationEventHandler onFixtureSeparationHandlerB = fixtureB.OnSeparation;
            if (onFixtureSeparationHandlerB != null)
            {
                onFixtureSeparationHandlerB(fixtureB, fixtureA, contact);
            }

            OnSeparationEventHandler onBodySeparationHandlerA = bodyA.OnSeparationEventHandler;
            if (onBodySeparationHandlerA != null)
            {
                onBodySeparationHandlerA(fixtureA, fixtureB, contact);
            }

            OnSeparationEventHandler onBodySeparationHandlerB = bodyB.OnSeparationEventHandler;
            if (onBodySeparationHandlerB != null)
            {
                onBodySeparationHandlerB(fixtureB, fixtureA, contact);
            }

            EndContactDelegate endContactHandler = EndContact;
            if (endContactHandler != null)
            {
                endContactHandler(contact);
            }
        }

        private void RemoveContactFromWorld(Contact contact)
        {
            contact.Prev.Next = contact.Next;
            contact.Next.Prev = contact.Prev;
            contact.Next = null;
            contact.Prev = null;
            ContactCount--;
        }

        private static void RemoveContactFromBody(Contact contact, Body body)
        {
            if (contact.NodeA == body.ContactList)
            {
                body.ContactList = contact.NodeA.Next;
            }

            if (contact.NodeA.Prev != null)
            {
                contact.NodeA.Prev.Next = contact.NodeA.Next;
            }

            if (contact.NodeA.Next != null)
            {
                contact.NodeA.Next.Prev = contact.NodeA.Prev;
            }
        }
        /// <summary>
        ///     Collides this instance
        /// </summary>
        internal void Collide()
        {
            if ((ContactCount > CollideMultithreadThreshold) && (Environment.ProcessorCount > 1))
            {
                CollideMultiCore();
                return;
            }

            // Update awake contacts.

            for (Contact c = ContactList.Next; c != ContactList;)
            {
                Fixture fixtureA = c.FixtureA;
                Fixture fixtureB = c.FixtureB;
                int indexA = c.ChildIndexA;
                int indexB = c.ChildIndexB;
                Body bodyA = fixtureA.GetBody;
                Body bodyB = fixtureB.GetBody;

                if (ShouldSkipContact(bodyA, bodyB))
                {
                    c = c.Next;
                    continue;
                }

                if (c.FilterFlag && ShouldDestroyContact(bodyA, bodyB, fixtureA, fixtureB))
                {
                    Contact cNuke = c;
                    c = c.Next;
                    Destroy(cNuke);
                    continue;
                }

                if (c.FilterFlag)
                {
                    c.FilterFlag = false;
                }

                bool activeA = bodyA.Awake && (bodyA.GetBodyType != BodyType.Static);
                bool activeB = bodyB.Awake && (bodyB.GetBodyType != BodyType.Static);

                if (!activeA && !activeB)
                {
                    c = c.Next;
                    continue;
                }

                int proxyIdA = fixtureA.Proxies[indexA].ProxyId;
                int proxyIdB = fixtureB.Proxies[indexB].ProxyId;

                bool overlap = BroadPhaseFixtureNode.TestOverlap(proxyIdA, proxyIdB);

                if (!overlap)
                {
                    Contact cNuke = c;
                    c = c.Next;
                    Destroy(cNuke);
                    continue;
                }

                c.Update(this);

                c = c.Next;
            }
        }

        private static bool ShouldSkipContact(Body bodyA, Body bodyB)
        {
            return !bodyA.Enabled || !bodyB.Enabled;
        }

        private bool ShouldDestroyContact(Body bodyA, Body bodyB, Fixture fixtureA, Fixture fixtureB)
        {
            if (!bodyB.ShouldCollide(bodyA))
            {
                return true;
            }

            if (!ShouldCollide(fixtureA, fixtureB))
            {
                return true;
            }

            CollisionFilterDelegate contactFilterHandler = ContactFilter;
            if (contactFilterHandler != null && !contactFilterHandler(fixtureA, fixtureB))
            {
                return true;
            }

            return false;
        }


        /// <summary>
        ///     Collides the multi core
        /// </summary>
        /// <exception cref="Exception"></exception>
        internal void CollideMultiCore()
        {
            int lockOrder = 0;

            for (Contact c = ContactList.Next; c != ContactList;)
            {
                Fixture fixtureA = c.FixtureA;
                Fixture fixtureB = c.FixtureB;
                int indexA = c.ChildIndexA;
                int indexB = c.ChildIndexB;
                Body bodyA = fixtureA.GetBody;
                Body bodyB = fixtureB.GetBody;

                if (ShouldSkipContact(bodyA, bodyB))
                {
                    c = c.Next;
                    continue;
                }

                if (c.FilterFlag && ShouldDestroyContact(bodyA, bodyB, fixtureA, fixtureB))
                {
                    Contact cNuke = c;
                    c = c.Next;
                    Destroy(cNuke);
                    continue;
                }

                if (c.FilterFlag)
                {
                    c.FilterFlag = false;
                }

                bool activeA = bodyA.Awake && (bodyA.GetBodyType != BodyType.Static);
                bool activeB = bodyB.Awake && (bodyB.GetBodyType != BodyType.Static);

                if (!activeA && !activeB)
                {
                    c = c.Next;
                    continue;
                }

                int proxyIdA = fixtureA.Proxies[indexA].ProxyId;
                int proxyIdB = fixtureB.Proxies[indexB].ProxyId;

                bool overlap = BroadPhaseFixtureNode.TestOverlap(proxyIdA, proxyIdB);

                if (!overlap)
                {
                    Contact cNuke = c;
                    c = c.Next;
                    Destroy(cNuke);
                    continue;
                }

                updateList.Add(c);
                bodyA.LockOrder = lockOrder++;
                bodyB.LockOrder = lockOrder++;


                c = c.Next;
            }

            ProcessParallelContacts();

            updateList.Clear();
        }

        private void ProcessParallelContacts()
        {
            Parallel.ForEach(updateList, c =>
            {
                Fixture fixtureA = c.FixtureA;
                Fixture fixtureB = c.FixtureB;

                Body orderedBodyA = fixtureA.GetBody;
                Body orderedBodyB = fixtureB.GetBody;
                int idA = orderedBodyA.LockOrder;
                int idB = orderedBodyB.LockOrder;
                if (idA == idB)
                {
                    throw new Exception();
                }

                if (idA > idB)
                {
                    orderedBodyA = fixtureB.GetBody;
                    orderedBodyB = fixtureA.GetBody;
                }

                for (;;)
                {
                    if (Interlocked.CompareExchange(ref orderedBodyA.Lock, 1, 0) == 0)
                    {
                        if (Interlocked.CompareExchange(ref orderedBodyB.Lock, 1, 0) == 0)
                        {
                            break;
                        }

                        Interlocked.Exchange(ref orderedBodyA.Lock, 0);
                    }

                    Thread.Sleep(0);
                }

                c.Update(this);

                Interlocked.Exchange(ref orderedBodyB.Lock, 0);
                Interlocked.Exchange(ref orderedBodyA.Lock, 0);
            });
        }


        /// <summary>
        ///     Describes whether should collide
        /// </summary>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="fixtureB">The fixture</param>
        /// <returns>The collide</returns>
        private static bool ShouldCollide(Fixture fixtureA, Fixture fixtureB)
        {
            if ((fixtureA.GetCollisionGroup != 0) && (fixtureA.GetCollisionGroup == fixtureB.GetCollisionGroup))
            {
                return fixtureA.GetCollisionGroup > 0;
            }

            bool collide = ((fixtureA.GetCollidesWith & fixtureB.GetCollisionCategories) != 0) &&
                           ((fixtureB.GetCollidesWith & fixtureA.GetCollisionCategories) != 0);

            return collide;
        }
    }
}