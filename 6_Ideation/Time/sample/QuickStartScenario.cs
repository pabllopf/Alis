

namespace Alis.Core.Aspect.Time.Sample
{
    /// <summary>
    ///     Small helpers for timing-related samples.
    /// </summary>
    internal static class QuickStartScenario
    {
        /// <summary>
        ///     Creates and starts a clock in one call.
        /// </summary>
        /// <returns>A running clock instance.</returns>
        internal static Clock StartClock() => Clock.Create();
    }
}
