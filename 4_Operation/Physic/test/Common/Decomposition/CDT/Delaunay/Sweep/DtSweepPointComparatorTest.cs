// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DtSweepPointComparatorTest.cs
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

using System.Collections.Generic;
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep point comparator test class
    /// </summary>
    public class DtSweepPointComparatorTest
    {
        /// <summary>
        ///     Tests that compare should return negative when p1 y less than p2 y
        /// </summary>
        [Fact]
        public void Compare_ShouldReturnNegative_WhenP1YLessThanP2Y()
        {
            DtSweepPointComparator comparator = new DtSweepPointComparator();
            TriangulationPoint p1 = new TriangulationPoint(5, 5);
            TriangulationPoint p2 = new TriangulationPoint(5, 10);
            
            int result = comparator.Compare(p1, p2);
            
            Assert.Equal(-1, result);
        }

        /// <summary>
        ///     Tests that compare should return positive when p1 y greater than p2 y
        /// </summary>
        [Fact]
        public void Compare_ShouldReturnPositive_WhenP1YGreaterThanP2Y()
        {
            DtSweepPointComparator comparator = new DtSweepPointComparator();
            TriangulationPoint p1 = new TriangulationPoint(5, 15);
            TriangulationPoint p2 = new TriangulationPoint(5, 10);
            
            int result = comparator.Compare(p1, p2);
            
            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that compare should return negative when y equal and p1 x less than p2 x
        /// </summary>
        [Fact]
        public void Compare_ShouldReturnNegative_WhenYEqualAndP1XLessThanP2X()
        {
            DtSweepPointComparator comparator = new DtSweepPointComparator();
            TriangulationPoint p1 = new TriangulationPoint(5, 10);
            TriangulationPoint p2 = new TriangulationPoint(10, 10);
            
            int result = comparator.Compare(p1, p2);
            
            Assert.Equal(-1, result);
        }

        /// <summary>
        ///     Tests that compare should return positive when y equal and p1 x greater than p2 x
        /// </summary>
        [Fact]
        public void Compare_ShouldReturnPositive_WhenYEqualAndP1XGreaterThanP2X()
        {
            DtSweepPointComparator comparator = new DtSweepPointComparator();
            TriangulationPoint p1 = new TriangulationPoint(15, 10);
            TriangulationPoint p2 = new TriangulationPoint(10, 10);
            
            int result = comparator.Compare(p1, p2);
            
            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that compare should return zero when points equal
        /// </summary>
        [Fact]
        public void Compare_ShouldReturnZero_WhenPointsEqual()
        {
            DtSweepPointComparator comparator = new DtSweepPointComparator();
            TriangulationPoint p1 = new TriangulationPoint(10, 10);
            TriangulationPoint p2 = new TriangulationPoint(10, 10);
            
            int result = comparator.Compare(p1, p2);
            
            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that comparator should implement i comparer
        /// </summary>
        [Fact]
        public void Comparator_ShouldImplementIComparer()
        {
            DtSweepPointComparator comparator = new DtSweepPointComparator();
            
            Assert.IsAssignableFrom<IComparer<TriangulationPoint>>(comparator);
        }

        /// <summary>
        ///     Tests that compare should prioritize y coordinate
        /// </summary>
        [Fact]
        public void Compare_ShouldPrioritizeYCoordinate()
        {
            DtSweepPointComparator comparator = new DtSweepPointComparator();
            TriangulationPoint p1 = new TriangulationPoint(100, 5);
            TriangulationPoint p2 = new TriangulationPoint(1, 10);
            
            int result = comparator.Compare(p1, p2);
            
            Assert.Equal(-1, result);
        }

        /// <summary>
        ///     Tests that compare should handle negative coordinates
        /// </summary>
        [Fact]
        public void Compare_ShouldHandleNegativeCoordinates()
        {
            DtSweepPointComparator comparator = new DtSweepPointComparator();
            TriangulationPoint p1 = new TriangulationPoint(-10, -10);
            TriangulationPoint p2 = new TriangulationPoint(-5, -5);
            
            int result = comparator.Compare(p1, p2);
            
            Assert.Equal(-1, result);
        }

        /// <summary>
        ///     Tests that compare should work with sorting algorithms
        /// </summary>
        [Fact]
        public void Compare_ShouldWorkWithSortingAlgorithms()
        {
            DtSweepPointComparator comparator = new DtSweepPointComparator();
            TriangulationPoint[] points = new[]
            {
                new TriangulationPoint(5, 10),
                new TriangulationPoint(2, 5),
                new TriangulationPoint(8, 15),
                new TriangulationPoint(1, 3)
            };
            
            System.Array.Sort(points, comparator);
            
            Assert.Equal(3, points[0].Y);
            Assert.Equal(5, points[1].Y);
            Assert.Equal(10, points[2].Y);
            Assert.Equal(15, points[3].Y);
        }

        /// <summary>
        ///     Tests that compare should be consistent
        /// </summary>
        [Fact]
        public void Compare_ShouldBeConsistent()
        {
            DtSweepPointComparator comparator = new DtSweepPointComparator();
            TriangulationPoint p1 = new TriangulationPoint(5, 5);
            TriangulationPoint p2 = new TriangulationPoint(10, 10);
            
            int result1 = comparator.Compare(p1, p2);
            int result2 = comparator.Compare(p1, p2);
            
            Assert.Equal(result1, result2);
        }

        /// <summary>
        ///     Tests that compare should be antisymmetric
        /// </summary>
        [Fact]
        public void Compare_ShouldBeAntisymmetric()
        {
            DtSweepPointComparator comparator = new DtSweepPointComparator();
            TriangulationPoint p1 = new TriangulationPoint(5, 5);
            TriangulationPoint p2 = new TriangulationPoint(10, 10);
            
            int resultAB = comparator.Compare(p1, p2);
            int resultBA = comparator.Compare(p2, p1);
            
            Assert.Equal(-resultAB, resultBA);
        }

        /// <summary>
        ///     Tests that compare should handle zero coordinates
        /// </summary>
        [Fact]
        public void Compare_ShouldHandleZeroCoordinates()
        {
            DtSweepPointComparator comparator = new DtSweepPointComparator();
            TriangulationPoint p1 = new TriangulationPoint(0, 0);
            TriangulationPoint p2 = new TriangulationPoint(0, 0);
            
            int result = comparator.Compare(p1, p2);
            
            Assert.Equal(0, result);
        }
    }
}

