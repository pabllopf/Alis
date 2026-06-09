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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Time;
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
        private readonly Clock _watch = new Clock();

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
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Releases managed and unmanaged resources
        /// </summary>
        /// <param name="disposing">Whether to release managed resources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _contactSolver?.Dispose();
            }
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

            IntegrateVelocities(h, ref gravity);
            InitializeSolverData(step);
            SolveVelocityConstraints(step);

            _contactSolver.StoreImpulses();

            IntegratePositions(h);

            bool positionSolved = SolvePositionConstraints(step);

            RecordJointUpdateTime();
            SynchronizeBodyStates();
            Report(_contactSolver.VelocityConstraints);
            UpdateSleepState(h, positionSolved);
        }

        /// <summary>
        /// Integrates the velocities using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="gravity">The gravity</param>
        private void IntegrateVelocities(float h, ref Vector2F gravity)
        {
            for (int i = 0; i < BodyCount; ++i)
            {
                Body b = Bodies[i];

                Vector2F c = b.Sweep.C;
                float a = b.Sweep.A;
                Vector2F v = b.LinearVelocityInternal;
                float w = b.AngularVelocity;

                b.Sweep.C0 = b.Sweep.C;
                b.Sweep.A0 = b.Sweep.A;

                if (b.GetBodyType == BodyType.Dynamic)
                {
                    if (b.IgnoreGravity)
                    {
                        v += h * (b.InvMass * b.Force);
                    }
                    else
                    {
                        v += h * (gravity + b.InvMass * b.Force);
                    }

                    w += h * b.InvI * b.Torque;

                    v *= MathUtils.Clamp(1.0f - h * b.LinearDamping, 0.0f, 1.0f);
                    w *= MathUtils.Clamp(1.0f - h * b.AngularDamping, 0.0f, 1.0f);
                }

                Positions[i].C = c;
                Positions[i].A = a;
                Velocities[i].V = v;
                Velocities[i].W = w;
            }
        }

        /// <summary>
        /// Initializes the solver data using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        private void InitializeSolverData(TimeStep step)
        {
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
        }

        /// <summary>
        /// Solves the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        private void SolveVelocityConstraints(TimeStep step)
        {
            SolverData solverData = new SolverData();
            solverData.Step = step;
            solverData.Positions = Positions;
            solverData.Velocities = Velocities;
            solverData.Locks = Locks;

            for (int i = 0; i < step.VelocityIterations; ++i)
            {
                SolveJointVelocityConstraints(ref solverData);
                _contactSolver.SolveVelocityConstraints();
            }
        }

        /// <summary>
        /// Solves the joint velocity constraints using the specified solver data
        /// </summary>
        /// <param name="solverData">The solver data</param>
        private void SolveJointVelocityConstraints(ref SolverData solverData)
        {
            for (int j = 0; j < JointCount; ++j)
            {
                Joint joint = _joints[j];
                if (!joint.Enabled)
                    continue;

                SolveEnabledJointVelocity(joint, ref solverData);
            }
        }

        /// <summary>
        /// Solves the enabled joint velocity using the specified joint
        /// </summary>
        /// <param name="joint">The joint</param>
        /// <param name="solverData">The solver data</param>
        private void SolveEnabledJointVelocity(Joint joint, ref SolverData solverData)
        {
            if (SettingEnv.EnableDiagnostics)
                _watch.Start();

            joint.SolveVelocityConstraints(ref solverData);
            joint.Validate(solverData.Step.InvDt);

            if (SettingEnv.EnableDiagnostics)
                _watch.Stop();
        }

        /// <summary>
        /// Integrates the positions using the specified h
        /// </summary>
        /// <param name="h">The </param>
        private void IntegratePositions(float h)
        {
            for (int i = 0; i < BodyCount; ++i)
            {
                Vector2F c = Positions[i].C;
                float a = Positions[i].A;
                Vector2F v = Velocities[i].V;
                float w = Velocities[i].W;

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

                c += h * v;
                a += h * w;

                Positions[i].C = c;
                Positions[i].A = a;
                Velocities[i].V = v;
                Velocities[i].W = w;
            }
        }

        /// <summary>
        /// Solves the position constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        /// <returns>The bool</returns>
        private bool SolvePositionConstraints(TimeStep step)
        {
            SolverData solverData = new SolverData();
            solverData.Step = step;
            solverData.Positions = Positions;
            solverData.Velocities = Velocities;
            solverData.Locks = Locks;

            for (int i = 0; i < step.PositionIterations; ++i)
            {
                bool contactsOkay = _contactSolver.SolvePositionConstraints();
                bool jointsOkay = SolveJointPositionConstraints(ref solverData);

                if (contactsOkay && jointsOkay)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Solves the joint position constraints using the specified solver data
        /// </summary>
        /// <param name="solverData">The solver data</param>
        /// <returns>The joints okay</returns>
        private bool SolveJointPositionConstraints(ref SolverData solverData)
        {
            bool jointsOkay = true;
            for (int j = 0; j < JointCount; ++j)
            {
                Joint joint = _joints[j];
                if (!joint.Enabled)
                    continue;

                bool jointOkay = SolveEnabledJointPosition(joint, ref solverData);
                jointsOkay = jointsOkay && jointOkay;
            }
            return jointsOkay;
        }

        /// <summary>
        /// Solves the enabled joint position using the specified joint
        /// </summary>
        /// <param name="joint">The joint</param>
        /// <param name="solverData">The solver data</param>
        /// <returns>The result</returns>
        private bool SolveEnabledJointPosition(Joint joint, ref SolverData solverData)
        {
            if (SettingEnv.EnableDiagnostics)
                _watch.Start();

            bool result = joint.SolvePositionConstraints(ref solverData);

            if (SettingEnv.EnableDiagnostics)
                _watch.Stop();

            return result;
        }

        /// <summary>
        /// Records the joint update time
        /// </summary>
        private void RecordJointUpdateTime()
        {
            if (SettingEnv.EnableDiagnostics)
            {
                JointUpdateTime = TimeSpan.FromTicks(_watch.ElapsedTicks);
                _watch.Reset();
            }
        }

        /// <summary>
        /// Synchronizes the body states
        /// </summary>
        private void SynchronizeBodyStates()
        {
            for (int i = 0; i < BodyCount; ++i)
            {
                Body body = Bodies[i];
                body.Sweep.C = Positions[i].C;
                body.Sweep.A = Positions[i].A;
                body.LinearVelocityInternal = Velocities[i].V;
                body.AngularVelocity = Velocities[i].W;
                body.SynchronizeTransform();
            }
        }

        /// <summary>
        /// Updates the sleep state using the specified h
        /// </summary>
        /// <param name="h">The </param>
        /// <param name="positionSolved">The position solved</param>
        private void UpdateSleepState(float h, bool positionSolved)
        {
            if (!SettingEnv.AllowSleep)
            {
                return;
            }

            float minSleepTime = SettingEnv.MaxFloat;

            for (int i = 0; i < BodyCount; ++i)
            {
                Body b = Bodies[i];

                if (b.GetBodyType == BodyType.Static)
                {
                    continue;
                }

                if (!b.SleepingAllowed || b.AngularVelocity * b.AngularVelocity > AngTolSqr || Vector2F.Dot(b.LinearVelocityInternal, b.LinearVelocityInternal) > LinTolSqr)
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

        /// <summary>
        ///     Solves the toi using the specified sub step
        /// </summary>
        /// <param name="subStep">The sub step</param>
        /// <param name="toiIndexA">The toi index</param>
        /// <param name="toiIndexB">The toi index</param>
        internal void SolveToi(ref TimeStep subStep, int toiIndexA, int toiIndexB)
        {
            for (int i = 0; i < BodyCount; ++i)
            {
                Body b = Bodies[i];
                Positions[i].C = b.Sweep.C;
                Positions[i].A = b.Sweep.A;
                Velocities[i].V = b.LinearVelocityInternal;
                Velocities[i].W = b.AngularVelocity;
            }

            _contactSolver.Reset(ref subStep, ContactCount, _contacts, Positions, Velocities,
                Locks, _contactManager.VelocityConstraintsMultithreadThreshold, _contactManager.PositionConstraintsMultithreadThreshold);

            for (int i = 0; i < subStep.PositionIterations; ++i)
            {
                bool contactsOkay = _contactSolver.SolveToiPositionConstraints(toiIndexA, toiIndexB);
                if (contactsOkay)
                {
                    break;
                }
            }

            Bodies[toiIndexA].Sweep.C0 = Positions[toiIndexA].C;
            Bodies[toiIndexA].Sweep.A0 = Positions[toiIndexA].A;
            Bodies[toiIndexB].Sweep.C0 = Positions[toiIndexB].C;
            Bodies[toiIndexB].Sweep.A0 = Positions[toiIndexB].A;

            _contactSolver.InitializeVelocityConstraints();

            for (int i = 0; i < subStep.VelocityIterations; ++i)
            {
                _contactSolver.SolveVelocityConstraints();
            }

            // because they can be quite large.

            float h = subStep.Dt;

            for (int i = 0; i < BodyCount; ++i)
            {
                Vector2F c = Positions[i].C;
                float a = Positions[i].A;
                Vector2F v = Velocities[i].V;
                float w = Velocities[i].W;

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

                c += h * v;
                a += h * w;

                Positions[i].C = c;
                Positions[i].A = a;
                Velocities[i].V = v;
                Velocities[i].W = w;

                Body body = Bodies[i];
                body.Sweep.C = c;
                body.Sweep.A = a;
                body.LinearVelocityInternal = v;
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
            body.GetIslandIndex = BodyCount;
            Bodies[BodyCount++] = body;
        }

        /// <summary>
        ///     Adds the contact
        /// </summary>
        /// <param name="contact">The contact</param>
        public void Add(Contact contact)
        {
            _contacts[ContactCount++] = contact;
        }

        /// <summary>
        ///     Adds the joint
        /// </summary>
        /// <param name="joint">The joint</param>
        public void Add(Joint joint)
        {
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