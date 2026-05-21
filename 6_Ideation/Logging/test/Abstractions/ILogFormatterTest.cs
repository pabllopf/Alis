

using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Core;
using Alis.Core.Aspect.Logging.Formatters;
using Xunit;

namespace Alis.Core.Aspect.Logging.Test.Abstractions
{
    /// <summary>
    ///     Comprehensive unit tests for the ILogFormatter interface contract.
    ///     Validates that implementations properly support all interface methods.
    /// </summary>
    public class ILogFormatterTest
    {
        /// <summary>
        ///     Tests that i log formatter implementation can be created
        /// </summary>
        [Fact]
        public void ILogFormatter_ImplementationCanBeCreated()
        {
            ILogFormatter formatter = new SimpleLogFormatter();

            Assert.NotNull(formatter);
        }

        /// <summary>
        ///     Tests that i log formatter has name property
        /// </summary>
        [Fact]
        public void ILogFormatter_HasNameProperty()
        {
            ILogFormatter formatter = new SimpleLogFormatter();

            Assert.NotNull(formatter.Name);
            Assert.NotEmpty(formatter.Name);
        }

        /// <summary>
        ///     Tests that i log formatter format method can be called
        /// </summary>
        [Fact]
        public void ILogFormatter_FormatMethod_CanBeCalled()
        {
            ILogFormatter formatter = new SimpleLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            string result = formatter.Format(entry);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        ///     Tests that i log formatter format returns string
        /// </summary>
        [Fact]
        public void ILogFormatter_FormatReturnsString()
        {
            ILogFormatter formatter = new SimpleLogFormatter();
            LogEntry entry = new LogEntry(LogLevel.Info, "Test", "Logger");

            string result = formatter.Format(entry);

            Assert.IsType<string>(result);
        }

        /// <summary>
        ///     Tests that i log formatter multiple implementations should work
        /// </summary>
        [Fact]
        public void ILogFormatter_MultipleImplementations_ShouldWork()
        {
            ILogFormatter formatter1 = new SimpleLogFormatter();
            ILogFormatter formatter2 = new CompactLogFormatter();
            ILogFormatter formatter3 = new JsonLogFormatter();

            Assert.NotNull(formatter1);
            Assert.NotNull(formatter2);
            Assert.NotNull(formatter3);
            Assert.NotEqual(formatter1.Name, formatter2.Name);
            Assert.NotEqual(formatter2.Name, formatter3.Name);
        }

        /// <summary>
        ///     Tests that i log formatter different implementations produce different output
        /// </summary>
        [Fact]
        public void ILogFormatter_DifferentImplementations_ProduceDifferentOutput()
        {
            ILogFormatter[] formatters = new ILogFormatter[]
            {
                new SimpleLogFormatter(),
                new CompactLogFormatter(),
                new JsonLogFormatter()
            };
            LogEntry entry = new LogEntry(LogLevel.Info, "Test message", "Logger");

            string[] results = new string[3];
            for (int i = 0; i < formatters.Length; i++)
            {
                results[i] = formatters[i].Format(entry);
            }

            Assert.NotEqual(results[0], results[1]);
            Assert.NotEqual(results[1], results[2]);
            Assert.NotEqual(results[0], results[2]);
        }
    }
}