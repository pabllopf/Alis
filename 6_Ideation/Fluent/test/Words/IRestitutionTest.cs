

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IRestitution interface.
    ///     Tests the Restitution method for bounce coefficient assignment.
    /// </summary>
    public class IRestitutionTest
    {
        /// <summary>
        ///     Tests that IRestitution can be implemented.
        /// </summary>
        [Fact]
        public void IRestitution_CanBeImplemented()
        {
            RestitutionBuilderImpl builder = new RestitutionBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IRestitution<RestitutionBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that Restitution sets value correctly.
        /// </summary>
        [Fact]
        public void Restitution_SetsValueCorrectly()
        {
            RestitutionBuilderImpl builder = new RestitutionBuilderImpl();
            RestitutionBuilder result = builder.Restitution(0.8f);
            Assert.Equal(0.8f, result.RestitutionValue);
        }

        /// <summary>
        ///     Tests that Restitution returns builder.
        /// </summary>
        [Fact]
        public void Restitution_ReturnsBuilder()
        {
            RestitutionBuilderImpl builder = new RestitutionBuilderImpl();
            RestitutionBuilder result = builder.Restitution(0.6f);
            Assert.NotNull(result);
            Assert.IsType<RestitutionBuilder>(result);
        }

        /// <summary>
        ///     Tests Restitution with valid bounce values.
        /// </summary>
        [Theory, InlineData(0f), InlineData(0.25f), InlineData(0.5f), InlineData(0.75f), InlineData(1f)]
        public void Restitution_WithValidBounceValues(float restitution)
        {
            RestitutionBuilderImpl builder = new RestitutionBuilderImpl();
            RestitutionBuilder result = builder.Restitution(restitution);
            Assert.Equal(restitution, result.RestitutionValue);
        }

        /// <summary>
        ///     Helper builder class for restitution.
        /// </summary>
        private class RestitutionBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the restitution value
            /// </summary>
            public float RestitutionValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IRestitution.
        /// </summary>
        private class RestitutionBuilderImpl : IRestitution<RestitutionBuilder, float>
        {
            /// <summary>
            ///     The restitution builder
            /// </summary>
            private readonly RestitutionBuilder _builder = new RestitutionBuilder();

            /// <summary>
            ///     Restitutions the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public RestitutionBuilder Restitution(float value)
            {
                _builder.RestitutionValue = value;
                return _builder;
            }
        }
    }
}