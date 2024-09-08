namespace Alis.Core.Physic.Dynamics
{
    /// Solver Data
    internal struct SolverData
    {
        /// <summary>
        /// The step
        /// </summary>
        internal TimeStep step;
        /// <summary>
        /// The positions
        /// </summary>
        internal SolverPosition[] positions;
        /// <summary>
        /// The velocities
        /// </summary>
        internal SolverVelocity[] velocities;
        /// <summary>
        /// The locks
        /// </summary>
        internal int[] locks;
    }
}