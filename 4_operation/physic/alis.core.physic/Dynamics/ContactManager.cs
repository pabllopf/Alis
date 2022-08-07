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

using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The contact manager class
    /// </summary>
    /// <seealso cref="PairCallback" />
    public class ContactManager : PairCallback
    {
        /// <summary>
        ///     The destroy immediate
        /// </summary>
        public bool DestroyImmediate;

        // This lets us provide broadphase proxy pair user data for
        // contacts that shouldn't exist.
        /// <summary>
        ///     The null contact
        /// </summary>
        public NullContact NullContact;

        /// <summary>
        ///     The world
        /// </summary>
        public World World;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactManager" /> class
        /// </summary>
        public ContactManager()
        {
        }

        // This is a callback from the broadphase when two AABB proxies begin
        // to overlap. We create a Contact to manage the narrow phase.
        /// <summary>
        ///     Pairs the added using the specified proxy user data a
        /// </summary>
        /// <param name="proxyUserDataA">The proxy user data</param>
        /// <param name="proxyUserDataB">The proxy user data</param>
        /// <returns>The </returns>
        public override object PairAdded(object proxyUserDataA, object proxyUserDataB)
        {
            Fixture fixtureA = proxyUserDataA as Fixture;
            Fixture fixtureB = proxyUserDataB as Fixture;

            Body bodyA = fixtureA.Body;
            Body bodyB = fixtureB.Body;

            if (bodyA.IsStatic() && bodyB.IsStatic())
            {
                return NullContact;
            }

            if (fixtureA.Body == fixtureB.Body)
            {
                return NullContact;
            }

            if (bodyB.IsConnected(bodyA))
            {
                return NullContact;
            }

            if (World.ContactFilter != null && World.ContactFilter.ShouldCollide(fixtureA, fixtureB) == false)
            {
                return NullContact;
            }

            // Call the factory.
            Contact c = Contact.Create(fixtureA, fixtureB);

            if (c == null)
            {
                return NullContact;
            }

            // Contact creation may swap shapes.
            fixtureA = c.FixtureA;
            fixtureB = c.FixtureB;
            bodyA = fixtureA.Body;
            bodyB = fixtureB.Body;

            // Insert into the world.
            c.Prev = null;
            c.Next = World.ContactList;
            if (World.ContactList != null)
            {
                World.ContactList.Prev = c;
            }

            World.ContactList = c;

            // Connect to island graph.

            // Connect to body 1
            c.NodeA.Contact = c;
            c.NodeA.Other = bodyB;

            c.NodeA.Prev = null;
            c.NodeA.Next = bodyA.ContactList;
            if (bodyA.ContactList != null)
            {
                bodyA.ContactList.Prev = c.NodeA;
            }

            bodyA.ContactList = c.NodeA;

            // Connect to body 2
            c.NodeB.Contact = c;
            c.NodeB.Other = bodyA;

            c.NodeB.Prev = null;
            c.NodeB.Next = bodyB.ContactList;
            if (bodyB.ContactList != null)
            {
                bodyB.ContactList.Prev = c.NodeB;
            }

            bodyB.ContactList = c.NodeB;

            ++World.ContactCount;
            return c;
        }

        // This is a callback from the broadphase when two AABB proxies cease
        // to overlap. We retire the Contact.
        /// <summary>
        ///     Pairs the removed using the specified proxy user data 1
        /// </summary>
        /// <param name="proxyUserData1">The proxy user data</param>
        /// <param name="proxyUserData2">The proxy user data</param>
        /// <param name="pairUserData">The pair user data</param>
        public override void PairRemoved(object proxyUserData1, object proxyUserData2, object pairUserData)
        {
            //B2_NOT_USED(proxyUserData1);
            //B2_NOT_USED(proxyUserData2);

            if (pairUserData == null)
            {
                return;
            }

            Contact c = pairUserData as Contact;
            if (c == NullContact)
            {
                return;
            }

            // An attached body is being destroyed, we must destroy this contact
            // immediately to avoid orphaned shape pointers.
            Destroy(c);
        }

        /// <summary>
        ///     Destroys the c
        /// </summary>
        /// <param name="c">The </param>
        public void Destroy(Contact c)
        {
            Fixture fixtureA = c.FixtureA;
            Fixture fixtureB = c.FixtureB;
            Body bodyA = fixtureA.Body;
            Body bodyB = fixtureB.Body;

            if (c.Manifold.PointCount > 0)
            {
                if (World.ContactListener != null)
                {
                    World.ContactListener.EndContact(c);
                }
            }

            // Remove from the world.
            if (c.Prev != null)
            {
                c.Prev.Next = c.Next;
            }

            if (c.Next != null)
            {
                c.Next.Prev = c.Prev;
            }

            if (c == World.ContactList)
            {
                World.ContactList = c.Next;
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
            Contact.Destroy(ref c);
            --World.ContactCount;
        }

        // This is the top level collision call for the time step. Here
        // all the narrow phase collision is processed for the world
        // contact list.
        /// <summary>
        ///     Collides this instance
        /// </summary>
        public void Collide()
        {
            // Update awake contacts.
            for (Contact c = World.ContactList; c != null; c = c.GetNext())
            {
                Body bodyA = c.FixtureA.Body;
                Body bodyB = c.FixtureB.Body;
                if (bodyA.IsSleeping() && bodyB.IsSleeping())
                {
                    continue;
                }

                c.Update(World.ContactListener);
            }
        }
    }
}