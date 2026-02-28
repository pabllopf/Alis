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
    ///     Tests the <see cref="GameObjectRefTuple{T1, T2, T3, T4, T5, T6, T7}"/> struct with seven components.
    /// </summary>
    public partial class GameObjectRefTupleTest
    {
        /// <summary>
        ///     Tests that game object ref tuple with seven components can be created.
        /// </summary>
        [Fact]
        public void RefTuple7_Initialize_ShouldSetAllComponents()
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
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);
            entity.Add(armor);
            entity.Add(test);
            entity.Add(test2);
            entity.Add(testStruct);
            
            // Act
            var tuple = new GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] { pos }, 0),
                Item2 = new Ref<Velocity>(new[] { vel }, 0),
                Item3 = new Ref<Health>(new[] { health }, 0),
                Item4 = new Ref<Armor>(new[] { armor }, 0),
                Item5 = new Ref<TestComponent>(new[] { test }, 0),
                Item6 = new Ref<TestComponent2>(new[] { test2 }, 0),
                Item7 = new Ref<TestStruct>(new[] { testStruct }, 0)
            };
            
            // Assert
            Assert.Equal(entity, tuple.GameObject);
            Assert.Equal(10, tuple.Item1.Value.X);
            Assert.Equal(100, tuple.Item3.Value.Value);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that ref tuple with seven components can be deconstructed.
        /// </summary>
        [Fact]
        public void RefTuple7_Deconstruct_ShouldReturnAllRefs()
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
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);
            entity.Add(armor);
            entity.Add(test);
            entity.Add(test2);
            entity.Add(testStruct);
            
            var tuple = new GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] { pos }, 0),
                Item2 = new Ref<Velocity>(new[] { vel }, 0),
                Item3 = new Ref<Health>(new[] { health }, 0),
                Item4 = new Ref<Armor>(new[] { armor }, 0),
                Item5 = new Ref<TestComponent>(new[] { test }, 0),
                Item6 = new Ref<TestComponent2>(new[] { test2 }, 0),
                Item7 = new Ref<TestStruct>(new[] { testStruct }, 0)
            };
            
            // Act
            var (go, posRef, velRef, healthRef, armorRef, testRef, test2Ref, structRef) = tuple;
            
            // Assert
            Assert.Equal(entity, go);
            Assert.Equal(5, posRef.Value.X);
            Assert.Equal(9, structRef.Value.Y);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that modifying components through seven-item ref tuple updates them.
        /// </summary>
        [Fact]
        public void RefTuple7_ModifyAllComponents_ShouldUpdateAll()
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
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);
            entity.Add(armor);
            entity.Add(test);
            entity.Add(test2);
            entity.Add(testStruct);
            
            var tuple = new GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] { pos }, 0),
                Item2 = new Ref<Velocity>(new[] { vel }, 0),
                Item3 = new Ref<Health>(new[] { health }, 0),
                Item4 = new Ref<Armor>(new[] { armor }, 0),
                Item5 = new Ref<TestComponent>(new[] { test }, 0),
                Item6 = new Ref<TestComponent2>(new[] { test2 }, 0),
                Item7 = new Ref<TestStruct>(new[] { testStruct }, 0)
            };
            
            // Act
            tuple.Item7.Value.X = 77;
            
            // Assert
            Assert.Equal(3, entity.Get<TestStruct>().X);
            
            world.Dispose();
        }
        
        /// <summary>
        ///     Tests that all fields of ref tuple with seven components are accessible.
        /// </summary>
        [Fact]
        public void RefTuple7_AllFields_ShouldBeAccessible()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position { X = 7, Y = 14 };
            Velocity vel = new Velocity { VX = 1.5f, VY = 2.5f };
            Health health = new Health { Value = 150 };
            Armor armor = new Armor { Defense = 75 };
            TestComponent test = new TestComponent { Value = 7 };
            TestComponent2 test2 = new TestComponent2 { Value = 14 };
            TestStruct testStruct = new TestStruct { X = 21, Y = 21 };
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);
            entity.Add(armor);
            entity.Add(test);
            entity.Add(test2);
            entity.Add(testStruct);
            
            // Act
            var tuple = new GameObjectRefTuple<Position, Velocity, Health, Armor, TestComponent, TestComponent2, TestStruct>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] { pos }, 0),
                Item2 = new Ref<Velocity>(new[] { vel }, 0),
                Item3 = new Ref<Health>(new[] { health }, 0),
                Item4 = new Ref<Armor>(new[] { armor }, 0),
                Item5 = new Ref<TestComponent>(new[] { test }, 0),
                Item6 = new Ref<TestComponent2>(new[] { test2 }, 0),
                Item7 = new Ref<TestStruct>(new[] { testStruct }, 0)
            };
            
            // Assert
            Assert.Equal(entity, tuple.GameObject);
            Assert.Equal(7, tuple.Item1.Value.X);
            Assert.Equal(21, tuple.Item7.Value.X);
            
            world.Dispose();
        }
    }
}