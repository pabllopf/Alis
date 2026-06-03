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
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The contact solver class
    /// </summary>
    public class ContactSolver : IDisposable
    {
        /// <summary>
        ///     Bundles contact constraint data for impulse application.
        /// </summary>
        private readonly struct ContactConstraintData
        {
            public readonly VelocityConstraintPoint Cp1;
            public readonly VelocityConstraintPoint Cp2;
            public readonly Vector2F Normal;

            public ContactConstraintData(VelocityConstraintPoint cp1, VelocityConstraintPoint cp2, Vector2F normal)
            {
                Cp1 = cp1;
                Cp2 = cp2;
                Normal = normal;
            }
        }
        /// <summary>
        ///     The countdown event
        /// </summary>
        private readonly CountdownEvent solveVelocityConstraintsWaitLock = new CountdownEvent(0);

        /// <summary>
        ///     The position constraints multithread threshold
        /// </summary>
        private int _positionConstraintsMultithreadThreshold;

        /// <summary>
        ///     The velocity constraints multithread threshold
        /// </summary>
        private int _velocityConstraintsMultithreadThreshold;

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
                solveVelocityConstraintsWaitLock?.Dispose();
            }
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

            for (int i = 0; i < Count; ++i)
            {
                Contact contact = contacts[i];

                Fixture fixtureA = contact.FixtureA;
                Fixture fixtureB = contact.FixtureB;
                Shape shapeA = fixtureA.GetShape;
                Shape shapeB = fixtureB.GetShape;
                float radiusA = shapeA.GetRadius;
                float radiusB = shapeB.GetRadius;
                Body bodyA = fixtureA.GetBody;
                Body bodyB = fixtureB.GetBody;
                Manifold manifold = contact.Manifold;

                int pointCount = manifold.PointCount;
                ContactVelocityConstraint vc = VelocityConstraints[i];
                vc.Friction = contact.Friction;
                vc.Restitution = contact.Restitution;
                vc.TangentSpeed = contact.TangentSpeed;
                vc.IndexA = bodyA.GetIslandIndex;
                vc.IndexB = bodyB.GetIslandIndex;
                vc.InvMassA = bodyA.InvMass;
                vc.InvMassB = bodyB.InvMass;
                vc.InvIa = bodyA.InvI;
                vc.InvIb = bodyB.InvI;
                vc.ContactIndex = i;
                vc.PointCount = pointCount;
                vc.K.SetZero();
                vc.NormalMass.SetZero();

                ContactPositionConstraint pc = PositionConstraints[i];
                pc.IndexA = bodyA.GetIslandIndex;
                pc.IndexB = bodyB.GetIslandIndex;
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
                        vcp.NormalImpulse = step.DtRatio * cp.NormalImpulse;
                        vcp.TangentImpulse = step.DtRatio * cp.TangentImpulse;
                    }
                    else
                    {
                        vcp.NormalImpulse = 0.0f;
                        vcp.TangentImpulse = 0.0f;
                    }

                    vcp.Ra = Vector2F.Zero;
                    vcp.Rb = Vector2F.Zero;
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
                Vector2F vA = Velocities[indexA].V;
                float wA = Velocities[indexA].W;

                Vector2F cB = Positions[indexB].C;
                float aB = Positions[indexB].A;
                Vector2F vB = Velocities[indexB].V;
                float wB = Velocities[indexB].W;

                ControllerTransform xfA = new ControllerTransform(Vector2F.Zero, aA);
                ControllerTransform xfB = new ControllerTransform(Vector2F.Zero, aB);
                xfA.Position = cA - Complex.Multiply(ref localCenterA, ref xfA.Rotation);
                xfB.Position = cB - Complex.Multiply(ref localCenterB, ref xfB.Rotation);

                WorldManifold.Initialize(ref manifold, ref xfA, radiusA, ref xfB, radiusB, out Vector2F normal, out FixedArray2<Vector2F> points);

                vc.Normal = normal;
                Vector2F tangent = MathUtils.Rot270(ref vc.Normal);

                InitializeVelocityConstraintPoints(vc, points, new VelocityConstraintInitData(cA, cB, mA, mB, iA, iB, tangent, vA, wA, vB, wB));

                if (vc.PointCount == 2)
                {
                    VelocityConstraintPoint vcp1 = vc.Points[0];
                    VelocityConstraintPoint vcp2 = vc.Points[1];

                    float rn1A = MathUtils.Cross(ref vcp1.Ra, ref vc.Normal);
                    float rn1B = MathUtils.Cross(ref vcp1.Rb, ref vc.Normal);
                    float rn2A = MathUtils.Cross(ref vcp2.Ra, ref vc.Normal);
                    float rn2B = MathUtils.Cross(ref vcp2.Rb, ref vc.Normal);

                    float k11 = mA + mB + iA * rn1A * rn1A + iB * rn1B * rn1B;
                    float k22 = mA + mB + iA * rn2A * rn2A + iB * rn2B * rn2B;
                    float k12 = mA + mB + iA * rn1A * rn2A + iB * rn1B * rn2B;

                    const float kMaxConditionNumber = 1000.0f;
                    if (k11 * k11 < kMaxConditionNumber * (k11 * k22 - k12 * k12))
                    {
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

        private static void InitializeVelocityConstraintPoints(ContactVelocityConstraint vc, FixedArray2<Vector2F> points, VelocityConstraintInitData data)
        {
            Vector2F cA = data.cA, cB = data.cB;
            float mA = data.mA, mB = data.mB, iA = data.iA, iB = data.iB;
            Vector2F tangent = data.tangent;
            Vector2F vA = data.vA, vB = data.vB;
            float wA = data.wA, wB = data.wB;

            int pointCount = vc.PointCount;
            for (int j = 0; j < pointCount; ++j)
            {
                VelocityConstraintPoint vcp = vc.Points[j];

                vcp.Ra = points[j] - cA;
                vcp.Rb = points[j] - cB;

                float rnA = MathUtils.Cross(ref vcp.Ra, ref vc.Normal);
                float rnB = MathUtils.Cross(ref vcp.Rb, ref vc.Normal);

                float kNormal = mA + mB + iA * rnA * rnA + iB * rnB * rnB;

                vcp.NormalMass = kNormal > 0.0f ? 1.0f / kNormal : 0.0f;


                float rtA = MathUtils.Cross(ref vcp.Ra, ref tangent);
                float rtB = MathUtils.Cross(ref vcp.Rb, ref tangent);

                float kTangent = mA + mB + iA * rtA * rtA + iB * rtB * rtB;

                vcp.TangentMass = kTangent > 0.0f ? 1.0f / kTangent : 0.0f;

                vcp.VelocityBias = 0.0f;
                float vRel = Vector2F.Dot(vc.Normal, vB + MathUtils.Cross(wB, ref vcp.Rb) - vA - MathUtils.Cross(wA, ref vcp.Ra));
                if (vRel < -SettingEnv.VelocityThreshold)
                {
                    vcp.VelocityBias = -vc.Restitution * vRel;
                }
            }
        }

        /// <summary>
        ///     Warms the start
        /// </summary>
        public void WarmStart()
        {
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

                Vector2F vA = Velocities[indexA].V;
                float wA = Velocities[indexA].W;
                Vector2F vB = Velocities[indexB].V;
                float wB = Velocities[indexB].W;

                Vector2F normal = vc.Normal;
                Vector2F tangent = MathUtils.Rot270(ref normal);

                for (int j = 0; j < pointCount; ++j)
                {
                    VelocityConstraintPoint vcp = vc.Points[j];
                    Vector2F p = vcp.NormalImpulse * normal + vcp.TangentImpulse * tangent;
                    wA -= iA * MathUtils.Cross(ref vcp.Ra, ref p);
                    vA -= mA * p;
                    wB += iB * MathUtils.Cross(ref vcp.Rb, ref p);
                    vB += mB * p;
                }

                Velocities[indexA].V = vA;
                Velocities[indexA].W = wA;
                Velocities[indexB].V = vB;
                Velocities[indexB].W = wB;
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

                int orderedIndexA = vc.IndexA;
                int orderedIndexB = vc.IndexB;
                if (orderedIndexB < orderedIndexA)
                {
                    orderedIndexA = vc.IndexB;
                    orderedIndexB = vc.IndexA;
                }

                AcquireContactLocks(orderedIndexA, orderedIndexB);

                int indexA = vc.IndexA;
                int indexB = vc.IndexB;
                float mA = vc.InvMassA;
                float iA = vc.InvIa;
                float mB = vc.InvMassB;
                float iB = vc.InvIb;

                Vector2F vA = Velocities[indexA].V;
                float wA = Velocities[indexA].W;
                Vector2F vB = Velocities[indexB].V;
                float wB = Velocities[indexB].W;

                Vector2F normal = vc.Normal;
                float friction = vc.Friction;

                SolveFrictionImpulse(vc, ref vA, ref wA, ref vB, ref wB, ref normal, friction, mA, iA, mB, iB);

                if (vc.PointCount == 1)
                {
                    SolveSinglePointNormal(ref vA, ref wA, ref vB, ref wB, vc, ref normal, mA, iA, mB, iB);
                }
                else
                {
                    SolveTwoPointNormal(ref vA, ref wA, ref vB, ref wB, vc, ref normal, mA, iA, mB, iB);
                }

                Velocities[indexA].V = vA;
                Velocities[indexA].W = wA;
                Velocities[indexB].V = vB;
                Velocities[indexB].W = wB;

                ReleaseContactLocks(orderedIndexB, orderedIndexA);
            }
        }

        private void AcquireContactLocks(int indexA, int indexB)
        {
            while (true)
            {
                if (Interlocked.CompareExchange(ref Locks[indexA], 1, 0) == 0)
                {
                    if (Interlocked.CompareExchange(ref Locks[indexB], 1, 0) == 0)
                    {
                        break;
                    }

                    Interlocked.Exchange(ref Locks[indexA], 0);
                }

                Thread.Sleep(0);
            }
        }

        private void ReleaseContactLocks(int indexB, int indexA)
        {
            Interlocked.Exchange(ref Locks[indexB], 0);
            Interlocked.Exchange(ref Locks[indexA], 0);
        }

        private static void SolveFrictionImpulse(
            ContactVelocityConstraint vc,
            ref Vector2F vA, ref float wA, ref Vector2F vB, ref float wB,
            ref Vector2F normal, float friction,
            float mA, float iA, float mB, float iB)
        {
            Vector2F tangent = MathUtils.Rot270(ref normal);

            for (int j = 0; j < vc.PointCount; ++j)
            {
                VelocityConstraintPoint vcp = vc.Points[j];

                Vector2F dv = vB + MathUtils.Cross(wB, ref vcp.Rb) - vA - MathUtils.Cross(wA, ref vcp.Ra);

                float vt = Vector2F.Dot(dv, tangent) - vc.TangentSpeed;
                float lambda = vcp.TangentMass * -vt;

                float maxFriction = friction * vcp.NormalImpulse;
                float newImpulse = MathUtils.Clamp(vcp.TangentImpulse + lambda, -maxFriction, maxFriction);
                lambda = newImpulse - vcp.TangentImpulse;
                vcp.TangentImpulse = newImpulse;

                Vector2F p = lambda * tangent;

                vA -= mA * p;
                wA -= iA * MathUtils.Cross(ref vcp.Ra, ref p);

                vB += mB * p;
                wB += iB * MathUtils.Cross(ref vcp.Rb, ref p);
            }
        }

        private static void SolveSinglePointNormal(
            ref Vector2F vA, ref float wA, ref Vector2F vB, ref float wB,
            ContactVelocityConstraint vc, ref Vector2F normal,
            float mA, float iA, float mB, float iB)
        {
            VelocityConstraintPoint vcp = vc.Points[0];

            Vector2F dv = vB + MathUtils.Cross(wB, ref vcp.Rb) - vA - MathUtils.Cross(wA, ref vcp.Ra);

            float vn = Vector2F.Dot(dv, normal);
            float lambda = -vcp.NormalMass * (vn - vcp.VelocityBias);

            float newImpulse = Math.Max(vcp.NormalImpulse + lambda, 0.0f);
            lambda = newImpulse - vcp.NormalImpulse;
            vcp.NormalImpulse = newImpulse;

            Vector2F p = lambda * normal;
            vA -= mA * p;
            wA -= iA * MathUtils.Cross(ref vcp.Ra, ref p);

            vB += mB * p;
            wB += iB * MathUtils.Cross(ref vcp.Rb, ref p);
        }

        private static void SolveTwoPointNormal(
            ref Vector2F vA, ref float wA, ref Vector2F vB, ref float wB,
            ContactVelocityConstraint vc, ref Vector2F normal,
            float mA, float iA, float mB, float iB)
        {
            VelocityConstraintPoint cp1 = vc.Points[0];
            VelocityConstraintPoint cp2 = vc.Points[1];

            Vector2F a = new Vector2F(cp1.NormalImpulse, cp2.NormalImpulse);
            Vector2F dv1 = vB + MathUtils.Cross(wB, ref cp1.Rb) - vA - MathUtils.Cross(wA, ref cp1.Ra);
            Vector2F dv2 = vB + MathUtils.Cross(wB, ref cp2.Rb) - vA - MathUtils.Cross(wA, ref cp2.Ra);

            float vn1 = Vector2F.Dot(dv1, normal);
            float vn2 = Vector2F.Dot(dv2, normal);

            Vector2F b = new Vector2F();
            b.X = vn1 - cp1.VelocityBias;
            b.Y = vn2 - cp2.VelocityBias;

            b -= MathUtils.Mul(ref vc.K, ref a);

            ContactConstraintData constraint = new ContactConstraintData(cp1, cp2, normal);

            Vector2F x = -MathUtils.Mul(ref vc.NormalMass, ref b);

            if ((x.X >= 0.0f) && (x.Y >= 0.0f))
            {
                ApplyBlockImpulse(ref vA, ref wA, ref vB, ref wB, x, a, constraint, mA, iA, mB, iB);
                return;
            }

            x.X = -cp1.NormalMass * b.X;
            x.Y = 0.0f;
            vn2 = vc.K.Ex.Y * x.X + b.Y;

            if ((x.X >= 0.0f) && (vn2 >= 0.0f))
            {
                ApplyBlockImpulse(ref vA, ref wA, ref vB, ref wB, x, a, constraint, mA, iA, mB, iB);
                return;
            }

            x.X = 0.0f;
            x.Y = -cp2.NormalMass * b.Y;
            vn1 = vc.K.Ey.X * x.Y + b.X;

            if ((x.Y >= 0.0f) && (vn1 >= 0.0f))
            {
                ApplyBlockImpulse(ref vA, ref wA, ref vB, ref wB, x, a, constraint, mA, iA, mB, iB);
                return;
            }

            x.X = 0.0f;
            x.Y = 0.0f;
            vn1 = b.X;
            vn2 = b.Y;

            if ((vn1 >= 0.0f) && (vn2 >= 0.0f))
            {
                ApplyBlockImpulse(ref vA, ref wA, ref vB, ref wB, x, a, constraint, mA, iA, mB, iB);
            }
        }

        private static void ApplyBlockImpulse(
            ref Vector2F vA, ref float wA, ref Vector2F vB, ref float wB,
            Vector2F x, Vector2F a, ContactConstraintData constraint,
            float mA, float iA, float mB, float iB)
        {
            Vector2F d = x - a;

            Vector2F p1 = d.X * constraint.Normal;
            Vector2F p2 = d.Y * constraint.Normal;
            vA -= mA * (p1 + p2);
            wA -= iA * (MathUtils.Cross(ref constraint.Cp1.Ra, ref p1) + MathUtils.Cross(ref constraint.Cp2.Ra, ref p2));

            vB += mB * (p1 + p2);
            wB += iB * (MathUtils.Cross(ref constraint.Cp1.Rb, ref p1) + MathUtils.Cross(ref constraint.Cp2.Rb, ref p2));

            constraint.Cp1.NormalImpulse = x.X;
            constraint.Cp2.NormalImpulse = x.Y;
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

                (int orderedIndexA, int orderedIndexB) = GetOrderedIndices(pc);
                LockBodies(orderedIndexA, orderedIndexB);

                minSeparation = SolveContactPositionConstraint(pc);

                UnlockBodies(orderedIndexA, orderedIndexB);
            }

            return minSeparation >= -3.0f * SettingEnv.LinearSlop;
        }

        private static (int, int) GetOrderedIndices(ContactPositionConstraint pc)
        {
            int orderedIndexA = pc.IndexA;
            int orderedIndexB = pc.IndexB;
            if (orderedIndexB < orderedIndexA)
            {
                orderedIndexA = pc.IndexB;
                orderedIndexB = pc.IndexA;
            }
            return (orderedIndexA, orderedIndexB);
        }

        private void LockBodies(int orderedIndexA, int orderedIndexB)
        {
            while (true)
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
        }

        private void UnlockBodies(int orderedIndexA, int orderedIndexB)
        {
            Interlocked.Exchange(ref Locks[orderedIndexB], 0);
            Interlocked.Exchange(ref Locks[orderedIndexA], 0);
        }

        private float SolveContactPositionConstraint(ContactPositionConstraint pc)
        {
            float minSeparation = 0.0f;
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

            for (int j = 0; j < pointCount; ++j)
            {
                ControllerTransform xfA = new ControllerTransform(Vector2F.Zero, aA);
                ControllerTransform xfB = new ControllerTransform(Vector2F.Zero, aB);
                xfA.Position = cA - Complex.Multiply(ref localCenterA, ref xfA.Rotation);
                xfB.Position = cB - Complex.Multiply(ref localCenterB, ref xfB.Rotation);

                PositionSolverManifold.Initialize(pc, ref xfA, ref xfB, j, out Vector2F normal, out Vector2F point, out float separation);

                Vector2F rA = point - cA;
                Vector2F rB = point - cB;

                minSeparation = Math.Min(minSeparation, separation);

                float c = MathUtils.Clamp(SettingEnv.Baumgarte * (separation + SettingEnv.LinearSlop), -SettingEnv.MaxLinearCorrection, 0.0f);

                float rnA = MathUtils.Cross(ref rA, ref normal);
                float rnB = MathUtils.Cross(ref rB, ref normal);
                float k = mA + mB + iA * rnA * rnA + iB * rnB * rnB;

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

            return minSeparation;
        }

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
                    ControllerTransform xfA = new ControllerTransform(Vector2F.Zero, aA);
                    ControllerTransform xfB = new ControllerTransform(Vector2F.Zero, aB);
                    xfA.Position = cA - Complex.Multiply(ref localCenterA, ref xfA.Rotation);
                    xfB.Position = cB - Complex.Multiply(ref localCenterB, ref xfB.Rotation);

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
            public static void Initialize(ref Manifold manifold, ref ControllerTransform xfA, float radiusA, ref ControllerTransform xfB, float radiusB, out Vector2F normal, out FixedArray2<Vector2F> points)
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
                        Vector2F pointA = ControllerTransform.Multiply(ref manifold.LocalPoint, ref xfA);
                        Vector2F pointB = ControllerTransform.Multiply(manifold.Points[0].LocalPoint, ref xfB);
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
                        normal = Complex.Multiply(ref manifold.LocalNormal, ref xfA.Rotation);
                        Vector2F planePoint = ControllerTransform.Multiply(ref manifold.LocalPoint, ref xfA);

                        for (int i = 0; i < manifold.PointCount; ++i)
                        {
                            Vector2F clipPoint = ControllerTransform.Multiply(manifold.Points[i].LocalPoint, ref xfB);
                            Vector2F cA = clipPoint + (radiusA - Vector2F.Dot(clipPoint - planePoint, normal)) * normal;
                            Vector2F cB = clipPoint - radiusB * normal;
                            points[i] = 0.5f * (cA + cB);
                        }
                    }
                        break;

                    case ManifoldType.FaceB:
                    {
                        normal = Complex.Multiply(ref manifold.LocalNormal, ref xfB.Rotation);
                        Vector2F planePoint = ControllerTransform.Multiply(ref manifold.LocalPoint, ref xfB);

                        for (int i = 0; i < manifold.PointCount; ++i)
                        {
                            Vector2F clipPoint = ControllerTransform.Multiply(manifold.Points[i].LocalPoint, ref xfA);
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
    }
}