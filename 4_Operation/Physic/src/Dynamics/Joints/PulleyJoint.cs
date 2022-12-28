// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PulleyJoint.cs
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

using System;
using System.Diagnostics;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Definitions.Joints;
using Alis.Core.Physic.Dynamics.Joints.Misc;
using Alis.Core.Physic.Dynamics.Solver;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Dynamics.Joints
{
    // Pulley:
    // length1 = norm(p1 - s1)
    // length2 = norm(p2 - s2)
    // C0 = (length1 + ratio * length2)_initial
    // C = C0 - (length1 + ratio * length2)
    // u1 = (p1 - s1) / norm(p1 - s1)
    // u2 = (p2 - s2) / norm(p2 - s2)
    // Cdot = -dot(u1, v1 + cross(w1, r1)) - ratio * dot(u2, v2 + cross(w2, r2))
    // J = -[u1 cross(r1, u1) ratio * u2  ratio * cross(r2, u2)]
    // K = J * invM * JT
    //   = invMass1 + invI1 * cross(r1, u1)^2 + ratio^2 * (invMass2 + invI2 * cross(r2, u2)^2)

    /// <summary>
    ///     The pulley joint is connected to two bodies and two fixed world points. The pulley supports a ratio such that:
    ///     <![CDATA[length1 + ratio * length2 <= constant]]>
    ///     Yes, the force transmitted is scaled by the ratio. Warning: the pulley joint can get a bit squirrelly by itself.
    ///     They
    ///     often work better when combined with prismatic joints. You should also cover the the anchor points with static
    ///     shapes
    ///     to prevent one side from going to zero length.
    /// </summary>
    public class PulleyJoint : Joint
    {
        /// <summary>
        ///     The constant
        /// </summary>
        private readonly float constant;

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
        private float lengthA;

        /// <summary>
        ///     The length
        /// </summary>
        private float lengthB;

        // Solver shared
        /// <summary>
        ///     The local anchor
        /// </summary>
        private Vector2F localAnchorA;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private Vector2F localAnchorB;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2F localCenterA;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2F localCenterB;

        /// <summary>
        ///     The mass
        /// </summary>
        private float mass;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F rA;

        /// <summary>
        ///     The ratio
        /// </summary>
        private float ratio;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F rB;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F uA;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F uB;

        /// <summary>
        ///     The world anchor
        /// </summary>
        private Vector2F worldAnchorA;

        /// <summary>
        ///     The world anchor
        /// </summary>
        private Vector2F worldAnchorB;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PulleyJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public PulleyJoint(PulleyJointDef def)
            : base(def)
        {
            worldAnchorA = def.GroundAnchorA;
            worldAnchorB = def.GroundAnchorB;
            localAnchorA = def.LocalAnchorA;
            localAnchorB = def.LocalAnchorB;

            lengthA = def.LengthA;
            lengthB = def.LengthB;

            Debug.Assert(def.Ratio != 0.0f);
            ratio = def.Ratio;

            constant = def.LengthA + ratio * def.LengthB;
        }

        /// <summary>Constructor for PulleyJoint.</summary>
        /// <param name="bodyA">The first body.</param>
        /// <param name="bodyB">The second body.</param>
        /// <param name="anchorA">The anchor on the first body.</param>
        /// <param name="anchorB">The anchor on the second body.</param>
        /// <param name="worldAnchorA">The world anchor for the first body.</param>
        /// <param name="worldAnchorB">The world anchor for the second body.</param>
        /// <param name="ratio">The ratio.</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public PulleyJoint(Body bodyA, Body bodyB, Vector2F anchorA, Vector2F anchorB, Vector2F worldAnchorA,
            Vector2F worldAnchorB, float ratio, bool useWorldCoordinates = false)
            : base(bodyA, bodyB, JointType.Pulley)
        {
            this.worldAnchorA = worldAnchorA;
            this.worldAnchorB = worldAnchorB;

            if (useWorldCoordinates)
            {
                localAnchorA = bodyA.GetLocalPoint(anchorA);
                localAnchorB = bodyB.GetLocalPoint(anchorB);

                Vector2F dA = anchorA - worldAnchorA;
                lengthA = dA.Length();
                Vector2F dB = anchorB - worldAnchorB;
                lengthB = dB.Length();
            }
            else
            {
                localAnchorA = anchorA;
                localAnchorB = anchorB;

                Vector2F dA = anchorA - bodyA.GetLocalPoint(worldAnchorA);
                lengthA = dA.Length();
                Vector2F dB = anchorB - bodyB.GetLocalPoint(worldAnchorB);
                lengthB = dB.Length();
            }

            Debug.Assert(ratio != 0.0f);
            Debug.Assert(ratio > MathConstants.Epsilon);

            this.ratio = ratio;
            constant = lengthA + ratio * lengthB;
            impulse = 0.0f;
        }

        /// <summary>The local anchor point on BodyA</summary>
        public Vector2F LocalAnchorA
        {
            get => localAnchorA;
            set => localAnchorA = value;
        }

        /// <summary>The local anchor point on BodyB</summary>
        public Vector2F LocalAnchorB
        {
            get => localAnchorB;
            set => localAnchorB = value;
        }

        /// <summary>Get the first world anchor.</summary>
        public sealed override Vector2F WorldAnchorA
        {
            get => worldAnchorA;
            set => worldAnchorA = value;
        }

        /// <summary>Get the second world anchor.</summary>
        public sealed override Vector2F WorldAnchorB
        {
            get => worldAnchorB;
            set => worldAnchorB = value;
        }

        /// <summary>Get the current length of the segment attached to BodyA.</summary>
        public float LengthA
        {
            get => lengthA;
            set => lengthA = value;
        }

        /// <summary>Get the current length of the segment attached to BodyB.</summary>
        public float LengthB
        {
            get => lengthB;
            set => lengthB = value;
        }

        /// <summary>The current length between the anchor point on BodyA and WorldAnchorA</summary>
        public float CurrentLengthA
        {
            get
            {
                Vector2F p = BodyA.GetWorldPoint(localAnchorA);
                Vector2F s = worldAnchorA;
                Vector2F d = p - s;
                return d.Length();
            }
        }

        /// <summary>The current length between the anchor point on BodyB and WorldAnchorB</summary>
        public float CurrentLengthB
        {
            get
            {
                Vector2F p = BodyB.GetWorldPoint(localAnchorB);
                Vector2F s = worldAnchorB;
                Vector2F d = p - s;
                return d.Length();
            }
        }

        /// <summary>Get the pulley ratio.</summary>
        public float Ratio
        {
            get => ratio;
            set => ratio = value;
        }

        /// <summary>
        ///     Shifts the origin using the specified new origin
        /// </summary>
        /// <param name="newOrigin">The new origin</param>
        public override void ShiftOrigin(ref Vector2F newOrigin)
        {
            worldAnchorA -= newOrigin;
            worldAnchorB -= newOrigin;
        }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2F GetReactionForce(float invDt)
        {
            Vector2F p = impulse * uB;
            return invDt * p;
        }

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt) => 0.0f;

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

            Vector2F cA = data.Positions[indexA].C;
            float aA = data.Positions[indexA].A;
            Vector2F vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;

            Vector2F cB = data.Positions[indexB].C;
            float aB = data.Positions[indexB].A;
            Vector2F vB = data.Velocities[indexB].V;
            float wB = data.Velocities[indexB].W;

            Rotation qA = new Rotation(aA), qB = new Rotation(aB);

            rA = MathUtils.Mul(qA, localAnchorA - localCenterA);
            rB = MathUtils.Mul(qB, localAnchorB - localCenterB);

            // Get the pulley axes.
            uA = cA + rA - worldAnchorA;
            uB = cB + rB - worldAnchorB;

            float lengthA = uA.Length();
            float lengthB = uB.Length();

            if (lengthA > 10.0f * Settings.LinearSlop)
            {
                uA *= 1.0f / lengthA;
            }
            else
            {
                uA = Vector2F.Zero;
            }

            if (lengthB > 10.0f * Settings.LinearSlop)
            {
                uB *= 1.0f / lengthB;
            }
            else
            {
                uB = Vector2F.Zero;
            }

            // Compute effective mass.
            float ruA = MathUtils.Cross(rA, uA);
            float ruB = MathUtils.Cross(rB, uB);

            float mA = invMassA + invIa * ruA * ruA;
            float mB = invMassB + invIb * ruB * ruB;

            mass = mA + ratio * ratio * mB;

            if (mass > 0.0f)
            {
                mass = 1.0f / mass;
            }

            if (data.Step.WarmStarting)
            {
                // Scale impulses to support variable time steps.
                impulse *= data.Step.DeltaTimeRatio;

                // Warm starting.
                Vector2F pa = -impulse * uA;
                Vector2F pb = -ratio * impulse * uB;

                vA += invMassA * pa;
                wA += invIa * MathUtils.Cross(rA, pa);
                vB += invMassB * pb;
                wB += invIb * MathUtils.Cross(rB, pb);
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
            Vector2F vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;
            Vector2F vB = data.Velocities[indexB].V;
            float wB = data.Velocities[indexB].W;

            Vector2F vpA = vA + MathUtils.Cross(wA, rA);
            Vector2F vpB = vB + MathUtils.Cross(wB, rB);

            float cdot = -Vector2F.Dot(uA, vpA) - ratio * Vector2F.Dot(uB, vpB);
            float impulse = -mass * cdot;
            this.impulse += impulse;

            Vector2F pa = -impulse * uA;
            Vector2F pb = -ratio * impulse * uB;
            vA += invMassA * pa;
            wA += invIa * MathUtils.Cross(rA, pa);
            vB += invMassB * pb;
            wB += invIb * MathUtils.Cross(rB, pb);

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
            Vector2F cA = data.Positions[indexA].C;
            float aA = data.Positions[indexA].A;
            Vector2F cB = data.Positions[indexB].C;
            float aB = data.Positions[indexB].A;

            Rotation qA = new Rotation(aA), qB = new Rotation(aB);

            Vector2F rA = MathUtils.Mul(qA, localAnchorA - localCenterA);
            Vector2F rB = MathUtils.Mul(qB, localAnchorB - localCenterB);

            // Get the pulley axes.
            Vector2F uA = cA + rA - worldAnchorA;
            Vector2F uB = cB + rB - worldAnchorB;

            float lengthA = uA.Length();
            float lengthB = uB.Length();

            if (lengthA > 10.0f * Settings.LinearSlop)
            {
                uA *= 1.0f / lengthA;
            }
            else
            {
                uA = Vector2F.Zero;
            }

            if (lengthB > 10.0f * Settings.LinearSlop)
            {
                uB *= 1.0f / lengthB;
            }
            else
            {
                uB = Vector2F.Zero;
            }

            // Compute effective mass.
            float ruA = MathUtils.Cross(rA, uA);
            float ruB = MathUtils.Cross(rB, uB);

            float mA = invMassA + invIa * ruA * ruA;
            float mB = invMassB + invIb * ruB * ruB;

            float mass = mA + ratio * ratio * mB;

            if (mass > 0.0f)
            {
                mass = 1.0f / mass;
            }

            float c = constant - lengthA - ratio * lengthB;
            float linearError = Math.Abs(c);

            float impulse = -mass * c;

            Vector2F pa = -impulse * uA;
            Vector2F pb = -ratio * impulse * uB;

            cA += invMassA * pa;
            aA += invIa * MathUtils.Cross(rA, pa);
            cB += invMassB * pb;
            aB += invIb * MathUtils.Cross(rB, pb);

            data.Positions[indexA].C = cA;
            data.Positions[indexA].A = aA;
            data.Positions[indexB].C = cB;
            data.Positions[indexB].A = aB;

            return linearError < Settings.LinearSlop;
        }
    }
}