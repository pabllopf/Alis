using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    /// Prismatic joint definition. This requires defining a line of
    /// motion using an axis and an anchor point. The definition uses local
    /// anchor points and a local axis so that the initial configuration
    /// can violate the constraint slightly. The joint translation is zero
    /// when the local anchor points coincide in world space. Using local
    /// anchors and a local axis helps when saving and loading a game.
    /// </summary>
    public class PrismaticJointDef : JointDef
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PrismaticJointDef"/> class
        /// </summary>
        public PrismaticJointDef()
        {
            Type = JointType.PrismaticJoint;
            LocalAnchor1.SetZero();
            LocalAnchor2.SetZero();
            LocalAxis1.Set(1.0f, 0.0f);
            ReferenceAngle = 0.0f;
            EnableLimit = false;
            LowerTranslation = 0.0f;
            UpperTranslation = 0.0f;
            EnableMotor = false;
            MaxMotorForce = 0.0f;
            MotorSpeed = 0.0f;
        }

        /// <summary>
        /// Initialize the bodies, anchors, axis, and reference angle using the world
        /// anchor and world axis.
        /// </summary>
        public void Initialize(Body body1, Body body2, Vec2 anchor, Vec2 axis)
        {
            Body1 = body1;
            Body2 = body2;
            LocalAnchor1 = body1.GetLocalPoint(anchor);
            LocalAnchor2 = body2.GetLocalPoint(anchor);
            LocalAxis1 = body1.GetLocalVector(axis);
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
        /// The local translation axis in body1.
        /// </summary>
        public Vec2 LocalAxis1;

        /// <summary>
        /// The constrained angle between the bodies: body2_angle - body1_angle.
        /// </summary>
        public float ReferenceAngle;

        /// <summary>
        /// Enable/disable the joint limit.
        /// </summary>
        public bool EnableLimit;

        /// <summary>
        /// The lower translation limit, usually in meters.
        /// </summary>
        public float LowerTranslation;

        /// <summary>
        /// The upper translation limit, usually in meters.
        /// </summary>
        public float UpperTranslation;

        /// <summary>
        /// Enable/disable the joint motor.
        /// </summary>
        public bool EnableMotor;

        /// <summary>
        /// The maximum motor torque, usually in N-m.
        /// </summary>
        public float MaxMotorForce;

        /// <summary>
        /// The desired motor speed in radians per second.
        /// </summary>
        public float MotorSpeed;
    }
}