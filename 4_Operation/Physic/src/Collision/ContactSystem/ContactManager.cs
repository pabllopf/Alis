// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ContactManager.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Physic.Collision.Broadphase;
using Alis.Core.Physic.Collision.Filtering;
using Alis.Core.Physic.Collision.Handlers;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Handlers;

namespace Alis.Core.Physic.Collision.ContactSystem
{
    /// <summary>
    ///     The contact manager class
    /// </summary>
    public class ContactManager
    {
        /// <summary>Fires when a contact is created</summary>
        public BeginContactHandler BeginContact;

        /// <summary>
        ///     The contact count
        /// </summary>
        internal int ContactCounter;

        /// <summary>The filter used by the contact manager.</summary>
        public CollisionFilterHandler ContactFilter;

        /// <summary>
        ///     The contact list
        /// </summary>
        internal Contact ContactList;

        /// <summary>Fires when a contact is deleted</summary>
        public EndContactHandler EndContact;

        /// <summary>Fires when the broadphase detects that two Fixtures are close to each other.</summary>
        public BroadphaseHandler OnBroadphaseCollision;

        /// <summary>Fires after the solver has run</summary>
        public PostSolveHandler PostSolve;

        /// <summary>Fires before the solver runs</summary>
        public PreSolveHandler PreSolve;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactManager" /> class
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        internal ContactManager(IBroadPhase broadPhase)
        {
            BroadPhase = broadPhase;
            OnBroadphaseCollision = AddPair;
        }

        /// <summary>
        ///     Gets the value of the broad phase
        /// </summary>
        public IBroadPhase BroadPhase { get; }

        /// <summary>
        ///     Gets the value of the contact count
        /// </summary>
        public int ContactCount => ContactCounter;

        // Broad-phase callback.
        /// <summary>
        ///     Adds the pair using the specified proxy a
        /// </summary>
        /// <param name="proxyA">The proxy</param>
        /// <param name="proxyB">The proxy</param>
        private void AddPair(ref FixtureProxy proxyA, ref FixtureProxy proxyB)
        {
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

            // TODO_ERIN use a hash table to remove a potential bottleneck when both
            // bodies have a lot of contacts.
            // Does a contact already exist?
            ContactEdge edge = bodyB.ContactList;
            while (edge != null)
            {
                if (edge.Other == bodyA)
                {
                    Fixture fA = edge.Contact.FixtureA;
                    Fixture fB = edge.Contact.FixtureB;
                    int iA = edge.Contact.ChildIndexA;
                    int iB = edge.Contact.ChildIndexB;

                    if (fA == fixtureA && fB == fixtureB && iA == indexA && iB == indexB)
                    {
                        // A contact already exists.
                        return;
                    }

                    if (fA == fixtureB && fB == fixtureA && iA == indexB && iB == indexA)
                    {
                        // A contact already exists.
                        return;
                    }
                }

                edge = edge.Next;
            }

            // Does a joint override collision? Is at least one body dynamic?
            if (!bodyB.ShouldCollide(bodyA))
            {
                return;
            }

            //Check default filter
            if (!ShouldCollide(fixtureA, fixtureB))
            {
                return;
            }

            // Check user filtering.
            if (ContactFilter != null && !ContactFilter(fixtureA, fixtureB))
            {
                return;
            }

            //Velcro: BeforeCollision delegate
            if (fixtureA.BeforeCollision != null && !fixtureA.BeforeCollision(fixtureA, fixtureB))
            {
                return;
            }

            if (fixtureB.BeforeCollision != null && !fixtureB.BeforeCollision(fixtureB, fixtureA))
            {
                return;
            }

            // Call the factory.
            Contact c = Contact.Create(fixtureA, indexA, fixtureB, indexB);
            if (c == null)
            {
                return;
            }

            // Contact creation may swap fixtures.
            fixtureA = c.FixtureA;
            fixtureB = c.FixtureB;
            indexA = c.ChildIndexA;
            indexB = c.ChildIndexB;
            bodyA = fixtureA.Body;
            bodyB = fixtureB.Body;

            // Insert into the world.
            c.Previous = null;
            c.Next = ContactList;
            if (ContactList != null)
            {
                ContactList.Previous = c;
            }

            ContactList = c;

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
            ++ContactCounter;
        }

        /// <summary>
        ///     Finds the new contacts
        /// </summary>
        internal void FindNewContacts()
        {
            BroadPhase.UpdatePairs(OnBroadphaseCollision);
        }

        /// <summary>
        ///     Removes the c
        /// </summary>
        /// <param name="c">The </param>
        internal void Remove(Contact c)
        {
            if (c.FixtureA == null || c.FixtureB == null)
            {
                return;
            }

            Fixture fixtureA = c.FixtureA;
            Fixture fixtureB = c.FixtureB;

            //Velcro: When contacts are removed, we invoke OnSeparation
            if (c.IsTouching)
            {
                //Report the separation to both participants:
                fixtureA.OnSeparation?.Invoke(fixtureA, fixtureB, c);

                //Reverse the order of the reported fixtures. The first fixture is always the one that the user subscribed to.
                fixtureB.OnSeparation?.Invoke(fixtureB, fixtureA, c);

                //The generic handler
                EndContact?.Invoke(c);
            }

            Body bodyA = fixtureA.Bodyprivate;
            Body bodyB = fixtureB.Bodyprivate;

            // Remove from the world.
            if (c.Previous != null)
            {
                c.Previous.Next = c.Next;
            }

            if (c.Next != null)
            {
                c.Next.Previous = c.Previous;
            }

            if (c == ContactList)
            {
                ContactList = c.Next;
            }

            // Remove from body 1
            if (c.NodeA.Prev != null)
            {
                c.NodeA.Prev.Next = c.NodeA.Next;
            }

            if (c.NodeA.Next != null)
            {
                c.NodeA.Next.Prev = c.NodeA.Prev;
            }

            if (c.NodeA == bodyA.ContactList)
            {
                bodyA.ContactList = c.NodeA.Next;
            }

            // Remove from body 2
            if (c.NodeB.Prev != null)
            {
                c.NodeB.Prev.Next = c.NodeB.Next;
            }

            if (c.NodeB.Next != null)
            {
                c.NodeB.Next.Prev = c.NodeB.Prev;
            }

            if (c.NodeB == bodyB.ContactList)
            {
                bodyB.ContactList = c.NodeB.Next;
            }

            // Call the factory.
            c.Destroy();
            --ContactCounter;
        }

        /// <summary>
        ///     This is the top level collision call for the time step. Here all the narrow phase collision is processed for the
        ///     world contact list.
        /// </summary>
        internal void Collide()
        {
            // Update awake contacts.

            Contact c = ContactList;

            while (c != null)
            {
                Fixture fixtureA = c.FixtureA;
                Fixture fixtureB = c.FixtureB;
                int indexA = c.ChildIndexA;
                int indexB = c.ChildIndexB;
                Body bodyA = fixtureA.Bodyprivate;
                Body bodyB = fixtureB.Bodyprivate;

                //Velcro: Do no try to collide disabled bodies
                if (!bodyA.Enabled || !bodyB.Enabled)
                {
                    c = c.Next;
                    continue;
                }

                // Is this contact flagged for filtering?
                if (c.FilterFlag)
                {
                    // Should these bodies collide?
                    if (!bodyB.ShouldCollide(bodyA))
                    {
                        Contact cNuke = c;
                        c = cNuke.Next;
                        Remove(cNuke);
                        continue;
                    }

                    // Check default filtering
                    if (!ShouldCollide(fixtureA, fixtureB))
                    {
                        Contact cNuke = c;
                        c = cNuke.Next;
                        Remove(cNuke);
                        continue;
                    }

                    // Check user filtering.
                    if (ContactFilter != null && !ContactFilter(fixtureA, fixtureB))
                    {
                        Contact cNuke = c;
                        c = cNuke.Next;
                        Remove(cNuke);
                        continue;
                    }

                    // Clear the filtering flag.
                    c.Flags &= ~ContactFlags.FilterFlag;
                }

                bool activeA = bodyA.Awake && bodyA.BodyType != BodyType.Static;
                bool activeB = bodyB.Awake && bodyB.BodyType != BodyType.Static;

                // At least one body must be awake and it must be dynamic or kinematic.
                if (!activeA && !activeB)
                {
                    c = c.Next;
                    continue;
                }

                int proxyIdA = fixtureA.Proxies[indexA].ProxyId;
                int proxyIdB = fixtureB.Proxies[indexB].ProxyId;
                bool overlap = BroadPhase.TestOverlap(proxyIdA, proxyIdB);

                // Here we destroy contacts that cease to overlap in the broad-phase.
                if (!overlap)
                {
                    Contact cNuke = c;
                    c = cNuke.Next;
                    Remove(cNuke);
                    continue;
                }

                // The contact persists.
                c.Update(this);
                c = c.Next;
            }
        }

        /// <summary>
        ///     Describes whether should collide
        /// </summary>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="fixtureB">The fixture</param>
        /// <returns>The collide</returns>
        private static bool ShouldCollide(Fixture fixtureA, Fixture fixtureB)
        {
            if (fixtureA.CollisionGroup == fixtureB.CollisionGroup &&
                fixtureA.CollisionGroup != 0)
            {
                return fixtureA.CollisionGroup > 0;
            }

            bool collide = (fixtureA.CollidesWith & fixtureB.CollisionCategories) != 0 &&
                           (fixtureA.CollisionCategories & fixtureB.CollidesWith) != 0;

            return collide;
        }
    }
}