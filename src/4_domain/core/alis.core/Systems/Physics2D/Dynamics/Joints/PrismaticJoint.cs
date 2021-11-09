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
        private float _a1, _a2;

        /// <summary>
        ///     The axial mass
        /// </summary>
        private float _axialMass;

        /// <summary>
        ///     The perp
        /// </summary>
        private Vector2 _axis, _perp;

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
        private Vector2 _impulse;

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
        ///     The inv ia
        /// </summary>
        private float _invIA;

        /// <summary>
        ///     The inv ib
        /// </summary>
        private float _invIB;

        /// <summary>
        ///     The inv mass
        /// </summary>
        private float _invMassA;

        /// <summary>
        ///     The inv mass
        /// </summary>
        private float _invMassB;

        /// <summary>
        ///     The
        /// </summary>
        private Mat22 _K;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private Vector2 _localAnchorA;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private Vector2 _localAnchorB;

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
        private Vector2 _localXAxisA;

        /// <summary>
        ///     The local axis
        /// </summary>
        private Vector2 _localYAxisA;

        /// <summary>
        ///     The lower impulse
        /// </summary>
        private float _lowerImpulse;

        /// <summary>
        ///     The lower translation
        /// </summary>
        private float _lowerTranslation;

        /// <summary>
        ///     The max motor force
        /// </summary>
        private float _maxMotorForce;

        /// <summary>
        ///     The motor impulse
        /// </summary>
        private float _motorImpulse;

        /// <summary>
        ///     The motor speed
        /// </summary>
        private float _motorSpeed;

        /// <summary>
        ///     The reference angle
        /// </summary>
        private float _referenceAngle;

        /// <summary>
        ///     The
        /// </summary>
        private float _s1, _s2;

        /// <summary>
        ///     The translation
        /// </summary>
        private float _translation;

        /// <summary>
        ///     The upper impulse
        /// </summary>
        private float _upperImpulse;

        /// <summary>
        ///     The upper translation
        /// </summary>
        private float _upperTranslation;

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
            _localYAxisA = MathUtils.Cross(1.0f, LocalXAxisA);
            ReferenceAngle = def.ReferenceAngle;


            _lowerTranslation = def.LowerTranslation;
            _upperTranslation = def.UpperTranslation;

            Debug.Assert(_lowerTranslation <= _upperTranslation);

            _maxMotorForce = def.MaxMotorForce;
            _motorSpeed = def.MotorSpeed;
            _enableLimit = def.EnableLimit;
            _enableMotor = def.EnableMotor;
        }

        /// <summary>The local anchor point on BodyA</summary>
        public Vector2 LocalAnchorA
        {
            get => _localAnchorA;
            set => _localAnchorA = value;
        }

        /// <summary>The local anchor point on BodyB</summary>
        public Vector2 LocalAnchorB
        {
            get => _localAnchorB;
            set => _localAnchorB = value;
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

                Vector2 rA = MathUtils.Mul(bA._xf.q, LocalAnchorA - bA._sweep.LocalCenter);
                Vector2 rB = MathUtils.Mul(bB._xf.q, LocalAnchorB - bB._sweep.LocalCenter);
                Vector2 p1 = bA._sweep.C + rA;
                Vector2 p2 = bB._sweep.C + rB;
                Vector2 d = p2 - p1;
                Vector2 axis = MathUtils.Mul(bA._xf.q, LocalXAxisA);

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
            get => _enableLimit;
            set
            {
                if (value != _enableLimit)
                {
                    WakeBodies();
                    _enableLimit = value;
                    _lowerImpulse = 0.0f;
                    _upperImpulse = 0.0f;
                }
            }
        }

        /// <summary>Get the lower joint limit, usually in meters.</summary>
        public float LowerLimit
        {
            get => _lowerTranslation;
            set
            {
                if (value != _lowerTranslation)
                {
                    WakeBodies();
                    _lowerTranslation = value;
                    _lowerImpulse = 0.0f;
                }
            }
        }

        /// <summary>Get the upper joint limit, usually in meters.</summary>
        public float UpperLimit
        {
            get => _upperTranslation;
            set
            {
                if (value != _upperTranslation)
                {
                    WakeBodies();
                    _upperTranslation = value;
                    _upperImpulse = 0.0f;
                }
            }
        }

        /// <summary>Is the joint motor enabled?</summary>
        /// <value><c>true</c> if [motor enabled]; otherwise, <c>false</c>.</value>
        public bool MotorEnabled
        {
            get => _enableMotor;
            set
            {
                if (value != _enableMotor)
                {
                    WakeBodies();
                    _enableMotor = value;
                }
            }
        }

        /// <summary>Set the motor speed, usually in meters per second.</summary>
        /// <value>The speed.</value>
        public float MotorSpeed
        {
            set
            {
                if (value != _motorSpeed)
                {
                    WakeBodies();
                    _motorSpeed = value;
                }
            }
            get => _motorSpeed;
        }

        /// <summary>Set the maximum motor force, usually in N.</summary>
        /// <value>The force.</value>
        public float MaxMotorForce
        {
            get => _maxMotorForce;
            set
            {
                if (value != _maxMotorForce)
                {
                    WakeBodies();
                    _maxMotorForce = value;
                }
            }
        }

        /// <summary>The local joint axis relative to bodyA.</summary>
        public Vector2 LocalXAxisA
        {
            get => _localXAxisA;
            set { _localXAxisA = value; }
        }

        /// <summary>
        ///     Gets the value of the local y axis a
        /// </summary>
        public Vector2 LocalYAxisA => _localYAxisA;

        /// <summary>Get the reference angle.</summary>
        public float ReferenceAngle
        {
            get => _referenceAngle;
            set { _referenceAngle = value; }
        }

        /// <summary>Get the current motor force given the inverse time step, usually in N.</summary>
        public float GetMotorForce(float invDt) => invDt * _motorImpulse;

        /// <summary>Set the joint limits, usually in meters.</summary>
        /// <param name="lower">The lower limit</param>
        /// <param name="upper">The upper limit</param>
        public void SetLimits(float lower, float upper)
        {
            if (upper != _upperTranslation || lower != _lowerTranslation)
            {
                WakeBodies();
                _upperTranslation = upper;
                _lowerTranslation = lower;
                _lowerImpulse = 0.0f;
                _upperImpulse = 0.0f;
            }
        }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2 GetReactionForce(float invDt) =>
            invDt * (_impulse.X * _perp + (_motorImpulse + _lowerImpulse - _upperImpulse) * _axis);

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
            _invMassA = BodyA.InvMass;
            _invMassB = BodyB.InvMass;
            _invIA = BodyA.InvI;
            _invIB = BodyB.InvI;

            Vector2 cA = data.Positions[_indexA].C;
            float aA = data.Positions[_indexA].A;
            Vector2 vA = data.Velocities[_indexA].V;
            float wA = data.Velocities[_indexA].W;

            Vector2 cB = data.Positions[_indexB].C;
            float aB = data.Positions[_indexB].A;
            Vector2 vB = data.Velocities[_indexB].V;
            float wB = data.Velocities[_indexB].W;

            Rot qA = new Rot(aA), qB = new Rot(aB);

            // Compute the effective masses.
            Vector2 rA = MathUtils.Mul(qA, LocalAnchorA - _localCenterA);
            Vector2 rB = MathUtils.Mul(qB, LocalAnchorB - _localCenterB);
            Vector2 d = cB - cA + rB - rA;

            float mA = _invMassA, mB = _invMassB;
            float iA = _invIA, iB = _invIB;

            // Compute motor Jacobian and effective mass.
            {
                _axis = MathUtils.Mul(qA, LocalXAxisA);
                _a1 = MathUtils.Cross(d + rA, _axis);
                _a2 = MathUtils.Cross(rB, _axis);

                _axialMass = mA + mB + iA * _a1 * _a1 + iB * _a2 * _a2;
                if (_axialMass > 0.0f)
                {
                    _axialMass = 1.0f / _axialMass;
                }
            }

            // Prismatic constraint.
            {
                _perp = MathUtils.Mul(qA, _localYAxisA);

                _s1 = MathUtils.Cross(d + rA, _perp);
                _s2 = MathUtils.Cross(rB, _perp);

                float k11 = mA + mB + iA * _s1 * _s1 + iB * _s2 * _s2;
                float k12 = iA * _s1 + iB * _s2;
                float k22 = iA + iB;
                if (k22 == 0.0f)
                {
                    // For bodies with fixed rotation.
                    k22 = 1.0f;
                }

                _K.ex = new Vector2(k11, k12);
                _K.ey = new Vector2(k12, k22);
            }

            if (_enableLimit)
            {
                _translation = Vector2.Dot(_axis, d);
            }
            else
            {
                _lowerImpulse = 0.0f;
                _upperImpulse = 0.0f;
            }

            if (!_enableMotor)
            {
                _motorImpulse = 0.0f;
            }

            if (data.Step.WarmStarting)
            {
                // Account for variable time step.
                _impulse *= data.Step.DeltaTimeRatio;
                _motorImpulse *= data.Step.DeltaTimeRatio;
                _lowerImpulse *= data.Step.DeltaTimeRatio;
                _upperImpulse *= data.Step.DeltaTimeRatio;

                float axialImpulse = _motorImpulse + _lowerImpulse - _upperImpulse;
                Vector2 P = _impulse.X * _perp + axialImpulse * _axis;
                float LA = _impulse.X * _s1 + _impulse.Y + axialImpulse * _a1;
                float LB = _impulse.X * _s2 + _impulse.Y + axialImpulse * _a2;

                vA -= mA * P;
                wA -= iA * LA;

                vB += mB * P;
                wB += iB * LB;
            }
            else
            {
                _impulse = Vector2.Zero;
                _motorImpulse = 0.0f;
                _lowerImpulse = 0.0f;
                _upperImpulse = 0.0f;
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
            Vector2 vA = data.Velocities[_indexA].V;
            float wA = data.Velocities[_indexA].W;
            Vector2 vB = data.Velocities[_indexB].V;
            float wB = data.Velocities[_indexB].W;

            float mA = _invMassA, mB = _invMassB;
            float iA = _invIA, iB = _invIB;

            // Solve linear motor constraint.
            if (_enableMotor)
            {
                float Cdot = Vector2.Dot(_axis, vB - vA) + _a2 * wB - _a1 * wA;
                float impulse = _axialMass * (_motorSpeed - Cdot);
                float oldImpulse = _motorImpulse;
                float maxImpulse = data.Step.DeltaTime * _maxMotorForce;
                _motorImpulse = MathUtils.Clamp(_motorImpulse + impulse, -maxImpulse, maxImpulse);
                impulse = _motorImpulse - oldImpulse;

                Vector2 P = impulse * _axis;
                float LA = impulse * _a1;
                float LB = impulse * _a2;

                vA -= mA * P;
                wA -= iA * LA;
                vB += mB * P;
                wB += iB * LB;
            }

            if (_enableLimit)
            {
                // Lower limit
                {
                    float C = _translation - _lowerTranslation;
                    float Cdot = MathUtils.Dot(_axis, vB - vA) + _a2 * wB - _a1 * wA;
                    float impulse = -_axialMass * (Cdot + MathUtils.Max(C, 0.0f) * data.Step.InvertedDeltaTime);
                    float oldImpulse = _lowerImpulse;
                    _lowerImpulse = MathUtils.Max(_lowerImpulse + impulse, 0.0f);
                    impulse = _lowerImpulse - oldImpulse;

                    Vector2 P = impulse * _axis;
                    float LA = impulse * _a1;
                    float LB = impulse * _a2;

                    vA -= mA * P;
                    wA -= iA * LA;
                    vB += mB * P;
                    wB += iB * LB;
                }

                // Upper limit
                // Note: signs are flipped to keep C positive when the constraint is satisfied.
                // This also keeps the impulse positive when the limit is active.
                {
                    float C = _upperTranslation - _translation;
                    float Cdot = MathUtils.Dot(_axis, vA - vB) + _a1 * wA - _a2 * wB;
                    float impulse = -_axialMass * (Cdot + MathUtils.Max(C, 0.0f) * data.Step.InvertedDeltaTime);
                    float oldImpulse = _upperImpulse;
                    _upperImpulse = MathUtils.Max(_upperImpulse + impulse, 0.0f);
                    impulse = _upperImpulse - oldImpulse;

                    Vector2 P = impulse * _axis;
                    float LA = impulse * _a1;
                    float LB = impulse * _a2;

                    vA += mA * P;
                    wA += iA * LA;
                    vB -= mB * P;
                    wB -= iB * LB;
                }
            }

            // Solve the prismatic constraint in block form.
            {
                Vector2 Cdot;
                Cdot.X = MathUtils.Dot(_perp, vB - vA) + _s2 * wB - _s1 * wA;
                Cdot.Y = wB - wA;

                Vector2 df = _K.Solve(-Cdot);
                _impulse += df;

                Vector2 P = df.X * _perp;
                float LA = df.X * _s1 + df.Y;
                float LB = df.X * _s2 + df.Y;

                vA -= mA * P;
                wA -= iA * LA;

                vB += mB * P;
                wB += iB * LB;
            }

            data.Velocities[_indexA].V = vA;
            data.Velocities[_indexA].W = wA;
            data.Velocities[_indexB].V = vB;
            data.Velocities[_indexB].W = wB;
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
            Vector2 cA = data.Positions[_indexA].C;
            float aA = data.Positions[_indexA].A;
            Vector2 cB = data.Positions[_indexB].C;
            float aB = data.Positions[_indexB].A;

            Rot qA = new Rot(aA), qB = new Rot(aB);

            float mA = _invMassA, mB = _invMassB;
            float iA = _invIA, iB = _invIB;

            // Compute fresh Jacobians
            Vector2 rA = MathUtils.Mul(qA, LocalAnchorA - _localCenterA);
            Vector2 rB = MathUtils.Mul(qB, LocalAnchorB - _localCenterB);
            Vector2 d = cB + rB - cA - rA;

            Vector2 axis = MathUtils.Mul(qA, LocalXAxisA);
            float a1 = MathUtils.Cross(d + rA, axis);
            float a2 = MathUtils.Cross(rB, axis);
            Vector2 perp = MathUtils.Mul(qA, _localYAxisA);

            float s1 = MathUtils.Cross(d + rA, perp);
            float s2 = MathUtils.Cross(rB, perp);

            Vector3 impulse;
            Vector2 C1;
            C1.X = Vector2.Dot(perp, d);
            C1.Y = aB - aA - ReferenceAngle;

            float linearError = MathUtils.Abs(C1.X);
            float angularError = MathUtils.Abs(C1.Y);

            bool active = false;
            float C2 = 0.0f;
            if (_enableLimit)
            {
                float translation = MathUtils.Dot(axis, d);
                if (MathUtils.Abs(_upperTranslation - _lowerTranslation) < 2.0f * Settings.LinearSlop)
                {
                    C2 = translation;
                    linearError = MathUtils.Max(linearError, MathUtils.Abs(translation));
                    active = true;
                }
                else if (translation <= _lowerTranslation)
                {
                    C2 = MathUtils.Min(translation - _lowerTranslation, 0.0f);
                    linearError = MathUtils.Max(linearError, _lowerTranslation - translation);
                    active = true;
                }
                else if (translation >= _upperTranslation)
                {
                    C2 = MathUtils.Max(translation - _upperTranslation, 0.0f);
                    linearError = MathUtils.Max(linearError, translation - _upperTranslation);
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

                Mat33 K;
                K.ex = new Vector3(k11, k12, k13);
                K.ey = new Vector3(k12, k22, k23);
                K.ez = new Vector3(k13, k23, k33);

                Vector3 C;
                C.X = C1.X;
                C.Y = C1.Y;
                C.Z = C2;

                impulse = K.Solve33(-C);
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

                Mat22 K;
                K.ex = new Vector2(k11, k12);
                K.ey = new Vector2(k12, k22);

                Vector2 impulse1 = K.Solve(-C1);
                impulse.X = impulse1.X;
                impulse.Y = impulse1.Y;
                impulse.Z = 0.0f;
            }

            Vector2 P = impulse.X * perp + impulse.Z * axis;
            float LA = impulse.X * s1 + impulse.Y + impulse.Z * a1;
            float LB = impulse.X * s2 + impulse.Y + impulse.Z * a2;

            cA -= mA * P;
            aA -= iA * LA;
            cB += mB * P;
            aB += iB * LB;

            data.Positions[_indexA].C = cA;
            data.Positions[_indexA].A = aA;
            data.Positions[_indexB].C = cB;
            data.Positions[_indexB].A = aB;

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
            _localYAxisA = MathUtils.Cross(1.0f, LocalXAxisA);
        }
    }
}