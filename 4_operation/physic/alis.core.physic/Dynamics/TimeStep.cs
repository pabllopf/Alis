namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    /// The time step
    /// </summary>
    public struct TimeStep
    {
        /// <summary>
        /// The dt
        /// </summary>
        public float Dt; // time step
        /// <summary>
        /// The inv dt
        /// </summary>
        public float InvDt; // inverse time step (0 if dt == 0).
        /// <summary>
        /// The dt ratio
        /// </summary>
        public float DtRatio;	// dt * inv_dt0
        /// <summary>
        /// The velocity iterations
        /// </summary>
        public int VelocityIterations;
        /// <summary>
        /// The position iterations
        /// </summary>
        public int PositionIterations;
        /// <summary>
        /// The warm starting
        /// </summary>
        public bool WarmStarting;
    }
}