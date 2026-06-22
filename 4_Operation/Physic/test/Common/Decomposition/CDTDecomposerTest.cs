// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CDTDecomposerTest.cs
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
    /// The cdt decomposer test class
    /// </summary>
    public class CdtDecomposerTest
    {
        /// <summary>
        /// Tests that cdt decomposer type should be accessible
        /// </summary>
        [Fact]
        public void CdtDecomposer_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(CdtDecomposer));
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

            List<Vertices> result = CdtDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
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

            List<Vertices> result = CdtDecomposer.ConvexPartition(vertices);

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

            List<Vertices> result = CdtDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 3);
        }

        /// <summary>
        ///     Tests that convex partition with polygon having a hole includes hole branch
        /// </summary>
        [Fact]
        public void ConvexPartition_WithHole_ShouldIncludeHoleBranch()
        {
            Vertices outer = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(10f, 10f),
                new Vector2F(0f, 10f)
            });

            Vertices inner = new Vertices(new[]
            {
                new Vector2F(2f, 2f),
                new Vector2F(8f, 2f),
                new Vector2F(8f, 8f),
                new Vector2F(2f, 8f)
            });

            outer.Holes = new List<Vertices> { inner };

            List<Vertices> result = CdtDecomposer.ConvexPartition(outer);

            Assert.NotNull(result);
            Assert.True(result.Count >= 4);
        }
    }
}
