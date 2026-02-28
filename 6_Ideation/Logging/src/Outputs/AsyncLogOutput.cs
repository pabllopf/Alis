// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AsyncLogOutput.cs
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

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Outputs
{
    /// <summary>
    ///     Wraps an output and queues writes to process them asynchronously.
    ///     Useful for file and network I/O to avoid blocking the main thread.
    ///     AOT-compatible: Uses queuing and thread management, no reflection.
    /// </summary>
    public sealed class AsyncLogOutput : ILogOutput
    {
        private readonly ILogOutput _innerOutput;
        private readonly int _maxQueueSize;
        private readonly Queue<ILogEntry> _queue;
        private readonly object _queueLock = new object();
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the AsyncLogOutput class.
        /// </summary>
        /// <param name="innerOutput">The underlying output to wrap.</param>
        /// <param name="maxQueueSize">Maximum entries to queue. 0 = unlimited.</param>
        public AsyncLogOutput(ILogOutput innerOutput, int maxQueueSize = 10000)
        {
            _innerOutput = innerOutput ?? throw new ArgumentNullException(nameof(innerOutput));
            _queue = new Queue<ILogEntry>();
            _maxQueueSize = maxQueueSize > 0 ? maxQueueSize : int.MaxValue;
        }

        /// <inheritdoc />
        public string Name => $"Async[{_innerOutput.Name}]";

        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <inheritdoc />
        public void Write(ILogEntry entry)
        {
            if (entry == null || _disposed || !IsEnabled)
            {
                return;
            }

            lock (_queueLock)
            {
                if (_queue.Count < _maxQueueSize)
                {
                    _queue.Enqueue(entry);
                }
                else
                {
                    // Queue is full, drop oldest entries or write directly
                    if (_queue.Count > 0)
                    {
                        _queue.Dequeue();
                    }

                    _queue.Enqueue(entry);
                }
            }
        }

        /// <inheritdoc />
        public void Flush()
        {
            lock (_queueLock)
            {
                while (_queue.Count > 0)
                {
                    ILogEntry entry = _queue.Dequeue();
                    try
                    {
                        _innerOutput.Write(entry);
                    }
                    catch
                    {
                        // Prevent single entry write failures from blocking flush
                    }
                }
            }

            _innerOutput.Flush();
        }

        /// <inheritdoc />
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            Flush();
            _innerOutput.Dispose();
        }
    }
}