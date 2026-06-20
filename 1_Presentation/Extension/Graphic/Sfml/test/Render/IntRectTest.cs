// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IntRectTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Render;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Unit tests for the IntRect struct.
    /// </summary>
    public class IntRectTest
    {
        /// <summary>
        ///     Tests the constructors and field assignment.
        /// </summary>
        [Fact]
        public void Constructor_AssignsFields()
        {
            IntRect rect = new IntRect(1, 2, 3, 4);
            Assert.Equal(1, rect.Left);
            Assert.Equal(2, rect.Top);
            Assert.Equal(3, rect.Width);
            Assert.Equal(4, rect.Height);
        }

        /// <summary>
        ///     Tests Contains method for points inside and outside.
        /// </summary>
        [Fact]
        public void Contains_Works()
        {
            IntRect rect = new IntRect(0, 0, 10, 10);
            Assert.True(rect.Contains(5, 5));
            Assert.False(rect.Contains(15, 5));
        }

        /// <summary>
        ///     Tests Intersects method for overlapping and non-overlapping rectangles.
        /// </summary>
        [Fact]
        public void Intersects_Works()
        {
            IntRect r1 = new IntRect(0, 0, 10, 10);
            IntRect r2 = new IntRect(5, 5, 10, 10);
            IntRect r3 = new IntRect(20, 20, 5, 5);
            Assert.True(r1.Intersects(r2));
            Assert.False(r1.Intersects(r3));
        }

        /// <summary>
        ///     Tests Intersects with overlap output.
        /// </summary>
        [Fact]
        public void Intersects_OverlapOutput_Works()
        {
            IntRect r1 = new IntRect(0, 0, 10, 10);
            IntRect r2 = new IntRect(5, 5, 10, 10);
            Assert.True(r1.Intersects(r2, out IntRect overlap));
            Assert.Equal(5, overlap.Left);
            Assert.Equal(5, overlap.Top);
            Assert.Equal(5, overlap.Width);
            Assert.Equal(5, overlap.Height);
        }

        /// <summary>
        ///     Tests ToString returns the expected format.
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            IntRect rect = new IntRect(1, 2, 3, 4);
            string str = rect.ToString();
            Assert.Contains("Left(1)", str);
            Assert.Contains("Top(2)", str);
            Assert.Contains("Width(3)", str);
            Assert.Contains("Height(4)", str);
        }

        /// <summary>
        ///     Tests the Vector2F constructor.
        /// </summary>
        [Fact]
        public void Constructor_FromVector2F_AssignsFields()
        {
            IntRect rect = new IntRect(new Vector2F(1, 2), new Vector2F(3, 4));
            Assert.Equal(1, rect.Left);
            Assert.Equal(2, rect.Top);
            Assert.Equal(3, rect.Width);
            Assert.Equal(4, rect.Height);
        }

        /// <summary>
        ///     Tests Contains with a point on the left boundary.
        /// </summary>
        [Fact]
        public void Contains_OnLeftBoundary_ReturnsTrue()
        {
            IntRect rect = new IntRect(0, 0, 10, 10);
            Assert.True(rect.Contains(0, 5));
        }

        /// <summary>
        ///     Tests Contains with a point on the right boundary (exclusive).
        /// </summary>
        [Fact]
        public void Contains_OnRightBoundary_ReturnsFalse()
        {
            IntRect rect = new IntRect(0, 0, 10, 10);
            Assert.False(rect.Contains(10, 5));
        }

        /// <summary>
        ///     Tests Contains with a point on the top boundary.
        /// </summary>
        [Fact]
        public void Contains_OnTopBoundary_ReturnsTrue()
        {
            IntRect rect = new IntRect(0, 0, 10, 10);
            Assert.True(rect.Contains(5, 0));
        }

        /// <summary>
        ///     Tests Contains with a point on the bottom boundary.
        /// </summary>
        [Fact]
        public void Contains_OnBottomBoundary_ReturnsFalse()
        {
            IntRect rect = new IntRect(0, 0, 10, 10);
            Assert.False(rect.Contains(5, 10));
        }

        /// <summary>
        ///     Tests Contains with a point completely outside.
        /// </summary>
        [Fact]
        public void Contains_OutsideBothAxes_ReturnsFalse()
        {
            IntRect rect = new IntRect(0, 0, 10, 10);
            Assert.False(rect.Contains(20, 20));
        }

        /// <summary>
        ///     Tests Contains with a rectangle that has negative width and height.
        /// </summary>
        [Fact]
        public void Contains_NegativeDimensions_WorksCorrectly()
        {
            IntRect rect = new IntRect(10, 10, -10, -10);
            Assert.True(rect.Contains(5, 5));
            Assert.False(rect.Contains(15, 15));
        }

        /// <summary>
        ///     Tests Intersects with rectangles that have negative dimensions.
        /// </summary>
        [Fact]
        public void Intersects_NegativeDimensions_WorksCorrectly()
        {
            IntRect r1 = new IntRect(10, 10, -10, -10);
            IntRect r2 = new IntRect(5, 5, 5, 5);
            Assert.True(r1.Intersects(r2));
        }

        /// <summary>
        ///     Tests Intersects with touching edges (no overlap).
        /// </summary>
        [Fact]
        public void Intersects_TouchingEdges_ReturnsFalse()
        {
            IntRect r1 = new IntRect(0, 0, 10, 10);
            IntRect r2 = new IntRect(10, 0, 10, 10);
            Assert.False(r1.Intersects(r2));
        }

        /// <summary>
        ///     Tests Intersects with no overlap verifies overlap is cleared.
        /// </summary>
        [Fact]
        public void Intersects_NoOverlap_OverlapCleared()
        {
            IntRect r1 = new IntRect(0, 0, 10, 10);
            IntRect r2 = new IntRect(20, 20, 10, 10);
            Assert.False(r1.Intersects(r2, out IntRect overlap));
            Assert.Equal(0, overlap.Left);
            Assert.Equal(0, overlap.Top);
            Assert.Equal(0, overlap.Width);
            Assert.Equal(0, overlap.Height);
        }

        /// <summary>
        ///     Tests Equals with another IntRect — equal values.
        /// </summary>
        [Fact]
        public void Equals_EqualValues_ReturnsTrue()
        {
            IntRect r1 = new IntRect(1, 2, 3, 4);
            IntRect r2 = new IntRect(1, 2, 3, 4);
            Assert.True(r1.Equals(r2));
        }

        /// <summary>
        ///     Tests Equals with another IntRect — different values.
        /// </summary>
        [Fact]
        public void Equals_DifferentValues_ReturnsFalse()
        {
            IntRect r1 = new IntRect(1, 2, 3, 4);
            IntRect r2 = new IntRect(5, 6, 7, 8);
            Assert.False(r1.Equals(r2));
        }

        /// <summary>
        ///     Tests Equals with object parameter.
        /// </summary>
        [Fact]
        public void Equals_ObjectParameter_WorksCorrectly()
        {
            IntRect r1 = new IntRect(1, 2, 3, 4);
            object r2 = new IntRect(1, 2, 3, 4);
            object nonRect = new object();
            Assert.True(r1.Equals(r2));
            Assert.False(r1.Equals(nonRect));
        }

        /// <summary>
        ///     Tests GetHashCode for equal rects.
        /// </summary>
        [Fact]
        public void GetHashCode_EqualRects_ReturnsSameValue()
        {
            IntRect r1 = new IntRect(1, 2, 3, 4);
            IntRect r2 = new IntRect(1, 2, 3, 4);
            Assert.Equal(r1.GetHashCode(), r2.GetHashCode());
        }

        /// <summary>
        ///     Tests GetHashCode for different rects.
        /// </summary>
        [Fact]
        public void GetHashCode_DifferentRects_ReturnsDifferentValue()
        {
            IntRect r1 = new IntRect(1, 2, 3, 4);
            IntRect r2 = new IntRect(5, 6, 7, 8);
            Assert.NotEqual(r1.GetHashCode(), r2.GetHashCode());
        }

        /// <summary>
        ///     Tests the equality operator.
        /// </summary>
        [Fact]
        public void Operator_Equality_WorksCorrectly()
        {
            IntRect r1 = new IntRect(1, 2, 3, 4);
            IntRect r2 = new IntRect(1, 2, 3, 4);
            IntRect r3 = new IntRect(5, 6, 7, 8);
            Assert.True(r1 == r2);
            Assert.False(r1 == r3);
        }

        /// <summary>
        ///     Tests the inequality operator.
        /// </summary>
        [Fact]
        public void Operator_Inequality_WorksCorrectly()
        {
            IntRect r1 = new IntRect(1, 2, 3, 4);
            IntRect r2 = new IntRect(1, 2, 3, 4);
            IntRect r3 = new IntRect(5, 6, 7, 8);
            Assert.False(r1 != r2);
            Assert.True(r1 != r3);
        }

        /// <summary>
        ///     Tests explicit cast to FloatRect.
        /// </summary>
        [Fact]
        public void ExplicitCast_ToFloatRect_WorksCorrectly()
        {
            IntRect rect = new IntRect(1, 2, 3, 4);
            FloatRect floatRect = (FloatRect) rect;
            Assert.Equal(1, floatRect.Left);
            Assert.Equal(2, floatRect.Top);
            Assert.Equal(3, floatRect.Width);
            Assert.Equal(4, floatRect.Height);
        }
    }
}