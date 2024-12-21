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

using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collision;
using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The contact solver class
    /// </summary>
    public class ContactSolver
    {
        /// <summary>
        ///     The countdown event
        /// </summary>
        private readonly CountdownEvent SolveVelocityConstraintsWaitLock = new CountdownEvent(0);

        /// <summary>
        ///     The contacts
        /// </summary>
        public Contact[] _contacts;

        /// <summary>
        ///     The count
        /// </summary>
        public int _count;

        /// <summary>
        ///     The locks
        /// </summary>
        internal int[] _locks;

        /// <summary>
        ///     The position constraints
        /// </summary>
        public ContactPositionConstraint[] _positionConstraints;

        /// <summary>
        ///     The position constraints multithread threshold
        /// </summary>
        private int _positionConstraintsMultithreadThreshold;

        /// <summary>
        ///     The positions
        /// </summary>
        internal SolverPosition[] _positions;

        /// <summary>
        ///     The velocities
        /// </summary>
        internal SolverVelocity[] _velocities;

        /// <summary>
        ///     The velocity constraints
        /// </summary>
        public ContactVelocityConstraint[] _velocityConstraints;

        /// <summary>
        ///     The velocity constraints multithread threshold
        /// </summary>
        private int _velocityConstraintsMultithreadThreshold;

        /// <summary>
        ///     Resets the step
        /// </summary>
        /// <param name="step">The step</param>
        /// <param name="count">The count</param>
        /// <param name="contacts">The contacts</param>
        /// <param name="positions">The positions</param>
        /// <param name="velocities">The velocities</param>
        /// <param name="locks">The locks</param>
        /// <param name="velocityConstraintsMultithreadThreshold">The velocity constraints multithread threshold</param>
        /// <param name="positionConstraintsMultithreadThreshold">The position constraints multithread threshold</param>
        internal void Reset(ref TimeStep step, int count, Contact[] contacts, SolverPosition[] positions, SolverVelocity[] velocities,
            int[] locks, int velocityConstraintsMultithreadThreshold, int positionConstraintsMultithreadThreshold)
        {
            _count = count;
            _positions = positions;
            _velocities = velocities;
            _locks = locks;
            _contacts = contacts;
            _velocityConstraintsMultithreadThreshold = velocityConstraintsMultithreadThreshold;
            _positionConstraintsMultithreadThreshold = positionConstraintsMultithreadThreshold;

            // grow the array
            if (_velocityConstraints == null || _velocityConstraints.Length < count)
            {
                int newBufferCount = Math.Max(count, 32);
                newBufferCount = newBufferCount + ((newBufferCount * 2) >> 4); // grow by x1.125f
                newBufferCount = (newBufferCount + 31) & ~31; // grow in chunks of 32.
                int oldBufferCount = _velocityConstraints == null ? 0 : _velocityConstraints.Length;
                Array.Resize(ref _velocityConstraints, newBufferCount);
                Array.Resize(ref _positionConstraints, newBufferCount);

                for (int i = oldBufferCount; i < newBufferCount; i++)
                {
                    _velocityConstraints[i] = new ContactVelocityConstraint();
                    _positionConstraints[i] = new ContactPositionConstraint();
                }
            }

            // Initialize position independent portions of the constraints.
            for (int i = 0; i < _count; ++i)
            {
                Contact contact = contacts[i];

                Fixture fixtureA = contact.FixtureA;
                Fixture fixtureB = contact.FixtureB;
                Shape shapeA = fixtureA.Shape;
                Shape shapeB = fixtureB.Shape;
                float radiusA = shapeA.Radius;
                float radiusB = shapeB.Radius;
                Body bodyA = fixtureA.Body;
                Body bodyB = fixtureB.Body;
                Manifold manifold = contact.Manifold;

                int pointCount = manifold.PointCount;
                Debug.Assert(pointCount > 0);

                ContactVelocityConstraint vc = _velocityConstraints[i];
                vc.friction = contact.Friction;
                vc.restitution = contact.Restitution;
                vc.tangentSpeed = contact.TangentSpeed;
                vc.indexA = bodyA.IslandIndex;
                vc.indexB = bodyB.IslandIndex;
                vc.invMassA = bodyA._invMass;
                vc.invMassB = bodyB._invMass;
                vc.invIA = bodyA._invI;
                vc.invIB = bodyB._invI;
                vc.contactIndex = i;
                vc.pointCount = pointCount;
                vc.K.SetZero();
                vc.normalMass.SetZero();

                ContactPositionConstraint pc = _positionConstraints[i];
                pc.indexA = bodyA.IslandIndex;
                pc.indexB = bodyB.IslandIndex;
                pc.invMassA = bodyA._invMass;
                pc.invMassB = bodyB._invMass;
                pc.localCenterA = bodyA._sweep.LocalCenter;
                pc.localCenterB = bodyB._sweep.LocalCenter;
                pc.invIA = bodyA._invI;
                pc.invIB = bodyB._invI;
                pc.localNormal = manifold.LocalNormal;
                pc.localPoint = manifold.LocalPoint;
                pc.pointCount = pointCount;
                pc.radiusA = radiusA;
                pc.radiusB = radiusB;
                pc.type = manifold.Type;

                for (int j = 0; j < pointCount; ++j)
                {
                    ManifoldPoint cp = manifold.Points[j];
                    VelocityConstraintPoint vcp = vc.points[j];

                    if (step.warmStarting)
                    {
                        vcp.normalImpulse = step.dtRatio * cp.NormalImpulse;
                        vcp.tangentImpulse = step.dtRatio * cp.TangentImpulse;
                    }
                    else
                    {
                        vcp.normalImpulse = 0.0f;
                        vcp.tangentImpulse = 0.0f;
                    }

                    vcp.rA = Vector2F.Zero;
                    vcp.rB = Vector2F.Zero;
                    vcp.normalMass = 0.0f;
                    vcp.tangentMass = 0.0f;
                    vcp.velocityBias = 0.0f;

                    pc.localPoints[j] = cp.LocalPoint;
                }
            }
        }

        /// <summary>
        ///     Initializes the velocity constraints
        /// </summary>
        public void InitializeVelocityConstraints()
        {
            for (int i = 0; i < _count; ++i)
            {
                ContactVelocityConstraint vc = _velocityConstraints[i];
                ContactPositionConstraint pc = _positionConstraints[i];

                float radiusA = pc.radiusA;
                float radiusB = pc.radiusB;
                Manifold manifold = _contacts[vc.contactIndex].Manifold;

                int indexA = vc.indexA;
                int indexB = vc.indexB;

                float mA = vc.invMassA;
                float mB = vc.invMassB;
                float iA = vc.invIA;
                float iB = vc.invIB;
                Vector2F localCenterA = pc.localCenterA;
                Vector2F localCenterB = pc.localCenterB;

                Vector2F cA = _positions[indexA].c;
                float aA = _positions[indexA].a;
                Vector2F vA = _velocities[indexA].v;
                float wA = _velocities[indexA].w;

                Vector2F cB = _positions[indexB].c;
                float aB = _positions[indexB].a;
                Vector2F vB = _velocities[indexB].v;
                float wB = _velocities[indexB].w;

                Debug.Assert(manifold.PointCount > 0);

                Transform xfA = new Transform(Vector2F.Zero, aA);
                Transform xfB = new Transform(Vector2F.Zero, aB);
                xfA.p = cA - Complex.Multiply(ref localCenterA, ref xfA.q);
                xfB.p = cB - Complex.Multiply(ref localCenterB, ref xfB.q);

                WorldManifold.Initialize(ref manifold, ref xfA, radiusA, ref xfB, radiusB, out Vector2F normal, out FixedArray2<Vector2F> points);

                vc.normal = normal;
                Vector2F tangent = MathUtils.Rot270(ref vc.normal);

                int pointCount = vc.pointCount;
                for (int j = 0; j < pointCount; ++j)
                {
                    VelocityConstraintPoint vcp = vc.points[j];

                    vcp.rA = points[j] - cA;
                    vcp.rB = points[j] - cB;

                    float rnA = MathUtils.Cross(ref vcp.rA, ref vc.normal);
                    float rnB = MathUtils.Cross(ref vcp.rB, ref vc.normal);

                    float kNormal = mA + mB + iA * rnA * rnA + iB * rnB * rnB;

                    vcp.normalMass = kNormal > 0.0f ? 1.0f / kNormal : 0.0f;


                    float rtA = MathUtils.Cross(ref vcp.rA, ref tangent);
                    float rtB = MathUtils.Cross(ref vcp.rB, ref tangent);

                    float kTangent = mA + mB + iA * rtA * rtA + iB * rtB * rtB;

                    vcp.tangentMass = kTangent > 0.0f ? 1.0f / kTangent : 0.0f;

                    // Setup a velocity bias for restitution.
                    vcp.velocityBias = 0.0f;
                    float vRel = Vector2F.Dot(vc.normal, vB + MathUtils.Cross(wB, ref vcp.rB) - vA - MathUtils.Cross(wA, ref vcp.rA));
                    if (vRel < -SettingEnv.VelocityThreshold)
                    {
                        vcp.velocityBias = -vc.restitution * vRel;
                    }
                }

                // If we have two points, then prepare the block solver.
                if (vc.pointCount == 2)
                {
                    VelocityConstraintPoint vcp1 = vc.points[0];
                    VelocityConstraintPoint vcp2 = vc.points[1];

                    float rn1A = MathUtils.Cross(ref vcp1.rA, ref vc.normal);
                    float rn1B = MathUtils.Cross(ref vcp1.rB, ref vc.normal);
                    float rn2A = MathUtils.Cross(ref vcp2.rA, ref vc.normal);
                    float rn2B = MathUtils.Cross(ref vcp2.rB, ref vc.normal);

                    float k11 = mA + mB + iA * rn1A * rn1A + iB * rn1B * rn1B;
                    float k22 = mA + mB + iA * rn2A * rn2A + iB * rn2B * rn2B;
                    float k12 = mA + mB + iA * rn1A * rn2A + iB * rn1B * rn2B;

                    // Ensure a reasonable condition number.
                    const float k_maxConditionNumber = 1000.0f;
                    if (k11 * k11 < k_maxConditionNumber * (k11 * k22 - k12 * k12))
                    {
                        // K is safe to invert.
                        vc.K.Ex = new Vector2F(k11, k12);
                        vc.K.Ey = new Vector2F(k12, k22);
                        vc.normalMass = vc.K.Inverse;
                    }
                    else
                    {
                        // The constraints are redundant, just use one.

                        vc.pointCount = 1;
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
            for (int i = 0; i < _count; ++i)
            {
                ContactVelocityConstraint vc = _velocityConstraints[i];

                int indexA = vc.indexA;
                int indexB = vc.indexB;
                float mA = vc.invMassA;
                float iA = vc.invIA;
                float mB = vc.invMassB;
                float iB = vc.invIB;
                int pointCount = vc.pointCount;

                Vector2F vA = _velocities[indexA].v;
                float wA = _velocities[indexA].w;
                Vector2F vB = _velocities[indexB].v;
                float wB = _velocities[indexB].w;

                Vector2F normal = vc.normal;
                Vector2F tangent = MathUtils.Rot270(ref normal);

                for (int j = 0; j < pointCount; ++j)
                {
                    VelocityConstraintPoint vcp = vc.points[j];
                    Vector2F P = vcp.normalImpulse * normal + vcp.tangentImpulse * tangent;
                    wA -= iA * MathUtils.Cross(ref vcp.rA, ref P);
                    vA -= mA * P;
                    wB += iB * MathUtils.Cross(ref vcp.rB, ref P);
                    vB += mB * P;
                }

                _velocities[indexA].v = vA;
                _velocities[indexA].w = wA;
                _velocities[indexB].v = vB;
                _velocities[indexB].w = wB;
            }
        }

        /// <summary>
        ///     Solves the velocity constraints
        /// </summary>
        public void SolveVelocityConstraints()
        {
            if ((_count >= _velocityConstraintsMultithreadThreshold) && (Environment.ProcessorCount > 1))
            {
                if (_count == 0)
                {
                    return;
                }

                int batchSize = (int) Math.Ceiling((float) _count / Environment.ProcessorCount);
                int batches = (int) Math.Ceiling((float) _count / batchSize);


                SolveVelocityConstraintsWaitLock.Reset(batches);
                for (int i = 0; i < batches; i++)
                {
                    int start = i * batchSize;
                    int end = Math.Min(start + batchSize, _count);
                    ThreadPool.QueueUserWorkItem(SolveVelocityConstraintsCallback, SolveVelocityConstraintsState.Get(this, start, end));
                }

                // We avoid SolveVelocityConstraintsWaitLock.Wait(); because it spins a few milliseconds before going into sleep. Going into sleep(0) directly in a while loop is faster.
                while (SolveVelocityConstraintsWaitLock.CurrentCount > 0)
                    Thread.Sleep(0);

                SolveVelocityConstraints(0, _count);
            }
            else
            {
                SolveVelocityConstraints(0, _count);
            }
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified start
        /// </summary>
        /// <param name="start">The start</param>
        /// <param name="end">The end</param>
        private void SolveVelocityConstraints(int start, int end)
        {
            for (int i = start; i < end; ++i)
            {
                ContactVelocityConstraint vc = _velocityConstraints[i];


                // find lower order item
                int orderedIndexA = vc.indexA;
                int orderedIndexB = vc.indexB;
                if (orderedIndexB < orderedIndexA)
                {
                    orderedIndexA = vc.indexB;
                    orderedIndexB = vc.indexA;
                }

                for (;;)
                {
                    if (Interlocked.CompareExchange(ref _locks[orderedIndexA], 1, 0) == 0)
                    {
                        if (Interlocked.CompareExchange(ref _locks[orderedIndexB], 1, 0) == 0)
                        {
                            break;
                        }

                        Interlocked.Exchange(ref _locks[orderedIndexA], 0);
                    }

                    Thread.Sleep(0);
                }


                int indexA = vc.indexA;
                int indexB = vc.indexB;
                float mA = vc.invMassA;
                float iA = vc.invIA;
                float mB = vc.invMassB;
                float iB = vc.invIB;
                int pointCount = vc.pointCount;

                Vector2F vA = _velocities[indexA].v;
                float wA = _velocities[indexA].w;
                Vector2F vB = _velocities[indexB].v;
                float wB = _velocities[indexB].w;

                Vector2F normal = vc.normal;
                Vector2F tangent = MathUtils.Rot270(ref normal);
                float friction = vc.friction;

                Debug.Assert(pointCount == 1 || pointCount == 2);

                // Solve tangent constraints first because non-penetration is more important
                // than friction.
                for (int j = 0; j < pointCount; ++j)
                {
                    VelocityConstraintPoint vcp = vc.points[j];

                    // Relative velocity at contact
                    Vector2F dv = vB + MathUtils.Cross(wB, ref vcp.rB) - vA - MathUtils.Cross(wA, ref vcp.rA);

                    // Compute tangent force
                    float vt = Vector2F.Dot(dv, tangent) - vc.tangentSpeed;
                    float lambda = vcp.tangentMass * -vt;

                    // b2Clamp the accumulated force
                    float maxFriction = friction * vcp.normalImpulse;
                    float newImpulse = MathUtils.Clamp(vcp.tangentImpulse + lambda, -maxFriction, maxFriction);
                    lambda = newImpulse - vcp.tangentImpulse;
                    vcp.tangentImpulse = newImpulse;

                    // Apply contact impulse
                    Vector2F P = lambda * tangent;

                    vA -= mA * P;
                    wA -= iA * MathUtils.Cross(ref vcp.rA, ref P);

                    vB += mB * P;
                    wB += iB * MathUtils.Cross(ref vcp.rB, ref P);
                }

                // Solve normal constraints
                if (vc.pointCount == 1)
                {
                    VelocityConstraintPoint vcp = vc.points[0];

                    // Relative velocity at contact
                    Vector2F dv = vB + MathUtils.Cross(wB, ref vcp.rB) - vA - MathUtils.Cross(wA, ref vcp.rA);

                    // Compute normal impulse
                    float vn = Vector2F.Dot(dv, normal);
                    float lambda = -vcp.normalMass * (vn - vcp.velocityBias);

                    // b2Clamp the accumulated impulse
                    float newImpulse = Math.Max(vcp.normalImpulse + lambda, 0.0f);
                    lambda = newImpulse - vcp.normalImpulse;
                    vcp.normalImpulse = newImpulse;

                    // Apply contact impulse
                    Vector2F P = lambda * normal;
                    vA -= mA * P;
                    wA -= iA * MathUtils.Cross(ref vcp.rA, ref P);

                    vB += mB * P;
                    wB += iB * MathUtils.Cross(ref vcp.rB, ref P);
                }
                else
                {
                    // Block solver developed in collaboration with Dirk Gregorius (back in 01/07 on Box2D_Lite).
                    // Build the mini LCP for this contact patch
                    //
                    // vn = A * x + b, vn >= 0, , vn >= 0, x >= 0 and vn_i * x_i = 0 with i = 1..2
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

                    VelocityConstraintPoint cp1 = vc.points[0];
                    VelocityConstraintPoint cp2 = vc.points[1];

                    Vector2F a = new Vector2F(cp1.normalImpulse, cp2.normalImpulse);
                    Debug.Assert((a.X >= 0.0f) && (a.Y >= 0.0f));

                    // Relative velocity at contact
                    Vector2F dv1 = vB + MathUtils.Cross(wB, ref cp1.rB) - vA - MathUtils.Cross(wA, ref cp1.rA);
                    Vector2F dv2 = vB + MathUtils.Cross(wB, ref cp2.rB) - vA - MathUtils.Cross(wA, ref cp2.rA);

                    // Compute normal velocity
                    float vn1 = Vector2F.Dot(dv1, normal);
                    float vn2 = Vector2F.Dot(dv2, normal);

                    Vector2F b = new Vector2F();
                    b.X = vn1 - cp1.velocityBias;
                    b.Y = vn2 - cp2.velocityBias;

                    // Compute b'
                    b -= MathUtils.Mul(ref vc.K, ref a);

                    //B2_NOT_USED(k_errorTol);

                    for (;;)
                    {
                        //
                        // Case 1: vn = 0
                        //
                        // 0 = A * x + b'
                        //
                        // Solve for x:
                        //
                        // x = - inv(A) * b'
                        //
                        Vector2F x = -MathUtils.Mul(ref vc.normalMass, ref b);

                        if ((x.X >= 0.0f) && (x.Y >= 0.0f))
                        {
                            // Get the incremental impulse
                            Vector2F d = x - a;

                            // Apply incremental impulse
                            Vector2F P1 = d.X * normal;
                            Vector2F P2 = d.Y * normal;
                            vA -= mA * (P1 + P2);
                            wA -= iA * (MathUtils.Cross(ref cp1.rA, ref P1) + MathUtils.Cross(ref cp2.rA, ref P2));

                            vB += mB * (P1 + P2);
                            wB += iB * (MathUtils.Cross(ref cp1.rB, ref P1) + MathUtils.Cross(ref cp2.rB, ref P2));

                            // Accumulate
                            cp1.normalImpulse = x.X;
                            cp2.normalImpulse = x.Y;

                            break;
                        }

                        //
                        // Case 2: vn1 = 0 and x2 = 0
                        //
                        //   0 = a11 * x1 + a12 * 0 + b1' 
                        // vn2 = a21 * x1 + a22 * 0 + b2'
                        //
                        x.X = -cp1.normalMass * b.X;
                        x.Y = 0.0f;
                        vn1 = 0.0f;
                        vn2 = vc.K.Ex.Y * x.X + b.Y;

                        if ((x.X >= 0.0f) && (vn2 >= 0.0f))
                        {
                            // Get the incremental impulse
                            Vector2F d = x - a;

                            // Apply incremental impulse
                            Vector2F P1 = d.X * normal;
                            Vector2F P2 = d.Y * normal;
                            vA -= mA * (P1 + P2);
                            wA -= iA * (MathUtils.Cross(ref cp1.rA, ref P1) + MathUtils.Cross(ref cp2.rA, ref P2));

                            vB += mB * (P1 + P2);
                            wB += iB * (MathUtils.Cross(ref cp1.rB, ref P1) + MathUtils.Cross(ref cp2.rB, ref P2));

                            // Accumulate
                            cp1.normalImpulse = x.X;
                            cp2.normalImpulse = x.Y;

                            break;
                        }


                        //
                        // Case 3: vn2 = 0 and x1 = 0
                        //
                        // vn1 = a11 * 0 + a12 * x2 + b1' 
                        //   0 = a21 * 0 + a22 * x2 + b2'
                        //
                        x.X = 0.0f;
                        x.Y = -cp2.normalMass * b.Y;
                        vn1 = vc.K.Ey.X * x.Y + b.X;
                        vn2 = 0.0f;

                        if ((x.Y >= 0.0f) && (vn1 >= 0.0f))
                        {
                            // Resubstitute for the incremental impulse
                            Vector2F d = x - a;

                            // Apply incremental impulse
                            Vector2F P1 = d.X * normal;
                            Vector2F P2 = d.Y * normal;
                            vA -= mA * (P1 + P2);
                            wA -= iA * (MathUtils.Cross(ref cp1.rA, ref P1) + MathUtils.Cross(ref cp2.rA, ref P2));

                            vB += mB * (P1 + P2);
                            wB += iB * (MathUtils.Cross(ref cp1.rB, ref P1) + MathUtils.Cross(ref cp2.rB, ref P2));

                            // Accumulate
                            cp1.normalImpulse = x.X;
                            cp2.normalImpulse = x.Y;

                            break;
                        }

                        //
                        // Case 4: x1 = 0 and x2 = 0
                        // 
                        // vn1 = b1
                        // vn2 = b2;
                        x.X = 0.0f;
                        x.Y = 0.0f;
                        vn1 = b.X;
                        vn2 = b.Y;

                        if ((vn1 >= 0.0f) && (vn2 >= 0.0f))
                        {
                            // Resubstitute for the incremental impulse
                            Vector2F d = x - a;

                            // Apply incremental impulse
                            Vector2F P1 = d.X * normal;
                            Vector2F P2 = d.Y * normal;
                            vA -= mA * (P1 + P2);
                            wA -= iA * (MathUtils.Cross(ref cp1.rA, ref P1) + MathUtils.Cross(ref cp2.rA, ref P2));

                            vB += mB * (P1 + P2);
                            wB += iB * (MathUtils.Cross(ref cp1.rB, ref P1) + MathUtils.Cross(ref cp2.rB, ref P2));

                            // Accumulate
                            cp1.normalImpulse = x.X;
                            cp2.normalImpulse = x.Y;
                        }

                        break;
                    }
                }

                _velocities[indexA].v = vA;
                _velocities[indexA].w = wA;
                _velocities[indexB].v = vB;
                _velocities[indexB].w = wB;


                Interlocked.Exchange(ref _locks[orderedIndexB], 0);
                Interlocked.Exchange(ref _locks[orderedIndexA], 0);
            }
        }

        /// <summary>
        ///     Stores the impulses
        /// </summary>
        public void StoreImpulses()
        {
            for (int i = 0; i < _count; ++i)
            {
                ContactVelocityConstraint vc = _velocityConstraints[i];
                Manifold manifold = _contacts[vc.contactIndex].Manifold;

                for (int j = 0; j < vc.pointCount; ++j)
                {
                    ManifoldPoint point = manifold.Points[j];
                    point.NormalImpulse = vc.points[j].normalImpulse;
                    point.TangentImpulse = vc.points[j].tangentImpulse;
                    manifold.Points[j] = point;
                }

                _contacts[vc.contactIndex].Manifold = manifold;
            }
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <returns>The contacts okay</returns>
        public bool SolvePositionConstraints()
        {
            bool contactsOkay = false;

            if ((_count >= _positionConstraintsMultithreadThreshold) && (Environment.ProcessorCount > 1))
            {
                if (_count == 0)
                {
                    return true;
                }

                int batchSize = (int) Math.Ceiling((float) _count / Environment.ProcessorCount);
                int batches = (int) Math.Ceiling((float) _count / batchSize);


                Parallel.For(0, batches, i =>
                {
                    int start = i * batchSize;
                    int end = Math.Min(start + batchSize, _count);
                    bool res = SolvePositionConstraints(start, end);
                    contactsOkay = contactsOkay || res;
                });

                contactsOkay = SolvePositionConstraints(0, _count);
            }
            else
            {
                contactsOkay = SolvePositionConstraints(0, _count);
            }

            return contactsOkay;
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="start">The start</param>
        /// <param name="end">The end</param>
        /// <returns>The bool</returns>
        private bool SolvePositionConstraints(int start, int end)
        {
            float minSeparation = 0.0f;

            for (int i = start; i < end; ++i)
            {
                ContactPositionConstraint pc = _positionConstraints[i];


                // Find lower order item.
                int orderedIndexA = pc.indexA;
                int orderedIndexB = pc.indexB;
                if (orderedIndexB < orderedIndexA)
                {
                    orderedIndexA = pc.indexB;
                    orderedIndexB = pc.indexA;
                }

                // Lock bodies.
                for (;;)
                {
                    if (Interlocked.CompareExchange(ref _locks[orderedIndexA], 1, 0) == 0)
                    {
                        if (Interlocked.CompareExchange(ref _locks[orderedIndexB], 1, 0) == 0)
                        {
                            break;
                        }

                        Interlocked.Exchange(ref _locks[orderedIndexA], 0);
                    }

                    Thread.Sleep(0);
                }


                int indexA = pc.indexA;
                int indexB = pc.indexB;
                Vector2F localCenterA = pc.localCenterA;
                float mA = pc.invMassA;
                float iA = pc.invIA;
                Vector2F localCenterB = pc.localCenterB;
                float mB = pc.invMassB;
                float iB = pc.invIB;
                int pointCount = pc.pointCount;

                Vector2F cA = _positions[indexA].c;
                float aA = _positions[indexA].a;
                Vector2F cB = _positions[indexB].c;
                float aB = _positions[indexB].a;

                // Solve normal constraints
                for (int j = 0; j < pointCount; ++j)
                {
                    Transform xfA = new Transform(Vector2F.Zero, aA);
                    Transform xfB = new Transform(Vector2F.Zero, aB);
                    xfA.p = cA - Complex.Multiply(ref localCenterA, ref xfA.q);
                    xfB.p = cB - Complex.Multiply(ref localCenterB, ref xfB.q);

                    PositionSolverManifold.Initialize(pc, ref xfA, ref xfB, j, out Vector2F normal, out Vector2F point, out float separation);

                    Vector2F rA = point - cA;
                    Vector2F rB = point - cB;

                    // Track max constraint error.
                    minSeparation = Math.Min(minSeparation, separation);

                    // Prevent large corrections and allow slop.
                    float C = MathUtils.Clamp(SettingEnv.Baumgarte * (separation + SettingEnv.LinearSlop), -SettingEnv.MaxLinearCorrection, 0.0f);

                    // Compute the effective mass.
                    float rnA = MathUtils.Cross(ref rA, ref normal);
                    float rnB = MathUtils.Cross(ref rB, ref normal);
                    float K = mA + mB + iA * rnA * rnA + iB * rnB * rnB;

                    // Compute normal impulse
                    float impulse = K > 0.0f ? -C / K : 0.0f;

                    Vector2F P = impulse * normal;

                    cA -= mA * P;
                    aA -= iA * MathUtils.Cross(ref rA, ref P);

                    cB += mB * P;
                    aB += iB * MathUtils.Cross(ref rB, ref P);
                }

                _positions[indexA].c = cA;
                _positions[indexA].a = aA;
                _positions[indexB].c = cB;
                _positions[indexB].a = aB;


                // Unlock bodies.
                Interlocked.Exchange(ref _locks[orderedIndexB], 0);
                Interlocked.Exchange(ref _locks[orderedIndexA], 0);
            }

            // We can't expect minSpeparation >= -b2_linearSlop because we don't
            // push the separation above -b2_linearSlop.
            return minSeparation >= -3.0f * SettingEnv.LinearSlop;
        }

        // Sequential position solver for position constraints.
        /// <summary>
        ///     Describes whether this instance solve toi position constraints
        /// </summary>
        /// <param name="toiIndexA">The toi index</param>
        /// <param name="toiIndexB">The toi index</param>
        /// <returns>The bool</returns>
        public bool SolveTOIPositionConstraints(int toiIndexA, int toiIndexB)
        {
            float minSeparation = 0.0f;

            for (int i = 0; i < _count; ++i)
            {
                ContactPositionConstraint pc = _positionConstraints[i];

                int indexA = pc.indexA;
                int indexB = pc.indexB;
                Vector2F localCenterA = pc.localCenterA;
                Vector2F localCenterB = pc.localCenterB;
                int pointCount = pc.pointCount;

                float mA = 0.0f;
                float iA = 0.0f;
                if (indexA == toiIndexA || indexA == toiIndexB)
                {
                    mA = pc.invMassA;
                    iA = pc.invIA;
                }

                float mB = 0.0f;
                float iB = 0.0f;
                if (indexB == toiIndexA || indexB == toiIndexB)
                {
                    mB = pc.invMassB;
                    iB = pc.invIB;
                }

                Vector2F cA = _positions[indexA].c;
                float aA = _positions[indexA].a;

                Vector2F cB = _positions[indexB].c;
                float aB = _positions[indexB].a;

                // Solve normal constraints
                for (int j = 0; j < pointCount; ++j)
                {
                    Transform xfA = new Transform(Vector2F.Zero, aA);
                    Transform xfB = new Transform(Vector2F.Zero, aB);
                    xfA.p = cA - Complex.Multiply(ref localCenterA, ref xfA.q);
                    xfB.p = cB - Complex.Multiply(ref localCenterB, ref xfB.q);

                    PositionSolverManifold.Initialize(pc, ref xfA, ref xfB, j, out Vector2F normal, out Vector2F point, out float separation);

                    Vector2F rA = point - cA;
                    Vector2F rB = point - cB;

                    // Track max constraint error.
                    minSeparation = Math.Min(minSeparation, separation);

                    // Prevent large corrections and allow slop.
                    float C = MathUtils.Clamp(SettingEnv.Baumgarte * (separation + SettingEnv.LinearSlop), -SettingEnv.MaxLinearCorrection, 0.0f);

                    // Compute the effective mass.
                    float rnA = MathUtils.Cross(ref rA, ref normal);
                    float rnB = MathUtils.Cross(ref rB, ref normal);
                    float K = mA + mB + iA * rnA * rnA + iB * rnB * rnB;

                    // Compute normal impulse
                    float impulse = K > 0.0f ? -C / K : 0.0f;

                    Vector2F P = impulse * normal;

                    cA -= mA * P;
                    aA -= iA * MathUtils.Cross(ref rA, ref P);

                    cB += mB * P;
                    aB += iB * MathUtils.Cross(ref rB, ref P);
                }

                _positions[indexA].c = cA;
                _positions[indexA].a = aA;

                _positions[indexB].c = cB;
                _positions[indexB].a = aB;
            }

            // We can't expect minSpeparation >= -b2_linearSlop because we don't
            // push the separation above -b2_linearSlop.
            return minSeparation >= -1.5f * SettingEnv.LinearSlop;
        }

        /// <summary>
        ///     Solves the velocity constraints callback using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        private static void SolveVelocityConstraintsCallback(object state)
        {
            SolveVelocityConstraintsState svcState = (SolveVelocityConstraintsState) state;

            svcState.ContactSolver.SolveVelocityConstraints(svcState.Start, svcState.End);
            SolveVelocityConstraintsState.Return(svcState);
            svcState.ContactSolver.SolveVelocityConstraintsWaitLock.Signal();
        }

        /// <summary>
        ///     The world manifold class
        /// </summary>
        public static class WorldManifold
        {
            /// <summary>
            ///     Evaluate the manifold with supplied transforms. This assumes
            ///     modest motion from the original state. This does not change the
            ///     point count, impulses, etc. The radii must come from the Shapes
            ///     that generated the manifold.
            /// </summary>
            /// <param name="manifold">The manifold.</param>
            /// <param name="xfA">The transform for A.</param>
            /// <param name="radiusA">The radius for A.</param>
            /// <param name="xfB">The transform for B.</param>
            /// <param name="radiusB">The radius for B.</param>
            /// <param name="normal">World vector pointing from A to B</param>
            /// <param name="points">Torld contact point (point of intersection).</param>
            public static void Initialize(ref Manifold manifold, ref Transform xfA, float radiusA, ref Transform xfB, float radiusB, out Vector2F normal, out FixedArray2<Vector2F> points)
            {
                normal = Vector2F.Zero;
                points = new FixedArray2<Vector2F>();

                if (manifold.PointCount == 0)
                {
                    return;
                }

                switch (manifold.Type)
                {
                    case ManifoldType.Circles:
                    {
                        normal = new Vector2F(1.0f, 0.0f);
                        Vector2F pointA = Transform.Multiply(ref manifold.LocalPoint, ref xfA);
                        Vector2F pointB = Transform.Multiply(manifold.Points[0].LocalPoint, ref xfB);
                        if (Vector2F.DistanceSquared(pointA, pointB) > SettingEnv.Epsilon * SettingEnv.Epsilon)
                        {
                            normal = pointB - pointA;
                            normal.Normalize();
                        }

                        Vector2F cA = pointA + radiusA * normal;
                        Vector2F cB = pointB - radiusB * normal;
                        points[0] = 0.5f * (cA + cB);
                    }
                        break;

                    case ManifoldType.FaceA:
                    {
                        normal = Complex.Multiply(ref manifold.LocalNormal, ref xfA.q);
                        Vector2F planePoint = Transform.Multiply(ref manifold.LocalPoint, ref xfA);

                        for (int i = 0; i < manifold.PointCount; ++i)
                        {
                            Vector2F clipPoint = Transform.Multiply(manifold.Points[i].LocalPoint, ref xfB);
                            Vector2F cA = clipPoint + (radiusA - Vector2F.Dot(clipPoint - planePoint, normal)) * normal;
                            Vector2F cB = clipPoint - radiusB * normal;
                            points[i] = 0.5f * (cA + cB);
                        }
                    }
                        break;

                    case ManifoldType.FaceB:
                    {
                        normal = Complex.Multiply(ref manifold.LocalNormal, ref xfB.q);
                        Vector2F planePoint = Transform.Multiply(ref manifold.LocalPoint, ref xfB);

                        for (int i = 0; i < manifold.PointCount; ++i)
                        {
                            Vector2F clipPoint = Transform.Multiply(manifold.Points[i].LocalPoint, ref xfA);
                            Vector2F cB = clipPoint + (radiusB - Vector2F.Dot(clipPoint - planePoint, normal)) * normal;
                            Vector2F cA = clipPoint - radiusA * normal;
                            points[i] = 0.5f * (cA + cB);
                        }

                        // Ensure normal points from A to B.
                        normal = -normal;
                    }
                        break;
                }
            }
        }

        /// <summary>
        ///     The position solver manifold class
        /// </summary>
        private static class PositionSolverManifold
        {
            /// <summary>
            ///     Initializes the pc
            /// </summary>
            /// <param name="pc">The pc</param>
            /// <param name="xfA">The xf</param>
            /// <param name="xfB">The xf</param>
            /// <param name="index">The index</param>
            /// <param name="normal">The normal</param>
            /// <param name="point">The point</param>
            /// <param name="separation">The separation</param>
            public static void Initialize(ContactPositionConstraint pc, ref Transform xfA, ref Transform xfB, int index, out Vector2F normal, out Vector2F point, out float separation)
            {
                Debug.Assert(pc.pointCount > 0);

                switch (pc.type)
                {
                    case ManifoldType.Circles:
                    {
                        Vector2F pointA = Transform.Multiply(ref pc.localPoint, ref xfA);
                        Vector2F pointB = Transform.Multiply(pc.localPoints[0], ref xfB);
                        normal = pointB - pointA;

                        // Handle zero normalization
                        if (normal != Vector2F.Zero)
                        {
                            normal.Normalize();
                        }

                        point = 0.5f * (pointA + pointB);
                        separation = Vector2F.Dot(pointB - pointA, normal) - pc.radiusA - pc.radiusB;
                    }
                        break;

                    case ManifoldType.FaceA:
                    {
                        Complex.Multiply(ref pc.localNormal, ref xfA.q, out normal);
                        Vector2F planePoint = Transform.Multiply(ref pc.localPoint, ref xfA);

                        Vector2F clipPoint = Transform.Multiply(pc.localPoints[index], ref xfB);
                        separation = Vector2F.Dot(clipPoint - planePoint, normal) - pc.radiusA - pc.radiusB;
                        point = clipPoint;
                    }
                        break;

                    case ManifoldType.FaceB:
                    {
                        Complex.Multiply(ref pc.localNormal, ref xfB.q, out normal);
                        Vector2F planePoint = Transform.Multiply(ref pc.localPoint, ref xfB);

                        Vector2F clipPoint = Transform.Multiply(pc.localPoints[index], ref xfA);
                        separation = Vector2F.Dot(clipPoint - planePoint, normal) - pc.radiusA - pc.radiusB;
                        point = clipPoint;

                        // Ensure normal points from A to B
                        normal = -normal;
                    }
                        break;
                    default:
                        normal = Vector2F.Zero;
                        point = Vector2F.Zero;
                        separation = 0;
                        break;
                }
            }
        }

        /// <summary>
        ///     The solve velocity constraints state class
        /// </summary>
        private class SolveVelocityConstraintsState
        {
            /// <summary>
            ///     The solve velocity constraints state
            /// </summary>
            private static readonly ConcurrentQueue<SolveVelocityConstraintsState> _queue = new ConcurrentQueue<SolveVelocityConstraintsState>(); // pool

            /// <summary>
            ///     The contact solver
            /// </summary>
            public ContactSolver ContactSolver;

            /// <summary>
            ///     Initializes a new instance of the <see cref="SolveVelocityConstraintsState" /> class
            /// </summary>
            private SolveVelocityConstraintsState()
            {
            }

            /// <summary>
            ///     Gets or sets the value of the start
            /// </summary>
            public int Start { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the end
            /// </summary>
            public int End { get; private set; }

            /// <summary>
            ///     Gets the contact solver
            /// </summary>
            /// <param name="contactSolver">The contact solver</param>
            /// <param name="start">The start</param>
            /// <param name="end">The end</param>
            /// <returns>The result</returns>
            internal static object Get(ContactSolver contactSolver, int start, int end)
            {
                if (!_queue.TryDequeue(out SolveVelocityConstraintsState result))
                {
                    result = new SolveVelocityConstraintsState();
                }

                result.ContactSolver = contactSolver;
                result.Start = start;
                result.End = end;

                return result;
            }

            /// <summary>
            ///     Returns the state
            /// </summary>
            /// <param name="state">The state</param>
            internal static void Return(object state)
            {
                _queue.Enqueue((SolveVelocityConstraintsState) state);
            }
        }
    }
}