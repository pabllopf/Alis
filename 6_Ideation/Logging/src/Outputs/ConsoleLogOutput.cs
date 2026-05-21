

using System;
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Formatters;

namespace Alis.Core.Aspect.Logging.Outputs
{
    /// <summary>
    ///     Writes log entries to the standard console output.
    ///     Uses colored output when available based on log level.
    ///     Thread-safe: Console.WriteLine is thread-safe in .NET.
    ///     AOT-compatible: No reflection, simple console I/O.
    /// </summary>
    public sealed class ConsoleLogOutput : ILogOutput
    {
        /// <summary>
        ///     The formatter used to convert log entries into strings for console display.
        /// </summary>
        private readonly ILogFormatter _formatter;

        /// <summary>
        ///     Indicates whether this instance has been disposed and should no longer accept writes.
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the ConsoleLogOutput class.
        /// </summary>
        /// <param name="formatter">The formatter to use for log entries. If null, uses a simple formatter.</param>
        public ConsoleLogOutput(ILogFormatter formatter = null) => _formatter = formatter ?? new SimpleLogFormatter();


        /// <summary>
        ///     Gets a human-readable identifier for this console output.
        /// </summary>
        public string Name => "ConsoleOutput";


        /// <summary>
        ///     Gets or sets whether this output is currently accepting log entries.
        ///     When disabled, <see cref="Write"/> silently ignores entries.
        /// </summary>
        public bool IsEnabled { get; set; } = true;


        /// <summary>
        ///     Writes the formatted log entry to <see cref="Console.Out"/> with color coding
        ///     based on the log severity level. Colors: Trace=Gray, Debug=Cyan, Info=White,
        ///     Warning=Yellow, Error=Red, Critical=Magenta.
        /// </summary>
        /// <param name="entry">The log entry to format and write to the console. Null entries are silently ignored.</param>
        [ExcludeFromCodeCoverage]
        public void Write(ILogEntry entry)
        {
            if (entry == null || _disposed)
            {
                return;
            }

            string formatted = _formatter.Format(entry);
            ConsoleColor originalColor = Console.ForegroundColor;

            try
            {
                Console.ForegroundColor = entry.Level switch
                {
                    LogLevel.Trace => ConsoleColor.Gray,
                    LogLevel.Debug => ConsoleColor.Cyan,
                    LogLevel.Info => ConsoleColor.White,
                    LogLevel.Warning => ConsoleColor.Yellow,
                    LogLevel.Error => ConsoleColor.Red,
                    LogLevel.Critical => ConsoleColor.Magenta,
                    _ => ConsoleColor.White
                };

                Console.WriteLine(formatted);
            }
            catch
            {
            }
            finally
            {
                try
                {
                    Console.ForegroundColor = originalColor;
                }
                catch
                {
                }
            }
        }


        /// <summary>
        ///     No-op for console output since <see cref="Console.WriteLine"/> writes immediately.
        /// </summary>
        public void Flush()
        {
        }


        /// <summary>
        ///     Releases all resources used by the console output.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
        }
    }
}