

using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Formatters;

namespace Alis.Core.Aspect.Logging.Outputs
{
    /// <summary>
    ///     Writes log entries to the debugger output (Debug.WriteLine).
    ///     Only writes output when debugger is attached.
    ///     Useful for development-time debugging.
    ///     AOT-compatible: Uses Debug.WriteLine, no reflection.
    /// </summary>
    public sealed class DebugLogOutput : ILogOutput
    {
        /// <summary>
        ///     The formatter
        /// </summary>
        private readonly ILogFormatter _formatter;

        /// <summary>
        ///     The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the DebugLogOutput class.
        /// </summary>
        /// <param name="formatter">The formatter to use. If null, uses a simple formatter.</param>
        public DebugLogOutput(ILogFormatter formatter = null) => _formatter = formatter ?? new SimpleLogFormatter();


        /// <summary>
        ///     Gets a human-readable identifier for this debug output.
        /// </summary>
        public string Name => "DebugOutput";


        /// <summary>
        ///     Gets or sets whether this output is currently accepting log entries.
        /// </summary>
        public bool IsEnabled { get; set; } = true;


        /// <summary>
        ///     Writes the specified log entry to the debugger output.
        /// </summary>
        /// <param name="entry">The log entry to write.</param>
        [ExcludeFromCodeCoverage]
        public void Write(ILogEntry entry)
        {
            if (entry == null || _disposed || !Debugger.IsAttached)
            {
                return;
            }

            try
            {
                string formatted = _formatter.Format(entry);
                Debug.WriteLine(formatted);
            }
            catch
            {
            }
        }


        /// <summary>
        ///     No-op for debug output since Debug.WriteLine writes immediately.
        /// </summary>
        public void Flush()
        {
        }


        /// <summary>
        ///     Releases all resources used by the debug output.
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