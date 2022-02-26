// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PrismaticJoint.cs
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

using System.Diagnostics;
using System.Numerics;
using Alis.Core.Systems.Physics2D.Config;
using Alis.Core.Systems.Physics2D.Definitions.Joints;
using Alis.Core.Systems.Physics2D.Dynamics.Joints.Misc;
using Alis.Core.Systems.Physics2D.Dynamics.Solver;
using Alis.Core.Systems.Physics2D.Shared;
using Alis.Core.Systems.Physics2D.Utilities;

namespace Alis.Core.Systems.Physics2D.Dynamics.Joints
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
        private Vector2 axis, perp;

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
        private Vector2 impulse;

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
        private Mat22 k;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private Vector2 localAnchorA;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private Vector2 localAnchorB;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 localCenterA;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 localCenterB;

        /// <summary>
        ///     The local axis
        /// </summary>
        private Vector2 localXAxisA;

        /// <summary>
        ///     The local axis
        /// </summary>
        private Vector2 localYAxisA;

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
        public PrismaticJoint(Body bodyA, Body bodyB, Vector2 anchorA, Vector2 anchorB, Vector2 axis,
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
        public PrismaticJoint(Body bodyA, Body bodyB, Vector2 anchor, Vector2 axis, bool useWorldCoordinates = false)
            : base(bodyA, bodyB, JointType.Prismatic)
        {
            Initialize(anchor, anchor, axis, useWorldCoordinates);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PrismaticJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public PrismaticJoint(PrismaticJointDef def)
            : base(def)
        {
            LocalAnchorA = def.LocalAnchorA;
            LocalAnchorB = def.LocalAnchorB;
            LocalXAxisA = def.LocalAxisA;

            LocalXAxisA = Vector2.Normalize(LocalXAxisA);
            localYAxisA = MathUtils.Cross(1.0f, LocalXAxisA);
            ReferenceAngle = def.ReferenceAngle;


            lowerTranslation = def.LowerTranslation;
            upperTranslation = def.UpperTranslation;

            Debug.Assert(lowerTranslation <= upperTranslation);

            maxMotorForce = def.MaxMotorForce;
            motorSpeed = def.MotorSpeed;
            enableLimit = def.EnableLimit;
            enableMotor = def.EnableMotor;
        }

        /// <summary>The local anchor point on BodyA</summary>
        public Vector2 LocalAnchorA
        {
            get => localAnchorA;
            set => localAnchorA = value;
        }

        /// <summary>The local anchor point on BodyB</summary>
        public Vector2 LocalAnchorB
        {
            get => localAnchorB;
            set => localAnchorB = value;
        }

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

        /// <summary>Get the current joint translation, usually in meters.</summary>
        public float JointTranslation
        {
            get
            {
                Vector2 pA = BodyA.GetWorldPoint(LocalAnchorA);
                Vector2 pB = BodyB.GetWorldPoint(LocalAnchorB);
                Vector2 d = pB - pA;
                Vector2 axis = BodyA.GetWorldVector(LocalXAxisA);

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

                Vector2 rA = MathUtils.Mul(bA.Xf.Q, LocalAnchorA - bA.Sweep.LocalCenter);
                Vector2 rB = MathUtils.Mul(bB.Xf.Q, LocalAnchorB - bB.Sweep.LocalCenter);
                Vector2 p1 = bA.Sweep.C + rA;
                Vector2 p2 = bB.Sweep.C + rB;
                Vector2 d = p2 - p1;
                Vector2 axis = MathUtils.Mul(bA.Xf.Q, LocalXAxisA);

                Vector2 vA = bA.LinearVelocity;
                Vector2 vB = bB.LinearVelocity;
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
        public float MaxMotorForce
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
        public Vector2 LocalXAxisA
        {
            get => localXAxisA;
            set => localXAxisA = value;
        }

        /// <summary>
        ///     Gets the value of the local y axis a
        /// </summary>
        public Vector2 LocalYAxisA => localYAxisA;

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
        public override Vector2 GetReactionForce(float invDt) =>
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

            Vector2 cA = data.Positions[indexA].C;
            float aA = data.Positions[indexA].A;
            Vector2 vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;

            Vector2 cB = data.Positions[indexB].C;
            float aB = data.Positions[indexB].A;
            Vector2 vB = data.Velocities[indexB].V;
            float wB = data.Velocities[indexB].W;

            Rot qA = new Rot(aA), qB = new Rot(aB);

            // Compute the effective masses.
            Vector2 rA = MathUtils.Mul(qA, LocalAnchorA - localCenterA);
            Vector2 rB = MathUtils.Mul(qB, LocalAnchorB - localCenterB);
            Vector2 d = cB - cA + rB - rA;

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

                k.Ex = new Vector2(k11, k12);
                k.Ey = new Vector2(k12, k22);
            }

            if (enableLimit)
            {
                translation = Vector2.Dot(axis, d);
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
                Vector2 p = impulse.X * perp + axialImpulse * axis;
                float la = impulse.X * s1 + impulse.Y + axialImpulse * a1;
                float lb = impulse.X * s2 + impulse.Y + axialImpulse * a2;

                vA -= mA * p;
                wA -= iA * la;

                vB += mB * p;
                wB += iB * lb;
            }
            else
            {
                impulse = Vector2.Zero;
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
            Vector2 vA = data.Velocities[indexA].V;
            float wA = data.Velocities[indexA].W;
            Vector2 vB = data.Velocities[indexB].V;
            float wB = data.Velocities[indexB].W;

            float mA = invMassA, mB = invMassB;
            float iA = invIa, iB = invIb;

            // Solve linear motor constraint.
            if (enableMotor)
            {
                float cdot = Vector2.Dot(axis, vB - vA) + a2 * wB - a1 * wA;
                float impulse = axialMass * (motorSpeed - cdot);
                float oldImpulse = motorImpulse;
                float maxImpulse = data.Step.DeltaTime * maxMotorForce;
                motorImpulse = MathUtils.Clamp(motorImpulse + impulse, -maxImpulse, maxImpulse);
                impulse = motorImpulse - oldImpulse;

                Vector2 p = impulse * axis;
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

                    Vector2 p = impulse * axis;
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

                    Vector2 p = impulse * axis;
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
                Vector2 cdot;
                cdot.X = MathUtils.Dot(perp, vB - vA) + s2 * wB - s1 * wA;
                cdot.Y = wB - wA;

                Vector2 df = k.Solve(-cdot);
                impulse += df;

                Vector2 p = df.X * perp;
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
            Vector2 cA = data.Positions[indexA].C;
            float aA = data.Positions[indexA].A;
            Vector2 cB = data.Positions[indexB].C;
            float aB = data.Positions[indexB].A;

            Rot qA = new Rot(aA), qB = new Rot(aB);

            float mA = invMassA, mB = invMassB;
            float iA = invIa, iB = invIb;

            // Compute fresh Jacobians
            Vector2 rA = MathUtils.Mul(qA, LocalAnchorA - localCenterA);
            Vector2 rB = MathUtils.Mul(qB, LocalAnchorB - localCenterB);
            Vector2 d = cB + rB - cA - rA;

            Vector2 axis = MathUtils.Mul(qA, LocalXAxisA);
            float a1 = MathUtils.Cross(d + rA, axis);
            float a2 = MathUtils.Cross(rB, axis);
            Vector2 perp = MathUtils.Mul(qA, localYAxisA);

            float s1 = MathUtils.Cross(d + rA, perp);
            float s2 = MathUtils.Cross(rB, perp);

            Vector3 impulse;
            Vector2 c1;
            c1.X = Vector2.Dot(perp, d);
            c1.Y = aB - aA - ReferenceAngle;

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

                Mat33 k;
                k.Ex = new Vector3(k11, k12, k13);
                k.Ey = new Vector3(k12, k22, k23);
                k.Ez = new Vector3(k13, k23, k33);

                Vector3 c;
                c.X = c1.X;
                c.Y = c1.Y;
                c.Z = c2;

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

                Mat22 k;
                k.Ex = new Vector2(k11, k12);
                k.Ey = new Vector2(k12, k22);

                Vector2 impulse1 = k.Solve(-c1);
                impulse.X = impulse1.X;
                impulse.Y = impulse1.Y;
                impulse.Z = 0.0f;
            }

            Vector2 p = impulse.X * perp + impulse.Z * axis;
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

            return linearError <= Settings.LinearSlop && angularError <= Settings.AngularSlop;
        }

        //Velcro: We support initializing without a template
        /// <summary>
        ///     Initializes the local anchor a
        /// </summary>
        /// <param name="localAnchorA">The local anchor</param>
        /// <param name="localAnchorB">The local anchor</param>
        /// <param name="axis">The axis</param>
        /// <param name="useWorldCoordinates">The use world coordinates</param>
        private void Initialize(Vector2 localAnchorA, Vector2 localAnchorB, Vector2 axis, bool useWorldCoordinates)
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
            LocalXAxisA = Vector2.Normalize(LocalXAxisA);
            localYAxisA = MathUtils.Cross(1.0f, LocalXAxisA);
        }
    }
}