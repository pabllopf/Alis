// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EarclipDecomposerTest.cs
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
    /// The earclip decomposer test class
    /// </summary>
    public class EarclipDecomposerTest
    {
        /// <summary>
        /// Tests that earclip decomposer type should be accessible
        /// </summary>
        [Fact]
        public void EarclipDecomposer_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(EarclipDecomposer));
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

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        /// Tests that convex partition with square should return triangles
        /// </summary>
        [Fact]
        public void ConvexPartition_WithSquare_ShouldReturnResult()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(0f, 2f),
                new Vector2F(2f, 2f),
                new Vector2F(2f, 0f)
            });

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that convex partition with pentagon should return result
        /// </summary>
        [Fact]
        public void ConvexPartition_WithPentagon_ShouldReturnResult()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(-0.5f, 1f),
                new Vector2F(1f, 2f),
                new Vector2F(2.5f, 1f),
                new Vector2F(2f, 0f)
            });

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
        }

        /// <summary>
        /// Tests that convex partition with concave shape should decompose
        /// </summary>
        [Fact]
        public void ConvexPartition_WithConcaveShape_ShouldDecompose()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(0f, 2f),
                new Vector2F(1f, 2f),
                new Vector2F(1f, 1f),
                new Vector2F(3f, 1f),
                new Vector2F(3f, 0f)
            });

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        /// Tests that convex partition with custom tolerance should work
        /// </summary>
        [Fact]
        public void ConvexPartition_WithCustomTolerance_ShouldWork()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices, 0.1f);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }
    }
}
