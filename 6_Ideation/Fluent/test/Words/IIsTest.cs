

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IIs interface.
    ///     Tests the Is method for type checking and assertion.
    /// </summary>
    public class IIsTest
    {
        /// <summary>
        ///     Tests that IIs can be implemented.
        /// </summary>
        [Fact]
        public void IIs_CanBeImplemented()
        {
            IsBuilder builder = new IsBuilder();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IIs<Builder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Is returns builder.
        /// </summary>
        [Fact]
        public void Is_ReturnsBuilder()
        {
            IsBuilder builder = new IsBuilder();
            Builder result = builder.Is<object>("value");
            Assert.NotNull(result);
            Assert.IsType<Builder>(result);
        }

        /// <summary>
        ///     Tests that Is method preserves value.
        /// </summary>
        [Fact]
        public void Is_PreservesValue()
        {
            IsBuilder builder = new IsBuilder();
            Builder result = builder.Is<object>("test");
            Assert.Equal("test", result.IsValue);
        }

        /// <summary>
        ///     Tests Is with different type parameters.
        /// </summary>
        [Fact]
        public void Is_WithDifferentTypeParameters()
        {
            IsBuilder builder = new IsBuilder();
            Builder result1 = builder.Is<int>("first");
            Builder result2 = builder.Is<string>("second");
            Assert.Equal("second", result2.IsValue);
        }

        /// <summary>
        ///     Tests Is method chaining.
        /// </summary>
        [Fact]
        public void Is_SupportsChaining()
        {
            IsBuilder builder = new IsBuilder();
            Builder result = builder.Is<int>("value");
            Assert.NotNull(result);
            Assert.IsType<Builder>(result);
        }

        /// <summary>
        ///     Helper builder class.
        /// </summary>
        private class Builder
        {
            /// <summary>
            ///     Gets or sets the value of the is value
            /// </summary>
            public string IsValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IIs.
        /// </summary>
        private class IsBuilder : IIs<Builder, string>
        {
            /// <summary>
            ///     The builder
            /// </summary>
            private readonly Builder _builder = new Builder();

            /// <summary>
            ///     Ises the value
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public Builder Is<T>(string value)
            {
                _builder.IsValue = value;
                return _builder;
            }
        }
    }
}