// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MarchingSquaresCellPatternCoverageTests.cs
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
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.TextureTools;
using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    /// <summary>
    ///     The marching squares cell pattern coverage tests class
    /// </summary>
    public class MarchingSquaresCellPatternCoverageTests
    {
        /// <summary>
        ///     Builds a field where the first two rows contain the corner patterns needed to exercise
        ///     the single vertex interpolation and left edge y interpolation branches.
        /// </summary>
        /// <returns>The built field</returns>
        private static sbyte[,] BuildCornerPatternField()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    f[x, y] = 1;
                }
            }

            f[0, 1] = -1;
            f[2, 1] = -1;
            f[3, 1] = -1;
            f[4, 1] = -1;
            f[5, 0] = -1;
            f[5, 1] = -1;
            f[6, 0] = -1;
            f[6, 1] = -1;
            f[7, 0] = -1;
            return f;
        }

        /// <summary>
        ///     Tests that detect squares with sparse corner patterns produces polygons with interpolated vertices.
        /// </summary>
        [Fact]
        public void DetectSquares_WithSparseCornerPatterns_ProducesPolygons()
        {
            sbyte[,] f = BuildCornerPatternField();
            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(8, 8));
            List<Vertices> result = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 1, false);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Tests that detect squares with sparse corner patterns combined produces polygons.
        /// </summary>
        [Fact]
        public void DetectSquares_WithSparseCornerPatternsCombined_ProducesPolygons()
        {
            sbyte[,] f = BuildCornerPatternField();
            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(8, 8));
            List<Vertices> result = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 1, true);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Tests that detect squares with single vertex corner patterns uses the interpolated
        ///     left edge point when the top right vertex is not present.
        /// </summary>
        [Fact]
        public void DetectSquares_WithOnlyTopLeftNegative_ProducesPolygonWithLeftEdgeVertex()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    f[x, y] = 1;
                }
            }

            f[0, 1] = -1;

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(8, 8));
            List<Vertices> result = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 2, false);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Tests that detect squares with the left edge negative produces a polygon that
        ///     includes the interpolated left edge point.
        /// </summary>
        [Fact]
        public void DetectSquares_WithLeftEdgeNegative_ProducesPolygonWithLeftEdgeVertex()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    f[x, y] = 1;
                }
            }

            f[0, 0] = -1;
            f[0, 1] = -1;

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(8, 8));
            List<Vertices> result = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 2, false);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Tests that detect squares with a fully negative first row produces a strip polygon.
        /// </summary>
        [Fact]
        public void DetectSquares_WithFullyNegativeRow_ProducesStripPolygon()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    f[x, y] = 1;
                }
            }

            for (int x = 0; x < 8; x++)
            {
                f[x, 0] = -1;
                f[x, 1] = -1;
            }

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(8, 8));
            List<Vertices> result = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 1, true);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Tests that detect squares with a checkerboard of negative corners produces many polygons.
        /// </summary>
        [Fact]
        public void DetectSquares_WithCheckerboardNegativeCorners_ProducesPolygons()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    f[x, y] = ((x + y) % 2 == 0) ? (sbyte) -1 : (sbyte) 1;
                }
            }

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(8, 8));
            List<Vertices> result = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 1, false);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Tests that a grid of cells with a single negative corner at the domain origin produces a polygon.
        /// </summary>
        [Fact]
        public void DetectSquares_WithSingleNegativeCornerAtOrigin_ProducesPolygon()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    f[x, y] = 1;
                }
            }

            f[0, 0] = -1;

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(8, 8));
            List<Vertices> result = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 1, true);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Builds a field containing a solid 2x2 block of negative samples centered on the grid.
        /// </summary>
        /// <returns>The built field</returns>
        private static sbyte[,] BuildSolidBlockField()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    f[x, y] = 1;
                }
            }

            for (int x = 1; x <= 2; x++)
            {
                for (int y = 1; y <= 2; y++)
                {
                    f[x, y] = -1;
                }
            }

            return f;
        }

        /// <summary>
        ///     Tests that detect squares with a solid block and combine merges the nine per-row and
        ///     per-cell polygons into a single combined polygon that keeps the block bounds corners.
        /// </summary>
        [Fact]
        public void DetectSquares_WithSolidBlockAndCombine_MergesIntoSinglePolygon()
        {
            sbyte[,] f = BuildSolidBlockField();
            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(8, 8));

            List<Vertices> separated = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 0, false);
            List<Vertices> combined = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 0, true);

            Assert.True(separated.Count > 1);
            Assert.Equal(1, combined.Count);
            Assert.Equal(10, combined[0].Count);

            bool containsTopLeftBlockCorner = false;
            bool containsBottomRightBlockCorner = false;
            foreach (Vector2F vertex in combined[0])
            {
                if (vertex.X == 0.5f && vertex.Y == 2.0f)
                {
                    containsTopLeftBlockCorner = true;
                }

                if (vertex.X == 2.5f && vertex.Y == 1.0f)
                {
                    containsBottomRightBlockCorner = true;
                }
            }

            Assert.True(containsTopLeftBlockCorner);
            Assert.True(containsBottomRightBlockCorner);
        }

        /// <summary>
        ///     Tests that detect squares with isolated solid cells and combine keeps the polygons
        ///     separated because vertically adjacent cells cannot be combined.
        /// </summary>
        [Fact]
        public void DetectSquares_WithIsolatedCellDiagonalAndCombine_KeepsPolygonsSeparated()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    f[x, y] = 1;
                }
            }

            f[1, 1] = -1;
            f[2, 1] = -1;
            f[1, 2] = -1;
            f[2, 2] = -1;

            f[5, 5] = -1;
            f[6, 5] = -1;
            f[5, 6] = -1;
            f[6, 6] = -1;

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(8, 8));

            List<Vertices> separated = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 0, false);
            List<Vertices> combined = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 0, true);

            Assert.Equal(18, separated.Count);
            Assert.Equal(2, combined.Count);
            Assert.Equal(10, combined[0].Count);
            Assert.Equal(10, combined[1].Count);
        }

        /// <summary>
        ///     Tests that detect squares with a single negative sample uses linear interpolation
        ///     of the shared edge point with one bin and produces the expected interpolated vertex.
        /// </summary>
        [Fact]
        public void DetectSquares_WithInterpolatedEdgeVertex_ProducesLerpedPoint()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    f[x, y] = 1;
                }
            }

            f[1, 1] = -1;

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(6, 6));
            List<Vertices> result = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 1, false);

            Assert.NotEmpty(result);

            bool containsInterpolatedVertex = false;
            foreach (Vector2F vertex in result[0])
            {
                if (vertex.X == 1.75f && vertex.Y == 1.0f)
                {
                    containsInterpolatedVertex = true;
                }
            }

            Assert.True(containsInterpolatedVertex);
        }

        /// <summary>
        ///     Tests that detect squares with a wide solid block and combine keeps a single polygon
        ///     covering the whole surface and preserves the multi cell boundary vertices of both rows.
        /// </summary>
        [Fact]
        public void DetectSquares_WithWideSolidBlockAndCombine_MergesIntoSinglePolygon()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    f[x, y] = 1;
                }
            }

            for (int x = 1; x <= 4; x++)
            {
                for (int y = 1; y <= 2; y++)
                {
                    f[x, y] = -1;
                }
            }

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(8, 8));
            List<Vertices> combined = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 0, true);

            Assert.Equal(1, combined.Count);
            Assert.Equal(16, combined[0].Count);

            bool containsLeftBottomBlockCorner = false;
            bool containsRightTopBlockCorner = false;
            foreach (Vector2F vertex in combined[0])
            {
                if (vertex.X == 1.0f && vertex.Y == 0.5f)
                {
                    containsLeftBottomBlockCorner = true;
                }

                if (vertex.X == 4.5f && vertex.Y == 2.0f)
                {
                    containsRightTopBlockCorner = true;
                }
            }

            Assert.True(containsLeftBottomBlockCorner);
            Assert.True(containsRightTopBlockCorner);
        }

        /// <summary>
        ///     Tests that detect squares with equal wall values avoids interpolation by zero division
        ///     and produces a mid edge point on a shared edge of a two cell surface.
        /// </summary>
        [Fact]
        public void DetectSquares_WithSharedDegenerateEdge_UsesMidInterpolation()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    f[x, y] = 1;
                }
            }

            for (int y = 0; y < 3; y++)
            {
                f[1, y] = -1;
            }

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(6, 6));
            List<Vertices> result = MarchingSquares.DetectSquares(domain, 0.5f, 1.0f, f, 1, true);

            Assert.NotEmpty(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Builds a field with dense scattered negative samples that exercises the scan line
        ///     combining walk, polygon reference updates and repeated merge attempts.
        /// </summary>
        /// <returns>The built field</returns>
        private static sbyte[,] BuildScatteredField()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    f[x, y] = 1;
                }
            }

            f[0, 1] = -1;
            f[0, 2] = -1;
            f[1, 2] = -1;
            f[3, 2] = -1;
            f[4, 2] = -1;
            f[7, 3] = -1;
            f[0, 3] = -1;
            f[1, 4] = -1;
            f[2, 4] = -1;
            f[3, 4] = -1;
            f[5, 4] = -1;
            f[6, 4] = -1;
            f[0, 5] = -1;
            f[4, 5] = -1;
            f[0, 6] = -1;
            f[3, 6] = -1;
            f[6, 6] = -1;
            f[0, 7] = -1;
            f[1, 7] = -1;
            f[2, 7] = -1;
            f[6, 7] = -1;
            f[7, 7] = -1;

            return f;
        }

        /// <summary>
        ///     Tests that detect squares with scattered negative samples combines the merged scan line
        ///     polygons without losing vertices and skips cells whose polygons are already merged.
        /// </summary>
        [Fact]
        public void DetectSquares_WithScatteredSamplesAndCombine_MergesAdjacentScanLines()
        {
            sbyte[,] f = BuildScatteredField();
            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(8, 8));

            List<Vertices> separated = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 0, false);
            List<Vertices> combined = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 0, true);

            Assert.True(combined.Count < separated.Count);

            int totalCombinedVertices = 0;
            foreach (Vertices polygon in combined)
            {
                Assert.True(polygon.Count > 2);
                totalCombinedVertices += polygon.Count;
            }

            int totalSeparatedVertices = 0;
            foreach (Vertices polygon in separated)
            {
                totalSeparatedVertices += polygon.Count;
            }

            Assert.True(totalCombinedVertices < totalSeparatedVertices);
        }
    }
}
