// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DebugLogOutputTest.cs
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
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the DebugLogOutput class.
    ///     Validates debug output writing and debugger awareness.
    /// </summary>
    public class DebugLogOutputTest
    {
        /// <summary>
        ///     Tests that debug log output constructor default formatter
        /// </summary>
        [Fact]
        public void DebugLogOutput_Constructor_DefaultFormatter()
        {
            DebugLogOutput output = new DebugLogOutput();

            Assert.NotNull(output);
        }

        /// <summary>
        ///     Tests that debug log output write should not throw
        /// </summary>
        [Fact]
        public void DebugLogOutput_Write_ShouldNotThrow()
        {
            DebugLogOutput output = new DebugLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "Logger");

            output.Write(entry);
        }

        /// <summary>
        ///     Tests that debug log output null entry should not throw
        /// </summary>
        [Fact]
        public void DebugLogOutput_NullEntry_ShouldNotThrow()
        {
            DebugLogOutput output = new DebugLogOutput();

            output.Write(null);
        }

        /// <summary>
        ///     Tests that debug log output all levels should not throw
        /// </summary>
        [Fact]
        public void DebugLogOutput_AllLevels_ShouldNotThrow()
        {
            DebugLogOutput output = new DebugLogOutput();
            LogLevel[] levels = new[] {LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical};

            foreach (LogLevel level in levels)
            {
                LogEntry entry = new LogEntry(level, "Test", "Logger");
                output.Write(entry); // Should not throw
            }
        }

        /// <summary>
        ///     Tests that debug log output custom formatter should be used
        /// </summary>
        [Fact]
        public void DebugLogOutput_CustomFormatter_ShouldBeUsed()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            DebugLogOutput output = new DebugLogOutput(formatter);

            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
        }

        /// <summary>
        ///     Tests that debug log output null formatter should use default
        /// </summary>
        [Fact]
        public void DebugLogOutput_NullFormatter_ShouldUseDefault()
        {
            DebugLogOutput output = new DebugLogOutput();

            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
        }

        /// <summary>
        ///     Tests that debug log output disable should not write
        /// </summary>
        [Fact]
        public void DebugLogOutput_Disable_ShouldNotWrite()
        {
            DebugLogOutput output = new DebugLogOutput();
            output.IsEnabled = false;

            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
        }

        /// <summary>
        ///     Tests that debug log output flush should not throw
        /// </summary>
        [Fact]
        public void DebugLogOutput_Flush_ShouldNotThrow()
        {
            DebugLogOutput output = new DebugLogOutput();

            output.Flush();
        }

        /// <summary>
        ///     Tests that debug log output dispose should not throw
        /// </summary>
        [Fact]
        public void DebugLogOutput_Dispose_ShouldNotThrow()
        {
            DebugLogOutput output = new DebugLogOutput();

            output.Dispose();
        }

        /// <summary>
        ///     Tests that debug log output repeated dispose should not throw
        /// </summary>
        [Fact]
        public void DebugLogOutput_RepeatedDispose_ShouldNotThrow()
        {
            DebugLogOutput output = new DebugLogOutput();

            output.Dispose();
            output.Dispose();
        }

        /// <summary>
        ///     Tests that debug log output has name
        /// </summary>
        [Fact]
        public void DebugLogOutput_HasName()
        {
            DebugLogOutput output = new DebugLogOutput();

            Assert.NotNull(output.Name);
            Assert.Equal("DebugOutput", output.Name);
        }

        /// <summary>
        ///     Tests that debug log output is enabled default true
        /// </summary>
        [Fact]
        public void DebugLogOutput_IsEnabled_DefaultTrue()
        {
            DebugLogOutput output = new DebugLogOutput();

            Assert.True(output.IsEnabled);
        }

        /// <summary>
        ///     Tests that debug log output is enabled can be toggled
        /// </summary>
        [Fact]
        public void DebugLogOutput_IsEnabled_CanBeToggled()
        {
            DebugLogOutput output = new DebugLogOutput();

            output.IsEnabled = true;
            Assert.True(output.IsEnabled);

            output.IsEnabled = false;
            Assert.False(output.IsEnabled);

            output.IsEnabled = true;
            Assert.True(output.IsEnabled);
        }

        /// <summary>
        ///     Tests that debug log output with exception should not throw
        /// </summary>
        [Fact]
        public void DebugLogOutput_WithException_ShouldNotThrow()
        {
            DebugLogOutput output = new DebugLogOutput();
            InvalidOperationException exception = new InvalidOperationException("Test exception");
            LogEntry entry = new LogEntry(LogLevel.Error, "Error message", "Logger", exception);

            output.Write(entry);
        }

        /// <summary>
        ///     Tests that debug log output with correlation id should not throw
        /// </summary>
        [Fact]
        public void DebugLogOutput_WithCorrelationId_ShouldNotThrow()
        {
            DebugLogOutput output = new DebugLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", correlationId: "CORR-123");

            output.Write(entry);
        }

        /// <summary>
        ///     Tests that debug log output with scopes should not throw
        /// </summary>
        [Fact]
        public void DebugLogOutput_WithScopes_ShouldNotThrow()
        {
            DebugLogOutput output = new DebugLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: new[] {"Scope1", "Scope2"});

            output.Write(entry);
        }
    }
}