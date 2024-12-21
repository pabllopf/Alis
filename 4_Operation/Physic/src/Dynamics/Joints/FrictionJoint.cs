// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrictionJoint.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    // Point-to-point constraint
    // Cdot = v2 - v1
    //      = v2 + cross(w2, r2) - v1 - cross(w1, r1)
    // J = [-I -r1_skew I r2_skew ]
    // Identity used:
    // w k % (rx i + ry j) = w * (-ry i + rx j)

    // Angle constraint
    // Cdot = w2 - w1
    // J = [0 0 -1 0 0 1]
    // K = invI1 + invI2

    /// <summary>
    ///     Friction joint. This is used for top-down friction.
    ///     It provides 2D translational friction and angular friction.
    /// </summary>
    public class FrictionJoint : Joint
    {
        /// <summary>
        ///     The angular impulse
        /// </summary>
        private float _angularImpulse;

        /// <summary>
        ///     The angular mass
        /// </summary>
        private float _angularMass;

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
        ///     The linear impulse
        /// </summary>
        private Vector2F _linearImpulse;

        /// <summary>
        ///     The linear mass
        /// </summary>
        private Mat22 _linearMass;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2F _localCenterA;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2F _localCenterB;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F _rA;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F _rB;

        /// <summary>
        ///     Initializes a new instance of the <see cref="FrictionJoint" /> class
        /// </summary>
        internal FrictionJoint() => JointType = JointType.Friction;

        /// <summary>
        ///     Constructor for FrictionJoint.
        /// </summary>
        /// <param name="bodyA"></param>
        /// <param name="bodyB"></param>
        /// <param name="anchor"></param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public FrictionJoint(Body bodyA, Body bodyB, Vector2F anchor, bool useWorldCoordinates = false)
            : base(bodyA, bodyB)
        {
            JointType = JointType.Friction;

            if (useWorldCoordinates)
            {
                LocalAnchorA = BodyA.GetLocalPoint(anchor);
                LocalAnchorB = BodyB.GetLocalPoint(anchor);
            }
            else
            {
                LocalAnchorA = anchor;
                LocalAnchorB = anchor;
            }
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
        ///     The maximum friction force in N.
        /// </summary>
        public float MaxForce { get; set; }

        /// <summary>
        ///     The maximum friction torque in N-m.
        /// </summary>
        public float MaxTorque { get; set; }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2F GetReactionForce(float invDt) => invDt * _linearImpulse;

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt) => invDt * _angularImpulse;

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

            float aA = data.positions[_indexA].a;
            Vector2F vA = data.velocities[_indexA].v;
            float wA = data.velocities[_indexA].w;

            float aB = data.positions[_indexB].a;
            Vector2F vB = data.velocities[_indexB].v;
            float wB = data.velocities[_indexB].w;

            Complex qA = Complex.FromAngle(aA);
            Complex qB = Complex.FromAngle(aB);

            // Compute the effective mass matrix.
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
            float iA = _invIA, iB = _invIB;

            Mat22 K = new Mat22();
            K.Ex.X = mA + mB + iA * _rA.Y * _rA.Y + iB * _rB.Y * _rB.Y;
            K.Ex.Y = -iA * _rA.X * _rA.Y - iB * _rB.X * _rB.Y;
            K.Ey.X = K.Ex.Y;
            K.Ey.Y = mA + mB + iA * _rA.X * _rA.X + iB * _rB.X * _rB.X;

            _linearMass = K.Inverse;

            _angularMass = iA + iB;
            if (_angularMass > 0.0f)
            {
                _angularMass = 1.0f / _angularMass;
            }

            if (data.step.warmStarting)
            {
                // Scale impulses to support a variable time step.
                _linearImpulse *= data.step.dtRatio;
                _angularImpulse *= data.step.dtRatio;

                Vector2F P = new Vector2F(_linearImpulse.X, _linearImpulse.Y);
                vA -= mA * P;
                wA -= iA * (MathUtils.Cross(ref _rA, ref P) + _angularImpulse);
                vB += mB * P;
                wB += iB * (MathUtils.Cross(ref _rB, ref P) + _angularImpulse);
            }
            else
            {
                _linearImpulse = Vector2F.Zero;
                _angularImpulse = 0.0f;
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
            Vector2F vA = data.velocities[_indexA].v;
            float wA = data.velocities[_indexA].w;
            Vector2F vB = data.velocities[_indexB].v;
            float wB = data.velocities[_indexB].w;

            float mA = _invMassA, mB = _invMassB;
            float iA = _invIA, iB = _invIB;

            float h = data.step.dt;

            // Solve angular friction
            {
                float Cdot = wB - wA;
                float impulse = -_angularMass * Cdot;

                float oldImpulse = _angularImpulse;
                float maxImpulse = h * MaxTorque;
                _angularImpulse = MathUtils.Clamp(_angularImpulse + impulse, -maxImpulse, maxImpulse);
                impulse = _angularImpulse - oldImpulse;

                wA -= iA * impulse;
                wB += iB * impulse;
            }

            // Solve linear friction
            {
                Vector2F Cdot = vB + MathUtils.Cross(wB, ref _rB) - vA - MathUtils.Cross(wA, ref _rA);

                Vector2F impulse = -MathUtils.Mul(ref _linearMass, ref Cdot);
                Vector2F oldImpulse = _linearImpulse;
                _linearImpulse += impulse;

                float maxImpulse = h * MaxForce;

                if (_linearImpulse.LengthSquared() > maxImpulse * maxImpulse)
                {
                    _linearImpulse.Normalize();
                    _linearImpulse *= maxImpulse;
                }

                impulse = _linearImpulse - oldImpulse;

                vA -= mA * impulse;
                wA -= iA * MathUtils.Cross(ref _rA, ref impulse);

                vB += mB * impulse;
                wB += iB * MathUtils.Cross(ref _rB, ref impulse);
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
        internal override bool SolvePositionConstraints(ref SolverData data) => true;
    }
}