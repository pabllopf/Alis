

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The velocity constraint point class
    /// </summary>
    public sealed class VelocityConstraintPoint
    {
        /// <summary>
        ///     The normal impulse
        /// </summary>
        public float NormalImpulse;

        /// <summary>
        ///     The normal mass
        /// </summary>
        public float NormalMass;

        /// <summary>
        ///     The
        /// </summary>
        public Vector2F Ra;

        /// <summary>
        ///     The
        /// </summary>
        public Vector2F Rb;

        /// <summary>
        ///     The tangent impulse
        /// </summary>
        public float TangentImpulse;

        /// <summary>
        ///     The tangent mass
        /// </summary>
        public float TangentMass;

        /// <summary>
        ///     The velocity bias
        /// </summary>
        public float VelocityBias;
    }
}