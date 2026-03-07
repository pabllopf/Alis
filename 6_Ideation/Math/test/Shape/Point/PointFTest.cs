// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PointFTest.cs
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
using Alis.Core.Aspect.Math.Shapes;
using Alis.Core.Aspect.Math.Shapes.Point;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape.Point
{
    /// <summary>
    ///     The point test class
    /// </summary>
    public class PointFTest
    {
        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void Constructor_InitializesPropertiesCorrectly()
        {
            PointF point = new PointF {X = 1.0f, Y = 2.0f};

            Assert.Equal(1.0f, point.X);
            Assert.Equal(2.0f, point.Y);
        }

        /// <summary>
        ///     Tests that properties set values correctly
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [Theory, InlineData(0f, 0f), InlineData(-1f, -1f), InlineData(float.MaxValue, float.MaxValue)]
        public void Properties_SetValuesCorrectly(float x, float y)
        {
            PointF point = new PointF {X = x, Y = y};

            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
        }

        /// <summary>
        /// Tests that constructor with single value initializes both coordinates
        /// </summary>
        [Fact]
        public void Constructor_WithSingleValue_InitializesBothCoordinates()
        {
            PointF point = new PointF(5.5f);

            Assert.Equal(5.5f, point.X);
            Assert.Equal(5.5f, point.Y);
        }

        /// <summary>
        /// Tests that constructor with two values initializes coordinates correctly
        /// </summary>
        [Fact]
        public void Constructor_WithTwoValues_InitializesCoordinatesCorrectly()
        {
            PointF point = new PointF(3.5f, 4.5f);

            Assert.Equal(3.5f, point.X);
            Assert.Equal(4.5f, point.Y);
        }

        /// <summary>
        /// Tests that constructor copy constructor copies point values
        /// </summary>
        [Fact]
        public void Constructor_CopyConstructor_CopiesPointValues()
        {
            PointF original = new PointF(2.5f, 3.5f);
            PointF copy = new PointF(original);

            Assert.Equal(original.X, copy.X);
            Assert.Equal(original.Y, copy.Y);
        }

        /// <summary>
        /// Tests that constructor with zero value initializes correctly
        /// </summary>
        [Fact]
        public void Constructor_WithZeroValue_InitializesCorrectly()
        {
            PointF point = new PointF(0f);

            Assert.Equal(0f, point.X);
            Assert.Equal(0f, point.Y);
        }

        /// <summary>
        /// Tests that constructor with negative values initializes correctly
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeValues_InitializesCorrectly()
        {
            PointF point = new PointF(-1.5f, -2.5f);

            Assert.Equal(-1.5f, point.X);
            Assert.Equal(-2.5f, point.Y);
        }

        /// <summary>
        /// Tests that x property can be set and retrieved
        /// </summary>
        [Fact]
        public void XProperty_CanBeSetAndRetrieved()
        {
            PointF point = new PointF(1f, 2f);

            point.X = 5f;

            Assert.Equal(5f, point.X);
            Assert.Equal(2f, point.Y);
        }

        /// <summary>
        /// Tests that y property can be set and retrieved
        /// </summary>
        [Fact]
        public void YProperty_CanBeSetAndRetrieved()
        {
            PointF point = new PointF(1f, 2f);

            point.Y = 6f;

            Assert.Equal(1f, point.X);
            Assert.Equal(6f, point.Y);
        }

        /// <summary>
        /// Tests that properties can be set independently
        /// </summary>
        [Fact]
        public void Properties_CanBeSetIndependently()
        {
            PointF point = new PointF(1f, 2f);

            point.X = 10f;
            point.Y = 20f;

            Assert.Equal(10f, point.X);
            Assert.Equal(20f, point.Y);
        }

        /// <summary>
        /// Tests that point f is value type
        /// </summary>
        [Fact]
        public void PointF_IsValueType()
        {
            Assert.True(typeof(PointF).IsValueType);
        }

        /// <summary>
        /// Tests that copy constructor creates independent copy
        /// </summary>
        [Fact]
        public void CopyConstructor_CreatesIndependentCopy()
        {
            PointF original = new PointF(1f, 2f);
            PointF copy = new PointF(original);

            copy.X = 10f;
            copy.Y = 20f;

            Assert.Equal(1f, original.X);
            Assert.Equal(2f, original.Y);
            Assert.Equal(10f, copy.X);
            Assert.Equal(20f, copy.Y);
        }

        /// <summary>
        /// Tests that assignment creates independent copy
        /// </summary>
        [Fact]
        public void Assignment_CreatesIndependentCopy()
        {
            PointF first = new PointF(5f, 6f);
            PointF second = first;

            second.X = 15f;

            Assert.Equal(5f, first.X);
            Assert.Equal(15f, second.X);
        }

        /// <summary>
        /// Tests that point f with max value stores correctly
        /// </summary>
        [Fact]
        public void PointF_WithMaxValue_StoresCorrectly()
        {
            PointF point = new PointF(float.MaxValue, float.MaxValue);

            Assert.Equal(float.MaxValue, point.X);
            Assert.Equal(float.MaxValue, point.Y);
        }

        /// <summary>
        /// Tests that point f with min value stores correctly
        /// </summary>
        [Fact]
        public void PointF_WithMinValue_StoresCorrectly()
        {
            PointF point = new PointF(float.MinValue, float.MinValue);

            Assert.Equal(float.MinValue, point.X);
            Assert.Equal(float.MinValue, point.Y);
        }

        /// <summary>
        /// Tests that point f with na n stores correctly
        /// </summary>
        [Fact]
        public void PointF_WithNaN_StoresCorrectly()
        {
            PointF point = new PointF(float.NaN, float.NaN);

            Assert.True(float.IsNaN(point.X));
            Assert.True(float.IsNaN(point.Y));
        }

        /// <summary>
        /// Tests that point f with infinity stores correctly
        /// </summary>
        [Fact]
        public void PointF_WithInfinity_StoresCorrectly()
        {
            PointF point = new PointF(float.PositiveInfinity, float.NegativeInfinity);

            Assert.True(float.IsPositiveInfinity(point.X));
            Assert.True(float.IsNegativeInfinity(point.Y));
        }

        /// <summary>
        /// Tests that equality with same values returns true
        /// </summary>
        [Fact]
        public void Equality_WithSameValues_ReturnsTrue()
        {
            PointF p1 = new PointF(5f, 6f);
            PointF p2 = new PointF(5f, 6f);

            Assert.Equal(p1, p2);
        }

        /// <summary>
        /// Tests that equality with different values returns false
        /// </summary>
        [Fact]
        public void Equality_WithDifferentValues_ReturnsFalse()
        {
            PointF p1 = new PointF(5f, 6f);
            PointF p2 = new PointF(5f, 7f);

            Assert.NotEqual(p1, p2);
        }

        /// <summary>
        /// Tests that get hash code with same values returns same hash
        /// </summary>
        [Fact]
        public void GetHashCode_WithSameValues_ReturnsSameHash()
        {
            PointF p1 = new PointF(5f, 6f);
            PointF p2 = new PointF(5f, 6f);

            Assert.Equal(p1.GetHashCode(), p2.GetHashCode());
        }

        /// <summary>
        /// Tests that to string returns formatted string
        /// </summary>
        [Fact]
        public void ToString_ReturnsFormattedString()
        {
            PointF point = new PointF(3.5f, 4.5f);
            string result = point.ToString();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        /// <summary>
        /// Tests that point f implements i shape
        /// </summary>
        [Fact]
        public void PointF_ImplementsIShape()
        {
            PointF point = new PointF(1f, 2f);

            Assert.IsAssignableFrom<IShape>(point);
        }
    }
}