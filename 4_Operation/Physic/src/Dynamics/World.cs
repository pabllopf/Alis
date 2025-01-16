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
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joints;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The world class manages all physics entities, dynamic simulation,
    ///     and asynchronous queries.
    /// </summary>
    public partial class World
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
        ///     The world has new fixture
        /// </summary>
        internal bool WorldHasNewFixture;

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
        ///     Initializes a new instance of the <see cref="World" /> class.
        /// </summary>
        public World()
        {
            Island = new Island();
            Enabled = true;
            BodyList = new BodyCollection(this);
            JointList = new JointCollection(this);
            ControllerList = new ControllerCollection(this);

            _queryCallbackCache = QueryAabbCallback;
            _rayCastCallbackCache = RayCastCallback;
            _testPointDelegateCache = TestPointCallback;


            ContactManager = new ContactManager(new DynamicTreeBroadPhase());
            Gravity = new Vector2F(0f, -9.80665f);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="World" /> class.
        /// </summary>
        /// <param name="gravity">The gravity.</param>
        public World(Vector2F gravity) : this() => Gravity = gravity;

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
        public Vector2F Gravity
        {
            get => _gravity;
            set
            {
                if (IsLocked)
                {
                    throw new InvalidOperationException("The World is locked.");
                }

                _gravity = value;
            }
        }

        /// <summary>
        ///     Is the world locked (in the middle of a time step).
        /// </summary>
        public bool IsLocked { get; private set; }

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
        public bool Enabled { get; set; }

        /// <summary>
        ///     Gets the value of the island
        /// </summary>
        public Island Island { get; }

        /// <summary>
        ///     Solves the step
        /// </summary>
        /// <param name="step">The step</param>
        private void Solve(ref TimeStep step)
        {
            // Size the island for the worst case.
            Island.Reset(BodyList.Count,
                ContactManager.ContactCount,
                JointList.Count,
                ContactManager);

            // Clear all the island flags.
            foreach (Body b in BodyList)
            {
                b._island = false;
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

            for (int index = BodyList._list.Count - 1; index >= 0; index--)
            {
                Body seed = BodyList._list[index];

                if (seed._island)
                {
                    continue;
                }

                if (seed.Awake == false || seed.Enabled == false)
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
                _stack[stackCount++] = seed;

                seed._island = true;

                // Perform a depth first search (DFS) on the constraint graph.
                while (stackCount > 0)
                {
                    // Grab the next body off the stack and add it to the island.
                    Body b = _stack[--stackCount];
                    Debug.Assert(b.Enabled);
                    Island.Add(b);

                    // Make sure the body is awake.
                    b.Awake = true;

                    // To keep islands as small as possible, we don't
                    // propagate islands across static bodies.
                    if (b.BodyType == BodyType.Static)
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
                        bool sensorA = contact.FixtureA.IsSensor;
                        bool sensorB = contact.FixtureB.IsSensor;
                        if (sensorA || sensorB)
                        {
                            continue;
                        }

                        Island.Add(contact);
                        contact.IslandFlag = true;

                        Body other = ce.Other;

                        // Was the other body already added to this island?
                        if (other._island)
                        {
                            continue;
                        }

                        Debug.Assert(stackCount < stackSize);
                        _stack[stackCount++] = other;

                        other._island = true;
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

                            Island.Add(je.Joint);
                            je.Joint.IslandFlag = true;

                            if (other._island)
                            {
                                continue;
                            }

                            Debug.Assert(stackCount < stackSize);
                            _stack[stackCount++] = other;

                            other._island = true;
                        }
                        else
                        {
                            Island.Add(je.Joint);
                            je.Joint.IslandFlag = true;
                        }
                    }
                }

                Island.Solve(ref step, ref _gravity);

                // Post solve cleanup.
                for (int i = 0; i < Island.BodyCount; ++i)
                {
                    // Allow static bodies to participate in other islands.
                    Body b = Island.Bodies[i];
                    if (b.BodyType == BodyType.Static)
                    {
                        b._island = false;
                    }
                }
            }

            foreach (Body b in BodyList)
            {
                // If a body was not in an island then it did not move.
                if (!b._island)
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
        }

        /// <summary>
        ///     Solves the toi using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        /// <param name="iterations">The iterations</param>
        private void SolveToi(ref TimeStep step, ref SolverIterations iterations)
        {
            Island.Reset(2 * SettingEnv.MaxToiContacts, SettingEnv.MaxToiContacts, 0, ContactManager);

            if (_stepComplete)
            {
                for (int i = 0; i < BodyList._list.Count; i++)
                {
                    BodyList._list[i]._island = false;
                    BodyList._list[i]._sweep.Alpha0 = 0.0f;
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
                        if (fA.IsSensor || fB.IsSensor)
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
                        if ((activeA == false) && (activeB == false))
                        {
                            continue;
                        }

                        bool collideA = (bA.IsBullet || typeA != BodyType.Dynamic) && !bA.IgnoreCCD;
                        bool collideB = (bB.IsBullet || typeB != BodyType.Dynamic) && !bB.IgnoreCCD;

                        // Are these two non-bullet dynamic bodies?
                        if ((collideA == false) && (collideB == false))
                        {
                            continue;
                        }

                        // Compute the TOI for this contact.
                        // Put the sweeps onto the same time interval.
                        float alpha0 = bA._sweep.Alpha0;

                        if (bA._sweep.Alpha0 < bB._sweep.Alpha0)
                        {
                            alpha0 = bB._sweep.Alpha0;
                            bA._sweep.Advance(alpha0);
                        }
                        else if (bB._sweep.Alpha0 < bA._sweep.Alpha0)
                        {
                            alpha0 = bA._sweep.Alpha0;
                            bB._sweep.Advance(alpha0);
                        }

                        Debug.Assert(alpha0 < 1.0f);

                        // Compute the time of impact in interval [0, minTOI]
                        _input.ProxyA = new DistanceProxy(fA.Shape, c.ChildIndexA);
                        _input.ProxyB = new DistanceProxy(fB.Shape, c.ChildIndexB);
                        _input.SweepA = bA._sweep;
                        _input.SweepB = bB._sweep;
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
                Body bA0 = fA1.Body;
                Body bB0 = fB1.Body;

                Sweep backup1 = bA0._sweep;
                Sweep backup2 = bB0._sweep;

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
                    bA0._sweep = backup1;
                    bB0._sweep = backup2;
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

                bA0._island = true;
                bB0._island = true;
                minContact.IslandFlag = true;

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
                                (body.IsBullet == false) && (other.IsBullet == false))
                            {
                                continue;
                            }

                            // Skip sensors.
                            if (contact.FixtureA.IsSensor || contact.FixtureB.IsSensor)
                            {
                                continue;
                            }

                            // Tentatively advance the body to the TOI.
                            Sweep backup = other._sweep;
                            if (!other._island)
                            {
                                other.Advance(minAlpha);
                            }

                            // Update the contact points
                            contact.Update(ContactManager);

                            // Was the contact disabled by the user?
                            if (contact.Enabled == false)
                            {
                                other._sweep = backup;
                                other.SynchronizeTransform();
                                continue;
                            }

                            // Are there contact points?
                            if (contact.IsTouching == false)
                            {
                                other._sweep = backup;
                                other.SynchronizeTransform();
                                continue;
                            }

                            // Add the contact to the island
                            contact.IslandFlag = true;
                            Island.Add(contact);

                            // Has the other body already been added to the island?
                            if (other._island)
                            {
                                continue;
                            }

                            // Add the other body to the island.
                            other._island = true;

                            if (other.BodyType != BodyType.Static)
                            {
                                other.Awake = true;
                            }

                            Island.Add(other);
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
                Island.SolveTOI(ref subStep, bA0.IslandIndex, bB0.IslandIndex);

                // Reset island flags and synchronize broad-phase proxies.
                for (int i = 0; i < Island.BodyCount; ++i)
                {
                    Body body = Island.Bodies[i];
                    body._island = false;

                    if (body.BodyType != BodyType.Dynamic)
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
            if (IsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            if (body._world == this)
            {
                throw new ArgumentException("You are adding the same body more than once.", "body");
            }

            if (body._world != null)
            {
                throw new ArgumentException("body belongs to another world.", "body");
            }

            body._world = this;
            BodyList._list.Add(body);
            BodyList._generationStamp++;


            // Update transform
            body.SetTransformIgnoreContacts(ref body._xf.p, body.Rotation);

            // Create proxies
            if (Enabled)
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
                for (int i = 0; i < body.FixtureList._list.Count; i++)
                {
                    fixtureAddedHandler(this, body, body.FixtureList._list[i]);
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
            if (IsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            if (body.World != this)
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
            body.onCollisionEventHandler = null;
            body.onSeparationEventHandler = null;

            // Delete the attached fixtures. This destroys broad-phase proxies.
            body.DestroyProxies();
            FixtureDelegate fixtureRemovedHandler = FixtureRemoved;
            if (fixtureRemovedHandler != null)
            {
                for (int i = 0; i < body.FixtureList._list.Count; i++)
                {
                    fixtureRemovedHandler(this, body, body.FixtureList._list[i]);
                }
            }

            body._world = null;
            BodyList._list.Remove(body);
            BodyList._generationStamp++;

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
            if (IsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            if (joint == null)
            {
                throw new ArgumentNullException("joint");
            }

            if (joint._world == this)
            {
                throw new ArgumentException("You are adding the same joint more than once.", "joint");
            }

            if (joint._world != null)
            {
                throw new ArgumentException("joint belongs to another world.", "joint");
            }

            // Connect to the world list.
            joint._world = this;
            JointList._list.Add(joint);
            JointList._generationStamp++;

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
            if (IsLocked)
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
            joint._world = null;
            JointList._list.Remove(joint);
            JointList._generationStamp++;

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
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public void Step(float dt, ref SolverIterations iterations)
        {
            if (IsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            if (!Enabled)
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

            IsLocked = true;
            try
            {
                //Update controllers
                for (int i = 0; i < ControllerList._list.Count; i++)
                {
                    ControllerList._list[i].Update(dt);
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
                IsLocked = false;
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
            for (int i = 0; i < BodyList._list.Count; i++)
            {
                Body body = BodyList._list[i];
                body.Force = Vector2F.Zero;
                body._torque = 0.0f;
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
            if (IsLocked)
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
            ControllerList._list.Add(controller);
            ControllerList._generationStamp++;

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
            if (IsLocked)
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
            ControllerList._list.Remove(controller);
            ControllerList._generationStamp++;

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
                b._xf.p -= newOrigin;
                b._sweep.C0 -= newOrigin;
                b._sweep.C -= newOrigin;
            }

            ContactManager.BroadPhase.ShiftOrigin(newOrigin);
        }

        /// <summary>
        ///     Warning: This method is locked during callbacks.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when the world is Locked/Stepping.</exception>
        public void Clear()
        {
            if (IsLocked)
            {
                throw new InvalidOperationException("The World is locked.");
            }

            for (int i = BodyList._list.Count - 1; i >= 0; i--)
            {
                Remove(BodyList._list[i]);
            }

            for (int i = ControllerList._list.Count - 1; i >= 0; i--)
            {
                Remove(ControllerList._list[i]);
            }
        }
    }
}