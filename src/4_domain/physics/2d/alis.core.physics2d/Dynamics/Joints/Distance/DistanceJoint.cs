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

using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Physics2D.Common;
using Alis.Core.Physics2D.Dynamics.World;

namespace Alis.Core.Physics2D.Dynamics.Joints.Distance
{
    /// <summary>
    ///     A distance joint constrains two points on two bodies
    ///     to remain at a fixed distance from each other. You can view
    ///     this as a massless, rigid rod.
    /// </summary>
    public class DistanceJoint : Joint
    {
        /// <summary>
        /// The length
        /// </summary>
        private readonly float m_length;
        /// <summary>
        /// The localanchora
        /// </summary>
        private readonly Vector2 m_localAnchorA;
        /// <summary>
        /// The localanchorb
        /// </summary>
        private readonly Vector2 m_localAnchorB;
        /// <summary>
        /// The bias
        /// </summary>
        private float m_bias;
        /// <summary>
        /// The gamma
        /// </summary>
        private float m_gamma;
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
        /// The invia
        /// </summary>
        private float m_invIA;
        /// <summary>
        /// The invib
        /// </summary>
        private float m_invIB;
        /// <summary>
        /// The invmassa
        /// </summary>
        private float m_invMassA;
        /// <summary>
        /// The invmassb
        /// </summary>
        private float m_invMassB;
        /// <summary>
        /// The localcentera
        /// </summary>
        private Vector2 m_localCenterA;
        /// <summary>
        /// The localcenterb
        /// </summary>
        private Vector2 m_localCenterB;
        /// <summary>
        /// The mass
        /// </summary>
        private float m_mass; // effective mass for the constraint.
        /// <summary>
        /// The ra
        /// </summary>
        private Vector2 m_rA;
        /// <summary>
        /// The rb
        /// </summary>
        private Vector2 m_rB;
        /// <summary>
        /// The 
        /// </summary>
        private Vector2 m_u;

        /// <summary>
        /// Initializes a new instance of the <see cref="DistanceJoint"/> class
        /// </summary>
        /// <param name="def">The def</param>
        public DistanceJoint(DistanceJointDef def)
            : base(def)
        {
            m_localAnchorA = def.localAnchorA;
            m_localAnchorB = def.localAnchorB;
            m_length = def.length;

            if (def.frequencyHz.HasValue && def.dampingRatio.HasValue)
            {
                LinearStiffness(out def.stiffness, out def.damping, def.frequencyHz.Value, def.dampingRatio.Value,
                    def.bodyA,
                    def.bodyB);
            }

            Stiffness = def.stiffness;
            Damping = def.damping;
            m_impulse = 0.0f;
            m_gamma = 0.0f;
            m_bias = 0.0f;
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
        ///     Set/get the linear stiffness in N/m
        /// </summary>
        public float Stiffness
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        /// <summary>
        ///     Set/get linear damping in N*s/m
        /// </summary>
        public float Damping
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set;
        }

        /// <summary>
        /// Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="inv_dt">The inv dt</param>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override Vector2 GetReactionForce(float inv_dt) => inv_dt * m_impulse * m_u;

        /// <summary>
        /// Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="inv_dt">The inv dt</param>
        /// <returns>The float</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override float GetReactionTorque(float inv_dt) => 0.0f;

        /// <summary>
        /// Inits the velocity constraints using the specified data
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
            m_u = cB + m_rB - cA - m_rA;

            // Handle singularity.
            float length = m_u.Length();
            if (length > Settings.LinearSlop)
            {
                m_u *= 1.0f / length;
            }
            else
            {
                m_u = Vector2.Zero;
            }

            float crAu = Vectex.Cross(m_rA, m_u);
            float crBu = Vectex.Cross(m_rB, m_u);
            float invMass = m_invMassA + m_invIA * crAu * crAu + m_invMassB + m_invIB * crBu * crBu;

            // Compute the effective mass matrix.
            if (Stiffness > 0.0f)
            {
                float C = length - m_length;

                float d = Damping;

                float k = Stiffness;

                // magic formulas
                float h = data.step.dt;

                // gamma = 1 / (h * (d + h * k)), the extra factor of h in the denominator is since the lambda is an impulse, not a force
                m_gamma = h * (d + h * k);
                m_gamma = m_gamma != 0.0f ? 1.0f / m_gamma : 0.0f;
                m_bias = C * h * k * m_gamma;

                invMass += m_gamma;
                m_mass = invMass != 0.0f ? 1.0f / invMass : 0.0f;
            }
            else
            {
                m_gamma = 0.0f;
                m_bias = 0.0f;
                m_mass = invMass != 0.0f ? 1.0f / invMass : 0.0f;
            }

            if (data.step.warmStarting)
            {
                // Scale the impulse to support a variable time step.
                m_impulse *= data.step.dtRatio;

                Vector2 P = m_impulse * m_u;
                vA -= m_invMassA * P;
                wA -= m_invIA * Vectex.Cross(m_rA, P);
                vB += m_invMassB * P;
                wB += m_invIB * Vectex.Cross(m_rB, P);
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
        /// Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void SolveVelocityConstraints(in SolverData data)
        {
            Vector2 vA = data.velocities[m_indexA].v;
            float wA = data.velocities[m_indexA].w;
            Vector2 vB = data.velocities[m_indexB].v;
            float wB = data.velocities[m_indexB].w;

            // Cdot = dot(u, v + cross(w, r))
            Vector2 vpA = vA + Vectex.Cross(wA, m_rA);
            Vector2 vpB = vB + Vectex.Cross(wB, m_rB);
            float Cdot = Vector2.Dot(m_u, vpB - vpA);

            float impulse = -m_mass * (Cdot + m_bias + m_gamma * m_impulse);
            m_impulse += impulse;

            Vector2 P = impulse * m_u;
            vA -= m_invMassA * P;
            wA -= m_invIA * Vectex.Cross(m_rA, P);
            vB += m_invMassB * P;
            wB += m_invIB * Vectex.Cross(m_rB, P);

            data.velocities[m_indexA].v = vA;
            data.velocities[m_indexA].w = wA;
            data.velocities[m_indexB].v = vB;
            data.velocities[m_indexB].w = wB;
        }

        /// <summary>
        /// Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(in SolverData data)
        {
            if (Stiffness > 0.0f)
                //There is no position correction for soft distance constraints.
            {
                return true;
            }

            Vector2 cA = data.positions[m_indexA].c;
            float aA = data.positions[m_indexA].a;
            Vector2 cB = data.positions[m_indexB].c;
            float aB = data.positions[m_indexB].a;

            Rot qA = new Rot(aA), qB = new Rot(aB);

            Vector2 rA = Math.Mul(qA, m_localAnchorA - m_localCenterA);
            Vector2 rB = Math.Mul(qB, m_localAnchorB - m_localCenterB);
            Vector2 u = cB + rB - cA - rA;

            float length = u.Length();
            u = Vector2.Normalize(u);
            float C = length - m_length;
            C = System.Math.Clamp(C, -Settings.MaxLinearCorrection, Settings.MaxLinearCorrection);

            float impulse = -m_mass * C;
            Vector2 P = impulse * u;

            cA -= m_invMassA * P;
            aA -= m_invIA * Vectex.Cross(rA, P);
            cB += m_invMassB * P;
            aB += m_invIB * Vectex.Cross(rB, P);

            data.positions[m_indexA].c = cA;
            data.positions[m_indexA].a = aA;
            data.positions[m_indexB].c = cB;
            data.positions[m_indexB].a = aB;

            return System.Math.Abs(C) < Settings.LinearSlop;
        }
    }
}