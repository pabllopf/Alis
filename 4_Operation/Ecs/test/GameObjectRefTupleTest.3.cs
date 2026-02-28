// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectRefTupleTest.3.cs
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
    ///     Tests the <see cref="GameObjectRefTuple{T1, T2, T3}" /> struct with three components.
    /// </summary>
    public partial class GameObjectRefTupleTest
    {
        /// <summary>
        ///     Tests that game object ref tuple with three components can be created.
        /// </summary>
        [Fact]
        public void RefTuple3_Initialize_ShouldSetGameObjectAndComponents()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position {X = 10, Y = 20};
            Velocity vel = new Velocity {VX = 1, VY = 2};
            Health health = new Health {Value = 100};
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);

            // Act
            GameObjectRefTuple<Position, Velocity, Health> tuple = new GameObjectRefTuple<Position, Velocity, Health>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] {pos}, 0),
                Item2 = new Ref<Velocity>(new[] {vel}, 0),
                Item3 = new Ref<Health>(new[] {health}, 0)
            };

            // Assert
            Assert.Equal(entity, tuple.GameObject);
            Assert.Equal(10, tuple.Item1.Value.X);
            Assert.Equal(1, tuple.Item2.Value.VX);
            Assert.Equal(100, tuple.Item3.Value.Value);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that ref tuple with three components can be deconstructed.
        /// </summary>
        [Fact]
        public void RefTuple3_Deconstruct_ShouldReturnGameObjectAndAllRefs()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position {X = 5, Y = 10};
            Velocity vel = new Velocity {VX = 2, VY = 3};
            Health health = new Health {Value = 50};
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);

            GameObjectRefTuple<Position, Velocity, Health> tuple = new GameObjectRefTuple<Position, Velocity, Health>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] {pos}, 0),
                Item2 = new Ref<Velocity>(new[] {vel}, 0),
                Item3 = new Ref<Health>(new[] {health}, 0)
            };

            // Act
            (GameObject go, Ref<Position> posRef, Ref<Velocity> velRef, Ref<Health> healthRef) = tuple;

            // Assert
            Assert.Equal(entity, go);
            Assert.Equal(5, posRef.Value.X);
            Assert.Equal(2, velRef.Value.VX);
            Assert.Equal(50, healthRef.Value.Value);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that modifying components through ref tuple updates all of them.
        /// </summary>
        [Fact]
        public void RefTuple3_ModifyComponents_ShouldUpdateAll()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position {X = 1, Y = 2};
            Velocity vel = new Velocity {VX = 0.5f, VY = 0.5f};
            Health health = new Health {Value = 75};
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);

            GameObjectRefTuple<Position, Velocity, Health> tuple = new GameObjectRefTuple<Position, Velocity, Health>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] {pos}, 0),
                Item2 = new Ref<Velocity>(new[] {vel}, 0),
                Item3 = new Ref<Health>(new[] {health}, 0)
            };

            // Act
            tuple.Item1.Value.X = 100;
            tuple.Item2.Value.VX = 10;
            tuple.Item3.Value.Value = 200;

            // Assert
            Assert.Equal(1, entity.Get<Position>().X);
            Assert.Equal(0.5, entity.Get<Velocity>().VX);
            Assert.Equal(75, entity.Get<Health>().Value);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that multiple ref tuples with three components maintain separate state.
        /// </summary>
        [Fact]
        public void RefTuple3_MultipleTuples_ShouldMaintainSeparateState()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity1 = world.Create();
            GameObject entity2 = world.Create();

            Position pos1 = new Position {X = 1, Y = 1};
            Velocity vel1 = new Velocity {VX = 0.1f, VY = 0.1f};
            Health health1 = new Health {Value = 100};
            entity1.Add(pos1);
            entity1.Add(vel1);
            entity1.Add(health1);

            Position pos2 = new Position {X = 2, Y = 2};
            Velocity vel2 = new Velocity {VX = 0.2f, VY = 0.2f};
            Health health2 = new Health {Value = 50};
            entity2.Add(pos2);
            entity2.Add(vel2);
            entity2.Add(health2);

            // Act
            GameObjectRefTuple<Position, Velocity, Health> tuple1 = new GameObjectRefTuple<Position, Velocity, Health>
            {
                GameObject = entity1,
                Item1 = new Ref<Position>(new[] {pos1}, 0),
                Item2 = new Ref<Velocity>(new[] {vel1}, 0),
                Item3 = new Ref<Health>(new[] {health1}, 0)
            };

            GameObjectRefTuple<Position, Velocity, Health> tuple2 = new GameObjectRefTuple<Position, Velocity, Health>
            {
                GameObject = entity2,
                Item1 = new Ref<Position>(new[] {pos2}, 0),
                Item2 = new Ref<Velocity>(new[] {vel2}, 0),
                Item3 = new Ref<Health>(new[] {health2}, 0)
            };

            // Assert
            Assert.NotEqual(tuple1.GameObject, tuple2.GameObject);
            Assert.Equal(1, tuple1.Item1.Value.X);
            Assert.Equal(2, tuple2.Item1.Value.X);
            Assert.Equal(100, tuple1.Item3.Value.Value);
            Assert.Equal(50, tuple2.Item3.Value.Value);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that all fields of ref tuple with three components are accessible.
        /// </summary>
        [Fact]
        public void RefTuple3_AllFields_ShouldBeAccessible()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position {X = 42, Y = 84};
            Velocity vel = new Velocity {VX = 1.5f, VY = 2.5f};
            Health health = new Health {Value = 150};
            entity.Add(pos);
            entity.Add(vel);
            entity.Add(health);

            // Act
            GameObjectRefTuple<Position, Velocity, Health> tuple = new GameObjectRefTuple<Position, Velocity, Health>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] {pos}, 0),
                Item2 = new Ref<Velocity>(new[] {vel}, 0),
                Item3 = new Ref<Health>(new[] {health}, 0)
            };

            // Assert
            Assert.Equal(entity, tuple.GameObject);
            Assert.Equal(42, tuple.Item1.Value.X);
            Assert.Equal(1.5f, tuple.Item2.Value.VX);
            Assert.Equal(150, tuple.Item3.Value.Value);

            world.Dispose();
        }

        /// <summary>
        ///     Tests that ref tuple with three different component types works.
        /// </summary>
        [Fact]
        public void RefTuple3_WithDifferentComponentTypes_ShouldWork()
        {
            // Arrange
            Scene world = new Scene();
            GameObject entity = world.Create();
            Position pos = new Position {X = 5, Y = 10};
            Health health = new Health {Value = 100};
            Armor armor = new Armor {Defense = 25};
            entity.Add(pos);
            entity.Add(health);
            entity.Add(armor);

            // Act
            GameObjectRefTuple<Position, Health, Armor> tuple = new GameObjectRefTuple<Position, Health, Armor>
            {
                GameObject = entity,
                Item1 = new Ref<Position>(new[] {pos}, 0),
                Item2 = new Ref<Health>(new[] {health}, 0),
                Item3 = new Ref<Armor>(new[] {armor}, 0)
            };

            // Assert
            Assert.Equal(5, tuple.Item1.Value.X);
            Assert.Equal(100, tuple.Item2.Value.Value);
            Assert.Equal(25, tuple.Item3.Value.Defense);

            world.Dispose();
        }
    }
}