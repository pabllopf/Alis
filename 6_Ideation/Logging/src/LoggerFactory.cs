// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoggerFactory.cs
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
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Formatters;

namespace Alis.Core.Aspect.Logging
{
    /// <summary>
    ///     Factory for creating and configuring logger instances.
    ///     Uses a fluent builder pattern for configuration.
    ///     AOT-compatible: No reflection, no singleton pattern.
    ///     Not thread-safe for configuration, but created loggers are thread-safe.
    /// </summary>
    public sealed class LoggerFactory : IDisposable
    {
        private readonly List<ILogFilter> _filters = new List<ILogFilter>();
        private readonly List<ILogOutput> _outputs = new List<ILogOutput>();
        private bool _disposed;
        private ILogFormatter _formatter;
        private LogLevel _minimumLevel = LogLevel.Trace;

        /// <summary>
        ///     Initializes a new instance of the LoggerFactory class.
        /// </summary>
        public LoggerFactory() =>
            // Default formatter
            _formatter = new SimpleLogFormatter();

        /// <inheritdoc />
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;

            // Flush all outputs
            foreach (ILogOutput output in _outputs)
            {
                try
                {
                    output.Flush();
                    output.Dispose();
                }
                catch
                {
                    // Prevent one output failure from affecting others
                }
            }

            _outputs.Clear();
            _filters.Clear();
        }

        /// <summary>
        ///     Adds a log output to this factory.
        ///     All loggers created by this factory will write to this output.
        /// </summary>
        /// <param name="output">The output to add.</param>
        /// <returns>This factory for fluent chaining.</returns>
        public LoggerFactory AddOutput(ILogOutput output)
        {
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            _outputs.Add(output);
            return this;
        }

        /// <summary>
        ///     Adds a log filter to this factory.
        ///     All loggers created by this factory will apply this filter.
        /// </summary>
        /// <param name="filter">The filter to add.</param>
        /// <returns>This factory for fluent chaining.</returns>
        public LoggerFactory AddFilter(ILogFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter));
            }

            _filters.Add(filter);
            return this;
        }

        /// <summary>
        ///     Sets the log formatter for this factory.
        ///     All loggers created by this factory will use this formatter.
        /// </summary>
        /// <param name="formatter">The formatter to use.</param>
        /// <returns>This factory for fluent chaining.</returns>
        public LoggerFactory SetFormatter(ILogFormatter formatter)
        {
            _formatter = formatter ?? throw new ArgumentNullException(nameof(formatter));
            return this;
        }

        /// <summary>
        ///     Sets the minimum log level for all loggers created by this factory.
        /// </summary>
        /// <param name="level">The minimum level.</param>
        /// <returns>This factory for fluent chaining.</returns>
        public LoggerFactory SetMinimumLevel(LogLevel level)
        {
            _minimumLevel = level;
            return this;
        }

        /// <summary>
        ///     Creates a new logger instance with the given name.
        ///     The logger will use all configured outputs, filters, and formatter.
        /// </summary>
        /// <param name="name">The name for the logger (typically a class or component name).</param>
        /// <returns>A configured ILogger instance.</returns>
        public ILogger CreateLogger(string name)
        {
            CoreLogger logger = new CoreLogger(name, _outputs, _filters, _formatter, _minimumLevel);
            return logger;
        }

        /// <summary>
        ///     Flushes all outputs and cleans up resources.
        /// </summary>
        public void Flush()
        {
            if (_disposed)
            {
                return;
            }

            foreach (ILogOutput output in _outputs)
            {
                try
                {
                    output.Flush();
                }
                catch
                {
                    // Prevent one output failure from affecting others
                }
            }
        }
    }
}