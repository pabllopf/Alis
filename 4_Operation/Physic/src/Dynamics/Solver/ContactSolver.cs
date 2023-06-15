// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactSolver.cs
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

//#define B2_DEBUG_SOLVER
/*
* Velcro Physics:
* Copyright (c) 2017 Ian Qvist
* 
* Original source Box2D:
* Copyright (c) 2006-2011 Erin Catto http://www.box2d.org 
* 
* This software is provided 'as-is', without any express or implied 
* warranty.  In no event will the authors be held liable for any damages 
* arising from the use of this software. 
* Permission is granted to anyone to use this software for any purpose, 
* including commercial applications, and to alter it and redistribute it 
* freely, subject to the following restrictions: 
* 1. The origin of this software must not be misrepresented; you must not 
* claim that you wrote the original software. If you use this software 
* in a product, an acknowledgment in the product documentation would be 
* appreciated but is not required. 
* 2. Altered source versions must be plainly marked as such, and must not be 
* misrepresented as being the original software. 
* 3. This notice may not be removed or altered from any source distribution. 
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.Narrowphase;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Shared.Optimization;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Dynamics.Solver
{
    /// <summary>
    ///     The contact solver class
    /// </summary>
    internal class ContactSolver
    {
        /// <summary>
        ///     The contacts
        /// </summary>
        private List<Contact> contacts = new List<Contact>();

        /// <summary>
        ///     The count
        /// </summary>
        private int count;

        /// <summary>
        ///     The position constraints
        /// </summary>
        private List<ContactPositionConstraint> positionConstraints = new List<ContactPositionConstraint>();

        /// <summary>
        ///     The positions
        /// </summary>
        private List<Position> positions = new List<Position>();

        /// <summary>
        ///     The step
        /// </summary>
        private TimeStep step;

        /// <summary>
        ///     The velocities
        /// </summary>
        private List<Velocity> velocities = new List<Velocity>();

        /// <summary>
        ///     The velocity constraints
        /// </summary>
        public List<ContactVelocityConstraint> VelocityConstraints = new List<ContactVelocityConstraint>();

        /// <summary>
        ///     Resets the step
        /// </summary>
        /// <param name="step">The step</param>
        /// <param name="count">The count</param>
        /// <param name="contacts">The contacts</param>
        /// <param name="positions">The positions</param>
        /// <param name="velocities">The velocities</param>
        public void Reset(TimeStep step, int count, List<Contact> contacts, List<Position> positions, List<Velocity> velocities)
        {
            this.step = step;
            this.count = count;
            this.positions = positions;
            this.velocities = velocities;
            this.contacts = contacts;

            // grow the array
            if (VelocityConstraints == null || VelocityConstraints.Count < count)
            {
                VelocityConstraints = new List<ContactVelocityConstraint>(count * 2);
                positionConstraints = new List<ContactPositionConstraint>(count * 2);

                for (int i = 0; i < VelocityConstraints.Count; i++)
                {
                    VelocityConstraints[i] = new ContactVelocityConstraint();
                }

                for (int i = 0; i < positionConstraints.Count; i++)
                {
                    positionConstraints[i] = new ContactPositionConstraint();
                }
            }

            // Initialize position independent portions of the constraints.
            for (int i = 0; i < this.count; ++i)
            {
                Contact contact = contacts[i];

                Fixture fixtureA = contact.FixtureA;
                Fixture fixtureB = contact.FixtureB;
                Shape shapeA = fixtureA.Shape;
                Shape shapeB = fixtureB.Shape;
                float radiusA = shapeA.RadiusPrivate;
                float radiusB = shapeB.RadiusPrivate;
                Body bodyA = fixtureA.Body;
                Body bodyB = fixtureB.Body;
                Manifold manifold = contact.Manifold;

                int pointCount = manifold.PointCount;
                Debug.Assert(pointCount > 0);

                if (VelocityConstraints.Count <= i)
                {
                    VelocityConstraints.Add(new ContactVelocityConstraint());
                }

                ContactVelocityConstraint vc = VelocityConstraints[i];
                vc.Friction = contact.Friction;
                vc.Restitution = contact.Restitution;
                vc.Threshold = contact.RestitutionThreshold;
                vc.TangentSpeed = contact.TangentSpeed;
                vc.IndexA = bodyA.IslandIndex;
                vc.IndexB = bodyB.IslandIndex;
                vc.InvMassA = bodyA.InvMass;
                vc.InvMassB = bodyB.InvMass;
                vc.InvIa = bodyA.InvI;
                vc.InvIb = bodyB.InvI;
                vc.ContactIndex = i;
                vc.PointCount = pointCount;
                vc.K.SetZero();
                vc.NormalMass.SetZero();

                if (positionConstraints.Count <= i)
                {
                    positionConstraints.Add(new ContactPositionConstraint());
                }

                ContactPositionConstraint pc = positionConstraints[i];
                pc.IndexA = bodyA.IslandIndex;
                pc.IndexB = bodyB.IslandIndex;
                pc.InvMassA = bodyA.InvMass;
                pc.InvMassB = bodyB.InvMass;
                pc.LocalCenterA = bodyA.Sweep.LocalCenter;
                pc.LocalCenterB = bodyB.Sweep.LocalCenter;
                pc.InvIa = bodyA.InvI;
                pc.InvIb = bodyB.InvI;
                pc.LocalNormal = manifold.LocalNormal;
                pc.LocalPoint = manifold.LocalPoint;
                pc.PointCount = pointCount;
                pc.RadiusA = radiusA;
                pc.RadiusB = radiusB;
                pc.Type = manifold.Type;

                for (int j = 0; j < pointCount; ++j)
                {
                    ManifoldPoint cp = manifold.Points[j];
                    VelocityConstraintPoint vcp = vc.Points[j];

                    if (step.WarmStarting)
                    {
                        vcp.NormalImpulse = this.step.DeltaTimeRatio * cp.NormalImpulse;
                        vcp.TangentImpulse = this.step.DeltaTimeRatio * cp.TangentImpulse;
                    }
                    else
                    {
                        vcp.NormalImpulse = 0.0f;
                        vcp.TangentImpulse = 0.0f;
                    }

                    vcp.Ra = Vector2.Zero;
                    vcp.Rb = Vector2.Zero;
                    vcp.NormalMass = 0.0f;
                    vcp.TangentMass = 0.0f;
                    vcp.VelocityBias = 0.0f;

                    pc.LocalPoints[j] = cp.LocalPoint;
                }
            }
        }

        /// <summary>Initialize position dependent portions of the velocity constraints.</summary>
        public void InitializeVelocityConstraints()
        {
            for (int i = 0; i < count; ++i)
            {
                ContactVelocityConstraint vc = VelocityConstraints[i];
                ContactPositionConstraint pc = positionConstraints[i];

                float radiusA = pc.RadiusA;
                float radiusB = pc.RadiusB;
                Manifold manifold = contacts[vc.ContactIndex].Manifold;

                int indexA = vc.IndexA;
                int indexB = vc.IndexB;

                float mA = vc.InvMassA;
                float mB = vc.InvMassB;
                float iA = vc.InvIa;
                float iB = vc.InvIb;
                Vector2 localCenterA = pc.LocalCenterA;
                Vector2 localCenterB = pc.LocalCenterB;

                Vector2 cA = positions[indexA].C;
                float aA = positions[indexA].A;
                Vector2 vA = velocities[indexA].V;
                float wA = velocities[indexA].W;

                Vector2 cB = positions[indexB].C;
                float aB = positions[indexB].A;
                Vector2 vB = velocities[indexB].V;
                float wB = velocities[indexB].W;

                Debug.Assert(manifold.PointCount > 0);

                Transform xfA = new Transform();
                Transform xfB = new Transform();
                xfA.Rotation.Set(aA);
                xfB.Rotation.Set(aB);
                xfA.Position = cA - MathUtils.Mul(xfA.Rotation, localCenterA);
                xfB.Position = cB - MathUtils.Mul(xfB.Rotation, localCenterB);

                WorldManifold.Initialize(ref manifold, ref xfA, radiusA, ref xfB, radiusB, out Vector2 normal,
                    out FixedArray2<Vector2> points, out _);

                vc.Normal = normal;

                int pointCount = vc.PointCount;
                for (int j = 0; j < pointCount; ++j)
                {
                    VelocityConstraintPoint vcp = vc.Points[j];

                    vcp.Ra = points[j] - cA;
                    vcp.Rb = points[j] - cB;

                    float rnA = MathUtils.Cross(vcp.Ra, vc.Normal);
                    float rnB = MathUtils.Cross(vcp.Rb, vc.Normal);

                    float kNormal = mA + mB + iA * rnA * rnA + iB * rnB * rnB;

                    vcp.NormalMass = kNormal > 0.0f ? 1.0f / kNormal : 0.0f;

                    Vector2 tangent = MathUtils.Cross(vc.Normal, 1.0f);

                    float rtA = MathUtils.Cross(vcp.Ra, tangent);
                    float rtB = MathUtils.Cross(vcp.Rb, tangent);

                    float kTangent = mA + mB + iA * rtA * rtA + iB * rtB * rtB;

                    vcp.TangentMass = kTangent > 0.0f ? 1.0f / kTangent : 0.0f;

                    // Setup a velocity bias for restitution.
                    vcp.VelocityBias = 0.0f;
                    float vRel = MathUtils.Dot(vc.Normal,
                        vB + MathUtils.Cross(wB, vcp.Rb) - vA - MathUtils.Cross(wA, vcp.Ra));
                    if (vRel < -vc.Threshold)
                    {
                        vcp.VelocityBias = -vc.Restitution * vRel;
                    }
                }

                // If we have two points, then prepare the block solver.
                if ((vc.PointCount == 2) && Settings.BlockSolve)
                {
                    VelocityConstraintPoint vcp1 = vc.Points[0];
                    VelocityConstraintPoint vcp2 = vc.Points[1];

                    float rn1A = MathUtils.Cross(vcp1.Ra, vc.Normal);
                    float rn1B = MathUtils.Cross(vcp1.Rb, vc.Normal);
                    float rn2A = MathUtils.Cross(vcp2.Ra, vc.Normal);
                    float rn2B = MathUtils.Cross(vcp2.Rb, vc.Normal);

                    float k11 = mA + mB + iA * rn1A * rn1A + iB * rn1B * rn1B;
                    float k22 = mA + mB + iA * rn2A * rn2A + iB * rn2B * rn2B;
                    float k12 = mA + mB + iA * rn1A * rn2A + iB * rn1B * rn2B;

                    // Ensure a reasonable condition number.
                    const float kMaxConditionNumber = 1000.0f;
                    if (k11 * k11 < kMaxConditionNumber * (k11 * k22 - k12 * k12))
                    {
                        // K is safe to invert.
                        vc.K.Ex = new Vector2(k11, k12);
                        vc.K.Ey = new Vector2(k12, k22);
                        vc.NormalMass = vc.K.Inverse;
                    }
                    else
                    {
                        // The constraints are redundant, just use one.
                        // TODO_ERIN use deepest?
                        vc.PointCount = 1;
                    }
                }
            }
        }

        /// <summary>
        ///     Warms the start
        /// </summary>
        public void WarmStart()
        {
            // Warm start.
            for (int i = 0; i < count; ++i)
            {
                ContactVelocityConstraint vc = VelocityConstraints[i];

                int indexA = vc.IndexA;
                int indexB = vc.IndexB;
                float mA = vc.InvMassA;
                float iA = vc.InvIa;
                float mB = vc.InvMassB;
                float iB = vc.InvIb;
                int pointCount = vc.PointCount;

                Vector2 vA = velocities[indexA].V;
                float wA = velocities[indexA].W;
                Vector2 vB = velocities[indexB].V;
                float wB = velocities[indexB].W;

                Vector2 normal = vc.Normal;
                Vector2 tangent = MathUtils.Cross(normal, 1.0f);

                for (int j = 0; j < pointCount; ++j)
                {
                    VelocityConstraintPoint vcp = vc.Points[j];
                    Vector2 p = vcp.NormalImpulse * normal + vcp.TangentImpulse * tangent;
                    wA -= iA * MathUtils.Cross(vcp.Ra, p);
                    vA -= mA * p;
                    wB += iB * MathUtils.Cross(vcp.Rb, p);
                    vB += mB * p;
                }

                velocities[indexA].V = vA;
                velocities[indexA].W = wA;
                velocities[indexB].V = vB;
                velocities[indexB].W = wB;
            }
        }

        /// <summary>
        ///     Solves the velocity constraints
        /// </summary>
        public void SolveVelocityConstraints()
        {
            for (int i = 0; i < count; ++i)
            {
                ContactVelocityConstraint vc = VelocityConstraints[i];

                int indexA = vc.IndexA;
                int indexB = vc.IndexB;
                float mA = vc.InvMassA;
                float iA = vc.InvIa;
                float mB = vc.InvMassB;
                float iB = vc.InvIb;
                int pointCount = vc.PointCount;

                Vector2 vA = velocities[indexA].V;
                float wA = velocities[indexA].W;
                Vector2 vB = velocities[indexB].V;
                float wB = velocities[indexB].W;

                Vector2 normal = vc.Normal;
                Vector2 tangent = MathUtils.Cross(normal, 1.0f);
                float friction = vc.Friction;

                Debug.Assert(pointCount == 1 || pointCount == 2);

                // Solve tangent constraints first because non-penetration is more important
                // than friction.
                for (int j = 0; j < pointCount; ++j)
                {
                    VelocityConstraintPoint vcp = vc.Points[j];

                    // Relative velocity at contact
                    Vector2 dv = vB + MathUtils.Cross(wB, vcp.Rb) - vA - MathUtils.Cross(wA, vcp.Ra);

                    // Compute tangent force
                    float vt = Vector2.Dot(dv, tangent) - vc.TangentSpeed;
                    float lambda = vcp.TangentMass * -vt;

                    // b2Clamp the accumulated force
                    float maxFriction = friction * vcp.NormalImpulse;
                    float newImpulse = MathUtils.Clamp(vcp.TangentImpulse + lambda, -maxFriction, maxFriction);
                    lambda = newImpulse - vcp.TangentImpulse;
                    vcp.TangentImpulse = newImpulse;

                    // Apply contact impulse
                    Vector2 p = lambda * tangent;

                    vA -= mA * p;
                    wA -= iA * MathUtils.Cross(vcp.Ra, p);

                    vB += mB * p;
                    wB += iB * MathUtils.Cross(vcp.Rb, p);
                }

                // Solve normal constraints
                if (pointCount == 1 || !Settings.BlockSolve)
                {
                    for (int j = 0; j < pointCount; ++j)
                    {
                        VelocityConstraintPoint vcp = vc.Points[j];

                        // Relative velocity at contact
                        Vector2 dv = vB + MathUtils.Cross(wB, vcp.Rb) - vA - MathUtils.Cross(wA, vcp.Ra);

                        // Compute normal impulse
                        float vn = Vector2.Dot(dv, normal);
                        float lambda = -vcp.NormalMass * (vn - vcp.VelocityBias);

                        // b2Clamp the accumulated impulse
                        float newImpulse = Math.Max(vcp.NormalImpulse + lambda, 0.0f);
                        lambda = newImpulse - vcp.NormalImpulse;
                        vcp.NormalImpulse = newImpulse;

                        // Apply contact impulse
                        Vector2 p = lambda * normal;
                        vA -= mA * p;
                        wA -= iA * MathUtils.Cross(vcp.Ra, p);

                        vB += mB * p;
                        wB += iB * MathUtils.Cross(vcp.Rb, p);
                    }
                }
                else
                {
                    // Block solver developed in collaboration with Dirk Gregorius (back in 01/07 on Box2D_Lite).
                    // Build the mini LCP for this contact patch
                    //
                    // vn = A * x + b, vn >= 0, x >= 0 and vn_i * x_i = 0 with i = 1..2
                    //
                    // A = J * W * JT and J = ( -n, -r1 x n, n, r2 x n )
                    // b = vn0 - velocityBias
                    //
                    // The system is solved using the "Total enumeration method" (s. Murty). The complementary constraint vn_i * x_i
                    // implies that we must have in any solution either vn_i = 0 or x_i = 0. So for the 2D contact problem the cases
                    // vn1 = 0 and vn2 = 0, x1 = 0 and x2 = 0, x1 = 0 and vn2 = 0, x2 = 0 and vn1 = 0 need to be tested. The first valid
                    // solution that satisfies the problem is chosen.
                    // 
                    // In order to account of the accumulated impulse 'a' (because of the iterative nature of the solver which only requires
                    // that the accumulated impulse is clamped and not the incremental impulse) we change the impulse variable (x_i).
                    //
                    // Substitute:
                    // 
                    // x = a + d
                    // 
                    // a := old total impulse
                    // x := new total impulse
                    // d := incremental impulse 
                    //
                    // For the current iteration we extend the formula for the incremental impulse
                    // to compute the new total impulse:
                    //
                    // vn = A * d + b
                    //    = A * (x - a) + b
                    //    = A * x + b - A * a
                    //    = A * x + b'
                    // b' = b - A * a;

                    VelocityConstraintPoint cp1 = vc.Points[0];
                    VelocityConstraintPoint cp2 = vc.Points[1];

                    Vector2 a = new Vector2(cp1.NormalImpulse, cp2.NormalImpulse);
                    Debug.Assert((a.X >= 0.0f) && (a.Y >= 0.0f));

                    // Relative velocity at contact
                    Vector2 dv1 = vB + MathUtils.Cross(wB, cp1.Rb) - vA - MathUtils.Cross(wA, cp1.Ra);
                    Vector2 dv2 = vB + MathUtils.Cross(wB, cp2.Rb) - vA - MathUtils.Cross(wA, cp2.Ra);

                    // Compute normal velocity
                    float vn1 = Vector2.Dot(dv1, normal);
                    float vn2 = Vector2.Dot(dv2, normal);

                    Vector2 b = new Vector2(
                        vn1 - cp1.VelocityBias,
                        vn2 - cp2.VelocityBias
                    );

                    // Compute b'
                    b -= MathUtils.Mul(ref vc.K, a);

                    //
                    // Case 1: vn = 0
                    //
                    // 0 = A * x + b'
                    //
                    // Solve for x:
                    //
                    // x = - inv(A) * b'
                    //
                    Vector2 x = -MathUtils.Mul(ref vc.NormalMass, b);

                    if ((x.X >= 0.0f) && (x.Y >= 0.0f))
                    {
                        // Get the incremental impulse
                        Vector2 d = x - a;

                        // Apply incremental impulse
                        Vector2 p1 = d.X * normal;
                        Vector2 p2 = d.Y * normal;
                        vA -= mA * (p1 + p2);
                        wA -= iA * (MathUtils.Cross(cp1.Ra, p1) + MathUtils.Cross(cp2.Ra, p2));

                        vB += mB * (p1 + p2);
                        wB += iB * (MathUtils.Cross(cp1.Rb, p1) + MathUtils.Cross(cp2.Rb, p2));

                        // Accumulate
                        cp1.NormalImpulse = x.X;
                        cp2.NormalImpulse = x.Y;

#if B2_DEBUG_SOLVER
                            // Postconditions
                            dv1 = vB + MathUtils.Cross(wB, cp1.rB) - vA - MathUtils.Cross(wA, cp1.rA);
                            dv2 = vB + MathUtils.Cross(wB, cp2.rB) - vA - MathUtils.Cross(wA, cp2.rA);

                            // Compute normal velocity
                            vn1 = Vector2.Dot(dv1, normal);
                            vn2 = Vector2.Dot(dv2, normal);

                            Debug.Assert(Math.Abs(vn1 - cp1.VelocityBias) < k_errorTol);
                            Debug.Assert(Math.Abs(vn2 - cp2.VelocityBias) < k_errorTol);
#endif
                        break;
                    }

                    //
                    // Case 2: vn1 = 0 and x2 = 0
                    //
                    //   0 = a11 * x1 + a12 * 0 + b1' 
                    // vn2 = a21 * x1 + a22 * 0 + b2'
                    //
                    x = new Vector2(-cp1.NormalMass * b.X, 0.0f);
                    vn1 = 0.0f;
                    vn2 = vc.K.Ex.Y * x.X + b.Y;

                    if ((x.X >= 0.0f) && (vn2 >= 0.0f))
                    {
                        // Get the incremental impulse
                        Vector2 d = x - a;

                        // Apply incremental impulse
                        Vector2 p1 = d.X * normal;
                        Vector2 p2 = d.Y * normal;
                        vA -= mA * (p1 + p2);
                        wA -= iA * (MathUtils.Cross(cp1.Ra, p1) + MathUtils.Cross(cp2.Ra, p2));

                        vB += mB * (p1 + p2);
                        wB += iB * (MathUtils.Cross(cp1.Rb, p1) + MathUtils.Cross(cp2.Rb, p2));

                        // Accumulate
                        cp1.NormalImpulse = x.X;
                        cp2.NormalImpulse = x.Y;

#if B2_DEBUG_SOLVER
                            // Postconditions
                            dv1 = vB + MathUtils.Cross(wB, cp1.rB) - vA - MathUtils.Cross(wA, cp1.rA);

                            // Compute normal velocity
                            vn1 = Vector2.Dot(dv1, normal);

                            Debug.Assert(Math.Abs(vn1 - cp1.VelocityBias) < k_errorTol);
#endif
                        break;
                    }

                    //
                    // Case 3: vn2 = 0 and x1 = 0
                    //
                    // vn1 = a11 * 0 + a12 * x2 + b1' 
                    //   0 = a21 * 0 + a22 * x2 + b2'
                    //
                    x = new Vector2(0.0f, -cp2.NormalMass * b.Y);
                    vn1 = vc.K.Ey.X * x.Y + b.X;
                    vn2 = 0.0f;

                    if ((x.Y >= 0.0f) && (vn1 >= 0.0f))
                    {
                        // Resubstitute for the incremental impulse
                        Vector2 d = x - a;

                        // Apply incremental impulse
                        Vector2 p1 = d.X * normal;
                        Vector2 p2 = d.Y * normal;
                        vA -= mA * (p1 + p2);
                        wA -= iA * (MathUtils.Cross(cp1.Ra, p1) + MathUtils.Cross(cp2.Ra, p2));

                        vB += mB * (p1 + p2);
                        wB += iB * (MathUtils.Cross(cp1.Rb, p1) + MathUtils.Cross(cp2.Rb, p2));

                        // Accumulate
                        cp1.NormalImpulse = x.X;
                        cp2.NormalImpulse = x.Y;

#if B2_DEBUG_SOLVER
                            // Postconditions
                            dv2 = vB + MathUtils.Cross(wB, cp2.rB) - vA - MathUtils.Cross(wA, cp2.rA);

                            // Compute normal velocity
                            vn2 = Vector2.Dot(dv2, normal);

                            Debug.Assert(Math.Abs(vn2 - cp2.VelocityBias) < k_errorTol);
#endif
                        break;
                    }

                    //
                    // Case 4: x1 = 0 and x2 = 0
                    // 
                    // vn1 = b1
                    // vn2 = b2;
                    x = Vector2.Zero;
                    vn1 = b.X;
                    vn2 = b.Y;

                    if ((vn1 >= 0.0f) && (vn2 >= 0.0f))
                    {
                        // Resubstitute for the incremental impulse
                        Vector2 d = x - a;

                        // Apply incremental impulse
                        Vector2 p1 = d.X * normal;
                        Vector2 p2 = d.Y * normal;
                        vA -= mA * (p1 + p2);
                        wA -= iA * (MathUtils.Cross(cp1.Ra, p1) + MathUtils.Cross(cp2.Ra, p2));

                        vB += mB * (p1 + p2);
                        wB += iB * (MathUtils.Cross(cp1.Rb, p1) + MathUtils.Cross(cp2.Rb, p2));

                        // Accumulate
                        cp1.NormalImpulse = x.X;
                        cp2.NormalImpulse = x.Y;
                    }
                }

                velocities[indexA].V = vA;
                velocities[indexA].W = wA;
                velocities[indexB].V = vB;
                velocities[indexB].W = wB;
            }
        }

        /// <summary>
        ///     Stores the impulses
        /// </summary>
        public void StoreImpulses()
        {
            for (int i = 0; i < count; ++i)
            {
                ContactVelocityConstraint vc = VelocityConstraints[i];
                Manifold manifold = contacts[vc.ContactIndex].Manifold;

                for (int j = 0; j < vc.PointCount; ++j)
                {
                    ManifoldPoint point = manifold.Points[j];
                    point.NormalImpulse = vc.Points[j].NormalImpulse;
                    point.TangentImpulse = vc.Points[j].TangentImpulse;
                    manifold.Points[j] = point;
                }

                contacts[vc.ContactIndex].Manifold = manifold;
            }
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <returns>The bool</returns>
        public bool SolvePositionConstraints()
        {
            float minSeparation = 0.0f;

            for (int i = 0; i < count; ++i)
            {
                ContactPositionConstraint pc = positionConstraints[i];

                int indexA = pc.IndexA;
                int indexB = pc.IndexB;
                Vector2 localCenterA = pc.LocalCenterA;
                float mA = pc.InvMassA;
                float iA = pc.InvIa;
                Vector2 localCenterB = pc.LocalCenterB;
                float mB = pc.InvMassB;
                float iB = pc.InvIb;
                int pointCount = pc.PointCount;

                Vector2 cA = positions[indexA].C;
                float aA = positions[indexA].A;

                Vector2 cB = positions[indexB].C;
                float aB = positions[indexB].A;

                // Solve normal constraints
                for (int j = 0; j < pointCount; ++j)
                {
                    Transform xfA = new Transform();
                    Transform xfB = new Transform();
                    xfA.Rotation.Set(aA);
                    xfB.Rotation.Set(aB);
                    xfA.Position = cA - MathUtils.Mul(xfA.Rotation, localCenterA);
                    xfB.Position = cB - MathUtils.Mul(xfB.Rotation, localCenterB);

                    PositionSolverManifold.Initialize(pc, ref xfA, ref xfB, j, out Vector2 normal, out Vector2 point,
                        out float separation);

                    Vector2 rA = point - cA;
                    Vector2 rB = point - cB;

                    // Track max constraint error.
                    minSeparation = Math.Min(minSeparation, separation);

                    // Prevent large corrections and allow slop.
                    float c = MathUtils.Clamp(Settings.Baumgarte * (separation + Settings.LinearSlop),
                        -Settings.LinearCorrection, 0.0f);

                    // Compute the effective mass.
                    float rnA = MathUtils.Cross(rA, normal);
                    float rnB = MathUtils.Cross(rB, normal);
                    float k = mA + mB + iA * rnA * rnA + iB * rnB * rnB;

                    // Compute normal impulse
                    float impulse = k > 0.0f ? -c / k : 0.0f;

                    Vector2 p = impulse * normal;

                    cA -= mA * p;
                    aA -= iA * MathUtils.Cross(rA, p);

                    cB += mB * p;
                    aB += iB * MathUtils.Cross(rB, p);
                }

                positions[indexA].C = cA;
                positions[indexA].A = aA;

                positions[indexB].C = cB;
                positions[indexB].A = aB;
            }

            // We can't expect minSpeparation >= -b2_linearSlop because we don't
            // push the separation above -b2_linearSlop.
            return minSeparation >= -3.0f * Settings.LinearSlop;
        }

        // Sequential position solver for position constraints.
        /// <summary>
        ///     Describes whether this instance solve toi position constraints
        /// </summary>
        /// <param name="toiIndexA">The toi index</param>
        /// <param name="toiIndexB">The toi index</param>
        /// <returns>The bool</returns>
        public bool SolveToiPositionConstraints(int toiIndexA, int toiIndexB)
        {
            float minSeparation = 0.0f;

            for (int i = 0; i < count; ++i)
            {
                ContactPositionConstraint pc = positionConstraints[i];

                int indexA = pc.IndexA;
                int indexB = pc.IndexB;
                Vector2 localCenterA = pc.LocalCenterA;
                Vector2 localCenterB = pc.LocalCenterB;
                int pointCount = pc.PointCount;

                float mA = 0.0f;
                float iA = 0.0f;
                if (indexA == toiIndexA || indexA == toiIndexB)
                {
                    mA = pc.InvMassA;
                    iA = pc.InvIa;
                }

                float mB = 0.0f;
                float iB = 0.0f;
                if (indexB == toiIndexA || indexB == toiIndexB)
                {
                    mB = pc.InvMassB;
                    iB = pc.InvIb;
                }

                Vector2 cA = positions[indexA].C;
                float aA = positions[indexA].A;

                Vector2 cB = positions[indexB].C;
                float aB = positions[indexB].A;

                // Solve normal constraints
                for (int j = 0; j < pointCount; ++j)
                {
                    Transform xfA = new Transform();
                    Transform xfB = new Transform();
                    xfA.Rotation.Set(aA);
                    xfB.Rotation.Set(aB);
                    xfA.Position = cA - MathUtils.Mul(xfA.Rotation, localCenterA);
                    xfB.Position = cB - MathUtils.Mul(xfB.Rotation, localCenterB);

                    PositionSolverManifold.Initialize(pc, ref xfA, ref xfB, j, out Vector2 normal, out Vector2 point,
                        out float separation);

                    Vector2 rA = point - cA;
                    Vector2 rB = point - cB;

                    // Track max constraint error.
                    minSeparation = Math.Min(minSeparation, separation);

                    // Prevent large corrections and allow slop.
                    float c = MathUtils.Clamp(Settings.ToiBaumgarte * (separation + Settings.LinearSlop),
                        -Settings.LinearCorrection, 0.0f);

                    // Compute the effective mass.
                    float rnA = MathUtils.Cross(rA, normal);
                    float rnB = MathUtils.Cross(rB, normal);
                    float k = mA + mB + iA * rnA * rnA + iB * rnB * rnB;

                    // Compute normal impulse
                    float impulse = k > 0.0f ? -c / k : 0.0f;

                    Vector2 p = impulse * normal;

                    cA -= mA * p;
                    aA -= iA * MathUtils.Cross(rA, p);

                    cB += mB * p;
                    aB += iB * MathUtils.Cross(rB, p);
                }

                positions[indexA].C = cA;
                positions[indexA].A = aA;

                positions[indexB].C = cB;
                positions[indexB].A = aB;
            }

            // We can't expect minSpeparation >= -b2_linearSlop because we don't
            // push the separation above -b2_linearSlop.
            return minSeparation >= -1.5f * Settings.LinearSlop;
        }
    }
}