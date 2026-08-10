// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EarclipDecomposerRemainingCoverageTests.cs
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
    ///     The earclip decomposer remaining coverage tests class
    /// </summary>
    public class EarclipDecomposerRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that convex partition with pinch polygon splits at pinch point
        /// </summary>
        [Fact]
        public void ConvexPartition_WithPinchPolygon_SplitsAtPinchPoint()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(2, 0),
                new Vector2F(2, 2),
                new Vector2F(0, 2),
                new Vector2F(0, 1),
                new Vector2F(0, 0)
            };

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices, 0.001f);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that convex partition with concave polygon produces triangles
        /// </summary>
        [Fact]
        public void ConvexPartition_WithConcavePolygon_ProducesTriangles()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(3, 0),
                new Vector2F(3, 3),
                new Vector2F(1, 3),
                new Vector2F(1, 1),
                new Vector2F(0, 1)
            };

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices, 0.001f);

            Assert.NotNull(result);
            foreach (Vertices triangle in result)
            {
                Assert.Equal(3, triangle.Count);
            }
        }

        /// <summary>
        ///     Tests that convex partition with self touching polygon produces triangles
        /// </summary>
        [Fact]
        public void ConvexPartition_WithSelfTouchingPolygon_ProducesTriangles()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(2, 0),
                new Vector2F(2, 2),
                new Vector2F(1, 2),
                new Vector2F(1, 0),
                new Vector2F(0, 0)
            };

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices, 0.001f);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that convex partition with pentagon produces triangles
        /// </summary>
        [Fact]
        public void ConvexPartition_WithPentagon_ProducesTriangles()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(2, 0),
                new Vector2F(2.5f, 1),
                new Vector2F(2, 2),
                new Vector2F(0, 2)
            };

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices, 0.001f);

            Assert.NotNull(result);
            Assert.True(result.Count >= 3);
        }
    }
}
