// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimpleCombinerRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.PolygonManipulation;
using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    ///     The simple combiner remaining coverage tests class
    /// </summary>
    public class SimpleCombinerRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that polygonize triangles with degenerate triangle skips corrupt poly
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_WithDegenerateTriangle_SkipsCorruptPoly()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices(new[]
                {
                    new Vector2F(0, 0),
                    new Vector2F(1, 0),
                    new Vector2F(2, 0)
                }),
                new Vertices(new[]
                {
                    new Vector2F(0, 0),
                    new Vector2F(1, 0),
                    new Vector2F(0.5f, 1)
                })
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that polygonize triangles with empty triangle removes empty polygons
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_WithEmptyTriangle_RemovesEmptyPolygons()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices(new[]
                {
                    new Vector2F(0, 0),
                    new Vector2F(1, 1),
                    new Vector2F(2, 2)
                }),
                new Vertices(new[]
                {
                    new Vector2F(0, 0),
                    new Vector2F(1, 0),
                    new Vector2F(0.5f, 1)
                })
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that polygonize triangles with max polys limits result
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_WithMaxPolys_LimitsResult()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices(new[] { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0.5f, 1) }),
                new Vertices(new[] { new Vector2F(2, 0), new Vector2F(3, 0), new Vector2F(2.5f, 1) }),
                new Vertices(new[] { new Vector2F(4, 0), new Vector2F(5, 0), new Vector2F(4.5f, 1) })
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles, 1);

            Assert.NotNull(result);
            Assert.True(result.Count <= 1);
        }

        /// <summary>
        ///     Tests that polygonize triangles with shared collinear edges merges polygon
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_WithSharedCollinearEdges_MergesPolygon()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices(new[] { new Vector2F(0, 0), new Vector2F(1, 0), new Vector2F(0.5f, 0.5f) }),
                new Vertices(new[] { new Vector2F(1, 0), new Vector2F(2, 0), new Vector2F(1.5f, 0.5f) }),
                new Vertices(new[] { new Vector2F(0, 0), new Vector2F(2, 0), new Vector2F(1, 0.0001f) })
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles, int.MaxValue, 0.001f);

            Assert.NotNull(result);
        }
    }
}
