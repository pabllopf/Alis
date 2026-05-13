// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MemoryLogOutput.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Collections.Generic;
using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Outputs
{
    /// <summary>
    ///     Stores log entries in memory for inspection and debugging.
    ///     Useful for testing and retrieving recent log entries.
    ///     Thread-safe: Uses locks for access to the entries list.
    ///     AOT-compatible: No reflection, pure collection-based storage.
    /// </summary>
    public sealed class MemoryLogOutput : ILogOutput
    {
        /// <summary>
        ///     Internal list storing all log entries retained in memory.
        /// </summary>
        private readonly List<ILogEntry> _entries;

        /// <summary>
        ///     Synchronization lock for thread-safe access to the entries list.
        /// </summary>
        private readonly object _lock = new object();

        /// <summary>
        ///     Maximum number of entries to retain. Oldest entries are evicted when exceeded.
        /// </summary>
        private readonly int _maxEntries;

        /// <summary>
        ///     Indicates whether this instance has been disposed and should no longer accept entries.
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the MemoryLogOutput class.
        /// </summary>
        /// <param name="maxEntries">Maximum number of entries to keep. Oldest entries are removed when exceeded. 0 = unlimited.</param>
        public MemoryLogOutput(int maxEntries = 1000)
        {
            _entries = new List<ILogEntry>();
            _maxEntries = maxEntries > 0 ? maxEntries : int.MaxValue;
        }

        /// <summary>
        ///     Gets the count of entries currently stored.
        /// </summary>
        public int Count
        {
            get
            {
                lock (_lock)
                {
                    return _entries.Count;
                }
            }
        }


        /// <summary>
        ///     Gets a human-readable identifier for this in-memory output.
        /// </summary>
        public string Name => "MemoryOutput";


        /// <summary>
        ///     Gets or sets whether this output is currently accepting log entries.
        ///     When disabled, <see cref="Write"/> silently ignores entries.
        /// </summary>
        public bool IsEnabled { get; set; } = true;


        /// <summary>
        ///     Stores the log entry in the internal list. If the maximum entry count is exceeded,
        ///     the oldest entries are automatically removed to stay within the limit.
        /// </summary>
        /// <param name="entry">The log entry to store. Null entries are silently ignored.</param>
        public void Write(ILogEntry entry)
        {
            if (entry == null || _disposed)
            {
                return;
            }

            lock (_lock)
            {
                _entries.Add(entry);

                // Remove oldest entries if we exceed max
                if (_entries.Count > _maxEntries)
                {
                    _entries.RemoveRange(0, _entries.Count - _maxEntries);
                }
            }
        }


        /// <summary>
        ///     No-op for memory output since entries are always immediately available.
        /// </summary>
        public void Flush()
        {
            // Memory output is always flushed
        }


        /// <summary>
        ///     Clears all stored entries and marks this instance as disposed.
        ///     Safe to call multiple times.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;

            lock (_lock)
            {
                _entries.Clear();
            }
        }

        /// <summary>
        ///     Gets a snapshot of all stored entries.
        /// </summary>
        /// <returns>A list copy of all current entries.</returns>
        public IReadOnlyList<ILogEntry> GetEntries()
        {
            lock (_lock)
            {
                return new List<ILogEntry>(_entries);
            }
        }

        /// <summary>
        ///     Clears all stored entries.
        /// </summary>
        public void Clear()
        {
            lock (_lock)
            {
                _entries.Clear();
            }
        }
    }
}