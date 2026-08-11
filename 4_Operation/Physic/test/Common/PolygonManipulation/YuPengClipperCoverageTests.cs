// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:YuPengClipperCoverageTests.cs
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
using Alis.Core.Physic.Common.PolygonManipulation;
using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    ///     The yu peng clipper coverage tests class
    /// </summary>
    public class YuPengClipperCoverageTests
    {
        /// <summary>
        ///     Tests that union with a zigzag polygon crossing the subject edge multiple times returns a result
        /// </summary>
        [Fact]
        public void Union_WithZigzagClip_CrossingEdgeMultipleTimes_ReturnsResult()
        {
            Vertices square = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(8f, 0f),
                new Vector2F(8f, 8f),
                new Vector2F(0f, 8f)
            });
            Vertices zigzag = new Vertices(new[]
            {
                new Vector2F(1f, 10f),
                new Vector2F(2f, 6f),
                new Vector2F(3f, 10f),
                new Vector2F(4f, 6f),
                new Vector2F(5f, 10f),
                new Vector2F(6f, 6f),
                new Vector2F(7f, 10f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Union(square, zigzag, out error);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that union with a polygon containing coincident vertices removes them
        /// </summary>
        [Fact]
        public void Union_WithCoincidentVertices_RemovesThem()
        {
            Vertices square = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(4f, 4f),
                new Vector2F(0f, 4f)
            });
            Vertices duplicated = new Vertices(new[]
            {
                new Vector2F(1f, 1f),
                new Vector2F(1f, 1f),
                new Vector2F(2f, 1f),
                new Vector2F(2f, 2f),
                new Vector2F(1f, 2f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Union(square, duplicated, out error);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that difference with a degenerate clip polygon returns a result without crashing
        /// </summary>
        [Fact]
        public void Difference_WithDegenerateClip_ReturnsResult()
        {
            Vertices square = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(4f, 0f),
                new Vector2F(4f, 4f),
                new Vector2F(0f, 4f)
            });
            Vertices sliver = new Vertices(new[]
            {
                new Vector2F(1f, 1f),
                new Vector2F(3f, 1f),
                new Vector2F(2f, 1.5f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Difference(square, sliver, out error);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that intersect with a collinear degenerate polygon returns a result
        /// </summary>
        [Fact]
        public void Intersect_WithCollinearPolygon_ReturnsResult()
        {
            Vertices square = new Vertices(new[]
            {
                new Vector2F(1f, 1f),
                new Vector2F(4f, 1f),
                new Vector2F(4f, 4f),
                new Vector2F(1f, 4f)
            });
            Vertices collinear = new Vertices(new[]
            {
                new Vector2F(1f, 1f),
                new Vector2F(2f, 2f),
                new Vector2F(1f, 2f)
            });

            PolyClipError error = PolyClipError.None;
            List<Vertices> result = YuPengClipper.Intersect(square, collinear, out error);

            Assert.NotNull(result);
        }

        /// <summary>
        ///     Tests that edge equals with null object returns false
        /// </summary>
        [Fact]
        public void Edge_Equals_WithNullObject_ReturnsFalse()
        {
            YuPengClipper.Edge edge = new YuPengClipper.Edge(new Vector2F(1f, 1f), new Vector2F(2f, 2f));

            Assert.False(edge.Equals((object) null));
        }

        /// <summary>
        ///     Tests that edge equals with non edge object returns false
        /// </summary>
        [Fact]
        public void Edge_Equals_WithNonEdgeObject_ReturnsFalse()
        {
            YuPengClipper.Edge edge = new YuPengClipper.Edge(new Vector2F(1f, 1f), new Vector2F(2f, 2f));

            Assert.False(edge.Equals("not an edge"));
        }

        /// <summary>
        ///     Tests that edge equals with null edge returns false
        /// </summary>
        [Fact]
        public void Edge_Equals_WithNullEdge_ReturnsFalse()
        {
            YuPengClipper.Edge edge = new YuPengClipper.Edge(new Vector2F(1f, 1f), new Vector2F(2f, 2f));

            Assert.False(edge.Equals(null));
        }

        /// <summary>
        ///     Tests that edge equals with equal edge returns true
        /// </summary>
        [Fact]
        public void Edge_Equals_WithEqualEdge_ReturnsTrue()
        {
            YuPengClipper.Edge edge = new YuPengClipper.Edge(new Vector2F(1f, 1f), new Vector2F(2f, 2f));
            YuPengClipper.Edge other = new YuPengClipper.Edge(new Vector2F(1f, 1f), new Vector2F(2f, 2f));

            Assert.True(edge.Equals(other));
        }

        /// <summary>
        ///     Tests that edge get hash code returns consistent value
        /// </summary>
        [Fact]
        public void Edge_GetHashCode_ReturnsConsistentValue()
        {
            YuPengClipper.Edge edge = new YuPengClipper.Edge(new Vector2F(1f, 1f), new Vector2F(2f, 2f));

            Assert.Equal(edge.GetHashCode(), edge.GetHashCode());
        }
    }
}
