

namespace Alis.Core.Ecs.Systems.Configuration.Time
{
    /// <summary>
    ///     The time setting interface
    /// </summary>
    public interface ITimeSetting
    {
        /// <summary>
        ///     Gets the value of the fixed time step
        /// </summary>
        float FixedTimeStep { get; }

        /// <summary>
        ///     Gets the value of the maximum allowed time step
        /// </summary>
        float MaximumAllowedTimeStep { get; }

        /// <summary>
        ///     Gets the value of the time scale
        /// </summary>
        float TimeScale { get; }
    }
}