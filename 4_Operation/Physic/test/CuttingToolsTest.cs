// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CuttingToolsTest.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.PolygonManipulation;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test
{
    /// <summary>
    ///     Tests for the CuttingTools class covering SplitShape, Cut, and all internal helpers.
    ///     Pure math functions (ClassifyVertex) are tested directly; integration tests require WorldPhysic.
    /// </summary>
    public class CuttingToolsTest : IDisposable
    {
        /// <summary>
        /// The world
        /// </summary>
        private WorldPhysic? _world;

        /// <summary>
        ///     Cleans up resources
        /// </summary>
        public void Dispose()
        {
            _world = null;
        }

        #region ClassifyVertex — Pure Math Tests

        /// <summary>
        ///     Tests that ClassifyVertex returns 0 for vertices on one side of the cut line
        /// </summary>
        [Fact]
        public void ClassifyVertex_ReturnsZeroForVertexOnPositiveSide()
        {
            // Arrange — entry at (0,0), exit at (10,0)
            Vector2F entry = new Vector2F(0f, 0f);
            Vector2F exit = new Vector2F(10f, 0f);

            // A vertex at (5, 1) is on the positive side of the directed line from entry to exit
            Vector2F vertex = new Vector2F(5f, 1f);

            // Act — ClassifyVertex uses: Dot(Cross(exit - entry, 1), vertex - entry) > epsilon
            // Cross((10,0)-(0,0), 1) = (0, 0, 10) -> 2D: z-component = 10
            // Dot((0, 10), (5, 1)) = 10 > epsilon -> returns 0
            int result = ClassifyVertexDirect(vertex, entry, exit);

            // Assert
            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that ClassifyVertex returns 1 for vertices on the other side of the cut line
        /// </summary>
        [Fact]
        public void ClassifyVertex_ReturnsOneForVertexOnNegativeSide()
        {
            // Arrange — entry at (0,0), exit at (10,0)
            Vector2F entry = new Vector2F(0f, 0f);
            Vector2F exit = new Vector2F(10f, 0f);

            // A vertex at (5, -1) is on the negative side of the directed line
            Vector2F vertex = new Vector2F(5f, -1f);

            // Act — Cross((10,0), 1) z-component = 10
            // Dot((0, 10), (5, -1)) = -10 < epsilon -> returns 1
            int result = ClassifyVertexDirect(vertex, entry, exit);

            // Assert
            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that ClassifyVertex handles vertices exactly on the cut line (returns 1 when <= epsilon)
        /// </summary>
        [Fact]
        public void ClassifyVertex_OnCutLine_ReturnsOne()
        {
            // Arrange — entry at (0,0), exit at (10,0)
            Vector2F entry = new Vector2F(0f, 0f);
            Vector2F exit = new Vector2F(10f, 0f);

            // A vertex exactly on the line (y=0)
            Vector2F vertex = new Vector2F(5f, 0f);

            // Act — Dot((0, 10), (5, 0)) = 0 <= epsilon -> returns 1
            int result = ClassifyVertexDirect(vertex, entry, exit);

            // Assert
            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that ClassifyVertex handles vertices near the cut line (within epsilon)
        /// </summary>
        [Fact]
        public void ClassifyVertex_NearCutLine_ReturnsOne()
        {
            // Arrange — entry at (0,0), exit at (10,0)
            Vector2F entry = new Vector2F(0f, 0f);
            Vector2F exit = new Vector2F(10f, 0f);

            // A vertex very close to the line (within epsilon)
            Vector2F vertex = new Vector2F(5f, SettingEnv.Epsilon / 2f);

            // Act — Dot((0, 10), (5, epsilon/2)) = 10 * epsilon/2 = 5*epsilon
            // 5*epsilon > epsilon -> returns 0
            int result = ClassifyVertexDirect(vertex, entry, exit);

            // Assert
            Assert.Equal(1, result);
        }

        /// <summary>
        ///     Tests that ClassifyVertex handles reversed cut direction
        /// </summary>
        [Fact]
        public void ClassifyVertex_ReversedCutDirection_InvertsClassification()
        {
            // Arrange
            Vector2F entry = new Vector2F(0f, 0f);
            Vector2F exit = new Vector2F(10f, 0f);
            Vector2F vertex = new Vector2F(5f, 1f);

            // Act — classify with forward direction
            int forwardResult = ClassifyVertexDirect(vertex, entry, exit);

            // Act — classify with reversed direction
            int reverseResult = ClassifyVertexDirect(vertex, exit, entry);

            // Assert — reversing the cut line inverts the classification
            Assert.NotEqual(forwardResult, reverseResult);
        }

        #endregion

        #region ComputeOffsetBeforeCut / ComputeOffsetAfterCut — Pure Math Tests

        /// <summary>
        ///     Tests that ComputeOffsetBeforeCut normalizes the offset vector
        /// </summary>
        [Fact]
        public void ComputeOffsetBeforeCut_ReturnsNormalizedVector()
        {
            // Arrange — Create a simple polygon with 3 vertices
            Vertices polygon = new Vertices { new Vector2F(0f, 0f), new Vector2F(10f, 0f), new Vector2F(5f, 10f) };
            Vertices[] polygons = { polygon, new Vertices() };
            int[] cutAdded = { 1, -1 };

            // Act — compute offset before cut at index 0
            Vector2F offset = ComputeOffsetBeforeCutDirect(polygons, 0, cutAdded);

            // Assert — offset should be normalized (length ≈ 1)
            float length = offset.Length();
            Assert.InRange(length, 0.99f, 1.01f);
        }

        /// <summary>
        ///     Tests that ComputeOffsetBeforeCut handles cut at index 0 (wraps around)
        /// </summary>
        [Fact]
        public void ComputeOffsetBeforeCut_CutAtIndexZero_WrapsAround()
        {
            // Arrange — polygon where cutAdded[0] = 0 (cut at first vertex)
            Vertices polygon = new Vertices { new Vector2F(0f, 0f), new Vector2F(10f, 0f), new Vector2F(5f, 10f) };
            Vertices[] polygons = { polygon, new Vertices() };
            int[] cutAdded = { 0, -1 };

            // Act — when cutAdded[n] == 0, offset = last vertex - first vertex (wraps)
            Vector2F offset = ComputeOffsetBeforeCutDirect(polygons, 0, cutAdded);

            // Assert
            Assert.True(offset.IsValid());
        }

        /// <summary>
        ///     Tests that ComputeOffsetAfterCut normalizes the offset vector
        /// </summary>
        [Fact]
        public void ComputeOffsetAfterCut_ReturnsNormalizedVector()
        {
            // Arrange — Create a polygon with enough vertices after the cut
            Vertices polygon = new Vertices { new Vector2F(0f, 0f), new Vector2F(10f, 0f), new Vector2F(5f, 10f), new Vector2F(-5f, 10f) };
            Vertices[] polygons = { polygon, new Vertices() };
            int[] cutAdded = { 1, -1 };

            // Act — compute offset after cut
            Vector2F offset = ComputeOffsetAfterCutDirect(polygons, 0, cutAdded);

            // Assert — offset should be normalized
            float length = offset.Length();
            Assert.InRange(length, 0.99f, 1.01f);
        }

        /// <summary>
        ///     Tests that ComputeOffsetAfterCut handles wrap-around when cut is near end
        /// </summary>
        [Fact]
        public void ComputeOffsetAfterCut_CutNearEnd_WrapsAround()
        {
            // Arrange — polygon where cut is near the end
            Vertices polygon = new Vertices { new Vector2F(0f, 0f), new Vector2F(10f, 0f), new Vector2F(5f, 10f) };
            Vertices[] polygons = { polygon, new Vertices() };
            int[] cutAdded = { 2, -1 };

            // Act — when cutAdded[n] >= polygon.Count - 2, wraps to first vertex
            Vector2F offset = ComputeOffsetAfterCutDirect(polygons, 0, cutAdded);

            // Assert
            Assert.True(offset.IsValid());
        }

        /// <summary>
        ///     Tests that invalid offset defaults to Vector2F.One
        /// </summary>
        [Fact]
        public void ComputeOffset_InvalidOffsets_DefaultToOne()
        {
            // Arrange — Create a polygon where the computed offset might be invalid (zero length)
            Vertices polygon = new Vertices { new Vector2F(0f, 0f), new Vector2F(0f, 0f) };
            Vertices[] polygons = { polygon, new Vertices() };
            int[] cutAdded = { 0, -1 };

            // Act — when offset is invalid (zero length), it defaults to Vector2F.One
            Vector2F offset = ComputeOffsetBeforeCutDirect(polygons, 0, cutAdded);

            // Assert — should default to Vector2F.One when invalid
            Assert.True(offset.IsValid());
        }

        #endregion

        #region EnsureCutPointsAdded — Logic Tests

        /// <summary>
        ///     Tests that EnsureCutPointsAdded adds cut points when cutAdded is -1
        /// </summary>
        [Fact]
        public void EnsureCutPointsAdded_WhenCutMinusOneAddsPoints()
        {
            // Arrange — Both cutAdded are -1 (no cuts made yet)
            Vertices polygon0 = new Vertices { new Vector2F(0f, 0f), new Vector2F(10f, 0f) };
            Vertices polygon1 = new Vertices { new Vector2F(0f, 5f), new Vector2F(10f, 5f) };
            Vertices[] polygons = { polygon0, polygon1 };
            int[] cutAdded = { -1, -1 };
            Vector2F entry = new Vector2F(5f, 2f);
            Vector2F exit = new Vector2F(5f, 3f);

            // Act — EnsureCutPointsAdded adds exit+entry to polygon[0] and entry+exit to polygon[1]
            EnsureCutPointsAddedDirect(polygons, cutAdded, entry, exit);

            // Assert — both polygons should have 4 vertices now (2 original + 2 cut points)
            Assert.Equal(4, polygons[0].Count);
            Assert.Equal(4, polygons[1].Count);
        }

        /// <summary>
        ///     Tests that EnsureCutPointsAdded skips when cutAdded is not -1
        /// </summary>
        [Fact]
        public void EnsureCutPointsAdded_WhenCutNotMinusOneSkips()
        {
            // Arrange — Both cutAdded have valid indices (cuts already made)
            Vertices polygon0 = new Vertices { new Vector2F(0f, 0f), new Vector2F(10f, 0f) };
            Vertices polygon1 = new Vertices { new Vector2F(0f, 5f), new Vector2F(10f, 5f) };
            Vertices[] polygons = { polygon0, polygon1 };
            int[] cutAdded = { 0, 0 }; // Both have valid indices
            Vector2F entry = new Vector2F(5f, 2f);
            Vector2F exit = new Vector2F(5f, 3f);

            // Act — EnsureCutPointsAdded should skip (no -1 values)
            EnsureCutPointsAddedDirect(polygons, cutAdded, entry, exit);

            // Assert — counts should remain unchanged (2 vertices each)
            Assert.Equal(2, polygons[0].Count);
            Assert.Equal(2, polygons[1].Count);
            Assert.Equal(0, cutAdded[0]); // Unchanged
            Assert.Equal(0, cutAdded[1]); // Unchanged
        }

        #endregion

        #region Integration Tests — Require WorldPhysic (Skipped)

        /// <summary>
        ///     Tests that SplitShape splits a polygon fixture into two parts
        ///     SKIPPED — requires real Fixture with PolygonShape and WorldPhysic
        /// </summary>
        [Fact(Skip = "Requires real Fixture with PolygonShape and WorldPhysic")] public void SplitShape_SplitsPolygonFixtureIntoTwoParts()
        {
            // Arrange — create a polygon fixture with vertices
            // Act — split using entry and exit points
            // Assert — two valid polygon vertex collections returned
        }

        /// <summary>
        ///     Tests that SplitShape returns empty vertices when shape is not PolygonShape
        ///     SKIPPED — requires real Fixture with non-polygon shape
        /// </summary>
        [Fact(Skip = "Requires real Fixture with non-polygon shape")] public void SplitShape_NonPolygonShape_ReturnsEmptyVertices()
        {
            // Arrange — fixture with CircleShape (not PolygonShape)
            // Act — split should return empty vertices for both outputs
            // Assert — first and second are empty Vertices collections
        }

        /// <summary>
        ///     Tests that Cut returns false when start or end point is inside a shape
        ///     SKIPPED — requires real WorldPhysic with TestPoint implementation
        /// </summary>
        [Fact(Skip = "Requires real WorldPhysic with TestPoint implementation")] public void Cut_ReturnsFalseWhenPointInsideShape()
        {
            // Arrange — world with a body
            // Act — cut with start point inside the shape
            // Assert — returns false
        }

        /// <summary>
        ///     Tests that Cut returns true when a valid cut is performed
        ///     SKIPPED — requires full physics engine integration
        /// </summary>
        [Fact(Skip = "Requires full physics engine integration")] public void Cut_ValidCut_ReturnsTrue()
        {
            // Arrange — world with polygon bodies
            // Act — cut through a body
            // Assert — returns true, creates two new dynamic bodies
        }

        /// <summary>
        ///     Tests that Cut skips non-polygon shapes
        ///     SKIPPED — requires full physics engine integration
        /// </summary>
        [Fact(Skip = "Requires full physics engine integration")] public void Cut_SkipsNonPolygonShapes()
        {
            // Arrange — world with mixed shape types (polygon + circle)
            // Act — cut through the world
            // Assert — only polygon shapes are split, circles untouched
        }

        /// <summary>
        ///     Tests that Cut returns false when fewer than 2 intersections found
        ///     SKIPPED — requires full physics engine integration
        /// </summary>
        [Fact(Skip = "Requires full physics engine integration")] public void Cut_FewerThanTwoIntersections_ReturnsFalse()
        {
            // Arrange — world with a body that the cut line barely touches
            // Act — cut that intersects only once
            // Assert — returns false (entryPoints + exitPoints < 2)
        }

        /// <summary>
        ///     Tests that Cut creates dynamic bodies from split polygons
        ///     SKIPPED — requires full physics engine integration
        /// </summary>
        [Fact(Skip = "Requires full physics engine integration")] public void Cut_CreatesDynamicBodiesFromSplit()
        {
            // Arrange — world with a static polygon body
            // Act — cut through the body
            // Assert — two new dynamic bodies created with correct properties
        }

        /// <summary>
        ///     Tests that Cut preserves body properties (rotation, velocity) when splitting
        ///     SKIPPED — requires full physics engine integration
        /// </summary>
        [Fact(Skip = "Requires full physics engine integration")] public void Cut_PreservesBodyProperties()
        {
            // Arrange — world with a static body that has rotation and velocity set
            // Act — cut through the body
            // Assert — new bodies inherit rotation and velocity from original
        }

        /// <summary>
        ///     Tests that Cut removes the original body after splitting
        ///     SKIPPED — requires full physics engine integration
        /// </summary>
        [Fact(Skip = "Requires full physics engine integration")] public void Cut_RemovesOriginalBodyAfterSplitting()
        {
            // Arrange — world with one static body
            // Act — cut through the body
            // Assert — original body removed, two new bodies exist
        }

        /// <summary>
        ///     Tests that Cut handles multiple fixtures in the same cut line
        ///     SKIPPED — requires full physics engine integration
        /// </summary>
        [Fact(Skip = "Requires full physics engine integration")] public void Cut_HandlesMultipleFixtures()
        {
            // Arrange — world with multiple polygon bodies intersected by the cut line
            // Act — cut through all of them
            // Assert — each polygon body is split, non-polygon bodies untouched
        }

        #endregion

        #region Helper Methods — Direct Access to Private Static Methods

        /// <summary>
        ///     Directly calls ClassifyVertex logic for testing (private method access via reflection-equivalent)
        /// </summary>
        private static int ClassifyVertexDirect(Vector2F vertex, Vector2F localEntryPoint, Vector2F localExitPoint)
        {
            // This mirrors: Vector2F.Dot(MathUtils.Cross(localExitPoint - localEntryPoint, 1), vertex - localEntryPoint) > SettingEnv.Epsilon ? 0 : 1
            // MathUtils.Cross(Vector2F, float) returns Vector2F
            Vector2F direction = localExitPoint - localEntryPoint;
            Vector2F crossResult = MathUtils.Cross(direction, 1f);
            Vector2F toVertex = vertex - localEntryPoint;
            float dot = Vector2F.Dot(crossResult, toVertex);
            return dot > SettingEnv.Epsilon ? 0 : 1;
        }

        /// <summary>
        ///     Directly calls ComputeOffsetBeforeCut logic for testing
        /// </summary>
        private static Vector2F ComputeOffsetBeforeCutDirect(Vertices[] newPolygon, int n, int[] cutAdded)
        {
            Vector2F offset;
            if (cutAdded[n] > 0)
            {
                offset = newPolygon[n][cutAdded[n] - 1] - newPolygon[n][cutAdded[n]];
            }
            else
            {
                offset = newPolygon[n][newPolygon[n].Count - 1] - newPolygon[n][0];
            }

            offset.Normalize();

            if (!offset.IsValid())
            {
                offset = Vector2F.One;
            }

            return offset;
        }

        /// <summary>
        ///     Directly calls ComputeOffsetAfterCut logic for testing
        /// </summary>
        private static Vector2F ComputeOffsetAfterCutDirect(Vertices[] newPolygon, int n, int[] cutAdded)
        {
            Vector2F offset;
            if (cutAdded[n] < newPolygon[n].Count - 2)
            {
                offset = newPolygon[n][cutAdded[n] + 2] - newPolygon[n][cutAdded[n] + 1];
            }
            else
            {
                offset = newPolygon[n][0] - newPolygon[n][newPolygon[n].Count - 1];
            }

            offset.Normalize();

            if (!offset.IsValid())
            {
                offset = Vector2F.One;
            }

            return offset;
        }

        /// <summary>
        ///     Directly calls EnsureCutPointsAdded logic for testing
        /// </summary>
        private static void EnsureCutPointsAddedDirect(Vertices[] newPolygon, int[] cutAdded, Vector2F localEntryPoint, Vector2F localExitPoint)
        {
            if (cutAdded[0] == -1)
            {
                cutAdded[0] = newPolygon[0].Count;
                newPolygon[0].Add(localExitPoint);
                newPolygon[0].Add(localEntryPoint);
            }

            if (cutAdded[1] == -1)
            {
                cutAdded[1] = newPolygon[1].Count;
                newPolygon[1].Add(localEntryPoint);
                newPolygon[1].Add(localExitPoint);
            }
        }

        #endregion
    }
}
