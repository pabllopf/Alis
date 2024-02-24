// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrictionJoint.cs
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

using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Util;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics.Solver;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     Friction joint. This is used for top-down friction. It provides 2D translational friction and angular
    ///     friction.
    ///     Point-to-point constraint
    ///     cDot = v2 - v1
    ///     = v2 + cross(w2, r2) - v1 - cross(w1, r1)
    ///     J = [-I -r1_skew I r2_skew ]
    ///     Identity used:
    ///     w k % (rx i + ry j) = w * (-ry i + rx j)
    ///     Angle constraint
    ///     cDot = w2 - w1
    ///     J = [0 0 -1 0 0 1]
    ///     K = invI1 + invI2
    /// </summary>
    public class FrictionJoint : Joint
    {
        /// <summary>
        ///     The angular impulse
        /// </summary>
        private float angularImpulse;

        /// <summary>
        ///     The angular mass
        /// </summary>
        private float angularMass;

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

        // Solver shared
        /// <summary>
        ///     The linear impulse
        /// </summary>
        private Vector2 linearImpulse;

        /// <summary>
        ///     The linear mass
        /// </summary>
        private Matrix2X2 linearMass;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2 rA;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2 rB;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrictionJoint" /> class
        /// </summary>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="jointType">The joint type</param>
        /// <param name="collideConnected">The collide connected</param>
        /// <param name="localAnchorA">The local anchor</param>
        /// <param name="localAnchorB">The local anchor</param>
        /// <param name="maxForce">The max force</param>
        /// <param name="maxTorque">The max torque</param>
        public FrictionJoint(
            Body bodyA = null,
            Body bodyB = null,
            JointType jointType = default(JointType),
            bool collideConnected = false,
            Vector2 localAnchorA = default(Vector2),
            Vector2 localAnchorB = default(Vector2),
            float maxForce = 0.0f,
            float maxTorque = 0.0f
        )
            : base(bodyA, bodyB, jointType, collideConnected)
        {
            LocalAnchorA = localAnchorA;
            LocalAnchorB = localAnchorB;
            Force = maxForce;
            Torque = maxTorque;
        }

        /// <summary>Constructor for FrictionJoint.</summary>
        /// <param name="bodyA"></param>
        /// <param name="bodyB"></param>
        /// <param name="anchor"></param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public FrictionJoint(Body bodyA, Body bodyB, Vector2 anchor, bool useWorldCoordinates = false)
            : base(bodyA, bodyB, JointType.Friction)
        {
            if (useWorldCoordinates)
            {
                LocalAnchorA = BodyA.GetLocalPoint(anchor);
                LocalAnchorB = BodyB.GetLocalPoint(anchor);
            }
            else
            {
                LocalAnchorA = anchor;
                LocalAnchorB = anchor;
            }
        }

        /// <summary>The local anchor point on BodyA</summary>
        private Vector2 LocalAnchorA { get; set; }

        /// <summary>The local anchor point on BodyB</summary>
        private Vector2 LocalAnchorB { get; set; }

        /// <summary>
        ///     Gets or sets the value of the world anchor a
        /// </summary>
        public override Vector2 WorldAnchorA
        {
            get => BodyA.GetWorldPoint(LocalAnchorA);
            set => LocalAnchorA = BodyA.GetLocalPoint(value);
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public override Vector2 WorldAnchorB
        {
            get => BodyB.GetWorldPoint(LocalAnchorB);
            set => LocalAnchorB = BodyB.GetLocalPoint(value);
        }

        /// <summary>The maximum friction force in N.</summary>
        private float Force { get; }

        /// <summary>The maximum friction torque in N-m.</summary>
        private float Torque { get; }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        protected override Vector2 GetReactionForce(float invDt) => invDt * linearImpulse;

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
            Vector2 localCenterA = BodyA.Sweep.LocalCenter;
            Vector2 localCenterB = BodyB.Sweep.LocalCenter;
            invMassA = BodyA.InvMass;
            invMassB = BodyB.InvMass;
            invIa = BodyA.InvI;
            invIb = BodyB.InvI;

            float aA = data.Positions[indexA].A;
            Vector2 vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;

            float aB = data.Positions[indexB].A;
            Vector2 vB = data.Velocities[indexB].V;
            float wB = data.Velocities[indexB].W;

            Rotation qA = new Rotation(aA), qB = new Rotation(aB);

            // Compute the effective mass matrix.
            rA = MathUtils.Mul(qA, LocalAnchorA - localCenterA);
            rB = MathUtils.Mul(qB, LocalAnchorB - localCenterB);

            // J = [-I -r1_skew I r2_skew]
            //     [ 0       -1 0       1]
            // r_skew = [-ry; rx]

            // Matlab
            // K = [ mA+r1y^2*iA+mB+r2y^2*iB,  -r1y*iA*r1x-r2y*iB*r2x,          -r1y*iA-r2y*iB]
            //     [  -r1y*iA*r1x-r2y*iB*r2x, mA+r1x^2*iA+mB+r2x^2*iB,           r1x*iA+r2x*iB]
            //     [          -r1y*iA-r2y*iB,           r1x*iA+r2x*iB,                   iA+iB]

            float mA = invMassA, mB = invMassB;
            float iA = invIa, iB = invIb;

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
        ///     Solves the velocity constraints using the specified data.
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

            SolveAngularFriction(ref wA, ref wB, iA, iB, h);
            SolveLinearFriction(ref vA, ref wA, ref vB, ref wB, mA, mB, iA, iB, h);

            data.Velocities[indexA].V = vA;
            data.Velocities[indexA].W = wA;
            data.Velocities[indexB].V = vB;
            data.Velocities[indexB].W = wB;
        }

        /// <summary>
        ///     Solves the angular friction using the specified v a
        /// </summary>
        /// <param name="wA">The </param>
        /// <param name="wB">The </param>
        /// <param name="iA">The </param>
        /// <param name="iB">The </param>
        /// <param name="h">The </param>
        private void SolveAngularFriction(ref float wA, ref float wB, float iA, float iB, float h)
        {
            float cDot = wB - wA;
            float impulse = -angularMass * cDot;

            float oldImpulse = angularImpulse;
            float maxImpulse = h * Torque;
            angularImpulse = MathUtils.Clamp(angularImpulse + impulse, -maxImpulse, maxImpulse);
            impulse = angularImpulse - oldImpulse;

            wA -= iA * impulse;
            wB += iB * impulse;
        }

        /// <summary>
        ///     Solves the linear friction using the specified v a
        /// </summary>
        /// <param name="vA">The </param>
        /// <param name="wA">The </param>
        /// <param name="vB">The </param>
        /// <param name="wB">The </param>
        /// <param name="mA">The </param>
        /// <param name="mB">The </param>
        /// <param name="iA">The </param>
        /// <param name="iB">The </param>
        /// <param name="h">The </param>
        private void SolveLinearFriction(ref Vector2 vA, ref float wA, ref Vector2 vB, ref float wB, float mA, float mB, float iA, float iB, float h)
        {
            Vector2 cDot = vB + MathUtils.Cross(wB, rB) - vA - MathUtils.Cross(wA, rA);

            Vector2 impulse = -MathUtils.Mul(ref linearMass, cDot);
            Vector2 oldImpulse = linearImpulse;
            linearImpulse += impulse;

            float maxImpulse = h * Force;

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


        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(ref SolverData data) => true;
    }
}