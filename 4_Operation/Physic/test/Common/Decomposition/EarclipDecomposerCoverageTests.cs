// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EarclipDecomposerCoverageTests.cs
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
    ///     The earclip decomposer coverage tests class
    /// </summary>
    public class EarclipDecomposerCoverageTests
    {
        /// <summary>
        ///     Tests that triangulate polygon with a pinch point producing a two vertex part triangulates the other part
        /// </summary>
        [Fact]
        public void TriangulatePolygon_WithSmallPinchPart_TriangulatesOtherPart()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(0f, 0f),
                new Vector2F(4f, 4f),
                new Vector2F(0f, 4f)
            });

            List<Vertices> result = EarclipDecomposer.TriangulatePolygon(vertices, 1e-6f);

            Assert.NotNull(result);
            Assert.True(result.Count >= 1);
        }

        /// <summary>
        ///     Tests that resolve pinch point with less than three vertices returns false
        /// </summary>
        [Fact]
        public void ResolvePinchPoint_WithLessThanThreeVertices_ReturnsFalse()
        {
            Vertices pin = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f)
            });

            bool result = EarclipDecomposer.ResolvePinchPoint(pin, out Vertices poutA, out Vertices poutB, 1e-6f);

            Assert.False(result);
            Assert.NotNull(poutA);
            Assert.NotNull(poutB);
        }

        /// <summary>
        ///     Tests that is ear with invalid index returns false
        /// </summary>
        [Fact]
        public void IsEar_WithInvalidIndex_ReturnsFalse()
        {
            float[] xv = { 0f, 1f, 1f, 0f };
            float[] yv = { 0f, 0f, 1f, 1f };

            bool result = EarclipDecomposer.IsEar(4, xv, yv, 4);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that is ear with index out of range returns false
        /// </summary>
        [Fact]
        public void IsEar_WithNegativeIndex_ReturnsFalse()
        {
            float[] xv = { 0f, 1f, 1f, 0f };
            float[] yv = { 0f, 0f, 1f, 1f };

            bool result = EarclipDecomposer.IsEar(-1, xv, yv, 4);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that is ear with a vertex inside the candidate triangle returns false
        /// </summary>
        [Fact]
        public void IsEar_WithVertexInsideCandidateTriangle_ReturnsFalse()
        {
            float[] xv = { 0f, 0f, 1f, 3f, 3f };
            float[] yv = { 0f, 3f, 1f, 3f, 0f };

            bool result = EarclipDecomposer.IsEar(0, xv, yv, 5);

            Assert.False(result);
        }
    }
}
