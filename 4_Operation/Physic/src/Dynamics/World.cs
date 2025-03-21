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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joints;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The world class manages all physics entities, dynamic simulation,
    ///     and asynchronous queries.
    /// </summary>
    public class World
    {
        /// <summary>This is only for debugging the solver</summary>
        private const bool WarmStarting = true;

        /// <summary>This is only for debugging the solver</summary>
        private const bool SubStepping = false;

        /// <summary>
        ///     The query callback cache
        /// </summary>
        private readonly BroadPhaseQueryCallback _queryCallbackCache;

        /// <summary>
        ///     The ray cast callback cache
        /// </summary>
        private readonly BroadPhaseRayCastCallback _rayCastCallbackCache;

        /// <summary>
        ///     The test point delegate cache
        /// </summary>
        private readonly QueryReportFixtureDelegate _testPointDelegateCache;

        /// <summary>
        ///     The stopwatch
        /// </summary>
        private readonly Stopwatch _watch = new Stopwatch();

        /// <summary>
        ///     Get the world body list.
        /// </summary>
        /// <value>The head of the world body list.</value>
        internal readonly BodyCollection BodyList;

        /// <summary>
        ///     Get the contact manager for testing.
        /// </summary>
        /// <value>The contact manager.</value>
        internal readonly ContactManager ContactManager;

        /// <summary>
        ///     The controller list
        /// </summary>
        internal readonly ControllerCollection ControllerList;

        /// <summary>
        ///     Get the world joint list.
        /// </summary>
        /// <value>The joint list.</value>
        internal readonly JointCollection JointList;

        /// <summary>
        ///     The gravity
        /// </summary>
        private Vector2F _gravity;

        /// <summary>
        ///     The toi input
        /// </summary>
        private ToiInput _input = new ToiInput();

        /// <summary>
        ///     The inv dt
        /// </summary>
        private float _invDt0;

        /// <summary>
        ///     The query delegate tmp
        /// </summary>
        private QueryReportFixtureDelegate _queryDelegateTmp;

        /// <summary>
        ///     The ray cast delegate tmp
        /// </summary>
        private RayCastReportFixtureDelegate _rayCastDelegateTmp;

        /// <summary>
        ///     The body
        /// </summary>
        private Body[] _stack = new Body[64];

        /// <summary>
        ///     The step complete
        /// </summary>
        private bool _stepComplete = true;

        /// <summary>
        ///     The test point fixture tmp
        /// </summary>
        private Fixture _testPointFixtureTmp;

        /// <summary>
        ///     The test point point tmp
        /// </summary>
        private Vector2F _testPointPointTmp;

        /// <summary>
        ///     Fires whenever a body has been added
        /// </summary>
        public BodyDelegate BodyAdded;

        /// <summary>
        ///     Fires whenever a body has been removed
        /// </summary>
        public BodyDelegate BodyRemoved;

        /// <summary>
        ///     Fires every time a controller is added to the World.
        /// </summary>
        public ControllerDelegate ControllerAdded;

        /// <summary>
        ///     Fires every time a controlelr is removed form the World.
        /// </summary>
        public ControllerDelegate ControllerRemoved;

        /// <summary>
        ///     Fires whenever a fixture has been added
        /// </summary>
        public FixtureDelegate FixtureAdded;

        /// <summary>
        ///     Fires whenever a fixture has been removed
        /// </summary>
        public FixtureDelegate FixtureRemoved;

        /// <summary>
        ///     Fires whenever a joint has been added
        /// </summary>
        public JointDelegate JointAdded;

        /// <summary>
        ///     Fires whenever a joint has been removed
        /// </summary>
        public JointDelegate JointRemoved;

        /// <summary>
        ///     Set the user data. Use this to store your application specific data.
        /// </summary>
        /// <value>The user data.</value>
        public object Tag;

        /// <summary>
        ///     The world has new fixture
        /// </summary>
        internal bool WorldHasNewFixture;

        /// <summary>
        ///     Initializes a new instance of the <see cref="World" /> class.
        /// </summary>
        public World()
        {
            GetIsland = new Island();
            GetEnabled = true;
            BodyList = new BodyCollection(this);
            JointList = new JointCollection(this);
            ControllerList = new ControllerCollection(this);

            _queryCallbackCache = QueryAabbCallback;
            _rayCastCallbackCache = RayCastCallback;
            _testPointDelegateCache = TestPointCallback;


            ContactManager = new ContactManager(new DynamicTreeBroadPhase());
            GetGravity = new Vector2F(0f, -9.80665f);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="World" /> class.
        /// </summary>
        /// <param name="gravity">The gravity.</param>
        public World(Vector2F gravity) : this() => GetGravity = gravity;

        /// <summary>
        ///     Initializes a new instance of the <see cref="World" /> class.
        /// </summary>
        public World(IBroadPhase broadPhase) : this() => ContactManager = new ContactManager(broadPhase);

        /// <summary>
        ///     Gets or sets the value of the update time
        /// </summary>
        public TimeSpan UpdateTime { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the continuous physics time
        /// </summary>
        public TimeSpan ContinuousPhysicsTime { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the controllers update time
        /// </summary>
        public TimeSpan ControllersUpdateTime { get; private set; }

        /// <summary>
        ///     Gets the value of the add remove time
        /// </summary>
        public TimeSpan AddRemoveTime { get; }

        /// <summary>
        ///     Gets or sets the value of the new contacts time
        /// </summary>
        public TimeSpan NewContactsTime { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the contacts update time
        /// </summary>
        public TimeSpan ContactsUpdateTime { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the solve update time
        /// </summary>
        public TimeSpan SolveUpdateTime { get; private set; }

        /// <summary>
        ///     Get the number of broad-phase proxies.
        /// </summary>
        /// <value>The proxy count.</value>
        public int ProxyCount => ContactManager.BroadPhase.ProxyCount;

        /// <summary>
        ///     Get the number of contacts (each may have 0 or more contact points).
        /// </summary>
        /// <value>The contact count.</value>
        public int ContactCount => ContactManager.ContactCount;

        /// <summary>
        ///     Change the global gravity vector.
        /// </summary>
        /// <value>The gravity.</value>
        public Vector2F GetGravity
        {
            get => _gravity;
            set
            {
                if (GetIsLocked)
                {
                    throw new InvalidOperationException("The World is locked.");
                }

                _gravity = value;
            }
        }

        /// <summary>
        ///     Is the world locked (in the middle of a time step).
        /// </summary>
        public bool GetIsLocked { get; private set; }

        /// <summary>
        ///     Get the world contact list.
        ///     ContactList is the head of a circular linked list. Use Contact.Next to get
        ///     the next contact in the world list. A contact equal to ContactList indicates the end of the list.
        /// </summary>
        /// <value>The head of the world contact list.</value>
        /// <example>for (Contact c = World.ContactList.Next; c != World..ContactList; c = c.Next)</example>
        public ContactListHead ContactList => ContactManager.ContactList;

        /// <summary>
        ///     If false, the whole simulation stops. It still processes added and removed geometries.
        /// </summary>
        public bool GetEnabled { get; set; }

        /// <summary>
        ///     Gets the value of the island
        /// </summary>
        public Island GetIsland { get; }

        /// <summary>
        ///     Solves the step
        /// </summary>
        /// <param name="step">The step</param>
        private void Solve(ref TimeStep step)
        {
            // Size the island for the worst case.
            GetIsland.Reset(BodyList.Count,
                ContactManager.ContactCount,
                JointList.Count,
                ContactManager);

            // Clear all the island flags.
            foreach (Body b in BodyList)
            {
                b.Island = false;
            }

            for (Contact c = ContactManager.ContactList.Next; c != ContactManager.ContactList; c = c.Next)
            {
                c.IslandFlag = false;
            }

            foreach (Joint j in JointList)
            {
                j.IslandFlag = false;
            }

            // Build and simulate all awake islands.
            int stackSize = BodyList.Count;
            if (stackSize > _stack.Length)
            {
                _stack = new Body[Math.Max(_stack.Length * 2, stackSize)];
            }

            for (int index = BodyList.List.Count - 1; index >= 0; index--)
            {
                Body seed = BodyList.List[index];

                if (seed.Island)
                {
                    continue;
                }

                if (seed.Awake == false || seed.Enabled == false)
                {
                    continue;
                }

                // The seed can be dynamic or kinematic.
                if (seed.GetBodyType == BodyType.Static)
                {
                    continue;
                }

                // Reset island and stack.
                GetIsland.Clear();
                int stackCount = 0;
                _stack[stackCount++] = seed;

                seed.Island = true;

                // Perform a depth first search (DFS) on the constraint graph.
                while (stackCount > 0)
                {
                    // Grab the next body off the stack and add it to the island.
                    Body b = _stack[--stackCount];
                    Debug.Assert(b.Enabled);
                    GetIsland.Add(b);

                    // Make sure the body is awake.
                    b.Awake = true;

                    // To keep islands as small as possible, we don't
                    // propagate islands across static bodies.
                    if (b.GetBodyType == BodyType.Static)
                    {
                        continue;
                    }

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
                        if (ce.Contact.Enabled == false || ce.Contact.IsTouching == false)
                        {
                            continue;
                        }

                        // Skip sensors.
                        bool sensorA = contact.FixtureA.GetIsSensor;
                        bool sensorB = contact.FixtureB.GetIsSensor;
                        if (sensorA || sensorB)
                        {
                            continue;
                        }

                        GetIsland.Add(contact);
                        contact.IslandFlag = true;

                        Body other = ce.Other;

                        // Was the other body already added to this island?
                        if (other.Island)
                        {
                            continue;
                        }

                        Debug.Assert(stackCount < stackSize);
                        _stack[stackCount++] = other;

                        other.Island = true;
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
                            if (other.Enabled == false)
                            {
                                continue;
                            }

                            GetIsland.Add(je.Joint);
                            je.Joint.IslandFlag = true;

                            if (other.Island)
                            {
                                continue;
                            }

                            Debug.Assert(stackCount < stackSize);
                            _stack[stackCount++] = other;

                            other.Island = true;
                        }
                        else
                        {
                            GetIsland.Add(je.Joint);
                            je.Joint.IslandFlag = true;
                        }
                    }
                }

                GetIsland.Solve(ref step, ref _gravity);

                // Post solve cleanup.
                for (int i = 0; i < GetIsland.BodyCount; ++i)
                {
                    // Allow static bodies to participate in other islands.
                    Body b = GetIsland.Bodies[i];
                    if (b.GetBodyType == BodyType.Static)
                    {
                        b.Island = false;
                    }
                }
            }

            foreach (Body b in BodyList)
            {
                // If a body was not in an island then it did not move.
                if (!b.Island)
                {
                    continue;
                }

                if (b.GetBodyType == BodyType.Static)
                {
                    continue;
                }

                // Update fixtures (for broad-phase).
                b.SynchronizeFixtures();
            }

            // Look for new contacts.
            ContactManager.FindNewContacts();
        }

        /// <summary>
        ///     Solves the toi using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        /// <param name="iterations">The iterations</param>
        private void SolveToi(ref TimeStep step, ref SolverIterations iterations)
        {
            GetIsland.Reset(2 * SettingEnv.MaxToiContacts, SettingEnv.MaxToiContacts, 0, ContactManager);

            if (_stepComplete)
            {
                for (int i = 0; i < BodyList.List.Count; i++)
                {
                    BodyList.List[i].Island = false;
                    BodyList.List[i].Sweep.Alpha0 = 0.0f;
                }

                for (Contact c = ContactManager.ContactList.Next; c != ContactManager.ContactList; c = c.Next)
                {
                    // Invalidate TOI
                    c.IslandFlag = false;
                    c.ToiFlag = false;
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


                for (Contact c = ContactManager.ContactList.Next; c != ContactManager.ContactList; c = c.Next)
                {
                    // Is this contact disabled?
                    if (c.Enabled == false)
                    {
                        continue;
                    }

                    // Prevent excessive sub-stepping.
                    if (c.ToiCount > SettingEnv.MaxSubSteps)
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
                        if (fA.GetIsSensor || fB.GetIsSensor)
                        {
                            continue;
                        }

                        Body bA = fA.GetBody;
                        Body bB = fB.GetBody;

                        BodyType typeA = bA.GetBodyType;
                        BodyType typeB = bB.GetBodyType;
                        Debug.Assert(typeA == BodyType.Dynamic || typeB == BodyType.Dynamic);

                        bool activeA = bA.Awake && (typeA != BodyType.Static);
                        bool activeB = bB.Awake && (typeB != BodyType.Static);

                        // Is at least one body active (awake and dynamic or kinematic)?
                        if ((activeA == false) && (activeB == false))
                        {
                            continue;
                        }

                        bool collideA = (bA.IsBullet || typeA != BodyType.Dynamic) && !bA.IgnoreCcd;
                        bool collideB = (bB.IsBullet || typeB != BodyType.Dynamic) && !bB.IgnoreCcd;

                        // Are these two non-bullet dynamic bodies?
                        if ((collideA == false) && (collideB == false))
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
                        _input.ProxyA = new DistanceProxy(fA.GetShape, c.ChildIndexA);
                        _input.ProxyB = new DistanceProxy(fB.GetShape, c.ChildIndexB);
                        _input.SweepA = bA.Sweep;
                        _input.SweepB = bB.Sweep;
                        _input.TMax = 1.0f;

                        TimeOfImpact.CalculateTimeOfImpact(out ToiOutput output, ref _input);

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
                        c.ToiFlag = true;
                    }

                    if (alpha < minAlpha)
                    {
                        // This is the minimum TOI found so far.
                        minContact = c;
                        minAlpha = alpha;
                    }
                }

                if (minContact == null || 1.0f - 10.0f * SettingEnv.Epsilon < minAlpha)
                {
                    // No more TOI events. Done!
                    _stepComplete = true;
                    break;
                }

                // Advance the bodies to the TOI.
                Fixture fA1 = minContact.FixtureA;
                Fixture fB1 = minContact.FixtureB;
                Body bA0 = fA1.GetBody;
                Body bB0 = fB1.GetBody;

                Sweep backup1 = bA0.Sweep;
                Sweep backup2 = bB0.Sweep;

                bA0.Advance(minAlpha);
                bB0.Advance(minAlpha);

                // The TOI contact likely has some new contact points.
                minContact.Update(ContactManager);
                minContact.ToiFlag = false;
                ++minContact.ToiCount;

                // Is the contact solid?
                if (minContact.Enabled == false || minContact.IsTouching == false)
                {
                    // Restore the sweeps.
                    minContact.Enabled = false;
                    bA0.Sweep = backup1;
                    bB0.Sweep = backup2;
                    bA0.SynchronizeTransform();
                    bB0.SynchronizeTransform();
                    continue;
                }

                bA0.Awake = true;
                bB0.Awake = true;

                // Build the island
                GetIsland.Clear();
                GetIsland.Add(bA0);
                GetIsland.Add(bB0);
                GetIsland.Add(minContact);

                bA0.Island = true;
                bB0.Island = true;
                minContact.IslandFlag = true;

                // Get contacts on bodyA and bodyB.
                Body[] bodies = {bA0, bB0};
                for (int i = 0; i < 2; ++i)
                {
                    Body body = bodies[i];
                    if (body.GetBodyType == BodyType.Dynamic)
                    {
                        for (ContactEdge ce = body.ContactList; ce != null; ce = ce.Next)
                        {
                            Contact contact = ce.Contact;

                            if (GetIsland.BodyCount == GetIsland.BodyCapacity)
                            {
                                break;
                            }

                            if (GetIsland.ContactCount == GetIsland.ContactCapacity)
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
                            if ((other.GetBodyType == BodyType.Dynamic) &&
                                (body.IsBullet == false) && (other.IsBullet == false))
                            {
                                continue;
                            }

                            // Skip sensors.
                            if (contact.FixtureA.GetIsSensor || contact.FixtureB.GetIsSensor)
                            {
                                continue;
                            }

                            // Tentatively advance the body to the TOI.
                            Sweep backup = other.Sweep;
                            if (!other.Island)
                            {
                                other.Advance(minAlpha);
                            }

                            // Update the contact points
                            contact.Update(ContactManager);

                            // Was the contact disabled by the user?
                            if (contact.Enabled == false)
                            {
                                other.Sweep = backup;
                                other.SynchronizeTransform();
                                continue;
                            }

                            // Are there contact points?
                            if (contact.IsTouching == false)
                            {
                                other.Sweep = backup;
                                other.SynchronizeTransform();
                                continue;
                            }

                            // Add the contact to the island
                            contact.IslandFlag = true;
                            GetIsland.Add(contact);

                            // Has the other body already been added to the island?
                            if (other.Island)
                            {
                                continue;
                            }

                            // Add the other body to the island.
                            other.Island = true;

                            if (other.GetBodyType != BodyType.Static)
                            {
                                other.Awake = true;
                            }

                            GetIsland.Add(other);
                        }
                    }
                }

                TimeStep subStep;
                subStep.PositionIterations = iterations.ToiPositionIterations;
                subStep.VelocityIterations = iterations.ToiVelocityIterations;
                subStep.Dt = (1.0f - minAlpha) * step.Dt;
                subStep.InvDt = 1.0f / subStep.Dt;
                subStep.DtRatio = 1.0f;
                subStep.WarmStarting = false;
                GetIsland.SolveToi(ref subStep, bA0.GetIslandIndex, bB0.GetIslandIndex);

                // Reset island flags and synchronize broad-phase proxies.
                for (int i = 0; i < GetIsland.BodyCount; ++i)
                {
                    Body body = GetIsland.Bodies[i];
                    body.Island = false;

                    if (body.GetBodyType != BodyType.Dynamic)
                    {
                        continue;
                    }

                    body.SynchronizeFixtures();

                    // Invalidate all contact TOIs on this displaced body.
                    for (ContactEdge ce = body.ContactList; ce != null; ce = ce.Next)
                    {
                        ce.Contact.ToiFlag = false;
                        ce.Contact.IslandFlag = false;
                    }
                }

                // Commit fixture proxy movements to the broad-phase so that new contacts are created.
                // Also, some contacts can be destroyed.
                ContactManager.FindNewContacts();
            }
        }

        /// <summary>
        ///     Add a rigid body.
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public virtual void Add(Body body)
        {
            if (GetIsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            if (body.World == this)
            {
                throw new ArgumentException("You are adding the same body more than once.", "body");
            }

            if (body.World != null)
            {
                throw new ArgumentException("body belongs to another world.", "body");
            }

            body.World = this;
            BodyList.List.Add(body);
            BodyList.GenerationStamp++;


            // Update transform
            body.SetTransformIgnoreContacts(ref body.Xf.P, body.Rotation);

            // Create proxies
            if (GetEnabled)
            {
                body.CreateProxies();
            }

            ContactManager.FindNewContacts();


            // Fire World events:

            BodyDelegate bodyAddedHandler = BodyAdded;
            if (bodyAddedHandler != null)
            {
                bodyAddedHandler(this, body);
            }

            FixtureDelegate fixtureAddedHandler = FixtureAdded;
            if (fixtureAddedHandler != null)
            {
                for (int i = 0; i < body.FixtureList.List.Count; i++)
                {
                    fixtureAddedHandler(this, body, body.FixtureList.List[i]);
                }
            }
        }

        /// <summary>
        ///     Destroy a rigid body.
        ///     Warning: This automatically deletes all associated shapes and joints.
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// <param name="body">The body.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public virtual void Remove(Body body)
        {
            if (GetIsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            if (body.GetWorld != this)
            {
                throw new ArgumentException("You are removing a body that is not in the simulation.", "body");
            }

            // Delete the attached joints.
            JointEdge je = body.JointList;
            while (je != null)
            {
                JointEdge je0 = je;
                je = je.Next;

                Remove(je0.Joint);
            }

            body.JointList = null;

            // Delete the attached contacts.
            ContactEdge ce = body.ContactList;
            while (ce != null)
            {
                ContactEdge ce0 = ce;
                ce = ce.Next;
                ContactManager.Destroy(ce0.Contact);
            }

            body.ContactList = null;

            // remove the attached contact callbacks
            body.OnCollisionEventHandler = null;
            body.OnSeparationEventHandler = null;

            // Delete the attached fixtures. This destroys broad-phase proxies.
            body.DestroyProxies();
            FixtureDelegate fixtureRemovedHandler = FixtureRemoved;
            if (fixtureRemovedHandler != null)
            {
                for (int i = 0; i < body.FixtureList.List.Count; i++)
                {
                    fixtureRemovedHandler(this, body, body.FixtureList.List[i]);
                }
            }

            body.World = null;
            BodyList.List.Remove(body);
            BodyList.GenerationStamp++;

            BodyDelegate bodyRemovedHandler = BodyRemoved;
            if (bodyRemovedHandler != null)
            {
                bodyRemovedHandler(this, body);
            }
        }

        /// <summary>
        ///     Create a joint to constrain bodies together. This may cause the connected bodies to cease colliding.
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// <param name="joint">The joint.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public void Add(Joint joint)
        {
            if (GetIsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            if (joint == null)
            {
                throw new ArgumentNullException("joint");
            }

            if (joint.WorldInternal == this)
            {
                throw new ArgumentException("You are adding the same joint more than once.", "joint");
            }

            if (joint.WorldInternal != null)
            {
                throw new ArgumentException("joint belongs to another world.", "joint");
            }

            // Connect to the world list.
            joint.WorldInternal = this;
            JointList.List.Add(joint);
            JointList.GenerationStamp++;

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
                if (joint.CollideConnected == false)
                {
                    ContactEdge edge = bodyB.ContactList;
                    while (edge != null)
                    {
                        if (edge.Other == bodyA)
                        {
                            // Flag the contact for filtering at the next time step (where either
                            // body is awake).
                            edge.Contact.FilterFlag = true;
                        }

                        edge = edge.Next;
                    }
                }
            }

            JointDelegate jointAddedHandler = JointAdded;
            if (jointAddedHandler != null)
            {
                jointAddedHandler(this, joint);
            }

            // Note: creating a joint doesn't wake the bodies.
        }

        /// <summary>
        ///     Destroy a joint. This may cause the connected bodies to begin colliding.
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// <param name="joint">The joint.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public void Remove(Joint joint)
        {
            if (GetIsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            if (joint == null)
            {
                throw new ArgumentNullException("joint");
            }

            if (joint.World != this)
            {
                throw new ArgumentException("You are removing a joint that is not in the simulation.", "joint");
            }

            bool collideConnected = joint.CollideConnected;

            // Remove from the world list.
            joint.WorldInternal = null;
            JointList.List.Remove(joint);
            JointList.GenerationStamp++;

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
            }

            // WIP David
            if (!joint.IsFixedType())
            {
                // If the joint prevents collisions, then flag any contacts for filtering.
                if (collideConnected == false)
                {
                    ContactEdge edge = bodyB.ContactList;
                    while (edge != null)
                    {
                        if (edge.Other == bodyA)
                        {
                            // Flag the contact for filtering at the next time step (where either
                            // body is awake).
                            edge.Contact.FilterFlag = true;
                        }

                        edge = edge.Next;
                    }
                }
            }

            JointDelegate jointRemovedHandler = JointRemoved;
            if (jointRemovedHandler != null)
            {
                jointRemovedHandler(this, joint);
            }
        }

        /// <summary>
        ///     Take a time step. This performs collision detection, integration,
        ///     and consraint solution.
        /// </summary>
        /// <param name="dt">The amount of time to simulate, this should not vary.</param>
        public void Step(TimeSpan dt)
        {
            Step((float) dt.TotalSeconds);
        }

        /// <summary>
        ///     Take a time step. This performs collision detection, integration,
        ///     and consraint solution.
        /// </summary>
        /// <param name="dt">The amount of time to simulate, this should not vary.</param>
        /// <param name="iterations"></param>
        public void Step(TimeSpan dt, ref SolverIterations iterations)
        {
            Step((float) dt.TotalSeconds, ref iterations);
        }

        /// <summary>
        ///     Take a time step. This performs collision detection, integration,
        ///     and consraint solution.
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// <param name="dt">The amount of time to simulate in seconds, this should not vary.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public void Step(float dt)
        {
            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = SettingEnv.PositionIterations;
            iterations.VelocityIterations = SettingEnv.VelocityIterations;
            iterations.ToiPositionIterations = SettingEnv.ToiPositionIterations;
            iterations.ToiVelocityIterations = SettingEnv.ToiVelocityIterations;
            Step(dt, ref iterations);
        }

        /// <summary>
        ///     Take a time step. This performs collision detection, integration,
        ///     and consraint solution.
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// <param name="dt">The amount of time to simulate in seconds, this should not vary.</param>
        /// <param name="iterations"></param>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public void Step(float dt, ref SolverIterations iterations)
        {
            if (GetIsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            if (!GetEnabled)
            {
                return;
            }

            if (SettingEnv.EnableDiagnostics)
            {
                _watch.Start();
            }

            // If new fixtures were added, we need to find the new contacts.
            if (WorldHasNewFixture)
            {
                ContactManager.FindNewContacts();
                WorldHasNewFixture = false;
            }

            if (SettingEnv.EnableDiagnostics)
            {
                NewContactsTime = TimeSpan.FromTicks(_watch.ElapsedTicks) - AddRemoveTime;
            }

            //FPE only: moved position and velocity iterations into Settings.cs
            TimeStep step;
            step.PositionIterations = iterations.PositionIterations;
            step.VelocityIterations = iterations.VelocityIterations;
            step.Dt = dt;
            step.InvDt = dt > 0.0f ? 1.0f / dt : 0.0f;
            step.DtRatio = _invDt0 * dt;
            step.WarmStarting = WarmStarting;

            GetIsLocked = true;
            try
            {
                //Update controllers
                for (int i = 0; i < ControllerList.List.Count; i++)
                {
                    ControllerList.List[i].Update(dt);
                }

                if (SettingEnv.EnableDiagnostics)
                {
                    ControllersUpdateTime = TimeSpan.FromTicks(_watch.ElapsedTicks) - (AddRemoveTime + NewContactsTime);
                }

                // Update contacts. This is where some contacts are destroyed.
                ContactManager.Collide();
                if (SettingEnv.EnableDiagnostics)
                {
                    ContactsUpdateTime = TimeSpan.FromTicks(_watch.ElapsedTicks) - (AddRemoveTime + NewContactsTime + ControllersUpdateTime);
                }

                // Integrate velocities, solve velocity constraints, and integrate positions.
                if (_stepComplete && (step.Dt > 0.0f))
                {
                    Solve(ref step);
                }

                if (SettingEnv.EnableDiagnostics)
                {
                    SolveUpdateTime = TimeSpan.FromTicks(_watch.ElapsedTicks) - (AddRemoveTime + NewContactsTime + ControllersUpdateTime + ContactsUpdateTime);
                }

                // Handle TOI events.
                if (SettingEnv.ContinuousPhysics && (step.Dt > 0.0f))
                {
                    SolveToi(ref step, ref iterations);
                }

                if (SettingEnv.EnableDiagnostics)
                {
                    ContinuousPhysicsTime = TimeSpan.FromTicks(_watch.ElapsedTicks) - (AddRemoveTime + NewContactsTime + ControllersUpdateTime + ContactsUpdateTime + SolveUpdateTime);
                }

                if (SettingEnv.AutoClearForces)
                {
                    ClearForces();
                }
            }
            finally
            {
                GetIsLocked = false;
            }

            if (step.Dt > 0.0f)
            {
                _invDt0 = step.InvDt;
            }

            if (SettingEnv.EnableDiagnostics)
            {
                _watch.Stop();
                UpdateTime = TimeSpan.FromTicks(_watch.ElapsedTicks);
                _watch.Reset();
            }
        }

        /// <summary>
        ///     Call this after you are done with time steps to clear the forces. You normally
        ///     call this after each call to Step, unless you are performing sub-steps. By default,
        ///     forces will be automatically cleared, so you don't need to call this function.
        /// </summary>
        public void ClearForces()
        {
            for (int i = 0; i < BodyList.List.Count; i++)
            {
                Body body = BodyList.List[i];
                body.Force = Vector2F.Zero;
                body.Torque = 0.0f;
            }
        }

        /// <summary>
        ///     Query the world for all fixtures that potentially overlap the provided AABB.
        ///     Inside the callback:
        ///     Return true: Continues the query
        ///     Return false: Terminate the query
        /// </summary>
        /// <param name="callback">A user implemented callback class.</param>
        /// <param name="aabb">The aabb query box.</param>
        public void QueryAabb(QueryReportFixtureDelegate callback, Aabb aabb)
        {
            QueryAabb(callback, ref aabb);
        }

        /// <summary>
        ///     Query the world for all fixtures that potentially overlap the provided AABB.
        ///     Inside the callback:
        ///     Return true: Continues the query
        ///     Return false: Terminate the query
        /// </summary>
        /// <param name="callback">A user implemented callback class.</param>
        /// <param name="aabb">The aabb query box.</param>
        public void QueryAabb(QueryReportFixtureDelegate callback, ref Aabb aabb)
        {
            _queryDelegateTmp = callback;
            ContactManager.BroadPhase.Query(_queryCallbackCache, ref aabb);
            _queryDelegateTmp = null;
        }

        /// <summary>
        ///     Describes whether this instance query aabb callback
        /// </summary>
        /// <param name="proxyId">The proxy id</param>
        /// <returns>The bool</returns>
        private bool QueryAabbCallback(int proxyId)
        {
            FixtureProxy proxy = ContactManager.BroadPhase.GetProxy(proxyId);
            return _queryDelegateTmp(proxy.Fixture);
        }

        /// <summary>
        ///     Ray-cast the world for all fixtures in the path of the ray. Your callback
        ///     controls whether you get the closest point, any point, or n-points.
        ///     The ray-cast ignores shapes that contain the starting point.
        ///     Inside the callback:
        ///     return -1: ignore this fixture and continue
        ///     return 0: terminate the ray cast
        ///     return fraction: clip the ray to this point
        ///     return 1: don't clip the ray and continue
        /// </summary>
        /// <param name="callback">A user implemented callback class.</param>
        /// <param name="point1">The ray starting point.</param>
        /// <param name="point2">The ray ending point.</param>
        public void RayCast(RayCastReportFixtureDelegate callback, Vector2F point1, Vector2F point2)
        {
            RayCastInput input = new RayCastInput();
            input.MaxFraction = 1.0f;
            input.Point1 = point1;
            input.Point2 = point2;

            _rayCastDelegateTmp = callback;
            ContactManager.BroadPhase.RayCast(_rayCastCallbackCache, ref input);
            _rayCastDelegateTmp = null;
        }

        /// <summary>
        ///     Rays the cast callback using the specified ray cast input
        /// </summary>
        /// <param name="rayCastInput">The ray cast input</param>
        /// <param name="proxyId">The proxy id</param>
        /// <returns>The float</returns>
        private float RayCastCallback(ref RayCastInput rayCastInput, int proxyId)
        {
            FixtureProxy proxy = ContactManager.BroadPhase.GetProxy(proxyId);
            Fixture fixture = proxy.Fixture;
            int index = proxy.ChildIndex;
            bool hit = fixture.RayCast(out RayCastOutput output, ref rayCastInput, index);

            if (hit)
            {
                float fraction = output.Fraction;
                Vector2F point = (1.0f - fraction) * rayCastInput.Point1 + fraction * rayCastInput.Point2;
                return _rayCastDelegateTmp(fixture, point, output.Normal, fraction);
            }

            return rayCastInput.MaxFraction;
        }

        /// <summary>
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public void Add(Controller controller)
        {
            if (GetIsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            if (controller == null)
            {
                throw new ArgumentNullException("controller");
            }

            if (controller.World == this)
            {
                throw new ArgumentException("You are adding the same controller more than once.", "controller");
            }

            if (controller.World != null)
            {
                throw new ArgumentException("Controller belongs to another world.", "controller");
            }

            controller.World = this;
            ControllerList.List.Add(controller);
            ControllerList.GenerationStamp++;

            ControllerDelegate controllerAddedHandler = ControllerAdded;
            if (controllerAddedHandler != null)
            {
                controllerAddedHandler(this, controller);
            }
        }

        /// <summary>
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public void Remove(Controller controller)
        {
            if (GetIsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            if (controller == null)
            {
                throw new ArgumentNullException("controller");
            }

            if (controller.World != this)
            {
                throw new ArgumentException("You are removing a controller that is not in the simulation.", "controller");
            }

            controller.World = null;
            ControllerList.List.Remove(controller);
            ControllerList.GenerationStamp++;

            ControllerDelegate controllerRemovedHandler = ControllerRemoved;
            if (controllerRemovedHandler != null)
            {
                controllerRemovedHandler(this, controller);
            }
        }

        /// <summary>
        ///     Tests the point using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <returns>The test point fixture tmp</returns>
        public Fixture TestPoint(Vector2F point)
        {
            Aabb aabb;
            Vector2F d = new Vector2F(SettingEnv.Epsilon, SettingEnv.Epsilon);
            aabb.LowerBound = point - d;
            aabb.UpperBound = point + d;

            _testPointPointTmp = point;
            _testPointFixtureTmp = null;

            // Query the world for overlapping shapes.
            QueryAabb(_testPointDelegateCache, ref aabb);

            return _testPointFixtureTmp;
        }

        /// <summary>
        ///     Describes whether this instance test point callback
        /// </summary>
        /// <param name="fixture">The fixture</param>
        /// <returns>The bool</returns>
        private bool TestPointCallback(Fixture fixture)
        {
            bool inside = fixture.TestPoint(ref _testPointPointTmp);
            if (inside)
            {
                _testPointFixtureTmp = fixture;
                return false;
            }

            // Continue the query.
            return true;
        }

        /// Shift the world origin. Useful for large worlds.
        /// The body shift formula is: position -= newOrigin
        /// @param newOrigin the new origin with respect to the old origin
        /// Warning: Calling this method mid-update might cause a crash.
        public void ShiftOrigin(Vector2F newOrigin)
        {
            foreach (Body b in BodyList)
            {
                b.Xf.P -= newOrigin;
                b.Sweep.C0 -= newOrigin;
                b.Sweep.C -= newOrigin;
            }

            ContactManager.BroadPhase.ShiftOrigin(newOrigin);
        }

        /// <summary>
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public void Clear()
        {
            if (GetIsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            for (int i = BodyList.List.Count - 1; i >= 0; i--)
            {
                Remove(BodyList.List[i]);
            }

            for (int i = ControllerList.List.Count - 1; i >= 0; i--)
            {
                Remove(ControllerList.List[i]);
            }
        }

        /// <summary>
        ///     Creates the body using the specified position
        /// </summary>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public virtual Body CreateBody(Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Body body = new Body();
            body.Position = position;
            body.Rotation = rotation;
            body.GetBodyType = bodyType;


            Add(body);

            return body;
        }

        /// <summary>
        ///     Creates the edge using the specified start
        /// </summary>
        /// <param name="start">The start</param>
        /// <param name="end">The end</param>
        /// <returns>The body</returns>
        public Body CreateEdge(Vector2F start, Vector2F end)
        {
            Body body = CreateBody();

            body.CreateEdge(start, end);
            return body;
        }

        /// <summary>
        ///     Creates the chain shape using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="position">The position</param>
        /// <returns>The body</returns>
        public Body CreateChainShape(Vertices vertices, Vector2F position = new Vector2F())
        {
            Body body = CreateBody(position);

            body.CreateChainShape(vertices);
            return body;
        }

        /// <summary>
        ///     Creates the loop shape using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="position">The position</param>
        /// <returns>The body</returns>
        public Body CreateLoopShape(Vertices vertices, Vector2F position = new Vector2F())
        {
            Body body = CreateBody(position);

            body.CreateLoopShape(vertices);
            return body;
        }

        /// <summary>
        ///     Creates the rectangle using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <exception cref="ArgumentOutOfRangeException">height Height must be more than 0 meters</exception>
        /// <exception cref="ArgumentOutOfRangeException">width Width must be more than 0 meters</exception>
        /// <returns>The body</returns>
        public Body CreateRectangle(float width, float height, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException("width", "Width must be more than 0 meters");
            }

            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("height", "Height must be more than 0 meters");
            }

            Body body = CreateBody(position, rotation, bodyType);

            Vertices rectangleVertices = PolygonTools.CreateRectangle(width / 2, height / 2);
            body.CreatePolygon(rectangleVertices, density);

            return body;
        }

        /// <summary>
        ///     Creates the circle using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateCircle(float radius, float density, Vector2F position = new Vector2F(), BodyType bodyType = BodyType.Static)
        {
            Body body = CreateBody(position, 0, bodyType);
            body.CreateCircle(radius, density);
            return body;
        }

        /// <summary>
        ///     Creates the ellipse using the specified x radius
        /// </summary>
        /// <param name="xRadius">The radius</param>
        /// <param name="yRadius">The radius</param>
        /// <param name="edges">The edges</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateEllipse(float xRadius, float yRadius, int edges, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Body body = CreateBody(position, rotation, bodyType);
            body.CreateEllipse(xRadius, yRadius, edges, density);
            return body;
        }

        /// <summary>
        ///     Creates the polygon using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreatePolygon(Vertices vertices, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Body body = CreateBody(position, rotation, bodyType);
            body.CreatePolygon(vertices, density);
            return body;
        }

        /// <summary>
        ///     Creates the compound polygon using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateCompoundPolygon(List<Vertices> list, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            //We create a single body
            Body body = CreateBody(position, rotation, bodyType);
            body.CreateCompoundPolygon(list, density);
            return body;
        }

        /// <summary>
        ///     Creates the gear using the specified radius
        /// </summary>
        /// <param name="radius">The radius</param>
        /// <param name="numberOfTeeth">The number of teeth</param>
        /// <param name="tipPercentage">The tip percentage</param>
        /// <param name="toothHeight">The tooth height</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateGear(float radius, int numberOfTeeth, float tipPercentage, float toothHeight, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Vertices gearPolygon = PolygonTools.CreateGear(radius, numberOfTeeth, tipPercentage, toothHeight);

            //Gears can in some cases be convex
            if (!gearPolygon.IsConvex())
            {
                //Decompose the gear:
                List<Vertices> list = Triangulate.ConvexPartition(gearPolygon, TriangulationAlgorithm.Earclip);

                return CreateCompoundPolygon(list, density, position, rotation, bodyType);
            }

            return CreatePolygon(gearPolygon, density, position, rotation, bodyType);
        }

        /// <summary>
        ///     Creates the capsule using the specified height
        /// </summary>
        /// <param name="height">The height</param>
        /// <param name="topRadius">The top radius</param>
        /// <param name="topEdges">The top edges</param>
        /// <param name="bottomRadius">The bottom radius</param>
        /// <param name="bottomEdges">The bottom edges</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateCapsule(float height, float topRadius, int topEdges, float bottomRadius, int bottomEdges, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Vertices verts = PolygonTools.CreateCapsule(height, topRadius, topEdges, bottomRadius, bottomEdges);

            //There are too many vertices in the capsule. We decompose it.
            if (verts.Count >= SettingEnv.MaxPolygonVertices)
            {
                List<Vertices> vertList = Triangulate.ConvexPartition(verts, TriangulationAlgorithm.Earclip);
                return CreateCompoundPolygon(vertList, density, position, rotation, bodyType);
            }

            return CreatePolygon(verts, density, position, rotation, bodyType);
        }

        /// <summary>
        ///     Creates the capsule using the specified height
        /// </summary>
        /// <param name="height">The height</param>
        /// <param name="endRadius">The end radius</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateCapsule(float height, float endRadius, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            //Create the middle rectangle
            Vertices rectangle = PolygonTools.CreateRectangle(endRadius, height / 2);

            List<Vertices> list = new List<Vertices>();
            list.Add(rectangle);

            Body body = CreateCompoundPolygon(list, density, position, rotation, bodyType);
            body.CreateCircle(endRadius, density, new Vector2F(0, height / 2));
            body.CreateCircle(endRadius, density, new Vector2F(0, -(height / 2)));

            //Create the two circles
            //CircleShape topCircle = new CircleShape(endRadius, density);
            //topCircle.Position = new Vector2F(0, height / 2);
            //body.CreateFixture(topCircle);

            //CircleShape bottomCircle = new CircleShape(endRadius, density);
            //bottomCircle.Position = new Vector2F(0, -(height / 2));
            //body.CreateFixture(bottomCircle);
            return body;
        }

        /// <summary>
        ///     Creates the rounded rectangle using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="xRadius">The radius</param>
        /// <param name="yRadius">The radius</param>
        /// <param name="segments">The segments</param>
        /// <param name="density">The density</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateRoundedRectangle(float width, float height, float xRadius, float yRadius, int segments, float density, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Vertices verts = PolygonTools.CreateRoundedRectangle(width, height, xRadius, yRadius, segments);

            //There are too many vertices in the capsule. We decompose it.
            if (verts.Count >= SettingEnv.MaxPolygonVertices)
            {
                List<Vertices> vertList = Triangulate.ConvexPartition(verts, TriangulationAlgorithm.Earclip);
                return CreateCompoundPolygon(vertList, density, position, rotation, bodyType);
            }

            return CreatePolygon(verts, density, position, rotation, bodyType);
        }

        /// <summary>
        ///     Creates the line arc using the specified radians
        /// </summary>
        /// <param name="radians">The radians</param>
        /// <param name="sides">The sides</param>
        /// <param name="radius">The radius</param>
        /// <param name="closed">The closed</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateLineArc(float radians, int sides, float radius, bool closed = false, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Body body = CreateBody(position, rotation, bodyType);
            body.CreateLineArc(radians, sides, radius, closed);
            return body;
        }

        /// <summary>
        ///     Creates the solid arc using the specified density
        /// </summary>
        /// <param name="density">The density</param>
        /// <param name="radians">The radians</param>
        /// <param name="sides">The sides</param>
        /// <param name="radius">The radius</param>
        /// <param name="position">The position</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="bodyType">The body type</param>
        /// <returns>The body</returns>
        public Body CreateSolidArc(float density, float radians, int sides, float radius, Vector2F position = new Vector2F(), float rotation = 0, BodyType bodyType = BodyType.Static)
        {
            Body body = CreateBody(position, rotation, bodyType);
            body.CreateSolidArc(density, radians, sides, radius);

            return body;
        }

        /// <summary>
        ///     Creates a chain.
        /// </summary>
        /// <param name="world">The world.</param>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        /// <param name="linkWidth">The width.</param>
        /// <param name="linkHeight">The height.</param>
        /// <param name="numberOfLinks">The number of links.</param>
        /// <param name="linkDensity">The link density.</param>
        /// <param name="attachRopeJoint">
        ///     Creates a rope joint between start and end. This enforces the length of the rope. Said in
        ///     another way: it makes the rope less bouncy.
        /// </param>
        /// <returns></returns>
        public Path CreateChain(Vector2F start, Vector2F end, float linkWidth, float linkHeight, int numberOfLinks, float linkDensity, bool attachRopeJoint)
        {
            Debug.Assert(numberOfLinks >= 2);

            //Chain start / end
            Path path = new Path();
            path.Add(start);
            path.Add(end);

            //A single chainlink
            PolygonShape shape = new PolygonShape(PolygonTools.CreateRectangle(linkWidth, linkHeight), linkDensity);

            //Use PathManager to create all the chainlinks based on the chainlink created before.
            List<Body> chainLinks = PathManager.EvenlyDistributeShapesAlongPath(this, path, shape, BodyType.Dynamic, numberOfLinks);


            //if (fixStart)
            //{
            //    //Fix the first chainlink to the world
            //    JointFactory.CreateFixedRevoluteJoint(this, chainLinks[0], new Vector2F(0, -(linkHeight / 2)),
            //                                          chainLinks[0].Position);
            //}

            //if (fixEnd)
            //{
            //    //Fix the last chainlink to the world
            //    JointFactory.CreateFixedRevoluteJoint(this, chainLinks[chainLinks.Count - 1],
            //                                          new Vector2F(0, (linkHeight / 2)),
            //                                          chainLinks[chainLinks.Count - 1].Position);
            //}

            //Attach all the chainlinks together with a revolute joint
            PathManager.AttachBodiesWithRevoluteJoint(this, chainLinks, new Vector2F(0, -linkHeight), new Vector2F(0, linkHeight), false, false);

            if (attachRopeJoint)
            {
                JointFactory.CreateRopeJoint(this, chainLinks[0], chainLinks[chainLinks.Count - 1], Vector2F.Zero, Vector2F.Zero);
            }

            return path;
        }
    }
}