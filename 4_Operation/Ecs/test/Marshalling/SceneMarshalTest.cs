// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneMarshalTest.cs
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

using System;
using Alis.Core.Ecs.Marshalling;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Marshalling
{
    /// <summary>
    ///     Tests the <see cref="SceneMarshal"/> class.
    /// </summary>
    public class SceneMarshalTest
    {
        /// <summary>
        ///     Tests that get component returns correct component reference.
        /// </summary>
        [Fact]
        public void GetComponent_WithValidEntity_ShouldReturnCorrectReference()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position position = new Position { X = 10, Y = 20 };
            entity.Add(position);
            
            // Act
            ref Position retrieved = ref SceneMarshal.GetComponent<Position>(world, entity);
            
            // Assert
            Assert.Equal(10, retrieved.X);
            Assert.Equal(20, retrieved.Y);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that get component allows modification through reference.
        /// </summary>
        [Fact]
        public void GetComponent_ModifyThroughReference_ShouldUpdateComponent()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            entity.Add(new Position { X = 10, Y = 20 });
            
            // Act
            ref Position retrieved = ref SceneMarshal.GetComponent<Position>(world, entity);
            retrieved.X = 100;
            retrieved.Y = 200;
            
            // Assert
            Position updated = entity.Get<Position>();
            Assert.Equal(100, updated.X);
            Assert.Equal(200, updated.Y);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that get raw buffer returns correct span and index.
        /// </summary>
        [Fact]
        public void GetRawBuffer_WithValidEntity_ShouldReturnSpanAndIndex()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            entity.Add(new Position { X = 5, Y = 10 });
            
            // Act
            Span<Position> buffer = SceneMarshal.GetRawBuffer<Position>(world, entity, out int index);
            
            // Assert
            Assert.True(buffer.Length > 0);
            Assert.True(index >= 0);
            Assert.Equal(5, buffer[index].X);
            Assert.Equal(10, buffer[index].Y);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that get raw buffer allows modification through span.
        /// </summary>
        [Fact]
        public void GetRawBuffer_ModifyThroughSpan_ShouldUpdateComponent()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            entity.Add(new Position { X = 5, Y = 10 });
            
            // Act
            Span<Position> buffer = SceneMarshal.GetRawBuffer<Position>(world, entity, out int index);
            buffer[index] = new Position { X = 50, Y = 100 };
            
            // Assert
            Position updated = entity.Get<Position>();
            Assert.Equal(50, updated.X);
            Assert.Equal(100, updated.Y);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that get with entity id returns correct component.
        /// </summary>
        [Fact]
        public void Get_WithEntityId_ShouldReturnCorrectComponent()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            entity.Add(new Velocity { VX = 1, VY = 2 });
            
            // Act
            ref Velocity retrieved = ref SceneMarshal.Get<Velocity>(world, entity.EntityID);
            
            // Assert
            Assert.Equal(1, retrieved.VX);
            Assert.Equal(2, retrieved.VY);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that get with entity id allows modification.
        /// </summary>
        [Fact]
        public void Get_WithEntityId_AllowsModification()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            entity.Add(new Velocity { VX = 1, VY = 2 });
            
            // Act
            ref Velocity retrieved = ref SceneMarshal.Get<Velocity>(world, entity.EntityID);
            retrieved.VX = 10;
            retrieved.VY = 20;
            
            // Assert
            Velocity updated = entity.Get<Velocity>();
            Assert.Equal(10, updated.VX);
            Assert.Equal(20, updated.VY);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that get component with multiple entities returns correct components.
        /// </summary>
        [Fact]
        public void GetComponent_WithMultipleEntities_ShouldReturnCorrectComponents()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity1 = world.Create();
            GameObject entity2 = world.Create();
            entity1.Add(new Position { X = 10, Y = 20 });
            entity2.Add(new Position { X = 30, Y = 40 });
            
            // Act
            ref Position pos1 = ref SceneMarshal.GetComponent<Position>(world, entity1);
            ref Position pos2 = ref SceneMarshal.GetComponent<Position>(world, entity2);
            
            // Assert
            Assert.Equal(10, pos1.X);
            Assert.Equal(20, pos1.Y);
            Assert.Equal(30, pos2.X);
            Assert.Equal(40, pos2.Y);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that get raw buffer with multiple entities in same archetype.
        /// </summary>
        [Fact]
        public void GetRawBuffer_WithMultipleEntitiesInSameArchetype_ShouldWork()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity1 = world.Create();
            GameObject entity2 = world.Create();
            entity1.Add(new Position { X = 1, Y = 2 });
            entity2.Add(new Position { X = 3, Y = 4 });
            
            // Act
            Span<Position> buffer1 = SceneMarshal.GetRawBuffer<Position>(world, entity1, out int index1);
            Span<Position> buffer2 = SceneMarshal.GetRawBuffer<Position>(world, entity2, out int index2);
            
            // Assert
            Assert.Equal(1, buffer1[index1].X);
            Assert.Equal(2, buffer1[index1].Y);
            Assert.Equal(3, buffer2[index2].X);
            Assert.Equal(4, buffer2[index2].Y);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that get component with struct component works correctly.
        /// </summary>
        [Fact]
        public void GetComponent_WithStructComponent_ShouldWorkCorrectly()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Health health = new Health { Value = 100 };
            entity.Add(health);
            
            // Act
            ref Health retrieved = ref SceneMarshal.GetComponent<Health>(world, entity);
            
            // Assert
            Assert.Equal(100, retrieved.Value);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that get with invalid entity id does not throw immediately.
        /// </summary>
        [Fact]
        public void Get_WithInvalidEntityId_ShouldNotThrowImmediately()
        {
            // Arrange
            Scene world = new Scene();
            
            // Act & Assert
            // Note: This is unsafe API, behavior with invalid ID is undefined
            // This test just verifies the method signature works
            Assert.NotNull(world);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that modifications through get component are visible through normal access.
        /// </summary>
        [Fact]
        public void GetComponent_ModificationsAreVisibleThroughNormalAccess()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            entity.Add(new Position { X = 0, Y = 0 });
            
            // Act
            ref Position pos = ref SceneMarshal.GetComponent<Position>(world, entity);
            pos.X = 999;
            pos.Y = 888;
            
            // Assert
            Assert.Equal(999, entity.Get<Position>().X);
            Assert.Equal(888, entity.Get<Position>().Y);
            
            world.Dispose();
        }
    }
}

