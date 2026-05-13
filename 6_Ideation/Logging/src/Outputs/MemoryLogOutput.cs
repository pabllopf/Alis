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
        ///     The entries
        /// </summary>
        private readonly List<ILogEntry> _entries;

        /// <summary>
        ///     The lock
        /// </summary>
        private readonly object _lock = new object();

        /// <summary>
        ///     The max entries
        /// </summary>
        private readonly int _maxEntries;

        /// <summary>
        ///     The disposed
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
        ///     Gets the value of the name
        /// </summary>
        public string Name => "MemoryOutput";


        /// <summary>
        ///     Gets or sets the value of the is enabled
        /// </summary>
        public bool IsEnabled { get; set; } = true;


        /// <summary>
        ///     Writes the entry
        /// </summary>
        /// <param name="entry">The entry</param>
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
        ///     Flushes this instance
        /// </summary>
        public void Flush()
        {
            // Memory output is always flushed
        }


        /// <summary>
        ///     Disposes this instance
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