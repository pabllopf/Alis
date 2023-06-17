// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WeldJoint.cs
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
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics.Solver;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Dynamics.Joints
{
    // Point-to-point constraint
    // C = p2 - p1
    // Cdot = v2 - v1
    //      = v2 + cross(w2, r2) - v1 - cross(w1, r1)
    // J = [-I -r1_skew I r2_skew ]
    // Identity used:
    // w k % (rx i + ry j) = w * (-ry i + rx j)

    // Angle constraint
    // C = angle2 - angle1 - referenceAngle
    // Cdot = w2 - w1
    // J = [0 0 -1 0 0 1]
    // K = invI1 + invI2

    /// <summary>
    ///     A weld joint essentially glues two bodies together. A weld joint may distort somewhat because the island
    ///     constraint solver is approximate. The joint is soft constraint based, which means the two bodies will move relative
    ///     to
    ///     each other, when a force is applied. To combine two bodies in a rigid fashion, combine the fixtures to a single
    ///     body
    ///     instead.
    /// </summary>
    public class WeldJoint : Joint
    {
        /// <summary>
        ///     The reference angle
        /// </summary>
        private readonly float referenceAngle;

        /// <summary>
        ///     The bias
        /// </summary>
        private float bias;

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
        private Vector3F impulse;

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
        private Matrix3X3F mass;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F rA;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F rB;

        /// <summary>
        ///     The stiffness
        /// </summary>
        private float stiffness;


        /// <summary>
        ///     Initializes a new instance of the <see cref="WeldJoint" /> class
        /// </summary>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="jointType">The joint type</param>
        /// <param name="collideConnected">The collide connected</param>
        /// <param name="localAnchorA">The local anchor</param>
        /// <param name="localAnchorB">The local anchor</param>
        /// <param name="referenceAngle">The reference angle</param>
        /// <param name="stiffness">The stiffness</param>
        /// <param name="damping">The damping</param>
        public WeldJoint(
            Body bodyA = null,
            Body bodyB = null,
            JointType jointType = default(JointType),
            bool collideConnected = false,
            Vector2F localAnchorA = default(Vector2F),
            Vector2F localAnchorB = default(Vector2F),
            float referenceAngle = 0.0f,
            float stiffness = 0.0f,
            float damping = 0.0f
        )
            : base(bodyA, bodyB, jointType, collideConnected)
        {
            this.localAnchorA = localAnchorA;
            this.localAnchorB = localAnchorB;
            this.referenceAngle = referenceAngle;
            this.stiffness = stiffness;
            this.damping = damping;
            impulse = Vector3F.Zero;
        }

        /// <summary>
        ///     You need to specify an anchor point where they are attached. The position of the anchor point is important for
        ///     computing the reaction torque.
        /// </summary>
        /// <param name="bodyA">The first body</param>
        /// <param name="bodyB">The second body</param>
        /// <param name="anchorA">The first body anchor.</param>
        /// <param name="anchorB">The second body anchor.</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public WeldJoint(Body bodyA, Body bodyB, Vector2F anchorA, Vector2F anchorB, bool useWorldCoordinates = false)
            : base(bodyA, bodyB, JointType.Weld)
        {
            if (useWorldCoordinates)
            {
                localAnchorA = bodyA.GetLocalPoint(anchorA);
                localAnchorB = bodyB.GetLocalPoint(anchorB);
            }
            else
            {
                localAnchorA = anchorA;
                localAnchorB = anchorB;
            }

            referenceAngle = bodyB.Sweep.A - bodyA.Sweep.A;
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

        /// <summary>
        ///     Gets or sets the value of the world anchor a
        /// </summary>
        public override Vector2F WorldAnchorA
        {
            get => BodyA.GetWorldPoint(localAnchorA);
            set => localAnchorA = BodyA.GetLocalPoint(value);
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public override Vector2F WorldAnchorB
        {
            get => BodyB.GetWorldPoint(localAnchorB);
            set => localAnchorB = BodyB.GetLocalPoint(value);
        }

        /// <summary>The bodyB angle minus bodyA angle in the reference state (radians).</summary>
        public float ReferenceAngle => referenceAngle;

        /// <summary>
        ///     The frequency of the joint. A higher frequency means a stiffer joint, but a too high value can cause the joint
        ///     to oscillate. Default is 0, which means the joint does no spring calculations.
        /// </summary>
        public float Stiffness
        {
            get => stiffness;
            set => stiffness = value;
        }

        /// <summary>
        ///     The damping on the joint. The damping is only used when the joint has a frequency (> 0). A higher value means
        ///     more damping.
        /// </summary>
        public float Damping
        {
            get => damping;
            set => damping = value;
        }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2F GetReactionForce(float invDt)
        {
            Vector2F p = new Vector2F(impulse.X, impulse.Y);
            return invDt * p;
        }

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt) => invDt * impulse.Z;

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

            float aA = data.Positions[indexA].A;
            Vector2F vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;

            float aB = data.Positions[indexB].A;
            Vector2F vB = data.Velocities[indexB].V;
            float wB = data.Velocities[indexB].W;

            Rotation qA = new Rotation(aA), qB = new Rotation(aB);

            rA = MathUtils.Mul(qA, localAnchorA - localCenterA);
            rB = MathUtils.Mul(qB, localAnchorB - localCenterB);

            // J = [-I -r1_skew I r2_skew]
            //     [ 0       -1 0       1]
            // r_skew = [-ry; rx]

            // Matlab
            // K = [ mA+r1y^2*iA+mB+r2y^2*iB,  -r1y*iA*r1x-r2y*iB*r2x,          -r1y*iA-r2y*iB]
            //     [  -r1y*iA*r1x-r2y*iB*r2x, mA+r1x^2*iA+mB+r2x^2*iB,           r1x*iA+r2x*iB]
            //     [          -r1y*iA-r2y*iB,           r1x*iA+r2x*iB,                   iA+iB]

            float mA = invMassA, mB = invMassB;
            float iA = invIa, iB = invIb;

            Matrix3X3F kk = new Matrix3X3F(
                mA + mB + rA.Y * rA.Y * iA + rB.Y * rB.Y * iB,
                -rA.Y * rA.X * iA - rB.Y * rB.X * iB,
                -rA.Y * iA - rB.Y * iB,
                -rA.Y * rA.X * iA - rB.Y * rB.X * iB,
                mA + mB + rA.X * rA.X * iA + rB.X * rB.X * iB,
                rA.X * iA + rB.X * iB,
                -rA.Y * iA - rB.Y * iB,
                rA.X * iA + rB.X * iB,
                iA + iB
            );

            if (stiffness > 0.0f)
            {
                kk.GetInverse22(ref mass);

                float invM = iA + iB;

                float c = aB - aA - referenceAngle;

                // Damping coefficient
                float d = damping;

                // Spring stiffness
                float k = stiffness;

                // magic formulas
                float h = data.Step.DeltaTime;
                gamma = h * (d + h * k);
                gamma = gamma != 0.0f ? 1.0f / gamma : 0.0f;
                bias = c * h * k * gamma;

                invM += gamma;
                mass.Ez = new Vector3F(
                    mass.Ez.X,
                    mass.Ez.Y,
                    invM != 0.0f ? 1.0f / invM : 0.0f
                );
            }
            else if (kk.Ez.Z == 0.0f)
            {
                kk.GetInverse22(ref mass);
                gamma = 0.0f;
                bias = 0.0f;
            }
            else
            {
                kk.GetSymInverse33(ref mass);
                gamma = 0.0f;
                bias = 0.0f;
            }

            if (data.Step.WarmStarting)
            {
                // Scale impulses to support a variable time step.
                impulse *= data.Step.DeltaTimeRatio;

                Vector2F p = new Vector2F(impulse.X, impulse.Y);

                vA -= mA * p;
                wA -= iA * (MathUtils.Cross(rA, p) + impulse.Z);

                vB += mB * p;
                wB += iB * (MathUtils.Cross(rB, p) + impulse.Z);
            }
            else
            {
                impulse = Vector3F.Zero;
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

            float mA = invMassA, mB = invMassB;
            float iA = invIa, iB = invIb;

            if (stiffness > 0.0f)
            {
                float cdot2 = wB - wA;

                float impulse2 = -mass.Ez.Z * (cdot2 + bias + gamma * impulse.Z);
                impulse = new Vector3F(
                    impulse.X,
                    impulse.Y,
                    impulse2
                );

                wA -= iA * impulse2;
                wB += iB * impulse2;

                Vector2F cdot1 = vB + MathUtils.Cross(wB, rB) - vA - MathUtils.Cross(wA, rA);

                Vector2F impulse1 = -MathUtils.Mul22(mass, cdot1);
                impulse = new Vector3F(
                    impulse1.X,
                    impulse1.Y,
                    impulse.Z
                );

                Vector2F p = impulse1;

                vA -= mA * p;
                wA -= iA * MathUtils.Cross(rA, p);

                vB += mB * p;
                wB += iB * MathUtils.Cross(rB, p);
            }
            else
            {
                Vector2F cdot1 = vB + MathUtils.Cross(wB, rB) - vA - MathUtils.Cross(wA, rA);
                float cdot2 = wB - wA;
                Vector3F cdot = new Vector3F(cdot1.X, cdot1.Y, cdot2);

                Vector3F impulse = -MathUtils.Mul(mass, cdot);
                this.impulse += impulse;

                Vector2F p = new Vector2F(impulse.X, impulse.Y);

                vA -= mA * p;
                wA -= iA * (MathUtils.Cross(rA, p) + impulse.Z);

                vB += mB * p;
                wB += iB * (MathUtils.Cross(rB, p) + impulse.Z);
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
            Vector2F cA = data.Positions[indexA].C;
            float aA = data.Positions[indexA].A;
            Vector2F cB = data.Positions[indexB].C;
            float aB = data.Positions[indexB].A;

            Rotation qA = new Rotation(aA), qB = new Rotation(aB);

            float mA = invMassA, mB = invMassB;
            float iA = invIa, iB = invIb;

            Vector2F rA = MathUtils.Mul(qA, LocalAnchorA - localCenterA);
            Vector2F rB = MathUtils.Mul(qB, LocalAnchorB - localCenterB);

            float positionError, angularError;

            Matrix3X3F k = new Matrix3X3F(
                mA + mB + rA.Y * rA.Y * iA + rB.Y * rB.Y * iB,
                -rA.Y * rA.X * iA - rB.Y * rB.X * iB,
                -rA.Y * iA - rB.Y * iB,
                -rA.Y * rA.X * iA - rB.Y * rB.X * iB,
                mA + mB + rA.X * rA.X * iA + rB.X * rB.X * iB,
                rA.X * iA + rB.X * iB,
                -rA.Y * iA - rB.Y * iB,
                rA.X * iA + rB.X * iB,
                iA + iB
            );

            if (stiffness > 0.0f)
            {
                Vector2F c1 = cB + rB - cA - rA;

                positionError = c1.Length();
                angularError = 0.0f;

                Vector2F p = -k.Solve22(c1);

                cA -= mA * p;
                aA -= iA * MathUtils.Cross(rA, p);

                cB += mB * p;
                aB += iB * MathUtils.Cross(rB, p);
            }
            else
            {
                Vector2F c1 = cB + rB - cA - rA;
                float c2 = aB - aA - referenceAngle;

                positionError = c1.Length();
                angularError = Math.Abs(c2);

                Vector3F c = new Vector3F(c1.X, c1.Y, c2);

                Vector3F impulse;
                if (k.Ez.Z > 0.0f)
                {
                    impulse = -k.Solve33(c);
                }
                else
                {
                    Vector2F impulse2 = -k.Solve22(c1);
                    impulse = new Vector3F(impulse2.X, impulse2.Y, 0.0f);
                }

                Vector2F p = new Vector2F(impulse.X, impulse.Y);

                cA -= mA * p;
                aA -= iA * (MathUtils.Cross(rA, p) + impulse.Z);

                cB += mB * p;
                aB += iB * (MathUtils.Cross(rB, p) + impulse.Z);
            }

            data.Positions[indexA].C = cA;
            data.Positions[indexA].A = aA;
            data.Positions[indexB].C = cB;
            data.Positions[indexB].A = aB;

            return (positionError <= Settings.LinearSlop) && (angularError <= Settings.AngularSlop);
        }
    }
}