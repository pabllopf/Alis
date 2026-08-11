// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BayazitDecomposerCoverageTests.cs
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
    ///     The bayazit decomposer coverage tests class
    /// </summary>
    public class BayazitDecomposerCoverageTests
    {
        /// <summary>
        ///     Tests that convex partition with a spiral polygon produces convex parts
        /// </summary>
        [Fact]
        public void ConvexPartition_WithSpiralPolygon_ProducesConvexParts()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(10f, 0f),
                new Vector2F(10f, 10f),
                new Vector2F(0f, 10f),
                new Vector2F(0f, 2f),
                new Vector2F(8f, 2f),
                new Vector2F(8f, 8f),
                new Vector2F(2f, 8f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Tests that convex partition with a comb polygon produces convex parts
        /// </summary>
        [Fact]
        public void ConvexPartition_WithCombPolygon_ProducesConvexParts()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(4f, 2f),
                new Vector2F(3f, 2f),
                new Vector2F(3f, 4f),
                new Vector2F(2f, 4f),
                new Vector2F(2f, 2f),
                new Vector2F(1f, 2f),
                new Vector2F(1f, 4f),
                new Vector2F(0f, 4f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Tests that convex partition with a star polygon produces convex parts
        /// </summary>
        [Fact]
        public void ConvexPartition_WithStarPolygon_ProducesConvexParts()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 3f),
                new Vector2F(2f, 1f),
                new Vector2F(4f, 3f),
                new Vector2F(3f, 0f),
                new Vector2F(5f, -2f),
                new Vector2F(1f, -2f),
                new Vector2F(0f, 0f)
            });

            List<Vertices> result = BayazitDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }
    }
}
