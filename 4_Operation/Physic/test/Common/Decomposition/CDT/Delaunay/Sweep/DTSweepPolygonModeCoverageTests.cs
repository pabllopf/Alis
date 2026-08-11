// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepPolygonModeCoverageTests.cs
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
using Alis.Core.Physic.Common.Decomposition;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep polygon mode coverage tests class
    /// </summary>
    public class DTSweepPolygonModeCoverageTests
    {
        /// <summary>
        ///     Tests that a square with a square hole decomposes into multiple triangles.
        /// </summary>
        [Fact]
        public void ConvexPartition_SquareWithSquareHole_ProducesTriangles()
        {
            Vertices outer = new Vertices
            {
                new Vector2F(0.0f, 0.0f),
                new Vector2F(4.0f, 0.0f),
                new Vector2F(4.0f, 4.0f),
                new Vector2F(0.0f, 4.0f)
            };

            Vertices hole = new Vertices
            {
                new Vector2F(1.0f, 1.0f),
                new Vector2F(3.0f, 1.0f),
                new Vector2F(3.0f, 3.0f),
                new Vector2F(1.0f, 3.0f)
            };

            outer.Holes = new List<Vertices> { hole };

            List<Vertices> triangles = CdtDecomposer.ConvexPartition(outer);

            Assert.NotNull(triangles);
            Assert.True(triangles.Count >= 8);
        }

        /// <summary>
        ///     Tests that a rectangle with an offset hole decomposes into multiple triangles.
        /// </summary>
        [Fact]
        public void ConvexPartition_RectangleWithOffsetHole_ProducesTriangles()
        {
            Vertices outer = new Vertices
            {
                new Vector2F(0.0f, 0.0f),
                new Vector2F(5.0f, 0.0f),
                new Vector2F(5.0f, 3.0f),
                new Vector2F(0.0f, 3.0f)
            };

            Vertices hole = new Vertices
            {
                new Vector2F(1.5f, 1.0f),
                new Vector2F(3.5f, 1.0f),
                new Vector2F(3.5f, 2.0f),
                new Vector2F(1.5f, 2.0f)
            };

            outer.Holes = new List<Vertices> { hole };

            List<Vertices> triangles = CdtDecomposer.ConvexPartition(outer);

            Assert.NotNull(triangles);
            Assert.True(triangles.Count >= 4);
        }

        /// <summary>
        ///     Tests that an h shaped polygon decomposes into multiple triangles.
        /// </summary>
        [Fact]
        public void ConvexPartition_HShapePolygon_ProducesTriangles()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0.0f, 0.0f),
                new Vector2F(4.0f, 0.0f),
                new Vector2F(4.0f, 5.0f),
                new Vector2F(0.0f, 5.0f),
                new Vector2F(0.0f, 4.0f),
                new Vector2F(3.0f, 4.0f),
                new Vector2F(3.0f, 3.0f),
                new Vector2F(1.0f, 3.0f),
                new Vector2F(1.0f, 2.0f),
                new Vector2F(3.0f, 2.0f),
                new Vector2F(3.0f, 1.0f),
                new Vector2F(0.0f, 1.0f)
            };

            List<Vertices> triangles = CdtDecomposer.ConvexPartition(vertices);

            Assert.NotNull(triangles);
            Assert.True(triangles.Count >= 8);
        }

        /// <summary>
        ///     Tests that a c shaped polygon decomposes into multiple triangles.
        /// </summary>
        [Fact]
        public void ConvexPartition_CShapePolygon_ProducesTriangles()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0.0f, 0.0f),
                new Vector2F(6.0f, 0.0f),
                new Vector2F(6.0f, 6.0f),
                new Vector2F(5.0f, 6.0f),
                new Vector2F(5.0f, 1.0f),
                new Vector2F(1.0f, 1.0f),
                new Vector2F(1.0f, 6.0f),
                new Vector2F(0.0f, 6.0f)
            };

            List<Vertices> triangles = CdtDecomposer.ConvexPartition(vertices);

            Assert.NotNull(triangles);
            Assert.True(triangles.Count >= 4);
        }

        /// <summary>
        ///     Tests that a cross shaped polygon decomposes into multiple triangles.
        /// </summary>
        [Fact]
        public void ConvexPartition_CrossShapePolygon_ProducesTriangles()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(1.0f, 0.0f),
                new Vector2F(2.0f, 0.0f),
                new Vector2F(2.0f, 1.0f),
                new Vector2F(3.0f, 1.0f),
                new Vector2F(3.0f, 2.0f),
                new Vector2F(2.0f, 2.0f),
                new Vector2F(2.0f, 3.0f),
                new Vector2F(1.0f, 3.0f),
                new Vector2F(1.0f, 2.0f),
                new Vector2F(0.0f, 2.0f),
                new Vector2F(0.0f, 1.0f),
                new Vector2F(1.0f, 1.0f)
            };

            List<Vertices> triangles = CdtDecomposer.ConvexPartition(vertices);

            Assert.NotNull(triangles);
            Assert.True(triangles.Count >= 4);
        }
    }
}
