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
using Alis.Aspect.Logging;
using Alis.Aspect.Math;
using Alis.Aspect.Time;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Controllers;
using Alis.Core.Physic.Dynamics.Joints;
using Alis.Core.Physic.Exception;
using Math = Alis.Aspect.Math.Math;

namespace Alis.Core.Physic
{
    /// <summary>
    ///     The world class manages all physics entities, dynamic simulation,
    ///     and asynchronous queries.
    /// </summary>
    public class World 
    {
        /// <summary>
        ///     The raycast normal
        /// </summary>
        private Vector2 raycastNormal;

        /// <summary>
        ///     Construct a world object.
        /// </summary>
        /// <param name="worldAabb">A bounding box that completely encompasses all your shapes.</param>
        /// <param name="gravity">The world gravity vector.</param>
        /// <param name="doSleep">Improve performance by not simulating inactive bodies.</param>
        public World(Aabb worldAabb, Vector2 gravity, bool doSleep)
        {
            Listener = null;
            BoundaryListener = null;
            Filter = null;
            ContactListener = null;
            DebugDraw = null;

            BodyList = new List<Body>();
            ContactList = new List<Contact>();
            JointList = new List<Joint>();
            ControllerList = new List<Controller>();
            
            ContactCount = 0;

            WarmStarting = true;
            ContinuousPhysics = true;

            AllowSleep = doSleep;
            Gravity = gravity;

            Lock = false;

            InvDt0 = 0.0f;

            ContactManager = new ContactManager();
            ContactManager.World = this;
            BroadPhase = new BroadPhase(worldAabb, ContactManager);

            BodyDef bd = new BodyDef();
            GroundBody = CreateBody(bd);
        }

        /// <summary>
        ///     The allow sleep
        /// </summary>
        public bool AllowSleep { get; }

        /// <summary>
        ///     The contact manager
        /// </summary>
        public ContactManager ContactManager { get; }

        /// <summary>
        ///     The ground body
        /// </summary>
        public Body GroundBody { get; }

        /// <summary>
        ///     The body count
        /// </summary>
        public int BodyCount { get => BodyList.Count;}

        /// <summary>
        ///     The body list
        /// </summary>
        public List<Body> BodyList { get; private set; }

        /// <summary>
        ///     The boundary listener
        /// </summary>
        public BoundaryListener BoundaryListener { get; private set; }

        /// <summary>
        ///     The broad phase
        /// </summary>
        internal BroadPhase BroadPhase { get; set; }

        /// <summary>
        ///     The contact count
        /// </summary>
        internal int ContactCount { get; set; }

        /// <summary>
        ///     The contact filter
        /// </summary>
        internal ContactFilter Filter { get; set; }

        // Do not access

        /// <summary>
        ///     The contact list
        /// </summary>
        internal List<Contact> ContactList { get; set; }

        /// <summary>
        ///     The contact listener
        /// </summary>
        internal IContactListener ContactListener { get; set; }

        // This is for debugging the solver.

        /// <summary>
        ///     The continuous physics
        /// </summary>
        public bool ContinuousPhysics { get; private set; }

        /// <summary>
        ///     The controller count
        /// </summary>
        public int ControllerCount { get; private set; }

        /// <summary>
        ///     The controller list
        /// </summary>
        public List<Controller> ControllerList { get; private set; }

        /// <summary>
        ///     The debug draw
        /// </summary>
        public DebugDraw DebugDraw { get; private set; }

        /// <summary>
        ///     The destruction listener
        /// </summary>
        public DestructionListener Listener { get; private set; }

        // This is used to compute the time step ratio to
        // support a variable time step.

        /// <summary>
        ///     The inv dt0
        /// </summary>
        public float InvDt0 { get; private set; }

        /// <summary>
        ///     The joint count
        /// </summary>
        public int JointCount { get => JointList.Count; }

        /// <summary>
        ///     The joint list
        /// </summary>
        public List<Joint> JointList { get; private set; }

        /// <summary>
        ///     The lock
        /// </summary>
        internal bool Lock { get; set; }

        /// <summary>
        ///     The raycast segment
        /// </summary>
        public Segment RaycastSegment { get; private set; }

        /// <summary>
        ///     The raycast solid shape
        /// </summary>
        public bool RaycastSolidShape { get; private set; }

        /// <summary>
        ///     The raycast user data
        /// </summary>
        public object RaycastUserData { get; private set; }

        // This is for debugging the solver.

        /// <summary>
        ///     The warm starting
        /// </summary>
        public bool WarmStarting { get; private set; }

        /// <summary>
        ///     Get\Set global gravity vector.
        /// </summary>
        public Vector2 Gravity { get; set; }
        
        /// <summary>
        ///     Create a rigid body given a definition. No reference to the definition
        ///     is retained.
        ///     @warning This function is locked during callbacks.
        /// </summary>
        /// <param name="bodyDef"></param>
        /// <returns></returns>
        public Body CreateBody(BodyDef bodyDef)
        {
            if (Lock) throw new LockException();
            Body body = new Body(bodyDef, this);
            BodyList.Add(body);
            return body;
        }

        /// <summary>
        ///     Destroy a rigid body given a definition. No reference to the definition
        ///     is retained. This function is locked during callbacks.
        ///     @warning This automatically deletes all associated shapes and joints.
        ///     @warning This function is locked during callbacks.
        /// </summary>
        /// <param name="body"></param>
        public void DestroyBody(Body body)
        {
            if (Lock) throw new LockException();
            BodyList.Remove(body);
        }

        /// <summary>
        ///     Create a joint to constrain bodies together. No reference to the definition
        ///     is retained. This may cause the connected bodies to cease colliding.
        ///     @warning This function is locked during callbacks.
        /// </summary>
        /// <param name="jointDef"></param>
        /// <returns></returns>
        public Joint CreateJoint(JointDef jointDef)
        {
            if (Lock) throw new LockException();

            Joint joint = Joint.Create(jointDef);
            
            /*
            // Connect to the bodies' doubly linked lists.
            joint.Node1.Joint = joint;
            joint.Node1.Other = joint.Body2;
            joint.Node1.Prev = null;
            joint.Node1.Next = joint.Body1.JointList;
            if (joint.Body1.JointList != null)
            {
                joint.Body1.JointList.Prev = joint.Node1;
            }

            joint.Body1.JointList = joint.Node1;

            joint.Node2.Joint = joint;
            joint.Node2.Other = joint.Body1;
            joint.Node2.Prev = null;
            joint.Node2.Next = joint.Body2.JointList;
            if (joint.Body2.JointList != null)
            {
                joint.Body2.JointList.Prev = joint.Node2;
            }

            joint.Body2.JointList = joint.Node2;

            // If the joint prevents collisions, then reset collision filtering.
            if (jointDef.CollideConnected == false)
            {
                // Reset the proxies on the body with the minimum number of shapes.
                Body b = jointDef.Body1.FixtureCount < jointDef.Body2.FixtureCount ? jointDef.Body1 : jointDef.Body2;
                for (Fixture f = b.FixtureList; f != null; f = f.Next)
                {
                    f.RefilterProxy(BroadPhase, b.GetXForm());
                }
            }*/

            JointList.Add(joint);
            
            return joint;
        }

        /// <summary>
        ///     Destroy a joint. This may cause the connected bodies to begin colliding.
        ///     @warning This function is locked during callbacks.
        /// </summary>
        /// <param name="joint"></param>
        public void DestroyJoint(Joint joint)
        {
            if (Lock) throw new LockException();
            
            JointList.Remove(joint);
            
           /* bool collideConnected = joint.CollideConnected;
            
            // Disconnect from island graph.
            Body body1 = joint.Body1;
            Body body2 = joint.Body2;

            // Wake up connected bodies.
            body1.WakeUp();
            body2.WakeUp();

            // Remove from body 1.
            if (joint.Node1.Prev != null)
            {
                joint.Node1.Prev.Next = joint.Node1.Next;
            }

            if (joint.Node1.Next != null)
            {
                joint.Node1.Next.Prev = joint.Node1.Prev;
            }

            if (joint.Node1 == body1.JointList)
            {
                body1.JointList = joint.Node1.Next;
            }

            joint.Node1.Prev = null;
            joint.Node1.Next = null;

            // Remove from body 2
            if (joint.Node2.Prev != null)
            {
                joint.Node2.Prev.Next = joint.Node2.Next;
            }

            if (joint.Node2.Next != null)
            {
                joint.Node2.Next.Prev = joint.Node2.Prev;
            }

            if (joint.Node2 == body2.JointList)
            {
                body2.JointList = joint.Node2.Next;
            }

            joint.Node2.Prev = null;
            joint.Node2.Next = null;

            Joint.Destroy(joint);

            // If the joint prevents collisions, then reset collision filtering.
            if (collideConnected == false)
            {
                // Reset the proxies on the body with the minimum number of shapes.
                Body b = body1.FixtureCount < body2.FixtureCount ? body1 : body2;
                for (Fixture f = b.FixtureList; f != null; f = f.Next)
                {
                    f.RefilterProxy(BroadPhase, b.GetXForm());
                }
            }*/
        }

        /// <summary>
        ///     Adds the controller using the specified def
        /// </summary>
        /// <param name="controller">The def</param>
        /// <returns>The def</returns>
        public Controller AddController(Controller controller)
        {
            controller.World = this;
            ControllerList.Add(controller);
            return controller;
        }

        /// <summary>
        ///     Removes the controller using the specified controller
        /// </summary>
        /// <param name="controller">The controller</param>
        public void RemoveController(Controller controller)
        {
            ControllerList.Remove(controller);
        }
        
        /// <summary>
        ///     Take a time step. This performs collision detection, integration,
        ///     and constraint solution.
        /// </summary>
        /// <param name="dt">The amount of time to simulate, this should not vary.</param>
        /// <param name="velocityIterations">The velocity iterations.</param>
        /// <param name="positionIteration">The position iteration.</param>
        public void Step(float dt, int velocityIterations, int positionIteration)
        {
            Lock = true;

            TimeStep step = new TimeStep();
            step.Dt = dt;
            step.VelocityIterations = velocityIterations;
            step.PositionIterations = positionIteration;
            if (dt > 0.0f)
            {
                step.InvDt = 1.0f / dt;
            }
            else
            {
                step.InvDt = 0.0f;
            }

            step.DtRatio = InvDt0 * dt;

            step.WarmStarting = WarmStarting;

            // Update contacts.
            ContactManager.Collide();

            // Integrate velocities, solve velocity constraints, and integrate positions.
            if (step.Dt > 0.0f)
            {
                Solve(step);
            }

            // Handle TOI events.
            if (ContinuousPhysics && step.Dt > 0.0f)
            {
                SolveToi(step);
            }
            
            InvDt0 = step.InvDt;
            Lock = false;
        }

        /// Query the world for all shapes that potentially overlap the
        /// provided AABB. You provide a shape pointer buffer of specified
        /// size. The number of shapes found is returned.
        /// @param aabb the query box.
        /// @param shapes a user allocated shape pointer array of size maxCount (or greater).
        /// @param maxCount the capacity of the shapes array.
        /// @return the number of shapes found in aabb.
        public int Query(Aabb aabb, Fixture[] fixtures, int maxCount)
        {
            return BroadPhase.Query(aabb, new object[maxCount], maxCount);
        }

        /// <summary>
        ///     Query the world for all shapes that intersect a given segment. You provide a shap
        ///     pointer buffer of specified size. The number of shapes found is returned, and the buffer
        ///     is filled in order of intersection.
        /// </summary>
        /// <param name="segment">
        ///     Defines the begin and end point of the ray cast, from p1 to p2.
        ///     Use Segment.Extend to create (semi-)infinite rays.
        /// </param>
        /// <param name="fixtures">The fixtures.</param>
        /// <param name="maxCount">The capacity of the shapes array.</param>
        /// <param name="solidShapes">Determines if shapes that the ray starts in are counted as hits.</param>
        /// <param name="userData">
        ///     Passed through the worlds contact filter, with method RayCollide. This can be used to filter
        ///     valid shapes.
        /// </param>
        /// <returns>The number of shapes found</returns>
        public int Raycast(Segment segment, out Fixture[] fixtures, int maxCount, bool solidShapes, object userData)
        {
            RaycastSegment = segment;
            RaycastUserData = userData;
            RaycastSolidShape = solidShapes;

            object[] results = new object[maxCount];
            fixtures = new Fixture[maxCount];
            int count = BroadPhase.QuerySegment(segment, results, maxCount, RaycastSortKey);

            for (int i = 0; i < count; ++i)
            {
                fixtures[i] = (Fixture)results[i];
            }

            return count;
        }

        /// <summary>
        ///     Performs a raycast as with Raycast, finding the first intersecting shape.
        /// </summary>
        /// <param name="segment">
        ///     Defines the begin and end point of the ray cast, from p1 to p2.
        ///     Use Segment.Extend to create (semi-)infinite rays.
        /// </param>
        /// <param name="lambda">
        ///     Returns the hit fraction. You can use this to compute the contact point
        ///     p = (1 - lambda) * segment.p1 + lambda * segment.p2.
        /// </param>
        /// <param name="normal">Returns the normal at the contact point. If there is no intersection, the normal is not set.</param>
        /// <param name="solidShapes">Determines if shapes that the ray starts in are counted as hits.</param>
        /// <param name="userData"></param>
        /// <returns>Returns the colliding shape shape, or null if not found.</returns>
        public Fixture RaycastOne(Segment segment, out float lambda, out Vector2 normal, bool solidShapes,
            object userData)
        {
            int maxCount = 1;
            Fixture[] fixture;
            lambda = 0.0f;
            normal = new Vector2();

            int count = Raycast(segment, out fixture, maxCount, solidShapes, userData);

            if (count == 0)
            {
                return null;
            }

            Box2DxDebug.Assert(count == 1);

            //Redundantly do TestSegment a second time, as the previous one's results are inaccessible

            fixture[0].TestSegment(out lambda, out normal, segment, 1);
            //We already know it returns true
            return fixture[0];
        }

        // Find islands, integrate and solve constraints, solve position constraints
        /// <summary>
        ///     Solves the step
        /// </summary>
        /// <param name="step">The step</param>
        private void Solve(TimeStep step)
        {
            // Step all controlls
            for (int i =0; i < ControllerList.Count; i++) {
                ControllerList[i].Step(step);
            }

            // Size the island for the worst case.
            Island island = new Island(BodyCount, ContactCount, JointCount, ContactListener);

            // Clear all the island flags.
            for (int i = 0; i < BodyList.Count; i++)
            {
                BodyList[i].Flags &= ~BodyFlags.Island;
            }

            for (int i = 0; i < ContactList.Count; i++)
            {
                ContactList[i].Flags &= ~Contact.CollisionFlags.Island;
            }

            for (int i = 0; i < JointList.Count; i++)
            {
                JointList[i].IslandFlag = false;
            }

            // Build and simulate all awake islands.
            int stackSize = BodyCount;
            {
                Body[] stack = new Body[stackSize];

                for (int j = 0; j < BodyList.Count; j++)
                {
                    if ((BodyList[j].Flags & (BodyFlags.Island | BodyFlags.Sleep | BodyFlags.Frozen)) != 0)
                    {
                        continue;
                    }

                    if (BodyList[j].IsStatic())
                    {
                        continue;
                    }

                    // Reset island and stack.
                    island.Clear();
                    int stackCount = 0;
                    stack[stackCount++] = BodyList[j];
                    BodyList[j].Flags |= BodyFlags.Island;

                    // Perform a depth first search (DFS) on the constraint graph.
                    while (stackCount > 0)
                    {
                        // Grab the next body off the stack and add it to the island.
                        Body b = stack[--stackCount];
                        island.Add(b);

                        // Make sure the body is awake.
                        b.Flags &= ~BodyFlags.Sleep;

                        // To keep islands as small as possible, we don't
                        // propagate islands across static bodies.
                        if (b.IsStatic())
                        {
                            continue;
                        }

                        // Search all contacts connected to this body.
                        for (ContactEdge cn = b.ContactList; cn != null; cn = cn.Next)
                        {
                            // Has this contact already been added to an island?
                            if ((cn.Contact.Flags &
                                 (Contact.CollisionFlags.Island | Contact.CollisionFlags.NonSolid)) != 0)
                            {
                                continue;
                            }

                            // Is this contact touching?
                            if ((cn.Contact.Flags & Contact.CollisionFlags.Touch) == 0)
                            {
                                continue;
                            }

                            island.Add(cn.Contact);
                            cn.Contact.Flags |= Contact.CollisionFlags.Island;

                            Body other = cn.Other;

                            // Was the other body already added to this island?
                            if ((other.Flags & BodyFlags.Island) != 0)
                            {
                                continue;
                            }

                            Box2DxDebug.Assert(stackCount < stackSize);
                            stack[stackCount++] = other;
                            other.Flags |= BodyFlags.Island;
                        }

                        // Search all joints connect to this body.
                        for (JointEdge jn = b.JointList; jn != null; jn = jn.Next)
                        {
                            if (jn.Joint.IslandFlag)
                            {
                                continue;
                            }

                            island.Add(jn.Joint);
                            jn.Joint.IslandFlag = true;

                            Body other = jn.Other;
                            if ((other.Flags & BodyFlags.Island) != 0)
                            {
                                continue;
                            }

                            Box2DxDebug.Assert(stackCount < stackSize);
                            stack[stackCount++] = other;
                            other.Flags |= BodyFlags.Island;
                        }
                    }

                    island.Solve(step, Gravity, AllowSleep);

                    // Post solve cleanup.
                    for (int i = 0; i < island.BodyCount; ++i)
                    {
                        // Allow static bodies to participate in other islands.
                        Body b = island.Bodies[i];
                        if (b.IsStatic())
                        {
                            b.Flags &= ~BodyFlags.Island;
                        }
                    }
                }

                stack = null;
            }

            // Synchronize shapes, check for out of range bodies.
            for (int i = 0; i < BodyList.Count; i++)
            {
                if ((BodyList[i].Flags & (BodyFlags.Sleep | BodyFlags.Frozen)) != 0)
                {
                    continue;
                }

                if (BodyList[i].IsStatic())
                {
                    continue;
                }

                // Update shapes (for broad-phase). If the shapes go out of
                // the world AABB then shapes and contacts may be destroyed,
                // including contacts that are
                bool inRange = BodyList[i].SynchronizeFixtures();

                // Did the body's shapes leave the world?
                if (inRange == false && BoundaryListener != null)
                {
                    BoundaryListener.Violation(BodyList[i]);
                }
            }

            // Commit shape proxy movements to the broad-phase so that new contacts are created.
            // Also, some contacts can be destroyed.
            BroadPhase.Commit();
        }

        // Find TOI contacts and solve them.
        /// <summary>
        ///     Solves the toi using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        private void SolveToi(TimeStep step)
        {
            // Reserve an island and a queue for TOI island solution.
            Island island = new Island(BodyCount, Settings.MaxToiContactsPerIsland, Settings.MaxToiJointsPerIsland,
                ContactListener);

            //Simple one pass queue
            //Relies on the fact that we're only making one pass
            //through and each body can only be pushed/popped once.
            //To push: 
            //  queue[queueStart+queueSize++] = newElement;
            //To pop: 
            //	poppedElement = queue[queueStart++];
            //  --queueSize;
            int queueCapacity = BodyCount;
            Body[] queue = new Body[queueCapacity];

            for (int i = 0; i < BodyList.Count; i++)
            {
                BodyList[i].Flags &= ~BodyFlags.Island;
                BodyList[i].Sweep.T0 = 0.0f;
            }

            /*for (Body b = BodyList; b != null; b = b.Next)
            {
                b.Flags &= ~BodyFlags.Island;
                b.Sweep.T0 = 0.0f;
            }*/

            for (int i = 0; i < ContactList.Count; i++)
            {
                // Invalidate TOI
                ContactList[i].Flags &= ~(Contact.CollisionFlags.Toi | Contact.CollisionFlags.Island);
            }

            for (int j = 0; j < JointList.Count; j++)
            {
                JointList[j].IslandFlag = false;
            }

            // Find TOI events and solve them.
            for (;;)
            {
                // Find the first TOI.
                Contact minContact = null;
                float minToi = 1.0f;

                for (int i = 0; i < ContactList.Count; i++)
                {
                    if ((int)(ContactList[i].Flags & (Contact.CollisionFlags.Slow | Contact.CollisionFlags.NonSolid)) == 1)
                    {
                        continue;
                    }

                    // TODO_ERIN keep a counter on the contact, only respond to M TOIs per contact.

                    float toi = 1.0f;
                    if ((int)(ContactList[i].Flags & Contact.CollisionFlags.Toi) == 1)
                    {
                        // This contact has a valid cached TOI.
                        toi = ContactList[i].Toi;
                    }
                    else
                    {
                        // Compute the TOI for this contact.
                        Fixture s1 = ContactList[i].FixtureA;
                        Fixture s2 = ContactList[i].FixtureB;
                        Body b1 = s1.Body;
                        Body b2 = s2.Body;

                        if ((b1.IsStatic() || b1.IsSleeping()) && (b2.IsStatic() || b2.IsSleeping()))
                        {
                            continue;
                        }

                        // Put the sweeps onto the same time interval.
                        float t0 = b1.Sweep.T0;

                        if (b1.Sweep.T0 < b2.Sweep.T0)
                        {
                            t0 = b2.Sweep.T0;
                            b1.Sweep.Advance(t0);
                        }
                        else if (b2.Sweep.T0 < b1.Sweep.T0)
                        {
                            t0 = b1.Sweep.T0;
                            b2.Sweep.Advance(t0);
                        }

                        Box2DxDebug.Assert(t0 < 1.0f);

                        // Compute the time of impact.
                        toi = ContactList[i].ComputeToi(b1.Sweep, b2.Sweep);
                        //b2TimeOfImpact(c->m_fixtureA->GetShape(), b1->m_sweep, c->m_fixtureB->GetShape(), b2->m_sweep);

                        Box2DxDebug.Assert(0.0f <= toi && toi <= 1.0f);

                        // If the TOI is in range ...
                        if (0.0f < toi && toi < 1.0f)
                        {
                            // Interpolate on the actual range.
                            toi = Math.Min((1.0f - toi) * t0 + toi, 1.0f);
                        }


                        ContactList[i].Toi = toi;
                        ContactList[i].Flags |= Contact.CollisionFlags.Toi;
                    }

                    if (Settings.FltEpsilon < toi && toi < minToi)
                    {
                        // This is the minimum TOI found so far.
                        minContact = ContactList[i];
                        minToi = toi;
                    }
                }

                if (minContact == null || 1.0f - 100.0f * Settings.FltEpsilon < minToi)
                {
                    // No more TOI events. Done!
                    break;
                }

                // Advance the bodies to the TOI.
                Fixture f1 = minContact.FixtureA;
                Fixture f2 = minContact.FixtureB;
                Body b3 = f1.Body;
                Body b4 = f2.Body;
                b3.Advance(minToi);
                b4.Advance(minToi);

                // The TOI contact likely has some new contact points.
                minContact.Update(ContactListener);
                minContact.Flags &= ~Contact.CollisionFlags.Toi;

                if ((minContact.Flags & Contact.CollisionFlags.Touch) == 0)
                {
                    // This shouldn't happen. Numerical error?
                    //b2Assert(false);
                    continue;
                }

                // Build the TOI island. We need a dynamic seed.
                Body seed = b3;
                if (seed.IsStatic())
                {
                    seed = b4;
                }

                // Reset island and queue.
                island.Clear();

                int queueStart = 0; // starting index for queue
                int queueSize = 0; // elements in queue
                queue[queueStart + queueSize++] = seed;
                seed.Flags |= BodyFlags.Island;

                // Perform a breadth first search (BFS) on the contact/joint graph.
                while (queueSize > 0)
                {
                    // Grab the next body off the stack and add it to the island.
                    Body b = queue[queueStart++];
                    --queueSize;

                    island.Add(b);

                    // Make sure the body is awake.
                    b.Flags &= ~BodyFlags.Sleep;

                    // To keep islands as small as possible, we don't
                    // propagate islands across static bodies.
                    if (b.IsStatic())
                    {
                        continue;
                    }

                    // Search all contacts connected to this body.
                    for (ContactEdge cEdge = b.ContactList; cEdge != null; cEdge = cEdge.Next)
                    {
                        // Does the TOI island still have space for contacts?
                        if (island.ContactCount == island.ContactCapacity)
                        {
                            continue;
                        }

                        // Has this contact already been added to an island? Skip slow or non-solid contacts.
                        if ((int)(cEdge.Contact.Flags & (Contact.CollisionFlags.Island | Contact.CollisionFlags.Slow |
                                                         Contact.CollisionFlags.NonSolid)) != 0)
                        {
                            continue;
                        }

                        // Is this contact touching? For performance we are not updating this contact.
                        if ((cEdge.Contact.Flags & Contact.CollisionFlags.Touch) == 0)
                        {
                            continue;
                        }

                        island.Add(cEdge.Contact);
                        cEdge.Contact.Flags |= Contact.CollisionFlags.Island;

                        // Update other body.
                        Body other = cEdge.Other;

                        // Was the other body already added to this island?
                        if ((int)(other.Flags & BodyFlags.Island) == 1)
                        {
                            continue;
                        }

                        // March forward, this can do no harm since this is the min TOI.
                        if (other.IsStatic() == false)
                        {
                            other.Advance(minToi);
                            other.WakeUp();
                        }

                        //Box2DXDebug.Assert(queueStart + queueSize < queueCapacity);
                        queue[queueStart + queueSize] = other;
                        ++queueSize;
                        other.Flags |= BodyFlags.Island;
                    }

                    for (JointEdge jEdge = b.JointList; jEdge != null; jEdge = jEdge.Next)
                    {
                        if (island.JointCount == island.JointCapacity)
                        {
                            continue;
                        }

                        if (jEdge.Joint.IslandFlag)
                        {
                            continue;
                        }

                        island.Add(jEdge.Joint);

                        jEdge.Joint.IslandFlag = true;

                        Body other = jEdge.Other;

                        if ((int)(other.Flags & BodyFlags.Island) == 1)
                        {
                            continue;
                        }

                        if (!other.IsStatic())
                        {
                            other.Advance(minToi);
                            other.WakeUp();
                        }

                        //Box2DXDebug.Assert(queueStart + queueSize < queueCapacity);
                        queue[queueStart + queueSize] = other;
                        ++queueSize;
                        other.Flags |= BodyFlags.Island;
                    }
                }

                TimeStep subStep;
                subStep.WarmStarting = false;
                subStep.Dt = (1.0f - minToi) * step.Dt;
                subStep.InvDt = 1.0f / subStep.Dt;
                subStep.DtRatio = 0.0f;
                subStep.VelocityIterations = step.VelocityIterations;
                subStep.PositionIterations = step.PositionIterations;

                island.SolveToi(ref subStep);

                // Post solve cleanup.
                for (int i = 0; i < island.BodyCount; ++i)
                {
                    // Allow bodies to participate in future TOI islands.
                    Body b = island.Bodies[i];
                    b.Flags &= ~BodyFlags.Island;

                    if ((int)(b.Flags & (BodyFlags.Sleep | BodyFlags.Frozen)) == 1)
                    {
                        continue;
                    }

                    if (b.IsStatic())
                    {
                        continue;
                    }

                    // Update fixtures (for broad-phase). If the fixtures go out of
                    // the world AABB then fixtures and contacts may be destroyed,
                    // including contacts that are
                    bool inRange = b.SynchronizeFixtures();

                    // Did the body's fixtures leave the world?
                    if (inRange == false && BoundaryListener != null)
                    {
                        BoundaryListener.Violation(b);
                    }

                    // Invalidate all contact TOIs associated with this body. Some of these
                    // may not be in the island because they were not touching.
                    for (ContactEdge cn = b.ContactList; cn != null; cn = cn.Next)
                    {
                        cn.Contact.Flags &= ~Contact.CollisionFlags.Toi;
                    }
                }

                for (int i = 0; i < island.ContactCount; ++i)
                {
                    // Allow contacts to participate in future TOI islands.
                    Contact c = island.Contacts[i];
                    c.Flags &= ~(Contact.CollisionFlags.Toi | Contact.CollisionFlags.Island);
                }

                for (int i = 0; i < island.JointCount; ++i)
                {
                    // Allow joints to participate in future TOI islands.
                    Joint j = island.Joints[i];
                    j.IslandFlag = false;
                }

                // Commit fixture proxy movements to the broad-phase so that new contacts are created.
                // Also, some contacts can be destroyed.
                BroadPhase.Commit();
            }

            queue = null;
        }
        
        /// <summary>
        ///     Raycasts the sort key using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The lambda</returns>
        private static float RaycastSortKey(object data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            
            Fixture fixture = data as Fixture;
            Body body = fixture.Body;
            World world = body.GetWorld();

            if (world.Filter != null && !world.Filter.RayCollide(world.RaycastUserData, fixture))
            {
                return -1;
            }

            float lambda;

            SegmentCollide collide =
                fixture.TestSegment(out lambda, out world.raycastNormal, world.RaycastSegment, 1);

            if (world.RaycastSolidShape && collide == SegmentCollide.MissCollide)
            {
                return -1;
            }

            if (!world.RaycastSolidShape && collide != SegmentCollide.HitCollide)
            {
                return -1;
            }

            return lambda;
        }
    }
}