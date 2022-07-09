namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    /// Gear joint definition. This definition requires two existing
    /// revolute or prismatic joints (any combination will work).
    /// The provided joints must attach a dynamic body to a static body.
    /// </summary>
    public class GearJointDef : JointDef
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GearJointDef"/> class
        /// </summary>
        public GearJointDef()
        {
            Type = JointType.GearJoint;
            Joint1 = null;
            Joint2 = null;
            Ratio = 1.0f;
        }

        /// <summary>
        /// The first revolute/prismatic joint attached to the gear joint.
        /// </summary>
        public Joint Joint1;

        /// <summary>
        /// The second revolute/prismatic joint attached to the gear joint.
        /// </summary>
        public Joint Joint2;

        /// <summary>
        /// The gear ratio.
        /// @see GearJoint for explanation.
        /// </summary>
        public float Ratio;
    }
}