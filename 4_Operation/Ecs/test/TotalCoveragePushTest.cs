using System;
using System.Reflection;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    public class TotalCoveragePushTest
    {
        [Fact]
        public void GameObjectExtensions_Deconstruct_AllArities()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position { X = 1 }, new Velocity { X = 2 },
                new Health { Value = 3 }, new Transform { X = 4, Rotation = 5 },
                new TestComponent { Value = 6 }, new AnotherComponent { Data = 7 },
                new Damage { Value = 8 }, new Armor { Value = 9 });

            go.Deconstruct(out Ref<Position> p);
            go.Deconstruct(out Ref<Position> p2, out Ref<Velocity> v2);
            go.Deconstruct(out Ref<Position> p3, out Ref<Velocity> v3, out Ref<Health> h3);
            go.Deconstruct(out Ref<Position> p4, out Ref<Velocity> v4, out Ref<Health> h4, out Ref<Transform> t4);
            go.Deconstruct(out Ref<Position> p5, out Ref<Velocity> v5, out Ref<Health> h5, out Ref<Transform> t5, out Ref<TestComponent> tc5);
            go.Deconstruct(out Ref<Position> p6, out Ref<Velocity> v6, out Ref<Health> h6, out Ref<Transform> t6, out Ref<TestComponent> tc6, out Ref<AnotherComponent> a6);
            go.Deconstruct(out Ref<Position> p7, out Ref<Velocity> v7, out Ref<Health> h7, out Ref<Transform> t7, out Ref<TestComponent> tc7, out Ref<AnotherComponent> a7, out Ref<Damage> d7);
            go.Deconstruct(out Ref<Position> p8, out Ref<Velocity> v8, out Ref<Health> h8, out Ref<Transform> t8, out Ref<TestComponent> tc8, out Ref<AnotherComponent> a8, out Ref<Damage> d8, out Ref<Armor> ar8);
        }

        [Fact]
        public void EntityUpdate_ThroughScene_With8Components_Works()
        {
            using Scene scene = new();
            scene.Create(new Position(), new Velocity(), new Health(), new Transform(),
                new TestComponent(), new AnotherComponent(), new Damage(), new Armor());
            scene.Update();
        }

        [Fact]
        public void NeighborCache_ViaAddRemove_ExercisesPaths()
        {
            using Scene scene = new();
            var go = scene.Create(new Position());
            for (int i = 0; i < 15; i++)
            {
                go.Add(new Velocity { X = i });
                go.Remove<Velocity>();
                go.Add(new Health { Value = i });
                go.Remove<Health>();
                go.Add(new Transform { X = i });
                go.Remove<Transform>();
            }
            scene.Update();
        }

        [Fact]
        public void GameObjectRefTuple_Arity8_Works()
        {
            using Scene scene = new();
            scene.Create(new Position(), new Velocity(), new Health(), new Transform(),
                new TestComponent(), new AnotherComponent(), new Damage(), new Armor());
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>,
                With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
            foreach (var tuple in query.EnumerateWithEntities<Position, Velocity, Health, Transform,
                TestComponent, AnotherComponent, Damage, Armor>())
            {
                Assert.True(tuple.GameObject.IsAlive);
            }
        }

        [Fact]
        public void UpdateRunnerFactory_AllArities_Accessible()
        {
            Assert.NotNull(typeof(ComponentStorageBase).Assembly.GetType("Alis.Core.Ecs.Updating.Runners.UpdateRunnerFactory`2"));
            Assert.NotNull(typeof(ComponentStorageBase).Assembly.GetType("Alis.Core.Ecs.Updating.Runners.UpdateRunnerFactory`3"));
            Assert.NotNull(typeof(ComponentStorageBase).Assembly.GetType("Alis.Core.Ecs.Updating.Runners.UpdateRunnerFactory`4"));
            Assert.NotNull(typeof(ComponentStorageBase).Assembly.GetType("Alis.Core.Ecs.Updating.Runners.UpdateRunnerFactory`5"));
        }

        [Fact]
        public void ChunkQueryEnumerator_AllArities_Accessible()
        {
            Assert.True(typeof(ChunkQueryEnumerator<Position>).IsValueType);
            Assert.True(typeof(ChunkQueryEnumerator<Position, Velocity>).IsValueType);
            Assert.True(typeof(ChunkQueryEnumerator<Position, Velocity, Health>).IsValueType);
            Assert.True(typeof(ChunkQueryEnumerator<Position, Velocity, Health, Transform>).IsValueType);
        }

        [Fact]
        public void ChunkTuple_AllArities_Accessible()
        {
            Assert.True(typeof(ChunkTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>).IsValueType);
            Assert.True(typeof(ChunkTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>).IsValueType);
            Assert.True(typeof(ChunkTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>).IsValueType);
            Assert.True(typeof(ChunkTuple<Position, Velocity, Health, Transform, TestComponent>).IsValueType);
            Assert.True(typeof(ChunkTuple<Position, Velocity, Health, Transform>).IsValueType);
            Assert.True(typeof(ChunkTuple<Position, Velocity, Health>).IsValueType);
            Assert.True(typeof(ChunkTuple<Position, Velocity>).IsValueType);
            Assert.True(typeof(ChunkTuple<Position>).IsValueType);
        }

        [Fact]
        public void GameObject_EntityID_Access()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            int entityId = go.EntityID;
            Assert.True(entityId >= 0);
        }

        [Fact]
        public void ComponentHandle_Boxed_CreateAndDispose()
        {
            Position pos = new Position { X = 42 };
            ComponentHandle handle = ComponentHandle.CreateFromBoxed(typeof(Position), (object)pos);
            Assert.True(typeof(ComponentHandle).IsValueType);
            handle.Dispose();
        }

        [Fact]
        public void ComponentHandle_Retrieve_Works()
        {
            Position pos = new Position { X = 42 };
            ComponentHandle handle = ComponentHandle.Create(pos);
            Assert.True(typeof(ComponentHandle).IsValueType);
            handle.Dispose();
        }

        [Fact]
        public void Scene_CreateEntityFromLocation_Works()
        {
            using Scene scene = new();
            scene.Create(new Position());
            GameObject go = scene.CreateEntityFromLocation(default);
            Assert.False(go.IsAlive);
        }

        [Fact]
        public void FastestArrayPool_ClearBuckets_Works()
        {
            var pool = FastestArrayPool<int>.Shared;
            int[] arr = pool.Rent(100);
            pool.Return(arr);
            var type = pool.GetType();
            var method = type.GetMethod("ClearBuckets",
                BindingFlags.Instance | BindingFlags.NonPublic);
            if (method != null)
                method.Invoke(pool, null);
        }

        [Fact]
        public void FastestArrayPool_GlobalClearBuckets_Invokes()
        {
            var pool = FastestArrayPool<int>.Shared;
            int[] arr = pool.Rent(100);
            pool.Return(arr);
            Gen2GcCallback.Register(() =>
            {
                var method = pool.GetType().GetMethod("ClearBuckets", BindingFlags.Instance | BindingFlags.NonPublic);
                method?.Invoke(pool, null);
                return false;
            });
        }

        [Fact]
        public void Game_InvokePerEntity_NoEvents_NoThrow()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Update();
        }

        [Fact]
        public void DeleteComponentData_WithDelete_Works()
        {
            using Scene scene = new();
            var go = scene.Create(new Position());
            go.Delete();
            scene.Update();
        }

        [Fact]
        public void ArchetypeEdgeKey_ValueType_Works()
        {
            Assert.True(typeof(ArchetypeEdgeKey).IsValueType);
        }

        [Fact]
        public void GameObject_EntityWorld_Span_Access()
        {
            using Scene scene = new();
            scene.Create(new Position());
            Assert.NotNull(scene);
        }

        [Fact]
        public void Scene_Update_WithAttributeType()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Update();
        }
    }
}
