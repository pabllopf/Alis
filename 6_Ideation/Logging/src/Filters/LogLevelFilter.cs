// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LogLevelFilter.cs
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

using Alis.Core.Aspect.Logging.Abstractions;

namespace Alis.Core.Aspect.Logging.Filters
{
    /// <summary>
    ///     Filters log entries based on their severity level.
    ///     Only entries with level >= minimum level pass through.
    ///     AOT-compatible: Simple value comparison.
    /// </summary>
    public sealed class LogLevelFilter : ILogFilter
    {
        private readonly LogLevel _minimumLevel;

        /// <summary>
        ///     Initializes a new instance of the LogLevelFilter class.
        /// </summary>
        /// <param name="minimumLevel">The minimum level to accept.</param>
        public LogLevelFilter(LogLevel minimumLevel) => _minimumLevel = minimumLevel;

        /// <inheritdoc />
        public string Name => $"LogLevelFilter[{_minimumLevel}]";

        /// <inheritdoc />
        public bool ShouldLog(ILogEntry entry) => entry?.Level >= _minimumLevel;
    }
}