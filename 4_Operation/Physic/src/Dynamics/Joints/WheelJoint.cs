// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WheelJoint.cs
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
using System.Diagnostics;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics.Solver;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     A wheel joint. This joint provides two degrees of freedom: translation along an axis fixed in bodyA and
    ///     rotation in the plane. In other words, it is a point to line constraint with a rotational motor and a linear
    ///     spring/damper. The spring/damper is initialized upon creation. This joint is designed for vehicle suspensions.
    ///
    /// Linear constraint (point-to-line)
    /// d = pB - pA = xB + rB - xA - rA
    /// C = dot(ay, d)
    /// Cdo = dot(d, cross(wA, ay)) + dot(ay, vB + cross(wB, rB) - vA - cross(wA, rA))
    ///      = -dot(ay, vA) - dot(cross(d + rA, ay), wA) + dot(ay, vB) + dot(cross(rB, ay), vB)
    /// J = [-ay, -cross(d + rA, ay), ay, cross(rB, ay)]
    /// 
    /// Spring linear constraint
    /// C = dot(ax, d)
    /// Cdo = = -dot(ax, vA) - dot(cross(d + rA, ax), wA) + dot(ax, vB) + dot(cross(rB, ax), vB)
    /// J = [-ax -cross(d+rA, ax) ax cross(rB, ax)]
    /// 
    /// Motor rotational constraint
    /// Cdo = wB - wA
    /// J = [0 0 -1 0 0 1]
    /// </summary>
    public class WheelJoint : Joint
    {
        /// <summary>
        ///     The local axis
        /// </summary>
        private readonly Vector2F localXAxisA;

        /// <summary>
        ///     The local axis
        /// </summary>
        private readonly Vector2F localYAxisA;

        /// <summary>
        ///     The ay
        /// </summary>
        private Vector2F ax, ay;

        /// <summary>
        ///     The axial mass
        /// </summary>
        private float axialMass;

        /// <summary>
        ///     The bias
        /// </summary>
        private float bias;

        /// <summary>
        ///     The damping
        /// </summary>
        private float damping;

        /// <summary>
        ///     The enable limit
        /// </summary>
        private bool enableLimit;

        /// <summary>
        ///     The enable motor
        /// </summary>
        private bool enableMotor;

        /// <summary>
        ///     The gamma
        /// </summary>
        private float gamma;

        /// <summary>
        ///     The impulse
        /// </summary>
        private float impulse;


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
        ///     The lower impulse
        /// </summary>
        private float lowerImpulse;

        /// <summary>
        ///     The lower translation
        /// </summary>
        private float lowerTranslation;

        /// <summary>
        ///     The mass
        /// </summary>
        private float mass;

        /// <summary>
        ///     The max motor torque
        /// </summary>
        private float maxMotorTorque;

        /// <summary>
        ///     The motor impulse
        /// </summary>
        private float motorImpulse;

        /// <summary>
        ///     The motor mass
        /// </summary>
        private float motorMass;

        /// <summary>
        ///     The motor speed
        /// </summary>
        private float motorSpeed;

        /// <summary>
        ///     The bx
        /// </summary>
        private float sAx, sBx;

        /// <summary>
        ///     The by
        /// </summary>
        private float sAy, sBy;

        /// <summary>
        ///     The spring impulse
        /// </summary>
        private float springImpulse;

        /// <summary>
        ///     The spring mass
        /// </summary>
        private float springMass;

        /// <summary>
        ///     The stiffness
        /// </summary>
        private float stiffness;

        /// <summary>
        ///     The translation
        /// </summary>
        private float translation;

        /// <summary>
        ///     The upper impulse
        /// </summary>
        private float upperImpulse;

        /// <summary>
        ///     The upper translation
        /// </summary>
        private float upperTranslation;

        /// <summary>Constructor for WheelJoint</summary>
        /// <param name="bodyA">The first body</param>
        /// <param name="bodyB">The second body</param>
        /// <param name="anchor">The anchor point</param>
        /// <param name="axis">The axis</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public WheelJoint(Body bodyA, Body bodyB, Vector2F anchor, Vector2F axis, bool useWorldCoordinates = false)
            : base(bodyA, bodyB, JointType.Wheel)
        {
            if (useWorldCoordinates)
            {
                localAnchorA = bodyA.GetLocalPoint(anchor);
                localAnchorB = bodyB.GetLocalPoint(anchor);
                localXAxisA = bodyA.GetLocalVector(axis);
            }
            else
            {
                localAnchorA = bodyA.GetLocalPoint(bodyB.GetWorldPoint(anchor));
                localAnchorB = anchor;
                localXAxisA = bodyA.GetLocalVector(axis);
            }

            localYAxisA = MathUtils.Cross(1.0f, localXAxisA);
        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="WheelJoint" /> class
        /// </summary>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="jointType">The joint type</param>
        /// <param name="collideConnected">The collide connected</param>
        /// <param name="localAnchorA">The local anchor</param>
        /// <param name="localAnchorB">The local anchor</param>
        /// <param name="localAxisA">The local axis</param>
        /// <param name="enableLimit">The enable limit</param>
        /// <param name="lowerTranslation">The lower translation</param>
        /// <param name="upperTranslation">The upper translation</param>
        /// <param name="enableMotor">The enable motor</param>
        /// <param name="maxMotorTorque">The max motor torque</param>
        /// <param name="motorSpeed">The motor speed</param>
        /// <param name="stiffness">The stiffness</param>
        /// <param name="damping">The damping</param>
        public WheelJoint(
            Body bodyA = null,
            Body bodyB = null,
            JointType jointType = default(JointType),
            bool collideConnected = false,
            Vector2F localAnchorA = default(Vector2F),
            Vector2F localAnchorB = default(Vector2F),
            Vector2F localAxisA = default(Vector2F),
            bool enableLimit = false,
            float lowerTranslation = 0.0f,
            float upperTranslation = 0.0f,
            bool enableMotor = false,
            float maxMotorTorque = 0.0f,
            float motorSpeed = 0.0f,
            float stiffness = 0.0f,
            float damping = 0.0f
        )
            : base(bodyA, bodyB, jointType, collideConnected)
        {
            if (localAxisA.Equals(default(Vector2F)))
            {
                localAxisA = new Vector2F(1.0f, 0.0f);
            }

            this.localAnchorA = localAnchorA;
            this.localAnchorB = localAnchorB;
            localXAxisA = localAxisA;
            localYAxisA = MathUtils.Cross(1.0f, localXAxisA);
            this.lowerTranslation = lowerTranslation;
            this.upperTranslation = upperTranslation;
            this.enableLimit = enableLimit;
            this.maxMotorTorque = maxMotorTorque;
            this.motorSpeed = motorSpeed;
            this.enableMotor = enableMotor;
            this.stiffness = stiffness;
            this.damping = damping;
        }

        /// <summary>
        ///     Gets the value of the local x axis a
        /// </summary>
        public Vector2F LocalXAxisA => localXAxisA;

        /// <summary>
        ///     Gets the value of the local y axis a
        /// </summary>
        public Vector2F LocalYAxisA => localYAxisA;

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

        /// <summary>The desired motor speed in radians per second.</summary>
        public float MotorSpeed
        {
            get => motorSpeed;
            set
            {
                if (Math.Abs(value - motorSpeed) > 0.0001f)
                {
                    WakeBodies();
                    motorSpeed = value;
                }
            }
        }

        /// <summary>The maximum motor torque, usually in N-m.</summary>
        public float MotorTorque
        {
            get => maxMotorTorque;
            set
            {
                if (Math.Abs(value - maxMotorTorque) > 0.0001f)
                {
                    WakeBodies();
                    maxMotorTorque = value;
                }
            }
        }

        /// <summary>Gets the translation along the axis</summary>
        public float JointTranslation
        {
            get
            {
                Body bA = BodyA;
                Body bB = BodyB;

                Vector2F pA = bA.GetWorldPoint(localAnchorA);
                Vector2F pB = bB.GetWorldPoint(localAnchorB);
                Vector2F d = pB - pA;
                Vector2F axis = bA.GetWorldVector(localXAxisA);
                
                return Vector2F.Dot(d, axis);
            }
        }

        /// <summary>
        ///     Gets the value of the joint linear speed
        /// </summary>
        public float JointLinearSpeed
        {
            get
            {
                Body bA = BodyA;
                Body bB = BodyB;

                Vector2F rA = MathUtils.Mul(bA.Xf.Rotation, localAnchorA - bA.Sweep.LocalCenter);
                Vector2F rB = MathUtils.Mul(bB.Xf.Rotation, localAnchorB - bB.Sweep.LocalCenter);
                Vector2F p1 = bA.Sweep.C + rA;
                Vector2F p2 = bB.Sweep.C + rB;
                Vector2F d = p2 - p1;
                Vector2F axis = MathUtils.Mul(bA.Xf.Rotation, localXAxisA);

                Vector2F vA = bA.LinearVelocity;
                Vector2F vB = bB.LinearVelocity;
                float wA = bA.AngularVelocity;
                float wB = bB.AngularVelocity;

                float speed = MathUtils.Dot(d, MathUtils.Cross(wA, axis)) +
                              MathUtils.Dot(axis, vB + MathUtils.Cross(wB, rB) - vA - MathUtils.Cross(wA, rA));
                return speed;
            }
        }

        /// <summary>
        ///     Gets the value of the joint angle
        /// </summary>
        public float JointAngle
        {
            get
            {
                Body bA = BodyA;
                Body bB = BodyB;
                return bB.Sweep.A - bA.Sweep.A;
            }
        }

        /// <summary>Gets the angular velocity of the joint</summary>
        public float JointAngularSpeed
        {
            get
            {
                float wA = BodyA.AngularVelocity;
                float wB = BodyB.AngularVelocity;
                return wB - wA;
            }
        }

        /// <summary>Enable/disable the joint motor.</summary>
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

        /// <summary>
        ///     Gets or sets the value of the upper limit
        /// </summary>
        public float UpperLimit
        {
            get => upperTranslation;
            set
            {
                if (Math.Abs(upperTranslation - value) > 0.0001f)
                {
                    WakeBodies();
                    upperTranslation = value;
                    upperImpulse = 0.0f;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the value of the lower limit
        /// </summary>
        public float LowerLimit
        {
            get => lowerTranslation;
            set
            {
                if (Math.Abs(lowerTranslation - value) > 0.0001f)
                {
                    WakeBodies();
                    lowerTranslation = value;
                    lowerImpulse = 0.0f;
                }
            }
        }

        /// <summary>
        ///     Gets or sets the value of the enable limit
        /// </summary>
        public bool EnableLimit
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

        /// <summary>
        ///     Gets or sets the value of the damping
        /// </summary>
        public float Damping
        {
            get => damping;
            set => damping = value;
        }

        /// <summary>
        ///     Gets or sets the value of the stiffness
        /// </summary>
        public float Stiffness
        {
            get => stiffness;
            set => stiffness = value;
        }

        /// <summary>
        ///     Sets the limits using the specified lower
        /// </summary>
        /// <param name="lower">The lower</param>
        /// <param name="upper">The upper</param>
        public void SetLimits(float lower, float upper)
        {
            Debug.Assert(lower <= upper);
            if (Math.Abs(lower - lowerTranslation) > 0.0001f || Math.Abs(upper - upperTranslation) > 0.0001f)
            {
                WakeBodies();
                lowerTranslation = lower;
                upperTranslation = upper;
                lowerImpulse = 0.0f;
                upperImpulse = 0.0f;
            }
        }

        /// <summary>Gets the torque of the motor</summary>
        /// <param name="invDt">inverse delta time</param>
        public float GetMotorTorque(float invDt) => invDt * motorImpulse;

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2F GetReactionForce(float invDt) =>
            invDt * (impulse * ay + (springImpulse + lowerImpulse - upperImpulse) * ax);

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt) => invDt * motorImpulse;

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

            float mA = invMassA, mB = invMassB;
            float iA = invIa, iB = invIb;

            Vector2F cA = data.Positions[indexA].C;
            float aA = data.Positions[indexA].A;
            Vector2F vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;

            Vector2F cB = data.Positions[indexB].C;
            float aB = data.Positions[indexB].A;
            Vector2F vB = data.Velocities[indexB].V;
            float wB = data.Velocities[indexB].W;

            Rotation qA = new Rotation(aA), qB = new Rotation(aB);
            
            Vector2F rA = MathUtils.Mul(qA, localAnchorA - localCenterA);
            Vector2F rB = MathUtils.Mul(qB, localAnchorB - localCenterB);
            Vector2F d = cB + rB - cA - rA;
            
            {
                ay = MathUtils.Mul(qA, localYAxisA);
                sAy = MathUtils.Cross(d + rA, ay);
                sBy = MathUtils.Cross(rB, ay);

                mass = mA + mB + iA * sAy * sAy + iB * sBy * sBy;

                if (mass > 0.0f)
                {
                    mass = 1.0f / mass;
                }
            }

            ax = MathUtils.Mul(qA, localXAxisA);
            sAx = MathUtils.Cross(d + rA, ax);
            sBx = MathUtils.Cross(rB, ax);

            float invMass = mA + mB + iA * sAx * sAx + iB * sBx * sBx;
            if (invMass > 0.0f)
            {
                axialMass = 1.0f / invMass;
            }
            else
            {
                axialMass = 0.0f;
            }

            springMass = 0.0f;
            bias = 0.0f;
            gamma = 0.0f;

            if ((stiffness > 0.0f) && (invMass > 0.0f))
            {
                springMass = 1.0f / invMass;

                float c = MathUtils.Dot(d, ax);
                
                float h = data.Step.DeltaTime;
                gamma = h * (damping + h * stiffness);
                if (gamma > 0.0f)
                {
                    gamma = 1.0f / gamma;
                }

                bias = c * h * stiffness * gamma;

                springMass = invMass + gamma;
                if (springMass > 0.0f)
                {
                    springMass = 1.0f / springMass;
                }
            }
            else
            {
                springImpulse = 0.0f;
            }

            if (enableLimit)
            {
                translation = MathUtils.Dot(ax, d);
            }
            else
            {
                lowerImpulse = 0.0f;
                upperImpulse = 0.0f;
            }

            if (enableMotor)
            {
                motorMass = iA + iB;
                if (motorMass > 0.0f)
                {
                    motorMass = 1.0f / motorMass;
                }
            }
            else
            {
                motorMass = 0.0f;
                motorImpulse = 0.0f;
            }

            if (data.Step.WarmStarting)
            {
                impulse *= data.Step.DeltaTimeRatio;
                springImpulse *= data.Step.DeltaTimeRatio;
                motorImpulse *= data.Step.DeltaTimeRatio;

                float axialImpulse = springImpulse + lowerImpulse - upperImpulse;
                Vector2F p = impulse * ay + axialImpulse * ax;
                float la = impulse * sAy + axialImpulse * sAx + motorImpulse;
                float lb = impulse * sBy + axialImpulse * sBx + motorImpulse;

                vA -= invMassA * p;
                wA -= invIa * la;

                vB += invMassB * p;
                wB += invIb * lb;
            }
            else
            {
                impulse = 0.0f;
                springImpulse = 0.0f;
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
            float mA = invMassA, mB = invMassB;
            float iA = invIa, iB = invIb;

            Vector2F vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;
            Vector2F vB = data.Velocities[indexB].V;
            float wB = data.Velocities[indexB].W;
            
            {
                float dot = MathUtils.Dot(ax, vB - vA) + sBx * wB - sAx * wA;
                float impulseLocal = -springMass * (dot + bias + gamma * springImpulse);
                springImpulse += impulseLocal;

                Vector2F p = impulseLocal * ax;
                float la = impulseLocal * sAx;
                float lb = impulseLocal * sBx;

                vA -= mA * p;
                wA -= iA * la;

                vB += mB * p;
                wB += iB * lb;
            }

            {
                float dot = wB - wA - motorSpeed;
                float impulseLocal = -motorMass * dot;

                float oldImpulse = motorImpulse;
                float maxImpulse = data.Step.DeltaTime * maxMotorTorque;
                motorImpulse = MathUtils.Clamp(motorImpulse + impulseLocal, -maxImpulse, maxImpulse);
                impulseLocal = motorImpulse - oldImpulse;

                wA -= iA * impulseLocal;
                wB += iB * impulseLocal;
            }

            if (enableLimit)
            {
                {
                    float c = translation - lowerTranslation;
                    float dot = MathUtils.Dot(ax, vB - vA) + sBx * wB - sAx * wA;
                    float impulseLocal = -axialMass * (dot + MathUtils.Max(c, 0.0f) * data.Step.InvertedDeltaTime);
                    float oldImpulse = lowerImpulse;
                    lowerImpulse = MathUtils.Max(lowerImpulse + impulseLocal, 0.0f);
                    impulseLocal = lowerImpulse - oldImpulse;

                    Vector2F p = impulseLocal * ax;
                    float la = impulseLocal * sAx;
                    float lb = impulseLocal * sBx;

                    vA -= mA * p;
                    wA -= iA * la;
                    vB += mB * p;
                    wB += iB * lb;
                }
                
                {
                    float c = upperTranslation - translation;
                    float dot = MathUtils.Dot(ax, vA - vB) + sAx * wA - sBx * wB;
                    float impulseLocal = -axialMass * (dot + MathUtils.Max(c, 0.0f) * data.Step.InvertedDeltaTime);
                    float oldImpulse = upperImpulse;
                    upperImpulse = MathUtils.Max(upperImpulse + impulseLocal, 0.0f);
                    impulseLocal = upperImpulse - oldImpulse;

                    Vector2F p = impulseLocal * ax;
                    float la = impulseLocal * sAx;
                    float lb = impulseLocal * sBx;

                    vA += mA * p;
                    wA += iA * la;
                    vB -= mB * p;
                    wB -= iB * lb;
                }
            }

            {
                float dot = MathUtils.Dot(ay, vB - vA) + sBy * wB - sAy * wA;
                float impulseLocal = -mass * dot;
                impulse += impulseLocal;

                Vector2F p = impulseLocal * ay;
                float la = impulseLocal * sAy;
                float lb = impulseLocal * sBy;

                vA -= mA * p;
                wA -= iA * la;

                vB += mB * p;
                wB += iB * lb;
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

            float linearError = 0.0f;

            if (enableLimit)
            {
                Rotation qA = new Rotation(aA), qB = new Rotation(aB);

                Vector2F rA = MathUtils.Mul(qA, localAnchorA - localCenterA);
                Vector2F rB = MathUtils.Mul(qB, localAnchorB - localCenterB);
                Vector2F d = cB - cA + rB - rA;

                Vector2F axLocal = MathUtils.Mul(qA, localXAxisA);
                float sAxLocal = MathUtils.Cross(d + rA, ax);
                float sBxLocal = MathUtils.Cross(rB, ax);

                float c = 0.0f;
                float translationLocal = MathUtils.Dot(axLocal, d);
                if (MathUtils.Abs(upperTranslation - lowerTranslation) < 2.0f * Settings.LinearSlop)
                {
                    c = translationLocal;
                }
                else if (translationLocal <= lowerTranslation)
                {
                    c = MathUtils.Min(translationLocal - lowerTranslation, 0.0f);
                }
                else if (translationLocal >= upperTranslation)
                {
                    c = MathUtils.Max(translationLocal - upperTranslation, 0.0f);
                }

                if (c != 0.0f)
                {
                    float invMass = invMassA + invMassB + invIa * sAxLocal * sAxLocal + invIb * sBxLocal * sBxLocal;
                    float impulseLocal = 0.0f;
                    if (invMass != 0.0f)
                    {
                        impulseLocal = -c / invMass;
                    }

                    Vector2F p = impulseLocal * axLocal;
                    float la = impulseLocal * sAxLocal;
                    float lb = impulseLocal * sBxLocal;

                    cA -= invMassA * p;
                    aA -= invIa * la;
                    cB += invMassB * p;
                    aB += invIb * lb;

                    linearError = MathUtils.Abs(c);
                }
            }
            
            {
                Rotation qA = new Rotation(aA), qB = new Rotation(aB);

                Vector2F rA = MathUtils.Mul(qA, localAnchorA - localCenterA);
                Vector2F rB = MathUtils.Mul(qB, localAnchorB - localCenterB);
                Vector2F d = cB - cA + rB - rA;

                Vector2F ayLocal = MathUtils.Mul(qA, localYAxisA);

                float sAyLocal = MathUtils.Cross(d + rA, ayLocal);
                float sByLocal = MathUtils.Cross(rB, ayLocal);

                float c = MathUtils.Dot(d, ayLocal);

                float invMass = invMassA + invMassB + invIa * sAy * sAy + invIb * sBy * sBy;

                float impulseLocal = 0.0f;
                if (invMass != 0.0f)
                {
                    impulseLocal = -c / invMass;
                }

                Vector2F p = impulseLocal * ayLocal;
                float la = impulseLocal * sAyLocal;
                float lb = impulseLocal * sByLocal;

                cA -= invMassA * p;
                aA -= invIa * la;
                cB += invMassB * p;
                aB += invIb * lb;

                linearError = MathUtils.Max(linearError, MathUtils.Abs(c));
            }

            data.Positions[indexA].C = cA;
            data.Positions[indexA].A = aA;
            data.Positions[indexB].C = cB;
            data.Positions[indexB].A = aB;

            return linearError <= Settings.LinearSlop;
        }
    }
}