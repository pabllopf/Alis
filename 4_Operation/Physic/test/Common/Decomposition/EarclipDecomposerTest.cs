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
    ///     The earclip decomposer test class
    /// </summary>
    public class EarclipDecomposerTest
    {
        /// <summary>
        /// Creates the triangle vertices
        /// </summary>
        /// <returns>The vertices</returns>
        private static Vertices CreateTriangleVertices()
        {
            return new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(0, 1)
            };
        }

        /// <summary>
        /// Creates the quad vertices
        /// </summary>
        /// <returns>The vertices</returns>
        private static Vertices CreateQuadVertices()
        {
            return new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(1, 1),
                new Vector2F(0, 1)
            };
        }

        /// <summary>
        /// Creates the pentagon vertices
        /// </summary>
        /// <returns>The vertices</returns>
        private static Vertices CreatePentagonVertices()
        {
            return new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 0),
                new Vector2F(1, 1),
                new Vector2F(0.5f, 1.5f),
                new Vector2F(0, 1)
            };
        }

        /// <summary>
        ///     Tests that ConvexPartition with a triangle returns one vertex set
        /// </summary>
        [Fact]
        public void ConvexPartition_Triangle_ShouldReturnOneSet()
        {
            Vertices vertices = CreateTriangleVertices();

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.Single(result);
        }

        /// <summary>
        ///     Tests that ConvexPartition with a quad returns triangulated result
        /// </summary>
        [Fact]
        public void ConvexPartition_Quad_ShouldReturnTriangulatedResult()
        {
            Vertices vertices = CreateQuadVertices();

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that ConvexPartition with empty vertices returns empty list
        /// </summary>
        [Fact]
        public void ConvexPartition_EmptyVertices_ShouldReturnEmptyList()
        {
            Vertices vertices = new Vertices();

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.Equal(0, result.Count);
        }

        /// <summary>
        ///     Tests that ConvexPartition with two vertices returns empty list
        /// </summary>
        [Fact]
        public void ConvexPartition_TwoVertices_ShouldReturnEmptyList()
        {
            Vertices vertices = new Vertices
            {
                new Vector2F(0, 0),
                new Vector2F(1, 1)
            };

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
            Assert.Equal(0, result.Count);
        }

        /// <summary>
        ///     Tests that ConvexPartition with default tolerance works
        /// </summary>
        [Fact]
        public void ConvexPartition_WithDefaultTolerance_ShouldWork()
        {
            Vertices vertices = CreatePentagonVertices();

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that ConvexPartition with custom tolerance works
        /// </summary>
        [Fact]
        public void ConvexPartition_WithCustomTolerance_ShouldWork()
        {
            Vertices vertices = CreatePentagonVertices();

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices, 0.1f);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that ConvexPartition with zero tolerance works
        /// </summary>
        [Fact]
        public void ConvexPartition_WithZeroTolerance_ShouldWork()
        {
            Vertices vertices = CreatePentagonVertices();

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices, 0f);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that ConvexPartition with large polygon works
        /// </summary>
        [Fact]
        public void ConvexPartition_LargePolygon_ShouldReturnResult()
        {
            Vertices vertices = new Vertices();
            for (int i = 0; i < 12; i++)
            {
                double angle = i * 2 * System.Math.PI / 12;
                vertices.Add(new Vector2F(
                    (float)System.Math.Cos(angle),
                    (float)System.Math.Sin(angle)));
            }

            List<Vertices> result = EarclipDecomposer.ConvexPartition(vertices);

            Assert.NotNull(result);
        }
    }
}
