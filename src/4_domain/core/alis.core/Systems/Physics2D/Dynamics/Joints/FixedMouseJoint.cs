// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   FixedMouseJoint.cs
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

using System.Numerics;
using Alis.Core.Systems.Physics2D.Definitions.Joints;
using Alis.Core.Systems.Physics2D.Dynamics.Joints.Misc;
using Alis.Core.Systems.Physics2D.Dynamics.Solver;
using Alis.Core.Systems.Physics2D.Shared;
using Alis.Core.Systems.Physics2D.Utilities;

namespace Alis.Core.Systems.Physics2D.Dynamics.Joints
{
    // p = attached point, m = mouse point
    // C = p - m
    // Cdot = v
    //      = v + cross(w, r)
    // J = [I r_skew]
    // Identity used:
    // w k % (rx i + ry j) = w * (-ry i + rx j)

    /// <summary>
    ///     A mouse joint is used to make a point on a body track a specified world point. This a soft constraint with a
    ///     maximum force. This allows the constraint to stretch and without applying huge forces. NOTE: this joint is not
    ///     documented in the manual because it was developed to be used in the testbed. If you want to learn how to use the
    ///     mouse
    ///     joint, look at the testbed.
    /// </summary>
    public class FixedMouseJoint : Joint
    {
        /// <summary>
        ///     The beta
        /// </summary>
        private float _beta;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2 _C;

        /// <summary>
        ///     The damping
        /// </summary>
        private float _damping;

        /// <summary>
        ///     The gamma
        /// </summary>
        private float _gamma;

        // Solver shared
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
        ///     The inv ia
        /// </summary>
        private float _invIA;

        /// <summary>
        ///     The inv mass
        /// </summary>
        private float _invMassA;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private Vector2 _localAnchorA;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 _localCenterA;

        /// <summary>
        ///     The mass
        /// </summary>
        private Mat22 _mass;

        /// <summary>
        ///     The max force
        /// </summary>
        private float _maxForce;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2 _rA;

        /// <summary>
        ///     The stiffness
        /// </summary>
        private float _stiffness;

        /// <summary>
        ///     The target
        /// </summary>
        private Vector2 _targetB;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FixedMouseJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public FixedMouseJoint(FixedMouseJointDef def) : base(def)
        {
            _targetB = def.Target;
            _localAnchorA = MathUtils.MulT(BodyB._xf, _targetB);
            _maxForce = def.MaxForce;
            _stiffness = def.Stiffness;
            _damping = def.Damping;
        }

        /// <summary>This requires a world target point, tuning parameters, and the time step.</summary>
        /// <param name="body">The body.</param>
        /// <param name="target">The target.</param>
        public FixedMouseJoint(Body body, Vector2 target)
            : base(body, JointType.FixedMouse)
        {
            _targetB = target;
            _localAnchorA = MathUtils.MulT(BodyA._xf, _targetB);
        }

        /// <summary>The local anchor point on BodyB</summary>
        public Vector2 LocalAnchorA
        {
            get => _localAnchorA;
            set => _localAnchorA = value;
        }

        /// <summary>Use this to update the target point.</summary>
        public override Vector2 WorldAnchorA
        {
            get => BodyA.GetWorldPoint(_localAnchorA);
            set => _localAnchorA = BodyA.GetLocalPoint(value);
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public override Vector2 WorldAnchorB
        {
            get => _targetB;
            set
            {
                if (_targetB != value)
                {
                    BodyA.Awake = true;
                    _targetB = value;
                }
            }
        }

        /// <summary>
        ///     The maximum constraint force that can be exerted to move the candidate body. Usually you will express as some
        ///     multiple of the weight (multiplier * mass * gravity). Set/get the maximum force in Newtons.
        /// </summary>
        public float MaxForce
        {
            get => _maxForce;
            set => _maxForce = value;
        }

        /// <summary>Set/get the linear stiffness in N/m</summary>
        public float Stiffness
        {
            get => _stiffness;
            set => _stiffness = value;
        }

        /// <summary>Set/get linear damping in N*s/m</summary>
        public float Damping
        {
            get => _damping;
            set => _damping = value;
        }

        /// <summary>
        ///     Shifts the origin using the specified new origin
        /// </summary>
        /// <param name="newOrigin">The new origin</param>
        public override void ShiftOrigin(ref Vector2 newOrigin)
        {
            _targetB -= newOrigin;
        }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2 GetReactionForce(float invDt) => invDt * _impulse;

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt) => 0.0f;

        /// <summary>
        ///     Inits the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void InitVelocityConstraints(ref SolverData data)
        {
            _indexA = BodyA.IslandIndex;
            _localCenterA = BodyA._sweep.LocalCenter;
            _invMassA = BodyA.InvMass;
            _invIA = BodyA.InvI;

            Vector2 cA = data.Positions[_indexA].C;
            float aA = data.Positions[_indexA].A;
            Vector2 vA = data.Velocities[_indexA].V;
            float wA = data.Velocities[_indexA].W;

            Rot qA = new Rot(aA);

            float d = _damping;
            float k = _stiffness;

            // magic formulas
            // gamma has units of inverse mass.
            // beta has units of inverse time.
            float h = data.Step.DeltaTime;
            _gamma = h * (d + h * k);
            if (_gamma != 0.0f)
            {
                _gamma = 1.0f / _gamma;
            }

            _beta = h * k * _gamma;

            // Compute the effective mass matrix.
            _rA = MathUtils.Mul(qA, _localAnchorA - _localCenterA);

            // K    = [(1/m1 + 1/m2) * eye(2) - skew(r1) * invI1 * skew(r1) - skew(r2) * invI2 * skew(r2)]
            //      = [1/m1+1/m2     0    ] + invI1 * [r1.y*r1.y -r1.x*r1.y] + invI2 * [r1.y*r1.y -r1.x*r1.y]
            //        [    0     1/m1+1/m2]           [-r1.x*r1.y r1.x*r1.x]           [-r1.x*r1.y r1.x*r1.x]
            Mat22 K = new Mat22();
            K.ex.X = _invMassA + _invIA * _rA.Y * _rA.Y + _gamma;
            K.ex.Y = -_invIA * _rA.X * _rA.Y;
            K.ey.X = K.ex.Y;
            K.ey.Y = _invMassA + _invIA * _rA.X * _rA.X + _gamma;

            _mass = K.Inverse;

            _C = cA + _rA - _targetB;
            _C *= _beta;

            // Cheat with some damping
            wA *= 0.98f;

            if (data.Step.WarmStarting)
            {
                _impulse *= data.Step.DeltaTimeRatio;
                vA += _invMassA * _impulse;
                wA += _invIA * MathUtils.Cross(_rA, _impulse);
            }
            else
            {
                _impulse = Vector2.Zero;
            }

            data.Velocities[_indexA].V = vA;
            data.Velocities[_indexA].W = wA;
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void SolveVelocityConstraints(ref SolverData data)
        {
            Vector2 vA = data.Velocities[_indexA].V;
            float wA = data.Velocities[_indexA].W;

            // Cdot = v + cross(w, r)
            Vector2 Cdot = vA + MathUtils.Cross(wA, _rA);
            Vector2 impulse = MathUtils.Mul(ref _mass, -(Cdot + _C + _gamma * _impulse));

            Vector2 oldImpulse = _impulse;
            _impulse += impulse;
            float maxImpulse = data.Step.DeltaTime * _maxForce;
            if (_impulse.LengthSquared() > maxImpulse * maxImpulse)
            {
                _impulse *= maxImpulse / _impulse.Length();
            }

            impulse = _impulse - oldImpulse;

            vA += _invMassA * impulse;
            wA += _invIA * MathUtils.Cross(_rA, impulse);

            data.Velocities[_indexA].V = vA;
            data.Velocities[_indexA].W = wA;
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(ref SolverData data) => true;
    }
}