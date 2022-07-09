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
        public float _a1, _a2;

        /// <summary>
        ///     The perp
        /// </summary>
        public Vec2 _axis, _perp;

        /// <summary>
        ///     The enable limit
        /// </summary>
        public bool _enableLimit;

        /// <summary>
        ///     The enable motor
        /// </summary>
        public bool _enableMotor;

        /// <summary>
        ///     The impulse
        /// </summary>
        public Vec3 _impulse;

        /// <summary>
        ///     The
        /// </summary>
        public Mat33 _K;

        /// <summary>
        ///     The limit state
        /// </summary>
        public LimitState _limitState;

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vec2 _localAnchor1;

        /// <summary>
        ///     The local anchor
        /// </summary>
        public Vec2 _localAnchor2;

        /// <summary>
        ///     The local axis
        /// </summary>
        public Vec2 _localXAxis1;

        /// <summary>
        ///     The local axis
        /// </summary>
        public Vec2 _localYAxis1;

        /// <summary>
        ///     The lower translation
        /// </summary>
        public float _lowerTranslation;

        /// <summary>
        ///     The max motor force
        /// </summary>
        public float _maxMotorForce;

        /// <summary>
        ///     The motor impulse
        /// </summary>
        public float _motorImpulse;

        /// <summary>
        ///     The motor mass
        /// </summary>
        public float _motorMass; // effective mass for motor/limit translational constraint.

        /// <summary>
        ///     The motor speed
        /// </summary>
        public float _motorSpeed;

        /// <summary>
        ///     The ref angle
        /// </summary>
        public float _refAngle;

        /// <summary>
        ///     The
        /// </summary>
        public float _s1, _s2;

        /// <summary>
        ///     The upper translation
        /// </summary>
        public float _upperTranslation;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PrismaticJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public PrismaticJoint(PrismaticJointDef def)
            : base(def)
        {
            _localAnchor1 = def.LocalAnchor1;
            _localAnchor2 = def.LocalAnchor2;
            _localXAxis1 = def.LocalAxis1;
            _localYAxis1 = Vec2.Cross(1.0f, _localXAxis1);
            _refAngle = def.ReferenceAngle;

            _impulse.SetZero();
            _motorMass = 0.0f;
            _motorImpulse = 0.0f;

            _lowerTranslation = def.LowerTranslation;
            _upperTranslation = def.UpperTranslation;
            _maxMotorForce = Settings.FORCE_INV_SCALE(def.MaxMotorForce);
            _motorSpeed = def.MotorSpeed;
            _enableLimit = def.EnableLimit;
            _enableMotor = def.EnableMotor;
            _limitState = LimitState.InactiveLimit;

            _axis.SetZero();
            _perp.SetZero();
        }

        /// <summary>
        ///     Gets the value of the anchor 1
        /// </summary>
        public override Vec2 Anchor1 => Body1.GetWorldPoint(_localAnchor1);

        /// <summary>
        ///     Gets the value of the anchor 2
        /// </summary>
        public override Vec2 Anchor2 => Body2.GetWorldPoint(_localAnchor2);

        /// <summary>
        ///     Get the current joint translation, usually in meters.
        /// </summary>
        public float JointTranslation
        {
            get
            {
                Body b1 = Body1;
                Body b2 = Body2;

                Vec2 p1 = b1.GetWorldPoint(_localAnchor1);
                Vec2 p2 = b2.GetWorldPoint(_localAnchor2);
                Vec2 d = p2 - p1;
                Vec2 axis = b1.GetWorldVector(_localXAxis1);

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

                Vec2 r1 = Math.Mul(b1.GetXForm().R, _localAnchor1 - b1.GetLocalCenter());
                Vec2 r2 = Math.Mul(b2.GetXForm().R, _localAnchor2 - b2.GetLocalCenter());
                Vec2 p1 = b1.Sweep.C + r1;
                Vec2 p2 = b2.Sweep.C + r2;
                Vec2 d = p2 - p1;
                Vec2 axis = b1.GetWorldVector(_localXAxis1);

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
        public bool IsLimitEnabled => _enableLimit;

        /// <summary>
        ///     Get the lower joint limit, usually in meters.
        /// </summary>
        public float LowerLimit => _lowerTranslation;

        /// <summary>
        ///     Get the upper joint limit, usually in meters.
        /// </summary>
        public float UpperLimit => _upperTranslation;

        /// <summary>
        ///     Is the joint motor enabled?
        /// </summary>
        public bool IsMotorEnabled => _enableMotor;

        /// <summary>
        ///     Get\Set the motor speed, usually in meters per second.
        /// </summary>
        public float MotorSpeed
        {
            get { return _motorSpeed; }
            set
            {
                Body1.WakeUp();
                Body2.WakeUp();
                _motorSpeed = value;
            }
        }

        /// <summary>
        ///     Get the current motor force, usually in N.
        /// </summary>
        public float MotorForce => _motorImpulse;

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="inv_dt">The inv dt</param>
        /// <returns>The vec</returns>
        public override Vec2 GetReactionForce(float inv_dt)
        {
            return inv_dt * (_impulse.X * _perp + (_motorImpulse + _impulse.Z) * _axis);
        }

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="inv_dt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float inv_dt)
        {
            return inv_dt * _impulse.Y;
        }

        /// <summary>
        ///     Enable/disable the joint limit.
        /// </summary>
        public void EnableLimit(bool flag)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            _enableLimit = flag;
        }

        /// <summary>
        ///     Set the joint limits, usually in meters.
        /// </summary>
        public void SetLimits(float lower, float upper)
        {
            Box2DXDebug.Assert(lower <= upper);
            Body1.WakeUp();
            Body2.WakeUp();
            _lowerTranslation = lower;
            _upperTranslation = upper;
        }

        /// <summary>
        ///     Enable/disable the joint motor.
        /// </summary>
        public void EnableMotor(bool flag)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            _enableMotor = flag;
        }

        /// <summary>
        ///     Set the maximum motor force, usually in N.
        /// </summary>
        public void SetMaxMotorForce(float force)
        {
            Body1.WakeUp();
            Body2.WakeUp();
            _maxMotorForce = Settings.FORCE_SCALE(1.0f) * force;
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
            Vec2 r1 = Box2DXMath.Mul(xf1.R, _localAnchor1 - LocalCenter1);
            Vec2 r2 = Box2DXMath.Mul(xf2.R, _localAnchor2 - LocalCenter2);
            Vec2 d = b2.Sweep.C + r2 - b1.Sweep.C - r1;

            InvMass1 = b1.InvMass;
            InvI1 = b1.InvI;
            InvMass2 = b2.InvMass;
            InvI2 = b2.InvI;

            // Compute motor Jacobian and effective mass.
            {
                _axis = Box2DXMath.Mul(xf1.R, _localXAxis1);
                _a1 = Vec2.Cross(d + r1, _axis);
                _a2 = Vec2.Cross(r2, _axis);

                _motorMass = InvMass1 + InvMass2 + InvI1 * _a1 * _a1 + InvI2 * _a2 * _a2;
                Box2DXDebug.Assert(_motorMass > Settings.FltEpsilon);
                _motorMass = 1.0f / _motorMass;
            }

            // Prismatic constraint.
            {
                _perp = Box2DXMath.Mul(xf1.R, _localYAxis1);

                _s1 = Vec2.Cross(d + r1, _perp);
                _s2 = Vec2.Cross(r2, _perp);

                float m1 = InvMass1, m2 = InvMass2;
                float i1 = InvI1, i2 = InvI2;

                float k11 = m1 + m2 + i1 * _s1 * _s1 + i2 * _s2 * _s2;
                float k12 = i1 * _s1 + i2 * _s2;
                float k13 = i1 * _s1 * _a1 + i2 * _s2 * _a2;
                float k22 = i1 + i2;
                float k23 = i1 * _a1 + i2 * _a2;
                float k33 = m1 + m2 + i1 * _a1 * _a1 + i2 * _a2 * _a2;

                _K.Col1.Set(k11, k12, k13);
                _K.Col2.Set(k12, k22, k23);
                _K.Col3.Set(k13, k23, k33);
            }

            // Compute motor and limit terms.
            if (_enableLimit)
            {
                float jointTranslation = Vec2.Dot(_axis, d);
                if (Box2DXMath.Abs(_upperTranslation - _lowerTranslation) < 2.0f * Settings.LinearSlop)
                {
                    _limitState = LimitState.EqualLimits;
                }
                else if (jointTranslation <= _lowerTranslation)
                {
                    if (_limitState != LimitState.AtLowerLimit)
                    {
                        _limitState = LimitState.AtLowerLimit;
                        _impulse.Z = 0.0f;
                    }
                }
                else if (jointTranslation >= _upperTranslation)
                {
                    if (_limitState != LimitState.AtUpperLimit)
                    {
                        _limitState = LimitState.AtUpperLimit;
                        _impulse.Z = 0.0f;
                    }
                }
                else
                {
                    _limitState = LimitState.InactiveLimit;
                    _impulse.Z = 0.0f;
                }
            }
            else
            {
                _limitState = LimitState.InactiveLimit;
            }

            if (_enableMotor == false)
            {
                _motorImpulse = 0.0f;
            }

            if (step.WarmStarting)
            {
                // Account for variable time step.
                _impulse *= step.DtRatio;
                _motorImpulse *= step.DtRatio;

                Vec2 P = _impulse.X * _perp + (_motorImpulse + _impulse.Z) * _axis;
                float L1 = _impulse.X * _s1 + _impulse.Y + (_motorImpulse + _impulse.Z) * _a1;
                float L2 = _impulse.X * _s2 + _impulse.Y + (_motorImpulse + _impulse.Z) * _a2;

                b1.LinearVelocity -= InvMass1 * P;
                b1.AngularVelocity -= InvI1 * L1;

                b2.LinearVelocity += InvMass2 * P;
                b2.AngularVelocity += InvI2 * L2;
            }
            else
            {
                _impulse.SetZero();
                _motorImpulse = 0.0f;
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
            if (_enableMotor && _limitState != LimitState.EqualLimits)
            {
                float Cdot = Vec2.Dot(_axis, v2 - v1) + _a2 * w2 - _a1 * w1;
                float impulse = _motorMass * (_motorSpeed - Cdot);
                float oldImpulse = _motorImpulse;
                float maxImpulse = step.Dt * _maxMotorForce;
                _motorImpulse = Box2DXMath.Clamp(_motorImpulse + impulse, -maxImpulse, maxImpulse);
                impulse = _motorImpulse - oldImpulse;

                Vec2 P = impulse * _axis;
                float L1 = impulse * _a1;
                float L2 = impulse * _a2;

                v1 -= InvMass1 * P;
                w1 -= InvI1 * L1;

                v2 += InvMass2 * P;
                w2 += InvI2 * L2;
            }

            Vec2 Cdot1;
            Cdot1.X = Vec2.Dot(_perp, v2 - v1) + _s2 * w2 - _s1 * w1;
            Cdot1.Y = w2 - w1;

            if (_enableLimit && _limitState != LimitState.InactiveLimit)
            {
                // Solve prismatic and limit constraint in block form.
                float Cdot2;
                Cdot2 = Vec2.Dot(_axis, v2 - v1) + _a2 * w2 - _a1 * w1;
                Vec3 Cdot = new Vec3(Cdot1.X, Cdot1.Y, Cdot2);

                Vec3 f1 = _impulse;
                Vec3 df = _K.Solve33(-Cdot);
                _impulse += df;

                if (_limitState == LimitState.AtLowerLimit)
                {
                    _impulse.Z = Box2DXMath.Max(_impulse.Z, 0.0f);
                }
                else if (_limitState == LimitState.AtUpperLimit)
                {
                    _impulse.Z = Box2DXMath.Min(_impulse.Z, 0.0f);
                }

                // f2(1:2) = invK(1:2,1:2) * (-Cdot(1:2) - K(1:2,3) * (f2(3) - f1(3))) + f1(1:2)
                Vec2 b = -Cdot1 - (_impulse.Z - f1.Z) * new Vec2(_K.Col3.X, _K.Col3.Y);
                Vec2 f2r = _K.Solve22(b) + new Vec2(f1.X, f1.Y);
                _impulse.X = f2r.X;
                _impulse.Y = f2r.Y;

                df = _impulse - f1;

                Vec2 P = df.X * _perp + df.Z * _axis;
                float L1 = df.X * _s1 + df.Y + df.Z * _a1;
                float L2 = df.X * _s2 + df.Y + df.Z * _a2;

                v1 -= InvMass1 * P;
                w1 -= InvI1 * L1;

                v2 += InvMass2 * P;
                w2 += InvI2 * L2;
            }
            else
            {
                // Limit is inactive, just solve the prismatic constraint in block form.
                Vec2 df = _K.Solve22(-Cdot1);
                _impulse.X += df.X;
                _impulse.Y += df.Y;

                Vec2 P = df.X * _perp;
                float L1 = df.X * _s1 + df.Y;
                float L2 = df.X * _s2 + df.Y;

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

            Vec2 r1 = Box2DXMath.Mul(R1, _localAnchor1 - LocalCenter1);
            Vec2 r2 = Box2DXMath.Mul(R2, _localAnchor2 - LocalCenter2);
            Vec2 d = c2 + r2 - c1 - r1;

            if (_enableLimit)
            {
                _axis = Box2DXMath.Mul(R1, _localXAxis1);

                _a1 = Vec2.Cross(d + r1, _axis);
                _a2 = Vec2.Cross(r2, _axis);

                float translation = Vec2.Dot(_axis, d);
                if (Box2DXMath.Abs(_upperTranslation - _lowerTranslation) < 2.0f * Settings.LinearSlop)
                {
                    // Prevent large angular corrections
                    C2 = Box2DXMath.Clamp(translation, -Settings.MaxLinearCorrection, Settings.MaxLinearCorrection);
                    linearError = Box2DXMath.Abs(translation);
                    active = true;
                }
                else if (translation <= _lowerTranslation)
                {
                    // Prevent large linear corrections and allow some slop.
                    C2 = Box2DXMath.Clamp(translation - _lowerTranslation + Settings.LinearSlop,
                        -Settings.MaxLinearCorrection, 0.0f);
                    linearError = _lowerTranslation - translation;
                    active = true;
                }
                else if (translation >= _upperTranslation)
                {
                    // Prevent large linear corrections and allow some slop.
                    C2 = Box2DXMath.Clamp(translation - _upperTranslation - Settings.LinearSlop, 0.0f,
                        Settings.MaxLinearCorrection);
                    linearError = translation - _upperTranslation;
                    active = true;
                }
            }

            _perp = Box2DXMath.Mul(R1, _localYAxis1);

            _s1 = Vec2.Cross(d + r1, _perp);
            _s2 = Vec2.Cross(r2, _perp);

            Vec3 impulse;
            Vec2 C1 = new Vec2();
            C1.X = Vec2.Dot(_perp, d);
            C1.Y = a2 - a1 - _refAngle;

            linearError = Box2DXMath.Max(linearError, Box2DXMath.Abs(C1.X));
            angularError = Box2DXMath.Abs(C1.Y);

            if (active)
            {
                float m1 = InvMass1, m2 = InvMass2;
                float i1 = InvI1, i2 = InvI2;

                float k11 = m1 + m2 + i1 * _s1 * _s1 + i2 * _s2 * _s2;
                float k12 = i1 * _s1 + i2 * _s2;
                float k13 = i1 * _s1 * _a1 + i2 * _s2 * _a2;
                float k22 = i1 + i2;
                float k23 = i1 * _a1 + i2 * _a2;
                float k33 = m1 + m2 + i1 * _a1 * _a1 + i2 * _a2 * _a2;

                _K.Col1.Set(k11, k12, k13);
                _K.Col2.Set(k12, k22, k23);
                _K.Col3.Set(k13, k23, k33);

                Vec3 C = new Vec3();
                C.X = C1.X;
                C.Y = C1.Y;
                C.Z = C2;

                impulse = _K.Solve33(-C);
            }
            else
            {
                float m1 = InvMass1, m2 = InvMass2;
                float i1 = InvI1, i2 = InvI2;

                float k11 = m1 + m2 + i1 * _s1 * _s1 + i2 * _s2 * _s2;
                float k12 = i1 * _s1 + i2 * _s2;
                float k22 = i1 + i2;

                _K.Col1.Set(k11, k12, 0.0f);
                _K.Col2.Set(k12, k22, 0.0f);

                Vec2 impulse1 = _K.Solve22(-C1);
                impulse.X = impulse1.X;
                impulse.Y = impulse1.Y;
                impulse.Z = 0.0f;
            }

            Vec2 P = impulse.X * _perp + impulse.Z * _axis;
            float L1 = impulse.X * _s1 + impulse.Y + impulse.Z * _a1;
            float L2 = impulse.X * _s2 + impulse.Y + impulse.Z * _a2;

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