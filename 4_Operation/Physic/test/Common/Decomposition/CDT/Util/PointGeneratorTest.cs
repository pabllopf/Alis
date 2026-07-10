// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PointGeneratorTest.cs
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
using Alis.Core.Physic.Common.Decomposition.CDT.Util;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Util
{
    /// <summary>
    /// The point generator test class
    /// </summary>
    public class PointGeneratorTest
    {
        /// <summary>
        /// Tests that point generator type should be accessible
        /// </summary>
        [Fact]
        public void PointGenerator_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(PointGenerator));
        }

        /// <summary>
        /// Tests that UniformDistribution returns correct number of points
        /// </summary>
        [Fact]
        public void UniformDistribution_WithPositiveN_ReturnsCorrectCount()
        {
            List<TriangulationPoint> points = PointGenerator.UniformDistribution(10, 100.0);

            Assert.Equal(10, points.Count);
        }

        /// <summary>
        /// Tests that UniformDistribution with zero returns empty list
        /// </summary>
        [Fact]
        public void UniformDistribution_WithZeroN_ReturnsEmptyList()
        {
            List<TriangulationPoint> points = PointGenerator.UniformDistribution(0, 100.0);

            Assert.Empty(points);
        }

        /// <summary>
        /// Tests that UniformDistribution points are within scale range
        /// </summary>
        [Fact]
        public void UniformDistribution_PointsAreWithinScaleRange()
        {
            double scale = 100.0;
            List<TriangulationPoint> points = PointGenerator.UniformDistribution(100, scale);

            foreach (TriangulationPoint p in points)
            {
                Assert.InRange(p.X, -scale / 2, scale / 2);
                Assert.InRange(p.Y, -scale / 2, scale / 2);
            }
        }

        /// <summary>
        /// Tests that UniformDistribution generates different points
        /// </summary>
        [Fact]
        public void UniformDistribution_GeneratesDifferentPoints()
        {
            List<TriangulationPoint> points = PointGenerator.UniformDistribution(10, 100.0);

            Assert.Equal(10, points.Count);
        }

        /// <summary>
        /// Tests that UniformGrid returns correct number of points
        /// </summary>
        [Fact]
        public void UniformGrid_WithPositiveN_ReturnsCorrectCount()
        {
            int n = 5;
            List<TriangulationPoint> points = PointGenerator.UniformGrid(n, 100.0);

            Assert.Equal((n + 1) * (n + 1), points.Count);
        }

        /// <summary>
        /// Tests that UniformGrid with zero returns a single point
        /// </summary>
        [Fact]
        public void UniformGrid_WithZeroN_ReturnsSinglePoint()
        {
            List<TriangulationPoint> points = PointGenerator.UniformGrid(0, 100.0);

            Assert.Single(points);
        }

        /// <summary>
        /// Tests that UniformGrid points are within scale range
        /// </summary>
        [Fact]
        public void UniformGrid_PointsAreWithinScaleRange()
        {
            double scale = 100.0;
            int n = 5;
            List<TriangulationPoint> points = PointGenerator.UniformGrid(n, scale);

            foreach (TriangulationPoint p in points)
            {
                Assert.InRange(p.X, -scale / 2, scale / 2);
                Assert.InRange(p.Y, -scale / 2, scale / 2);
            }
        }

        /// <summary>
        /// Tests that UniformGrid points are ordered correctly
        /// </summary>
        [Fact]
        public void UniformGrid_PointsAreOrdered()
        {
            int n = 2;
            List<TriangulationPoint> points = PointGenerator.UniformGrid(n, 10.0);

            Assert.Equal((n + 1) * (n + 1), points.Count);
        }
    }
}
