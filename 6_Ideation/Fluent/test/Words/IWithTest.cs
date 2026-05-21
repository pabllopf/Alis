

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IWith interface.
    ///     Tests the With method for fluent builder pattern.
    /// </summary>
    public class IWithTest
    {
        /// <summary>
        ///     Tests that IWith can be implemented.
        /// </summary>
        [Fact]
        public void IWith_CanBeImplemented()
        {
            WithBuilder builder = new WithBuilder();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IWith<Builder, string>>(builder);
        }

        /// <summary>
        ///     Tests that With returns builder.
        /// </summary>
        [Fact]
        public void With_ReturnsBuilder()
        {
            WithBuilder builder = new WithBuilder();
            Builder result = builder.With("value");
            Assert.NotNull(result);
            Assert.IsType<Builder>(result);
        }

        /// <summary>
        ///     Tests that With sets value correctly.
        /// </summary>
        [Fact]
        public void With_SetsValueCorrectly()
        {
            WithBuilder builder = new WithBuilder();
            Builder result = builder.With("test");
            Assert.Equal("test", result.WithValue);
        }

        /// <summary>
        ///     Tests method chaining support.
        /// </summary>
        [Fact]
        public void With_SupportsMethodChaining()
        {
            WithBuilder withBuilder = new WithBuilder();
            Builder result1 = withBuilder.With("first");
            Assert.Equal("first", result1.WithValue);
        }

        /// <summary>
        ///     Tests IWith with integer argument.
        /// </summary>
        [Fact]
        public void IWith_WithIntegerArgumentType()
        {
            IntWithBuilder builder = new IntWithBuilder();
            IntBuilder result = builder.With(100);
            Assert.Equal(100, result.Value);
        }

        /// <summary>
        ///     Helper builder class.
        /// </summary>
        private class Builder
        {
            /// <summary>
            ///     Gets or sets the value of the with value
            /// </summary>
            public string WithValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IWith.
        /// </summary>
        private class WithBuilder : IWith<Builder, string>
        {
            /// <summary>
            ///     The builder
            /// </summary>
            private readonly Builder _builder = new Builder();

            /// <summary>
            ///     Adds the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public Builder With(string value)
            {
                _builder.WithValue = value;
                return _builder;
            }
        }

        /// <summary>
        ///     Helper builder with integer.
        /// </summary>
        private class IntBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the value
            /// </summary>
            public int Value { get; set; }
        }

        /// <summary>
        ///     Helper implementation with integer.
        /// </summary>
        private class IntWithBuilder : IWith<IntBuilder, int>
        {
            /// <summary>
            ///     The int builder
            /// </summary>
            private readonly IntBuilder _builder = new IntBuilder();

            /// <summary>
            ///     Adds the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public IntBuilder With(int value)
            {
                _builder.Value = value;
                return _builder;
            }
        }
    }
}