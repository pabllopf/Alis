

using System.Text;
using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Formatters
{
    /// <summary>
    ///     Simple, human-readable log formatter.
    ///     Format: [TIME] [LEVEL] [LoggerName] Message [Exception]
    ///     AOT-compatible: Uses StringBuilder, no reflection.
    /// </summary>
    public sealed class SimpleLogFormatter : ILogFormatter
    {
        /// <summary>
        ///     Gets a human-readable name for this formatter.
        /// </summary>
        public string Name => "SimpleFormatter";


        /// <summary>
        ///     Formats the specified log entry into a human-readable string.
        /// </summary>
        /// <param name="entry">The log entry to format.</param>
        /// <returns>A formatted string representation of the log entry.</returns>
        public string Format(ILogEntry entry)
        {
            StringBuilder sb = new StringBuilder(256);

            sb.Append('[');
            sb.Append(entry.Timestamp);
            sb.Append("] [");
            sb.Append(entry.Level);
            sb.Append("] [");
            sb.Append(entry.LoggerName);
            sb.Append("] ");
            sb.Append(entry.Message);

            if (!string.IsNullOrEmpty(entry.CorrelationId))
            {
                sb.Append(" [CorrelationId: ");
                sb.Append(entry.CorrelationId);
                sb.Append(']');
            }

            if (entry.Scopes.Count > 0)
            {
                sb.Append(" [Scopes: ");
                for (int i = 0; i < entry.Scopes.Count; i++)
                {
                    if (i > 0)
                    {
                        sb.Append(" -> ");
                    }

                    sb.Append(entry.Scopes[i]);
                }

                sb.Append(']');
            }

            if (entry.Exception != null)
            {
                sb.AppendLine();
                sb.Append("Exception: ");
                sb.AppendLine(entry.Exception.GetType().Name);
                sb.Append("Message: ");
                sb.AppendLine(entry.Exception.Message);
                sb.Append("StackTrace: ");
                sb.AppendLine(entry.Exception.StackTrace);
            }

            return sb.ToString();
        }
    }
}