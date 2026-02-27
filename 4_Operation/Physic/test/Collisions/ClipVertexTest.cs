// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ClipVertexTest.cs
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
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The clip vertex test class
    /// </summary>
    public class ClipVertexTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize with default values
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            ClipVertex clipVertex = new ClipVertex();
            
            Assert.Equal(default(ContactId), clipVertex.Id);
            Assert.Equal(Vector2F.Zero, clipVertex.V);
        }

        /// <summary>
        ///     Tests that id property should set and get correctly
        /// </summary>
        [Fact]
        public void IdProperty_ShouldSetAndGetCorrectly()
        {
            ClipVertex clipVertex = new ClipVertex();
            ContactId contactId = new ContactId();
            contactId.Key = 12345;
            
            clipVertex.Id = contactId;
            
            Assert.Equal(contactId.Key, clipVertex.Id.Key);
        }

        /// <summary>
        ///     Tests that v property should set and get correctly
        /// </summary>
        [Fact]
        public void VProperty_ShouldSetAndGetCorrectly()
        {
            ClipVertex clipVertex = new ClipVertex();
            Vector2F vector = new Vector2F(3.5f, 4.5f);
            
            clipVertex.V = vector;
            
            Assert.Equal(vector, clipVertex.V);
        }

        /// <summary>
        ///     Tests that clip vertex should support positive coordinates
        /// </summary>
        [Fact]
        public void ClipVertex_ShouldSupportPositiveCoordinates()
        {
            ClipVertex clipVertex = new ClipVertex
            {
                V = new Vector2F(10.5f, 20.3f)
            };
            
            Assert.Equal(10.5f, clipVertex.V.X);
            Assert.Equal(20.3f, clipVertex.V.Y);
        }

        /// <summary>
        ///     Tests that clip vertex should support negative coordinates
        /// </summary>
        [Fact]
        public void ClipVertex_ShouldSupportNegativeCoordinates()
        {
            ClipVertex clipVertex = new ClipVertex
            {
                V = new Vector2F(-5.2f, -8.7f)
            };
            
            Assert.Equal(-5.2f, clipVertex.V.X);
            Assert.Equal(-8.7f, clipVertex.V.Y);
        }

        /// <summary>
        ///     Tests that clip vertex should support zero coordinates
        /// </summary>
        [Fact]
        public void ClipVertex_ShouldSupportZeroCoordinates()
        {
            ClipVertex clipVertex = new ClipVertex
            {
                V = Vector2F.Zero
            };
            
            Assert.Equal(0.0f, clipVertex.V.X);
            Assert.Equal(0.0f, clipVertex.V.Y);
        }

        /// <summary>
        ///     Tests that clip vertex should be value type
        /// </summary>
        [Fact]
        public void ClipVertex_ShouldBeValueType()
        {
            ClipVertex vertex1 = new ClipVertex { V = new Vector2F(1.0f, 2.0f) };
            ClipVertex vertex2 = vertex1;
            
            vertex2.V = new Vector2F(3.0f, 4.0f);
            
            Assert.NotEqual(vertex1.V, vertex2.V);
        }

        /// <summary>
        ///     Tests that clip vertex should handle large coordinate values
        /// </summary>
        [Fact]
        public void ClipVertex_ShouldHandleLargeCoordinateValues()
        {
            ClipVertex clipVertex = new ClipVertex
            {
                V = new Vector2F(float.MaxValue / 2, float.MaxValue / 2)
            };
            
            Assert.True(clipVertex.V.X > 0);
            Assert.True(clipVertex.V.Y > 0);
        }

        /// <summary>
        ///     Tests that clip vertex should handle small coordinate values
        /// </summary>
        [Fact]
        public void ClipVertex_ShouldHandleSmallCoordinateValues()
        {
            ClipVertex clipVertex = new ClipVertex
            {
                V = new Vector2F(float.Epsilon, float.Epsilon)
            };
            
            Assert.Equal(float.Epsilon, clipVertex.V.X);
            Assert.Equal(float.Epsilon, clipVertex.V.Y);
        }
    }
}

