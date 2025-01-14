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
    public class ContactSolver : IDisposable
    {
        /// <summary>
        ///     The countdown event
        /// </summary>
        private readonly CountdownEvent solveVelocityConstraintsWaitLock = new CountdownEvent(0);

        /// <summary>
        ///     The contacts
        /// </summary>
        public Contact[] Contacts;

        /// <summary>
        ///     The count
        /// </summary>
        public int Count;

        /// <summary>
        ///     The locks
        /// </summary>
        internal int[] Locks;

        /// <summary>
        ///     The position constraints
        /// </summary>
        public ContactPositionConstraint[] PositionConstraints;

        /// <summary>
        ///     The position constraints multithread threshold
        /// </summary>
        private int _positionConstraintsMultithreadThreshold;

        /// <summary>
        ///     The positions
        /// </summary>
        internal SolverPosition[] Positions;

        /// <summary>
        ///     The velocities
        /// </summary>
        internal SolverVelocity[] Velocities;

        /// <summary>
        ///     The velocity constraints
        /// </summary>
        public ContactVelocityConstraint[] VelocityConstraints;

        /// <summary>
        ///     The velocity constraints multithread threshold
        /// </summary>
        private int _velocityConstraintsMultithreadThreshold;

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            solveVelocityConstraintsWaitLock?.Dispose();
        }

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
            Count = count;
            Positions = positions;
            Velocities = velocities;
            Locks = locks;
            Contacts = contacts;
            _velocityConstraintsMultithreadThreshold = velocityConstraintsMultithreadThreshold;
            _positionConstraintsMultithreadThreshold = positionConstraintsMultithreadThreshold;

            // grow the array
            if (VelocityConstraints == null || VelocityConstraints.Length < count)
            {
                int newBufferCount = Math.Max(count, 32);
                newBufferCount = newBufferCount + ((newBufferCount * 2) >> 4); // grow by x1.125f
                newBufferCount = (newBufferCount + 31) & ~31; // grow in chunks of 32.
                int oldBufferCount = VelocityConstraints == null ? 0 : VelocityConstraints.Length;
                Array.Resize(ref VelocityConstraints, newBufferCount);
                Array.Resize(ref PositionConstraints, newBufferCount);

                for (int i = oldBufferCount; i < newBufferCount; i++)
                {
                    VelocityConstraints[i] = new ContactVelocityConstraint();
                    PositionConstraints[i] = new ContactPositionConstraint();
                }
            }

            // Initialize position independent portions of the constraints.
            for (int i = 0; i < Count; ++i)
            {
                Contact contact = contacts[i];

                Fixture fixtureA = contact.FixtureA;
                Fixture fixtureB = contact.FixtureB;
                Shape shapeA = fixtureA.Shape;
                Shape shapeB = fixtureB.Shape;
                float radiusA = shapeA.GetRadius;
                float radiusB = shapeB.GetRadius;
                Body bodyA = fixtureA.Body;
                Body bodyB = fixtureB.Body;
                Manifold manifold = contact.Manifold;

                int pointCount = manifold.PointCount;
                Debug.Assert(pointCount > 0);

                ContactVelocityConstraint vc = VelocityConstraints[i];
                vc.Friction = contact.Friction;
                vc.Restitution = contact.Restitution;
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

                ContactPositionConstraint pc = PositionConstraints[i];
                pc.IndexA = bodyA.IslandIndex;
                pc.IndexB = bodyB.IslandIndex;
                pc.InvMassA = bodyA.InvMass;
                pc.InvMassB = bodyB.InvMass;
                pc.LocalCenterA = bodyA._sweep.LocalCenter;
                pc.LocalCenterB = bodyB._sweep.LocalCenter;
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
                        vcp.NormalImpulse = step.DtRatio * cp.NormalImpulse;
                        vcp.TangentImpulse = step.DtRatio * cp.TangentImpulse;
                    }
                    else
                    {
                        vcp.NormalImpulse = 0.0f;
                        vcp.TangentImpulse = 0.0f;
                    }

                    vcp.RA = Vector2F.Zero;
                    vcp.RB = Vector2F.Zero;
                    vcp.NormalMass = 0.0f;
                    vcp.TangentMass = 0.0f;
                    vcp.VelocityBias = 0.0f;

                    pc.LocalPoints[j] = cp.LocalPoint;
                }
            }
        }

        /// <summary>
        ///     Initializes the velocity constraints
        /// </summary>
        public void InitializeVelocityConstraints()
        {
            for (int i = 0; i < Count; ++i)
            {
                ContactVelocityConstraint vc = VelocityConstraints[i];
                ContactPositionConstraint pc = PositionConstraints[i];

                float radiusA = pc.RadiusA;
                float radiusB = pc.RadiusB;
                Manifold manifold = Contacts[vc.ContactIndex].Manifold;

                int indexA = vc.IndexA;
                int indexB = vc.IndexB;

                float mA = vc.InvMassA;
                float mB = vc.InvMassB;
                float iA = vc.InvIa;
                float iB = vc.InvIb;
                Vector2F localCenterA = pc.LocalCenterA;
                Vector2F localCenterB = pc.LocalCenterB;

                Vector2F cA = Positions[indexA].C;
                float aA = Positions[indexA].A;
                Vector2F vA = Velocities[indexA].v;
                float wA = Velocities[indexA].w;

                Vector2F cB = Positions[indexB].C;
                float aB = Positions[indexB].A;
                Vector2F vB = Velocities[indexB].v;
                float wB = Velocities[indexB].w;

                Debug.Assert(manifold.PointCount > 0);

                Transform xfA = new Transform(Vector2F.Zero, aA);
                Transform xfB = new Transform(Vector2F.Zero, aB);
                xfA.p = cA - Complex.Multiply(ref localCenterA, ref xfA.q);
                xfB.p = cB - Complex.Multiply(ref localCenterB, ref xfB.q);

                WorldManifold.Initialize(ref manifold, ref xfA, radiusA, ref xfB, radiusB, out Vector2F normal, out FixedArray2<Vector2F> points);

                vc.Normal = normal;
                Vector2F tangent = MathUtils.Rot270(ref vc.Normal);

                int pointCount = vc.PointCount;
                for (int j = 0; j < pointCount; ++j)
                {
                    VelocityConstraintPoint vcp = vc.Points[j];

                    vcp.RA = points[j] - cA;
                    vcp.RB = points[j] - cB;

                    float rnA = MathUtils.Cross(ref vcp.RA, ref vc.Normal);
                    float rnB = MathUtils.Cross(ref vcp.RB, ref vc.Normal);

                    float kNormal = mA + mB + iA * rnA * rnA + iB * rnB * rnB;

                    vcp.NormalMass = kNormal > 0.0f ? 1.0f / kNormal : 0.0f;


                    float rtA = MathUtils.Cross(ref vcp.RA, ref tangent);
                    float rtB = MathUtils.Cross(ref vcp.RB, ref tangent);

                    float kTangent = mA + mB + iA * rtA * rtA + iB * rtB * rtB;

                    vcp.TangentMass = kTangent > 0.0f ? 1.0f / kTangent : 0.0f;

                    // Setup a velocity bias for restitution.
                    vcp.VelocityBias = 0.0f;
                    float vRel = Vector2F.Dot(vc.Normal, vB + MathUtils.Cross(wB, ref vcp.RB) - vA - MathUtils.Cross(wA, ref vcp.RA));
                    if (vRel < -SettingEnv.VelocityThreshold)
                    {
                        vcp.VelocityBias = -vc.Restitution * vRel;
                    }
                }

                // If we have two points, then prepare the block solver.
                if (vc.PointCount == 2)
                {
                    VelocityConstraintPoint vcp1 = vc.Points[0];
                    VelocityConstraintPoint vcp2 = vc.Points[1];

                    float rn1A = MathUtils.Cross(ref vcp1.RA, ref vc.Normal);
                    float rn1B = MathUtils.Cross(ref vcp1.RB, ref vc.Normal);
                    float rn2A = MathUtils.Cross(ref vcp2.RA, ref vc.Normal);
                    float rn2B = MathUtils.Cross(ref vcp2.RB, ref vc.Normal);

                    float k11 = mA + mB + iA * rn1A * rn1A + iB * rn1B * rn1B;
                    float k22 = mA + mB + iA * rn2A * rn2A + iB * rn2B * rn2B;
                    float k12 = mA + mB + iA * rn1A * rn2A + iB * rn1B * rn2B;

                    // Ensure a reasonable condition number.
                    const float kMaxConditionNumber = 1000.0f;
                    if (k11 * k11 < kMaxConditionNumber * (k11 * k22 - k12 * k12))
                    {
                        // K is safe to invert.
                        vc.K.Ex = new Vector2F(k11, k12);
                        vc.K.Ey = new Vector2F(k12, k22);
                        vc.NormalMass = vc.K.Inverse;
                    }
                    else
                    {
                        // The constraints are redundant, just use one.

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
            for (int i = 0; i < Count; ++i)
            {
                ContactVelocityConstraint vc = VelocityConstraints[i];

                int indexA = vc.IndexA;
                int indexB = vc.IndexB;
                float mA = vc.InvMassA;
                float iA = vc.InvIa;
                float mB = vc.InvMassB;
                float iB = vc.InvIb;
                int pointCount = vc.PointCount;

                Vector2F vA = Velocities[indexA].v;
                float wA = Velocities[indexA].w;
                Vector2F vB = Velocities[indexB].v;
                float wB = Velocities[indexB].w;

                Vector2F normal = vc.Normal;
                Vector2F tangent = MathUtils.Rot270(ref normal);

                for (int j = 0; j < pointCount; ++j)
                {
                    VelocityConstraintPoint vcp = vc.Points[j];
                    Vector2F p = vcp.NormalImpulse * normal + vcp.TangentImpulse * tangent;
                    wA -= iA * MathUtils.Cross(ref vcp.RA, ref p);
                    vA -= mA * p;
                    wB += iB * MathUtils.Cross(ref vcp.RB, ref p);
                    vB += mB * p;
                }

                Velocities[indexA].v = vA;
                Velocities[indexA].w = wA;
                Velocities[indexB].v = vB;
                Velocities[indexB].w = wB;
            }
        }

        /// <summary>
        ///     Solves the velocity constraints
        /// </summary>
        public void SolveVelocityConstraints()
        {
            if ((Count >= _velocityConstraintsMultithreadThreshold) && (Environment.ProcessorCount > 1))
            {
                if (Count == 0)
                {
                    return;
                }

                int batchSize = (int) Math.Ceiling((float) Count / Environment.ProcessorCount);
                int batches = (int) Math.Ceiling((float) Count / batchSize);


                solveVelocityConstraintsWaitLock.Reset(batches);
                for (int i = 0; i < batches; i++)
                {
                    int start = i * batchSize;
                    int end = Math.Min(start + batchSize, Count);
                    ThreadPool.QueueUserWorkItem(SolveVelocityConstraintsCallback, SolveVelocityConstraintsState.Get(this, start, end));
                }

                // We avoid SolveVelocityConstraintsWaitLock.Wait(); because it spins a few milliseconds before going into sleep. Going into sleep(0) directly in a while loop is faster.
                while (solveVelocityConstraintsWaitLock.CurrentCount > 0)
                {
                    Thread.Sleep(0);
                }

                SolveVelocityConstraints(0, Count);
            }
            else
            {
                SolveVelocityConstraints(0, Count);
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
                ContactVelocityConstraint vc = VelocityConstraints[i];


                // find lower order item
                int orderedIndexA = vc.IndexA;
                int orderedIndexB = vc.IndexB;
                if (orderedIndexB < orderedIndexA)
                {
                    orderedIndexA = vc.IndexB;
                    orderedIndexB = vc.IndexA;
                }

                for (;;)
                {
                    if (Interlocked.CompareExchange(ref Locks[orderedIndexA], 1, 0) == 0)
                    {
                        if (Interlocked.CompareExchange(ref Locks[orderedIndexB], 1, 0) == 0)
                        {
                            break;
                        }

                        Interlocked.Exchange(ref Locks[orderedIndexA], 0);
                    }

                    Thread.Sleep(0);
                }


                int indexA = vc.IndexA;
                int indexB = vc.IndexB;
                float mA = vc.InvMassA;
                float iA = vc.InvIa;
                float mB = vc.InvMassB;
                float iB = vc.InvIb;
                int pointCount = vc.PointCount;

                Vector2F vA = Velocities[indexA].v;
                float wA = Velocities[indexA].w;
                Vector2F vB = Velocities[indexB].v;
                float wB = Velocities[indexB].w;

                Vector2F normal = vc.Normal;
                Vector2F tangent = MathUtils.Rot270(ref normal);
                float friction = vc.Friction;

                Debug.Assert(pointCount == 1 || pointCount == 2);

                // Solve tangent constraints first because non-penetration is more important
                // than friction.
                for (int j = 0; j < pointCount; ++j)
                {
                    VelocityConstraintPoint vcp = vc.Points[j];

                    // Relative velocity at contact
                    Vector2F dv = vB + MathUtils.Cross(wB, ref vcp.RB) - vA - MathUtils.Cross(wA, ref vcp.RA);

                    // Compute tangent force
                    float vt = Vector2F.Dot(dv, tangent) - vc.TangentSpeed;
                    float lambda = vcp.TangentMass * -vt;

                    // b2Clamp the accumulated force
                    float maxFriction = friction * vcp.NormalImpulse;
                    float newImpulse = MathUtils.Clamp(vcp.TangentImpulse + lambda, -maxFriction, maxFriction);
                    lambda = newImpulse - vcp.TangentImpulse;
                    vcp.TangentImpulse = newImpulse;

                    // Apply contact impulse
                    Vector2F p = lambda * tangent;

                    vA -= mA * p;
                    wA -= iA * MathUtils.Cross(ref vcp.RA, ref p);

                    vB += mB * p;
                    wB += iB * MathUtils.Cross(ref vcp.RB, ref p);
                }

                // Solve normal constraints
                if (vc.PointCount == 1)
                {
                    VelocityConstraintPoint vcp = vc.Points[0];

                    // Relative velocity at contact
                    Vector2F dv = vB + MathUtils.Cross(wB, ref vcp.RB) - vA - MathUtils.Cross(wA, ref vcp.RA);

                    // Compute normal impulse
                    float vn = Vector2F.Dot(dv, normal);
                    float lambda = -vcp.NormalMass * (vn - vcp.VelocityBias);

                    // b2Clamp the accumulated impulse
                    float newImpulse = Math.Max(vcp.NormalImpulse + lambda, 0.0f);
                    lambda = newImpulse - vcp.NormalImpulse;
                    vcp.NormalImpulse = newImpulse;

                    // Apply contact impulse
                    Vector2F p = lambda * normal;
                    vA -= mA * p;
                    wA -= iA * MathUtils.Cross(ref vcp.RA, ref p);

                    vB += mB * p;
                    wB += iB * MathUtils.Cross(ref vcp.RB, ref p);
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

                    VelocityConstraintPoint cp1 = vc.Points[0];
                    VelocityConstraintPoint cp2 = vc.Points[1];

                    Vector2F a = new Vector2F(cp1.NormalImpulse, cp2.NormalImpulse);
                    Debug.Assert((a.X >= 0.0f) && (a.Y >= 0.0f));

                    // Relative velocity at contact
                    Vector2F dv1 = vB + MathUtils.Cross(wB, ref cp1.RB) - vA - MathUtils.Cross(wA, ref cp1.RA);
                    Vector2F dv2 = vB + MathUtils.Cross(wB, ref cp2.RB) - vA - MathUtils.Cross(wA, ref cp2.RA);

                    // Compute normal velocity
                    float vn1 = Vector2F.Dot(dv1, normal);
                    float vn2 = Vector2F.Dot(dv2, normal);

                    Vector2F b = new Vector2F();
                    b.X = vn1 - cp1.VelocityBias;
                    b.Y = vn2 - cp2.VelocityBias;

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
                        Vector2F x = -MathUtils.Mul(ref vc.NormalMass, ref b);

                        if ((x.X >= 0.0f) && (x.Y >= 0.0f))
                        {
                            // Get the incremental impulse
                            Vector2F d = x - a;

                            // Apply incremental impulse
                            Vector2F p1 = d.X * normal;
                            Vector2F p2 = d.Y * normal;
                            vA -= mA * (p1 + p2);
                            wA -= iA * (MathUtils.Cross(ref cp1.RA, ref p1) + MathUtils.Cross(ref cp2.RA, ref p2));

                            vB += mB * (p1 + p2);
                            wB += iB * (MathUtils.Cross(ref cp1.RB, ref p1) + MathUtils.Cross(ref cp2.RB, ref p2));

                            // Accumulate
                            cp1.NormalImpulse = x.X;
                            cp2.NormalImpulse = x.Y;

                            break;
                        }

                        //
                        // Case 2: vn1 = 0 and x2 = 0
                        //
                        //   0 = a11 * x1 + a12 * 0 + b1' 
                        // vn2 = a21 * x1 + a22 * 0 + b2'
                        //
                        x.X = -cp1.NormalMass * b.X;
                        x.Y = 0.0f;
                        vn1 = 0.0f;
                        vn2 = vc.K.Ex.Y * x.X + b.Y;

                        if ((x.X >= 0.0f) && (vn2 >= 0.0f))
                        {
                            // Get the incremental impulse
                            Vector2F d = x - a;

                            // Apply incremental impulse
                            Vector2F p1 = d.X * normal;
                            Vector2F p2 = d.Y * normal;
                            vA -= mA * (p1 + p2);
                            wA -= iA * (MathUtils.Cross(ref cp1.RA, ref p1) + MathUtils.Cross(ref cp2.RA, ref p2));

                            vB += mB * (p1 + p2);
                            wB += iB * (MathUtils.Cross(ref cp1.RB, ref p1) + MathUtils.Cross(ref cp2.RB, ref p2));

                            // Accumulate
                            cp1.NormalImpulse = x.X;
                            cp2.NormalImpulse = x.Y;

                            break;
                        }


                        //
                        // Case 3: vn2 = 0 and x1 = 0
                        //
                        // vn1 = a11 * 0 + a12 * x2 + b1' 
                        //   0 = a21 * 0 + a22 * x2 + b2'
                        //
                        x.X = 0.0f;
                        x.Y = -cp2.NormalMass * b.Y;
                        vn1 = vc.K.Ey.X * x.Y + b.X;
                        vn2 = 0.0f;

                        if ((x.Y >= 0.0f) && (vn1 >= 0.0f))
                        {
                            // Resubstitute for the incremental impulse
                            Vector2F d = x - a;

                            // Apply incremental impulse
                            Vector2F p1 = d.X * normal;
                            Vector2F p2 = d.Y * normal;
                            vA -= mA * (p1 + p2);
                            wA -= iA * (MathUtils.Cross(ref cp1.RA, ref p1) + MathUtils.Cross(ref cp2.RA, ref p2));

                            vB += mB * (p1 + p2);
                            wB += iB * (MathUtils.Cross(ref cp1.RB, ref p1) + MathUtils.Cross(ref cp2.RB, ref p2));

                            // Accumulate
                            cp1.NormalImpulse = x.X;
                            cp2.NormalImpulse = x.Y;

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
                            Vector2F p1 = d.X * normal;
                            Vector2F p2 = d.Y * normal;
                            vA -= mA * (p1 + p2);
                            wA -= iA * (MathUtils.Cross(ref cp1.RA, ref p1) + MathUtils.Cross(ref cp2.RA, ref p2));

                            vB += mB * (p1 + p2);
                            wB += iB * (MathUtils.Cross(ref cp1.RB, ref p1) + MathUtils.Cross(ref cp2.RB, ref p2));

                            // Accumulate
                            cp1.NormalImpulse = x.X;
                            cp2.NormalImpulse = x.Y;
                        }

                        break;
                    }
                }

                Velocities[indexA].v = vA;
                Velocities[indexA].w = wA;
                Velocities[indexB].v = vB;
                Velocities[indexB].w = wB;


                Interlocked.Exchange(ref Locks[orderedIndexB], 0);
                Interlocked.Exchange(ref Locks[orderedIndexA], 0);
            }
        }

        /// <summary>
        ///     Stores the impulses
        /// </summary>
        public void StoreImpulses()
        {
            for (int i = 0; i < Count; ++i)
            {
                ContactVelocityConstraint vc = VelocityConstraints[i];
                Manifold manifold = Contacts[vc.ContactIndex].Manifold;

                for (int j = 0; j < vc.PointCount; ++j)
                {
                    ManifoldPoint point = manifold.Points[j];
                    point.NormalImpulse = vc.Points[j].NormalImpulse;
                    point.TangentImpulse = vc.Points[j].TangentImpulse;
                    manifold.Points[j] = point;
                }

                Contacts[vc.ContactIndex].Manifold = manifold;
            }
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <returns>The contacts okay</returns>
        public bool SolvePositionConstraints()
        {
            bool contactsOkay = false;

            if ((Count >= _positionConstraintsMultithreadThreshold) && (Environment.ProcessorCount > 1))
            {
                if (Count == 0)
                {
                    return true;
                }

                int batchSize = (int) Math.Ceiling((float) Count / Environment.ProcessorCount);
                int batches = (int) Math.Ceiling((float) Count / batchSize);


                Parallel.For(0, batches, i =>
                {
                    int start = i * batchSize;
                    int end = Math.Min(start + batchSize, Count);
                    bool res = SolvePositionConstraints(start, end);
                    contactsOkay = contactsOkay || res;
                });

                contactsOkay = SolvePositionConstraints(0, Count);
            }
            else
            {
                contactsOkay = SolvePositionConstraints(0, Count);
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
                ContactPositionConstraint pc = PositionConstraints[i];


                // Find lower order item.
                int orderedIndexA = pc.IndexA;
                int orderedIndexB = pc.IndexB;
                if (orderedIndexB < orderedIndexA)
                {
                    orderedIndexA = pc.IndexB;
                    orderedIndexB = pc.IndexA;
                }

                // Lock bodies.
                for (;;)
                {
                    if (Interlocked.CompareExchange(ref Locks[orderedIndexA], 1, 0) == 0)
                    {
                        if (Interlocked.CompareExchange(ref Locks[orderedIndexB], 1, 0) == 0)
                        {
                            break;
                        }

                        Interlocked.Exchange(ref Locks[orderedIndexA], 0);
                    }

                    Thread.Sleep(0);
                }


                int indexA = pc.IndexA;
                int indexB = pc.IndexB;
                Vector2F localCenterA = pc.LocalCenterA;
                float mA = pc.InvMassA;
                float iA = pc.InvIa;
                Vector2F localCenterB = pc.LocalCenterB;
                float mB = pc.InvMassB;
                float iB = pc.InvIb;
                int pointCount = pc.PointCount;

                Vector2F cA = Positions[indexA].C;
                float aA = Positions[indexA].A;
                Vector2F cB = Positions[indexB].C;
                float aB = Positions[indexB].A;

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
                    float c = MathUtils.Clamp(SettingEnv.Baumgarte * (separation + SettingEnv.LinearSlop), -SettingEnv.MaxLinearCorrection, 0.0f);

                    // Compute the effective mass.
                    float rnA = MathUtils.Cross(ref rA, ref normal);
                    float rnB = MathUtils.Cross(ref rB, ref normal);
                    float k = mA + mB + iA * rnA * rnA + iB * rnB * rnB;

                    // Compute normal impulse
                    float impulse = k > 0.0f ? -c / k : 0.0f;

                    Vector2F p = impulse * normal;

                    cA -= mA * p;
                    aA -= iA * MathUtils.Cross(ref rA, ref p);

                    cB += mB * p;
                    aB += iB * MathUtils.Cross(ref rB, ref p);
                }

                Positions[indexA].C = cA;
                Positions[indexA].A = aA;
                Positions[indexB].C = cB;
                Positions[indexB].A = aB;


                // Unlock bodies.
                Interlocked.Exchange(ref Locks[orderedIndexB], 0);
                Interlocked.Exchange(ref Locks[orderedIndexA], 0);
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
        public bool SolveToiPositionConstraints(int toiIndexA, int toiIndexB)
        {
            float minSeparation = 0.0f;

            for (int i = 0; i < Count; ++i)
            {
                ContactPositionConstraint pc = PositionConstraints[i];

                int indexA = pc.IndexA;
                int indexB = pc.IndexB;
                Vector2F localCenterA = pc.LocalCenterA;
                Vector2F localCenterB = pc.LocalCenterB;
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

                Vector2F cA = Positions[indexA].C;
                float aA = Positions[indexA].A;

                Vector2F cB = Positions[indexB].C;
                float aB = Positions[indexB].A;

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
                    float c = MathUtils.Clamp(SettingEnv.Baumgarte * (separation + SettingEnv.LinearSlop), -SettingEnv.MaxLinearCorrection, 0.0f);

                    // Compute the effective mass.
                    float rnA = MathUtils.Cross(ref rA, ref normal);
                    float rnB = MathUtils.Cross(ref rB, ref normal);
                    float k = mA + mB + iA * rnA * rnA + iB * rnB * rnB;

                    // Compute normal impulse
                    float impulse = k > 0.0f ? -c / k : 0.0f;

                    Vector2F p = impulse * normal;

                    cA -= mA * p;
                    aA -= iA * MathUtils.Cross(ref rA, ref p);

                    cB += mB * p;
                    aB += iB * MathUtils.Cross(ref rB, ref p);
                }

                Positions[indexA].C = cA;
                Positions[indexA].A = aA;

                Positions[indexB].C = cB;
                Positions[indexB].A = aB;
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
            svcState.ContactSolver.solveVelocityConstraintsWaitLock.Signal();
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
                Debug.Assert(pc.PointCount > 0);

                switch (pc.Type)
                {
                    case ManifoldType.Circles:
                    {
                        Vector2F pointA = Transform.Multiply(ref pc.LocalPoint, ref xfA);
                        Vector2F pointB = Transform.Multiply(pc.LocalPoints[0], ref xfB);
                        normal = pointB - pointA;

                        // Handle zero normalization
                        if (normal != Vector2F.Zero)
                        {
                            normal.Normalize();
                        }

                        point = 0.5f * (pointA + pointB);
                        separation = Vector2F.Dot(pointB - pointA, normal) - pc.RadiusA - pc.RadiusB;
                    }
                        break;

                    case ManifoldType.FaceA:
                    {
                        Complex.Multiply(ref pc.LocalNormal, ref xfA.q, out normal);
                        Vector2F planePoint = Transform.Multiply(ref pc.LocalPoint, ref xfA);

                        Vector2F clipPoint = Transform.Multiply(pc.LocalPoints[index], ref xfB);
                        separation = Vector2F.Dot(clipPoint - planePoint, normal) - pc.RadiusA - pc.RadiusB;
                        point = clipPoint;
                    }
                        break;

                    case ManifoldType.FaceB:
                    {
                        Complex.Multiply(ref pc.LocalNormal, ref xfB.q, out normal);
                        Vector2F planePoint = Transform.Multiply(ref pc.LocalPoint, ref xfB);

                        Vector2F clipPoint = Transform.Multiply(pc.LocalPoints[index], ref xfA);
                        separation = Vector2F.Dot(clipPoint - planePoint, normal) - pc.RadiusA - pc.RadiusB;
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
            private static readonly ConcurrentQueue<SolveVelocityConstraintsState> Queue = new ConcurrentQueue<SolveVelocityConstraintsState>(); // pool

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
                if (!Queue.TryDequeue(out SolveVelocityConstraintsState result))
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
                Queue.Enqueue((SolveVelocityConstraintsState) state);
            }
        }
    }
}