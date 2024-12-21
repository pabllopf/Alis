// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GearJoint.cs
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

using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    // Gear Joint:
    // C0 = (coordinate1 + ratio * coordinate2)_initial
    // C = (coordinate1 + ratio * coordinate2) - C0 = 0
    // J = [J1 ratio * J2]
    // K = J * invM * JT
    //   = J1 * invM1 * J1T + ratio * ratio * J2 * invM2 * J2T
    //
    // Revolute:
    // coordinate = rotation
    // Cdot = angularVelocity
    // J = [0 0 1]
    // K = J * invM * JT = invI
    //
    // Prismatic:
    // coordinate = dot(p - pg, ug)
    // Cdot = dot(v + cross(w, r), ug)
    // J = [ug cross(r, ug)]
    // K = J * invM * JT = invMass + invI * cross(r, ug)^2

    /// <summary>
    ///     A gear joint is used to connect two joints together.
    ///     Either joint can be a revolute or prismatic joint.
    ///     You specify a gear ratio to bind the motions together:
    ///     <![CDATA[coordinate1 + ratio * coordinate2 = ant]]>
    ///     The ratio can be negative or positive. If one joint is a revolute joint
    ///     and the other joint is a prismatic joint, then the ratio will have units
    ///     of length or units of 1/length.
    ///     Warning: You have to manually destroy the gear joint if jointA or jointB is destroyed.
    /// </summary>
    public class GearJoint : Joint
    {
        /// <summary>
        ///     The body
        /// </summary>
        private readonly Body _bodyA;

        /// <summary>
        ///     The body
        /// </summary>
        private readonly Body _bodyB;

        /// <summary>
        ///     The body
        /// </summary>
        private readonly Body _bodyC;

        /// <summary>
        ///     The body
        /// </summary>
        private readonly Body _bodyD;

        /// <summary>
        ///     The constant
        /// </summary>
        private readonly float _constant;

        // Solver shared
        /// <summary>
        ///     The local anchor
        /// </summary>
        private readonly Vector2F _localAnchorA;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private readonly Vector2F _localAnchorB;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private readonly Vector2F _localAnchorC;

        /// <summary>
        ///     The local anchor
        /// </summary>
        private readonly Vector2F _localAnchorD;

        /// <summary>
        ///     The reference angle
        /// </summary>
        private readonly float _referenceAngleA;

        /// <summary>
        ///     The reference angle
        /// </summary>
        private readonly float _referenceAngleB;

        /// <summary>
        ///     The type
        /// </summary>
        private readonly JointType _typeA;

        /// <summary>
        ///     The type
        /// </summary>
        private readonly JointType _typeB;

        /// <summary>
        ///     The
        /// </summary>
        private float _iA, _iB, _iC, _iD;

        /// <summary>
        ///     The impulse
        /// </summary>
        private float _impulse;

        // Solver temp
        /// <summary>
        ///     The index
        /// </summary>
        private int _indexA, _indexB, _indexC, _indexD;

        /// <summary>
        ///     The jv bd
        /// </summary>
        private Vector2F _JvAC, _JvBD;

        /// <summary>
        ///     The jw
        /// </summary>
        private float _JwA, _JwB, _JwC, _JwD;

        /// <summary>
        ///     The lc
        /// </summary>
        private Vector2F _lcA, _lcB, _lcC, _lcD;

        /// <summary>
        ///     The local axis
        /// </summary>
        private Vector2F _localAxisC;

        /// <summary>
        ///     The local axis
        /// </summary>
        private Vector2F _localAxisD;

        /// <summary>
        ///     The
        /// </summary>
        private float _mA, _mB, _mC, _mD;

        /// <summary>
        ///     The mass
        /// </summary>
        private float _mass;

        /// <summary>
        ///     The ratio
        /// </summary>
        private float _ratio;

        /// <summary>
        ///     Requires two existing revolute or prismatic joints (any combination will work).
        ///     The provided joints must attach a dynamic body to a static body.
        /// </summary>
        /// <param name="jointA">The first joint.</param>
        /// <param name="jointB">The second joint.</param>
        /// <param name="ratio">The ratio.</param>
        /// <param name="bodyA">The first body</param>
        /// <param name="bodyB">The second body</param>
        public GearJoint(Body bodyA, Body bodyB, Joint jointA, Joint jointB, float ratio = 1f)
        {
            JointType = JointType.Gear;
            BodyA = bodyA;
            BodyB = bodyB;
            JointA = jointA;
            JointB = jointB;
            Ratio = ratio;

            _typeA = jointA.JointType;
            _typeB = jointB.JointType;

            Debug.Assert(_typeA == JointType.Revolute || _typeA == JointType.Prismatic || _typeA == JointType.FixedRevolute || _typeA == JointType.FixedPrismatic);
            Debug.Assert(_typeB == JointType.Revolute || _typeB == JointType.Prismatic || _typeB == JointType.FixedRevolute || _typeB == JointType.FixedPrismatic);

            float coordinateA, coordinateB;


            _bodyC = JointA.BodyA;
            _bodyA = JointA.BodyB;

            // Get geometry of joint1
            Transform xfA = _bodyA._xf;
            float aA = _bodyA._sweep.A;
            Transform xfC = _bodyC._xf;
            float aC = _bodyC._sweep.A;

            if (_typeA == JointType.Revolute)
            {
                RevoluteJoint revolute = (RevoluteJoint) jointA;
                _localAnchorC = revolute.LocalAnchorA;
                _localAnchorA = revolute.LocalAnchorB;
                _referenceAngleA = revolute.ReferenceAngle;
                _localAxisC = Vector2F.Zero;

                coordinateA = aA - aC - _referenceAngleA;
            }
            else
            {
                PrismaticJoint prismatic = (PrismaticJoint) jointA;
                _localAnchorC = prismatic.LocalAnchorA;
                _localAnchorA = prismatic.LocalAnchorB;
                _referenceAngleA = prismatic.ReferenceAngle;
                _localAxisC = prismatic.LocalXAxis;

                Vector2F pC = _localAnchorC;
                Vector2F pA = Complex.Divide(Complex.Multiply(ref _localAnchorA, ref xfA.q) + (xfA.p - xfC.p), ref xfC.q);
                coordinateA = Vector2F.Dot(pA - pC, _localAxisC);
            }

            _bodyD = JointB.BodyA;
            _bodyB = JointB.BodyB;

            // Get geometry of joint2
            Transform xfB = _bodyB._xf;
            float aB = _bodyB._sweep.A;
            Transform xfD = _bodyD._xf;
            float aD = _bodyD._sweep.A;

            if (_typeB == JointType.Revolute)
            {
                RevoluteJoint revolute = (RevoluteJoint) jointB;
                _localAnchorD = revolute.LocalAnchorA;
                _localAnchorB = revolute.LocalAnchorB;
                _referenceAngleB = revolute.ReferenceAngle;
                _localAxisD = Vector2F.Zero;

                coordinateB = aB - aD - _referenceAngleB;
            }
            else
            {
                PrismaticJoint prismatic = (PrismaticJoint) jointB;
                _localAnchorD = prismatic.LocalAnchorA;
                _localAnchorB = prismatic.LocalAnchorB;
                _referenceAngleB = prismatic.ReferenceAngle;
                _localAxisD = prismatic.LocalXAxis;

                Vector2F pD = _localAnchorD;
                Vector2F pB = Complex.Divide(Complex.Multiply(ref _localAnchorB, ref xfB.q) + (xfB.p - xfD.p), ref xfD.q);
                coordinateB = Vector2F.Dot(pB - pD, _localAxisD);
            }

            _ratio = ratio;
            _constant = coordinateA + _ratio * coordinateB;
            _impulse = 0.0f;
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor a
        /// </summary>
        public override Vector2F WorldAnchorA
        {
            get => _bodyA.GetWorldPoint(_localAnchorA);
            set => Debug.Assert(false, "You can't set the world anchor on this joint type.");
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public override Vector2F WorldAnchorB
        {
            get => _bodyB.GetWorldPoint(_localAnchorB);
            set => Debug.Assert(false, "You can't set the world anchor on this joint type.");
        }

        /// <summary>
        ///     The gear ratio.
        /// </summary>
        public float Ratio
        {
            get => _ratio;
            set
            {
                Debug.Assert(MathUtils.IsValid(value));
                _ratio = value;
            }
        }

        /// <summary>
        ///     The first revolute/prismatic joint attached to the gear joint.
        /// </summary>
        public Joint JointA { get; }

        /// <summary>
        ///     The second revolute/prismatic joint attached to the gear joint.
        /// </summary>
        public Joint JointB { get; }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2F GetReactionForce(float invDt)
        {
            Vector2F P = _impulse * _JvAC;
            return invDt * P;
        }

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt)
        {
            float L = _impulse * _JwA;
            return invDt * L;
        }

        /// <summary>
        ///     Inits the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void InitVelocityConstraints(ref SolverData data)
        {
            _indexA = _bodyA.IslandIndex;
            _indexB = _bodyB.IslandIndex;
            _indexC = _bodyC.IslandIndex;
            _indexD = _bodyD.IslandIndex;
            _lcA = _bodyA._sweep.LocalCenter;
            _lcB = _bodyB._sweep.LocalCenter;
            _lcC = _bodyC._sweep.LocalCenter;
            _lcD = _bodyD._sweep.LocalCenter;
            _mA = _bodyA._invMass;
            _mB = _bodyB._invMass;
            _mC = _bodyC._invMass;
            _mD = _bodyD._invMass;
            _iA = _bodyA._invI;
            _iB = _bodyB._invI;
            _iC = _bodyC._invI;
            _iD = _bodyD._invI;

            float aA = data.positions[_indexA].a;
            Vector2F vA = data.velocities[_indexA].v;
            float wA = data.velocities[_indexA].w;

            float aB = data.positions[_indexB].a;
            Vector2F vB = data.velocities[_indexB].v;
            float wB = data.velocities[_indexB].w;

            float aC = data.positions[_indexC].a;
            Vector2F vC = data.velocities[_indexC].v;
            float wC = data.velocities[_indexC].w;

            float aD = data.positions[_indexD].a;
            Vector2F vD = data.velocities[_indexD].v;
            float wD = data.velocities[_indexD].w;

            Complex qA = Complex.FromAngle(aA);
            Complex qB = Complex.FromAngle(aB);
            Complex qC = Complex.FromAngle(aC);
            Complex qD = Complex.FromAngle(aD);

            _mass = 0.0f;

            if (_typeA == JointType.Revolute)
            {
                _JvAC = Vector2F.Zero;
                _JwA = 1.0f;
                _JwC = 1.0f;
                _mass += _iA + _iC;
            }
            else
            {
                Vector2F u = Complex.Multiply(ref _localAxisC, ref qC);
                Vector2F rC = Complex.Multiply(_localAnchorC - _lcC, ref qC);
                Vector2F rA = Complex.Multiply(_localAnchorA - _lcA, ref qA);
                _JvAC = u;
                _JwC = MathUtils.Cross(ref rC, ref u);
                _JwA = MathUtils.Cross(ref rA, ref u);
                _mass += _mC + _mA + _iC * _JwC * _JwC + _iA * _JwA * _JwA;
            }

            if (_typeB == JointType.Revolute)
            {
                _JvBD = Vector2F.Zero;
                _JwB = _ratio;
                _JwD = _ratio;
                _mass += _ratio * _ratio * (_iB + _iD);
            }
            else
            {
                Vector2F u = Complex.Multiply(ref _localAxisD, ref qD);
                Vector2F rD = Complex.Multiply(_localAnchorD - _lcD, ref qD);
                Vector2F rB = Complex.Multiply(_localAnchorB - _lcB, ref qB);
                _JvBD = _ratio * u;
                _JwD = _ratio * MathUtils.Cross(ref rD, ref u);
                _JwB = _ratio * MathUtils.Cross(ref rB, ref u);
                _mass += _ratio * _ratio * (_mD + _mB) + _iD * _JwD * _JwD + _iB * _JwB * _JwB;
            }

            // Compute effective mass.
            _mass = _mass > 0.0f ? 1.0f / _mass : 0.0f;

            if (data.step.warmStarting)
            {
                vA += _mA * _impulse * _JvAC;
                wA += _iA * _impulse * _JwA;
                vB += _mB * _impulse * _JvBD;
                wB += _iB * _impulse * _JwB;
                vC -= _mC * _impulse * _JvAC;
                wC -= _iC * _impulse * _JwC;
                vD -= _mD * _impulse * _JvBD;
                wD -= _iD * _impulse * _JwD;
            }
            else
            {
                _impulse = 0.0f;
            }

            data.velocities[_indexA].v = vA;
            data.velocities[_indexA].w = wA;
            data.velocities[_indexB].v = vB;
            data.velocities[_indexB].w = wB;
            data.velocities[_indexC].v = vC;
            data.velocities[_indexC].w = wC;
            data.velocities[_indexD].v = vD;
            data.velocities[_indexD].w = wD;
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
            Vector2F vC = data.velocities[_indexC].v;
            float wC = data.velocities[_indexC].w;
            Vector2F vD = data.velocities[_indexD].v;
            float wD = data.velocities[_indexD].w;

            float Cdot = Vector2F.Dot(_JvAC, vA - vC) + Vector2F.Dot(_JvBD, vB - vD);
            Cdot += _JwA * wA - _JwC * wC + (_JwB * wB - _JwD * wD);

            float impulse = -_mass * Cdot;
            _impulse += impulse;

            vA += _mA * impulse * _JvAC;
            wA += _iA * impulse * _JwA;
            vB += _mB * impulse * _JvBD;
            wB += _iB * impulse * _JwB;
            vC -= _mC * impulse * _JvAC;
            wC -= _iC * impulse * _JwC;
            vD -= _mD * impulse * _JvBD;
            wD -= _iD * impulse * _JwD;

            data.velocities[_indexA].v = vA;
            data.velocities[_indexA].w = wA;
            data.velocities[_indexB].v = vB;
            data.velocities[_indexB].w = wB;
            data.velocities[_indexC].v = vC;
            data.velocities[_indexC].w = wC;
            data.velocities[_indexD].v = vD;
            data.velocities[_indexD].w = wD;
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(ref SolverData data)
        {
            Vector2F cA = data.positions[_indexA].c;
            float aA = data.positions[_indexA].a;
            Vector2F cB = data.positions[_indexB].c;
            float aB = data.positions[_indexB].a;
            Vector2F cC = data.positions[_indexC].c;
            float aC = data.positions[_indexC].a;
            Vector2F cD = data.positions[_indexD].c;
            float aD = data.positions[_indexD].a;

            Complex qA = Complex.FromAngle(aA);
            Complex qB = Complex.FromAngle(aB);
            Complex qC = Complex.FromAngle(aC);
            Complex qD = Complex.FromAngle(aD);

            const float linearError = 0.0f;

            float coordinateA, coordinateB;

            Vector2F JvAC, JvBD;
            float JwA, JwB, JwC, JwD;
            float mass = 0.0f;

            if (_typeA == JointType.Revolute)
            {
                JvAC = Vector2F.Zero;
                JwA = 1.0f;
                JwC = 1.0f;
                mass += _iA + _iC;

                coordinateA = aA - aC - _referenceAngleA;
            }
            else
            {
                Vector2F u = Complex.Multiply(ref _localAxisC, ref qC);
                Vector2F rC = Complex.Multiply(_localAnchorC - _lcC, ref qC);
                Vector2F rA = Complex.Multiply(_localAnchorA - _lcA, ref qA);
                JvAC = u;
                JwC = MathUtils.Cross(ref rC, ref u);
                JwA = MathUtils.Cross(ref rA, ref u);
                mass += _mC + _mA + _iC * JwC * JwC + _iA * JwA * JwA;

                Vector2F pC = _localAnchorC - _lcC;
                Vector2F pA = Complex.Divide(rA + (cA - cC), ref qC);
                coordinateA = Vector2F.Dot(pA - pC, _localAxisC);
            }

            if (_typeB == JointType.Revolute)
            {
                JvBD = Vector2F.Zero;
                JwB = _ratio;
                JwD = _ratio;
                mass += _ratio * _ratio * (_iB + _iD);

                coordinateB = aB - aD - _referenceAngleB;
            }
            else
            {
                Vector2F u = Complex.Multiply(ref _localAxisD, ref qD);
                Vector2F rD = Complex.Multiply(_localAnchorD - _lcD, ref qD);
                Vector2F rB = Complex.Multiply(_localAnchorB - _lcB, ref qB);
                JvBD = _ratio * u;
                JwD = _ratio * MathUtils.Cross(ref rD, ref u);
                JwB = _ratio * MathUtils.Cross(ref rB, ref u);
                mass += _ratio * _ratio * (_mD + _mB) + _iD * JwD * JwD + _iB * JwB * JwB;

                Vector2F pD = _localAnchorD - _lcD;
                Vector2F pB = Complex.Divide(rB + (cB - cD), ref qD);
                coordinateB = Vector2F.Dot(pB - pD, _localAxisD);
            }

            float C = coordinateA + _ratio * coordinateB - _constant;

            float impulse = 0.0f;
            if (mass > 0.0f)
            {
                impulse = -C / mass;
            }

            cA += _mA * impulse * JvAC;
            aA += _iA * impulse * JwA;
            cB += _mB * impulse * JvBD;
            aB += _iB * impulse * JwB;
            cC -= _mC * impulse * JvAC;
            aC -= _iC * impulse * JwC;
            cD -= _mD * impulse * JvBD;
            aD -= _iD * impulse * JwD;

            data.positions[_indexA].c = cA;
            data.positions[_indexA].a = aA;
            data.positions[_indexB].c = cB;
            data.positions[_indexB].a = aB;
            data.positions[_indexC].c = cC;
            data.positions[_indexC].a = aC;
            data.positions[_indexD].c = cD;
            data.positions[_indexD].a = aD;


            return linearError < SettingEnv.LinearSlop;
        }
    }
}