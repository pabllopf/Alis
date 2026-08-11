// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepFillChainCoverageTests.cs
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
    ///     The dt sweep fill chain coverage tests class
    /// </summary>
    public class DTSweepFillChainCoverageTests
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
        ///     Tests that a constraint below a spike front fills the right regions.
        /// </summary>
        [Fact]
        public void Triangulate_ConstraintBelowSpikeFront_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 1.5),
                new TriangulationPoint(2.0, 2.2),
                new TriangulationPoint(3.0, 1.5),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(5.0, 0.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(3.0, 2.0),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(5.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[4], points[6]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 9);
        }

        /// <summary>
        ///     Tests that a constraint across a deep pit fills the right regions.
        /// </summary>
        [Fact]
        public void Triangulate_ConstraintAcrossDeepPit_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 0.2),
                new TriangulationPoint(2.0, -0.8),
                new TriangulationPoint(3.0, 0.2),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(5.0, 0.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(3.0, 2.0),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(5.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[4], points[6]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 9);
        }

        /// <summary>
        ///     Tests that a constraint below a plateau front fills the right regions.
        /// </summary>
        [Fact]
        public void Triangulate_ConstraintBelowPlateauFront_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 1.0),
                new TriangulationPoint(2.0, 1.0),
                new TriangulationPoint(3.0, 1.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(5.0, 0.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(3.0, 2.0),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(5.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[4], points[6]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 9);
        }

        /// <summary>
        ///     Tests that a constraint below a double spike front fills the right regions.
        /// </summary>
        [Fact]
        public void Triangulate_ConstraintBelowDoubleSpikeFront_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(1.0, 1.5),
                new TriangulationPoint(1.5, 2.4),
                new TriangulationPoint(2.0, 1.5),
                new TriangulationPoint(2.5, 2.4),
                new TriangulationPoint(3.0, 1.5),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(5.0, 0.0),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(1.0, 2.0),
                new TriangulationPoint(2.0, 2.0),
                new TriangulationPoint(3.0, 2.0),
                new TriangulationPoint(4.0, 2.0),
                new TriangulationPoint(5.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[6], points[8]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 11);
        }

        /// <summary>
        ///     Tests that a constraint from the bottom right to the top left with a wide front fills.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintWithWideFront_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>();
            points.Add(new TriangulationPoint(0.0, 0.0));
            points.Add(new TriangulationPoint(4.0, 0.0));
            points.Add(new TriangulationPoint(1.0, 1.0));
            points.Add(new TriangulationPoint(2.0, 1.5));
            points.Add(new TriangulationPoint(3.0, 1.0));
            points.Add(new TriangulationPoint(0.5, 0.5));
            points.Add(new TriangulationPoint(1.5, 0.5));
            points.Add(new TriangulationPoint(2.5, 0.5));
            points.Add(new TriangulationPoint(3.5, 0.5));
            points.Add(new TriangulationPoint(0.0, 2.0));
            points.Add(new TriangulationPoint(4.0, 2.0));

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[1], points[9]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 8);
        }

        /// <summary>
        ///     Tests that a constraint from the bottom right to the top left with a large front fills.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintWithLargeFront_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0.0, 0.0),
                new TriangulationPoint(4.0, 0.0),
                new TriangulationPoint(1.0, 0.7),
                new TriangulationPoint(2.0, 0.7),
                new TriangulationPoint(3.0, 0.7),
                new TriangulationPoint(0.5, 1.4),
                new TriangulationPoint(1.5, 1.4),
                new TriangulationPoint(2.5, 1.4),
                new TriangulationPoint(3.5, 1.4),
                new TriangulationPoint(0.0, 2.0),
                new TriangulationPoint(4.0, 2.0)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[1], points[9]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 8);
        }

        /// <summary>
        ///     Tests that a constraint from the mid right to the top left with a full mesh fills.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintWithFullMesh_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>();
            for (int x = 0; x <= 4; x++)
            {
                for (int y = 0; y <= 2; y++)
                {
                    points.Add(new TriangulationPoint(x, y));
                }
            }

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[4], points[0]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 13);
        }

        /// <summary>
        ///     Tests that a constraint from the bottom right to the top left with a dense mesh fills.
        /// </summary>
        [Fact]
        public void Triangulate_RightConstraintWithDenseMesh_ProducesTriangles()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>();
            for (int x = 0; x <= 6; x++)
            {
                for (int y = 0; y <= 3; y++)
                {
                    points.Add(new TriangulationPoint(x, y));
                }
            }

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[6], points[0]
            };

            int count = RunConstrained(points, constraints);

            Assert.True(count >= 25);
        }
    }
}
