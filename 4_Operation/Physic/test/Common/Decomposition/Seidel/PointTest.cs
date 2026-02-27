// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PointTest.cs
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

using Alis.Core.Physic.Common.Decomposition.Seidel;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The point test class
    /// </summary>
    public class PointTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with coordinates
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithCoordinates()
        {
            float x = 5.0f;
            float y = 10.0f;
            
            Point point = new Point(x, y);
            
            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
            Assert.Null(point.Next);
            Assert.Null(point.Prev);
        }

        /// <summary>
        ///     Tests that operator minus should subtract points correctly
        /// </summary>
        [Fact]
        public void OperatorMinus_ShouldSubtractPointsCorrectly()
        {
            Point p1 = new Point(10, 20);
            Point p2 = new Point(3, 5);
            
            Point result = p1 - p2;
            
            Assert.Equal(7, result.X);
            Assert.Equal(15, result.Y);
        }

        /// <summary>
        ///     Tests that operator plus should add points correctly
        /// </summary>
        [Fact]
        public void OperatorPlus_ShouldAddPointsCorrectly()
        {
            Point p1 = new Point(5, 10);
            Point p2 = new Point(3, 7);
            
            Point result = p1 + p2;
            
            Assert.Equal(8, result.X);
            Assert.Equal(17, result.Y);
        }

        /// <summary>
        ///     Tests that operator minus with float should subtract from both coordinates
        /// </summary>
        [Fact]
        public void OperatorMinusWithFloat_ShouldSubtractFromBothCoordinates()
        {
            Point p = new Point(10, 20);
            
            Point result = p - 5.0f;
            
            Assert.Equal(5, result.X);
            Assert.Equal(15, result.Y);
        }

        /// <summary>
        ///     Tests that operator plus with float should add to both coordinates
        /// </summary>
        [Fact]
        public void OperatorPlusWithFloat_ShouldAddToBothCoordinates()
        {
            Point p = new Point(10, 20);
            
            Point result = p + 5.0f;
            
            Assert.Equal(15, result.X);
            Assert.Equal(25, result.Y);
        }

        /// <summary>
        ///     Tests that cross should calculate cross product
        /// </summary>
        [Fact]
        public void Cross_ShouldCalculateCrossProduct()
        {
            Point p1 = new Point(1, 0);
            Point p2 = new Point(0, 1);
            
            float cross = p1.Cross(p2);
            
            Assert.Equal(1.0f, cross);
        }

        /// <summary>
        ///     Tests that dot should calculate dot product
        /// </summary>
        [Fact]
        public void Dot_ShouldCalculateDotProduct()
        {
            Point p1 = new Point(3, 4);
            Point p2 = new Point(2, 1);
            
            float dot = p1.Dot(p2);
            
            Assert.Equal(10.0f, dot);
        }

        /// <summary>
        ///     Tests that neq should return true for different points
        /// </summary>
        [Fact]
        public void Neq_ShouldReturnTrue_ForDifferentPoints()
        {
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 2);
            
            bool notEqual = p1.Neq(p2);
            
            Assert.True(notEqual);
        }

        /// <summary>
        ///     Tests that neq should return false for same points
        /// </summary>
        [Fact]
        public void Neq_ShouldReturnFalse_ForSamePoints()
        {
            Point p1 = new Point(1, 1);
            Point p2 = new Point(1, 1);
            
            bool notEqual = p1.Neq(p2);
            
            Assert.False(notEqual);
        }

        /// <summary>
        ///     Tests that orient2d should calculate orientation
        /// </summary>
        [Fact]
        public void Orient2D_ShouldCalculateOrientation()
        {
            Point pa = new Point(0, 0);
            Point pb = new Point(1, 0);
            Point pc = new Point(0, 1);
            
            float orientation = pa.Orient2D(pb, pc);
            
            Assert.NotEqual(0, orientation);
        }

        /// <summary>
        ///     Tests that next and prev should support linked list structure
        /// </summary>
        [Fact]
        public void NextAndPrev_ShouldSupportLinkedListStructure()
        {
            Point p1 = new Point(0, 0);
            Point p2 = new Point(1, 1);
            Point p3 = new Point(2, 2);
            
            p1.Next = p2;
            p2.Prev = p1;
            p2.Next = p3;
            p3.Prev = p2;
            
            Assert.Equal(p2, p1.Next);
            Assert.Equal(p1, p2.Prev);
            Assert.Equal(p3, p2.Next);
            Assert.Equal(p2, p3.Prev);
        }

        /// <summary>
        ///     Tests that point should handle zero cross product
        /// </summary>
        [Fact]
        public void Point_ShouldHandleZeroCrossProduct()
        {
            Point p1 = new Point(1, 1);
            Point p2 = new Point(2, 2);
            
            float cross = p1.Cross(p2);
            
            Assert.Equal(0.0f, cross);
        }

        /// <summary>
        ///     Tests that point should handle negative coordinates in operations
        /// </summary>
        [Fact]
        public void Point_ShouldHandleNegativeCoordinatesInOperations()
        {
            Point p1 = new Point(-5, -10);
            Point p2 = new Point(3, 7);
            
            Point result = p1 + p2;
            
            Assert.Equal(-2, result.X);
            Assert.Equal(-3, result.Y);
        }
    }
}

