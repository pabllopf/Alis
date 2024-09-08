namespace Alis.Core.Physic.Collision
{
    /// <summary>
    /// The toi output state enum
    /// </summary>
    public enum TOIOutputState
    {
        /// <summary>
        /// The unknown toi output state
        /// </summary>
        Unknown,
        /// <summary>
        /// The failed toi output state
        /// </summary>
        Failed,
        /// <summary>
        /// The overlapped toi output state
        /// </summary>
        Overlapped,
        /// <summary>
        /// The touching toi output state
        /// </summary>
        Touching,
        /// <summary>
        /// The seperated toi output state
        /// </summary>
        Seperated
    }
}