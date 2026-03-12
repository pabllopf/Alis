// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectAddRemoveTest.cs
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
    ///     Tests for all Add and Remove methods of GameObject
    /// </summary>
    public class GameObjectAddRemoveTest
    {
        #region Add<T> (Arity 1) Tests

        /// <summary>
        /// Tests that Add with arity 1 adds component successfully
        /// </summary>
        [Fact]
        public void Add_Arity1_AddsComponentSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 10, Y = 20});

            Assert.True(entity.Has<Velocity>());
            Assert.Equal(10, entity.Get<Velocity>().X);
            Assert.Equal(20, entity.Get<Velocity>().Y);
        }

        /// <summary>
        /// Tests that Add with arity 1 adds component and can be verified
        /// </summary>
        [Fact]
        public void Add_Arity1_AddsComponentAndCanBeVerified()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.Equal(5, entity.Get<Velocity>().X);
            Assert.Equal(100, entity.Get<Health>().Value);
        }

        /// <summary>
        /// Tests that Add with arity 1 can modify existing component data
        /// </summary>
        [Fact]
        public void Add_Arity1_CanModifyComponentData()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Health {Value = 100});
            ref Health health = ref entity.Get<Health>();
            health.Value = 50;

            Assert.Equal(50, entity.Get<Health>().Value);
        }

        #endregion

        #region Add<T1, T2> (Arity 2) Tests

        /// <summary>
        /// Tests that Add with arity 2 adds both components successfully
        /// </summary>
        [Fact]
        public void Add_Arity2_AddsBothComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
        }

        /// <summary>
        /// Tests that Add with arity 2 adds components in sequence successfully
        /// </summary>
        [Fact]
        public void Add_Arity2_AddsComponentsInSequenceSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});
            entity.Add(new Armor {Value = 50});

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
        }

        #endregion

        #region Add<T1, T2, T3> (Arity 3) Tests

        /// <summary>
        /// Tests that Add with arity 3 adds all components successfully
        /// </summary>
        [Fact]
        public void Add_Arity3_AddsAllComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});
            entity.Add(new Armor {Value = 50});

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
        }

        #endregion

        #region Add<T1..T4> (Arity 4) Tests

        /// <summary>
        /// Tests that Add with arity 4 adds all components successfully
        /// </summary>
        [Fact]
        public void Add_Arity4_AddsAllComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});
            entity.Add(new Armor {Value = 50});
            entity.Add(new Damage {Value = 25});

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
            Assert.True(entity.Has<Damage>());
        }

        #endregion

        #region Add<T1..T5> (Arity 5) Tests

        /// <summary>
        /// Tests that Add with arity 5 adds all components successfully
        /// </summary>
        [Fact]
        public void Add_Arity5_AddsAllComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});
            entity.Add(new Armor {Value = 50});
            entity.Add(new Damage {Value = 25});
            entity.Add(new Transform {X = 0, Y = 0, Rotation = 0});

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
            Assert.True(entity.Has<Damage>());
            Assert.True(entity.Has<Transform>());
        }

        #endregion

        #region Add<T1..T6> (Arity 6) Tests

        /// <summary>
        /// Tests that Add with arity 6 adds all components successfully
        /// </summary>
        [Fact]
        public void Add_Arity6_AddsAllComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});
            entity.Add(new Armor {Value = 50});
            entity.Add(new Damage {Value = 25});
            entity.Add(new Transform {X = 0, Y = 0, Rotation = 0});
            entity.Add(new TestComponent {Value = 42});

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
            Assert.True(entity.Has<Damage>());
            Assert.True(entity.Has<Transform>());
            Assert.True(entity.Has<TestComponent>());
        }

        #endregion

        #region Add<T1..T7> (Arity 7) Tests

        /// <summary>
        /// Tests that Add with arity 7 adds all components successfully
        /// </summary>
        [Fact]
        public void Add_Arity7_AddsAllComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});
            entity.Add(new Armor {Value = 50});
            entity.Add(new Damage {Value = 25});
            entity.Add(new Transform {X = 0, Y = 0, Rotation = 0});
            entity.Add(new TestComponent {Value = 42});
            entity.Add(new AnotherComponent {Data = 1, Y = 1});

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
            Assert.True(entity.Has<Damage>());
            Assert.True(entity.Has<Transform>());
            Assert.True(entity.Has<TestComponent>());
            Assert.True(entity.Has<AnotherComponent>());
        }

        #endregion

        #region Add<T1..T8> (Arity 8) Tests

        /// <summary>
        /// Tests that Add with arity 8 adds all components successfully
        /// </summary>
        [Fact]
        public void Add_Arity8_AddsAllComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});
            entity.Add(new Armor {Value = 50});
            entity.Add(new Damage {Value = 25});
            entity.Add(new Transform {X = 0, Y = 0, Rotation = 0});
            entity.Add(new TestComponent {Value = 42});
            entity.Add(new AnotherComponent {Data = 1, Y = 1});
            entity.Add(new AnotherComponent2 {Name = "test"});

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
            Assert.True(entity.Has<Damage>());
            Assert.True(entity.Has<Transform>());
            Assert.True(entity.Has<TestComponent>());
            Assert.True(entity.Has<AnotherComponent>());
            Assert.True(entity.Has<AnotherComponent2>());
        }

        #endregion

        #region AddBoxed Tests

        /// <summary>
        /// Tests that AddBoxed adds component successfully
        /// </summary>
        [Fact]
        public void AddBoxed_AddsComponentSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.AddBoxed(new Velocity {X = 10, Y = 20});

            Assert.True(entity.Has<Velocity>());
            Assert.Equal(10, entity.Get<Velocity>().X);
        }

        /// <summary>
        /// Tests that AddBoxed with boxed value type works
        /// </summary>
        [Fact]
        public void AddBoxed_WithBoxedValueType_Works()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            object boxedHealth = new Health {Value = 75};
            entity.AddBoxed(boxedHealth);

            Assert.True(entity.Has<Health>());
            Assert.Equal(75, entity.Get<Health>().Value);
        }

        #endregion

        #region AddAs(Type, object) Tests

        /// <summary>
        /// Tests that AddAs with Type adds component successfully
        /// </summary>
        [Fact]
        public void AddAs_WithType_AddsComponentSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.AddAs(typeof(Velocity), new Velocity {X = 15, Y = 25});

            Assert.True(entity.Has<Velocity>());
            Assert.Equal(15, entity.Get<Velocity>().X);
        }

        #endregion

        #region AddAs(ComponentId, object) Tests

        /// <summary>
        /// Tests that AddAs with ComponentId adds component successfully
        /// </summary>
        [Fact]
        public void AddAs_WithComponentId_AddsComponentSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.AddAs(Component<Velocity>.Id, new Velocity {X = 20, Y = 30});

            Assert.True(entity.Has<Velocity>());
            Assert.Equal(20, entity.Get<Velocity>().X);
        }

        #endregion

        #region Remove<T> (Arity 1) Tests

        /// <summary>
        /// Tests that Remove with arity 1 removes component successfully
        /// </summary>
        [Fact]
        public void Remove_Arity1_RemovesComponentSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Add(new Velocity {X = 10, Y = 20});

            entity.Remove<Velocity>();

            Assert.False(entity.Has<Velocity>());
        }

        /// <summary>
        /// Tests that Remove with arity 1 removes component and can be verified
        /// </summary>
        [Fact]
        public void Remove_Arity1_RemovesComponentAndCanBeVerified()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});

            Assert.True(entity.Has<Velocity>());

            entity.Remove<Velocity>();

            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
        }

        /// <summary>
        /// Tests that Remove with arity 1 preserves other components
        /// </summary>
        [Fact]
        public void Remove_Arity1_PreservesOtherComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Add(new Velocity {X = 10, Y = 20});
            entity.Add(new Health {Value = 100});

            entity.Remove<Velocity>();

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Health>());
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
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});

            entity.Remove<Velocity>();
            entity.Remove<Health>();

            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
        }

        #endregion

        #region Remove<T1, T2, T3> (Arity 3) Tests

        /// <summary>
        /// Tests that Remove with arity 3 removes all components successfully
        /// </summary>
        [Fact]
        public void Remove_Arity3_RemovesAllComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});
            entity.Add(new Armor {Value = 50});

            entity.Remove<Velocity>();
            entity.Remove<Health>();
            entity.Remove<Armor>();

            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
        }

        #endregion

        #region Remove<T1..T4> (Arity 4) Tests

        /// <summary>
        /// Tests that Remove with arity 4 removes all components successfully
        /// </summary>
        [Fact]
        public void Remove_Arity4_RemovesAllComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});
            entity.Add(new Armor {Value = 50});
            entity.Add(new Damage {Value = 25});

            entity.Remove<Velocity>();
            entity.Remove<Health>();
            entity.Remove<Armor>();
            entity.Remove<Damage>();

            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
        }

        #endregion

        #region Remove<T1..T5> (Arity 5) Tests

        /// <summary>
        /// Tests that Remove with arity 5 removes all components successfully
        /// </summary>
        [Fact]
        public void Remove_Arity5_RemovesAllComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});
            entity.Add(new Armor {Value = 50});
            entity.Add(new Damage {Value = 25});
            entity.Add(new Transform {X = 0, Y = 0, Rotation = 0});

            entity.Remove<Velocity>();
            entity.Remove<Health>();
            entity.Remove<Armor>();
            entity.Remove<Damage>();
            entity.Remove<Transform>();

            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.False(entity.Has<Transform>());
        }

        #endregion

        #region Remove<T1..T6> (Arity 6) Tests

        /// <summary>
        /// Tests that Remove with arity 6 removes all components successfully
        /// </summary>
        [Fact]
        public void Remove_Arity6_RemovesAllComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});
            entity.Add(new Armor {Value = 50});
            entity.Add(new Damage {Value = 25});
            entity.Add(new Transform {X = 0, Y = 0, Rotation = 0});
            entity.Add(new TestComponent {Value = 42});

            entity.Remove<Velocity>();
            entity.Remove<Health>();
            entity.Remove<Armor>();
            entity.Remove<Damage>();
            entity.Remove<Transform>();
            entity.Remove<TestComponent>();

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
        /// Tests that Remove with arity 7 removes all components successfully
        /// </summary>
        [Fact]
        public void Remove_Arity7_RemovesAllComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});
            entity.Add(new Armor {Value = 50});
            entity.Add(new Damage {Value = 25});
            entity.Add(new Transform {X = 0, Y = 0, Rotation = 0});
            entity.Add(new TestComponent {Value = 42});
            entity.Add(new AnotherComponent {Data = 1, Y = 1});

            entity.Remove<Velocity>();
            entity.Remove<Health>();
            entity.Remove<Armor>();
            entity.Remove<Damage>();
            entity.Remove<Transform>();
            entity.Remove<TestComponent>();
            entity.Remove<AnotherComponent>();

            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.False(entity.Has<Transform>());
            Assert.False(entity.Has<TestComponent>());
            Assert.False(entity.Has<AnotherComponent>());
        }

        #endregion

        #region Remove<T1..T8> (Arity 8) Tests

        /// <summary>
        /// Tests that Remove with arity 8 removes all components successfully
        /// </summary>
        [Fact]
        public void Remove_Arity8_RemovesAllComponentsSuccessfully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Add(new Velocity {X = 5, Y = 10});
            entity.Add(new Health {Value = 100});
            entity.Add(new Armor {Value = 50});
            entity.Add(new Damage {Value = 25});
            entity.Add(new Transform {X = 0, Y = 0, Rotation = 0});
            entity.Add(new TestComponent {Value = 42});
            entity.Add(new AnotherComponent {Data = 1, Y = 1});
            entity.Add(new AnotherComponent2 {Name = "test"});

            entity.Remove<Velocity>();
            entity.Remove<Health>();
            entity.Remove<Armor>();
            entity.Remove<Damage>();
            entity.Remove<Transform>();
            entity.Remove<TestComponent>();
            entity.Remove<AnotherComponent>();
            entity.Remove<AnotherComponent2>();

            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.False(entity.Has<Transform>());
            Assert.False(entity.Has<TestComponent>());
            Assert.False(entity.Has<AnotherComponent>());
            Assert.False(entity.Has<AnotherComponent2>());
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
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Add(new Velocity {X = 10, Y = 20});

            entity.Remove(Component<Velocity>.Id);

            Assert.False(entity.Has<Velocity>());
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
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Add(new Velocity {X = 10, Y = 20});

            entity.Remove(typeof(Velocity));

            Assert.False(entity.Has<Velocity>());
        }

        #endregion

        #region Add/Remove Integration Tests

        /// <summary>
        /// Tests that Add and Remove can be used sequentially
        /// </summary>
        [Fact]
        public void AddRemove_CanBeUsedSequentially()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 10, Y = 20});
            Assert.True(entity.Has<Velocity>());

            entity.Remove<Velocity>();
            Assert.False(entity.Has<Velocity>());

            entity.Add(new Velocity {X = 5, Y = 15});
            Assert.True(entity.Has<Velocity>());
            Assert.Equal(5, entity.Get<Velocity>().X);
        }

        /// <summary>
        /// Tests that Add and Remove work with multiple components
        /// </summary>
        [Fact]
        public void AddRemove_WorksWithMultipleComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 10, Y = 20});
            entity.Add(new Health {Value = 100});
            entity.Add(new Armor {Value = 50});

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());

            entity.Remove<Health>();

            Assert.True(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
        }

        /// <summary>
        /// Tests that Remove only affects specified components
        /// </summary>
        [Fact]
        public void Remove_OnlyAffectsSpecifiedComponents()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Add(new Velocity {X = 10, Y = 20});
            entity.Add(new Health {Value = 100});

            entity.Remove<Velocity>();

            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.Equal(1, entity.Get<Position>().X);
            Assert.Equal(100, entity.Get<Health>().Value);
        }

        #endregion
    }
}

