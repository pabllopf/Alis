// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShapeTypeTest.cs
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

using Alis.Core.Physic.Collisions.Shapes;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions.Shapes
{
    /// <summary>
    ///     The shape type test class
    /// </summary>
    public class ShapeTypeTest
    {
        /// <summary>
        ///     Tests that unknown should have value negative one
        /// </summary>
        [Fact]
        public void Unknown_ShouldHaveValueNegativeOne()
        {
            byte value = unchecked((byte)(-1));
            Assert.Equal(value, unchecked((byte)ShapeType.Unknown));
        }

        /// <summary>
        ///     Tests that unknown value cast to byte should equal 255
        /// </summary>
        [Fact]
        public void Unknown_CastToByte_ShouldEqual255()
        {
            byte value = 255;
            Assert.Equal(value, unchecked((byte)ShapeType.Unknown));
        }

        /// <summary>
        ///     Tests that circle should have value zero
        /// </summary>
        [Fact]
        public void Circle_ShouldHaveValueZero()
        {
            byte value = 0;
            Assert.Equal(value, (byte) ShapeType.Circle);
        }

        /// <summary>
        ///     Tests that edge should have value one
        /// </summary>
        [Fact]
        public void Edge_ShouldHaveValueOne()
        {
            byte value = 1;
            Assert.Equal(value, (byte) ShapeType.Edge);
        }

        /// <summary>
        ///     Tests that polygon should have value two
        /// </summary>
        [Fact]
        public void Polygon_ShouldHaveValueTwo()
        {
            byte value = 2;
            Assert.Equal(value, (byte) ShapeType.Polygon);
        }

        /// <summary>
        ///     Tests that chain should have value three
        /// </summary>
        [Fact]
        public void Chain_ShouldHaveValueThree()
        {
            byte value = 3;
            Assert.Equal(value, (byte) ShapeType.Chain);
        }

        /// <summary>
        ///     Tests that typeCount should have value four
        /// </summary>
        [Fact]
        public void TypeCount_ShouldHaveValueFour()
        {
            byte value = 4;
            Assert.Equal(value, (byte) ShapeType.TypeCount);
        }

        /// <summary>
        ///     Tests that all values should be unique
        /// </summary>
        [Fact]
        public void AllValues_ShouldBeUnique()
        {
            Assert.NotEqual(ShapeType.Unknown, ShapeType.Circle);
            Assert.NotEqual(ShapeType.Unknown, ShapeType.Edge);
            Assert.NotEqual(ShapeType.Unknown, ShapeType.Polygon);
            Assert.NotEqual(ShapeType.Unknown, ShapeType.Chain);
            Assert.NotEqual(ShapeType.Unknown, ShapeType.TypeCount);
            Assert.NotEqual(ShapeType.Circle, ShapeType.Edge);
            Assert.NotEqual(ShapeType.Circle, ShapeType.Polygon);
            Assert.NotEqual(ShapeType.Circle, ShapeType.Chain);
            Assert.NotEqual(ShapeType.Circle, ShapeType.TypeCount);
            Assert.NotEqual(ShapeType.Edge, ShapeType.Polygon);
            Assert.NotEqual(ShapeType.Edge, ShapeType.Chain);
            Assert.NotEqual(ShapeType.Edge, ShapeType.TypeCount);
            Assert.NotEqual(ShapeType.Polygon, ShapeType.Chain);
            Assert.NotEqual(ShapeType.Polygon, ShapeType.TypeCount);
            Assert.NotEqual(ShapeType.Chain, ShapeType.TypeCount);
        }
    }
}
