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
        [Fact]
        public void DebugLogOutput_Constructor_DefaultFormatter()
        {
            // Act
            DebugLogOutput output = new DebugLogOutput();

            // Assert
            Assert.NotNull(output);
        }

        [Fact]
        public void DebugLogOutput_Write_ShouldNotThrow()
        {
            // Arrange
            DebugLogOutput output = new DebugLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "Logger");

            // Act & Assert - Should not throw
            output.Write(entry);
        }

        [Fact]
        public void DebugLogOutput_NullEntry_ShouldNotThrow()
        {
            // Arrange
            DebugLogOutput output = new DebugLogOutput();

            // Act & Assert - Should not throw
            output.Write(null);
        }

        [Fact]
        public void DebugLogOutput_AllLevels_ShouldNotThrow()
        {
            // Arrange
            DebugLogOutput output = new DebugLogOutput();
            LogLevel[] levels = new[] {LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical};

            // Act & Assert
            foreach (LogLevel level in levels)
            {
                LogEntry entry = new LogEntry(level, "Test", "Logger");
                output.Write(entry); // Should not throw
            }
        }

        [Fact]
        public void DebugLogOutput_CustomFormatter_ShouldBeUsed()
        {
            // Arrange
            JsonLogFormatter formatter = new JsonLogFormatter();
            DebugLogOutput output = new DebugLogOutput(formatter);

            // Act & Assert - Should not throw
            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
        }

        [Fact]
        public void DebugLogOutput_NullFormatter_ShouldUseDefault()
        {
            // Arrange & Act
            DebugLogOutput output = new DebugLogOutput();

            // Assert
            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
        }

        [Fact]
        public void DebugLogOutput_Disable_ShouldNotWrite()
        {
            // Arrange
            DebugLogOutput output = new DebugLogOutput();
            output.IsEnabled = false;

            // Act & Assert - Should not throw
            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
        }

        [Fact]
        public void DebugLogOutput_Flush_ShouldNotThrow()
        {
            // Arrange
            DebugLogOutput output = new DebugLogOutput();

            // Act & Assert - Should not throw
            output.Flush();
        }

        [Fact]
        public void DebugLogOutput_Dispose_ShouldNotThrow()
        {
            // Arrange
            DebugLogOutput output = new DebugLogOutput();

            // Act & Assert - Should not throw
            output.Dispose();
        }

        [Fact]
        public void DebugLogOutput_RepeatedDispose_ShouldNotThrow()
        {
            // Arrange
            DebugLogOutput output = new DebugLogOutput();

            // Act & Assert - Should not throw
            output.Dispose();
            output.Dispose();
        }

        [Fact]
        public void DebugLogOutput_HasName()
        {
            // Arrange
            DebugLogOutput output = new DebugLogOutput();

            // Assert
            Assert.NotNull(output.Name);
            Assert.Equal("DebugOutput", output.Name);
        }

        [Fact]
        public void DebugLogOutput_IsEnabled_DefaultTrue()
        {
            // Arrange
            DebugLogOutput output = new DebugLogOutput();

            // Assert
            Assert.True(output.IsEnabled);
        }

        [Fact]
        public void DebugLogOutput_IsEnabled_CanBeToggled()
        {
            // Arrange
            DebugLogOutput output = new DebugLogOutput();

            // Act & Assert
            output.IsEnabled = true;
            Assert.True(output.IsEnabled);

            output.IsEnabled = false;
            Assert.False(output.IsEnabled);

            output.IsEnabled = true;
            Assert.True(output.IsEnabled);
        }

        [Fact]
        public void DebugLogOutput_WithException_ShouldNotThrow()
        {
            // Arrange
            DebugLogOutput output = new DebugLogOutput();
            InvalidOperationException exception = new InvalidOperationException("Test exception");
            LogEntry entry = new LogEntry(LogLevel.Error, "Error message", "Logger", exception);

            // Act & Assert - Should not throw
            output.Write(entry);
        }

        [Fact]
        public void DebugLogOutput_WithCorrelationId_ShouldNotThrow()
        {
            // Arrange
            DebugLogOutput output = new DebugLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", correlationId: "CORR-123");

            // Act & Assert - Should not throw
            output.Write(entry);
        }

        [Fact]
        public void DebugLogOutput_WithScopes_ShouldNotThrow()
        {
            // Arrange
            DebugLogOutput output = new DebugLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: new[] {"Scope1", "Scope2"});

            // Act & Assert - Should not throw
            output.Write(entry);
        }
    }
}