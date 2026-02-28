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
    ///     Tests the <see cref="GameObjectRefTuple{T1, T2, T3, T4, T5, T6, T7, T8}"/> struct with eight components.
    /// </summary>
    public partial class GameObjectRefTupleTest
    {
        /// <summary>
        ///     Tests that game object ref tuple with eight components can be created.
        /// </summary>
        [Fact]
        public void RefTuple8_Initialize_ShouldSetAllComponents()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position { X = 10, Y = 20 };
            Velocity vel = new Velocity { VX = 1, VY = 2 };
            Health health = new Health { Value = 100 };
            Armor armor = new Armor { Defense = 50 };
            TestComponent test = new TestComponent { Value = 5 };
            TestComponent2 test2 = new TestComponent2 { Value = 10 };
            TestStruct testStruct = new TestStruct { X = 15, Y = 15 };
            AnotherComponent another = new AnotherComponent { X = 200, Y = 200 };
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);
            entity.Add(armor);
            entity.Add(test);
            entity.Add(test2);
            entity.Add(testStruct);
            entity.Add(another);
            
            // Act
            GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct, AnotherComponent> tuple = new GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct, AnotherComponent>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] { pos }, 0),
                Item2 = new Ref<Velocity>(new[] { vel }, 0),
                Item3 = new Ref<Health>(new[] { health }, 0),
                Item4 = new Ref<Armor>(new[] { armor }, 0),
                Item5 = new Ref<TestComponent>(new[] { test }, 0),
                Item6 = new Ref<TestComponent2>(new[] { test2 }, 0),
                Item7 = new Ref<TestStruct>(new[] { testStruct }, 0),
                Item8 = new Ref<AnotherComponent>(new[] { another }, 0)
            };
            
            // Assert
            Assert.Equal(entity, tuple.GameObject);
            Assert.Equal(10, tuple.Item1.Value.X);
            Assert.Equal(100, tuple.Item3.Value.Value);
            Assert.Equal(200, tuple.Item8.Value.X);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that ref tuple with eight components can be deconstructed.
        /// </summary>
        [Fact]
        public void RefTuple8_Deconstruct_ShouldReturnAllRefs()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position { X = 5, Y = 10 };
            Velocity vel = new Velocity { VX = 2, VY = 3 };
            Health health = new Health { Value = 50 };
            Armor armor = new Armor { Defense = 25 };
            TestComponent test = new TestComponent { Value = 3 };
            TestComponent2 test2 = new TestComponent2 { Value = 6 };
            TestStruct testStruct = new TestStruct { X = 9, Y = 9 };
            AnotherComponent another = new AnotherComponent { X = 100, Y = 100 };
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);
            entity.Add(armor);
            entity.Add(test);
            entity.Add(test2);
            entity.Add(testStruct);
            entity.Add(another);
            
            GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct, AnotherComponent> tuple = new GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct, AnotherComponent>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] { pos }, 0),
                Item2 = new Ref<Velocity>(new[] { vel }, 0),
                Item3 = new Ref<Health>(new[] { health }, 0),
                Item4 = new Ref<Armor>(new[] { armor }, 0),
                Item5 = new Ref<TestComponent>(new[] { test }, 0),
                Item6 = new Ref<TestComponent2>(new[] { test2 }, 0),
                Item7 = new Ref<TestStruct>(new[] { testStruct }, 0),
                Item8 = new Ref<AnotherComponent>(new[] { another }, 0)
            };
            
            // Act
            (GameObject go, Ref<Position> posRef, Ref<Velocity> velRef, Ref<Health> healthRef, Ref<Armor> armorRef, Ref<TestComponent> testRef, Ref<TestComponent2> test2Ref, Ref<TestStruct> structRef, Ref<AnotherComponent> anotherRef) = tuple;
            
            // Assert
            Assert.Equal(entity, go);
            Assert.Equal(5, posRef.Value.X);
            Assert.Equal(100, anotherRef.Value.X);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that modifying all eight components updates them.
        /// </summary>
        [Fact]
        public void RefTuple8_ModifyAllComponents_ShouldUpdateAll()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position { X = 1, Y = 2 };
            Velocity vel = new Velocity { VX = 0.5f, VY = 0.5f };
            Health health = new Health { Value = 75 };
            Armor armor = new Armor { Defense = 10 };
            TestComponent test = new TestComponent { Value = 1 };
            TestComponent2 test2 = new TestComponent2 { Value = 2 };
            TestStruct testStruct = new TestStruct { X = 3, Y = 3 };
            AnotherComponent another = new AnotherComponent { X = 50, Y = 50 };
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);
            entity.Add(armor);
            entity.Add(test);
            entity.Add(test2);
            entity.Add(testStruct);
            entity.Add(another);
            
            GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct, AnotherComponent> tuple = new GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct, AnotherComponent>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] { pos }, 0),
                Item2 = new Ref<Velocity>(new[] { vel }, 0),
                Item3 = new Ref<Health>(new[] { health }, 0),
                Item4 = new Ref<Armor>(new[] { armor }, 0),
                Item5 = new Ref<TestComponent>(new[] { test }, 0),
                Item6 = new Ref<TestComponent2>(new[] { test2 }, 0),
                Item7 = new Ref<TestStruct>(new[] { testStruct }, 0),
                Item8 = new Ref<AnotherComponent>(new[] { another }, 0)
            };
            
            // Act
            tuple.Item8.Value.X = 999;
            
            // Assert
            Assert.Equal(50, entity.Get<AnotherComponent>().X);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that all fields of ref tuple with eight components are accessible.
        /// </summary>
        [Fact]
        public void RefTuple8_AllFields_ShouldBeAccessible()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position { X = 8, Y = 16 };
            Velocity vel = new Velocity { VX = 1.5f, VY = 2.5f };
            Health health = new Health { Value = 150 };
            Armor armor = new Armor { Defense = 75 };
            TestComponent test = new TestComponent { Value = 8 };
            TestComponent2 test2 = new TestComponent2 { Value = 16 };
            TestStruct testStruct = new TestStruct { X = 24, Y = 24 };
            AnotherComponent another = new AnotherComponent { X = 300, Y = 300 };
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);
            entity.Add(armor);
            entity.Add(test);
            entity.Add(test2);
            entity.Add(testStruct);
            entity.Add(another);
            
            // Act
            GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct, AnotherComponent> tuple = new GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct, AnotherComponent>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] { pos }, 0),
                Item2 = new Ref<Velocity>(new[] { vel }, 0),
                Item3 = new Ref<Health>(new[] { health }, 0),
                Item4 = new Ref<Armor>(new[] { armor }, 0),
                Item5 = new Ref<TestComponent>(new[] { test }, 0),
                Item6 = new Ref<TestComponent2>(new[] { test2 }, 0),
                Item7 = new Ref<TestStruct>(new[] { testStruct }, 0),
                Item8 = new Ref<AnotherComponent>(new[] { another }, 0)
            };
            
            // Assert
            Assert.Equal(entity, tuple.GameObject);
            Assert.Equal(8, tuple.Item1.Value.X);
            Assert.Equal(24, tuple.Item7.Value.X);
            Assert.Equal(300, tuple.Item8.Value.X);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that multiple ref tuples with eight components maintain separate state.
        /// </summary>
        [Fact]
        public void RefTuple8_MultipleTuples_ShouldMaintainSeparateState()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity1 = world.Create();
            GameObject entity2 = world.Create();
            
            Position pos1 = new Position { X = 1, Y = 1 };
            Velocity vel1 = new Velocity { VX = 0.1f, VY = 0.1f };
            Health health1 = new Health { Value = 100 };
            Armor armor1 = new Armor { Defense = 50 };
            TestComponent test1 = new TestComponent { Value = 10 };
            TestComponent2 test2a = new TestComponent2 { Value = 15 };
            TestStruct struct1 = new TestStruct { X = 20, Y = 20 };
            AnotherComponent another1 = new AnotherComponent { X = 250, Y = 250 };
            entity1.Add(pos1);
            entity1.Add(vel1);
            entity1.Add(health1);
            entity1.Add(armor1);
            entity1.Add(test1);
            entity1.Add(test2a);
            entity1.Add(struct1);
            entity1.Add(another1);
            
            Position pos2 = new Position { X = 2, Y = 2 };
            Velocity vel2 = new Velocity { VX = 0.2f, VY = 0.2f };
            Health health2 = new Health { Value = 50 };
            Armor armor2 = new Armor { Defense = 25 };
            TestComponent test2 = new TestComponent { Value = 20 };
            TestComponent2 test2b = new TestComponent2 { Value = 25 };
            TestStruct struct2 = new TestStruct { X = 30, Y = 30 };
            AnotherComponent another2 = new AnotherComponent { X = 350, Y = 350 };
            entity2.Add(pos2);
            entity2.Add(vel2);
            entity2.Add(health2);
            entity2.Add(armor2);
            entity2.Add(test2);
            entity2.Add(test2b);
            entity2.Add(struct2);
            entity2.Add(another2);
            
            // Act
            GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct, AnotherComponent> tuple1 = new GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct, AnotherComponent>
            {
                GameObject = entity1,
                Item1 = new Ref<Position>(new[] { pos1 }, 0),
                Item2 = new Ref<Velocity>(new[] { vel1 }, 0),
                Item3 = new Ref<Health>(new[] { health1 }, 0),
                Item4 = new Ref<Armor>(new[] { armor1 }, 0),
                Item5 = new Ref<TestComponent>(new[] { test1 }, 0),
                Item6 = new Ref<TestComponent2>(new[] { test2a }, 0),
                Item7 = new Ref<TestStruct>(new[] { struct1 }, 0),
                Item8 = new Ref<AnotherComponent>(new[] { another1 }, 0)
            };
            
            GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct, AnotherComponent> tuple2 = new GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct, AnotherComponent>
            {
                GameObject = entity2,
                Item1 = new Ref<Position>(new[] { pos2 }, 0),
                Item2 = new Ref<Velocity>(new[] { vel2 }, 0),
                Item3 = new Ref<Health>(new[] { health2 }, 0),
                Item4 = new Ref<Armor>(new[] { armor2 }, 0),
                Item5 = new Ref<TestComponent>(new[] { test2 }, 0),
                Item6 = new Ref<TestComponent2>(new[] { test2b }, 0),
                Item7 = new Ref<TestStruct>(new[] { struct2 }, 0),
                Item8 = new Ref<AnotherComponent>(new[] { another2 }, 0)
            };
            
            // Assert
            Assert.NotEqual(tuple1.GameObject, tuple2.GameObject);
            Assert.Equal(250, tuple1.Item8.Value.X);
            Assert.Equal(350, tuple2.Item8.Value.X);
            
            world.Dispose();
        }
    }
}