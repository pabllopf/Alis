

using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Filters;

namespace Alis.Core.Aspect.Logging.Sample
{
    /// <summary>
    ///     Small logging scenario helper for sample composition.
    /// </summary>
    internal static class QuickStartScenario
    {
        /// <summary>
        ///     Creates an info-level log filter used by sample pipelines.
        /// </summary>
        /// <returns>A configured log filter instance.</returns>
        internal static ILogFilter CreateInfoFilter() => new LogLevelFilter(LogLevel.Info);
    }
}
