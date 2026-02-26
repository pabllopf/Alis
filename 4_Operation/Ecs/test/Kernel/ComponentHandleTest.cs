// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentHandleTest.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Tests the <see cref="ComponentHandle"/> struct.
    /// </summary>
    public class ComponentHandleTest
    {
        /// <summary>
        ///     Tests that create with component returns valid handle.
        /// </summary>
        [Fact]
        public void Create_WithComponent_ShouldReturnValidHandle()
        {
            // Arrange
            Position position = new Position { X = 10, Y = 20 };
            
            // Act
            ComponentHandle handle = ComponentHandle.Create(position);
            
            // Assert
            Assert.Equal(typeof(Position), handle.Type);
            Assert.Equal(Component<Position>.Id, handle.ComponentId);
        }
        
        /// <summary>
        ///     Tests that retrieve returns correct component value.
        /// </summary>
        [Fact]
        public void Retrieve_WithValidHandle_ShouldReturnCorrectValue()
        {
            // Arrange
            Position position = new Position { X = 10, Y = 20 };
            ComponentHandle handle = ComponentHandle.Create(position);
            
            // Act
            Position retrieved = handle.Retrieve<Position>();
            
            // Assert
            Assert.Equal(10, retrieved.X);
            Assert.Equal(20, retrieved.Y);
        }
        
        /// <summary>
        ///     Tests that retrieve boxed returns component as object.
        /// </summary>
        [Fact]
        public void RetrieveBoxed_WithValidHandle_ShouldReturnBoxedComponent()
        {
            // Arrange
            Position position = new Position { X = 10, Y = 20 };
            ComponentHandle handle = ComponentHandle.Create(position);
            
            // Act
            object retrieved = handle.RetrieveBoxed();
            
            // Assert
            Assert.NotNull(retrieved);
            Assert.IsType<Position>(retrieved);
            Position pos = (Position)retrieved;
            Assert.Equal(10, pos.X);
            Assert.Equal(20, pos.Y);
        }
        
        /// <summary>
        ///     Tests that create from boxed with component id works correctly.
        /// </summary>
        [Fact]
        public void CreateFromBoxed_WithComponentId_ShouldCreateValidHandle()
        {
            // Arrange
            object position = new Position { X = 10, Y = 20 };
            ComponentId typeId = Component<Position>.Id;
            
            // Act
            ComponentHandle handle = ComponentHandle.CreateFromBoxed(typeId, position);
            
            // Assert
            Assert.Equal(typeof(Position), handle.Type);
            Assert.Equal(typeId, handle.ComponentId);
        }
        
        /// <summary>
        ///     Tests that create from boxed without component id works correctly.
        /// </summary>
        [Fact]
        public void CreateFromBoxed_WithoutComponentId_ShouldCreateValidHandle()
        {
            // Arrange
            object velocity = new Velocity { VX = 1, VY = 2 };
            
            // Act
            ComponentHandle handle = ComponentHandle.CreateFromBoxed(velocity);
            
            // Assert
            Assert.Equal(typeof(Velocity), handle.Type);
        }
        
        /// <summary>
        ///     Tests that type property returns correct component type.
        /// </summary>
        [Fact]
        public void Type_ShouldReturnCorrectComponentType()
        {
            // Arrange
            Health health = new Health { Value = 100 };
            ComponentHandle handle = ComponentHandle.Create(health);
            
            // Act
            Type type = handle.Type;
            
            // Assert
            Assert.Equal(typeof(Health), type);
        }
        
        /// <summary>
        ///     Tests that component id property returns correct id.
        /// </summary>
        [Fact]
        public void ComponentId_ShouldReturnCorrectId()
        {
            // Arrange
            Position position = new Position();
            ComponentHandle handle = ComponentHandle.Create(position);
            
            // Act
            ComponentId componentId = handle.ComponentId;
            
            // Assert
            Assert.Equal(Component<Position>.Id, componentId);
        }
        
        /// <summary>
        ///     Tests that equals with same handle returns true.
        /// </summary>
        [Fact]
        public void Equals_WithSameHandle_ShouldReturnTrue()
        {
            // Arrange
            Position position = new Position { X = 10, Y = 20 };
            ComponentHandle handle1 = ComponentHandle.Create(position);
            ComponentHandle handle2 = handle1;
            
            // Act
            bool equals = handle1.Equals(handle2);
            
            // Assert
            Assert.True(equals);
        }
        
        /// <summary>
        ///     Tests that equals with different handles returns false.
        /// </summary>
        [Fact]
        public void Equals_WithDifferentHandles_ShouldReturnFalse()
        {
            // Arrange
            Position position1 = new Position { X = 10, Y = 20 };
            Position position2 = new Position { X = 30, Y = 40 };
            ComponentHandle handle1 = ComponentHandle.Create(position1);
            ComponentHandle handle2 = ComponentHandle.Create(position2);
            
            // Act
            bool equals = handle1.Equals(handle2);
            
            // Assert
            Assert.False(equals);
        }
        
        /// <summary>
        ///     Tests that operator equals works correctly.
        /// </summary>
        [Fact]
        public void OperatorEquals_WithSameHandles_ShouldReturnTrue()
        {
            // Arrange
            Position position = new Position();
            ComponentHandle handle1 = ComponentHandle.Create(position);
            ComponentHandle handle2 = handle1;
            
            // Act
            bool equals = handle1 == handle2;
            
            // Assert
            Assert.True(equals);
        }
        
        /// <summary>
        ///     Tests that operator not equals works correctly.
        /// </summary>
        [Fact]
        public void OperatorNotEquals_WithDifferentHandles_ShouldReturnTrue()
        {
            // Arrange
            Position position1 = new Position();
            Position position2 = new Position();
            ComponentHandle handle1 = ComponentHandle.Create(position1);
            ComponentHandle handle2 = ComponentHandle.Create(position2);
            
            // Act
            bool notEquals = handle1 != handle2;
            
            // Assert
            Assert.True(notEquals);
        }
        
        /// <summary>
        ///     Tests that get hash code returns consistent value.
        /// </summary>
        [Fact]
        public void GetHashCode_ShouldReturnConsistentValue()
        {
            // Arrange
            Position position = new Position();
            ComponentHandle handle = ComponentHandle.Create(position);
            
            // Act
            int hashCode1 = handle.GetHashCode();
            int hashCode2 = handle.GetHashCode();
            
            // Assert
            Assert.Equal(hashCode1, hashCode2);
        }
        
        /// <summary>
        ///     Tests that dispose does not throw exception.
        /// </summary>
        [Fact]
        public void Dispose_ShouldNotThrowException()
        {
            // Arrange
            Position position = new Position();
            ComponentHandle handle = ComponentHandle.Create(position);
            
            // Act & Assert
            handle.Dispose();
        }
        
        /// <summary>
        ///     Tests that handle works with reference type components.
        /// </summary>
        [Fact]
        public void ComponentHandle_WithReferenceTypes_ShouldWork()
        {
            // Arrange
            string text = "test";
            ComponentHandle handle = ComponentHandle.Create(text);
            
            // Act
            string retrieved = handle.Retrieve<string>();
            
            // Assert
            Assert.Equal("test", retrieved);
        }
        
        /// <summary>
        ///     Tests that multiple create and retrieve operations work correctly.
        /// </summary>
        [Fact]
        public void MultipleCreateAndRetrieve_ShouldWorkCorrectly()
        {
            // Arrange
            Position pos1 = new Position { X = 1, Y = 2 };
            Position pos2 = new Position { X = 3, Y = 4 };
            Position pos3 = new Position { X = 5, Y = 6 };
            
            // Act
            ComponentHandle handle1 = ComponentHandle.Create(pos1);
            ComponentHandle handle2 = ComponentHandle.Create(pos2);
            ComponentHandle handle3 = ComponentHandle.Create(pos3);
            
            Position retrieved1 = handle1.Retrieve<Position>();
            Position retrieved2 = handle2.Retrieve<Position>();
            Position retrieved3 = handle3.Retrieve<Position>();
            
            // Assert
            Assert.Equal(1, retrieved1.X);
            Assert.Equal(3, retrieved2.X);
            Assert.Equal(5, retrieved3.X);
            
            handle1.Dispose();
            handle2.Dispose();
            handle3.Dispose();
        }
        
        /// <summary>
        ///     Tests that equals with object returns correct result.
        /// </summary>
        [Fact]
        public void Equals_WithObject_ShouldReturnCorrectResult()
        {
            // Arrange
            Position position = new Position();
            ComponentHandle handle = ComponentHandle.Create(position);
            object handleObj = handle;
            
            // Act
            bool equals = handle.Equals(handleObj);
            
            // Assert
            Assert.True(equals);
        }
        
        /// <summary>
        ///     Tests that equals with null object returns false.
        /// </summary>
        [Fact]
        public void Equals_WithNullObject_ShouldReturnFalse()
        {
            // Arrange
            Position position = new Position();
            ComponentHandle handle = ComponentHandle.Create(position);
            
            // Act
            bool equals = handle.Equals(null);
            
            // Assert
            Assert.False(equals);
        }
    }
}

