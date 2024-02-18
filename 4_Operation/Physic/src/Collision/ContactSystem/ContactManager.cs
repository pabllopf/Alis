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
using System.Linq;
using Alis.Core.Physic.Collision.Broadphase;
using Alis.Core.Physic.Collision.Distance;
using Alis.Core.Physic.Collision.Handlers;
using Alis.Core.Physic.Collision.TOI;
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
        /// <summary>
        ///     The current instance
        /// </summary>
        public static ContactManager Current;

        /// <summary>
        ///     The contact list
        /// </summary>
        private readonly List<Contact> contactList = new List<Contact>();

        /// <summary>
        ///     The contact
        /// </summary>
        public readonly Queue<Contact> ContactPool = new Queue<Contact>(256);

        /// <summary>Fires when the broadphase detects that two Fixtures are close to each other.</summary>
        private readonly BroadphaseHandler onBroadphaseCollision;

        /// <summary>Fires when a contact is created</summary>
        public BeginContactHandler BeginContact;

        /// <summary>
        ///     The contact count
        /// </summary>
        private int contactCounter;

        /// <summary>The filter used by the contact manager.</summary>
        public CollisionFilterHandler ContactFilter;

        /// <summary>Fires when a contact is deleted</summary>
        public EndContactHandler EndContact;

        /// <summary>
        ///     The last min alpha
        /// </summary>
        private float lastMinAlpha;

        /// <summary>Fires after the solver has run</summary>
        public PostSolveHandler PostSolve;

        /// <summary>Fires before the solver runs</summary>
        public PreSolveHandler PreSolve;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactManager" /> class
        /// </summary>
        static ContactManager() => Current = new ContactManager(new DynamicTreeBroadPhase());

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactManager" /> class
        /// </summary>
        /// <param name="broadPhase">The broad phase</param>
        internal ContactManager(IBroadPhase broadPhase)
        {
            BroadPhase = broadPhase;
            onBroadphaseCollision = AddPair;
            Current = this;
        }

        /// <summary>
        ///     Gets the value of the broad phase
        /// </summary>
        public IBroadPhase BroadPhase { get; }

        /// <summary>
        ///     Gets the value of the contact count
        /// </summary>
        public int ContactCount => contactCounter;

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

            if (fixtureA == null || fixtureB == null)
            {
                return;
            }

            Body bodyA = fixtureA.Body;
            Body bodyB = fixtureB.Body;

            // Are the fixtures on the same body?
            if (bodyA == bodyB)
            {
                return;
            }

            ContactEdge edge = bodyB.ContactList;
            while (edge != null)
            {
                if (edge.Other == bodyA)
                {
                    Fixture fA = edge.Contact.FixtureA;
                    Fixture fB = edge.Contact.FixtureB;
                    int iA = edge.Contact.ChildIndexA;
                    int iB = edge.Contact.ChildIndexB;

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
            if ((ContactFilter != null) && !ContactFilter(fixtureA, fixtureB))
            {
                return;
            }

            //Velcro: BeforeCollision delegate
            if ((fixtureA.BeforeCollision != null) && !fixtureA.BeforeCollision(fixtureA, fixtureB))
            {
                return;
            }

            if ((fixtureB.BeforeCollision != null) && !fixtureB.BeforeCollision(fixtureB, fixtureA))
            {
                return;
            }

            // Call the factory.
            Contact c = Contact.Create(fixtureA, indexA, fixtureB, indexB);
            if (c == null)
            {
                return;
            }

            fixtureA = c.FixtureA;
            fixtureB = c.FixtureB;
            bodyA = fixtureA.Body;
            bodyB = fixtureB.Body;


            contactList.Add(c);

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
            ++contactCounter;
        }

        /// <summary>
        ///     Finds the new contacts
        /// </summary>
        internal void FindNewContacts()
        {
            BroadPhase.UpdatePairs(onBroadphaseCollision);
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

            Body bodyA = fixtureA.Body;
            Body bodyB = fixtureB.Body;

            // Remove from the world.
            /*
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
            }*/
            contactList.Remove(c);

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
            --contactCounter;
        }

        /// <summary>
        ///     This is the top level collision call for the time step. Here all the narrow phase collision is processed for the
        ///     world contact list.
        /// </summary>
        internal void Collide()
        {
            for (int i = 0; i < contactList.Count; i++)
            {
                Contact c = contactList[i];

                Fixture fixtureA = c.FixtureA;
                Fixture fixtureB = c.FixtureB;
                int indexA = c.ChildIndexA;
                int indexB = c.ChildIndexB;
                Body bodyA = fixtureA.Body;
                Body bodyB = fixtureB.Body;

                //Velcro: Do no try to collide disabled bodies
                if (!bodyA.Enabled || !bodyB.Enabled)
                {
                    continue;
                }

                // Is this contact flagged for filtering?
                if (c.FilterFlag)
                {
                    // Should these bodies collide?
                    if (!bodyB.ShouldCollide(bodyA))
                    {
                        Remove(c);
                        continue;
                    }

                    // Check default filtering
                    if (!ShouldCollide(fixtureA, fixtureB))
                    {
                        Remove(c);
                        continue;
                    }

                    // Check user filtering.
                    if ((ContactFilter != null) && !ContactFilter(fixtureA, fixtureB))
                    {
                        Remove(c);
                        continue;
                    }

                    // Clear the filtering flag.
                    c.Flags &= ~ContactFlags.FilterFlag;
                }

                bool activeA = bodyA.Awake && (bodyA.BodyType != BodyType.Static);
                bool activeB = bodyB.Awake && (bodyB.BodyType != BodyType.Static);

                // At least one body must be awake and it must be dynamic or kinematic.
                if (!activeA && !activeB)
                {
                    continue;
                }

                int proxyIdA = fixtureA.Proxies[indexA].ProxyId;
                int proxyIdB = fixtureB.Proxies[indexB].ProxyId;
                bool overlap = BroadPhase.TestOverlap(proxyIdA, proxyIdB);

                // Here we destroy contacts that cease to overlap in the broad-phase.
                if (!overlap)
                {
                    Remove(c);
                    continue;
                }

                // The contact persists.
                c.Update(this);
            }
        }

        /// <summary>
        ///     Gets the the min contact using the specified min alpha
        /// </summary>
        /// <param name="minAlpha">The min alpha</param>
        /// <returns>The contact</returns>
        internal Contact GetTheMinContact(float minAlpha)
        {
            foreach (Contact c in contactList.Where(c => c.Enabled).Where(c => c.ToiCount <= Settings.SubSteps))
            {
                if (c.ToiFlag)
                {
                    // This contact has a valid cached TOI.
                    continue;
                }

                Fixture fA = c.FixtureA;
                Fixture fB = c.FixtureB;

                // Is there a sensor?
                if (fA.IsSensorPrivate || fB.IsSensorPrivate)
                {
                    continue;
                }

                Body bA = fA.Body;
                Body bB = fB.Body;

                BodyType typeA = bA.BodyType;
                BodyType typeB = bB.BodyType;

                bool activeA = bA.Awake && (typeA != BodyType.Static);
                bool activeB = bB.Awake && (typeB != BodyType.Static);

                // Is at least one body active (awake and dynamic or kinematic)?
                if (!activeA && !activeB)
                {
                    continue;
                }

                bool collideA = (bA.IsBullet || typeA != BodyType.Dynamic) &&
                                ((fA.IgnoreCcdWith & fB.CollisionCategories) == 0) && !bA.IgnoreCcd;
                bool collideB = (bB.IsBullet || typeB != BodyType.Dynamic) &&
                                ((fB.IgnoreCcdWith & fA.CollisionCategories) == 0) && !bB.IgnoreCcd;

                // Are these two non-bullet dynamic bodies?
                if (!collideA && !collideB)
                {
                    continue;
                }

                // Compute the TOI for this contact.
                // Put the sweeps onto the same time interval.
                float alpha0 = bA.Sweep.Alpha0;

                if (bA.Sweep.Alpha0 < bB.Sweep.Alpha0)
                {
                    alpha0 = bB.Sweep.Alpha0;
                    bA.Sweep.Advance(alpha0);
                }
                else if (bB.Sweep.Alpha0 < bA.Sweep.Alpha0)
                {
                    alpha0 = bA.Sweep.Alpha0;
                    bB.Sweep.Advance(alpha0);
                }

                // Compute the time of impact in interval [0, minTOI]
                ToiInput input = new ToiInput
                {
                    ProxyA = new DistanceProxy(fA.Shape, c.ChildIndexA),
                    ProxyB = new DistanceProxy(fB.Shape, c.ChildIndexB),
                    SweepA = bA.Sweep,
                    SweepB = bB.Sweep,
                    Max = 1.0f
                };

                TimeOfImpact.CalculateTimeOfImpact(ref input, out ToiOutput output);

                // Beta is the fraction of the remaining portion of the .
                float beta = output.T;
                float alpha = output.State == ToiOutputState.Touching ? Math.Min(alpha0 + (1.0f - alpha0) * beta, 1.0f) : 1.0f;

                c.Toi = alpha;
                c.Flags &= ~ContactFlags.ToiFlag;


                if (alpha < minAlpha)
                {
                    // This is the minimum TOI found so far.
                    lastMinAlpha = alpha;
                    return c;
                }
            }

            return null;
        }

        /// <summary>
        ///     Describes whether should collide
        /// </summary>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="fixtureB">The fixture</param>
        /// <returns>The collide</returns>
        private static bool ShouldCollide(Fixture fixtureA, Fixture fixtureB)
        {
            if ((fixtureA.CollisionGroup == fixtureB.CollisionGroup) &&
                (fixtureA.CollisionGroup != 0))
            {
                return fixtureA.CollisionGroup > 0;
            }

            bool collide = ((fixtureA.CollidesWith & fixtureB.CollisionCategories) != 0) &&
                           ((fixtureA.CollisionCategories & fixtureB.CollidesWith) != 0);

            return collide;
        }

        /// <summary>
        ///     Clears the flags
        /// </summary>
        internal void ClearFlags() => contactList.ForEach(c => c.ClearFlags());

        /// <summary>
        ///     Invalidates the toi
        /// </summary>
        public void InvalidateToi() => contactList.ForEach(i => i.InvalidateToi());

        /// <summary>
        ///     Calculates the min alpha
        /// </summary>
        /// <returns>The float</returns>
        public float CalculateMinAlpha() => lastMinAlpha;
    }
}