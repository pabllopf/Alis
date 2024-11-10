﻿// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Island.cs
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
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joints;


namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     This is an internal class.
    /// </summary>
    public class Island
    {
        /// <summary>
        /// The linear sleep tolerance
        /// </summary>
        private const float LinTolSqr = Settings.LinearSleepTolerance * Settings.LinearSleepTolerance;
        /// <summary>
        /// The angular sleep tolerance
        /// </summary>
        private const float AngTolSqr = Settings.AngularSleepTolerance * Settings.AngularSleepTolerance;
        /// <summary>
        /// The contact manager
        /// </summary>
        private ContactManager _contactManager;
        /// <summary>
        /// The contacts
        /// </summary>
        private Contact[] _contacts;
        /// <summary>
        /// The contact solver
        /// </summary>
        private readonly ContactSolver _contactSolver = new ContactSolver();
        /// <summary>
        /// The joints
        /// </summary>
        private Joint[] _joints;
        /// <summary>
        /// The locks
        /// </summary>
        internal int[] _locks;
        /// <summary>
        /// The positions
        /// </summary>
        internal SolverPosition[] _positions;

        /// <summary>
        /// The velocities
        /// </summary>
        internal SolverVelocity[] _velocities;
        /// <summary>
        /// The stopwatch
        /// </summary>
        private readonly Stopwatch _watch = new Stopwatch();

        /// <summary>
        /// The bodies
        /// </summary>
        public Body[] Bodies;

        /// <summary>
        /// The body capacity
        /// </summary>
        public int BodyCapacity;
        /// <summary>
        /// The body count
        /// </summary>
        public int BodyCount;
        /// <summary>
        /// The contact capacity
        /// </summary>
        public int ContactCapacity;
        /// <summary>
        /// The contact count
        /// </summary>
        public int ContactCount;
        /// <summary>
        /// The joint capacity
        /// </summary>
        public int JointCapacity;
        /// <summary>
        /// The joint count
        /// </summary>
        public int JointCount;
        /// <summary>
        /// The joint update time
        /// </summary>
        public TimeSpan JointUpdateTime;

        /// <summary>
        /// Resets the body capacity
        /// </summary>
        /// <param name="bodyCapacity">The body capacity</param>
        /// <param name="contactCapacity">The contact capacity</param>
        /// <param name="jointCapacity">The joint capacity</param>
        /// <param name="contactManager">The contact manager</param>
        public void Reset(int bodyCapacity, int contactCapacity, int jointCapacity, ContactManager contactManager)
        {
            BodyCapacity = bodyCapacity;
            ContactCapacity = contactCapacity;
            JointCapacity = jointCapacity;
            BodyCount = 0;
            ContactCount = 0;
            JointCount = 0;

            _contactManager = contactManager;

            if (Bodies == null || Bodies.Length < bodyCapacity)
            {
                int newBodyBufferCapacity = Math.Max(bodyCapacity, 32);
                newBodyBufferCapacity = (newBodyBufferCapacity + 31) & ~31; // grow in chunks of 32.
                Bodies = new Body[newBodyBufferCapacity];
                _velocities = new SolverVelocity[newBodyBufferCapacity];
                _positions = new SolverPosition[newBodyBufferCapacity];
                _locks = new int[newBodyBufferCapacity];
            }

            if (_contacts == null || _contacts.Length < contactCapacity)
            {
                int newContactBufferCapacity = Math.Max(contactCapacity, 32);
                newContactBufferCapacity = newContactBufferCapacity + ((newContactBufferCapacity * 2) >> 4); // grow by x1.125f
                newContactBufferCapacity = (newContactBufferCapacity + 31) & ~31; // grow in chunks of 32.
                _contacts = new Contact[newContactBufferCapacity];
            }

            if (_joints == null || _joints.Length < jointCapacity)
            {
                int newJointBufferCapacity = Math.Max(jointCapacity, 32);
                newJointBufferCapacity = (newJointBufferCapacity + 31) & ~31; // grow in chunks of 32.
                _joints = new Joint[newJointBufferCapacity];
            }
        }

        /// <summary>
        /// Clears this instance
        /// </summary>
        public void Clear()
        {
            BodyCount = 0;
            ContactCount = 0;
            JointCount = 0;
        }

        /// <summary>
        /// Solves the step
        /// </summary>
        /// <param name="step">The step</param>
        /// <param name="gravity">The gravity</param>
        internal void Solve(ref TimeStep step, ref Vector2 gravity)
        {
            float h = step.dt;

            // Integrate velocities and apply damping. Initialize the body state.
            for (int i = 0; i < BodyCount; ++i)
            {
                Body b = Bodies[i];

                Vector2 c = b._sweep.C;
                float a = b._sweep.A;
                Vector2 v = b._linearVelocity;
                float w = b._angularVelocity;

                // Store positions for continuous collision.
                b._sweep.C0 = b._sweep.C;
                b._sweep.A0 = b._sweep.A;

                if (b.BodyType == BodyType.Dynamic)
                {
                    // Integrate velocities.

                    // FPE: Only apply gravity if the body wants it.
                    if (b.IgnoreGravity)
                        v += h * (b._invMass * b._force);
                    else
                        v += h * (gravity + b._invMass * b._force);

                    w += h * b._invI * b._torque;

                    // Apply damping.
                    // ODE: dv/dt + c * v = 0
                    // Solution: v(t) = v0 * exp(-c * t)
                    // Time step: v(t + dt) = v0 * exp(-c * (t + dt)) = v0 * exp(-c * t) * exp(-c * dt) = v * exp(-c * dt)
                    // v2 = exp(-c * dt) * v1
                    // Taylor expansion:
                    // v2 = (1.0f - c * dt) * v1
                    v *= MathUtils.Clamp(1.0f - h * b.LinearDamping, 0.0f, 1.0f);
                    w *= MathUtils.Clamp(1.0f - h * b.AngularDamping, 0.0f, 1.0f);
                }

                _positions[i].c = c;
                _positions[i].a = a;
                _velocities[i].v = v;
                _velocities[i].w = w;
            }

            // Solver data
            SolverData solverData = new SolverData();
            solverData.step = step;
            solverData.positions = _positions;
            solverData.velocities = _velocities;
            solverData.locks = _locks;

            _contactSolver.Reset(ref step, ContactCount, _contacts, _positions, _velocities,
                _locks, _contactManager.VelocityConstraintsMultithreadThreshold, _contactManager.PositionConstraintsMultithreadThreshold);
            _contactSolver.InitializeVelocityConstraints();

            if (step.warmStarting)
            {
                _contactSolver.WarmStart();
            }

            if (Settings.EnableDiagnostics)
                _watch.Start();

            for (int i = 0; i < JointCount; ++i)
            {
                if (_joints[i].Enabled)
                    _joints[i].InitVelocityConstraints(ref solverData);
            }

            if (Settings.EnableDiagnostics)
                _watch.Stop();

            // Solve velocity constraints.
            for (int i = 0; i < step.velocityIterations; ++i)
            {
                for (int j = 0; j < JointCount; ++j)
                {
                    Joint joint = _joints[j];

                    if (!joint.Enabled)
                        continue;

                    if (Settings.EnableDiagnostics)
                        _watch.Start();

                    joint.SolveVelocityConstraints(ref solverData);
                    joint.Validate(step.inv_dt);

                    if (Settings.EnableDiagnostics)
                        _watch.Stop();
                }

                _contactSolver.SolveVelocityConstraints();
            }

            // Store impulses for warm starting.
            _contactSolver.StoreImpulses();

            // Integrate positions
            for (int i = 0; i < BodyCount; ++i)
            {
                Vector2 c = _positions[i].c;
                float a = _positions[i].a;
                Vector2 v = _velocities[i].v;
                float w = _velocities[i].w;

                // Check for large velocities
                Vector2 translation = h * v;
                if (Vector2.Dot(translation, translation) > Settings.MaxTranslationSquared)
                {
                    float ratio = Settings.MaxTranslation / translation.Length();
                    v *= ratio;
                }

                float rotation = h * w;
                if (rotation * rotation > Settings.MaxRotationSquared)
                {
                    float ratio = Settings.MaxRotation / Math.Abs(rotation);
                    w *= ratio;
                }

                // Integrate
                c += h * v;
                a += h * w;

                _positions[i].c = c;
                _positions[i].a = a;
                _velocities[i].v = v;
                _velocities[i].w = w;
            }


            // Solve position constraints
            bool positionSolved = false;
            for (int i = 0; i < step.positionIterations; ++i)
            {
                bool contactsOkay = _contactSolver.SolvePositionConstraints();

                bool jointsOkay = true;
                for (int j = 0; j < JointCount; ++j)
                {
                    Joint joint = _joints[j];

                    if (!joint.Enabled)
                        continue;

                    if (Settings.EnableDiagnostics)
                        _watch.Start();

                    bool jointOkay = joint.SolvePositionConstraints(ref solverData);

                    if (Settings.EnableDiagnostics)
                        _watch.Stop();

                    jointsOkay = jointsOkay && jointOkay;
                }

                if (contactsOkay && jointsOkay)
                {
                    // Exit early if the position errors are small.
                    positionSolved = true;
                    break;
                }
            }

            if (Settings.EnableDiagnostics)
            {
                JointUpdateTime = TimeSpan.FromTicks(_watch.ElapsedTicks);
                _watch.Reset();
            }

            // Copy state buffers back to the bodies
            for (int i = 0; i < BodyCount; ++i)
            {
                Body body = Bodies[i];
                body._sweep.C = _positions[i].c;
                body._sweep.A = _positions[i].a;
                body._linearVelocity = _velocities[i].v;
                body._angularVelocity = _velocities[i].w;
                body.SynchronizeTransform();
            }

            Report(_contactSolver._velocityConstraints);

            if (Settings.AllowSleep)
            {
                float minSleepTime = Settings.MaxFloat;

                for (int i = 0; i < BodyCount; ++i)
                {
                    Body b = Bodies[i];

                    if (b.BodyType == BodyType.Static)
                        continue;

                    if (!b.SleepingAllowed || b._angularVelocity * b._angularVelocity > AngTolSqr || Vector2.Dot(b._linearVelocity, b._linearVelocity) > LinTolSqr)
                    {
                        b._sleepTime = 0.0f;
                        minSleepTime = 0.0f;
                    }
                    else
                    {
                        b._sleepTime += h;
                        minSleepTime = Math.Min(minSleepTime, b._sleepTime);
                    }
                }

                if ((minSleepTime >= Settings.TimeToSleep) && positionSolved)
                {
                    for (int i = 0; i < BodyCount; ++i)
                    {
                        Body b = Bodies[i];
                        b.Awake = false;
                    }
                }
            }
        }

        /// <summary>
        /// Solves the toi using the specified sub step
        /// </summary>
        /// <param name="subStep">The sub step</param>
        /// <param name="toiIndexA">The toi index</param>
        /// <param name="toiIndexB">The toi index</param>
        internal void SolveTOI(ref TimeStep subStep, int toiIndexA, int toiIndexB)
        {
            Debug.Assert(toiIndexA < BodyCount);
            Debug.Assert(toiIndexB < BodyCount);

            // Initialize the body state.
            for (int i = 0; i < BodyCount; ++i)
            {
                Body b = Bodies[i];
                _positions[i].c = b._sweep.C;
                _positions[i].a = b._sweep.A;
                _velocities[i].v = b._linearVelocity;
                _velocities[i].w = b._angularVelocity;
            }

            _contactSolver.Reset(ref subStep, ContactCount, _contacts, _positions, _velocities,
                _locks, _contactManager.VelocityConstraintsMultithreadThreshold, _contactManager.PositionConstraintsMultithreadThreshold);

            // Solve position constraints.
            for (int i = 0; i < subStep.positionIterations; ++i)
            {
                bool contactsOkay = _contactSolver.SolveTOIPositionConstraints(toiIndexA, toiIndexB);
                if (contactsOkay)
                {
                    break;
                }
            }

            // Leap of faith to new safe state.
            Bodies[toiIndexA]._sweep.C0 = _positions[toiIndexA].c;
            Bodies[toiIndexA]._sweep.A0 = _positions[toiIndexA].a;
            Bodies[toiIndexB]._sweep.C0 = _positions[toiIndexB].c;
            Bodies[toiIndexB]._sweep.A0 = _positions[toiIndexB].a;

            // No warm starting is needed for TOI events because warm
            // starting impulses were applied in the discrete solver.
            _contactSolver.InitializeVelocityConstraints();

            // Solve velocity constraints.
            for (int i = 0; i < subStep.velocityIterations; ++i)
            {
                _contactSolver.SolveVelocityConstraints();
            }

            // Don't store the TOI contact forces for warm starting
            // because they can be quite large.

            float h = subStep.dt;

            // Integrate positions.
            for (int i = 0; i < BodyCount; ++i)
            {
                Vector2 c = _positions[i].c;
                float a = _positions[i].a;
                Vector2 v = _velocities[i].v;
                float w = _velocities[i].w;

                // Check for large velocities
                Vector2 translation = h * v;
                if (Vector2.Dot(translation, translation) > Settings.MaxTranslationSquared)
                {
                    float ratio = Settings.MaxTranslation / translation.Length();
                    v *= ratio;
                }

                float rotation = h * w;
                if (rotation * rotation > Settings.MaxRotationSquared)
                {
                    float ratio = Settings.MaxRotation / Math.Abs(rotation);
                    w *= ratio;
                }

                // Integrate
                c += h * v;
                a += h * w;

                _positions[i].c = c;
                _positions[i].a = a;
                _velocities[i].v = v;
                _velocities[i].w = w;

                // Sync bodies
                Body body = Bodies[i];
                body._sweep.C = c;
                body._sweep.A = a;
                body._linearVelocity = v;
                body._angularVelocity = w;
                body.SynchronizeTransform();
            }

            Report(_contactSolver._velocityConstraints);
        }

        /// <summary>
        /// Adds the body
        /// </summary>
        /// <param name="body">The body</param>
        public void Add(Body body)
        {
            Debug.Assert(BodyCount < BodyCapacity);
            body.IslandIndex = BodyCount;
            Bodies[BodyCount++] = body;
        }

        /// <summary>
        /// Adds the contact
        /// </summary>
        /// <param name="contact">The contact</param>
        public void Add(Contact contact)
        {
            Debug.Assert(ContactCount < ContactCapacity);
            _contacts[ContactCount++] = contact;
        }

        /// <summary>
        /// Adds the joint
        /// </summary>
        /// <param name="joint">The joint</param>
        public void Add(Joint joint)
        {
            Debug.Assert(JointCount < JointCapacity);
            _joints[JointCount++] = joint;
        }

        /// <summary>
        /// Reports the constraints
        /// </summary>
        /// <param name="constraints">The constraints</param>
        private void Report(ContactVelocityConstraint[] constraints)
        {
            if (_contactManager == null)
                return;

            for (int i = 0; i < ContactCount; ++i)
            {
                Contact c = _contacts[i];

                //FPE optimization: We don't store the impulses and send it to the delegate. We just send the whole contact.
                //FPE feature: added after collision
                var afterCollisionHandlerA = c.FixtureA.AfterCollision;
                if (afterCollisionHandlerA != null)
                    afterCollisionHandlerA(c.FixtureA, c.FixtureB, c, constraints[i]);

                var afterCollisionHandlerB = c.FixtureB.AfterCollision;
                if (afterCollisionHandlerB != null)
                    afterCollisionHandlerB(c.FixtureB, c.FixtureA, c, constraints[i]);

                var postSolveHandler = _contactManager.PostSolve;
                if (postSolveHandler != null)
                    postSolveHandler(c, constraints[i]);
            }
        }
    }
}