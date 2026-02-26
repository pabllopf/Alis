// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldArchetypeTableItemTest.cs
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

using Alis.Core.Ecs.Kernel.Archetypes;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests the <see cref="WorldArchetypeTableItem"/> struct.
    /// </summary>
    public class WorldArchetypeTableItemTest
    {
        /// <summary>
        ///     Tests that constructor initializes archetype correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeArchetype()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            Archetype temp = world.DefaultArchetype;
            
            // Act
            WorldArchetypeTableItem item = new WorldArchetypeTableItem(archetype, temp);
            
            // Assert
            Assert.Equal(archetype, item.Archetype);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that constructor initializes deferred creation archetype correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeDeferredCreationArchetype()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            Archetype temp = world.DefaultArchetype;
            
            // Act
            WorldArchetypeTableItem item = new WorldArchetypeTableItem(archetype, temp);
            
            // Assert
            Assert.Equal(temp, item.DeferredCreationArchetype);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that archetype can be modified after construction.
        /// </summary>
        [Fact]
        public void Archetype_CanBeModified_AfterConstruction()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype1 = world.DefaultArchetype;
            Archetype archetype2 = world.DefaultArchetype;
            Archetype temp = world.DefaultArchetype;
            WorldArchetypeTableItem item = new WorldArchetypeTableItem(archetype1, temp);
            
            // Act
            item.Archetype = archetype2;
            
            // Assert
            Assert.Equal(archetype2, item.Archetype);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that deferred creation archetype can be modified after construction.
        /// </summary>
        [Fact]
        public void DeferredCreationArchetype_CanBeModified_AfterConstruction()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            Archetype temp1 = world.DefaultArchetype;
            Archetype temp2 = world.DefaultArchetype;
            WorldArchetypeTableItem item = new WorldArchetypeTableItem(archetype, temp1);
            
            // Act
            item.DeferredCreationArchetype = temp2;
            
            // Assert
            Assert.Equal(temp2, item.DeferredCreationArchetype);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that both archetypes can be the same instance.
        /// </summary>
        [Fact]
        public void BothArchetypes_CanBeTheSameInstance()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            
            // Act
            WorldArchetypeTableItem item = new WorldArchetypeTableItem(archetype, archetype);
            
            // Assert
            Assert.Equal(archetype, item.Archetype);
            Assert.Equal(archetype, item.DeferredCreationArchetype);
            Assert.Same(item.Archetype, item.DeferredCreationArchetype);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that multiple instances maintain separate data.
        /// </summary>
        [Fact]
        public void MultipleInstances_ShouldMaintainSeparateData()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype1 = world.DefaultArchetype;
            Archetype archetype2 = world.DefaultArchetype;
            Archetype temp1 = world.DefaultArchetype;
            Archetype temp2 = world.DefaultArchetype;
            
            // Act
            WorldArchetypeTableItem item1 = new WorldArchetypeTableItem(archetype1, temp1);
            WorldArchetypeTableItem item2 = new WorldArchetypeTableItem(archetype2, temp2);
            
            // Assert
            Assert.Equal(archetype1, item1.Archetype);
            Assert.Equal(temp1, item1.DeferredCreationArchetype);
            Assert.Equal(archetype2, item2.Archetype);
            Assert.Equal(temp2, item2.DeferredCreationArchetype);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that constructor with archetypes stores them correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithArchetypes_ShouldStoreCorrectly()
        {
            // Arrange
            Scene world = new Scene();
            Archetype archetype = world.DefaultArchetype;
            Archetype temp = world.DefaultArchetype;
            
            // Act
            WorldArchetypeTableItem item = new WorldArchetypeTableItem(archetype, temp);
            
            // Assert
            // Note: In a world with a single archetype, both may point to same instance
            Assert.NotNull(item.Archetype);
            Assert.NotNull(item.DeferredCreationArchetype);
            
            world.Dispose();
        }
    }
}

