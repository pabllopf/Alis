// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectIdOnlyTest.cs
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

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Tests the <see cref="GameObjectIdOnly"/> struct.
    /// </summary>
    public partial class GameObjectIdOnlyTest
    {
        /// <summary>
        ///     Tests that constructor initializes id and version correctly.
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeIdAndVersion()
        {
            // Arrange & Act
            GameObjectIdOnly idOnly = new GameObjectIdOnly(42, 5);
            
            // Assert
            Assert.Equal(42, idOnly.ID);
            Assert.Equal((ushort)5, idOnly.Version);
        }
        
        /// <summary>
        ///     Tests that to entity creates correct game object.
        /// </summary>
        [Fact]
        public void ToEntity_ShouldCreateCorrectGameObject()
        {
            // Arrange
            Scene world = new Scene();
            GameObjectIdOnly idOnly = new GameObjectIdOnly(10, 2);
            
            // Act
            GameObject entity = idOnly.ToEntity(world);
            
            // Assert
            Assert.Equal(10, entity.EntityID);
            Assert.Equal((ushort)2, entity.EntityVersion);
            Assert.Equal(world.Id, entity.WorldID);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that deconstruct extracts id and version correctly.
        /// </summary>
        [Fact]
        public void Deconstruct_ShouldExtractIdAndVersion()
        {
            // Arrange
            GameObjectIdOnly idOnly = new GameObjectIdOnly(100, 10);
            
            // Act
            idOnly.Deconstruct(out int id, out ushort version);
            
            // Assert
            Assert.Equal(100, id);
            Assert.Equal((ushort)10, version);
        }
        
        /// <summary>
        ///     Tests that set entity updates game object correctly.
        /// </summary>
        [Fact]
        public void SetEntity_ShouldUpdateGameObject()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            GameObjectIdOnly idOnly = new GameObjectIdOnly(50, 3);
            
            // Act
            idOnly.SetEntity(ref entity);
            
            // Assert
            Assert.Equal(50, entity.EntityID);
            Assert.Equal((ushort)3, entity.EntityVersion);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that init with game object copies values correctly.
        /// </summary>
        [Fact]
        public void Init_WithGameObject_ShouldCopyValues()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            GameObjectIdOnly idOnly = new GameObjectIdOnly(0, 0);
            
            // Act
            idOnly.Init(entity);
            
            // Assert
            Assert.Equal(entity.EntityID, idOnly.ID);
            Assert.Equal(entity.EntityVersion, idOnly.Version);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that init with another game object id only copies values.
        /// </summary>
        [Fact]
        public void Init_WithAnotherGameObjectIdOnly_ShouldCopyValues()
        {
            // Arrange
            GameObjectIdOnly source = new GameObjectIdOnly(75, 7);
            GameObjectIdOnly target = new GameObjectIdOnly(0, 0);
            
            // Act
            target.Init(source);
            
            // Assert
            Assert.Equal(75, target.ID);
            Assert.Equal((ushort)7, target.Version);
        }
        
        /// <summary>
        ///     Tests that constructor with zero values works correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithZeroValues_ShouldWorkCorrectly()
        {
            // Arrange & Act
            GameObjectIdOnly idOnly = new GameObjectIdOnly(0, 0);
            
            // Assert
            Assert.Equal(0, idOnly.ID);
            Assert.Equal((ushort)0, idOnly.Version);
        }
        
        /// <summary>
        ///     Tests that constructor with negative id works correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeId_ShouldWorkCorrectly()
        {
            // Arrange & Act
            GameObjectIdOnly idOnly = new GameObjectIdOnly(-1, 5);
            
            // Assert
            Assert.Equal(-1, idOnly.ID);
            Assert.Equal((ushort)5, idOnly.Version);
        }
        
        /// <summary>
        ///     Tests that constructor with max values works correctly.
        /// </summary>
        [Fact]
        public void Constructor_WithMaxValues_ShouldWorkCorrectly()
        {
            // Arrange & Act
            GameObjectIdOnly idOnly = new GameObjectIdOnly(int.MaxValue, ushort.MaxValue);
            
            // Assert
            Assert.Equal(int.MaxValue, idOnly.ID);
            Assert.Equal(ushort.MaxValue, idOnly.Version);
        }
        
        /// <summary>
        ///     Tests that id can be modified after construction.
        /// </summary>
        [Fact]
        public void ID_CanBeModified_AfterConstruction()
        {
            // Arrange
            GameObjectIdOnly idOnly = new GameObjectIdOnly(10, 1);
            
            // Act
            idOnly.ID = 20;
            
            // Assert
            Assert.Equal(20, idOnly.ID);
        }
        
        /// <summary>
        ///     Tests that version can be modified after construction.
        /// </summary>
        [Fact]
        public void Version_CanBeModified_AfterConstruction()
        {
            // Arrange
            GameObjectIdOnly idOnly = new GameObjectIdOnly(10, 1);
            
            // Act
            idOnly.Version = 5;
            
            // Assert
            Assert.Equal((ushort)5, idOnly.Version);
        }
        
        /// <summary>
        ///     Tests that set entity preserves world id.
        /// </summary>
        [Fact]
        public void SetEntity_ShouldPreserveWorldId()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            ushort originalWorldId = entity.WorldID;
            GameObjectIdOnly idOnly = new GameObjectIdOnly(99, 9);
            
            // Act
            idOnly.SetEntity(ref entity);
            
            // Assert
            Assert.Equal(originalWorldId, entity.WorldID);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that multiple init calls overwrite previous values.
        /// </summary>
        [Fact]
        public void Init_MultipleCalls_ShouldOverwriteValues()
        {
            // Arrange
            GameObjectIdOnly idOnly = new GameObjectIdOnly(10, 1);
            GameObjectIdOnly source1 = new GameObjectIdOnly(20, 2);
            GameObjectIdOnly source2 = new GameObjectIdOnly(30, 3);
            
            // Act
            idOnly.Init(source1);
            idOnly.Init(source2);
            
            // Assert
            Assert.Equal(30, idOnly.ID);
            Assert.Equal((ushort)3, idOnly.Version);
        }
    }
}

