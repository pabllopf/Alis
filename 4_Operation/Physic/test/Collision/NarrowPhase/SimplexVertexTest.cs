// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimplexVertexTest.cs
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
using Alis.Core.Physic.Collision.NarrowPhase;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.NarrowPhase
{
    /// <summary>
    /// The simplex vertex test class
    /// </summary>
    public class SimplexVertexTest
    {
        /// <summary>
        /// Tests that test a property
        /// </summary>
        [Fact]
        public void Test_AProperty()
        {
            // Arrange
            SimplexVertex simplexVertex = new SimplexVertex();
            float expectedValue = 1.5f;
            
            // Act
            simplexVertex.A = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, simplexVertex.A);
        }
        
        /// <summary>
        /// Tests that test index a property
        /// </summary>
        [Fact]
        public void Test_IndexAProperty()
        {
            // Arrange
            SimplexVertex simplexVertex = new SimplexVertex();
            int expectedValue = 1;
            
            // Act
            simplexVertex.IndexA = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, simplexVertex.IndexA);
        }
        
        /// <summary>
        /// Tests that test index b property
        /// </summary>
        [Fact]
        public void Test_IndexBProperty()
        {
            // Arrange
            SimplexVertex simplexVertex = new SimplexVertex();
            int expectedValue = 2;
            
            // Act
            simplexVertex.IndexB = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, simplexVertex.IndexB);
        }
        
        /// <summary>
        /// Tests that test w property
        /// </summary>
        [Fact]
        public void Test_WProperty()
        {
            // Arrange
            SimplexVertex simplexVertex = new SimplexVertex();
            Vector2 expectedValue = new Vector2(1, 1);
            
            // Act
            simplexVertex.W = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, simplexVertex.W);
        }
        
        /// <summary>
        /// Tests that test wa property
        /// </summary>
        [Fact]
        public void Test_WaProperty()
        {
            // Arrange
            SimplexVertex simplexVertex = new SimplexVertex();
            Vector2 expectedValue = new Vector2(2, 2);
            
            // Act
            simplexVertex.Wa = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, simplexVertex.Wa);
        }
        
        /// <summary>
        /// Tests that test wb property
        /// </summary>
        [Fact]
        public void Test_WbProperty()
        {
            // Arrange
            SimplexVertex simplexVertex = new SimplexVertex();
            Vector2 expectedValue = new Vector2(3, 3);
            
            // Act
            simplexVertex.Wb = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, simplexVertex.Wb);
        }
    }
}