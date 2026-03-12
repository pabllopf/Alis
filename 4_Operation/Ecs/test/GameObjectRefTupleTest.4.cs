// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectRefTupleTest.4.cs
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
    ///     Tests the <see cref="GameObjectRefTuple{T1, T2, T3, T4}" /> struct with four components.
    /// </summary>
    public partial class GameObjectRefTupleTest
    {
        /// <summary>
        ///     Tests that game object ref tuple with four components can be created and initialized.
        /// </summary>
        [Fact]
        public void RefTuple4_Initialize_ShouldSetGameObjectAndAllComponents()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position {X = 10, Y = 20};
            Velocity vel = new Velocity {X = 1, Y = 2};
            Health health = new Health {Value = 100};
            Armor armor = new Armor {Value = 50};
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);
            entity.Add(armor);

            // Act
            GameObjectRefTuple<Position, Velocity, Health, Armor> tuple = new GameObjectRefTuple<Position, Velocity, Health, Armor>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] {pos}, 0),
                Item2 = new Ref<Velocity>(new[] {vel}, 0),
                Item3 = new Ref<Health>(new[] {health}, 0),
                Item4 = new Ref<Armor>(new[] {armor}, 0)
            };

            // Assert
            Assert.Equal(entity, tuple.GameObject);
            Assert.Equal(10, tuple.Item1.Value.X);
            Assert.Equal(1, tuple.Item2.Value.X);
            Assert.Equal(100, tuple.Item3.Value.Value);
            Assert.Equal(50, tuple.Item4.Value.Value);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that ref tuple with four components can be deconstructed.
        /// </summary>
        [Fact]
        public void RefTuple4_Deconstruct_ShouldReturnGameObjectAndAllRefs()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position {X = 5, Y = 10};
            Velocity vel = new Velocity {X = 2, Y = 3};
            Health health = new Health {Value = 50};
            Armor armor = new Armor {Value = 25};
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);
            entity.Add(armor);

            GameObjectRefTuple<Position, Velocity, Health, Armor> tuple = new GameObjectRefTuple<Position, Velocity, Health, Armor>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] {pos}, 0),
                Item2 = new Ref<Velocity>(new[] {vel}, 0),
                Item3 = new Ref<Health>(new[] {health}, 0),
                Item4 = new Ref<Armor>(new[] {armor}, 0)
            };

            // Act
            (GameObject go, Ref<Position> posRef, Ref<Velocity> velRef, Ref<Health> healthRef, Ref<Armor> armorRef) = tuple;

            // Assert
            Assert.Equal(entity, go);
            Assert.Equal(5, posRef.Value.X);
            Assert.Equal(2, velRef.Value.X);
            Assert.Equal(50, healthRef.Value.Value);
            Assert.Equal(25, armorRef.Value.Value);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that modifying all four components through ref tuple updates them.
        /// </summary>
        [Fact]
        public void RefTuple4_ModifyAllComponents_ShouldUpdateAll()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position {X = 1, Y = 2};
            Velocity vel = new Velocity {X = 0.5f, Y = 0.5f};
            Health health = new Health {Value = 75};
            Armor armor = new Armor {Value = 10};
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);
            entity.Add(armor);

            GameObjectRefTuple<Position, Velocity, Health, Armor> tuple = new GameObjectRefTuple<Position, Velocity, Health, Armor>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] {pos}, 0),
                Item2 = new Ref<Velocity>(new[] {vel}, 0),
                Item3 = new Ref<Health>(new[] {health}, 0),
                Item4 = new Ref<Armor>(new[] {armor}, 0)
            };

            // Act
            tuple.Item1.Value.X = 100;
            tuple.Item2.Value.X = 10;
            tuple.Item3.Value.Value = 200;
            tuple.Item4.Value.Value = 100;

            // Assert
            Assert.Equal(1, entity.Get<Position>().X);
            Assert.Equal(0.5, entity.Get<Velocity>().X);
            Assert.Equal(75, entity.Get<Health>().Value);
            Assert.Equal(10, entity.Get<Armor>().Value);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that all fields of ref tuple with four components are accessible.
        /// </summary>
        [Fact]
        public void RefTuple4_AllFields_ShouldBeAccessible()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position {X = 42, Y = 84};
            Velocity vel = new Velocity {X = 1.5f, Y = 2.5f};
            Health health = new Health {Value = 150};
            Armor armor = new Armor {Value = 75};
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);
            entity.Add(armor);

            // Act
            GameObjectRefTuple<Position, Velocity, Health, Armor> tuple = new GameObjectRefTuple<Position, Velocity, Health, Armor>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] {pos}, 0),
                Item2 = new Ref<Velocity>(new[] {vel}, 0),
                Item3 = new Ref<Health>(new[] {health}, 0),
                Item4 = new Ref<Armor>(new[] {armor}, 0)
            };

            // Assert
            Assert.Equal(entity, tuple.GameObject);
            Assert.Equal(42, tuple.Item1.Value.X);
            Assert.Equal(1.5f, tuple.Item2.Value.X);
            Assert.Equal(150, tuple.Item3.Value.Value);
            Assert.Equal(75, tuple.Item4.Value.Value);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that multiple ref tuples with four components maintain separate state.
        /// </summary>
        [Fact]
        public void RefTuple4_MultipleTuples_ShouldMaintainSeparateState()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity1 = world.Create();
            GameObject entity2 = world.Create();

            Position pos1 = new Position {X = 1, Y = 1};
            Velocity vel1 = new Velocity {X = 0.1f, Y = 0.1f};
            Health health1 = new Health {Value = 100};
            Armor armor1 = new Armor {Value = 50};
            entity1.Add(pos1);
            entity1.Add(vel1);
            entity1.Add(health1);
            entity1.Add(armor1);

            Position pos2 = new Position {X = 2, Y = 2};
            Velocity vel2 = new Velocity {X = 0.2f, Y = 0.2f};
            Health health2 = new Health {Value = 50};
            Armor armor2 = new Armor {Value = 25};
            entity2.Add(pos2);
            entity2.Add(vel2);
            entity2.Add(health2);
            entity2.Add(armor2);

            // Act
            GameObjectRefTuple<Position, Velocity, Health, Armor> tuple1 = new GameObjectRefTuple<Position, Velocity, Health, Armor>
            {
                GameObject = entity1,
                Item1 = new Ref<Position>(new[] {pos1}, 0),
                Item2 = new Ref<Velocity>(new[] {vel1}, 0),
                Item3 = new Ref<Health>(new[] {health1}, 0),
                Item4 = new Ref<Armor>(new[] {armor1}, 0)
            };

            GameObjectRefTuple<Position, Velocity, Health, Armor> tuple2 = new GameObjectRefTuple<Position, Velocity, Health, Armor>
            {
                GameObject = entity2,
                Item1 = new Ref<Position>(new[] {pos2}, 0),
                Item2 = new Ref<Velocity>(new[] {vel2}, 0),
                Item3 = new Ref<Health>(new[] {health2}, 0),
                Item4 = new Ref<Armor>(new[] {armor2}, 0)
            };

            // Assert
            Assert.NotEqual(tuple1.GameObject, tuple2.GameObject);
            Assert.Equal(1, tuple1.Item1.Value.X);
            Assert.Equal(2, tuple2.Item1.Value.X);

            world.Dispose();
        }
    }
}