// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   AngleJoint.cs
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

using System.Diagnostics;
using System.Numerics;
using Alis.Core.Systems.Physics2D.Dynamics.Joints.Misc;
using Alis.Core.Systems.Physics2D.Dynamics.Solver;
using Alis.Core.Systems.Physics2D.Utilities;

namespace Alis.Core.Systems.Physics2D.Dynamics.Joints
{
    /// <summary>Maintains a fixed angle between two bodies</summary>
    public class AngleJoint : Joint
    {
        /// <summary>
        ///     The bias
        /// </summary>
        private float _bias;

        /// <summary>
        ///     The bias factor
        /// </summary>
        private float _biasFactor;

        /// <summary>
        ///     The joint error
        /// </summary>
        private float _jointError;

        /// <summary>
        ///     The mass factor
        /// </summary>
        private float _massFactor;

        /// <summary>
        ///     The max impulse
        /// </summary>
        private float _maxImpulse;

        /// <summary>
        ///     The softness
        /// </summary>
        private float _softness;

        /// <summary>
        ///     The target angle
        /// </summary>
        private float _targetAngle;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AngleJoint" /> class
        /// </summary>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        public AngleJoint(Body bodyA, Body bodyB)
            : base(bodyA, bodyB, JointType.Angle)
        {
            _biasFactor = .2f;
            _maxImpulse = float.MaxValue;
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor a
        /// </summary>
        public override Vector2 WorldAnchorA
        {
            get => BodyA.Position;
            set => Debug.Assert(false, "You can't set the world anchor on this joint type.");
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public override Vector2 WorldAnchorB
        {
            get => BodyB.Position;
            set => Debug.Assert(false, "You can't set the world anchor on this joint type.");
        }

        /// <summary>The desired angle between BodyA and BodyB</summary>
        public float TargetAngle
        {
            get => _targetAngle;
            set
            {
                if (_targetAngle != value)
                {
                    _targetAngle = value;
                    WakeBodies();
                }
            }
        }

        /// <summary>Gets or sets the bias factor. Defaults to 0.2</summary>
        public float BiasFactor
        {
            get => _biasFactor;
            set => _biasFactor = value;
        }

        /// <summary>Gets or sets the maximum impulse. Defaults to float.MaxValue</summary>
        public float MaxImpulse
        {
            get => _maxImpulse;
            set => _maxImpulse = value;
        }

        /// <summary>Gets or sets the softness of the joint. Defaults to 0</summary>
        public float Softness
        {
            get => _softness;
            set => _softness = value;
        }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2 GetReactionForce(float invDt) => Vector2.Zero;

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
            int indexA = BodyA.IslandIndex;
            int indexB = BodyB.IslandIndex;

            float aW = data.Positions[indexA].A;
            float bW = data.Positions[indexB].A;

            _jointError = bW - aW - _targetAngle;
            _bias = -_biasFactor * data.Step.InvertedDeltaTime * _jointError;
            _massFactor = (1 - _softness) / (BodyA._invI + BodyB._invI);
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void SolveVelocityConstraints(ref SolverData data)
        {
            int indexA = BodyA.IslandIndex;
            int indexB = BodyB.IslandIndex;

            float p = (_bias - data.Velocities[indexB].W + data.Velocities[indexA].W) * _massFactor;

            data.Velocities[indexA].W -=
                BodyA._invI * MathUtils.Sign(p) * MathUtils.Min(MathUtils.Abs(p), _maxImpulse);
            data.Velocities[indexB].W +=
                BodyB._invI * MathUtils.Sign(p) * MathUtils.Min(MathUtils.Abs(p), _maxImpulse);
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(ref SolverData data) =>
            //no position solving for this joint
            true;
    }
}