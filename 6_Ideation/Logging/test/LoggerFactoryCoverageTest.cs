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
    ///     Coverage-driven tests for LoggerFactory targeting uncovered code paths.
    /// </summary>
    public class LoggerFactoryCoverageTest
    {
        /// <summary>
        /// Tests that should swallow exception during dispose
        /// </summary>
        [Fact]
        public void ShouldSwallowExceptionDuringDispose()
        {
            ThrowingOutput throwOnDispose = new ThrowingOutput(throwOnDispose: true);
            LoggerFactory factory = new LoggerFactory();
            factory.AddOutput(throwOnDispose);

            Exception ex = Record.Exception(() => factory.Dispose());

            Assert.Null(ex);
            Assert.True(throwOnDispose.DisposeCalled);
        }

        /// <summary>
        /// Tests that should swallow exception during flush
        /// </summary>
        [Fact]
        public void ShouldSwallowExceptionDuringFlush()
        {
            ThrowingOutput throwOnFlush = new ThrowingOutput(throwOnFlush: true);
            LoggerFactory factory = new LoggerFactory();
            factory.AddOutput(throwOnFlush);

            Exception ex = Record.Exception(() => factory.Flush());

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that should return early from flush when disposed
        /// </summary>
        [Fact]
        public void ShouldReturnEarlyFromFlushWhenDisposed()
        {
            LoggerFactory factory = new LoggerFactory();
            factory.Dispose();

            Exception ex = Record.Exception(() => factory.Flush());

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that should dispose multiple outputs swallowing exceptions
        /// </summary>
        [Fact]
        public void ShouldDisposeMultipleOutputsSwallowingExceptions()
        {
            ThrowingOutput throwOnDispose = new ThrowingOutput(throwOnDispose: true);
            MemoryLogOutput memory = new MemoryLogOutput();
            LoggerFactory factory = new LoggerFactory();
            factory.AddOutput(throwOnDispose);
            factory.AddOutput(memory);

            Exception ex = Record.Exception(() => factory.Dispose());

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that should set minimum level and return factory
        /// </summary>
        [Fact]
        public void ShouldSetMinimumLevelAndReturnFactory()
        {
            LoggerFactory factory = new LoggerFactory();

            LoggerFactory result = factory.SetMinimumLevel(LogLevel.Error);

            Assert.Same(factory, result);
        }

        /// <summary>
        /// Tests that should set formatter and return factory
        /// </summary>
        [Fact]
        public void ShouldSetFormatterAndReturnFactory()
        {
            LoggerFactory factory = new LoggerFactory();
            CompactLogFormatter formatter = new CompactLogFormatter();

            LoggerFactory result = factory.SetFormatter(formatter);

            Assert.Same(factory, result);
        }

        /// <summary>
        /// Tests that should set formatter null and throw
        /// </summary>
        [Fact]
        public void ShouldSetFormatterNullAndThrow()
        {
            LoggerFactory factory = new LoggerFactory();

            Assert.Throws<ArgumentNullException>(() => factory.SetFormatter(null));
        }

        /// <summary>
        /// Tests that should add output null and throw
        /// </summary>
        [Fact]
        public void ShouldAddOutputNullAndThrow()
        {
            LoggerFactory factory = new LoggerFactory();

            Assert.Throws<ArgumentNullException>(() => factory.AddOutput(null));
        }

        /// <summary>
        /// Tests that should add filter null and throw
        /// </summary>
        [Fact]
        public void ShouldAddFilterNullAndThrow()
        {
            LoggerFactory factory = new LoggerFactory();

            Assert.Throws<ArgumentNullException>(() => factory.AddFilter(null));
        }

        /// <summary>
        /// Tests that should flush all outputs with throwing one
        /// </summary>
        [Fact]
        public void ShouldFlushAllOutputsWithThrowingOne()
        {
            ThrowingOutput throwOnFlush = new ThrowingOutput(throwOnFlush: true);
            MemoryLogOutput memory = new MemoryLogOutput();
            LoggerFactory factory = new LoggerFactory();
            factory.AddOutput(throwOnFlush);
            factory.AddOutput(memory);
            ILogger logger = factory.CreateLogger("Test");
            logger.LogInfo("msg");

            Exception ex = Record.Exception(() => factory.Flush());

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that should swallow exception during write in core logger
        /// </summary>
        [Fact]
        public void ShouldSwallowExceptionDuringWriteInCoreLogger()
        {
            ThrowingOutput throwOnWrite = new ThrowingOutput(throwOnWrite: true);
            MemoryLogOutput memory = new MemoryLogOutput();
            LoggerFactory factory = new LoggerFactory();
            factory.AddOutput(throwOnWrite);
            factory.AddOutput(memory);
            ILogger logger = factory.CreateLogger("Test");

            Exception ex = Record.Exception(() => logger.LogInfo("msg"));

            Assert.Null(ex);
            Assert.Single(memory.GetEntries());
        }

        /// <summary>
        /// Tests that should swallow exception from throwing filter
        /// </summary>
        [Fact]
        public void ShouldSwallowExceptionFromThrowingFilter()
        {
            MemoryLogOutput memory = new MemoryLogOutput();
            LoggerFactory factory = new LoggerFactory();
            factory.AddOutput(memory);
            factory.AddFilter(new ThrowingFilter());
            ILogger logger = factory.CreateLogger("Test");

            Exception ex = Record.Exception(() => logger.LogInfo("msg"));

            Assert.Null(ex);
            Assert.Empty(memory.GetEntries());
        }

        /// <summary>
        ///     Helper output that throws on Dispose, Flush, or Write.
        /// </summary>
        private sealed class ThrowingOutput : ILogOutput
        {
            /// <summary>
            /// The throw on dispose
            /// </summary>
            private readonly bool _throwOnDispose;
            /// <summary>
            /// The throw on flush
            /// </summary>
            private readonly bool _throwOnFlush;
            /// <summary>
            /// The throw on write
            /// </summary>
            private readonly bool _throwOnWrite;

            /// <summary>
            /// Gets or sets the value of the dispose called
            /// </summary>
            public bool DisposeCalled { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="ThrowingOutput"/> class
            /// </summary>
            /// <param name="throwOnDispose">The throw on dispose</param>
            /// <param name="throwOnFlush">The throw on flush</param>
            /// <param name="throwOnWrite">The throw on write</param>
            public ThrowingOutput(bool throwOnDispose = false, bool throwOnFlush = false, bool throwOnWrite = false)
            {
                _throwOnDispose = throwOnDispose;
                _throwOnFlush = throwOnFlush;
                _throwOnWrite = throwOnWrite;
            }

            /// <summary>
            /// Gets the value of the name
            /// </summary>
            public string Name => "ThrowingOutput";
            /// <summary>
            /// Gets or sets the value of the is enabled
            /// </summary>
            public bool IsEnabled { get; set; } = true;

            /// <summary>
            /// Writes the entry
            /// </summary>
            /// <param name="entry">The entry</param>
            /// <exception cref="InvalidOperationException">Write failed</exception>
            public void Write(ILogEntry entry)
            {
                if (_throwOnWrite)
                {
                    throw new InvalidOperationException("Write failed");
                }
            }

            /// <summary>
            /// Flushes this instance
            /// </summary>
            /// <exception cref="InvalidOperationException">Flush failed</exception>
            public void Flush()
            {
                if (_throwOnFlush)
                {
                    throw new InvalidOperationException("Flush failed");
                }
            }

            /// <summary>
            /// Disposes this instance
            /// </summary>
            /// <exception cref="InvalidOperationException">Dispose failed</exception>
            public void Dispose()
            {
                DisposeCalled = true;
                if (_throwOnDispose)
                {
                    throw new InvalidOperationException("Dispose failed");
                }
            }
        }

        /// <summary>
        ///     Helper filter that throws on ShouldLog.
        /// </summary>
        private sealed class ThrowingFilter : ILogFilter
        {
            /// <summary>
            /// Gets the value of the name
            /// </summary>
            public string Name => "ThrowingFilter";

            /// <summary>
            /// Shoulds the log using the specified entry
            /// </summary>
            /// <param name="entry">The entry</param>
            /// <exception cref="InvalidOperationException">Filter failed</exception>
            /// <returns>The bool</returns>
            public bool ShouldLog(ILogEntry entry)
            {
                throw new InvalidOperationException("Filter failed");
            }
        }
    }
}
