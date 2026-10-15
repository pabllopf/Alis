// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepRightRecursionCoverageTests.cs
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
    ///     Coverage tests exercising the right concave/convex constrained edge fill recursion of
    ///     <see cref="DtSweep" /> (FillRightConcaveEdgeEvent / FillRightConvexEdgeEvent).
    /// </summary>
    public class DTSweepRightRecursionCoverageTests
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
        ///     Tests that a right constrained edge whose front has a concave successor re-enters the
        ///     right concave edge fill recursion.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintWithConcaveSuccessor_FillsConcaveRecursively()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-5.0, 8.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(5.0, -3.0),
                new TriangulationPoint(5.0, -8.0),
                new TriangulationPoint(-7.0, -7.0),
                new TriangulationPoint(-5.0, -3.0),
                new TriangulationPoint(-6.0, 4.0),
                new TriangulationPoint(5.0, 3.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(-1.0, -4.0),
                new TriangulationPoint(6.0, 3.0),
                new TriangulationPoint(2.0, -3.0),
                new TriangulationPoint(-7.0, -1.0),
                new TriangulationPoint(0.0, 5.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[6], points[10]
            };

            int count = RunConstrained(points, constraints);

            Assert.Equal(19, count);
        }

        /// <summary>
        ///     Tests that a right constrained edge whose front turns convex traverses the right convex
        ///     edge fill branch and re-enters the recursion.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintWithConvexSuccessor_FillsConvexRecursively()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(-1.0, -5.0),
                new TriangulationPoint(-1.0, 1.0),
                new TriangulationPoint(-4.0, 5.0),
                new TriangulationPoint(6.0, -7.0),
                new TriangulationPoint(3.0, -4.0),
                new TriangulationPoint(6.0, 0.0),
                new TriangulationPoint(1.0, -4.0),
                new TriangulationPoint(-8.0, 6.0),
                new TriangulationPoint(2.0, 3.0),
                new TriangulationPoint(-4.0, -6.0),
                new TriangulationPoint(0.0, -8.0),
                new TriangulationPoint(6.0, 5.0),
                new TriangulationPoint(4.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[11], points[7],
                points[9], points[3],
                points[1], points[9]
            };

            int count = RunConstrained(points, constraints);

            Assert.Equal(18, count);
        }
    }
}
