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
        private Vector2F jvAc;

        /// <summary>
        ///     The jv bd
        /// </summary>
        private Vector2F jvBd;

        /// <summary>
        ///     The jw
        /// </summary>
        private float jwA;

        /// <summary>
        ///     The jw
        /// </summary>
        private float jwB;

        /// <summary>
        ///     The jw
        /// </summary>
        private float jwC;

        /// <summary>
        ///     The jw
        /// </summary>
        private float jwD;

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
                Vector2F pA = Complex.Divide(Complex.Multiply(ref _localAnchorA, ref xfA.Q) + (xfA.P - xfC.P), ref xfC.Q);
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
                Vector2F pB = Complex.Divide(Complex.Multiply(ref _localAnchorB, ref xfB.Q) + (xfB.P - xfD.P), ref xfD.Q);
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
            Vector2F p = _impulse * jvAc;
            return invDt * p;
        }

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt)
        {
            float l = _impulse * jwA;
            return invDt * l;
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
            _mA = _bodyA.InvMass;
            _mB = _bodyB.InvMass;
            _mC = _bodyC.InvMass;
            _mD = _bodyD.InvMass;
            _iA = _bodyA.InvI;
            _iB = _bodyB.InvI;
            _iC = _bodyC.InvI;
            _iD = _bodyD.InvI;

            float aA = data.Positions[_indexA].A;
            Vector2F vA = data.Velocities[_indexA].V;
            float wA = data.Velocities[_indexA].W;

            float aB = data.Positions[_indexB].A;
            Vector2F vB = data.Velocities[_indexB].V;
            float wB = data.Velocities[_indexB].W;

            float aC = data.Positions[_indexC].A;
            Vector2F vC = data.Velocities[_indexC].V;
            float wC = data.Velocities[_indexC].W;

            float aD = data.Positions[_indexD].A;
            Vector2F vD = data.Velocities[_indexD].V;
            float wD = data.Velocities[_indexD].W;

            Complex qA = Complex.FromAngle(aA);
            Complex qB = Complex.FromAngle(aB);
            Complex qC = Complex.FromAngle(aC);
            Complex qD = Complex.FromAngle(aD);

            _mass = 0.0f;

            if (_typeA == JointType.Revolute)
            {
                jvAc = Vector2F.Zero;
                jwA = 1.0f;
                jwC = 1.0f;
                _mass += _iA + _iC;
            }
            else
            {
                Vector2F u = Complex.Multiply(ref _localAxisC, ref qC);
                Vector2F rC = Complex.Multiply(_localAnchorC - _lcC, ref qC);
                Vector2F rA = Complex.Multiply(_localAnchorA - _lcA, ref qA);
                jvAc = u;
                jwC = MathUtils.Cross(ref rC, ref u);
                jwA = MathUtils.Cross(ref rA, ref u);
                _mass += _mC + _mA + _iC * jwC * jwC + _iA * jwA * jwA;
            }

            if (_typeB == JointType.Revolute)
            {
                jvBd = Vector2F.Zero;
                jwB = _ratio;
                jwD = _ratio;
                _mass += _ratio * _ratio * (_iB + _iD);
            }
            else
            {
                Vector2F u = Complex.Multiply(ref _localAxisD, ref qD);
                Vector2F rD = Complex.Multiply(_localAnchorD - _lcD, ref qD);
                Vector2F rB = Complex.Multiply(_localAnchorB - _lcB, ref qB);
                jvBd = _ratio * u;
                jwD = _ratio * MathUtils.Cross(ref rD, ref u);
                jwB = _ratio * MathUtils.Cross(ref rB, ref u);
                _mass += _ratio * _ratio * (_mD + _mB) + _iD * jwD * jwD + _iB * jwB * jwB;
            }

            // Compute effective mass.
            _mass = _mass > 0.0f ? 1.0f / _mass : 0.0f;

            if (data.Step.WarmStarting)
            {
                vA += _mA * _impulse * jvAc;
                wA += _iA * _impulse * jwA;
                vB += _mB * _impulse * jvBd;
                wB += _iB * _impulse * jwB;
                vC -= _mC * _impulse * jvAc;
                wC -= _iC * _impulse * jwC;
                vD -= _mD * _impulse * jvBd;
                wD -= _iD * _impulse * jwD;
            }
            else
            {
                _impulse = 0.0f;
            }

            data.Velocities[_indexA].V = vA;
            data.Velocities[_indexA].W = wA;
            data.Velocities[_indexB].V = vB;
            data.Velocities[_indexB].W = wB;
            data.Velocities[_indexC].V = vC;
            data.Velocities[_indexC].W = wC;
            data.Velocities[_indexD].V = vD;
            data.Velocities[_indexD].W = wD;
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
            Vector2F vC = data.Velocities[_indexC].V;
            float wC = data.Velocities[_indexC].W;
            Vector2F vD = data.Velocities[_indexD].V;
            float wD = data.Velocities[_indexD].W;

            float cdot = Vector2F.Dot(jvAc, vA - vC) + Vector2F.Dot(jvBd, vB - vD);
            cdot += jwA * wA - jwC * wC + (jwB * wB - jwD * wD);

            float impulse = -_mass * cdot;
            _impulse += impulse;

            vA += _mA * impulse * jvAc;
            wA += _iA * impulse * jwA;
            vB += _mB * impulse * jvBd;
            wB += _iB * impulse * jwB;
            vC -= _mC * impulse * jvAc;
            wC -= _iC * impulse * jwC;
            vD -= _mD * impulse * jvBd;
            wD -= _iD * impulse * jwD;

            data.Velocities[_indexA].V = vA;
            data.Velocities[_indexA].W = wA;
            data.Velocities[_indexB].V = vB;
            data.Velocities[_indexB].W = wB;
            data.Velocities[_indexC].V = vC;
            data.Velocities[_indexC].W = wC;
            data.Velocities[_indexD].V = vD;
            data.Velocities[_indexD].W = wD;
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
            Vector2F cC = data.Positions[_indexC].C;
            float aC = data.Positions[_indexC].A;
            Vector2F cD = data.Positions[_indexD].C;
            float aD = data.Positions[_indexD].A;

            Complex qA = Complex.FromAngle(aA);
            Complex qB = Complex.FromAngle(aB);
            Complex qC = Complex.FromAngle(aC);
            Complex qD = Complex.FromAngle(aD);

            const float linearError = 0.0f;

            float coordinateA, coordinateB;

            Vector2F jvAc, jvBd;
            float jwA, jwB, jwC, jwD;
            float mass = 0.0f;

            if (_typeA == JointType.Revolute)
            {
                jvAc = Vector2F.Zero;
                jwA = 1.0f;
                jwC = 1.0f;
                mass += _iA + _iC;

                coordinateA = aA - aC - _referenceAngleA;
            }
            else
            {
                Vector2F u = Complex.Multiply(ref _localAxisC, ref qC);
                Vector2F rC = Complex.Multiply(_localAnchorC - _lcC, ref qC);
                Vector2F rA = Complex.Multiply(_localAnchorA - _lcA, ref qA);
                jvAc = u;
                jwC = MathUtils.Cross(ref rC, ref u);
                jwA = MathUtils.Cross(ref rA, ref u);
                mass += _mC + _mA + _iC * jwC * jwC + _iA * jwA * jwA;

                Vector2F pC = _localAnchorC - _lcC;
                Vector2F pA = Complex.Divide(rA + (cA - cC), ref qC);
                coordinateA = Vector2F.Dot(pA - pC, _localAxisC);
            }

            if (_typeB == JointType.Revolute)
            {
                jvBd = Vector2F.Zero;
                jwB = _ratio;
                jwD = _ratio;
                mass += _ratio * _ratio * (_iB + _iD);

                coordinateB = aB - aD - _referenceAngleB;
            }
            else
            {
                Vector2F u = Complex.Multiply(ref _localAxisD, ref qD);
                Vector2F rD = Complex.Multiply(_localAnchorD - _lcD, ref qD);
                Vector2F rB = Complex.Multiply(_localAnchorB - _lcB, ref qB);
                jvBd = _ratio * u;
                jwD = _ratio * MathUtils.Cross(ref rD, ref u);
                jwB = _ratio * MathUtils.Cross(ref rB, ref u);
                mass += _ratio * _ratio * (_mD + _mB) + _iD * jwD * jwD + _iB * jwB * jwB;

                Vector2F pD = _localAnchorD - _lcD;
                Vector2F pB = Complex.Divide(rB + (cB - cD), ref qD);
                coordinateB = Vector2F.Dot(pB - pD, _localAxisD);
            }

            float c = coordinateA + _ratio * coordinateB - _constant;

            float impulse = 0.0f;
            if (mass > 0.0f)
            {
                impulse = -c / mass;
            }

            cA += _mA * impulse * jvAc;
            aA += _iA * impulse * jwA;
            cB += _mB * impulse * jvBd;
            aB += _iB * impulse * jwB;
            cC -= _mC * impulse * jvAc;
            aC -= _iC * impulse * jwC;
            cD -= _mD * impulse * jvBd;
            aD -= _iD * impulse * jwD;

            data.Positions[_indexA].C = cA;
            data.Positions[_indexA].A = aA;
            data.Positions[_indexB].C = cB;
            data.Positions[_indexB].A = aB;
            data.Positions[_indexC].C = cC;
            data.Positions[_indexC].A = aC;
            data.Positions[_indexD].C = cD;
            data.Positions[_indexD].A = aD;


            return linearError < SettingEnv.LinearSlop;
        }
    }
}