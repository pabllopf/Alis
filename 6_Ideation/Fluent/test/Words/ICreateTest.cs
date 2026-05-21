

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the ICreate interface.
    ///     Tests fluent builder pattern with Create method.
    /// </summary>
    public class ICreateTest
    {
        /// <summary>
        ///     Tests that ICreate can be implemented.
        /// </summary>
        [Fact]
        public void ICreate_CanBeImplemented()
        {
            CreateBuilder builder = new CreateBuilder();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<ICreate<TestBuilder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Create returns builder with value set.
        /// </summary>
        [Fact]
        public void Create_ReturnsBuilderWithValueSet()
        {
            CreateBuilder builder = new CreateBuilder();
            TestBuilder result = builder.Create("test");
            Assert.NotNull(result);
            Assert.Equal("test", result.CreatedValue);
        }

        /// <summary>
        ///     Tests fluent chaining capability.
        /// </summary>
        [Fact]
        public void Create_SupportsFluentChaining()
        {
            CreateBuilder createBuilder = new CreateBuilder();
            TestBuilder result = createBuilder.Create("value");
            Assert.NotNull(result);
            Assert.IsType<TestBuilder>(result);
        }

        /// <summary>
        ///     Tests Create with null value.
        /// </summary>
        [Fact]
        public void Create_CanHandleNullArgument()
        {
            CreateBuilder builder = new CreateBuilder();
            TestBuilder result = builder.Create(null);
            Assert.NotNull(result);
            Assert.Null(result.CreatedValue);
        }

        /// <summary>
        ///     Tests Create with different argument types.
        /// </summary>
        [Fact]
        public void ICreate_WithIntegerArgumentType()
        {
            IntCreateBuilder builder = new IntCreateBuilder();
            IntTestBuilder result = builder.Create(42);
            Assert.Equal(42, result.Value);
        }

        /// <summary>
        ///     Helper builder class.
        /// </summary>
        private class TestBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the created value
            /// </summary>
            public string CreatedValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of ICreate.
        /// </summary>
        private class CreateBuilder : ICreate<TestBuilder, string>
        {
            /// <summary>
            ///     The test builder
            /// </summary>
            private readonly TestBuilder _builder = new TestBuilder();

            /// <summary>
            ///     Creates the obj
            /// </summary>
            /// <param name="obj">The obj</param>
            /// <returns>The builder</returns>
            public TestBuilder Create(string obj)
            {
                _builder.CreatedValue = obj;
                return _builder;
            }
        }

        /// <summary>
        ///     Helper builder with integer.
        /// </summary>
        private class IntTestBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the value
            /// </summary>
            public int Value { get; set; }
        }

        /// <summary>
        ///     Helper implementation with integer.
        /// </summary>
        private class IntCreateBuilder : ICreate<IntTestBuilder, int>
        {
            /// <summary>
            ///     The int test builder
            /// </summary>
            private readonly IntTestBuilder _builder = new IntTestBuilder();

            /// <summary>
            ///     Creates the obj
            /// </summary>
            /// <param name="obj">The obj</param>
            /// <returns>The builder</returns>
            public IntTestBuilder Create(int obj)
            {
                _builder.Value = obj;
                return _builder;
            }
        }
    }
}