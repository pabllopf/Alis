

using System;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     Maintains a fixed angle between two bodies
    /// </summary>
    public class AngleJoint : Joint
    {
        /// <summary>
        ///     The bias
        /// </summary>
        private float _bias;

        /// <summary>
        ///     The joint error
        /// </summary>
        private float _jointError;

        /// <summary>
        ///     The mass factor
        /// </summary>
        private float _massFactor;

        /// <summary>
        ///     The target angle
        /// </summary>
        private float _targetAngle;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AngleJoint" /> class
        /// </summary>
        internal AngleJoint() => JointType = JointType.Angle;

        /// <summary>
        ///     Constructor for AngleJoint
        /// </summary>
        /// <param name="bodyA">The first body</param>
        /// <param name="bodyB">The second body</param>
        public AngleJoint(Body bodyA, Body bodyB)
            : base(bodyA, bodyB)
        {
            JointType = JointType.Angle;
            BiasFactor = .2f;
            MaxImpulse = float.MaxValue;
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor a
        /// </summary>
        public override Vector2F WorldAnchorA
        {
            get => BodyA.Position;
            set { _ = value; }  // Intentionally ignored for AngleJoint
        }

        /// <summary>
        ///     Gets or sets the value of the world anchor b
        /// </summary>
        public override Vector2F WorldAnchorB
        {
            get => BodyB.Position;
            set => throw new NotSupportedException("AngleJoint does not support setting WorldAnchorB directly.");
        }

        /// <summary>
        ///     The desired angle between BodyA and BodyB
        /// </summary>
        public float TargetAngle
        {
            get => _targetAngle;
            set
            {
                if (Math.Abs(value - _targetAngle) > float.Epsilon)
                {
                    _targetAngle = value;
                    WakeBodies();
                }
            }
        }

        /// <summary>
        ///     Gets or sets the bias factor.
        ///     Defaults to 0.2
        /// </summary>
        public float BiasFactor { get; set; }

        /// <summary>
        ///     Gets or sets the maximum impulse
        ///     Defaults to float.MaxValue
        /// </summary>
        public float MaxImpulse { get; set; }

        /// <summary>
        ///     Gets or sets the softness of the joint
        ///     Defaults to 0
        /// </summary>
        public float Softness { get; set; }

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
            int indexA = BodyA.GetIslandIndex;
            int indexB = BodyB.GetIslandIndex;

            float aW = data.Positions[indexA].A;
            float bW = data.Positions[indexB].A;

            _jointError = bW - aW - TargetAngle;
            _bias = -BiasFactor * data.Step.InvDt * _jointError;
            _massFactor = (1 - Softness) / (BodyA.InvI + BodyB.InvI);
        }

        /// <summary>
        ///     Solves the velocity constraints using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        internal override void SolveVelocityConstraints(ref SolverData data)
        {
            int indexA = BodyA.GetIslandIndex;
            int indexB = BodyB.GetIslandIndex;

            float p = (_bias - data.Velocities[indexB].W + data.Velocities[indexA].W) * _massFactor;

            data.Velocities[indexA].W -= BodyA.InvI * Math.Sign(p) * Math.Min(Math.Abs(p), MaxImpulse);
            data.Velocities[indexB].W += BodyB.InvI * Math.Sign(p) * Math.Min(Math.Abs(p), MaxImpulse);
        }

        /// <summary>
        ///     Describes whether this instance solve position constraints
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The bool</returns>
        internal override bool SolvePositionConstraints(ref SolverData data) =>
            true;
    }
}