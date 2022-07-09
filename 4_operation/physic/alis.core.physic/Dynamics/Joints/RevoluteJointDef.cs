using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    /// Revolute joint definition. This requires defining an
    /// anchor point where the bodies are joined. The definition
    /// uses local anchor points so that the initial configuration
    /// can violate the constraint slightly. You also need to
    /// specify the initial relative angle for joint limits. This
    /// helps when saving and loading a game.
    /// The local anchor points are measured from the body's origin
    /// rather than the center of mass because:
    /// 1. you might not know where the center of mass will be.
    /// 2. if you add/remove shapes from a body and recompute the mass,
    ///    the joints will be broken.
    /// </summary>
    public class RevoluteJointDef : JointDef
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RevoluteJointDef"/> class
        /// </summary>
        public RevoluteJointDef()
        {
            Type = JointType.RevoluteJoint;
            LocalAnchor1.Set(0.0f, 0.0f);
            LocalAnchor2.Set(0.0f, 0.0f);
            ReferenceAngle = 0.0f;
            LowerAngle = 0.0f;
            UpperAngle = 0.0f;
            MaxMotorTorque = 0.0f;
            MotorSpeed = 0.0f;
            EnableLimit = false;
            EnableMotor = false;
        }

        /// <summary>
        /// Initialize the bodies, anchors, and reference angle using the world
        /// anchor.
        /// </summary>
        public void Initialize(Body body1, Body body2, Vec2 anchor)
        {
            Body1 = body1;
            Body2 = body2;
            LocalAnchor1 = body1.GetLocalPoint(anchor);
            LocalAnchor2 = body2.GetLocalPoint(anchor);
            ReferenceAngle = body2.GetAngle() - body1.GetAngle();
        }

        /// <summary>
        /// The local anchor point relative to body1's origin.
        /// </summary>
        public Vec2 LocalAnchor1;

        /// <summary>
        /// The local anchor point relative to body2's origin.
        /// </summary>
        public Vec2 LocalAnchor2;

        /// <summary>
        /// The body2 angle minus body1 angle in the reference state (radians).
        /// </summary>
        public float ReferenceAngle;

        /// <summary>
        /// A flag to enable joint limits.
        /// </summary>
        public bool EnableLimit;

        /// <summary>
        /// The lower angle for the joint limit (radians).
        /// </summary>
        public float LowerAngle;

        /// <summary>
        /// The upper angle for the joint limit (radians).
        /// </summary>
        public float UpperAngle;

        /// <summary>
        /// A flag to enable the joint motor.
        /// </summary>
        public bool EnableMotor;

        /// <summary>
        /// The desired motor speed. Usually in radians per second.
        /// </summary>
        public float MotorSpeed;

        /// <summary>
        /// The maximum motor torque used to achieve the desired motor speed.
        /// Usually in N-m.
        /// </summary>
        public float MaxMotorTorque;
    }
}