// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:World.cs
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
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Collision.Broadphase;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Distance;
using Alis.Core.Physic.Collision.TOI;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Alis.Core.Physic.Dynamics.Solver;
using Alis.Core.Physic.Extensions.Controllers.ControllerBase;

namespace Alis.Core.Physic
{
    /// <summary>The world class manages all physics entities, dynamic simulation, and asynchronous queries.</summary>
    public class World
    {
        /// <summary>
        ///     The island
        /// </summary>
        private readonly Island island;

        /// <summary>
        ///     The breakable body
        /// </summary>
        private readonly List<BreakableBody> BreakableBodies = new List<BreakableBody>();

        /// <summary>
        ///     The contact
        /// </summary>
        public readonly Queue<Contact> ContactPool = new Queue<Contact>(256);

        /// <summary>
        ///     Initializes a new instance of the <see cref="World" /> class
        /// </summary>
        /// <param name="gravity">The gravity</param>
        public World(Vector2F gravity)
        {
            Gravity = gravity;
            Current = this;
            ContactManager = new ContactManager(new DynamicTreeBroadPhase());
            island = new Island(ContactManager);
        }

        /// <summary>
        ///     Gets the value of the gravity
        /// </summary>
        private Vector2F Gravity { get; }

        /// <summary>
        ///     Gets or sets the value of the bodys
        /// </summary>
        public List<Body> Bodies { get; } = new List<Body>();

        /// <summary>
        ///     Gets or sets the value of the joints
        /// </summary>
        private List<Joint> Joints { get; } = new List<Joint>();

        /// <summary>
        ///     Gets the value of the controllers
        /// </summary>
        private List<Controller> Controllers { get; } = new List<Controller>();

        /// <summary>
        ///     Gets or sets the value of the contact manager
        /// </summary>
        public ContactManager ContactManager { get; set; }

        /// <summary>
        ///     Gets or sets the value of the step
        /// </summary>
        private TimeStep TimeStep { get; set; } = new TimeStep();

        /// <summary>
        ///     The current
        /// </summary>
        public static World Current;

        /// <summary>
        ///     Adds the body using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        public void AddBody(Body body) => Bodies.Add(body);

        /// <summary>
        ///     Removes the body using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        public void RemoveBody(Body body) => Bodies.Remove(body);

        /// <summary>
        ///     Adds the breakable body using the specified breakable body
        /// </summary>
        /// <param name="breakableBody">The breakable body</param>
        public void AddBreakableBody(BreakableBody breakableBody) => BreakableBodies.Add(breakableBody);

        /// <summary>
        ///     Removes the breakable body using the specified breakable body
        /// </summary>
        /// <param name="breakableBody">The breakable body</param>
        public void RemoveBreakableBody(BreakableBody breakableBody) => BreakableBodies.Remove(breakableBody);

        /// <summary>
        ///     Adds the joint using the specified joint
        /// </summary>
        /// <param name="joint">The joint</param>
        public void AddJoint(Joint joint) => Joints.Add(joint);

        /// <summary>
        ///     Removes the joint using the specified joint
        /// </summary>
        /// <param name="joint">The joint</param>
        public void RemoveJoint(Joint joint) => Joints.Remove(joint);

        /// <summary>
        ///     Adds the controller using the specified controller
        /// </summary>
        /// <param name="controller">The controller</param>
        public void AddController(Controller controller) => Controllers.Add(controller);

        /// <summary>
        ///     Removes the controller using the specified controller
        /// </summary>
        /// <param name="controller">The controller</param>
        public void RemoveController(Controller controller) => Controllers.Remove(controller);

        /// <summary>
        ///     Steps the dt
        /// </summary>
        /// <param name="dt">The dt</param>
        /// <param name="velocityIterations">The velocity iterations</param>
        /// <param name="positionIterations">The position iterations</param>
        public void Step(float dt, int velocityIterations = 8, int positionIterations = 3)
        {
            FindNewContacts();
            UpdateTimeStep(dt, velocityIterations, positionIterations);
            UpdateControllers(dt);
            CollideContacts();
            Solve();
            SolveToi();
            UpdateInvertedDeltaTime(dt);
            ClearForces();
            UpdateBreakableBodies();
        }

        /// <summary>
        ///     Finds the new contacts
        /// </summary>
        private void FindNewContacts() => ContactManager.FindNewContacts();

        /// <summary>
        ///     Updates the time step using the specified dt
        /// </summary>
        /// <param name="dt">The dt</param>
        /// <param name="velocityIterations">The velocity iterations</param>
        /// <param name="positionIterations">The position iterations</param>
        private void UpdateTimeStep(float dt, int velocityIterations, int positionIterations)
        {
            TimeStep.DeltaTime = dt;
            TimeStep.VelocityIterations = velocityIterations;
            TimeStep.PositionIterations = positionIterations;
            TimeStep.InvertedDeltaTime = dt > 0.0f ? 1.0f / dt : 0.0f;
            TimeStep.DeltaTimeRatio = TimeStep.InvertedDeltaTimeZero * dt;
        }

        /// <summary>
        ///     Updates the controllers using the specified dt
        /// </summary>
        /// <param name="dt">The dt</param>
        private void UpdateControllers(float dt) => Controllers.ForEach(controller => controller.Update(dt));

        /// <summary>
        ///     Collides the contacts
        /// </summary>
        private void CollideContacts() => ContactManager.Collide();

        /// <summary>
        ///     Updates the inverted delta time using the specified dt
        /// </summary>
        /// <param name="dt">The dt</param>
        private void UpdateInvertedDeltaTime(float dt) => TimeStep.InvertedDeltaTimeZero = TimeStep.DeltaTime > 0.0f ? TimeStep.InvertedDeltaTime : TimeStep.InvertedDeltaTimeZero;

        /// <summary>
        ///     Updates the breakable bodies
        /// </summary>
        private void UpdateBreakableBodies() => BreakableBodies.ForEach(body => body.Update());

        /// <summary>
        ///     Solves the step
        /// </summary>
        private void Solve()
        {
            // Clear all the island flags.
            Bodies.ForEach(i => i.ClearFlags());

            // Clear all flags of the contacts.
            ContactManager.ClearFlags();

            // DisableIslandFlag for all joints.
            Joints.ForEach(i => i.DisableIslandFlag());

            for (int index = Bodies.Count - 1; index >= 0; index--)
            {
                Body body = Bodies[index];
                if ((body.Flags & BodyFlags.IslandFlag) == BodyFlags.IslandFlag)
                {
                    continue;
                }

                if (!body.Awake || !body.Enabled)
                {
                    continue;
                }

                // The seed can be dynamic or kinematic.
                if (body.BodyType == BodyType.Static)
                {
                    continue;
                }

                // Reset island and stack.
                island.Clear();

                body.Flags |= BodyFlags.IslandFlag;

                //Debug.Assert(b.Enabled);
                island.Add(body);

                // To keep islands as small as possible, we don't
                // propagate islands across static bodies.
                if (body.BodyType == BodyType.Static)
                {
                    continue;
                }

                // Make sure the body is awake (without resetting sleep timer).
                body.Flags |= BodyFlags.AwakeFlag;

                // Search all contacts connected to this body.
                for (ContactEdge ce = body.ContactList; ce != null; ce = ce.Next)
                {
                    Contact contact = ce.Contact;

                    // Has this contact already been added to an island?
                    if (contact.IslandFlag)
                    {
                        continue;
                    }

                    // Is this contact solid and touching?
                    if (!contact.Enabled || !contact.IsTouching)
                    {
                        continue;
                    }

                    // Skip sensors.
                    bool sensorA = contact.FixtureA.IsSensor;
                    bool sensorB = contact.FixtureB.IsSensor;
                    if (sensorA || sensorB)
                    {
                        continue;
                    }

                    island.Add(contact);
                    contact.Flags |= ContactFlags.IslandFlag;

                    Body other = ce.Other;

                    // Was the other body already added to this island?
                    if (other.IsIsland)
                    {
                        continue;
                    }

                    //Debug.Assert(stackCount < stackSize);
                    other.Flags |= BodyFlags.IslandFlag;
                }

                // Search all joints connect to this body.
                for (JointEdge je = body.JointList; je != null; je = je.Next)
                {
                    if (je.Joint.IslandFlag)
                    {
                        continue;
                    }

                    Body other = je.Other;

                    // WIP David
                    //Enter here when it's a non-fixed joint. Non-fixed joints have a other body.
                    if (other != null)
                    {
                        // Don't simulate joints connected to inactive bodies.
                        if (!other.Enabled)
                        {
                            continue;
                        }

                        island.Add(je.Joint);
                        je.Joint.IslandFlag = true;

                        if (other.IsIsland)
                        {
                            continue;
                        }

                        other.Flags |= BodyFlags.IslandFlag;
                    }
                    else
                    {
                        island.Add(je.Joint);
                        je.Joint.IslandFlag = true;
                    }
                }

                island.Solve(TimeStep, Gravity, true);
            }

            // Posts the solve cleanup
            island.PostSolveCleanup();

            // Synchronize fixtures, check for out of range bodies.
            Bodies.ForEach(i => i.CheckOutRange());

            // Look for new contacts.
            ContactManager.FindNewContacts();
        }

        /// <summary>
        ///     Solves the toi
        /// </summary>
        private void SolveToi()
        {
            Bodies.ForEach(i =>
            {
                i.Flags &= ~BodyFlags.IslandFlag;
                i.Sweep.Alpha0 = 0.0f;
            });

            foreach (Contact c in ContactManager.ContactList)
            {
                // Invalidate TOI
                c.Flags &= ~(ContactFlags.ToiFlag | ContactFlags.IslandFlag);
                c.ToiCount = 0;
                c.Toi = 1.0f;
            }

            // Find TOI events and solve them.
            for (;;)
            {
                // Find the first TOI.
                Contact minContact = null;
                float minAlpha = 1.0f;

                foreach (Contact c in ContactManager.ContactList)
                {
                    // Is this contact disabled?
                    if (!c.Enabled)
                    {
                        continue;
                    }

                    // Prevent excessive sub-stepping.
                    if (c.ToiCount > Settings.SubSteps)
                    {
                        continue;
                    }

                    float alpha;
                    if (c.ToiFlag)
                    {
                        // This contact has a valid cached TOI.
                        alpha = c.Toi;
                    }
                    else
                    {
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
                        //Debug.Assert(typeA == BodyType.Dynamic || typeB == BodyType.Dynamic);

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

                        //Debug.Assert(alpha0 < 1.0f);

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
                        if (output.State == ToiOutputState.Touching)
                        {
                            alpha = Math.Min(alpha0 + (1.0f - alpha0) * beta, 1.0f);
                        }
                        else
                        {
                            alpha = 1.0f;
                        }

                        c.Toi = alpha;
                        c.Flags &= ~ContactFlags.ToiFlag;
                    }

                    if (alpha < minAlpha)
                    {
                        // This is the minimum TOI found so far.
                        minContact = c;
                        minAlpha = alpha;
                    }
                }

                if (minContact == null || 1.0f - 10.0f * Constant.Epsilon < minAlpha)
                {
                    // No more TOI events. Done!
                    //StepComplete = true;
                    break;
                }

                // Advance the bodies to the TOI.
                Fixture fA1 = minContact.FixtureA;
                Fixture fB1 = minContact.FixtureB;
                Body bA0 = fA1.Body;
                Body bB0 = fB1.Body;

                Sweep backup1 = bA0.Sweep;
                Sweep backup2 = bB0.Sweep;

                bA0.Advance(minAlpha);
                bB0.Advance(minAlpha);

                // The TOI contact likely has some new contact points.
                minContact.Update(ContactManager);
                minContact.Flags &= ~ContactFlags.ToiFlag;
                ++minContact.ToiCount;

                // Is the contact solid?
                if (!minContact.Enabled || !minContact.IsTouching)
                {
                    // Restore the sweeps.
                    minContact.Flags &= ~ContactFlags.EnabledFlag;
                    bA0.Sweep = backup1;
                    bB0.Sweep = backup2;
                    bA0.SynchronizeTransform();
                    bB0.SynchronizeTransform();
                    continue;
                }

                bA0.Awake = true;
                bB0.Awake = true;

                // Build the island
                island.Clear();
                island.Add(bA0);
                island.Add(bB0);
                island.Add(minContact);

                bA0.Flags |= BodyFlags.IslandFlag;
                bB0.Flags |= BodyFlags.IslandFlag;
                minContact.Flags &= ~ContactFlags.IslandFlag;

                // Get contacts on bodyA and bodyB.
                Body[] bodies = {bA0, bB0};
                for (int i = 0; i < 2; ++i)
                {
                    Body body = bodies[i];
                    if (body.BodyType == BodyType.Dynamic)
                    {
                        for (ContactEdge ce = body.ContactList; ce != null; ce = ce.Next)
                        {
                            Contact contact = ce.Contact;

                            // Has this contact already been added to the island?
                            if (contact.IslandFlag)
                            {
                                continue;
                            }

                            // Only add static, kinematic, or bullet bodies.
                            Body other = ce.Other;
                            if ((other.BodyType == BodyType.Dynamic) &&
                                !body.IsBullet && !other.IsBullet)
                            {
                                continue;
                            }

                            // Skip sensors.
                            bool sensorA = contact.FixtureA.IsSensorPrivate;
                            bool sensorB = contact.FixtureB.IsSensorPrivate;
                            if (sensorA || sensorB)
                            {
                                continue;
                            }

                            // Tentatively advance the body to the TOI.
                            Sweep backup = other.Sweep;
                            if (!other.IsIsland)
                            {
                                other.Advance(minAlpha);
                            }

                            // Update the contact points
                            contact.Update(ContactManager);

                            // Was the contact disabled by the user?
                            if (!contact.Enabled)
                            {
                                other.Sweep = backup;
                                other.SynchronizeTransform();
                                continue;
                            }

                            // Are there contact points?
                            if (!contact.IsTouching)
                            {
                                other.Sweep = backup;
                                other.SynchronizeTransform();
                                continue;
                            }

                            // Add the contact to the island
                            minContact.Flags |= ContactFlags.IslandFlag;
                            island.Add(contact);

                            // Has the other body already been added to the island?
                            if (other.IsIsland)
                            {
                                continue;
                            }

                            // Add the other body to the island.
                            other.Flags |= BodyFlags.IslandFlag;

                            if (other.BodyType != BodyType.Static)
                            {
                                other.Awake = true;
                            }

                            island.Add(other);
                        }
                    }
                }

                TimeStep subStep = new TimeStep();
                subStep.DeltaTime = (1.0f - minAlpha) * TimeStep.DeltaTime;
                subStep.InvertedDeltaTime = 1.0f / subStep.DeltaTime;
                subStep.DeltaTimeRatio = 1.0f;
                subStep.PositionIterations = 20;
                subStep.VelocityIterations = TimeStep.VelocityIterations;
                subStep.WarmStarting = false;
                island.SolveToi(ref subStep, bA0.IslandIndex, bB0.IslandIndex);

                // Reset island flags and synchronize broad-phase proxies.
                for (int i = 0; i < island.Bodies.Count; ++i)
                {
                    Body body = island.Bodies[i];
                    body.Flags &= ~BodyFlags.IslandFlag;

                    if (body.BodyType != BodyType.Dynamic)
                    {
                        continue;
                    }

                    body.SynchronizeFixtures();

                    // Invalidate all contact TOIs on this displaced body.
                    for (ContactEdge ce = body.ContactList; ce != null; ce = ce.Next)
                    {
                        ce.Contact.Flags &= ~(ContactFlags.ToiFlag | ContactFlags.IslandFlag);
                    }
                }

                // Commit fixture proxy movements to the broad-phase so that new contacts are created.
                // Also, some contacts can be destroyed.
                ContactManager.FindNewContacts();
            }
        }

        /// <summary>
        ///     Clear all forces
        /// </summary>
        internal void ClearForces() => Bodies.ForEach(i => i.ClearForces());
    }
}