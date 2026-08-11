// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepFillChainFinalCoverageTests.cs
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
    ///     The dt sweep fill chain final coverage tests class
    /// </summary>
    public class DTSweepFillChainFinalCoverageTests
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
        ///     Tests that a left constraint with a descending front exercises the convex fill chain.
        /// </summary>
        [Fact]
        public void Triangulate_LeftConstraintWithDescendingFront_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, -1.5),
                new TriangulationPoint(2.0, -0.6),
                new TriangulationPoint(3.0, 0.7),
                new TriangulationPoint(4.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[5]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a left constraint with a deep descending front exercises the walk around branch.
        /// </summary>
        [Fact]
        public void Triangulate_LeftConstraintWithDeepDescendingFront_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, -3.0),
                new TriangulationPoint(2.0, -3.0),
                new TriangulationPoint(3.0, -3.0),
                new TriangulationPoint(4.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[5]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a left constraint with an ascending front exercises the recursive concave fill.
        /// </summary>
        [Fact]
        public void Triangulate_LeftConstraintWithAscendingFront_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 0.3),
                new TriangulationPoint(2.0, 0.6),
                new TriangulationPoint(3.0, 0.9),
                new TriangulationPoint(4.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[5]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a right constraint with an alternating front exercises the clockwise walk around branch.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintWithAlternatingFront_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(1.0, 0.5),
                new TriangulationPoint(2.0, -0.5),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(0.0, 1.5),
                new TriangulationPoint(3.0, 1.5)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[1], points[5]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a left constraint with a wavy front exercises the recursive convex fill.
        /// </summary>
        [Fact]
        public void Triangulate_LeftConstraintWithWavyFront_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, -0.6),
                new TriangulationPoint(2.0, 0.4),
                new TriangulationPoint(3.0, 1.2),
                new TriangulationPoint(5.0, -4.0),
                new TriangulationPoint(4.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[6]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a grid with a point exactly on the constraint diagonal is triangulated.
        /// </summary>
        [Fact]
        public void Triangulate_GridWithPointOnConstraintDiagonal_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>();
            for (int x = 0; x <= 6; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    points.Add(new TriangulationPoint(x, y));
                }
            }

            points.Add(new TriangulationPoint(1.0, 1.0 / 3.0));

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[20]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 10);
        }

        /// <summary>
        ///     Tests that a wide shallow valley in a point set triggers the degenerate basin handling.
        /// </summary>
        [Fact]
        public void Triangulate_WideShallowValley_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(2.0, -1.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(0.0, 2.5)
            };

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.True(pointSet.GetTriangles.Count >= 4);
        }

        /// <summary>
        ///     Tests that a point set with a deep pit at the right edge triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_DeepPitAtRightEdge_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(5.0, 0.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(2.0, -2.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(0.0, 3.5)
            };

            PointSet pointSet = new PointSet(points);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(pointSet);
            DtSweep.Triangulate(tcx);

            Assert.True(pointSet.GetTriangles.Count >= 5);
        }
    }
}
