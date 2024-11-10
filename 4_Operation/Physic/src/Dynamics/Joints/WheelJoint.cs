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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     A wheel joint. This joint provides two degrees of freedom: translation
    ///     along an axis fixed in bodyA and rotation in the plane. You can use a
    ///     joint limit to restrict the range of motion and a joint motor to drive
    ///     the rotation or to model rotational friction.
    ///     This joint is designed for vehicle suspensions.
    /// </summary>
    /// <remarks>
    ///     Linear constraint (point-to-line)
    ///     d = pB - pA = xB + rB - xA - rA
    ///     C = dot(ay, d)
    ///     Cdot = dot(d, cross(wA, ay)) + dot(ay, vB + cross(wB, rB) - vA - cross(wA, rA))
    ///     = -dot(ay, vA) - dot(cross(d + rA, ay), wA) + dot(ay, vB) + dot(cross(rB, ay), vB)
    ///     J = [-ay, -cross(d + rA, ay), ay, cross(rB, ay)]
    ///     Spring linear constraint
    ///     C = dot(ax, d)
    ///     Cdot = = -dot(ax, vA) - dot(cross(d + rA, ax), wA) + dot(ax, vB) + dot(cross(rB, ax), vB)
    ///     J = [-ax -cross(d+rA, ax) ax cross(rB, ax)]
    ///     Motor rotational constraint
    ///     Cdot = wB - wA
    ///     J = [0 0 -1 0 0 1]
    /// </remarks>
    public class WheelJoint : Joint
    {
        /// <summary>
        ///     The ay
        /// </summary>
        private Vector2 _ax, _ay;

        /// <summary>
        ///     The axis
        /// </summary>
        private Vector2 _axis;

        /// <summary>
        ///     The bias
        /// </summary>
        private float _bias;

        /// <summary>
        ///     The enable motor
        /// </summary>
        private bool _enableMotor;

        /// <summary>
        ///     The gamma
        /// </summary>
        private float _gamma;

        /// <summary>
        ///     The impulse
        /// </summary>
        private float _impulse;

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
        ///     The local center
        /// </summary>
        private Vector2 _localCenterA;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 _localCenterB;

        // Solver shared
        /// <summary>
        ///     The local axis
        /// </summary>
        private Vector2 _localXAxis;

        /// <summary>
        ///     The local axis
        /// </summary>
        private Vector2 _localYAxis;

        /// <summary>
        ///     The mass
        /// </summary>
        private float _mass;

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
        private float _motorMass;

        /// <summary>
        ///     The motor speed
        /// </summary>
        private float _motorSpeed;

        /// <summary>
        ///     The bx
        /// </summary>
        private float _sAx, _sBx;

        /// <summary>
        ///     The by
        /// </summary>
        private float _sAy, _sBy;

        /// <summary>
        ///     The spring impulse
        /// </summary>
        private float _springImpulse;

        /// <summary>
        ///     The spring mass
        /// </summary>
        private float _springMass;

        /// <summary>
        ///     The inv ia
        /// </summary>
        private float invIa;

        /// <summary>
        ///     The inv ib
        /// </summary>
        private float invIb;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WheelJoint" /> class
        /// </summary>
        internal WheelJoint() => JointType = JointType.Wheel;

        /// <summary>
        ///     Constructor for WheelJoint
        /// </summary>
        /// <param name="bodyA">The first body</param>
        /// <param name="bodyB">The second body</param>
        /// <param name="anchor">The anchor point</param>
        /// <param name="axis">The axis</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public WheelJoint(Body bodyA, Body bodyB, Vector2 anchor, Vector2 axis, bool useWorldCoordinates = false)
            : base(bodyA, bodyB)
        {
            JointType = JointType.Wheel;

            if (useWorldCoordinates)
            {
                LocalAnchorA = bodyA.GetLocalPoint(anchor);
                LocalAnchorB = bodyB.GetLocalPoint(anchor);
            }
            else
            {
                LocalAnchorA = bodyA.GetLocalPoint(bodyB.GetWorldPoint(anchor));
                LocalAnchorB = anchor;
            }

            Axis = axis; //FPE only: We maintain the original value as it is supposed to.
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
        ///     The axis at which the suspension moves.
        /// </summary>
        public Vector2 Axis
        {
            get => _axis;
            set
            {
                _axis = value;
                _localXAxis = BodyA.GetLocalVector(_axis);
                _localYAxis = MathUtils.Rot90(ref _localXAxis);
            }
        }

        /// <summary>
        ///     The axis in local coordinates relative to BodyA
        /// </summary>
        public Vector2 LocalXAxis => _localXAxis;

        /// <summary>
        ///     The desired motor speed in radians per second.
        /// </summary>
        public float MotorSpeed
        {
            get => _motorSpeed;
            set
            {
                WakeBodies();
                _motorSpeed = value;
            }
        }

        /// <summary>
        ///     The maximum motor torque, usually in N-m.
        /// </summary>
        public float MaxMotorTorque
        {
            get => _maxMotorTorque;
            set
            {
                WakeBodies();
                _maxMotorTorque = value;
            }
        }

        /// <summary>
        ///     Suspension frequency, zero indicates no suspension
        /// </summary>
        public float Frequency { get; set; }

        /// <summary>
        ///     Suspension damping ratio, one indicates critical damping
        /// </summary>
        public float DampingRatio { get; set; }

        /// <summary>
        ///     Gets the translation along the axis
        /// </summary>
        public float JointTranslation
        {
            get
            {
                Body bA = BodyA;
                Body bB = BodyB;

                Vector2 pA = bA.GetWorldPoint(LocalAnchorA);
                Vector2 pB = bB.GetWorldPoint(LocalAnchorB);
                Vector2 d = pB - pA;
                Vector2 axis = bA.GetWorldVector(ref _localXAxis);

                float translation = Vector2.Dot(d, axis);
                return translation;
            }
        }

        /// <summary>
        ///     Gets the angular velocity of the joint
        /// </summary>
        public float JointSpeed
        {
            get
            {
                float wA = BodyA.AngularVelocity;
                float wB = BodyB.AngularVelocity;
                return wB - wA;
            }
        }

        /// <summary>
        ///     Enable/disable the joint motor.
        /// </summary>
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
        ///     Gets the torque of the motor
        /// </summary>
        /// <param name="invDt">inverse delta time</param>
        public float GetMotorTorque(float invDt) => invDt * _motorImpulse;

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2 GetReactionForce(float invDt) => invDt * (_impulse * _ay + _springImpulse * _ax);

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt) => invDt * _motorImpulse;

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

            float mA = _invMassA, mB = _invMassB;
            float iA = invIa, iB = invIb;

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
            Vector2 d1 = cB + rB - cA - rA;

            // Point to line constraint
            {
                _ay = Complex.Multiply(ref _localYAxis, ref qA);
                _sAy = MathUtils.Cross(d1 + rA, _ay);
                _sBy = MathUtils.Cross(ref rB, ref _ay);

                _mass = mA + mB + iA * _sAy * _sAy + iB * _sBy * _sBy;

                if (_mass > 0.0f)
                {
                    _mass = 1.0f / _mass;
                }
            }

            // Spring constraint
            _springMass = 0.0f;
            _bias = 0.0f;
            _gamma = 0.0f;
            if (Frequency > 0.0f)
            {
                _ax = Complex.Multiply(ref _localXAxis, ref qA);
                _sAx = MathUtils.Cross(d1 + rA, _ax);
                _sBx = MathUtils.Cross(ref rB, ref _ax);

                float invMass = mA + mB + iA * _sAx * _sAx + iB * _sBx * _sBx;

                if (invMass > 0.0f)
                {
                    _springMass = 1.0f / invMass;

                    float c = Vector2.Dot(d1, _ax);

                    // Frequency
                    float omega = Constant.Tau * Frequency;

                    // Damping coefficient
                    float d = 2.0f * _springMass * DampingRatio * omega;

                    // Spring stiffness
                    float k = _springMass * omega * omega;

                    // magic formulas
                    float h = data.step.dt;
                    _gamma = h * (d + h * k);
                    if (_gamma > 0.0f)
                    {
                        _gamma = 1.0f / _gamma;
                    }

                    _bias = c * h * k * _gamma;

                    _springMass = invMass + _gamma;
                    if (_springMass > 0.0f)
                    {
                        _springMass = 1.0f / _springMass;
                    }
                }
            }
            else
            {
                _springImpulse = 0.0f;
            }

            // Rotational motor
            if (_enableMotor)
            {
                _motorMass = iA + iB;
                if (_motorMass > 0.0f)
                {
                    _motorMass = 1.0f / _motorMass;
                }
            }
            else
            {
                _motorMass = 0.0f;
                _motorImpulse = 0.0f;
            }

            if (data.step.warmStarting)
            {
                // Account for variable time step.
                _impulse *= data.step.dtRatio;
                _springImpulse *= data.step.dtRatio;
                _motorImpulse *= data.step.dtRatio;

                Vector2 p = _impulse * _ay + _springImpulse * _ax;
                float la = _impulse * _sAy + _springImpulse * _sAx + _motorImpulse;
                float lb = _impulse * _sBy + _springImpulse * _sBx + _motorImpulse;

                vA -= _invMassA * p;
                wA -= invIa * la;

                vB += _invMassB * p;
                wB += invIb * lb;
            }
            else
            {
                _impulse = 0.0f;
                _springImpulse = 0.0f;
                _motorImpulse = 0.0f;
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
            float mA = _invMassA, mB = _invMassB;
            float iA = invIa, iB = invIb;

            Vector2 vA = data.velocities[_indexA].v;
            float wA = data.velocities[_indexA].w;
            Vector2 vB = data.velocities[_indexB].v;
            float wB = data.velocities[_indexB].w;

            // Solve spring constraint
            {
                float cdot = Vector2.Dot(_ax, vB - vA) + _sBx * wB - _sAx * wA;
                float impulse = -_springMass * (cdot + _bias + _gamma * _springImpulse);
                _springImpulse += impulse;

                Vector2 p = impulse * _ax;
                float la = impulse * _sAx;
                float lb = impulse * _sBx;

                vA -= mA * p;
                wA -= iA * la;

                vB += mB * p;
                wB += iB * lb;
            }

            // Solve rotational motor constraint
            {
                float cdot = wB - wA - _motorSpeed;
                float impulse = -_motorMass * cdot;

                float oldImpulse = _motorImpulse;
                float maxImpulse = data.step.dt * _maxMotorTorque;
                _motorImpulse = MathUtils.Clamp(_motorImpulse + impulse, -maxImpulse, maxImpulse);
                impulse = _motorImpulse - oldImpulse;

                wA -= iA * impulse;
                wB += iB * impulse;
            }

            // Solve point to line constraint
            {
                float cdot = Vector2.Dot(_ay, vB - vA) + _sBy * wB - _sAy * wA;
                float impulse = -_mass * cdot;
                _impulse += impulse;

                Vector2 p = impulse * _ay;
                float la = impulse * _sAy;
                float lb = impulse * _sBy;

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

            Vector2 rA = Complex.Multiply(LocalAnchorA - _localCenterA, ref qA);
            Vector2 rB = Complex.Multiply(LocalAnchorB - _localCenterB, ref qB);
            Vector2 d = cB - cA + rB - rA;

            Vector2 ay = Complex.Multiply(ref _localYAxis, ref qA);

            float sAy = MathUtils.Cross(d + rA, ay);
            float sBy = MathUtils.Cross(ref rB, ref ay);

            float c = Vector2.Dot(d, ay);

            float k = _invMassA + _invMassB + invIa * _sAy * _sAy + invIb * _sBy * _sBy;

            float impulse;
            if (Math.Abs(k) > float.Epsilon)
            {
                impulse = -c / k;
            }
            else
            {
                impulse = 0.0f;
            }

            Vector2 p = impulse * ay;
            float la = impulse * sAy;
            float lb = impulse * sBy;

            cA -= _invMassA * p;
            aA -= invIa * la;
            cB += _invMassB * p;
            aB += invIb * lb;

            data.positions[_indexA].c = cA;
            data.positions[_indexA].a = aA;
            data.positions[_indexB].c = cB;
            data.positions[_indexB].a = aB;

            return Math.Abs(c) <= Settings.LinearSlop;
        }
    }
}