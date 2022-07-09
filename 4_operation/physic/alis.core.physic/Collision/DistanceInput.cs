using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// Input for Distance.
    /// You have to option to use the shape radii
    /// in the computation.
    /// </summary>
    public struct DistanceInput
    {
        /// <summary>
        /// The transform
        /// </summary>
        public XForm TransformA;
        /// <summary>
        /// The transform
        /// </summary>
        public XForm TransformB;
        /// <summary>
        /// The use radii
        /// </summary>
        public bool UseRadii;
    }
}