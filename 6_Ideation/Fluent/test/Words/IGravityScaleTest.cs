

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IGravityScale interface.
    ///     Tests the GravityScale method for gravity multiplier assignment.
    /// </summary>
    public class IGravityScaleTest
    {
        /// <summary>
        ///     Tests that IGravityScale can be implemented.
        /// </summary>
        [Fact]
        public void IGravityScale_CanBeImplemented()
        {
            GravityScaleBuilderImpl builder = new GravityScaleBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IGravityScale<GravityScaleBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that GravityScale sets value correctly.
        /// </summary>
        [Fact]
        public void GravityScale_SetsValueCorrectly()
        {
            GravityScaleBuilderImpl builder = new GravityScaleBuilderImpl();
            GravityScaleBuilder result = builder.GravityScale(2f);
            Assert.Equal(2f, result.GravityScaleValue);
        }

        /// <summary>
        ///     Tests that GravityScale returns builder.
        /// </summary>
        [Fact]
        public void GravityScale_ReturnsBuilder()
        {
            GravityScaleBuilderImpl builder = new GravityScaleBuilderImpl();
            GravityScaleBuilder result = builder.GravityScale(0.5f);
            Assert.NotNull(result);
            Assert.IsType<GravityScaleBuilder>(result);
        }

        /// <summary>
        ///     Tests GravityScale with various multipliers.
        /// </summary>
        [Theory, InlineData(0f), InlineData(0.5f), InlineData(1f), InlineData(2f), InlineData(5f)]
        public void GravityScale_WithVariousMultipliers(float scale)
        {
            GravityScaleBuilderImpl builder = new GravityScaleBuilderImpl();
            GravityScaleBuilder result = builder.GravityScale(scale);
            Assert.Equal(scale, result.GravityScaleValue);
        }

        /// <summary>
        ///     Helper builder class for gravity scale.
        /// </summary>
        private class GravityScaleBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the gravity scale value
            /// </summary>
            public float GravityScaleValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IGravityScale.
        /// </summary>
        private class GravityScaleBuilderImpl : IGravityScale<GravityScaleBuilder, float>
        {
            /// <summary>
            ///     The gravity scale builder
            /// </summary>
            private readonly GravityScaleBuilder _builder = new GravityScaleBuilder();

            /// <summary>
            ///     Gravities the scale using the specified value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public GravityScaleBuilder GravityScale(float value)
            {
                _builder.GravityScaleValue = value;
                return _builder;
            }
        }
    }
}