

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IAdd interface.
    ///     Ensures the Add method can be implemented and returns the correct builder type.
    /// </summary>
    public class IAddTest
    {
        /// <summary>
        ///     Ensures Add returns a builder with the correct value.
        /// </summary>
        [Fact]
        public void Add_ReturnsBuilderWithCorrectValue()
        {
            DummyAdd add = new DummyAdd();
            DummyBuilder builder = add.Add(123);
            Assert.NotNull(builder);
            Assert.Equal(123, builder.Value);
        }

        /// <summary>
        ///     The dummy builder class
        /// </summary>
        private class DummyBuilder
        {
            /// <summary>
            ///     The value
            /// </summary>
            public int Value;
        }

        /// <summary>
        ///     The dummy add class
        /// </summary>
        /// <seealso cref="IAdd{DummyBuilder,}" />
        private class DummyAdd : IAdd<DummyBuilder, int>
        {
            /// <summary>
            ///     Adds the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The dummy builder</returns>
            public DummyBuilder Add(int value) => new DummyBuilder {Value = value};
        }
    }
}