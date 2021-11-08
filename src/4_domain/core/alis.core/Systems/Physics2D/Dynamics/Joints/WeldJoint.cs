// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   WeldJoint.cs
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

using System;
using System.Numerics;
using Alis.Core.Systems.Physics2D.Definitions.Joints;
using Alis.Core.Systems.Physics2D.Dynamics.Joints.Misc;
using Alis.Core.Systems.Physics2D.Dynamics.Solver;
using Alis.Core.Systems.Physics2D.Shared;
using Alis.Core.Systems.Physics2D.Utilities;

namespace Alis.Core.Systems.Physics2D.Dynamics.Joints
{
    // Point-to-point constraint
    // C = p2 - p1
    // Cdot = v2 - v1
    //      = v2 + cross(w2, r2) - v1 - cross(w1, r1)
    // J = [-I -r1_skew I r2_skew ]
    // Identity used:
    // w k % (rx i + ry j) = w * (-ry i + rx j)

    // Angle constraint
    // C = angle2 - angle1 - referenceAngle
    // Cdot = w2 - w1
    // J = [0 0 -1 0 0 1]
    // K = invI1 + invI2

    /// <summary>
    ///     A weld joint essentially glues two bodies together. A weld joint may distort somewhat because the island
    ///     constraint solver is approximate. The joint is soft constraint based, which means the two bodies will move relative
    ///     to
    ///     each other, when a force is applied. To combine two bodies in a rigid fashion, combine the fixtures to a single
    ///     body
    ///     instead.
    /// </summary>
    public class WeldJoint : Joint
    {
        /// <summary>
        ///     The reference angle
        /// </summary>
        private readonly float _referenceAngle;

        /// <summary>
        ///     The bias
        /// </summary>
        private float _bias;

        /// <summary>
        ///     The damping
        /// </summary>
        private float _damping;

        /// <summary>
        ///     The gamma
        /// </summary>
        private float _gamma;

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

        // Solver shared
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
        ///     The mass
        /// </summary>
        private Mat33 _mass;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2 _rA;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2 _rB;

        /// <summary>
        ///     The stiffness
        /// </summary>
        private float _stiffness;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WeldJoint" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public WeldJoint(WeldJointDef def)
            : base(def)
        {
            _localAnchorA = def.LocalAnchorA;
            _localAnchorB = def.LocalAnchorB;
            _referenceAngle = def.ReferenceAngle;
            _stiffness = def.Stiffness;
            _damping = def.Damping;

            _impulse = Vector3.Zero;
        }

        /// <summary>
        ///     You need to specify an anchor point where they are attached. The position of the anchor point is important for
        ///     computing the reaction torque.
        /// </summary>
        /// <param name="bodyA">The first body</param>
        /// <param name="bodyB">The second body</param>
        /// <param name="anchorA">The first body anchor.</param>
        /// <param name="anchorB">The second body anchor.</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public WeldJoint(Body bodyA, Body bodyB, Vector2 anchorA, Vector2 anchorB, bool useWorldCoordinates = false)
            : base(bodyA, bodyB, JointType.Weld)
        {
            if (useWorldCoordinates)
            {
                _localAnchorA = bodyA.GetLocalPoint(anchorA);
                _localAnchorB = bodyB.GetLocalPoint(anchorB);
            }
            else
            {
                _localAnchorA = anchorA;
                _localAnchorB = anchorB;
            }

            _referenceAngle = bodyB._sweep.A - bodyA._sweep.A;
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
            get => _bodyA.GetWorldPoint(_localAnchorA);
            set => _localAnchorA = _bodyA.GetLocalPoint(value);
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public override Vector2 WorldAnchorB
        {
            get => _bodyB.GetWorldPoint(_localAnchorB);
            set => _localAnchorB = _bodyB.GetLocalPoint(value);
        }

        /// <summary>The bodyB angle minus bodyA angle in the reference state (radians).</summary>
        public float ReferenceAngle => _referenceAngle;

        /// <summary>
        ///     The frequency of the joint. A higher frequency means a stiffer joint, but a too high value can cause the joint
        ///     to oscillate. Default is 0, which means the joint does no spring calculations.
        /// </summary>
        public float Stiffness
        {
            get => _stiffness;
            set => _stiffness = value;
        }

        /// <summary>
        ///     The damping on the joint. The damping is only used when the joint has a frequency (> 0). A higher value means
        ///     more damping.
        /// </summary>
        public float Damping
        {
            get => _damping;
            set => _damping = value;
        }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2 GetReactionForce(float invDt)
        {
            Vector2 P = new Vector2(_impulse.X, _impulse.Y);
            return invDt * P;
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
            _indexA = BodyA.IslandIndex;
            _indexB = BodyB.IslandIndex;
            _localCenterA = BodyA._sweep.LocalCenter;
            _localCenterB = BodyB._sweep.LocalCenter;
            _invMassA = BodyA._invMass;
            _invMassB = BodyB._invMass;
            _invIA = BodyA._invI;
            _invIB = BodyB._invI;

            float aA = data.Positions[_indexA].A;
            Vector2 vA = data.Velocities[_indexA].V;
            float wA = data.Velocities[_indexA].W;

            float aB = data.Positions[_indexB].A;
            Vector2 vB = data.Velocities[_indexB].V;
            float wB = data.Velocities[_indexB].W;

            Rot qA = new Rot(aA), qB = new Rot(aB);

            _rA = MathUtils.Mul(qA, _localAnchorA - _localCenterA);
            _rB = MathUtils.Mul(qB, _localAnchorB - _localCenterB);

            // J = [-I -r1_skew I r2_skew]
            //     [ 0       -1 0       1]
            // r_skew = [-ry; rx]

            // Matlab
            // K = [ mA+r1y^2*iA+mB+r2y^2*iB,  -r1y*iA*r1x-r2y*iB*r2x,          -r1y*iA-r2y*iB]
            //     [  -r1y*iA*r1x-r2y*iB*r2x, mA+r1x^2*iA+mB+r2x^2*iB,           r1x*iA+r2x*iB]
            //     [          -r1y*iA-r2y*iB,           r1x*iA+r2x*iB,                   iA+iB]

            float mA = _invMassA, mB = _invMassB;
            float iA = _invIA, iB = _invIB;

            Mat33 K;
            K.ex.X = mA + mB + _rA.Y * _rA.Y * iA + _rB.Y * _rB.Y * iB;
            K.ey.X = -_rA.Y * _rA.X * iA - _rB.Y * _rB.X * iB;
            K.ez.X = -_rA.Y * iA - _rB.Y * iB;
            K.ex.Y = K.ey.X;
            K.ey.Y = mA + mB + _rA.X * _rA.X * iA + _rB.X * _rB.X * iB;
            K.ez.Y = _rA.X * iA + _rB.X * iB;
            K.ex.Z = K.ez.X;
            K.ey.Z = K.ez.Y;
            K.ez.Z = iA + iB;

            if (_stiffness > 0.0f)
            {
                K.GetInverse22(ref _mass);

                float invM = iA + iB;

                float C = aB - aA - _referenceAngle;

                // Damping coefficient
                float d = _damping;

                // Spring stiffness
                float k = _stiffness;

                // magic formulas
                float h = data.Step.DeltaTime;
                _gamma = h * (d + h * k);
                _gamma = _gamma != 0.0f ? 1.0f / _gamma : 0.0f;
                _bias = C * h * k * _gamma;

                invM += _gamma;
                _mass.ez.Z = invM != 0.0f ? 1.0f / invM : 0.0f;
            }
            else if (K.ez.Z == 0.0f)
            {
                K.GetInverse22(ref _mass);
                _gamma = 0.0f;
                _bias = 0.0f;
            }
            else
            {
                K.GetSymInverse33(ref _mass);
                _gamma = 0.0f;
                _bias = 0.0f;
            }

            if (data.Step.WarmStarting)
            {
                // Scale impulses to support a variable time step.
                _impulse *= data.Step.DeltaTimeRatio;

                Vector2 P = new Vector2(_impulse.X, _impulse.Y);

                vA -= mA * P;
                wA -= iA * (MathUtils.Cross(_rA, P) + _impulse.Z);

                vB += mB * P;
                wB += iB * (MathUtils.Cross(_rB, P) + _impulse.Z);
            }
            else
            {
                _impulse = Vector3.Zero;
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

            if (_stiffness > 0.0f)
            {
                float Cdot2 = wB - wA;

                float impulse2 = -_mass.ez.Z * (Cdot2 + _bias + _gamma * _impulse.Z);
                _impulse.Z += impulse2;

                wA -= iA * impulse2;
                wB += iB * impulse2;

                Vector2 Cdot1 = vB + MathUtils.Cross(wB, _rB) - vA - MathUtils.Cross(wA, _rA);

                Vector2 impulse1 = -MathUtils.Mul22(_mass, Cdot1);
                _impulse.X += impulse1.X;
                _impulse.Y += impulse1.Y;

                Vector2 P = impulse1;

                vA -= mA * P;
                wA -= iA * MathUtils.Cross(_rA, P);

                vB += mB * P;
                wB += iB * MathUtils.Cross(_rB, P);
            }
            else
            {
                Vector2 Cdot1 = vB + MathUtils.Cross(wB, _rB) - vA - MathUtils.Cross(wA, _rA);
                float Cdot2 = wB - wA;
                Vector3 Cdot = new Vector3(Cdot1.X, Cdot1.Y, Cdot2);

                Vector3 impulse = -MathUtils.Mul(_mass, Cdot);
                _impulse += impulse;

                Vector2 P = new Vector2(impulse.X, impulse.Y);

                vA -= mA * P;
                wA -= iA * (MathUtils.Cross(_rA, P) + impulse.Z);

                vB += mB * P;
                wB += iB * (MathUtils.Cross(_rB, P) + impulse.Z);
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
            Vector2 cA = data.Positions[_indexA].C;
            float aA = data.Positions[_indexA].A;
            Vector2 cB = data.Positions[_indexB].C;
            float aB = data.Positions[_indexB].A;

            Rot qA = new Rot(aA), qB = new Rot(aB);

            float mA = _invMassA, mB = _invMassB;
            float iA = _invIA, iB = _invIB;

            Vector2 rA = MathUtils.Mul(qA, LocalAnchorA - _localCenterA);
            Vector2 rB = MathUtils.Mul(qB, LocalAnchorB - _localCenterB);

            float positionError, angularError;

            Mat33 K = new Mat33();
            K.ex.X = mA + mB + rA.Y * rA.Y * iA + rB.Y * rB.Y * iB;
            K.ey.X = -rA.Y * rA.X * iA - rB.Y * rB.X * iB;
            K.ez.X = -rA.Y * iA - rB.Y * iB;
            K.ex.Y = K.ey.X;
            K.ey.Y = mA + mB + rA.X * rA.X * iA + rB.X * rB.X * iB;
            K.ez.Y = rA.X * iA + rB.X * iB;
            K.ex.Z = K.ez.X;
            K.ey.Z = K.ez.Y;
            K.ez.Z = iA + iB;

            if (_stiffness > 0.0f)
            {
                Vector2 C1 = cB + rB - cA - rA;

                positionError = C1.Length();
                angularError = 0.0f;

                Vector2 P = -K.Solve22(C1);

                cA -= mA * P;
                aA -= iA * MathUtils.Cross(rA, P);

                cB += mB * P;
                aB += iB * MathUtils.Cross(rB, P);
            }
            else
            {
                Vector2 C1 = cB + rB - cA - rA;
                float C2 = aB - aA - _referenceAngle;

                positionError = C1.Length();
                angularError = Math.Abs(C2);

                Vector3 C = new Vector3(C1.X, C1.Y, C2);

                Vector3 impulse;
                if (K.ez.Z > 0.0f)
                {
                    impulse = -K.Solve33(C);
                }
                else
                {
                    Vector2 impulse2 = -K.Solve22(C1);
                    impulse = new Vector3(impulse2.X, impulse2.Y, 0.0f);
                }

                Vector2 P = new Vector2(impulse.X, impulse.Y);

                cA -= mA * P;
                aA -= iA * (MathUtils.Cross(rA, P) + impulse.Z);

                cB += mB * P;
                aB += iB * (MathUtils.Cross(rB, P) + impulse.Z);
            }

            data.Positions[_indexA].C = cA;
            data.Positions[_indexA].A = aA;
            data.Positions[_indexB].C = cB;
            data.Positions[_indexB].A = aB;

            return positionError <= Settings.LinearSlop && angularError <= Settings.AngularSlop;
        }
    }
}