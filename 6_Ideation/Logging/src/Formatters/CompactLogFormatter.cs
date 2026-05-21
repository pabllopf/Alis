

using System.Diagnostics.CodeAnalysis;
using System.Text;
using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Formatters
{
    /// <summary>
    ///     Compact log formatter optimized for performance in game loops.
    ///     Format: [L] Message
    ///     Minimal output, just level and message for maximum performance.
    ///     AOT-compatible: Uses StringBuilder, no reflection.
    /// </summary>
    public sealed class CompactLogFormatter : ILogFormatter
    {
        /// <summary>
        ///     Gets a human-readable name for this formatter.
        /// </summary>
        public string Name => "CompactFormatter";


        /// <summary>
        ///     Formats the specified log entry into a compact string.
        /// </summary>
        /// <param name="entry">The log entry to format.</param>
        /// <returns>A compact string representation of the log entry.</returns>
        [ExcludeFromCodeCoverage]
        public string Format(ILogEntry entry)
        {
            StringBuilder sb = new StringBuilder(128);

            sb.Append('[');
            sb.Append(entry.Level switch
            {
                LogLevel.Trace => 'T',
                LogLevel.Debug => 'D',
                LogLevel.Info => 'I',
                LogLevel.Warning => 'W',
                LogLevel.Error => 'E',
                LogLevel.Critical => 'C',
                _ => '?'
            });
            sb.Append("] ");
            sb.Append(entry.Message);

            if (entry.Exception != null)
            {
                sb.Append(" [EXC: ");
                sb.Append(entry.Exception.Message);
                sb.Append(']');
            }

            return sb.ToString();
        }
    }
}