

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
        ///     Tests that logger factory constructor should initialize with default formatter
        /// </summary>
        [Fact]
        public void LoggerFactory_Constructor_ShouldInitializeWithDefaultFormatter()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                ILogger logger = factory.CreateLogger("TestLogger");
                Assert.NotNull(logger);
            }
        }

        /// <summary>
        ///     Tests that logger factory create logger should return valid logger
        /// </summary>
        [Fact]
        public void LoggerFactory_CreateLogger_ShouldReturnValidLogger()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                ILogger logger = factory.CreateLogger("TestLogger");

                Assert.NotNull(logger);
                Assert.Equal("TestLogger", logger.Name);
            }
        }

        /// <summary>
        ///     Tests that logger factory create logger with different names should return different instances
        /// </summary>
        [Fact]
        public void LoggerFactory_CreateLoggerWithDifferentNames_ShouldReturnDifferentInstances()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                ILogger logger1 = factory.CreateLogger("Logger1");
                ILogger logger2 = factory.CreateLogger("Logger2");

                Assert.NotSame(logger1, logger2);
                Assert.Equal("Logger1", logger1.Name);
                Assert.Equal("Logger2", logger2.Name);
            }
        }

        /// <summary>
        ///     Tests that logger factory create logger with same name should return different instances
        /// </summary>
        [Fact]
        public void LoggerFactory_CreateLoggerWithSameName_ShouldReturnDifferentInstances()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                ILogger logger1 = factory.CreateLogger("SameName");
                ILogger logger2 = factory.CreateLogger("SameName");

                Assert.NotSame(logger1, logger2);
                Assert.Equal("SameName", logger1.Name);
                Assert.Equal("SameName", logger2.Name);
            }
        }

        /// <summary>
        ///     Tests that logger factory add output should chain fluently
        /// </summary>
        [Fact]
        public void LoggerFactory_AddOutput_ShouldChainFluently()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                MemoryLogOutput output = new MemoryLogOutput();

                LoggerFactory result = factory.AddOutput(output);

                Assert.Same(factory, result);
            }
        }

        /// <summary>
        ///     Tests that logger factory add filter should chain fluently
        /// </summary>
        [Fact]
        public void LoggerFactory_AddFilter_ShouldChainFluently()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                LogLevelFilter filter = new LogLevelFilter(LogLevel.Info);

                LoggerFactory result = factory.AddFilter(filter);

                Assert.Same(factory, result);
            }
        }

        /// <summary>
        ///     Tests that logger factory set formatter should chain fluently
        /// </summary>
        [Fact]
        public void LoggerFactory_SetFormatter_ShouldChainFluently()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                CompactLogFormatter formatter = new CompactLogFormatter();

                LoggerFactory result = factory.SetFormatter(formatter);

                Assert.Same(factory, result);
            }
        }

        /// <summary>
        ///     Tests that logger factory set minimum level should chain fluently
        /// </summary>
        [Fact]
        public void LoggerFactory_SetMinimumLevel_ShouldChainFluently()
        {
            using (LoggerFactory factory = new LoggerFactory())

            {
                LoggerFactory result = factory.SetMinimumLevel(LogLevel.Warning);

                Assert.Same(factory, result);
            }
        }

        /// <summary>
        ///     Tests that logger factory fluent configuration should chain multiple methods
        /// </summary>
        [Fact]
        public void LoggerFactory_FluentConfiguration_ShouldChainMultipleMethods()
        {
            using (LoggerFactory factory = new LoggerFactory()
                       .AddOutput(new MemoryLogOutput())
                       .AddFilter(new LogLevelFilter(LogLevel.Info))
                       .SetMinimumLevel(LogLevel.Debug)
                       .SetFormatter(new SimpleLogFormatter()))
            {
                ILogger logger = factory.CreateLogger("TestLogger");

                Assert.NotNull(logger);
            }
        }

        /// <summary>
        ///     Tests that logger factory add null output should throw argument null exception
        /// </summary>
        [Fact]
        public void LoggerFactory_AddNullOutput_ShouldThrowArgumentNullException()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                Assert.Throws<ArgumentNullException>(() => factory.AddOutput(null));
            }
        }

        /// <summary>
        ///     Tests that logger factory add null filter should throw argument null exception
        /// </summary>
        [Fact]
        public void LoggerFactory_AddNullFilter_ShouldThrowArgumentNullException()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                Assert.Throws<ArgumentNullException>(() => factory.AddFilter(null));
            }
        }

        /// <summary>
        ///     Tests that logger factory set null formatter should throw argument null exception
        /// </summary>
        [Fact]
        public void LoggerFactory_SetNullFormatter_ShouldThrowArgumentNullException()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                Assert.Throws<ArgumentNullException>(() => factory.SetFormatter(null));
            }
        }

        /// <summary>
        ///     Tests that logger factory configured output should be used by loggers
        /// </summary>
        [Fact]
        public void LoggerFactory_ConfiguredOutput_ShouldBeUsedByLoggers()
        {
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("TestLogger");

                logger.LogInfo("Test message");

                Assert.Single(memoryOutput.GetEntries());
            }
        }

        /// <summary>
        ///     Tests that logger factory configured filter should be applied by loggers
        /// </summary>
        [Fact]
        public void LoggerFactory_ConfiguredFilter_ShouldBeAppliedByLoggers()
        {
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(memoryOutput);
                factory.AddFilter(new LogLevelFilter(LogLevel.Warning));
                ILogger logger = factory.CreateLogger("TestLogger");

                logger.LogInfo("Info");
                logger.LogWarning("Warning");
                logger.LogError("Error");

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Equal(2, entries.Count);
                Assert.All(entries, e => Assert.True(e.Level >= LogLevel.Warning));
            }
        }

        /// <summary>
        ///     Tests that logger factory configured formatter should be used by outputs
        /// </summary>
        [Fact]
        public void LoggerFactory_ConfiguredFormatter_ShouldBeUsedByOutputs()
        {
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(memoryOutput);
                factory.SetFormatter(new CompactLogFormatter());
                ILogger logger = factory.CreateLogger("TestLogger");

                logger.LogInfo("Test message");

                Assert.Single(memoryOutput.GetEntries());
            }
        }

        /// <summary>
        ///     Tests that logger factory minimum level should be applied to loggers
        /// </summary>
        [Fact]
        public void LoggerFactory_MinimumLevel_ShouldBeAppliedToLoggers()
        {
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(memoryOutput);
                factory.SetMinimumLevel(LogLevel.Warning);
                ILogger logger = factory.CreateLogger("TestLogger");

                logger.LogDebug("Debug");
                logger.LogInfo("Info");
                logger.LogWarning("Warning");

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
                Assert.Equal(LogLevel.Warning, entries[0].Level);
            }
        }

        /// <summary>
        ///     Tests that logger factory multiple outputs should all receive entries
        /// </summary>
        [Fact]
        public void LoggerFactory_MultipleOutputs_ShouldAllReceiveEntries()
        {
            MemoryLogOutput memory1 = new MemoryLogOutput();
            MemoryLogOutput memory2 = new MemoryLogOutput();
            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(memory1);
                factory.AddOutput(memory2);
                ILogger logger = factory.CreateLogger("TestLogger");

                logger.LogInfo("Message");

                Assert.Single(memory1.GetEntries());
                Assert.Single(memory2.GetEntries());
            }
        }

        /// <summary>
        ///     Tests that logger factory flush should flush all outputs
        /// </summary>
        [Fact]
        public void LoggerFactory_Flush_ShouldFlushAllOutputs()
        {
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(memoryOutput);
                ILogger logger = factory.CreateLogger("TestLogger");
                logger.LogInfo("Test");

                factory.Flush();

                Assert.Single(memoryOutput.GetEntries());
            }
        }

        /// <summary>
        ///     Tests that logger factory dispose should call dispose on outputs
        /// </summary>
        [Fact]
        public void LoggerFactory_Dispose_ShouldCallDisposeOnOutputs()
        {
            DisposableLogOutput disposableOutput = new DisposableLogOutput();
            LoggerFactory factory = new LoggerFactory();
            factory.AddOutput(disposableOutput);

            factory.Dispose();

            Assert.True(disposableOutput.IsDisposed);
        }


        /// <summary>
        ///     Tests that logger factory disposed factory should not throw on second dispose
        /// </summary>
        [Fact]
        public void LoggerFactory_DisposedFactory_ShouldNotThrowOnSecondDispose()
        {
            LoggerFactory factory = new LoggerFactory();

            factory.Dispose();
            factory.Dispose();
        }

        /// <summary>
        ///     Tests that logger factory create logger with empty name should be allowed
        /// </summary>
        [Fact]
        public void LoggerFactory_CreateLoggerWithEmptyName_ShouldBeAllowed()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                ILogger logger = factory.CreateLogger(string.Empty);

                Assert.NotNull(logger);
                Assert.Equal(string.Empty, logger.Name);
            }
        }

        /// <summary>
        ///     Tests that logger factory add multiple same filters should apply all
        /// </summary>
        [Fact]
        public void LoggerFactory_AddMultipleSameFilters_ShouldApplyAll()
        {
            MemoryLogOutput memoryOutput = new MemoryLogOutput();
            using (LoggerFactory factory = new LoggerFactory())
            {
                factory.AddOutput(memoryOutput);
                factory.AddFilter(new LogLevelFilter(LogLevel.Info));
                factory.AddFilter(new LoggerNameFilter(new[] {"TestLogger"}));
                ILogger logger = factory.CreateLogger("TestLogger");

                logger.LogInfo("Message");
                logger.LogDebug("Debug");

                IReadOnlyList<ILogEntry> entries = memoryOutput.GetEntries();
                Assert.Single(entries);
            }
        }

        /// <summary>
        ///     Tests that logger factory change formatter should affect new loggers
        /// </summary>
        [Fact]
        public void LoggerFactory_ChangeFormatter_ShouldAffectNewLoggers()
        {
            using (LoggerFactory factory = new LoggerFactory())
            {
                SimpleLogFormatter formatter1 = new SimpleLogFormatter();
                factory.SetFormatter(formatter1);

                ILogger logger1 = factory.CreateLogger("Logger1");
                Assert.NotNull(logger1);

                CompactLogFormatter formatter2 = new CompactLogFormatter();
                factory.SetFormatter(formatter2);

                ILogger logger2 = factory.CreateLogger("Logger2");

                Assert.NotNull(logger2);
            }
        }

        /// <summary>
        ///     Helper output for testing disposal.
        /// </summary>
        private sealed class DisposableLogOutput : ILogOutput
        {
            /// <summary>
            ///     Gets or sets the value of the is disposed
            /// </summary>
            public bool IsDisposed { get; private set; }

            /// <summary>
            ///     Gets the value of the name
            /// </summary>
            public string Name => "DisposableOutput";

            /// <summary>
            ///     Gets or sets the value of the is enabled
            /// </summary>
            public bool IsEnabled { get; set; } = true;

            /// <summary>
            ///     Writes the entry
            /// </summary>
            /// <param name="entry">The entry</param>
            public void Write(ILogEntry entry)
            {
            }

            /// <summary>
            ///     Flushes this instance
            /// </summary>
            public void Flush()
            {
            }

            /// <summary>
            ///     Disposes this instance
            /// </summary>
            public void Dispose()
            {
                IsDisposed = true;
            }
        }
    }
}