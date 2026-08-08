// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonGeneratorTest.cs
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
using Alis.Core.Physic.Common.Decomposition.CDT.Util;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Decomposition.CDT.Util
{
    /// <summary>
    /// The polygon generator test class
    /// </summary>
    public class PolygonGeneratorTest
    {
        /// <summary>
        /// Tests that polygon generator type should be accessible
        /// </summary>
        [Fact]
        public void PolygonGenerator_TypeShouldBeAccessible()
        {
            Assert.NotNull(typeof(PolygonGenerator));
        }

        /// <summary>
        /// Tests that RandomCircleSweep returns polygon with correct vertex count
        /// </summary>
        [Fact]
        public void RandomCircleSweep_WithValidInput_ReturnsPolygonWithCorrectVertexCount()
        {
            int vertexCount = 10;
            Physic.Common.Decomposition.CDT.Polygon.Polygon polygon = PolygonGenerator.RandomCircleSweep(100.0, vertexCount);

            Assert.Equal(vertexCount, polygon.GetPoints.Count);
        }

        /// <summary>
        /// Tests that RandomCircleSweep with many vertices returns correct count
        /// </summary>
        [Fact]
        public void RandomCircleSweep_WithManyVertices_ReturnsCorrectCount()
        {
            int vertexCount = 500;
            Physic.Common.Decomposition.CDT.Polygon.Polygon polygon = PolygonGenerator.RandomCircleSweep(100.0, vertexCount);

            Assert.Equal(vertexCount, polygon.GetPoints.Count);
        }

        /// <summary>
        /// Tests that RandomCircleSweep throws with fewer than 3 vertices
        /// </summary>
        [Fact]
        public void RandomCircleSweep_WithLessThanThreeVertices_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => PolygonGenerator.RandomCircleSweep(100.0, 2));
        }

        /// <summary>
        /// Tests that RandomCircleSweep2 returns polygon with correct vertex count
        /// </summary>
        [Fact]
        public void RandomCircleSweep2_WithValidInput_ReturnsPolygonWithCorrectVertexCount()
        {
            int vertexCount = 10;
            Physic.Common.Decomposition.CDT.Polygon.Polygon polygon = PolygonGenerator.RandomCircleSweep2(100.0, vertexCount);

            Assert.Equal(vertexCount, polygon.GetPoints.Count);
        }

        /// <summary>
        /// Tests that RandomCircleSweep2 with many vertices returns correct count
        /// </summary>
        [Fact]
        public void RandomCircleSweep2_WithManyVertices_ReturnsCorrectCount()
        {
            int vertexCount = 500;
            Physic.Common.Decomposition.CDT.Polygon.Polygon polygon = PolygonGenerator.RandomCircleSweep2(100.0, vertexCount);

            Assert.Equal(vertexCount, polygon.GetPoints.Count);
        }

        /// <summary>
        /// Tests that RandomCircleSweep2 throws with fewer than 3 vertices
        /// </summary>
        [Fact]
        public void RandomCircleSweep2_WithLessThanThreeVertices_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => PolygonGenerator.RandomCircleSweep2(100.0, 2));
        }

        /// <summary>
        /// Tests that Rng static field is accessible
        /// </summary>
        [Fact]
        public void Rng_StaticField_ShouldBeAccessible()
        {
            Assert.NotNull(PolygonGenerator.Rng);
        }
    }
}
