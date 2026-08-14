// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FloatRectRemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     The float rect remaining coverage tests class
    /// </summary>
    public class FloatRectRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor assigns fields
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_AssignsFields()
        {
            FloatRect rect = new FloatRect(1, 2, 3, 4);

            Assert.Equal(1, rect.Left);
            Assert.Equal(2, rect.Top);
            Assert.Equal(3, rect.Width);
            Assert.Equal(4, rect.Height);
        }

        /// <summary>
        ///     Tests that constructor from vector 2 f assigns fields
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Constructor_FromVector2F_AssignsFields()
        {
            FloatRect rect = new FloatRect(new Vector2F(1, 2), new Vector2F(3, 4));

            Assert.Equal(1, rect.Left);
            Assert.Equal(2, rect.Top);
            Assert.Equal(3, rect.Width);
            Assert.Equal(4, rect.Height);
        }

        /// <summary>
        ///     Tests that contains with point inside returns true
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Contains_WithPointInside_ReturnsTrue()
        {
            FloatRect rect = new FloatRect(0, 0, 10, 10);

            Assert.True(rect.Contains(5, 5));
        }

        /// <summary>
        ///     Tests that contains with point outside returns false
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Contains_WithPointOutside_ReturnsFalse()
        {
            FloatRect rect = new FloatRect(0, 0, 10, 10);

            Assert.False(rect.Contains(15, 5));
        }

        /// <summary>
        ///     Tests that contains with point on right edge returns false
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Contains_WithPointOnRightEdge_ReturnsFalse()
        {
            FloatRect rect = new FloatRect(0, 0, 10, 10);

            Assert.False(rect.Contains(10, 5));
        }

        /// <summary>
        ///     Tests that contains with point on bottom edge returns false
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Contains_WithPointOnBottomEdge_ReturnsFalse()
        {
            FloatRect rect = new FloatRect(0, 0, 10, 10);

            Assert.False(rect.Contains(5, 10));
        }

        /// <summary>
        ///     Tests that contains with negative width handles min max
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Contains_WithNegativeWidth_HandlesMinMax()
        {
            FloatRect rect = new FloatRect(10, 0, -10, 10);

            Assert.True(rect.Contains(5, 5));
            Assert.False(rect.Contains(-1, 5));
        }

        /// <summary>
        ///     Tests that contains with negative height handles min max
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Contains_WithNegativeHeight_HandlesMinMax()
        {
            FloatRect rect = new FloatRect(0, 10, 10, -10);

            Assert.True(rect.Contains(5, 5));
            Assert.False(rect.Contains(5, -1));
        }

        /// <summary>
        ///     Tests that intersects with overlapping returns true
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Intersects_WithOverlapping_ReturnsTrue()
        {
            FloatRect r1 = new FloatRect(0, 0, 10, 10);
            FloatRect r2 = new FloatRect(5, 5, 10, 10);

            Assert.True(r1.Intersects(r2));
        }

        /// <summary>
        ///     Tests that intersects with non overlapping returns false
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Intersects_WithNonOverlapping_ReturnsFalse()
        {
            FloatRect r1 = new FloatRect(0, 0, 10, 10);
            FloatRect r2 = new FloatRect(20, 20, 5, 5);

            Assert.False(r1.Intersects(r2));
        }

        /// <summary>
        ///     Tests that intersects with touching edges returns false
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Intersects_WithTouchingEdges_ReturnsFalse()
        {
            FloatRect r1 = new FloatRect(0, 0, 10, 10);
            FloatRect r2 = new FloatRect(10, 0, 5, 5);

            Assert.False(r1.Intersects(r2));
        }

        /// <summary>
        ///     Tests that intersects with overlap output fills overlap
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Intersects_WithOverlapOutput_FillsOverlap()
        {
            FloatRect r1 = new FloatRect(0, 0, 10, 10);
            FloatRect r2 = new FloatRect(5, 5, 10, 10);

            bool result = r1.Intersects(r2, out FloatRect overlap);

            Assert.True(result);
            Assert.Equal(5, overlap.Left);
            Assert.Equal(5, overlap.Top);
            Assert.Equal(5, overlap.Width);
            Assert.Equal(5, overlap.Height);
        }

        /// <summary>
        ///     Tests that intersects with no overlap zeroes output
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Intersects_WithNoOverlap_ZeroesOutput()
        {
            FloatRect r1 = new FloatRect(0, 0, 10, 10);
            FloatRect r2 = new FloatRect(20, 20, 5, 5);

            bool result = r1.Intersects(r2, out FloatRect overlap);

            Assert.False(result);
            Assert.Equal(0, overlap.Left);
            Assert.Equal(0, overlap.Top);
            Assert.Equal(0, overlap.Width);
            Assert.Equal(0, overlap.Height);
        }

        /// <summary>
        ///     Tests that intersects with negative dimensions handles min max
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Intersects_WithNegativeDimensions_HandlesMinMax()
        {
            FloatRect r1 = new FloatRect(10, 10, -10, -10);
            FloatRect r2 = new FloatRect(5, 5, 10, 10);

            bool result = r1.Intersects(r2, out FloatRect overlap);

            Assert.True(result);
            Assert.Equal(5, overlap.Left);
            Assert.Equal(5, overlap.Top);
            Assert.Equal(5, overlap.Width);
            Assert.Equal(5, overlap.Height);
        }

        /// <summary>
        ///     Tests that to string returns expected format
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ToString_ReturnsExpectedFormat()
        {
            FloatRect rect = new FloatRect(1, 2, 3, 4);

            string str = rect.ToString();

            Assert.Contains("Left(1)", str);
            Assert.Contains("Top(2)", str);
            Assert.Contains("Width(3)", str);
            Assert.Contains("Height(4)", str);
        }

        /// <summary>
        ///     Tests that equals with same rect returns true
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Equals_WithSameRect_ReturnsTrue()
        {
            FloatRect r1 = new FloatRect(1, 2, 3, 4);
            FloatRect r2 = new FloatRect(1, 2, 3, 4);

            Assert.True(r1.Equals(r2));
        }

        /// <summary>
        ///     Tests that equals with different rect returns false
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Equals_WithDifferentRect_ReturnsFalse()
        {
            FloatRect r1 = new FloatRect(1, 2, 3, 4);
            FloatRect r2 = new FloatRect(5, 2, 3, 4);

            Assert.False(r1.Equals(r2));
        }

        /// <summary>
        ///     Tests that equals with boxed rect returns true
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Equals_WithBoxedRect_ReturnsTrue()
        {
            FloatRect rect = new FloatRect(1, 2, 3, 4);
            object boxed = rect;

            Assert.True(rect.Equals(boxed));
        }

        /// <summary>
        ///     Tests that equals with non rect object returns false
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Equals_WithNonRectObject_ReturnsFalse()
        {
            FloatRect rect = new FloatRect(1, 2, 3, 4);

            Assert.False(rect.Equals("not a rect"));
            Assert.False(rect.Equals(null));
        }

        /// <summary>
        ///     Tests that equality operator returns true for equal rects
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void EqualityOperator_WithEqualRects_ReturnsTrue()
        {
            FloatRect r1 = new FloatRect(1, 2, 3, 4);
            FloatRect r2 = new FloatRect(1, 2, 3, 4);

            Assert.True(r1 == r2);
        }

        /// <summary>
        ///     Tests that inequality operator returns true for different rects
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void InequalityOperator_WithDifferentRects_ReturnsTrue()
        {
            FloatRect r1 = new FloatRect(1, 2, 3, 4);
            FloatRect r2 = new FloatRect(5, 2, 3, 4);

            Assert.True(r1 != r2);
        }

        /// <summary>
        ///     Tests that get hash code is deterministic for equal rects
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void GetHashCode_IsDeterministic()
        {
            FloatRect r1 = new FloatRect(1, 2, 3, 4);
            FloatRect r2 = new FloatRect(1, 2, 3, 4);

            Assert.Equal(r1.GetHashCode(), r2.GetHashCode());
        }

        /// <summary>
        ///     Tests that explicit cast to int rect truncates values
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void ExplicitCast_ToIntRect_TruncatesValues()
        {
            FloatRect rect = new FloatRect(1.5f, 2.5f, 3.5f, 4.5f);

            IntRect intRect = (IntRect) rect;

            Assert.Equal(1, intRect.Left);
            Assert.Equal(2, intRect.Top);
            Assert.Equal(3, intRect.Width);
            Assert.Equal(4, intRect.Height);
        }
    }
}
