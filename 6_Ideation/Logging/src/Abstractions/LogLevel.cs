

namespace Alis.Core.Aspect.Logging.Abstractions
{
    /// <summary>
    ///     Enumeration of log levels for categorizing log entries.
    ///     Follows standard logging severity levels from lowest to highest.
    /// </summary>
    public enum LogLevel : byte
    {
        /// <summary>
        ///     Trace level: Most detailed, for diagnostic information.
        /// </summary>
        Trace = 0,

        /// <summary>
        ///     Debug level: Information useful for development and debugging.
        /// </summary>
        Debug = 1,

        /// <summary>
        ///     Info level: General informational messages.
        /// </summary>
        Info = 2,

        /// <summary>
        ///     Warning level: Warning messages for potentially problematic situations.
        /// </summary>
        Warning = 3,

        /// <summary>
        ///     Error level: Error messages for serious problems.
        /// </summary>
        Error = 4,

        /// <summary>
        ///     Critical level: Critical errors requiring immediate attention.
        /// </summary>
        Critical = 5,

        /// <summary>
        ///     None: Special level to disable logging.
        /// </summary>
        None = 255
    }
}