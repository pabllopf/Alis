

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Output result from continuous collision detection (Time of Impact calculation).
    /// </summary>
    /// <remarks>
    ///     Contains the state of the TOI computation and the fractional time of impact.
    ///     The state indicates whether a collision was detected, and if so, at what fraction
    ///     of the time step it occurred.
    /// </remarks>
    public struct ToiOutput
    {
        /// <summary>
        ///     Gets or sets the state of the time of impact computation.
        /// </summary>
        /// <value>
        ///     A <see cref="ToiOutputState"/> indicating whether the TOI was computed,
        ///     the shapes are already overlapping, or the sweep did not complete.
        /// </value>
        public ToiOutputState State;

        /// <summary>
        ///     Gets or sets the fractional time of impact in [0, tMax].
        /// </summary>
        /// <value>
        ///     A <see cref="float"/> representing the fraction of the time step when collision first occurs.
        /// </value>
        /// <remarks>
        ///     Valid only when <see cref="State"/> is <see cref="ToiOutputState.Collided"/>.
        ///     A value of 0 means the shapes are already overlapping at the start of the step.
        /// </remarks>
        public float T;
    }
}