// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectRemainingCoverageTests.cs
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
using System.Collections.Generic;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    public class GameObjectRemainingCoverageTests
    {
        [Fact]
        public void Add_WhenAllowStructualChangesFalse_DeferredViaCommandBuffer()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 3, Y = 4});

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.True(entity.Has<Velocity>());
            Assert.Equal(3, entity.Get<Velocity>().X);
        }

        [Fact]
        public void Remove_WhenAllowStructualChangesFalse_DeferredViaCommandBuffer()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});
            scene.EnterDisallowState();

            entity.Remove<Velocity>();

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Position>());
        }

        [Fact]
        public void AddAs_WhenAllowStructualChangesFalse_DeferredViaCommandBuffer()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.AddAs(Component<Velocity>.Id, new Velocity {X = 5, Y = 10});

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.True(entity.Has<Velocity>());
            Assert.Equal(5, entity.Get<Velocity>().X);
        }

        [Fact]
        public void AddAs_ByType_WhenAllowStructualChangesFalse_Deferred()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.AddAs(typeof(Velocity), new Velocity {X = 7, Y = 14});

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.True(entity.Has<Velocity>());
            Assert.Equal(7, entity.Get<Velocity>().X);
        }

        [Fact]
        public void Delete_WhenAllowStructualChangesFalse_DeferredViaCommandBuffer()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            scene.EnterDisallowState();

            entity.Delete();

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.False(entity.IsAlive);
        }

        [Fact]
        public void Has_OnDeadEntity_ThrowsInvalidOperationException()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();

            Assert.Throws<InvalidOperationException>(() => entity.Has<Position>());
        }

        [Fact]
        public void Has_WithComponentId_OnDeadEntity_ThrowsInvalidOperationException()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();

            Assert.Throws<InvalidOperationException>(() => entity.Has(Component<Position>.Id));
        }

        [Fact]
        public void Has_WithType_OnDeadEntity_ThrowsInvalidOperationException()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();

            Assert.Throws<InvalidOperationException>(() => entity.Has(typeof(Position)));
        }

        [Fact]
        public void TryGet_Unsafe_OnDeadEntity_ThrowsInvalidOperationException()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();

            Assert.Throws<InvalidOperationException>(() => entity.TryGet(typeof(Position), out _));
        }

        [Fact]
        public void SceneGetter_OnDeadEntity_ReturnsScene()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();

            Assert.Equal(scene, entity.Scene);
        }

        [Fact]
        public void ComponentTypes_OnDeadEntity_ThrowsInvalidOperationException()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();

            Assert.Throws<InvalidOperationException>(() => _ = entity.ComponentTypes);
        }

        [Fact]
        public void Type_OnDeadEntity_ThrowsInvalidOperationException()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});
            entity.Delete();

            Assert.Throws<InvalidOperationException>(() => _ = entity.Type);
        }

        [Fact]
        public void Get_ByComponentId_ThrowsComponentNotFoundException_WhenMissing()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            Assert.Throws<ComponentNotFoundException>(() => entity.Get(Component<Velocity>.Id));
        }

        [Fact]
        public void Get_ByType_ThrowsComponentNotFoundException_WhenMissing()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            Assert.Throws<ComponentNotFoundException>(() => entity.Get(typeof(Velocity)));
        }

        [Fact]
        public void EnumerateComponents_WithOneComponent_VisitsOne()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            CountingGenericActionPlain counter = new CountingGenericActionPlain();
            entity.EnumerateComponents(counter);

            Assert.Equal(1, counter.CallCount);
        }

        [Fact]
        public void Add_WithWorldEvent_FiresComponentAddedEvent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            List<ComponentId> addedIds = new List<ComponentId>();
            scene.ComponentAdded += (go, id) => addedIds.Add(id);

            entity.Add(new Velocity {X = 3, Y = 4});

            Assert.Contains(Component<Velocity>.Id, addedIds);
        }

        [Fact]
        public void Remove_WithWorldEvent_FiresComponentRemovedEvent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});

            List<ComponentId> removedIds = new List<ComponentId>();
            scene.ComponentRemoved += (go, id) => removedIds.Add(id);

            entity.Remove<Velocity>();

            Assert.Contains(Component<Velocity>.Id, removedIds);
        }

        [Fact]
        public void Add_WithPerEntityEvent_FiresOnComponentAdded()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            int calls = 0;
            entity.OnComponentAdded += (go, id) => calls++;

            entity.Add(new Velocity {X = 3, Y = 4});

            Assert.Equal(1, calls);
        }

        [Fact]
        public void Remove_WithPerEntityEvent_FiresOnComponentRemoved()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});

            int calls = 0;
            entity.OnComponentRemoved += (go, id) => calls++;

            entity.Remove<Velocity>();

            Assert.Equal(1, calls);
        }

        [Fact]
        public void Delete_WithPerEntityEvent_FiresOnDelete()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            int calls = 0;
            entity.OnDelete += (go) => calls++;

            entity.Delete();

            Assert.Equal(1, calls);
        }

        [Fact]
        public void Add_MultiComponent_WithWorldEvent_FiresForEach()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            List<ComponentId> addedIds = new List<ComponentId>();
            scene.ComponentAdded += (go, id) => addedIds.Add(id);

            entity.Add(new Velocity {X = 3, Y = 4});

            Assert.Single(addedIds);
        }

        [Fact]
        public void Remove_MultiComponent_WithWorldEvent_FiresForEach()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});

            List<ComponentId> removedIds = new List<ComponentId>();
            scene.ComponentRemoved += (go, id) => removedIds.Add(id);

            entity.Remove<Velocity>();

            Assert.Contains(Component<Velocity>.Id, removedIds);
        }

        [Fact]
        public void UnsubscribeEvent_WhenLastListenerRemoved_ClearsFlag()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            Action<GameObject, ComponentId> handler = (go, id) => { };
            entity.OnComponentAdded += handler;
            entity.OnComponentAdded -= handler;

            int calls = 0;
            entity.OnComponentAdded += (go, id) => calls++;
            entity.Add(new Velocity {X = 3, Y = 4});

            Assert.Equal(1, calls);
        }

        [Fact]
        public void UnsubscribeEvent_OnDelete_WhenLastListenerRemoved_ClearsFlag()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            Action<GameObject> handler = (go) => { };
            entity.OnDelete += handler;
            entity.OnDelete -= handler;

            int calls = 0;
            entity.OnDelete += (go) => calls++;
            entity.Delete();

            Assert.Equal(1, calls);
        }

        [Fact]
        public void InitalizeEventRecord_ForOnDelete_AddsHandler()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            int calls = 0;
            entity.OnDelete += (go) => calls++;

            entity.Delete();

            Assert.Equal(1, calls);
        }

        [Fact]
        public void InitalizeEventRecord_ForOnComponentAddedGeneric_AddsGenericHandler()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            CountingGenericAction action = new CountingGenericAction();
            entity.OnComponentAddedGeneric += action;

            entity.Add(new Health {Value = 10});

            Assert.Equal(1, action.CallCount);
        }

        [Fact]
        public void InitalizeEventRecord_ForOnComponentRemovedGeneric_AddsGenericHandler()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Health {Value = 10});

            CountingGenericAction action = new CountingGenericAction();
            entity.OnComponentRemovedGeneric += action;

            entity.Remove<Health>();

            Assert.Equal(1, action.CallCount);
        }

        [Fact]
        public void Remove_NonGeneric_ByComponentId_WithAllowStructualChangesFalse_Deferred()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});
            scene.EnterDisallowState();

            entity.Remove(Component<Velocity>.Id);

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Position>());
        }

        [Fact]
        public void Remove_NonGeneric_ByType_WithAllowStructualChangesFalse_Deferred()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4});
            scene.EnterDisallowState();

            entity.Remove(typeof(Velocity));

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.False(entity.Has<Velocity>());
            Assert.True(entity.Has<Position>());
        }

        [Fact]
        public void Add_T1T2_Deferred_WhenAllowStructualChangesFalse()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 3, Y = 4}, new Health {Value = 5});

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
        }

        [Fact]
        public void Add_T1T2T3_Deferred_WhenAllowStructualChangesFalse()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(new Velocity {X = 3, Y = 4}, new Health {Value = 5}, new Armor {Value = 6});

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
        }

        [Fact]
        public void Add_T1T2T3T4_Deferred_WhenAllowStructualChangesFalse()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Armor {Value = 6},
                new Damage {Value = 7});

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Armor>());
            Assert.True(entity.Has<Damage>());
        }

        [Fact]
        public void Add_T1T2T3T4T5_Deferred_WhenAllowStructualChangesFalse()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Armor {Value = 6},
                new Damage {Value = 7},
                new Transform {X = 8, Y = 9});

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
            Assert.True(entity.Has<Transform>());
        }

        [Fact]
        public void Add_T1T2T3T4T5T6_Deferred_WhenAllowStructualChangesFalse()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Armor {Value = 6},
                new Damage {Value = 7},
                new Transform {X = 8, Y = 9},
                new TestComponent {Value = 10});

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<TestComponent>());
        }

        [Fact]
        public void Add_T1T2T3T4T5T6T7_Deferred_WhenAllowStructualChangesFalse()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Armor {Value = 6},
                new Damage {Value = 7},
                new Transform {X = 8, Y = 9},
                new TestComponent {Value = 10},
                new AnotherComponent {Name = "a"});

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<AnotherComponent>());
        }

        [Fact]
        public void Add_T1T2T3T4T5T6T7T8_Deferred_WhenAllowStructualChangesFalse()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Add(
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Armor {Value = 6},
                new Damage {Value = 7},
                new Transform {X = 8, Y = 9},
                new TestComponent {Value = 10},
                new AnotherComponent {Name = "a"},
                new AnotherComponent2 {Name = "b"});

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<AnotherComponent2>());
        }

        [Fact]
        public void Remove_T1T2_Deferred_WhenAllowStructualChangesFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2}, new Velocity {X = 3, Y = 4}, new Health {Value = 5});
            scene.EnterDisallowState();

            entity.Remove<Velocity, Health>();

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.True(entity.Has<Position>());
        }

        [Fact]
        public void Remove_T1T2T3_Deferred_WhenAllowStructualChangesFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Armor {Value = 6});
            scene.EnterDisallowState();

            entity.Remove<Velocity, Health, Armor>();

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.True(entity.Has<Position>());
        }

        [Fact]
        public void Remove_T1T2T3T4_Deferred_WhenAllowStructualChangesFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Armor {Value = 6},
                new Damage {Value = 7});
            scene.EnterDisallowState();

            entity.Remove<Velocity, Health, Armor, Damage>();

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.True(entity.Has<Position>());
        }

        [Fact]
        public void Remove_T1T2T3T4T5_Deferred_WhenAllowStructualChangesFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Armor {Value = 6},
                new Damage {Value = 7},
                new Transform {X = 8, Y = 9});
            scene.EnterDisallowState();

            entity.Remove<Velocity, Health, Armor, Damage, Transform>();

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.False(entity.Has<Transform>());
            Assert.True(entity.Has<Position>());
        }

        [Fact]
        public void Remove_T1T2T3T4T5T6_Deferred_WhenAllowStructualChangesFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Armor {Value = 6},
                new Damage {Value = 7},
                new Transform {X = 8, Y = 9},
                new TestComponent {Value = 10});
            scene.EnterDisallowState();

            entity.Remove<Velocity, Health, Armor, Damage, Transform, TestComponent>();

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.False(entity.Has<Transform>());
            Assert.False(entity.Has<TestComponent>());
            Assert.True(entity.Has<Position>());
        }

        [Fact]
        public void Remove_T1T2T3T4T5T6T7_Deferred_WhenAllowStructualChangesFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Armor {Value = 6},
                new Damage {Value = 7},
                new Transform {X = 8, Y = 9},
                new TestComponent {Value = 10});
            entity.Add(new AnotherComponent {Name = "a"});
            scene.EnterDisallowState();

            entity.Remove<Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent>();

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.False(entity.Has<Transform>());
            Assert.False(entity.Has<TestComponent>());
            Assert.False(entity.Has<AnotherComponent>());
            Assert.True(entity.Has<Position>());
        }

        [Fact]
        public void Remove_T1T2T3T4T5T6T7T8_Deferred_WhenAllowStructualChangesFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {X = 3, Y = 4},
                new Health {Value = 5},
                new Armor {Value = 6},
                new Damage {Value = 7},
                new Transform {X = 8, Y = 9},
                new TestComponent {Value = 10});
            entity.Add(new AnotherComponent {Name = "a"});
            entity.Add(new AnotherComponent2 {Name = "b"});
            scene.EnterDisallowState();

            entity.Remove<Velocity, Health, Armor, Damage, Transform, TestComponent, AnotherComponent, AnotherComponent2>();

            scene.ExitDisallowState(null);
            scene.Update();

            Assert.False(entity.Has<Velocity>());
            Assert.False(entity.Has<Health>());
            Assert.False(entity.Has<Armor>());
            Assert.False(entity.Has<Damage>());
            Assert.False(entity.Has<Transform>());
            Assert.False(entity.Has<TestComponent>());
            Assert.False(entity.Has<AnotherComponent>());
            Assert.False(entity.Has<AnotherComponent2>());
            Assert.True(entity.Has<Position>());
        }

        [Fact]
        public void InvokeComponentWorldEvents_Arity1_ThroughAdd_FiresWorldEvent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            int calls = 0;
            scene.ComponentAdded += (go, id) => calls++;

            entity.Add(new Velocity {X = 3, Y = 4});

            Assert.Equal(1, calls);
        }

        [Fact]
        public void OnComponentAdded_ThenRemoveLastListener_EventNoLongerFires()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            int calls = 0;
            void Handler(GameObject _, ComponentId __) => calls++;

            entity.OnComponentAdded += Handler;
            entity.OnComponentAdded -= Handler;

            entity.Add(new Velocity {X = 3, Y = 4});

            Assert.Equal(0, calls);
        }

        [Fact]
        public void TryGet_WithType_OnEntityWithoutComponent_ReturnsFalse()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            bool found = entity.TryGet(typeof(Velocity), out object value);

            Assert.False(found);
            Assert.Null(value);
        }

        [Fact]
        public void TryGet_WithType_OnEntityWithComponent_ReturnsTrue()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            bool found = entity.TryGet(typeof(Position), out object value);

            Assert.True(found);
            Assert.IsType<Position>(value);
        }

        [Fact]
        public void Get_ByType_ReturnsBoxedComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 5, Y = 10});

            object boxed = entity.Get(typeof(Position));

            Assert.IsType<Position>(boxed);
            Assert.Equal(5, ((Position)boxed).X);
            Assert.Equal(10, ((Position)boxed).Y);
        }

        [Fact]
        public void AddAs_WithComponentId_WhenAllowStructualChanges_AddsComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.AddAs(Component<Velocity>.Id, new Velocity {X = 10, Y = 20});

            Assert.True(entity.Has<Velocity>());
            Assert.Equal(10, entity.Get<Velocity>().X);
        }

        [Fact]
        public void AddAs_WithType_WhenAllowStructualChanges_AddsComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.AddAs(typeof(Velocity), new Velocity {X = 15, Y = 25});

            Assert.True(entity.Has<Velocity>());
            Assert.Equal(15, entity.Get<Velocity>().X);
        }

        private sealed class CountingGenericAction : IGenericAction<GameObject>
        {
            public int CallCount { get; private set; }

            public void Invoke<T>(GameObject param, ref T type)
            {
                CallCount++;
            }
        }

        private sealed class CountingGenericActionPlain : IGenericAction
        {
            public int CallCount { get; private set; }

            public void Invoke<T>(ref T type)
            {
                CallCount++;
            }
        }
    }
}
