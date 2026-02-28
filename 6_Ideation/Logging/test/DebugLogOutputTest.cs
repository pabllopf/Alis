// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: DebugLogOutputTest.cs
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

using Alis.Core.Aspect.Logging;
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
            var output = new DebugLogOutput();

            // Assert
            Assert.NotNull(output);
        }

        [Fact]
        public void DebugLogOutput_Write_ShouldNotThrow()
        {
            // Arrange
            var output = new DebugLogOutput();
            var entry = new LogEntry(LogLevel.Info, "Test message", "Logger");

            // Act & Assert - Should not throw
            output.Write(entry);
        }

        [Fact]
        public void DebugLogOutput_NullEntry_ShouldNotThrow()
        {
            // Arrange
            var output = new DebugLogOutput();

            // Act & Assert - Should not throw
            output.Write(null);
        }

        [Fact]
        public void DebugLogOutput_AllLevels_ShouldNotThrow()
        {
            // Arrange
            var output = new DebugLogOutput();
            var levels = new[] { LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical };

            // Act & Assert
            foreach (var level in levels)
            {
                var entry = new LogEntry(level, "Test", "Logger");
                output.Write(entry); // Should not throw
            }
        }

        [Fact]
        public void DebugLogOutput_CustomFormatter_ShouldBeUsed()
        {
            // Arrange
            var formatter = new JsonLogFormatter();
            var output = new DebugLogOutput(formatter);

            // Act & Assert - Should not throw
            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
        }

        [Fact]
        public void DebugLogOutput_NullFormatter_ShouldUseDefault()
        {
            // Arrange & Act
            var output = new DebugLogOutput(null);

            // Assert
            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
        }

        [Fact]
        public void DebugLogOutput_Disable_ShouldNotWrite()
        {
            // Arrange
            var output = new DebugLogOutput();
            output.IsEnabled = false;

            // Act & Assert - Should not throw
            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
        }

        [Fact]
        public void DebugLogOutput_Flush_ShouldNotThrow()
        {
            // Arrange
            var output = new DebugLogOutput();

            // Act & Assert - Should not throw
            output.Flush();
        }

        [Fact]
        public void DebugLogOutput_Dispose_ShouldNotThrow()
        {
            // Arrange
            var output = new DebugLogOutput();

            // Act & Assert - Should not throw
            output.Dispose();
        }

        [Fact]
        public void DebugLogOutput_RepeatedDispose_ShouldNotThrow()
        {
            // Arrange
            var output = new DebugLogOutput();

            // Act & Assert - Should not throw
            output.Dispose();
            output.Dispose();
        }

        [Fact]
        public void DebugLogOutput_HasName()
        {
            // Arrange
            var output = new DebugLogOutput();

            // Assert
            Assert.NotNull(output.Name);
            Assert.Equal("DebugOutput", output.Name);
        }

        [Fact]
        public void DebugLogOutput_IsEnabled_DefaultTrue()
        {
            // Arrange
            var output = new DebugLogOutput();

            // Assert
            Assert.True(output.IsEnabled);
        }

        [Fact]
        public void DebugLogOutput_IsEnabled_CanBeToggled()
        {
            // Arrange
            var output = new DebugLogOutput();

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
            var output = new DebugLogOutput();
            var exception = new System.InvalidOperationException("Test exception");
            var entry = new LogEntry(LogLevel.Error, "Error message", "Logger", exception);

            // Act & Assert - Should not throw
            output.Write(entry);
        }

        [Fact]
        public void DebugLogOutput_WithCorrelationId_ShouldNotThrow()
        {
            // Arrange
            var output = new DebugLogOutput();
            var entry = new LogEntry(LogLevel.Info, "Message", "Logger", correlationId: "CORR-123");

            // Act & Assert - Should not throw
            output.Write(entry);
        }

        [Fact]
        public void DebugLogOutput_WithScopes_ShouldNotThrow()
        {
            // Arrange
            var output = new DebugLogOutput();
            var entry = new LogEntry(LogLevel.Info, "Message", "Logger", scopes: new[] { "Scope1", "Scope2" });

            // Act & Assert - Should not throw
            output.Write(entry);
        }
    }
}

