// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IntRectTests.cs
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
    ///     Unit tests for the IntRect struct covering all public members and both branches.
    /// </summary>
    public class IntRectTests
    {
        /// <summary>
        ///     Tests that the coordinate constructor assigns all fields.
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
        ///     Tests that the vector constructor assigns all fields.
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
        ///     Tests that Contains returns true for an inner point.
        /// </summary>
        [Fact]
        public void Contains_PointInside_ReturnsTrue()
        {
            IntRect rect = new IntRect(0, 0, 10, 10);

            Assert.True(rect.Contains(5, 5));
        }

        /// <summary>
        ///     Tests that Contains returns false for a point outside on both axes.
        /// </summary>
        [Fact]
        public void Contains_PointOutside_ReturnsFalse()
        {
            IntRect rect = new IntRect(0, 0, 10, 10);

            Assert.False(rect.Contains(20, 20));
        }

        /// <summary>
        ///     Tests that Contains includes the left and top boundaries.
        /// </summary>
        [Fact]
        public void Contains_OnLeftAndTopBoundaries_ReturnsTrue()
        {
            IntRect rect = new IntRect(0, 0, 10, 10);

            Assert.True(rect.Contains(0, 5));
            Assert.True(rect.Contains(5, 0));
            Assert.True(rect.Contains(0, 0));
        }

        /// <summary>
        ///     Tests that Contains excludes the right and bottom boundaries.
        /// </summary>
        [Fact]
        public void Contains_OnRightAndBottomBoundaries_ReturnsFalse()
        {
            IntRect rect = new IntRect(0, 0, 10, 10);

            Assert.False(rect.Contains(10, 5));
            Assert.False(rect.Contains(5, 10));
        }

        /// <summary>
        ///     Tests that Contains handles negative width by normalizing the span.
        /// </summary>
        [Fact]
        public void Contains_NegativeWidth_NormalizesSpan()
        {
            IntRect rect = new IntRect(10, 0, -10, 10);

            Assert.True(rect.Contains(5, 5));
            Assert.False(rect.Contains(10, 5));
            Assert.False(rect.Contains(-1, 5));
        }

        /// <summary>
        ///     Tests that Contains handles negative height by normalizing the span.
        /// </summary>
        [Fact]
        public void Contains_NegativeHeight_NormalizesSpan()
        {
            IntRect rect = new IntRect(0, 10, 10, -10);

            Assert.True(rect.Contains(5, 5));
            Assert.False(rect.Contains(5, 10));
            Assert.False(rect.Contains(5, -1));
        }

        /// <summary>
        ///     Tests that Contains handles both negative width and height.
        /// </summary>
        [Fact]
        public void Contains_NegativeBothDimensions_NormalizesSpan()
        {
            IntRect rect = new IntRect(10, 10, -10, -10);

            Assert.True(rect.Contains(5, 5));
            Assert.False(rect.Contains(15, 15));
        }

        /// <summary>
        ///     Tests that Intersects returns true for overlapping rectangles.
        /// </summary>
        [Fact]
        public void Intersects_Overlapping_ReturnsTrue()
        {
            IntRect r1 = new IntRect(0, 0, 10, 10);
            IntRect r2 = new IntRect(5, 5, 10, 10);

            Assert.True(r1.Intersects(r2));
        }

        /// <summary>
        ///     Tests that Intersects returns false for non-overlapping rectangles.
        /// </summary>
        [Fact]
        public void Intersects_NonOverlapping_ReturnsFalse()
        {
            IntRect r1 = new IntRect(0, 0, 10, 10);
            IntRect r2 = new IntRect(20, 20, 5, 5);

            Assert.False(r1.Intersects(r2));
        }

        /// <summary>
        ///     Tests that Intersects returns false when rectangles only touch edges.
        /// </summary>
        [Fact]
        public void Intersects_TouchingEdges_ReturnsFalse()
        {
            IntRect r1 = new IntRect(0, 0, 10, 10);
            IntRect r2 = new IntRect(10, 0, 10, 10);

            Assert.False(r1.Intersects(r2));
        }

        /// <summary>
        ///     Tests that Intersects with overlap output fills the overlap rectangle.
        /// </summary>
        [Fact]
        public void Intersects_WithOverlapOutput_FillsOverlap()
        {
            IntRect r1 = new IntRect(0, 0, 10, 10);
            IntRect r2 = new IntRect(5, 5, 10, 10);

            bool result = r1.Intersects(r2, out IntRect overlap);

            Assert.True(result);
            Assert.Equal(5, overlap.Left);
            Assert.Equal(5, overlap.Top);
            Assert.Equal(5, overlap.Width);
            Assert.Equal(5, overlap.Height);
        }

        /// <summary>
        ///     Tests that Intersects with no overlap zeroes the overlap rectangle.
        /// </summary>
        [Fact]
        public void Intersects_NoOverlap_ZeroesOverlapOutput()
        {
            IntRect r1 = new IntRect(0, 0, 10, 10);
            IntRect r2 = new IntRect(20, 20, 5, 5);

            bool result = r1.Intersects(r2, out IntRect overlap);

            Assert.False(result);
            Assert.Equal(0, overlap.Left);
            Assert.Equal(0, overlap.Top);
            Assert.Equal(0, overlap.Width);
            Assert.Equal(0, overlap.Height);
        }

        /// <summary>
        ///     Tests that Intersects handles rectangles with negative dimensions.
        /// </summary>
        [Fact]
        public void Intersects_NegativeDimensions_HandlesCorrectly()
        {
            IntRect r1 = new IntRect(10, 10, -10, -10);
            IntRect r2 = new IntRect(5, 5, 10, 10);

            bool result = r1.Intersects(r2, out IntRect overlap);

            Assert.True(result);
            Assert.Equal(5, overlap.Left);
            Assert.Equal(5, overlap.Top);
            Assert.Equal(5, overlap.Width);
            Assert.Equal(5, overlap.Height);
        }

        /// <summary>
        ///     Tests that ToString returns the expected format.
        /// </summary>
        [Fact]
        public void ToString_ReturnsExpectedFormat()
        {
            IntRect rect = new IntRect(1, 2, 3, 4);

            string str = rect.ToString();

            Assert.Contains("[IntRect]", str);
            Assert.Contains("Left(1)", str);
            Assert.Contains("Top(2)", str);
            Assert.Contains("Width(3)", str);
            Assert.Contains("Height(4)", str);
        }

        /// <summary>
        ///     Tests that Equals returns true for rects within the tolerance.
        /// </summary>
        [Fact]
        public void Equals_NearlyEqualValues_ReturnsTrue()
        {
            IntRect r1 = new IntRect(1, 2, 3, 4);
            IntRect r2 = new IntRect(1.005f, 2, 3, 4);

            Assert.True(r1.Equals(r2));
        }

        /// <summary>
        ///     Tests that Equals returns false for rects beyond the tolerance.
        /// </summary>
        [Fact]
        public void Equals_ValuesBeyondTolerance_ReturnsFalse()
        {
            IntRect r1 = new IntRect(1, 2, 3, 4);
            IntRect r2 = new IntRect(1.011f, 2, 3, 4);

            Assert.False(r1.Equals(r2));
        }

        /// <summary>
        ///     Tests that Equals returns true for rects with identical values.
        /// </summary>
        [Fact]
        public void Equals_EqualValues_ReturnsTrue()
        {
            IntRect r1 = new IntRect(1, 2, 3, 4);
            IntRect r2 = new IntRect(1, 2, 3, 4);

            Assert.True(r1.Equals(r2));
        }

        /// <summary>
        ///     Tests that Equals returns false for rects with different values.
        /// </summary>
        [Fact]
        public void Equals_DifferentValues_ReturnsFalse()
        {
            IntRect r1 = new IntRect(1, 2, 3, 4);
            IntRect r2 = new IntRect(5, 6, 7, 8);

            Assert.False(r1.Equals(r2));
        }

        /// <summary>
        ///     Tests that Equals object overload returns true for a boxed equal rect.
        /// </summary>
        [Fact]
        public void Equals_Object_BoxedEqualRect_ReturnsTrue()
        {
            IntRect rect = new IntRect(1, 2, 3, 4);
            object boxed = new IntRect(1, 2, 3, 4);

            Assert.True(rect.Equals(boxed));
        }

        /// <summary>
        ///     Tests that Equals object overload returns false for a non rect object and null.
        /// </summary>
        [Fact]
        public void Equals_Object_NonRectAndNull_ReturnsFalse()
        {
            IntRect rect = new IntRect(1, 2, 3, 4);

            Assert.False(rect.Equals("not a rect"));
            Assert.False(rect.Equals(null));
        }

        /// <summary>
        ///     Tests that GetHashCode is stable for equal rects.
        /// </summary>
        [Fact]
        public void GetHashCode_EqualRects_ReturnsSameValue()
        {
            IntRect r1 = new IntRect(1, 2, 3, 4);
            IntRect r2 = new IntRect(1, 2, 3, 4);

            Assert.Equal(r1.GetHashCode(), r2.GetHashCode());
        }

        /// <summary>
        ///     Tests that GetHashCode differs for distinct rects.
        /// </summary>
        [Fact]
        public void GetHashCode_DifferentRects_ReturnsDifferentValue()
        {
            IntRect r1 = new IntRect(1, 2, 3, 4);
            IntRect r2 = new IntRect(5, 6, 7, 8);

            Assert.NotEqual(r1.GetHashCode(), r2.GetHashCode());
        }

        /// <summary>
        ///     Tests that the equality operator behaves correctly.
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
        ///     Tests that the inequality operator behaves correctly.
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
        ///     Tests that the explicit cast to FloatRect preserves the values.
        /// </summary>
        [Fact]
        public void ExplicitCast_ToFloatRect_PreservesValues()
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
