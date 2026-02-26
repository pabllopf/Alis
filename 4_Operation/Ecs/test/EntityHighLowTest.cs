// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityHighLowTest.cs
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

using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests the <see cref="EntityHighLow"/> struct.
    /// </summary>
    public class EntityHighLowTest
    {
        /// <summary>
        ///     Tests that entity id can be set and retrieved correctly.
        /// </summary>
        [Fact]
        public void EntityID_SetAndGet_ShouldWorkCorrectly()
        {
            // Arrange
            EntityHighLow entityHighLow = new EntityHighLow();
            
            // Act
            entityHighLow.EntityID = 42;
            
            // Assert
            Assert.Equal(42, entityHighLow.EntityID);
        }
        
        /// <summary>
        ///     Tests that entity low can be set and retrieved correctly.
        /// </summary>
        [Fact]
        public void EntityLow_SetAndGet_ShouldWorkCorrectly()
        {
            // Arrange
            EntityHighLow entityHighLow = new EntityHighLow();
            
            // Act
            entityHighLow.EntityLow = 123456;
            
            // Assert
            Assert.Equal(123456, entityHighLow.EntityLow);
        }
        
        /// <summary>
        ///     Tests that both fields can be set independently.
        /// </summary>
        [Fact]
        public void BothFields_SetIndependently_ShouldNotInterfere()
        {
            // Arrange
            EntityHighLow entityHighLow = new EntityHighLow();
            
            // Act
            entityHighLow.EntityID = 100;
            entityHighLow.EntityLow = 200;
            
            // Assert
            Assert.Equal(100, entityHighLow.EntityID);
            Assert.Equal(200, entityHighLow.EntityLow);
        }
        
        /// <summary>
        ///     Tests that default values are zero.
        /// </summary>
        [Fact]
        public void DefaultValues_ShouldBeZero()
        {
            // Arrange & Act
            EntityHighLow entityHighLow = new EntityHighLow();
            
            // Assert
            Assert.Equal(0, entityHighLow.EntityID);
            Assert.Equal(0, entityHighLow.EntityLow);
        }
        
        /// <summary>
        ///     Tests that negative values can be stored.
        /// </summary>
        [Fact]
        public void NegativeValues_ShouldBeStoredCorrectly()
        {
            // Arrange
            EntityHighLow entityHighLow = new EntityHighLow();
            
            // Act
            entityHighLow.EntityID = -1;
            entityHighLow.EntityLow = -1000;
            
            // Assert
            Assert.Equal(-1, entityHighLow.EntityID);
            Assert.Equal(-1000, entityHighLow.EntityLow);
        }
        
        /// <summary>
        ///     Tests that maximum int values can be stored.
        /// </summary>
        [Fact]
        public void MaxValues_ShouldBeStoredCorrectly()
        {
            // Arrange
            EntityHighLow entityHighLow = new EntityHighLow();
            
            // Act
            entityHighLow.EntityID = int.MaxValue;
            entityHighLow.EntityLow = int.MaxValue;
            
            // Assert
            Assert.Equal(int.MaxValue, entityHighLow.EntityID);
            Assert.Equal(int.MaxValue, entityHighLow.EntityLow);
        }
        
        /// <summary>
        ///     Tests that minimum int values can be stored.
        /// </summary>
        [Fact]
        public void MinValues_ShouldBeStoredCorrectly()
        {
            // Arrange
            EntityHighLow entityHighLow = new EntityHighLow();
            
            // Act
            entityHighLow.EntityID = int.MinValue;
            entityHighLow.EntityLow = int.MinValue;
            
            // Assert
            Assert.Equal(int.MinValue, entityHighLow.EntityID);
            Assert.Equal(int.MinValue, entityHighLow.EntityLow);
        }
    }
}

