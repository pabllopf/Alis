// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FlipcodeDecomposerTest.cs
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

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    /// <summary>
    /// The flipcode decomposer test class
    /// </summary>
    public class FlipcodeDecomposerTest
    {
        /// <summary>
        /// Tests that flipcode decomposer type should be accessible
        /// </summary>
        [Fact]
        public void FlipcodeDecomposer_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(FlipcodeDecomposer));
        }

        /// <summary>
        /// Tests that convex partition with triangle should return single part
        /// </summary>
        [Fact]
        public void ConvexPartition_WithTriangle_ShouldReturnSinglePart()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });

            List<Vertices> result = FlipcodeDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Tests that inside triangle returns false when point is outside
        /// </summary>
        [Fact]
        public void InsideTriangle_PointOutside_ReturnsFalse()
        {
            Vector2F a = new Vector2F(0f, 0f);
            Vector2F b = new Vector2F(1f, 0f);
            Vector2F c = new Vector2F(0f, 1f);
            Vector2F p = new Vector2F(10f, 10f);

            bool result = FlipcodeDecomposer.InsideTriangle(ref a, ref b, ref c, ref p);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that snip returns false for degenerate triangle
        /// </summary>
        [Fact]
        public void Snip_DegenerateTriangle_ReturnsFalse()
        {
            Vertices contour = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });
            int[] vertices = {0, 1, 2, 3};
            Vector2F a = contour[0];
            Vector2F b = contour[1];
            Vector2F c = contour[2];

            bool result = FlipcodeDecomposer.Snip(contour, 0, 1, 2, 4, vertices, ref a, ref b, ref c);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that snip returns false when vertex inside triangle
        /// </summary>
        [Fact]
        public void Snip_VertexInsideTriangle_ReturnsFalse()
        {
            Vertices contour = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(1f, 1f),
                new Vector2F(0f, 2f)
            });
            int[] vertices = {0, 1, 2, 3};
            Vector2F a = contour[0];
            Vector2F b = contour[1];
            Vector2F c = contour[3];

            bool result = FlipcodeDecomposer.Snip(contour, 0, 1, 3, 4, vertices, ref a, ref b, ref c);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that convex partition with quadrilateral returns triangles
        /// </summary>
        [Fact]
        public void ConvexPartition_WithQuadrilateral_ReturnsTriangles()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(1f, 1f),
                new Vector2F(0f, 1f)
            });

            List<Vertices> result = FlipcodeDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
        }

        /// <summary>
        ///     Tests that convex partition with pentagon returns triangles
        /// </summary>
        [Fact]
        public void ConvexPartition_WithPentagon_ReturnsTriangles()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(3f, 1f),
                new Vector2F(1f, 3f),
                new Vector2F(-1f, 1f)
            });

            List<Vertices> result = FlipcodeDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 3);
        }
    }
}
