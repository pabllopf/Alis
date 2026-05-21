

using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Formatters;

namespace Alis.Core.Aspect.Logging.Outputs
{
    /// <summary>
    ///     Writes log entries to a file on disk.
    ///     Supports appending to existing files and creates directories as needed.
    ///     Thread-safe: Uses a lock for file writes.
    ///     AOT-compatible: Uses standard file I/O, no reflection.
    /// </summary>
    public sealed class FileLogOutput : ILogOutput
    {
        /// <summary>
        ///     The file path
        /// </summary>
        private readonly string _filePath;

        /// <summary>
        ///     The formatter
        /// </summary>
        private readonly ILogFormatter _formatter;

        /// <summary>
        ///     The write lock
        /// </summary>
        private readonly object _writeLock = new object();

        /// <summary>
        ///     The disposed
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     The writer
        /// </summary>
        private StreamWriter _writer;

        /// <summary>
        ///     Initializes a new instance of the FileLogOutput class.
        /// </summary>
        /// <param name="filePath">The path to the log file.</param>
        /// <param name="formatter">The formatter to use. If null, uses a simple formatter.</param>
        /// <param name="append">Whether to append to existing file or overwrite.</param>
        public FileLogOutput(string filePath, ILogFormatter formatter = null, bool append = true)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
            }

            _filePath = filePath;
            _formatter = formatter ?? new SimpleLogFormatter();

            try
            {
                string directory = Path.GetDirectoryName(filePath);
                if (!string.IsNullOrEmpty(directory) && !Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                _writer = new StreamWriter(
                    new FileStream(filePath, append ? FileMode.Append : FileMode.Create, FileAccess.Write, FileShare.Read),
                    new UTF8Encoding(false))
                {
                    AutoFlush = true
                };
            }
            catch
            {
                IsEnabled = false;
            }
        }


        /// <summary>
        ///     Gets a human-readable identifier for this file output.
        /// </summary>
        public string Name => $"FileOutput[{Path.GetFileName(_filePath)}]";


        /// <summary>
        ///     Gets or sets whether this output is currently accepting log entries.
        /// </summary>
        public bool IsEnabled { get; set; } = true;


        /// <summary>
        ///     Writes the specified log entry to the file.
        /// </summary>
        /// <param name="entry">The log entry to write.</param>
        [ExcludeFromCodeCoverage]
        public void Write(ILogEntry entry)
        {
            if (entry == null || _disposed || _writer == null)
            {
                return;
            }

            lock (_writeLock)
            {
                try
                {
                    string formatted = _formatter.Format(entry);
                    _writer.WriteLine(formatted);
                }
                catch
                {
                }
            }
        }


        /// <summary>
        ///     Flushes any buffered data to the file.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void Flush()
        {
            if (_disposed || _writer == null)
            {
                return;
            }

            lock (_writeLock)
            {
                try
                {
                    _writer.Flush();
                }
                catch
                {
                }
            }
        }


        /// <summary>
        ///     Releases all resources used by the file output.
        /// </summary>
        [ExcludeFromCodeCoverage]
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;

            lock (_writeLock)
            {
                try
                {
                    _writer?.Flush();
                    _writer?.Dispose();
                    _writer = null;
                }
                catch
                {
                }
            }
        }
    }
}