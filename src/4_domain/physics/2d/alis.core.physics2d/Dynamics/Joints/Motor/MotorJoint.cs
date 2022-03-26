// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   MotorJoint.cs
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

using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Physics2D.World;

namespace Alis.Core.Physics2D.Joints.Motor
{
    /// <summary>
    ///     The motor joint class
    /// </summary>
    /// <seealso cref="Joint" />
    internal class MotorJoint : Joint
    {
        /// <summary>
        ///     The angularerror
        /// </summary>
        private float m_angularError;

        /// <summary>
        ///     The angularimpulse
        /// </summary>
        private float m_angularImpulse;

        /// <summary>
        ///     The angularmass
        /// </summary>
        private float m_angularMass;

        /// <summary>
        ///     The angularoffset
        /// </summary>
        private float m_angularOffset;

        /// <summary>
        ///     The correctionfactor
        /// </summary>
        private float m_correctionFactor;

        // Solver temp
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
        ///     The linearerror
        /// </summary>
        private Vector2 m_linearError;

        /// <summary>
        ///     The linearimpulse
        /// </summary>
        private Vector2 m_linearImpulse;

        /// <summary>
        ///     The linearmass
        /// </summary>
        private Matrix3x2 m_linearMass;

        // Solver shared
        /// <summary>
        ///     The linearoffset
        /// </summary>
        private Vector2 m_linearOffset;

        /// <summary>
        ///     The localcentera
        /// </summary>
        private Vector2 m_localCenterA;

        /// <summary>
        ///     The localcenterb
        /// </summary>
        private Vector2 m_localCenterB;

        /// <summary>
        ///     The maxforce
        /// </summary>
        private float m_maxForce;

        /// <summary>
        ///     The maxtorque
        /// </summary>
        private float m_maxTorque;

        /// <summary>
        ///     The ra
        /// </summary>
        private Vector2 m_rA;

        /// <summary>
        ///     The rb
        /// </summary>
        private Vector2 m_rB;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MotorJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        internal MotorJoint(in MotorJointDef def) : base(def)
        {
            m_linearOffset = def.linearOffset;
            m_angularOffset = def.angularOffset;

            m_maxForce = def.maxForce;
            m_maxTorque = def.maxTorque;
            m_correctionFactor = def.correctionFactor;
        }

        /// <summary>
        ///     Gets the value of the get anchor a
        /// </summary>
        public override Vector2 GetAnchorA => m_bodyA.GetPosition();

        /// <summary>
        ///     Gets the value of the get anchor b
        /// </summary>
        public override Vector2 GetAnchorB => m_bodyB.GetPosition();

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="inv_dt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2 GetReactionForce(float inv_dt) => inv_dt * m_linearImpulse;

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="inv_dt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float inv_dt) => inv_dt * m_angularImpulse;

        /// Set/get the target linear offset, in frame A, in meters.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetLinearOffset(in Vector2 linearOffset)
        {
            if (linearOffset.X != m_linearOffset.X || linearOffset.Y != m_linearOffset.Y)
            {
                m_bodyA.SetAwake(true);
                m_bodyB.SetAwake(true);
                m_linearOffset = linearOffset;
            }
        }

        /// <summary>
        ///     Gets the linear offset
        /// </summary>
        /// <returns>The vector</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public Vector2 GetLinearOffset() => m_linearOffset;

        /// Set/get the target angular offset, in radians.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetAngularOffset(float angularOffset)
        {
            if (angularOffset != m_angularOffset)
            {
                m_bodyA.SetAwake(true);
                m_bodyB.SetAwake(true);
                m_angularOffset = angularOffset;
            }
        }

        /// <summary>
        ///     Gets the angular offset
        /// </summary>
        /// <returns>The float</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetAngularOffset() => m_angularOffset;

        /// Set the maximum friction force in N.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetMaxForce(float force)
        {
            m_maxForce = force;
        }

        /// Get the maximum friction force in N.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetMaxForce() => m_maxForce;

        /// Set the maximum friction torque in N*m.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetMaxTorque(float torque)
        {
            m_maxTorque = torque;
        }

        /// Get the maximum friction torque in N*m.
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetMaxTorque() => m_maxTorque;

        /// Set the position correction factor in the range [0,1].
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetCorrectionFactor(float factor)
        {
            m_correctionFactor = factor;
        }

        /// Get the position correction factor in the range [0,1].
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public float GetCorrectionFactor() => m_correctionFactor;

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

            // Compute the effective mass matrix.
            m_rA = Math.Mul(qA, m_linearOffset - m_localCenterA);
            m_rB = Math.Mul(qB, -m_localCenterB);

            // J = [-I -r1_skew I r2_skew]
            // r_skew = [-ry; rx]

            // Matlab
            // K = [ mA+r1y^2*iA+mB+r2y^2*iB,  -r1y*iA*r1x-r2y*iB*r2x,          -r1y*iA-r2y*iB]
            //     [  -r1y*iA*r1x-r2y*iB*r2x, mA+r1x^2*iA+mB+r2x^2*iB,           r1x*iA+r2x*iB]
            //     [          -r1y*iA-r2y*iB,           r1x*iA+r2x*iB,                   iA+iB]

            float mA = m_invMassA, mB = m_invMassB;
            float iA = m_invIA, iB = m_invIB;

            // Upper 2 by 2 of K for point to point
            Matrix3x2 K = new Matrix3x2();
            K.M11 = mA + mB + iA * m_rA.Y * m_rA.Y + iB * m_rB.Y * m_rB.Y;
            K.M21 = -iA * m_rA.X * m_rA.Y - iB * m_rB.X * m_rB.Y;
            K.M12 = K.M21;
            K.M22 = mA + mB + iA * m_rA.X * m_rA.X + iB * m_rB.X * m_rB.X;

            /*Matrix3x2*/
            Matrex.Invert(K, out m_linearMass);

            m_angularMass = iA + iB;
            if (m_angularMass > 0.0f)
            {
                m_angularMass = 1.0f / m_angularMass;
            }

            m_linearError = cB + m_rB - cA - m_rA;
            m_angularError = aB - aA - m_angularOffset;

            if (data.step.warmStarting)
            {
                // Scale impulses to support a variable time step.
                m_linearImpulse *= data.step.dtRatio;
                m_angularImpulse *= data.step.dtRatio;

                Vector2 P = new Vector2(m_linearImpulse.X, m_linearImpulse.Y);
                vA -= mA * P;
                wA -= iA * (Vectex.Cross(m_rA, P) + m_angularImpulse);
                vB += mB * P;
                wB += iB * (Vectex.Cross(m_rB, P) + m_angularImpulse);
            }
            else
            {
                m_linearImpulse = Vector2.Zero;
                m_angularImpulse = 0.0f;
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
            ;
            Vector2 vA = data.velocities[m_indexA].v;
            float wA = data.velocities[m_indexA].w;
            Vector2 vB = data.velocities[m_indexB].v;
            float wB = data.velocities[m_indexB].w;

            float mA = m_invMassA, mB = m_invMassB;
            float iA = m_invIA, iB = m_invIB;

            float h = data.step.dt;
            float inv_h = data.step.inv_dt;

            // Solve angular friction
            {
                float Cdot = wB - wA + inv_h * m_correctionFactor * m_angularError;
                float impulse = -m_angularMass * Cdot;

                float oldImpulse = m_angularImpulse;
                float maxImpulse = h * m_maxTorque;
                m_angularImpulse = System.Math.Clamp(m_angularImpulse + impulse, -maxImpulse, maxImpulse);
                impulse = m_angularImpulse - oldImpulse;

                wA -= iA * impulse;
                wB += iB * impulse;
            }

            // Solve linear friction
            {
                Vector2 Cdot = vB + Vectex.Cross(wB, m_rB) - vA - Vectex.Cross(wA, m_rA) +
                               inv_h * m_correctionFactor * m_linearError;

                Vector2 impulse = -Vector2.Transform(Cdot, m_linearMass); // Math.Mul(m_linearMass, Cdot);
                Vector2 oldImpulse = m_linearImpulse;
                m_linearImpulse += impulse;

                float maxImpulse = h * m_maxForce;

                if (m_linearImpulse.LengthSquared() > maxImpulse * maxImpulse)
                {
                    m_linearImpulse = Vector2.Normalize(m_linearImpulse);
                    m_linearImpulse *= maxImpulse;
                }

                impulse = m_linearImpulse - oldImpulse;

                vA -= mA * impulse;
                wA -= iA * Vectex.Cross(m_rA, impulse);

                vB += mB * impulse;
                wB += iB * Vectex.Cross(m_rB, impulse);
            }

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
        internal override bool SolvePositionConstraints(in SolverData data) => true;
    }
}