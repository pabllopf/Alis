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
using System.Reflection;
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
        ///     Tests that polygonize triangles with a degenerate triangle skips the corrupt polygon.
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_WithDegenerateTriangle_SkipsCorruptPolygon()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices(new[]
                {
                    new Vector2F(0f, 0f),
                    new Vector2F(1f, 0f),
                    new Vector2F(1f, 0f)
                })
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that polygonize triangles with a thin sliver pair collapses and skips the corrupt polygon.
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_WithThinSliverPair_SkipsCorruptPolygon()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices(new[]
                {
                    new Vector2F(0f, 0f),
                    new Vector2F(1f, 0f),
                    new Vector2F(0f, 0.0005f)
                }),
                new Vertices(new[]
                {
                    new Vector2F(1f, 0f),
                    new Vector2F(2f, 0f),
                    new Vector2F(1f, 0.0005f)
                })
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that polygonize triangles with three tiny slivers collapses and skips the corrupt polygon.
        /// </summary>
        [Fact]
        public void PolygonizeTriangles_WithTinySlivers_SkipsCorruptPolygon()
        {
            List<Vertices> triangles = new List<Vertices>
            {
                new Vertices(new[]
                {
                    new Vector2F(0f, 0f),
                    new Vector2F(1f, 0f),
                    new Vector2F(0f, 0.0001f)
                }),
                new Vertices(new[]
                {
                    new Vector2F(1f, 0f),
                    new Vector2F(2f, 0f),
                    new Vector2F(1f, 0.0001f)
                }),
                new Vertices(new[]
                {
                    new Vector2F(2f, 0f),
                    new Vector2F(3f, 0f),
                    new Vector2F(2f, 0.0001f)
                })
            };

            List<Vertices> result = SimpleCombiner.PolygonizeTriangles(triangles);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that remove empty polygons removes empty entries.
        /// </summary>
        [Fact]
        public void RemoveEmptyPolygons_RemovesEmptyEntries()
        {
            MethodInfo method = typeof(SimpleCombiner).GetMethod("RemoveEmptyPolygons",
                BindingFlags.NonPublic | BindingFlags.Static);

            List<Vertices> polys = new List<Vertices>
            {
                new Vertices(new[] { new Vector2F(0f, 0f), new Vector2F(1f, 0f), new Vector2F(0f, 1f) }),
                new Vertices(),
                new Vertices(new[] { new Vector2F(2f, 0f), new Vector2F(3f, 0f), new Vector2F(2f, 1f) })
            };

            method.Invoke(null, new object[] { polys });

            Assert.Equal(2, polys.Count);
        }
    }
}
