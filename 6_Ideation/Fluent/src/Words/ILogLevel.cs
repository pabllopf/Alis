

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that configures the minimum logging level
    ///     for diagnostics, warnings, and error output.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The log level type — typically a <see cref="LogLevel"/> enum value.</typeparam>
    /// <remarks>
    ///     Setting the log level filters which messages get emitted at runtime.
    ///     Common levels: <c>Trace</c>, <c>Debug</c>, <c>Info</c>, <c>Warning</c>, <c>Error</c>, <c>Critical</c>.
    ///     Production builds typically set this to <c>Warning</c> or higher for performance.
    /// </remarks>
    public interface ILogLevel<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Sets the minimum log level on the builder.
        /// </summary>
        /// <param name="value">The minimum log level — messages below this severity are suppressed.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder LogLevel(TArgument value);
    }
}