// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BayazitDecomposerTargetedCoverageTests.cs
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
    ///     Targeted coverage tests for BayazitDecomposer focusing on the adjacent-split
    ///     branch (lines 71-78) and the score+=3 branch (lines 213-215).
    /// </summary>
    public class BayazitDecomposerTargetedCoverageTests
    {
        /// <summary>
        ///     Tests that a V-shaped concave polygon triggers the adjacent split branch
        ///     where lowerIndex == (upperIndex + 1) % vertices.Count.
        /// </summary>
        [Fact]
        public void TriangulatePolygon_VShapedPolygon_TriggersAdjacentSplit()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(4f, 4f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 4f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
        }

        /// <summary>
        ///     Tests that a notched rectangle triggers the adjacent split branch.
        /// </summary>
        [Fact]
        public void TriangulatePolygon_NotchedRectangle_TriggersAdjacentSplit()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(6f, 0f),
                new Vector2F(6f, 4f),
                new Vector2F(4f, 4f),
                new Vector2F(4f, 2f),
                new Vector2F(2f, 2f),
                new Vector2F(2f, 4f),
                new Vector2F(0f, 4f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
        }

        /// <summary>
        ///     Tests that an arrow-shaped polygon triggers the adjacent split branch.
        /// </summary>
        [Fact]
        public void TriangulatePolygon_ArrowPolygon_TriggersAdjacentSplit()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 2f),
                new Vector2F(3f, 0f),
                new Vector2F(3f, 1f),
                new Vector2F(6f, 1f),
                new Vector2F(6f, 3f),
                new Vector2F(3f, 3f),
                new Vector2F(3f, 4f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
        }

        /// <summary>
        ///     Tests that a polygon with two reflex vertices facing each other
        ///     triggers the score+=3 branch where the candidate is reflex.
        /// </summary>
        [Fact]
        public void TriangulatePolygon_TwoReflexFacing_TriggersScorePlusThree()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(8f, 0f),
                new Vector2F(8f, 2f),
                new Vector2F(6f, 2f),
                new Vector2F(6f, 6f),
                new Vector2F(8f, 6f),
                new Vector2F(8f, 8f),
                new Vector2F(0f, 8f),
                new Vector2F(0f, 6f),
                new Vector2F(2f, 6f),
                new Vector2F(2f, 2f),
                new Vector2F(0f, 2f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
        }

        /// <summary>
        ///     Tests that a C-shaped polygon triggers both branches.
        /// </summary>
        [Fact]
        public void TriangulatePolygon_CShapedPolygon_TriggersBothBranches()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(6f, 0f),
                new Vector2F(6f, 6f),
                new Vector2F(2f, 6f),
                new Vector2F(2f, 2f),
                new Vector2F(4f, 2f),
                new Vector2F(4f, 4f),
                new Vector2F(0f, 4f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Tests that a staircase polygon triggers the adjacent split.
        /// </summary>
        [Fact]
        public void TriangulatePolygon_StaircasePolygon_TriggersAdjacentSplit()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(2f, 0f),
                new Vector2F(2f, 1f),
                new Vector2F(4f, 1f),
                new Vector2F(4f, 2f),
                new Vector2F(6f, 2f),
                new Vector2F(6f, 3f),
                new Vector2F(0f, 3f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
        }

        /// <summary>
        ///     Tests that a polygon with a deep narrow notch triggers the adjacent split.
        /// </summary>
        [Fact]
        public void TriangulatePolygon_DeepNotchPolygon_TriggersAdjacentSplit()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(10f, 10f),
                new Vector2F(8f, 10f),
                new Vector2F(8f, 3f),
                new Vector2F(7f, 3f),
                new Vector2F(7f, 10f),
                new Vector2F(0f, 10f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
        }

        /// <summary>
        ///     Tests that a polygon with two reflex vertices on the same side
        ///     triggers the score+=3 branch.
        /// </summary>
        [Fact]
        public void TriangulatePolygon_SameSideReflex_TriggersScorePlusThree()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(10f, 10f),
                new Vector2F(7f, 10f),
                new Vector2F(7f, 5f),
                new Vector2F(5f, 5f),
                new Vector2F(5f, 8f),
                new Vector2F(3f, 8f),
                new Vector2F(3f, 5f),
                new Vector2F(0f, 5f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
        }

        /// <summary>
        ///     Tests that CanSee with two reflex vertices in mutual visibility returns true.
        /// </summary>
        [Fact]
        public void CanSee_TwoReflexVerticesMutualVisibility_ReturnsTrue()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(10f, 3f),
                new Vector2F(7f, 3f),
                new Vector2F(7f, 7f),
                new Vector2F(10f, 7f),
                new Vector2F(10f, 10f),
                new Vector2F(0f, 10f),
                new Vector2F(0f, 7f),
                new Vector2F(3f, 7f),
                new Vector2F(3f, 3f),
                new Vector2F(0f, 3f)
            });

            bool canSee = BayazitDecomposer.CanSee(3, 9, vertices);

            Assert.True(canSee);
        }

        /// <summary>
        ///     Tests that CanSee with reflex vertex and candidate where candidate is
        ///     also reflex triggers the score+=3 path.
        /// </summary>
        [Fact]
        public void CanSee_ReflexCandidateInWedge_ReturnsTrue()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(8f, 0f),
                new Vector2F(8f, 3f),
                new Vector2F(6f, 3f),
                new Vector2F(6f, 6f),
                new Vector2F(8f, 6f),
                new Vector2F(8f, 8f),
                new Vector2F(0f, 8f),
                new Vector2F(0f, 5f),
                new Vector2F(2f, 5f),
                new Vector2F(2f, 3f),
                new Vector2F(0f, 3f)
            });

            bool canSee = BayazitDecomposer.CanSee(3, 9, vertices);

            Assert.True(canSee);
        }

        /// <summary>
        ///     Tests that a polygon with alternating in-out vertices triggers both branches.
        /// </summary>
        [Fact]
        public void TriangulatePolygon_AlternatingInOut_TriggersBothBranches()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(4f, 1f),
                new Vector2F(3f, 1f),
                new Vector2F(3f, 2f),
                new Vector2F(4f, 2f),
                new Vector2F(4f, 3f),
                new Vector2F(3f, 3f),
                new Vector2F(3f, 4f),
                new Vector2F(0f, 4f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
        }
    }
}
