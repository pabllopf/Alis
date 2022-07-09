using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    /// Distance joint definition. This requires defining an
    /// anchor point on both bodies and the non-zero length of the
    /// distance joint. The definition uses local anchor points
    /// so that the initial configuration can violate the constraint
    /// slightly. This helps when saving and loading a game.
    /// @warning Do not use a zero or short length.
    /// </summary>
    public class DistanceJointDef : JointDef
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DistanceJointDef"/> class
        /// </summary>
        public DistanceJointDef()
        {
            Type = JointType.DistanceJoint;
            LocalAnchor1.Set(0.0f, 0.0f);
            LocalAnchor2.Set(0.0f, 0.0f);
            Length = 1.0f;
            FrequencyHz = 0.0f;
            DampingRatio = 0.0f;
        }

        /// <summary>
        /// Initialize the bodies, anchors, and length using the world anchors.
        /// </summary>
        public void Initialize(Body body1, Body body2, Vec2 anchor1, Vec2 anchor2)
        {
            Body1 = body1;
            Body2 = body2;
            LocalAnchor1 = body1.GetLocalPoint(anchor1);
            LocalAnchor2 = body2.GetLocalPoint(anchor2);
            Vec2 d = anchor2 - anchor1;
            Length = d.Length();
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
        /// The equilibrium length between the anchor points.
        /// </summary>
        public float Length;

        /// <summary>
        /// The response speed.
        /// </summary>
        public float FrequencyHz;

        /// <summary>
        /// The damping ratio. 0 = no damping, 1 = critical damping.
        /// </summary>
        public float DampingRatio;
    }
}