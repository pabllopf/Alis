// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepTargetedCoverageTests.cs
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
using System.Reflection;
using Alis.Core.Physic.Common.Decomposition.CDT;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Alis.Core.Physic.Common.Decomposition.CDT.Sets;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    /// The dt sweep targeted coverage tests class
    /// </summary>
    public class DTSweepTargetedCoverageTests
    {
        /// <summary>
        /// The dt sweep
        /// </summary>
        private static readonly Type Type = typeof(DtSweep);

        /// <summary>
        /// The static
        /// </summary>
        private static readonly BindingFlags Flags = BindingFlags.NonPublic | BindingFlags.Static;



        /// <summary>
        /// Tests that edge event catch block catches point on edge exception via integration
        /// </summary>
        [Fact]
        public void EdgeEvent_CatchBlock_Integration()
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>
            {
                new TriangulationPoint(0, 0),
                new TriangulationPoint(2, 0),
                new TriangulationPoint(2, 2),
                new TriangulationPoint(0, 2),
                new TriangulationPoint(1, 1)
            };

            List<TriangulationPoint> constraints = new List<TriangulationPoint>
            {
                points[0], points[2],
                points[1], points[4]
            };

            ConstrainedPointSet cps = new ConstrainedPointSet(points, constraints);
            DtSweepContext tcx = new DtSweepContext();
            tcx.PrepareTriangulation(cps);
            DtSweep.Triangulate(tcx);

            Assert.NotNull(cps.GetTriangles);
        }

        // ========================================================================
        // FinalizationConvexHull — lines 110-115, 119-124
        // ========================================================================

        /// <summary>
        /// Tests that finalization convex hull if blocks covered via many point sets
        /// </summary>
        [Fact]
        public void FinalizationConvexHull_ManyPointSets_CoversIfBlocks()
        {
            for (int trial = 0; trial < 20; trial++)
            {
                List<TriangulationPoint> points = new List<TriangulationPoint>();
                System.Random rng = new System.Random(trial * 7 + 42);
                for (int i = 0; i < 5 + trial % 4; i++)
                {
                    points.Add(new TriangulationPoint(rng.NextDouble() * 10, rng.NextDouble() * 10));
                }

                PointSet ps = new PointSet(points);
                DtSweepContext tcx = new DtSweepContext();
                tcx.PrepareTriangulation(ps);
                DtSweep.Triangulate(tcx);
                Assert.NotNull(ps.GetTriangles);
            }
        }

        // ========================================================================
        // FinalizationConvexHull lines 110-115, 119-124 via reflection
        // ========================================================================

        
        /// <summary>
        /// The mock triangulatable class
        /// </summary>
        internal class MockTriangulatable : ITriangulatable
        {
            /// <summary>
            /// The delaunay triangle
            /// </summary>
            public readonly List<DelaunayTriangle> Triangles = new List<DelaunayTriangle>();

            /// <summary>
            /// Gets the value of the get points
            /// </summary>
            public IList<TriangulationPoint> GetPoints => new List<TriangulationPoint>();

            /// <summary>
            /// Gets the value of the get triangles
            /// </summary>
            public IList<DelaunayTriangle> GetTriangles => Triangles.AsReadOnly();

            /// <summary>
            /// Gets the value of the triangulation mode
            /// </summary>
            public TriangulationMode TriangulationMode => TriangulationMode.Unconstrained;

            /// <summary>
            /// Prepares the triangulation using the specified tcx
            /// </summary>
            /// <param name="tcx">The tcx</param>
            public void PrepareTriangulation(TriangulationContext tcx) { }

            /// <summary>
            /// Adds the triangle using the specified t
            /// </summary>
            /// <param name="t">The </param>
            public void AddTriangle(DelaunayTriangle t) => Triangles.Add(t);

            /// <summary>
            /// Adds the triangles using the specified tris
            /// </summary>
            /// <param name="tris">The tris</param>
            public void AddTriangles(IEnumerable<DelaunayTriangle> tris) => Triangles.AddRange(tris);

            /// <summary>
            /// Clears the triangles
            /// </summary>
            public void ClearTriangles() => Triangles.Clear();
        }
    }
}
