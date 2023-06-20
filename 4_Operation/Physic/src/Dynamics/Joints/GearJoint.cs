// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GearJoint.cs
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
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics.Solver;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Dynamics.Joints
{
    // Gear Joint:
    // C0 = (coordinate1 + ratio * coordinate2)_initial
    // C = (coordinate1 + ratio * coordinate2) - C0 = 0
    // J = [J1 ratio * J2]
    // K = J * invM * JT
    //   = J1 * invM1 * J1T + ratio * ratio * J2 * invM2 * J2T
    //
    // Revolute:
    // coordinate = rotation
    // Cdot = angularVelocity
    // J = [0 0 1]
    // K = J * invM * JT = invI
    //
    // Prismatic:
    // coordinate = dot(p - pg, ug)
    // Cdot = dot(v + cross(w, r), ug)
    // J = [ug cross(r, ug)]
    // K = J * invM * JT = invMass + invI * cross(r, ug)^2

    /// <summary>
    ///     A gear joint is used to connect two joints together. Either joint can be a revolute or prismatic joint. You specify
    ///     a
    ///     gear ratio to bind the motions together:
    ///     <![CDATA[coordinate1 + ratio * coordinate2 = ant]]>
    ///     The ratio can be negative or positive. If one joint is a revolute joint and the other joint is a prismatic joint,
    ///     then
    ///     the ratio will have units of length or units of 1/length. Warning: You have to manually destroy the gear joint if
    ///     jointA or jointB is destroyed.
    /// </summary>
    public class GearJoint : Joint
    {
        /// <summary>
        ///     The body
        /// </summary>
        private readonly Body bodyC;

        /// <summary>
        ///     The body
        /// </summary>
        private readonly Body bodyD;

        /// <summary>
        ///     The constant
        /// </summary>
        private readonly float constant;

        /// <summary>
        ///     The joint
        /// </summary>
        private readonly Joint jointA;

        /// <summary>
        ///     The joint
        /// </summary>
        private readonly Joint jointB;

        // Solver shared
        /// <summary>
        ///     The local anchor
        /// </summary>
        private readonly Vector2F localAnchorA;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private readonly Vector2F localAnchorB;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private readonly Vector2F localAnchorC;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private readonly Vector2F localAnchorD;

        /// <summary>
        ///     The local axis
        /// </summary>
        private readonly Vector2F localAxisC;

        /// <summary>
        ///     The local axis
        /// </summary>
        private readonly Vector2F localAxisD;

        /// <summary>
        ///     The reference angle
        /// </summary>
        private readonly float referenceAngleA;

        /// <summary>
        ///     The reference angle
        /// </summary>
        private readonly float referenceAngleB;

        /// <summary>
        ///     The type
        /// </summary>
        private readonly JointType typeA;

        /// <summary>
        ///     The type
        /// </summary>
        private readonly JointType typeB;

        /// <summary>
        ///     The
        /// </summary>
        private float iA, iB, iC, iD;

        /// <summary>
        ///     The impulse
        /// </summary>
        private float impulse;

        // Solver temp
        /// <summary>
        ///     The index
        /// </summary>
        private int indexA, indexB, indexC, indexD;

        /// <summary>
        ///     The jv bd
        /// </summary>
        private Vector2F jvAc, jvBd;

        /// <summary>
        ///     The jw
        /// </summary>
        private float jwA, jwB, jwC, jwD;

        /// <summary>
        ///     The lc
        /// </summary>
        private Vector2F lcA, lcB, lcC, lcD;

        /// <summary>
        ///     The
        /// </summary>
        private float mA, mB, mC, mD;

        /// <summary>
        ///     The mass
        /// </summary>
        private float mass;

        /// <summary>
        ///     The ratio
        /// </summary>
        private float ratio;


        /// <summary>
        ///     Initializes a new instance of the <see cref="GearJoint" /> class
        /// </summary>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="jointType">The joint type</param>
        /// <param name="collideConnected">The collide connected</param>
        /// <param name="jointA">The joint</param>
        /// <param name="jointB">The joint</param>
        /// <param name="ratio">The ratio</param>
        public GearJoint(
            Body bodyA = null,
            Body bodyB = null,
            JointType jointType = default(JointType),
            bool collideConnected = false,
            Joint jointA = null,
            Joint jointB = null,
            float ratio = 1.0f
        ) : base(bodyA, bodyB, jointType, collideConnected)
        {
            this.jointA = jointA;
            this.jointB = jointB;

            typeA = this.jointA.JointType;
            typeB = this.jointB.JointType;


            float coordinateA, coordinateB;

            bodyC = this.jointA.BodyA;
            BodyA = this.jointA.BodyB;

            // Get geometry of joint1
            Transform xfA = BodyA.Xf;
            float aA = BodyA.Sweep.A;
            Transform xfC = bodyC.Xf;
            float aC = bodyC.Sweep.A;

            if (typeA == JointType.Revolute)
            {
                RevoluteJoint revolute = (RevoluteJoint) jointA;
                localAnchorC = revolute.LocalAnchorA;
                localAnchorA = revolute.LocalAnchorB;
                referenceAngleA = revolute.ReferenceAngle;
                localAxisC = Vector2F.Zero;

                coordinateA = aA - aC - referenceAngleA;
            }
            else
            {
                PrismaticJoint prismatic = (PrismaticJoint) jointA;
                localAnchorC = prismatic.LocalAnchorA;
                localAnchorA = prismatic.LocalAnchorB;
                referenceAngleA = prismatic.ReferenceAngle;
                localAxisC = prismatic.LocalXAxisA;

                Vector2F pC = localAnchorC;
                Vector2F pA = MathUtils.MulT(xfC.Rotation, MathUtils.Mul(xfA.Rotation, localAnchorA) + (xfA.Position - xfC.Position));
                coordinateA = MathUtils.Dot(pA - pC, localAxisC);
            }

            bodyD = jointB.BodyA;
            BodyB = jointB.BodyB;

            // Get geometry of joint2
            Transform xfB = BodyB.Xf;
            float aB = BodyB.Sweep.A;
            Transform xfD = bodyD.Xf;
            float aD = bodyD.Sweep.A;

            if (typeB == JointType.Revolute)
            {
                RevoluteJoint revolute = (RevoluteJoint) jointB;
                localAnchorD = revolute.LocalAnchorA;
                localAnchorB = revolute.LocalAnchorB;
                referenceAngleB = revolute.ReferenceAngle;
                localAxisD = Vector2F.Zero;

                coordinateB = aB - aD - referenceAngleB;
            }
            else
            {
                PrismaticJoint prismatic = (PrismaticJoint) jointB;
                localAnchorD = prismatic.LocalAnchorA;
                localAnchorB = prismatic.LocalAnchorB;
                referenceAngleB = prismatic.ReferenceAngle;
                localAxisD = prismatic.LocalXAxisA;

                Vector2F pD = localAnchorD;
                Vector2F pB = MathUtils.MulT(xfD.Rotation, MathUtils.Mul(xfB.Rotation, localAnchorB) + (xfB.Position - xfD.Position));
                coordinateB = MathUtils.Dot(pB - pD, localAxisD);
            }

            this.ratio = ratio;

            constant = coordinateA + ratio * coordinateB;

            impulse = 0.0f;
        }

        /// <summary>
        ///     Requires two existing revolute or prismatic joints (any combination will work). The provided joints must
        ///     attach a dynamic body to a static body.
        /// </summary>
        /// <param name="jointA">The first joint.</param>
        /// <param name="jointB">The second joint.</param>
        /// <param name="ratio">The ratio.</param>
        /// <param name="bodyA">The first body</param>
        /// <param name="bodyB">The second body</param>
        public GearJoint(Body bodyA, Body bodyB, Joint jointA, Joint jointB, float ratio = 1f) : base(bodyA, bodyB,
            JointType.Gear)
        {
            this.jointA = jointA;
            this.jointB = jointB;

            typeA = jointA.JointType;
            typeB = jointB.JointType;

            float coordinateA, coordinateB;

            bodyC = JointA.BodyA;
            BodyA = JointA.BodyB;


            // Get geometry of joint1
            Transform xfA = BodyA.Xf;
            float aA = BodyA.Sweep.A;
            Transform xfC = bodyC.Xf;
            float aC = bodyC.Sweep.A;

            if (typeA == JointType.Revolute)
            {
                RevoluteJoint revolute = (RevoluteJoint) jointA;
                localAnchorC = revolute.LocalAnchorA;
                localAnchorA = revolute.LocalAnchorB;
                referenceAngleA = revolute.ReferenceAngle;
                localAxisC = Vector2F.Zero;

                coordinateA = aA - aC - referenceAngleA;
            }
            else
            {
                PrismaticJoint prismatic = (PrismaticJoint) jointA;
                localAnchorC = prismatic.LocalAnchorA;
                localAnchorA = prismatic.LocalAnchorB;
                referenceAngleA = prismatic.ReferenceAngle;
                localAxisC = prismatic.LocalXAxisA;

                Vector2F pC = localAnchorC;
                Vector2F pA = MathUtils.MulT(xfC.Rotation, MathUtils.Mul(xfA.Rotation, localAnchorA) + (xfA.Position - xfC.Position));
                coordinateA = Vector2F.Dot(pA - pC, localAxisC);
            }

            bodyD = JointB.BodyA;
            BodyB = JointB.BodyB;

            // Get geometry of joint2
            Transform xfB = BodyB.Xf;
            float aB = BodyB.Sweep.A;
            Transform xfD = bodyD.Xf;
            float aD = bodyD.Sweep.A;

            if (typeB == JointType.Revolute)
            {
                RevoluteJoint revolute = (RevoluteJoint) jointB;
                localAnchorD = revolute.LocalAnchorA;
                localAnchorB = revolute.LocalAnchorB;
                referenceAngleB = revolute.ReferenceAngle;
                localAxisD = Vector2F.Zero;

                coordinateB = aB - aD - referenceAngleB;
            }
            else
            {
                PrismaticJoint prismatic = (PrismaticJoint) jointB;
                localAnchorD = prismatic.LocalAnchorA;
                localAnchorB = prismatic.LocalAnchorB;
                referenceAngleB = prismatic.ReferenceAngle;
                localAxisD = prismatic.LocalXAxisA;

                Vector2F pD = localAnchorD;
                Vector2F pB = MathUtils.MulT(xfD.Rotation, MathUtils.Mul(xfB.Rotation, localAnchorB) + (xfB.Position - xfD.Position));
                coordinateB = Vector2F.Dot(pB - pD, localAxisD);
            }

            this.ratio = ratio;
            constant = coordinateA + this.ratio * coordinateB;
            impulse = 0.0f;
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor a
        /// </summary>
        public override Vector2F WorldAnchorA
        {
            get => BodyA.GetWorldPoint(localAnchorA);
            set => throw new ArgumentException(value.ToString());
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public override Vector2F WorldAnchorB
        {
            get => BodyB.GetWorldPoint(localAnchorB);
            set => throw new ArgumentException(value.ToString());
        }

        /// <summary>The gear ratio.</summary>
        public float Ratio
        {
            get => ratio;
            set => ratio = value;
        }

        /// <summary>The first revolute/prismatic joint attached to the gear joint.</summary>
        public Joint JointA => jointA;

        /// <summary>The second revolute/prismatic joint attached to the gear joint.</summary>
        public Joint JointB => jointB;

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2F GetReactionForce(float invDt)
        {
            Vector2F p = impulse * jvAc;
            return invDt * p;
        }

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt)
        {
            float l = impulse * jwA;
            return invDt * l;
        }

        /// <summary>
        ///     Inits the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void InitVelocityConstraints(ref SolverData data)
        {
            indexA = BodyA.IslandIndex;
            indexB = BodyB.IslandIndex;
            indexC = bodyC.IslandIndex;
            indexD = bodyD.IslandIndex;
            lcA = BodyA.Sweep.LocalCenter;
            lcB = BodyB.Sweep.LocalCenter;
            lcC = bodyC.Sweep.LocalCenter;
            lcD = bodyD.Sweep.LocalCenter;
            mA = BodyA.InvMass;
            mB = BodyB.InvMass;
            mC = bodyC.InvMass;
            mD = bodyD.InvMass;
            iA = BodyA.InvI;
            iB = BodyB.InvI;
            iC = bodyC.InvI;
            iD = bodyD.InvI;

            float aA = data.Positions[indexA].A;
            Vector2F vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;

            float aB = data.Positions[indexB].A;
            Vector2F vB = data.Velocities[indexB].V;
            float wB = data.Velocities[indexB].W;

            float aC = data.Positions[indexC].A;
            Vector2F vC = data.Velocities[indexC].V;
            float wC = data.Velocities[indexC].W;

            float aD = data.Positions[indexD].A;
            Vector2F vD = data.Velocities[indexD].V;
            float wD = data.Velocities[indexD].W;

            Rotation qA = new Rotation(aA), qB = new Rotation(aB), qC = new Rotation(aC), qD = new Rotation(aD);

            mass = 0.0f;

            if (typeA == JointType.Revolute)
            {
                jvAc = Vector2F.Zero;
                jwA = 1.0f;
                jwC = 1.0f;
                mass += iA + iC;
            }
            else
            {
                Vector2F u = MathUtils.Mul(qC, localAxisC);
                Vector2F rC = MathUtils.Mul(qC, localAnchorC - lcC);
                Vector2F rA = MathUtils.Mul(qA, localAnchorA - lcA);
                jvAc = u;
                jwC = MathUtils.Cross(rC, u);
                jwA = MathUtils.Cross(rA, u);
                mass += mC + mA + iC * jwC * jwC + iA * jwA * jwA;
            }

            if (typeB == JointType.Revolute)
            {
                jvBd = Vector2F.Zero;
                jwB = ratio;
                jwD = ratio;
                mass += ratio * ratio * (iB + iD);
            }
            else
            {
                Vector2F u = MathUtils.Mul(qD, localAxisD);
                Vector2F rD = MathUtils.Mul(qD, localAnchorD - lcD);
                Vector2F rB = MathUtils.Mul(qB, localAnchorB - lcB);
                jvBd = ratio * u;
                jwD = ratio * MathUtils.Cross(rD, u);
                jwB = ratio * MathUtils.Cross(rB, u);
                mass += ratio * ratio * (mD + mB) + iD * jwD * jwD + iB * jwB * jwB;
            }

            // Compute effective mass.
            mass = mass > 0.0f ? 1.0f / mass : 0.0f;

            if (data.Step.WarmStarting)
            {
                vA += mA * impulse * jvAc;
                wA += iA * impulse * jwA;
                vB += mB * impulse * jvBd;
                wB += iB * impulse * jwB;
                vC -= mC * impulse * jvAc;
                wC -= iC * impulse * jwC;
                vD -= mD * impulse * jvBd;
                wD -= iD * impulse * jwD;
            }
            else
            {
                impulse = 0.0f;
            }

            data.Velocities[indexA].V = vA;
            data.Velocities[indexA].W = wA;
            data.Velocities[indexB].V = vB;
            data.Velocities[indexB].W = wB;
            data.Velocities[indexC].V = vC;
            data.Velocities[indexC].W = wC;
            data.Velocities[indexD].V = vD;
            data.Velocities[indexD].W = wD;
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
            Vector2F vC = data.Velocities[indexC].V;
            float wC = data.Velocities[indexC].W;
            Vector2F vD = data.Velocities[indexD].V;
            float wD = data.Velocities[indexD].W;

            float cdot = Vector2F.Dot(jvAc, vA - vC) + Vector2F.Dot(jvBd, vB - vD);
            cdot += jwA * wA - jwC * wC + (jwB * wB - jwD * wD);

            float impulse = -mass * cdot;
            this.impulse += impulse;

            vA += mA * impulse * jvAc;
            wA += iA * impulse * jwA;
            vB += mB * impulse * jvBd;
            wB += iB * impulse * jwB;
            vC -= mC * impulse * jvAc;
            wC -= iC * impulse * jwC;
            vD -= mD * impulse * jvBd;
            wD -= iD * impulse * jwD;

            data.Velocities[indexA].V = vA;
            data.Velocities[indexA].W = wA;
            data.Velocities[indexB].V = vB;
            data.Velocities[indexB].W = wB;
            data.Velocities[indexC].V = vC;
            data.Velocities[indexC].W = wC;
            data.Velocities[indexD].V = vD;
            data.Velocities[indexD].W = wD;
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
            Vector2F cC = data.Positions[indexC].C;
            float aC = data.Positions[indexC].A;
            Vector2F cD = data.Positions[indexD].C;
            float aD = data.Positions[indexD].A;

            Rotation qA = new Rotation(aA), qB = new Rotation(aB), qC = new Rotation(aC), qD = new Rotation(aD);

            const float linearError = 0.0f;

            float coordinateA, coordinateB;

            Vector2F jvAc, jvBd;
            float jwA, jwB, jwC, jwD;
            float mass = 0.0f;

            if (typeA == JointType.Revolute)
            {
                jvAc = Vector2F.Zero;
                jwA = 1.0f;
                jwC = 1.0f;
                mass += iA + iC;

                coordinateA = aA - aC - referenceAngleA;
            }
            else
            {
                Vector2F u = MathUtils.Mul(qC, localAxisC);
                Vector2F rC = MathUtils.Mul(qC, localAnchorC - lcC);
                Vector2F rA = MathUtils.Mul(qA, localAnchorA - lcA);
                jvAc = u;
                jwC = MathUtils.Cross(rC, u);
                jwA = MathUtils.Cross(rA, u);
                mass += mC + mA + iC * jwC * jwC + iA * jwA * jwA;

                Vector2F pC = localAnchorC - lcC;
                Vector2F pA = MathUtils.MulT(qC, rA + (cA - cC));
                coordinateA = Vector2F.Dot(pA - pC, localAxisC);
            }

            if (typeB == JointType.Revolute)
            {
                jvBd = Vector2F.Zero;
                jwB = ratio;
                jwD = ratio;
                mass += ratio * ratio * (iB + iD);

                coordinateB = aB - aD - referenceAngleB;
            }
            else
            {
                Vector2F u = MathUtils.Mul(qD, localAxisD);
                Vector2F rD = MathUtils.Mul(qD, localAnchorD - lcD);
                Vector2F rB = MathUtils.Mul(qB, localAnchorB - lcB);
                jvBd = ratio * u;
                jwD = ratio * MathUtils.Cross(rD, u);
                jwB = ratio * MathUtils.Cross(rB, u);
                mass += ratio * ratio * (mD + mB) + iD * jwD * jwD + iB * jwB * jwB;

                Vector2F pD = localAnchorD - lcD;
                Vector2F pB = MathUtils.MulT(qD, rB + (cB - cD));
                coordinateB = Vector2F.Dot(pB - pD, localAxisD);
            }

            float c = coordinateA + ratio * coordinateB - constant;

            float impulse = 0.0f;
            if (mass > 0.0f)
            {
                impulse = -c / mass;
            }

            cA += mA * impulse * jvAc;
            aA += iA * impulse * jwA;
            cB += mB * impulse * jvBd;
            aB += iB * impulse * jwB;
            cC -= mC * impulse * jvAc;
            aC -= iC * impulse * jwC;
            cD -= mD * impulse * jvBd;
            aD -= iD * impulse * jwD;

            data.Positions[indexA].C = cA;
            data.Positions[indexA].A = aA;
            data.Positions[indexB].C = cB;
            data.Positions[indexB].A = aB;
            data.Positions[indexC].C = cC;
            data.Positions[indexC].A = aC;
            data.Positions[indexD].C = cD;
            data.Positions[indexD].A = aD;

            return linearError < Settings.LinearSlop;
        }
    }
}