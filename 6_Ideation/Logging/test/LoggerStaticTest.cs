// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoggerStaticTest.cs
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
        /// <summary>
        ///     Tests that logger trace should not throw
        /// </summary>
        [Fact]
        public void Logger_Trace_ShouldNotThrow()
        {
            Logger.Trace("Trace message");
        }

        /// <summary>
        ///     Tests that logger debug should not throw
        /// </summary>
        [Fact]
        public void Logger_Debug_ShouldNotThrow()
        {
            Logger.Debug("Debug message");
        }

        /// <summary>
        ///     Tests that logger info should not throw
        /// </summary>
        [Fact]
        public void Logger_Info_ShouldNotThrow()
        {
            Logger.Info("Info message");
        }

        /// <summary>
        ///     Tests that logger log should not throw
        /// </summary>
        [Fact]
        public void Logger_Log_ShouldNotThrow()
        {
            Logger.Log("Log message");
        }

        /// <summary>
        ///     Tests that logger warning should not throw
        /// </summary>
        [Fact]
        public void Logger_Warning_ShouldNotThrow()
        {
            Logger.Warning("Warning message");
        }

        /// <summary>
        ///     Tests that logger error should not throw
        /// </summary>
        [Fact]
        public void Logger_Error_ShouldNotThrow()
        {
            Logger.Error("Error message");
        }


        /// <summary>
        ///     Tests that logger set default logger should accept custom logger
        /// </summary>
        [Fact]
        public void Logger_SetDefaultLogger_ShouldAcceptCustomLogger()
        {
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            LoggerFactory factory = new LoggerFactory();
            factory.AddOutput(memoryOutput);
            ILogger customLogger = factory.CreateLogger("CustomLogger");

            Logger.SetDefaultLogger(customLogger);
            customLogger.LogInfo("Test");

            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
        }

        /// <summary>
        ///     Tests that logger set default logger null should reset to default
        /// </summary>
        [Fact]
        public void Logger_SetDefaultLoggerNull_ShouldResetToDefault()
        {
            Logger.SetDefaultLogger(null);

            Logger.Info("Test"); // Should not throw
        }

        /// <summary>
        ///     Tests that logger multiple calls sequential should not throw
        /// </summary>
        [Fact]
        public void Logger_MultipleCallsSequential_ShouldNotThrow()
        {
            Logger.Trace("1");
            Logger.Debug("2");
            Logger.Info("3");
            Logger.Log("4");
            Logger.Warning("5");
            Logger.Error("6");
        }

        /// <summary>
        ///     Tests that logger empty message should not throw
        /// </summary>
        [Fact]
        public void Logger_EmptyMessage_ShouldNotThrow()
        {
            Logger.Info(string.Empty);
            Logger.Warning(string.Empty);
            Logger.Error(string.Empty);
        }

        /// <summary>
        ///     Tests that logger long message should not throw
        /// </summary>
        [Fact]
        public void Logger_LongMessage_ShouldNotThrow()
        {
            string longMessage = new string('x', 10000);

            Logger.Info(longMessage);
        }

        /// <summary>
        ///     Tests that logger special characters should not throw
        /// </summary>
        [Fact]
        public void Logger_SpecialCharacters_ShouldNotThrow()
        {
            string specialMessage = "Message with special chars: \n \t \r \" ' \\";

            Logger.Info(specialMessage);
        }

        /// <summary>
        ///     Tests that logger exception should throw exception with correct message
        /// </summary>
        [Fact]
        public void Logger_Exception_ShouldThrowExceptionWithCorrectMessage()
        {
            string exceptionMessage = "Test exception message";

            InvalidOperationException thrownException = Assert.Throws<InvalidOperationException>(() => Logger.Exception(exceptionMessage));
            Assert.Equal(exceptionMessage, thrownException.Message);
        }

        /// <summary>
        ///     Tests that logger exception should log critical before throwing
        /// </summary>
        [Fact]
        public void Logger_Exception_ShouldLogCriticalBeforeThrowing()
        {
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            LoggerFactory factory = new LoggerFactory();
            factory.AddOutput(memoryOutput);
            ILogger customLogger = factory.CreateLogger("ExceptionTestLogger");
            Logger.SetDefaultLogger(customLogger);
            string exceptionMessage = "Critical error occurred";

            Assert.Throws<InvalidOperationException>(() => Logger.Exception(exceptionMessage));

            IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
            Assert.Single(entries);
            Assert.Equal(LogLevel.Critical, entries[0].Level);
            Assert.Contains(exceptionMessage, entries[0].Message);
        }

        /// <summary>
        ///     Tests that logger exception with empty message should throw
        /// </summary>
        [Fact]
        public void Logger_Exception_WithEmptyMessage_ShouldThrow()
        {
            string emptyMessage = string.Empty;

            InvalidOperationException thrownException = Assert.Throws<InvalidOperationException>(() => Logger.Exception(emptyMessage));
            Assert.Equal(emptyMessage, thrownException.Message);
        }

        /// <summary>
        ///     Tests that logger exception with null message should throw
        /// </summary>
        [Fact]
        public void Logger_Exception_WithNullMessage_ShouldThrow()
        {
            string nullMessage = null;

            Assert.Throws<InvalidOperationException>(() => Logger.Exception(nullMessage));
        }

        /// <summary>
        ///     Tests that logger exception with long message should throw with full message
        /// </summary>
        [Fact]
        public void Logger_Exception_WithLongMessage_ShouldThrowWithFullMessage()
        {
            string longMessage = new string('x', 1000);

            InvalidOperationException thrownException = Assert.Throws<InvalidOperationException>(() => Logger.Exception(longMessage));
            Assert.Equal(longMessage, thrownException.Message);
        }

        /// <summary>
        ///     Tests that logger exception with special characters should preserve message
        /// </summary>
        [Fact]
        public void Logger_Exception_WithSpecialCharacters_ShouldPreserveMessage()
        {
            string specialMessage = "Error: \n\t\"Value\" is 'invalid'\\path";

            InvalidOperationException thrownException = Assert.Throws<InvalidOperationException>(() => Logger.Exception(specialMessage));
            Assert.Equal(specialMessage, thrownException.Message);
        }
    }
}