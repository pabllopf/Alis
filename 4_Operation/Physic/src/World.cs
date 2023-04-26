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

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Collision.Broadphase;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.TOI;
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
        private readonly List<BreakableBody> breakableBodies = new List<BreakableBody>();

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
            island = new Island();
        }

        /// <summary>
        ///     Gets the value of the gravity
        /// </summary>
        private Vector2F Gravity { get; }

        /// <summary>
        ///     Gets or sets the value of the bodies
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
        public void AddBreakableBody(BreakableBody breakableBody) => breakableBodies.Add(breakableBody);

        /// <summary>
        ///     Removes the breakable body using the specified breakable body
        /// </summary>
        /// <param name="breakableBody">The breakable body</param>
        public void RemoveBreakableBody(BreakableBody breakableBody) => breakableBodies.Remove(breakableBody);

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
        private void UpdateBreakableBodies() => breakableBodies.ForEach(body => body.Update());

        /// <summary>
        ///     Solves the step
        /// </summary>
        private void Solve()
        {
            // Clear all the island flags.
            Bodies.ForEach(i => i.ClearFlags());
            
            // DisableIslandFlag for all joints.
            Joints.ForEach(i => i.DisableIslandFlag());

            // Clear all flags of the contacts.
            ContactManager.ClearFlags();
            
            // Island solving.
            island.Solve(TimeStep, Gravity, true, ContactManager, Bodies);

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
            SetAlphaToZeroForFastMovingBodies();
            InvalidateContactToIs();
            SolveToiEvents();
        }
        
        /// <summary>
        /// Sets the alpha to zero for fast moving bodies
        /// </summary>
        private void SetAlphaToZeroForFastMovingBodies() => Bodies.ForEach(i => i.SetAlphaToZero());

        /// <summary>
        /// Invalidates the contact to is
        /// </summary>
        private void InvalidateContactToIs() => ContactManager.InvalidateTOI();
        
        /// <summary>
        /// Solves the TOI (Time of Impact) events.
        /// </summary>
        private void SolveToiEvents()
        {
            while (true)
            {
                // Reset minAlpha to 1.0f
                float minAlpha = 1.0f;
                
                // Find the first TOI contact.
                Contact minContact = ContactManager.GetTheMinContact(ref minAlpha);

                if (minContact == null || IsMinAlphaGreaterThanEpsilon(minAlpha))
                {
                    // No more TOI events. Done!
                    return;
                }

                // Advance the bodies to the TOI.
                Body[] bodies = AdvanceBody(ref minContact, ref minAlpha);

                // Solve the TOI island.
                SolveToiIsland(minAlpha, bodies[0].IslandIndex, bodies[1].IslandIndex);

                // Reset island flags and synchronize broad-phase proxies.
                SynchronizeIslandBodies();

                // Commit fixture proxy movements to the broad-phase so that new contacts are created.
                // Also, some contacts can be destroyed.
                FindNewContacts();
            }
        }

        /// <summary>
        /// Describes whether this instance is min alpha greater than epsilon
        /// </summary>
        /// <param name="minAlpha">The min alpha</param>
        /// <returns>The bool</returns>
        private static bool IsMinAlphaGreaterThanEpsilon(float minAlpha) => minAlpha >= 1.0f - Constant.Epsilon * 10.0f;

        /// <summary>
        /// Advances the body using the specified min contact
        /// </summary>
        /// <param name="minContact">The min contact</param>
        /// <param name="minAlpha">The min alpha</param>
        /// <returns>The bodies</returns>
        private Body[] AdvanceBody(ref Contact minContact, ref float minAlpha)
        {
            // Advance the bodies to the TOI.
            Fixture fA1 = minContact.FixtureA;
            Fixture fB1 = minContact.FixtureB;
            Body bA0 = fA1.Body;
            Body bB0 = fB1.Body;
            
            Body[] bodies = {bA0, bB0};

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
                return bodies;
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

            // Get contacts on bodyA and bodyB;
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

            return bodies;
        }

        /// <summary>
        /// Solves the toi island using the specified min alpha
        /// </summary>
        /// <param name="minAlpha">The min alpha</param>
        /// <param name="islandIndexA">The island index</param>
        /// <param name="islandIndexB">The island index</param>
        private void SolveToiIsland(float minAlpha, int islandIndexA, int islandIndexB)
        {
            island.SolveToi(
                new TimeStep
                {
                    DeltaTime = (1.0f - minAlpha) * TimeStep.DeltaTime,
                    InvertedDeltaTime = 1.0f / ((1.0f - minAlpha) * TimeStep.DeltaTime),
                    DeltaTimeRatio = 1.0f,
                    PositionIterations = 20,
                    VelocityIterations = TimeStep.VelocityIterations,
                    WarmStarting = false
                },
                islandIndexA, 
                islandIndexB, 
                ContactManager);
        }

        /// <summary>
        /// Synchronizes the island bodies
        /// </summary>
        private void SynchronizeIslandBodies() => island.SynchronizeBodies();

        /// <summary>
        ///     Clear all forces
        /// </summary>
        internal void ClearForces() => Bodies.ForEach(i => i.ClearForces());
    }
}