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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
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
        ///     The enable limit
        /// </summary>
        private bool _enableLimit;

        /// <summary>
        ///     The enable motor
        /// </summary>
        private bool _enableMotor;

        // Solver shared
        /// <summary>
        ///     The impulse
        /// </summary>
        private Vector3F _impulse;

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
        private Vector2F _localCenterA;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2F _localCenterB;

        /// <summary>
        ///     The lower angle
        /// </summary>
        private float _lowerAngle;

        /// <summary>
        ///     The mass
        /// </summary>
        private Mat33 _mass; // effective mass for point-to-point constraint.

        /// <summary>
        ///     The max motor torque
        /// </summary>
        private float _maxMotorTorque;

        /// <summary>
        ///     The motor impulse
        /// </summary>
        private float _motorImpulse;

        /// <summary>
        ///     The motor mass
        /// </summary>
        private float _motorMass; // effective mass for motor/limit angular constraint.

        /// <summary>
        ///     The motor speed
        /// </summary>
        private float _motorSpeed;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F _rA;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F _rB;

        /// <summary>
        ///     The reference angle
        /// </summary>
        private float _referenceAngle;

        /// <summary>
        ///     The upper angle
        /// </summary>
        private float _upperAngle;

        /// <summary>
        ///     The inv ia
        /// </summary>
        private float invIa;

        /// <summary>
        ///     The inv ib
        /// </summary>
        private float invIb;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RevoluteJoint" /> class
        /// </summary>
        internal RevoluteJoint() => JointType = JointType.Revolute;

        /// <summary>
        ///     Constructor of RevoluteJoint.
        /// </summary>
        /// <param name="bodyA">The first body.</param>
        /// <param name="bodyB">The second body.</param>
        /// <param name="anchorA">The first body anchor.</param>
        /// <param name="anchorB">The second anchor.</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public RevoluteJoint(Body bodyA, Body bodyB, Vector2F anchorA, Vector2F anchorB, bool useWorldCoordinates = false)
            : base(bodyA, bodyB)
        {
            JointType = JointType.Revolute;

            if (useWorldCoordinates)
            {
                LocalAnchorA = BodyA.GetLocalPoint(anchorA);
                LocalAnchorB = BodyB.GetLocalPoint(anchorB);
            }
            else
            {
                LocalAnchorA = anchorA;
                LocalAnchorB = anchorB;
            }

            ReferenceAngle = BodyB.Rotation - BodyA.Rotation;

            _impulse = Vector3F.Zero;
            _limitState = LimitState.Inactive;
        }

        /// <summary>
        ///     Constructor of RevoluteJoint.
        /// </summary>
        /// <param name="bodyA">The first body.</param>
        /// <param name="bodyB">The second body.</param>
        /// <param name="anchor">The shared anchor.</param>
        /// <param name="useWorldCoordinates"></param>
        public RevoluteJoint(Body bodyA, Body bodyB, Vector2F anchor, bool useWorldCoordinates = false)
            : this(bodyA, bodyB, anchor, anchor, useWorldCoordinates)
        {
        }

        /// <summary>
        ///     The local anchor point on BodyA
        /// </summary>
        public Vector2F LocalAnchorA { get; set; }

        /// <summary>
        ///     The local anchor point on BodyB
        /// </summary>
        public Vector2F LocalAnchorB { get; set; }

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

        /// <summary>
        ///     The referance angle computed as BodyB angle minus BodyA angle.
        /// </summary>
        public float ReferenceAngle
        {
            get => _referenceAngle;
            set
            {
                WakeBodies();
                _referenceAngle = value;
            }
        }

        /// <summary>
        ///     Get the current joint angle in radians.
        /// </summary>
        public float JointAngle => BodyB.Sweep.A - BodyA.Sweep.A - ReferenceAngle;

        /// <summary>
        ///     Get the current joint angle speed in radians per second.
        /// </summary>
        public float JointSpeed => BodyB.AngularVelocity - BodyA.AngularVelocity;

        /// <summary>
        ///     Is the joint limit enabled?
        /// </summary>
        /// <value><c>true</c> if [limit enabled]; otherwise, <c>false</c>.</value>
        public bool LimitEnabled
        {
            get => _enableLimit;
            set
            {
                if (_enableLimit != value)
                {
                    WakeBodies();
                    _enableLimit = value;
                    _impulse.Z = 0.0f;
                }
            }
        }

        /// <summary>
        ///     Get the lower joint limit in radians.
        /// </summary>
        public float LowerLimit
        {
            get => _lowerAngle;
            set
            {
                if (Math.Abs(_lowerAngle - value) > float.Epsilon)
                {
                    WakeBodies();
                    _lowerAngle = value;
                    _impulse.Z = 0.0f;
                }
            }
        }

        /// <summary>
        ///     Get the upper joint limit in radians.
        /// </summary>
        public float UpperLimit
        {
            get => _upperAngle;
            set
            {
                if (Math.Abs(_upperAngle - value) > float.Epsilon)
                {
                    WakeBodies();
                    _upperAngle = value;
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
        ///     Get or set the motor speed in radians per second.
        /// </summary>
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
        ///     Get or set the maximum motor torque, usually in N-m.
        /// </summary>
        public float MaxMotorTorque
        {
            set
            {
                WakeBodies();
                _maxMotorTorque = value;
            }
            get => _maxMotorTorque;
        }

        /// <summary>
        ///     Get or set the current motor impulse, usually in N-m.
        /// </summary>
        public float MotorImpulse
        {
            get => _motorImpulse;
            set
            {
                WakeBodies();
                _motorImpulse = value;
            }
        }

        /// <summary>
        ///     Set the joint limits, usually in meters.
        /// </summary>
        /// <param name="lower">The lower limit</param>
        /// <param name="upper">The upper limit</param>
        public void SetLimits(float lower, float upper)
        {
            if (Math.Abs(lower - _lowerAngle) > float.Epsilon || Math.Abs(upper - _upperAngle) > float.Epsilon)
            {
                WakeBodies();
                _upperAngle = upper;
                _lowerAngle = lower;
                _impulse.Z = 0.0f;
            }
        }

        /// <summary>
        ///     Gets the motor torque in N-m.
        /// </summary>
        /// <param name="invDt">The inverse delta time</param>
        public float GetMotorTorque(float invDt) => invDt * _motorImpulse;

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2F GetReactionForce(float invDt)
        {
            Vector2F p = new Vector2F(_impulse.X, _impulse.Y);
            return invDt * p;
        }

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt) => invDt * _impulse.Z;

        /// <summary>
        ///     Inits the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void InitVelocityConstraints(ref SolverData data)
        {
            _indexA = BodyA.GetIslandIndex;
            _indexB = BodyB.GetIslandIndex;
            _localCenterA = BodyA.Sweep.LocalCenter;
            _localCenterB = BodyB.Sweep.LocalCenter;
            _invMassA = BodyA.InvMass;
            _invMassB = BodyB.InvMass;
            invIa = BodyA.InvI;
            invIb = BodyB.InvI;

            float aA = data.Positions[_indexA].A;
            Vector2F vA = data.Velocities[_indexA].V;
            float wA = data.Velocities[_indexA].W;

            float aB = data.Positions[_indexB].A;
            Vector2F vB = data.Velocities[_indexB].V;
            float wB = data.Velocities[_indexB].W;

            Complex qA = Complex.FromAngle(aA);
            Complex qB = Complex.FromAngle(aB);

            _rA = Complex.Multiply(LocalAnchorA - _localCenterA, ref qA);
            _rB = Complex.Multiply(LocalAnchorB - _localCenterB, ref qB);

            // J = [-I -r1_skew I r2_skew]
            //     [ 0       -1 0       1]
            // r_skew = [-ry; rx]

            // Matlab
            // K = [ mA+r1y^2*iA+mB+r2y^2*iB,  -r1y*iA*r1x-r2y*iB*r2x,          -r1y*iA-r2y*iB]
            //     [  -r1y*iA*r1x-r2y*iB*r2x, mA+r1x^2*iA+mB+r2x^2*iB,           r1x*iA+r2x*iB]
            //     [          -r1y*iA-r2y*iB,           r1x*iA+r2x*iB,                   iA+iB]

            float mA = _invMassA, mB = _invMassB;
            float iA = invIa, iB = invIb;

            bool fixedRotation = iA + Math.Abs(iB) < float.Epsilon;

            _mass.Ex.X = mA + mB + _rA.Y * _rA.Y * iA + _rB.Y * _rB.Y * iB;
            _mass.Ey.X = -_rA.Y * _rA.X * iA - _rB.Y * _rB.X * iB;
            _mass.Ez.X = -_rA.Y * iA - _rB.Y * iB;
            _mass.Ex.Y = _mass.Ey.X;
            _mass.Ey.Y = mA + mB + _rA.X * _rA.X * iA + _rB.X * _rB.X * iB;
            _mass.Ez.Y = _rA.X * iA + _rB.X * iB;
            _mass.Ex.Z = _mass.Ez.X;
            _mass.Ey.Z = _mass.Ez.Y;
            _mass.Ez.Z = iA + iB;

            _motorMass = iA + iB;
            if (_motorMass > 0.0f)
            {
                _motorMass = 1.0f / _motorMass;
            }

            if (!_enableMotor || fixedRotation)
            {
                _motorImpulse = 0.0f;
            }

            if (_enableLimit && !fixedRotation)
            {
                float jointAngle = aB - aA - ReferenceAngle;
                if (Math.Abs(_upperAngle - _lowerAngle) < 2.0f * SettingEnv.AngularSlop)
                {
                    _limitState = LimitState.Equal;
                }
                else if (jointAngle <= _lowerAngle)
                {
                    if (_limitState != LimitState.AtLower)
                    {
                        _impulse.Z = 0.0f;
                    }

                    _limitState = LimitState.AtLower;
                }
                else if (jointAngle >= _upperAngle)
                {
                    if (_limitState != LimitState.AtUpper)
                    {
                        _impulse.Z = 0.0f;
                    }

                    _limitState = LimitState.AtUpper;
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
            }

            if (data.Step.WarmStarting)
            {
                // Scale impulses to support a variable time step.
                _impulse *= data.Step.DtRatio;
                _motorImpulse *= data.Step.DtRatio;

                Vector2F p = new Vector2F(_impulse.X, _impulse.Y);

                vA -= mA * p;
                wA -= iA * (MathUtils.Cross(ref _rA, ref p) + MotorImpulse + _impulse.Z);

                vB += mB * p;
                wB += iB * (MathUtils.Cross(ref _rB, ref p) + MotorImpulse + _impulse.Z);
            }
            else
            {
                _impulse = Vector3F.Zero;
                _motorImpulse = 0.0f;
            }

            data.Velocities[_indexA].V = vA;
            data.Velocities[_indexA].W = wA;
            data.Velocities[_indexB].V = vB;
            data.Velocities[_indexB].W = wB;
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void SolveVelocityConstraints(ref SolverData data)
        {
            Vector2F vA = data.Velocities[_indexA].V;
            float wA = data.Velocities[_indexA].W;
            Vector2F vB = data.Velocities[_indexB].V;
            float wB = data.Velocities[_indexB].W;

            float mA = _invMassA, mB = _invMassB;
            float iA = invIa, iB = invIb;

            bool fixedRotation = iA + Math.Abs(iB) < float.Epsilon;

            // Solve motor constraint.
            if (_enableMotor && (_limitState != LimitState.Equal) && !fixedRotation)
            {
                float cdot = wB - wA - _motorSpeed;
                float impulse = _motorMass * -cdot;
                float oldImpulse = _motorImpulse;
                float maxImpulse = data.Step.Dt * _maxMotorTorque;
                _motorImpulse = MathUtils.Clamp(_motorImpulse + impulse, -maxImpulse, maxImpulse);
                impulse = _motorImpulse - oldImpulse;

                wA -= iA * impulse;
                wB += iB * impulse;
            }

            // Solve limit constraint.
            if (_enableLimit && (_limitState != LimitState.Inactive) && !fixedRotation)
            {
                Vector2F cdot1 = vB + MathUtils.Cross(wB, ref _rB) - vA - MathUtils.Cross(wA, ref _rA);
                float cdot2 = wB - wA;
                Vector3F cdot = new Vector3F(cdot1.X, cdot1.Y, cdot2);

                Vector3F impulse = -_mass.Solve33(cdot);

                if (_limitState == LimitState.Equal)
                {
                    _impulse += impulse;
                }
                else if (_limitState == LimitState.AtLower)
                {
                    float newImpulse = _impulse.Z + impulse.Z;
                    if (newImpulse < 0.0f)
                    {
                        Vector2F rhs = -cdot1 + _impulse.Z * new Vector2F(_mass.Ez.X, _mass.Ez.Y);
                        Vector2F reduced = _mass.Solve22(rhs);
                        impulse.X = reduced.X;
                        impulse.Y = reduced.Y;
                        impulse.Z = -_impulse.Z;
                        _impulse.X += reduced.X;
                        _impulse.Y += reduced.Y;
                        _impulse.Z = 0.0f;
                    }
                    else
                    {
                        _impulse += impulse;
                    }
                }
                else if (_limitState == LimitState.AtUpper)
                {
                    float newImpulse = _impulse.Z + impulse.Z;
                    if (newImpulse > 0.0f)
                    {
                        Vector2F rhs = -cdot1 + _impulse.Z * new Vector2F(_mass.Ez.X, _mass.Ez.Y);
                        Vector2F reduced = _mass.Solve22(rhs);
                        impulse.X = reduced.X;
                        impulse.Y = reduced.Y;
                        impulse.Z = -_impulse.Z;
                        _impulse.X += reduced.X;
                        _impulse.Y += reduced.Y;
                        _impulse.Z = 0.0f;
                    }
                    else
                    {
                        _impulse += impulse;
                    }
                }

                Vector2F p = new Vector2F(impulse.X, impulse.Y);

                vA -= mA * p;
                wA -= iA * (MathUtils.Cross(ref _rA, ref p) + impulse.Z);

                vB += mB * p;
                wB += iB * (MathUtils.Cross(ref _rB, ref p) + impulse.Z);
            }
            else
            {
                // Solve point-to-point constraint
                Vector2F cdot = vB + MathUtils.Cross(wB, ref _rB) - vA - MathUtils.Cross(wA, ref _rA);
                Vector2F impulse = _mass.Solve22(-cdot);

                _impulse.X += impulse.X;
                _impulse.Y += impulse.Y;

                vA -= mA * impulse;
                wA -= iA * MathUtils.Cross(ref _rA, ref impulse);

                vB += mB * impulse;
                wB += iB * MathUtils.Cross(ref _rB, ref impulse);
            }

            data.Velocities[_indexA].V = vA;
            data.Velocities[_indexA].W = wA;
            data.Velocities[_indexB].V = vB;
            data.Velocities[_indexB].W = wB;
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(ref SolverData data)
        {
            Vector2F cA = data.Positions[_indexA].C;
            float aA = data.Positions[_indexA].A;
            Vector2F cB = data.Positions[_indexB].C;
            float aB = data.Positions[_indexB].A;


            float angularError = 0.0f;
            float positionError;

            bool fixedRotation = invIa + Math.Abs(invIb) < float.Epsilon;

            // Solve angular limit constraint.
            if (_enableLimit && (_limitState != LimitState.Inactive) && !fixedRotation)
            {
                float angle = aB - aA - ReferenceAngle;
                float limitImpulse = 0.0f;

                if (_limitState == LimitState.Equal)
                {
                    // Prevent large angular corrections
                    float c = MathUtils.Clamp(angle - _lowerAngle, -SettingEnv.MaxAngularCorrection, SettingEnv.MaxAngularCorrection);
                    limitImpulse = -_motorMass * c;
                    angularError = Math.Abs(c);
                }
                else if (_limitState == LimitState.AtLower)
                {
                    float c = angle - _lowerAngle;
                    angularError = -c;

                    // Prevent large angular corrections and allow some slop.
                    c = MathUtils.Clamp(c + SettingEnv.AngularSlop, -SettingEnv.MaxAngularCorrection, 0.0f);
                    limitImpulse = -_motorMass * c;
                }
                else if (_limitState == LimitState.AtUpper)
                {
                    float c = angle - _upperAngle;
                    angularError = c;

                    // Prevent large angular corrections and allow some slop.
                    c = MathUtils.Clamp(c - SettingEnv.AngularSlop, 0.0f, SettingEnv.MaxAngularCorrection);
                    limitImpulse = -_motorMass * c;
                }

                aA -= invIa * limitImpulse;
                aB += invIb * limitImpulse;
            }

            // Solve point-to-point constraint.
            {
                Complex qA = Complex.FromAngle(aA);
                Complex qB = Complex.FromAngle(aB);
                Vector2F rA = Complex.Multiply(LocalAnchorA - _localCenterA, ref qA);
                Vector2F rB = Complex.Multiply(LocalAnchorB - _localCenterB, ref qB);

                Vector2F c = cB + rB - cA - rA;
                positionError = c.Length();

                float mA = _invMassA, mB = _invMassB;
                float iA = invIa, iB = invIb;

                Mat22 k = new Mat22();
                k.Ex.X = mA + mB + iA * rA.Y * rA.Y + iB * rB.Y * rB.Y;
                k.Ex.Y = -iA * rA.X * rA.Y - iB * rB.X * rB.Y;
                k.Ey.X = k.Ex.Y;
                k.Ey.Y = mA + mB + iA * rA.X * rA.X + iB * rB.X * rB.X;

                Vector2F impulse = -k.Solve(c);

                cA -= mA * impulse;
                aA -= iA * MathUtils.Cross(ref rA, ref impulse);

                cB += mB * impulse;
                aB += iB * MathUtils.Cross(ref rB, ref impulse);
            }

            data.Positions[_indexA].C = cA;
            data.Positions[_indexA].A = aA;
            data.Positions[_indexB].C = cB;
            data.Positions[_indexB].A = aB;

            return (positionError <= SettingEnv.LinearSlop) && (angularError <= SettingEnv.AngularSlop);
        }
    }
}