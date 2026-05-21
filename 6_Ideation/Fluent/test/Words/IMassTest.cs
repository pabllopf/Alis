

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IMass interface.
    ///     Tests the Mass method for object mass assignment.
    /// </summary>
    public class IMassTest
    {
        /// <summary>
        ///     Tests that IMass can be implemented.
        /// </summary>
        [Fact]
        public void IMass_CanBeImplemented()
        {
            MassBuilderImpl builder = new MassBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IMass<MassBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that Mass sets value correctly.
        /// </summary>
        [Fact]
        public void Mass_SetsValueCorrectly()
        {
            MassBuilderImpl builder = new MassBuilderImpl();
            MassBuilder result = builder.Mass(2.5f);
            Assert.Equal(2.5f, result.MassValue);
        }

        /// <summary>
        ///     Tests that Mass returns builder.
        /// </summary>
        [Fact]
        public void Mass_ReturnsBuilder()
        {
            MassBuilderImpl builder = new MassBuilderImpl();
            MassBuilder result = builder.Mass(1f);
            Assert.NotNull(result);
            Assert.IsType<MassBuilder>(result);
        }

        /// <summary>
        ///     Tests Mass with typical physics values.
        /// </summary>
        [Theory, InlineData(0.1f), InlineData(1f), InlineData(5f), InlineData(10f), InlineData(100f)]
        public void Mass_WithTypicalPhysicsValues(float mass)
        {
            MassBuilderImpl builder = new MassBuilderImpl();
            MassBuilder result = builder.Mass(mass);
            Assert.Equal(mass, result.MassValue);
        }

        /// <summary>
        ///     Helper builder class for mass.
        /// </summary>
        private class MassBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the mass value
            /// </summary>
            public float MassValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IMass.
        /// </summary>
        private class MassBuilderImpl : IMass<MassBuilder, float>
        {
            /// <summary>
            ///     The mass builder
            /// </summary>
            private readonly MassBuilder _builder = new MassBuilder();

            /// <summary>
            ///     Masses the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public MassBuilder Mass(float value)
            {
                _builder.MassValue = value;
                return _builder;
            }
        }
    }
}