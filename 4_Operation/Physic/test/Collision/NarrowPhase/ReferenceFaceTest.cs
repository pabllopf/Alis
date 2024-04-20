// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ReferenceFaceTest.cs
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
    /// The reference face test class
    /// </summary>
    public class ReferenceFaceTest
    {
        /// <summary>
        /// Tests that test i 1 property
        /// </summary>
        [Fact]
        public void Test_I1Property()
        {
            // Arrange
            ReferenceFace referenceFace = new ReferenceFace();
            int expectedValue = 1;
            
            // Act
            referenceFace.I1 = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, referenceFace.I1);
        }
        
        /// <summary>
        /// Tests that test i 2 property
        /// </summary>
        [Fact]
        public void Test_I2Property()
        {
            // Arrange
            ReferenceFace referenceFace = new ReferenceFace();
            int expectedValue = 2;
            
            // Act
            referenceFace.I2 = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, referenceFace.I2);
        }
        
        /// <summary>
        /// Tests that test v 1 property
        /// </summary>
        [Fact]
        public void Test_V1Property()
        {
            // Arrange
            ReferenceFace referenceFace = new ReferenceFace();
            Vector2 expectedValue = new Vector2(1, 1);
            
            // Act
            referenceFace.V1 = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, referenceFace.V1);
        }
        
        /// <summary>
        /// Tests that test v 2 property
        /// </summary>
        [Fact]
        public void Test_V2Property()
        {
            // Arrange
            ReferenceFace referenceFace = new ReferenceFace();
            Vector2 expectedValue = new Vector2(2, 2);
            
            // Act
            referenceFace.V2 = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, referenceFace.V2);
        }
        
        /// <summary>
        /// Tests that test normal property
        /// </summary>
        [Fact]
        public void Test_NormalProperty()
        {
            // Arrange
            ReferenceFace referenceFace = new ReferenceFace();
            Vector2 expectedValue = new Vector2(1, 0);
            
            // Act
            referenceFace.Normal = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, referenceFace.Normal);
        }
        
        /// <summary>
        /// Tests that test side normal 1 property
        /// </summary>
        [Fact]
        public void Test_SideNormal1Property()
        {
            // Arrange
            ReferenceFace referenceFace = new ReferenceFace();
            Vector2 expectedValue = new Vector2(0, 1);
            
            // Act
            referenceFace.SideNormal1 = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, referenceFace.SideNormal1);
        }
        
        /// <summary>
        /// Tests that test side offset 1 property
        /// </summary>
        [Fact]
        public void Test_SideOffset1Property()
        {
            // Arrange
            ReferenceFace referenceFace = new ReferenceFace();
            float expectedValue = 1.5f;
            
            // Act
            referenceFace.SideOffset1 = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, referenceFace.SideOffset1);
        }
        
        /// <summary>
        /// Tests that test side normal 2 property
        /// </summary>
        [Fact]
        public void Test_SideNormal2Property()
        {
            // Arrange
            ReferenceFace referenceFace = new ReferenceFace();
            Vector2 expectedValue = new Vector2(1, 0);
            
            // Act
            referenceFace.SideNormal2 = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, referenceFace.SideNormal2);
        }
        
        /// <summary>
        /// Tests that test side offset 2 property
        /// </summary>
        [Fact]
        public void Test_SideOffset2Property()
        {
            // Arrange
            ReferenceFace referenceFace = new ReferenceFace();
            float expectedValue = 2.5f;
            
            // Act
            referenceFace.SideOffset2 = expectedValue;
            
            // Assert
            Assert.Equal(expectedValue, referenceFace.SideOffset2);
        }
    }
}