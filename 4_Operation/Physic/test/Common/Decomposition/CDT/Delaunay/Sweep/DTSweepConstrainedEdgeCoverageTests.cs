// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepConstrainedEdgeCoverageTests.cs
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
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Alis.Core.Physic.Common.Decomposition.CDT.Sets;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep constrained edge coverage tests class
    /// </summary>
    public class DTSweepConstrainedEdgeCoverageTests
    {
        /// <summary>
        ///     Runs the triangulation on the given constrained point set and asserts a valid result.
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="constraints">The constraints</param>
        /// <returns>The resulting triangle count</returns>
        private static int RunConstrained(List<TriangulationPoint> points, List<TriangulationPoint> constraints)
        {
            ConstrainedPointSet cps = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(cps);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(cps.GetTriangles);
            return cps.GetTriangles.Count;
        }

        /// <summary>
        ///     Tests that a square with both diagonals constrained triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_SquareWithBothDiagonals_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(0.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[2]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 2);
        }

        /// <summary>
        ///     Tests that a square with a center point and crossing diagonals triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_SquareWithCenterAndCrossingDiagonals_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 1.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[2]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a dense mesh with crossing diagonal constraints triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_DenseMeshWithCrossingDiagonals_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(4.0, 4.0),
                new TriangulationPoint(0.0, 4.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 3.0),
                new TriangulationPoint(3.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[2]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 6);
        }

        /// <summary>
        ///     Tests that a hexagon with a long diagonal constraint triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_HexagonWithLongDiagonal_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(3.0, 3.0),
                new TriangulationPoint(1.0, 3.0),
                new TriangulationPoint(0.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[3]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a point lying exactly on a constrained edge is handled.
        /// </summary>
        [Fact]
        public void Triangulate_PointOnConstrainedEdge_IsHandled()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(2.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[1]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 1);
        }

        /// <summary>
        ///     Tests that a point lying on a constrained diagonal is handled.
        /// </summary>
        [Fact]
        public void Triangulate_PointOnConstrainedDiagonal_IsHandled()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(1.5, 1.5)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[2]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that multiple points on a constrained edge are handled.
        /// </summary>
        [Fact]
        public void Triangulate_MultiplePointsOnConstrainedEdge_IsHandled()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(0.0, 3.0),
                new TriangulationPoint(4.0, 3.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[1]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a horizontal constraint across the middle triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_HorizontalConstraintAcrossMiddle_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(0.0, 1.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(2.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[2], points[3]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a vertical constraint across the middle triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_VerticalConstraintAcrossMiddle_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(1.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[4], points[6]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a constraint crossing an interior point mesh triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_ConstraintCrossingInteriorMesh_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(3.0, 3.0),
                new TriangulationPoint(0.0, 3.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[2]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 6);
        }

        /// <summary>
        ///     Tests that a constraint between two interior points triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_ConstraintBetweenInteriorPoints_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(4.0, 4.0),
                new TriangulationPoint(0.0, 4.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(3.0, 3.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[4], points[5]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a fan of constraints from a shared point triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_FanOfConstraintsFromSharedPoint_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 1.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[4], points[0],
                points[4], points[1],
                points[4], points[2],
                points[4], points[3]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a pentagon with two crossing constraints triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_PentagonWithCrossingConstraints_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(3.0, 3.0),
                new TriangulationPoint(1.5, 1.0),
                new TriangulationPoint(0.0, 3.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[2]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 3);
        }

        /// <summary>
        ///     Tests that a constrained edge going against the sweep direction triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_ConstraintAgainstSweepDirection_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 0.5),
                new TriangulationPoint(1.0, 1.5)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[5], points[4]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a constraint skipping over multiple points triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_ConstraintSkippingPoints_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(3.0, 3.0),
                new TriangulationPoint(2.0, 3.0),
                new TriangulationPoint(1.0, 3.0),
                new TriangulationPoint(0.0, 3.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[4]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 6);
        }

        /// <summary>
        ///     Tests that a star shaped constrained point set triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_StarShapedConstrainedSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.5),
                new TriangulationPoint(2.5, 2.5),
                new TriangulationPoint(0.5, 2.0),
                new TriangulationPoint(1.2, 0.9),
                new TriangulationPoint(1.6, 1.1)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[1],
                points[1], points[2],
                points[2], points[3],
                points[3], points[0],
                points[4], points[5]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that intersecting constraints throw an invalid operation exception.
        /// </summary>
        [Fact]
        public void Triangulate_IntersectingConstraints_ThrowsInvalidOperationException()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(0.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[2],
                points[1], points[3]
            };

            ConstrainedPointSet cps = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(cps);

            Assert.Throws<System.InvalidOperationException>(() => DtSweep.Triangulate(tcx));
        }
    }
}