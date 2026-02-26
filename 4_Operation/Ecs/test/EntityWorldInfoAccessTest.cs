// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityWorldInfoAccessTest.cs
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

using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests the <see cref="EntityWorldInfoAccess"/> struct.
    /// </summary>
    public class EntityWorldInfoAccessTest
    {
        /// <summary>
        ///     Tests that entity id only can be set and retrieved.
        /// </summary>
        [Fact]
        public void EntityIDOnly_SetAndGet_ShouldWorkCorrectly()
        {
            // Arrange
            EntityWorldInfoAccess info = new EntityWorldInfoAccess();
            GameObjectIdOnly entityIdOnly = new GameObjectIdOnly(42, 1);
            
            // Act
            info.EntityIDOnly = entityIdOnly;
            
            // Assert
            Assert.Equal(42, info.EntityIDOnly.ID);
            Assert.Equal((ushort)1, info.EntityIDOnly.Version);
        }
        
        /// <summary>
        ///     Tests that world id can be set and retrieved.
        /// </summary>
        [Fact]
        public void WorldID_SetAndGet_ShouldWorkCorrectly()
        {
            // Arrange
            EntityWorldInfoAccess info = new EntityWorldInfoAccess();
            
            // Act
            info.WorldID = 5;
            
            // Assert
            Assert.Equal((ushort)5, info.WorldID);
        }
        
        /// <summary>
        ///     Tests that both fields can be set independently.
        /// </summary>
        [Fact]
        public void BothFields_SetIndependently_ShouldNotInterfere()
        {
            // Arrange
            EntityWorldInfoAccess info = new EntityWorldInfoAccess();
            GameObjectIdOnly entityIdOnly = new GameObjectIdOnly(100, 2);
            
            // Act
            info.EntityIDOnly = entityIdOnly;
            info.WorldID = 10;
            
            // Assert
            Assert.Equal(100, info.EntityIDOnly.ID);
            Assert.Equal((ushort)2, info.EntityIDOnly.Version);
            Assert.Equal((ushort)10, info.WorldID);
        }
        
        /// <summary>
        ///     Tests that default values are initialized correctly.
        /// </summary>
        [Fact]
        public void DefaultValues_ShouldBeInitialized()
        {
            // Arrange & Act
            EntityWorldInfoAccess info = new EntityWorldInfoAccess();
            
            // Assert
            Assert.Equal(0, info.EntityIDOnly.ID);
            Assert.Equal((ushort)0, info.EntityIDOnly.Version);
            Assert.Equal((ushort)0, info.WorldID);
        }
        
        /// <summary>
        ///     Tests that maximum ushort values can be stored for world id.
        /// </summary>
        [Fact]
        public void WorldID_MaxValue_ShouldBeStoredCorrectly()
        {
            // Arrange
            EntityWorldInfoAccess info = new EntityWorldInfoAccess();
            
            // Act
            info.WorldID = ushort.MaxValue;
            
            // Assert
            Assert.Equal(ushort.MaxValue, info.WorldID);
        }
        
        /// <summary>
        ///     Tests that entity id only with maximum values can be stored.
        /// </summary>
        [Fact]
        public void EntityIDOnly_MaxValues_ShouldBeStoredCorrectly()
        {
            // Arrange
            EntityWorldInfoAccess info = new EntityWorldInfoAccess();
            GameObjectIdOnly entityIdOnly = new GameObjectIdOnly(int.MaxValue, ushort.MaxValue);
            
            // Act
            info.EntityIDOnly = entityIdOnly;
            
            // Assert
            Assert.Equal(int.MaxValue, info.EntityIDOnly.ID);
            Assert.Equal(ushort.MaxValue, info.EntityIDOnly.Version);
        }
        
        /// <summary>
        ///     Tests that multiple instances maintain separate data.
        /// </summary>
        [Fact]
        public void MultipleInstances_ShouldMaintainSeparateData()
        {
            // Arrange
            EntityWorldInfoAccess info1 = new EntityWorldInfoAccess();
            EntityWorldInfoAccess info2 = new EntityWorldInfoAccess();
            GameObjectIdOnly entityIdOnly1 = new GameObjectIdOnly(10, 1);
            GameObjectIdOnly entityIdOnly2 = new GameObjectIdOnly(20, 2);
            
            // Act
            info1.EntityIDOnly = entityIdOnly1;
            info1.WorldID = 5;
            info2.EntityIDOnly = entityIdOnly2;
            info2.WorldID = 10;
            
            // Assert
            Assert.Equal(10, info1.EntityIDOnly.ID);
            Assert.Equal((ushort)5, info1.WorldID);
            Assert.Equal(20, info2.EntityIDOnly.ID);
            Assert.Equal((ushort)10, info2.WorldID);
        }
    }
}

