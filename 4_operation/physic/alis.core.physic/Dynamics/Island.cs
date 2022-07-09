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

The _bodies are not accessed during iteration. Instead read only data, such as
the mass values are stored with the constraints. The mutable data are the constraint
impulses and the _bodies velocities/positions. The impulses are held inside the
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
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joints;
using Math = Alis.Core.Physic.Common.Math;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The island class
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class Island : IDisposable
    {
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
        ///     The contacts
        /// </summary>
        public Contact[] Contacts;

        /// <summary>
        ///     The joint capacity
        /// </summary>
        public int JointCapacity;

        /// <summary>
        ///     The joint count
        /// </summary>
        public int JointCount;

        /// <summary>
        ///     The joints
        /// </summary>
        public Joint[] Joints;

        /// <summary>
        ///     The listener
        /// </summary>
        public ContactListener Listener;

        /// <summary>
        ///     The position iteration count
        /// </summary>
        public int PositionIterationCount;

        /// <summary>
        ///     The positions
        /// </summary>
        public Position[] Positions;

        /// <summary>
        ///     The velocities
        /// </summary>
        public Velocity[] Velocities;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Island" /> class
        /// </summary>
        /// <param name="bodyCapacity">The body capacity</param>
        /// <param name="contactCapacity">The contact capacity</param>
        /// <param name="jointCapacity">The joint capacity</param>
        /// <param name="listener">The listener</param>
        public Island(int bodyCapacity, int contactCapacity, int jointCapacity, ContactListener listener)
        {
            BodyCapacity = bodyCapacity;
            ContactCapacity = contactCapacity;
            JointCapacity = jointCapacity;
            //__bodyCount = 0;
            //_contactCount = 0;
            //_jointCount = 0;

            Listener = listener;

            Bodies = new Body[bodyCapacity];
            Contacts = new Contact[contactCapacity];
            Joints = new Joint[jointCapacity];

            Velocities = new Velocity[BodyCapacity];
            Positions = new Position[BodyCapacity];
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            // Warning: the order should reverse the constructor order.
            Positions = null;
            Velocities = null;
            Joints = null;
            Contacts = null;
            Bodies = null;
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
        /// <param name="allowSleep">The allow sleep</param>
        public void Solve(TimeStep step, Vec2 gravity, bool allowSleep)
        {
            // Integrate velocities and apply damping.
            for (int i = 0; i < BodyCount; ++i)
            {
                Body b = Bodies[i];

                if (b.IsStatic())
                    continue;

                // Integrate velocities.
                b.LinearVelocity += step.Dt * (gravity + b.InvMass * b.Force);
                b.AngularVelocity += step.Dt * b.InvI * b.Torque;

                // Reset forces.
                b.Force.Set(0.0f, 0.0f);
                b.Torque = 0.0f;

                // Apply damping.
                // ODE: dv/dt + c * v = 0
                // Solution: v(t) = v0 * exp(-c * t)
                // Time step: v(t + dt) = v0 * exp(-c * (t + dt)) = v0 * exp(-c * t) * exp(-c * dt) = v * exp(-c * dt)
                // v2 = exp(-c * dt) * v1
                // Taylor expansion:
                // v2 = (1.0f - c * dt) * v1
                b.LinearVelocity *= Math.Clamp(1.0f - step.Dt * b.LinearDamping, 0.0f, 1.0f);
                b.AngularVelocity *= Math.Clamp(1.0f - step.Dt * b.AngularDamping, 0.0f, 1.0f);
            }

            ContactSolver contactSolver = new ContactSolver(step, Contacts, ContactCount);

            // Initialize velocity constraints.
            contactSolver.InitVelocityConstraints(step);

            for (int i = 0; i < JointCount; ++i)
            {
                Joints[i].InitVelocityConstraints(step);
            }

            // Solve velocity constraints.
            for (int i = 0; i < step.VelocityIterations; ++i)
            {
                for (int j = 0; j < JointCount; ++j)
                {
                    Joints[j].SolveVelocityConstraints(step);
                }

                contactSolver.SolveVelocityConstraints();
            }

            // Post-solve (store impulses for warm starting).
            contactSolver.FinalizeVelocityConstraints();

            // Integrate positions.
            for (int i = 0; i < BodyCount; ++i)
            {
                Body b = Bodies[i];

                if (b.IsStatic())
                    continue;

                // Check for large velocities.
                Vec2 translation = step.Dt * b.LinearVelocity;
                if (Vec2.Dot(translation, translation) > Settings.MaxTranslationSquared)
                {
                    translation.Normalize();
                    b.LinearVelocity = (Settings.MaxTranslation * step.InvDt) * translation;
                }

                float rotation = step.Dt * b.AngularVelocity;
                if (rotation * rotation > Settings.MaxRotationSquared)
                {
                    if (rotation < 0.0)
                    {
                        b.AngularVelocity = -step.InvDt * Settings.MaxRotation;
                    }
                    else
                    {
                        b.AngularVelocity = step.InvDt * Settings.MaxRotation;
                    }
                }

                // Store positions for continuous collision.
                b.Sweep.C0 = b.Sweep.C;
                b.Sweep.A0 = b.Sweep.A;

                // Integrate
                b.Sweep.C += step.Dt * b.LinearVelocity;
                b.Sweep.A += step.Dt * b.AngularVelocity;

                // Compute new transform
                b.SynchronizeTransform();

                // Note: shapes are synchronized later.
            }

            // Iterate over constraints.
            for (int i = 0; i < step.PositionIterations; ++i)
            {
                bool contactsOkay = contactSolver.SolvePositionConstraints(Settings.ContactBaumgarte);

                bool jointsOkay = true;
                for (int j = 0; j < JointCount; ++j)
                {
                    bool jointOkay = Joints[j].SolvePositionConstraints(Settings.ContactBaumgarte);
                    jointsOkay = jointsOkay && jointOkay;
                }

                if (contactsOkay && jointsOkay)
                {
                    // Exit early if the position errors are small.
                    break;
                }
            }

            Report(contactSolver._constraints);

            if (allowSleep)
            {
                float minSleepTime = Settings.FltMax;

#if !TARGET_FLOAT32_IS_FIXED
                float linTolSqr = Settings.LinearSleepTolerance * Settings.LinearSleepTolerance;
                float angTolSqr = Settings.AngularSleepTolerance * Settings.AngularSleepTolerance;
#endif

                for (int i = 0; i < BodyCount; ++i)
                {
                    Body b = Bodies[i];
                    if (b.InvMass == 0.0f)
                    {
                        continue;
                    }

                    if ((b.Flags & BodyFlags.AllowSleep) == 0)
                    {
                        b.SleepTime = 0.0f;
                        minSleepTime = 0.0f;
                    }

                    if ((b.Flags & BodyFlags.AllowSleep) == 0 ||
#if TARGET_FLOAT32_IS_FIXED
						Common.Math.Abs(b._angularVelocity) > Settings.AngularSleepTolerance ||
						Common.Math.Abs(b._linearVelocity.X) > Settings.LinearSleepTolerance ||
						Common.Math.Abs(b._linearVelocity.Y) > Settings.LinearSleepTolerance)
#else
                        b.AngularVelocity * b.AngularVelocity > angTolSqr ||
                        Vec2.Dot(b.LinearVelocity, b.LinearVelocity) > linTolSqr)
#endif
                    {
                        b.SleepTime = 0.0f;
                        minSleepTime = 0.0f;
                    }
                    else
                    {
                        b.SleepTime += step.Dt;
                        minSleepTime = Math.Min(minSleepTime, b.SleepTime);
                    }
                }

                if (minSleepTime >= Settings.TimeToSleep)
                {
                    for (int i = 0; i < BodyCount; ++i)
                    {
                        Body b = Bodies[i];
                        b.Flags |= BodyFlags.Sleep;
                        b.LinearVelocity = Vec2.Zero;
                        b.AngularVelocity = 0.0f;
                    }
                }
            }
        }

        /// <summary>
        ///     Solves the toi using the specified sub step
        /// </summary>
        /// <param name="subStep">The sub step</param>
        public void SolveToi(ref TimeStep subStep)
        {
            ContactSolver contactSolver = new ContactSolver(subStep, Contacts, ContactCount);

            // No warm starting is needed for TOI events because warm
            // starting impulses were applied in the discrete solver.

            // Warm starting for joints is off for now, but we need to
            // call this function to compute Jacobians.
            for (int i = 0; i < JointCount; ++i)
            {
                Joints[i].InitVelocityConstraints(subStep);
            }

            // Solve velocity constraints.
            for (int i = 0; i < subStep.VelocityIterations; ++i)
            {
                contactSolver.SolveVelocityConstraints();
                for (int j = 0; j < JointCount; ++j)
                {
                    Joints[j].SolveVelocityConstraints(subStep);
                }
            }

            // Don't store the TOI contact forces for warm starting
            // because they can be quite large.

            // Integrate positions.
            for (int i = 0; i < BodyCount; ++i)
            {
                Body b = Bodies[i];

                if (b.IsStatic())
                    continue;

                // Check for large velocities.
                Vec2 translation = subStep.Dt * b.LinearVelocity;
                if (Vec2.Dot(translation, translation) > Settings.MaxTranslationSquared)
                {
                    translation.Normalize();
                    b.LinearVelocity = (Settings.MaxTranslation * subStep.InvDt) * translation;
                }

                float rotation = subStep.Dt * b.AngularVelocity;
                if (rotation * rotation > Settings.MaxRotationSquared)
                {
                    if (rotation < 0.0)
                    {
                        b.AngularVelocity = -subStep.InvDt * Settings.MaxRotation;
                    }
                    else
                    {
                        b.AngularVelocity = subStep.InvDt * Settings.MaxRotation;
                    }
                }

                // Store positions for continuous collision.
                b.Sweep.C0 = b.Sweep.C;
                b.Sweep.A0 = b.Sweep.A;

                // Integrate
                b.Sweep.C += subStep.Dt * b.LinearVelocity;
                b.Sweep.A += subStep.Dt * b.AngularVelocity;

                // Compute new transform
                b.SynchronizeTransform();

                // Note: shapes are synchronized later.
            }

            // Solve position constraints.
            const float kToiBaumgarte = 0.75f;
            for (int i = 0; i < subStep.PositionIterations; ++i)
            {
                bool contactsOkay = contactSolver.SolvePositionConstraints(kToiBaumgarte);
                bool jointsOkay = true;
                for (int j = 0; j < JointCount; ++j)
                {
                    bool jointOkay = Joints[j].SolvePositionConstraints(kToiBaumgarte);
                    jointsOkay = jointsOkay && jointOkay;
                }

                if (contactsOkay && jointsOkay)
                {
                    break;
                }
            }

            Report(contactSolver._constraints);
        }

        /// <summary>
        ///     Adds the body
        /// </summary>
        /// <param name="body">The body</param>
        public void Add(Body body)
        {
            Box2DXDebug.Assert(BodyCount < BodyCapacity);
            body.IslandIndex = BodyCount;
            Bodies[BodyCount++] = body;
        }

        /// <summary>
        ///     Adds the contact
        /// </summary>
        /// <param name="contact">The contact</param>
        public void Add(Contact contact)
        {
            Box2DXDebug.Assert(ContactCount < ContactCapacity);
            Contacts[ContactCount++] = contact;
        }

        /// <summary>
        ///     Adds the joint
        /// </summary>
        /// <param name="joint">The joint</param>
        public void Add(Joint joint)
        {
            Box2DXDebug.Assert(JointCount < JointCapacity);
            Joints[JointCount++] = joint;
        }

        /// <summary>
        ///     Reports the constraints
        /// </summary>
        /// <param name="constraints">The constraints</param>
        public void Report(ContactConstraint[] constraints)
        {
            if (Listener == null)
            {
                return;
            }

            for (int i = 0; i < ContactCount; ++i)
            {
                Contact c = Contacts[i];
                ContactConstraint cc = constraints[i];
                ContactImpulse impulse = new ContactImpulse();
                for (int j = 0; j < cc.PointCount; ++j)
                {
                    impulse.NormalImpulses[j] = cc.Points[j].NormalImpulse;
                    impulse.TangentImpulses[j] = cc.Points[j].TangentImpulse;
                }

                Listener.PostSolve(c, impulse);
            }
        }
    }
}