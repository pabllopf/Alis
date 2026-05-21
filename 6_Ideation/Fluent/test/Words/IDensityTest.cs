

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IDensity interface.
    ///     Tests the Density method for material density assignment.
    /// </summary>
    public class IDensityTest
    {
        /// <summary>
        ///     Tests that IDensity can be implemented.
        /// </summary>
        [Fact]
        public void IDensity_CanBeImplemented()
        {
            DensityBuilderImpl builder = new DensityBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IDensity<DensityBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that Density sets value correctly.
        /// </summary>
        [Fact]
        public void Density_SetsValueCorrectly()
        {
            DensityBuilderImpl builder = new DensityBuilderImpl();
            DensityBuilder result = builder.Density(1000f);
            Assert.Equal(1000f, result.DensityValue);
        }

        /// <summary>
        ///     Tests that Density returns builder.
        /// </summary>
        [Fact]
        public void Density_ReturnsBuilder()
        {
            DensityBuilderImpl builder = new DensityBuilderImpl();
            DensityBuilder result = builder.Density(500f);
            Assert.NotNull(result);
            Assert.IsType<DensityBuilder>(result);
        }

        /// <summary>
        ///     Tests Density with various material values.
        /// </summary>
        [Theory, InlineData(100f), InlineData(500f), InlineData(1000f), InlineData(2000f)]
        public void Density_WithVariousMaterials(float density)
        {
            DensityBuilderImpl builder = new DensityBuilderImpl();
            DensityBuilder result = builder.Density(density);
            Assert.Equal(density, result.DensityValue);
        }

        /// <summary>
        ///     Helper builder class for density.
        /// </summary>
        private class DensityBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the density value
            /// </summary>
            public float DensityValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IDensity.
        /// </summary>
        private class DensityBuilderImpl : IDensity<DensityBuilder, float>
        {
            /// <summary>
            ///     The density builder
            /// </summary>
            private readonly DensityBuilder _builder = new DensityBuilder();

            /// <summary>
            ///     Densities the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public DensityBuilder Density(float value)
            {
                _builder.DensityValue = value;
                return _builder;
            }
        }
    }
}