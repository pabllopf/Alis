// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepFillAndBasinCoverageTests.cs
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
    ///     The dt sweep fill and basin coverage tests class
    /// </summary>
    public class DTSweepFillAndBasinCoverageTests
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
        ///     Tests that a constraint going from the bottom right to the upper left fills the right above edge region.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintUpLeft_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(2.0, 0.7),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 1.4),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(4.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[2], points[5]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 6);
        }

        /// <summary>
        ///     Tests that a horizontal constraint at the top with points below fills the right edge regions.
        /// </summary>
        [Fact]
        public void Triangulate_TopHorizontalConstraint_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.0),
                new TriangulationPoint(2.0, 0.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(4.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[9], points[8]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 8);
        }

        /// <summary>
        ///     Tests that a constraint going from the bottom left to the upper right fills the left edge regions.
        /// </summary>
        [Fact]
        public void Triangulate_LeftConstraintUpRight_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 0.4),
                new TriangulationPoint(2.0, 0.8),
                new TriangulationPoint(3.0, 1.2),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(4.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[6]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 5);
        }

        /// <summary>
        ///     Tests that a constraint with intermediate points below it fills both sides.
        /// </summary>
        [Fact]
        public void Triangulate_DiagonalConstraintWithBelowPoints_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.3),
                new TriangulationPoint(2.0, 0.6),
                new TriangulationPoint(3.0, 0.9),
                new TriangulationPoint(4.0, 1.2),
                new TriangulationPoint(5.0, 0.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(4.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[5], points[6]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 7);
        }
    }
}
