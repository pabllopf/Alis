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
        /// <summary>
        ///     Tests that logger factory add null output should throw
        /// </summary>
        [Fact]
        public void LoggerFactory_AddNullOutput_ShouldThrow()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                Assert.Throws<ArgumentNullException>(() => factory.AddOutput(null));
            }
        }

        /// <summary>
        ///     Tests that logger factory add null filter should throw
        /// </summary>
        [Fact]
        public void LoggerFactory_AddNullFilter_ShouldThrow()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                Assert.Throws<ArgumentNullException>(() => factory.AddFilter(null));
            }
        }

        /// <summary>
        ///     Tests that logger factory set null formatter should throw
        /// </summary>
        [Fact]
        public void LoggerFactory_SetNullFormatter_ShouldThrow()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                Assert.Throws<ArgumentNullException>(() => factory.SetFormatter(null));
            }
        }

        /// <summary>
        ///     Tests that file log output null path should throw
        /// </summary>
        [Fact]
        public void FileLogOutput_NullPath_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => new FileLogOutput(null));
            Assert.Throws<ArgumentException>(() => new FileLogOutput(string.Empty));
            Assert.Throws<ArgumentException>(() => new FileLogOutput("   "));
        }

        /// <summary>
        ///     Tests that sampling log filter invalid sample rate should throw
        /// </summary>
        [Fact]
        public void SamplingLogFilter_InvalidSampleRate_ShouldThrow()
        {
            Assert.Throws<ArgumentException>(() => new SamplingLogFilter(0));
            Assert.Throws<ArgumentException>(() => new SamplingLogFilter(-1));
        }

        /// <summary>
        ///     Tests that async log output null inner output should throw
        /// </summary>
        [Fact]
        public void AsyncLogOutput_NullInnerOutput_ShouldThrow()
        {
            Assert.Throws<ArgumentNullException>(() => new AsyncLogOutput(null));
        }

        /// <summary>
        ///     Tests that logger log after dispose should handle gracefully
        /// </summary>
        [Fact]
        public void Logger_LogAfterDispose_ShouldHandleGracefully()
        {
            LoggerFactory factory = new LoggerFactory();
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            factory.AddOutput(memoryOutput);
            ILogger logger = factory.CreateLogger("TestLogger");

            factory.Dispose();
            logger.LogInfo("After dispose"); // Should not throw

        }

        /// <summary>
        ///     Tests that file log output write after dispose should handle gracefully
        /// </summary>
        [Fact]
        public void FileLogOutput_WriteAfterDispose_ShouldHandleGracefully()
        {
            FileLogOutput output = new FileLogOutput(Path.GetTempFileName());

            output.Dispose();
            output.Write(new LogEntry(LogLevel.Info, "After dispose", "Logger")); // Should not throw

        }

        /// <summary>
        ///     Tests that log entry with null exception should handle gracefully
        /// </summary>
        [Fact]
        public void LogEntry_WithNullException_ShouldHandleGracefully()
        {
            LogEntry entry = new LogEntry(LogLevel.Error, "Error", "Logger");

            Assert.Null(entry.Exception);
        }

        /// <summary>
        ///     Tests that simple log formatter with null exception should work
        /// </summary>
        [Fact]
        public void SimpleLogFormatter_WithNullException_ShouldWork()
        {
            SimpleLogFormatter formatter = new SimpleLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Error, "Error", "Logger");

            string result = formatter.Format(entry);

            Assert.NotNull(result);
            Assert.Contains("Error", result);
        }

        /// <summary>
        ///     Tests that json log formatter with null exception should not include exception
        /// </summary>
        [Fact]
        public void JsonLogFormatter_WithNullException_ShouldNotIncludeException()
        {
            JsonLogFormatter formatter = new JsonLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            string result = formatter.Format(entry);

            Assert.DoesNotContain("\"exception\":", result);
        }

        /// <summary>
        ///     Tests that conditional log filter null entry should return false
        /// </summary>
        [Fact]
        public void ConditionalLogFilter_NullEntry_ShouldReturnFalse()
        {
            ConditionalLogFilter filter = new ConditionalLogFilter(_ => true);

            bool result = filter.ShouldLog(null);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that logger name filter empty name list should allow all
        /// </summary>
        [Fact]
        public void LoggerNameFilter_EmptyNameList_ShouldAllowAll()
        {
            LoggerNameFilter filter = new LoggerNameFilter(new string[] { });
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            bool result = filter.ShouldLog(entry);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that composite log filter require all all must pass
        /// </summary>
        [Fact]
        public void CompositeLogFilter_RequireAll_AllMustPass()
        {
            ConditionalLogFilter filter1 = new ConditionalLogFilter(e => e.Message.Length > 0);
            ConditionalLogFilter filter2 = new ConditionalLogFilter(e => e.LoggerName != null);
            CompositeLogFilter composite = new CompositeLogFilter(new[] {filter1, filter2});
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            bool result = composite.ShouldLog(entry);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that composite log filter require any one must pass
        /// </summary>
        [Fact]
        public void CompositeLogFilter_RequireAny_OneMustPass()
        {
            ConditionalLogFilter filter1 = new ConditionalLogFilter(_ => false);
            ConditionalLogFilter filter2 = new ConditionalLogFilter(_ => true);
            CompositeLogFilter composite = new CompositeLogFilter(new[] {filter1, filter2}, false);
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            bool result = composite.ShouldLog(entry);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that memory log output is disabled after dispose
        /// </summary>
        [Fact]
        public void MemoryLogOutput_IsDisabledAfterDispose()
        {
            MemoryLogOutput output = new MemoryLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            output.Dispose();
            output.Write(entry); // Should not add after dispose

            Assert.Empty(output.GetEntries());
        }
    }
}