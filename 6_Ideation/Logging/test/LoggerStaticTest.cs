// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: LoggerStaticTest.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the static Logger class (backward compatibility).
    ///     Validates legacy API functionality and default logger behavior.
    /// </summary>
    public class LoggerStaticTest
    {
        [Fact]
        public void Logger_Trace_ShouldNotThrow()
        {
            // Act & Assert - Should not throw
            Logger.Trace("Trace message");
        }

        [Fact]
        public void Logger_Debug_ShouldNotThrow()
        {
            // Act & Assert - Should not throw
            Logger.Debug("Debug message");
        }

        [Fact]
        public void Logger_Info_ShouldNotThrow()
        {
            // Act & Assert - Should not throw
            Logger.Info("Info message");
        }

        [Fact]
        public void Logger_Log_ShouldNotThrow()
        {
            // Act & Assert - Should not throw
            Logger.Log("Log message");
        }

        [Fact]
        public void Logger_Warning_ShouldNotThrow()
        {
            // Act & Assert - Should not throw
            Logger.Warning("Warning message");
        }

        [Fact]
        public void Logger_Error_ShouldNotThrow()
        {
            // Act & Assert - Should not throw
            Logger.Error("Error message");
        }

        [Fact]
        public void Logger_Exception_ShouldThrow()
        {
            // Act & Assert
            Assert.Throws<System.Exception>(() => Logger.Exception("Exception message"));
        }

        [Fact]
        public void Logger_SetDefaultLogger_ShouldAcceptCustomLogger()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            LoggerFactory factory = new LoggerFactory();
            factory.AddOutput(memoryOutput);
            ILogger customLogger = factory.CreateLogger("CustomLogger");

            // Act
            Logger.SetDefaultLogger(customLogger);
            customLogger.LogInfo("Test");

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
        }

        [Fact]
        public void Logger_SetDefaultLoggerNull_ShouldResetToDefault()
        {
            // Act
            Logger.SetDefaultLogger(null);

            // Assert - Should use default logger
            Logger.Info("Test"); // Should not throw
        }

        [Fact]
        public void Logger_MultipleCallsSequential_ShouldNotThrow()
        {
            // Act & Assert
            Logger.Trace("1");
            Logger.Debug("2");
            Logger.Info("3");
            Logger.Log("4");
            Logger.Warning("5");
            Logger.Error("6");
        }

        [Fact]
        public void Logger_EmptyMessage_ShouldNotThrow()
        {
            // Act & Assert
            Logger.Info(string.Empty);
            Logger.Warning(string.Empty);
            Logger.Error(string.Empty);
        }

        [Fact]
        public void Logger_LongMessage_ShouldNotThrow()
        {
            // Arrange
            string longMessage = new string('x', 10000);

            // Act & Assert
            Logger.Info(longMessage);
        }

        [Fact]
        public void Logger_SpecialCharacters_ShouldNotThrow()
        {
            // Arrange
            string specialMessage = "Message with special chars: \n \t \r \" ' \\";

            // Act & Assert
            Logger.Info(specialMessage);
        }

        [Fact]
        public void Logger_InfoAndWarningMapping()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            LoggerFactory factory = new LoggerFactory();
            factory.AddOutput(memoryOutput);
            ILogger logger = factory.CreateLogger("TestLogger");
            Logger.SetDefaultLogger(logger);

            // Act
            Logger.Info("Info");
            Logger.Log("Log");

            // Assert
            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Equal(2, entries.Count);
        }
    }
}

