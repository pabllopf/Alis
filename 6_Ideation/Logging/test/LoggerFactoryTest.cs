// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LoggerFactoryTest.cs
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
using Alis.Core.Aspect.Logging.Filters;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test
{
    /// <summary>
    ///     Comprehensive unit tests for the LoggerFactory class.
    ///     Validates factory configuration, logger creation, fluent builder pattern,
    ///     and proper resource cleanup.
    /// </summary>
    public class LoggerFactoryTest
    {
        /// <summary>
        /// Tests that logger factory constructor should initialize with default formatter
        /// </summary>
        [Fact]
        public void LoggerFactory_Constructor_ShouldInitializeWithDefaultFormatter()
        {
            // Act
            using (LoggerFactory factory = new LoggerFactory())
            {
                // Assert
                ILogger logger = factory.CreateLogger("TestLogger");
                Assert.NotNull(logger);
            }
        }

        /// <summary>
        /// Tests that logger factory create logger should return valid logger
        /// </summary>
        [Fact]
        public void LoggerFactory_CreateLogger_ShouldReturnValidLogger()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                // Act
                ILogger logger = factory.CreateLogger("TestLogger");

                // Assert
                Assert.NotNull(logger);
                Assert.Equal("TestLogger", logger.Name);
            }
        }

        /// <summary>
        /// Tests that logger factory create logger with different names should return different instances
        /// </summary>
        [Fact]
        public void LoggerFactory_CreateLoggerWithDifferentNames_ShouldReturnDifferentInstances()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                // Act
                ILogger logger1 = factory.CreateLogger("Logger1");
                ILogger logger2 = factory.CreateLogger("Logger2");

                // Assert
                Assert.NotSame(logger1, logger2);
                Assert.Equal("Logger1", logger1.Name);
                Assert.Equal("Logger2", logger2.Name);
            }
        }

        /// <summary>
        /// Tests that logger factory create logger with same name should return different instances
        /// </summary>
        [Fact]
        public void LoggerFactory_CreateLoggerWithSameName_ShouldReturnDifferentInstances()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                // Act
                ILogger logger1 = factory.CreateLogger("SameName");
                ILogger logger2 = factory.CreateLogger("SameName");

                // Assert
                Assert.NotSame(logger1, logger2);
                Assert.Equal("SameName", logger1.Name);
                Assert.Equal("SameName", logger2.Name);
            }
        }

        /// <summary>
        /// Tests that logger factory add output should chain fluently
        /// </summary>
        [Fact]
        public void LoggerFactory_AddOutput_ShouldChainFluently()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput output = new MemoryLogOutput();

                // Act
                LoggerFactory result = factory.AddOutput(output);

                // Assert
                Assert.Same(factory, result);
            }
        }

        /// <summary>
        /// Tests that logger factory add filter should chain fluently
        /// </summary>
        [Fact]
        public void LoggerFactory_AddFilter_ShouldChainFluently()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                LogLevelFilter filter = new LogLevelFilter(LogLevel.Info);

                // Act
                LoggerFactory result = factory.AddFilter(filter);

                // Assert
                Assert.Same(factory, result);
            }
        }

        /// <summary>
        /// Tests that logger factory set formatter should chain fluently
        /// </summary>
        [Fact]
        public void LoggerFactory_SetFormatter_ShouldChainFluently()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                CompactLogFormatter formatter = new CompactLogFormatter();

                // Act
                LoggerFactory result = factory.SetFormatter(formatter);

                // Assert
                Assert.Same(factory, result);
            }
        }

        /// <summary>
        /// Tests that logger factory set minimum level should chain fluently
        /// </summary>
        [Fact]
        public void LoggerFactory_SetMinimumLevel_ShouldChainFluently()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())

                // Act
            {
                LoggerFactory result = factory.SetMinimumLevel(LogLevel.Warning);

                // Assert
                Assert.Same(factory, result);
            }
        }

        /// <summary>
        /// Tests that logger factory fluent configuration should chain multiple methods
        /// </summary>
        [Fact]
        public void LoggerFactory_FluentConfiguration_ShouldChainMultipleMethods()
        {
            // Arrange & Act
            using (LoggerFactory factory = new LoggerFactory()
                       .AddOutput(new MemoryLogOutput())
                       .AddFilter(new LogLevelFilter(LogLevel.Info))
                       .SetMinimumLevel(LogLevel.Debug)
                       .SetFormatter(new SimpleLogFormatter()))
            {
                ILogger logger = factory.CreateLogger("TestLogger");

                // Assert
                Assert.NotNull(logger);
            }
        }

        /// <summary>
        /// Tests that logger factory add null output should throw argument null exception
        /// </summary>
        [Fact]
        public void LoggerFactory_AddNullOutput_ShouldThrowArgumentNullException()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => factory.AddOutput(null));
            }
        }

        /// <summary>
        /// Tests that logger factory add null filter should throw argument null exception
        /// </summary>
        [Fact]
        public void LoggerFactory_AddNullFilter_ShouldThrowArgumentNullException()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => factory.AddFilter(null));
            }
        }

        /// <summary>
        /// Tests that logger factory set null formatter should throw argument null exception
        /// </summary>
        [Fact]
        public void LoggerFactory_SetNullFormatter_ShouldThrowArgumentNullException()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                // Act & Assert
                Assert.Throws<ArgumentNullException>(() => factory.SetFormatter(null));
            }
        }

        /// <summary>
        /// Tests that logger factory configured output should be used by loggers
        /// </summary>
        [Fact]
        public void LoggerFactory_ConfiguredOutput_ShouldBeUsedByLoggers()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("TestLogger");

                // Act
                logger.LogInfo("Test message");

                // Assert
                Assert.Single(memoryOutput.GetEntries());
            }
        }

        /// <summary>
        /// Tests that logger factory configured filter should be applied by loggers
        /// </summary>
        [Fact]
        public void LoggerFactory_ConfiguredFilter_ShouldBeAppliedByLoggers()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(memoryOutput);
                factory.AddFilter(new LogLevelFilter(LogLevel.Warning));
                ILogger logger = factory.CreateLogger("TestLogger");

                // Act
                logger.LogInfo("Info");
                logger.LogWarning("Warning");
                logger.LogError("Error");

                // Assert
                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Equal(2, entries.Count);
                Assert.All(entries, e => Assert.True(e.Level >= LogLevel.Warning));
            }
        }

        /// <summary>
        /// Tests that logger factory configured formatter should be used by outputs
        /// </summary>
        [Fact]
        public void LoggerFactory_ConfiguredFormatter_ShouldBeUsedByOutputs()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(memoryOutput);
                factory.SetFormatter(new CompactLogFormatter());
                ILogger logger = factory.CreateLogger("TestLogger");

                // Act
                logger.LogInfo("Test message");

                // Assert
                Assert.Single(memoryOutput.GetEntries());
            }
        }

        /// <summary>
        /// Tests that logger factory minimum level should be applied to loggers
        /// </summary>
        [Fact]
        public void LoggerFactory_MinimumLevel_ShouldBeAppliedToLoggers()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(memoryOutput);
                factory.SetMinimumLevel(LogLevel.Warning);
                ILogger logger = factory.CreateLogger("TestLogger");

                // Act
                logger.LogDebug("Debug");
                logger.LogInfo("Info");
                logger.LogWarning("Warning");

                // Assert
                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Equal(LogLevel.Warning, entries[0].Level);
            }
        }

        /// <summary>
        /// Tests that logger factory multiple outputs should all receive entries
        /// </summary>
        [Fact]
        public void LoggerFactory_MultipleOutputs_ShouldAllReceiveEntries()
        {
            // Arrange
            MemoryLogOutput memory1 = new MemoryLogOutput();
            MemoryLogOutput memory2 = new MemoryLogOutput();
            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(memory1);
                factory.AddOutput(memory2);
                ILogger logger = factory.CreateLogger("TestLogger");

                // Act
                logger.LogInfo("Message");

                // Assert
                Assert.Single(memory1.GetEntries());
                Assert.Single(memory2.GetEntries());
            }
        }

        /// <summary>
        /// Tests that logger factory flush should flush all outputs
        /// </summary>
        [Fact]
        public void LoggerFactory_Flush_ShouldFlushAllOutputs()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("TestLogger");
                logger.LogInfo("Test");

                // Act
                factory.Flush();

                // Assert
                Assert.Single(memoryOutput.GetEntries());
            }
        }

        /// <summary>
        /// Tests that logger factory dispose should call dispose on outputs
        /// </summary>
        [Fact]
        public void LoggerFactory_Dispose_ShouldCallDisposeOnOutputs()
        {
            // Arrange
            DisposableLogOutput disposableOutput = new DisposableLogOutput();
            LoggerFactory factory = new LoggerFactory();
            factory.AddOutput(disposableOutput);

            // Act
            factory.Dispose();

            // Assert
            Assert.True(disposableOutput.IsDisposed);
        }


        /// <summary>
        /// Tests that logger factory disposed factory should not throw on second dispose
        /// </summary>
        [Fact]
        public void LoggerFactory_DisposedFactory_ShouldNotThrowOnSecondDispose()
        {
            // Arrange
            LoggerFactory factory = new LoggerFactory();

            // Act & Assert - Should not throw
            factory.Dispose();
            factory.Dispose();
        }

        /// <summary>
        /// Tests that logger factory create logger with empty name should be allowed
        /// </summary>
        [Fact]
        public void LoggerFactory_CreateLoggerWithEmptyName_ShouldBeAllowed()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                // Act
                ILogger logger = factory.CreateLogger(string.Empty);

                // Assert
                Assert.NotNull(logger);
                Assert.Equal(string.Empty, logger.Name);
            }
        }

        /// <summary>
        /// Tests that logger factory add multiple same filters should apply all
        /// </summary>
        [Fact]
        public void LoggerFactory_AddMultipleSameFilters_ShouldApplyAll()
        {
            // Arrange
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(memoryOutput);
                factory.AddFilter(new LogLevelFilter(LogLevel.Info));
                factory.AddFilter(new LoggerNameFilter(new[] {"TestLogger"}, true));
                ILogger logger = factory.CreateLogger("TestLogger");

                // Act
                logger.LogInfo("Message");
                logger.LogDebug("Debug");

                // Assert
                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
            }
        }

        /// <summary>
        /// Tests that logger factory change formatter should affect new loggers
        /// </summary>
        [Fact]
        public void LoggerFactory_ChangeFormatter_ShouldAffectNewLoggers()
        {
            // Arrange
            using (LoggerFactory factory = new LoggerFactory())
            {
                SimpleLogFormatter formatter1 = new SimpleLogFormatter();
                factory.SetFormatter(formatter1);

                ILogger logger1 = factory.CreateLogger("Logger1");
                Assert.NotNull(logger1);

                // Act
                CompactLogFormatter formatter2 = new CompactLogFormatter();
                factory.SetFormatter(formatter2);

                ILogger logger2 = factory.CreateLogger("Logger2");

                // Assert
                Assert.NotNull(logger2);
            }
        }

        /// <summary>
        ///     Helper output for testing disposal.
        /// </summary>
        private sealed class DisposableLogOutput : ILogOutput
        {
            /// <summary>
            /// Gets or sets the value of the is disposed
            /// </summary>
            public bool IsDisposed { get; private set; }
            /// <summary>
            /// Gets the value of the name
            /// </summary>
            public string Name => "DisposableOutput";
            /// <summary>
            /// Gets or sets the value of the is enabled
            /// </summary>
            public bool IsEnabled { get; set; } = true;

            /// <summary>
            /// Writes the entry
            /// </summary>
            /// <param name="entry">The entry</param>
            public void Write(ILogEntry entry)
            {
            }

            /// <summary>
            /// Flushes this instance
            /// </summary>
            public void Flush()
            {
            }

            /// <summary>
            /// Disposes this instance
            /// </summary>
            public void Dispose()
            {
                IsDisposed = true;
            }
        }
    }
}