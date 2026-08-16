// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepRemainingCoverageTests.cs
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

using System;
using System.Collections.Generic;
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Alis.Core.Physic.Common.Decomposition.CDT.Sets;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep remaining coverage tests class
    /// </summary>
    public class DTSweepRemainingCoverageTests
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
        ///     Tests that a constraint above a right deep valley triggers the right below fill.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintAboveDeepValley_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(5.0, 2.0),
                new TriangulationPoint(3.0, 1.6),
                new TriangulationPoint(3.1, 1.55),
                new TriangulationPoint(6.0, 2.5),
                new TriangulationPoint(0.0, 3.0),
                new TriangulationPoint(5.0, 3.0),
                new TriangulationPoint(0.0, 4.0),
                new TriangulationPoint(5.0, 4.0),
                new TriangulationPoint(6.0, 4.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[1], points[5]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 8);
        }

        /// <summary>
        ///     Tests that a constraint above a deep right pit triggers the right below fill.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintAboveDeepPit_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(6.0, 2.0),
                new TriangulationPoint(5.0, 0.8666666666666665),
                new TriangulationPoint(5.1, 0.8166666666666666),
                new TriangulationPoint(7.0, 2.5),
                new TriangulationPoint(0.0, 3.0),
                new TriangulationPoint(6.0, 3.0),
                new TriangulationPoint(0.0, 4.0),
                new TriangulationPoint(6.0, 4.0),
                new TriangulationPoint(7.0, 4.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[1], points[5]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 8);
        }

        /// <summary>
        ///     Tests that a constraint above a wide right valley triggers the right below fill.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintAboveWideValley_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(5.0, 2.0),
                new TriangulationPoint(4.0, 1.4),
                new TriangulationPoint(4.4, 1.15),
                new TriangulationPoint(6.0, 2.5),
                new TriangulationPoint(0.0, 3.0),
                new TriangulationPoint(5.0, 3.0),
                new TriangulationPoint(0.0, 4.0),
                new TriangulationPoint(5.0, 4.0),
                new TriangulationPoint(6.0, 4.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[1], points[5]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 8);
        }

        /// <summary>
        ///     Tests that a constraint above a far right valley triggers the right below fill.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintAboveFarValley_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(7.0, 2.0),
                new TriangulationPoint(4.5, 1.5571428571428572),
                new TriangulationPoint(4.9, 1.407142857142857),
                new TriangulationPoint(8.0, 2.5),
                new TriangulationPoint(0.0, 3.0),
                new TriangulationPoint(7.0, 3.0),
                new TriangulationPoint(0.0, 4.0),
                new TriangulationPoint(7.0, 4.0),
                new TriangulationPoint(8.0, 4.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[1], points[5]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 8);
        }

        /// <summary>
        ///     Runs the triangulation on the given point set and asserts a valid result.
        /// </summary>
        /// <param name="points">The points</param>
        /// <returns>The resulting triangle count</returns>
        private static int RunPointSet(List<TriangulationPoint> points)
        {
            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);
            Assert.NotNull(pointSet.GetTriangles);
            return pointSet.GetTriangles.Count;
        }

        /// <summary>
        ///     Tests that a deep flat valley point set triggers the large hole stop.
        /// </summary>
        [Fact]
        public void Triangulate_DeepFlatValleyPointSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, -3.0),
                new TriangulationPoint(0.0, 4.0),
                new TriangulationPoint(3.0, -2.4),
                new TriangulationPoint(4.0, -2.4),
                new TriangulationPoint(5.0, -2.4),
                new TriangulationPoint(6.0, -1.8),
                new TriangulationPoint(0.0, 5.0),
                new TriangulationPoint(7.0, 5.0),
                new TriangulationPoint(8.0, 5.0)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 7);
        }

        /// <summary>
        ///     Tests that a deep stepped valley point set triggers the large hole stop.
        /// </summary>
        [Fact]
        public void Triangulate_DeepSteppedValleyPointSet_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, -3.0),
                new TriangulationPoint(0.0, 4.0),
                new TriangulationPoint(3.0, -2.4),
                new TriangulationPoint(4.0, -1.8),
                new TriangulationPoint(5.0, -1.2),
                new TriangulationPoint(6.0, -0.6),
                new TriangulationPoint(0.0, 5.0),
                new TriangulationPoint(7.0, 5.0),
                new TriangulationPoint(8.0, 5.0)
            };

            int count = RunPointSet(points);

            Assert.True(count >= 7);
        }

        /// <summary>
        ///     Tests that a constraint passing through an interior point triangulates and skips the edge.
        /// </summary>
        [Fact]
        public void Triangulate_ConstraintThroughInteriorPoints_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(6.0, 6.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(4.0, 4.0),
                new TriangulationPoint(1.0, 3.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(0.0, 6.0),
                new TriangulationPoint(6.0, 0.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[1]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 6);
        }

        /// <summary>
        ///     Tests that crossing diagonal constraints through an interior point triangulate.
        /// </summary>
        [Fact]
        public void Triangulate_CrossingDiagonalsThroughPoint_ThrowsIntersectingConstraints()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(3.0, 3.0),
                new TriangulationPoint(0.0, 3.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 1.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[2],
                points[1], points[3]
            };

            ConstrainedPointSet cps = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(cps);

            Assert.Throws<InvalidOperationException>(() => DtSweep.Triangulate(tcx));
        }

        /// <summary>
        ///     Tests that a constraint along a row of collinear points triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_ConstraintAlongCollinearRow_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(0.0, 4.0),
                new TriangulationPoint(4.0, 4.0),
                new TriangulationPoint(2.0, 4.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[1]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }
    }
}
