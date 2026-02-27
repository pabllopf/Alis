// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: IGraphicTest.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web: https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

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
        ///     Helper builder class for graphics.
        /// </summary>
        private class GraphicBuilder
        {
            public string GraphicType { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IGraphic.
        /// </summary>
        private class GraphicBuilderImpl : IGraphic<GraphicBuilder, string>
        {
            private readonly GraphicBuilder _builder = new GraphicBuilder();

            public GraphicBuilder Graphic(string value)
            {
                _builder.GraphicType = value;
                return _builder;
            }
        }

        /// <summary>
        ///     Tests that IGraphic can be implemented.
        /// </summary>
        [Fact]
        public void IGraphic_CanBeImplemented()
        {
            var builder = new GraphicBuilderImpl();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IGraphic<GraphicBuilder, string>>(builder);
        }

        /// <summary>
        ///     Tests that Graphic sets type correctly.
        /// </summary>
        [Fact]
        public void Graphic_SetsTypeCorrectly()
        {
            var builder = new GraphicBuilderImpl();
            var result = builder.Graphic("Sprite");
            Assert.Equal("Sprite", result.GraphicType);
        }

        /// <summary>
        ///     Tests that Graphic returns builder.
        /// </summary>
        [Fact]
        public void Graphic_ReturnsBuilder()
        {
            var builder = new GraphicBuilderImpl();
            var result = builder.Graphic("Mesh");
            Assert.NotNull(result);
            Assert.IsType<GraphicBuilder>(result);
        }

        /// <summary>
        ///     Tests Graphic with various types.
        /// </summary>
        [Theory]
        [InlineData("Sprite")]
        [InlineData("Mesh")]
        [InlineData("Particle")]
        [InlineData("Trail")]
        public void Graphic_WithVariousTypes(string type)
        {
            var builder = new GraphicBuilderImpl();
            var result = builder.Graphic(type);
            Assert.Equal(type, result.GraphicType);
        }
    }
}

