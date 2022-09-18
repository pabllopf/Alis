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

using System;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shape;
using Alis.Core.Physic.Dynamics.Body;
using Alis.Core.Physic.Dynamics.Fixtures;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The contact solver class
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class ContactSolver : IDisposable
    {
        /// <summary>
        ///     The constraints
        /// </summary>
        public ContactConstraint[] Constraints;

        /// <summary>
        ///     The step
        /// </summary>
        private TimeStep step;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ContactSolver" /> class
        /// </summary>
        /// <param name="step">The step</param>
        /// <param name="contacts">The contacts</param>
        /// <param name="contactCount">The contact count</param>
        public ContactSolver(TimeStep step, Contact[] contacts, int contactCount)
        {
            this.step = step;
            ConstraintCount = contactCount;

            Constraints = new ContactConstraint[ConstraintCount];
            for (int i = 0; i < ConstraintCount; i++)
            {
                Constraints[i] = new ContactConstraint();
            }

            //int count = 0;
            for (int i = 0; i < ConstraintCount; ++i)
            {
                Contact contact = contacts[i];

                Fixture fixtureA = contact.FixtureA;
                Fixture fixtureB = contact.FixtureB;
                IShape shapeA = fixtureA.Shape;
                IShape shapeB = fixtureB.Shape;
                float radiusA = shapeA.GetRadius();
                float radiusB = shapeB.GetRadius();
                BodyBase bodyBaseA = fixtureA.BodyBase;
                BodyBase bodyBaseB = fixtureB.BodyBase;
                Manifold manifold = contact.Manifold;

                float friction = Settings.MixFriction(fixtureA.Friction, fixtureB.Friction);
                float restitution = Settings.MixRestitution(fixtureA.Restitution, fixtureB.Restitution);

                Vector2 vA = bodyBaseA.LinearVelocity;
                Vector2 vB = bodyBaseB.LinearVelocity;
                float wA = bodyBaseA.AngularVelocity;
                float wB = bodyBaseB.AngularVelocity;

                Box2DxDebug.Assert(manifold.PointCount > 0);

                WorldManifold worldManifold = new WorldManifold();
                worldManifold.Initialize(manifold, bodyBaseA.Xf, radiusA, bodyBaseB.Xf, radiusB);

                ContactConstraint cc = Constraints[i];
                cc.BodyBaseA = bodyBaseA;
                cc.BodyBaseB = bodyBaseB;
                cc.Manifold = manifold;
                cc.Normal = worldManifold.Normal;
                cc.PointCount = manifold.PointCount;
                cc.Friction = friction;
                cc.Restitution = restitution;

                cc.LocalPlaneNormal = manifold.LocalPlaneNormal;
                cc.LocalPoint = manifold.LocalPoint;
                cc.Radius = radiusA + radiusB;
                cc.Type = manifold.Type;

                unsafe
                {
                    fixed (ContactConstraintPoint* ccPointsPtr = cc.Points)
                    {
                        for (int j = 0; j < cc.PointCount; ++j)
                        {
                            ManifoldPoint cp = manifold.Points[j];
                            ContactConstraintPoint* ccp = &ccPointsPtr[j];

                            ccp->NormalImpulse = cp.NormalImpulse;
                            ccp->TangentImpulse = cp.TangentImpulse;

                            ccp->LocalPoint = cp.LocalPoint;

                            ccp->Ra = worldManifold.Points[j] - bodyBaseA.Sweep.C;
                            ccp->Rb = worldManifold.Points[j] - bodyBaseB.Sweep.C;

                            float rnA = Vector2.Cross(ccp->Ra, cc.Normal);
                            float rnB = Vector2.Cross(ccp->Rb, cc.Normal);
                            rnA *= rnA;
                            rnB *= rnB;

                            float kNormal = bodyBaseA.InvMass + bodyBaseB.InvMass + bodyBaseA.InvI * rnA + bodyBaseB.InvI * rnB;

                            Box2DxDebug.Assert(kNormal > Settings.FltEpsilon);
                            ccp->NormalMass = 1.0f / kNormal;

                            float kEqualized = bodyBaseA.Mass * bodyBaseA.InvMass + bodyBaseB.Mass * bodyBaseB.InvMass;
                            kEqualized += bodyBaseA.Mass * bodyBaseA.InvI * rnA + bodyBaseB.Mass * bodyBaseB.InvI * rnB;

                            Box2DxDebug.Assert(kEqualized > Settings.FltEpsilon);
                            ccp->EqualizedMass = 1.0f / kEqualized;

                            Vector2 tangent = Vector2.Cross(cc.Normal, 1.0f);

                            float rtA = Vector2.Cross(ccp->Ra, tangent);
                            float rtB = Vector2.Cross(ccp->Rb, tangent);
                            rtA *= rtA;
                            rtB *= rtB;

                            float kTangent = bodyBaseA.InvMass + bodyBaseB.InvMass + bodyBaseA.InvI * rtA + bodyBaseB.InvI * rtB;

                            Box2DxDebug.Assert(kTangent > Settings.FltEpsilon);
                            ccp->TangentMass = 1.0f / kTangent;

                            // Setup a velocity bias for restitution.
                            ccp->VelocityBias = 0.0f;
                            float vRel = Vector2.Dot(cc.Normal,
                                vB + Vector2.Cross(wB, ccp->Rb) - vA - Vector2.Cross(wA, ccp->Ra));
                            if (vRel < -Settings.VelocityThreshold)
                            {
                                ccp->VelocityBias = -cc.Restitution * vRel;
                            }
                        }

                        // If we have two points, then prepare the block solver.
                        if (cc.PointCount == 2)
                        {
                            ContactConstraintPoint* ccp1 = &ccPointsPtr[0];
                            ContactConstraintPoint* ccp2 = &ccPointsPtr[1];

                            float invMassA = bodyBaseA.InvMass;
                            float invIa = bodyBaseA.InvI;
                            float invMassB = bodyBaseB.InvMass;
                            float invIb = bodyBaseB.InvI;

                            float rn1A = Vector2.Cross(ccp1->Ra, cc.Normal);
                            float rn1B = Vector2.Cross(ccp1->Rb, cc.Normal);
                            float rn2A = Vector2.Cross(ccp2->Ra, cc.Normal);
                            float rn2B = Vector2.Cross(ccp2->Rb, cc.Normal);

                            float k11 = invMassA + invMassB + invIa * rn1A * rn1A + invIb * rn1B * rn1B;
                            float k22 = invMassA + invMassB + invIa * rn2A * rn2A + invIb * rn2B * rn2B;
                            float k12 = invMassA + invMassB + invIa * rn1A * rn2A + invIb * rn1B * rn2B;

                            // Ensure a reasonable condition number.
                            const float kMaxConditionNumber = 100.0f;
                            if (k11 * k11 < kMaxConditionNumber * (k11 * k22 - k12 * k12))
                            {
                                // K is safe to invert.
                                cc.K.Col1.Set(k11, k12);
                                cc.K.Col2.Set(k12, k22);
                                cc.NormalMass = cc.K.GetInverse();
                            }
                            else
                            {
                                // The constraints are redundant, just use one.
                                // TODO_ERIN use deepest?
                                cc.PointCount = 1;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     The constraint count
        /// </summary>
        public int ConstraintCount { get; }

        /// <summary>
        ///     The position solver manifold
        /// </summary>
        private static readonly PositionSolverManifold SPositionSolverManifold = new PositionSolverManifold();

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            Constraints = null;
        }

        /// <summary>
        ///     Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        public void InitVelocityConstraints(TimeStep step)
        {
            unsafe
            {
                // Warm start.
                for (int i = 0; i < ConstraintCount; ++i)
                {
                    ContactConstraint c = Constraints[i];

                    BodyBase bodyBaseA = c.BodyBaseA;
                    BodyBase bodyBaseB = c.BodyBaseB;
                    float invMassA = bodyBaseA.InvMass;
                    float invIa = bodyBaseA.InvI;
                    float invMassB = bodyBaseB.InvMass;
                    float invIb = bodyBaseB.InvI;
                    Vector2 normal = c.Normal;
                    Vector2 tangent = Vector2.Cross(normal, 1.0f);

                    fixed (ContactConstraintPoint* pointsPtr = c.Points)
                    {
                        if (step.WarmStarting)
                        {
                            for (int j = 0; j < c.PointCount; ++j)
                            {
                                ContactConstraintPoint* ccp = &pointsPtr[j];
                                ccp->NormalImpulse *= step.DtRatio;
                                ccp->TangentImpulse *= step.DtRatio;
                                Vector2 p = ccp->NormalImpulse * normal + ccp->TangentImpulse * tangent;
                                bodyBaseA.AngularVelocity -= invIa * Vector2.Cross(ccp->Ra, p);
                                bodyBaseA.LinearVelocity -= invMassA * p;
                                bodyBaseB.AngularVelocity += invIb * Vector2.Cross(ccp->Rb, p);
                                bodyBaseB.LinearVelocity += invMassB * p;
                            }
                        }
                        else
                        {
                            for (int j = 0; j < c.PointCount; ++j)
                            {
                                ContactConstraintPoint* ccp = &pointsPtr[j];
                                ccp->NormalImpulse = 0.0f;
                                ccp->TangentImpulse = 0.0f;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Solves the velocity constraints
        /// </summary>
        public void SolveVelocityConstraints()
        {
            for (int i = 0; i < ConstraintCount; ++i)
            {
                ContactConstraint c = Constraints[i];
                BodyBase bodyBaseA = c.BodyBaseA;
                BodyBase bodyBaseB = c.BodyBaseB;
                float wA = bodyBaseA.AngularVelocity;
                float wB = bodyBaseB.AngularVelocity;
                Vector2 vA = bodyBaseA.LinearVelocity;
                Vector2 vB = bodyBaseB.LinearVelocity;
                float invMassA = bodyBaseA.InvMass;
                float invIa = bodyBaseA.InvI;
                float invMassB = bodyBaseB.InvMass;
                float invIb = bodyBaseB.InvI;
                Vector2 normal = c.Normal;
                Vector2 tangent = Vector2.Cross(normal, 1.0f);
                float friction = c.Friction;

                Box2DxDebug.Assert(c.PointCount == 1 || c.PointCount == 2);

                unsafe
                {
                    fixed (ContactConstraintPoint* pointsPtr = c.Points)
                    {
                        // Solve tangent constraints
                        for (int j = 0; j < c.PointCount; ++j)
                        {
                            ContactConstraintPoint* ccp = &pointsPtr[j];

                            // Relative velocity at contact
                            Vector2 dv = vB + Vector2.Cross(wB, ccp->Rb) - vA - Vector2.Cross(wA, ccp->Ra);

                            // Compute tangent force
                            float vt = Vector2.Dot(dv, tangent);
                            float lambda = ccp->TangentMass * -vt;

                            // b2Clamp the accumulated force
                            float maxFriction = friction * ccp->NormalImpulse;
                            float newImpulse = Helper.Clamp(ccp->TangentImpulse + lambda, -maxFriction, maxFriction);
                            lambda = newImpulse - ccp->TangentImpulse;

                            // Apply contact impulse
                            Vector2 p = lambda * tangent;

                            vA -= invMassA * p;
                            wA -= invIa * Vector2.Cross(ccp->Ra, p);

                            vB += invMassB * p;
                            wB += invIb * Vector2.Cross(ccp->Rb, p);

                            ccp->TangentImpulse = newImpulse;
                        }

                        // Solve normal constraints
                        if (c.PointCount == 1)
                        {
                            ContactConstraintPoint ccp = c.Points[0];

                            // Relative velocity at contact
                            Vector2 dv = vB + Vector2.Cross(wB, ccp.Rb) - vA - Vector2.Cross(wA, ccp.Ra);

                            // Compute normal impulse
                            float vn = Vector2.Dot(dv, normal);
                            float lambda = -ccp.NormalMass * (vn - ccp.VelocityBias);

                            // Clamp the accumulated impulse
                            float newImpulse = Helper.Max(ccp.NormalImpulse + lambda, 0.0f);
                            lambda = newImpulse - ccp.NormalImpulse;

                            // Apply contact impulse
                            Vector2 p = lambda * normal;
                            vA -= invMassA * p;
                            wA -= invIa * Vector2.Cross(ccp.Ra, p);

                            vB += invMassB * p;
                            wB += invIb * Vector2.Cross(ccp.Rb, p);
                            ccp.NormalImpulse = newImpulse;
                        }
                        else
                        {
                            // Block solver developed in collaboration with Dirk Gregorius (back in 01/07 on Box2D_Lite).
                            // Build the mini LCP for this contact patch
                            //
                            // vn = A * x + b, vn >= 0, , vn >= 0, x >= 0 and vn_i * x_i = 0 with i = 1..2
                            //
                            // A = J * W * JT and J = ( -n, -r1 x n, n, r2 x n )
                            // b = vn_0 - velocityBias
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
                            // x = x' - a
                            // 
                            // Plug into above equation:
                            //
                            // vn = A * x + b
                            //    = A * (x' - a) + b
                            //    = A * x' + b - A * a
                            //    = A * x' + b'
                            // b' = b - A * a;

                            ContactConstraintPoint* cp1 = &pointsPtr[0];
                            ContactConstraintPoint* cp2 = &pointsPtr[1];

                            Vector2 a = new Vector2(cp1->NormalImpulse, cp2->NormalImpulse);
                            Box2DxDebug.Assert((a.X >= 0.0f) && (a.Y >= 0.0f));

                            // Relative velocity at contact
                            Vector2 dv1 = vB + Vector2.Cross(wB, cp1->Rb) - vA - Vector2.Cross(wA, cp1->Ra);
                            Vector2 dv2 = vB + Vector2.Cross(wB, cp2->Rb) - vA - Vector2.Cross(wA, cp2->Ra);

                            // Compute normal velocity
                            float vn1 = Vector2.Dot(dv1, normal);
                            float vn2 = Vector2.Dot(dv2, normal);

                            Vector2 b;
                            b.X = vn1 - cp1->VelocityBias;
                            b.Y = vn2 - cp2->VelocityBias;
                            b -= Helper.Mul(c.K, a);

                            //const float k_errorTol = 1e-3f;
                            //B2_NOT_USED(k_errorTol);

                            for (;;)
                            {
                                //
                                // Case 1: vn = 0
                                //
                                // 0 = A * x' + b'
                                //
                                // Solve for x':
                                //
                                // x' = - inv(A) * b'
                                //
                                Vector2 x = -Helper.Mul(c.NormalMass, b);

                                if ((x.X >= 0.0f) && (x.Y >= 0.0f))
                                {
                                    // Resubstitute for the incremental impulse
                                    Vector2 d = x - a;

                                    // Apply incremental impulse
                                    Vector2 p1 = d.X * normal;
                                    Vector2 p2 = d.Y * normal;
                                    vA -= invMassA * (p1 + p2);
                                    wA -= invIa * (Vector2.Cross(cp1->Ra, p1) + Vector2.Cross(cp2->Ra, p2));

                                    vB += invMassB * (p1 + p2);
                                    wB += invIb * (Vector2.Cross(cp1->Rb, p1) + Vector2.Cross(cp2->Rb, p2));

                                    // Accumulate
                                    cp1->NormalImpulse = x.X;
                                    cp2->NormalImpulse = x.Y;

#if DEBUG_SOLVER
									// Postconditions
									dv1 = vB + Vec2.Cross(wB, cp1->RB) - vA - Vec2.Cross(wA, cp1->RA);
									dv2 = vB + Vec2.Cross(wB, cp2->RB) - vA - Vec2.Cross(wA, cp2->RA);

									// Compute normal velocity
									vn1 = Vec2.Dot(dv1, normal);
									vn2 = Vec2.Dot(dv2, normal);

									Box2DXDebug.Assert(Common.Helper.Abs(vn1 - cp1.VelocityBias) < k_errorTol);
									Box2DXDebug.Assert(Common.Helper.Abs(vn2 - cp2.VelocityBias) < k_errorTol);
#endif
                                    break;
                                }

                                //
                                // Case 2: vn1 = 0 and x2 = 0
                                //
                                //   0 = a11 * x1' + a12 * 0 + b1' 
                                // vn2 = a21 * x1' + a22 * 0 + b2'
                                //
                                x.X = -cp1->NormalMass * b.X;
                                x.Y = 0.0f;
/*
                                vn1 = 0.0f;
*/
                                vn2 = c.K.Col1.Y * x.X + b.Y;

                                if ((x.X >= 0.0f) && (vn2 >= 0.0f))
                                {
                                    // Resubstitute for the incremental impulse
                                    Vector2 d = x - a;

                                    // Apply incremental impulse
                                    Vector2 p1 = d.X * normal;
                                    Vector2 p2 = d.Y * normal;
                                    vA -= invMassA * (p1 + p2);
                                    wA -= invIa * (Vector2.Cross(cp1->Ra, p1) + Vector2.Cross(cp2->Ra, p2));

                                    vB += invMassB * (p1 + p2);
                                    wB += invIb * (Vector2.Cross(cp1->Rb, p1) + Vector2.Cross(cp2->Rb, p2));

                                    // Accumulate
                                    cp1->NormalImpulse = x.X;
                                    cp2->NormalImpulse = x.Y;

#if DEBUG_SOLVER
									// Postconditions
									dv1 = vB + Vec2.Cross(wB, cp1->RB) - vA - Vec2.Cross(wA, cp1->RA);

									// Compute normal velocity
									vn1 = Vec2.Dot(dv1, normal);

									Box2DXDebug.Assert(Common.Helper.Abs(vn1 - cp1.VelocityBias) < k_errorTol);
#endif
                                    break;
                                }


                                //
                                // Case 3: w2 = 0 and x1 = 0
                                //
                                // vn1 = a11 * 0 + a12 * x2' + b1' 
                                //   0 = a21 * 0 + a22 * x2' + b2'
                                //
                                x.X = 0.0f;
                                x.Y = -cp2->NormalMass * b.Y;
                                vn1 = c.K.Col2.X * x.Y + b.X;
/*
                                vn2 = 0.0f;
*/

                                if ((x.Y >= 0.0f) && (vn1 >= 0.0f))
                                {
                                    // Resubstitute for the incremental impulse
                                    Vector2 d = x - a;

                                    // Apply incremental impulse
                                    Vector2 p1 = d.X * normal;
                                    Vector2 p2 = d.Y * normal;
                                    vA -= invMassA * (p1 + p2);
                                    wA -= invIa * (Vector2.Cross(cp1->Ra, p1) + Vector2.Cross(cp2->Ra, p2));

                                    vB += invMassB * (p1 + p2);
                                    wB += invIb * (Vector2.Cross(cp1->Rb, p1) + Vector2.Cross(cp2->Rb, p2));

                                    // Accumulate
                                    cp1->NormalImpulse = x.X;
                                    cp2->NormalImpulse = x.Y;

#if DEBUG_SOLVER
									// Postconditions
									dv2 = vB + Vec2.Cross(wB, cp2->RB) - vA - Vec2.Cross(wA, cp2->RA);

									// Compute normal velocity
									vn2 = Vec2.Dot(dv2, normal);

									Box2DXDebug.Assert(Common.Helper.Abs(vn2 - cp2.VelocityBias) < k_errorTol);
#endif
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
                                    Vector2 d = x - a;

                                    // Apply incremental impulse
                                    Vector2 p1 = d.X * normal;
                                    Vector2 p2 = d.Y * normal;
                                    vA -= invMassA * (p1 + p2);
                                    wA -= invIa * (Vector2.Cross(cp1->Ra, p1) + Vector2.Cross(cp2->Ra, p2));

                                    vB += invMassB * (p1 + p2);
                                    wB += invIb * (Vector2.Cross(cp1->Rb, p1) + Vector2.Cross(cp2->Rb, p2));

                                    // Accumulate
                                    cp1->NormalImpulse = x.X;
                                    cp2->NormalImpulse = x.Y;
                                }

                                // No solution, give up. This is hit sometimes, but it doesn't seem to matter.
                                break;
                            }
                        }

                        bodyBaseA.LinearVelocity = vA;
                        bodyBaseA.AngularVelocity = wA;
                        bodyBaseB.LinearVelocity = vB;
                        bodyBaseB.AngularVelocity = wB;
                    }
                }
            }
        }

        /// <summary>
        ///     Finalizes the velocity constraints
        /// </summary>
        public void FinalizeVelocityConstraints()
        {
            for (int i = 0; i < ConstraintCount; ++i)
            {
                ContactConstraint c = Constraints[i];
                Manifold m = c.Manifold;

                for (int j = 0; j < c.PointCount; ++j)
                {
                    m.Points[j].NormalImpulse = c.Points[j].NormalImpulse;
                    m.Points[j].TangentImpulse = c.Points[j].TangentImpulse;
                }
            }
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="baumgarte">The baumgarte</param>
        /// <returns>The bool</returns>
        public bool SolvePositionConstraints(float baumgarte)
        {
            float minSeparation = 0.0f;

            for (int i = 0; i < ConstraintCount; ++i)
            {
                ContactConstraint c = Constraints[i];
                BodyBase bodyBaseA = c.BodyBaseA;
                BodyBase bodyBaseB = c.BodyBaseB;

                float invMassA = bodyBaseA.Mass * bodyBaseA.InvMass;
                float invIa = bodyBaseA.Mass * bodyBaseA.InvI;
                float invMassB = bodyBaseB.Mass * bodyBaseB.InvMass;
                float invIb = bodyBaseB.Mass * bodyBaseB.InvI;

                SPositionSolverManifold.Initialize(c);
                Vector2 normal = SPositionSolverManifold.Normal;

                // Solver normal constraints
                for (int j = 0; j < c.PointCount; ++j)
                {
                    Vector2 point = SPositionSolverManifold.Points[j];
                    float separation = SPositionSolverManifold.Separations[j];

                    Vector2 rA = point - bodyBaseA.Sweep.C;
                    Vector2 rB = point - bodyBaseB.Sweep.C;

                    // Track max constraint error.
                    minSeparation = Helper.Min(minSeparation, separation);

                    // Prevent large corrections and allow slop.
                    float clamp = baumgarte * Helper.Clamp(separation + Settings.LinearSlop,
                        -Settings.MaxLinearCorrection,
                        0.0f);

                    // Compute normal impulse
                    float impulse = -c.Points[j].EqualizedMass * clamp;

                    Vector2 p = impulse * normal;

                    bodyBaseA.Sweep.C -= invMassA * p;
                    bodyBaseA.Sweep.A -= invIa * Vector2.Cross(rA, p);
                    bodyBaseA.SynchronizeTransform();

                    bodyBaseB.Sweep.C += invMassB * p;
                    bodyBaseB.Sweep.A += invIb * Vector2.Cross(rB, p);
                    bodyBaseB.SynchronizeTransform();
                }
            }

            // We can't expect minSpeparation >= -Settings.LinearSlop because we don't
            // push the separation above -Settings.LinearSlop.
            return minSeparation >= -1.5f * Settings.LinearSlop;
        }
    }
}