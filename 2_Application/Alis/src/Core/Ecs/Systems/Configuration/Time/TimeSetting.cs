

using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Systems.Configuration.Time
{
    /// <summary>
    ///     The time class
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public readonly struct TimeSetting(
        float fixedTimeStep,
        float maximumAllowedTimeStep,
        float timeScale) : ITimeSetting
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TimeSetting" /> class
        /// </summary>
        public TimeSetting() : this(0.016f, 0.25f, 1.0f)
        {
        }

        /// <summary>
        ///     Gets the value of the maximum allowed time step
        /// </summary>
        public float MaximumAllowedTimeStep { get; } = maximumAllowedTimeStep;

        /// <summary>
        ///     Gets the value of the time scale
        /// </summary>
        public float TimeScale { get; } = timeScale;

        /// <summary>
        ///     Gets the value of the fixed time step
        /// </summary>
        public float FixedTimeStep { get; } = fixedTimeStep;
    }
}