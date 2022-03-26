// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   MouseJoint.cs
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

// p = attached point, m = mouse point
// C = p - m
// Cdot = v
//      = v + cross(w, r)
// J = [I r_skew]
// Identity used:
// w k % (rx i + ry j) = w * (-ry i + rx j)

using System.Numerics;
using Alis.Core.Physics2D.World;

namespace Alis.Core.Physics2D.Joints.Mouse
{
    /// <summary>
    ///     A mouse joint is used to make a point on a body track a
    ///     specified world point. This a soft constraint with a maximum
    ///     force. This allows the constraint to stretch and without
    ///     applying huge forces.
    /// </summary>
    public class MouseJoint : Joint
    {
        /// <summary>
        ///     The dampingratio
        /// </summary>
        private readonly float m_dampingRatio;

        /// <summary>
        ///     The frequencyhz
        /// </summary>
        private readonly float m_frequencyHz;

        /// <summary>
        ///     The localanchor
        /// </summary>
        private readonly Vector2 m_localAnchor;

        /// <summary>
        ///     The maxforce
        /// </summary>
        private readonly float m_maxForce;

        /// <summary>
        ///     The beta
        /// </summary>
        private float m_beta;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2 m_C;

        /// <summary>
        ///     The gamma
        /// </summary>
        private float m_gamma;

        /// <summary>
        ///     The impulse
        /// </summary>
        private Vector2 m_impulse;

        /// <summary>
        ///     The indexb
        /// </summary>
        private int m_indexB;

        /// <summary>
        ///     The invib
        /// </summary>
        private float m_invIB;

        /// <summary>
        ///     The invmassb
        /// </summary>
        private float m_invMassB;

        /// <summary>
        ///     The localcenterb
        /// </summary>
        private Vector2 m_localCenterB;

        /// <summary>
        ///     The mass
        /// </summary>
        private Matrix3x2 m_mass;

        /// <summary>
        ///     The rb
        /// </summary>
        private Vector2 m_rB;

        /// <summary>
        ///     The targeta
        /// </summary>
        private Vector2 m_targetA;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MouseJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public MouseJoint(MouseJointDef def)
            : base(def)
        {
            m_targetA = def.Target;
            m_localAnchor = Math.MulT(m_bodyB.GetTransform(), m_targetA);

            m_maxForce = def.MaxForce;
            m_impulse = Vector2.Zero;

            m_frequencyHz = def.FrequencyHz;
            m_dampingRatio = def.DampingRatio;

            m_beta = 0.0f;
            m_gamma = 0.0f;
        }

        /// <summary>
        ///     Gets the value of the get anchor a
        /// </summary>
        public override Vector2 GetAnchorA => m_targetA;

        /// <summary>
        ///     Gets the value of the get anchor b
        /// </summary>
        public override Vector2 GetAnchorB => m_bodyB.GetWorldPoint(m_localAnchor);

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="inv_dt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2 GetReactionForce(float inv_dt) => inv_dt * m_impulse;

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="inv_dt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float inv_dt) => inv_dt * 0.0f;

        /// <summary>
        ///     Use this to update the target point.
        /// </summary>
        public void SetTarget(Vector2 target)
        {
            if (!m_bodyB.IsAwake())
            {
                m_bodyB.SetAwake(true);
            }

            m_targetA = target;
        }

        /// <summary>
        ///     Inits the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void InitVelocityConstraints(in SolverData data)
        {
            m_indexB = m_bodyB.m_islandIndex;
            m_localCenterB = m_bodyB.m_sweep.localCenter;
            m_invMassB = m_bodyB.m_invMass;
            m_invIB = m_bodyB.m_invI;

            Vector2 cB = data.positions[m_indexB].c;
            float aB = data.positions[m_indexB].a;
            Vector2 vB = data.velocities[m_indexB].v;
            float wB = data.velocities[m_indexB].w;

            Rot qB = new Rot(aB);

            float mass = m_bodyB.GetMass();

            // Frequency
            float omega = Settings.Tau * m_frequencyHz;

            // Damping coefficient
            float d = 2.0f * mass * m_dampingRatio * omega;

            // Spring stiffness
            float k = mass * (omega * omega);

            // magic formulas
            // gamma has units of inverse mass.
            // beta has units of inverse time.
            float h = data.step.dt;
            m_gamma = h * (d + h * k);
            if (m_gamma != 0.0f)
            {
                m_gamma = 1.0f / m_gamma;
            }

            m_beta = h * k * m_gamma;

            // Compute the effective mass matrix.
            m_rB = Math.Mul(qB, -m_localCenterB);

            // K    = [(1/m1 + 1/m2) * eye(2) - skew(r1) * invI1 * skew(r1) - skew(r2) * invI2 * skew(r2)]
            //      = [1/m1+1/m2     0    ] + invI1 * [r1.y*r1.y -r1.x*r1.y] + invI2 * [r1.y*r1.y -r1.x*r1.y]
            //        [    0     1/m1+1/m2]           [-r1.x*r1.y r1.x*r1.x]           [-r1.x*r1.y r1.x*r1.x]
            Matrix3x2 K = new Matrix3x2();
            K.M11 = m_invMassB + m_invIB * m_rB.Y * m_rB.Y + m_gamma;
            K.M21 = -m_invIB * m_rB.X * m_rB.Y;
            K.M12 = K.M21;
            K.M22 = m_invMassB + m_invIB * m_rB.X * m_rB.Y + m_gamma;

            /*Matrix3x2*/
            Matrex.Invert(K, out m_mass);

            //_mass = K.GetInverse();

            m_C = cB + m_rB - m_targetA;
            m_C *= m_beta;

            // Cheat with some damping
            wB *= 0.98f;

            if (data.step.warmStarting)
            {
                m_impulse *= data.step.dtRatio;
                vB += m_invMassB * m_impulse;
                wB += m_invIB * Vectex.Cross(m_rB, m_impulse);
            }
            else
            {
                m_impulse = Vector2.Zero;
            }

            data.velocities[m_indexB].v = vB;
            data.velocities[m_indexB].w = wB;
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void SolveVelocityConstraints(in SolverData data)
        {
            Vector2 vB = data.velocities[m_indexB].v;
            float wB = data.velocities[m_indexB].w;

            // Cdot = v + cross(w, r)
            Vector2 Cdot = vB + Vectex.Cross(wB, m_rB);
            Vector2 impulse =
                Vector2.Transform(-(Cdot + m_C + m_gamma * m_impulse),
                    m_mass); //Math.Mul(_mass, -(Cdot + _C + _gamma * _impulse));

            Vector2 oldImpulse = m_impulse;
            m_impulse += impulse;
            float maxImpulse = data.step.dt * m_maxForce;
            if (m_impulse.LengthSquared() > maxImpulse * maxImpulse)
            {
                m_impulse *= maxImpulse / m_impulse.Length();
            }

            impulse = m_impulse - oldImpulse;

            vB += m_invMassB * impulse;
            wB += m_invIB * Vectex.Cross(m_rB, impulse);

            data.velocities[m_indexB].v = vB;
            data.velocities[m_indexB].w = wB;
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(in SolverData data) => true;
    }
}