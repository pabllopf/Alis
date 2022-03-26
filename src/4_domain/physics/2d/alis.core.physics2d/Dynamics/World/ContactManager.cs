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

using Alis.Core.Physics2D.Bodies;
using Alis.Core.Physics2D.Contacts;
using Alis.Core.Physics2D.Fixtures;
using Alis.Core.Physics2D.World.Callbacks;

namespace Alis.Core.Physics2D.World
{
    /// <summary>
    ///     Delegate of World.
    /// </summary>
    internal class ContactManager
    {
        /// <summary>
        ///     The broadphase
        /// </summary>
        internal BroadPhase m_broadPhase;

        /// <summary>
        ///     The contactcount
        /// </summary>
        internal int m_contactCount;

        /// <summary>
        ///     The contactfilter
        /// </summary>
        internal ContactFilter m_contactFilter;

        /// <summary>
        ///     The contactlist
        /// </summary>
        internal Contact m_contactList;

        /// <summary>
        ///     The contactlistener
        /// </summary>
        internal ContactListener m_contactListener;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactManager" /> class
        /// </summary>
        internal ContactManager()
        {
            m_contactList = null;
            m_contactCount = 0;
            m_contactFilter = new ContactFilter();
            m_contactListener = null;
            m_broadPhase = new BroadPhase();
        }

        /// <summary>
        ///     Destroys the c
        /// </summary>
        /// <param name="c">The </param>
        internal void Destroy(Contact c)
        {
            Fixture fixtureA = c.FixtureA;
            Fixture fixtureB = c.FixtureB;
            Body bodyA = fixtureA.Body;
            Body bodyB = fixtureB.Body;

            if (m_contactListener != null && c.Touching)
            {
                m_contactListener.EndContact(c);
            }

            // Remove from the world.
            if (c.m_prev != null)
            {
                c.m_prev.m_next = c.m_next;
            }

            if (c.m_next != null)
            {
                c.m_next.m_prev = c.m_prev;
            }

            if (c == m_contactList)
            {
                m_contactList = c.m_next;
            }

            // Remove from body 1
            if (c.m_nodeA.prev != null)
            {
                c.m_nodeA.prev.next = c.m_nodeA.next;
            }

            if (c.m_nodeA.next != null)
            {
                c.m_nodeA.next.prev = c.m_nodeA.prev;
            }

            if (c.m_nodeA == bodyA.m_contactList)
            {
                bodyA.m_contactList = c.m_nodeA.next;
            }

            // Remove from body 2
            if (c.m_nodeB.prev != null)
            {
                c.m_nodeB.prev.next = c.m_nodeB.next;
            }

            if (c.m_nodeB.next != null)
            {
                c.m_nodeB.next.prev = c.m_nodeB.prev;
            }

            if (c.m_nodeB == bodyB.m_contactList)
            {
                bodyB.m_contactList = c.m_nodeB.next;
            }

            // provided all the above removes all references, it'll be picked up by the GC

            --m_contactCount;
        }

        /// <summary>
        ///     Collides this instance
        /// </summary>
        internal void Collide()
        {
            // Update awake contacts.
            Contact c = m_contactList;
            while (c != null)
            {
                Fixture fixtureA = c.FixtureA;
                Fixture fixtureB = c.FixtureB;
                int indexA = c.ChildIndexA;
                int indexB = c.ChildIndexB;
                Body bodyA = fixtureA.Body;
                Body bodyB = fixtureB.Body;

                // Is this contact flagged for filtering?
                if ((c.m_flags & CollisionFlags.Filter) == CollisionFlags.Filter)
                {
                    // Should these bodies collide?
                    if (bodyB.ShouldCollide(bodyA) == false)
                    {
                        Contact cNuke = c;
                        c = cNuke.GetNext();
                        Destroy(cNuke);
                        continue;
                    }

                    // Check user filtering.
                    if (m_contactFilter != null && m_contactFilter.ShouldCollide(fixtureA, fixtureB) == false)
                    {
                        Contact cNuke = c;
                        c = cNuke.GetNext();
                        Destroy(cNuke);
                        continue;
                    }

                    // Clear the filtering flag.
                    c.m_flags &= ~CollisionFlags.Filter;
                }

                bool activeA = bodyA.IsAwake() && bodyA.m_type != BodyType.Static;
                bool activeB = bodyB.IsAwake() && bodyB.m_type != BodyType.Static;

                // At least one body must be awake and it must be dynamic or kinematic.
                if (activeA == false && activeB == false)
                {
                    c = c.GetNext();
                    continue;
                }

                int proxyIdA = fixtureA.m_proxies[indexA].proxyId;
                int proxyIdB = fixtureB.m_proxies[indexB].proxyId;
                bool overlap = m_broadPhase.TestOverlap(proxyIdA, proxyIdB);

                // Here we destroy contacts that cease to overlap in the broad-phase.
                if (overlap == false)
                {
                    Contact cNuke = c;
                    c = cNuke.GetNext();
                    Destroy(cNuke);
                    continue;
                }

                // The contact persists.
                c.Update(m_contactListener);
                c = c.GetNext();
            }
        }

        /// <summary>
        ///     Finds the new contacts
        /// </summary>
        internal void FindNewContacts()
        {
            m_broadPhase.UpdatePairs(AddPair);
        }

        /// <summary>
        ///     Adds the pair using the specified proxy user data a
        /// </summary>
        /// <param name="proxyUserDataA">The proxy user data</param>
        /// <param name="proxyUserDataB">The proxy user data</param>
        private void AddPair(object proxyUserDataA, object proxyUserDataB)
        {
            FixtureProxy proxyA = (FixtureProxy) proxyUserDataA;
            FixtureProxy proxyB = (FixtureProxy) proxyUserDataB;

            Fixture fixtureA = proxyA.fixture;
            Fixture fixtureB = proxyB.fixture;

            int indexA = proxyA.childIndex;
            int indexB = proxyB.childIndex;

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
            ContactEdge edge = bodyB.GetContactList();
            while (edge != null)
            {
                if (edge.other == bodyA)
                {
                    Fixture fA = edge.contact.GetFixtureA();
                    Fixture fB = edge.contact.GetFixtureB();
                    int iA = edge.contact.GetChildIndexA();
                    int iB = edge.contact.GetChildIndexB();

                    if (fA == fixtureA && fB == fixtureB && iA == indexA && iB == indexB)
                        // A contact already exists.
                    {
                        return;
                    }

                    if (fA == fixtureB && fB == fixtureA && iA == indexB && iB == indexA)
                        // A contact already exists.
                    {
                        return;
                    }
                }

                edge = edge.next;
            }

            // Does a joint override collision? Is at least one body dynamic?
            if (bodyB.ShouldCollide(bodyA) == false)
            {
                return;
            }

            // Check user filtering.
            if (m_contactFilter != null && m_contactFilter.ShouldCollide(fixtureA, fixtureB) == false)
            {
                return;
            }

            // Call the factory.
            Contact? c = Contact.Create(fixtureA, indexA, fixtureB, indexB);
            if (c == null)
            {
                return;
            }

            // Contact creation may swap fixtures.
            fixtureA = c.GetFixtureA();
            fixtureB = c.GetFixtureB();
            indexA = c.GetChildIndexA();
            indexB = c.GetChildIndexB();
            bodyA = fixtureA.GetBody();
            bodyB = fixtureB.GetBody();

            // Insert into the world.
            c.m_prev = null;
            c.m_next = m_contactList;
            if (m_contactList != null)
            {
                m_contactList.m_prev = c;
            }

            m_contactList = c;

            // Connect to island graph.

            // Connect to body A
            c.m_nodeA.contact = c;
            c.m_nodeA.other = bodyB;

            c.m_nodeA.prev = null;
            c.m_nodeA.next = bodyA.m_contactList;
            if (bodyA.m_contactList != null)
            {
                bodyA.m_contactList.prev = c.m_nodeA;
            }

            bodyA.m_contactList = c.m_nodeA;

            // Connect to body B
            c.m_nodeB.contact = c;
            c.m_nodeB.other = bodyA;

            c.m_nodeB.prev = null;
            c.m_nodeB.next = bodyB.m_contactList;
            if (bodyB.m_contactList != null)
            {
                bodyB.m_contactList.prev = c.m_nodeB;
            }

            bodyB.m_contactList = c.m_nodeB;

            ++m_contactCount;
        }
    }
}