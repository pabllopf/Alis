// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MarchingSquaresCombineScanLineCoverageTests.cs
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
    ///     The marching squares combine scan line coverage tests class
    /// </summary>
    public class MarchingSquaresCombineScanLineCoverageTests
    {
        /// <summary>
        ///     Tests that detect squares with combine skips a scan line start whose successor does not
        ///     lie on the same scan line, keeping the affected cells as separate polygons instead of
        ///     merging them across rows.
        /// </summary>
        [Fact]
        public void DetectSquares_WhenScanLineStartHasNoOnLineSuccessor_SkipsMergeWithoutThrowing()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    f[x, y] = 1;
                }
            }

            f[1, 0] = -1;

            Aabb domain = new Aabb(new Vector2F(-0.5f, 0f), new Vector2F(1.5f, 2f));

            List<Vertices> separated = MarchingSquares.DetectSquares(domain, 0.3f, 0.3f, f, 1, false);
            List<Vertices> combined = MarchingSquares.DetectSquares(domain, 0.3f, 0.3f, f, 1, true);

            Assert.NotNull(combined);
            Assert.Equal(12, separated.Count);
            Assert.Equal(4, combined.Count);
            Assert.True(combined.Count < separated.Count);

            foreach (Vertices polygon in combined)
            {
                Assert.True(polygon.Count >= 3);
            }
        }

        /// <summary>
        ///     Tests that detect squares with combine merges a diamond of four isolated cells into a
        ///     single polygon when the upper cell references the same polygon as the lower cell,
        ///     which exercises the shared polygon guard of the combine check.
        /// </summary>
        [Fact]
        public void DetectSquares_WhenLowerAndUpperCellSharePolygon_KeepsSingleCombinedPolygon()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    f[x, y] = 1;
                }
            }

            f[1, 0] = -1;
            f[0, 1] = -1;
            f[2, 1] = -1;
            f[1, 2] = -1;

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(2, 2));

            List<Vertices> separated = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 0, false);
            List<Vertices> combined = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 0, true);

            Assert.Equal(4, separated.Count);
            Assert.Single(combined);
            Assert.Equal(16, combined[0].Count);
        }
    }
}
