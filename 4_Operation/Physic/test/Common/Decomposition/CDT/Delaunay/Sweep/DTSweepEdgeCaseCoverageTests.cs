// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepEdgeCaseCoverageTests.cs
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
using Alis.Core.Physic.Common.Decomposition.CDT.Sets;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep edge case coverage tests class
    /// </summary>
    public class DTSweepEdgeCaseCoverageTests
    {
        /// <summary>
        ///     Runs the triangulation on the given point set and asserts a valid result.
        /// </summary>
        /// <param name="points">The points</param>
        /// <returns>The resulting triangle count</returns>
        private static int RunPointSet(params TriangulationPoint[] points)
        {
            PointSet pointSet = new PointSet(new List<TriangulationPoint>(points));
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(pointSet.GetTriangles);
            return pointSet.GetTriangles.Count;
        }

        /// <summary>
        ///     Tests that a plain square point set triangulates into a convex hull.
        /// </summary>
        [Fact]
        public void Triangulate_SquarePointSet_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(0.0, 2.0));

            Assert.True(count >= 2);
        }

        /// <summary>
        ///     Tests that a pentagon point set triangulates into a convex hull.
        /// </summary>
        [Fact]
        public void Triangulate_PentagonPointSet_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(3.0, 1.5),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(0.0, 1.0));

            Assert.True(count >= 3);
        }

        /// <summary>
        ///     Tests that a hexagon point set triangulates into a convex hull.
        /// </summary>
        [Fact]
        public void Triangulate_HexagonPointSet_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(1.0, 3.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(0.0, 1.0));

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a diamond point set with a center point triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_DiamondWithCenter_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(2.0, 4.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(2.0, 2.0));

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a three by three grid of points triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_ThreeByThreeGrid_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(0.0, 1.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 2.0));

            Assert.True(count >= 8);
        }

        /// <summary>
        ///     Tests that a four by four grid of points triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_FourByFourGrid_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>();
            for (int x = 0; x < 4; x++)
            {
                for (int y = 0; y < 4; y++)
                {
                    points.Add(new TriangulationPoint(x, y));
                }
            }

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.True(pointSet.GetTriangles.Count >= 14);
        }

        /// <summary>
        ///     Tests that a u shaped point set triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_UShapePointSet_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(3.0, 2.0),
                new TriangulationPoint(3.0, 3.0),
                new TriangulationPoint(0.0, 3.0));

            Assert.True(count >= 6);
        }

        /// <summary>
        ///     Tests that two horizontal rows of points triangulate.
        /// </summary>
        [Fact]
        public void Triangulate_TwoHorizontalRows_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(0.0, 1.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(2.0, 1.0));

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a comb shaped point set triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_CombShapePointSet_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(4.0, 4.0),
                new TriangulationPoint(3.0, 4.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(2.0, 4.0),
                new TriangulationPoint(1.0, 4.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(0.0, 1.0));

            Assert.True(count >= 8);
        }

        /// <summary>
        ///     Tests that a parabola shaped point set triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_ParabolaPointSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>();
            for (int x = 0; x <= 8; x++)
            {
                points.Add(new TriangulationPoint(x, x * x / 8.0));
            }

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.True(pointSet.GetTriangles.Count >= 6);
        }

        /// <summary>
        ///     Tests that a circular point set triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_CircularPointSet_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(0.707, 0.707),
                new TriangulationPoint(0.0, 1.0),
                new TriangulationPoint(-0.707, 0.707),
                new TriangulationPoint(-1.0, 0.0),
                new TriangulationPoint(-0.707, -0.707),
                new TriangulationPoint(0.0, -1.0),
                new TriangulationPoint(0.707, -0.707));

            Assert.True(count >= 6);
        }

        /// <summary>
        ///     Tests that a skewed grid of points triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_SkewedGridPointSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>();
            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    points.Add(new TriangulationPoint(x + 0.1 * y, y + 0.1 * x));
                }
            }

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.True(pointSet.GetTriangles.Count >= 24);
        }

        /// <summary>
        ///     Tests that a repeated y coordinate point set triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_RepeatedYCoordinates_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(0.0, 1.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(6.0, 1.0),
                new TriangulationPoint(1.0, 3.0),
                new TriangulationPoint(4.0, 3.0),
                new TriangulationPoint(2.0, 5.0),
                new TriangulationPoint(5.0, 5.0));

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a wide top row point set triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_WideTopRowPointSet_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(3.0, 2.0),
                new TriangulationPoint(4.0, 2.0));

            Assert.True(count >= 8);
        }

        /// <summary>
        ///     Tests that a wide top row with a rightmost peak point set triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_RightmostPeakPointSet_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(3.0, 2.0),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(3.5, 3.0));

            Assert.True(count >= 9);
        }

        /// <summary>
        ///     Tests that a point set with a plateau at the top triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_TopPlateauPointSet_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(3.0, 2.0));

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a point set with an extreme right point triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_ExtremeRightPointPointSet_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(1.0, 3.0));

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a point set with a descending right side triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_DescendingRightSidePointSet_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(3.0, 3.0));

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a point set with a deep pit on the right side triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_PitOnRightSidePointSet_ProducesTriangles()
        {
            int count = RunPointSet(
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 3.0),
                new TriangulationPoint(3.0, 2.0),
                new TriangulationPoint(2.0, 4.0));

            Assert.True(count >= 7);
        }
    }
}
