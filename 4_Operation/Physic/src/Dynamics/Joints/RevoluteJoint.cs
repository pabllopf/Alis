// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RevoluteJoint.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics.Joints.Misc;
using Alis.Core.Physic.Dynamics.Solver;
using Alis.Core.Physic.Shared;
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

    // Motor constraint
    // Cdot = w2 - w1
    // J = [0 0 -1 0 0 1]
    // K = invI1 + invI2

    /// <summary>
    ///     A revolute joint constrains to bodies to share a common point while they are free to rotate about the point.
    ///     The relative rotation about the shared point is the joint angle. You can limit the relative rotation with a joint
    ///     limit
    ///     that specifies a lower and upper angle. You can use a motor to drive the relative rotation about the shared point.
    ///     A
    ///     maximum motor torque is provided so that infinite forces are not generated.
    /// </summary>
    public class RevoluteJoint : Joint
    {
        /// <summary>
        ///     The angle
        /// </summary>
        private float angle;

        /// <summary>
        ///     The axial mass
        /// </summary>
        private float axialMass;

        /// <summary>
        ///     The enable limit
        /// </summary>
        private bool enableLimit;

        /// <summary>
        ///     The enable motor
        /// </summary>
        private bool enableMotor;

        /// <summary>
        ///     The impulse
        /// </summary>
        private Vector2F impulse;

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
        ///     The
        /// </summary>
        private Matrix2X2F k;

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
        ///     The lower angle
        /// </summary>
        private float lowerAngle;

        /// <summary>
        ///     The lower impulse
        /// </summary>
        private float lowerImpulse;

        /// <summary>
        ///     The max motor torque
        /// </summary>
        private float maxMotorTorque;

        /// <summary>
        ///     The motor impulse
        /// </summary>
        private float motorImpulse;

        /// <summary>
        ///     The motor speed
        /// </summary>
        private float motorSpeed;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F rA;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F rB;

        /// <summary>
        ///     The reference angle
        /// </summary>
        private float referenceAngle;

        /// <summary>
        ///     The upper angle
        /// </summary>
        private float upperAngle;

        /// <summary>
        ///     The upper impulse
        /// </summary>
        private float upperImpulse;

        /// <summary>A flag to enable joint limits.</summary>
        public bool EnableLimit { get; set; }

        /// <summary>A flag to enable the joint motor.</summary>
        public bool EnableMotor { get; set; }

        /// <summary>The lower angle for the joint limit (radians).</summary>
        public float LowerAngle { get; set; }

        /// <summary>The upper angle for the joint limit (radians).</summary>
        public float UpperAngle { get; set; }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="RevoluteJoint"/> class
        /// </summary>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="jointType">The joint type</param>
        /// <param name="collideConnected">The collide connected</param>
        /// <param name="localAnchorA">The local anchor</param>
        /// <param name="localAnchorB">The local anchor</param>
        /// <param name="referenceAngle">The reference angle</param>
        /// <param name="lowerAngle">The lower angle</param>
        /// <param name="upperAngle">The upper angle</param>
        /// <param name="motorTorque">The motor torque</param>
        /// <param name="motorSpeed">The motor speed</param>
        /// <param name="enableLimit">The enable limit</param>
        /// <param name="enableMotor">The enable motor</param>
        public RevoluteJoint(
            Body bodyA = null,
            Body bodyB = null,
            JointType jointType = default(JointType),
            bool collideConnected = false,
            Vector2F localAnchorA = default(Vector2F),
            Vector2F localAnchorB = default(Vector2F),
            float referenceAngle = 0.0f,
            float lowerAngle = 0.0f,
            float upperAngle = 0.0f,
            float motorTorque = 0.0f,
            float motorSpeed = 0.0f,
            bool enableLimit = false,
            bool enableMotor = false
            )
            : base(bodyA, bodyB, jointType, collideConnected)
        {
            this.localAnchorA = localAnchorA;
            this.localAnchorB = localAnchorB;
            this.referenceAngle = referenceAngle;
            this.lowerAngle = lowerAngle;
            this.upperAngle = upperAngle;
            this.maxMotorTorque = motorTorque;
            this.motorSpeed = motorSpeed;
            this.enableLimit = enableLimit;
            this.enableMotor = enableMotor;
            this.angle = 0.0f;
        }

        /// <summary>Constructor of RevoluteJoint.</summary>
        /// <param name="bodyA">The first body.</param>
        /// <param name="bodyB">The second body.</param>
        /// <param name="anchorA">The first body anchor.</param>
        /// <param name="anchorB">The second anchor.</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public RevoluteJoint(Body bodyA, Body bodyB, Vector2F anchorA, Vector2F anchorB, bool useWorldCoordinates = false)
            : base(bodyA, bodyB, JointType.Revolute)
        {
            if (useWorldCoordinates)
            {
                LocalAnchorA = bodyA.GetLocalPoint(anchorA);
                LocalAnchorB = bodyB.GetLocalPoint(anchorB);
            }
            else
            {
                LocalAnchorA = anchorA;
                LocalAnchorB = anchorB;
            }

            ReferenceAngle = bodyB.Sweep.A - bodyA.Sweep.A;
        }

        /// <summary>Constructor of RevoluteJoint.</summary>
        /// <param name="bodyA">The first body.</param>
        /// <param name="bodyB">The second body.</param>
        /// <param name="anchor">The shared anchor.</param>
        /// <param name="useWorldCoordinates"></param>
        public RevoluteJoint(Body bodyA, Body bodyB, Vector2F anchor, bool useWorldCoordinates = false)
            : this(bodyA, bodyB, anchor, anchor, useWorldCoordinates)
        {
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
            get => BodyA.GetWorldPoint(LocalAnchorA);
            set => LocalAnchorA = BodyA.GetLocalPoint(value);
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public override Vector2F WorldAnchorB
        {
            get => BodyB.GetWorldPoint(LocalAnchorB);
            set => LocalAnchorB = BodyB.GetLocalPoint(value);
        }

        /// <summary>The referance angle computed as BodyB angle minus BodyA angle.</summary>
        public float ReferenceAngle
        {
            get => referenceAngle;
            set => referenceAngle = value;
        }

        /// <summary>Get the current joint angle in radians.</summary>
        public float JointAngle => BodyB.Sweep.A - BodyA.Sweep.A - ReferenceAngle;

        /// <summary>Get the current joint angle speed in radians per second.</summary>
        public float JointSpeed => BodyB.AngularVelocity - BodyA.AngularVelocity;

        /// <summary>Is the joint limit enabled?</summary>
        /// <value><c>true</c> if [limit enabled]; otherwise, <c>false</c>.</value>
        public bool LimitEnabled
        {
            get => enableLimit;
            set
            {
                if (enableLimit != value)
                {
                    WakeBodies();
                    enableLimit = value;
                    lowerImpulse = 0.0f;
                    upperImpulse = 0.0f;
                }
            }
        }

        /// <summary>Get the lower joint limit in radians.</summary>
        public float LowerLimit
        {
            get => lowerAngle;
            set
            {
                if (lowerAngle != value)
                {
                    WakeBodies();
                    lowerAngle = value;
                    lowerImpulse = 0.0f;
                }
            }
        }

        /// <summary>Get the upper joint limit in radians.</summary>
        public float UpperLimit
        {
            get => upperAngle;
            set
            {
                if (upperAngle != value)
                {
                    WakeBodies();
                    upperAngle = value;
                    upperImpulse = 0.0f;
                }
            }
        }

        /// <summary>Is the joint motor enabled?</summary>
        /// <value><c>true</c> if [motor enabled]; otherwise, <c>false</c>.</value>
        public bool MotorEnabled
        {
            get => enableMotor;
            set
            {
                if (value != enableMotor)
                {
                    WakeBodies();
                    enableMotor = value;
                }
            }
        }

        /// <summary>Get or set the motor speed in radians per second.</summary>
        public float MotorSpeed
        {
            set
            {
                if (value != motorSpeed)
                {
                    WakeBodies();
                    motorSpeed = value;
                }
            }
            get => motorSpeed;
        }

        /// <summary>Get or set the maximum motor torque, usually in N-m.</summary>
        public float MaxMotorTorque
        {
            set
            {
                if (value != maxMotorTorque)
                {
                    WakeBodies();
                    maxMotorTorque = value;
                }
            }
            get => maxMotorTorque;
        }

        /// <summary>Set the joint limits, usually in meters.</summary>
        /// <param name="lower">The lower limit</param>
        /// <param name="upper">The upper limit</param>
        public void SetLimits(float lower, float upper)
        {
            if (lower != lowerAngle || upper != upperAngle)
            {
                WakeBodies();
                lowerImpulse = 0.0f;
                upperImpulse = 0.0f;
                upperAngle = upper;
                lowerAngle = lower;
            }
        }

        /// <summary>Gets the motor torque in N-m.</summary>
        /// <param name="invDt">The inverse delta time</param>
        public float GetMotorTorque(float invDt) => invDt * motorImpulse;

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
        public override float GetReactionTorque(float invDt) => invDt * (motorImpulse + lowerImpulse - upperImpulse);

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

            rA = MathUtils.Mul(qA, LocalAnchorA - localCenterA);
            rB = MathUtils.Mul(qB, LocalAnchorB - localCenterB);

            // J = [-I -r1_skew I r2_skew]
            // r_skew = [-ry; rx]

            // Matlab
            // K = [ mA+r1y^2*iA+mB+r2y^2*iB,  -r1y*iA*r1x-r2y*iB*r2x]
            //     [  -r1y*iA*r1x-r2y*iB*r2x, mA+r1x^2*iA+mB+r2x^2*iB]

            float mA = invMassA, mB = invMassB;
            float iA = invIa, iB = invIb;

            k.Ex.X = mA + mB + rA.Y * rA.Y * iA + rB.Y * rB.Y * iB;
            k.Ey.X = -rA.Y * rA.X * iA - rB.Y * rB.X * iB;
            k.Ex.Y = k.Ey.X;
            k.Ey.Y = mA + mB + rA.X * rA.X * iA + rB.X * rB.X * iB;

            axialMass = iA + iB;
            bool fixedRotation;
            if (axialMass > 0.0f)
            {
                axialMass = 1.0f / axialMass;
                fixedRotation = false;
            }
            else
            {
                fixedRotation = true;
            }

            angle = aB - aA - ReferenceAngle;
            if (enableLimit == false || fixedRotation)
            {
                lowerImpulse = 0.0f;
                upperImpulse = 0.0f;
            }

            if (enableMotor == false || fixedRotation)
            {
                motorImpulse = 0.0f;
            }

            if (data.Step.WarmStarting)
            {
                // Scale impulses to support a variable time step.
                impulse *= data.Step.DeltaTimeRatio;
                motorImpulse *= data.Step.DeltaTimeRatio;
                lowerImpulse *= data.Step.DeltaTimeRatio;
                upperImpulse *= data.Step.DeltaTimeRatio;

                float axialImpulse = motorImpulse + lowerImpulse - upperImpulse;
                Vector2F p = new Vector2F(impulse.X, impulse.Y);

                vA -= mA * p;
                wA -= iA * (MathUtils.Cross(rA, p) + axialImpulse);

                vB += mB * p;
                wB += iB * (MathUtils.Cross(rB, p) + axialImpulse);
            }
            else
            {
                impulse = Vector2F.Zero;
                motorImpulse = 0.0f;
                lowerImpulse = 0.0f;
                upperImpulse = 0.0f;
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

            bool fixedRotation = iA + iB == 0.0f;

            // Solve motor constraint.
            if (enableMotor && (fixedRotation == false))
            {
                float cdot = wB - wA - motorSpeed;
                float impulse = -axialMass * cdot;
                float oldImpulse = motorImpulse;
                float maxImpulse = data.Step.DeltaTime * maxMotorTorque;
                motorImpulse = MathUtils.Clamp(motorImpulse + impulse, -maxImpulse, maxImpulse);
                impulse = motorImpulse - oldImpulse;

                wA -= iA * impulse;
                wB += iB * impulse;
            }

            if (enableLimit && (fixedRotation == false))
            {
                // Lower limit
                {
                    float c = angle - lowerAngle;
                    float cdot = wB - wA;
                    float impulse = -axialMass * (cdot + MathUtils.Max(c, 0.0f) * data.Step.InvertedDeltaTime);
                    float oldImpulse = lowerImpulse;
                    lowerImpulse = MathUtils.Max(lowerImpulse + impulse, 0.0f);
                    impulse = lowerImpulse - oldImpulse;

                    wA -= iA * impulse;
                    wB += iB * impulse;
                }

                // Upper limit
                // Note: signs are flipped to keep C positive when the constraint is satisfied.
                // This also keeps the impulse positive when the limit is active.
                {
                    float c = upperAngle - angle;
                    float cdot = wA - wB;
                    float impulse = -axialMass * (cdot + MathUtils.Max(c, 0.0f) * data.Step.InvertedDeltaTime);
                    float oldImpulse = upperImpulse;
                    upperImpulse = MathUtils.Max(upperImpulse + impulse, 0.0f);
                    impulse = upperImpulse - oldImpulse;

                    wA += iA * impulse;
                    wB -= iB * impulse;
                }
            }

            // Solve point-to-point constraint
            {
                Vector2F cdot = vB + MathUtils.Cross(wB, rB) - vA - MathUtils.Cross(wA, rA);
                Vector2F impulse = k.Solve(-cdot);

                this.impulse.X += impulse.X;
                this.impulse.Y += impulse.Y;

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
        internal override bool SolvePositionConstraints(ref SolverData data)
        {
            Vector2F cA = data.Positions[indexA].C;
            float aA = data.Positions[indexA].A;
            Vector2F cB = data.Positions[indexB].C;
            float aB = data.Positions[indexB].A;

            Rotation qA = new Rotation(aA), qB = new Rotation(aB);

            float angularError = 0.0f;
            float positionError = 0.0f;

            bool fixedRotation = invIa + invIb == 0.0f;

            // Solve angular limit constraint
            if (enableLimit && (fixedRotation == false))
            {
                float angle = aB - aA - ReferenceAngle;
                float c = 0.0f;

                if (MathUtils.Abs(upperAngle - lowerAngle) < 2.0f * Settings.AngularSlop)
                {
                    // Prevent large angular corrections
                    c = MathUtils.Clamp(angle - lowerAngle, -Settings.MaxAngularCorrection,
                        Settings.MaxAngularCorrection);
                }
                else if (angle <= lowerAngle)
                {
                    // Prevent large angular corrections and allow some slop.
                    c = MathUtils.Clamp(angle - lowerAngle + Settings.AngularSlop, -Settings.MaxAngularCorrection,
                        0.0f);
                }
                else if (angle >= upperAngle)
                {
                    // Prevent large angular corrections and allow some slop.
                    c = MathUtils.Clamp(angle - upperAngle - Settings.AngularSlop, 0.0f,
                        Settings.MaxAngularCorrection);
                }

                float limitImpulse = -axialMass * c;
                aA -= invIa * limitImpulse;
                aB += invIb * limitImpulse;
                angularError = MathUtils.Abs(c);
            }

            // Solve point-to-point constraint.
            {
                qA.Set(aA);
                qB.Set(aB);
                Vector2F rA = MathUtils.Mul(qA, LocalAnchorA - localCenterA);
                Vector2F rB = MathUtils.Mul(qB, LocalAnchorB - localCenterB);

                Vector2F c = cB + rB - cA - rA;
                positionError = c.Length();

                float mA = invMassA, mB = invMassB;
                float iA = invIa, iB = invIb;

                Matrix2X2F k;
                k.Ex.X = mA + mB + iA * rA.Y * rA.Y + iB * rB.Y * rB.Y;
                k.Ex.Y = -iA * rA.X * rA.Y - iB * rB.X * rB.Y;
                k.Ey.X = k.Ex.Y;
                k.Ey.Y = mA + mB + iA * rA.X * rA.X + iB * rB.X * rB.X;

                Vector2F impulse = -k.Solve(c);

                cA -= mA * impulse;
                aA -= iA * MathUtils.Cross(rA, impulse);

                cB += mB * impulse;
                aB += iB * MathUtils.Cross(rB, impulse);
            }

            data.Positions[indexA].C = cA;
            data.Positions[indexA].A = aA;
            data.Positions[indexB].C = cB;
            data.Positions[indexB].A = aB;

            return (positionError <= Settings.LinearSlop) && (angularError <= Settings.AngularSlop);
        }
    }
}