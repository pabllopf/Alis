// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DimensionsTest.cs
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

using System;
using Alis.Extension.Math.ProceduralDungeon.Models;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test.Models
{
    /// <summary>
    ///     Test class for <see cref="Dimensions" />.
    ///     Verifies dimensions struct operations and validation.
    /// </summary>
    public class DimensionsTest
    {
        /// <summary>
        ///     Tests that constructor sets properties correctly with valid values.
        /// </summary>
        [Fact]
        public void Constructor_WithValidValues_SetsProperties()
        {
            int width = 10;
            int height = 20;

            Dimensions dimensions = new Dimensions(width, height);

            Assert.Equal(width, dimensions.Width);
            Assert.Equal(height, dimensions.Height);
        }

        /// <summary>
        ///     Tests that constructor throws exception with zero width.
        /// </summary>
        [Fact]
        public void Constructor_WithZeroWidth_ThrowsArgumentException()
        {
            int width = 0;
            int height = 20;

            Assert.Throws<ArgumentException>(() => new Dimensions(width, height));
        }

        /// <summary>
        ///     Tests that constructor throws exception with negative width.
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeWidth_ThrowsArgumentException()
        {
            int width = -5;
            int height = 20;

            Assert.Throws<ArgumentException>(() => new Dimensions(width, height));
        }

        /// <summary>
        ///     Tests that constructor throws exception with zero height.
        /// </summary>
        [Fact]
        public void Constructor_WithZeroHeight_ThrowsArgumentException()
        {
            int width = 10;
            int height = 0;

            Assert.Throws<ArgumentException>(() => new Dimensions(width, height));
        }

        /// <summary>
        ///     Tests that constructor throws exception with negative height.
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeHeight_ThrowsArgumentException()
        {
            int width = 10;
            int height = -5;

            Assert.Throws<ArgumentException>(() => new Dimensions(width, height));
        }

        /// <summary>
        ///     Tests that Area property calculates correctly.
        /// </summary>
        [Fact]
        public void Area_CalculatesCorrectValue()
        {
            Dimensions dimensions = new Dimensions(10, 20);

            int area = dimensions.Area;

            Assert.Equal(200, area);
        }

        /// <summary>
        ///     Tests equality operator with equal dimensions.
        /// </summary>
        [Fact]
        public void EqualityOperator_WithEqualDimensions_ReturnsTrue()
        {
            Dimensions dim1 = new Dimensions(10, 20);
            Dimensions dim2 = new Dimensions(10, 20);

            bool result = dim1 == dim2;

            Assert.True(result);
        }

        /// <summary>
        ///     Tests equality operator with different dimensions.
        /// </summary>
        [Fact]
        public void EqualityOperator_WithDifferentDimensions_ReturnsFalse()
        {
            Dimensions dim1 = new Dimensions(10, 20);
            Dimensions dim2 = new Dimensions(15, 25);

            bool result = dim1 == dim2;

            Assert.False(result);
        }

        /// <summary>
        ///     Tests inequality operator with different dimensions.
        /// </summary>
        [Fact]
        public void InequalityOperator_WithDifferentDimensions_ReturnsTrue()
        {
            Dimensions dim1 = new Dimensions(10, 20);
            Dimensions dim2 = new Dimensions(15, 25);

            bool result = dim1 != dim2;

            Assert.True(result);
        }

        /// <summary>
        ///     Tests inequality operator with equal dimensions.
        /// </summary>
        [Fact]
        public void InequalityOperator_WithEqualDimensions_ReturnsFalse()
        {
            Dimensions dim1 = new Dimensions(10, 20);
            Dimensions dim2 = new Dimensions(10, 20);

            bool result = dim1 != dim2;

            Assert.False(result);
        }

        /// <summary>
        ///     Tests Equals method with equal dimensions.
        /// </summary>
        [Fact]
        public void Equals_WithEqualDimensions_ReturnsTrue()
        {
            Dimensions dim1 = new Dimensions(10, 20);
            Dimensions dim2 = new Dimensions(10, 20);

            bool result = dim1.Equals(dim2);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests Equals method with different dimensions.
        /// </summary>
        [Fact]
        public void Equals_WithDifferentDimensions_ReturnsFalse()
        {
            Dimensions dim1 = new Dimensions(10, 20);
            Dimensions dim2 = new Dimensions(15, 25);

            bool result = dim1.Equals(dim2);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests Equals method with object parameter.
        /// </summary>
        [Fact]
        public void Equals_WithObjectParameter_ReturnsCorrectResult()
        {
            Dimensions dim1 = new Dimensions(10, 20);
            object dim2 = new Dimensions(10, 20);
            object notDimensions = "not dimensions";

            bool equalResult = dim1.Equals(dim2);
            bool notEqualResult = dim1.Equals(notDimensions);

            Assert.True(equalResult);
            Assert.False(notEqualResult);
        }

        /// <summary>
        ///     Tests GetHashCode returns consistent values.
        /// </summary>
        [Fact]
        public void GetHashCode_WithEqualDimensions_ReturnsSameValue()
        {
            Dimensions dim1 = new Dimensions(10, 20);
            Dimensions dim2 = new Dimensions(10, 20);

            int hash1 = dim1.GetHashCode();
            int hash2 = dim2.GetHashCode();

            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Tests ToString returns formatted string.
        /// </summary>
        [Fact]
        public void ToString_ReturnsFormattedString()
        {
            Dimensions dimensions = new Dimensions(10, 20);

            string result = dimensions.ToString();

            Assert.Equal("10 x 20", result);
        }

        /// <summary>
        ///     Tests CanContain returns true when dimensions are larger.
        /// </summary>
        [Fact]
        public void CanContain_WithSmallerDimensions_ReturnsTrue()
        {
            Dimensions larger = new Dimensions(20, 30);
            Dimensions smaller = new Dimensions(10, 15);

            bool result = larger.CanContain(smaller);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests CanContain returns true when dimensions are equal.
        /// </summary>
        [Fact]
        public void CanContain_WithEqualDimensions_ReturnsTrue()
        {
            Dimensions dim1 = new Dimensions(20, 30);
            Dimensions dim2 = new Dimensions(20, 30);

            bool result = dim1.CanContain(dim2);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests CanContain returns false when dimensions are smaller.
        /// </summary>
        [Fact]
        public void CanContain_WithLargerDimensions_ReturnsFalse()
        {
            Dimensions smaller = new Dimensions(10, 15);
            Dimensions larger = new Dimensions(20, 30);

            bool result = smaller.CanContain(larger);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests CanContain returns false when only width is smaller.
        /// </summary>
        [Fact]
        public void CanContain_WithSmallerWidth_ReturnsFalse()
        {
            Dimensions dim1 = new Dimensions(10, 30);
            Dimensions dim2 = new Dimensions(20, 15);

            bool result = dim1.CanContain(dim2);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests CanContain returns false when only height is smaller.
        /// </summary>
        [Fact]
        public void CanContain_WithSmallerHeight_ReturnsFalse()
        {
            Dimensions dim1 = new Dimensions(30, 10);
            Dimensions dim2 = new Dimensions(15, 20);

            bool result = dim1.CanContain(dim2);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests GetHashCode returns different hash for different dimensions.
        /// </summary>
        [Fact]
        public void GetHashCode_WithDifferentDimensions_ReturnsDifferentHash()
        {
            Dimensions dim1 = new Dimensions(10, 20);
            Dimensions dim2 = new Dimensions(20, 30);

            int hash1 = dim1.GetHashCode();
            int hash2 = dim2.GetHashCode();

            Assert.NotEqual(hash1, hash2);
        }

        /// <summary>
        ///     Tests with large dimension values.
        /// </summary>
        [Fact]
        public void Constructor_WithLargeValues_SetsPropertiesCorrectly()
        {
            int width = int.MaxValue;
            int height = int.MaxValue;

            Dimensions dimensions = new Dimensions(width, height);

            Assert.Equal(width, dimensions.Width);
            Assert.Equal(height, dimensions.Height);
        }

        /// <summary>
        ///     Tests Area property with large dimensions.
        /// </summary>
        [Fact]
        public void Area_WithLargeDimensions_CalculatesCorrectly()
        {
            Dimensions dimensions = new Dimensions(1000, 1000);

            int area = dimensions.Area;

            Assert.Equal(1000000, area);
        }

        /// <summary>
        ///     Tests CanContain with edge case dimensions.
        /// </summary>
        [Theory, InlineData(1, 1, 1, 1), InlineData(100, 100, 1, 1), InlineData(1, 1, 100, 100)]
        public void CanContain_WithVariousDimensions_ReturnsCorrectResult(int width1, int height1, int width2, int height2)
        {
            Dimensions dim1 = new Dimensions(width1, height1);
            Dimensions dim2 = new Dimensions(width2, height2);

            bool result = dim1.CanContain(dim2);

            if ((width1 >= width2) && (height1 >= height2))
            {
                Assert.True(result);
            }
            else
            {
                Assert.False(result);
            }
        }
    }
}