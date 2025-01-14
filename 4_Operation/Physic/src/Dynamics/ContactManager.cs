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
using Alis.Core.Aspect.Memory.Exceptions;
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The contact manager class
    /// </summary>
    public class ContactManager
    {
        /// <summary>
        ///     The contact pool list
        /// </summary>
        internal readonly ContactListHead _contactPoolList;

        /// <summary>
        ///     The broad phase
        /// </summary>
        public readonly IBroadPhase BroadPhase;

        /// <summary>
        ///     The contact list
        /// </summary>
        public readonly ContactListHead ContactList;

        /// <summary>
        ///     A temporary list of contacts to be updated during Collide().
        /// </summary>
        private readonly List<Contact> updateList = new List<Contact>();


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
        ///     Fires when the broadphase detects that two Fixtures are close to each other.
        /// </summary>
        public readonly BroadphaseDelegate OnBroadphaseCollision;

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
        /// <param name="broadPhase">The broad phase</param>
        internal ContactManager(IBroadPhase broadPhase)
        {
            ContactList = new ContactListHead();
            ContactCount = 0;
            _contactPoolList = new ContactListHead();

            BroadPhase = broadPhase;
            OnBroadphaseCollision += AddPair;
        }

        /// <summary>
        ///     Gets or sets the value of the contact count
        /// </summary>
        public int ContactCount { get; private set; }

        // Broad-phase callback.
        /// <summary>
        ///     Adds the pair using the specified proxy id a
        /// </summary>
        /// <param name="proxyIdA">The proxy id</param>
        /// <param name="proxyIdB">The proxy id</param>
        private void AddPair(int proxyIdA, int proxyIdB)
        {
            FixtureProxy proxyA = BroadPhase.GetProxy(proxyIdA);
            FixtureProxy proxyB = BroadPhase.GetProxy(proxyIdB);

            Fixture fixtureA = proxyA.Fixture;
            Fixture fixtureB = proxyB.Fixture;

            int indexA = proxyA.ChildIndex;
            int indexB = proxyB.ChildIndex;

            Body bodyA = fixtureA.Body;
            Body bodyB = fixtureB.Body;

            // Are the fixtures on the same body?
            if (bodyA == bodyB)
            {
                return;
            }

            // Does a contact already exist?
            for (ContactEdge ceB = bodyB.ContactList; ceB != null; ceB = ceB.Next)
            {
                if (ceB.Other == bodyA)
                {
                    Fixture fA = ceB.Contact.FixtureA;
                    Fixture fB = ceB.Contact.FixtureB;
                    int iA = ceB.Contact.ChildIndexA;
                    int iB = ceB.Contact.ChildIndexB;

                    if ((fA == fixtureA) && (fB == fixtureB) && (iA == indexA) && (iB == indexB))
                    {
                        // A contact already exists.
                        return;
                    }

                    if ((fA == fixtureB) && (fB == fixtureA) && (iA == indexB) && (iB == indexA))
                    {
                        // A contact already exists.
                        return;
                    }
                }
            }

            // Does a joint override collision? Is at least one body dynamic?
            if (bodyB.ShouldCollide(bodyA) == false)
            {
                return;
            }

            //Check default filter
            if (ShouldCollide(fixtureA, fixtureB) == false)
            {
                return;
            }

            // Check user filtering.
            CollisionFilterDelegate contactFilterHandler = ContactFilter;
            if (contactFilterHandler != null)
            {
                if (contactFilterHandler(fixtureA, fixtureB) == false)
                {
                    return;
                }
            }

            //FPE feature: BeforeCollision delegate
            BeforeCollisionEventHandler beforeCollisionHandlerA = fixtureA.BeforeCollision;
            if (beforeCollisionHandlerA != null)
            {
                if (beforeCollisionHandlerA(fixtureA, fixtureB) == false)
                {
                    return;
                }
            }

            BeforeCollisionEventHandler beforeCollisionHandlerB = fixtureB.BeforeCollision;
            if (beforeCollisionHandlerB != null)
            {
                if (beforeCollisionHandlerB(fixtureB, fixtureA) == false)
                {
                    return;
                }
            }

            // Call the factory.
            Contact c = Contact.Create(this, fixtureA, indexA, fixtureB, indexB);

            if (c == null)
            {
                return;
            }

            // Contact creation may swap fixtures.
            fixtureA = c.FixtureA;
            fixtureB = c.FixtureB;
            bodyA = fixtureA.Body;
            bodyB = fixtureB.Body;

            // Insert into the world.
            c.Prev = ContactList;
            c.Next = c.Prev.Next;
            c.Prev.Next = c;
            c.Next.Prev = c;
            ContactCount++;


            // Connect to island graph.

            // Connect to body A
            c.NodeA.Contact = c;
            c.NodeA.Other = bodyB;

            c.NodeA.Prev = null;
            c.NodeA.Next = bodyA.ContactList;
            if (bodyA.ContactList != null)
            {
                bodyA.ContactList.Prev = c.NodeA;
            }

            bodyA.ContactList = c.NodeA;

            // Connect to body B
            c.NodeB.Contact = c;
            c.NodeB.Other = bodyA;

            c.NodeB.Prev = null;
            c.NodeB.Next = bodyB.ContactList;
            if (bodyB.ContactList != null)
            {
                bodyB.ContactList.Prev = c.NodeB;
            }

            bodyB.ContactList = c.NodeB;

            // Wake up the bodies
            if ((fixtureA.IsSensor == false) && (fixtureB.IsSensor == false))
            {
                bodyA.Awake = true;
                bodyB.Awake = true;
            }
        }

        /// <summary>
        ///     Finds the new contacts
        /// </summary>
        internal void FindNewContacts()
        {
            BroadPhase.UpdatePairs(OnBroadphaseCollision);
        }

        /// <summary>
        ///     Destroys the contact
        /// </summary>
        /// <param name="contact">The contact</param>
        internal void Destroy(Contact contact)
        {
            Fixture fixtureA = contact.FixtureA;
            Fixture fixtureB = contact.FixtureB;
            Body bodyA = fixtureA.Body;
            Body bodyB = fixtureB.Body;

            if (contact.IsTouching)
            {
                //Report the separation to both participants:
                OnSeparationEventHandler onFixtureSeparationHandlerA = fixtureA.OnSeparation;
                if (onFixtureSeparationHandlerA != null)
                {
                    onFixtureSeparationHandlerA(fixtureA, fixtureB, contact);
                }

                //Reverse the order of the reported fixtures. The first fixture is always the one that the
                //user subscribed to.
                OnSeparationEventHandler onFixtureSeparationHandlerB = fixtureB.OnSeparation;
                if (onFixtureSeparationHandlerB != null)
                {
                    onFixtureSeparationHandlerB(fixtureB, fixtureA, contact);
                }

                //Report the separation to both bodies:
                OnSeparationEventHandler onBodySeparationHandlerA = bodyA.onSeparationEventHandler;
                if (onBodySeparationHandlerA != null)
                {
                    onBodySeparationHandlerA(fixtureA, fixtureB, contact);
                }

                //Reverse the order of the reported fixtures. The first fixture is always the one that the
                //user subscribed to.
                OnSeparationEventHandler onBodySeparationHandlerB = bodyB.onSeparationEventHandler;
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

            // Remove from the world.
            contact.Prev.Next = contact.Next;
            contact.Next.Prev = contact.Prev;
            contact.Next = null;
            contact.Prev = null;
            ContactCount--;

            // Remove from body 1
            if (contact.NodeA == bodyA.ContactList)
            {
                bodyA.ContactList = contact.NodeA.Next;
            }

            if (contact.NodeA.Prev != null)
            {
                contact.NodeA.Prev.Next = contact.NodeA.Next;
            }

            if (contact.NodeA.Next != null)
            {
                contact.NodeA.Next.Prev = contact.NodeA.Prev;
            }

            // Remove from body 2
            if (contact.NodeB == bodyB.ContactList)
            {
                bodyB.ContactList = contact.NodeB.Next;
            }

            if (contact.NodeB.Prev != null)
            {
                contact.NodeB.Prev.Next = contact.NodeB.Next;
            }

            if (contact.NodeB.Next != null)
            {
                contact.NodeB.Next.Prev = contact.NodeB.Prev;
            }

            contact.Destroy();

            // Insert into the pool.
            contact.Next = _contactPoolList.Next;
            _contactPoolList.Next = contact;
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
                Body bodyA = fixtureA.Body;
                Body bodyB = fixtureB.Body;

                //Do no try to collide disabled bodies
                if (!bodyA.Enabled || !bodyB.Enabled)
                {
                    c = c.Next;
                    continue;
                }

                // Is this contact flagged for filtering?
                if (c.FilterFlag)
                {
                    // Should these bodies collide?
                    if (bodyB.ShouldCollide(bodyA) == false)
                    {
                        Contact cNuke = c;
                        c = c.Next;
                        Destroy(cNuke);
                        continue;
                    }

                    // Check default filtering
                    if (ShouldCollide(fixtureA, fixtureB) == false)
                    {
                        Contact cNuke = c;
                        c = c.Next;
                        Destroy(cNuke);
                        continue;
                    }

                    // Check user filtering.
                    CollisionFilterDelegate contactFilterHandler = ContactFilter;
                    if (contactFilterHandler != null)
                    {
                        if (contactFilterHandler(fixtureA, fixtureB) == false)
                        {
                            Contact cNuke = c;
                            c = c.Next;
                            Destroy(cNuke);
                            continue;
                        }
                    }

                    // Clear the filtering flag.
                    c.FilterFlag = false;
                }

                bool activeA = bodyA.Awake && (bodyA.BodyType != BodyType.Static);
                bool activeB = bodyB.Awake && (bodyB.BodyType != BodyType.Static);

                // At least one body must be awake and it must be dynamic or kinematic.
                if ((activeA == false) && (activeB == false))
                {
                    c = c.Next;
                    continue;
                }

                int proxyIdA = fixtureA.Proxies[indexA].ProxyId;
                int proxyIdB = fixtureB.Proxies[indexB].ProxyId;

                bool overlap = BroadPhase.TestOverlap(proxyIdA, proxyIdB);

                // Here we destroy contacts that cease to overlap in the broad-phase.
                if (overlap == false)
                {
                    Contact cNuke = c;
                    c = c.Next;
                    Destroy(cNuke);
                    continue;
                }

                // The contact persists.
                c.Update(this);

                c = c.Next;
            }
        }


        /// <summary>
        ///     Collides the multi core
        /// </summary>
        /// <exception cref="Exception"></exception>
        internal void CollideMultiCore()
        {
            int lockOrder = 0;

            // Update awake contacts.
            for (Contact c = ContactList.Next; c != ContactList;)
            {
                Fixture fixtureA = c.FixtureA;
                Fixture fixtureB = c.FixtureB;
                int indexA = c.ChildIndexA;
                int indexB = c.ChildIndexB;
                Body bodyA = fixtureA.Body;
                Body bodyB = fixtureB.Body;

                //Do no try to collide disabled bodies
                if (!bodyA.Enabled || !bodyB.Enabled)
                {
                    c = c.Next;
                    continue;
                }

                // Is this contact flagged for filtering?
                if (c.FilterFlag)
                {
                    // Should these bodies collide?
                    if (bodyB.ShouldCollide(bodyA) == false)
                    {
                        Contact cNuke = c;
                        c = c.Next;
                        Destroy(cNuke);
                        continue;
                    }

                    // Check default filtering
                    if (ShouldCollide(fixtureA, fixtureB) == false)
                    {
                        Contact cNuke = c;
                        c = c.Next;
                        Destroy(cNuke);
                        continue;
                    }

                    // Check user filtering.
                    CollisionFilterDelegate contactFilterHandler = ContactFilter;
                    if (contactFilterHandler != null)
                    {
                        if (contactFilterHandler(fixtureA, fixtureB) == false)
                        {
                            Contact cNuke = c;
                            c = c.Next;
                            Destroy(cNuke);
                            continue;
                        }
                    }

                    // Clear the filtering flag.
                    c.FilterFlag = false;
                }

                bool activeA = bodyA.Awake && (bodyA.BodyType != BodyType.Static);
                bool activeB = bodyB.Awake && (bodyB.BodyType != BodyType.Static);

                // At least one body must be awake and it must be dynamic or kinematic.
                if ((activeA == false) && (activeB == false))
                {
                    c = c.Next;
                    continue;
                }

                int proxyIdA = fixtureA.Proxies[indexA].ProxyId;
                int proxyIdB = fixtureB.Proxies[indexB].ProxyId;

                bool overlap = BroadPhase.TestOverlap(proxyIdA, proxyIdB);

                // Here we destroy contacts that cease to overlap in the broad-phase.
                if (overlap == false)
                {
                    Contact cNuke = c;
                    c = c.Next;
                    Destroy(cNuke);
                    continue;
                }

                // The contact persists.
                updateList.Add(c);
                // Assign a unique id for lock order
                bodyA._lockOrder = lockOrder++;
                bodyB._lockOrder = lockOrder++;


                c = c.Next;
            }


            // update contacts
            Parallel.ForEach(updateList, c =>
            {
                // find lower order item
                Fixture fixtureA = c.FixtureA;
                Fixture fixtureB = c.FixtureB;

                // find lower order item
                Body orderedBodyA = fixtureA.Body;
                Body orderedBodyB = fixtureB.Body;
                int idA = orderedBodyA._lockOrder;
                int idB = orderedBodyB._lockOrder;
                if (idA == idB)
                {
                    throw new GeneralAlisException();
                }

                if (idA > idB)
                {
                    orderedBodyA = fixtureB.Body;
                    orderedBodyB = fixtureA.Body;
                }

                // obtain lock
                for (;;)
                {
                    if (Interlocked.CompareExchange(ref orderedBodyA._lock, 1, 0) == 0)
                    {
                        if (Interlocked.CompareExchange(ref orderedBodyB._lock, 1, 0) == 0)
                        {
                            break;
                        }

                        Interlocked.Exchange(ref orderedBodyA._lock, 0);
                    }

                    Thread.Sleep(0);
                }

                c.Update(this);

                Interlocked.Exchange(ref orderedBodyB._lock, 0);
                Interlocked.Exchange(ref orderedBodyA._lock, 0);
            });

            updateList.Clear();
        }


        /// <summary>
        ///     Describes whether should collide
        /// </summary>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="fixtureB">The fixture</param>
        /// <returns>The collide</returns>
        private static bool ShouldCollide(Fixture fixtureA, Fixture fixtureB)
        {
            if ((fixtureA.CollisionGroup != 0) && (fixtureA.CollisionGroup == fixtureB.CollisionGroup))
            {
                return fixtureA.CollisionGroup > 0;
            }

            bool collide = ((fixtureA.CollidesWith & fixtureB.CollisionCategories) != 0) &&
                           ((fixtureB.CollidesWith & fixtureA.CollisionCategories) != 0);

            return collide;
        }

        #region Settings

        /// <summary>
        ///     A threshold for activating multiple cores to solve VelocityConstraints.
        ///     An Island with a contact count above this threshold will use multiple threads to solve VelocityConstraints.
        ///     A value of 0 will always use multithreading. A value of (int.MaxValue) will never use multithreading.
        ///     Typical values are {128 or 256}.
        /// </summary>
        public readonly int VelocityConstraintsMultithreadThreshold = int.MaxValue;

        /// <summary>
        ///     A threshold for activating multiple cores to solve PositionConstraints.
        ///     An Island with a contact count above this threshold will use multiple threads to solve PositionConstraints.
        ///     A value of 0 will always use multithreading. A value of (int.MaxValue) will never use multithreading.
        ///     Typical values are {128 or 256}.
        /// </summary>
        public readonly int PositionConstraintsMultithreadThreshold = int.MaxValue;

        /// <summary>
        ///     A threshold for activating multiple cores to solve Collide.
        ///     An World with a contact count above this threshold will use multiple threads to solve Collide.
        ///     A value of 0 will always use multithreading. A value of (int.MaxValue) will never use multithreading.
        ///     Typical values are {128 or 256}.
        /// </summary>
        public readonly int CollideMultithreadThreshold = int.MaxValue;

        #endregion
    }
}