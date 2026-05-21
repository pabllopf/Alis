

using System;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Outputs;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Abstractions
{
    /// <summary>
    ///     Comprehensive unit tests for the ILogOutput interface contract.
    ///     Validates that implementations properly support all interface methods.
    /// </summary>
    public class ILogOutputTest
    {
        /// <summary>
        ///     Tests that i log output implementation can be created
        /// </summary>
        [Fact]
        public void ILogOutput_ImplementationCanBeCreated()
        {
            ILogOutput output = new MemoryLogOutput();

            Assert.NotNull(output);
        }

        /// <summary>
        ///     Tests that i log output has name property
        /// </summary>
        [Fact]
        public void ILogOutput_HasNameProperty()
        {
            ILogOutput output = new MemoryLogOutput();

            Assert.NotNull(output.Name);
            Assert.NotEmpty(output.Name);
        }

        /// <summary>
        ///     Tests that i log output has is enabled property
        /// </summary>
        [Fact]
        public void ILogOutput_HasIsEnabledProperty()
        {
            ILogOutput output = new MemoryLogOutput();

            Assert.True(output.IsEnabled);
            output.IsEnabled = false;
            Assert.False(output.IsEnabled);
        }

        /// <summary>
        ///     Tests that i log output write method can be called
        /// </summary>
        [Fact]
        public void ILogOutput_WriteMethod_CanBeCalled()
        {
            ILogOutput output = new MemoryLogOutput();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            output.Write(entry);
        }

        /// <summary>
        ///     Tests that i log output flush method can be called
        /// </summary>
        [Fact]
        public void ILogOutput_FlushMethod_CanBeCalled()
        {
            ILogOutput output = new MemoryLogOutput();

            output.Flush();
        }

        /// <summary>
        ///     Tests that i log output dispose method can be called
        /// </summary>
        [Fact]
        public void ILogOutput_DisposeMethod_CanBeCalled()
        {
            ILogOutput output = new MemoryLogOutput();

            output.Dispose();
        }

        /// <summary>
        ///     Tests that i log output multiple implementations should work
        /// </summary>
        [Fact]
        public void ILogOutput_MultipleImplementations_ShouldWork()
        {
            ILogOutput output1 = new MemoryLogOutput();
            ILogOutput output2 = new ConsoleLogOutput();

            Assert.NotNull(output1);
            Assert.NotNull(output2);
            Assert.NotEqual(output1.Name, output2.Name);
        }

        /// <summary>
        ///     Tests that i log output can be disposable interface
        /// </summary>
        [Fact]
        public void ILogOutput_CanBeDisposableInterface()
        {
            ILogOutput output = new MemoryLogOutput();

            Assert.IsAssignableFrom<IDisposable>(output);
            output.Dispose();
        }
    }
}