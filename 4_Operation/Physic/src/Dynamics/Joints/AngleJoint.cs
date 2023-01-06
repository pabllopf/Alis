// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AngleJoint.cs
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
using Alis.Core.Physic.Dynamics.Solver;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>Maintains a fixed angle between two bodies</summary>
    public class AngleJoint : Joint
    {
        /// <summary>
        ///     The bias
        /// </summary>
        private float bias;

        /// <summary>
        ///     The bias factor
        /// </summary>
        private float biasFactor;

        /// <summary>
        ///     The joint error
        /// </summary>
        private float jointError;

        /// <summary>
        ///     The mass factor
        /// </summary>
        private float massFactor;

        /// <summary>
        ///     The max impulse
        /// </summary>
        private float maxImpulse;

        /// <summary>
        ///     The softness
        /// </summary>
        private float softness;

        /// <summary>
        ///     The target angle
        /// </summary>
        private float targetAngle;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AngleJoint" /> class
        /// </summary>
        /// <param name="bodyA">The body</param>
        /// <param name="bodyB">The body</param>
        public AngleJoint(Body bodyA, Body bodyB)
            : base(bodyA, bodyB, JointType.Angle)
        {
            biasFactor = .2f;
            maxImpulse = float.MaxValue;
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor a
        /// </summary>
        public override Vector2F WorldAnchorA
        {
            get => BodyA.Position;
            set => Debug.Assert(false, "You can't set the world anchor on this joint type.");
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public override Vector2F WorldAnchorB
        {
            get => BodyB.Position;
            set => Debug.Assert(false, "You can't set the world anchor on this joint type.");
        }

        /// <summary>The desired angle between BodyA and BodyB</summary>
        public float TargetAngle
        {
            get => targetAngle;
            set
            {
                if (targetAngle != value)
                {
                    targetAngle = value;
                    WakeBodies();
                }
            }
        }

        /// <summary>Gets or sets the bias factor. Defaults to 0.2</summary>
        public float BiasFactor
        {
            get => biasFactor;
            set => biasFactor = value;
        }

        /// <summary>Gets or sets the maximum impulse. Defaults to float.MaxValue</summary>
        public float Impulse
        {
            get => maxImpulse;
            set => maxImpulse = value;
        }

        /// <summary>Gets or sets the softness of the joint. Defaults to 0</summary>
        public float Softness
        {
            get => softness;
            set => softness = value;
        }

        /// <summary>
        ///     Gets the reaction force using the specified inv dt
        /// </summary>
        /// <param name="invDt">The inv dt</param>
        /// <returns>The vector</returns>
        public override Vector2F GetReactionForce(float invDt) => Vector2F.Zero;

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

            jointError = bW - aW - targetAngle;
            bias = -biasFactor * data.Step.InvertedDeltaTime * jointError;
            massFactor = (1 - softness) / (BodyA.InvI + BodyB.InvI);
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void SolveVelocityConstraints(ref SolverData data)
        {
            int indexA = BodyA.IslandIndex;
            int indexB = BodyB.IslandIndex;

            float p = (bias - data.Velocities[indexB].W + data.Velocities[indexA].W) * massFactor;

            data.Velocities[indexA].W -=
                BodyA.InvI * MathUtils.Sign(p) * MathUtils.Min(MathUtils.Abs(p), maxImpulse);
            data.Velocities[indexB].W +=
                BodyB.InvI * MathUtils.Sign(p) * MathUtils.Min(MathUtils.Abs(p), maxImpulse);
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