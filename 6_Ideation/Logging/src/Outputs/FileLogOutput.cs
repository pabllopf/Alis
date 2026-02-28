// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: FileLogOutput.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
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
        private readonly string _filePath;
        private readonly ILogFormatter _formatter;
        private readonly object _writeLock = new object();
        private StreamWriter _writer;
        private bool _disposed;

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

        /// <inheritdoc />
        public string Name => $"FileOutput[{Path.GetFileName(_filePath)}]";

        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc />
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
                    // Prevent file write failures from propagating
                }
            }
        }

        /// <inheritdoc />
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
                    // Prevent flush failures from propagating
                }
            }
        }

        /// <inheritdoc />
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
                    // Ignore disposal failures
                }
            }
        }
    }
}

