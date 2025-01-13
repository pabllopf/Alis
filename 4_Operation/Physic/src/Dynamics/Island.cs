// --------------------------------------------------------------------------
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
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joints;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     This is an internal class.
    /// </summary>
    public class Island : IDisposable
    {
        /// <summary>
        ///     The linear sleep tolerance
        /// </summary>
        private const float LinTolSqr = SettingEnv.LinearSleepTolerance * SettingEnv.LinearSleepTolerance;

        /// <summary>
        ///     The angular sleep tolerance
        /// </summary>
        private const float AngTolSqr = SettingEnv.AngularSleepTolerance * SettingEnv.AngularSleepTolerance;

        /// <summary>
        ///     The contact solver
        /// </summary>
        private readonly ContactSolver _contactSolver = new ContactSolver();

        /// <summary>
        ///     The stopwatch
        /// </summary>
        private readonly Stopwatch _watch = new Stopwatch();

        /// <summary>
        ///     The contact manager
        /// </summary>
        private ContactManager _contactManager;

        /// <summary>
        ///     The contacts
        /// </summary>
        private Contact[] _contacts;

        /// <summary>
        ///     The joints
        /// </summary>
        private Joint[] _joints;

        /// <summary>
        ///     The locks
        /// </summary>
        internal int[] _locks;

        /// <summary>
        ///     The positions
        /// </summary>
        internal SolverPosition[] _positions;

        /// <summary>
        ///     The velocities
        /// </summary>
        internal SolverVelocity[] _velocities;

        /// <summary>
        ///     The bodies
        /// </summary>
        public Body[] Bodies;

        /// <summary>
        ///     The body capacity
        /// </summary>
        public int BodyCapacity;

        /// <summary>
        ///     The body count
        /// </summary>
        public int BodyCount;

        /// <summary>
        ///     The contact capacity
        /// </summary>
        public int ContactCapacity;

        /// <summary>
        ///     The contact count
        /// </summary>
        public int ContactCount;

        /// <summary>
        ///     The joint capacity
        /// </summary>
        public int JointCapacity;

        /// <summary>
        ///     The joint count
        /// </summary>
        public int JointCount;

        /// <summary>
        ///     The joint update time
        /// </summary>
        public TimeSpan JointUpdateTime;


        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _contactSolver?.Dispose();
        }

        /// <summary>
        ///     Resets the body capacity
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
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            BodyCount = 0;
            ContactCount = 0;
            JointCount = 0;
        }

        /// <summary>
        ///     Solves the step
        /// </summary>
        /// <param name="step">The step</param>
        /// <param name="gravity">The gravity</param>
        internal void Solve(ref TimeStep step, ref Vector2F gravity)
        {
            float h = step.Dt;

            // Integrate velocities and apply damping. Initialize the body state.
            for (int i = 0; i < BodyCount; ++i)
            {
                Body b = Bodies[i];

                Vector2F c = b._sweep.C;
                float a = b._sweep.A;
                Vector2F v = b._linearVelocity;
                float w = b.AngularVelocity;

                // Store positions for continuous collision.
                b._sweep.C0 = b._sweep.C;
                b._sweep.A0 = b._sweep.A;

                if (b.BodyType == BodyType.Dynamic)
                {
                    // Integrate velocities.

                    // FPE: Only apply gravity if the body wants it.
                    if (b.IgnoreGravity)
                    {
                        v += h * (b.InvMass * b.Force);
                    }
                    else
                    {
                        v += h * (gravity + b.InvMass * b.Force);
                    }

                    w += h * b.InvI * b._torque;

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

                _positions[i].C = c;
                _positions[i].A = a;
                _velocities[i].v = v;
                _velocities[i].w = w;
            }

            // Solver data
            SolverData solverData = new SolverData();
            solverData.Step = step;
            solverData.Positions = _positions;
            solverData.Velocities = _velocities;
            solverData.Locks = _locks;

            _contactSolver.Reset(ref step, ContactCount, _contacts, _positions, _velocities,
                _locks, _contactManager.VelocityConstraintsMultithreadThreshold, _contactManager.PositionConstraintsMultithreadThreshold);
            _contactSolver.InitializeVelocityConstraints();

            if (step.WarmStarting)
            {
                _contactSolver.WarmStart();
            }

            if (SettingEnv.EnableDiagnostics)
            {
                _watch.Start();
            }

            for (int i = 0; i < JointCount; ++i)
            {
                if (_joints[i].Enabled)
                {
                    _joints[i].InitVelocityConstraints(ref solverData);
                }
            }

            if (SettingEnv.EnableDiagnostics)
            {
                _watch.Stop();
            }

            // Solve velocity constraints.
            for (int i = 0; i < step.VelocityIterations; ++i)
            {
                for (int j = 0; j < JointCount; ++j)
                {
                    Joint joint = _joints[j];

                    if (!joint.Enabled)
                    {
                        continue;
                    }

                    if (SettingEnv.EnableDiagnostics)
                    {
                        _watch.Start();
                    }

                    joint.SolveVelocityConstraints(ref solverData);
                    joint.Validate(step.InvDt);

                    if (SettingEnv.EnableDiagnostics)
                    {
                        _watch.Stop();
                    }
                }

                _contactSolver.SolveVelocityConstraints();
            }

            // Store impulses for warm starting.
            _contactSolver.StoreImpulses();

            // Integrate positions
            for (int i = 0; i < BodyCount; ++i)
            {
                Vector2F c = _positions[i].C;
                float a = _positions[i].A;
                Vector2F v = _velocities[i].v;
                float w = _velocities[i].w;

                // Check for large velocities
                Vector2F translation = h * v;
                if (Vector2F.Dot(translation, translation) > SettingEnv.MaxTranslationSquared)
                {
                    float ratio = SettingEnv.MaxTranslation / translation.Length();
                    v *= ratio;
                }

                float rotation = h * w;
                if (rotation * rotation > SettingEnv.MaxRotationSquared)
                {
                    float ratio = SettingEnv.MaxRotation / Math.Abs(rotation);
                    w *= ratio;
                }

                // Integrate
                c += h * v;
                a += h * w;

                _positions[i].C = c;
                _positions[i].A = a;
                _velocities[i].v = v;
                _velocities[i].w = w;
            }


            // Solve position constraints
            bool positionSolved = false;
            for (int i = 0; i < step.PositionIterations; ++i)
            {
                bool contactsOkay = _contactSolver.SolvePositionConstraints();

                bool jointsOkay = true;
                for (int j = 0; j < JointCount; ++j)
                {
                    Joint joint = _joints[j];

                    if (!joint.Enabled)
                    {
                        continue;
                    }

                    if (SettingEnv.EnableDiagnostics)
                    {
                        _watch.Start();
                    }

                    bool jointOkay = joint.SolvePositionConstraints(ref solverData);

                    if (SettingEnv.EnableDiagnostics)
                    {
                        _watch.Stop();
                    }

                    jointsOkay = jointsOkay && jointOkay;
                }

                if (contactsOkay && jointsOkay)
                {
                    // Exit early if the position errors are small.
                    positionSolved = true;
                    break;
                }
            }

            if (SettingEnv.EnableDiagnostics)
            {
                JointUpdateTime = TimeSpan.FromTicks(_watch.ElapsedTicks);
                _watch.Reset();
            }

            // Copy state buffers back to the bodies
            for (int i = 0; i < BodyCount; ++i)
            {
                Body body = Bodies[i];
                body._sweep.C = _positions[i].C;
                body._sweep.A = _positions[i].A;
                body._linearVelocity = _velocities[i].v;
                body.AngularVelocity = _velocities[i].w;
                body.SynchronizeTransform();
            }

            Report(_contactSolver._velocityConstraints);

            if (SettingEnv.AllowSleep)
            {
                float minSleepTime = SettingEnv.MaxFloat;

                for (int i = 0; i < BodyCount; ++i)
                {
                    Body b = Bodies[i];

                    if (b.BodyType == BodyType.Static)
                    {
                        continue;
                    }

                    if (!b.SleepingAllowed || b.AngularVelocity * b.AngularVelocity > AngTolSqr || Vector2F.Dot(b._linearVelocity, b._linearVelocity) > LinTolSqr)
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

                if ((minSleepTime >= SettingEnv.TimeToSleep) && positionSolved)
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
        ///     Solves the toi using the specified sub step
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
                _positions[i].C = b._sweep.C;
                _positions[i].A = b._sweep.A;
                _velocities[i].v = b._linearVelocity;
                _velocities[i].w = b.AngularVelocity;
            }

            _contactSolver.Reset(ref subStep, ContactCount, _contacts, _positions, _velocities,
                _locks, _contactManager.VelocityConstraintsMultithreadThreshold, _contactManager.PositionConstraintsMultithreadThreshold);

            // Solve position constraints.
            for (int i = 0; i < subStep.PositionIterations; ++i)
            {
                bool contactsOkay = _contactSolver.SolveTOIPositionConstraints(toiIndexA, toiIndexB);
                if (contactsOkay)
                {
                    break;
                }
            }

            // Leap of faith to new safe state.
            Bodies[toiIndexA]._sweep.C0 = _positions[toiIndexA].C;
            Bodies[toiIndexA]._sweep.A0 = _positions[toiIndexA].A;
            Bodies[toiIndexB]._sweep.C0 = _positions[toiIndexB].C;
            Bodies[toiIndexB]._sweep.A0 = _positions[toiIndexB].A;

            // No warm starting is needed for TOI events because warm
            // starting impulses were applied in the discrete solver.
            _contactSolver.InitializeVelocityConstraints();

            // Solve velocity constraints.
            for (int i = 0; i < subStep.VelocityIterations; ++i)
            {
                _contactSolver.SolveVelocityConstraints();
            }

            // Don't store the TOI contact forces for warm starting
            // because they can be quite large.

            float h = subStep.Dt;

            // Integrate positions.
            for (int i = 0; i < BodyCount; ++i)
            {
                Vector2F c = _positions[i].C;
                float a = _positions[i].A;
                Vector2F v = _velocities[i].v;
                float w = _velocities[i].w;

                // Check for large velocities
                Vector2F translation = h * v;
                if (Vector2F.Dot(translation, translation) > SettingEnv.MaxTranslationSquared)
                {
                    float ratio = SettingEnv.MaxTranslation / translation.Length();
                    v *= ratio;
                }

                float rotation = h * w;
                if (rotation * rotation > SettingEnv.MaxRotationSquared)
                {
                    float ratio = SettingEnv.MaxRotation / Math.Abs(rotation);
                    w *= ratio;
                }

                // Integrate
                c += h * v;
                a += h * w;

                _positions[i].C = c;
                _positions[i].A = a;
                _velocities[i].v = v;
                _velocities[i].w = w;

                // Sync bodies
                Body body = Bodies[i];
                body._sweep.C = c;
                body._sweep.A = a;
                body._linearVelocity = v;
                body.AngularVelocity = w;
                body.SynchronizeTransform();
            }

            Report(_contactSolver._velocityConstraints);
        }

        /// <summary>
        ///     Adds the body
        /// </summary>
        /// <param name="body">The body</param>
        public void Add(Body body)
        {
            Debug.Assert(BodyCount < BodyCapacity);
            body.IslandIndex = BodyCount;
            Bodies[BodyCount++] = body;
        }

        /// <summary>
        ///     Adds the contact
        /// </summary>
        /// <param name="contact">The contact</param>
        public void Add(Contact contact)
        {
            Debug.Assert(ContactCount < ContactCapacity);
            _contacts[ContactCount++] = contact;
        }

        /// <summary>
        ///     Adds the joint
        /// </summary>
        /// <param name="joint">The joint</param>
        public void Add(Joint joint)
        {
            Debug.Assert(JointCount < JointCapacity);
            _joints[JointCount++] = joint;
        }

        /// <summary>
        ///     Reports the constraints
        /// </summary>
        /// <param name="constraints">The constraints</param>
        private void Report(ContactVelocityConstraint[] constraints)
        {
            if (_contactManager == null)
            {
                return;
            }

            for (int i = 0; i < ContactCount; ++i)
            {
                Contact c = _contacts[i];

                //FPE optimization: We don't store the impulses and send it to the delegate. We just send the whole contact.
                //FPE feature: added after collision
                AfterCollisionEventHandler afterCollisionHandlerA = c.FixtureA.AfterCollision;
                if (afterCollisionHandlerA != null)
                {
                    afterCollisionHandlerA(c.FixtureA, c.FixtureB, c, constraints[i]);
                }

                AfterCollisionEventHandler afterCollisionHandlerB = c.FixtureB.AfterCollision;
                if (afterCollisionHandlerB != null)
                {
                    afterCollisionHandlerB(c.FixtureB, c.FixtureA, c, constraints[i]);
                }

                PostSolveDelegate postSolveHandler = _contactManager.PostSolve;
                if (postSolveHandler != null)
                {
                    postSolveHandler(c, constraints[i]);
                }
            }
        }
    }
}