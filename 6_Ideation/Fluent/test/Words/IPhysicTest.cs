

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IPhysic interface.
    ///     Tests the Physic method for physics configuration.
    /// </summary>
    public class IPhysicTest
    {
        /// <summary>
        ///     Tests that IPhysic can be implemented.
        /// </summary>
        [Fact]
        public void IPhysic_CanBeImplemented()
        {
            PhysicBuilderImpl builder = new PhysicBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IPhysic<PhysicBuilder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Physic sets engine correctly.
        /// </summary>
        [Fact]
        public void Physic_SetsEngineCorrectly()
        {
            PhysicBuilderImpl builder = new PhysicBuilderImpl();
            PhysicBuilder result = builder.Physic("Box2D");
            Assert.Equal("Box2D", result.PhysicsEngine);
        }

        /// <summary>
        ///     Tests that Physic returns builder.
        /// </summary>
        [Fact]
        public void Physic_ReturnsBuilder()
        {
            PhysicBuilderImpl builder = new PhysicBuilderImpl();
            PhysicBuilder result = builder.Physic("Bullet");
            Assert.NotNull(result);
            Assert.IsType<PhysicBuilder>(result);
        }

        /// <summary>
        ///     Tests Physic with various engines.
        /// </summary>
        [Theory, InlineData("Box2D"), InlineData("Bullet"), InlineData("PhysX"), InlineData("Havok")]
        public void Physic_WithVariousEngines(string engine)
        {
            PhysicBuilderImpl builder = new PhysicBuilderImpl();
            PhysicBuilder result = builder.Physic(engine);
            Assert.Equal(engine, result.PhysicsEngine);
        }

        /// <summary>
        ///     Helper builder class for physics.
        /// </summary>
        private class PhysicBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the physics engine
            /// </summary>
            public string PhysicsEngine { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IPhysic.
        /// </summary>
        private class PhysicBuilderImpl : IPhysic<PhysicBuilder, string>
        {
            /// <summary>
            ///     The physic builder
            /// </summary>
            private readonly PhysicBuilder _builder = new PhysicBuilder();

            /// <summary>
            ///     Physics the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public PhysicBuilder Physic(string value)
            {
                _builder.PhysicsEngine = value;
                return _builder;
            }
        }
    }
}