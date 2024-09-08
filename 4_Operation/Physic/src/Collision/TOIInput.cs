using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    /// <summary>
    ///     Input parameters for CalculateTimeOfImpact
    /// </summary>
    public class TOIInput
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
        /// The sweep
        /// </summary>
        public Sweep SweepA;
        /// <summary>
        /// The sweep
        /// </summary>
        public Sweep SweepB;
        /// <summary>
        /// The max
        /// </summary>
        public float TMax; // defines sweep interval [0, tMax]
    }
}