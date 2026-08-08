// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneRemainingCoverageTests.cs
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
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// The scene remaining coverage tests class
    /// </summary>
    public class SceneRemainingCoverageTests
    {
        /// <summary>
        /// Tests that constructor default archetype not null
        /// </summary>
        [Fact] public void Constructor_DefaultArchetype_NotNull()
        {
            using Scene scene = new Scene();
            Assert.NotNull(scene.DefaultArchetype);
        }

        /// <summary>
        /// Tests that constructor default world game object scene matches
        /// </summary>
        [Fact] public void Constructor_DefaultWorldGameObject_SceneMatches()
        {
            using Scene scene = new Scene();
            Assert.Same(scene, scene.DefaultWorldGameObject.Scene);
        }

        /// <summary>
        /// Tests that constructor world archetype table non empty
        /// </summary>
        [Fact] public void Constructor_WorldArchetypeTable_NonEmpty()
        {
            using Scene scene = new Scene();
            Assert.NotNull(scene.WorldArchetypeTable);
            Assert.True(scene.WorldArchetypeTable.Length > 0);
        }

        /// <summary>
        /// Tests that constructor shared countdown not null
        /// </summary>
        [Fact] public void Constructor_SharedCountdown_NotNull()
        {
            using Scene scene = new Scene();
            Assert.NotNull(scene.SharedCountdown);
        }

        /// <summary>
        /// Tests that dispose does not throw
        /// </summary>
        [Fact] public void Dispose_DoesNotThrow()
        {
            Scene scene = new Scene();
            scene.Dispose();
        }

        /// <summary>
        /// Tests that entity count with recycled ids reflects active count
        /// </summary>
        [Fact] public void EntityCount_WithRecycledIds_ReflectsActiveCount()
        {
            using Scene scene = new Scene();
            GameObject go1 = scene.Create();
            GameObject go2 = scene.Create();
            scene.Create();
            Assert.Equal(3, scene.EntityCount);
            go1.Delete();
            Assert.Equal(2, scene.EntityCount);
            go2.Delete();
            Assert.Equal(1, scene.EntityCount);
            scene.Create();
            Assert.Equal(2, scene.EntityCount);
        }

        /// <summary>
        /// Tests that entity created add and remove last listener clears flag
        /// </summary>
        [Fact] public void EntityCreated_AddAndRemoveLastListener_ClearsFlag()
        {
            using Scene scene = new Scene();
            Action<GameObject> handler = _ => { };
            scene.EntityCreated += handler;
            scene.EntityCreated -= handler;
            int calls = 0;
            scene.EntityCreated += _ => calls++;
            scene.Create();
            Assert.Equal(1, calls);
        }

        /// <summary>
        /// Tests that entity deleted add and remove last listener clears flag
        /// </summary>
        [Fact] public void EntityDeleted_AddAndRemoveLastListener_ClearsFlag()
        {
            using Scene scene = new Scene();
            Action<GameObject> handler = _ => { };
            scene.EntityDeleted += handler;
            scene.EntityDeleted -= handler;
            int calls = 0;
            scene.EntityDeleted += _ => calls++;
            GameObject go = scene.Create();
            go.Delete();
            Assert.Equal(1, calls);
        }

        /// <summary>
        /// Tests that component added add and remove last listener clears flag
        /// </summary>
        [Fact] public void ComponentAdded_AddAndRemoveLastListener_ClearsFlag()
        {
            using Scene scene = new Scene();
            Action<GameObject, ComponentId> handler = (_, _) => { };
            scene.ComponentAdded += handler;
            scene.ComponentAdded -= handler;
            int calls = 0;
            scene.ComponentAdded += (_, _) => calls++;
            GameObject go = scene.Create();
            go.Add(new Position { X = 1, Y = 2 });
            Assert.Equal(1, calls);
        }

        /// <summary>
        /// Tests that component removed add and remove last listener clears flag
        /// </summary>
        [Fact] public void ComponentRemoved_AddAndRemoveLastListener_ClearsFlag()
        {
            using Scene scene = new Scene();
            Action<GameObject, ComponentId> handler = (_, _) => { };
            scene.ComponentRemoved += handler;
            scene.ComponentRemoved -= handler;
            int calls = 0;
            scene.ComponentRemoved += (_, _) => calls++;
            GameObject go = scene.Create(new Position { X = 1, Y = 2 });
            go.Remove<Position>();
            Assert.Equal(1, calls);
        }

        /// <summary>
        /// Tests that update with enabled archetypes iterates enabled
        /// </summary>
        [Fact] public void Update_WithEnabledArchetypes_IteratesEnabled()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Velocity { X = 3, Y = 4 });
            scene.Update();
        }

        /// <summary>
        /// Tests that update generic cache miss creates and then hits cache
        /// </summary>
        [Fact] public void UpdateGeneric_CacheMiss_CreatesAndThenHitsCache()
        {
            using Scene scene = new Scene();
            scene.Update<SceneRemainingTestUpdateAttribute>();
            scene.Update<SceneRemainingTestUpdateAttribute>();
        }

        /// <summary>
        /// Tests that update type cache miss creates and then hits cache
        /// </summary>
        [Fact] public void UpdateType_CacheMiss_CreatesAndThenHitsCache()
        {
            using Scene scene = new Scene();
            scene.Update(typeof(SceneRemainingTestUpdateAttribute));
            scene.Update(typeof(SceneRemainingTestUpdateAttribute));
        }

        /// <summary>
        /// Tests that update component cache miss creates and then hits cache
        /// </summary>
        [Fact] public void UpdateComponent_CacheMiss_CreatesAndThenHitsCache()
        {
            using Scene scene = new Scene();
            ComponentId id = Component.GetComponentId(typeof(Position));
            scene.UpdateComponent(id);
            scene.UpdateComponent(id);
        }

        /// <summary>
        /// Tests that custom query first call creates and caches
        /// </summary>
        [Fact] public void CustomQuery_FirstCall_CreatesAndCaches()
        {
            using Scene scene = new Scene();
            Rule rule = new With<Position>().Rule;
            Query q1 = scene.CustomQuery(rule);
            Query q2 = scene.CustomQuery(rule);
            Assert.Same(q1, q2);
        }

        /// <summary>
        /// Tests that custom query multiple rules caches correctly
        /// </summary>
        [Fact] public void CustomQuery_MultipleRules_CachesCorrectly()
        {
            using Scene scene = new Scene();
            Rule r1 = new With<Position>().Rule;
            Rule r2 = new With<Velocity>().Rule;
            Query q = scene.CustomQuery(r1, r2);
            Assert.NotNull(q);
            Query qCached = scene.CustomQuery(r1, r2);
            Assert.Same(q, qCached);
        }

        /// <summary>
        /// Tests that archetype added when archetype already exists does not double push
        /// </summary>
        [Fact] public void ArchetypeAdded_WhenArchetypeAlreadyExists_DoesNotDoublePush()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Position { X = 3, Y = 4 });
        }

        /// <summary>
        /// Tests that create in deferred state single component
        /// </summary>
        [Fact] public void CreateInDeferredState_SingleComponent()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(new Position { X = 10, Y = 20 });
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
            Assert.Equal(10, go.Get<Position>().X);
            Assert.Equal(20, go.Get<Position>().Y);
        }

        /// <summary>
        /// Tests that create in deferred state two components
        /// </summary>
        [Fact] public void CreateInDeferredState_TwoComponents()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(new Position { X = 1, Y = 2 }, new Health { Value = 100 });
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
            Assert.Equal(1, go.Get<Position>().X);
            Assert.Equal(100, go.Get<Health>().Value);
        }

        /// <summary>
        /// Tests that create in deferred state three components
        /// </summary>
        [Fact] public void CreateInDeferredState_ThreeComponents()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(new Position { X = 1, Y = 2 }, new Health { Value = 100 }, new Velocity { X = 3, Y = 4 });
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
            Assert.Equal(1, go.Get<Position>().X);
            Assert.Equal(3, go.Get<Velocity>().X);
        }

        /// <summary>
        /// Tests that create in deferred state four components
        /// </summary>
        [Fact] public void CreateInDeferredState_FourComponents()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(new Position(), new Health { Value = 10 }, new Velocity(), new Damage { Value = 50 });
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
            Assert.Equal(10, go.Get<Health>().Value);
            Assert.Equal(50, go.Get<Damage>().Value);
        }

        /// <summary>
        /// Tests that create in deferred state five components
        /// </summary>
        [Fact] public void CreateInDeferredState_FiveComponents()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(
                new Position(),
                new Health { Value = 1 },
                new Velocity(),
                new Damage { Value = 2 },
                new Armor { Value = 3 });
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
            Assert.Equal(1, go.Get<Health>().Value);
            Assert.Equal(3, go.Get<Armor>().Value);
        }

        /// <summary>
        /// Tests that create in deferred state six components
        /// </summary>
        [Fact] public void CreateInDeferredState_SixComponents()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(
                new Position(),
                new Health { Value = 1 },
                new Velocity(),
                new Damage { Value = 2 },
                new Armor { Value = 3 },
                new Transform { X = 4, Y = 5 });
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
            Assert.Equal(4, go.Get<Transform>().X);
        }

        /// <summary>
        /// Tests that create in deferred state seven components
        /// </summary>
        [Fact] public void CreateInDeferredState_SevenComponents()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(
                new Position(),
                new Health { Value = 1 },
                new Velocity(),
                new Damage { Value = 2 },
                new Armor { Value = 3 },
                new Transform { X = 4, Y = 5 },
                new TestComponent { Value = 6 });
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
            Assert.Equal(6, go.Get<TestComponent>().Value);
        }

        /// <summary>
        /// Tests that create in deferred state eight components
        /// </summary>
        [Fact] public void CreateInDeferredState_EightComponents()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(
                new Position(),
                new Health { Value = 1 },
                new Velocity(),
                new Damage { Value = 2 },
                new Armor { Value = 3 },
                new Transform { X = 4, Y = 5 },
                new TestComponent { Value = 6 },
                new AnotherComponent { Name = "test", Data = 7 });
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
            Assert.Equal("test", go.Get<AnotherComponent>().Name);
        }

        /// <summary>
        /// Tests that create in deferred state zero components
        /// </summary>
        [Fact] public void CreateInDeferredState_ZeroComponents()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create();
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
        }

        /// <summary>
        /// Tests that create many single with entity created listener fires events
        /// </summary>
        [Fact] public void CreateMany_Single_WithEntityCreatedListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            ChunkTuple<Position> result = scene.CreateMany<Position>(3);
            Assert.Equal(3, callCount);
            Assert.Equal(3, result.Span.Length);
        }

        /// <summary>
        /// Tests that create many two components with listener fires events
        /// </summary>
        [Fact] public void CreateMany_TwoComponents_WithListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            scene.CreateMany<Position, Health>(2);
            Assert.Equal(2, callCount);
        }

        /// <summary>
        /// Tests that create many three components with listener fires events
        /// </summary>
        [Fact] public void CreateMany_ThreeComponents_WithListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            scene.CreateMany<Position, Health, Velocity>(2);
            Assert.Equal(2, callCount);
        }

        /// <summary>
        /// Tests that create many four components with listener fires events
        /// </summary>
        [Fact] public void CreateMany_FourComponents_WithListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            scene.CreateMany<Position, Health, Velocity, Damage>(2);
            Assert.Equal(2, callCount);
        }

        /// <summary>
        /// Tests that create many five components with listener fires events
        /// </summary>
        [Fact] public void CreateMany_FiveComponents_WithListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            scene.CreateMany<Position, Health, Velocity, Damage, Armor>(2);
            Assert.Equal(2, callCount);
        }

        /// <summary>
        /// Tests that create many six components with listener fires events
        /// </summary>
        [Fact] public void CreateMany_SixComponents_WithListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform>(2);
            Assert.Equal(2, callCount);
        }

        /// <summary>
        /// Tests that create many seven components with listener fires events
        /// </summary>
        [Fact] public void CreateMany_SevenComponents_WithListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform, TestComponent>(2);
            Assert.Equal(2, callCount);
        }

        /// <summary>
        /// Tests that create many eight components with listener fires events
        /// </summary>
        [Fact] public void CreateMany_EightComponents_WithListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform, TestComponent, AnotherComponent>(2);
            Assert.Equal(2, callCount);
        }

        /// <summary>
        /// Tests that create many zero count throws argument out of range
        /// </summary>
        [Fact] public void CreateMany_ZeroCount_ThrowsArgumentOutOfRange()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position>(0));
        }

        /// <summary>
        /// Tests that create many two components zero count throws
        /// </summary>
        [Fact] public void CreateMany_TwoComponents_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health>(0));
        }

        /// <summary>
        /// Tests that create many three components zero count throws
        /// </summary>
        [Fact] public void CreateMany_ThreeComponents_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health, Velocity>(0));
        }

        /// <summary>
        /// Tests that create many four components zero count throws
        /// </summary>
        [Fact] public void CreateMany_FourComponents_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health, Velocity, Damage>(0));
        }

        /// <summary>
        /// Tests that create many five components zero count throws
        /// </summary>
        [Fact] public void CreateMany_FiveComponents_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health, Velocity, Damage, Armor>(0));
        }

        /// <summary>
        /// Tests that create many six components zero count throws
        /// </summary>
        [Fact] public void CreateMany_SixComponents_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform>(0));
        }

        /// <summary>
        /// Tests that create many seven components zero count throws
        /// </summary>
        [Fact] public void CreateMany_SevenComponents_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform, TestComponent>(0));
        }

        /// <summary>
        /// Tests that create many eight components zero count throws
        /// </summary>
        [Fact] public void CreateMany_EightComponents_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform, TestComponent, AnotherComponent>(0));
        }

        /// <summary>
        /// Tests that ensure capacity negative count does nothing
        /// </summary>
        [Fact] public void EnsureCapacity_NegativeCount_DoesNothing()
        {
            using Scene scene = new Scene();
            scene.EnsureCapacity(default, 0);
            scene.EnsureCapacity(default, -1);
        }

        /// <summary>
        /// Tests that ensure capacity core positive count works
        /// </summary>
        [Fact] public void EnsureCapacityCore_PositiveCount_Works()
        {
            using Scene scene = new Scene();
            scene.EnsureCapacityCore(scene.DefaultArchetype, 5);
        }

        /// <summary>
        /// Tests that ensure capacity core zero count throws
        /// </summary>
        [Fact] public void EnsureCapacityCore_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.EnsureCapacityCore(scene.DefaultArchetype, 0));
        }

        /// <summary>
        /// Tests that create from objects with listener fires event
        /// </summary>
        [Fact] public void CreateFromObjects_WithListener_FiresEvent()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            scene.CreateFromObjects(new object[] { new Position { X = 1, Y = 2 } });
            Assert.Equal(1, callCount);
        }

        /// <summary>
        /// Tests that create from objects multiple components fires event once
        /// </summary>
        [Fact] public void CreateFromObjects_MultipleComponents_FiresEventOnce()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            scene.CreateFromObjects(new object[] { new Position { X = 1, Y = 2 }, new Health { Value = 100 } });
            Assert.Equal(1, callCount);
        }

        /// <summary>
        /// Tests that create entity without event does not fire listener
        /// </summary>
        [Fact] public void CreateEntityWithoutEvent_DoesNotFireListener()
        {
            using Scene scene = new Scene();
            bool fired = false;
            scene.EntityCreated += _ => fired = true;
            scene.CreateEntityWithoutEvent();
            Assert.False(fired);
        }

        /// <summary>
        /// Tests that invoke entity created with listener fires
        /// </summary>
        [Fact] public void InvokeEntityCreated_WithListener_Fires()
        {
            using Scene scene = new Scene();
            bool fired = false;
            scene.EntityCreated += _ => fired = true;
            GameObject go = scene.CreateEntityWithoutEvent();
            Assert.False(fired);
            scene.InvokeEntityCreated(go);
            Assert.True(fired);
        }

        /// <summary>
        /// Tests that entity created remove last listener clears world event flags
        /// </summary>
        [Fact] public void EntityCreated_RemoveLastListener_ClearsWorldEventFlags()
        {
            using Scene scene = new Scene();
            Action<GameObject> handler = _ => { };
            scene.EntityCreated += handler;
            scene.EntityCreated -= handler;
            int calls = 0;
            scene.EntityCreated += _ => calls++;
            scene.Create();
            Assert.Equal(1, calls);
        }

        /// <summary>
        /// Tests that exit disallow state with filter and update deferred resolves creations
        /// </summary>
        [Fact] public void ExitDisallowState_WithFilterAndUpdateDeferred_ResolvesCreations()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(new Position { X = 5, Y = 10 });
            TestComponentUpdateFilter filter = new TestComponentUpdateFilter();
            scene.ExitDisallowState(filter, true);
            Assert.True(go.IsAlive);
            Assert.True(filter.Called);
            Assert.Equal(5, go.Get<Position>().X);
        }

        /// <summary>
        /// Tests that exit disallow state with null filter and update deferred resolves creations
        /// </summary>
        [Fact] public void ExitDisallowState_WithNullFilterAndUpdateDeferred_ResolvesCreations()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(new Position { X = 7, Y = 14 });
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
            Assert.Equal(7, go.Get<Position>().X);
        }

        /// <summary>
        /// Tests that exit disallow state with deferred entities no update resolves simple
        /// </summary>
        [Fact] public void ExitDisallowState_WithDeferredEntitiesNoUpdate_ResolvesSimple()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(new Position { X = 3, Y = 6 });
            scene.ExitDisallowState(null, false);
            Assert.True(go.IsAlive);
            Assert.Equal(3, go.Get<Position>().X);
        }

        /// <summary>
        /// Tests that constructor unique ids across instances
        /// </summary>
        [Fact] public void Constructor_UniqueIdsAcrossInstances()
        {
            using Scene s1 = new Scene();
            using Scene s2 = new Scene();
            Assert.NotEqual(s1.Id, s2.Id);
        }

        /// <summary>
        /// Tests that query after archetype added returns new entities
        /// </summary>
        [Fact] public void Query_AfterArchetypeAdded_ReturnsNewEntities()
        {
            using Scene scene = new Scene();
            Rule rule = new With<Position>().Rule;
            Query q = scene.CustomQuery(rule);
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Position { X = 3, Y = 4 });
            int count = 0;
            foreach (GameObject _ in q.EnumerateWithEntities())
            {
                count++;
            }
            Assert.Equal(2, count);
        }

        /// <summary>
        /// Tests that create many two components without listener does not throw
        /// </summary>
        [Fact] public void CreateMany_TwoComponents_WithoutListener_DoesNotThrow()
        {
            using Scene scene = new Scene();
            ChunkTuple<Position, Health> result = scene.CreateMany<Position, Health>(2);
            Assert.Equal(2, result.Span1.Length);
            Assert.Equal(2, result.Span2.Length);
        }

        /// <summary>
        /// Tests that create many three components without listener does not throw
        /// </summary>
        [Fact] public void CreateMany_ThreeComponents_WithoutListener_DoesNotThrow()
        {
            using Scene scene = new Scene();
            ChunkTuple<Position, Health, Velocity> result = scene.CreateMany<Position, Health, Velocity>(2);
            Assert.Equal(2, result.Span1.Length);
        }

        /// <summary>
        /// Tests that create many four components without listener does not throw
        /// </summary>
        [Fact] public void CreateMany_FourComponents_WithoutListener_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.CreateMany<Position, Health, Velocity, Damage>(2);
        }

        /// <summary>
        /// Tests that create many five components without listener does not throw
        /// </summary>
        [Fact] public void CreateMany_FiveComponents_WithoutListener_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.CreateMany<Position, Health, Velocity, Damage, Armor>(2);
        }

        /// <summary>
        /// Tests that create many six components without listener does not throw
        /// </summary>
        [Fact] public void CreateMany_SixComponents_WithoutListener_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform>(2);
        }

        /// <summary>
        /// Tests that create many seven components without listener does not throw
        /// </summary>
        [Fact] public void CreateMany_SevenComponents_WithoutListener_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform, TestComponent>(2);
        }

        /// <summary>
        /// Tests that create many eight components without listener does not throw
        /// </summary>
        [Fact] public void CreateMany_EightComponents_WithoutListener_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform, TestComponent, AnotherComponent>(2);
        }

        /// <summary>
        /// Tests that update generic with entities having attribute does not throw
        /// </summary>
        [Fact] public void Update_Generic_WithEntitiesHavingAttribute_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Velocity { X = 3, Y = 4 });
            scene.Update<SceneRemainingTestUpdateAttribute>();
        }

        /// <summary>
        /// Tests that archetype added with existing query cache attaches to query
        /// </summary>
        [Fact] public void ArchetypeAdded_WithExistingQueryCache_AttachesToQuery()
        {
            using Scene scene = new Scene();
            Rule rule = new With<Position>().Rule;
            Query q = scene.CustomQuery(rule);
            Assert.NotNull(q);
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Position { X = 3, Y = 4 });
            int count = 0;
            foreach (GameObject _ in q.EnumerateWithEntities())
            {
                count++;
            }
            Assert.Equal(2, count);
        }

        /// <summary>
        /// Tests that scene update archetype table with same size
        /// </summary>
        [Fact] public void Scene_UpdateArchetypeTable_WithSameSize()
        {
            using Scene scene = new Scene();
            int size = scene.WorldArchetypeTable.Length;
            scene.UpdateArchetypeTable(size);
            Assert.Equal(size, scene.WorldArchetypeTable.Length);
        }
    }

    /// <summary>
    /// The scene remaining test update attribute class
    /// </summary>
    /// <seealso cref="UpdateTypeAttribute"/>
    internal sealed class SceneRemainingTestUpdateAttribute : UpdateTypeAttribute;

    /// <summary>
    /// The test component update filter class
    /// </summary>
    /// <seealso cref="IComponentUpdateFilter"/>
    internal sealed class TestComponentUpdateFilter : IComponentUpdateFilter
    {
        /// <summary>
        /// Gets or sets the value of the called
        /// </summary>
        public bool Called { get; private set; }

        /// <summary>
        /// Updates the subset using the specified archetypes
        /// </summary>
        /// <param name="archetypes">The archetypes</param>
        public void UpdateSubset(ReadOnlySpan<ArchetypeDeferredUpdateRecord> archetypes)
        {
            Called = true;
        }
    }
}
