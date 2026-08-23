// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepFillHoleCoverageTests.cs
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
    ///     The dt sweep fill hole coverage tests class
    /// </summary>
    public class DTSweepFillHoleCoverageTests
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
        ///     Tests that a right constraint below a surviving spike fills the right concave region.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintWithSurvivingSpike_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 0.15),
                new TriangulationPoint(3.0, 0.15),
                new TriangulationPoint(2.0, 0.85),
                new TriangulationPoint(5.0, 1.2),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(5.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[1], points[6]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 7);
        }

        /// <summary>
        ///     Tests that a right constraint below a surviving spike with a high spike fills.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintWithHighSurvivingSpike_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 0.2),
                new TriangulationPoint(3.0, 0.2),
                new TriangulationPoint(2.0, 1.1),
                new TriangulationPoint(5.0, 1.5),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(5.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[1], points[6]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 7);
        }

        /// <summary>
        ///     Tests that a left constraint above a surviving spike fills the left concave region.
        /// </summary>
        [Fact]
        public void Triangulate_LeftConstraintWithSurvivingSpike_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(3.0, 0.15),
                new TriangulationPoint(1.0, 0.15),
                new TriangulationPoint(2.0, 0.85),
                new TriangulationPoint(-1.0, 1.2),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(-1.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[1], points[6]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 7);
        }

        /// <summary>
        ///     Tests that a left constraint with a high surviving spike fills the left region.
        /// </summary>
        [Fact]
        public void Triangulate_LeftConstraintWithHighSurvivingSpike_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(3.0, 0.2),
                new TriangulationPoint(1.0, 0.2),
                new TriangulationPoint(2.0, 1.1),
                new TriangulationPoint(-1.0, 1.5),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(-1.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[1], points[6]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 7);
        }

        /// <summary>
        ///     Tests that a right constraint with two surviving spikes fills both concave regions.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintWithTwoSpikes_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 0.15),
                new TriangulationPoint(1.5, 0.85),
                new TriangulationPoint(2.0, 0.15),
                new TriangulationPoint(2.5, 0.85),
                new TriangulationPoint(3.0, 0.15),
                new TriangulationPoint(5.0, 1.2),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(5.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[1], points[8]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 9);
        }

        /// <summary>
        ///     Tests that a right constraint with a wide surviving plateau fills the right region.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintWithSurvivingPlateau_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 0.2),
                new TriangulationPoint(2.0, 0.2),
                new TriangulationPoint(3.0, 0.2),
                new TriangulationPoint(1.0, 0.9),
                new TriangulationPoint(2.0, 0.9),
                new TriangulationPoint(3.0, 0.9),
                new TriangulationPoint(5.0, 1.4),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(5.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[1], points[9]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 9);
        }
    }
}
