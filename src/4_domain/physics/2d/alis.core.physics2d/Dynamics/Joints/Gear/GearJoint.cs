// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   GearJoint.cs
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

// Gear Joint:
// C0 = (coordinate1 + ratio * coordinate2)_initial
// C = C0 - (cordinate1 + ratio * coordinate2) = 0
// Cdot = -(Cdot1 + ratio * Cdot2)
// J = -[J1 ratio * J2]
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

using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Physics2D.Common;
using Alis.Core.Physics2D.Dynamics.Bodies;
using Alis.Core.Physics2D.Dynamics.Joints.Prismatic;
using Alis.Core.Physics2D.Dynamics.Joints.Revolute;
using Alis.Core.Physics2D.Dynamics.World;

namespace Alis.Core.Physics2D.Dynamics.Joints.Gear
{
    /// <summary>
    ///     A gear joint is used to connect two joints together. Either joint
    ///     can be a revolute or prismatic joint. You specify a gear ratio
    ///     to bind the motions together:
    ///     coordinate1 + ratio * coordinate2 = constant
    ///     The ratio can be negative or positive. If one joint is a revolute joint
    ///     and the other joint is a prismatic joint, then the ratio will have units
    ///     of length or units of 1/length.
    ///     @warning The revolute and prismatic joints must be attached to
    ///     fixed bodies (which must be body1 on those joints).
    /// </summary>
    public class GearJoint : Joint
    {
        /// <summary>
        /// The bodyc
        /// </summary>
        private readonly Body m_bodyC;
        /// <summary>
        /// The bodyd
        /// </summary>
        private readonly Body m_bodyD;
        /// <summary>
        /// The constant
        /// </summary>
        private readonly float m_constant;
        /// <summary>
        /// The joint1
        /// </summary>
        private readonly Joint m_joint1;
        /// <summary>
        /// The joint2
        /// </summary>
        private readonly Joint m_joint2;
        /// <summary>
        /// The localanchora
        /// </summary>
        private readonly Vector2 m_localAnchorA;
        /// <summary>
        /// The localanchorb
        /// </summary>
        private readonly Vector2 m_localAnchorB;
        /// <summary>
        /// The localanchorc
        /// </summary>
        private readonly Vector2 m_localAnchorC;
        /// <summary>
        /// The localanchord
        /// </summary>
        private readonly Vector2 m_localAnchorD;
        /// <summary>
        /// The localaxisc
        /// </summary>
        private readonly Vector2 m_localAxisC;
        /// <summary>
        /// The localaxisd
        /// </summary>
        private readonly Vector2 m_localAxisD;
        /// <summary>
        /// The referenceanglea
        /// </summary>
        private readonly float m_referenceAngleA;
        /// <summary>
        /// The referenceangleb
        /// </summary>
        private readonly float m_referenceAngleB;
        /// <summary>
        /// The ia
        /// </summary>
        private float m_iA;
        /// <summary>
        /// The ib
        /// </summary>
        private float m_iB;
        /// <summary>
        /// The ic
        /// </summary>
        private float m_iC;
        /// <summary>
        /// The id
        /// </summary>
        private float m_iD;
        /// <summary>
        /// The impulse
        /// </summary>
        private float m_impulse;
        /// <summary>
        /// The indexa
        /// </summary>
        private int m_indexA;
        /// <summary>
        /// The indexb
        /// </summary>
        private int m_indexB;
        /// <summary>
        /// The indexc
        /// </summary>
        private int m_indexC;
        /// <summary>
        /// The indexd
        /// </summary>
        private int m_indexD;
        /// <summary>
        /// The jvac
        /// </summary>
        private Vector2 m_jvAc;
        /// <summary>
        /// The jvbd
        /// </summary>
        private Vector2 m_jvBd;
        /// <summary>
        /// The jwa
        /// </summary>
        private float m_jwA;
        /// <summary>
        /// The jwb
        /// </summary>
        private float m_jwB;
        /// <summary>
        /// The jwc
        /// </summary>
        private float m_jwC;
        /// <summary>
        /// The jwd
        /// </summary>
        private float m_jwD;
        /// <summary>
        /// The lca
        /// </summary>
        private Vector2 m_lcA;
        /// <summary>
        /// The lcb
        /// </summary>
        private Vector2 m_lcB;
        /// <summary>
        /// The lcc
        /// </summary>
        private Vector2 m_lcC;
        /// <summary>
        /// The lcd
        /// </summary>
        private Vector2 m_lcD;
        /// <summary>
        /// The ma
        /// </summary>
        private float m_mA;
        /// <summary>
        /// The mass
        /// </summary>
        private float m_mass;
        /// <summary>
        /// The mb
        /// </summary>
        private float m_mB;
        /// <summary>
        /// The mc
        /// </summary>
        private float m_mC;
        /// <summary>
        /// The md
        /// </summary>
        private float m_mD;

        /// <summary>
        /// Initializes a new instance of the <see cref="GearJoint"/> class
        /// </summary>
        /// <param name="def">The def</param>
        public GearJoint(GearJointDef def)
            : base(def)
        {
            m_joint1 = def.Joint1;
            m_joint2 = def.Joint2;

            //Debug.Assert(_typeA == JointType.RevoluteJoint || _typeA == JointType.PrismaticJoint);
            //Debug.Assert(_typeB == JointType.RevoluteJoint || _typeB == JointType.PrismaticJoint);

            float coordinateA, coordinateB;

            // TODO_ERIN there might be some problem with the joint edges in b2Joint.

            m_bodyC = m_joint1.GetBodyA();
            m_bodyA = m_joint1.GetBodyB();

            // Get geometry of joint1
            Transform xfA = m_bodyA.m_xf;
            float aA = m_bodyA.m_sweep.a;
            Transform xfC = m_bodyC.m_xf;
            float aC = m_bodyC.m_sweep.a;

            if (m_joint1 is RevoluteJoint revolute1)
            {
                m_localAnchorC = revolute1.m_localAnchorA;
                m_localAnchorA = revolute1.m_localAnchorB;
                m_referenceAngleA = revolute1.m_referenceAngle;
                m_localAxisC = Vector2.Zero;

                coordinateA = aA - aC - m_referenceAngleA;
            }
            else
            {
                PrismaticJoint prismatic = (PrismaticJoint) def.Joint1;
                m_localAnchorC = prismatic.m_localAnchorA;
                m_localAnchorA = prismatic.m_localAnchorB;
                m_referenceAngleA = prismatic.m_referenceAngle;
                m_localAxisC = prismatic.m_localXAxisA;

                Vector2 pC = m_localAnchorC;
                Vector2 pA = Math.MulT(xfC.q, Vector2.Transform(m_localAnchorA, xfA.q) + (xfA.p - xfC.p));
                coordinateA = Vector2.Dot(pA - pC, m_localAxisC);
            }

            m_bodyD = m_joint2.GetBodyA();
            m_bodyB = m_joint2.GetBodyB();

            // Get geometry of joint2
            Transform xfB = m_bodyB.m_xf;
            float aB = m_bodyB.m_sweep.a;
            Transform xfD = m_bodyD.m_xf;
            float aD = m_bodyD.m_sweep.a;

            if (m_joint2 is RevoluteJoint revolute2)
            {
                m_localAnchorD = revolute2.m_localAnchorA;
                m_localAnchorB = revolute2.m_localAnchorB;
                m_referenceAngleB = revolute2.m_referenceAngle;
                m_localAxisD = Vector2.Zero;

                coordinateB = aB - aD - m_referenceAngleB;
            }
            else
            {
                PrismaticJoint prismatic = (PrismaticJoint) def.Joint2;
                m_localAnchorD = prismatic.m_localAnchorA;
                m_localAnchorB = prismatic.m_localAnchorB;
                m_referenceAngleB = prismatic.m_referenceAngle;
                m_localAxisD = prismatic.m_localXAxisA;

                Vector2 pD = m_localAnchorD;
                Vector2 pB = Math.MulT(xfD.q, Vector2.Transform(m_localAnchorB, xfB.q) + (xfB.p - xfD.p));
                coordinateB = Vector2.Dot(pB - pD, m_localAxisD);
            }

            Ratio = def.Ratio;

            m_constant = coordinateA + Ratio * coordinateB;

            m_impulse = 0.0f;
        }

        /// <summary>
        /// Gets the value of the get anchor a
        /// </summary>
        public override Vector2 GetAnchorA => m_bodyA.GetWorldPoint(m_localAnchorA);
        /// <summary>
        /// Gets the value of the get anchor b
        /// </summary>
        public override Vector2 GetAnchorB => m_bodyB.GetWorldPoint(m_localAnchorB);

        /// <summary>
        ///     Get the gear ratio.
        /// </summary>
        public float Ratio
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        /// <summary>
        /// Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override Vector2 GetReactionForce(float invDt) => m_impulse * m_jvAc;

        /// <summary>
        /// Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override float GetReactionTorque(float invDt) => invDt * m_impulse * m_jwA;

        /// <summary>
        /// Inits the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void InitVelocityConstraints(in SolverData data)
        {
            m_indexA = m_bodyA.m_islandIndex;
            m_indexB = m_bodyB.m_islandIndex;
            m_indexC = m_bodyC.m_islandIndex;
            m_indexD = m_bodyD.m_islandIndex;
            m_lcA = m_bodyA.m_sweep.localCenter;
            m_lcB = m_bodyB.m_sweep.localCenter;
            m_lcC = m_bodyC.m_sweep.localCenter;
            m_lcD = m_bodyD.m_sweep.localCenter;
            m_mA = m_bodyA.m_invMass;
            m_mB = m_bodyB.m_invMass;
            m_mC = m_bodyC.m_invMass;
            m_mD = m_bodyD.m_invMass;
            m_iA = m_bodyA.m_invI;
            m_iB = m_bodyB.m_invI;
            m_iC = m_bodyC.m_invI;
            m_iD = m_bodyD.m_invI;

            float aA = data.positions[m_indexA].a;
            Vector2 vA = data.velocities[m_indexA].v;
            float wA = data.velocities[m_indexA].w;

            float aB = data.positions[m_indexB].a;
            Vector2 vB = data.velocities[m_indexB].v;
            float wB = data.velocities[m_indexB].w;

            float aC = data.positions[m_indexC].a;
            Vector2 vC = data.velocities[m_indexC].v;
            float wC = data.velocities[m_indexC].w;

            float aD = data.positions[m_indexD].a;
            Vector2 vD = data.velocities[m_indexD].v;
            float wD = data.velocities[m_indexD].w;

            Rot qA = new Rot(aA), qB = new Rot(aB), qC = new Rot(aC), qD = new Rot(aD);

            m_mass = 0.0f;

            if (m_joint1 is RevoluteJoint)
            {
                m_jvAc = Vector2.Zero;
                m_jwA = 1.0f;
                m_jwC = 1.0f;
                m_mass += m_iA + m_iC;
            }
            else
            {
                Vector2 u = Math.Mul(qC, m_localAxisC);
                Vector2 rC = Math.Mul(qC, m_localAnchorC - m_lcC);
                Vector2 rA = Math.Mul(qA, m_localAnchorA - m_lcA);
                m_jvAc = u;
                m_jwC = Vectex.Cross(rC, u);
                m_jwA = Vectex.Cross(rA, u);
                m_mass += m_mC + m_mA + m_iC * m_jwC * m_jwC + m_iA * m_jwA * m_jwA;
            }

            if (m_joint2 is RevoluteJoint)
            {
                m_jvBd = Vector2.Zero;
                m_jwB = Ratio;
                m_jwD = Ratio;
                m_mass += Ratio * Ratio * (m_iB + m_iD);
            }
            else
            {
                Vector2 u = Math.Mul(qD, m_localAxisD);
                Vector2 rD = Math.Mul(qD, m_localAnchorD - m_lcD);
                Vector2 rB = Math.Mul(qB, m_localAnchorB - m_lcB);
                m_jvBd = Ratio * u;
                m_jwD = Ratio * Vectex.Cross(rD, u);
                m_jwB = Ratio * Vectex.Cross(rB, u);
                m_mass += Ratio * Ratio * (m_mD + m_mB) + m_iD * m_jwD * m_jwD + m_iB * m_jwB * m_jwB;
            }

            // Compute effective mass.
            m_mass = m_mass > 0.0f ? 1.0f / m_mass : 0.0f;

            if (data.step.warmStarting)
            {
                vA += m_mA * m_impulse * m_jvAc;
                wA += m_iA * m_impulse * m_jwA;
                vB += m_mB * m_impulse * m_jvBd;
                wB += m_iB * m_impulse * m_jwB;
                vC -= m_mC * m_impulse * m_jvAc;
                wC -= m_iC * m_impulse * m_jwC;
                vD -= m_mD * m_impulse * m_jvBd;
                wD -= m_iD * m_impulse * m_jwD;
            }
            else
            {
                m_impulse = 0.0f;
            }

            data.velocities[m_indexA].v = vA;
            data.velocities[m_indexA].w = wA;
            data.velocities[m_indexB].v = vB;
            data.velocities[m_indexB].w = wB;
            data.velocities[m_indexC].v = vC;
            data.velocities[m_indexC].w = wC;
            data.velocities[m_indexD].v = vD;
            data.velocities[m_indexD].w = wD;
        }

        /// <summary>
        /// Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void SolveVelocityConstraints(in SolverData data)
        {
            Vector2 vA = data.velocities[m_indexA].v;
            float wA = data.velocities[m_indexA].w;
            Vector2 vB = data.velocities[m_indexB].v;
            float wB = data.velocities[m_indexB].w;
            Vector2 vC = data.velocities[m_indexC].v;
            float wC = data.velocities[m_indexC].w;
            Vector2 vD = data.velocities[m_indexD].v;
            float wD = data.velocities[m_indexD].w;

            float Cdot = Vector2.Dot(m_jvAc, vA - vC) + Vector2.Dot(m_jvBd, vB - vD);
            Cdot += m_jwA * wA - m_jwC * wC + (m_jwB * wB - m_jwD * wD);

            float impulse = -m_mass * Cdot;
            m_impulse += impulse;

            vA += m_mA * impulse * m_jvAc;
            wA += m_iA * impulse * m_jwA;
            vB += m_mB * impulse * m_jvBd;
            wB += m_iB * impulse * m_jwB;
            vC -= m_mC * impulse * m_jvAc;
            wC -= m_iC * impulse * m_jwC;
            vD -= m_mD * impulse * m_jvBd;
            wD -= m_iD * impulse * m_jwD;

            data.velocities[m_indexA].v = vA;
            data.velocities[m_indexA].w = wA;
            data.velocities[m_indexB].v = vB;
            data.velocities[m_indexB].w = wB;
            data.velocities[m_indexC].v = vC;
            data.velocities[m_indexC].w = wC;
            data.velocities[m_indexD].v = vD;
            data.velocities[m_indexD].w = wD;
        }

        /// <summary>
        /// Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(in SolverData data)
        {
            Vector2 cA = data.positions[m_indexA].c;
            float aA = data.positions[m_indexA].a;
            Vector2 cB = data.positions[m_indexB].c;
            float aB = data.positions[m_indexB].a;
            Vector2 cC = data.positions[m_indexC].c;
            float aC = data.positions[m_indexC].a;
            Vector2 cD = data.positions[m_indexD].c;
            float aD = data.positions[m_indexD].a;

            Rot qA = new Rot(aA), qB = new Rot(aB), qC = new Rot(aC), qD = new Rot(aD);

            float linearError = 0.0f;

            float coordinateA, coordinateB;

            Vector2 JvAC, JvBD;
            float JwA, JwB, JwC, JwD;
            float mass = 0.0f;

            if (m_joint1 is RevoluteJoint)
            {
                JvAC = Vector2.Zero;
                JwA = 1.0f;
                JwC = 1.0f;
                mass += m_iA + m_iC;

                coordinateA = aA - aC - m_referenceAngleA;
            }
            else
            {
                Vector2 u = Math.Mul(qC, m_localAxisC);
                Vector2 rC = Math.Mul(qC, m_localAnchorC - m_lcC);
                Vector2 rA = Math.Mul(qA, m_localAnchorA - m_lcA);
                JvAC = u;
                JwC = Vectex.Cross(rC, u);
                JwA = Vectex.Cross(rA, u);
                mass += m_mC + m_mA + m_iC * JwC * JwC + m_iA * JwA * JwA;

                Vector2 pC = m_localAnchorC - m_lcC;
                Vector2 pA = Math.MulT(qC, rA + (cA - cC));
                coordinateA = Vector2.Dot(pA - pC, m_localAxisC);
            }

            if (m_joint2 is RevoluteJoint)
            {
                JvBD = Vector2.Zero;
                JwB = Ratio;
                JwD = Ratio;
                mass += Ratio * Ratio * (m_iB + m_iD);

                coordinateB = aB - aD - m_referenceAngleB;
            }
            else
            {
                Vector2 u = Math.Mul(qD, m_localAxisD);
                Vector2 rD = Math.Mul(qD, m_localAnchorD - m_lcD);
                Vector2 rB = Math.Mul(qB, m_localAnchorB - m_lcB);
                JvBD = Ratio * u;
                JwD = Ratio * Vectex.Cross(rD, u);
                JwB = Ratio * Vectex.Cross(rB, u);
                mass += Ratio * Ratio * (m_mD + m_mB) + m_iD * JwD * JwD + m_iB * JwB * JwB;

                Vector2 pD = m_localAnchorD - m_lcD;
                Vector2 pB = Math.MulT(qD, rB + (cB - cD));
                coordinateB = Vector2.Dot(pB - pD, m_localAxisD);
            }

            float C = coordinateA + Ratio * coordinateB - m_constant;

            float impulse = 0.0f;
            if (mass > 0.0f)
            {
                impulse = -C / mass;
            }

            cA += m_mA * impulse * JvAC;
            aA += m_iA * impulse * JwA;
            cB += m_mB * impulse * JvBD;
            aB += m_iB * impulse * JwB;
            cC -= m_mC * impulse * JvAC;
            aC -= m_iC * impulse * JwC;
            cD -= m_mD * impulse * JvBD;
            aD -= m_iD * impulse * JwD;

            data.positions[m_indexA].c = cA;
            data.positions[m_indexA].a = aA;
            data.positions[m_indexB].c = cB;
            data.positions[m_indexB].a = aB;
            data.positions[m_indexC].c = cC;
            data.positions[m_indexC].a = aC;
            data.positions[m_indexD].c = cD;
            data.positions[m_indexD].a = aD;

            // TODO_ERIN not implemented
            return linearError < Settings.LinearSlop;
        }
    }
}