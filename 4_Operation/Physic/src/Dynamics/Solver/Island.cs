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
using System.Collections.Generic;
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics.Joints;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Dynamics.Solver
{
    /// <summary>This is an internal class.</summary>
    internal class Island
    {
        /// <summary>
        ///     The bodies
        /// </summary>
        internal readonly List<Body> Bodies = new List<Body>(Settings.ToiContacts * 2);

        /// <summary>
        ///     The contact manager
        /// </summary>
        private readonly ContactManager contactManager;

        /// <summary>
        ///     The contacts
        /// </summary>
        private readonly List<Contact> contacts = new List<Contact>(Settings.ToiContacts * 2);

        /// <summary>
        ///     The contact solver
        /// </summary>
        private readonly ContactSolver contactSolver = new ContactSolver();

        /// <summary>
        ///     The joints
        /// </summary>
        private readonly List<Joint> joints = new List<Joint>(Settings.ToiContacts);

        /// <summary>
        ///     The positions
        /// </summary>
        private readonly List<Position> positions = new List<Position>(Settings.ToiContacts);

        /// <summary>
        ///     The velocities
        /// </summary>
        private readonly List<Velocity> velocities = new List<Velocity>(Settings.ToiContacts);

        /// <summary>
        ///     Initializes a new instance of the <see cref="Island" /> class
        /// </summary>
        /// <param name="contactManager">The contact manager</param>
        public Island(ContactManager contactManager) => this.contactManager = contactManager;

        /// <summary>
        ///     The angular sleep tolerance
        /// </summary>
        private const float AngTolSqr = Settings.AngularSleepTolerance * Settings.AngularSleepTolerance;

        /// <summary>
        ///     The linear sleep tolerance
        /// </summary>
        private const float LinTolSqr = Settings.LinearSleepTolerance * Settings.LinearSleepTolerance;

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            Bodies.Clear();
            contacts.Clear();
            joints.Clear();
        }

        /// <summary>
        ///     Solves the profile
        /// </summary>
        /// <param name="step">The step</param>
        /// <param name="gravity">The gravity</param>
        /// <param name="allowSleep">The allow sleep</param>
        public void Solve(TimeStep step, Vector2F gravity, bool allowSleep)
        {
            float h = step.DeltaTime;

            // Integrate velocities and apply damping. Initialize the body state.
            foreach (Body b in Bodies)
            {
                Vector2F c = b.Sweep.C;
                float a = b.Sweep.A;
                Vector2F v = b.LinearVelocity;
                float w = b.AngularVelocity;

                // Store positions for continuous collision.
                b.Sweep.C0 = b.Sweep.C;
                b.Sweep.A0 = b.Sweep.A;

                if (b.BodyType == BodyType.Dynamic)
                {
                    // Integrate velocities.
                    v += h * b.InvMass * (b.GravityScale * b.Mass * gravity + b.Force);
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

                if (positions.Count <= Bodies.IndexOf(b))
                {
                    positions.Add(new Position(c, a));
                }
                else
                {
                    positions[Bodies.IndexOf(b)].C = c;
                    positions[Bodies.IndexOf(b)].A = a;
                }

                if (velocities.Count <= Bodies.IndexOf(b))
                {
                    velocities.Insert(Bodies.IndexOf(b), new Velocity(v, w));
                }
                else
                {
                    velocities[Bodies.IndexOf(b)].V = v;
                    velocities[Bodies.IndexOf(b)].W = w;
                }
            }

            // Solver data
            SolverData solverData = new SolverData
            {
                Step = step,
                Positions = positions,
                Velocities = velocities
            };

            //Velcro: We reduce the amount of garbage by reusing the contact solver and only resetting the state
            contactSolver.Reset(step, contacts.Count, contacts, positions, velocities);
            contactSolver.InitializeVelocityConstraints();

            if (step.WarmStarting)
            {
                contactSolver.WarmStart();
            }

            for (int i = 0; i < joints.Count; ++i)
            {
                if (joints[i].Enabled)
                {
                    joints[i].InitVelocityConstraints(ref solverData);
                }
            }

            //profile.SolveInit = timer.ElapsedTicks;

            // Solve velocity constraints.
            for (int i = 0; i < step.VelocityIterations; ++i)
            {
                for (int j = 0; j < joints.Count; ++j)
                {
                    Joint joint = joints[j];

                    if (!joint.Enabled)
                    {
                        continue;
                    }

                    joint.SolveVelocityConstraints(ref solverData);
                    joint.Validate(step.InvertedDeltaTime);
                }

                contactSolver.SolveVelocityConstraints();
            }

            // Store impulses for warm starting.
            contactSolver.StoreImpulses();
            //profile.SolveVelocity = timer.ElapsedTicks;

            // Integrate positions
            for (int i = 0; i < positions.Count; ++i)
            {
                Vector2F c = positions[i].C;
                float a = positions[i].A;
                Vector2F v = velocities[i].V;
                float w = velocities[i].W;

                // Check for large velocities
                Vector2F translation = h * v;
                if (Vector2F.Dot(translation, translation) > Settings.Translation * Settings.Translation)
                {
                    float ratio = Settings.Translation / translation.Length();
                    v *= ratio;
                }

                float rotation = h * w;
                if (rotation * rotation > Settings.Rotation * Settings.Rotation)
                {
                    float ratio = Settings.Rotation / Math.Abs(rotation);
                    w *= ratio;
                }

                // Integrate
                c += h * v;
                a += h * w;

                positions[i].C = c;
                positions[i].A = a;
                velocities[i].V = v;
                velocities[i].W = w;
            }

            // Solve position constraints
            bool positionSolved = false;
            for (int i = 0; i < step.PositionIterations; ++i)
            {
                bool contactsOkay = contactSolver.SolvePositionConstraints();

                bool jointsOkay = true;
                for (int j = 0; j < joints.Count; ++j)
                {
                    Joint joint = joints[j];

                    //Velcro: We support disabling joints
                    if (!joint.Enabled)
                    {
                        continue;
                    }

                    bool jointOkay = joint.SolvePositionConstraints(ref solverData);
                    jointsOkay = jointsOkay && jointOkay;
                }

                if (contactsOkay && jointsOkay)
                {
                    // Exit early if the position errors are small.
                    positionSolved = true;
                    break;
                }
            }

            // Copy state buffers back to the bodies
            for (int i = 0; i < Bodies.Count; ++i)
            {
                Body body = Bodies[i];
                body.Sweep.C = positions[i].C;
                body.Sweep.A = positions[i].A;
                body.LinearVelocity = velocities[i].V;
                body.AngularVelocity = velocities[i].W;
                body.SynchronizeTransform();
            }

            //profile.SolvePosition = timer.ElapsedTicks;

            Report(contactSolver.VelocityConstraints);

            if (allowSleep)
            {
                float minSleepTime = float.MaxValue;

                for (int i = 0; i < Bodies.Count; ++i)
                {
                    Body b = Bodies[i];

                    if (b.BodyType == BodyType.Static)
                    {
                        continue;
                    }

                    if (!b.SleepingAllowed || b.AngularVelocity * b.AngularVelocity > AngTolSqr ||
                        Vector2F.Dot(b.LinearVelocity, b.LinearVelocity) > LinTolSqr)
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

                if ((minSleepTime >= Settings.TimeToSleep) && positionSolved)
                {
                    for (int i = 0; i < Bodies.Count; ++i)
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
            Debug.Assert(toiIndexA < Bodies.Count);
            Debug.Assert(toiIndexB < Bodies.Count);

            // Initialize the body state.
            for (int i = 0; i < Bodies.Count; ++i)
            {
                Body b = Bodies[i];

                if (positions.Count <= Bodies.IndexOf(b))
                {
                    positions.Add(new Position(b.Sweep.C, b.Sweep.A));
                }
                else
                {
                    positions[Bodies.IndexOf(b)].C = b.Sweep.C;
                    positions[Bodies.IndexOf(b)].A = b.Sweep.A;
                }

                if (velocities.Count <= Bodies.IndexOf(b))
                {
                    velocities.Insert(Bodies.IndexOf(b), new Velocity(b.LinearVelocity, b.AngularVelocity));
                }
                else
                {
                    velocities[Bodies.IndexOf(b)].V = b.LinearVelocity;
                    velocities[Bodies.IndexOf(b)].W = b.AngularVelocity;
                }
            }

            //Velcro: We reset the contact solver instead of craeting a new one to reduce garbage
            contactSolver.Reset(subStep, contacts.Count, contacts, positions, velocities);

            // Solve position constraints.
            for (int i = 0; i < subStep.PositionIterations; ++i)
            {
                bool contactsOkay = contactSolver.SolveToiPositionConstraints(toiIndexA, toiIndexB);
                if (contactsOkay)
                {
                    break;
                }
            }

            // Leap of faith to new safe state.
            Bodies[toiIndexA].Sweep.C0 = positions[toiIndexA].C;
            Bodies[toiIndexA].Sweep.A0 = positions[toiIndexA].A;
            Bodies[toiIndexB].Sweep.C0 = positions[toiIndexB].C;
            Bodies[toiIndexB].Sweep.A0 = positions[toiIndexB].A;

            // No warm starting is needed for TOI events because warm
            // starting impulses were applied in the discrete solver.
            contactSolver.InitializeVelocityConstraints();

            // Solve velocity constraints.
            for (int i = 0; i < subStep.VelocityIterations; ++i)
            {
                contactSolver.SolveVelocityConstraints();
            }

            // Don't store the TOI contact forces for warm starting
            // because they can be quite large.

            float h = subStep.DeltaTime;

            // Integrate positions.
            for (int i = 0; i < Bodies.Count; ++i)
            {
                Vector2F c = positions[i].C;
                float a = positions[i].A;
                Vector2F v = velocities[i].V;
                float w = velocities[i].W;

                // Check for large velocities
                Vector2F translation = h * v;
                if (Vector2F.Dot(translation, translation) > Settings.Translation * Settings.Translation)
                {
                    float ratio = Settings.Translation / translation.Length();
                    v *= ratio;
                }

                float rotation = h * w;
                if (rotation * rotation > Settings.Rotation * Settings.Rotation)
                {
                    float ratio = Settings.Rotation / Math.Abs(rotation);
                    w *= ratio;
                }

                // Integrate
                c += h * v;
                a += h * w;

                positions[i].C = c;
                positions[i].A = a;
                velocities[i].V = v;
                velocities[i].W = w;

                // Sync bodies
                Body body = Bodies[i];
                body.Sweep.C = c;
                body.Sweep.A = a;
                body.LinearVelocity = v;
                body.AngularVelocity = w;
                body.SynchronizeTransform();
            }

            Report(contactSolver.VelocityConstraints);
        }

        /// <summary>
        ///     Adds the body
        /// </summary>
        /// <param name="body">The body</param>
        public void Add(Body body)
        {
            body.IslandIndex = Bodies.Count;
            Bodies.Add(body);
        }

        /// <summary>
        ///     Adds the contact
        /// </summary>
        /// <param name="contact">The contact</param>
        public void Add(Contact contact) => contacts.Add(contact);

        /// <summary>
        ///     Adds the joint
        /// </summary>
        /// <param name="joint">The joint</param>
        public void Add(Joint joint) => joints.Add(joint);

        /// <summary>
        ///     Reports the constraints
        /// </summary>
        /// <param name="constraints">The constraints</param>
        private void Report(List<ContactVelocityConstraint> constraints)
        {
            if (contactManager == null)
            {
                return;
            }

            for (int i = 0; i < contacts.Count; ++i)
            {
                Contact c = contacts[i];

                //Velcro feature: added after collision
                c.FixtureA.AfterCollision?.Invoke(c.FixtureA, c.FixtureB, c, constraints[i]);
                c.FixtureB.AfterCollision?.Invoke(c.FixtureB, c.FixtureA, c, constraints[i]);

                //Velcro optimization: We don't store the impulses and send it to the delegate. We just send the whole contact.
                contactManager.PostSolve?.Invoke(c, constraints[i]);
            }
        }

        /// <summary>
        ///     Posts the solve cleanup
        /// </summary>
        public void PostSolveCleanup()
        {
            // Post solve cleanup.
            for (int i = 0; i < Bodies.Count; ++i)
            {
                // Allow static bodies to participate in other islands.
                if (Bodies[i].BodyType == BodyType.Static)
                {
                    Bodies[i].Flags &= ~BodyFlags.IslandFlag;
                }
            }
        }
    }
}