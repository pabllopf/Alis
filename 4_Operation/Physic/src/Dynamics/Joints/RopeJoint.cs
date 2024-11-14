// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RopeJoint.cs
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
    ///     A rope joint enforces a maximum distance between two points on two bodies. It has no other effect.
    ///     It can be used on ropes that are made up of several connected bodies, and if there is a need to support a heavy
    ///     body.
    ///     This joint is used for stabiliation of heavy objects on soft constraint joints.
    ///     Warning: if you attempt to change the maximum length during the simulation you will get some non-physical behavior.
    ///     Use the DistanceJoint instead if you want to dynamically control the length.
    /// </summary>
    /// <remarks>
    ///     Limit:
    ///     C = norm(pB - pA) - L
    ///     u = (pB - pA) / norm(pB - pA)
    ///     Cdot = dot(u, vB + cross(wB, rB) - vA - cross(wA, rA))
    ///     J = [-u -cross(rA, u) u cross(rB, u)]
    ///     K = J * invM * JT
    ///     = invMassA + invIA * cross(rA, u)^2 + invMassB + invIB * cross(rB, u)^2
    /// </remarks>
    public class RopeJoint : Joint
    {
        // Solver shared
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
        ///     The length
        /// </summary>
        private float _length;

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
        private float _mass;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2 _rA, _rB;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2 _u;

        /// <summary>
        ///     The inv ia
        /// </summary>
        private float invIa;

        /// <summary>
        ///     The inv ib
        /// </summary>
        private float invIb;

        /// <summary>
        ///     Initializes a new instance of the <see cref="RopeJoint" /> class
        /// </summary>
        internal RopeJoint() => JointType = JointType.Rope;

        /// <summary>
        ///     Constructor for RopeJoint.
        /// </summary>
        /// <param name="bodyA">The first body</param>
        /// <param name="bodyB">The second body</param>
        /// <param name="anchorA">The anchor on the first body</param>
        /// <param name="anchorB">The anchor on the second body</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public RopeJoint(Body bodyA, Body bodyB, Vector2 anchorA, Vector2 anchorB, bool useWorldCoordinates = false)
            : base(bodyA, bodyB)
        {
            JointType = JointType.Rope;

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

            //FPE feature: Setting default MaxLength
            Vector2 d = WorldAnchorB - WorldAnchorA;
            MaxLength = d.Length();
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
        public sealed override Vector2 WorldAnchorA
        {
            get => BodyA.GetWorldPoint(LocalAnchorA);
            set => LocalAnchorA = BodyA.GetLocalPoint(value);
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public sealed override Vector2 WorldAnchorB
        {
            get => BodyB.GetWorldPoint(LocalAnchorB);
            set => LocalAnchorB = BodyB.GetLocalPoint(value);
        }

        /// <summary>
        ///     Get or set the maximum length of the rope.
        ///     By default, it is the distance between the two anchor points.
        /// </summary>
        public float MaxLength { get; set; }

        /// <summary>
        ///     Gets the state of the joint.
        /// </summary>
        public LimitState State { get; private set; }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2 GetReactionForce(float invDt) => invDt * _impulse * _u;

        /// <summary>
        ///     Gets the reaction torque using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The float</returns>
        public override float GetReactionTorque(float invDt) => 0;

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

            _rA = Complex.Multiply(LocalAnchorA - _localCenterA, ref qA);
            _rB = Complex.Multiply(LocalAnchorB - _localCenterB, ref qB);
            _u = cB + _rB - cA - _rA;

            _length = _u.Length();

            float c = _length - MaxLength;
            if (c > 0.0f)
            {
                State = LimitState.AtUpper;
            }
            else
            {
                State = LimitState.Inactive;
            }

            if (_length > SettingEnv.LinearSlop)
            {
                _u *= 1.0f / _length;
            }
            else
            {
                _u = Vector2.Zero;
                _mass = 0.0f;
                _impulse = 0.0f;
                return;
            }

            // Compute effective mass.
            float crA = MathUtils.Cross(ref _rA, ref _u);
            float crB = MathUtils.Cross(ref _rB, ref _u);
            float invMass = _invMassA + invIa * crA * crA + _invMassB + invIb * crB * crB;

            _mass = Math.Abs(invMass) >= float.Epsilon ? 1.0f / invMass : 0.0f;

            if (data.step.warmStarting)
            {
                // Scale the impulse to support a variable time step.
                _impulse *= data.step.dtRatio;

                Vector2 p = _impulse * _u;
                vA -= _invMassA * p;
                wA -= invIa * MathUtils.Cross(ref _rA, ref p);
                vB += _invMassB * p;
                wB += invIb * MathUtils.Cross(ref _rB, ref p);
            }
            else
            {
                _impulse = 0.0f;
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

            // Cdot = dot(u, v + cross(w, r))
            Vector2 vpA = vA + MathUtils.Cross(wA, ref _rA);
            Vector2 vpB = vB + MathUtils.Cross(wB, ref _rB);
            float c = _length - MaxLength;
            float cdot = Vector2.Dot(_u, vpB - vpA);

            // Predictive constraint.
            if (c < 0.0f)
            {
                cdot += data.step.inv_dt * c;
            }

            float impulse = -_mass * cdot;
            float oldImpulse = _impulse;
            _impulse = Math.Min(0.0f, _impulse + impulse);
            impulse = _impulse - oldImpulse;

            Vector2 p = impulse * _u;
            vA -= _invMassA * p;
            wA -= invIa * MathUtils.Cross(ref _rA, ref p);
            vB += _invMassB * p;
            wB += invIb * MathUtils.Cross(ref _rB, ref p);

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
            Vector2 u = cB + rB - cA - rA;

            float length = u.Length();
            u.Normalize();
            float c = length - MaxLength;

            c = MathUtils.Clamp(c, 0.0f, SettingEnv.MaxLinearCorrection);

            float impulse = -_mass * c;
            Vector2 p = impulse * u;

            cA -= _invMassA * p;
            aA -= invIa * MathUtils.Cross(ref rA, ref p);
            cB += _invMassB * p;
            aB += invIb * MathUtils.Cross(ref rB, ref p);

            data.positions[_indexA].c = cA;
            data.positions[_indexA].a = aA;
            data.positions[_indexB].c = cB;
            data.positions[_indexB].a = aB;

            return length - MaxLength < SettingEnv.LinearSlop;
        }
    }
}