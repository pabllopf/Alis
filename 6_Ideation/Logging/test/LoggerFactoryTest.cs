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


        [Fact]
        public void LoggerFactory_DisposedFactory_ShouldNotThrowOnSecondDispose()
        {
            // Arrange
            LoggerFactory factory = new LoggerFactory();

            // Act & Assert - Should not throw
            factory.Dispose();
            factory.Dispose();
        }

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
            public bool IsDisposed { get; private set; }
            public string Name => "DisposableOutput";
            public bool IsEnabled { get; set; } = true;

            public void Write(ILogEntry entry)
            {
            }

            public void Flush()
            {
            }

            public void Dispose()
            {
                IsDisposed = true;
            }
        }
    }
}