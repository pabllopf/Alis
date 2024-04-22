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
using System.Collections.Generic;
using System.Diagnostics;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Collision.NarrowPhase;
using Alis.Core.Physic.Config;

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
        ///     Resets the step param
        /// </summary>
        /// <param name="stepParam">The step param</param>
        /// <param name="countParam">The count param</param>
        /// <param name="contactList">The contact list</param>
        /// <param name="positionList">The position list</param>
        /// <param name="velocitiesList">The velocities list</param>
        public void Reset(TimeStep stepParam, int countParam, List<Contact> contactList, List<Position> positionList, List<Velocity> velocitiesList)
        {
            InitializeParameters(stepParam, countParam, contactList, positionList, velocitiesList);
            GrowArrayIfNeeded(countParam);
            InitializeConstraints(countParam);
        }
        
        /// <summary>
        ///     Initializes the parameters using the specified step param
        /// </summary>
        /// <param name="stepParam">The step param</param>
        /// <param name="countParam">The count param</param>
        /// <param name="contactList">The contact list</param>
        /// <param name="positionList">The position list</param>
        /// <param name="velocitiesList">The velocities list</param>
        private void InitializeParameters(TimeStep stepParam, int countParam, List<Contact> contactList, List<Position> positionList, List<Velocity> velocitiesList)
        {
            step = stepParam;
            count = countParam;
            positions = positionList;
            velocities = velocitiesList;
            contacts = contactList;
        }
        
        /// <summary>
        ///     Grows the array if needed using the specified count param
        /// </summary>
        /// <param name="countParam">The count param</param>
        private void GrowArrayIfNeeded(int countParam)
        {
            if (VelocityConstraints == null || VelocityConstraints.Count < countParam)
            {
                VelocityConstraints = new List<ContactVelocityConstraint>(countParam * 2);
                positionConstraints = new List<ContactPositionConstraint>(countParam * 2);
                
                for (int i = 0; i < VelocityConstraints.Count; i++)
                {
                    VelocityConstraints[i] = new ContactVelocityConstraint();
                }
                
                for (int i = 0; i < positionConstraints.Count; i++)
                {
                    positionConstraints[i] = new ContactPositionConstraint();
                }
            }
        }
        
        /// <summary>
        ///     Initializes the constraints using the specified count param
        /// </summary>
        /// <param name="countParam">The count param</param>
        private void InitializeConstraints(int countParam)
        {
            for (int i = 0; i < countParam; ++i)
            {
                Contact contact = contacts[i];
                InitializeVelocityConstraint(i, contact);
                InitializePositionConstraint(i, contact);
            }
        }
        
        /// <summary>
        ///     Initializes the velocity constraint using the specified i
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="contact">The contact</param>
        private void InitializeVelocityConstraint(int i, Contact contact)
        {
            if (VelocityConstraints.Count <= i)
            {
                VelocityConstraints.Add(new ContactVelocityConstraint());
            }
            
            ContactVelocityConstraint vc = VelocityConstraints[i];
            vc.Friction = contact.Friction;
            vc.Restitution = contact.Restitution;
            vc.Threshold = contact.RestitutionThreshold;
            vc.TangentSpeed = contact.TangentSpeed;
            vc.IndexA = contact.FixtureA.Body.IslandIndex;
            vc.IndexB = contact.FixtureB.Body.IslandIndex;
            vc.InvMassA = contact.FixtureA.Body.InvMass;
            vc.InvMassB = contact.FixtureB.Body.InvMass;
            vc.InvIa = contact.FixtureA.Body.InvI;
            vc.InvIb = contact.FixtureB.Body.InvI;
            vc.ContactIndex = i;
            vc.PointCount = contact.Manifold.PointCount;
            vc.K.SetZero();
            vc.NormalMass.SetZero();
        }
        
        /// <summary>
        ///     Initializes the position constraint using the specified i
        /// </summary>
        /// <param name="i">The </param>
        /// <param name="contact">The contact</param>
        private void InitializePositionConstraint(int i, Contact contact)
        {
            if (positionConstraints.Count <= i)
            {
                positionConstraints.Add(new ContactPositionConstraint());
            }
            
            ContactPositionConstraint pc = positionConstraints[i];
            pc.IndexA = contact.FixtureA.Body.IslandIndex;
            pc.IndexB = contact.FixtureB.Body.IslandIndex;
            pc.InvMassA = contact.FixtureA.Body.InvMass;
            pc.InvMassB = contact.FixtureB.Body.InvMass;
            pc.LocalCenterA = contact.FixtureA.Body.Sweep.LocalCenter;
            pc.LocalCenterB = contact.FixtureB.Body.Sweep.LocalCenter;
            pc.InvIa = contact.FixtureA.Body.InvI;
            pc.InvIb = contact.FixtureB.Body.InvI;
            pc.LocalNormal = contact.Manifold.LocalNormal;
            pc.LocalPoint = contact.Manifold.LocalPoint;
            pc.PointCount = contact.Manifold.PointCount;
            pc.RadiusA = contact.FixtureA.Shape.RadiusPrivate;
            pc.RadiusB = contact.FixtureB.Shape.RadiusPrivate;
            pc.Type = contact.Manifold.Type;
            
            for (int j = 0; j < pc.PointCount; ++j)
            {
                ManifoldPoint cp = contact.Manifold.Points[j];
                VelocityConstraintPoint vcp = VelocityConstraints[i].Points[j];
                
                if (step.WarmStarting)
                {
                    vcp.NormalImpulse = step.DeltaTimeRatio * cp.NormalImpulse;
                    vcp.TangentImpulse = step.DeltaTimeRatio * cp.TangentImpulse;
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
        
        /// <summary>
        ///     Initializes the velocity constraints
        /// </summary>
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
                
                Transform xfA, xfB;
                InitializeTransforms(aA, cA, localCenterA, aB, cB, localCenterB, out xfA, out xfB);
                
                Vector2 normal;
                Vector2[] points;
                InitializeWorldManifold(ref manifold, ref xfA, radiusA, ref xfB, radiusB, out normal, out points);
                
                vc.Normal = normal;
                
                InitializeVelocityConstraintPoints(vc, cA, cB, mA, mB, iA, iB, normal, points, vA, vB, wA, wB);
                
                if ((vc.PointCount == 2) && Settings.BlockSolve)
                {
                    PrepareBlockSolver(vc, mA, mB, iA, iB);
                }
            }
        }
        
        /// <summary>
        ///     Initializes the transforms using the specified a a
        /// </summary>
        /// <param name="aA">The </param>
        /// <param name="cA">The </param>
        /// <param name="localCenterA">The local center</param>
        /// <param name="aB">The </param>
        /// <param name="cB">The </param>
        /// <param name="localCenterB">The local center</param>
        /// <param name="xfA">The xf</param>
        /// <param name="xfB">The xf</param>
        private void InitializeTransforms(float aA, Vector2 cA, Vector2 localCenterA, float aB, Vector2 cB, Vector2 localCenterB, out Transform xfA, out Transform xfB)
        {
            xfA = new Transform();
            xfB = new Transform();
            xfA.Rotation.Set(aA);
            xfB.Rotation.Set(aB);
            xfA.Position = cA - MathUtils.Mul(xfA.Rotation, localCenterA);
            xfB.Position = cB - MathUtils.Mul(xfB.Rotation, localCenterB);
        }
        
        /// <summary>
        ///     Initializes the world manifold using the specified manifold
        /// </summary>
        /// <param name="manifold">The manifold</param>
        /// <param name="xfA">The xf</param>
        /// <param name="radiusA">The radius</param>
        /// <param name="xfB">The xf</param>
        /// <param name="radiusB">The radius</param>
        /// <param name="normal">The normal</param>
        /// <param name="points">The points</param>
        private void InitializeWorldManifold(ref Manifold manifold, ref Transform xfA, float radiusA, ref Transform xfB, float radiusB, out Vector2 normal, out Vector2[] points)
        {
            WorldManifold.Initialize(ref manifold, ref xfA, radiusA, ref xfB, radiusB, out normal, out points);
        }
        
        /// <summary>
        ///     Initializes the velocity constraint points using the specified vc
        /// </summary>
        /// <param name="vc">The vc</param>
        /// <param name="cA">The </param>
        /// <param name="cB">The </param>
        /// <param name="mA">The </param>
        /// <param name="mB">The </param>
        /// <param name="iA">The </param>
        /// <param name="iB">The </param>
        /// <param name="normal">The normal</param>
        /// <param name="points">The points</param>
        /// <param name="vA">The </param>
        /// <param name="vB">The </param>
        /// <param name="wA">The </param>
        /// <param name="wB">The </param>
        private void InitializeVelocityConstraintPoints(ContactVelocityConstraint vc, Vector2 cA, Vector2 cB, float mA, float mB, float iA, float iB, Vector2 normal, Vector2[] points, Vector2 vA, Vector2 vB, float wA, float wB)
        {
            int pointCount = vc.PointCount;
            for (int j = 0; j < pointCount; ++j)
            {
                VelocityConstraintPoint vcp = vc.Points[j];
                
                vcp.Ra = points[j] - cA;
                vcp.Rb = points[j] - cB;
                
                float rnA = MathUtils.Cross(vcp.Ra, normal);
                float rnB = MathUtils.Cross(vcp.Rb, normal);
                
                float kNormal = mA + mB + iA * rnA * rnA + iB * rnB * rnB;
                
                vcp.NormalMass = kNormal > 0.0f ? 1.0f / kNormal : 0.0f;
                
                Vector2 tangent = MathUtils.Cross(normal, 1.0f);
                
                float rtA = MathUtils.Cross(vcp.Ra, tangent);
                float rtB = MathUtils.Cross(vcp.Rb, tangent);
                
                float kTangent = mA + mB + iA * rtA * rtA + iB * rtB * rtB;
                
                vcp.TangentMass = kTangent > 0.0f ? 1.0f / kTangent : 0.0f;
                
                // Setup a velocity bias for restitution.
                vcp.VelocityBias = 0.0f;
                float vRel = MathUtils.Dot(normal, vB + MathUtils.Cross(wB, vcp.Rb) - vA - MathUtils.Cross(wA, vcp.Ra));
                if (vRel < -vc.Threshold)
                {
                    vcp.VelocityBias = -vc.Restitution * vRel;
                }
            }
        }
        
        /// <summary>
        ///     Prepares the block solver using the specified vc
        /// </summary>
        /// <param name="vc">The vc</param>
        /// <param name="mA">The </param>
        /// <param name="mB">The </param>
        /// <param name="iA">The </param>
        /// <param name="iB">The </param>
        private void PrepareBlockSolver(ContactVelocityConstraint vc, float mA, float mB, float iA, float iB)
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
                vc.PointCount = 1;
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
                InitializeVelocityConstraint(vc);
                
                if (vc.PointCount == 1 || !Settings.BlockSolve)
                {
                    SolveNormalConstraints(vc);
                }
                else
                {
                    SolveBlockConstraints(vc);
                }
            }
        }
        
        /// <summary>
        ///     Initializes the velocity constraint using the specified vc
        /// </summary>
        /// <param name="vc">The vc</param>
        private void InitializeVelocityConstraint(ContactVelocityConstraint vc)
        {
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
                SolveTangentConstraints(vc, j, mA, iA, mB, iB, vA, wA, vB, wB, normal, tangent, friction);
            }
        }
        
        /// <summary>
        ///     Solves the tangent constraints using the specified vc
        /// </summary>
        /// <param name="vc">The vc</param>
        /// <param name="j">The </param>
        /// <param name="mA">The </param>
        /// <param name="iA">The </param>
        /// <param name="mB">The </param>
        /// <param name="iB">The </param>
        /// <param name="vA">The </param>
        /// <param name="wA">The </param>
        /// <param name="vB">The </param>
        /// <param name="wB">The </param>
        /// <param name="normal">The normal</param>
        /// <param name="tangent">The tangent</param>
        /// <param name="friction">The friction</param>
        private void SolveTangentConstraints(ContactVelocityConstraint vc, int j, float mA, float iA, float mB, float iB, Vector2 vA, float wA, Vector2 vB, float wB, Vector2 normal, Vector2 tangent, float friction)
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
        
        /// <summary>
        ///     Solves the normal constraints using the specified vc
        /// </summary>
        /// <param name="vc">The vc</param>
        private void SolveNormalConstraints(ContactVelocityConstraint vc)
        {
            for (int j = 0; j < vc.PointCount; ++j)
            {
                SolveNormalConstraint(vc, j);
            }
        }
        
        /// <summary>
        ///     Solves the normal constraint using the specified vc
        /// </summary>
        /// <param name="vc">The vc</param>
        /// <param name="j">The </param>
        private void SolveNormalConstraint(ContactVelocityConstraint vc, int j)
        {
            VelocityConstraintPoint vcp = vc.Points[j];
            
            // Relative velocity at contact
            Vector2 dv = velocities[vc.IndexB].V + MathUtils.Cross(velocities[vc.IndexB].W, vcp.Rb) - velocities[vc.IndexA].V - MathUtils.Cross(velocities[vc.IndexA].W, vcp.Ra);
            
            // Compute normal impulse
            float vn = Vector2.Dot(dv, vc.Normal);
            float lambda = -vcp.NormalMass * (vn - vcp.VelocityBias);
            
            // b2Clamp the accumulated impulse
            float newImpulse = Math.Max(vcp.NormalImpulse + lambda, 0.0f);
            lambda = newImpulse - vcp.NormalImpulse;
            vcp.NormalImpulse = newImpulse;
            
            // Apply contact impulse
            Vector2 p = lambda * vc.Normal;
            velocities[vc.IndexA].V -= vc.InvMassA * p;
            velocities[vc.IndexA].W -= vc.InvIa * MathUtils.Cross(vcp.Ra, p);
            
            velocities[vc.IndexB].V += vc.InvMassB * p;
            velocities[vc.IndexB].W += vc.InvIb * MathUtils.Cross(vcp.Rb, p);
        }
        
        /// <summary>
        ///     Solves the block constraints using the specified vc
        /// </summary>
        /// <param name="vc">The vc</param>
        private void SolveBlockConstraints(ContactVelocityConstraint vc)
        {
            // Block solver developed in collaboration with Dirk Gregoris (back in 01/07 on Box2D_Lite).
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
            Vector2 dv1 = velocities[vc.IndexB].V + MathUtils.Cross(velocities[vc.IndexB].W, cp1.Rb) - velocities[vc.IndexA].V - MathUtils.Cross(velocities[vc.IndexA].W, cp1.Ra);
            Vector2 dv2 = velocities[vc.IndexB].V + MathUtils.Cross(velocities[vc.IndexB].W, cp2.Rb) - velocities[vc.IndexA].V - MathUtils.Cross(velocities[vc.IndexA].W, cp2.Ra);
            
            // Compute normal velocity
            float vn1 = Vector2.Dot(dv1, vc.Normal);
            float vn2 = Vector2.Dot(dv2, vc.Normal);
            
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
                cp1.NormalImpulse = x.X;
                cp2.NormalImpulse = x.Y;
                
                return;
            }
            
            x = new Vector2(-cp1.NormalMass * b.X, 0.0f);
            vn2 = vc.K.Ex.Y * x.X + b.Y;
            
            if ((x.X >= 0.0f) && (vn2 >= 0.0f))
            {
                cp1.NormalImpulse = x.X;
                cp2.NormalImpulse = x.Y;
                
                return;
            }
            
            x = new Vector2(0.0f, -cp2.NormalMass * b.Y);
            vn1 = vc.K.Ey.X * x.Y + b.X;
            
            if ((x.Y >= 0.0f) && (vn1 >= 0.0f))
            {
                cp1.NormalImpulse = x.X;
                cp2.NormalImpulse = x.Y;
                
                return;
            }
            
            x = Vector2.Zero;
            vn1 = b.X;
            vn2 = b.Y;
            
            if ((vn1 >= 0.0f) && (vn2 >= 0.0f))
            {
                Vector2 d = x - a;
                
                Vector2 p1 = d.X * vc.Normal;
                Vector2 p2 = d.Y * vc.Normal;
                velocities[vc.IndexA].V -= vc.InvMassA * (p1 + p2);
                velocities[vc.IndexA].W -= vc.InvIa * (MathUtils.Cross(cp1.Ra, p1) + MathUtils.Cross(cp2.Ra, p2));
                
                velocities[vc.IndexB].V += vc.InvMassB * (p1 + p2);
                velocities[vc.IndexB].W += vc.InvIb * (MathUtils.Cross(cp1.Rb, p1) + MathUtils.Cross(cp2.Rb, p2));
                
                cp1.NormalImpulse = x.X;
                cp2.NormalImpulse = x.Y;
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
                    
                    minSeparation = Math.Min(minSeparation, separation);
                    
                    float c = MathUtils.Clamp(Settings.Baumgarte * (separation + Settings.LinearSlop),
                        -Settings.LinearCorrection, 0.0f);
                    
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
            
            // We can't expect min separation >= -b2_linearSlop because we don't
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
            
            // We can't expect min separation >= -b2_linearSlop because we don't
            // push the separation above -b2_linearSlop.
            return minSeparation >= -1.5f * Settings.LinearSlop;
        }
    }
}