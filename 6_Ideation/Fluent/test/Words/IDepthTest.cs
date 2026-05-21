

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IDepth interface.
    ///     Tests the Depth method for rendering depth/z-order assignment.
    /// </summary>
    public class IDepthTest
    {
        /// <summary>
        ///     Tests that IDepth can be implemented.
        /// </summary>
        [Fact]
        public void IDepth_CanBeImplemented()
        {
            DepthBuilderImpl builder = new DepthBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IDepth<DepthBuilder, int>>(builder);
        }

        /// <summary>
        ///     Tests that Depth sets value correctly.
        /// </summary>
        [Fact]
        public void Depth_SetsValueCorrectly()
        {
            DepthBuilderImpl builder = new DepthBuilderImpl();
            DepthBuilder result = builder.Depth(10);
            Assert.Equal(10, result.DepthValue);
        }

        /// <summary>
        ///     Tests that Depth returns builder.
        /// </summary>
        [Fact]
        public void Depth_ReturnsBuilder()
        {
            DepthBuilderImpl builder = new DepthBuilderImpl();
            DepthBuilder result = builder.Depth(5);
            Assert.NotNull(result);
            Assert.IsType<DepthBuilder>(result);
        }

        /// <summary>
        ///     Tests Depth with various values.
        /// </summary>
        [Theory, InlineData(0), InlineData(1), InlineData(100), InlineData(-10)]
        public void Depth_WithVariousValues(int depth)
        {
            DepthBuilderImpl builder = new DepthBuilderImpl();
            DepthBuilder result = builder.Depth(depth);
            Assert.Equal(depth, result.DepthValue);
        }

        /// <summary>
        ///     Helper builder class for depth.
        /// </summary>
        private class DepthBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the depth value
            /// </summary>
            public int DepthValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IDepth.
        /// </summary>
        private class DepthBuilderImpl : IDepth<DepthBuilder, int>
        {
            /// <summary>
            ///     The depth builder
            /// </summary>
            private readonly DepthBuilder _builder = new DepthBuilder();

            /// <summary>
            ///     Depths the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public DepthBuilder Depth(int value)
            {
                _builder.DepthValue = value;
                return _builder;
            }
        }
    }
}