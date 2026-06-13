// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceProxyTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The distance proxy test class
    /// </summary>
    public class DistanceProxyTest
    {
        /// <summary>
        /// Tests that constructor with circle shape should set single vertex at center
        /// </summary>
        [Fact]
        public void Constructor_WithCircleShape_ShouldSetSingleVertexAtCenter()
        {
            CircleShape circle = new CircleShape(1f, 1f);
            DistanceProxy proxy = new DistanceProxy(circle, 0);

            Vector2F supportVertex = proxy.GetSupportVertex(new Vector2F(1f, 0f));

            Assert.Equal(Vector2F.Zero, supportVertex);
        }

        /// <summary>
        /// Tests that constructor with circle shape should return index zero for any direction
        /// </summary>
        [Fact]
        public void Constructor_WithCircleShape_ShouldReturnIndexZeroForAnyDirection()
        {
            CircleShape circle = new CircleShape(1f, 1f);
            DistanceProxy proxy = new DistanceProxy(circle, 0);

            int supportIndex = proxy.GetSupport(new Vector2F(1f, 0f));

            Assert.Equal(0, supportIndex);
        }

        /// <summary>
        /// Tests that constructor with polygon shape should return correct support index
        /// </summary>
        [Fact]
        public void Constructor_WithPolygonShape_ShouldReturnCorrectSupportIndex()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });
            PolygonShape polygon = new PolygonShape(vertices, 1f);
            DistanceProxy proxy = new DistanceProxy(polygon, 0);

            int supportX = proxy.GetSupport(new Vector2F(1f, 0f));
            int supportY = proxy.GetSupport(new Vector2F(0f, 1f));
            int supportNegX = proxy.GetSupport(new Vector2F(-1f, 0f));

            Assert.Equal(1, supportX);
            Assert.Equal(2, supportY);
            Assert.Equal(0, supportNegX);
        }

        /// <summary>
        /// Tests that constructor with polygon shape should return correct support vertex
        /// </summary>
        [Fact]
        public void Constructor_WithPolygonShape_ShouldReturnCorrectSupportVertex()
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(0f, 0f),
                new Vector2F(1f, 0f),
                new Vector2F(0f, 1f)
            });
            PolygonShape polygon = new PolygonShape(vertices, 1f);
            DistanceProxy proxy = new DistanceProxy(polygon, 0);

            Vector2F supportVertexX = proxy.GetSupportVertex(new Vector2F(1f, 0f));
            Vector2F supportVertexY = proxy.GetSupportVertex(new Vector2F(0f, 1f));
            Vector2F supportVertexNegX = proxy.GetSupportVertex(new Vector2F(-1f, 0f));

            Assert.Equal(new Vector2F(1f, 0f), supportVertexX);
            Assert.Equal(new Vector2F(0f, 1f), supportVertexY);
            Assert.Equal(new Vector2F(0f, 0f), supportVertexNegX);
        }

        /// <summary>
        /// Tests that constructor with edge shape should set two vertices
        /// </summary>
        [Fact]
        public void Constructor_WithEdgeShape_ShouldSetTwoVertices()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0f, 0f), new Vector2F(1f, 0f));
            DistanceProxy proxy = new DistanceProxy(edge, 0);

            Vector2F supportRight = proxy.GetSupportVertex(new Vector2F(1f, 0f));
            Vector2F supportLeft = proxy.GetSupportVertex(new Vector2F(-1f, 0f));

            Assert.Equal(new Vector2F(1f, 0f), supportRight);
            Assert.Equal(new Vector2F(0f, 0f), supportLeft);
        }

        /// <summary>
        /// Tests that constructor with edge shape should return correct support index
        /// </summary>
        [Fact]
        public void Constructor_WithEdgeShape_ShouldReturnCorrectSupportIndex()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0f, 0f), new Vector2F(1f, 0f));
            DistanceProxy proxy = new DistanceProxy(edge, 0);

            int supportRight = proxy.GetSupport(new Vector2F(1f, 0f));
            int supportLeft = proxy.GetSupport(new Vector2F(-1f, 0f));

            Assert.Equal(1, supportRight);
            Assert.Equal(0, supportLeft);
        }
    }
}
