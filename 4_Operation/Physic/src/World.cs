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
using System.Diagnostics;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Collision.Broadphase;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Distance;
using Alis.Core.Physic.Collision.RayCast;
using Alis.Core.Physic.Collision.TOI;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Handlers;
using Alis.Core.Physic.Dynamics.Joints;
using Alis.Core.Physic.Dynamics.Solver;
using Alis.Core.Physic.Extensions.Controllers.ControllerBase;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic
{
    /// <summary>The world class manages all physics entities, dynamic simulation, and asynchronous queries.</summary>
    public class World
    {
        /// <summary>
        ///     The body
        /// </summary>
        private readonly HashSet<Body> bodyAddList;

        /// <summary>
        ///     The body
        /// </summary>
        private readonly HashSet<Body> bodyRemoveList;

        /// <summary>
        ///     The joint
        /// </summary>
        private readonly HashSet<Joint> jointAddList;

        /// <summary>
        ///     The joint
        /// </summary>
        private readonly HashSet<Joint> jointRemoveList;

        /// <summary>
        ///     The ray cast callback wrapper
        /// </summary>
        private readonly Func<RayCastInput, int, float> rayCastCallbackWrapper;

        /// <summary>
        ///     The restart
        /// </summary>
        private readonly Pool<Stopwatch> timerPool;

        /// <summary>
        ///     The gravity
        /// </summary>
        private Vector2F gravity;

        /// <summary>
        ///     The inv dt
        /// </summary>
        private float invDt0;

        /// <summary>
        ///     The profile
        /// </summary>
        private Profile profile;

        /// <summary>
        ///     The ray cast callback
        /// </summary>
        private Func<Fixture, Vector2F, Vector2F, float, float> rayCastCallback;

        /// <summary>
        ///     The body
        /// </summary>
        private Body[] stack;

        /// <summary>
        ///     The step complete
        /// </summary>
        private bool stepComplete = true;

        /// <summary>Initializes a new instance of the <see cref="World" /> class.</summary>
        public World(Vector2F gravity)
        {
            bodyAddList = new HashSet<Body>();
            bodyRemoveList = new HashSet<Body>();
            jointAddList = new HashSet<Joint>();
            jointRemoveList = new HashSet<Joint>();

            ContactPool = new Queue<Contact>(256);

            TestPointAllFixtures = new List<Fixture>();

            stack = new Body[64];

            timerPool = new Pool<Stopwatch>(Stopwatch.StartNew, sw => sw.Restart(), 5, false);

            this.gravity = gravity;
            Enabled = true;
            SleepingAllowed = true;
            WarmStartingEnabled = true;
            ContinuousPhysicsEnabled = true;

            Island = new Island();
            ControllerList = new List<Controller>();
            BreakableBodyList = new List<BreakableBody>();
            BodyList = new List<Body>(32);
            JointList = new List<Joint>(32);


            rayCastCallback = RayCastCallback;
            rayCastCallbackWrapper = RayCastCallbackWrapper;

            ContactManager = new ContactManager(new DynamicTreeBroadPhase());

            BodyAdded += OnBodyAdded;
            BodyRemoved += OnBodyRemoved;

            ControllerAdded += OnControllerAdded;
            ControllerRemoved += OnControllerRemoved;

            FixtureAdded += OnFixtureAdded;
            FixtureRemoved += OnFixtureRemoved;

            JointAdded += OnJointAdded;
            JointRemoved += OnJointRemoved;
        }

        /// <summary>
        ///     The test point all fixtures
        /// </summary>
        public List<Fixture> TestPointAllFixtures { get; private set; }

        /// <summary>
        ///     The contact
        /// </summary>
        internal Queue<Contact> ContactPool { get; }

        /// <summary>
        ///     The island
        /// </summary>
        private Island Island { get; }

        /// <summary>
        ///     The new contacts
        /// </summary>
        internal bool NewContacts { get; set; }

        /// <summary>
        ///     Gets or sets the value of the continuous physics enabled
        /// </summary>
        private bool ContinuousPhysicsEnabled { get; }

        /// <summary>
        ///     Gets or sets the value of the sleeping allowed
        /// </summary>
        private bool SleepingAllowed { get; }

        /// <summary>
        ///     Gets or sets the value of the warm starting enabled
        /// </summary>
        private bool WarmStartingEnabled { get; }

        /// <summary>
        ///     Enabling diagnostics causes the engine to gather timing information. You can see how much time it took to
        ///     solve the contacts, solve CCD and update the controllers.
        /// </summary>
        public bool EnableDiagnostics { get; set; }

        /// <summary>
        ///     Gets the value of the profile
        /// </summary>
        public ref Profile Profile => ref profile;

        /// <summary>
        ///     Gets the value of the controller list
        /// </summary>
        private List<Controller> ControllerList { get; }

        /// <summary>
        ///     Gets the value of the breakable body list
        /// </summary>
        private List<BreakableBody> BreakableBodyList { get; }

        /// <summary>Get the number of broad-phase proxies.</summary>
        /// <value>The proxy count.</value>
        public int ProxyCount => ContactManager.BroadPhase.ProxyCount;

        /// <summary>Get the contact manager for testing.</summary>
        /// <value>The contact manager.</value>
        public ContactManager ContactManager { get; set; }

        /// <summary>Get the world body list.</summary>
        /// <value>The head of the world body list.</value>
        public List<Body> BodyList { get; }

        /// <summary>Get the world joint list.</summary>
        /// <value>The joint list.</value>
        private List<Joint> JointList { get; }

        /// <summary>If false, the whole simulation stops. It still processes added and removed geometries.</summary>
        private bool Enabled { get; }

        /// <summary>
        ///     Gets or sets the value of the is locked
        /// </summary>
        public bool IsLocked { get; private set; }

        /// <summary>
        ///     Rays the cast callback using the specified arg 1
        /// </summary>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        /// <param name="arg4">The arg</param>
        /// <returns>The float</returns>
        private static float RayCastCallback(Fixture arg1, Vector2F arg2, Vector2F arg3, float arg4) => 0.0f;

        /// <summary>
        ///     Ons the body added using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        private static void OnBodyAdded(Body body) => Logger.Event("World.OnBodyAdded()");

        /// <summary>
        ///     Ons the body removed using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        private static void OnBodyRemoved(Body body) => Logger.Event("World.OnBodyRemoved()");

        /// <summary>
        ///     Ons the joint removed using the specified joint
        /// </summary>
        /// <param name="joint">The joint</param>
        private static void OnJointRemoved(Joint joint) => Logger.Event("Wolds.OnFixtureRemoved()");

        /// <summary>
        ///     Ons the joint added using the specified joint
        /// </summary>
        /// <param name="joint">The joint</param>
        private static void OnJointAdded(Joint joint) => Logger.Event("Wolds.OnFixtureRemoved()");

        /// <summary>
        ///     Ons the fixture removed using the specified fixture
        /// </summary>
        /// <param name="fixture">The fixture</param>
        private static void OnFixtureRemoved(Fixture fixture) => Logger.Event("Wolds.OnFixtureRemoved()");

        /// <summary>
        ///     Ons the fixture added using the specified fixture
        /// </summary>
        /// <param name="fixture">The fixture</param>
        private static void OnFixtureAdded(Fixture fixture) => Logger.Event("Wolds.OnFixtureAdded()");

        /// <summary>
        ///     Ons the controller removed using the specified controller
        /// </summary>
        /// <param name="controller">The controller</param>
        private static void OnControllerRemoved(Controller controller) =>
            Logger.Event("Wolds.OnControllerRemoved()");

        /// <summary>
        ///     Ons the controller added using the specified controller
        /// </summary>
        /// <param name="controller">The controller</param>
        private static void OnControllerAdded(Controller controller) => Logger.Event("Wolds.OnControllerAdded()");

        /// <summary>Fires whenever a body has been added</summary>
        public event BodyHandler BodyAdded;

        /// <summary>Fires whenever a body has been removed</summary>
        public event BodyHandler BodyRemoved;

        /// <summary>Fires every time a controller is added to the World.</summary>
        public event ControllerHandler ControllerAdded;

        /// <summary>Fires every time a controller is removed form the World.</summary>
        public event ControllerHandler ControllerRemoved;

        /// <summary>Fires whenever a fixture has been added</summary>
        public event FixtureHandler FixtureAdded;

        /// <summary>Fires whenever a fixture has been removed</summary>
        public event FixtureHandler FixtureRemoved;

        /// <summary>Fires whenever a joint has been added</summary>
        public event JointHandler JointAdded;

        /// <summary>Fires whenever a joint has been removed</summary>
        public event JointHandler JointRemoved;

        /// <summary>Add a rigid body.</summary>
        /// <param name="body">The body.</param>
        /// <param name="delayUntilNextStep">If true, the body is added at next time step</param>
        public void AddBody(Body body, bool delayUntilNextStep = false)
        {
            if (delayUntilNextStep)
            {
                if (bodyAddList.Contains(body))
                {
                    throw new ArgumentException("The body is already added to the world.");
                }

                bodyAddList.Add(body);
            }
            else
            {
                if (IsLocked)
                {
                    throw new InvalidOperationException("The World is locked.");
                }

                AddBodyInternal(body);
            }
        }

        /// <summary>Destroy a rigid body. Warning: This automatically deletes all associated shapes and joints.</summary>
        /// <param name="body">The body.</param>
        /// <param name="delayUntilNextStep">If true, the body is removed at next time step</param>
        public void RemoveBody(Body body, bool delayUntilNextStep = false)
        {
            if (delayUntilNextStep)
            {
                if (bodyRemoveList.Contains(body))
                {
                    throw new ArgumentException("The body is already removed from the world.");
                }

                bodyRemoveList.Add(body);
            }
            else
            {
                if (IsLocked)
                {
                    throw new InvalidOperationException("The World is locked.");
                }

                RemoveBodyInternal(body);
            }
        }

        /// <summary>Create a joint to constrain bodies together. This may cause the connected bodies to cease colliding.</summary>
        /// <param name="joint">The joint.</param>
        /// <param name="delayUntilNextStep">If true, the joint is added at next time step</param>
        public void AddJoint(Joint joint, bool delayUntilNextStep = false)
        {
            if (delayUntilNextStep)
            {
                if (jointAddList.Contains(joint))
                {
                    throw new ArgumentException("The joint is already added to the world.");
                }

                jointAddList.Add(joint);
            }
            else
            {
                if (IsLocked)
                {
                    throw new InvalidOperationException("The World is locked.");
                }

                AddJointInternal(joint);
            }
        }

        /// <summary>Destroy a joint. This may cause the connected bodies to begin colliding.</summary>
        /// <param name="joint">The joint.</param>
        /// <param name="delayUntilNextStep">If true, the joint is removed at next time step</param>
        private void RemoveJoint(Joint joint, bool delayUntilNextStep = false)
        {
            if (delayUntilNextStep)
            {
                if (jointRemoveList.Contains(joint))
                {
                    throw new InvalidOperationException(
                        "The joint is already marked for removal. You are removing the joint more than once.");
                }

                jointRemoveList.Add(joint);
            }
            else
            {
                if (IsLocked)
                {
                    throw new InvalidOperationException("The World is locked.");
                }

                RemoveJointInternal(joint);
            }
        }

        /// <summary>
        ///     Adds the controller using the specified controller
        /// </summary>
        /// <param name="controller">The controller</param>
        public void AddController(Controller controller)
        {
            if (ControllerList.Contains(controller))
            {
                throw new InvalidOperationException("Controller already exist in the world");
            }

            controller.World = this;
            ControllerList.Add(controller);
            ControllerAdded(controller);
        }

        /// <summary>
        ///     Removes the controller using the specified controller
        /// </summary>
        /// <param name="controller">The controller</param>
        private void RemoveController(Controller controller)
        {
            if (!ControllerList.Contains(controller))
            {
                throw new InvalidOperationException("You can`t remove a controller that is not in the world");
            }

            ControllerList.Remove(controller);
            ControllerRemoved(controller);
        }

        /// <summary>
        ///     Adds the breakable body using the specified breakable body
        /// </summary>
        /// <param name="breakableBody">The breakable body</param>
        public void AddBreakableBody(BreakableBody breakableBody) => BreakableBodyList.Add(breakableBody);

        /// <summary>
        ///     Removes the breakable body using the specified breakable body
        /// </summary>
        /// <param name="breakableBody">The breakable body</param>
        public void RemoveBreakableBody(BreakableBody breakableBody)
        {
            if (!BreakableBodyList.Contains(breakableBody))
            {
                throw new InvalidOperationException(
                    "The breakable body list does not contain the body you tried to remove.");
            }

            BreakableBodyList.Remove(breakableBody);
        }

        /// <summary>Take a time step. This performs collision detection, integration, and constraint solution.</summary>
        /// <param name="dt">The amount of time to simulate, this should not vary.</param>
        /// <param name="velocityIterations">
        ///     The number of velocity iterations to do in this step. Lesser means more performance
        ///     but more inaccurate velocity calculations.
        /// </param>
        /// <param name="positionIterations">
        ///     The number of position iterations to do in this step. Lesser means more performance,
        ///     but also more inaccurate position calculations.
        /// </param>
        public void Step(float dt, int velocityIterations = 8, int positionIterations = 3)
        {
            //Velcro: We support disabling the world
            if (!Enabled)
            {
                return;
            }

            //Velcro: We reuse the timers to avoid generating garbage
            Stopwatch stepTimer = timerPool.GetFromPool(true);

            {
                //Velcro: We support add/removal of objects live in the engine.
                Stopwatch timer = timerPool.GetFromPool(true);
                ProcessChanges();
                profile.AddRemoveTime = timer.ElapsedTicks;
                timerPool.ReturnToPool(timer);
            }

            // If new fixtures were added, we need to find the new contacts.
            if (NewContacts)
            {
                //Velcro: We measure how much time is spent on finding new contacts
                Stopwatch timer = timerPool.GetFromPool(true);
                ContactManager.FindNewContacts();
                NewContacts = false;
                profile.NewContactsTime = timer.ElapsedTicks;
                timerPool.ReturnToPool(timer);
            }

            IsLocked = true;

            TimeStep step = new TimeStep();
            step.DeltaTime = dt;
            step.VelocityIterations = velocityIterations;
            step.PositionIterations = positionIterations;
            step.WarmStarting = WarmStartingEnabled;
            if (dt > 0.0f)
            {
                step.InvertedDeltaTime = 1.0f / dt;
            }
            else
            {
                step.InvertedDeltaTime = 0.0f;
            }

            step.DeltaTimeRatio = invDt0 * dt;

            {
                //Velcro: We have the concept of controllers. We update them here
                Stopwatch timer = timerPool.GetFromPool(true);
                for (int i = 0; i < ControllerList.Count; i++)
                {
                    ControllerList[i].Update(dt);
                }

                profile.ControllersUpdateTime = timer.ElapsedTicks;
                timerPool.ReturnToPool(timer);
            }

            // Update contacts. This is where some contacts are destroyed.
            {
                Stopwatch timer = timerPool.GetFromPool(true);
                ContactManager.Collide();
                profile.Collide = timer.ElapsedTicks;
                timerPool.ReturnToPool(timer);
            }

            // Integrate velocities, solve velocity constraints, and integrate positions.
            if (stepComplete && (step.DeltaTime > 0.0f))
            {
                Stopwatch timer = timerPool.GetFromPool(true);
                Solve(ref step);
                profile.Solve = timer.ElapsedTicks;
                timerPool.ReturnToPool(timer);
            }

            // Handle TOI events.
            if (ContinuousPhysicsEnabled && (step.DeltaTime > 0.0f))
            {
                Stopwatch timer = timerPool.GetFromPool(true);
                SolveToi(ref step);
                profile.SolveToi = timer.ElapsedTicks;
                timerPool.ReturnToPool(timer);
            }

            if (step.DeltaTime > 0.0f)
            {
                invDt0 = step.InvertedDeltaTime;
            }

            if (Settings.AutoClearForces)
            {
                ClearForces();
            }

            {
                //Velcro: We support breakable bodies. We update them here.
                Stopwatch timer = timerPool.GetFromPool(true);

                for (int i = 0; i < BreakableBodyList.Count; i++)
                {
                    BreakableBodyList[i].Update();
                }

                profile.BreakableBodies = timer.ElapsedTicks;
                timerPool.ReturnToPool(timer);
            }

            IsLocked = false;

            profile.Step = stepTimer.ElapsedTicks;
            timerPool.ReturnToPool(stepTimer);
        }

        /// <summary>
        ///     Call this after you are done with time steps to clear the forces. You normally call this after each call to
        ///     Step, unless you are performing sub-steps. By default, forces will be automatically cleared, so you don't need to
        ///     call
        ///     this function.
        /// </summary>
        public void ClearForces()
        {
            for (int i = 0; i < BodyList.Count; i++)
            {
                BodyList[i].Force = Vector2F.Zero;
                BodyList[i].Torque = 0.0f;
            }
        }


        /// <summary>
        ///     Query the world for all fixtures that potentially overlap the provided AABB. Use the overload with a callback
        ///     for filtering and better performance.
        /// </summary>
        /// <param name="aabb">The AABB query box.</param>
        /// <returns>A list of fixtures that were in the affected area.</returns>
        public List<Fixture> QueryAabb(ref Aabb aabb) => TestPointAllFixtures;

        /// <summary>
        ///     Ray-cast the world for all fixtures in the path of the ray. Your callback controls whether you get the closest
        ///     point, any point, or n-points. The ray-cast ignores shapes that contain the starting point. Inside the callback:
        ///     return
        ///     -1: ignore this fixture and continue return 0: terminate the ray cast return fraction: clip the ray to this point
        ///     return 1: don't clip the ray and continue
        /// </summary>
        /// <param name="callback">A user implemented callback class.</param>
        /// <param name="point1">The ray starting point.</param>
        /// <param name="point2">The ray ending point.</param>
        public void RayCast(Func<Fixture, Vector2F, Vector2F, float, float> callback, Vector2F point1, Vector2F point2)
        {
            RayCastInput input = new RayCastInput
            {
                Fraction = 1.0f,
                Point1 = point1,
                Point2 = point2
            };

            rayCastCallback = callback;
            ContactManager.BroadPhase.RayCast(rayCastCallbackWrapper, ref input);
            rayCastCallback = null;
        }

        /// <summary>
        ///     Rays the cast using the specified point 1
        /// </summary>
        /// <param name="point1">The point</param>
        /// <param name="point2">The point</param>
        /// <returns>The affected</returns>
        public List<Fixture> RayCast(Vector2F point1, Vector2F point2)
        {
            List<Fixture> affected = new List<Fixture>();

            float RayCastCallback(Fixture f, Vector2F vector2, Vector2F vector3, float f1)
            {
                affected.Add(f);
                return 1;
            }

            RayCast(RayCastCallback, point1, point2);

            return affected;
        }

        /// <summary>Returns a list of fixtures that are at the specified point.</summary>
        /// <param name="point">The point.</param>
        public List<Fixture> TestPointAll(Vector2F point)
        {
            Aabb aabb;
            Vector2F d = new Vector2F(Constant.Epsilon, Constant.Epsilon);
            aabb.LowerBound = point - d;
            aabb.UpperBound = point + d;

            TestPointAllFixtures = new List<Fixture>();

            ContactManager.BroadPhase.Query(proxyId =>
            {
                Fixture fixture = ContactManager.BroadPhase.GetProxy(proxyId).Fixture;

                if (fixture.TestPoint(ref point))
                {
                    TestPointAllFixtures.Add(fixture);
                }

                return true;
            }, ref aabb);

            return TestPointAllFixtures;
        }

        /// <summary>
        ///     Shift the world origin.
        ///     Useful for large worlds.
        ///     The body shift formula is: position -= newOrigin
        /// </summary>
        /// <param name="newOrigin">
        ///     the newOrigin the new origin with respect to the old origin
        ///     Warning: Calling this method mid-update might cause a crash.
        /// </param>
        public void ShiftOrigin(Vector2F newOrigin)
        {
            Debug.Assert(!IsLocked);
            if (IsLocked)
            {
                return;
            }

            foreach (Body b in BodyList)
            {
                b.Xf.Position -= newOrigin;
                b.Sweep.C0 -= newOrigin;
                b.Sweep.C -= newOrigin;
            }

            foreach (Joint joint in JointList)
            {
                joint.ShiftOrigin(ref newOrigin);
            }

            ContactManager.BroadPhase.ShiftOrigin(ref newOrigin);
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            ProcessChanges();

            for (int i = BodyList.Count - 1; i >= 0; i--)
            {
                RemoveBody(BodyList[i]);
            }

            for (int i = ControllerList.Count - 1; i >= 0; i--)
            {
                RemoveController(ControllerList[i]);
            }

            for (int i = BreakableBodyList.Count - 1; i >= 0; i--)
            {
                RemoveBreakableBody(BreakableBodyList[i]);
            }

            //We call ProcessChanges again since the user could have added items to the body/joint queues in the Removed/Added events
            ProcessChanges();
        }

        /// <summary>
        ///     Raises the new fixture event using the specified fixture
        /// </summary>
        /// <param name="fixture">The fixture</param>
        internal void RaiseNewFixtureEvent(Fixture fixture) => FixtureAdded(fixture);

        /// <summary>
        ///     Processes the removed joints
        /// </summary>
        private void ProcessRemovedJoints()
        {
            if (jointRemoveList.Count == 0)
            {
                return;
            }

            foreach (Joint joint in jointRemoveList)
            {
                RemoveJointInternal(joint);
            }

            jointRemoveList.Clear();
        }

        /// <summary>
        ///     Processes the added joints
        /// </summary>
        private void ProcessAddedJoints()
        {
            if (jointAddList.Count == 0)
            {
                return;
            }

            foreach (Joint joint in jointAddList)
            {
                AddJointInternal(joint);
            }

            jointAddList.Clear();
        }

        /// <summary>
        ///     Processes the added bodies
        /// </summary>
        private void ProcessAddedBodies()
        {
            if (bodyAddList.Count > 0)
            {
                foreach (Body body in bodyAddList)
                {
                    AddBodyInternal(body);
                }

                bodyAddList.Clear();
            }
        }

        /// <summary>
        ///     Processes the removed bodies
        /// </summary>
        private void ProcessRemovedBodies()
        {
            if (bodyRemoveList.Count > 0)
            {
                foreach (Body body in bodyRemoveList)
                {
                    RemoveBodyInternal(body);
                }

                bodyRemoveList.Clear();
            }
        }


        /// <summary>
        ///     Rays the cast callback wrapper using the specified ray cast input
        /// </summary>
        /// <param name="rayCastInput">The ray cast input</param>
        /// <param name="proxyId">The proxy id</param>
        /// <returns>The float</returns>
        private float RayCastCallbackWrapper(RayCastInput rayCastInput, int proxyId)
        {
            FixtureProxy proxy = ContactManager.BroadPhase.GetProxy(proxyId);
            Fixture fixture = proxy.Fixture;
            int index = proxy.ChildIndex;
            bool hit = fixture.RayCast(out RayCastOutput output, ref rayCastInput, index);

            if (hit)
            {
                float fraction = output.Fraction;
                Vector2F point = (1.0f - fraction) * rayCastInput.Point1 + fraction * rayCastInput.Point2;
                return rayCastCallback(fixture, point, output.Normal, fraction);
            }

            return rayCastInput.Fraction;
        }

        /// <summary>
        ///     Solves the step
        /// </summary>
        /// <param name="step">The step</param>
        private void Solve(ref TimeStep step)
        {
            profile.SolveInit = 0;
            profile.SolveVelocity = 0;
            profile.SolvePosition = 0;

            // Size the island for the worst case.
            Island.Reset(BodyList.Count,
                ContactManager.ContactCounter,
                JointList.Count,
                ContactManager);

            // Clear all the island flags.
            foreach (Body b in BodyList)
            {
                b.Flags &= ~BodyFlags.IslandFlag;
            }

            for (Contact c = ContactManager.ContactList; c != null; c = c.Next)
            {
                c.Flags &= ~ContactFlags.IslandFlag;
            }

            foreach (Joint j in JointList)
            {
                j.IslandFlag = false;
            }

            // Build and simulate all awake islands.
            int stackSize = BodyList.Count;
            if (stackSize > stack.Length)
            {
                stack = new Body[Math.Max(stack.Length * 2, stackSize)];
            }

            for (int index = BodyList.Count - 1; index >= 0; index--)
            {
                Body seed = BodyList[index];
                if ((seed.Flags & BodyFlags.IslandFlag) == BodyFlags.IslandFlag)
                {
                    continue;
                }

                if (!seed.Awake || !seed.Enabled)
                {
                    continue;
                }

                // The seed can be dynamic or kinematic.
                if (seed.BodyType == BodyType.Static)
                {
                    continue;
                }

                // Reset island and stack.
                Island.Clear();
                int stackCount = 0;
                stack[stackCount++] = seed;

                seed.Flags |= BodyFlags.IslandFlag;

                // Perform a depth first search (DFS) on the constraint graph.
                while (stackCount > 0)
                {
                    // Grab the next body off the stack and add it to the island.
                    Body b = stack[--stackCount];
                    Debug.Assert(b.Enabled);
                    Island.Add(b);

                    // To keep islands as small as possible, we don't
                    // propagate islands across static bodies.
                    if (b.BodyType == BodyType.Static)
                    {
                        continue;
                    }

                    // Make sure the body is awake (without resetting sleep timer).
                    b.Flags |= BodyFlags.AwakeFlag;

                    // Search all contacts connected to this body.
                    for (ContactEdge ce = b.ContactList; ce != null; ce = ce.Next)
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

                        Island.Add(contact);
                        contact.Flags |= ContactFlags.IslandFlag;

                        Body other = ce.Other;

                        // Was the other body already added to this island?
                        if (other.IsIsland)
                        {
                            continue;
                        }

                        Debug.Assert(stackCount < stackSize);
                        stack[stackCount++] = other;
                        other.Flags |= BodyFlags.IslandFlag;
                    }

                    // Search all joints connect to this body.
                    for (JointEdge je = b.JointList; je != null; je = je.Next)
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

                            Island.Add(je.Joint);
                            je.Joint.IslandFlag = true;

                            if (other.IsIsland)
                            {
                                continue;
                            }

                            Debug.Assert(stackCount < stackSize);
                            stack[stackCount++] = other;

                            other.Flags |= BodyFlags.IslandFlag;
                        }
                        else
                        {
                            Island.Add(je.Joint);
                            je.Joint.IslandFlag = true;
                        }
                    }
                }

                Profile profile = new Profile();
                Island.Solve(ref profile, ref step, ref gravity, SleepingAllowed);
                this.profile.SolveInit += profile.SolveInit;
                this.profile.SolveVelocity += profile.SolveVelocity;
                this.profile.SolvePosition += profile.SolvePosition;

                // Post solve cleanup.
                for (int i = 0; i < Island.BodyCount; ++i)
                {
                    // Allow static bodies to participate in other islands.
                    Body b = Island.Bodies[i];
                    if (b.BodyType == BodyType.Static)
                    {
                        b.Flags &= ~BodyFlags.IslandFlag;
                    }
                }
            }

            {
                Stopwatch timer = timerPool.GetFromPool(true);

                // Synchronize fixtures, check for out of range bodies.
                foreach (Body b in BodyList)
                {
                    // If a body was not in an island then it did not move.
                    if ((b.Flags & BodyFlags.IslandFlag) == 0)
                    {
                        continue;
                    }

                    if (b.BodyType == BodyType.Static)
                    {
                        continue;
                    }

                    // Update fixtures (for broad-phase).
                    b.SynchronizeFixtures();
                }

                // Look for new contacts.
                ContactManager.FindNewContacts();
                profile.Broadphase = timer.ElapsedTicks;
                timerPool.ReturnToPool(timer);
            }
        }

        /// <summary>
        ///     Solves the toi using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        private void SolveToi(ref TimeStep step)
        {
            Island.Reset(2 * Settings.ToiContacts, Settings.ToiContacts, 0, ContactManager);

            if (stepComplete)
            {
                for (int i = 0; i < BodyList.Count; i++)
                {
                    BodyList[i].Flags &= ~BodyFlags.IslandFlag;
                    BodyList[i].Sweep.Alpha0 = 0.0f;
                }

                for (Contact c = ContactManager.ContactList; c != null; c = c.Next)
                {
                    // Invalidate TOI
                    c.Flags &= ~(ContactFlags.ToiFlag | ContactFlags.IslandFlag);
                    c.ToiCount = 0;
                    c.Toi = 1.0f;
                }
            }

            // Find TOI events and solve them.
            for (;;)
            {
                // Find the first TOI.
                Contact minContact = null;
                float minAlpha = 1.0f;

                for (Contact c = ContactManager.ContactList; c != null; c = c.Next)
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
                        Debug.Assert(typeA == BodyType.Dynamic || typeB == BodyType.Dynamic);

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

                        Debug.Assert(alpha0 < 1.0f);

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
                    stepComplete = true;
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
                Island.Clear();
                Island.Add(bA0);
                Island.Add(bB0);
                Island.Add(minContact);

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

                            if (Island.BodyCount == Island.BodyCapacity)
                            {
                                break;
                            }

                            if (Island.ContactCount == Island.ContactCapacity)
                            {
                                break;
                            }

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
                            Island.Add(contact);

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

                            Island.Add(other);
                        }
                    }
                }

                TimeStep subStep = new TimeStep();
                subStep.DeltaTime = (1.0f - minAlpha) * step.DeltaTime;
                subStep.InvertedDeltaTime = 1.0f / subStep.DeltaTime;
                subStep.DeltaTimeRatio = 1.0f;
                subStep.PositionIterations = 20;
                subStep.VelocityIterations = step.VelocityIterations;
                subStep.WarmStarting = false;
                Island.SolveToi(ref subStep, bA0.IslandIndex, bB0.IslandIndex);

                // Reset island flags and synchronize broad-phase proxies.
                for (int i = 0; i < Island.BodyCount; ++i)
                {
                    Body body = Island.Bodies[i];
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
        ///     Describes whether this instance test point callback
        /// </summary>
        /// <param name="fixture">The fixture</param>
        /// <param name="point">The point</param>
        /// <returns>The bool</returns>
        private bool TestPointCallback(Fixture fixture, ref Vector2F point) => !fixture.TestPoint(ref point);

        /// <summary>
        ///     Adds the joint internal using the specified joint
        /// </summary>
        /// <param name="joint">The joint</param>
        private void AddJointInternal(Joint joint)
        {
            // Connect to the world list.
            JointList.Add(joint);

            // Connect to the bodies' doubly linked lists.
            joint.EdgeA.Joint = joint;
            joint.EdgeA.Other = joint.BodyB;
            joint.EdgeA.Prev = null;
            joint.EdgeA.Next = joint.BodyA.JointList;

            if (joint.BodyA.JointList != null)
            {
                joint.BodyA.JointList.Prev = joint.EdgeA;
            }

            joint.BodyA.JointList = joint.EdgeA;

            // WIP David
            if (!joint.IsFixedType())
            {
                joint.EdgeB.Joint = joint;
                joint.EdgeB.Other = joint.BodyA;
                joint.EdgeB.Prev = null;
                joint.EdgeB.Next = joint.BodyB.JointList;

                if (joint.BodyB.JointList != null)
                {
                    joint.BodyB.JointList.Prev = joint.EdgeB;
                }

                joint.BodyB.JointList = joint.EdgeB;

                Body bodyA = joint.BodyA;
                Body bodyB = joint.BodyB;

                // If the joint prevents collisions, then flag any contacts for filtering.
                if (!joint.CollideConnected)
                {
                    ContactEdge edge = bodyB.ContactList;
                    while (edge != null)
                    {
                        if (edge.Other == bodyA)
                        {
                            // Flag the contact for filtering at the next time step (where either
                            // body is awake).
                            edge.Contact.Flags |= ContactFlags.FilterFlag;
                        }

                        edge = edge.Next;
                    }
                }
            }

            JointAdded(joint);

            // Note: creating a joint doesn't wake the bodies.
        }

        /// <summary>
        ///     Removes the joint internal using the specified joint
        /// </summary>
        /// <param name="joint">The joint</param>
        private void RemoveJointInternal(Joint joint)
        {
            bool collideConnected = joint.CollideConnected;

            // Remove from the world list.
            JointList.Remove(joint);

            // Disconnect from island graph.
            Body bodyA = joint.BodyA;
            Body bodyB = joint.BodyB;

            // Wake up connected bodies.
            bodyA.Awake = true;

            // WIP David
            if (!joint.IsFixedType())
            {
                bodyB.Awake = true;
            }

            // Remove from body 1.
            if (joint.EdgeA.Prev != null)
            {
                joint.EdgeA.Prev.Next = joint.EdgeA.Next;
            }

            if (joint.EdgeA.Next != null)
            {
                joint.EdgeA.Next.Prev = joint.EdgeA.Prev;
            }

            if (joint.EdgeA == bodyA.JointList)
            {
                bodyA.JointList = joint.EdgeA.Next;
            }

            joint.EdgeA.Prev = null;
            joint.EdgeA.Next = null;

            // WIP David
            if (!joint.IsFixedType())
            {
                // Remove from body 2
                if (joint.EdgeB.Prev != null)
                {
                    joint.EdgeB.Prev.Next = joint.EdgeB.Next;
                }

                if (joint.EdgeB.Next != null)
                {
                    joint.EdgeB.Next.Prev = joint.EdgeB.Prev;
                }

                if (joint.EdgeB == bodyB.JointList)
                {
                    bodyB.JointList = joint.EdgeB.Next;
                }

                joint.EdgeB.Prev = null;
                joint.EdgeB.Next = null;

                // If the joint prevents collisions, then flag any contacts for filtering.
                if (!collideConnected)
                {
                    ContactEdge edge = bodyB.ContactList;
                    while (edge != null)
                    {
                        if (edge.Other == bodyA)
                        {
                            // Flag the contact for filtering at the next time step (where either
                            // body is awake).
                            edge.Contact.Flags |= ContactFlags.FilterFlag;
                        }

                        edge = edge.Next;
                    }
                }
            }

            JointRemoved(joint);
        }

        /// <summary>
        ///     Adds the body internal using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        private void AddBodyInternal(Body body)
        {
            body.World = this;

            // Add to world list.
            BodyList.Add(body);

            //Velcro: We have events to notify the user that a body was added
            BodyAdded(body);

            //Velcro: We have events to notify fixtures was added
            for (int i = 0; i < body.FixtureList.Count; i++)
            {
                FixtureAdded(body.FixtureList[i]);
            }
        }

        /// <summary>
        ///     Removes the body internal using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        private void RemoveBodyInternal(Body body)
        {
            // You tried to remove a body when the world is empty.
            if (BodyList.Count == 0)
            {
                throw new InvalidOperationException("The World is empty and you can´t remove a body.");
            }

            // You tried to remove a body that is not contained in the World.
            if (!BodyList.Contains(body))
            {
                throw new InvalidOperationException("The World don´t contains the body you are trying to remove.");
            }

            // Delete the attached joints.
            if (body.JointList != null)
            {
                JointEdge jointEdge = body.JointList;
                while (jointEdge != null)
                {
                    JointEdge nextJointEdge = jointEdge;
                    jointEdge = jointEdge.Next;

                    if (nextJointEdge.Joint != null)
                    {
                        RemoveJoint(nextJointEdge.Joint);
                    }
                }
            }

            // Set joint list to null.
            body.JointList = null;

            // Delete the attached contacts.
            if (body.ContactList != null)
            {
                ContactEdge contactEdge = body.ContactList;
                while (contactEdge != null)
                {
                    ContactEdge nextContactEdge = contactEdge;
                    contactEdge = contactEdge.Next;

                    if (nextContactEdge.Contact != null)
                    {
                        ContactManager.Remove(nextContactEdge.Contact);
                    }
                }
            }

            // Set contact list to null.
            body.ContactList = null;

            // Delete the attached fixtures. This destroys broad-phase proxies.
            if (body.FixtureList != null)
            {
                for (int i = 0; i < body.FixtureList.Count; i++)
                {
                    // Add event to notify fixture was removed
                    FixtureRemoved(body.FixtureList[i]);

                    // Remove fixture. This destroys proxy.
                    body.FixtureList[i].DestroyProxies(ContactManager.BroadPhase);
                    body.FixtureList[i].Destroy();
                }
            }

            // Set fixture list to null.
            body.FixtureList = null;

            // Make sure to cleanup the references and delegates
            body.World = null;
            body.OnCollision = null;
            body.OnSeparation = null;

            // Remove the body of the list.
            BodyList.Remove(body);

            // Call the world body removed event.
            BodyRemoved(body);
        }

        /// <summary>
        ///     Processes the changes
        /// </summary>
        private void ProcessChanges()
        {
            ProcessAddedBodies();
            ProcessAddedJoints();

            ProcessRemovedBodies();
            ProcessRemovedJoints();
        }
    }
}