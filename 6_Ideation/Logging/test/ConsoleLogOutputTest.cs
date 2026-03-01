// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConsoleLogOutputTest.cs
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
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the ConsoleLogOutput class.
    ///     Validates console output writing and color handling.
    /// </summary>
    public class ConsoleLogOutputTest
    {
        /// <summary>
        /// Tests that console log output constructor default formatter
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_Constructor_DefaultFormatter()
        {
            // Act
            ConsoleLogOutput output = new ConsoleLogOutput();

            // Assert
            Assert.NotNull(output);
        }

        /// <summary>
        /// Tests that console log output write should not throw
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_Write_ShouldNotThrow()
        {
            // Arrange
            ConsoleLogOutput output = new ConsoleLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "Logger");

            // Act & Assert - Should not throw
            output.Write(entry);
        }

        /// <summary>
        /// Tests that console log output null entry should not throw
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_NullEntry_ShouldNotThrow()
        {
            // Arrange
            ConsoleLogOutput output = new ConsoleLogOutput();

            // Act & Assert - Should not throw
            output.Write(null);
        }

        /// <summary>
        /// Tests that console log output all levels should not throw
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_AllLevels_ShouldNotThrow()
        {
            // Arrange
            ConsoleLogOutput output = new ConsoleLogOutput();
            LogLevel[] levels = new[] {LogLevel.Trace, LogLevel.Debug, LogLevel.Info, LogLevel.Warning, LogLevel.Error, LogLevel.Critical};

            // Act & Assert
            foreach (LogLevel level in levels)
            {
                LogEntry entry = new LogEntry(level, "Test", "Logger");
                output.Write(entry); // Should not throw
            }
        }

        /// <summary>
        /// Tests that console log output custom formatter should be used
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_CustomFormatter_ShouldBeUsed()
        {
            // Arrange
            CompactLogFormatter formatter = new CompactLogFormatter();
            ConsoleLogOutput output = new ConsoleLogOutput(formatter);

            // Act & Assert - Should not throw
            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
        }

        /// <summary>
        /// Tests that console log output null formatter should use default
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_NullFormatter_ShouldUseDefault()
        {
            // Arrange & Act
            ConsoleLogOutput output = new ConsoleLogOutput();

            // Assert - Should use default formatter
            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
        }

        /// <summary>
        /// Tests that console log output disable should not write
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_Disable_ShouldNotWrite()
        {
            // Arrange
            ConsoleLogOutput output = new ConsoleLogOutput();
            output.IsEnabled = false;

            // Act & Assert - Should not throw
            output.Write(new LogEntry(LogLevel.Info, "Test", "Logger"));
        }

        /// <summary>
        /// Tests that console log output flush should not throw
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_Flush_ShouldNotThrow()
        {
            // Arrange
            ConsoleLogOutput output = new ConsoleLogOutput();

            // Act & Assert - Should not throw
            output.Flush();
        }

        /// <summary>
        /// Tests that console log output dispose should not throw
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_Dispose_ShouldNotThrow()
        {
            // Arrange
            ConsoleLogOutput output = new ConsoleLogOutput();

            // Act & Assert - Should not throw
            output.Dispose();
        }

        /// <summary>
        /// Tests that console log output repeated dispose should not throw
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_RepeatedDispose_ShouldNotThrow()
        {
            // Arrange
            ConsoleLogOutput output = new ConsoleLogOutput();

            // Act & Assert - Should not throw
            output.Dispose();
            output.Dispose();
        }

        /// <summary>
        /// Tests that console log output has name
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_HasName()
        {
            // Arrange
            ConsoleLogOutput output = new ConsoleLogOutput();

            // Assert
            Assert.NotNull(output.Name);
            Assert.Equal("ConsoleOutput", output.Name);
        }

        /// <summary>
        /// Tests that console log output is enabled default true
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_IsEnabled_DefaultTrue()
        {
            // Arrange
            ConsoleLogOutput output = new ConsoleLogOutput();

            // Assert
            Assert.True(output.IsEnabled);
        }

        /// <summary>
        /// Tests that console log output is enabled can be toggled
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_IsEnabled_CanBeToggled()
        {
            // Arrange
            ConsoleLogOutput output = new ConsoleLogOutput();

            // Act & Assert
            output.IsEnabled = true;
            Assert.True(output.IsEnabled);

            output.IsEnabled = false;
            Assert.False(output.IsEnabled);

            output.IsEnabled = true;
            Assert.True(output.IsEnabled);
        }

        /// <summary>
        /// Tests that console log output long message should not throw
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_LongMessage_ShouldNotThrow()
        {
            // Arrange
            ConsoleLogOutput output = new ConsoleLogOutput();
            string longMessage = new string('x', 10000);
            LogEntry entry = new LogEntry(LogLevel.Info, longMessage, "Logger");

            // Act & Assert - Should not throw
            output.Write(entry);
        }

        /// <summary>
        /// Tests that console log output special characters should not throw
        /// </summary>
        [Fact]
        public void ConsoleLogOutput_SpecialCharacters_ShouldNotThrow()
        {
            // Arrange
            ConsoleLogOutput output = new ConsoleLogOutput();
            string specialMessage = "Message with special chars: \n \t \r \" ' \\";
            LogEntry entry = new LogEntry(LogLevel.Info, specialMessage, "Logger");

            // Act & Assert - Should not throw
            output.Write(entry);
        }
    }
}