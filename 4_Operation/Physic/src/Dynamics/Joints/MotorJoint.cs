// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MotorJoint.cs
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
    ///     A motor joint is used to control the relative motion
    ///     between two bodies. A typical usage is to control the movement
    ///     of a dynamic body with respect to the ground.
    /// </summary>
    public class MotorJoint : Joint
    {
        /// <summary>
        ///     The angular error
        /// </summary>
        private float _angularError;
        
        /// <summary>
        ///     The angular impulse
        /// </summary>
        private float _angularImpulse;
        
        /// <summary>
        ///     The angular mass
        /// </summary>
        private float _angularMass;
        
        /// <summary>
        ///     The angular offset
        /// </summary>
        private float _angularOffset;
        
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
        ///     The linear error
        /// </summary>
        private Vector2 _linearError;
        
        /// <summary>
        ///     The linear impulse
        /// </summary>
        private Vector2 _linearImpulse;
        
        /// <summary>
        ///     The linear mass
        /// </summary>
        private Mat22 _linearMass;
        
        // Solver shared
        /// <summary>
        ///     The linear offset
        /// </summary>
        private Vector2 _linearOffset;
        
        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 _localCenterA;
        
        /// <summary>
        ///     The local center
        /// </summary>
        private Vector2 _localCenterB;
        
        /// <summary>
        ///     The max force
        /// </summary>
        private float _maxForce;
        
        /// <summary>
        ///     The max torque
        /// </summary>
        private float _maxTorque;
        
        /// <summary>
        ///     The
        /// </summary>
        private Vector2 _rA;
        
        /// <summary>
        ///     The
        /// </summary>
        private Vector2 _rB;
        
        /// <summary>
        ///     The inv ia
        /// </summary>
        private float invIa;
        
        /// <summary>
        ///     The inv ib
        /// </summary>
        private float invIb;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="MotorJoint" /> class
        /// </summary>
        internal MotorJoint() => JointType = JointType.Motor;
        
        /// <summary>
        ///     Constructor for MotorJoint.
        /// </summary>
        /// <param name="bodyA">The first body</param>
        /// <param name="bodyB">The second body</param>
        /// <param name="useWorldCoordinates">Set to true if you are using world coordinates as anchors.</param>
        public MotorJoint(Body bodyA, Body bodyB, bool useWorldCoordinates = false)
            : base(bodyA, bodyB)
        {
            JointType = JointType.Motor;
            
            Vector2 xB = BodyB.Position;
            
            _linearOffset = useWorldCoordinates ? BodyA.GetLocalPoint(xB) : xB;
            
            //Defaults
            _angularOffset = 0.0f;
            _maxForce = 1.0f;
            _maxTorque = 1.0f;
            CorrectionFactor = 0.3f;
            
            _angularOffset = BodyB.Rotation - BodyA.Rotation;
        }
        
        /// <summary>
        ///     Gets or sets the value of the world anchor a
        /// </summary>
        public override Vector2 WorldAnchorA
        {
            get => BodyA.Position;
            set
            {
                _linearError = value;
                Debug.Assert(false, "You can't set the world anchor on this joint type.");
            }
        }
        
        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public override Vector2 WorldAnchorB
        {
            get => BodyB.Position;
            set
            {
                _linearError = value;
                Debug.Assert(false, "You can't set the world anchor on this joint type.");
            }
        }
        
        /// <summary>
        ///     The maximum amount of force that can be applied to BodyA
        /// </summary>
        public float MaxForce
        {
            set
            {
                Debug.Assert(MathUtils.IsValid(value) && (value >= 0.0f));
                _maxForce = value;
            }
            get => _maxForce;
        }
        
        /// <summary>
        ///     The maximum amount of torque that can be applied to BodyA
        /// </summary>
        public float MaxTorque
        {
            set
            {
                Debug.Assert(MathUtils.IsValid(value) && (value >= 0.0f));
                _maxTorque = value;
            }
            get => _maxTorque;
        }
        
        /// <summary>
        ///     The linear (translation) offset.
        /// </summary>
        public Vector2 LinearOffset
        {
            set
            {
                if (Math.Abs(_linearOffset.X - value.X) > float.Epsilon || Math.Abs(_linearOffset.Y - value.Y) > float.Epsilon)
                {
                    WakeBodies();
                    _linearOffset = value;
                }
            }
            get => _linearOffset;
        }
        
        /// <summary>
        ///     Get or set the angular offset.
        /// </summary>
        public float AngularOffset
        {
            set
            {
                if (Math.Abs(_angularOffset - value) > float.Epsilon)
                {
                    WakeBodies();
                    _angularOffset = value;
                }
            }
            get => _angularOffset;
        }
        
        //FPE note: Used for serialization.
        /// <summary>
        ///     Gets or sets the value of the correction factor
        /// </summary>
        internal float CorrectionFactor { get; set; }
        
        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2 GetReactionForce(float invDt) => invDt * _linearImpulse;
        
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
            
            // Compute the effective mass matrix.
            _rA = -Complex.Multiply(ref _localCenterA, ref qA);
            _rB = -Complex.Multiply(ref _localCenterB, ref qB);
            
            // J = [-I -r1_skew I r2_skew]
            //     [ 0       -1 0       1]
            // r_skew = [-ry; rx]
            
            // Matlab
            // K = [ mA+r1y^2*iA+mB+r2y^2*iB,  -r1y*iA*r1x-r2y*iB*r2x,          -r1y*iA-r2y*iB]
            //     [  -r1y*iA*r1x-r2y*iB*r2x, mA+r1x^2*iA+mB+r2x^2*iB,           r1x*iA+r2x*iB]
            //     [          -r1y*iA-r2y*iB,           r1x*iA+r2x*iB,                   iA+iB]
            
            float mA = _invMassA, mB = _invMassB;
            float iA = invIa, iB = invIb;
            
            Mat22 k = new Mat22();
            k.Ex.X = mA + mB + iA * _rA.Y * _rA.Y + iB * _rB.Y * _rB.Y;
            k.Ex.Y = -iA * _rA.X * _rA.Y - iB * _rB.X * _rB.Y;
            k.Ey.X = k.Ex.Y;
            k.Ey.Y = mA + mB + iA * _rA.X * _rA.X + iB * _rB.X * _rB.X;
            
            _linearMass = k.Inverse;
            
            _angularMass = iA + iB;
            if (_angularMass > 0.0f)
            {
                _angularMass = 1.0f / _angularMass;
            }
            
            _linearError = cB + _rB - cA - _rA - Complex.Multiply(ref _linearOffset, ref qA);
            _angularError = aB - aA - _angularOffset;
            
            if (data.step.warmStarting)
            {
                // Scale impulses to support a variable time step.
                _linearImpulse *= data.step.dtRatio;
                _angularImpulse *= data.step.dtRatio;
                
                Vector2 p = new Vector2(_linearImpulse.X, _linearImpulse.Y);
                
                vA -= mA * p;
                wA -= iA * (MathUtils.Cross(ref _rA, ref p) + _angularImpulse);
                vB += mB * p;
                wB += iB * (MathUtils.Cross(ref _rB, ref p) + _angularImpulse);
            }
            else
            {
                _linearImpulse = Vector2.Zero;
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
            Vector2 vA = data.velocities[_indexA].v;
            float wA = data.velocities[_indexA].w;
            Vector2 vB = data.velocities[_indexB].v;
            float wB = data.velocities[_indexB].w;
            
            float mA = _invMassA, mB = _invMassB;
            float iA = invIa, iB = invIb;
            
            float h = data.step.dt;
            float invH = data.step.inv_dt;
            
            // Solve angular friction
            {
                float cdot = wB - wA + invH * CorrectionFactor * _angularError;
                float impulse = -_angularMass * cdot;
                
                float oldImpulse = _angularImpulse;
                float maxImpulse = h * _maxTorque;
                _angularImpulse = MathUtils.Clamp(_angularImpulse + impulse, -maxImpulse, maxImpulse);
                impulse = _angularImpulse - oldImpulse;
                
                wA -= iA * impulse;
                wB += iB * impulse;
            }
            
            // Solve linear friction
            {
                Vector2 cdot = vB + MathUtils.Cross(wB, ref _rB) - vA - MathUtils.Cross(wA, ref _rA) + invH * CorrectionFactor * _linearError;
                
                Vector2 impulse = -MathUtils.Mul(ref _linearMass, ref cdot);
                Vector2 oldImpulse = _linearImpulse;
                _linearImpulse += impulse;
                
                float maxImpulse = h * _maxForce;
                
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