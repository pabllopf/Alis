using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    /// Pulley joint definition. This requires two ground anchors,
    /// two dynamic body anchor points, max lengths for each side,
    /// and a pulley ratio.
    /// </summary>
    public class PulleyJointDef : JointDef
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PulleyJointDef"/> class
        /// </summary>
        public PulleyJointDef()
        {
            Type = JointType.PulleyJoint;
            GroundAnchor1.Set(-1.0f, 1.0f);
            GroundAnchor2.Set(1.0f, 1.0f);
            LocalAnchor1.Set(-1.0f, 0.0f);
            LocalAnchor2.Set(1.0f, 0.0f);
            Length1 = 0.0f;
            MaxLength1 = 0.0f;
            Length2 = 0.0f;
            MaxLength2 = 0.0f;
            Ratio = 1.0f;
            CollideConnected = true;
        }

        /// Initialize the bodies, anchors, lengths, max lengths, and ratio using the world anchors.
        public void Initialize(Body body1, Body body2,
            Vec2 groundAnchor1, Vec2 groundAnchor2,
            Vec2 anchor1, Vec2 anchor2,
            float ratio)
        {
            Body1 = body1;
            Body2 = body2;
            GroundAnchor1 = groundAnchor1;
            GroundAnchor2 = groundAnchor2;
            LocalAnchor1 = body1.GetLocalPoint(anchor1);
            LocalAnchor2 = body2.GetLocalPoint(anchor2);
            Vec2 d1 = anchor1 - groundAnchor1;
            Length1 = d1.Length();
            Vec2 d2 = anchor2 - groundAnchor2;
            Length2 = d2.Length();
            Ratio = ratio;
            Box2DXDebug.Assert(ratio > Settings.FltEpsilon);
            float C = Length1 + ratio * Length2;
            MaxLength1 = C - ratio * PulleyJoint.MinPulleyLength;
            MaxLength2 = (C - PulleyJoint.MinPulleyLength) / ratio;
        }

        /// <summary>
        /// The first ground anchor in world coordinates. This point never moves.
        /// </summary>
        public Vec2 GroundAnchor1;

        /// <summary>
        /// The second ground anchor in world coordinates. This point never moves.
        /// </summary>
        public Vec2 GroundAnchor2;

        /// <summary>
        /// The local anchor point relative to body1's origin.
        /// </summary>
        public Vec2 LocalAnchor1;

        /// <summary>
        /// The local anchor point relative to body2's origin.
        /// </summary>
        public Vec2 LocalAnchor2;

        /// <summary>
        /// The a reference length for the segment attached to body1.
        /// </summary>
        public float Length1;

        /// <summary>
        /// The maximum length of the segment attached to body1.
        /// </summary>
        public float MaxLength1;

        /// <summary>
        /// The a reference length for the segment attached to body2.
        /// </summary>
        public float Length2 { get; set; }

        /// <summary>
        /// The maximum length of the segment attached to body2.
        /// </summary>
        public float MaxLength2 { get; set; }

        /// <summary>
        /// The pulley ratio, used to simulate a block-and-tackle.
        /// </summary>
        public float Ratio;
    }
}