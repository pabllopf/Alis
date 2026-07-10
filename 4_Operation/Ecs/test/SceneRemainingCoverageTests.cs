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
    public class SceneRemainingCoverageTests
    {
        [Fact]
        public void Constructor_DefaultArchetype_NotNull()
        {
            using Scene scene = new Scene();
            Assert.NotNull(scene.DefaultArchetype);
        }

        [Fact]
        public void Constructor_DefaultWorldGameObject_SceneMatches()
        {
            using Scene scene = new Scene();
            Assert.Same(scene, scene.DefaultWorldGameObject.Scene);
        }

        [Fact]
        public void Constructor_WorldArchetypeTable_NonEmpty()
        {
            using Scene scene = new Scene();
            Assert.NotNull(scene.WorldArchetypeTable);
            Assert.True(scene.WorldArchetypeTable.Length > 0);
        }

        [Fact]
        public void Constructor_SharedCountdown_NotNull()
        {
            using Scene scene = new Scene();
            Assert.NotNull(scene.SharedCountdown);
        }

        [Fact]
        public void Dispose_DoesNotThrow()
        {
            Scene scene = new Scene();
            scene.Dispose();
        }

        [Fact]
        public void EntityCount_WithRecycledIds_ReflectsActiveCount()
        {
            using Scene scene = new Scene();
            GameObject go1 = scene.Create();
            GameObject go2 = scene.Create();
            GameObject go3 = scene.Create();
            Assert.Equal(3, scene.EntityCount);
            go1.Delete();
            Assert.Equal(2, scene.EntityCount);
            go2.Delete();
            Assert.Equal(1, scene.EntityCount);
            scene.Create();
            Assert.Equal(2, scene.EntityCount);
        }

        [Fact]
        public void EntityCreated_AddAndRemoveLastListener_ClearsFlag()
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

        [Fact]
        public void EntityDeleted_AddAndRemoveLastListener_ClearsFlag()
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

        [Fact]
        public void ComponentAdded_AddAndRemoveLastListener_ClearsFlag()
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

        [Fact]
        public void ComponentRemoved_AddAndRemoveLastListener_ClearsFlag()
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

        [Fact]
        public void Update_WithEnabledArchetypes_IteratesEnabled()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Velocity { X = 3, Y = 4 });
            scene.Update();
        }

        [Fact]
        public void UpdateGeneric_CacheMiss_CreatesAndThenHitsCache()
        {
            using Scene scene = new Scene();
            scene.Update<SceneRemainingTestUpdateAttribute>();
            scene.Update<SceneRemainingTestUpdateAttribute>();
        }

        [Fact]
        public void UpdateType_CacheMiss_CreatesAndThenHitsCache()
        {
            using Scene scene = new Scene();
            scene.Update(typeof(SceneRemainingTestUpdateAttribute));
            scene.Update(typeof(SceneRemainingTestUpdateAttribute));
        }

        [Fact]
        public void UpdateComponent_CacheMiss_CreatesAndThenHitsCache()
        {
            using Scene scene = new Scene();
            ComponentId id = Component.GetComponentId(typeof(Position));
            scene.UpdateComponent(id);
            scene.UpdateComponent(id);
        }

        [Fact]
        public void CustomQuery_FirstCall_CreatesAndCaches()
        {
            using Scene scene = new Scene();
            Rule rule = new With<Position>().Rule;
            Query q1 = scene.CustomQuery(rule);
            Query q2 = scene.CustomQuery(rule);
            Assert.Same(q1, q2);
        }

        [Fact]
        public void CustomQuery_MultipleRules_CachesCorrectly()
        {
            using Scene scene = new Scene();
            Rule r1 = new With<Position>().Rule;
            Rule r2 = new With<Velocity>().Rule;
            Query q = scene.CustomQuery(r1, r2);
            Assert.NotNull(q);
            Query qCached = scene.CustomQuery(r1, r2);
            Assert.Same(q, qCached);
        }

        [Fact]
        public void ArchetypeAdded_WhenArchetypeAlreadyExists_DoesNotDoublePush()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Position { X = 3, Y = 4 });
        }

        [Fact]
        public void CreateInDeferredState_SingleComponent()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(new Position { X = 10, Y = 20 });
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
            Assert.Equal(10, go.Get<Position>().X);
            Assert.Equal(20, go.Get<Position>().Y);
        }

        [Fact]
        public void CreateInDeferredState_TwoComponents()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(new Position { X = 1, Y = 2 }, new Health { Value = 100 });
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
            Assert.Equal(1, go.Get<Position>().X);
            Assert.Equal(100, go.Get<Health>().Value);
        }

        [Fact]
        public void CreateInDeferredState_ThreeComponents()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(new Position { X = 1, Y = 2 }, new Health { Value = 100 }, new Velocity { X = 3, Y = 4 });
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
            Assert.Equal(1, go.Get<Position>().X);
            Assert.Equal(3, go.Get<Velocity>().X);
        }

        [Fact]
        public void CreateInDeferredState_FourComponents()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(new Position(), new Health { Value = 10 }, new Velocity(), new Damage { Value = 50 });
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
            Assert.Equal(10, go.Get<Health>().Value);
            Assert.Equal(50, go.Get<Damage>().Value);
        }

        [Fact]
        public void CreateInDeferredState_FiveComponents()
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

        [Fact]
        public void CreateInDeferredState_SixComponents()
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

        [Fact]
        public void CreateInDeferredState_SevenComponents()
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

        [Fact]
        public void CreateInDeferredState_EightComponents()
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

        [Fact]
        public void CreateInDeferredState_ZeroComponents()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create();
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
        }

        [Fact]
        public void CreateMany_Single_WithEntityCreatedListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            ChunkTuple<Position> result = scene.CreateMany<Position>(3);
            Assert.Equal(3, callCount);
            Assert.Equal(3, result.Span.Length);
        }

        [Fact]
        public void CreateMany_TwoComponents_WithListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            ChunkTuple<Position, Health> result = scene.CreateMany<Position, Health>(2);
            Assert.Equal(2, callCount);
        }

        [Fact]
        public void CreateMany_ThreeComponents_WithListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            ChunkTuple<Position, Health, Velocity> result = scene.CreateMany<Position, Health, Velocity>(2);
            Assert.Equal(2, callCount);
        }

        [Fact]
        public void CreateMany_FourComponents_WithListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            ChunkTuple<Position, Health, Velocity, Damage> result = scene.CreateMany<Position, Health, Velocity, Damage>(2);
            Assert.Equal(2, callCount);
        }

        [Fact]
        public void CreateMany_FiveComponents_WithListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            ChunkTuple<Position, Health, Velocity, Damage, Armor> result = scene.CreateMany<Position, Health, Velocity, Damage, Armor>(2);
            Assert.Equal(2, callCount);
        }

        [Fact]
        public void CreateMany_SixComponents_WithListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            ChunkTuple<Position, Health, Velocity, Damage, Armor, Transform> result =
                scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform>(2);
            Assert.Equal(2, callCount);
        }

        [Fact]
        public void CreateMany_SevenComponents_WithListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            ChunkTuple<Position, Health, Velocity, Damage, Armor, Transform, TestComponent> result =
                scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform, TestComponent>(2);
            Assert.Equal(2, callCount);
        }

        [Fact]
        public void CreateMany_EightComponents_WithListener_FiresEvents()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            ChunkTuple<Position, Health, Velocity, Damage, Armor, Transform, TestComponent, AnotherComponent> result =
                scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform, TestComponent, AnotherComponent>(2);
            Assert.Equal(2, callCount);
        }

        [Fact]
        public void CreateMany_ZeroCount_ThrowsArgumentOutOfRange()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position>(0));
        }

        [Fact]
        public void CreateMany_TwoComponents_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health>(0));
        }

        [Fact]
        public void CreateMany_ThreeComponents_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health, Velocity>(0));
        }

        [Fact]
        public void CreateMany_FourComponents_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health, Velocity, Damage>(0));
        }

        [Fact]
        public void CreateMany_FiveComponents_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Health, Velocity, Damage, Armor>(0));
        }

        [Fact]
        public void CreateMany_SixComponents_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform>(0));
        }

        [Fact]
        public void CreateMany_SevenComponents_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform, TestComponent>(0));
        }

        [Fact]
        public void CreateMany_EightComponents_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform, TestComponent, AnotherComponent>(0));
        }

        [Fact]
        public void EnsureCapacity_NegativeCount_DoesNothing()
        {
            using Scene scene = new Scene();
            scene.EnsureCapacity(default, 0);
            scene.EnsureCapacity(default, -1);
        }

        [Fact]
        public void EnsureCapacityCore_PositiveCount_Works()
        {
            using Scene scene = new Scene();
            scene.EnsureCapacityCore(scene.DefaultArchetype, 5);
        }

        [Fact]
        public void EnsureCapacityCore_ZeroCount_Throws()
        {
            using Scene scene = new Scene();
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.EnsureCapacityCore(scene.DefaultArchetype, 0));
        }

        [Fact]
        public void CreateFromObjects_WithListener_FiresEvent()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            scene.CreateFromObjects(new object[] { new Position { X = 1, Y = 2 } });
            Assert.Equal(1, callCount);
        }

        [Fact]
        public void CreateFromObjects_MultipleComponents_FiresEventOnce()
        {
            using Scene scene = new Scene();
            int callCount = 0;
            scene.EntityCreated += _ => callCount++;
            scene.CreateFromObjects(new object[] { new Position { X = 1, Y = 2 }, new Health { Value = 100 } });
            Assert.Equal(1, callCount);
        }

        [Fact]
        public void CreateEntityWithoutEvent_DoesNotFireListener()
        {
            using Scene scene = new Scene();
            bool fired = false;
            scene.EntityCreated += _ => fired = true;
            scene.CreateEntityWithoutEvent();
            Assert.False(fired);
        }

        [Fact]
        public void InvokeEntityCreated_WithListener_Fires()
        {
            using Scene scene = new Scene();
            bool fired = false;
            scene.EntityCreated += _ => fired = true;
            GameObject go = scene.CreateEntityWithoutEvent();
            Assert.False(fired);
            scene.InvokeEntityCreated(go);
            Assert.True(fired);
        }

        [Fact]
        public void EntityCreated_RemoveLastListener_ClearsWorldEventFlags()
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

        [Fact]
        public void ExitDisallowState_WithFilterAndUpdateDeferred_ResolvesCreations()
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

        [Fact]
        public void ExitDisallowState_WithNullFilterAndUpdateDeferred_ResolvesCreations()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(new Position { X = 7, Y = 14 });
            scene.ExitDisallowState(null, true);
            Assert.True(go.IsAlive);
            Assert.Equal(7, go.Get<Position>().X);
        }

        [Fact]
        public void ExitDisallowState_WithDeferredEntitiesNoUpdate_ResolvesSimple()
        {
            using Scene scene = new Scene();
            scene.EnterDisallowState();
            GameObject go = scene.Create(new Position { X = 3, Y = 6 });
            scene.ExitDisallowState(null, false);
            Assert.True(go.IsAlive);
            Assert.Equal(3, go.Get<Position>().X);
        }

        [Fact]
        public void Constructor_UniqueIdsAcrossInstances()
        {
            using Scene s1 = new Scene();
            using Scene s2 = new Scene();
            Assert.NotEqual(s1.Id, s2.Id);
        }

        [Fact]
        public void Query_AfterArchetypeAdded_ReturnsNewEntities()
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

        [Fact]
        public void CreateMany_TwoComponents_WithoutListener_DoesNotThrow()
        {
            using Scene scene = new Scene();
            ChunkTuple<Position, Health> result = scene.CreateMany<Position, Health>(2);
            Assert.Equal(2, result.Span1.Length);
            Assert.Equal(2, result.Span2.Length);
        }

        [Fact]
        public void CreateMany_ThreeComponents_WithoutListener_DoesNotThrow()
        {
            using Scene scene = new Scene();
            ChunkTuple<Position, Health, Velocity> result = scene.CreateMany<Position, Health, Velocity>(2);
            Assert.Equal(2, result.Span1.Length);
        }

        [Fact]
        public void CreateMany_FourComponents_WithoutListener_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.CreateMany<Position, Health, Velocity, Damage>(2);
        }

        [Fact]
        public void CreateMany_FiveComponents_WithoutListener_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.CreateMany<Position, Health, Velocity, Damage, Armor>(2);
        }

        [Fact]
        public void CreateMany_SixComponents_WithoutListener_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform>(2);
        }

        [Fact]
        public void CreateMany_SevenComponents_WithoutListener_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform, TestComponent>(2);
        }

        [Fact]
        public void CreateMany_EightComponents_WithoutListener_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.CreateMany<Position, Health, Velocity, Damage, Armor, Transform, TestComponent, AnotherComponent>(2);
        }

        [Fact]
        public void Update_Generic_WithEntitiesHavingAttribute_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            scene.Create(new Velocity { X = 3, Y = 4 });
            scene.Update<SceneRemainingTestUpdateAttribute>();
        }

        [Fact]
        public void ArchetypeAdded_WithExistingQueryCache_AttachesToQuery()
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

        [Fact]
        public void Scene_UpdateArchetypeTable_WithSameSize()
        {
            using Scene scene = new Scene();
            int size = scene.WorldArchetypeTable.Length;
            scene.UpdateArchetypeTable(size);
            Assert.Equal(size, scene.WorldArchetypeTable.Length);
        }
    }

    internal sealed class SceneRemainingTestUpdateAttribute : UpdateTypeAttribute;

    internal sealed class TestComponentUpdateFilter : IComponentUpdateFilter
    {
        public bool Called { get; private set; }

        public void UpdateSubset(ReadOnlySpan<ArchetypeDeferredUpdateRecord> archetypes)
        {
            Called = true;
        }
    }
}
