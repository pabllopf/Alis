using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    /// The contact constraint point
    /// </summary>
    public struct ContactConstraintPoint
    {
        /// <summary>
        /// The local point
        /// </summary>
        public Vec2 LocalPoint;
        /// <summary>
        /// The ra
        /// </summary>
        public Vec2 RA;
        /// <summary>
        /// The rb
        /// </summary>
        public Vec2 RB;
        /// <summary>
        /// The normal impulse
        /// </summary>
        public float NormalImpulse;
        /// <summary>
        /// The tangent impulse
        /// </summary>
        public float TangentImpulse;
        /// <summary>
        /// The normal mass
        /// </summary>
        public float NormalMass;
        /// <summary>
        /// The tangent mass
        /// </summary>
        public float TangentMass;
        /// <summary>
        /// The equalized mass
        /// </summary>
        public float EqualizedMass;
        /// <summary>
        /// The velocity bias
        /// </summary>
        public float VelocityBias;
    }
}