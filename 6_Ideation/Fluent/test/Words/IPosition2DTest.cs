// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IPosition2DTest.cs
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
    ///     Unit tests for the IPosition2D interface.
    ///     Tests the Position method for 2D coordinate assignment.
    /// </summary>
    public class IPosition2DTest
    {
        /// <summary>
        ///     Tests that IPosition2D can be implemented.
        /// </summary>
        [Fact]
        public void IPosition2D_CanBeImplemented()
        {
            Position2DBuilder builder = new Position2DBuilder();
            Assert.NotNull(builder);
            Assert.IsAssignableFrom<IPosition2D<PositionBuilder, float>>(builder);
        }

        /// <summary>
        ///     Tests that Position sets coordinates correctly.
        /// </summary>
        [Fact]
        public void Position_SetsCoordinatesCorrectly()
        {
            Position2DBuilder builder = new Position2DBuilder();
            PositionBuilder result = builder.Position(10.5f, 20.5f);
            Assert.Equal(10.5f, result.X);
            Assert.Equal(20.5f, result.Y);
        }

        /// <summary>
        ///     Tests that Position returns builder.
        /// </summary>
        [Fact]
        public void Position_ReturnsBuilder()
        {
            Position2DBuilder builder = new Position2DBuilder();
            PositionBuilder result = builder.Position(5f, 5f);
            Assert.NotNull(result);
            Assert.IsType<PositionBuilder>(result);
        }

        /// <summary>
        ///     Tests Position with zero coordinates.
        /// </summary>
        [Fact]
        public void Position_WithZeroCoordinates()
        {
            Position2DBuilder builder = new Position2DBuilder();
            PositionBuilder result = builder.Position(0f, 0f);
            Assert.Equal(0f, result.X);
            Assert.Equal(0f, result.Y);
        }

        /// <summary>
        ///     Tests Position with negative coordinates.
        /// </summary>
        [Theory, InlineData(-1.5f, -2.5f), InlineData(-10f, 10f), InlineData(10f, -10f)]
        public void Position_WithVariousCoordinates(float x, float y)
        {
            Position2DBuilder builder = new Position2DBuilder();
            PositionBuilder result = builder.Position(x, y);
            Assert.Equal(x, result.X);
            Assert.Equal(y, result.Y);
        }

        /// <summary>
        ///     Helper builder class for position.
        /// </summary>
        private class PositionBuilder
        {
            /// <summary>
            /// Gets or sets the value of the x
            /// </summary>
            public float X { get; set; }
            /// <summary>
            /// Gets or sets the value of the y
            /// </summary>
            public float Y { get; set; }
        }

        /// <summary>
        ///     Helper implementation of IPosition2D.
        /// </summary>
        private class Position2DBuilder : IPosition2D<PositionBuilder, float>
        {
            /// <summary>
            /// The position builder
            /// </summary>
            private readonly PositionBuilder _builder = new PositionBuilder();

            /// <summary>
            /// Positions the x
            /// </summary>
            /// <param name="x">The </param>
            /// <param name="y">The </param>
            /// <returns>The builder</returns>
            public PositionBuilder Position(float x, float y)
            {
                _builder.X = x;
                _builder.Y = y;
                return _builder;
            }
        }
    }
}