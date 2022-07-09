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
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Controllers;
using Alis.Core.Physic.Dynamics.Joints;
using Math = Alis.Core.Physic.Common.Math;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The world class manages all physics entities, dynamic simulation,
    ///     and asynchronous queries.
    /// </summary>
    public class World : IDisposable
    {
        /// <summary>
        ///     The allow sleep
        /// </summary>
        private readonly bool _allowSleep;

        /// <summary>
        ///     The body count
        /// </summary>
        private int _bodyCount;

        /// <summary>
        ///     The body list
        /// </summary>
        private Body _bodyList;

        /// <summary>
        ///     The boundary listener
        /// </summary>
        private BoundaryListener _boundaryListener;

        /// <summary>
        ///     The broad phase
        /// </summary>
        internal BroadPhase _broadPhase;

        /// <summary>
        ///     The contact count
        /// </summary>
        internal int _contactCount;

        /// <summary>
        ///     The contact filter
        /// </summary>
        internal ContactFilter _contactFilter;

        // Do not access
        /// <summary>
        ///     The contact list
        /// </summary>
        internal Contact _contactList;

        /// <summary>
        ///     The contact listener
        /// </summary>
        internal ContactListener _contactListener;

        /// <summary>
        ///     The contact manager
        /// </summary>
        private readonly ContactManager _contactManager;

        // This is for debugging the solver.
        /// <summary>
        ///     The continuous physics
        /// </summary>
        private bool _continuousPhysics;

        /// <summary>
        ///     The controller count
        /// </summary>
        private int _controllerCount;

        /// <summary>
        ///     The controller list
        /// </summary>
        private Controller _controllerList;

        /// <summary>
        ///     The debug draw
        /// </summary>
        private DebugDraw _debugDraw;

        /// <summary>
        ///     The destruction listener
        /// </summary>
        private DestructionListener _destructionListener;

        /// <summary>
        ///     The gravity
        /// </summary>
        private Vec2 _gravity;

        /// <summary>
        ///     The ground body
        /// </summary>
        private readonly Body _groundBody;

        // This is used to compute the time step ratio to
        // support a variable time step.
        /// <summary>
        ///     The inv dt0
        /// </summary>
        private float _inv_dt0;

        /// <summary>
        ///     The joint count
        /// </summary>
        private int _jointCount;

        /// <summary>
        ///     The joint list
        /// </summary>
        private Joint _jointList;

        /// <summary>
        ///     The lock
        /// </summary>
        internal bool _lock;

        /// <summary>
        ///     The raycast normal
        /// </summary>
        private Vec2 _raycastNormal;

        /// <summary>
        ///     The raycast segment
        /// </summary>
        private Segment _raycastSegment;

        /// <summary>
        ///     The raycast solid shape
        /// </summary>
        private bool _raycastSolidShape;

        /// <summary>
        ///     The raycast user data
        /// </summary>
        private object _raycastUserData;

        // This is for debugging the solver.
        /// <summary>
        ///     The warm starting
        /// </summary>
        private bool _warmStarting;

        /// <summary>
        ///     Construct a world object.
        /// </summary>
        /// <param name="worldAABB">A bounding box that completely encompasses all your shapes.</param>
        /// <param name="gravity">The world gravity vector.</param>
        /// <param name="doSleep">Improve performance by not simulating inactive bodies.</param>
        public World(Aabb worldAABB, Vec2 gravity, bool doSleep)
        {
            _destructionListener = null;
            _boundaryListener = null;
            _contactFilter = null;
            _contactListener = null;
            _debugDraw = null;

            _bodyList = null;
            _contactList = null;
            _jointList = null;

            _bodyCount = 0;
            _contactCount = 0;
            _jointCount = 0;

            _warmStarting = true;
            _continuousPhysics = true;

            _allowSleep = doSleep;
            _gravity = gravity;

            _lock = false;

            _inv_dt0 = 0.0f;

            _contactManager = new ContactManager();
            _contactManager.World = this;
            _broadPhase = new BroadPhase(worldAABB, _contactManager);

            BodyDef bd = new BodyDef();
            _groundBody = CreateBody(bd);
        }

        /// <summary>
        ///     Get\Set global gravity vector.
        /// </summary>
        public Vec2 Gravity
        {
            get { return _gravity; }
            set { _gravity = value; }
        }

        /// <summary>
        ///     Destruct the world. All physics entities are destroyed.
        /// </summary>
        public void Dispose()
        {
            DestroyBody(_groundBody);
            if (_broadPhase is IDisposable)
                (_broadPhase as IDisposable).Dispose();
            _broadPhase = null;
        }

        /// <summary>
        ///     Register a destruction listener.
        /// </summary>
        /// <param name="listener"></param>
        public void SetDestructionListener(DestructionListener listener)
        {
            _destructionListener = listener;
        }

        /// <summary>
        ///     Register a broad-phase boundary listener.
        /// </summary>
        /// <param name="listener"></param>
        public void SetBoundaryListener(BoundaryListener listener)
        {
            _boundaryListener = listener;
        }

        /// <summary>
        ///     Register a contact filter to provide specific control over collision.
        ///     Otherwise the default filter is used (b2_defaultFilter).
        /// </summary>
        /// <param name="filter"></param>
        public void SetContactFilter(ContactFilter filter)
        {
            _contactFilter = filter;
        }

        /// <summary>
        ///     Register a contact event listener
        /// </summary>
        /// <param name="listener"></param>
        public void SetContactListener(ContactListener listener)
        {
            _contactListener = listener;
        }

        /// <summary>
        ///     Register a routine for debug drawing. The debug draw functions are called
        ///     inside the World.Step method, so make sure your renderer is ready to
        ///     consume draw commands when you call Step().
        /// </summary>
        /// <param name="debugDraw"></param>
        public void SetDebugDraw(DebugDraw debugDraw)
        {
            _debugDraw = debugDraw;
        }

        /// <summary>
        ///     Create a rigid body given a definition. No reference to the definition
        ///     is retained.
        ///     @warning This function is locked during callbacks.
        /// </summary>
        /// <param name="def"></param>
        /// <returns></returns>
        public Body CreateBody(BodyDef def)
        {
            Box2DXDebug.Assert(_lock == false);
            if (_lock)
            {
                return null;
            }

            Body b = new Body(def, this);

            // Add to world doubly linked list.
            b.Prev = null;
            b.Next = _bodyList;
            if (_bodyList != null)
            {
                _bodyList.Prev = b;
            }

            _bodyList = b;
            ++_bodyCount;

            return b;
        }

        /// <summary>
        ///     Destroy a rigid body given a definition. No reference to the definition
        ///     is retained. This function is locked during callbacks.
        ///     @warning This automatically deletes all associated shapes and joints.
        ///     @warning This function is locked during callbacks.
        /// </summary>
        /// <param name="b"></param>
        public void DestroyBody(Body b)
        {
            Box2DXDebug.Assert(_bodyCount > 0);
            Box2DXDebug.Assert(_lock == false);
            if (_lock)
            {
                return;
            }

            // Delete the attached joints.
            JointEdge jn = null;
            if (b.JointList != null)
                jn = b.JointList;
            while (jn != null)
            {
                JointEdge jn0 = jn;
                jn = jn.Next;

                if (_destructionListener != null)
                {
                    _destructionListener.SayGoodbye(jn0.Joint);
                }

                DestroyJoint(jn0.Joint);
            }

            //Detach controllers attached to this body
            ControllerEdge ce = b.ControllerList;
            while (ce != null)
            {
                ControllerEdge ce0 = ce;
                ce = ce.NextController;

                ce0.Controller.RemoveBody(b);
            }

            // Delete the attached fixtures. This destroys broad-phase
            // proxies and pairs, leading to the destruction of contacts.
            Fixture f = b.FixtureList;
            while (f != null)
            {
                Fixture f0 = f;
                f = f.Next;

                if (_destructionListener != null)
                {
                    _destructionListener.SayGoodbye(f0);
                }

                f0.Destroy(_broadPhase);
            }

            // Remove world body list.
            if (b.Prev != null)
            {
                b.Prev.Next = b.Next;
            }

            if (b.Next != null)
            {
                b.Next.Prev = b.Prev;
            }

            if (b == _bodyList)
            {
                _bodyList = b.Next;
            }

            --_bodyCount;
            if (b is IDisposable)
                (b as IDisposable).Dispose();
            b = null;
        }

        /// <summary>
        ///     Create a joint to constrain bodies together. No reference to the definition
        ///     is retained. This may cause the connected bodies to cease colliding.
        ///     @warning This function is locked during callbacks.
        /// </summary>
        /// <param name="def"></param>
        /// <returns></returns>
        public Joint CreateJoint(JointDef def)
        {
            Box2DXDebug.Assert(_lock == false);

            Joint j = Joint.Create(def);

            // Connect to the world list.
            j.Prev = null;
            j.Next = _jointList;
            if (_jointList != null)
            {
                _jointList.Prev = j;
            }

            _jointList = j;
            ++_jointCount;

            // Connect to the bodies' doubly linked lists.
            j.Node1.Joint = j;
            j.Node1.Other = j.Body2;
            j.Node1.Prev = null;
            j.Node1.Next = j.Body1.JointList;
            if (j.Body1.JointList != null)
                j.Body1.JointList.Prev = j.Node1;
            j.Body1.JointList = j.Node1;

            j.Node2.Joint = j;
            j.Node2.Other = j.Body1;
            j.Node2.Prev = null;
            j.Node2.Next = j.Body2.JointList;
            if (j.Body2.JointList != null)
                j.Body2.JointList.Prev = j.Node2;
            j.Body2.JointList = j.Node2;

            // If the joint prevents collisions, then reset collision filtering.
            if (def.CollideConnected == false)
            {
                // Reset the proxies on the body with the minimum number of shapes.
                Body b = def.Body1.FixtureCount < def.Body2.FixtureCount ? def.Body1 : def.Body2;
                for (Fixture f = b.FixtureList; f != null; f = f.Next)
                {
                    f.RefilterProxy(_broadPhase, b.GetXForm());
                }
            }

            return j;
        }

        /// <summary>
        ///     Destroy a joint. This may cause the connected bodies to begin colliding.
        ///     @warning This function is locked during callbacks.
        /// </summary>
        /// <param name="j"></param>
        public void DestroyJoint(Joint j)
        {
            Box2DXDebug.Assert(_lock == false);

            bool collideConnected = j.CollideConnected;

            // Remove from the doubly linked list.
            if (j.Prev != null)
            {
                j.Prev.Next = j.Next;
            }

            if (j.Next != null)
            {
                j.Next.Prev = j.Prev;
            }

            if (j == _jointList)
            {
                _jointList = j.Next;
            }

            // Disconnect from island graph.
            Body body1 = j.Body1;
            Body body2 = j.Body2;

            // Wake up connected bodies.
            body1.WakeUp();
            body2.WakeUp();

            // Remove from body 1.
            if (j.Node1.Prev != null)
            {
                j.Node1.Prev.Next = j.Node1.Next;
            }

            if (j.Node1.Next != null)
            {
                j.Node1.Next.Prev = j.Node1.Prev;
            }

            if (j.Node1 == body1.JointList)
            {
                body1.JointList = j.Node1.Next;
            }

            j.Node1.Prev = null;
            j.Node1.Next = null;

            // Remove from body 2
            if (j.Node2.Prev != null)
            {
                j.Node2.Prev.Next = j.Node2.Next;
            }

            if (j.Node2.Next != null)
            {
                j.Node2.Next.Prev = j.Node2.Prev;
            }

            if (j.Node2 == body2.JointList)
            {
                body2.JointList = j.Node2.Next;
            }

            j.Node2.Prev = null;
            j.Node2.Next = null;

            Joint.Destroy(j);

            Box2DXDebug.Assert(_jointCount > 0);
            --_jointCount;

            // If the joint prevents collisions, then reset collision filtering.
            if (collideConnected == false)
            {
                // Reset the proxies on the body with the minimum number of shapes.
                Body b = body1.FixtureCount < body2.FixtureCount ? body1 : body2;
                for (Fixture f = b.FixtureList; f != null; f = f.Next)
                {
                    f.RefilterProxy(_broadPhase, b.GetXForm());
                }
            }
        }

        /// <summary>
        ///     Adds the controller using the specified def
        /// </summary>
        /// <param name="def">The def</param>
        /// <returns>The def</returns>
        public Controller AddController(Controller def)
        {
            def.Next = _controllerList;
            def.Prev = null;
            if (_controllerList != null)
                _controllerList.Prev = def;
            _controllerList = def;
            ++_controllerCount;

            def.World = this;

            return def;
        }

        /// <summary>
        ///     Removes the controller using the specified controller
        /// </summary>
        /// <param name="controller">The controller</param>
        public void RemoveController(Controller controller)
        {
            Box2DXDebug.Assert(_controllerCount > 0);
            if (controller.Next != null)
                controller.Next.Prev = controller.Prev;
            if (controller.Prev != null)
                controller.Prev.Next = controller.Next;
            if (controller == _controllerList)
                _controllerList = controller.Next;
            --_controllerCount;
        }

        /// <summary>
        ///     The world provides a single static ground body with no collision shapes.
        ///     You can use this to simplify the creation of joints and static shapes.
        /// </summary>
        /// <returns></returns>
        public Body GetGroundBody()
        {
            return _groundBody;
        }

        /// <summary>
        ///     Get the world body list. With the returned body, use Body.GetNext to get
        ///     the next body in the world list. A null body indicates the end of the list.
        /// </summary>
        /// <returns>The head of the world body list.</returns>
        public Body GetBodyList()
        {
            return _bodyList;
        }

        /// <summary>
        ///     Get the world joint list. With the returned joint, use Joint.GetNext to get
        ///     the next joint in the world list. A null joint indicates the end of the list.
        /// </summary>
        /// <returns>The head of the world joint list.</returns>
        public Joint GetJointList()
        {
            return _jointList;
        }

        /// <summary>
        ///     Gets the controller list
        /// </summary>
        /// <returns>The controller list</returns>
        public Controller GetControllerList()
        {
            return _controllerList;
        }

        /// <summary>
        ///     Gets the controller count
        /// </summary>
        /// <returns>The controller count</returns>
        public int GetControllerCount()
        {
            return _controllerCount;
        }

        /// <summary>
        ///     Re-filter a fixture. This re-runs contact filtering on a fixture.
        /// </summary>
        public void Refilter(Fixture fixture)
        {
            Box2DXDebug.Assert(_lock == false);
            fixture.RefilterProxy(_broadPhase, fixture.Body.GetXForm());
        }

        /// <summary>
        ///     Enable/disable warm starting. For testing.
        /// </summary>
        public void SetWarmStarting(bool flag)
        {
            _warmStarting = flag;
        }

        /// <summary>
        ///     Enable/disable continuous physics. For testing.
        /// </summary>
        public void SetContinuousPhysics(bool flag)
        {
            _continuousPhysics = flag;
        }

        /// <summary>
        ///     Perform validation of internal data structures.
        /// </summary>
        public void Validate()
        {
            _broadPhase.Validate();
        }

        /// <summary>
        ///     Get the number of broad-phase proxies.
        /// </summary>
        public int GetProxyCount()
        {
            return _broadPhase.ProxyCount;
        }

        /// <summary>
        ///     Get the number of broad-phase pairs.
        /// </summary>
        /// <returns></returns>
        public int GetPairCount()
        {
            return _broadPhase.PairManager.PairCount;
        }

        /// <summary>
        ///     Get the number of bodies.
        /// </summary>
        /// <returns></returns>
        public int GetBodyCount()
        {
            return _bodyCount;
        }

        /// <summary>
        ///     Get the number joints.
        /// </summary>
        /// <returns></returns>
        public int GetJointCount()
        {
            return _jointCount;
        }

        /// <summary>
        ///     Get the number of contacts (each may have 0 or more contact points).
        /// </summary>
        /// <returns></returns>
        public int GetContactCount()
        {
            return _contactCount;
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
            _lock = true;

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

            step.DtRatio = _inv_dt0 * dt;

            step.WarmStarting = _warmStarting;

            // Update contacts.
            _contactManager.Collide();

            // Integrate velocities, solve velocity constraints, and integrate positions.
            if (step.Dt > 0.0f)
            {
                Solve(step);
            }

            // Handle TOI events.
            if (_continuousPhysics && step.Dt > 0.0f)
            {
                SolveTOI(step);
            }

            // Draw debug information.
            DrawDebugData();

            _inv_dt0 = step.InvDt;
            _lock = false;
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
            //using (object[] results = new object[maxCount])
            {
                object[] results = new object[maxCount];

                int count = _broadPhase.Query(aabb, results, maxCount);

                for (int i = 0; i < count; ++i)
                {
                    fixtures[i] = (Fixture) results[i];
                }

                results = null;
                return count;
            }
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
            _raycastSegment = segment;
            _raycastUserData = userData;
            _raycastSolidShape = solidShapes;

            object[] results = new object[maxCount];
            fixtures = new Fixture[maxCount];
            int count = _broadPhase.QuerySegment(segment, results, maxCount, RaycastSortKey);

            for (int i = 0; i < count; ++i)
            {
                fixtures[i] = (Fixture) results[i];
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
        public Fixture RaycastOne(Segment segment, out float lambda, out Vec2 normal, bool solidShapes, object userData)
        {
            int maxCount = 1;
            Fixture[] fixture;
            lambda = 0.0f;
            normal = new Vec2();

            int count = Raycast(segment, out fixture, maxCount, solidShapes, userData);

            if (count == 0)
                return null;

            Box2DXDebug.Assert(count == 1);

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
            for (Controller controller = _controllerList; controller != null; controller = controller.Next)
            {
                controller.Step(step);
            }

            // Size the island for the worst case.
            Island island = new Island(_bodyCount, _contactCount, _jointCount, _contactListener);

            // Clear all the island flags.
            for (Body b = _bodyList; b != null; b = b.Next)
            {
                b.Flags &= ~BodyFlags.Island;
            }

            for (Contact c = _contactList; c != null; c = c.Next)
            {
                c.Flags &= ~Contact.CollisionFlags.Island;
            }

            for (Joint j = _jointList; j != null; j = j.Next)
            {
                j.IslandFlag = false;
            }

            // Build and simulate all awake islands.
            int stackSize = _bodyCount;
            {
                Body[] stack = new Body[stackSize];

                for (Body seed = _bodyList; seed != null; seed = seed.Next)
                {
                    if ((seed.Flags & (BodyFlags.Island | BodyFlags.Sleep | BodyFlags.Frozen)) != 0)
                    {
                        continue;
                    }

                    if (seed.IsStatic())
                    {
                        continue;
                    }

                    // Reset island and stack.
                    island.Clear();
                    int stackCount = 0;
                    stack[stackCount++] = seed;
                    seed.Flags |= BodyFlags.Island;

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

                            Box2DXDebug.Assert(stackCount < stackSize);
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

                            Box2DXDebug.Assert(stackCount < stackSize);
                            stack[stackCount++] = other;
                            other.Flags |= BodyFlags.Island;
                        }
                    }

                    island.Solve(step, _gravity, _allowSleep);

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
            for (Body b = _bodyList; b != null; b = b.GetNext())
            {
                if ((b.Flags & (BodyFlags.Sleep | BodyFlags.Frozen)) != 0)
                {
                    continue;
                }

                if (b.IsStatic())
                {
                    continue;
                }

                // Update shapes (for broad-phase). If the shapes go out of
                // the world AABB then shapes and contacts may be destroyed,
                // including contacts that are
                bool inRange = b.SynchronizeFixtures();

                // Did the body's shapes leave the world?
                if (inRange == false && _boundaryListener != null)
                {
                    _boundaryListener.Violation(b);
                }
            }

            // Commit shape proxy movements to the broad-phase so that new contacts are created.
            // Also, some contacts can be destroyed.
            _broadPhase.Commit();
        }

        // Find TOI contacts and solve them.
        /// <summary>
        ///     Solves the toi using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        private void SolveTOI(TimeStep step)
        {
            // Reserve an island and a queue for TOI island solution.
            Island island = new Island(_bodyCount, Settings.MaxToiContactsPerIsland, Settings.MaxToiJointsPerIsland,
                _contactListener);

            //Simple one pass queue
            //Relies on the fact that we're only making one pass
            //through and each body can only be pushed/popped once.
            //To push: 
            //  queue[queueStart+queueSize++] = newElement;
            //To pop: 
            //	poppedElement = queue[queueStart++];
            //  --queueSize;
            int queueCapacity = _bodyCount;
            Body[] queue = new Body[queueCapacity];

            for (Body b = _bodyList; b != null; b = b.Next)
            {
                b.Flags &= ~BodyFlags.Island;
                b.Sweep.T0 = 0.0f;
            }

            for (Contact c = _contactList; c != null; c = c.Next)
            {
                // Invalidate TOI
                c.Flags &= ~(Contact.CollisionFlags.Toi | Contact.CollisionFlags.Island);
            }

            for (Joint j = _jointList; j != null; j = j.Next)
            {
                j.IslandFlag = false;
            }

            // Find TOI events and solve them.
            for (;;)
            {
                // Find the first TOI.
                Contact minContact = null;
                float minTOI = 1.0f;

                for (Contact c = _contactList; c != null; c = c.Next)
                {
                    if ((int) (c.Flags & (Contact.CollisionFlags.Slow | Contact.CollisionFlags.NonSolid)) == 1)
                    {
                        continue;
                    }

                    // TODO_ERIN keep a counter on the contact, only respond to M TOIs per contact.

                    float toi = 1.0f;
                    if ((int) (c.Flags & Contact.CollisionFlags.Toi) == 1)
                    {
                        // This contact has a valid cached TOI.
                        toi = c.Toi;
                    }
                    else
                    {
                        // Compute the TOI for this contact.
                        Fixture s1 = c.FixtureA;
                        Fixture s2 = c.FixtureB;
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

                        Box2DXDebug.Assert(t0 < 1.0f);

                        // Compute the time of impact.
                        toi = c.ComputeTOI(b1.Sweep, b2.Sweep);
                        //b2TimeOfImpact(c->m_fixtureA->GetShape(), b1->m_sweep, c->m_fixtureB->GetShape(), b2->m_sweep);

                        Box2DXDebug.Assert(0.0f <= toi && toi <= 1.0f);

                        // If the TOI is in range ...
                        if (0.0f < toi && toi < 1.0f)
                        {
                            // Interpolate on the actual range.
                            toi = Math.Min((1.0f - toi) * t0 + toi, 1.0f);
                        }


                        c.Toi = toi;
                        c.Flags |= Contact.CollisionFlags.Toi;
                    }

                    if (Settings.FltEpsilon < toi && toi < minTOI)
                    {
                        // This is the minimum TOI found so far.
                        minContact = c;
                        minTOI = toi;
                    }
                }

                if (minContact == null || 1.0f - 100.0f * Settings.FltEpsilon < minTOI)
                {
                    // No more TOI events. Done!
                    break;
                }

                // Advance the bodies to the TOI.
                Fixture f1 = minContact.FixtureA;
                Fixture f2 = minContact.FixtureB;
                Body b3 = f1.Body;
                Body b4 = f2.Body;
                b3.Advance(minTOI);
                b4.Advance(minTOI);

                // The TOI contact likely has some new contact points.
                minContact.Update(_contactListener);
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
                        if ((int) (cEdge.Contact.Flags & (Contact.CollisionFlags.Island | Contact.CollisionFlags.Slow |
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
                        if ((int) (other.Flags & BodyFlags.Island) == 1)
                        {
                            continue;
                        }

                        // March forward, this can do no harm since this is the min TOI.
                        if (other.IsStatic() == false)
                        {
                            other.Advance(minTOI);
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

                        if ((int) (other.Flags & BodyFlags.Island) == 1)
                        {
                            continue;
                        }

                        if (!other.IsStatic())
                        {
                            other.Advance(minTOI);
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
                subStep.Dt = (1.0f - minTOI) * step.Dt;
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

                    if ((int) (b.Flags & (BodyFlags.Sleep | BodyFlags.Frozen)) == 1)
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
                    if (inRange == false && _boundaryListener != null)
                    {
                        _boundaryListener.Violation(b);
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
                _broadPhase.Commit();
            }

            queue = null;
        }

        /// <summary>
        ///     Draws the joint using the specified joint
        /// </summary>
        /// <param name="joint">The joint</param>
        private void DrawJoint(Joint joint)
        {
            Body b1 = joint.GetBody1();
            Body b2 = joint.GetBody2();
            XForm xf1 = b1.GetXForm();
            XForm xf2 = b2.GetXForm();
            Vec2 x1 = xf1.Position;
            Vec2 x2 = xf2.Position;
            Vec2 p1 = joint.Anchor1;
            Vec2 p2 = joint.Anchor2;

            Color color = new Color(0.5f, 0.8f, 0.8f);

            switch (joint.GetType())
            {
                case JointType.DistanceJoint:
                    _debugDraw.DrawSegment(p1, p2, color);
                    break;

                case JointType.PulleyJoint:
                {
                    PulleyJoint pulley = (PulleyJoint) joint;
                    Vec2 s1 = pulley.GroundAnchorX1;
                    Vec2 s2 = pulley.GroundAnchorX2;
                    _debugDraw.DrawSegment(s1, p1, color);
                    _debugDraw.DrawSegment(s2, p2, color);
                    _debugDraw.DrawSegment(s1, s2, color);
                }
                    break;

                case JointType.MouseJoint:
                    // don't draw this
                    break;

                default:
                    _debugDraw.DrawSegment(x1, p1, color);
                    _debugDraw.DrawSegment(p1, p2, color);
                    _debugDraw.DrawSegment(x2, p2, color);
                    break;
            }
        }

        /// <summary>
        ///     Draws the fixture using the specified fixture
        /// </summary>
        /// <param name="fixture">The fixture</param>
        /// <param name="xf">The xf</param>
        /// <param name="color">The color</param>
        /// <param name="core">The core</param>
        private void DrawFixture(Fixture fixture, XForm xf, Color color, bool core)
        {
            Color coreColor = new Color(0.9f, 0.6f, 0.6f);

            switch (fixture.ShapeType)
            {
                case ShapeType.CircleShape:
                {
                    CircleShape circle = (CircleShape) fixture.Shape;

                    Vec2 center = Math.Mul(xf, circle.Position);
                    float radius = circle.Radius;
                    Vec2 axis = xf.R.col1;

                    _debugDraw.DrawSolidCircle(center, radius, axis, color);
                }
                    break;

                case ShapeType.PolygonShape:
                {
                    PolygonShape poly = (PolygonShape) fixture.Shape;
                    int vertexCount = poly.VertexCount;
                    Vec2[] localVertices = poly.Vertices;

                    Box2DXDebug.Assert(vertexCount <= Settings.MaxPolygonVertices);
                    Vec2[] vertices = new Vec2[Settings.MaxPolygonVertices];

                    for (int i = 0; i < vertexCount; ++i)
                    {
                        vertices[i] = Math.Mul(xf, localVertices[i]);
                    }

                    _debugDraw.DrawSolidPolygon(vertices, vertexCount, color);
                }
                    break;

                case ShapeType.EdgeShape:
                {
                    EdgeShape edge = (EdgeShape) fixture.Shape;

                    _debugDraw.DrawSegment(Math.Mul(xf, edge.Vertex1), Math.Mul(xf, edge.Vertex2), color);
                }
                    break;
            }
        }

        /// <summary>
        ///     Draws the debug data
        /// </summary>
        private void DrawDebugData()
        {
            if (_debugDraw == null)
            {
                return;
            }

            DebugDraw.DrawFlags flags = _debugDraw.Flags;

            if ((flags & DebugDraw.DrawFlags.Shape) != 0)
            {
                bool core = (flags & DebugDraw.DrawFlags.CoreShape) == DebugDraw.DrawFlags.CoreShape;

                for (Body b = _bodyList; b != null; b = b.GetNext())
                {
                    XForm xf = b.GetXForm();
                    for (Fixture f = b.GetFixtureList(); f != null; f = f.Next)
                    {
                        if (b.IsStatic())
                        {
                            DrawFixture(f, xf, new Color(0.5f, 0.9f, 0.5f), core);
                        }
                        else if (b.IsSleeping())
                        {
                            DrawFixture(f, xf, new Color(0.5f, 0.5f, 0.9f), core);
                        }
                        else
                        {
                            DrawFixture(f, xf, new Color(0.9f, 0.9f, 0.9f), core);
                        }
                    }
                }
            }

            if ((flags & DebugDraw.DrawFlags.Joint) != 0)
            {
                for (Joint j = _jointList; j != null; j = j.GetNext())
                {
                    if (j.GetType() != JointType.MouseJoint)
                    {
                        DrawJoint(j);
                    }
                }
            }

            if ((flags & DebugDraw.DrawFlags.Controller) != 0)
            {
                for (Controller c = _controllerList; c != null; c = c.GetNext())
                {
                    c.Draw(_debugDraw);
                }
            }

            if ((flags & DebugDraw.DrawFlags.Pair) != 0)
            {
                BroadPhase bp = _broadPhase;
                Vec2 invQ = new Vec2();
                invQ.Set(1.0f / bp.QuantizationFactor.X, 1.0f / bp.QuantizationFactor.Y);
                Color color = new Color(0.9f, 0.9f, 0.3f);

                for (int i = 0; i < PairManager.TableCapacity; ++i)
                {
                    ushort index = bp.PairManager.HashTable[i];
                    while (index != PairManager.NullPair)
                    {
                        Pair pair = bp.PairManager.Pairs[index];
                        Proxy p1 = bp.ProxyPool[pair.ProxyId1];
                        Proxy p2 = bp.ProxyPool[pair.ProxyId2];

                        Aabb b1 = new Aabb(), b2 = new Aabb();
                        b1.LowerBound.X = bp.WorldAabb.LowerBound.X + invQ.X * bp.Bounds[0][p1.LowerBounds[0]].Value;
                        b1.LowerBound.Y = bp.WorldAabb.LowerBound.Y + invQ.Y * bp.Bounds[1][p1.LowerBounds[1]].Value;
                        b1.UpperBound.X = bp.WorldAabb.LowerBound.X + invQ.X * bp.Bounds[0][p1.UpperBounds[0]].Value;
                        b1.UpperBound.Y = bp.WorldAabb.LowerBound.Y + invQ.Y * bp.Bounds[1][p1.UpperBounds[1]].Value;
                        b2.LowerBound.X = bp.WorldAabb.LowerBound.X + invQ.X * bp.Bounds[0][p2.LowerBounds[0]].Value;
                        b2.LowerBound.Y = bp.WorldAabb.LowerBound.Y + invQ.Y * bp.Bounds[1][p2.LowerBounds[1]].Value;
                        b2.UpperBound.X = bp.WorldAabb.LowerBound.X + invQ.X * bp.Bounds[0][p2.UpperBounds[0]].Value;
                        b2.UpperBound.Y = bp.WorldAabb.LowerBound.Y + invQ.Y * bp.Bounds[1][p2.UpperBounds[1]].Value;

                        Vec2 x1 = 0.5f * (b1.LowerBound + b1.UpperBound);
                        Vec2 x2 = 0.5f * (b2.LowerBound + b2.UpperBound);

                        _debugDraw.DrawSegment(x1, x2, color);

                        index = pair.Next;
                    }
                }
            }

            if ((flags & DebugDraw.DrawFlags.Aabb) != 0)
            {
                BroadPhase bp = _broadPhase;
                Vec2 worldLower = bp.WorldAabb.LowerBound;
                Vec2 worldUpper = bp.WorldAabb.UpperBound;

                Vec2 invQ = new Vec2();
                invQ.Set(1.0f / bp.QuantizationFactor.X, 1.0f / bp.QuantizationFactor.Y);
                Color color = new Color(0.9f, 0.3f, 0.9f);
                for (int i = 0; i < Settings.MaxProxies; ++i)
                {
                    Proxy p = bp.ProxyPool[i];
                    if (p.IsValid == false)
                    {
                        continue;
                    }

                    Aabb b = new Aabb();
                    b.LowerBound.X = worldLower.X + invQ.X * bp.Bounds[0][p.LowerBounds[0]].Value;
                    b.LowerBound.Y = worldLower.Y + invQ.Y * bp.Bounds[1][p.LowerBounds[1]].Value;
                    b.UpperBound.X = worldLower.X + invQ.X * bp.Bounds[0][p.UpperBounds[0]].Value;
                    b.UpperBound.Y = worldLower.Y + invQ.Y * bp.Bounds[1][p.UpperBounds[1]].Value;

                    Vec2[] vs1 = new Vec2[4];
                    vs1[0].Set(b.LowerBound.X, b.LowerBound.Y);
                    vs1[1].Set(b.UpperBound.X, b.LowerBound.Y);
                    vs1[2].Set(b.UpperBound.X, b.UpperBound.Y);
                    vs1[3].Set(b.LowerBound.X, b.UpperBound.Y);

                    _debugDraw.DrawPolygon(vs1, 4, color);
                }

                Vec2[] vs = new Vec2[4];
                vs[0].Set(worldLower.X, worldLower.Y);
                vs[1].Set(worldUpper.X, worldLower.Y);
                vs[2].Set(worldUpper.X, worldUpper.Y);
                vs[3].Set(worldLower.X, worldUpper.Y);
                _debugDraw.DrawPolygon(vs, 4, new Color(0.3f, 0.9f, 0.9f));
            }

            if ((flags & DebugDraw.DrawFlags.CenterOfMass) != 0)
            {
                for (Body b = _bodyList; b != null; b = b.GetNext())
                {
                    XForm xf = b.GetXForm();
                    xf.Position = b.GetWorldCenter();
                    _debugDraw.DrawXForm(xf);
                }
            }
        }

        //Is it safe to pass private static function pointers?
        /// <summary>
        ///     Raycasts the sort key using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The lambda</returns>
        private static float RaycastSortKey(object data)
        {
            Fixture fixture = data as Fixture;
            Box2DXDebug.Assert(fixture != null);
            Body body = fixture.Body;
            World world = body.GetWorld();

            if (world._contactFilter != null && !world._contactFilter.RayCollide(world._raycastUserData, fixture))
                return -1;

            float lambda;

            SegmentCollide collide =
                fixture.TestSegment(out lambda, out world._raycastNormal, world._raycastSegment, 1);

            if (world._raycastSolidShape && collide == SegmentCollide.MissCollide)
                return -1;
            if (!world._raycastSolidShape && collide != SegmentCollide.HitCollide)
                return -1;

            return lambda;
        }

        /// <summary>
        ///     Describes whether this instance in range
        /// </summary>
        /// <param name="aabb">The aabb</param>
        /// <returns>The bool</returns>
        public bool InRange(Aabb aabb)
        {
            return _broadPhase.InRange(aabb);
        }
    }
}