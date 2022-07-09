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
// Cdot = = -dot(ax1, v1) - dot(cross(d + r1, ax1), w1) + dot(ax1, v2) + dot(cross(r2, ax1), v2)
// J = [-ax1 -cross(d+r1,ax1) ax1 cross(r2,ax1)]

// Block Solver
// We develop a block solver that includes the joint limit. This makes the limit stiff (inelastic) even
// when the mass has poor distribution (leading to large torques about the joint anchor points).
//
// The Jacobian has 3 rows:
// J = [-uT -s1 uT s2] // linear
//     [0   -1   0  1] // angular
//     [-vT -a1 vT a2] // limit
//
// u = perp
// v = axis
// s1 = cross(d + r1, u), s2 = cross(r2, u)
// a1 = cross(d + r1, v), a2 = cross(r2, v)

// M * (v2 - v1) = JT * df
// J * v2 = bias
//
// v2 = v1 + invM * JT * df
// J * (v1 + invM * JT * df) = bias
// K * df = bias - J * v1 = -Cdot
// K = J * invM * JT
// Cdot = J * v1 - bias
//
// Now solve for f2.
// df = f2 - f1
// K * (f2 - f1) = -Cdot
// f2 = invK * (-Cdot) + f1
//
// Clamp accumulated limit impulse.
// lower: f2(3) = max(f2(3), 0)
// upper: f2(3) = min(f2(3), 0)
//
// Solve for correct f2(1:2)
// K(1:2, 1:2) * f2(1:2) = -Cdot(1:2) - K(1:2,3) * f2(3) + K(1:2,1:3) * f1
//                       = -Cdot(1:2) - K(1:2,3) * f2(3) + K(1:2,1:2) * f1(1:2) + K(1:2,3) * f1(3)
// K(1:2, 1:2) * f2(1:2) = -Cdot(1:2) - K(1:2,3) * (f2(3) - f1(3)) + K(1:2,1:2) * f1(1:2)
// f2(1:2) = invK(1:2,1:2) * (-Cdot(1:2) - K(1:2,3) * (f2(3) - f1(3))) + f1(1:2)
//
// Now compute impulse to be applied:
// df = f2 - f1

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    using Box2DXMath = Math;

    /// <summary>
    ///     A prismatic joint. This joint provides one degree of freedom: translation
    ///     along an axis fixed in body1. Relative rotation is prevented. You can
    ///     use a joint limit to restrict the range of motion and a joint motor to
    ///     drive the motion or to model joint friction.
    /// </summary>
    public class PrismaticJoint : Joint
    {
        /// <summary>
        ///     The
        /// </summary>
        public float A1;

        /// <summary>
        ///     The
        /// </summary>
        public float A2;

        /// <summary>
        ///     The perp
        /// </summary>
        public Vec2 Axis;

        /// <summary>
        ///     The perp
        /// </summary>
        public Vec2 Perp;

        /// <summary>
        ///     The impulse
        /// </summary>
        public Vec3 Impulse;

        /// <summary>
        ///     The
        /// </summary>
        public Mat33 K;

        /// <summary>
        ///     The limit state
        /// </summary>
        public LimitState LimitState;

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vec2 LocalAnchor1;

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vec2 LocalAnchor2;

        /// <summary>
        ///     The local axis
        /// </summary>
        public Vec2 LocalXAxis1;

        /// <summary>
        ///     The local axis
        /// </summary>
        public Vec2 LocalYAxis1;

        /// <summary>
        ///     The max motor force
        /// </summary>
        public float MaxMotorForce;

        /// <summary>
        ///     The motor mass
        /// </summary>
        public float MotorMass; // effective mass for motor/limit translational constraint.

        /// <summary>
        ///     The motor speed
        /// </summary>
        public float motorSpeedx;

        /// <summary>
        ///     The ref angle
        /// </summary>
        public float RefAngle;

        /// <summary>
        ///     The
        /// </summary>
        public float S1;

        /// <summary>
        ///     The
        /// </summary>
        public float S2;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PrismaticJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public PrismaticJoint(PrismaticJointDef def)
            : base(def)
        {
            LocalAnchor1 = def.LocalAnchor1;
            LocalAnchor2 = def.LocalAnchor2;
            LocalXAxis1 = def.LocalAxis1;
            LocalYAxis1 = Vec2.Cross(1.0f, LocalXAxis1);
            RefAngle = def.ReferenceAngle;

            Impulse.SetZero();
            MotorMass = 0.0f;
            MotorForce = 0.0f;

            LowerLimit = def.LowerTranslation;
            UpperLimit = def.UpperTranslation;
            MaxMotorForce = Settings.FORCE_INV_SCALE(def.MaxMotorForce);
            motorSpeedx = def.MotorSpeed;
            IsLimitEnabled = def.EnableLimit;
            IsMotorEnabled = def.EnableMotor;
            LimitState = LimitState.InactiveLimit;

            Axis.SetZero();
            Perp.SetZero();
        }

        /// <summary>
        ///     Gets the value of the anchor 1
        /// </summary>
        public override Vec2 Anchor1 => Body1.GetWorldPoint(LocalAnchor1);

        /// <summary>
        ///     Gets the value of the anchor 2
        /// </summary>
        public override Vec2 Anchor2 => Body2.GetWorldPoint(LocalAnchor2);

        /// <summary>
        ///     Get the current joint translation, usually in meters.
        /// </summary>
        public float JointTranslation
        {
            get
            {
                Body b1 = Body1;
                Body b2 = Body2;

                Vec2 p1 = b1.GetWorldPoint(LocalAnchor1);
                Vec2 p2 = b2.GetWorldPoint(LocalAnchor2);
                Vec2 d = p2 - p1;
                Vec2 axis = b1.GetWorldVector(LocalXAxis1);

                float translation = Vec2.Dot(d, axis);
                return translation;
            }
        }

        /// <summary>
        ///     Get the current joint translation speed, usually in meters per second.
        /// </summary>
        public float JointSpeed
        {
            get
            {
                Body b1 = Body1;
                Body b2 = Body2;

                Vec2 r1 = Math.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
                Vec2 r2 = Math.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());
                Vec2 p1 = b1.Sweep.C + r1;
                Vec2 p2 = b2.Sweep.C + r2;
                Vec2 d = p2 - p1;
                Vec2 axis = b1.GetWorldVector(LocalXAxis1);

                Vec2 v1 = b1.LinearVelocity;
                Vec2 v2 = b2.LinearVelocity;
                float w1 = b1.AngularVelocity;
                float w2 = b2.AngularVelocity;

                float speed = Vec2.Dot(d, Vec2.Cross(w1, axis)) +
                              Vec2.Dot(axis, v2 + Vec2.Cross(w2, r2) - v1 - Vec2.Cross(w1, r1));
                return speed;
            }
        }

        /// <summary>
        ///     Is the joint limit enabled?
        /// </summary>
        public bool IsLimitEnabled { get; set; }

        /// <summary>
        ///     Get the lower joint limit, usually in meters.
        /// </summary>
        public float LowerLimit { get; set; }

        /// <summary>
        ///     Get the upper joint limit, usually in meters.
        /// </summary>
        public float UpperLimit { get; set; }

        /// <summary>
        ///     Is the joint motor enabled?
        /// </summary>
        public bool IsMotorEnabled { get; set; }

        /// <summary>
        ///     Get\Set the motor speed, usually in meters per second.
        /// </summary>
        public float MotorSpeedx
        {
            get { return motorSpeedx; }
            set
            {
                Body1.WakeUp();
                Body2.WakeUp();
                motorSpeedx = value;
            }
        }

        /// <summary>
        ///     Get the current motor force, usually in N.
        /// </summary>
        public float MotorForce { get; set; }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="inv_dt">The inv dt</param>
        /// <returns>The vec</returns>
        public override Vec2 GetReactionForce(float inv_dt)
        {
            return inv_dt * (Impulse.X * Perp + (MotorForce + Impulse.Z) * Axis);
        }

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="inv_dt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float inv_dt)
        {
            return inv_dt * Impulse.Y;
        }

        /// <summary>
        ///     Enable/disable the joint limit.
        /// </summary>
        public void EnableLimit(bool flag)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            IsLimitEnabled = flag;
        }

        /// <summary>
        ///     Set the joint limits, usually in meters.
        /// </summary>
        public void SetLimits(float lower, float upper)
        {
            Box2DXDebug.Assert(lower <= upper);
            Body1.WakeUp();
            Body2.WakeUp();
            LowerLimit = lower;
            UpperLimit = upper;
        }

        /// <summary>
        ///     Enable/disable the joint motor.
        /// </summary>
        public void EnableMotor(bool flag)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            IsMotorEnabled = flag;
        }

        /// <summary>
        ///     Set the maximum motor force, usually in N.
        /// </summary>
        public void SetMaxMotorForce(float force)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            MaxMotorForce = Settings.FORCE_SCALE(1.0f) * force;
        }

        /// <summary>
        ///     Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal override void InitVelocityConstraints(TimeStep step)
        {
            Body b1 = Body1;
            Body b2 = Body2;

            // You cannot create a prismatic joint between bodies that
            // both have fixed rotation.
            Box2DXDebug.Assert(b1.InvI > 0.0f || b2.InvI > 0.0f);

            LocalCenter1 = b1.GetLocalCenter();
            LocalCenter2 = b2.GetLocalCenter();

            XForm xf1 = b1.GetXForm();
            XForm xf2 = b2.GetXForm();

            // Compute the effective masses.
            Vec2 r1 = Box2DXMath.Mul(xf1.R, LocalAnchor1 - LocalCenter1);
            Vec2 r2 = Box2DXMath.Mul(xf2.R, LocalAnchor2 - LocalCenter2);
            Vec2 d = b2.Sweep.C + r2 - b1.Sweep.C - r1;

            InvMass1 = b1.InvMass;
            InvI1 = b1.InvI;
            InvMass2 = b2.InvMass;
            InvI2 = b2.InvI;

            // Compute motor Jacobian and effective mass.
            {
                Axis = Box2DXMath.Mul(xf1.R, LocalXAxis1);
                A1 = Vec2.Cross(d + r1, Axis);
                A2 = Vec2.Cross(r2, Axis);

                MotorMass = InvMass1 + InvMass2 + InvI1 * A1 * A1 + InvI2 * A2 * A2;
                Box2DXDebug.Assert(MotorMass > Settings.FltEpsilon);
                MotorMass = 1.0f / MotorMass;
            }

            // Prismatic constraint.
            {
                Perp = Box2DXMath.Mul(xf1.R, LocalYAxis1);

                S1 = Vec2.Cross(d + r1, Perp);
                S2 = Vec2.Cross(r2, Perp);

                float m1 = InvMass1, m2 = InvMass2;
                float i1 = InvI1, i2 = InvI2;

                float k11 = m1 + m2 + i1 * S1 * S1 + i2 * S2 * S2;
                float k12 = i1 * S1 + i2 * S2;
                float k13 = i1 * S1 * A1 + i2 * S2 * A2;
                float k22 = i1 + i2;
                float k23 = i1 * A1 + i2 * A2;
                float k33 = m1 + m2 + i1 * A1 * A1 + i2 * A2 * A2;

                K.Col1.Set(k11, k12, k13);
                K.Col2.Set(k12, k22, k23);
                K.Col3.Set(k13, k23, k33);
            }

            // Compute motor and limit terms.
            if (IsLimitEnabled)
            {
                float jointTranslation = Vec2.Dot(Axis, d);
                if (Box2DXMath.Abs(UpperLimit - LowerLimit) < 2.0f * Settings.LinearSlop)
                {
                    LimitState = LimitState.EqualLimits;
                }
                else if (jointTranslation <= LowerLimit)
                {
                    if (LimitState != LimitState.AtLowerLimit)
                    {
                        LimitState = LimitState.AtLowerLimit;
                        Impulse.Z = 0.0f;
                    }
                }
                else if (jointTranslation >= UpperLimit)
                {
                    if (LimitState != LimitState.AtUpperLimit)
                    {
                        LimitState = LimitState.AtUpperLimit;
                        Impulse.Z = 0.0f;
                    }
                }
                else
                {
                    LimitState = LimitState.InactiveLimit;
                    Impulse.Z = 0.0f;
                }
            }
            else
            {
                LimitState = LimitState.InactiveLimit;
            }

            if (IsMotorEnabled == false)
            {
                MotorForce = 0.0f;
            }

            if (step.WarmStarting)
            {
                // Account for variable time step.
                Impulse *= step.DtRatio;
                MotorForce *= step.DtRatio;

                Vec2 P = Impulse.X * Perp + (MotorForce + Impulse.Z) * Axis;
                float L1 = Impulse.X * S1 + Impulse.Y + (MotorForce + Impulse.Z) * A1;
                float L2 = Impulse.X * S2 + Impulse.Y + (MotorForce + Impulse.Z) * A2;

                b1.LinearVelocity -= InvMass1 * P;
                b1.AngularVelocity -= InvI1 * L1;

                b2.LinearVelocity += InvMass2 * P;
                b2.AngularVelocity += InvI2 * L2;
            }
            else
            {
                Impulse.SetZero();
                MotorForce = 0.0f;
            }
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal override void SolveVelocityConstraints(TimeStep step)
        {
            Body b1 = Body1;
            Body b2 = Body2;

            Vec2 v1 = b1.LinearVelocity;
            float w1 = b1.AngularVelocity;
            Vec2 v2 = b2.LinearVelocity;
            float w2 = b2.AngularVelocity;

            // Solve linear motor constraint.
            if (IsMotorEnabled && LimitState != LimitState.EqualLimits)
            {
                float Cdot = Vec2.Dot(Axis, v2 - v1) + A2 * w2 - A1 * w1;
                float impulse = MotorMass * (motorSpeedx - Cdot);
                float oldImpulse = MotorForce;
                float maxImpulse = step.Dt * MaxMotorForce;
                MotorForce = Box2DXMath.Clamp(MotorForce + impulse, -maxImpulse, maxImpulse);
                impulse = MotorForce - oldImpulse;

                Vec2 P = impulse * Axis;
                float L1 = impulse * A1;
                float L2 = impulse * A2;

                v1 -= InvMass1 * P;
                w1 -= InvI1 * L1;

                v2 += InvMass2 * P;
                w2 += InvI2 * L2;
            }

            Vec2 Cdot1;
            Cdot1.X = Vec2.Dot(Perp, v2 - v1) + S2 * w2 - S1 * w1;
            Cdot1.Y = w2 - w1;

            if (IsLimitEnabled && LimitState != LimitState.InactiveLimit)
            {
                // Solve prismatic and limit constraint in block form.
                float Cdot2;
                Cdot2 = Vec2.Dot(Axis, v2 - v1) + A2 * w2 - A1 * w1;
                Vec3 Cdot = new Vec3(Cdot1.X, Cdot1.Y, Cdot2);

                Vec3 f1 = Impulse;
                Vec3 df = K.Solve33(-Cdot);
                Impulse += df;

                if (LimitState == LimitState.AtLowerLimit)
                {
                    Impulse.Z = Box2DXMath.Max(Impulse.Z, 0.0f);
                }
                else if (LimitState == LimitState.AtUpperLimit)
                {
                    Impulse.Z = Box2DXMath.Min(Impulse.Z, 0.0f);
                }

                // f2(1:2) = invK(1:2,1:2) * (-Cdot(1:2) - K(1:2,3) * (f2(3) - f1(3))) + f1(1:2)
                Vec2 b = -Cdot1 - (Impulse.Z - f1.Z) * new Vec2(K.Col3.X, K.Col3.Y);
                Vec2 f2r = K.Solve22(b) + new Vec2(f1.X, f1.Y);
                Impulse.X = f2r.X;
                Impulse.Y = f2r.Y;

                df = Impulse - f1;

                Vec2 P = df.X * Perp + df.Z * Axis;
                float L1 = df.X * S1 + df.Y + df.Z * A1;
                float L2 = df.X * S2 + df.Y + df.Z * A2;

                v1 -= InvMass1 * P;
                w1 -= InvI1 * L1;

                v2 += InvMass2 * P;
                w2 += InvI2 * L2;
            }
            else
            {
                // Limit is inactive, just solve the prismatic constraint in block form.
                Vec2 df = K.Solve22(-Cdot1);
                Impulse.X += df.X;
                Impulse.Y += df.Y;

                Vec2 P = df.X * Perp;
                float L1 = df.X * S1 + df.Y;
                float L2 = df.X * S2 + df.Y;

                v1 -= InvMass1 * P;
                w1 -= InvI1 * L1;

                v2 += InvMass2 * P;
                w2 += InvI2 * L2;
            }

            b1.LinearVelocity = v1;
            b1.AngularVelocity = w1;
            b2.LinearVelocity = v2;
            b2.AngularVelocity = w2;
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="baumgarte">The baumgarte</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(float baumgarte)
        {
            Body b1 = Body1;
            Body b2 = Body2;

            Vec2 c1 = b1.Sweep.C;
            float a1 = b1.Sweep.A;

            Vec2 c2 = b2.Sweep.C;
            float a2 = b2.Sweep.A;

            // Solve linear limit constraint.
            float linearError = 0.0f, angularError = 0.0f;
            bool active = false;
            float C2 = 0.0f;

            Mat22 R1 = new Mat22(a1), R2 = new Mat22(a2);

            Vec2 r1 = Box2DXMath.Mul(R1, LocalAnchor1 - LocalCenter1);
            Vec2 r2 = Box2DXMath.Mul(R2, LocalAnchor2 - LocalCenter2);
            Vec2 d = c2 + r2 - c1 - r1;

            if (IsLimitEnabled)
            {
                Axis = Box2DXMath.Mul(R1, LocalXAxis1);

                A1 = Vec2.Cross(d + r1, Axis);
                A2 = Vec2.Cross(r2, Axis);

                float translation = Vec2.Dot(Axis, d);
                if (Box2DXMath.Abs(UpperLimit - LowerLimit) < 2.0f * Settings.LinearSlop)
                {
                    // Prevent large angular corrections
                    C2 = Box2DXMath.Clamp(translation, -Settings.MaxLinearCorrection, Settings.MaxLinearCorrection);
                    linearError = Box2DXMath.Abs(translation);
                    active = true;
                }
                else if (translation <= LowerLimit)
                {
                    // Prevent large linear corrections and allow some slop.
                    C2 = Box2DXMath.Clamp(translation - LowerLimit + Settings.LinearSlop,
                        -Settings.MaxLinearCorrection, 0.0f);
                    linearError = LowerLimit - translation;
                    active = true;
                }
                else if (translation >= UpperLimit)
                {
                    // Prevent large linear corrections and allow some slop.
                    C2 = Box2DXMath.Clamp(translation - UpperLimit - Settings.LinearSlop, 0.0f,
                        Settings.MaxLinearCorrection);
                    linearError = translation - UpperLimit;
                    active = true;
                }
            }

            Perp = Box2DXMath.Mul(R1, LocalYAxis1);

            S1 = Vec2.Cross(d + r1, Perp);
            S2 = Vec2.Cross(r2, Perp);

            Vec3 impulse;
            Vec2 C1 = new Vec2();
            C1.X = Vec2.Dot(Perp, d);
            C1.Y = a2 - a1 - RefAngle;

            linearError = Box2DXMath.Max(linearError, Box2DXMath.Abs(C1.X));
            angularError = Box2DXMath.Abs(C1.Y);

            if (active)
            {
                float m1 = InvMass1, m2 = InvMass2;
                float i1 = InvI1, i2 = InvI2;

                float k11 = m1 + m2 + i1 * S1 * S1 + i2 * S2 * S2;
                float k12 = i1 * S1 + i2 * S2;
                float k13 = i1 * S1 * A1 + i2 * S2 * A2;
                float k22 = i1 + i2;
                float k23 = i1 * A1 + i2 * A2;
                float k33 = m1 + m2 + i1 * A1 * A1 + i2 * A2 * A2;

                K.Col1.Set(k11, k12, k13);
                K.Col2.Set(k12, k22, k23);
                K.Col3.Set(k13, k23, k33);

                Vec3 C = new Vec3();
                C.X = C1.X;
                C.Y = C1.Y;
                C.Z = C2;

                impulse = K.Solve33(-C);
            }
            else
            {
                float m1 = InvMass1, m2 = InvMass2;
                float i1 = InvI1, i2 = InvI2;

                float k11 = m1 + m2 + i1 * S1 * S1 + i2 * S2 * S2;
                float k12 = i1 * S1 + i2 * S2;
                float k22 = i1 + i2;

                K.Col1.Set(k11, k12, 0.0f);
                K.Col2.Set(k12, k22, 0.0f);

                Vec2 impulse1 = K.Solve22(-C1);
                impulse.X = impulse1.X;
                impulse.Y = impulse1.Y;
                impulse.Z = 0.0f;
            }

            Vec2 P = impulse.X * Perp + impulse.Z * Axis;
            float L1 = impulse.X * S1 + impulse.Y + impulse.Z * A1;
            float L2 = impulse.X * S2 + impulse.Y + impulse.Z * A2;

            c1 -= InvMass1 * P;
            a1 -= InvI1 * L1;
            c2 += InvMass2 * P;
            a2 += InvI2 * L2;

            // TODO_ERIN remove need for this.
            b1.Sweep.C = c1;
            b1.Sweep.A = a1;
            b2.Sweep.C = c2;
            b2.Sweep.A = a2;
            b1.SynchronizeTransform();
            b2.SynchronizeTransform();

            return linearError <= Settings.LinearSlop && angularError <= Settings.AngularSlop;
        }
    }
}