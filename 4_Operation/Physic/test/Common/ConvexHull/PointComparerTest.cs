// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PointComparerTest.cs
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
using Alis.Core.Physic.Common.ConvexHull;
using Xunit;

namespace Alis.Core.Physic.Test.Common.ConvexHull
{
    /// <summary>
    ///     The point comparer test class
    /// </summary>
    public class PointComparerTest
    {
        /// <summary>
        ///     Tests that compare should return negative when a x less than b x
        /// </summary>
        [Fact]
        public void Compare_ShouldReturnNegative_WhenAXLessThanBX()
        {
            PointComparer comparer = new PointComparer();
            Vector2F a = new Vector2F(1, 5);
            Vector2F b = new Vector2F(2, 5);
            
            int result = comparer.Compare(a, b);
            
            Assert.True(result < 0);
        }

        /// <summary>
        ///     Tests that compare should return positive when a x greater than b x
        /// </summary>
        [Fact]
        public void Compare_ShouldReturnPositive_WhenAXGreaterThanBX()
        {
            PointComparer comparer = new PointComparer();
            Vector2F a = new Vector2F(5, 5);
            Vector2F b = new Vector2F(2, 5);
            
            int result = comparer.Compare(a, b);
            
            Assert.True(result > 0);
        }

        /// <summary>
        ///     Tests that compare should use y when x values equal
        /// </summary>
        [Fact]
        public void Compare_ShouldUseY_WhenXValuesEqual()
        {
            PointComparer comparer = new PointComparer();
            Vector2F a = new Vector2F(5, 3);
            Vector2F b = new Vector2F(5, 7);
            
            int result = comparer.Compare(a, b);
            
            Assert.True(result < 0);
        }

        /// <summary>
        ///     Tests that compare should return zero for equal points
        /// </summary>
        [Fact]
        public void Compare_ShouldReturnZero_ForEqualPoints()
        {
            PointComparer comparer = new PointComparer();
            Vector2F a = new Vector2F(5, 10);
            Vector2F b = new Vector2F(5, 10);
            
            int result = comparer.Compare(a, b);
            
            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that compare should prioritize x over y
        /// </summary>
        [Fact]
        public void Compare_ShouldPrioritizeXOverY()
        {
            PointComparer comparer = new PointComparer();
            Vector2F a = new Vector2F(1, 100);
            Vector2F b = new Vector2F(2, 1);
            
            int result = comparer.Compare(a, b);
            
            Assert.True(result < 0); // Even though a.Y > b.Y, a.X < b.X determines result
        }

        /// <summary>
        ///     Tests that point comparer should inherit from comparer
        /// </summary>
        [Fact]
        public void PointComparer_ShouldInheritFromComparer()
        {
            PointComparer comparer = new PointComparer();
            
            Assert.IsAssignableFrom<System.Collections.Generic.Comparer<Vector2F>>(comparer);
        }

        /// <summary>
        ///     Tests that compare should handle negative coordinates
        /// </summary>
        [Fact]
        public void Compare_ShouldHandleNegativeCoordinates()
        {
            PointComparer comparer = new PointComparer();
            Vector2F a = new Vector2F(-5, -10);
            Vector2F b = new Vector2F(-3, -8);
            
            int result = comparer.Compare(a, b);
            
            Assert.True(result < 0);
        }

        /// <summary>
        ///     Tests that compare should handle zero coordinates
        /// </summary>
        [Fact]
        public void Compare_ShouldHandleZeroCoordinates()
        {
            PointComparer comparer = new PointComparer();
            Vector2F a = Vector2F.Zero;
            Vector2F b = new Vector2F(1, 1);
            
            int result = comparer.Compare(a, b);
            
            Assert.True(result < 0);
        }

        /// <summary>
        ///     Tests that compare should be consistent
        /// </summary>
        [Fact]
        public void Compare_ShouldBeConsistent()
        {
            PointComparer comparer = new PointComparer();
            Vector2F a = new Vector2F(3, 4);
            Vector2F b = new Vector2F(5, 6);
            
            int result1 = comparer.Compare(a, b);
            int result2 = comparer.Compare(a, b);
            
            Assert.Equal(result1, result2);
        }

        /// <summary>
        ///     Tests that compare should be transitive
        /// </summary>
        [Fact]
        public void Compare_ShouldBeTransitive()
        {
            PointComparer comparer = new PointComparer();
            Vector2F a = new Vector2F(1, 1);
            Vector2F b = new Vector2F(2, 2);
            Vector2F c = new Vector2F(3, 3);
            
            int ab = comparer.Compare(a, b);
            int bc = comparer.Compare(b, c);
            int ac = comparer.Compare(a, c);
            
            Assert.True(ab < 0);
            Assert.True(bc < 0);
            Assert.True(ac < 0);
        }
    }
}

