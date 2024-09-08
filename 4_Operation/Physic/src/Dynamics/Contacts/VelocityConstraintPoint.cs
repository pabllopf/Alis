using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    /// The velocity constraint point class
    /// </summary>
    public sealed class VelocityConstraintPoint
    {
        /// <summary>
        /// The normal impulse
        /// </summary>
        public float normalImpulse;
        /// <summary>
        /// The normal mass
        /// </summary>
        public float normalMass;
        /// <summary>
        /// The 
        /// </summary>
        public Vector2 rA;
        /// <summary>
        /// The 
        /// </summary>
        public Vector2 rB;
        /// <summary>
        /// The tangent impulse
        /// </summary>
        public float tangentImpulse;
        /// <summary>
        /// The tangent mass
        /// </summary>
        public float tangentMass;
        /// <summary>
        /// The velocity bias
        /// </summary>
        public float velocityBias;
    }
}