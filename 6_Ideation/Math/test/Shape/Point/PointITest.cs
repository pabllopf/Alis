// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PointITest.cs
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

using Alis.Core.Aspect.Math.Shapes;
using Alis.Core.Aspect.Math.Shapes.Point;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Point
{
    /// <summary>
    ///     The point test class
    /// </summary>
    public class PointITest
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            PointI point = new PointI {X = 1, Y = 2};

            Assert.Equal(1, point.X);
            Assert.Equal(2, point.Y);
        }

        /// <summary>
        ///     Tests that properties set values correctly
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [Theory, InlineData(0, 0), InlineData(-1, -1), InlineData(int.MaxValue, int.MaxValue)]
        public void Properties_SetValuesCorrectly(int x, int y)
        {
            PointI point = new PointI {X = x, Y = y};

            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
        }

        /// <summary>
        ///     Tests that the default constructor initializes properties to zero
        /// </summary>
        [Fact]
        public void Constructor_Default_InitializesToZero()
        {
            PointI point = new PointI();

            Assert.Equal(0, point.X);
            Assert.Equal(0, point.Y);
        }

        /// <summary>
        ///     Tests that the constructor with explicit values initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_WithExplicitValues_InitializesCorrectly()
        {
            PointI point = new PointI {X = 5, Y = 6};

            Assert.Equal(5, point.X);
            Assert.Equal(6, point.Y);
        }

        /// <summary>
        ///     Tests that the X property can be set and retrieved correctly
        /// </summary>
        [Fact]
        public void XProperty_CanBeSetAndRetrieved()
        {
            PointI point = new PointI {X = 1, Y = 2};

            point.X = 5;

            Assert.Equal(5, point.X);
            Assert.Equal(2, point.Y);
        }

        /// <summary>
        ///     Tests that the Y property can be set and retrieved correctly
        /// </summary>
        [Fact]
        public void YProperty_CanBeSetAndRetrieved()
        {
            PointI point = new PointI {X = 1, Y = 2};

            point.Y = 6;

            Assert.Equal(1, point.X);
            Assert.Equal(6, point.Y);
        }

        /// <summary>
        ///     Tests that the properties can be set independently
        /// </summary>
        [Fact]
        public void Properties_CanBeSetIndependently()
        {
            PointI point = new PointI {X = 1, Y = 2};

            point.X = 10;
            point.Y = 20;

            Assert.Equal(10, point.X);
            Assert.Equal(20, point.Y);
        }

        /// <summary>
        ///     Tests that the properties can be set to negative values
        /// </summary>
        [Fact]
        public void Properties_CanBeSetToNegativeValues()
        {
            PointI point = new PointI {X = -5, Y = -10};

            Assert.Equal(-5, point.X);
            Assert.Equal(-10, point.Y);
        }

        /// <summary>
        ///     Tests that PointI is a value type
        /// </summary>
        [Fact]
        public void PointI_IsValueType()
        {
            Assert.True(typeof(PointI).IsValueType);
        }

        /// <summary>
        ///     Tests that assignment creates an independent copy
        /// </summary>
        [Fact]
        public void Assignment_CreatesIndependentCopy()
        {
            PointI first = new PointI {X = 5, Y = 6};
            PointI second = first;

            second.X = 15;
            second.Y = 16;

            Assert.Equal(5, first.X);
            Assert.Equal(6, first.Y);
            Assert.Equal(15, second.X);
            Assert.Equal(16, second.Y);
        }

        /// <summary>
        ///     Tests that the struct layout is sequential
        /// </summary>
        [Fact]
        public void StructLayout_IsSequential()
        {
            Assert.True(typeof(PointI).IsLayoutSequential);
        }

        /// <summary>
        ///     Tests that PointI with MaxValue stores correctly
        /// </summary>
        [Fact]
        public void PointI_WithMaxValue_StoresCorrectly()
        {
            PointI point = new PointI {X = int.MaxValue, Y = int.MaxValue};

            Assert.Equal(int.MaxValue, point.X);
            Assert.Equal(int.MaxValue, point.Y);
        }

        /// <summary>
        ///     Tests that PointI with MinValue stores correctly
        /// </summary>
        [Fact]
        public void PointI_WithMinValue_StoresCorrectly()
        {
            PointI point = new PointI {X = int.MinValue, Y = int.MinValue};

            Assert.Equal(int.MinValue, point.X);
            Assert.Equal(int.MinValue, point.Y);
        }

        /// <summary>
        ///     Tests that PointI with zero values stores correctly
        /// </summary>
        [Fact]
        public void PointI_WithZeroValues_StoresCorrectly()
        {
            PointI point = new PointI {X = 0, Y = 0};

            Assert.Equal(0, point.X);
            Assert.Equal(0, point.Y);
        }

        /// <summary>
        ///     Tests that PointI with mixed signs stores correctly
        /// </summary>
        [Fact]
        public void PointI_WithMixedSigns_StoresCorrectly()
        {
            PointI point = new PointI {X = 100, Y = -100};

            Assert.Equal(100, point.X);
            Assert.Equal(-100, point.Y);
        }

        /// <summary>
        ///     Tests equality when two points have the same values
        /// </summary>
        [Fact]
        public void Equality_WithSameValues_ReturnsTrue()
        {
            PointI p1 = new PointI {X = 5, Y = 6};
            PointI p2 = new PointI {X = 5, Y = 6};

            Assert.Equal(p1, p2);
        }

        /// <summary>
        ///     Tests inequality when two points have different X values
        /// </summary>
        [Fact]
        public void Equality_WithDifferentXValues_ReturnsFalse()
        {
            PointI p1 = new PointI {X = 5, Y = 6};
            PointI p2 = new PointI {X = 4, Y = 6};

            Assert.NotEqual(p1, p2);
        }

        /// <summary>
        ///     Tests inequality when two points have different Y values
        /// </summary>
        [Fact]
        public void Equality_WithDifferentYValues_ReturnsFalse()
        {
            PointI p1 = new PointI {X = 5, Y = 6};
            PointI p2 = new PointI {X = 5, Y = 7};

            Assert.NotEqual(p1, p2);
        }

        /// <summary>
        ///     Tests that GetHashCode returns the same hash for points with the same values
        /// </summary>
        [Fact]
        public void GetHashCode_WithSameValues_ReturnsSameHash()
        {
            PointI p1 = new PointI {X = 5, Y = 6};
            PointI p2 = new PointI {X = 5, Y = 6};

            Assert.Equal(p1.GetHashCode(), p2.GetHashCode());
        }

        /// <summary>
        ///     Tests that GetHashCode returns different hashes for points with different values
        /// </summary>
        [Fact]
        public void GetHashCode_WithDifferentValues_ReturnsDifferentHashes()
        {
            PointI p1 = new PointI {X = 5, Y = 6};
            PointI p2 = new PointI {X = 7, Y = 8};

            Assert.NotEqual(p1.GetHashCode(), p2.GetHashCode());
        }

        /// <summary>
        ///     Tests that ToString returns a formatted string
        /// </summary>
        [Fact]
        public void ToString_ReturnsFormattedString()
        {
            PointI point = new PointI {X = 3, Y = 4};
            string result = point.ToString();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        ///     Tests that ToString returns a formatted string with negative values
        /// </summary>
        [Fact]
        public void ToString_WithNegativeValues_ReturnsFormattedString()
        {
            PointI point = new PointI {X = -3, Y = -4};
            string result = point.ToString();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        ///     Tests that PointI implements the IShape interface
        /// </summary>
        [Fact]
        public void PointI_ImplementsIShape()
        {
            PointI point = new PointI();

            Assert.IsAssignableFrom<IShape>(point);
        }
    }
}