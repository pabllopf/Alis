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
using Alis.Core.Physic.Collision.BroadPhase;
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
        ///     The contact list
        /// </summary>
        private readonly List<Contact> contactList = new List<Contact>();

        /// <summary>
        ///     The contact
        /// </summary>
        public readonly Queue<Contact> ContactPool = new Queue<Contact>(256);

        /// <summary>Fires when the broadphase detects that two Fixtures are close to each other.</summary>
        private readonly BroadPhaseHandler onBroadPhaseCollision;

        /// <summary>Fires when a contact is created</summary>
        public BeginContactHandler BeginContact { get; }

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
        /// <param name="broadPhase">The broad phase</param>
        internal ContactManager(IBroadPhase broadPhase)
        {
            BroadPhase = broadPhase;
            onBroadPhaseCollision = AddPair;
            Current = this;
        }

        /// <summary>
        ///     The dynamic tree broad phase
        /// </summary>
        public static ContactManager Current { get; private set; }

        /// <summary>
        ///     Gets the value of the broad phase
        /// </summary>
        public IBroadPhase BroadPhase { get; }

        /// <summary>
        ///     Gets the value of the contact count
        /// </summary>
        public int ContactCount => contactCounter;

        /// <summary>
        ///     Adds the pair using the specified proxy a
        /// </summary>
        /// <param name="proxyA">The proxy</param>
        /// <param name="proxyB">The proxy</param>
        private void AddPair(ref FixtureProxy proxyA, ref FixtureProxy proxyB)
        {
            Fixture fixtureA = proxyA.Fixture;
            Fixture fixtureB = proxyB.Fixture;

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

            if (CheckExistingContact(bodyA, bodyB, fixtureA, fixtureB, proxyA.ChildIndex, proxyB.ChildIndex))
            {
                return;
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

            CreateContact(fixtureA, proxyA.ChildIndex, fixtureB, proxyB.ChildIndex);
        }

        /// <summary>
        ///     Describes whether this instance check existing contact
        /// </summary>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="fixtureB">The fixture</param>
        /// <param name="indexA">The index</param>
        /// <param name="indexB">The index</param>
        /// <returns>The bool</returns>
        private bool CheckExistingContact(Body bodyA, Body bodyB, Fixture fixtureA, Fixture fixtureB, int indexA, int indexB)
        {
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
                        return true;
                    }

                    if ((fA == fixtureB) && (fB == fixtureA) && (iA == indexB) && (iB == indexA))
                    {
                        // A contact already exists.
                        return true;
                    }
                }

                edge = edge.Next;
            }

            return false;
        }

        /// <summary>
        ///     Creates the contact using the specified fixture a
        /// </summary>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="indexA">The index</param>
        /// <param name="fixtureB">The fixture</param>
        /// <param name="indexB">The index</param>
        private void CreateContact(Fixture fixtureA, int indexA, Fixture fixtureB, int indexB)
        {
            // Call the factory.
            Contact c = Contact.Create(fixtureA, indexA, fixtureB, indexB);
            if (c == null)
            {
                return;
            }

            fixtureA = c.FixtureA;
            fixtureB = c.FixtureB;
            Body bodyA = fixtureA.Body;
            Body bodyB = fixtureB.Body;

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
            BroadPhase.UpdatePairs(onBroadPhaseCollision);
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
        ///     Collides this instance
        /// </summary>
        internal void Collide()
        {
            for (int i = 0; i < contactList.Count; i++)
            {
                Contact c = contactList[i];

                if (!ShouldProcessContact(c))
                {
                    continue;
                }

                if (!ShouldPersistContact(c))
                {
                    Remove(c);
                    continue;
                }

                // The contact persists.
                c.Update(this);
            }
        }

        /// <summary>
        ///     Describes whether this instance should process contact
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        private bool ShouldProcessContact(Contact c)
        {
            Fixture fixtureA = c.FixtureA;
            Fixture fixtureB = c.FixtureB;
            Body bodyA = fixtureA.Body;
            Body bodyB = fixtureB.Body;

            // Do not try to collide disabled bodies
            if (!bodyA.Enabled || !bodyB.Enabled)
            {
                return false;
            }

            bool activeA = bodyA.Awake && (bodyA.BodyType != BodyType.Static);
            bool activeB = bodyB.Awake && (bodyB.BodyType != BodyType.Static);

            // At least one body must be awake and it must be dynamic or kinematic.
            return activeA || activeB;
        }

        /// <summary>
        ///     Describes whether this instance should persist contact
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The overlap</returns>
        private bool ShouldPersistContact(Contact c)
        {
            // Is this contact flagged for filtering?
            if (c.FilterFlag)
            {
                // Should these bodies collide?
                if (!ShouldBodiesCollide(c))
                {
                    return false;
                }

                // Clear the filtering flag.
                c.Flags &= ~ContactSetting.FilterFlag;
            }

            int proxyIdA = c.FixtureA.Proxies[c.ChildIndexA].ProxyId;
            int proxyIdB = c.FixtureB.Proxies[c.ChildIndexB].ProxyId;
            bool overlap = BroadPhase.TestOverlap(proxyIdA, proxyIdB);

            // Here we destroy contacts that cease to overlap in the broad-phase.
            return overlap;
        }

        /// <summary>
        ///     Describes whether this instance should bodies collide
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        private bool ShouldBodiesCollide(Contact c)
        {
            Fixture fixtureA = c.FixtureA;
            Fixture fixtureB = c.FixtureB;
            Body bodyA = fixtureA.Body;
            Body bodyB = fixtureB.Body;

            if (!bodyB.ShouldCollide(bodyA))
            {
                return false;
            }

            // Check default filtering
            if (!ShouldCollide(fixtureA, fixtureB))
            {
                return false;
            }

            // Check user filtering.
            if ((ContactFilter != null) && !ContactFilter(fixtureA, fixtureB))
            {
                return false;
            }

            return true;
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
                if (IsValidCachedToi(c) || IsSensorContact(c) || !IsActiveContact(c) || !IsCollidableContact(c))
                {
                    continue;
                }

                AdjustSweeps(c);

                ToiOutput output = ComputeTimeOfImpact(c);

                UpdateContactToi(c, output);

                if (c.Toi < minAlpha)
                {
                    lastMinAlpha = c.Toi;
                    return c;
                }
            }

            return null;
        }

        /// <summary>
        ///     Describes whether this instance is valid cached toi
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        private bool IsValidCachedToi(Contact c) => c.ToiFlag;

        /// <summary>
        ///     Describes whether this instance is sensor contact
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        private bool IsSensorContact(Contact c) => c.FixtureA.IsSensorPrivate || c.FixtureB.IsSensorPrivate;

        /// <summary>
        ///     Describes whether this instance is active contact
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        private bool IsActiveContact(Contact c)
        {
            Body bodyA = c.FixtureA.Body;
            Body bodyB = c.FixtureB.Body;

            bool activeA = bodyA.Awake && (bodyA.BodyType != BodyType.Static);
            bool activeB = bodyB.Awake && (bodyB.BodyType != BodyType.Static);

            return activeA || activeB;
        }

        /// <summary>
        ///     Describes whether this instance is collidable contact
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        private bool IsCollidableContact(Contact c)
        {
            Body bodyA = c.FixtureA.Body;
            Body bodyB = c.FixtureB.Body;

            bool collideA = (bodyA.IsBullet || bodyA.BodyType != BodyType.Dynamic) &&
                            ((c.FixtureA.IgnoreCcdWith & c.FixtureB.CollisionCategories) == 0) && !bodyA.IgnoreCcd;
            bool collideB = (bodyB.IsBullet || bodyB.BodyType != BodyType.Dynamic) &&
                            ((c.FixtureB.IgnoreCcdWith & c.FixtureA.CollisionCategories) == 0) && !bodyB.IgnoreCcd;

            return collideA || collideB;
        }

        /// <summary>
        ///     Adjusts the sweeps using the specified c
        /// </summary>
        /// <param name="c">The </param>
        private void AdjustSweeps(Contact c)
        {
            Body bodyA = c.FixtureA.Body;
            Body bodyB = c.FixtureB.Body;

            float alpha0 = bodyA.Sweep.Alpha0;

            if (bodyA.Sweep.Alpha0 < bodyB.Sweep.Alpha0)
            {
                alpha0 = bodyB.Sweep.Alpha0;
                bodyA.Sweep.Advance(alpha0);
            }
            else if (bodyB.Sweep.Alpha0 < bodyA.Sweep.Alpha0)
            {
                alpha0 = bodyA.Sweep.Alpha0;
                bodyB.Sweep.Advance(alpha0);
            }
        }

        /// <summary>
        ///     Computes the time of impact using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <returns>The output</returns>
        private ToiOutput ComputeTimeOfImpact(Contact c)
        {
            ToiInput input = new ToiInput
            {
                ProxyA = new DistanceProxy(c.FixtureA.Shape, c.ChildIndexA),
                ProxyB = new DistanceProxy(c.FixtureB.Shape, c.ChildIndexB),
                SweepA = c.FixtureA.Body.Sweep,
                SweepB = c.FixtureB.Body.Sweep,
                Max = 1.0f
            };

            TimeOfImpact.CalculateTimeOfImpact(ref input, out ToiOutput output);

            return output;
        }

        /// <summary>
        ///     Updates the contact toi using the specified c
        /// </summary>
        /// <param name="c">The </param>
        /// <param name="output">The output</param>
        private void UpdateContactToi(Contact c, ToiOutput output)
        {
            float beta = output.Property;
            float alpha = output.State == ToiOutputState.Touching ? Math.Min(c.FixtureA.Body.Sweep.Alpha0 + (1.0f - c.FixtureA.Body.Sweep.Alpha0) * beta, 1.0f) : 1.0f;

            c.Toi = alpha;
            c.Flags &= ~ContactSetting.ToiFlag;
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