// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Island.cs
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

/*
Position Correction Notes
=========================
I tried the several algorithms for position correction of the 2D revolute joint.
I looked at these systems:
- simple pendulum (1m diameter sphere on massless 5m stick) with initial angular velocity of 100 rad/s.
- suspension bridge with 30 1m long planks of length 1m.
- multi-link chain with 30 1m long links.

Here are the algorithms:

Baumgarte - A fraction of the position error is added to the velocity error. There is no
separate position solver.

Pseudo Velocities - After the velocity solver and position integration,
the position error, Jacobian, and effective mass are recomputed. Then
the velocity constraints are solved with pseudo velocities and a fraction
of the position error is added to the pseudo velocity error. The pseudo
velocities are initialized to zero and there is no warm-starting. After
the position solver, the pseudo velocities are added to the positions.
This is also called the First Order World method or the Position LCP method.

Modified Nonlinear Gauss-Seidel (NGS) - Like Pseudo Velocities except the
position error is re-computed for each constraint and the positions are updated
after the constraint is solved. The radius vectors (aka Jacobians) are
re-computed too (otherwise the algorithm has horrible instability). The pseudo
velocity states are not needed because they are effectively zero at the beginning
of each iteration. Since we have the current position error, we allow the
iterations to terminate early if the error becomes smaller than b2_linearSlop.

Full NGS or just NGS - Like Modified NGS except the effective mass are re-computed
each time a constraint is solved.

Here are the results:
Baumgarte - this is the cheapest algorithm but it has some stability problems,
especially with the bridge. The chain links separate easily close to the root
and they jitter as they struggle to pull together. This is one of the most common
methods in the field. The big drawback is that the position correction artificially
affects the momentum, thus leading to instabilities and false bounce. I used a
bias factor of 0.2. A larger bias factor makes the bridge less stable, a smaller
factor makes joints and contacts more spongy.

Pseudo Velocities - the is more stable than the Baumgarte method. The bridge is
stable. However, joints still separate with large angular velocities. Drag the
simple pendulum in a circle quickly and the joint will separate. The chain separates
easily and does not recover. I used a bias factor of 0.2. A larger value lead to
the bridge collapsing when a heavy cube drops on it.

Modified NGS - this algorithm is better in some ways than Baumgarte and Pseudo
Velocities, but in other ways it is worse. The bridge and chain are much more
stable, but the simple pendulum goes unstable at high angular velocities.

Full NGS - stable in all tests. The joints display good stiffness. The bridge
still sags, but this is better than infinite forces.

Recommendations
Pseudo Velocities are not really worthwhile because the bridge and chain cannot
recover from joint separation. In other cases the benefit over Baumgarte is small.

Modified NGS is not a robust method for the revolute joint due to the violent
instability seen in the simple pendulum. Perhaps it is viable with other constraint
types, especially scalar constraints where the effective mass is a scalar.

This leaves Baumgarte and Full NGS. Baumgarte has small, but manageable instabilities
and is very fast. I don't think we can escape Baumgarte, especially in highly
demanding cases where high constraint fidelity is not needed.

Full NGS is robust and easy on the eyes. I recommend this as an option for
higher fidelity simulation and certainly for suspension bridges and long chains.
Full NGS might be a good choice for ragdolls, especially motorized ragdolls where
joint separation can be problematic. The number of NGS iterations can be reduced
for better performance without harming robustness much.

Each joint in a can be handled differently in the position solver. So I recommend
a system where the user can select the algorithm on a per joint basis. I would
probably default to the slower Full NGS and let the user select the faster
Baumgarte method in performance critical scenarios.
*/

/*
Cache Performance

The Box2D solvers are dominated by cache misses. Data structures are designed
to increase the number of cache hits. Much of misses are due to random access
to body data. The constraint structures are iterated over linearly, which leads
to few cache misses.

The bodies are not accessed during iteration. Instead read only data, such as
the mass values are stored with the constraints. The mutable data are the constraint
impulses and the bodies velocities/positions. The impulses are held inside the
constraint structures. The body velocities/positions are held in compact, temporary
arrays to increase the number of cache hits. Linear and angular velocity are
stored in a single array since multiple arrays lead to multiple misses.
*/

/*
2D Rotation

R = [cos(theta) -sin(theta)]
    [sin(theta) cos(theta) ]

thetaDot = omega

Let q1 = cos(theta), q2 = sin(theta).
R = [q1 -q2]
    [q2  q1]

q1Dot = -thetaDot * q2
q2Dot = thetaDot * q1

q1_new = q1_old - dt * w * q2
q2_new = q2_old + dt * w * q1
then normalize.

This might be faster than computing sin+cos.
However, we can compute sin+cos of the same angle fast.
*/

using System;
using System.Diagnostics;
using System.Numerics;
using Alis.Core.Systems.Physics2D.Collision.ContactSystem;
using Alis.Core.Systems.Physics2D.Config;
using Alis.Core.Systems.Physics2D.Dynamics.Joints;
using Alis.Core.Systems.Physics2D.Utilities;

namespace Alis.Core.Systems.Physics2D.Dynamics.Solver
{
    /// <summary>This is an internal class.</summary>
    internal class Island
    {
        /// <summary>
        ///     The angular sleep tolerance
        /// </summary>
        private readonly float angTolSqr = Settings.AngularSleepTolerance * Settings.AngularSleepTolerance;

        /// <summary>
        ///     The contact solver
        /// </summary>
        private readonly ContactSolver contactSolver = new ContactSolver();

        /// <summary>
        ///     The linear sleep tolerance
        /// </summary>
        private readonly float linTolSqr = Settings.LinearSleepTolerance * Settings.LinearSleepTolerance;

        /// <summary>
        ///     The stopwatch
        /// </summary>
        private readonly Stopwatch timer = new Stopwatch();

        /// <summary>
        ///     The bodies
        /// </summary>
        internal Body[] Bodies;

        /// <summary>
        ///     The body capacity
        /// </summary>
        internal int BodyCapacity;

        /// <summary>
        ///     The body count
        /// </summary>
        internal int BodyCount;

        /// <summary>
        ///     The contact capacity
        /// </summary>
        internal int ContactCapacity;

        /// <summary>
        ///     The contact count
        /// </summary>
        internal int ContactCount;

        /// <summary>
        ///     The contact manager
        /// </summary>
        private ContactManager contactManager;

        /// <summary>
        ///     The contacts
        /// </summary>
        private Contact[] contacts;

        /// <summary>
        ///     The joint capacity
        /// </summary>
        private int jointCapacity;

        /// <summary>
        ///     The joint count
        /// </summary>
        private int jointCount;

        /// <summary>
        ///     The joints
        /// </summary>
        private Joint[] joints;

        /// <summary>
        ///     The positions
        /// </summary>
        private Position[] positions;

        /// <summary>
        ///     The velocities
        /// </summary>
        private Velocity[] velocities;

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
            this.jointCapacity = jointCapacity;
            BodyCount = 0;
            ContactCount = 0;
            jointCount = 0;

            this.contactManager = contactManager;

            if (Bodies == null || Bodies.Length < bodyCapacity)
            {
                Bodies = new Body[bodyCapacity];
                velocities = new Velocity[bodyCapacity];
                positions = new Position[bodyCapacity];
            }

            if (contacts == null || contacts.Length < contactCapacity)
            {
                contacts = new Contact[contactCapacity * 2];
            }

            if (joints == null || joints.Length < jointCapacity)
            {
                joints = new Joint[jointCapacity * 2];
            }
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            BodyCount = 0;
            ContactCount = 0;
            jointCount = 0;
        }

        /// <summary>
        ///     Solves the profile
        /// </summary>
        /// <param name="profile">The profile</param>
        /// <param name="step">The step</param>
        /// <param name="gravity">The gravity</param>
        /// <param name="allowSleep">The allow sleep</param>
        public void Solve(ref Profile profile, ref TimeStep step, ref Vector2 gravity, bool allowSleep)
        {
            float h = step.DeltaTime;

            // Integrate velocities and apply damping. Initialize the body state.
            for (int i = 0; i < BodyCount; ++i)
            {
                Body b = Bodies[i];

                Vector2 c = b.Sweep.C;
                float a = b.Sweep.A;
                Vector2 v = b.LinearVelocity;
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

                positions[i].C = c;
                positions[i].A = a;
                velocities[i].V = v;
                velocities[i].W = w;
            }

            timer.Restart();

            // Solver data
            SolverData solverData = new SolverData
            {
                Step = step,
                Positions = positions,
                Velocities = velocities
            };

            //Velcro: We reduce the amount of garbage by reusing the contactsolver and only resetting the state
            contactSolver.Reset(step, ContactCount, contacts, positions, velocities);
            contactSolver.InitializeVelocityConstraints();

            if (step.WarmStarting)
            {
                contactSolver.WarmStart();
            }

            for (int i = 0; i < jointCount; ++i)
            {
                if (joints[i].Enabled)
                {
                    joints[i].InitVelocityConstraints(ref solverData);
                }
            }

            profile.SolveInit = timer.ElapsedTicks;

            // Solve velocity constraints.
            timer.Restart();
            for (int i = 0; i < step.VelocityIterations; ++i)
            {
                for (int j = 0; j < jointCount; ++j)
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
            profile.SolveVelocity = timer.ElapsedTicks;

            // Integrate positions
            for (int i = 0; i < BodyCount; ++i)
            {
                Vector2 c = positions[i].C;
                float a = positions[i].A;
                Vector2 v = velocities[i].V;
                float w = velocities[i].W;

                // Check for large velocities
                Vector2 translation = h * v;
                if (Vector2.Dot(translation, translation) > Settings.MaxTranslation * Settings.MaxTranslation)
                {
                    float ratio = Settings.MaxTranslation / translation.Length();
                    v *= ratio;
                }

                float rotation = h * w;
                if (rotation * rotation > Settings.MaxRotation * Settings.MaxRotation)
                {
                    float ratio = Settings.MaxRotation / Math.Abs(rotation);
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
            timer.Restart();
            bool positionSolved = false;
            for (int i = 0; i < step.PositionIterations; ++i)
            {
                bool contactsOkay = contactSolver.SolvePositionConstraints();

                bool jointsOkay = true;
                for (int j = 0; j < jointCount; ++j)
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
            for (int i = 0; i < BodyCount; ++i)
            {
                Body body = Bodies[i];
                body.Sweep.C = positions[i].C;
                body.Sweep.A = positions[i].A;
                body.LinearVelocity = velocities[i].V;
                body.AngularVelocity = velocities[i].W;
                body.SynchronizeTransform();
            }

            profile.SolvePosition = timer.ElapsedTicks;

            Report(contactSolver.VelocityConstraints);

            if (allowSleep)
            {
                float minSleepTime = MathConstants.MaxFloat;

                for (int i = 0; i < BodyCount; ++i)
                {
                    Body b = Bodies[i];

                    if (b.BodyType == BodyType.Static)
                    {
                        continue;
                    }

                    if (!b.SleepingAllowed || b.AngularVelocity * b.AngularVelocity > angTolSqr ||
                        Vector2.Dot(b.LinearVelocity, b.LinearVelocity) > linTolSqr)
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

                if (minSleepTime >= Settings.TimeToSleep && positionSolved)
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
                positions[i].C = b.Sweep.C;
                positions[i].A = b.Sweep.A;
                velocities[i].V = b.LinearVelocity;
                velocities[i].W = b.AngularVelocity;
            }

            //Velcro: We reset the contact solver instead of craeting a new one to reduce garbage
            contactSolver.Reset(subStep, ContactCount, contacts, positions, velocities);

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
            for (int i = 0; i < BodyCount; ++i)
            {
                Vector2 c = positions[i].C;
                float a = positions[i].A;
                Vector2 v = velocities[i].V;
                float w = velocities[i].W;

                // Check for large velocities
                Vector2 translation = h * v;
                if (Vector2.Dot(translation, translation) > Settings.MaxTranslation * Settings.MaxTranslation)
                {
                    float ratio = Settings.MaxTranslation / translation.Length();
                    v *= ratio;
                }

                float rotation = h * w;
                if (rotation * rotation > Settings.MaxRotation * Settings.MaxRotation)
                {
                    float ratio = Settings.MaxRotation / Math.Abs(rotation);
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
            contacts[ContactCount++] = contact;
        }

        /// <summary>
        ///     Adds the joint
        /// </summary>
        /// <param name="joint">The joint</param>
        public void Add(Joint joint)
        {
            Debug.Assert(jointCount < jointCapacity);
            joints[jointCount++] = joint;
        }

        /// <summary>
        ///     Reports the constraints
        /// </summary>
        /// <param name="constraints">The constraints</param>
        private void Report(ContactVelocityConstraint[] constraints)
        {
            if (contactManager == null)
            {
                return;
            }

            for (int i = 0; i < ContactCount; ++i)
            {
                Contact c = contacts[i];

                //Velcro feature: added after collision
                c.FixtureA.AfterCollision?.Invoke(c.FixtureA, c.FixtureB, c, constraints[i]);
                c.FixtureB.AfterCollision?.Invoke(c.FixtureB, c.FixtureA, c, constraints[i]);

                //Velcro optimization: We don't store the impulses and send it to the delegate. We just send the whole contact.
                contactManager.PostSolve?.Invoke(c, constraints[i]);
            }
        }
    }
}