// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ThreadManager.cs
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
using Alis.Extension.Thread.Configuration;
using Alis.Extension.Thread.Execution;

namespace Alis.Extension.Thread
{
    /// <summary>
    ///     Modern thread manager for parallel execution of ECS component updates.
    ///     Provides automatic work partitioning and efficient thread pool management.
    /// </summary>
    public sealed class ThreadManager : IDisposable
    {
        /// <summary>
        ///     The parallel update executor
        /// </summary>
        private readonly ParallelUpdateExecutor parallelExecutor;

        /// <summary>
        ///     Whether the manager has been disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ThreadManager" /> class with default configuration
        /// </summary>
        public ThreadManager() : this(new ParallelExtensionConfiguration())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ThreadManager" /> class
        /// </summary>
        /// <param name="configuration">The parallel execution configuration</param>
        /// <exception cref="ArgumentNullException">Thrown when configuration is null</exception>
        public ThreadManager(ParallelExtensionConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            parallelExecutor = configuration.CreateExecutor();
        }

        /// <summary>
        ///     Gets the parallel update executor for executing component updates
        /// </summary>
        public ParallelUpdateExecutor ParallelExecutor
        {
            get
            {
                ThrowIfDisposed();
                return parallelExecutor;
            }
        }

        /// <summary>
        ///     Disposes the thread manager and releases all resources
        /// </summary>
        public void Dispose()
        {
            if (disposed)
            {
                return;
            }

            parallelExecutor?.Clear();
            disposed = true;
        }

        /// <summary>
        ///     Throws if the manager has been disposed
        /// </summary>
        /// <exception cref="ObjectDisposedException">Thrown when the manager is disposed</exception>
        private void ThrowIfDisposed()
        {
#if NET5_0_OR_GREATER
            ObjectDisposedException.ThrowIf(disposed, this);
#else
            if (disposed)
            {
                throw new ObjectDisposedException(GetType().FullName);
            }
#endif
        }
    }
}