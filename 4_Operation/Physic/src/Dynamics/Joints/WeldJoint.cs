// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WeldJoint.cs
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
    ///     A weld joint essentially glues two bodies together. A weld joint may
    ///     distort somewhat because the island constraint solver is approximate.
    ///     The joint is soft constraint based, which means the two bodies will move
    ///     relative to each other, when a force is applied. To combine two bodies
    ///     in a rigid fashion, combine the fixtures to a single body instead.
    /// </summary>
    /// <remarks>
    ///     Point-to-point constraint
    ///     C = p2 - p1
    ///     Cdot = v2 - v1
    ///     = v2 + cross(w2, r2) - v1 - cross(w1, r1)
    ///     J = [-I -r1_skew I r2_skew ]
    ///     Identity used:
    ///     w k % (rx i + ry j) = w * (-ry i + rx j)
    ///     Angle constraint
    ///     C = angle2 - angle1 - referenceAngle
    ///     Cdot = w2 - w1
    ///     J = [0 0 -1 0 0 1]
    ///     K = invI1 + invI2
    /// </remarks>
    public class WeldJoint : Joint
    {
        /// <summary>
        ///     The bias
        /// </summary>
        private float _bias;

        /// <summary>
        ///     The gamma
        /// </summary>
        private float _gamma;

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
        ///     The local center
        /// </summary>
        private Vector2F _localCenterA;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2F _localCenterB;

        /// <summary>
        ///     The mass
        /// </summary>
        private Mat33 _mass;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F _rA;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F _rB;

        /// <summary>
        ///     Initializes a new instance of the <see cref="WeldJoint" /> class
        /// </summary>
        internal WeldJoint() => JointType = JointType.Weld;

        /// <summary>
        ///     You need to specify an anchor point where they are attached.
        ///     The position of the anchor point is important for computing the reaction torque.
        /// </summary>
        /// <param name="bodyA">The first body</param>
        /// <param name="bodyB">The second body</param>
        /// <param name="anchorA">The first body anchor.</param>
        /// <param name="anchorB">The second body anchor.</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public WeldJoint(Body bodyA, Body bodyB, Vector2F anchorA, Vector2F anchorB, bool useWorldCoordinates = false)
            : base(bodyA, bodyB)
        {
            JointType = JointType.Weld;

            if (useWorldCoordinates)
            {
                LocalAnchorA = bodyA.GetLocalPoint(anchorA);
                LocalAnchorB = bodyB.GetLocalPoint(anchorB);
            }
            else
            {
                LocalAnchorA = anchorA;
                LocalAnchorB = anchorB;
            }

            ReferenceAngle = BodyB.Rotation - BodyA.Rotation;
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
        ///     The bodyB angle minus bodyA angle in the reference state (radians).
        /// </summary>
        public float ReferenceAngle { get; set; }

        /// <summary>
        ///     The frequency of the joint. A higher frequency means a stiffer joint, but
        ///     a too high value can cause the joint to oscillate.
        ///     Default is 0, which means the joint does no spring calculations.
        /// </summary>
        public float FrequencyHz { get; set; }

        /// <summary>
        ///     The damping on the joint. The damping is only used when
        ///     the joint has a frequency (> 0). A higher value means more damping.
        /// </summary>
        public float DampingRatio { get; set; }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2F GetReactionForce(float invDt) => invDt * new Vector2F(_impulse.X, _impulse.Y);

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
            _invMassA = BodyA.InvMass;
            _invMassB = BodyB.InvMass;
            _invIA = BodyA.InvI;
            _invIB = BodyB.InvI;

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

            float mA = _invMassA, mB = _invMassB;
            float iA = _invIA, iB = _invIB;

            Mat33 K = new Mat33();
            K.Ex.X = mA + mB + _rA.Y * _rA.Y * iA + _rB.Y * _rB.Y * iB;
            K.Ey.X = -_rA.Y * _rA.X * iA - _rB.Y * _rB.X * iB;
            K.Ez.X = -_rA.Y * iA - _rB.Y * iB;
            K.Ex.Y = K.Ey.X;
            K.Ey.Y = mA + mB + _rA.X * _rA.X * iA + _rB.X * _rB.X * iB;
            K.Ez.Y = _rA.X * iA + _rB.X * iB;
            K.Ex.Z = K.Ez.X;
            K.Ey.Z = K.Ez.Y;
            K.Ez.Z = iA + iB;

            if (FrequencyHz > 0.0f)
            {
                K.GetInverse22(ref _mass);

                float invM = iA + iB;
                float m = invM > 0.0f ? 1.0f / invM : 0.0f;

                float C = aB - aA - ReferenceAngle;

                // Frequency
                float omega = Constant.Tau * FrequencyHz;

                // Damping coefficient
                float d = 2.0f * m * DampingRatio * omega;

                // Spring stiffness
                float k = m * omega * omega;

                // magic formulas
                float h = data.Step.Dt;
                _gamma = h * (d + h * k);
                _gamma = Math.Abs(_gamma) < float.Epsilon ? 1.0f / _gamma : 0.0f;
                _bias = C * h * k * _gamma;

                invM += _gamma;
                _mass.Ez.Z = Math.Abs(invM) < float.Epsilon ? 1.0f / invM : 0.0f;
            }
            else if (Math.Abs(K.Ez.Z) < float.Epsilon)
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
                _impulse *= data.Step.DtRatio;

                Vector2F P = new Vector2F(_impulse.X, _impulse.Y);

                vA -= mA * P;
                wA -= iA * (MathUtils.Cross(ref _rA, ref P) + _impulse.Z);

                vB += mB * P;
                wB += iB * (MathUtils.Cross(ref _rB, ref P) + _impulse.Z);
            }
            else
            {
                _impulse = Vector3F.Zero;
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
            float iA = _invIA, iB = _invIB;

            if (FrequencyHz > 0.0f)
            {
                float cdot2 = wB - wA;

                float impulse2 = -_mass.Ez.Z * (cdot2 + _bias + _gamma * _impulse.Z);
                _impulse.Z += impulse2;

                wA -= iA * impulse2;
                wB += iB * impulse2;

                Vector2F cdot1 = vB + MathUtils.Cross(wB, ref _rB) - vA - MathUtils.Cross(wA, ref _rA);

                Vector2F impulse1 = -MathUtils.Mul22(_mass, cdot1);
                _impulse.X += impulse1.X;
                _impulse.Y += impulse1.Y;

                Vector2F p = impulse1;

                vA -= mA * p;
                wA -= iA * MathUtils.Cross(ref _rA, ref p);

                vB += mB * p;
                wB += iB * MathUtils.Cross(ref _rB, ref p);
            }
            else
            {
                Vector2F cdot1 = vB + MathUtils.Cross(wB, ref _rB) - vA - MathUtils.Cross(wA, ref _rA);
                float cdot2 = wB - wA;
                Vector3F cdot = new Vector3F(cdot1.X, cdot1.Y, cdot2);

                Vector3F impulse = -MathUtils.Mul(_mass, cdot);
                _impulse += impulse;

                Vector2F p = new Vector2F(impulse.X, impulse.Y);

                vA -= mA * p;
                wA -= iA * (MathUtils.Cross(ref _rA, ref p) + impulse.Z);

                vB += mB * p;
                wB += iB * (MathUtils.Cross(ref _rB, ref p) + impulse.Z);
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

            Complex qA = Complex.FromAngle(aA);
            Complex qB = Complex.FromAngle(aB);

            float mA = _invMassA, mB = _invMassB;
            float iA = _invIA, iB = _invIB;

            Vector2F rA = Complex.Multiply(LocalAnchorA - _localCenterA, ref qA);
            Vector2F rB = Complex.Multiply(LocalAnchorB - _localCenterB, ref qB);

            float positionError, angularError;

            Mat33 k = new Mat33();
            k.Ex.X = mA + mB + rA.Y * rA.Y * iA + rB.Y * rB.Y * iB;
            k.Ey.X = -rA.Y * rA.X * iA - rB.Y * rB.X * iB;
            k.Ez.X = -rA.Y * iA - rB.Y * iB;
            k.Ex.Y = k.Ey.X;
            k.Ey.Y = mA + mB + rA.X * rA.X * iA + rB.X * rB.X * iB;
            k.Ez.Y = rA.X * iA + rB.X * iB;
            k.Ex.Z = k.Ez.X;
            k.Ey.Z = k.Ez.Y;
            k.Ez.Z = iA + iB;

            if (FrequencyHz > 0.0f)
            {
                Vector2F c1 = cB + rB - cA - rA;

                positionError = c1.Length();
                angularError = 0.0f;

                Vector2F p = -k.Solve22(c1);

                cA -= mA * p;
                aA -= iA * MathUtils.Cross(ref rA, ref p);

                cB += mB * p;
                aB += iB * MathUtils.Cross(ref rB, ref p);
            }
            else
            {
                Vector2F c1 = cB + rB - cA - rA;
                float c2 = aB - aA - ReferenceAngle;

                positionError = c1.Length();
                angularError = Math.Abs(c2);

                Vector3F c = new Vector3F(c1.X, c1.Y, c2);

                Vector3F impulse;
                if (k.Ez.Z <= 0.0f)
                {
                    Vector2F impulse2 = -k.Solve22(c1);
                    impulse = new Vector3F(impulse2.X, impulse2.Y, 0.0f);
                }
                else
                {
                    impulse = -k.Solve33(c);
                }

                Vector2F p = new Vector2F(impulse.X, impulse.Y);

                cA -= mA * p;
                aA -= iA * (MathUtils.Cross(ref rA, ref p) + impulse.Z);

                cB += mB * p;
                aB += iB * (MathUtils.Cross(ref rB, ref p) + impulse.Z);
            }

            data.Positions[_indexA].C = cA;
            data.Positions[_indexA].A = aA;
            data.Positions[_indexB].C = cB;
            data.Positions[_indexB].A = aB;

            return (positionError <= SettingEnv.LinearSlop) && (angularError <= SettingEnv.AngularSlop);
        }
    }
}