// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: BayazitDecomposerCoverageTest.cs
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program. If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition
{
    /// <summary>
    ///     Coverage tests for BayazitDecomposer edge cases.
    /// </summary>
    public class BayazitDecomposerCoverageTest
    {
        /// <summary>
        ///     Tests CanVertexSee with a reflex vertex where LeftOn is TRUE and
        ///     RightOn is evaluated (both TRUE/FALSE). This covers the short-circuit
        ///     path where the second operand of && is evaluated.
        /// </summary>
        [Fact]
        public void CanVertexSee_ReflexLeftOnTrue_ShouldEvaluateRightOn()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(5f, 10f),
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(5f, 5f),
                new Vector2F(10f, 10f)
            });

            // Vertex 3 (5,5) is reflex. LeftOn(At(3), At(2), At(0)) is TRUE,
            // so RightOn is evaluated and returns FALSE → sees
            bool canSee = BayazitDecomposer.CanSee(3, 0, vertices);

            Assert.True(canSee);
        }

        /// <summary>
        ///     Tests CanVertexSee with a convex vertex where RightOn is FALSE and
        ///     LeftOn is evaluated (both TRUE/FALSE). This covers the short-circuit
        ///     path where the second operand of || is evaluated.
        /// </summary>
        [Fact]
        public void CanVertexSee_ConvexRightOnFalse_ShouldEvaluateLeftOn()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(10f, 10f),
                new Vector2F(5f, 10f),
                new Vector2F(5f, 8f),
                new Vector2F(2f, 8f),
                new Vector2F(2f, 5f),
                new Vector2F(0f, 5f)
            });

            // Vertex 3 (5,10) is convex.
            // With this arrangement RightOn is FALSE (target not to right of edge),
            // so LeftOn must be evaluated.
            bool canSee = BayazitDecomposer.CanSee(3, 0, vertices);

            Assert.False(canSee);
        }

        /// <summary>
        ///     Tests TriangulatePolygon with a polygon that exceeds MaxPolygonVertices (8)
        ///     and has a reflex vertex, ensuring the vertex split path is triggered
        ///     before the overflow split. Uses a 10-vertex polygon with one reflex vertex.
        /// </summary>
        [Fact]
        public void TriangulatePolygon_WithReflexAndManyVertices_ShouldSplit()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(5f, 2f),
                new Vector2F(10f, 0f),
                new Vector2F(12f, 5f),
                new Vector2F(10f, 10f),
                new Vector2F(7f, 8f),
                new Vector2F(5f, 10f),
                new Vector2F(3f, 8f),
                new Vector2F(0f, 10f),
                new Vector2F(-2f, 5f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
            foreach (Vertices part in result)
            {
                Assert.True(part.Count >= 3);
            }
        }

        /// <summary>
        ///     Tests FindBestSplitIndex via the TriangulatePolygon entry point,
        ///     ensuring the while (upperIndex < lowerIndex) normalization and
        ///     CanSee + score evaluation paths are exercised.
        ///     Uses a 6-vertex concave polygon designed to trigger FindBestSplitIndex.
        /// </summary>
        [Fact]
        public void TriangulatePolygon_WithNonAdjacentSplit_ShouldUseFindBestSplitIndex()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(10f, 10f),
                new Vector2F(7f, 10f),
                new Vector2F(7f, 3f),
                new Vector2F(3f, 3f),
                new Vector2F(3f, 10f),
                new Vector2F(0f, 10f)
            });

            List<Vertices> result = BayazitDecomposer.TriangulatePolygon(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
            foreach (Vertices part in result)
            {
                Assert.True(part.Count >= 3);
            }
        }

       
    }
}
