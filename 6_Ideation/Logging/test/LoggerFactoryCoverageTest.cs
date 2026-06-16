using System;
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

        [Fact]
        public void ShouldSwallowExceptionDuringFlush()
        {
            ThrowingOutput throwOnFlush = new ThrowingOutput(throwOnFlush: true);
            LoggerFactory factory = new LoggerFactory();
            factory.AddOutput(throwOnFlush);

            Exception ex = Record.Exception(() => factory.Flush());

            Assert.Null(ex);
        }

        [Fact]
        public void ShouldReturnEarlyFromFlushWhenDisposed()
        {
            LoggerFactory factory = new LoggerFactory();
            factory.Dispose();

            Exception ex = Record.Exception(() => factory.Flush());

            Assert.Null(ex);
        }

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

        [Fact]
        public void ShouldSetMinimumLevelAndReturnFactory()
        {
            LoggerFactory factory = new LoggerFactory();

            LoggerFactory result = factory.SetMinimumLevel(LogLevel.Error);

            Assert.Same(factory, result);
        }

        [Fact]
        public void ShouldSetFormatterAndReturnFactory()
        {
            LoggerFactory factory = new LoggerFactory();
            CompactLogFormatter formatter = new CompactLogFormatter();

            LoggerFactory result = factory.SetFormatter(formatter);

            Assert.Same(factory, result);
        }

        [Fact]
        public void ShouldSetFormatterNullAndThrow()
        {
            LoggerFactory factory = new LoggerFactory();

            Assert.Throws<ArgumentNullException>(() => factory.SetFormatter(null));
        }

        [Fact]
        public void ShouldAddOutputNullAndThrow()
        {
            LoggerFactory factory = new LoggerFactory();

            Assert.Throws<ArgumentNullException>(() => factory.AddOutput(null));
        }

        [Fact]
        public void ShouldAddFilterNullAndThrow()
        {
            LoggerFactory factory = new LoggerFactory();

            Assert.Throws<ArgumentNullException>(() => factory.AddFilter(null));
        }

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
        ///     Helper output that throws on Dispose or Flush.
        /// </summary>
        private sealed class ThrowingOutput : ILogOutput
        {
            private readonly bool _throwOnDispose;
            private readonly bool _throwOnFlush;

            public bool DisposeCalled { get; private set; }

            public ThrowingOutput(bool throwOnDispose = false, bool throwOnFlush = false)
            {
                _throwOnDispose = throwOnDispose;
                _throwOnFlush = throwOnFlush;
            }

            public string Name => "ThrowingOutput";
            public bool IsEnabled { get; set; } = true;

            public void Write(ILogEntry entry)
            {
            }

            public void Flush()
            {
                if (_throwOnFlush)
                {
                    throw new InvalidOperationException("Flush failed");
                }
            }

            public void Dispose()
            {
                DisposeCalled = true;
                if (_throwOnDispose)
                {
                    throw new InvalidOperationException("Dispose failed");
                }
            }
        }
    }
}
