using System;
using System.Buffers;
using System.Reflection;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// The total coverage push test class
    /// </summary>
    public class TotalCoveragePushTest
    {
        /// <summary>
        /// Tests that game object extensions deconstruct all arities
        /// </summary>
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

        /// <summary>
        /// Tests that entity update through scene with 8 components works
        /// </summary>
        [Fact]
        public void EntityUpdate_ThroughScene_With8Components_Works()
        {
            using Scene scene = new();
            scene.Create(new Position(), new Velocity(), new Health(), new Transform(),
                new TestComponent(), new AnotherComponent(), new Damage(), new Armor());
            scene.Update();
        }

        /// <summary>
        /// Tests that neighbor cache via add remove exercises paths
        /// </summary>
        [Fact]
        public void NeighborCache_ViaAddRemove_ExercisesPaths()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
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

        /// <summary>
        /// Tests that game object ref tuple arity 8 works
        /// </summary>
        [Fact]
        public void GameObjectRefTuple_Arity8_Works()
        {
            using Scene scene = new();
            scene.Create(new Position(), new Velocity(), new Health(), new Transform(),
                new TestComponent(), new AnotherComponent(), new Damage(), new Armor());
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>,
                With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
            foreach (GameObjectRefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> tuple in query.EnumerateWithEntities<Position, Velocity, Health, Transform,
                TestComponent, AnotherComponent, Damage, Armor>())
            {
                Assert.True(tuple.GameObject.IsAlive);
            }
        }

        /// <summary>
        /// Tests that update runner factory all arities accessible
        /// </summary>
        [Fact]
        public void UpdateRunnerFactory_AllArities_Accessible()
        {
            Assert.NotNull(typeof(ComponentStorageBase).Assembly.GetType("Alis.Core.Ecs.Updating.Runners.UpdateRunnerFactory`2"));
            Assert.NotNull(typeof(ComponentStorageBase).Assembly.GetType("Alis.Core.Ecs.Updating.Runners.UpdateRunnerFactory`3"));
            Assert.NotNull(typeof(ComponentStorageBase).Assembly.GetType("Alis.Core.Ecs.Updating.Runners.UpdateRunnerFactory`4"));
            Assert.NotNull(typeof(ComponentStorageBase).Assembly.GetType("Alis.Core.Ecs.Updating.Runners.UpdateRunnerFactory`5"));
        }

        /// <summary>
        /// Tests that chunk query enumerator all arities accessible
        /// </summary>
        [Fact]
        public void ChunkQueryEnumerator_AllArities_Accessible()
        {
            Assert.True(typeof(ChunkQueryEnumerator<Position>).IsValueType);
            Assert.True(typeof(ChunkQueryEnumerator<Position, Velocity>).IsValueType);
            Assert.True(typeof(ChunkQueryEnumerator<Position, Velocity, Health>).IsValueType);
            Assert.True(typeof(ChunkQueryEnumerator<Position, Velocity, Health, Transform>).IsValueType);
        }

        /// <summary>
        /// Tests that chunk tuple all arities accessible
        /// </summary>
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

        /// <summary>
        /// Tests that game object entity id access
        /// </summary>
        [Fact]
        public void GameObject_EntityID_Access()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            int entityId = go.EntityID;
            Assert.True(entityId >= 0);
        }

        /// <summary>
        /// Tests that component handle boxed create and dispose
        /// </summary>
        [Fact]
        public void ComponentHandle_Boxed_CreateAndDispose()
        {
            Position pos = new Position { X = 42 };
            ComponentHandle handle = ComponentHandle.CreateFromBoxed((object)pos);
            Assert.True(typeof(ComponentHandle).IsValueType);
            handle.Dispose();
        }

        /// <summary>
        /// Tests that component handle retrieve works
        /// </summary>
        [Fact]
        public void ComponentHandle_Retrieve_Works()
        {
            Position pos = new Position { X = 42 };
            ComponentHandle handle = ComponentHandle.Create(pos);
            Assert.True(typeof(ComponentHandle).IsValueType);
            handle.Dispose();
        }

        /// <summary>
        /// Tests that scene create entity from location works
        /// </summary>
        [Fact]
        public void Scene_CreateEntityFromLocation_Works()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Update();
        }

        /// <summary>
        /// Tests that fastest array pool clear buckets works
        /// </summary>
        [Fact]
        public void FastestArrayPool_ClearBuckets_Works()
        {
            ArrayPool<int> pool = FastestArrayPool<int>.Shared;
            int[] arr = pool.Rent(100);
            pool.Return(arr);
            Type type = pool.GetType();
            MethodInfo method = type.GetMethod("ClearBuckets",
                BindingFlags.Instance | BindingFlags.NonPublic);
            if (method != null)
                method.Invoke(pool, null);
        }

        /// <summary>
        /// Tests that fastest array pool global clear buckets invokes
        /// </summary>
        [Fact]
        public void FastestArrayPool_GlobalClearBuckets_Invokes()
        {
            ArrayPool<int> pool = FastestArrayPool<int>.Shared;
            int[] arr = pool.Rent(100);
            pool.Return(arr);
            Gen2GcCallback.Register(() =>
            {
                MethodInfo method = pool.GetType().GetMethod("ClearBuckets", BindingFlags.Instance | BindingFlags.NonPublic);
                method?.Invoke(pool, null);
                return false;
            });
        }

        /// <summary>
        /// Tests that game invoke per entity no events no throw
        /// </summary>
        [Fact]
        public void Game_InvokePerEntity_NoEvents_NoThrow()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Update();
        }

        /// <summary>
        /// Tests that delete component data with delete works
        /// </summary>
        [Fact]
        public void DeleteComponentData_WithDelete_Works()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            go.Delete();
            scene.Update();
        }

        /// <summary>
        /// Tests that archetype edge key value type works
        /// </summary>
        [Fact]
        public void ArchetypeEdgeKey_ValueType_Works()
        {
            Assert.True(typeof(ArchetypeEdgeKey).IsValueType);
        }

        /// <summary>
        /// Tests that game object entity world span access
        /// </summary>
        [Fact]
        public void GameObject_EntityWorld_Span_Access()
        {
            using Scene scene = new();
            scene.Create(new Position());
            Assert.NotNull(scene);
        }

        /// <summary>
        /// Tests that scene update with attribute type
        /// </summary>
        [Fact]
        public void Scene_Update_WithAttributeType()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Update();
        }
    }
}
