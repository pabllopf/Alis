// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PrismaticJoint.cs
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

using System.Diagnostics;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Dynamics.Solver;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Dynamics.Joints
{
    // Linear constraint (point-to-line)
    // d = p2 - p1 = x2 + r2 - x1 - r1
    // C = dot(perp, d)
    // Cdot = dot(d, cross(w1, perp)) + dot(perp, v2 + cross(w2, r2) - v1 - cross(w1, r1))
    //      = -dot(perp, v1) - dot(cross(d + r1, perp), w1) + dot(perp, v2) + dot(cross(r2, perp), v2)
    // J = [-perp, -cross(d + r1, perp), perp, cross(r2,perp)]
    //
    // Angular constraint
    // C = a2 - a1 + a_initial
    // Cdot = w2 - w1
    // J = [0 0 -1 0 0 1]
    //
    // K = J * invM * JT
    //
    // J = [-a -s1 a s2]
    //     [0  -1  0  1]
    // a = perp
    // s1 = cross(d + r1, a) = cross(p2 - x1, a)
    // s2 = cross(r2, a) = cross(p2 - x2, a)

    // Motor/Limit linear constraint
    // C = dot(ax1, d)
    // Cdot = -dot(ax1, v1) - dot(cross(d + r1, ax1), w1) + dot(ax1, v2) + dot(cross(r2, ax1), v2)
    // J = [-ax1 -cross(d+r1,ax1) ax1 cross(r2,ax1)]

    // Predictive limit is applied even when the limit is not active.
    // Prevents a constraint speed that can lead to a constraint error in one time step.
    // Want C2 = C1 + h * Cdot >= 0
    // Or:
    // Cdot + C1/h >= 0
    // I do not apply a negative constraint error because that is handled in position correction.
    // So:
    // Cdot + max(C1, 0)/h >= 0

    // Block Solver
    // We develop a block solver that includes the angular and linear constraints. This makes the limit stiffer.
    //
    // The Jacobian has 2 rows:
    // J = [-uT -s1 uT s2] // linear
    //     [0   -1   0  1] // angular
    //
    // u = perp
    // s1 = cross(d + r1, u), s2 = cross(r2, u)
    // a1 = cross(d + r1, v), a2 = cross(r2, v)

    /// <summary>
    ///     A prismatic joint. This joint provides one degree of freedom: translation along an axis fixed in bodyA.
    ///     Relative rotation is prevented. You can use a joint limit to restrict the range of motion and a joint motor to
    ///     drive
    ///     the motion or to model joint friction.
    /// </summary>
    public class PrismaticJoint : Joint
    {
        /// <summary>
        ///     The
        /// </summary>
        private float a1, a2;

        /// <summary>
        ///     The axial mass
        /// </summary>
        private float axialMass;

        /// <summary>
        ///     The perp
        /// </summary>
        private Vector2F axis, perp;

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
        ///     The local axis
        /// </summary>
        private Vector2F localXAxisA;

        /// <summary>
        ///     The local axis
        /// </summary>
        private Vector2F localYAxisA;

        /// <summary>
        ///     The lower impulse
        /// </summary>
        private float lowerImpulse;

        /// <summary>
        ///     The lower translation
        /// </summary>
        private float lowerTranslation;

        /// <summary>
        ///     The max motor force
        /// </summary>
        private float maxMotorForce;

        /// <summary>
        ///     The motor impulse
        /// </summary>
        private float motorImpulse;

        /// <summary>
        ///     The motor speed
        /// </summary>
        private float motorSpeed;

        /// <summary>
        ///     The reference angle
        /// </summary>
        private float referenceAngle;

        /// <summary>
        ///     The
        /// </summary>
        private float s1, s2;

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

        /// <summary>
        ///     This requires defining a line of motion using an axis and an anchor point. The definition uses local anchor
        ///     points and a local axis so that the initial configuration can violate the constraint slightly. The joint
        ///     translation is
        ///     zero when the local anchor points coincide in world space. Using local anchors and a local axis helps when saving
        ///     and
        ///     loading a game.
        /// </summary>
        /// <param name="bodyA">The first body.</param>
        /// <param name="bodyB">The second body.</param>
        /// <param name="anchorA">The first body anchor.</param>
        /// <param name="anchorB">The second body anchor.</param>
        /// <param name="axis">The axis.</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public PrismaticJoint(Body bodyA, Body bodyB, Vector2F anchorA, Vector2F anchorB, Vector2F axis,
            bool useWorldCoordinates = false)
            : base(bodyA, bodyB, JointType.Prismatic)
        {
            Initialize(anchorA, anchorB, axis, useWorldCoordinates);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PrismaticJoint" /> class
        /// </summary>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="anchor">The anchor</param>
        /// <param name="axis">The axis</param>
        /// <param name="useWorldCoordinates">The use world coordinates</param>
        public PrismaticJoint(Body bodyA, Body bodyB, Vector2F anchor, Vector2F axis, bool useWorldCoordinates = false)
            : base(bodyA, bodyB, JointType.Prismatic)
        {
            Initialize(anchor, anchor, axis, useWorldCoordinates);
        }


        /// <summary>
        ///     Initializes a new instance of the <see cref="PrismaticJoint" /> class
        /// </summary>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        /// <param name="jointType">The joint type</param>
        /// <param name="collideConnected">The collide connected</param>
        /// <param name="localAnchorA">The local anchor</param>
        /// <param name="localAnchorB">The local anchor</param>
        /// <param name="localAxisA">The local axis</param>
        /// <param name="referenceAngle">The reference angle</param>
        /// <param name="enableLimit">The enable limit</param>
        /// <param name="lowerTranslation">The lower translation</param>
        /// <param name="upperTranslation">The upper translation</param>
        /// <param name="enableMotor">The enable motor</param>
        /// <param name="maxMotorForce">The max motor force</param>
        /// <param name="motorSpeed">The motor speed</param>
        public PrismaticJoint(
            Body bodyA = null,
            Body bodyB = null,
            JointType jointType = default(JointType),
            bool collideConnected = false,
            Vector2F localAnchorA = default(Vector2F),
            Vector2F localAnchorB = default(Vector2F),
            Vector2F localAxisA = default(Vector2F),
            float referenceAngle = 0.0f,
            bool enableLimit = false,
            float lowerTranslation = 0.0f,
            float upperTranslation = 0.0f,
            bool enableMotor = false,
            float maxMotorForce = 0.0f,
            float motorSpeed = 0.0f
        )
            : base(bodyA, bodyB, jointType, collideConnected)
        {
            if (localAxisA.Equals(default(Vector2F)))
            {
                localAxisA = new Vector2F(1.0f, 1.0f);
            }

            LocalAnchorA = localAnchorA;
            LocalAnchorB = localAnchorB;
            LocalXAxisA = localAxisA;

            LocalXAxisA = Vector2F.Normalize(LocalXAxisA);
            localYAxisA = MathUtils.Cross(1.0f, LocalXAxisA);
            ReferenceAngle = referenceAngle;

            this.lowerTranslation = lowerTranslation;
            this.upperTranslation = upperTranslation;

            Debug.Assert(lowerTranslation <= upperTranslation);

            this.maxMotorForce = maxMotorForce;
            this.motorSpeed = motorSpeed;
            this.enableLimit = enableLimit;
            this.enableMotor = enableMotor;
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

        /// <summary>Get the current joint translation, usually in meters.</summary>
        public float JointTranslation
        {
            get
            {
                Vector2F pA = BodyA.GetWorldPoint(LocalAnchorA);
                Vector2F pB = BodyB.GetWorldPoint(LocalAnchorB);
                Vector2F d = pB - pA;
                Vector2F axis = BodyA.GetWorldVector(LocalXAxisA);

                float translation = MathUtils.Dot(d, axis);
                return translation;
            }
        }

        /// <summary>Get the current joint translation speed, usually in meters per second.</summary>
        public float JointSpeed
        {
            get
            {
                Body bA = BodyA;
                Body bB = BodyB;

                Vector2F rA = MathUtils.Mul(bA.Xf.Rotation, LocalAnchorA - bA.Sweep.LocalCenter);
                Vector2F rB = MathUtils.Mul(bB.Xf.Rotation, LocalAnchorB - bB.Sweep.LocalCenter);
                Vector2F p1 = bA.Sweep.C + rA;
                Vector2F p2 = bB.Sweep.C + rB;
                Vector2F d = p2 - p1;
                Vector2F axis = MathUtils.Mul(bA.Xf.Rotation, LocalXAxisA);

                Vector2F vA = bA.LinearVelocity;
                Vector2F vB = bB.LinearVelocity;
                float wA = bA.AngularVelocity;
                float wB = bB.AngularVelocity;

                float speed = MathUtils.Dot(d, MathUtils.Cross(wA, axis)) +
                              MathUtils.Dot(axis, vB + MathUtils.Cross(wB, rB) - vA - MathUtils.Cross(wA, rA));
                return speed;
            }
        }

        /// <summary>Is the joint limit enabled?</summary>
        /// <value><c>true</c> if [limit enabled]; otherwise, <c>false</c>.</value>
        public bool LimitEnabled
        {
            get => enableLimit;
            set
            {
                if (value != enableLimit)
                {
                    WakeBodies();
                    enableLimit = value;
                    lowerImpulse = 0.0f;
                    upperImpulse = 0.0f;
                }
            }
        }

        /// <summary>Get the lower joint limit, usually in meters.</summary>
        public float LowerLimit
        {
            get => lowerTranslation;
            set
            {
                if (value != lowerTranslation)
                {
                    WakeBodies();
                    lowerTranslation = value;
                    lowerImpulse = 0.0f;
                }
            }
        }

        /// <summary>Get the upper joint limit, usually in meters.</summary>
        public float UpperLimit
        {
            get => upperTranslation;
            set
            {
                if (value != upperTranslation)
                {
                    WakeBodies();
                    upperTranslation = value;
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

        /// <summary>Set the motor speed, usually in meters per second.</summary>
        /// <value>The speed.</value>
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

        /// <summary>Set the maximum motor force, usually in N.</summary>
        /// <value>The force.</value>
        public float MotorForce
        {
            get => maxMotorForce;
            set
            {
                if (value != maxMotorForce)
                {
                    WakeBodies();
                    maxMotorForce = value;
                }
            }
        }

        /// <summary>The local joint axis relative to bodyA.</summary>
        public Vector2F LocalXAxisA
        {
            get => localXAxisA;
            set => localXAxisA = value;
        }

        /// <summary>
        ///     Gets the value of the local y axis a
        /// </summary>
        public Vector2F LocalYAxisA => localYAxisA;

        /// <summary>Get the reference angle.</summary>
        public float ReferenceAngle
        {
            get => referenceAngle;
            set => referenceAngle = value;
        }

        /// <summary>Get the current motor force given the inverse time step, usually in N.</summary>
        public float GetMotorForce(float invDt) => invDt * motorImpulse;

        /// <summary>Set the joint limits, usually in meters.</summary>
        /// <param name="lower">The lower limit</param>
        /// <param name="upper">The upper limit</param>
        public void SetLimits(float lower, float upper)
        {
            if (upper != upperTranslation || lower != lowerTranslation)
            {
                WakeBodies();
                upperTranslation = upper;
                lowerTranslation = lower;
                lowerImpulse = 0.0f;
                upperImpulse = 0.0f;
            }
        }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2F GetReactionForce(float invDt) =>
            invDt * (impulse.X * perp + (motorImpulse + lowerImpulse - upperImpulse) * axis);

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt) => invDt * impulse.Y;

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

            Vector2F cA = data.Positions[indexA].C;
            float aA = data.Positions[indexA].A;
            Vector2F vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;

            Vector2F cB = data.Positions[indexB].C;
            float aB = data.Positions[indexB].A;
            Vector2F vB = data.Velocities[indexB].V;
            float wB = data.Velocities[indexB].W;

            Rotation qA = new Rotation(aA), qB = new Rotation(aB);

            // Compute the effective masses.
            Vector2F rA = MathUtils.Mul(qA, LocalAnchorA - localCenterA);
            Vector2F rB = MathUtils.Mul(qB, LocalAnchorB - localCenterB);
            Vector2F d = cB - cA + rB - rA;

            float mA = invMassA, mB = invMassB;
            float iA = invIa, iB = invIb;

            // Compute motor Jacobian and effective mass.
            {
                axis = MathUtils.Mul(qA, LocalXAxisA);
                a1 = MathUtils.Cross(d + rA, axis);
                a2 = MathUtils.Cross(rB, axis);

                axialMass = mA + mB + iA * a1 * a1 + iB * a2 * a2;
                if (axialMass > 0.0f)
                {
                    axialMass = 1.0f / axialMass;
                }
            }

            // Prismatic constraint.
            {
                perp = MathUtils.Mul(qA, localYAxisA);

                s1 = MathUtils.Cross(d + rA, perp);
                s2 = MathUtils.Cross(rB, perp);

                float k11 = mA + mB + iA * s1 * s1 + iB * s2 * s2;
                float k12 = iA * s1 + iB * s2;
                float k22 = iA + iB;
                if (k22 == 0.0f)
                {
                    // For bodies with fixed rotation.
                    k22 = 1.0f;
                }

                k.Ex = new Vector2F(k11, k12);
                k.Ey = new Vector2F(k12, k22);
            }

            if (enableLimit)
            {
                translation = Vector2F.Dot(axis, d);
            }
            else
            {
                lowerImpulse = 0.0f;
                upperImpulse = 0.0f;
            }

            if (!enableMotor)
            {
                motorImpulse = 0.0f;
            }

            if (data.Step.WarmStarting)
            {
                // Account for variable time step.
                impulse *= data.Step.DeltaTimeRatio;
                motorImpulse *= data.Step.DeltaTimeRatio;
                lowerImpulse *= data.Step.DeltaTimeRatio;
                upperImpulse *= data.Step.DeltaTimeRatio;

                float axialImpulse = motorImpulse + lowerImpulse - upperImpulse;
                Vector2F p = impulse.X * perp + axialImpulse * axis;
                float la = impulse.X * s1 + impulse.Y + axialImpulse * a1;
                float lb = impulse.X * s2 + impulse.Y + axialImpulse * a2;

                vA -= mA * p;
                wA -= iA * la;

                vB += mB * p;
                wB += iB * lb;
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

            // Solve linear motor constraint.
            if (enableMotor)
            {
                float cdot = Vector2F.Dot(axis, vB - vA) + a2 * wB - a1 * wA;
                float impulse = axialMass * (motorSpeed - cdot);
                float oldImpulse = motorImpulse;
                float maxImpulse = data.Step.DeltaTime * maxMotorForce;
                motorImpulse = MathUtils.Clamp(motorImpulse + impulse, -maxImpulse, maxImpulse);
                impulse = motorImpulse - oldImpulse;

                Vector2F p = impulse * axis;
                float la = impulse * a1;
                float lb = impulse * a2;

                vA -= mA * p;
                wA -= iA * la;
                vB += mB * p;
                wB += iB * lb;
            }

            if (enableLimit)
            {
                // Lower limit
                {
                    float c = translation - lowerTranslation;
                    float cdot = MathUtils.Dot(axis, vB - vA) + a2 * wB - a1 * wA;
                    float impulse = -axialMass * (cdot + MathUtils.Max(c, 0.0f) * data.Step.InvertedDeltaTime);
                    float oldImpulse = lowerImpulse;
                    lowerImpulse = MathUtils.Max(lowerImpulse + impulse, 0.0f);
                    impulse = lowerImpulse - oldImpulse;

                    Vector2F p = impulse * axis;
                    float la = impulse * a1;
                    float lb = impulse * a2;

                    vA -= mA * p;
                    wA -= iA * la;
                    vB += mB * p;
                    wB += iB * lb;
                }

                // Upper limit
                // Note: signs are flipped to keep C positive when the constraint is satisfied.
                // This also keeps the impulse positive when the limit is active.
                {
                    float c = upperTranslation - translation;
                    float cdot = MathUtils.Dot(axis, vA - vB) + a1 * wA - a2 * wB;
                    float impulse = -axialMass * (cdot + MathUtils.Max(c, 0.0f) * data.Step.InvertedDeltaTime);
                    float oldImpulse = upperImpulse;
                    upperImpulse = MathUtils.Max(upperImpulse + impulse, 0.0f);
                    impulse = upperImpulse - oldImpulse;

                    Vector2F p = impulse * axis;
                    float la = impulse * a1;
                    float lb = impulse * a2;

                    vA += mA * p;
                    wA += iA * la;
                    vB -= mB * p;
                    wB -= iB * lb;
                }
            }

            // Solve the prismatic constraint in block form.
            {
                Vector2F cdot = new Vector2F(
                        MathUtils.Dot(perp, vB - vA) + s2 * wB - s1 * wA,
                        wB - wA
                    );

                Vector2F df = k.Solve(-cdot);
                impulse += df;

                Vector2F p = df.X * perp;
                float la = df.X * s1 + df.Y;
                float lb = df.X * s2 + df.Y;

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

        // A velocity based solver computes reaction forces(impulses) using the velocity constraint solver. Under this context,
        // the position solver is not there to resolve forces. It is only there to cope with integration error.
        //
        // Therefore, the pseudo impulses in the position solver do not have any physical meaning. Thus it is okay if they suck.
        //
        // We could take the active state from the velocity solver. However, the joint might push past the limit when the velocity
        // solver indicates the limit is inactive.
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

            // Compute fresh Jacobians
            Vector2F rA = MathUtils.Mul(qA, LocalAnchorA - localCenterA);
            Vector2F rB = MathUtils.Mul(qB, LocalAnchorB - localCenterB);
            Vector2F d = cB + rB - cA - rA;

            Vector2F axis = MathUtils.Mul(qA, LocalXAxisA);
            float a1 = MathUtils.Cross(d + rA, axis);
            float a2 = MathUtils.Cross(rB, axis);
            Vector2F perp = MathUtils.Mul(qA, localYAxisA);

            float s1 = MathUtils.Cross(d + rA, perp);
            float s2 = MathUtils.Cross(rB, perp);

            Vector3F impulse;
            Vector2F c1 = new Vector2F(
                Vector2F.Dot(perp, d),
                aB - aA - ReferenceAngle
                );
            
            float linearError = MathUtils.Abs(c1.X);
            float angularError = MathUtils.Abs(c1.Y);

            bool active = false;
            float c2 = 0.0f;
            if (enableLimit)
            {
                float translation = MathUtils.Dot(axis, d);
                if (MathUtils.Abs(upperTranslation - lowerTranslation) < 2.0f * Settings.LinearSlop)
                {
                    c2 = translation;
                    linearError = MathUtils.Max(linearError, MathUtils.Abs(translation));
                    active = true;
                }
                else if (translation <= lowerTranslation)
                {
                    c2 = MathUtils.Min(translation - lowerTranslation, 0.0f);
                    linearError = MathUtils.Max(linearError, lowerTranslation - translation);
                    active = true;
                }
                else if (translation >= upperTranslation)
                {
                    c2 = MathUtils.Max(translation - upperTranslation, 0.0f);
                    linearError = MathUtils.Max(linearError, translation - upperTranslation);
                    active = true;
                }
            }

            if (active)
            {
                float k11 = mA + mB + iA * s1 * s1 + iB * s2 * s2;
                float k12 = iA * s1 + iB * s2;
                float k13 = iA * s1 * a1 + iB * s2 * a2;
                float k22 = iA + iB;
                if (k22 == 0.0f)
                {
                    // For fixed rotation
                    k22 = 1.0f;
                }

                float k23 = iA * a1 + iB * a2;
                float k33 = mA + mB + iA * a1 * a1 + iB * a2 * a2;

                Matrix3X3F k;
                k.Ex = new Vector3F(k11, k12, k13);
                k.Ey = new Vector3F(k12, k22, k23);
                k.Ez = new Vector3F(k13, k23, k33);

                Vector3F c = new Vector3F(
                    c1.X,
                    c1.Y,
                    c2
                    );

                impulse = k.Solve33(-c);
            }
            else
            {
                float k11 = mA + mB + iA * s1 * s1 + iB * s2 * s2;
                float k12 = iA * s1 + iB * s2;
                float k22 = iA + iB;
                if (k22 == 0.0f)
                {
                    k22 = 1.0f;
                }

                Matrix2X2F k;
                k.Ex = new Vector2F(k11, k12);
                k.Ey = new Vector2F(k12, k22);

                Vector2F impulse1 = k.Solve(-c1);
                impulse = new Vector3F(
                    impulse1.X,
                    impulse1.Y,
                    0.0f
                    );
               
            }

            Vector2F p = impulse.X * perp + impulse.Z * axis;
            float la = impulse.X * s1 + impulse.Y + impulse.Z * a1;
            float lb = impulse.X * s2 + impulse.Y + impulse.Z * a2;

            cA -= mA * p;
            aA -= iA * la;
            cB += mB * p;
            aB += iB * lb;

            data.Positions[indexA].C = cA;
            data.Positions[indexA].A = aA;
            data.Positions[indexB].C = cB;
            data.Positions[indexB].A = aB;

            return (linearError <= Settings.LinearSlop) && (angularError <= Settings.AngularSlop);
        }

        //Velcro: We support initializing without a template
        /// <summary>
        ///     Initializes the local anchor a
        /// </summary>
        /// <param name="localAnchorA">The local anchor</param>
        /// <param name="localAnchorB">The local anchor</param>
        /// <param name="axis">The axis</param>
        /// <param name="useWorldCoordinates">The use world coordinates</param>
        private void Initialize(Vector2F localAnchorA, Vector2F localAnchorB, Vector2F axis, bool useWorldCoordinates)
        {
            //Velcro: We support setting anchors in world coordinates
            if (useWorldCoordinates)
            {
                LocalAnchorA = BodyA.GetLocalPoint(localAnchorA);
                LocalAnchorB = BodyB.GetLocalPoint(localAnchorB);
                LocalXAxisA = BodyA.GetLocalVector(axis);
            }
            else
            {
                LocalAnchorA = localAnchorA;
                LocalAnchorB = localAnchorB;
                LocalXAxisA = axis;
            }

            ReferenceAngle = BodyB.Rotation - BodyA.Rotation;
            LocalXAxisA = Vector2F.Normalize(LocalXAxisA);
            localYAxisA = MathUtils.Cross(1.0f, LocalXAxisA);
        }
    }
}