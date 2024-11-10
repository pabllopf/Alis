// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PulleyJoint.cs
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
    // Pulley:
    // length1 = norm(p1 - s1)
    // length2 = norm(p2 - s2)
    // C0 = (length1 + ratio * length2)_initial
    // C = C0 - (length1 + ratio * length2)
    // u1 = (p1 - s1) / norm(p1 - s1)
    // u2 = (p2 - s2) / norm(p2 - s2)
    // Cdot = -dot(u1, v1 + cross(w1, r1)) - ratio * dot(u2, v2 + cross(w2, r2))
    // J = -[u1 cross(r1, u1) ratio * u2  ratio * cross(r2, u2)]
    // K = J * invM * JT
    //   = invMass1 + invI1 * cross(r1, u1)^2 + ratio^2 * (invMass2 + invI2 * cross(r2, u2)^2)
    
    /// <summary>
    ///     The pulley joint is connected to two bodies and two fixed world points.
    ///     The pulley supports a ratio such that:
    ///     <![CDATA[length1 + ratio * length2 <= constant]]>
    ///     Yes, the force transmitted is scaled by the ratio.
    ///     Warning: the pulley joint can get a bit squirrelly by itself. They often
    ///     work better when combined with prismatic joints. You should also cover the
    ///     the anchor points with static shapes to prevent one side from going to zero length.
    /// </summary>
    public class PulleyJoint : Joint
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
        private Vector2 _rA;
        
        /// <summary>
        ///     The
        /// </summary>
        private Vector2 _rB;
        
        /// <summary>
        ///     The
        /// </summary>
        private Vector2 _uA;
        
        /// <summary>
        ///     The
        /// </summary>
        private Vector2 _uB;
        
        /// <summary>
        ///     The inv ia
        /// </summary>
        private float invIa;
        
        /// <summary>
        ///     The inv ib
        /// </summary>
        private float invIb;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="PulleyJoint" /> class
        /// </summary>
        internal PulleyJoint() => JointType = JointType.Pulley;
        
        /// <summary>
        ///     Constructor for PulleyJoint.
        /// </summary>
        /// <param name="bodyA">The first body.</param>
        /// <param name="bodyB">The second body.</param>
        /// <param name="anchorA">The anchor on the first body.</param>
        /// <param name="anchorB">The anchor on the second body.</param>
        /// <param name="worldAnchorA">The world anchor for the first body.</param>
        /// <param name="worldAnchorB">The world anchor for the second body.</param>
        /// <param name="ratio">The ratio.</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public PulleyJoint(Body bodyA, Body bodyB, Vector2 anchorA, Vector2 anchorB, Vector2 worldAnchorA, Vector2 worldAnchorB, float ratio, bool useWorldCoordinates = false)
            : base(bodyA, bodyB)
        {
            JointType = JointType.Pulley;
            
            WorldAnchorA = worldAnchorA;
            WorldAnchorB = worldAnchorB;
            
            if (useWorldCoordinates)
            {
                LocalAnchorA = BodyA.GetLocalPoint(anchorA);
                LocalAnchorB = BodyB.GetLocalPoint(anchorB);
                
                Vector2 dA = anchorA - worldAnchorA;
                LengthA = dA.Length();
                Vector2 dB = anchorB - worldAnchorB;
                LengthB = dB.Length();
            }
            else
            {
                LocalAnchorA = anchorA;
                LocalAnchorB = anchorB;
                
                Vector2 dA = anchorA - BodyA.GetLocalPoint(worldAnchorA);
                LengthA = dA.Length();
                Vector2 dB = anchorB - BodyB.GetLocalPoint(worldAnchorB);
                LengthB = dB.Length();
            }
            
            Debug.Assert(Math.Abs(ratio) > SettingEnv.Epsilon);
            Debug.Assert(ratio > SettingEnv.Epsilon);
            
            Ratio = ratio;
            Constant = LengthA + ratio * LengthB;
            _impulse = 0.0f;
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
        ///     Get the first world anchor.
        /// </summary>
        /// <value></value>
        public sealed override Vector2 WorldAnchorA { get; set; }
        
        /// <summary>
        ///     Get the second world anchor.
        /// </summary>
        /// <value></value>
        public sealed override Vector2 WorldAnchorB { get; set; }
        
        /// <summary>
        ///     Get the current length of the segment attached to body1.
        /// </summary>
        /// <value></value>
        public float LengthA { get; set; }
        
        /// <summary>
        ///     Get the current length of the segment attached to body2.
        /// </summary>
        /// <value></value>
        public float LengthB { get; set; }
        
        /// <summary>
        ///     The current length between the anchor point on BodyA and WorldAnchorA
        /// </summary>
        public float CurrentLengthA
        {
            get
            {
                Vector2 p = BodyA.GetWorldPoint(LocalAnchorA);
                Vector2 s = WorldAnchorA;
                Vector2 d = p - s;
                return d.Length();
            }
        }
        
        /// <summary>
        ///     The current length between the anchor point on BodyB and WorldAnchorB
        /// </summary>
        public float CurrentLengthB
        {
            get
            {
                Vector2 p = BodyB.GetWorldPoint(LocalAnchorB);
                Vector2 s = WorldAnchorB;
                Vector2 d = p - s;
                return d.Length();
            }
        }
        
        /// <summary>
        ///     Get the pulley ratio.
        /// </summary>
        /// <value></value>
        public float Ratio { get; set; }
        
        //FPE note: Only used for serialization.
        /// <summary>
        ///     Gets or sets the value of the constant
        /// </summary>
        internal float Constant { get; set; }
        
        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2 GetReactionForce(float invDt)
        {
            Vector2 p = _impulse * _uB;
            return invDt * p;
        }
        
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
            
            // Get the pulley axes.
            _uA = cA + _rA - WorldAnchorA;
            _uB = cB + _rB - WorldAnchorB;
            
            float lengthA = _uA.Length();
            float lengthB = _uB.Length();
            
            if (lengthA > 10.0f * SettingEnv.LinearSlop)
            {
                _uA *= 1.0f / lengthA;
            }
            else
            {
                _uA = Vector2.Zero;
            }
            
            if (lengthB > 10.0f * SettingEnv.LinearSlop)
            {
                _uB *= 1.0f / lengthB;
            }
            else
            {
                _uB = Vector2.Zero;
            }
            
            // Compute effective mass.
            float ruA = MathUtils.Cross(ref _rA, ref _uA);
            float ruB = MathUtils.Cross(ref _rB, ref _uB);
            
            float mA = _invMassA + invIa * ruA * ruA;
            float mB = _invMassB + invIb * ruB * ruB;
            
            _mass = mA + Ratio * Ratio * mB;
            
            if (_mass > 0.0f)
            {
                _mass = 1.0f / _mass;
            }
            
            if (data.step.warmStarting)
            {
                // Scale impulses to support variable time steps.
                _impulse *= data.step.dtRatio;
                
                // Warm starting.
                Vector2 pa = -_impulse * _uA;
                Vector2 pb = -Ratio * _impulse * _uB;
                
                vA += _invMassA * pa;
                wA += invIa * MathUtils.Cross(ref _rA, ref pa);
                vB += _invMassB * pb;
                wB += invIb * MathUtils.Cross(ref _rB, ref pb);
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
            
            Vector2 vpA = vA + MathUtils.Cross(wA, ref _rA);
            Vector2 vpB = vB + MathUtils.Cross(wB, ref _rB);
            
            float cdot = -Vector2.Dot(_uA, vpA) - Ratio * Vector2.Dot(_uB, vpB);
            float impulse = -_mass * cdot;
            _impulse += impulse;
            
            Vector2 pa = -impulse * _uA;
            Vector2 pb = -Ratio * impulse * _uB;
            vA += _invMassA * pa;
            wA += invIa * MathUtils.Cross(ref _rA, ref pa);
            vB += _invMassB * pb;
            wB += invIb * MathUtils.Cross(ref _rB, ref pb);
            
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
            
            // Get the pulley axes.
            Vector2 uA = cA + rA - WorldAnchorA;
            Vector2 uB = cB + rB - WorldAnchorB;
            
            float lengthA = uA.Length();
            float lengthB = uB.Length();
            
            if (lengthA > 10.0f * SettingEnv.LinearSlop)
            {
                uA *= 1.0f / lengthA;
            }
            else
            {
                uA = Vector2.Zero;
            }
            
            if (lengthB > 10.0f * SettingEnv.LinearSlop)
            {
                uB *= 1.0f / lengthB;
            }
            else
            {
                uB = Vector2.Zero;
            }
            
            // Compute effective mass.
            float ruA = MathUtils.Cross(ref rA, ref uA);
            float ruB = MathUtils.Cross(ref rB, ref uB);
            
            float mA = _invMassA + invIa * ruA * ruA;
            float mB = _invMassB + invIb * ruB * ruB;
            
            float mass = mA + Ratio * Ratio * mB;
            
            if (mass > 0.0f)
            {
                mass = 1.0f / mass;
            }
            
            float c = Constant - lengthA - Ratio * lengthB;
            float linearError = Math.Abs(c);
            
            float impulse = -mass * c;
            
            Vector2 pa = -impulse * uA;
            Vector2 pb = -Ratio * impulse * uB;
            
            cA += _invMassA * pa;
            aA += invIa * MathUtils.Cross(ref rA, ref pa);
            cB += _invMassB * pb;
            aB += invIb * MathUtils.Cross(ref rB, ref pb);
            
            data.positions[_indexA].c = cA;
            data.positions[_indexA].a = aA;
            data.positions[_indexB].c = cB;
            data.positions[_indexB].a = aB;
            
            return linearError < SettingEnv.LinearSlop;
        }
    }
}