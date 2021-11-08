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

using Alis.Core.Systems.Physics2D.Collision.Broadphase;
using Alis.Core.Systems.Physics2D.Collision.Filtering;
using Alis.Core.Systems.Physics2D.Collision.Handlers;
using Alis.Core.Systems.Physics2D.Dynamics;
using Alis.Core.Systems.Physics2D.Dynamics.Handlers;

namespace Alis.Core.Systems.Physics2D.Collision.ContactSystem
{
    /// <summary>
    ///     The contact manager class
    /// </summary>
    public class ContactManager
    {
        /// <summary>
        ///     The contact count
        /// </summary>
        internal int _contactCount;

        /// <summary>
        ///     The contact list
        /// </summary>
        internal Contact _contactList;

        /// <summary>Fires when a contact is created</summary>
        public BeginContactHandler BeginContact;

        /// <summary>The filter used by the contact manager.</summary>
        public CollisionFilterHandler ContactFilter;

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
        public int ContactCount => _contactCount;

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
            ContactEdge edge = bodyB._contactList;
            while (edge != null)
            {
                if (edge.Other == bodyA)
                {
                    Fixture fA = edge.Contact._fixtureA;
                    Fixture fB = edge.Contact._fixtureB;
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
            fixtureA = c._fixtureA;
            fixtureB = c._fixtureB;
            indexA = c.ChildIndexA;
            indexB = c.ChildIndexB;
            bodyA = fixtureA.Body;
            bodyB = fixtureB.Body;

            // Insert into the world.
            c._prev = null;
            c._next = _contactList;
            if (_contactList != null)
            {
                _contactList._prev = c;
            }

            _contactList = c;

            // Connect to island graph.

            // Connect to body A
            c._nodeA.Contact = c;
            c._nodeA.Other = bodyB;

            c._nodeA.Prev = null;
            c._nodeA.Next = bodyA._contactList;
            if (bodyA._contactList != null)
            {
                bodyA._contactList.Prev = c._nodeA;
            }

            bodyA._contactList = c._nodeA;

            // Connect to body B
            c._nodeB.Contact = c;
            c._nodeB.Other = bodyA;

            c._nodeB.Prev = null;
            c._nodeB.Next = bodyB._contactList;
            if (bodyB._contactList != null)
            {
                bodyB._contactList.Prev = c._nodeB;
            }

            bodyB._contactList = c._nodeB;
            ++_contactCount;
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
            if (c._fixtureA == null || c._fixtureB == null)
            {
                return;
            }

            Fixture fixtureA = c._fixtureA;
            Fixture fixtureB = c._fixtureB;

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

            Body bodyA = fixtureA._body;
            Body bodyB = fixtureB._body;

            // Remove from the world.
            if (c._prev != null)
            {
                c._prev._next = c._next;
            }

            if (c._next != null)
            {
                c._next._prev = c._prev;
            }

            if (c == _contactList)
            {
                _contactList = c._next;
            }

            // Remove from body 1
            if (c._nodeA.Prev != null)
            {
                c._nodeA.Prev.Next = c._nodeA.Next;
            }

            if (c._nodeA.Next != null)
            {
                c._nodeA.Next.Prev = c._nodeA.Prev;
            }

            if (c._nodeA == bodyA._contactList)
            {
                bodyA._contactList = c._nodeA.Next;
            }

            // Remove from body 2
            if (c._nodeB.Prev != null)
            {
                c._nodeB.Prev.Next = c._nodeB.Next;
            }

            if (c._nodeB.Next != null)
            {
                c._nodeB.Next.Prev = c._nodeB.Prev;
            }

            if (c._nodeB == bodyB._contactList)
            {
                bodyB._contactList = c._nodeB.Next;
            }

            // Call the factory.
            c.Destroy();
            --_contactCount;
        }

        /// <summary>
        ///     This is the top level collision call for the time step. Here all the narrow phase collision is processed for the
        ///     world contact list.
        /// </summary>
        internal void Collide()
        {
            // Update awake contacts.

            Contact c = _contactList;

            while (c != null)
            {
                Fixture fixtureA = c._fixtureA;
                Fixture fixtureB = c._fixtureB;
                int indexA = c.ChildIndexA;
                int indexB = c.ChildIndexB;
                Body bodyA = fixtureA._body;
                Body bodyB = fixtureB._body;

                //Velcro: Do no try to collide disabled bodies
                if (!bodyA.Enabled || !bodyB.Enabled)
                {
                    c = c._next;
                    continue;
                }

                // Is this contact flagged for filtering?
                if (c.FilterFlag)
                {
                    // Should these bodies collide?
                    if (!bodyB.ShouldCollide(bodyA))
                    {
                        Contact cNuke = c;
                        c = cNuke._next;
                        Remove(cNuke);
                        continue;
                    }

                    // Check default filtering
                    if (!ShouldCollide(fixtureA, fixtureB))
                    {
                        Contact cNuke = c;
                        c = cNuke._next;
                        Remove(cNuke);
                        continue;
                    }

                    // Check user filtering.
                    if (ContactFilter != null && !ContactFilter(fixtureA, fixtureB))
                    {
                        Contact cNuke = c;
                        c = cNuke._next;
                        Remove(cNuke);
                        continue;
                    }

                    // Clear the filtering flag.
                    c._flags &= ~ContactFlags.FilterFlag;
                }

                bool activeA = bodyA.Awake && bodyA.BodyType != BodyType.Static;
                bool activeB = bodyB.Awake && bodyB.BodyType != BodyType.Static;

                // At least one body must be awake and it must be dynamic or kinematic.
                if (!activeA && !activeB)
                {
                    c = c._next;
                    continue;
                }

                int proxyIdA = fixtureA.Proxies[indexA].ProxyId;
                int proxyIdB = fixtureB.Proxies[indexB].ProxyId;
                bool overlap = BroadPhase.TestOverlap(proxyIdA, proxyIdB);

                // Here we destroy contacts that cease to overlap in the broad-phase.
                if (!overlap)
                {
                    Contact cNuke = c;
                    c = cNuke._next;
                    Remove(cNuke);
                    continue;
                }

                // The contact persists.
                c.Update(this);
                c = c._next;
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
            if (Settings.UseFpeCollisionCategories)
            {
                if (fixtureA.CollisionGroup == fixtureB.CollisionGroup &&
                    fixtureA.CollisionGroup != 0 && fixtureB.CollisionGroup != 0)
                {
                    return false;
                }

                if (((fixtureA.CollisionCategories & fixtureB.CollidesWith) ==
                     Category.None) &
                    ((fixtureB.CollisionCategories & fixtureA.CollidesWith) ==
                     Category.None))
                {
                    return false;
                }

                return true;
            }

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