

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IFriction interface.
    ///     Tests the Friction method for friction coefficient assignment.
    /// </summary>
    public class IFrictionTest
    {
        /// <summary>
        ///     Tests that IFriction can be implemented.
        /// </summary>
        [Fact]
        public void IFriction_CanBeImplemented()
        {
            FrictionBuilderImpl builder = new FrictionBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IFriction<FrictionBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that Friction sets value correctly.
        /// </summary>
        [Fact]
        public void Friction_SetsValueCorrectly()
        {
            FrictionBuilderImpl builder = new FrictionBuilderImpl();
            FrictionBuilder result = builder.Friction(0.5f);
            Assert.Equal(0.5f, result.FrictionValue);
        }

        /// <summary>
        ///     Tests that Friction returns builder.
        /// </summary>
        [Fact]
        public void Friction_ReturnsBuilder()
        {
            FrictionBuilderImpl builder = new FrictionBuilderImpl();
            FrictionBuilder result = builder.Friction(0.3f);
            Assert.NotNull(result);
            Assert.IsType<FrictionBuilder>(result);
        }

        /// <summary>
        ///     Tests Friction with typical physics values.
        /// </summary>
        [Theory, InlineData(0f), InlineData(0.3f), InlineData(0.5f), InlineData(1f)]
        public void Friction_WithTypicalPhysicsValues(float friction)
        {
            FrictionBuilderImpl builder = new FrictionBuilderImpl();
            FrictionBuilder result = builder.Friction(friction);
            Assert.Equal(friction, result.FrictionValue);
        }

        /// <summary>
        ///     Helper builder class for friction.
        /// </summary>
        private class FrictionBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the friction value
            /// </summary>
            public float FrictionValue { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IFriction.
        /// </summary>
        private class FrictionBuilderImpl : IFriction<FrictionBuilder, float>
        {
            /// <summary>
            ///     The friction builder
            /// </summary>
            private readonly FrictionBuilder _builder = new FrictionBuilder();

            /// <summary>
            ///     Frictions the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public FrictionBuilder Friction(float value)
            {
                _builder.FrictionValue = value;
                return _builder;
            }
        }
    }
}