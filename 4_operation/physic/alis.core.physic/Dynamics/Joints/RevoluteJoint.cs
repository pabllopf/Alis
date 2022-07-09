// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   RevoluteJoint.cs
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

using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    using Box2DXMath = Math;

    /// <summary>
    ///     A revolute joint constrains to bodies to share a common point while they
    ///     are free to rotate about the point. The relative rotation about the shared
    ///     point is the joint angle. You can limit the relative rotation with
    ///     a joint limit that specifies a lower and upper angle. You can use a motor
    ///     to drive the relative rotation about the shared point. A maximum motor torque
    ///     is provided so that infinite forces are not generated.
    /// </summary>
    public class RevoluteJoint : Joint
    {
        /// <summary>
        ///     The impulse
        /// </summary>
        public Vec3 Impulse { get; set; }

        /// <summary>
        ///     The mass
        /// </summary>
        public Mat33 Mass { get; set; }

        /// <summary>
        ///     The motor speed
        /// </summary>
        private float motorSpeed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RevoluteJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public RevoluteJoint(RevoluteJointDef def)
            : base(def)
        {
            LocalAnchor1 = def.LocalAnchor1;
            LocalAnchor2 = def.LocalAnchor2;
            ReferenceAngle = def.ReferenceAngle;

            Impulse = new Vec3();
            MotorTorque = 0.0f;

            LowerLimit = def.LowerAngle;
            UpperLimit = def.UpperAngle;
            MaxMotorTorque = def.MaxMotorTorque;
            MotorSpeed = def.MotorSpeed;
            IsLimitEnabled = def.EnableLimit;
            IsMotorEnabled = def.EnableMotor;
            State = LimitState.InactiveLimit;
        }

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vec2 LocalAnchor1 { get; }

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vec2 LocalAnchor2 { get; }

        /// <summary>
        ///     The motor mass
        /// </summary>
        public float MotorMass { get; set; }

        /// <summary>
        ///     The max motor torque
        /// </summary>
        public float MaxMotorTorque { get; set; }

        /// <summary>
        ///     The reference angle
        /// </summary>
        public float ReferenceAngle { get; }

        /// <summary>
        ///     The limit state
        /// </summary>
        public LimitState State { get; set; }

        /// <summary>
        ///     Gets the value of the anchor 1
        /// </summary>
        public override Vec2 Anchor1 => Body1.GetWorldPoint(LocalAnchor1);

        /// <summary>
        ///     Gets the value of the anchor 2
        /// </summary>
        public override Vec2 Anchor2 => Body2.GetWorldPoint(LocalAnchor2);

        /// <summary>
        ///     Get the current joint angle in radians.
        /// </summary>
        public float JointAngleX
        {
            get
            {
                Body b1 = Body1;
                Body b2 = Body2;
                return b2.Sweep.A - b1.Sweep.A - ReferenceAngle;
            }
        }


        /// <summary>
        ///     Get the current joint angle speed in radians per second.
        /// </summary>
        public float JointSpeedX
        {
            get
            {
                Body b1 = Body1;
                Body b2 = Body2;
                return b2.AngularVelocity - b1.AngularVelocity;
            }
        }

        /// <summary>
        ///     Is the joint limit enabled?
        /// </summary>
        public bool IsLimitEnabled { get; set; }

        /// <summary>
        ///     Get the lower joint limit in radians.
        /// </summary>
        public float LowerLimit { get; set; }

        /// <summary>
        ///     Get the upper joint limit in radians.
        /// </summary>
        public float UpperLimit { get; set; }

        /// <summary>
        ///     Is the joint motor enabled?
        /// </summary>
        public bool IsMotorEnabled { get; set; }

        /// <summary>
        ///     Get\Set the motor speed in radians per second.
        /// </summary>
        public float MotorSpeed
        {
            get { return motorSpeed; }
            set
            {
                Body1.WakeUp();
                Body2.WakeUp();
                motorSpeed = value;
            }
        }

        /// <summary>
        ///     Get the current motor torque, usually in N-m.
        /// </summary>
        public float MotorTorque { get; set; }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param>The inv dt</param>
        /// <param name="inv_dt"></param>
        /// <returns>The vec</returns>
        public override Vec2 GetReactionForce(float inv_dt)
        {
            Vec2 P = new Vec2(Impulse.X, Impulse.Y);
            return inv_dt * P;
        }

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param>The inv dt</param>
        /// <param name="inv_dt"></param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float inv_dt)
        {
            return inv_dt * Impulse.Z;
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
        ///     Set the joint limits in radians.
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
        ///     Set the maximum motor torque, usually in N-m.
        /// </summary>
        public void SetMaxMotorTorque(float torque)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            MaxMotorTorque = torque;
        }

        /// <summary>
        ///     Inits the velocity constraints using the specified step
        /// </summary>
        /// <param name="step">The step</param>
        internal override void InitVelocityConstraints(TimeStep step)
        {
            Body b1 = Body1;
            Body b2 = Body2;

            if (IsMotorEnabled || IsLimitEnabled)
            {
                // You cannot create a rotation limit between bodies that
                // both have fixed rotation.
                Box2DXDebug.Assert(b1.InvI > 0.0f || b2.InvI > 0.0f);
            }

            // Compute the effective mass matrix.
            Vec2 r1 = Box2DXMath.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
            Vec2 r2 = Box2DXMath.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

            // J = [-I -r1_skew I r2_skew]
            //     [ 0       -1 0       1]
            // r_skew = [-ry; rx]

            // Matlab
            // K = [ m1+r1y^2*i1+m2+r2y^2*i2,  -r1y*i1*r1x-r2y*i2*r2x,          -r1y*i1-r2y*i2]
            //     [  -r1y*i1*r1x-r2y*i2*r2x, m1+r1x^2*i1+m2+r2x^2*i2,           r1x*i1+r2x*i2]
            //     [          -r1y*i1-r2y*i2,           r1x*i1+r2x*i2,                   i1+i2]

            float m1 = b1.InvMass, m2 = b2.InvMass;
            float i1 = b1.InvI, i2 = b2.InvI;


            float col1x = m1 + m2 + r1.Y * r1.Y * i1 + r2.Y * r2.Y * i2;
            float col2x = -r1.Y * r1.X * i1 - r2.Y * r2.X * i2;
            float col3x = -r1.Y * i1 - r2.Y * i2;

            float col1y = Mass.Col2.X;
            float col2y = m1 + m2 + r1.X * r1.X * i1 + r2.X * r2.X * i2;
            float col3y = r1.X * i1 + r2.X * i2;

            float col1z = Mass.Col3.X;
            float col2z = Mass.Col3.Y;
            float col3z = i1 + i2;
            
            Mass = new Mat33(new Vec3(col1x, col1y, col1z), new Vec3(col2x, col2y, col2z), new Vec3(col3x, col3y, col3z));
            
            /*
			_mass.Col1.X = m1 + m2 + r1.Y * r1.Y * i1 + r2.Y * r2.Y * i2;
			_mass.Col2.X = -r1.Y * r1.X * i1 - r2.Y * r2.X * i2;
			_mass.Col3.X = -r1.Y * i1 - r2.Y * i2;
			_mass.Col1.Y = _mass.Col2.X;
			_mass.Col2.Y = m1 + m2 + r1.X * r1.X * i1 + r2.X * r2.X * i2;
			_mass.Col3.Y = r1.X * i1 + r2.X * i2;
			_mass.Col1.Z = _mass.Col3.X;
			_mass.Col2.Z = _mass.Col3.Y;
			_mass.Col3.Z = i1 + i2;
*/
            MotorMass = 1.0f / (i1 + i2);

            if (IsMotorEnabled == false)
            {
                MotorTorque = 0.0f;
            }

            if (IsLimitEnabled)
            {
                float jointAngle = b2.Sweep.A - b1.Sweep.A - ReferenceAngle;
                if (Box2DXMath.Abs(UpperLimit - LowerLimit) < 2.0f * Settings.AngularSlop)
                {
                    State = LimitState.EqualLimits;
                }
                else if (jointAngle <= LowerLimit)
                {
                    if (State != LimitState.AtLowerLimit)
                    {
                        Impulse = new Vec3(Impulse.X, Impulse.Y, 0.0f);
                    }

                    State = LimitState.AtLowerLimit;
                }
                else if (jointAngle >= UpperLimit)
                {
                    if (State != LimitState.AtUpperLimit)
                    {
                        Impulse = new Vec3(Impulse.X, Impulse.Y, 0.0f);
                    }

                    State = LimitState.AtUpperLimit;
                }
                else
                {
                    State = LimitState.InactiveLimit;
                    Impulse = new Vec3(Impulse.X, Impulse.Y, 0.0f);
                }
            }
            else
            {
                State = LimitState.InactiveLimit;
            }

            if (step.WarmStarting)
            {
                // Scale impulses to support a variable time step.
                Impulse *= step.DtRatio;
                MotorTorque *= step.DtRatio;

                Vec2 P = new Vec2(Impulse.X, Impulse.Y);

                b1.LinearVelocity -= m1 * P;
                b1.AngularVelocity -= i1 * (Vec2.Cross(r1, P) + MotorTorque + Impulse.Z);

                b2.LinearVelocity += m2 * P;
                b2.AngularVelocity += i2 * (Vec2.Cross(r2, P) + MotorTorque + Impulse.Z);
            }
            else
            {
                Impulse.SetZero();
                MotorTorque = 0.0f;
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

            float m1 = b1.InvMass, m2 = b2.InvMass;
            float i1 = b1.InvI, i2 = b2.InvI;

            //Solve motor constraint.
            if (IsMotorEnabled && State != LimitState.EqualLimits)
            {
                float Cdot = w2 - w1 - MotorSpeed;
                float impulse = MotorMass * -Cdot;
                float oldImpulse = MotorTorque;
                float maxImpulse = step.Dt * MaxMotorTorque;
                MotorTorque = Box2DXMath.Clamp(MotorTorque + impulse, -maxImpulse, maxImpulse);
                impulse = MotorTorque - oldImpulse;

                w1 -= i1 * impulse;
                w2 += i2 * impulse;
            }

            //Solve limit constraint.
            if (IsLimitEnabled && State != LimitState.InactiveLimit)
            {
                Vec2 r1 = Box2DXMath.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
                Vec2 r2 = Box2DXMath.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

                // Solve point-to-point constraint
                Vec2 Cdot1 = v2 + Vec2.Cross(w2, r2) - v1 - Vec2.Cross(w1, r1);
                float Cdot2 = w2 - w1;
                Vec3 Cdot = new Vec3(Cdot1.X, Cdot1.Y, Cdot2);

                Vec3 impulse = Mass.Solve33(-Cdot);

                if (State == LimitState.EqualLimits)
                {
                    Impulse += impulse;
                }
                else if (State == LimitState.AtLowerLimit)
                {
                    float newImpulse = Impulse.Z + impulse.Z;
                    if (newImpulse < 0.0f)
                    {
                        Vec2 reduced = Mass.Solve22(-Cdot1);
                        impulse.X = reduced.X;
                        impulse.Y = reduced.Y;
                        impulse.Z = -Impulse.Z;
                        Impulse = new Vec3(reduced.X, reduced.Y, 0.0f);
                    }
                }
                else if (State == LimitState.AtUpperLimit)
                {
                    float newImpulse = Impulse.Z + impulse.Z;
                    if (newImpulse > 0.0f)
                    {
                        Vec2 reduced = Mass.Solve22(-Cdot1);
                        impulse.X = reduced.X;
                        impulse.Y = reduced.Y;
                        impulse.Z = -Impulse.Z;
                        Impulse = new Vec3(reduced.X, reduced.Y, 0.0f);
                    }
                }

                Vec2 P = new Vec2(impulse.X, impulse.Y);

                v1 -= m1 * P;
                w1 -= i1 * (Vec2.Cross(r1, P) + impulse.Z);

                v2 += m2 * P;
                w2 += i2 * (Vec2.Cross(r2, P) + impulse.Z);
            }
            else
            {
                Vec2 r1 = Box2DXMath.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
                Vec2 r2 = Box2DXMath.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

                // Solve point-to-point constraint
                Vec2 Cdot = v2 + Vec2.Cross(w2, r2) - v1 - Vec2.Cross(w1, r1);
                Vec2 impulse = Mass.Solve22(-Cdot);
                
                Impulse = new Vec3(impulse.X, impulse.Y, Impulse.Z);

                v1 -= m1 * impulse;
                w1 -= i1 * Vec2.Cross(r1, impulse);

                v2 += m2 * impulse;
                w2 += i2 * Vec2.Cross(r2, impulse);
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
            // TODO_ERIN block solve with limit.

            Body b1 = Body1;
            Body b2 = Body2;

            float angularError = 0.0f;
            float positionError = 0.0f;

            // Solve angular limit constraint.
            if (IsLimitEnabled && State != LimitState.InactiveLimit)
            {
                float angle = b2.Sweep.A - b1.Sweep.A - ReferenceAngle;
                float limitImpulse = 0.0f;

                if (State == LimitState.EqualLimits)
                {
                    // Prevent large angular corrections
                    float C = Box2DXMath.Clamp(angle, -Settings.MaxAngularCorrection, Settings.MaxAngularCorrection);
                    limitImpulse = -MotorMass * C;
                    angularError = Box2DXMath.Abs(C);
                }
                else if (State == LimitState.AtLowerLimit)
                {
                    float C = angle - LowerLimit;
                    angularError = -C;

                    // Prevent large angular corrections and allow some slop.
                    C = Box2DXMath.Clamp(C + Settings.AngularSlop, -Settings.MaxAngularCorrection, 0.0f);
                    limitImpulse = -MotorMass * C;
                }
                else if (State == LimitState.AtUpperLimit)
                {
                    float C = angle - UpperLimit;
                    angularError = C;

                    // Prevent large angular corrections and allow some slop.
                    C = Box2DXMath.Clamp(C - Settings.AngularSlop, 0.0f, Settings.MaxAngularCorrection);
                    limitImpulse = -MotorMass * C;
                }

                b1.Sweep.A -= b1.InvI * limitImpulse;
                b2.Sweep.A += b2.InvI * limitImpulse;

                b1.SynchronizeTransform();
                b2.SynchronizeTransform();
            }

            // Solve point-to-point constraint.
            {
                Vec2 r1 = Box2DXMath.Mul(b1.GetXForm().R, LocalAnchor1 - b1.GetLocalCenter());
                Vec2 r2 = Box2DXMath.Mul(b2.GetXForm().R, LocalAnchor2 - b2.GetLocalCenter());

                Vec2 C = b2.Sweep.C + r2 - b1.Sweep.C - r1;
                positionError = C.Length();

                float invMass1 = b1.InvMass, invMass2 = b2.InvMass;
                float invI1 = b1.InvI, invI2 = b2.InvI;

                // Handle large detachment.
                float k_allowedStretch = 10.0f * Settings.LinearSlop;
                if (C.LengthSquared() > k_allowedStretch * k_allowedStretch)
                {
                    // Use a particle solution (no rotation).
                    Vec2 u = C;
                    u.Normalize();
                    float k = invMass1 + invMass2;
                    Box2DXDebug.Assert(k > Settings.FltEpsilon);
                    float m = 1.0f / k;
                    Vec2 impulse = m * -C;
                    float k_beta = 0.5f;
                    b1.Sweep.C -= k_beta * invMass1 * impulse;
                    b2.Sweep.C += k_beta * invMass2 * impulse;

                    C = b2.Sweep.C + r2 - b1.Sweep.C - r1;
                }

                Mat22 K1 = new Mat22();
                K1.col1.X = invMass1 + invMass2;
                K1.col2.X = 0.0f;
                K1.col1.Y = 0.0f;
                K1.col2.Y = invMass1 + invMass2;

                Mat22 K2 = new Mat22();
                K2.col1.X = invI1 * r1.Y * r1.Y;
                K2.col2.X = -invI1 * r1.X * r1.Y;
                K2.col1.Y = -invI1 * r1.X * r1.Y;
                K2.col2.Y = invI1 * r1.X * r1.X;

                Mat22 K3 = new Mat22();
                K3.col1.X = invI2 * r2.Y * r2.Y;
                K3.col2.X = -invI2 * r2.X * r2.Y;
                K3.col1.Y = -invI2 * r2.X * r2.Y;
                K3.col2.Y = invI2 * r2.X * r2.X;

                Mat22 K = K1 + K2 + K3;
                Vec2 impulse_ = K.Solve(-C);

                b1.Sweep.C -= b1.InvMass * impulse_;
                b1.Sweep.A -= b1.InvI * Vec2.Cross(r1, impulse_);

                b2.Sweep.C += b2.InvMass * impulse_;
                b2.Sweep.A += b2.InvI * Vec2.Cross(r2, impulse_);

                b1.SynchronizeTransform();
                b2.SynchronizeTransform();
            }

            return positionError <= Settings.LinearSlop && angularError <= Settings.AngularSlop;
        }
    }
}