

namespace Alis.Core.Aspect.Logging.Abstractions
{
    /// <summary>
    ///     Formats log entries into a string representation suitable for output.
    ///     Different formatters can produce different output styles (JSON, plain text, etc.).
    ///     AOT-compatible: Uses StringBuilder, no reflection.
    /// </summary>
    public interface ILogFormatter
    {
        /// <summary>
        ///     Gets a human-readable name for this formatter.
        /// </summary>
        /// <value>The human-readable name of this formatter.</value>
        string Name { get; }

        /// <summary>
        ///     Formats the given log entry into a string.
        /// </summary>
        /// <param name="entry">The log entry to format.</param>
        /// <returns>A formatted string representation of the log entry.</returns>
        string Format(ILogEntry entry);
    }
}