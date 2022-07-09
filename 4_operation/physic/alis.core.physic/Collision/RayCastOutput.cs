using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// Ray-cast output data.
    /// </summary>
    public struct RayCastOutput
    {
        /// <summary>
        /// The normal
        /// </summary>
        public Vec2 Normal;
        /// <summary>
        /// The fraction
        /// </summary>
        public float Fraction;
        /// <summary>
        /// The hit
        /// </summary>
        public bool Hit;
    }
}