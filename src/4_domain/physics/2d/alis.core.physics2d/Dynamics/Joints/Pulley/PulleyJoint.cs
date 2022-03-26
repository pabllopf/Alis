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

// Pulley:
// length1 = norm(p1 - s1)
// length2 = norm(p2 - s2)
// C0 = (length1 + ratio * length2)_initial
// C = C0 - (length1 + ratio * length2) >= 0
// u1 = (p1 - s1) / norm(p1 - s1)
// u2 = (p2 - s2) / norm(p2 - s2)
// Cdot = -dot(u1, v1 + cross(w1, r1)) - ratio * dot(u2, v2 + cross(w2, r2))
// J = -[u1 cross(r1, u1) ratio * u2  ratio * cross(r2, u2)]
// K = J * invM * JT
//   = invMass1 + invI1 * cross(r1, u1)^2 + ratio^2 * (invMass2 + invI2 * cross(r2, u2)^2)
//
// Limit:
// C = maxLength - length
// u = (p - s) / norm(p - s)
// Cdot = -dot(u, v + cross(w, r))
// K = invMass + invI * cross(r, u)^2
// 0 <= impulse

using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Physics2D.World;

namespace Alis.Core.Physics2D.Joints.Pulley
{
    /// <summary>
    ///     The pulley joint is connected to two bodies and two fixed ground points.
    ///     The pulley supports a ratio such that:
    ///     length1 + ratio * length2 <= constant
    ///     Yes, the force transmitted is scaled by the ratio.
    ///     The pulley also enforces a maximum length limit on both sides. This is
    ///     useful to prevent one side of the pulley hitting the top.
    /// </summary>
    public class PulleyJoint : Joint
    {
        /// <summary>
        ///     The constant
        /// </summary>
        private readonly float m_constant;

        /// <summary>
        ///     The localanchora
        /// </summary>
        private readonly Vector2 m_localAnchorA;

        /// <summary>
        ///     The localanchorb
        /// </summary>
        private readonly Vector2 m_localAnchorB;

        /// <summary>
        ///     The impulse
        /// </summary>
        private float m_impulse;

        /// <summary>
        ///     The indexa
        /// </summary>
        private int m_indexA;

        /// <summary>
        ///     The indexb
        /// </summary>
        private int m_indexB;

        /// <summary>
        ///     The invia
        /// </summary>
        private float m_invIA;

        /// <summary>
        ///     The invib
        /// </summary>
        private float m_invIB;

        /// <summary>
        ///     The invmassa
        /// </summary>
        private float m_invMassA;

        /// <summary>
        ///     The invmassb
        /// </summary>
        private float m_invMassB;

        /// <summary>
        ///     The localcentera
        /// </summary>
        private Vector2 m_localCenterA;

        /// <summary>
        ///     The localcenterb
        /// </summary>
        private Vector2 m_localCenterB;

        /// <summary>
        ///     The mass
        /// </summary>
        private float m_mass;

        /// <summary>
        ///     The ra
        /// </summary>
        private Vector2 m_rA;

        /// <summary>
        ///     The rb
        /// </summary>
        private Vector2 m_rB;

        /// <summary>
        ///     The ua
        /// </summary>
        private Vector2 m_uA;

        /// <summary>
        ///     The ub
        /// </summary>
        private Vector2 m_uB;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PulleyJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public PulleyJoint(PulleyJointDef def)
            : base(def)
        {
            GroundAnchorA = def.GroundAnchorA;
            GroundAnchorB = def.GroundAnchorB;
            m_localAnchorA = def.LocalAnchorA;
            m_localAnchorB = def.LocalAnchorB;

            LengthA = def.LengthA;
            LengthB = def.LengthB;

            //Debug.Assert(def.Ratio != 0.0f);
            Ratio = def.Ratio;

            m_constant = def.LengthA + Ratio * def.LengthB;

            m_impulse = 0.0f;
        }

        /// <summary>
        ///     Gets the value of the get anchor a
        /// </summary>
        public override Vector2 GetAnchorA => m_bodyA.GetWorldPoint(m_localAnchorA);

        /// <summary>
        ///     Gets the value of the get anchor b
        /// </summary>
        public override Vector2 GetAnchorB => m_bodyB.GetWorldPoint(m_localAnchorB);

        /// <summary>
        ///     Get the first ground anchor.
        /// </summary>
        public Vector2 GroundAnchorA
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        /// <summary>
        ///     Get the second ground anchor.
        /// </summary>
        public Vector2 GroundAnchorB
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        /// <summary>
        ///     Get the current length of the segment attached to body1.
        /// </summary>
        public float LengthA
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        /// <summary>
        ///     Get the current length of the segment attached to body2.
        /// </summary>
        public float LengthB
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        /// <summary>
        ///     Get the pulley ratio.
        /// </summary>
        public float Ratio
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
        }

        /// <summary>
        ///     The min pulley length
        /// </summary>
        public static readonly float MinPulleyLength = 2.0f;

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2 GetReactionForce(float invDt) => invDt * m_impulse * m_uB;

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="inv_dt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float inv_dt) => 0.0f;

        /// <summary>
        ///     Inits the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void InitVelocityConstraints(in SolverData data)
        {
            m_indexA = m_bodyA.m_islandIndex;
            m_indexB = m_bodyB.m_islandIndex;
            m_localCenterA = m_bodyA.m_sweep.localCenter;
            m_localCenterB = m_bodyB.m_sweep.localCenter;
            m_invMassA = m_bodyA.m_invMass;
            m_invMassB = m_bodyB.m_invMass;
            m_invIA = m_bodyA.m_invI;
            m_invIB = m_bodyB.m_invI;

            Vector2 cA = data.positions[m_indexA].c;
            float aA = data.positions[m_indexA].a;
            Vector2 vA = data.velocities[m_indexA].v;
            float wA = data.velocities[m_indexA].w;

            Vector2 cB = data.positions[m_indexB].c;
            float aB = data.positions[m_indexB].a;
            Vector2 vB = data.velocities[m_indexB].v;
            float wB = data.velocities[m_indexB].w;

            Rot qA = new Rot(aA), qB = new Rot(aB);

            m_rA = Math.Mul(qA, m_localAnchorA - m_localCenterA);
            m_rB = Math.Mul(qB, m_localAnchorB - m_localCenterB);

            // Get the pulley axes.
            m_uA = cA + m_rA - GroundAnchorA;
            m_uB = cB + m_rB - GroundAnchorB;

            float lengthA = m_uA.Length();
            float lengthB = m_uB.Length();

            if (lengthA > 10.0f * Settings.LinearSlop)
            {
                m_uA *= 1.0f / lengthA;
            }
            else
            {
                m_uA = Vector2.Zero;
            }

            if (lengthB > 10.0f * Settings.LinearSlop)
            {
                m_uB *= 1.0f / lengthB;
            }
            else
            {
                m_uB = Vector2.Zero;
            }

            // Compute effective mass.
            float ruA = Vectex.Cross(m_rA, m_uA);
            float ruB = Vectex.Cross(m_rB, m_uB);

            float mA = m_invMassA + m_invIA * ruA * ruA;
            float mB = m_invMassB + m_invIB * ruB * ruB;

            m_mass = mA + Ratio * Ratio * mB;

            if (m_mass > 0.0f)
            {
                m_mass = 1.0f / m_mass;
            }

            if (data.step.warmStarting)
            {
                // Scale impulses to support variable time steps.
                m_impulse *= data.step.dtRatio;

                // Warm starting.
                Vector2 PA = -m_impulse * m_uA;
                Vector2 PB = -Ratio * m_impulse * m_uB;

                vA += m_invMassA * PA;
                wA += m_invIA * Vectex.Cross(m_rA, PA);
                vB += m_invMassB * PB;
                wB += m_invIB * Vectex.Cross(m_rB, PB);
            }
            else
            {
                m_impulse = 0.0f;
            }

            data.velocities[m_indexA].v = vA;
            data.velocities[m_indexA].w = wA;
            data.velocities[m_indexB].v = vB;
            data.velocities[m_indexB].w = wB;
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void SolveVelocityConstraints(in SolverData data)
        {
            Vector2 vA = data.velocities[m_indexA].v;
            float wA = data.velocities[m_indexA].w;
            Vector2 vB = data.velocities[m_indexB].v;
            float wB = data.velocities[m_indexB].w;

            Vector2 vpA = vA + Vectex.Cross(wA, m_rA);
            Vector2 vpB = vB + Vectex.Cross(wB, m_rB);

            float Cdot = -Vector2.Dot(m_uA, vpA) - Ratio * Vector2.Dot(m_uB, vpB);
            float impulse = -m_mass * Cdot;
            m_impulse += impulse;

            Vector2 PA = -impulse * m_uA;
            Vector2 PB = -Ratio * impulse * m_uB;
            vA += m_invMassA * PA;
            wA += m_invIA * Vectex.Cross(m_rA, PA);
            vB += m_invMassB * PB;
            wB += m_invIB * Vectex.Cross(m_rB, PB);

            data.velocities[m_indexA].v = vA;
            data.velocities[m_indexA].w = wA;
            data.velocities[m_indexB].v = vB;
            data.velocities[m_indexB].w = wB;
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(in SolverData data)
        {
            Vector2 cA = data.positions[m_indexA].c;
            float aA = data.positions[m_indexA].a;
            Vector2 cB = data.positions[m_indexB].c;
            float aB = data.positions[m_indexB].a;

            Rot qA = new Rot(aA), qB = new Rot(aB);

            Vector2 rA = Math.Mul(qA, m_localAnchorA - m_localCenterA);
            Vector2 rB = Math.Mul(qB, m_localAnchorB - m_localCenterB);

            // Get the pulley axes.
            Vector2 uA = cA + rA - GroundAnchorA;
            Vector2 uB = cB + rB - GroundAnchorB;

            float lengthA = uA.Length();
            float lengthB = uB.Length();

            if (lengthA > 10.0f * Settings.LinearSlop)
            {
                uA *= 1.0f / lengthA;
            }
            else
            {
                uA = Vector2.Zero;
            }

            if (lengthB > 10.0f * Settings.LinearSlop)
            {
                uB *= 1.0f / lengthB;
            }
            else
            {
                uB = Vector2.Zero;
            }

            // Compute effective mass.
            float ruA = Vectex.Cross(rA, uA);
            float ruB = Vectex.Cross(rB, uB);

            float mA = m_invMassA + m_invIA * ruA * ruA;
            float mB = m_invMassB + m_invIB * ruB * ruB;

            float mass = mA + Ratio * Ratio * mB;

            if (mass > 0.0f)
            {
                mass = 1.0f / mass;
            }

            float C = m_constant - lengthA - Ratio * lengthB;
            float linearError = MathF.Abs(C);

            float impulse = -mass * C;

            Vector2 PA = -impulse * uA;
            Vector2 PB = -Ratio * impulse * uB;

            cA += m_invMassA * PA;
            aA += m_invIA * Vectex.Cross(rA, PA);
            cB += m_invMassB * PB;
            aB += m_invIB * Vectex.Cross(rB, PB);

            data.positions[m_indexA].c = cA;
            data.positions[m_indexA].a = aA;
            data.positions[m_indexB].c = cB;
            data.positions[m_indexB].a = aB;

            return linearError < Settings.LinearSlop;
        }
    }
}