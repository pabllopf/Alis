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
        ///     The locks
        /// </summary>
        internal int[] Locks;

        /// <summary>
        ///     The positions
        /// </summary>
        internal SolverPosition[] Positions;

        /// <summary>
        ///     The velocities
        /// </summary>
        internal SolverVelocity[] Velocities;


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
                Velocities = new SolverVelocity[newBodyBufferCapacity];
                Positions = new SolverPosition[newBodyBufferCapacity];
                Locks = new int[newBodyBufferCapacity];
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

                Vector2F c = b.Sweep.C;
                float a = b.Sweep.A;
                Vector2F v = b.LinearVelocity;
                float w = b.AngularVelocity;

                // Store positions for continuous collision.
                b.Sweep.C0 = b.Sweep.C;
                b.Sweep.A0 = b.Sweep.A;

                if (b.GetBodyType == BodyType.Dynamic)
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

                    w += h * b.InvI * b.Torque;

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

                Positions[i].C = c;
                Positions[i].A = a;
                Velocities[i].V = v;
                Velocities[i].W = w;
            }

            // Solver data
            SolverData solverData = new SolverData();
            solverData.Step = step;
            solverData.Positions = Positions;
            solverData.Velocities = Velocities;
            solverData.Locks = Locks;

            _contactSolver.Reset(ref step, ContactCount, _contacts, Positions, Velocities,
                Locks, _contactManager.VelocityConstraintsMultithreadThreshold, _contactManager.PositionConstraintsMultithreadThreshold);
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
                Vector2F c = Positions[i].C;
                float a = Positions[i].A;
                Vector2F v = Velocities[i].V;
                float w = Velocities[i].W;

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

                Positions[i].C = c;
                Positions[i].A = a;
                Velocities[i].V = v;
                Velocities[i].W = w;
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
                body.Sweep.C = Positions[i].C;
                body.Sweep.A = Positions[i].A;
                body.LinearVelocity = Velocities[i].V;
                body.AngularVelocity = Velocities[i].W;
                body.SynchronizeTransform();
            }

            Report(_contactSolver.VelocityConstraints);

            if (SettingEnv.AllowSleep)
            {
                float minSleepTime = SettingEnv.MaxFloat;

                for (int i = 0; i < BodyCount; ++i)
                {
                    Body b = Bodies[i];

                    if (b.GetBodyType == BodyType.Static)
                    {
                        continue;
                    }

                    if (!b.SleepingAllowed || b.AngularVelocity * b.AngularVelocity > AngTolSqr || Vector2F.Dot(b.LinearVelocity, b.LinearVelocity) > LinTolSqr)
                    {
                        b.SleepTime = 0.0f;
                        minSleepTime = 0.0f;
                    }
                    else
                    {
                        b.SleepTime += h;
                        minSleepTime = Math.Min(minSleepTime, b.SleepTime);
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
        internal void SolveToi(ref TimeStep subStep, int toiIndexA, int toiIndexB)
        {
            Debug.Assert(toiIndexA < BodyCount);
            Debug.Assert(toiIndexB < BodyCount);

            // Initialize the body state.
            for (int i = 0; i < BodyCount; ++i)
            {
                Body b = Bodies[i];
                Positions[i].C = b.Sweep.C;
                Positions[i].A = b.Sweep.A;
                Velocities[i].V = b.LinearVelocity;
                Velocities[i].W = b.AngularVelocity;
            }

            _contactSolver.Reset(ref subStep, ContactCount, _contacts, Positions, Velocities,
                Locks, _contactManager.VelocityConstraintsMultithreadThreshold, _contactManager.PositionConstraintsMultithreadThreshold);

            // Solve position constraints.
            for (int i = 0; i < subStep.PositionIterations; ++i)
            {
                bool contactsOkay = _contactSolver.SolveToiPositionConstraints(toiIndexA, toiIndexB);
                if (contactsOkay)
                {
                    break;
                }
            }

            // Leap of faith to new safe state.
            Bodies[toiIndexA].Sweep.C0 = Positions[toiIndexA].C;
            Bodies[toiIndexA].Sweep.A0 = Positions[toiIndexA].A;
            Bodies[toiIndexB].Sweep.C0 = Positions[toiIndexB].C;
            Bodies[toiIndexB].Sweep.A0 = Positions[toiIndexB].A;

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
                Vector2F c = Positions[i].C;
                float a = Positions[i].A;
                Vector2F v = Velocities[i].V;
                float w = Velocities[i].W;

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

                Positions[i].C = c;
                Positions[i].A = a;
                Velocities[i].V = v;
                Velocities[i].W = w;

                // Sync bodies
                Body body = Bodies[i];
                body.Sweep.C = c;
                body.Sweep.A = a;
                body.LinearVelocity = v;
                body.AngularVelocity = w;
                body.SynchronizeTransform();
            }

            Report(_contactSolver.VelocityConstraints);
        }

        /// <summary>
        ///     Adds the body
        /// </summary>
        /// <param name="body">The body</param>
        public void Add(Body body)
        {
            Debug.Assert(BodyCount < BodyCapacity);
            body.GetIslandIndex = BodyCount;
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