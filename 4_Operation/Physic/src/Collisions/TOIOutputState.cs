

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Specifies the result state of a Time of Impact (TOI) computation.
    /// </summary>
    public enum ToiOutputState
    {
        /// <summary>
        ///     The TOI computation has not yet been executed.
        /// </summary>
        Unknown,

        /// <summary>
        ///     The TOI computation failed to converge within the maximum number of iterations.
        /// </summary>
        Failed,

        /// <summary>
        ///     The shapes are already overlapping at the start of the time step (t = 0).
        /// </summary>
        Overlapped,

        /// <summary>
        ///     The shapes are in contact at the computed time of impact fraction.
        /// </summary>
        Touching,

        /// <summary>
        ///     The shapes did not collide within the specified time interval [0, tMax].
        /// </summary>
        Seperated
    }
}