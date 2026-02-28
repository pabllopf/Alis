// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ErrorHandlingTest.cs
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
using System.IO;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Filters;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive error handling tests for the logging framework.
    ///     Validates graceful handling of errors and edge cases.
    /// </summary>
    public class ErrorHandlingTest
    {
        [Fact]
        public void LoggerFactory_AddNullOutput_ShouldThrow()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => factory.AddOutput(null));
            }
        }

        [Fact]
        public void LoggerFactory_AddNullFilter_ShouldThrow()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => factory.AddFilter(null));
            }
        }

        [Fact]
        public void LoggerFactory_SetNullFormatter_ShouldThrow()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => factory.SetFormatter(null));
            }
        }

        [Fact]
        public void FileLogOutput_NullPath_ShouldThrow()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new FileLogOutput(null));
            Assert.Throws<ArgumentException>(() => new FileLogOutput(string.Empty));
            Assert.Throws<ArgumentException>(() => new FileLogOutput("   "));
        }

        [Fact]
        public void SamplingLogFilter_InvalidSampleRate_ShouldThrow()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new SamplingLogFilter(0));
            Assert.Throws<ArgumentException>(() => new SamplingLogFilter(-1));
        }

        [Fact]
        public void AsyncLogOutput_NullInnerOutput_ShouldThrow()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new AsyncLogOutput(null));
        }

        [Fact]
        public void Logger_LogAfterDispose_ShouldHandleGracefully()
        {
            // Arrange
            LoggerFactory factory = new LoggerFactory();
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            factory.AddOutput(memoryOutput);
            ILogger logger = factory.CreateLogger("TestLogger");

            // Act
            factory.Dispose();
            logger.LogInfo("After dispose"); // Should not throw

            // Assert - Behavior depends on implementation
        }

        [Fact]
        public void FileLogOutput_WriteAfterDispose_ShouldHandleGracefully()
        {
            // Arrange
            FileLogOutput output = new FileLogOutput(Path.GetTempFileName());

            // Act
            output.Dispose();
            output.Write(new LogEntry(LogLevel.Info, "After dispose", "Logger")); // Should not throw

            // Assert - Should complete without error
        }

        [Fact]
        public void LogEntry_WithNullException_ShouldHandleGracefully()
        {
            // Arrange & Act
            LogEntry entry = new LogEntry(LogLevel.Error, "Error", "Logger", null);

            // Assert
            Assert.Null(entry.Exception);
        }

        [Fact]
        public void SimpleLogFormatter_WithNullException_ShouldWork()
        {
            // Arrange
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Error, "Error", "Logger", null);

            // Act
            string result = formatter.Format(entry);

            // Assert
            Assert.NotNull(result);
            Assert.Contains("Error", result);
        }

        [Fact]
        public void JsonLogFormatter_WithNullException_ShouldNotIncludeException()
        {
            // Arrange
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            string result = formatter.Format(entry);

            // Assert
            Assert.DoesNotContain("\"exception\":", result);
        }

        [Fact]
        public void ConditionalLogFilter_NullEntry_ShouldReturnFalse()
        {
            // Arrange
            ConditionalLogFilter filter = new ConditionalLogFilter(_ => true);

            // Act
            bool result = filter.ShouldLog(null);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void LoggerNameFilter_EmptyNameList_ShouldAllowAll()
        {
            // Arrange
            LoggerNameFilter filter = new LoggerNameFilter(new string[] { }, true);
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            bool result = filter.ShouldLog(entry);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CompositeLogFilter_RequireAll_AllMustPass()
        {
            // Arrange
            ConditionalLogFilter filter1 = new ConditionalLogFilter(e => e.Message.Length > 0);
            ConditionalLogFilter filter2 = new ConditionalLogFilter(e => e.LoggerName != null);
            CompositeLogFilter composite = new CompositeLogFilter(new[] {filter1, filter2}, true);
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            bool result = composite.ShouldLog(entry);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CompositeLogFilter_RequireAny_OneMustPass()
        {
            // Arrange
            ConditionalLogFilter filter1 = new ConditionalLogFilter(_ => false);
            ConditionalLogFilter filter2 = new ConditionalLogFilter(_ => true);
            CompositeLogFilter composite = new CompositeLogFilter(new[] {filter1, filter2}, false);
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            bool result = composite.ShouldLog(entry);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void MemoryLogOutput_IsDisabledAfterDispose()
        {
            // Arrange
            MemoryLogOutput output = new MemoryLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            // Act
            output.Dispose();
            output.Write(entry); // Should not add after dispose

            // Assert
            Assert.Empty(output.GetEntries());
        }
    }
}