

namespace Alis.Core.Physic.Dynamics
{
    /// Solver Data
    internal struct SolverData
    {
        /// <summary>
        ///     The step
        /// </summary>
        internal TimeStep Step;

        /// <summary>
        ///     The positions
        /// </summary>
        internal SolverPosition[] Positions;

        /// <summary>
        ///     The velocities
        /// </summary>
        internal SolverVelocity[] Velocities;

        /// <summary>
        ///     The locks
        /// </summary>
        internal int[] Locks;
    }
}