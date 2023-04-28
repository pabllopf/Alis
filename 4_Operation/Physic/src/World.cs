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
        ///     Initializes a new instance of the <see cref="World" /> class
        /// </summary>
        /// <param name="gravity">The gravity</param>
        public World(Vector2F gravity)
        {
            Gravity = gravity;
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
        internal ContactManager ContactManager { get; set; }

        /// <summary>
        ///     Gets or sets the value of the step
        /// </summary>
        private TimeStep TimeStepGlobal { get; set; } = new TimeStep();
        
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
            UpdateInvertedDeltaTime();
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
            TimeStepGlobal.DeltaTime = dt;
            TimeStepGlobal.VelocityIterations = velocityIterations;
            TimeStepGlobal.PositionIterations = positionIterations;
            TimeStepGlobal.InvertedDeltaTime = dt > 0.0f ? 1.0f / dt : 0.0f;
            TimeStepGlobal.DeltaTimeRatio = TimeStepGlobal.InvertedDeltaTimeZero * dt;
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
        private void UpdateInvertedDeltaTime() => TimeStepGlobal.InvertedDeltaTimeZero = TimeStepGlobal.DeltaTime > 0.0f ? TimeStepGlobal.InvertedDeltaTime : TimeStepGlobal.InvertedDeltaTimeZero;

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
            island.Solve(TimeStepGlobal, Gravity, true, ContactManager, Bodies);

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
            InvalidateContactToi();
            SolveToiEvents();
        }
        
        /// <summary>
        /// Sets the alpha to zero for fast moving bodies
        /// </summary>
        private void SetAlphaToZeroForFastMovingBodies() => Bodies.ForEach(i => i.SetAlphaToZero());

        /// <summary>
        /// Invalidates the contact to is
        /// </summary>
        private void InvalidateContactToi() => ContactManager.InvalidateTOI();
        
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
                Contact minContact = ContactManager.GetTheMinContact(minAlpha);
                
                minAlpha = ContactManager.CalculateMinAlpha(); 

                if (minContact == null || IsMinAlphaGreaterThanEpsilon(minAlpha))
                {
                    // No more TOI events. Done!
                    return;
                }

                // Advance the bodies to the TOI.
                Body[] bodies = BodyHelper.AdvanceBody(ContactManager, island, minContact, minAlpha);

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
        /// Solves the toi island using the specified min alpha
        /// </summary>
        /// <param name="minAlpha">The min alpha</param>
        /// <param name="islandIndexA">The island index</param>
        /// <param name="islandIndexB">The island index</param>
        private void SolveToiIsland(float minAlpha, int islandIndexA, int islandIndexB) => island.SolveToi(minAlpha, TimeStepGlobal, islandIndexA, islandIndexB, ContactManager);

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