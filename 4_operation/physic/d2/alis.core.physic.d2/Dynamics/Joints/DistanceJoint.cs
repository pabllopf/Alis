// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   DistanceJoint.cs
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

using System.Diagnostics;
using Alis.Core.Physic.D2.Config;
using Alis.Core.Physic.D2.Definitions.Joints;
using Alis.Core.Physic.D2.Dynamics.Joints.Misc;
using Alis.Core.Physic.D2.Dynamics.Solver;
using Alis.Core.Physic.D2.Shared;
using Alis.Core.Physic.D2.Utilities;

namespace Alis.Core.Physic.D2.Dynamics.Joints
{
    // 1-D constrained system
    // m (v2 - v1) = lambda
    // v2 + (beta/h) * x1 + gamma * lambda = 0, gamma has units of inverse mass.
    // x2 = x1 + h * v2

    // 1-D mass-damper-spring system
    // m (v2 - v1) + h * d * v2 + h * k * 

    // C = norm(p2 - p1) - L
    // u = (p2 - p1) / norm(p2 - p1)
    // Cdot = dot(u, v2 + cross(w2, r2) - v1 - cross(w1, r1))
    // J = [-u -cross(r1, u) u cross(r2, u)]
    // K = J * invM * JT
    //   = invMass1 + invI1 * cross(r1, u)^2 + invMass2 + invI2 * cross(r2, u)^2

    /// <summary>
    ///     A distance joint constrains two points on two bodies to remain at a fixed distance from each other. You can
    ///     view this as a massless, rigid rod.
    /// </summary>
    public class DistanceJoint : Joint
    {
        /// <summary>
        ///     The bias
        /// </summary>
        private float bias;

        /// <summary>
        ///     The current length
        /// </summary>
        private float currentLength;

        /// <summary>
        ///     The damping
        /// </summary>
        private float damping;

        /// <summary>
        ///     The gamma
        /// </summary>
        private float gamma;

        /// <summary>
        ///     The impulse
        /// </summary>
        private float impulse;

        // Solver temp
        /// <summary>
        ///     The index
        /// </summary>
        private int indexA;

        /// <summary>
        ///     The index
        /// </summary>
        private int indexB;

        /// <summary>
        ///     The inv ia
        /// </summary>
        private float invIa;

        /// <summary>
        ///     The inv ib
        /// </summary>
        private float invIb;

        /// <summary>
        ///     The inv mass
        /// </summary>
        private float invMassA;

        /// <summary>
        ///     The inv mass
        /// </summary>
        private float invMassB;

        /// <summary>
        ///     The length
        /// </summary>
        private float length;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private Vector2 localAnchorA;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private Vector2 localAnchorB;

        // Solver shared
        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 localCenterA;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 localCenterB;

        /// <summary>
        ///     The lower impulse
        /// </summary>
        private float lowerImpulse;

        /// <summary>
        ///     The mass
        /// </summary>
        private float mass;

        /// <summary>
        ///     The max length
        /// </summary>
        private float maxLength;

        /// <summary>
        ///     The min length
        /// </summary>
        private float minLength;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2 rA;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2 rB;

        /// <summary>
        ///     The soft mass
        /// </summary>
        private float softMass;

        /// <summary>
        ///     The stiffness
        /// </summary>
        private float stiffness;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2 u;

        /// <summary>
        ///     The upper impulse
        /// </summary>
        private float upperImpulse;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DistanceJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public DistanceJoint(DistanceJointDef def) : base(def)
        {
            localAnchorA = def.LocalAnchorA;
            localAnchorB = def.LocalAnchorB;
            length = MathUtils.Max(def.Length, Settings.LinearSlop);
            minLength = MathUtils.Max(def.MinLength, Settings.LinearSlop);
            maxLength = MathUtils.Max(def.MaxLength, minLength);
            stiffness = def.Stiffness;
            damping = def.Damping;
        }

        /// <summary>
        ///     This requires defining an anchor point on both bodies and the non-zero length of the distance joint. If you
        ///     don't supply a length, the local anchor points is used so that the initial configuration can violate the constraint
        ///     slightly. This helps when saving and loading a game. Warning Do not use a zero or short length.
        /// </summary>
        /// <param name="bodyA">The first body</param>
        /// <param name="bodyB">The second body</param>
        /// <param name="anchorA">The first body anchor</param>
        /// <param name="anchorB">The second body anchor</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public DistanceJoint(Body bodyA, Body bodyB, Vector2 anchorA, Vector2 anchorB, bool useWorldCoordinates = false)
            : base(bodyA, bodyB, JointType.Distance)
        {
            Vector2 d;

            if (useWorldCoordinates)
            {
                localAnchorA = bodyA.GetLocalPoint(ref anchorA);
                localAnchorB = bodyB.GetLocalPoint(ref anchorB);

                d = anchorB - anchorA;
            }
            else
            {
                localAnchorA = anchorA;
                localAnchorB = anchorB;

                d = bodyB.GetWorldPoint(ref anchorB) - bodyA.GetWorldPoint(ref anchorA);
            }

            length = MathUtils.Max(d.Length(), Settings.LinearSlop);
            minLength = length;
            maxLength = length;
        }

        /// <summary>The local anchor point relative to bodyA's origin.</summary>
        public Vector2 LocalAnchorA
        {
            get => localAnchorA;
            set => localAnchorA = value;
        }

        /// <summary>The local anchor point relative to bodyB's origin.</summary>
        public Vector2 LocalAnchorB
        {
            get => localAnchorB;
            set => localAnchorB = value;
        }

        /// <summary>The anchor on <see cref="Joint.BodyA" /> in world coordinates</summary>
        public sealed override Vector2 WorldAnchorA
        {
            get => BodyA.GetWorldPoint(localAnchorA);
            set => Debug.Assert(false, "You can't set the world anchor on this joint type.");
        }

        /// <summary>The anchor on <see cref="Joint.BodyB" /> in world coordinates</summary>
        public sealed override Vector2 WorldAnchorB
        {
            get => BodyB.GetWorldPoint(localAnchorB);
            set => Debug.Assert(false, "You can't set the world anchor on this joint type.");
        }

        /// <summary>The rest length of this joint. Clamped to a stable minimum value.</summary>
        public float Length
        {
            get
            {
                Vector2 pA = BodyA.GetWorldPoint(localAnchorA);
                Vector2 pB = BodyB.GetWorldPoint(localAnchorB);
                Vector2 d = pB - pA;
                float length = d.Length();
                return length;
            }
            set
            {
                impulse = 0.0f;
                length = MathUtils.Max(Settings.LinearSlop, value);
            }
        }

        /// <summary>Set/get the linear stiffness in N/m</summary>
        public float Stiffness
        {
            get => stiffness;
            set => stiffness = value;
        }

        /// <summary>Set/get linear damping in N*s/m</summary>
        public float Damping
        {
            get => damping;
            set => damping = value;
        }

        /// <summary>Minimum length. Clamped to a stable minimum value.</summary>
        public float MinLength
        {
            get => minLength;
            set
            {
                lowerImpulse = 0.0f;
                minLength = MathUtils.Clamp(value, Settings.LinearSlop, maxLength);
            }
        }

        /// <summary>Maximum length. Must be greater than or equal to the minimum length.</summary>
        public float MaxLength
        {
            get => maxLength;
            set
            {
                upperImpulse = 0.0f;
                maxLength = MathUtils.Max(value, minLength);
            }
        }

        /// <summary>Get the reaction force given the inverse time step. Unit is N.</summary>
        public override Vector2 GetReactionForce(float invDt)
        {
            Vector2 f = invDt * (impulse + lowerImpulse - upperImpulse) * u;
            return f;
        }

        /// <summary>Get the reaction torque given the inverse time step. Unit is N*m. This is always zero for a distance joint.</summary>
        public override float GetReactionTorque(float invDt)
        {
            return 0.0f;
        }

        /// <summary>
        ///     Inits the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void InitVelocityConstraints(ref SolverData data)
        {
            indexA = BodyA.IslandIndex;
            indexB = BodyB.IslandIndex;
            localCenterA = BodyA.Sweep.LocalCenter;
            localCenterB = BodyB.Sweep.LocalCenter;
            invMassA = BodyA.InvMass;
            invMassB = BodyB.InvMass;
            invIa = BodyA.InvI;
            invIb = BodyB.InvI;

            Vector2 cA = data.Positions[indexA].C;
            float aA = data.Positions[indexA].A;
            Vector2 vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;

            Vector2 cB = data.Positions[indexB].C;
            float aB = data.Positions[indexB].A;
            Vector2 vB = data.Velocities[indexB].V;
            float wB = data.Velocities[indexB].W;

            Rot qA = new Rot(aA), qB = new Rot(aB);

            rA = MathUtils.Mul(ref qA, localAnchorA - localCenterA);
            rB = MathUtils.Mul(ref qB, localAnchorB - localCenterB);
            u = cB + rB - cA - rA;

            // Handle singularity.
            currentLength = u.Length();
            if (currentLength > Settings.LinearSlop)
            {
                u *= 1.0f / currentLength;
            }
            else
            {
                u = Vector2.Zero;
                mass = 0.0f;
                impulse = 0.0f;
                lowerImpulse = 0.0f;
                upperImpulse = 0.0f;
            }

            float crAu = MathUtils.Cross(rA, u);
            float crBu = MathUtils.Cross(rB, u);
            float invMass = invMassA + invIa * crAu * crAu + invMassB + invIb * crBu * crBu;
            mass = invMass != 0.0f ? 1.0f / invMass : 0.0f;

            if (stiffness > 0.0f && minLength < maxLength)
            {
                // soft
                float c = currentLength - length;

                float d = damping;
                float k = stiffness;

                // magic formulas
                float h = data.Step.DeltaTime;

                // gamma = 1 / (h * (d + h * k))
                // the extra factor of h in the denominator is since the lambda is an impulse, not a force
                gamma = h * (d + h * k);
                gamma = gamma != 0.0f ? 1.0f / gamma : 0.0f;
                bias = c * h * k * gamma;

                invMass += gamma;
                softMass = invMass != 0.0f ? 1.0f / invMass : 0.0f;
            }
            else
            {
                // rigid
                gamma = 0.0f;
                bias = 0.0f;
                softMass = mass;
            }

            if (data.Step.WarmStarting)
            {
                // Scale the impulse to support a variable time step.
                impulse *= data.Step.DeltaTimeRatio;
                lowerImpulse *= data.Step.DeltaTimeRatio;
                upperImpulse *= data.Step.DeltaTimeRatio;

                Vector2 p = (impulse + lowerImpulse - upperImpulse) * u;
                vA -= invMassA * p;
                wA -= invIa * MathUtils.Cross(ref rA, ref p);
                vB += invMassB * p;
                wB += invIb * MathUtils.Cross(ref rB, ref p);
            }
            else
            {
                impulse = 0.0f;
            }

            data.Velocities[indexA].V = vA;
            data.Velocities[indexA].W = wA;
            data.Velocities[indexB].V = vB;
            data.Velocities[indexB].W = wB;
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void SolveVelocityConstraints(ref SolverData data)
        {
            Vector2 vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;
            Vector2 vB = data.Velocities[indexB].V;
            float wB = data.Velocities[indexB].W;

            if (minLength < maxLength)
            {
                if (stiffness > 0.0f)
                {
                    // Cdot = dot(u, v + cross(w, r))
                    Vector2 vpA = vA + MathUtils.Cross(wA, rA);
                    Vector2 vpB = vB + MathUtils.Cross(wB, rB);
                    float cdot = MathUtils.Dot(u, vpB - vpA);

                    float impulse = -softMass * (cdot + bias + gamma * this.impulse);
                    this.impulse += impulse;

                    Vector2 p = impulse * u;
                    vA -= invMassA * p;
                    wA -= invIa * MathUtils.Cross(rA, p);
                    vB += invMassB * p;
                    wB += invIb * MathUtils.Cross(rB, p);
                }

                // lower
                {
                    float c = currentLength - minLength;
                    float bias = MathUtils.Max(0.0f, c) * data.Step.InvertedDeltaTime;

                    Vector2 vpA = vA + MathUtils.Cross(wA, rA);
                    Vector2 vpB = vB + MathUtils.Cross(wB, rB);
                    float cdot = MathUtils.Dot(u, vpB - vpA);

                    float impulse = -mass * (cdot + bias);
                    float oldImpulse = lowerImpulse;
                    lowerImpulse = MathUtils.Max(0.0f, lowerImpulse + impulse);
                    impulse = lowerImpulse - oldImpulse;
                    Vector2 p = impulse * u;

                    vA -= invMassA * p;
                    wA -= invIa * MathUtils.Cross(rA, p);
                    vB += invMassB * p;
                    wB += invIb * MathUtils.Cross(rB, p);
                }

                // upper
                {
                    float c = maxLength - currentLength;
                    float bias = MathUtils.Max(0.0f, c) * data.Step.InvertedDeltaTime;

                    Vector2 vpA = vA + MathUtils.Cross(wA, rA);
                    Vector2 vpB = vB + MathUtils.Cross(wB, rB);
                    float cdot = MathUtils.Dot(u, vpA - vpB);

                    float impulse = -mass * (cdot + bias);
                    float oldImpulse = upperImpulse;
                    upperImpulse = MathUtils.Max(0.0f, upperImpulse + impulse);
                    impulse = upperImpulse - oldImpulse;
                    Vector2 p = -impulse * u;

                    vA -= invMassA * p;
                    wA -= invIa * MathUtils.Cross(rA, p);
                    vB += invMassB * p;
                    wB += invIb * MathUtils.Cross(rB, p);
                }
            }
            else
            {
                // Equal limits

                // Cdot = dot(u, v + cross(w, r))
                Vector2 vpA = vA + MathUtils.Cross(wA, rA);
                Vector2 vpB = vB + MathUtils.Cross(wB, rB);
                float cdot = MathUtils.Dot(u, vpB - vpA);

                float impulse = -mass * cdot;
                this.impulse += impulse;

                Vector2 p = impulse * u;
                vA -= invMassA * p;
                wA -= invIa * MathUtils.Cross(rA, p);
                vB += invMassB * p;
                wB += invIb * MathUtils.Cross(rB, p);
            }

            data.Velocities[indexA].V = vA;
            data.Velocities[indexA].W = wA;
            data.Velocities[indexB].V = vB;
            data.Velocities[indexB].W = wB;
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(ref SolverData data)
        {
            Vector2 cA = data.Positions[indexA].C;
            float aA = data.Positions[indexA].A;
            Vector2 cB = data.Positions[indexB].C;
            float aB = data.Positions[indexB].A;

            Rot qA = new Rot(aA), qB = new Rot(aB);

            Vector2 rA = MathUtils.Mul(qA, localAnchorA - localCenterA);
            Vector2 rB = MathUtils.Mul(qB, localAnchorB - localCenterB);
            Vector2 u = cB + rB - cA - rA;

            float length = MathUtils.Normalize(ref u);
            float c;
            if (minLength == maxLength)
            {
                c = length - minLength;
            }
            else if (length < minLength)
            {
                c = length - minLength;
            }
            else if (maxLength < length)
            {
                c = length - maxLength;
            }
            else
            {
                return true;
            }

            float impulse = -mass * c;
            Vector2 p = impulse * u;

            cA -= invMassA * p;
            aA -= invIa * MathUtils.Cross(rA, p);
            cB += invMassB * p;
            aB += invIb * MathUtils.Cross(rB, p);

            data.Positions[indexA].C = cA;
            data.Positions[indexA].A = aA;
            data.Positions[indexB].C = cB;
            data.Positions[indexB].A = aB;

            return MathUtils.Abs(c) < Settings.LinearSlop;
        }
    }
}