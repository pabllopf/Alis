// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectRefTuple.cs
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
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests the <see cref="GameObjectRefTuple{T1}"/> struct with a single component.
    /// </summary>
    public partial class GameObjectRefTupleTest
    {
        /// <summary>
        ///     Tests that game object ref tuple can be initialized with a game object and component reference.
        /// </summary>
        [Fact]
        public void RefTuple1_Initialize_ShouldSetGameObjectAndComponent()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            entity.Add(new Position { X = 10, Y = 20 });
            
            // Act
            GameObjectRefTuple<Position> refTuple = new GameObjectRefTuple<Position>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] { new Position { X = 10, Y = 20 } }, 0)
            };
            
            // Assert
            Assert.Equal(entity, refTuple.GameObject);
            Assert.NotNull(refTuple.Item1);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that game object ref tuple deconstruction works correctly.
        /// </summary>
        [Fact]
        public void RefTuple1_Deconstruct_ShouldReturnGameObjectAndRef()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position { X = 5, Y = 15 };
            entity.Add(pos);
            
            GameObjectRefTuple<Position> tuple = new GameObjectRefTuple<Position>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] { pos }, 0)
            };
            
            // Act
            (GameObject go, Ref<Position> posRef) = tuple;
            
            // Assert
            Assert.Equal(entity, go);
            Assert.Equal(5, posRef.Value.X);
            Assert.Equal(15, posRef.Value.Y);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that multiple tuples with different game objects work independently.
        /// </summary>
        [Fact]
        public void RefTuple1_MultipleTuples_ShouldMaintainSeparateState()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity1 = world.Create();
            GameObject entity2 = world.Create();
            Position pos1 = new Position { X = 1, Y = 2 };
            Position pos2 = new Position { X = 3, Y = 4 };
            entity1.Add(pos1);
            entity2.Add(pos2);
            
            // Act
            GameObjectRefTuple<Position> tuple1 = new GameObjectRefTuple<Position> { GameObject = entity1, Item1 = new Ref<Position>(new[] { pos1 }, 0) };
            GameObjectRefTuple<Position> tuple2 = new GameObjectRefTuple<Position> { GameObject = entity2, Item1 = new Ref<Position>(new[] { pos2 }, 0) };
            
            // Assert
            Assert.NotEqual(tuple1.GameObject, tuple2.GameObject);
            Assert.Equal(1, tuple1.Item1.Value.X);
            Assert.Equal(3, tuple2.Item1.Value.X);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that ref tuple with different component types work correctly.
        /// </summary>
        [Fact]
        public void RefTuple1_WithDifferentComponentTypes_ShouldWork()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Health health = new Health { Value = 100 };
            entity.Add(health);
            
            // Act
            GameObjectRefTuple<Health> tuple = new GameObjectRefTuple<Health>
            {
                GameObject = entity,
                Item1 = new Ref<Health>(new[] { health }, 0)
            };
            
            // Assert
            Assert.Equal(100, tuple.Item1.Value.Value);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that game object field is properly accessible.
        /// </summary>
        [Fact]
        public void RefTuple1_GameObjectField_ShouldBeAccessible()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position();
            entity.Add(pos);
            
            // Act
            GameObjectRefTuple<Position> tuple = new GameObjectRefTuple<Position> { GameObject = entity, Item1 = new Ref<Position>(new[] { pos }, 0) };
            GameObject retrieved = tuple.GameObject;
            
            // Assert
            Assert.Equal(entity, retrieved);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that item1 field can be accessed and used.
        /// </summary>
        [Fact]
        public void RefTuple1_Item1Field_ShouldBeAccessible()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position { X = 42, Y = 84 };
            entity.Add(pos);
            
            // Act
            GameObjectRefTuple<Position> tuple = new GameObjectRefTuple<Position> { GameObject = entity, Item1 = new Ref<Position>(new[] { pos }, 0) };
            Ref<Position> item = tuple.Item1;
            
            // Assert
            Assert.Equal(42, item.Value.X);
            Assert.Equal(84, item.Value.Y);
            
            world.Dispose();
        }
    }
}