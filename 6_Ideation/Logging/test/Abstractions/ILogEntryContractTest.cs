// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ILogEntryContractTest.cs
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
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Abstractions
{
    /// <summary>
    ///     Contract tests for ILogEntry behavior through LogEntry implementation.
    /// </summary>
    public class ILogEntryContractTest
    {
        /// <summary>
        ///     Tests that log entry exposes all contract members with provided values.
        /// </summary>
        [Fact]
        public void LogEntry_ExposesContractValues()
        {
            InvalidOperationException exception = new InvalidOperationException("boom");
            Dictionary<string, object> properties = new Dictionary<string, object>
            {
                ["entityId"] = 10,
                ["isCritical"] = true
            };
            List<object> scopes = new List<object> {"Frame:124", "RenderSystem"};

            ILogEntry entry = new LogEntry(
                LogLevel.Error,
                "Render failed",
                "Game.Render",
                exception,
                "corr-123",
                properties,
                scopes);

            Assert.Equal(LogLevel.Error, entry.Level);
            Assert.Equal("Render failed", entry.Message);
            Assert.Equal("Game.Render", entry.LoggerName);
            Assert.Same(exception, entry.Exception);
            Assert.Equal("corr-123", entry.CorrelationId);
            Assert.Equal(2, entry.Properties.Count);
            Assert.Equal(2, entry.Scopes.Count);
            Assert.True(entry.ThreadId > 0);
            Assert.True(entry.Timestamp <= DateTime.UtcNow);
        }
    }
}
