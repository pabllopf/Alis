// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   LineJoint.cs
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
// K = J * invM * JT
//
// J = [-a -s1 a s2]
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
// lower: f2(2) = max(f2(2), 0)
// upper: f2(2) = min(f2(2), 0)
//
// Solve for correct f2(1)
// K(1,1) * f2(1) = -Cdot(1) - K(1,2) * f2(2) + K(1,1:2) * f1
//                = -Cdot(1) - K(1,2) * f2(2) + K(1,1) * f1(1) + K(1,2) * f1(2)
// K(1,1) * f2(1) = -Cdot(1) - K(1,2) * (f2(2) - f1(2)) + K(1,1) * f1(1)
// f2(1) = invK(1,1) * (-Cdot(1) - K(1,2) * (f2(2) - f1(2))) + f1(1)
//
// Now compute impulse to be applied:
// df = f2 - f1

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     A line joint. This joint provides one degree of freedom: translation
    ///     along an axis fixed in body1. You can use a joint limit to restrict
    ///     the range of motion and a joint motor to drive the motion or to
    ///     model joint friction.
    /// </summary>
    public class LineJoint : Joint
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
        ///     The enable limit
        /// </summary>
        public bool EnableLimitx;

        /// <summary>
        ///     The enable motor
        /// </summary>
        public bool EnableMotorx;

        /// <summary>
        ///     The impulse
        /// </summary>
        public Vec2 Impulse;

        /// <summary>
        ///     The
        /// </summary>
        public Mat22 K;

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
        ///     The lower translation
        /// </summary>
        public float LowerTranslation;

        /// <summary>
        ///     The max motor force
        /// </summary>
        public float MaxMotorForce;

        /// <summary>
        ///     The motor impulse
        /// </summary>
        public float MotorImpulse;

        /// <summary>
        ///     The motor mass
        /// </summary>
        public float MotorMass; // effective mass for motor/limit translational constraint.

        /// <summary>
        ///     The motor speed
        /// </summary>
        public float MotorSpeed;

        /// <summary>
        ///     The
        /// </summary>
        public float S1;

        /// <summary>
        ///     The
        /// </summary>
        private float s2;

        /// <summary>
        ///     The upper translation
        /// </summary>
        public float UpperTranslation;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LineJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public LineJoint(LineJointDef def)
            : base(def)
        {
            LocalAnchor1 = def.LocalAnchor1;
            LocalAnchor2 = def.LocalAnchor2;
            LocalXAxis1 = def.LocalAxis1;
            LocalYAxis1 = Vec2.Cross(1.0f, LocalXAxis1);

            Impulse.SetZero();
            MotorMass = 0.0f;
            MotorImpulse = 0.0f;

            LowerTranslation = def.LowerTranslation;
            UpperTranslation = def.UpperTranslation;
            MaxMotorForce = Settings.FORCE_INV_SCALE(def.MaxMotorForce);
            MotorSpeed = def.MotorSpeed;
            EnableLimitx = def.EnableLimit;
            EnableMotorx = def.EnableMotor;
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
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vec</returns>
        public override Vec2 GetReactionForce(float invDt)
        {
            return invDt * (Impulse.X * Perp + (MotorImpulse + Impulse.Y) * Axis);
        }

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt"></param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt)
        {
            return 0.0f;
        }

        /// <summary>
        ///     Get the current joint translation, usually in meters.
        /// </summary>
        public float GetJointTranslation()
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

        /// <summary>
        ///     Get the current joint translation speed, usually in meters per second.
        /// </summary>
        public float GetJointSpeed()
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

        /// <summary>
        ///     Is the joint limit enabled?
        /// </summary>
        public bool IsLimitEnabled()
        {
            return EnableLimitx;
        }

        /// <summary>
        ///     Enable/disable the joint limit.
        /// </summary>
        public void EnableLimit(bool flag)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            EnableLimitx = flag;
        }

        /// <summary>
        ///     Get the lower joint limit, usually in meters.
        /// </summary>
        public float GetLowerLimit()
        {
            return LowerTranslation;
        }

        /// <summary>
        ///     Get the upper joint limit, usually in meters.
        /// </summary>
        public float GetUpperLimit()
        {
            return UpperTranslation;
        }

        /// <summary>
        ///     Set the joint limits, usually in meters.
        /// </summary>
        public void SetLimits(float lower, float upper)
        {
            Box2DxDebug.Assert(lower <= upper);
            Body1.WakeUp();
            Body2.WakeUp();
            LowerTranslation = lower;
            UpperTranslation = upper;
        }

        /// <summary>
        ///     Is the joint motor enabled?
        /// </summary>
        public bool IsMotorEnabled()
        {
            return EnableMotorx;
        }

        /// <summary>
        ///     Enable/disable the joint motor.
        /// </summary>
        public void EnableMotor(bool flag)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            EnableMotorx = flag;
        }

        /// <summary>
        ///     Set the motor speed, usually in meters per second.
        /// </summary>
        public void SetMotorSpeed(float speed)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            MotorSpeed = speed;
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
        ///     Get the current motor force, usually in N.
        /// </summary>
        public float GetMotorForce()
        {
            return MotorImpulse;
        }

        /// <summary>
        ///     Get the motor speed, usually in meters per second.
        /// </summary>
        public float GetMotorSpeed()
        {
            return MotorSpeed;
        }

        /// <summary>
        ///     Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal override void InitVelocityConstraints(TimeStep step)
        {
            Body b1 = Body1;
            Body b2 = Body2;

            LocalCenter1 = b1.GetLocalCenter();
            LocalCenter2 = b2.GetLocalCenter();

            XForm xf1 = b1.GetXForm();
            XForm xf2 = b2.GetXForm();

            // Compute the effective masses.
            Vec2 r1 = Math.Mul(xf1.R, LocalAnchor1 - LocalCenter1);
            Vec2 r2 = Math.Mul(xf2.R, LocalAnchor2 - LocalCenter2);
            Vec2 d = b2.Sweep.C + r2 - b1.Sweep.C - r1;

            InvMass1 = b1.InvMass;
            InvI1 = b1.InvI;
            InvMass2 = b2.InvMass;
            InvI2 = b2.InvI;

            // Compute motor Jacobian and effective mass.
            {
                Axis = Math.Mul(xf1.R, LocalXAxis1);
                A1 = Vec2.Cross(d + r1, Axis);
                A2 = Vec2.Cross(r2, Axis);

                MotorMass = InvMass1 + InvMass2 + InvI1 * A1 * A1 + InvI2 * A2 * A2;
                Box2DxDebug.Assert(MotorMass > Settings.FltEpsilon);
                MotorMass = 1.0f / MotorMass;
            }

            // Prismatic constraint.
            {
                Perp = Math.Mul(xf1.R, LocalYAxis1);

                S1 = Vec2.Cross(d + r1, Perp);
                s2 = Vec2.Cross(r2, Perp);

                float m1 = InvMass1, m2 = InvMass2;
                float i1 = InvI1, i2 = InvI2;

                float k11 = m1 + m2 + i1 * S1 * S1 + i2 * s2 * s2;
                float k12 = i1 * S1 * A1 + i2 * s2 * A2;
                float k22 = m1 + m2 + i1 * A1 * A1 + i2 * A2 * A2;

                K.Col1.Set(k11, k12);
                K.Col2.Set(k12, k22);
            }

            // Compute motor and limit terms.
            if (EnableLimitx)
            {
                float jointTranslation = Vec2.Dot(Axis, d);
                if (Math.Abs(UpperTranslation - LowerTranslation) < 2.0f * Settings.LinearSlop)
                {
                    LimitState = LimitState.EqualLimits;
                }
                else if (jointTranslation <= LowerTranslation)
                {
                    if (LimitState != LimitState.AtLowerLimit)
                    {
                        LimitState = LimitState.AtLowerLimit;
                        Impulse.Y = 0.0f;
                    }
                }
                else if (jointTranslation >= UpperTranslation)
                {
                    if (LimitState != LimitState.AtUpperLimit)
                    {
                        LimitState = LimitState.AtUpperLimit;
                        Impulse.Y = 0.0f;
                    }
                }
                else
                {
                    LimitState = LimitState.InactiveLimit;
                    Impulse.Y = 0.0f;
                }
            }
            else
            {
                LimitState = LimitState.InactiveLimit;
            }

            if (EnableMotorx == false)
            {
                MotorImpulse = 0.0f;
            }

            if (step.WarmStarting)
            {
                // Account for variable time step.
                Impulse *= step.DtRatio;
                MotorImpulse *= step.DtRatio;

                Vec2 p = Impulse.X * Perp + (MotorImpulse + Impulse.Y) * Axis;
                float l1 = Impulse.X * S1 + (MotorImpulse + Impulse.Y) * A1;
                float l2 = Impulse.X * s2 + (MotorImpulse + Impulse.Y) * A2;

                b1.LinearVelocity -= InvMass1 * p;
                b1.AngularVelocity -= InvI1 * l1;

                b2.LinearVelocity += InvMass2 * p;
                b2.AngularVelocity += InvI2 * l2;
            }
            else
            {
                Impulse.SetZero();
                MotorImpulse = 0.0f;
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
            if (EnableMotorx && LimitState != LimitState.EqualLimits)
            {
                float cdot = Vec2.Dot(Axis, v2 - v1) + A2 * w2 - A1 * w1;
                float impulse = MotorMass * (MotorSpeed - cdot);
                float oldImpulse = MotorImpulse;
                float maxImpulse = step.Dt * MaxMotorForce;
                MotorImpulse = Math.Clamp(MotorImpulse + impulse, -maxImpulse, maxImpulse);
                impulse = MotorImpulse - oldImpulse;

                Vec2 p = impulse * Axis;
                float l1 = impulse * A1;
                float l2 = impulse * A2;

                v1 -= InvMass1 * p;
                w1 -= InvI1 * l1;

                v2 += InvMass2 * p;
                w2 += InvI2 * l2;
            }

            float cdot1 = Vec2.Dot(Perp, v2 - v1) + s2 * w2 - S1 * w1;

            if (EnableLimitx && LimitState != LimitState.InactiveLimit)
            {
                // Solve prismatic and limit constraint in block form.
                float cdot2 = Vec2.Dot(Axis, v2 - v1) + A2 * w2 - A1 * w1;
                Vec2 cdot = new Vec2(cdot1, cdot2);

                Vec2 f1 = Impulse;
                Vec2 df = K.Solve(-cdot);
                Impulse += df;

                if (LimitState == LimitState.AtLowerLimit)
                {
                    Impulse.Y = Math.Max(Impulse.Y, 0.0f);
                }
                else if (LimitState == LimitState.AtUpperLimit)
                {
                    Impulse.Y = Math.Min(Impulse.Y, 0.0f);
                }

                // f2(1) = invK(1,1) * (-Cdot(1) - K(1,2) * (f2(2) - f1(2))) + f1(1)
                float b = -cdot1 - (Impulse.Y - f1.Y) * K.Col2.X;
                float f2R = b / K.Col1.X + f1.X;
                Impulse.X = f2R;

                df = Impulse - f1;

                Vec2 p = df.X * Perp + df.Y * Axis;
                float l1 = df.X * S1 + df.Y * A1;
                float l2 = df.X * s2 + df.Y * A2;

                v1 -= InvMass1 * p;
                w1 -= InvI1 * l1;

                v2 += InvMass2 * p;
                w2 += InvI2 * l2;
            }
            else
            {
                // Limit is inactive, just solve the prismatic constraint in block form.
                float df = (-cdot1) / K.Col1.X;
                Impulse.X += df;

                Vec2 p = df * Perp;
                float l1 = df * S1;
                float l2 = df * s2;

                v1 -= InvMass1 * p;
                w1 -= InvI1 * l1;

                v2 += InvMass2 * p;
                w2 += InvI2 * l2;
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

            Vec2 invMass1 = b1.Sweep.C;
            float a1 = b1.Sweep.A;

            Vec2 invMass2 = b2.Sweep.C;
            float a2 = b2.Sweep.A;

            // Solve linear limit constraint.
            float linearError = 0.0f, angularError = 0.0f;
            bool active = false;
            float clamp = 0.0f;

            var mat22 = new Mat22(a1);
            var mat23 = new Mat22(a2);

            Vec2 r1 = Math.Mul(mat22, LocalAnchor1 - LocalCenter1);
            Vec2 r2 = Math.Mul(mat23, LocalAnchor2 - LocalCenter2);
            Vec2 d = invMass2 + r2 - invMass1 - r1;

            if (EnableLimitx)
            {
                Axis = Math.Mul(mat22, LocalXAxis1);

                A1 = Vec2.Cross(d + r1, Axis);
                A2 = Vec2.Cross(r2, Axis);

                float translation = Vec2.Dot(Axis, d);
                if (Math.Abs(UpperTranslation - LowerTranslation) < 2.0f * Settings.LinearSlop)
                {
                    // Prevent large angular corrections
                    clamp = Math.Clamp(translation, -Settings.MaxLinearCorrection, Settings.MaxLinearCorrection);
                    linearError = Math.Abs(translation);
                    active = true;
                }
                else if (translation <= LowerTranslation)
                {
                    // Prevent large linear corrections and allow some slop.
                    clamp = Math.Clamp(translation - LowerTranslation + Settings.LinearSlop,
                        -Settings.MaxLinearCorrection, 0.0f);
                    linearError = LowerTranslation - translation;
                    active = true;
                }
                else if (translation >= UpperTranslation)
                {
                    // Prevent large linear corrections and allow some slop.
                    clamp = Math.Clamp(translation - UpperTranslation - Settings.LinearSlop, 0.0f,
                        Settings.MaxLinearCorrection);
                    linearError = translation - UpperTranslation;
                    active = true;
                }
            }

            Perp = Math.Mul(mat22, LocalYAxis1);

            S1 = Vec2.Cross(d + r1, Perp);
            s2 = Vec2.Cross(r2, Perp);

            Vec2 impulse;
            float c1;
            c1 = Vec2.Dot(Perp, d);

            linearError = Math.Max(linearError, Math.Abs(c1));
            angularError = 0.0f;

            if (active)
            {
                float m1 = InvMass1, m2 = InvMass2;
                float i1 = InvI1, i2 = InvI2;

                float k11 = m1 + m2 + i1 * S1 * S1 + i2 * s2 * s2;
                float k12 = i1 * S1 * A1 + i2 * s2 * A2;
                float k22 = m1 + m2 + i1 * A1 * A1 + i2 * A2 * A2;

                K.Col1.Set(k11, k12);
                K.Col2.Set(k12, k22);

                Vec2 c = new Vec2();
                c.X = c1;
                c.Y = clamp;

                impulse = K.Solve(-c);
            }
            else
            {
                float m1 = InvMass1, m2 = InvMass2;
                float i1 = InvI1, i2 = InvI2;

                float k11 = m1 + m2 + i1 * S1 * S1 + i2 * s2 * s2;

                float impulse1 = (-c1) / k11;
                impulse.X = impulse1;
                impulse.Y = 0.0f;
            }

            Vec2 p = impulse.X * Perp + impulse.Y * Axis;
            float l1 = impulse.X * S1 + impulse.Y * A1;
            float l2 = impulse.X * s2 + impulse.Y * A2;

            invMass1 -= InvMass1 * p;
            a1 -= InvI1 * l1;
            invMass2 += InvMass2 * p;
            a2 += InvI2 * l2;

            // TODO_ERIN remove need for this.
            b1.Sweep.C = invMass1;
            b1.Sweep.A = a1;
            b2.Sweep.C = invMass2;
            b2.Sweep.A = a2;
            b1.SynchronizeTransform();
            b2.SynchronizeTransform();

            return linearError <= Settings.LinearSlop && angularError <= Settings.AngularSlop;
        }
    }
}