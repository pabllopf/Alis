using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     Input for Distance.ComputeDistance().
    ///     You have to option to use the shape radii in the computation.
    /// </summary>
    public struct DistanceInput
    {
        /// <summary>
        /// The proxy
        /// </summary>
        public DistanceProxy ProxyA;
        /// <summary>
        /// The proxy
        /// </summary>
        public DistanceProxy ProxyB;
        /// <summary>
        /// The transform
        /// </summary>
        public Transform TransformA;
        /// <summary>
        /// The transform
        /// </summary>
        public Transform TransformB;
        /// <summary>
        /// The use radii
        /// </summary>
        public bool UseRadii;
    }
}