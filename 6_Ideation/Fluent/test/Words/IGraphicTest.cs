

using Alis.Core.Aspect.Fluent.Words;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Words
{
    /// <summary>
    ///     Unit tests for the IGraphic interface.
    ///     Tests the Graphic method for graphics configuration.
    /// </summary>
    public class IGraphicTest
    {
        /// <summary>
        ///     Tests that IGraphic can be implemented.
        /// </summary>
        [Fact]
        public void IGraphic_CanBeImplemented()
        {
            GraphicBuilderImpl builder = new GraphicBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IGraphic<GraphicBuilder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Graphic sets type correctly.
        /// </summary>
        [Fact]
        public void Graphic_SetsTypeCorrectly()
        {
            GraphicBuilderImpl builder = new GraphicBuilderImpl();
            GraphicBuilder result = builder.Graphic("Sprite");
            Assert.Equal("Sprite", result.GraphicType);
        }

        /// <summary>
        ///     Tests that Graphic returns builder.
        /// </summary>
        [Fact]
        public void Graphic_ReturnsBuilder()
        {
            GraphicBuilderImpl builder = new GraphicBuilderImpl();
            GraphicBuilder result = builder.Graphic("Mesh");
            Assert.NotNull(result);
            Assert.IsType<GraphicBuilder>(result);
        }

        /// <summary>
        ///     Tests Graphic with various types.
        /// </summary>
        [Theory, InlineData("Sprite"), InlineData("Mesh"), InlineData("Particle"), InlineData("Trail")]
        public void Graphic_WithVariousTypes(string type)
        {
            GraphicBuilderImpl builder = new GraphicBuilderImpl();
            GraphicBuilder result = builder.Graphic(type);
            Assert.Equal(type, result.GraphicType);
        }

        /// <summary>
        ///     Helper builder class for graphics.
        /// </summary>
        private class GraphicBuilder
        {
            /// <summary>
            ///     Gets or sets the value of the graphic type
            /// </summary>
            public string GraphicType { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IGraphic.
        /// </summary>
        private class GraphicBuilderImpl : IGraphic<GraphicBuilder, string>
        {
            /// <summary>
            ///     The graphic builder
            /// </summary>
            private readonly GraphicBuilder _builder = new GraphicBuilder();

            /// <summary>
            ///     Graphics the value
            /// </summary>
            /// <param name="value">The value</param>
            /// <returns>The builder</returns>
            public GraphicBuilder Graphic(string value)
            {
                _builder.GraphicType = value;
                return _builder;
            }
        }
    }
}