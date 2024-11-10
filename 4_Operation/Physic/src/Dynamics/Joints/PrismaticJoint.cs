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

using System;
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     A prismatic joint. This joint provides one degree of freedom: translation
    ///     along an axis fixed in bodyA. Relative rotation is prevented. You can
    ///     use a joint limit to restrict the range of motion and a joint motor to
    ///     drive the motion or to model joint friction.
    /// </summary>
    /// <remarks>
    ///     Linear constraint (point-to-line)
    ///     d = p2 - p1 = x2 + r2 - x1 - r1
    ///     C = dot(perp, d)
    ///     Cdot = dot(d, cross(w1, perp)) + dot(perp, v2 + cross(w2, r2) - v1 - cross(w1, r1))
    ///     = -dot(perp, v1) - dot(cross(d + r1, perp), w1) + dot(perp, v2) + dot(cross(r2, perp), v2)
    ///     J = [-perp, -cross(d + r1, perp), perp, cross(r2,perp)]
    ///     Angular constraint
    ///     C = a2 - a1 + a_initial
    ///     Cdot = w2 - w1
    ///     J = [0 0 -1 0 0 1]
    ///     K = J * invM * JT
    ///     J = [-a -s1 a s2]
    ///     [0  -1  0  1]
    ///     a = perp
    ///     s1 = cross(d + r1, a) = cross(p2 - x1, a)
    ///     s2 = cross(r2, a) = cross(p2 - x2, a)
    ///     Motor/Limit linear constraint
    ///     C = dot(ax1, d)
    ///     Cdot = = -dot(ax1, v1) - dot(cross(d + r1, ax1), w1) + dot(ax1, v2) + dot(cross(r2, ax1), v2)
    ///     J = [-ax1 -cross(d+r1,ax1) ax1 cross(r2,ax1)]
    ///     Block Solver
    ///     We develop a block solver that includes the joint limit. This makes the limit stiff (inelastic) even
    ///     when the mass has poor distribution (leading to large torques about the joint anchor points).
    ///     The Jacobian has 3 rows:
    ///     J = [-uT -s1 uT s2] // linear
    ///     [0   -1   0  1] // angular
    ///     [-vT -a1 vT a2] // limit
    ///     u = perp
    ///     v = axis
    ///     s1 = cross(d + r1, u), s2 = cross(r2, u)
    ///     a1 = cross(d + r1, v), a2 = cross(r2, v)
    ///     M * (v2 - v1) = JT * df
    ///     J * v2 = bias
    ///     v2 = v1 + invM * JT * df
    ///     J * (v1 + invM * JT * df) = bias
    ///     K * df = bias - J * v1 = -Cdot
    ///     K = J * invM * JT
    ///     Cdot = J * v1 - bias
    ///     Now solve for f2.
    ///     df = f2 - f1
    ///     K * (f2 - f1) = -Cdot
    ///     f2 = invK * (-Cdot) + f1
    ///     Clamp accumulated limit impulse.
    ///     lower: f2(3) = max(f2(3), 0)
    ///     upper: f2(3) = min(f2(3), 0)
    ///     Solve for correct f2(1:2)
    ///     K(1:2, 1:2) * f2(1:2) = -Cdot(1:2) - K(1:2,3) * f2(3) + K(1:2,1:3) * f1
    ///     = -Cdot(1:2) - K(1:2,3) * f2(3) + K(1:2,1:2) * f1(1:2) + K(1:2,3) * f1(3)
    ///     K(1:2, 1:2) * f2(1:2) = -Cdot(1:2) - K(1:2,3) * (f2(3) - f1(3)) + K(1:2,1:2) * f1(1:2)
    ///     f2(1:2) = invK(1:2,1:2) * (-Cdot(1:2) - K(1:2,3) * (f2(3) - f1(3))) + f1(1:2)
    ///     Now compute impulse to be applied:
    ///     df = f2 - f1
    /// </remarks>
    public class PrismaticJoint : Joint
    {
        /// <summary>
        ///     The
        /// </summary>
        private float _a1, _a2;

        /// <summary>
        ///     The perp
        /// </summary>
        private Vector2 _axis, _perp;

        /// <summary>
        ///     The axis
        /// </summary>
        private Vector2 _axis1;

        /// <summary>
        ///     The enable limit
        /// </summary>
        private bool _enableLimit;

        /// <summary>
        ///     The enable motor
        /// </summary>
        private bool _enableMotor;

        /// <summary>
        ///     The impulse
        /// </summary>
        private Vector3 _impulse;

        // Solver temp
        /// <summary>
        ///     The index
        /// </summary>
        private int _indexA;

        /// <summary>
        ///     The index
        /// </summary>
        private int _indexB;

        /// <summary>
        ///     The inv mass
        /// </summary>
        private float _invMassA;

        /// <summary>
        ///     The inv mass
        /// </summary>
        private float _invMassB;

        /// <summary>
        ///     The limit state
        /// </summary>
        private LimitState _limitState;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 _localCenterA;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 _localCenterB;

        /// <summary>
        ///     The local axis
        /// </summary>
        private Vector2 _localXAxis;

        /// <summary>
        ///     The local axis
        /// </summary>
        private Vector2 _localYAxisA;

        /// <summary>
        ///     The lower translation
        /// </summary>
        private float _lowerTranslation;

        /// <summary>
        ///     The max motor force
        /// </summary>
        private float _maxMotorForce;

        /// <summary>
        ///     The motor mass
        /// </summary>
        private float _motorMass;

        /// <summary>
        ///     The motor speed
        /// </summary>
        private float _motorSpeed;

        /// <summary>
        ///     The
        /// </summary>
        private float _s1, _s2;

        /// <summary>
        ///     The upper translation
        /// </summary>
        private float _upperTranslation;

        /// <summary>
        ///     The inv ia
        /// </summary>
        private float invIa;

        /// <summary>
        ///     The inv ib
        /// </summary>
        private float invIb;

        /// <summary>
        ///     The
        /// </summary>
        private Mat33 k;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PrismaticJoint" /> class
        /// </summary>
        internal PrismaticJoint() => JointType = JointType.Prismatic;

        /// <summary>
        ///     This requires defining a line of
        ///     motion using an axis and an anchor point. The definition uses local
        ///     anchor points and a local axis so that the initial configuration
        ///     can violate the constraint slightly. The joint translation is zero
        ///     when the local anchor points coincide in world space. Using local
        ///     anchors and a local axis helps when saving and loading a game.
        /// </summary>
        /// <param name="bodyA">The first body.</param>
        /// <param name="bodyB">The second body.</param>
        /// <param name="anchorA">The first body anchor.</param>
        /// <param name="anchorB">The second body anchor.</param>
        /// <param name="axis">The axis.</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public PrismaticJoint(Body bodyA, Body bodyB, Vector2 anchorA, Vector2 anchorB, Vector2 axis, bool useWorldCoordinates = false)
            : base(bodyA, bodyB)
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
            : base(bodyA, bodyB)
        {
            Initialize(anchor, anchor, axis, useWorldCoordinates);
        }

        /// <summary>
        ///     The local anchor point on BodyA
        /// </summary>
        public Vector2 LocalAnchorA { get; set; }

        /// <summary>
        ///     The local anchor point on BodyB
        /// </summary>
        public Vector2 LocalAnchorB { get; set; }

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

        /// <summary>
        ///     Get the current joint translation, usually in meters.
        /// </summary>
        /// <value></value>
        public float JointTranslation
        {
            get
            {
                Vector2 d = BodyB.GetWorldPoint(LocalAnchorB) - BodyA.GetWorldPoint(LocalAnchorA);
                Vector2 axis = BodyA.GetWorldVector(ref _localXAxis);

                return Vector2.Dot(d, axis);
            }
        }

        /// <summary>
        ///     Get the current joint translation speed, usually in meters per second.
        /// </summary>
        /// <value></value>
        public float JointSpeed
        {
            get
            {
                Transform xf1 = BodyA.GetTransform();
                Transform xf2 = BodyB.GetTransform();

                Vector2 r1 = Complex.Multiply(LocalAnchorA - BodyA.LocalCenter, ref xf1.q);
                Vector2 r2 = Complex.Multiply(LocalAnchorB - BodyB.LocalCenter, ref xf2.q);
                Vector2 p1 = BodyA._sweep.C + r1;
                Vector2 p2 = BodyB._sweep.C + r2;
                Vector2 d = p2 - p1;
                Vector2 axis = BodyA.GetWorldVector(ref _localXAxis);

                Vector2 v1 = BodyA._linearVelocity;
                Vector2 v2 = BodyB._linearVelocity;
                float w1 = BodyA._angularVelocity;
                float w2 = BodyB._angularVelocity;

                float speed = Vector2.Dot(d, MathUtils.Cross(w1, ref axis)) + Vector2.Dot(axis, v2 + MathUtils.Cross(w2, ref r2) - v1 - MathUtils.Cross(w1, ref r1));
                return speed;
            }
        }

        /// <summary>
        ///     Is the joint limit enabled?
        /// </summary>
        /// <value><c>true</c> if [limit enabled]; otherwise, <c>false</c>.</value>
        public bool LimitEnabled
        {
            get => _enableLimit;
            set
            {
                Debug.Assert(BodyA.FixedRotation == false || BodyB.FixedRotation == false, "Warning: limits does currently not work with fixed rotation");

                if (value != _enableLimit)
                {
                    WakeBodies();
                    _enableLimit = value;
                    _impulse.Z = 0;
                }
            }
        }

        /// <summary>
        ///     Get the lower joint limit, usually in meters.
        /// </summary>
        /// <value></value>
        public float LowerLimit
        {
            get => _lowerTranslation;
            set
            {
                if (Math.Abs(value - _lowerTranslation) > float.Epsilon)
                {
                    WakeBodies();
                    _lowerTranslation = value;
                    _impulse.Z = 0.0f;
                }
            }
        }

        /// <summary>
        ///     Get the upper joint limit, usually in meters.
        /// </summary>
        /// <value></value>
        public float UpperLimit
        {
            get => _upperTranslation;
            set
            {
                if (Math.Abs(value - _upperTranslation) > float.Epsilon)
                {
                    WakeBodies();
                    _upperTranslation = value;
                    _impulse.Z = 0.0f;
                }
            }
        }

        /// <summary>
        ///     Is the joint motor enabled?
        /// </summary>
        /// <value><c>true</c> if [motor enabled]; otherwise, <c>false</c>.</value>
        public bool MotorEnabled
        {
            get => _enableMotor;
            set
            {
                WakeBodies();
                _enableMotor = value;
            }
        }

        /// <summary>
        ///     Set the motor speed, usually in meters per second.
        /// </summary>
        /// <value>The speed.</value>
        public float MotorSpeed
        {
            set
            {
                WakeBodies();
                _motorSpeed = value;
            }
            get => _motorSpeed;
        }

        /// <summary>
        ///     Set the maximum motor force, usually in N.
        /// </summary>
        /// <value>The force.</value>
        public float MaxMotorForce
        {
            get => _maxMotorForce;
            set
            {
                WakeBodies();
                _maxMotorForce = value;
            }
        }

        /// <summary>
        ///     Get the current motor impulse, usually in N.
        /// </summary>
        /// <value></value>
        public float MotorImpulse { get; set; }

        /// <summary>
        ///     The axis at which the joint moves.
        /// </summary>
        public Vector2 Axis1
        {
            get => _axis1;
            set
            {
                _axis1 = value;
                _localXAxis = BodyA.GetLocalVector(_axis1);
                _localXAxis.Normalize();
                _localYAxisA = MathUtils.Cross(1.0f, ref _localXAxis);
            }
        }

        /// <summary>
        ///     The axis in local coordinates relative to BodyA
        /// </summary>
        public Vector2 LocalXAxis => _localXAxis;

        /// <summary>
        ///     The reference angle.
        /// </summary>
        public float ReferenceAngle { get; set; }

        /// <summary>
        ///     Initializes the local anchor a
        /// </summary>
        /// <param name="localAnchorA">The local anchor</param>
        /// <param name="localAnchorB">The local anchor</param>
        /// <param name="axis">The axis</param>
        /// <param name="useWorldCoordinates">The use world coordinates</param>
        private void Initialize(Vector2 localAnchorA, Vector2 localAnchorB, Vector2 axis, bool useWorldCoordinates)
        {
            JointType = JointType.Prismatic;

            if (useWorldCoordinates)
            {
                LocalAnchorA = BodyA.GetLocalPoint(localAnchorA);
                LocalAnchorB = BodyB.GetLocalPoint(localAnchorB);
            }
            else
            {
                LocalAnchorA = localAnchorA;
                LocalAnchorB = localAnchorB;
            }

            Axis1 = axis; //FPE only: store the orignal value for use in Serialization
            ReferenceAngle = BodyB.Rotation - BodyA.Rotation;

            _limitState = LimitState.Inactive;
        }

        /// <summary>
        ///     Set the joint limits, usually in meters.
        /// </summary>
        /// <param name="lower">The lower limit</param>
        /// <param name="upper">The upper limit</param>
        public void SetLimits(float lower, float upper)
        {
            if (Math.Abs(upper - _upperTranslation) > float.Epsilon || Math.Abs(lower - _lowerTranslation) > float.Epsilon)
            {
                WakeBodies();
                _upperTranslation = upper;
                _lowerTranslation = lower;
                _impulse.Z = 0.0f;
            }
        }

        /// <summary>
        ///     Gets the motor force.
        /// </summary>
        /// <param name="invDt">The inverse delta time</param>
        public float GetMotorForce(float invDt) => invDt * MotorImpulse;

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2 GetReactionForce(float invDt) => invDt * (_impulse.X * _perp + (MotorImpulse + _impulse.Z) * _axis);

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt) => invDt * _impulse.Y;

        /// <summary>
        ///     Inits the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void InitVelocityConstraints(ref SolverData data)
        {
            _indexA = BodyA.IslandIndex;
            _indexB = BodyB.IslandIndex;
            _localCenterA = BodyA._sweep.LocalCenter;
            _localCenterB = BodyB._sweep.LocalCenter;
            _invMassA = BodyA._invMass;
            _invMassB = BodyB._invMass;
            invIa = BodyA._invI;
            invIb = BodyB._invI;

            Vector2 cA = data.positions[_indexA].c;
            float aA = data.positions[_indexA].a;
            Vector2 vA = data.velocities[_indexA].v;
            float wA = data.velocities[_indexA].w;

            Vector2 cB = data.positions[_indexB].c;
            float aB = data.positions[_indexB].a;
            Vector2 vB = data.velocities[_indexB].v;
            float wB = data.velocities[_indexB].w;

            Complex qA = Complex.FromAngle(aA);
            Complex qB = Complex.FromAngle(aB);

            // Compute the effective masses.
            Vector2 rA = Complex.Multiply(LocalAnchorA - _localCenterA, ref qA);
            Vector2 rB = Complex.Multiply(LocalAnchorB - _localCenterB, ref qB);
            Vector2 d = cB - cA + rB - rA;

            float mA = _invMassA, mB = _invMassB;
            float iA = invIa, iB = invIb;

            // Compute motor Jacobian and effective mass.
            {
                _axis = Complex.Multiply(ref _localXAxis, ref qA);
                _a1 = MathUtils.Cross(d + rA, _axis);
                _a2 = MathUtils.Cross(ref rB, ref _axis);

                _motorMass = mA + mB + iA * _a1 * _a1 + iB * _a2 * _a2;
                if (_motorMass > 0.0f)
                {
                    _motorMass = 1.0f / _motorMass;
                }
            }

            // Prismatic constraint.
            {
                _perp = Complex.Multiply(ref _localYAxisA, ref qA);

                _s1 = MathUtils.Cross(d + rA, _perp);
                _s2 = MathUtils.Cross(ref rB, ref _perp);

                float k11 = mA + mB + iA * _s1 * _s1 + iB * _s2 * _s2;
                float k12 = iA * _s1 + iB * _s2;
                float k13 = iA * _s1 * _a1 + iB * _s2 * _a2;
                float k22 = iA + iB;
                if (k22 == 0.0f)
                {
                    // For bodies with fixed rotation.
                    k22 = 1.0f;
                }

                float k23 = iA * _a1 + iB * _a2;
                float k33 = mA + mB + iA * _a1 * _a1 + iB * _a2 * _a2;

                k.Ex = new Vector3(k11, k12, k13);
                k.Ey = new Vector3(k12, k22, k23);
                k.Ez = new Vector3(k13, k23, k33);
            }

            // Compute motor and limit terms.
            if (_enableLimit)
            {
                float jointTranslation = Vector2.Dot(_axis, d);
                if (Math.Abs(_upperTranslation - _lowerTranslation) < 2.0f * Settings.LinearSlop)
                {
                    _limitState = LimitState.Equal;
                }
                else if (jointTranslation <= _lowerTranslation)
                {
                    if (_limitState != LimitState.AtLower)
                    {
                        _limitState = LimitState.AtLower;
                        _impulse.Z = 0.0f;
                    }
                }
                else if (jointTranslation >= _upperTranslation)
                {
                    if (_limitState != LimitState.AtUpper)
                    {
                        _limitState = LimitState.AtUpper;
                        _impulse.Z = 0.0f;
                    }
                }
                else
                {
                    _limitState = LimitState.Inactive;
                    _impulse.Z = 0.0f;
                }
            }
            else
            {
                _limitState = LimitState.Inactive;
                _impulse.Z = 0.0f;
            }

            if (_enableMotor == false)
            {
                MotorImpulse = 0.0f;
            }

            if (data.step.warmStarting)
            {
                // Account for variable time step.
                _impulse *= data.step.dtRatio;
                MotorImpulse *= data.step.dtRatio;

                Vector2 p = _impulse.X * _perp + (MotorImpulse + _impulse.Z) * _axis;
                float la = _impulse.X * _s1 + _impulse.Y + (MotorImpulse + _impulse.Z) * _a1;
                float lb = _impulse.X * _s2 + _impulse.Y + (MotorImpulse + _impulse.Z) * _a2;

                vA -= mA * p;
                wA -= iA * la;

                vB += mB * p;
                wB += iB * lb;
            }
            else
            {
                _impulse = Vector3.Zero;
                MotorImpulse = 0.0f;
            }

            data.velocities[_indexA].v = vA;
            data.velocities[_indexA].w = wA;
            data.velocities[_indexB].v = vB;
            data.velocities[_indexB].w = wB;
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void SolveVelocityConstraints(ref SolverData data)
        {
            Vector2 vA = data.velocities[_indexA].v;
            float wA = data.velocities[_indexA].w;
            Vector2 vB = data.velocities[_indexB].v;
            float wB = data.velocities[_indexB].w;

            float mA = _invMassA, mB = _invMassB;
            float iA = invIa, iB = invIb;

            // Solve linear motor constraint.
            if (_enableMotor && (_limitState != LimitState.Equal))
            {
                float cdot = Vector2.Dot(_axis, vB - vA) + _a2 * wB - _a1 * wA;
                float impulse = _motorMass * (_motorSpeed - cdot);
                float oldImpulse = MotorImpulse;
                float maxImpulse = data.step.dt * _maxMotorForce;
                MotorImpulse = MathUtils.Clamp(MotorImpulse + impulse, -maxImpulse, maxImpulse);
                impulse = MotorImpulse - oldImpulse;

                Vector2 p = impulse * _axis;
                float la = impulse * _a1;
                float lb = impulse * _a2;

                vA -= mA * p;
                wA -= iA * la;

                vB += mB * p;
                wB += iB * lb;
            }

            Vector2 cdot1 = new Vector2();
            cdot1.X = Vector2.Dot(_perp, vB - vA) + _s2 * wB - _s1 * wA;
            cdot1.Y = wB - wA;

            if (_enableLimit && (_limitState != LimitState.Inactive))
            {
                // Solve prismatic and limit constraint in block form.
                float cdot2;
                cdot2 = Vector2.Dot(_axis, vB - vA) + _a2 * wB - _a1 * wA;
                Vector3 cdot = new Vector3(cdot1.X, cdot1.Y, cdot2);

                Vector3 f1 = _impulse;
                Vector3 df = k.Solve33(-cdot);
                _impulse += df;

                if (_limitState == LimitState.AtLower)
                {
                    _impulse.Z = Math.Max(_impulse.Z, 0.0f);
                }
                else if (_limitState == LimitState.AtUpper)
                {
                    _impulse.Z = Math.Min(_impulse.Z, 0.0f);
                }

                // f2(1:2) = invK(1:2,1:2) * (-Cdot(1:2) - K(1:2,3) * (f2(3) - f1(3))) + f1(1:2)
                Vector2 b = -cdot1 - (_impulse.Z - f1.Z) * new Vector2(k.Ez.X, k.Ez.Y);
                Vector2 f2R = k.Solve22(b) + new Vector2(f1.X, f1.Y);
                _impulse.X = f2R.X;
                _impulse.Y = f2R.Y;

                df = _impulse - f1;

                Vector2 p = df.X * _perp + df.Z * _axis;
                float la = df.X * _s1 + df.Y + df.Z * _a1;
                float lb = df.X * _s2 + df.Y + df.Z * _a2;

                vA -= mA * p;
                wA -= iA * la;

                vB += mB * p;
                wB += iB * lb;
            }
            else
            {
                // Limit is inactive, just solve the prismatic constraint in block form.
                Vector2 df = k.Solve22(-cdot1);
                _impulse.X += df.X;
                _impulse.Y += df.Y;

                Vector2 p = df.X * _perp;
                float la = df.X * _s1 + df.Y;
                float lb = df.X * _s2 + df.Y;

                vA -= mA * p;
                wA -= iA * la;

                vB += mB * p;
                wB += iB * lb;
            }

            data.velocities[_indexA].v = vA;
            data.velocities[_indexA].w = wA;
            data.velocities[_indexB].v = vB;
            data.velocities[_indexB].w = wB;
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(ref SolverData data)
        {
            Vector2 cA = data.positions[_indexA].c;
            float aA = data.positions[_indexA].a;
            Vector2 cB = data.positions[_indexB].c;
            float aB = data.positions[_indexB].a;

            Complex qA = Complex.FromAngle(aA);
            Complex qB = Complex.FromAngle(aB);

            float mA = _invMassA, mB = _invMassB;
            float iA = invIa, iB = invIb;

            // Compute fresh Jacobians
            Vector2 rA = Complex.Multiply(LocalAnchorA - _localCenterA, ref qA);
            Vector2 rB = Complex.Multiply(LocalAnchorB - _localCenterB, ref qB);
            Vector2 d = cB + rB - cA - rA;

            Vector2 axis = Complex.Multiply(ref _localXAxis, ref qA);
            float a1 = MathUtils.Cross(d + rA, axis);
            float a2 = MathUtils.Cross(ref rB, ref axis);
            Vector2 perp = Complex.Multiply(ref _localYAxisA, ref qA);

            float s1 = MathUtils.Cross(d + rA, perp);
            float s2 = MathUtils.Cross(ref rB, ref perp);

            Vector3 impulse;
            Vector2 c1 = new Vector2();
            c1.X = Vector2.Dot(perp, d);
            c1.Y = aB - aA - ReferenceAngle;

            float linearError = Math.Abs(c1.X);
            float angularError = Math.Abs(c1.Y);

            bool active = false;
            float c2 = 0.0f;
            if (_enableLimit)
            {
                float translation = Vector2.Dot(axis, d);
                if (Math.Abs(_upperTranslation - _lowerTranslation) < 2.0f * Settings.LinearSlop)
                {
                    // Prevent large angular corrections
                    c2 = MathUtils.Clamp(translation, -Settings.MaxLinearCorrection, Settings.MaxLinearCorrection);
                    linearError = Math.Max(linearError, Math.Abs(translation));
                    active = true;
                }
                else if (translation <= _lowerTranslation)
                {
                    // Prevent large linear corrections and allow some slop.
                    c2 = MathUtils.Clamp(translation - _lowerTranslation + Settings.LinearSlop, -Settings.MaxLinearCorrection, 0.0f);
                    linearError = Math.Max(linearError, _lowerTranslation - translation);
                    active = true;
                }
                else if (translation >= _upperTranslation)
                {
                    // Prevent large linear corrections and allow some slop.
                    c2 = MathUtils.Clamp(translation - _upperTranslation - Settings.LinearSlop, 0.0f, Settings.MaxLinearCorrection);
                    linearError = Math.Max(linearError, translation - _upperTranslation);
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

                Mat33 kTe = new Mat33();
                kTe.Ex = new Vector3(k11, k12, k13);
                kTe.Ey = new Vector3(k12, k22, k23);
                kTe.Ez = new Vector3(k13, k23, k33);

                Vector3 c = new Vector3();
                c.X = c1.X;
                c.Y = c1.Y;
                c.Z = c2;

                impulse = kTe.Solve33(-c);
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

                Mat22 kTe = new Mat22();
                kTe.Ex = new Vector2(k11, k12);
                kTe.Ey = new Vector2(k12, k22);

                Vector2 impulse1 = kTe.Solve(-c1);
                impulse = new Vector3();
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

            data.positions[_indexA].c = cA;
            data.positions[_indexA].a = aA;
            data.positions[_indexB].c = cB;
            data.positions[_indexB].a = aB;

            return (linearError <= Settings.LinearSlop) && (angularError <= Settings.AngularSlop);
        }
    }
}