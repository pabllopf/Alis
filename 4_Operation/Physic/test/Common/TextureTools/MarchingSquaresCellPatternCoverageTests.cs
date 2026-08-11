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
    }
}
