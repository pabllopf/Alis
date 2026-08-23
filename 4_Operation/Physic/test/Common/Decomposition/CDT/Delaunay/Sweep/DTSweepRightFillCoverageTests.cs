// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepRightFillCoverageTests.cs
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
    ///     The dt sweep right fill coverage tests class
    /// </summary>
    public class DTSweepRightFillCoverageTests
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
        ///     Tests that a constraint from the top right to the top left fills the right side.
        /// </summary>
        [Fact]
        public void Triangulate_TopRightToTopLeft_ProducesTriangles()
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
        ///     Tests that a constraint from the bottom right to the mid left fills the right side.
        /// </summary>
        [Fact]
        public void Triangulate_BottomRightToMidLeft_ProducesTriangles()
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
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(3.0, 2.0),
                new TriangulationPoint(4.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[4], points[8]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 10);
        }

        /// <summary>
        ///     Tests that a constraint from the mid right to the bottom left fills the right side.
        /// </summary>
        [Fact]
        public void Triangulate_MidRightToBottomLeft_ProducesTriangles()
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
                new TriangulationPoint(4.0, 1.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(3.0, 2.0),
                new TriangulationPoint(4.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[8], points[0]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 10);
        }

        /// <summary>
        ///     Tests that a constraint from the bottom right to the upper left with a deep descent fills.
        /// </summary>
        [Fact]
        public void Triangulate_BottomRightToUpperLeftDeep_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.5),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(3.0, 1.5),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(5.0, 0.0),
                new TriangulationPoint(0.0, 3.0),
                new TriangulationPoint(1.0, 3.0),
                new TriangulationPoint(2.0, 3.0),
                new TriangulationPoint(3.0, 3.0),
                new TriangulationPoint(4.0, 3.0),
                new TriangulationPoint(5.0, 3.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[4], points[6]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 10);
        }

        /// <summary>
        ///     Tests that a constraint from the top right to the bottom left crosses the whole mesh.
        /// </summary>
        [Fact]
        public void Triangulate_TopRightToBottomLeft_ProducesTriangles()
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
                new TriangulationPoint(4.0, 1.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(3.0, 2.0),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(0.0, 3.0),
                new TriangulationPoint(1.0, 3.0),
                new TriangulationPoint(2.0, 3.0),
                new TriangulationPoint(3.0, 3.0),
                new TriangulationPoint(4.0, 3.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[18], points[0]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 16);
        }

        /// <summary>
        ///     Tests that a constraint from the top right to the bottom left in a sparse mesh triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_TopRightToBottomLeftSparse_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(3.0, 0.0),
                new TriangulationPoint(0.0, 3.0),
                new TriangulationPoint(3.0, 3.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(2.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[3], points[0]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 4);
        }

        /// <summary>
        ///     Tests that a constraint with points below the line fills the right concave region.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintWithPointsBelowLine_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 1.2),
                new TriangulationPoint(2.0, 0.8),
                new TriangulationPoint(3.0, 0.4),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(4.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[4], points[5]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 6);
        }

        /// <summary>
        ///     Tests that a constraint with a deep below line region fills the right concave region.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintWithDeepBelowLine_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(3.0, 0.5),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(0.0, 3.0),
                new TriangulationPoint(2.0, 3.0),
                new TriangulationPoint(4.0, 3.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[4], points[5]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 6);
        }

        /// <summary>
        ///     Tests that a constraint with alternating below and above points triangulates.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintWithAlternatingPoints_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.8),
                new TriangulationPoint(2.0, 1.6),
                new TriangulationPoint(3.0, 0.8),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(4.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[4], points[5]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 6);
        }

        /// <summary>
        ///     Tests that a constraint with a sawtooth front fills the right convex region.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintWithSawtoothFront_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.5),
                new TriangulationPoint(2.0, 0.3),
                new TriangulationPoint(3.0, 0.9),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(4.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[4], points[5]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 6);
        }

        /// <summary>
        ///     Tests that a left constraint with points below the line fills the left concave region.
        /// </summary>
        [Fact]
        public void Triangulate_LeftConstraintWithPointsBelowLine_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 0.3),
                new TriangulationPoint(2.0, 0.6),
                new TriangulationPoint(3.0, 0.9),
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
        ///     Tests that a left constraint with a sawtooth front fills the left convex region.
        /// </summary>
        [Fact]
        public void Triangulate_LeftConstraintWithSawtoothFront_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 0.5),
                new TriangulationPoint(2.0, 0.3),
                new TriangulationPoint(3.0, 0.9),
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
        ///     Tests that a left constraint with a deep below region fills the left convex region.
        /// </summary>
        [Fact]
        public void Triangulate_LeftConstraintWithDeepBelowLine_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(2.0, 1.5),
                new TriangulationPoint(3.0, 2.0),
                new TriangulationPoint(0.0, 3.0),
                new TriangulationPoint(4.0, 3.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[6]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 5);
        }
    }
}
