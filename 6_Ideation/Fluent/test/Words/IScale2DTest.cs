// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IScale2DTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
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
    ///     Unit tests for the IScale2D interface.
    ///     Tests the Scale method for 2D scaling assignment.
    /// </summary>
    public class IScale2DTest
    {
        /// <summary>
        ///     Tests that IScale2D can be implemented.
        /// </summary>
        [Fact]
        public void IScale2D_CanBeImplemented()
        {
            Scale2DBuilder builder = new Scale2DBuilder();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IScale2D<ScaleBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that Scale sets values correctly.
        /// </summary>
        [Fact]
        public void Scale_SetsValuesCorrectly()
        {
            Scale2DBuilder builder = new Scale2DBuilder();
            ScaleBuilder result = builder.Scale(2f, 3f);
            Assert.Equal(2f, result.ScaleX);
            Assert.Equal(3f, result.ScaleY);
        }

        /// <summary>
        ///     Tests that Scale returns builder.
        /// </summary>
        [Fact]
        public void Scale_ReturnsBuilder()
        {
            Scale2DBuilder builder = new Scale2DBuilder();
            ScaleBuilder result = builder.Scale(1f, 1f);
            Assert.NotNull(result);
            Assert.IsType<ScaleBuilder>(result);
        }

        /// <summary>
        ///     Tests Scale with uniform scaling.
        /// </summary>
        [Fact]
        public void Scale_WithUniformScaling()
        {
            Scale2DBuilder builder = new Scale2DBuilder();
            ScaleBuilder result = builder.Scale(1.5f, 1.5f);
            Assert.Equal(1.5f, result.ScaleX);
            Assert.Equal(1.5f, result.ScaleY);
        }

        /// <summary>
        ///     Tests Scale with extreme values.
        /// </summary>
        [Theory, InlineData(0.1f, 0.1f), InlineData(10f, 10f), InlineData(0.5f, 2f)]
        public void Scale_WithVariousScaleValues(float x, float y)
        {
            Scale2DBuilder builder = new Scale2DBuilder();
            ScaleBuilder result = builder.Scale(x, y);
            Assert.Equal(x, result.ScaleX);
            Assert.Equal(y, result.ScaleY);
        }

        /// <summary>
        ///     Helper builder class for scale.
        /// </summary>
        private class ScaleBuilder
        {
            /// <summary>
            /// Gets or sets the value of the scale x
            /// </summary>
            public float ScaleX { get; set; }
            /// <summary>
            /// Gets or sets the value of the scale y
            /// </summary>
            public float ScaleY { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IScale2D.
        /// </summary>
        private class Scale2DBuilder : IScale2D<ScaleBuilder, float>
        {
            /// <summary>
            /// The scale builder
            /// </summary>
            private readonly ScaleBuilder _builder = new ScaleBuilder();

            /// <summary>
            /// Scales the x
            /// </summary>
            /// <param name="x">The </param>
            /// <param name="y">The </param>
            /// <returns>The builder</returns>
            public ScaleBuilder Scale(float x, float y)
            {
                _builder.ScaleX = x;
                _builder.ScaleY = y;
                return _builder;
            }
        }
    }
}