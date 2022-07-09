namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    /// Joint definitions are used to construct joints.
    /// </summary>
    public class JointDef
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JointDef"/> class
        /// </summary>
        public JointDef()
        {
            Type = JointType.UnknownJoint;
            UserData = null;
            Body1 = null;
            Body2 = null;
            CollideConnected = false;
        }

        /// <summary>
        /// The joint type is set automatically for concrete joint types.
        /// </summary>
        public JointType Type;

        /// <summary>
        /// Use this to attach application specific data to your joints.
        /// </summary>
        public object UserData;

        /// <summary>
        /// The first attached body.
        /// </summary>
        public Body Body1;

        /// <summary>
        /// The second attached body.
        /// </summary>
        public Body Body2;

        /// <summary>
        /// Set this flag to true if the attached bodies should collide.
        /// </summary>
        public bool CollideConnected;
    }
}