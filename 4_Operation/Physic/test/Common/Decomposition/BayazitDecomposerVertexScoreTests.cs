// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: BayazitDecomposerVertexScoreTests.cs
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
    ///     Tests for <see cref="BayazitDecomposer.CalculateVertexScore" /> covering its three
    ///     scoring branches (+3 reflex candidate whose scored vertex lies inside its wedge,
    ///     +2 reflex candidate whose scored vertex lies outside that wedge and +1 convex
    ///     candidate) together with the end to end partition of the shared fixture polygon.
    /// </summary>
    public class BayazitDecomposerVertexScoreTests
    {
        /// <summary>
        ///     Builds the shared fixture: a rectangle with a stepped slot cut out of its bottom
        ///     side. The polygon is simple, wound counter clockwise and has reflex vertices at
        ///     index 2 (4,6), index 3 (6,6) and index 5 (8,3).
        /// </summary>
        /// <returns>The vertices</returns>
        private static Vertices SteppedSlotPolygon() => new Vertices(new[]
        {
            new Vector2F(0f, 0f),
            new Vector2F(4f, 0f),
            new Vector2F(4f, 6f),
            new Vector2F(6f, 6f),
            new Vector2F(6f, 3f),
            new Vector2F(8f, 3f),
            new Vector2F(8f, 0f),
            new Vector2F(12f, 0f),
            new Vector2F(12f, 10f),
            new Vector2F(0f, 10f)
        });

        /// <summary>
        ///     Tests that a reflex candidate whose scored vertex sits strictly inside the wedge
        ///     spanned by the candidate edges earns the +3 bonus on top of the distance term.
        /// </summary>
        [Fact]
        public void CalculateVertexScore_WhenCandidateIsReflexAndReflexVertexIsInsideWedge_AddsThreeBonus()
        {
            // Arrange
            Vertices vertices = SteppedSlotPolygon();

            // Both vertices are reflex, so the reflex guard of the candidate is entered.
            Assert.True(BayazitDecomposer.Reflex(2, vertices));
            Assert.True(BayazitDecomposer.Reflex(5, vertices));

            // Both halves of the compound condition hold, so the score += 3 branch is taken.
            Assert.True(BayazitDecomposer.RightOn(
                BayazitDecomposer.At(1, vertices),
                BayazitDecomposer.At(2, vertices),
                BayazitDecomposer.At(5, vertices)));

            Assert.True(BayazitDecomposer.LeftOn(
                BayazitDecomposer.At(3, vertices),
                BayazitDecomposer.At(2, vertices),
                BayazitDecomposer.At(5, vertices)));

            // Act
            // reflexVertex = 5 (8,3), candidate = 2 (4,6) => squared distance 16 + 9 = 25
            double score = BayazitDecomposer.CalculateVertexScore(5, 2, vertices);

            // Assert
            Assert.Equal(3d + 1d / 26d, score, 7);
        }

        /// <summary>
        ///     Tests that a reflex candidate whose scored vertex lies outside its wedge only
        ///     earns the +2 bonus.
        /// </summary>
        [Fact]
        public void CalculateVertexScore_WhenCandidateIsReflexAndReflexVertexIsOutsideWedge_AddsTwoBonus()
        {
            // Arrange
            Vertices vertices = SteppedSlotPolygon();

            // The candidate is reflex, so the reflex guard is entered ...
            Assert.True(BayazitDecomposer.Reflex(3, vertices));

            // ... the RightOn half of the condition holds but the LeftOn half fails,
            // forcing the score += 2 branch.
            Assert.True(BayazitDecomposer.RightOn(
                BayazitDecomposer.At(2, vertices),
                BayazitDecomposer.At(3, vertices),
                BayazitDecomposer.At(5, vertices)));

            Assert.False(BayazitDecomposer.LeftOn(
                BayazitDecomposer.At(4, vertices),
                BayazitDecomposer.At(3, vertices),
                BayazitDecomposer.At(5, vertices)));

            // Act
            // reflexVertex = 5 (8,3), candidate = 3 (6,6) => squared distance 4 + 9 = 13
            double score = BayazitDecomposer.CalculateVertexScore(5, 3, vertices);

            // Assert
            Assert.Equal(2d + 1d / 14d, score, 7);
        }

        /// <summary>
        ///     Tests that a convex candidate only earns the +1 bonus.
        /// </summary>
        [Fact]
        public void CalculateVertexScore_WhenCandidateIsConvex_AddsOneBonus()
        {
            // Arrange
            Vertices vertices = SteppedSlotPolygon();

            Assert.False(BayazitDecomposer.Reflex(0, vertices));

            // Act
            // reflexVertex = 5 (8,3), candidate = 0 (0,0) => squared distance 64 + 9 = 73
            double score = BayazitDecomposer.CalculateVertexScore(5, 0, vertices);

            // Assert
            Assert.Equal(1d + 1d / 74d, score, 7);
        }

        /// <summary>
        ///     Tests the invariant behind the +3 bonus: the wedge that makes a reflex candidate
        ///     worth +3 is exactly the wedge in which that candidate reports that it cannot see
        ///     back, which is why the split search itself never selects such a candidate.
        /// </summary>
        [Fact]
        public void CanVertexSee_WhenReflexVertexSitsInCandidateWedge_DeniesSeeingBack()
        {
            // Arrange
            Vertices vertices = SteppedSlotPolygon();

            // reflexVertex 5 lies strictly inside the wedge of reflex candidate 2.
            Assert.True(BayazitDecomposer.RightOn(
                BayazitDecomposer.At(1, vertices),
                BayazitDecomposer.At(2, vertices),
                BayazitDecomposer.At(5, vertices)));

            Assert.True(BayazitDecomposer.LeftOn(
                BayazitDecomposer.At(3, vertices),
                BayazitDecomposer.At(2, vertices),
                BayazitDecomposer.At(5, vertices)));

            // Act
            bool candidateSeesReflexVertex = BayazitDecomposer.CanVertexSee(2, 5, vertices);
            bool reflexVertexSeesCandidate = BayazitDecomposer.CanVertexSee(5, 2, vertices);
            bool mutuallyVisible = BayazitDecomposer.CanSee(5, 2, vertices);

            // Assert
            Assert.False(candidateSeesReflexVertex);
            Assert.True(reflexVertexSeesCandidate);
            Assert.False(mutuallyVisible);
        }

        /// <summary>
        ///     Tests that the stepped slot polygon is partitioned into convex parts of at least
        ///     three vertices, so no reflex vertex survives in the produced parts.
        /// </summary>
        [Fact]
        public void ConvexPartition_WithSteppedSlotPolygon_ReturnsOnlyConvexParts()
        {
            // Arrange
            Vertices vertices = SteppedSlotPolygon();

            // Act
            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count >= 2, "A stepped slot must be split into several parts");

            foreach (Vertices part in result)
            {
                Assert.True(part.Count >= 3, "Every partition must keep at least three vertices");

                for (int i = 0; i < part.Count; ++i)
                {
                    Assert.False(BayazitDecomposer.Reflex(i, part),
                        $"Partition vertex {i} of a {part.Count} vertex part must not be reflex");
                }
            }
        }

        /// <summary>
        ///     Tests that a reflex vertex looking for a split partner never receives a candidate
        ///     that would be scored with the +3 bonus, because such a candidate denies sight of
        ///     the reflex vertex.
        /// </summary>
        [Fact]
        public void FindBestSplitIndex_WithSteppedSlotPolygon_NeverSelectsAPlusThreeCandidate()
        {
            // Arrange
            Vertices vertices = SteppedSlotPolygon();

            // Act
            int bestIndex = BayazitDecomposer.FindBestSplitIndex(2, 0, vertices.Count - 1, vertices);

            // Assert
            Assert.True(BayazitDecomposer.CanSee(2, bestIndex, vertices),
                $"Chosen split index {bestIndex} must be mutually visible from the reflex vertex");

            // Index 5 would score 3 + 1/26 but denies sight of vertex 2, so it must not win.
            Assert.Equal(9, bestIndex);
        }
    }
}
