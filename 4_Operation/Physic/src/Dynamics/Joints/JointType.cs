namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    /// The joint type enum
    /// </summary>
    public enum JointType
    {
        /// <summary>
        /// The unknown joint type
        /// </summary>
        Unknown,
        /// <summary>
        /// The revolute joint type
        /// </summary>
        Revolute,
        /// <summary>
        /// The prismatic joint type
        /// </summary>
        Prismatic,
        /// <summary>
        /// The distance joint type
        /// </summary>
        Distance,
        /// <summary>
        /// The pulley joint type
        /// </summary>
        Pulley,

        //Mouse, <- We have fixed mouse
        /// <summary>
        /// The gear joint type
        /// </summary>
        Gear,
        /// <summary>
        /// The wheel joint type
        /// </summary>
        Wheel,
        /// <summary>
        /// The weld joint type
        /// </summary>
        Weld,
        /// <summary>
        /// The friction joint type
        /// </summary>
        Friction,
        /// <summary>
        /// The rope joint type
        /// </summary>
        Rope,
        /// <summary>
        /// The motor joint type
        /// </summary>
        Motor,

        //FPE note: From here on and down, it is only FPE joints
        /// <summary>
        /// The angle joint type
        /// </summary>
        Angle,
        /// <summary>
        /// The fixed mouse joint type
        /// </summary>
        FixedMouse,
        /// <summary>
        /// The fixed revolute joint type
        /// </summary>
        FixedRevolute,
        /// <summary>
        /// The fixed distance joint type
        /// </summary>
        FixedDistance,
        /// <summary>
        /// The fixed line joint type
        /// </summary>
        FixedLine,
        /// <summary>
        /// The fixed prismatic joint type
        /// </summary>
        FixedPrismatic,
        /// <summary>
        /// The fixed angle joint type
        /// </summary>
        FixedAngle,
        /// <summary>
        /// The fixed friction joint type
        /// </summary>
        FixedFriction
    }
}