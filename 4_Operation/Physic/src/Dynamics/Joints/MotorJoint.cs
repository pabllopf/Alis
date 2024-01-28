// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MotorJoint.cs
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
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics.Solver;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Dynamics.Joints
{
    // Point-to-point constraint
    // Cdot = v2 - v1
    //      = v2 + cross(w2, r2) - v1 - cross(w1, r1)
    // J = [-I -r1_skew I r2_skew ]
    // Identity used:
    // w k % (rx i + ry j) = w * (-ry i + rx j)
    //
    // r1 = offset - c1
    // r2 = -c2

    // Angle constraint
    // Cdot = w2 - w1
    // J = [0 0 -1 0 0 1]
    // K = invI1 + invI2

    /// <summary>
    ///     A motor joint is used to control the relative motion between two bodies. A typical usage is to control the
    ///     movement of a dynamic body with respect to the ground.
    /// </summary>
    public class MotorJoint : Joint
    {
        /// <summary>
        ///     The angular error
        /// </summary>
        private float angularError;

        /// <summary>
        ///     The angular impulse
        /// </summary>
        private float angularImpulse;

        /// <summary>
        ///     The angular mass
        /// </summary>
        private float angularMass;

        /// <summary>
        ///     The angular offset
        /// </summary>
        private float angularOffset;

        /// <summary>
        ///     The correction factor
        /// </summary>
        private float correctionFactor;

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
        ///     The linear error
        /// </summary>
        private Vector2 linearError;

        /// <summary>
        ///     The linear impulse
        /// </summary>
        private Vector2 linearImpulse;

        /// <summary>
        ///     The linear mass
        /// </summary>
        private Matrix2X2 linearMass;

        // Solver shared
        /// <summary>
        ///     The linear offset
        /// </summary>
        private Vector2 linearOffset;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 localCenterA;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 localCenterB;

        /// <summary>
        ///     The max force
        /// </summary>
        private float maxForce;

        /// <summary>
        ///     The max torque
        /// </summary>
        private float maxTorque;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2 rA;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2 rB;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MotorJoint" /> class
        /// </summary>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="jointType">The joint type</param>
        /// <param name="collideConnected">The collide connected</param>
        /// <param name="linearOffset">The linear offset</param>
        /// <param name="angularOffset">The angular offset</param>
        /// <param name="maxForce">The max force</param>
        /// <param name="maxTorque">The max torque</param>
        /// <param name="correctionFactor">The correction factor</param>
        public MotorJoint(
            Body bodyA = null,
            Body bodyB = null,
            JointType jointType = default(JointType),
            bool collideConnected = false,
            Vector2 linearOffset = default(Vector2),
            float angularOffset = 0.0f,
            float maxForce = 1.0f,
            float maxTorque = 1.0f,
            float correctionFactor = 0.3f
        )
            : base(bodyA, bodyB, jointType, collideConnected)
        {
            this.linearOffset = linearOffset;
            this.angularOffset = angularOffset;
            this.maxForce = maxForce;
            this.maxTorque = maxTorque;
            this.correctionFactor = correctionFactor;
        }

        /// <summary>Constructor for MotorJoint.</summary>
        /// <param name="bodyA">The first body</param>
        /// <param name="bodyB">The second body</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public MotorJoint(Body bodyA, Body bodyB, bool useWorldCoordinates = false)
            : base(bodyA, bodyB, JointType.Motor)
        {
            Vector2 xB = bodyB.Position;

            if (useWorldCoordinates)
            {
                linearOffset = bodyA.GetLocalPoint(xB);
            }
            else
            {
                linearOffset = xB;
            }

            maxForce = 1.0f;
            maxTorque = 1.0f;
            correctionFactor = 0.3f;

            angularOffset = bodyB.Rotation - bodyA.Rotation;
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor a
        /// </summary>
        public override Vector2 WorldAnchorA
        {
            get => BodyA.Position;
            set => throw new ArgumentException(value.ToString());
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public override Vector2 WorldAnchorB
        {
            get => BodyB.Position;
            set => throw new ArgumentException(value.ToString());
        }

        /// <summary>Get/set the maximum friction force in N.</summary>
        public float Force
        {
            set => maxForce = value;
            get => maxForce;
        }

        /// <summary>Get/set the maximum friction torque in N*m.</summary>
        public float Torque
        {
            set => maxTorque = value;
            get => maxTorque;
        }

        /// <summary>
        ///     Get/set the position correction factor in the range [0,1].
        /// </summary>
        public float CorrectionFactor
        {
            set => correctionFactor = value;
            get => correctionFactor;
        }

        /// <summary>The linear (translation) offset.</summary>
        public Vector2 LinearOffset
        {
            set
            {
                if (linearOffset != value)
                {
                    WakeBodies();
                    linearOffset = value;
                }
            }
            get => linearOffset;
        }

        /// <summary>Get or set the angular offset.</summary>
        public float AngularOffset
        {
            set
            {
                if (angularOffset != value)
                {
                    WakeBodies();
                    angularOffset = value;
                }
            }
            get => angularOffset;
        }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2 GetReactionForce(float invDt) => invDt * linearImpulse;

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt) => invDt * angularImpulse;

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

            Rotation qA = new Rotation(aA);
            Rotation qB = new Rotation(aB);

            // Compute the effective mass matrix.
            rA = MathUtils.Mul(qA, linearOffset - localCenterA);
            rB = MathUtils.Mul(qB, -localCenterB);

            // J = [-I -r1_skew I r2_skew]
            //     [ 0       -1 0       1]
            // r_skew = [-ry; rx]

            // Matlab
            // K = [ mA+r1y^2*iA+mB+r2y^2*iB,  -r1y*iA*r1x-r2y*iB*r2x,          -r1y*iA-r2y*iB]
            //     [  -r1y*iA*r1x-r2y*iB*r2x, mA+r1x^2*iA+mB+r2x^2*iB,           r1x*iA+r2x*iB]
            //     [          -r1y*iA-r2y*iB,           r1x*iA+r2x*iB,                   iA+iB]

            float mA = invMassA, mB = invMassB;
            float iA = invIa, iB = invIb;

            // Upper 2 by 2 of K for point to point
            Matrix2X2 k = new Matrix2X2(
                mA + mB + iA * rA.Y * rA.Y + iB * rB.Y * rB.Y,
                -iA * rA.X * rA.Y - iB * rB.X * rB.Y,
                -iA * rA.X * rA.Y - iB * rB.X * rB.Y,
                mA + mB + iA * rA.X * rA.X + iB * rB.X * rB.X
            );

            linearMass = k.Inverse;

            angularMass = iA + iB;
            if (angularMass > 0.0f)
            {
                angularMass = 1.0f / angularMass;
            }

            linearError = cB + rB - cA - rA;
            angularError = aB - aA - angularOffset;

            if (data.Step.WarmStarting)
            {
                // Scale impulses to support a variable time step.
                linearImpulse *= data.Step.DeltaTimeRatio;
                angularImpulse *= data.Step.DeltaTimeRatio;

                Vector2 p = new Vector2(linearImpulse.X, linearImpulse.Y);
                vA -= mA * p;
                wA -= iA * (MathUtils.Cross(rA, p) + angularImpulse);
                vB += mB * p;
                wB += iB * (MathUtils.Cross(rB, p) + angularImpulse);
            }
            else
            {
                linearImpulse = Vector2.Zero;
                angularImpulse = 0.0f;
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

            float mA = invMassA, mB = invMassB;
            float iA = invIa, iB = invIb;

            float h = data.Step.DeltaTime;
            float invH = data.Step.InvertedDeltaTime;

            // Solve angular friction
            {
                float cdot = wB - wA + invH * correctionFactor * angularError;
                float impulse = -angularMass * cdot;

                float oldImpulse = angularImpulse;
                float maxImpulse = h * maxTorque;
                angularImpulse = MathUtils.Clamp(angularImpulse + impulse, -maxImpulse, maxImpulse);
                impulse = angularImpulse - oldImpulse;

                wA -= iA * impulse;
                wB += iB * impulse;
            }

            // Solve linear friction
            {
                Vector2 cdot = vB + MathUtils.Cross(wB, rB) - vA - MathUtils.Cross(wA, rA) +
                               invH * correctionFactor * linearError;

                Vector2 impulse = -MathUtils.Mul(ref linearMass, ref cdot);
                Vector2 oldImpulse = linearImpulse;
                linearImpulse += impulse;

                float maxImpulse = h * maxForce;

                if (linearImpulse.LengthSquared() > maxImpulse * maxImpulse)
                {
                    linearImpulse = Vector2.Normalize(linearImpulse);
                    linearImpulse *= maxImpulse;
                }

                impulse = linearImpulse - oldImpulse;

                vA -= mA * impulse;
                wA -= iA * MathUtils.Cross(rA, impulse);

                vB += mB * impulse;
                wB += iB * MathUtils.Cross(rB, impulse);
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
        internal override bool SolvePositionConstraints(ref SolverData data) => true;
    }
}