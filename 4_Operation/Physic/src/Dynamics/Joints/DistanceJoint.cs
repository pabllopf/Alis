// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceJoint.cs
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
using System.Diagnostics;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     A distance joint rains two points on two bodies
    ///     to remain at a fixed distance from each other. You can view
    ///     this as a massless, rigid rod.
    /// </summary>
    /// <remarks>
    ///     1-D rained system
    ///     m (v2 - v1) = lambda
    ///     v2 + (beta/h) * x1 + gamma * lambda = 0, gamma has units of inverse mass.
    ///     x2 = x1 + h * v2
    ///     1-D mass-damper-spring system
    ///     m (v2 - v1) + h * d * v2 + h * k *
    ///     C = norm(p2 - p1) - L
    ///     u = (p2 - p1) / norm(p2 - p1)
    ///     Cdot = dot(u, v2 + cross(w2, r2) - v1 - cross(w1, r1))
    ///     J = [-u -cross(r1, u) u cross(r2, u)]
    ///     K = J * invM * JT
    ///     = invMass1 + invI1 * cross(r1, u)^2 + invMass2 + invI2 * cross(r2, u)^2
    /// </remarks>
    public class DistanceJoint : Joint
    {
        // Solver shared
        /// <summary>
        ///     The bias
        /// </summary>
        private float _bias;

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
        private Vector2F _localCenterA;

        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2F _localCenterB;

        /// <summary>
        ///     The mass
        /// </summary>
        private float _mass;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F _rA;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F _rB;

        /// <summary>
        ///     The
        /// </summary>
        private Vector2F _u;

        /// <summary>
        ///     The inv ia
        /// </summary>
        private float invIa;

        /// <summary>
        ///     The inv ib
        /// </summary>
        private float invIb;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DistanceJoint" /> class
        /// </summary>
        internal DistanceJoint() => JointType = JointType.Distance;

        /// <summary>
        ///     This requires defining an
        ///     anchor point on both bodies and the non-zero length of the
        ///     distance joint. If you don't supply a length, the local anchor points
        ///     is used so that the initial configuration can violate the constraint
        ///     slightly. This helps when saving and loading a game.
        ///     Warning Do not use a zero or short length.
        /// </summary>
        /// <param name="bodyA">The first body</param>
        /// <param name="bodyB">The second body</param>
        /// <param name="anchorA">The first body anchor</param>
        /// <param name="anchorB">The second body anchor</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public DistanceJoint(Body bodyA, Body bodyB, Vector2F anchorA, Vector2F anchorB, bool useWorldCoordinates = false)
            : base(bodyA, bodyB)
        {
            JointType = JointType.Distance;

            if (useWorldCoordinates)
            {
                LocalAnchorA = bodyA.GetLocalPoint(ref anchorA);
                LocalAnchorB = bodyB.GetLocalPoint(ref anchorB);
                Length = (anchorB - anchorA).Length();
            }
            else
            {
                LocalAnchorA = anchorA;
                LocalAnchorB = anchorB;
                Length = (BodyB.GetWorldPoint(ref anchorB) - BodyA.GetWorldPoint(ref anchorA)).Length();
            }
        }

        /// <summary>
        ///     The local anchor point relative to bodyA's origin.
        /// </summary>
        public Vector2F LocalAnchorA { get; set; }

        /// <summary>
        ///     The local anchor point relative to bodyB's origin.
        /// </summary>
        public Vector2F LocalAnchorB { get; set; }

        /// <summary>
        ///     Gets or sets the value of the world anchor a
        /// </summary>
        public sealed override Vector2F WorldAnchorA
        {
            get => BodyA.GetWorldPoint(LocalAnchorA);
            set
            {
                _localCenterA = value;
                Debug.Assert(false, "You can't set the world anchor on this joint type.");
            }
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public sealed override Vector2F WorldAnchorB
        {
            get => BodyB.GetWorldPoint(LocalAnchorB);
            set
            {
                _localCenterA = value;
                Debug.Assert(false, "You can't set the world anchor on this joint type.");
            }
        }

        /// <summary>
        ///     The natural length between the anchor points.
        ///     Manipulating the length can lead to non-physical behavior when the frequency is zero.
        /// </summary>
        public float Length { get; set; }

        /// <summary>
        ///     The mass-spring-damper frequency in Hertz. A value of 0
        ///     disables softness.
        /// </summary>
        public float Frequency { get; set; }

        /// <summary>
        ///     The damping ratio. 0 = no damping, 1 = critical damping.
        /// </summary>
        public float DampingRatio { get; set; }

        /// <summary>
        ///     Get the reaction force given the inverse time step. Unit is N.
        /// </summary>
        /// <param name="invDt"></param>
        /// <returns></returns>
        public override Vector2F GetReactionForce(float invDt)
        {
            Vector2F f = invDt * _impulse * _u;
            return f;
        }

        /// <summary>
        ///     Get the reaction torque given the inverse time step.
        ///     Unit is N*m. This is always zero for a distance joint.
        /// </summary>
        /// <param name="invDt"></param>
        /// <returns></returns>
        public override float GetReactionTorque(float invDt) => 0.0f;

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

            Vector2F cA = data.positions[_indexA].c;
            float aA = data.positions[_indexA].a;
            Vector2F vA = data.velocities[_indexA].v;
            float wA = data.velocities[_indexA].w;

            Vector2F cB = data.positions[_indexB].c;
            float aB = data.positions[_indexB].a;
            Vector2F vB = data.velocities[_indexB].v;
            float wB = data.velocities[_indexB].w;

            Complex qA = Complex.FromAngle(aA);
            Complex qB = Complex.FromAngle(aB);

            _rA = Complex.Multiply(LocalAnchorA - _localCenterA, ref qA);
            _rB = Complex.Multiply(LocalAnchorB - _localCenterB, ref qB);
            _u = cB + _rB - cA - _rA;

            // Handle singularity.
            float length = _u.Length();
            if (length > SettingEnv.LinearSlop)
            {
                _u *= 1.0f / length;
            }
            else
            {
                _u = Vector2F.Zero;
            }

            float crAu = MathUtils.Cross(ref _rA, ref _u);
            float crBu = MathUtils.Cross(ref _rB, ref _u);
            float invMass = _invMassA + invIa * crAu * crAu + _invMassB + invIb * crBu * crBu;

            // Compute the effective mass matrix.
            _mass = Math.Abs(invMass) > float.Epsilon ? 1.0f / invMass : 0.0f;

            if (Frequency > 0.0f)
            {
                float c = length - Length;

                // Frequency
                float omega = Constant.Tau * Frequency;

                // Damping coefficient
                float d = 2.0f * _mass * DampingRatio * omega;

                // Spring stiffness
                float k = _mass * omega * omega;

                // magic formulas
                float h = data.step.dt;
                _gamma = h * (d + h * k);
                _gamma = Math.Abs(_gamma) > float.Epsilon ? 1.0f / _gamma : 0.0f;
                _bias = c * h * k * _gamma;

                invMass += _gamma;
                _mass = Math.Abs(invMass) > float.Epsilon ? 1.0f / invMass : 0.0f;
            }
            else
            {
                _gamma = 0.0f;
                _bias = 0.0f;
            }

            if (data.step.warmStarting)
            {
                // Scale the impulse to support a variable time step.
                _impulse *= data.step.dtRatio;

                Vector2F p = _impulse * _u;
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
            Vector2F vA = data.velocities[_indexA].v;
            float wA = data.velocities[_indexA].w;
            Vector2F vB = data.velocities[_indexB].v;
            float wB = data.velocities[_indexB].w;

            // Cdot = dot(u, v + cross(w, r))
            Vector2F vpA = vA + MathUtils.Cross(wA, ref _rA);
            Vector2F vpB = vB + MathUtils.Cross(wB, ref _rB);
            float cdot = Vector2F.Dot(_u, vpB - vpA);

            float impulse = -_mass * (cdot + _bias + _gamma * _impulse);
            _impulse += impulse;

            Vector2F p = impulse * _u;
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
            if (Frequency > 0.0f)
            {
                // There is no position correction for soft distance constraints.
                return true;
            }

            Vector2F cA = data.positions[_indexA].c;
            float aA = data.positions[_indexA].a;
            Vector2F cB = data.positions[_indexB].c;
            float aB = data.positions[_indexB].a;

            Complex qA = Complex.FromAngle(aA);
            Complex qB = Complex.FromAngle(aB);

            Vector2F rA = Complex.Multiply(LocalAnchorA - _localCenterA, ref qA);
            Vector2F rB = Complex.Multiply(LocalAnchorB - _localCenterB, ref qB);
            Vector2F u = cB + rB - cA - rA;

            float length = u.Length();
            u.Normalize();
            float c = length - Length;
            c = MathUtils.Clamp(c, -SettingEnv.MaxLinearCorrection, SettingEnv.MaxLinearCorrection);

            float impulse = -_mass * c;
            Vector2F p = impulse * u;

            cA -= _invMassA * p;
            aA -= invIa * MathUtils.Cross(ref rA, ref p);
            cB += _invMassB * p;
            aB += invIb * MathUtils.Cross(ref rB, ref p);

            data.positions[_indexA].c = cA;
            data.positions[_indexA].a = aA;
            data.positions[_indexB].c = cB;
            data.positions[_indexB].a = aB;

            return Math.Abs(c) < SettingEnv.LinearSlop;
        }
    }
}