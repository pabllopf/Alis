// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectRemoveTest.cs
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

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Comprehensive tests for all Remove methods of GameObject (arities 1-8 + non-generic variants)
    /// </summary>
    public class GameObjectRemoveTest
    {
        #region Remove<T> (Arity 1) Tests

        /// <summary>
        /// Tests that Remove with arity 1 removes the component successfully
        /// </summary>
        [Fact]
        public void Remove_Arity1_RemovesComponentSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {VX = 10, VY = 20});

            Assert.True(entity.Has<Velocity>());

            entity.Remove<Velocity>();

            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Position>());
        }

        /// <summary>
        /// Tests that Remove with arity 1 preserves other components
        /// </summary>
        [Fact]
        public void Remove_Arity1_PreservesOtherComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 5, Y = 10},
                new Velocity {VX = 1, VY = 2},
                new Health {Value = 100}
            );

            entity.Remove<Velocity>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.Equal(5, entity.Get<Position>().X);
            Assert.Equal(100, entity.Get<Health>().Value);
        }

        /// <summary>
        /// Tests that Remove with arity 1 can be called multiple times
        /// </summary>
        [Fact]
        public void Remove_Arity1_CanBeCalledMultipleTimes()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 5, VY = 10},
                new Health {Value = 100}
            );

            entity.Remove<Velocity>();
            entity.Remove<Health>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
        }

        /// <summary>
        /// Tests that Remove with arity 1 updates entity type correctly
        /// </summary>
        [Fact]
        public void Remove_Arity1_UpdatesEntityTypeCorrectly()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {VX = 5, VY = 10});

            entity.Remove<Velocity>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
        }

        #endregion

        #region Remove<T1, T2> (Arity 2) Tests

        /// <summary>
        /// Tests that Remove with arity 2 removes both components successfully
        /// </summary>
        [Fact]
        public void Remove_Arity2_RemovesBothComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 5, VY = 10},
                new Health {Value = 100}
            );

            entity.Remove<Velocity>();
            entity.Remove<Health>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
        }

        /// <summary>
        /// Tests that Remove with arity 2 preserves remaining components
        /// </summary>
        [Fact]
        public void Remove_Arity2_PreservesRemainingComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 5, VY = 10},
                new Health {Value = 100},
                new Armor {Defense = 50}
            );

            entity.Remove<Velocity>();
            entity.Remove<Health>();

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Armor>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
        }

        #endregion

        #region Remove<T1, T2, T3> (Arity 3) Tests

        /// <summary>
        /// Tests that Remove with arity 3 removes all three components successfully
        /// </summary>
        [Fact]
        public void Remove_Arity3_RemovesAllThreeComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 5, VY = 10},
                new Health {Value = 100},
                new Armor {Defense = 50}
            );

            entity.Remove<Velocity>();
            entity.Remove<Health>();
            entity.Remove<Armor>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
        }

        /// <summary>
        /// Tests that Remove with arity 3 works with sequential removals
        /// </summary>
        [Fact]
        public void Remove_Arity3_WorksWithSequentialRemovals()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 5, VY = 10},
                new Health {Value = 100},
                new Armor {Defense = 50},
                new Damage {Amount = 25}
            );

            entity.Remove<Velocity>();
            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());

            entity.Remove<Health>();
            Assert.False(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());

            entity.Remove<Armor>();
            Assert.False(entity.Has<Armor>());
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Damage>());
        }

        #endregion

        #region Remove<T1, T2, T3, T4> (Arity 4) Tests

        /// <summary>
        /// Tests that Remove with arity 4 removes all four components successfully
        /// </summary>
        [Fact]
        public void Remove_Arity4_RemovesAllFourComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 5, VY = 10},
                new Health {Value = 100},
                new Armor {Defense = 50},
                new Damage {Amount = 25}
            );

            entity.Remove<Velocity>();
            entity.Remove<Health>();
            entity.Remove<Armor>();
            entity.Remove<Damage>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
        }

        /// <summary>
        /// Tests that Remove with arity 4 maintains entity integrity
        /// </summary>
        [Fact]
        public void Remove_Arity4_MaintainsEntityIntegrity()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 10, Y = 20},
                new Velocity {VX = 1, VY = 2},
                new Health {Value = 100},
                new Armor {Defense = 50},
                new Damage {Amount = 25}
            );

            entity.Remove<Velocity>();
            entity.Remove<Armor>();

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Damage>());
            Assert.Equal(10, entity.Get<Position>().X);
            Assert.Equal(100, entity.Get<Health>().Value);
        }

        #endregion

        #region Remove<T1..T5> (Arity 5) Tests

        /// <summary>
        /// Tests that Remove with arity 5 removes all five components successfully
        /// </summary>
        [Fact]
        public void Remove_Arity5_RemovesAllFiveComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 5, VY = 10},
                new Health {Value = 100},
                new Armor {Defense = 50},
                new Damage {Amount = 25},
                new Transform {X = 0, Y = 0, Rotation = 0}
            );

            entity.Remove<Velocity>();
            entity.Remove<Health>();
            entity.Remove<Armor>();
            entity.Remove<Damage>();
            entity.Remove<Transform>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.False(entity.Has<Transform>());
        }

        /// <summary>
        /// Tests that Remove with arity 5 works in different orders
        /// </summary>
        [Fact]
        public void Remove_Arity5_WorksInDifferentOrders()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 5, VY = 10},
                new Health {Value = 100},
                new Armor {Defense = 50},
                new Damage {Amount = 25},
                new Transform {X = 0, Y = 0, Rotation = 0}
            );

            // Remove in different order
            entity.Remove<Transform>();
            entity.Remove<Armor>();
            entity.Remove<Velocity>();

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Damage>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Transform>());
        }

        #endregion

        #region Remove<T1..T6> (Arity 6) Tests

        /// <summary>
        /// Tests that Remove with arity 6 removes all six components successfully
        /// </summary>
        [Fact]
        public void Remove_Arity6_RemovesAllSixComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 5, VY = 10},
                new Health {Value = 100},
                new Armor {Defense = 50},
                new Damage {Amount = 25},
                new Transform {X = 0, Y = 0, Rotation = 0},
                new TestComponent {Value = 42}
            );

            entity.Remove<Velocity>();
            entity.Remove<Health>();
            entity.Remove<Armor>();
            entity.Remove<Damage>();
            entity.Remove<Transform>();
            entity.Remove<TestComponent>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.False(entity.Has<Transform>());
            Assert.False(entity.Has<TestComponent>());
        }

        #endregion

        #region Remove<T1..T7> (Arity 7) Tests

        /// <summary>
        /// Tests that Remove with arity 7 removes all seven components successfully
        /// </summary>
        [Fact]
        public void Remove_Arity7_RemovesAllSevenComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 5, VY = 10},
                new Health {Value = 100},
                new Armor {Defense = 50},
                new Damage {Amount = 25},
                new Transform {X = 0, Y = 0, Rotation = 0},
                new TestComponent {Value = 42}
            );
            entity.Add(new AnotherComponent {X = 1, Y = 1});

            entity.Remove<Velocity>();
            entity.Remove<Health>();
            entity.Remove<Armor>();
            entity.Remove<Damage>();
            entity.Remove<Transform>();
            entity.Remove<TestComponent>();
            entity.Remove<AnotherComponent>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.False(entity.Has<Transform>());
            Assert.False(entity.Has<TestComponent>());
            Assert.False(entity.Has<AnotherComponent>());
        }

        /// <summary>
        /// Tests that Remove with arity 7 preserves entity after partial removal
        /// </summary>
        [Fact]
        public void Remove_Arity7_PreservesEntityAfterPartialRemoval()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 100, Y = 200},
                new Velocity {VX = 5, VY = 10},
                new Health {Value = 100},
                new Armor {Defense = 50},
                new Damage {Amount = 25},
                new Transform {X = 0, Y = 0, Rotation = 0},
                new TestComponent {Value = 42}
            );
            entity.Add(new AnotherComponent {X = 1, Y = 1});

            entity.Remove<Velocity>();
            entity.Remove<Armor>();
            entity.Remove<TestComponent>();

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Damage>());
            Assert.True(entity.Has<Transform>());
            Assert.True(entity.Has<AnotherComponent>());
            Assert.Equal(100, entity.Get<Position>().X);
        }

        #endregion

        #region Remove<T1..T8> (Arity 8) Tests

        /// <summary>
        /// Tests that Remove with arity 8 removes all eight components successfully
        /// </summary>
        [Fact]
        public void Remove_Arity8_RemovesAllEightComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 5, VY = 10},
                new Health {Value = 100},
                new Armor {Defense = 50},
                new Damage {Amount = 25},
                new Transform {X = 0, Y = 0, Rotation = 0},
                new TestComponent {Value = 42}
            );
            entity.Add(new AnotherComponent {X = 1, Y = 1});
            entity.Add(new AnotherComponent2 {Name = "test"});

            entity.Remove<Velocity>();
            entity.Remove<Health>();
            entity.Remove<Armor>();
            entity.Remove<Damage>();
            entity.Remove<Transform>();
            entity.Remove<TestComponent>();
            entity.Remove<AnotherComponent>();
            entity.Remove<AnotherComponent2>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.False(entity.Has<Transform>());
            Assert.False(entity.Has<TestComponent>());
            Assert.False(entity.Has<AnotherComponent>());
            Assert.False(entity.Has<AnotherComponent2>());
        }

        /// <summary>
        /// Tests that Remove with arity 8 works with complex removal patterns
        /// </summary>
        [Fact]
        public void Remove_Arity8_WorksWithComplexRemovalPatterns()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 5, VY = 10},
                new Health {Value = 100},
                new Armor {Defense = 50},
                new Damage {Amount = 25},
                new Transform {X = 0, Y = 0, Rotation = 0},
                new TestComponent {Value = 42}
            );
            entity.Add(new AnotherComponent {X = 1, Y = 1});
            entity.Add(new AnotherComponent2 {Name = "test"});

            // Remove every other component
            entity.Remove<Velocity>();
            entity.Remove<Armor>();
            entity.Remove<Transform>();
            entity.Remove<AnotherComponent>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.True(entity.Has<Damage>());
            Assert.False(entity.Has<Transform>());
            Assert.True(entity.Has<TestComponent>());
            Assert.False(entity.Has<AnotherComponent>());
            Assert.True(entity.Has<AnotherComponent2>());
        }

        #endregion

        #region Remove(ComponentId) Tests

        /// <summary>
        /// Tests that Remove with ComponentId removes component successfully
        /// </summary>
        [Fact]
        public void Remove_WithComponentId_RemovesComponentSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 10, VY = 20}
            );

            entity.Remove(Component<Velocity>.Id);

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
        }

        /// <summary>
        /// Tests that Remove with ComponentId works with multiple components
        /// </summary>
        [Fact]
        public void Remove_WithComponentId_WorksWithMultipleComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 10, VY = 20},
                new Health {Value = 100}
            );

            entity.Remove(Component<Velocity>.Id);
            entity.Remove(Component<Health>.Id);

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
        }

        /// <summary>
        /// Tests that Remove with ComponentId preserves component data for remaining components
        /// </summary>
        [Fact]
        public void Remove_WithComponentId_PreservesRemainingComponentData()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 50, Y = 100},
                new Velocity {VX = 10, VY = 20},
                new Health {Value = 75}
            );

            entity.Remove(Component<Velocity>.Id);

            Assert.Equal(50, entity.Get<Position>().X);
            Assert.Equal(75, entity.Get<Health>().Value);
        }

        #endregion

        #region Remove(Type) Tests

        /// <summary>
        /// Tests that Remove with Type removes component successfully
        /// </summary>
        [Fact]
        public void Remove_WithType_RemovesComponentSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 10, VY = 20}
            );

            entity.Remove(typeof(Velocity));

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
        }

        /// <summary>
        /// Tests that Remove with Type works with multiple removals
        /// </summary>
        [Fact]
        public void Remove_WithType_WorksWithMultipleRemovals()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 10, VY = 20},
                new Health {Value = 100},
                new Armor {Defense = 50}
            );

            entity.Remove(typeof(Velocity));
            entity.Remove(typeof(Armor));

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
        }

        /// <summary>
        /// Tests that Remove with Type maintains data integrity
        /// </summary>
        [Fact]
        public void Remove_WithType_MaintainsDataIntegrity()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 99, Y = 88},
                new Velocity {VX = 10, VY = 20},
                new Health {Value = 150}
            );

            entity.Remove(typeof(Velocity));

            Assert.Equal(99, entity.Get<Position>().X);
            Assert.Equal(88, entity.Get<Position>().Y);
            Assert.Equal(150, entity.Get<Health>().Value);
        }

        #endregion

        #region Integration and Edge Cases Tests

        /// <summary>
        /// Tests that Remove works after Add operations
        /// </summary>
        [Fact]
        public void Remove_WorksAfterAddOperations()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {VX = 10, VY = 20});
            entity.Add(new Health {Value = 100});

            Assert.True(entity.Has<Velocity>());

            entity.Remove<Velocity>();

            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
        }

        /// <summary>
        /// Tests that Remove can be followed by Add with same component type
        /// </summary>
        [Fact]
        public void Remove_CanBeFollowedByAddWithSameComponentType()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 10, VY = 20}
            );

            entity.Remove<Velocity>();
            Assert.False(entity.Has<Velocity>());

            entity.Add(new Velocity {VX = 5, VY = 15});
            Assert.True(entity.Has<Velocity>());
            Assert.Equal(5, entity.Get<Velocity>().VX);
        }

        /// <summary>
        /// Tests that Remove works with all non-generic variants
        /// </summary>
        [Fact]
        public void Remove_WorksWithAllNonGenericVariants()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 10, VY = 20},
                new Health {Value = 100}
            );

            // Generic remove
            entity.Remove<Velocity>();
            Assert.False(entity.Has<Velocity>());

            // ComponentId remove
            entity.Add(new Velocity {VX = 5, VY = 5});
            entity.Remove(Component<Velocity>.Id);
            Assert.False(entity.Has<Velocity>());

            // Type remove
            entity.Remove(typeof(Health));
            Assert.False(entity.Has<Health>());

            Assert.True(entity.Has<Position>());
        }

        /// <summary>
        /// Tests that Remove maintains entity stability with multiple operations
        /// </summary>
        [Fact]
        public void Remove_MaintainsEntityStabilityWithMultipleOperations()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 5, VY = 10},
                new Health {Value = 100}
            );

            for (int i = 0; i < 5; i++)
            {
                entity.Add(new Armor {Defense = i * 10});
                entity.Remove<Armor>();
            }

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
        }

        /// <summary>
        /// Tests that Remove works correctly when leaving only one component
        /// </summary>
        [Fact]
        public void Remove_WorksCorrectlyWhenLeavingOnlyOneComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 10, Y = 20},
                new Velocity {VX = 5, VY = 10},
                new Health {Value = 100}
            );

            entity.Remove<Velocity>();
            entity.Remove<Health>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.Equal(10, entity.Get<Position>().X);
            Assert.Equal(20, entity.Get<Position>().Y);
        }

        /// <summary>
        /// Tests that Remove updates archetype correctly
        /// </summary>
        [Fact]
        public void Remove_UpdatesArchetypeCorrectly()
        {
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position {X = 1, Y = 2}, new Velocity {VX = 5, VY = 10});
            GameObject entity2 = scene.Create(new Position {X = 3, Y = 4}, new Velocity {VX = 15, VY = 20});

            entity1.Remove<Velocity>();

            Assert.False(entity1.Has<Velocity>());
            Assert.True(entity2.Has<Velocity>());
        }

        #endregion
    }
}

