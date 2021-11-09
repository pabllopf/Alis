// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   World.cs
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

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Alis.Core.Systems.Physics2D.Collision.Broadphase;
using Alis.Core.Systems.Physics2D.Collision.ContactSystem;
using Alis.Core.Systems.Physics2D.Collision.Distance;
using Alis.Core.Systems.Physics2D.Collision.RayCast;
using Alis.Core.Systems.Physics2D.Collision.TOI;
using Alis.Core.Systems.Physics2D.Dynamics.Handlers;
using Alis.Core.Systems.Physics2D.Dynamics.Joints;
using Alis.Core.Systems.Physics2D.Dynamics.Joints.Misc;
using Alis.Core.Systems.Physics2D.Dynamics.Solver;
using Alis.Core.Systems.Physics2D.Extensions.Controllers.ControllerBase;
using Alis.Core.Systems.Physics2D.Shared;
using Alis.Core.Systems.Physics2D.Utilities;

namespace Alis.Core.Systems.Physics2D.Dynamics
{
    /// <summary>The world class manages all physics entities, dynamic simulation, and asynchronous queries.</summary>
    public class World
    {
        /// <summary>
        ///     The body
        /// </summary>
        private readonly HashSet<Body> _bodyAddList = new HashSet<Body>();

        /// <summary>
        ///     The body list
        /// </summary>
        private readonly List<Body> _bodyList;

        /// <summary>
        ///     The body
        /// </summary>
        private readonly HashSet<Body> _bodyRemoveList = new HashSet<Body>();

        /// <summary>
        ///     The breakable body list
        /// </summary>
        private readonly List<BreakableBody> _breakableBodyList;

        /// <summary>
        ///     The controller list
        /// </summary>
        private readonly List<Controller> _controllerList;

        /// <summary>
        ///     The joint
        /// </summary>
        private readonly HashSet<Joint> _jointAddList = new HashSet<Joint>();

        /// <summary>
        ///     The joint list
        /// </summary>
        private readonly List<Joint> _jointList;

        /// <summary>
        ///     The joint
        /// </summary>
        private readonly HashSet<Joint> _jointRemoveList = new HashSet<Joint>();

        /// <summary>
        ///     The query aabb callback wrapper
        /// </summary>
        private readonly Func<int, bool> _queryAABBCallbackWrapper;

        /// <summary>
        ///     The ray cast callback wrapper
        /// </summary>
        private readonly Func<RayCastInput, int, float> _rayCastCallbackWrapper;

        /// <summary>
        ///     The restart
        /// </summary>
        private readonly Pool<Stopwatch> _timerPool =
            new Pool<Stopwatch>(Stopwatch.StartNew, sw => sw.Restart(), 5, false);

        /// <summary>
        ///     The contact manager
        /// </summary>
        private ContactManager _contactManager;

        /// <summary>
        ///     The contact
        /// </summary>
        internal Queue<Contact> ContactPool { get; } = new Queue<Contact>(256);

        /// <summary>
        ///     The continuous physics enabled
        /// </summary>
        private bool _continuousPhysicsEnabled;

        /// <summary>
        ///     The enabled
        /// </summary>
        private bool _enabled;

        /// <summary>
        ///     The enable diagnostics
        /// </summary>
        private bool _enableDiagnostics;

        /// <summary>
        ///     The gravity
        /// </summary>
        private Vector2 _gravity;

        /// <summary>
        ///     The inv dt
        /// </summary>
        private float _invDt0;

        /// <summary>
        ///     The island
        /// </summary>
        internal Island Island1 { get; }

        /// <summary>
        ///     The is locked
        /// </summary>
        private bool _isLocked;

        /// <summary>
        ///     The my fixture
        /// </summary>
        private Fixture _myFixture;

        /// <summary>
        ///     The new contacts
        /// </summary>
        internal bool NewContacts { get; set; }

        /// <summary>
        ///     The point
        /// </summary>
        private Vector2 _point1;

        /// <summary>
        ///     The point
        /// </summary>
        private Vector2 _point2;

        /// <summary>
        ///     The profile
        /// </summary>
        private Profile _profile;

        /// <summary>
        ///     The query aabb callback
        /// </summary>
        private Func<Fixture, bool> _queryAABBCallback;

        /// <summary>
        ///     The ray cast callback
        /// </summary>
        private Func<Fixture, Vector2, Vector2, float, float> _rayCastCallback;

        /// <summary>
        ///     The sleeping allowed
        /// </summary>
        private bool _sleepingAllowed;

        /// <summary>
        ///     The body
        /// </summary>
        private Body[] _stack = new Body[64];

        /// <summary>
        ///     The step complete
        /// </summary>
        private bool _stepComplete = true;

        /// <summary>
        ///     The test point all fixtures
        /// </summary>
        private List<Fixture> _testPointAllFixtures;

        /// <summary>
        ///     The warm starting enabled
        /// </summary>
        private bool _warmStartingEnabled;

        /// <summary>Initializes a new instance of the <see cref="World" /> class.</summary>
        public World(Vector2 gravity)
        {
            _gravity = gravity;
            _enabled = true;
            _sleepingAllowed = true;
            _warmStartingEnabled = true;
            _continuousPhysicsEnabled = true;

            Island1 = new Island();
            _controllerList = new List<Controller>();
            _breakableBodyList = new List<BreakableBody>();
            _bodyList = new List<Body>(32);
            _jointList = new List<Joint>(32);

            _queryAABBCallbackWrapper = QueryAABBCallbackWrapper;
            _rayCastCallbackWrapper = RayCastCallbackWrapper;

            ContactManager = new ContactManager(new DynamicTreeBroadPhase());
        }

        /// <summary>
        ///     Gets or sets the value of the continuous physics enabled
        /// </summary>
        public bool ContinuousPhysicsEnabled
        {
            get => _continuousPhysicsEnabled;
            set => _continuousPhysicsEnabled = value;
        }

        /// <summary>
        ///     Gets or sets the value of the sleeping allowed
        /// </summary>
        public bool SleepingAllowed
        {
            get => _sleepingAllowed;
            set => _sleepingAllowed = value;
        }

        /// <summary>
        ///     Gets or sets the value of the warm starting enabled
        /// </summary>
        public bool WarmStartingEnabled
        {
            get => _warmStartingEnabled;
            set => _warmStartingEnabled = value;
        }

        /// <summary>
        ///     Enabling diagnostics causes the engine to gather timing information. You can see how much time it took to
        ///     solve the contacts, solve CCD and update the controllers.
        /// </summary>
        public bool EnableDiagnostics
        {
            get => _enableDiagnostics;
            set => _enableDiagnostics = value;
        }

        /// <summary>Change the global gravity vector.</summary>
        public Vector2 Gravity
        {
            get => _gravity;
            set => _gravity = value;
        }

        /// <summary>
        ///     Gets the value of the profile
        /// </summary>
        public ref Profile Profile => ref _profile;

        /// <summary>
        ///     Gets the value of the controller list
        /// </summary>
        public List<Controller> ControllerList => _controllerList;

        /// <summary>
        ///     Gets the value of the breakable body list
        /// </summary>
        public List<BreakableBody> BreakableBodyList => _breakableBodyList;

        /// <summary>Get the number of broad-phase proxies.</summary>
        /// <value>The proxy count.</value>
        public int ProxyCount => ContactManager.BroadPhase.ProxyCount;

        /// <summary>Get the contact manager for testing.</summary>
        /// <value>The contact manager.</value>
        public ContactManager ContactManager
        {
            get => _contactManager;
            set { _contactManager = value; }
        }

        /// <summary>Get the world body list.</summary>
        /// <value>The head of the world body list.</value>
        public List<Body> BodyList => _bodyList;

        /// <summary>Get the world joint list.</summary>
        /// <value>The joint list.</value>
        public List<Joint> JointList => _jointList;

        /// <summary>If false, the whole simulation stops. It still processes added and removed geometries.</summary>
        public bool Enabled
        {
            get => _enabled;
            set => _enabled = value;
        }

        /// <summary>
        ///     Gets or sets the value of the is locked
        /// </summary>
        public bool IsLocked
        {
            get => _isLocked;
            set => _isLocked = value;
        }

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
                Debug.Assert(!_bodyAddList.Contains(body), "You are adding the same body more than once.");

                if (!_bodyAddList.Contains(body))
                {
                    _bodyAddList.Add(body);
                }
            }
            else
            {
                Debug.Assert(!IsLocked);

                if (IsLocked)
                {
                    return;
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
                Debug.Assert(!_bodyRemoveList.Contains(body),
                    "The body is already marked for removal. You are removing the body more than once.");

                if (!_bodyRemoveList.Contains(body))
                {
                    _bodyRemoveList.Add(body);
                }
            }
            else
            {
                Debug.Assert(!IsLocked);

                if (IsLocked)
                {
                    return;
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
                Debug.Assert(!_jointAddList.Contains(joint), "You are adding the same joint more than once.");

                if (!_jointAddList.Contains(joint))
                {
                    _jointAddList.Add(joint);
                }
            }
            else
            {
                Debug.Assert(!IsLocked);

                if (IsLocked)
                {
                    return;
                }

                AddJointInternal(joint);
            }
        }

        /// <summary>Destroy a joint. This may cause the connected bodies to begin colliding.</summary>
        /// <param name="joint">The joint.</param>
        /// <param name="delayUntilNextStep">If true, the joint is removed at next time step</param>
        public void RemoveJoint(Joint joint, bool delayUntilNextStep = false)
        {
            if (delayUntilNextStep)
            {
                Debug.Assert(!_jointRemoveList.Contains(joint),
                    "The joint is already marked for removal. You are removing the joint more than once.");

                if (!_jointRemoveList.Contains(joint))
                {
                    _jointRemoveList.Add(joint);
                }
            }
            else
            {
                Debug.Assert(!IsLocked);

                if (IsLocked)
                {
                    return;
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
            Debug.Assert(!_controllerList.Contains(controller), "You are adding the same controller more than once.");

            controller.World = this;
            _controllerList.Add(controller);

            ControllerAdded?.Invoke(controller);
        }

        /// <summary>
        ///     Removes the controller using the specified controller
        /// </summary>
        /// <param name="controller">The controller</param>
        public void RemoveController(Controller controller)
        {
            Debug.Assert(_controllerList.Contains(controller),
                "You are removing a controller that is not in the simulation.");

            if (_controllerList.Contains(controller))
            {
                _controllerList.Remove(controller);

                ControllerRemoved?.Invoke(controller);
            }
        }

        /// <summary>
        ///     Adds the breakable body using the specified breakable body
        /// </summary>
        /// <param name="breakableBody">The breakable body</param>
        public void AddBreakableBody(BreakableBody breakableBody)
        {
            _breakableBodyList.Add(breakableBody);
        }

        /// <summary>
        ///     Removes the breakable body using the specified breakable body
        /// </summary>
        /// <param name="breakableBody">The breakable body</param>
        public void RemoveBreakableBody(BreakableBody breakableBody)
        {
            //The breakable body list does not contain the body you tried to remove.
            Debug.Assert(_breakableBodyList.Contains(breakableBody));

            _breakableBodyList.Remove(breakableBody);
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
            if (!_enabled)
            {
                return;
            }

            //Velcro: We reuse the timers to avoid generating garbage
            Stopwatch stepTimer = _timerPool.GetFromPool(true);

            {
                //Velcro: We support add/removal of objects live in the engine.
                Stopwatch timer = _timerPool.GetFromPool(true);
                ProcessChanges();
                _profile.AddRemoveTime = timer.ElapsedTicks;
                _timerPool.ReturnToPool(timer);
            }

            // If new fixtures were added, we need to find the new contacts.
            if (NewContacts)
            {
                //Velcro: We measure how much time is spent on finding new contacts
                Stopwatch timer = _timerPool.GetFromPool(true);
                ContactManager.FindNewContacts();
                NewContacts = false;
                _profile.NewContactsTime = timer.ElapsedTicks;
                _timerPool.ReturnToPool(timer);
            }

            IsLocked = true;

            TimeStep step;
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

            step.DeltaTimeRatio = _invDt0 * dt;

            {
                //Velcro: We have the concept of controllers. We update them here
                Stopwatch timer = _timerPool.GetFromPool(true);
                for (int i = 0; i < _controllerList.Count; i++)
                {
                    _controllerList[i].Update(dt);
                }

                _profile.ControllersUpdateTime = timer.ElapsedTicks;
                _timerPool.ReturnToPool(timer);
            }

            // Update contacts. This is where some contacts are destroyed.
            {
                Stopwatch timer = _timerPool.GetFromPool(true);
                ContactManager.Collide();
                _profile.Collide = timer.ElapsedTicks;
                _timerPool.ReturnToPool(timer);
            }

            // Integrate velocities, solve velocity constraints, and integrate positions.
            if (_stepComplete && step.DeltaTime > 0.0f)
            {
                Stopwatch timer = _timerPool.GetFromPool(true);
                Solve(ref step);
                _profile.Solve = timer.ElapsedTicks;
                _timerPool.ReturnToPool(timer);
            }

            // Handle TOI events.
            if (_continuousPhysicsEnabled && step.DeltaTime > 0.0f)
            {
                Stopwatch timer = _timerPool.GetFromPool(true);
                SolveTOI(ref step);
                _profile.SolveTOI = timer.ElapsedTicks;
                _timerPool.ReturnToPool(timer);
            }

            if (step.DeltaTime > 0.0f)
            {
                _invDt0 = step.InvertedDeltaTime;
            }

            if (Settings.AutoClearForces)
            {
                ClearForces();
            }

            {
                //Velcro: We support breakable bodies. We update them here.
                Stopwatch timer = _timerPool.GetFromPool(true);

                for (int i = 0; i < _breakableBodyList.Count; i++)
                {
                    _breakableBodyList[i].Update();
                }

                _profile.BreakableBodies = timer.ElapsedTicks;
                _timerPool.ReturnToPool(timer);
            }

            IsLocked = false;

            _profile.Step = stepTimer.ElapsedTicks;
            _timerPool.ReturnToPool(stepTimer);
        }

        /// <summary>
        ///     Call this after you are done with time steps to clear the forces. You normally call this after each call to
        ///     Step, unless you are performing sub-steps. By default, forces will be automatically cleared, so you don't need to
        ///     call
        ///     this function.
        /// </summary>
        public void ClearForces()
        {
            for (int i = 0; i < _bodyList.Count; i++)
            {
                Body body = _bodyList[i];
                body.Force = Vector2.Zero;
                body.Torque = 0.0f;
            }
        }

        /// <summary>
        ///     Query the world for all fixtures that potentially overlap the provided AABB. Inside the callback: Return true:
        ///     Continues the query Return false: Terminate the query
        /// </summary>
        /// <param name="callback">A user implemented callback class.</param>
        /// <param name="aabb">The AABB query box.</param>
        public void QueryAABB(Func<Fixture, bool> callback, ref AABB aabb)
        {
            _queryAABBCallback = callback;
            ContactManager.BroadPhase.Query(_queryAABBCallbackWrapper, ref aabb);
            _queryAABBCallback = null;
        }

        /// <summary>
        ///     Query the world for all fixtures that potentially overlap the provided AABB. Use the overload with a callback
        ///     for filtering and better performance.
        /// </summary>
        /// <param name="aabb">The AABB query box.</param>
        /// <returns>A list of fixtures that were in the affected area.</returns>
        public List<Fixture> QueryAABB(ref AABB aabb)
        {
            List<Fixture> affected = new List<Fixture>();

            QueryAABB(fixture =>
            {
                affected.Add(fixture);
                return true;
            }, ref aabb);

            return affected;
        }

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
        public void RayCast(Func<Fixture, Vector2, Vector2, float, float> callback, Vector2 point1, Vector2 point2)
        {
            RayCastInput input = new RayCastInput();
            input.MaxFraction = 1.0f;
            input.Point1 = point1;
            input.Point2 = point2;

            _rayCastCallback = callback;
            ContactManager.BroadPhase.RayCast(_rayCastCallbackWrapper, ref input);
            _rayCastCallback = null;
        }

        /// <summary>
        ///     Rays the cast using the specified point 1
        /// </summary>
        /// <param name="point1">The point</param>
        /// <param name="point2">The point</param>
        /// <returns>The affected</returns>
        public List<Fixture> RayCast(Vector2 point1, Vector2 point2)
        {
            List<Fixture> affected = new List<Fixture>();

            float RayCastCallback(Fixture f, Vector2 vector2, Vector2 vector3, float f1)
            {
                affected.Add(f);
                return 1;
            }

            RayCast(RayCastCallback, point1, point2);

            return affected;
        }

        /// <summary>
        ///     Tests the point using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <returns>The my fixture</returns>
        public Fixture TestPoint(Vector2 point)
        {
            AABB aabb;
            Vector2 d = new Vector2(MathConstants.Epsilon, MathConstants.Epsilon);
            aabb.LowerBound = point - d;
            aabb.UpperBound = point + d;

            _myFixture = null;
            _point1 = point;

            // Query the world for overlapping shapes.
            QueryAABB(TestPointCallback, ref aabb);

            return _myFixture;
        }

        /// <summary>Returns a list of fixtures that are at the specified point.</summary>
        /// <param name="point">The point.</param>
        public List<Fixture> TestPointAll(Vector2 point)
        {
            AABB aabb;
            Vector2 d = new Vector2(MathConstants.Epsilon, MathConstants.Epsilon);
            aabb.LowerBound = point - d;
            aabb.UpperBound = point + d;

            _point2 = point;
            _testPointAllFixtures = new List<Fixture>();

            // Query the world for overlapping shapes.
            QueryAABB(TestPointAllCallback, ref aabb);

            return _testPointAllFixtures;
        }

        /// <summary>
        ///     Shift the world origin. Useful for large worlds. The body shift formula is: position -= newOrigin @param
        ///     newOrigin the new origin with respect to the old origin Warning: Calling this method mid-update might cause a
        ///     crash.
        /// </summary>
        public void ShiftOrigin(Vector2 newOrigin)
        {
            Debug.Assert(!IsLocked);
            if (IsLocked)
            {
                return;
            }

            foreach (Body b in _bodyList)
            {
                b._xf.p -= newOrigin;
                b.Sweep.C0 -= newOrigin;
                b.Sweep.C -= newOrigin;
            }

            foreach (Joint joint in _jointList)
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

            for (int i = _bodyList.Count - 1; i >= 0; i--)
            {
                RemoveBody(_bodyList[i]);
            }

            for (int i = _controllerList.Count - 1; i >= 0; i--)
            {
                RemoveController(_controllerList[i]);
            }

            for (int i = _breakableBodyList.Count - 1; i >= 0; i--)
            {
                RemoveBreakableBody(_breakableBodyList[i]);
            }

            //We call ProcessChanges again since the user could have added items to the body/joint queues in the Removed/Added events
            ProcessChanges();
        }

        /// <summary>
        ///     Raises the new fixture event using the specified fixture
        /// </summary>
        /// <param name="fixture">The fixture</param>
        internal void RaiseNewFixtureEvent(Fixture fixture)
        {
            FixtureAdded?.Invoke(fixture);
        }

        /// <summary>
        ///     Processes the removed joints
        /// </summary>
        private void ProcessRemovedJoints()
        {
            if (_jointRemoveList.Count == 0)
            {
                return;
            }

            foreach (Joint joint in _jointRemoveList)
            {
                RemoveJointInternal(joint);
            }

            _jointRemoveList.Clear();
        }

        /// <summary>
        ///     Processes the added joints
        /// </summary>
        private void ProcessAddedJoints()
        {
            if (_jointAddList.Count == 0)
            {
                return;
            }

            foreach (Joint joint in _jointAddList)
            {
                AddJointInternal(joint);
            }

            _jointAddList.Clear();
        }

        /// <summary>
        ///     Processes the added bodies
        /// </summary>
        private void ProcessAddedBodies()
        {
            if (_bodyAddList.Count == 0)
            {
                return;
            }

            foreach (Body body in _bodyAddList)
            {
                AddBodyInternal(body);
            }

            _bodyAddList.Clear();
        }

        /// <summary>
        ///     Processes the removed bodies
        /// </summary>
        private void ProcessRemovedBodies()
        {
            if (_bodyRemoveList.Count == 0)
            {
                return;
            }

            foreach (Body body in _bodyRemoveList)
            {
                RemoveBodyInternal(body);
            }

            _bodyRemoveList.Clear();
        }

        /// <summary>
        ///     Describes whether this instance query aabb callback wrapper
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <returns>The bool</returns>
        private bool QueryAABBCallbackWrapper(int proxyId)
        {
            FixtureProxy proxy = ContactManager.BroadPhase.GetProxy(proxyId);
            return _queryAABBCallback(proxy.Fixture);
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
                Vector2 point = (1.0f - fraction) * rayCastInput.Point1 + fraction * rayCastInput.Point2;
                return _rayCastCallback(fixture, point, output.Normal, fraction);
            }

            return rayCastInput.MaxFraction;
        }

        /// <summary>
        ///     Solves the step
        /// </summary>
        /// <param name="step">The step</param>
        private void Solve(ref TimeStep step)
        {
            _profile.SolveInit = 0;
            _profile.SolveVelocity = 0;
            _profile.SolvePosition = 0;

            // Size the island for the worst case.
            Island1.Reset(_bodyList.Count,
                ContactManager._contactCount,
                _jointList.Count,
                ContactManager);

            // Clear all the island flags.
            foreach (Body b in _bodyList)
            {
                b.Flags &= ~BodyFlags.IslandFlag;
            }

            for (Contact c = ContactManager._contactList; c != null; c = c.Next)
            {
                c.Flags &= ~ContactFlags.IslandFlag;
            }

            foreach (Joint j in _jointList)
            {
                j.IslandFlag = false;
            }

            // Build and simulate all awake islands.
            int stackSize = _bodyList.Count;
            if (stackSize > _stack.Length)
            {
                _stack = new Body[Math.Max(_stack.Length * 2, stackSize)];
            }

            for (int index = _bodyList.Count - 1; index >= 0; index--)
            {
                Body seed = _bodyList[index];
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
                Island1.Clear();
                int stackCount = 0;
                _stack[stackCount++] = seed;

                seed.Flags |= BodyFlags.IslandFlag;

                // Perform a depth first search (DFS) on the constraint graph.
                while (stackCount > 0)
                {
                    // Grab the next body off the stack and add it to the island.
                    Body b = _stack[--stackCount];
                    Debug.Assert(b.Enabled);
                    Island1.Add(b);

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

                        Island1.Add(contact);
                        contact.Flags |= ContactFlags.IslandFlag;

                        Body other = ce.Other;

                        // Was the other body already added to this island?
                        if (other.IsIsland)
                        {
                            continue;
                        }

                        Debug.Assert(stackCount < stackSize);
                        _stack[stackCount++] = other;
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

                            Island1.Add(je.Joint);
                            je.Joint.IslandFlag = true;

                            if (other.IsIsland)
                            {
                                continue;
                            }

                            Debug.Assert(stackCount < stackSize);
                            _stack[stackCount++] = other;

                            other.Flags |= BodyFlags.IslandFlag;
                        }
                        else
                        {
                            Island1.Add(je.Joint);
                            je.Joint.IslandFlag = true;
                        }
                    }
                }

                Profile profile = new Profile();
                Island1.Solve(ref profile, ref step, ref _gravity, _sleepingAllowed);
                _profile.SolveInit += profile.SolveInit;
                _profile.SolveVelocity += profile.SolveVelocity;
                _profile.SolvePosition += profile.SolvePosition;

                // Post solve cleanup.
                for (int i = 0; i < Island1._bodyCount; ++i)
                {
                    // Allow static bodies to participate in other islands.
                    Body b = Island1._bodies[i];
                    if (b.BodyType == BodyType.Static)
                    {
                        b.Flags &= ~BodyFlags.IslandFlag;
                    }
                }
            }

            {
                Stopwatch timer = _timerPool.GetFromPool(true);

                // Synchronize fixtures, check for out of range bodies.
                foreach (Body b in _bodyList)
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
                _profile.Broadphase = timer.ElapsedTicks;
                _timerPool.ReturnToPool(timer);
            }
        }

        /// <summary>
        ///     Solves the toi using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        private void SolveTOI(ref TimeStep step)
        {
            Island1.Reset(2 * Settings.MaxToiContacts, Settings.MaxToiContacts, 0, ContactManager);

            if (_stepComplete)
            {
                for (int i = 0; i < _bodyList.Count; i++)
                {
                    _bodyList[i].Flags &= ~BodyFlags.IslandFlag;
                    _bodyList[i].Sweep.Alpha0 = 0.0f;
                }

                for (Contact c = ContactManager._contactList; c != null; c = c.Next)
                {
                    // Invalidate TOI
                    c.Flags &= ~(ContactFlags.TOIFlag | ContactFlags.IslandFlag);
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

                for (Contact c = ContactManager._contactList; c != null; c = c.Next)
                {
                    // Is this contact disabled?
                    if (!c.Enabled)
                    {
                        continue;
                    }

                    // Prevent excessive sub-stepping.
                    if (c.ToiCount > Settings.MaxSubSteps)
                    {
                        continue;
                    }

                    float alpha;
                    if (c.TOIFlag)
                    {
                        // This contact has a valid cached TOI.
                        alpha = c.Toi;
                    }
                    else
                    {
                        Fixture fA = c.FixtureA;
                        Fixture fB = c.FixtureB;

                        // Is there a sensor?
                        if (fA._isSensor || fB._isSensor)
                        {
                            continue;
                        }

                        Body bA = fA.Body;
                        Body bB = fB.Body;

                        BodyType typeA = bA.BodyType;
                        BodyType typeB = bB.BodyType;
                        Debug.Assert(typeA == BodyType.Dynamic || typeB == BodyType.Dynamic);

                        bool activeA = bA.Awake && typeA != BodyType.Static;
                        bool activeB = bB.Awake && typeB != BodyType.Static;

                        // Is at least one body active (awake and dynamic or kinematic)?
                        if (!activeA && !activeB)
                        {
                            continue;
                        }

                        bool collideA = (bA.IsBullet || typeA != BodyType.Dynamic) &&
                                        (fA.IgnoreCcdWith & fB.CollisionCategories) == 0 && !bA.IgnoreCCD;
                        bool collideB = (bB.IsBullet || typeB != BodyType.Dynamic) &&
                                        (fB.IgnoreCcdWith & fA.CollisionCategories) == 0 && !bB.IgnoreCCD;

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
                        TOIInput input = new TOIInput();
                        input.ProxyA = new DistanceProxy(fA.Shape, c.ChildIndexA);
                        input.ProxyB = new DistanceProxy(fB.Shape, c.ChildIndexB);
                        input.SweepA = bA.Sweep;
                        input.SweepB = bB.Sweep;
                        input.TMax = 1.0f;

                        TimeOfImpact.CalculateTimeOfImpact(ref input, out TOIOutput output);

                        // Beta is the fraction of the remaining portion of the .
                        float beta = output.T;
                        if (output.State == TOIOutputState.Touching)
                        {
                            alpha = Math.Min(alpha0 + (1.0f - alpha0) * beta, 1.0f);
                        }
                        else
                        {
                            alpha = 1.0f;
                        }

                        c.Toi = alpha;
                        c.Flags &= ~ContactFlags.TOIFlag;
                    }

                    if (alpha < minAlpha)
                    {
                        // This is the minimum TOI found so far.
                        minContact = c;
                        minAlpha = alpha;
                    }
                }

                if (minContact == null || 1.0f - 10.0f * MathConstants.Epsilon < minAlpha)
                {
                    // No more TOI events. Done!
                    _stepComplete = true;
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
                minContact.Flags &= ~ContactFlags.TOIFlag;
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
                Island1.Clear();
                Island1.Add(bA0);
                Island1.Add(bB0);
                Island1.Add(minContact);

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

                            if (Island1._bodyCount == Island1._bodyCapacity)
                            {
                                break;
                            }

                            if (Island1._contactCount == Island1._contactCapacity)
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
                            if (other.BodyType == BodyType.Dynamic &&
                                !body.IsBullet && !other.IsBullet)
                            {
                                continue;
                            }

                            // Skip sensors.
                            bool sensorA = contact.FixtureA._isSensor;
                            bool sensorB = contact.FixtureB._isSensor;
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
                            Island1.Add(contact);

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

                            Island1.Add(other);
                        }
                    }
                }

                TimeStep subStep;
                subStep.DeltaTime = (1.0f - minAlpha) * step.DeltaTime;
                subStep.InvertedDeltaTime = 1.0f / subStep.DeltaTime;
                subStep.DeltaTimeRatio = 1.0f;
                subStep.PositionIterations = 20;
                subStep.VelocityIterations = step.VelocityIterations;
                subStep.WarmStarting = false;
                Island1.SolveTOI(ref subStep, bA0.IslandIndex, bB0.IslandIndex);

                // Reset island flags and synchronize broad-phase proxies.
                for (int i = 0; i < Island1._bodyCount; ++i)
                {
                    Body body = Island1._bodies[i];
                    body.Flags &= ~BodyFlags.IslandFlag;

                    if (body.BodyType != BodyType.Dynamic)
                    {
                        continue;
                    }

                    body.SynchronizeFixtures();

                    // Invalidate all contact TOIs on this displaced body.
                    for (ContactEdge ce = body.ContactList; ce != null; ce = ce.Next)
                    {
                        ce.Contact.Flags &= ~(ContactFlags.TOIFlag | ContactFlags.IslandFlag);
                    }
                }

                // Commit fixture proxy movements to the broad-phase so that new contacts are created.
                // Also, some contacts can be destroyed.
                ContactManager.FindNewContacts();

                if (Settings.EnableSubStepping)
                {
                    _stepComplete = false;
                    break;
                }
            }
        }

        /// <summary>
        ///     Describes whether this instance test point callback
        /// </summary>
        /// <param name="fixture">The fixture</param>
        /// <returns>The bool</returns>
        private bool TestPointCallback(Fixture fixture)
        {
            bool inside = fixture.TestPoint(ref _point1);
            if (inside)
            {
                _myFixture = fixture;
                return false;
            }

            // Continue the query.
            return true;
        }

        /// <summary>
        ///     Describes whether this instance test point all callback
        /// </summary>
        /// <param name="fixture">The fixture</param>
        /// <returns>The bool</returns>
        private bool TestPointAllCallback(Fixture fixture)
        {
            bool inside = fixture.TestPoint(ref _point2);
            if (inside)
            {
                _testPointAllFixtures.Add(fixture);
            }

            // Continue the query.
            return true;
        }

        /// <summary>
        ///     Adds the joint internal using the specified joint
        /// </summary>
        /// <param name="joint">The joint</param>
        private void AddJointInternal(Joint joint)
        {
            // Connect to the world list.
            _jointList.Add(joint);

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

            JointAdded?.Invoke(joint);

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
            _jointList.Remove(joint);

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

            JointRemoved?.Invoke(joint);
        }

        /// <summary>
        ///     Adds the body internal using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        private void AddBodyInternal(Body body)
        {
            body._world = this;

            // Add to world list.
            _bodyList.Add(body);

            //Velcro: We have events to notify the user that a body was added
            BodyAdded?.Invoke(body);

            //Velcro: We have events to notify fixtures was added
            if (FixtureAdded != null)
            {
                for (int i = 0; i < body.FixtureList.Count; i++)
                {
                    FixtureAdded(body.FixtureList[i]);
                }
            }
        }

        /// <summary>
        ///     Removes the body internal using the specified body
        /// </summary>
        /// <param name="body">The body</param>
        private void RemoveBodyInternal(Body body)
        {
            Debug.Assert(_bodyList.Count > 0);

            //Velcro: We check if the user is trying to remove a body more than one (to check for bugs)
            Debug.Assert(_bodyList.Contains(body));

            // Delete the attached joints.
            JointEdge je = body.JointList;
            while (je != null)
            {
                JointEdge je0 = je;
                je = je.Next;

                RemoveJointInternal(je0.Joint);
            }

            body.JointList = null;

            // Delete the attached contacts.
            ContactEdge ce = body.ContactList;
            while (ce != null)
            {
                ContactEdge ce0 = ce;
                ce = ce.Next;
                ContactManager.Remove(ce0.Contact);
            }

            body.ContactList = null;

            // Delete the attached fixtures. This destroys broad-phase proxies.
            for (int i = 0; i < body.FixtureList.Count; i++)
            {
                Fixture fixture = body.FixtureList[i];

                //Velcro: Added event
                FixtureRemoved?.Invoke(fixture);

                fixture.DestroyProxies(ContactManager.BroadPhase);
                fixture.Destroy();
            }

            body.FixtureList = null;

            //Velcro: We make sure to cleanup the references and delegates
            body._world = null;
            body.OnCollision = null;
            body.OnSeparation = null;

            // Remove world body list.
            _bodyList.Remove(body);

            BodyRemoved?.Invoke(body);
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