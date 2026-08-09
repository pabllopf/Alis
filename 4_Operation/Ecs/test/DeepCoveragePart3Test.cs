using System.Buffers;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// The deep coverage part test class
    /// </summary>
    public class DeepCoveragePart3Test
    {

        /// <summary>
        /// Tests that component registry register and lookup consistent
        /// </summary>
        [Fact] public void ComponentRegistry_RegisterAndLookup_Consistent()
        {
            ComponentId posId = Component<Position>.Id;
            ComponentId velId = Component<Velocity>.Id;
            ComponentId healthId = Component<Health>.Id;
            Assert.NotEqual(posId.RawIndex, velId.RawIndex);
            Assert.NotEqual(velId.RawIndex, healthId.RawIndex);
            Assert.NotEqual(posId.RawIndex, healthId.RawIndex);
        }

        /// <summary>
        /// Tests that fast lookup multiple cache misses works
        /// </summary>
        [Fact] public void FastLookup_MultipleCacheMisses_Works()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            for (int i = 0; i < 12; i++)
            {
                go.Add(new Velocity { X = i });
                go.Remove<Velocity>();
                go.Add(new Health { Value = i });
                go.Remove<Health>();
            }
            scene.Update();
        }

        /// <summary>
        /// Tests that command buffer multiple operations work
        /// </summary>
        [Fact] public void CommandBuffer_MultipleOperations_Work()
        {
            using Scene scene = new();
            GameObject go1 = scene.Create(new Position());
            GameObject go2 = scene.Create(new Position(), new Velocity());
            CommandBuffer buffer = new CommandBuffer(scene);
            buffer.AddComponent(go1, new Velocity { X = 10 });
            buffer.AddComponent(go1, new Health { Value = 100 });
            buffer.RemoveComponent<Velocity>(go2);
            buffer.DeleteEntity(go1);
            buffer.Playback();
        }

        /// <summary>
        /// Tests that fastest array pool get bucket index various sizes
        /// </summary>
        [Fact] public void FastestArrayPool_GetBucketIndex_VariousSizes()
        {
            ArrayPool<int> pool = FastestArrayPool<int>.Shared;
            int[] sizes = [0, 1, 15, 16, 17, 31, 32, 33, 255, 256, 257, 65535, 65536, int.MaxValue / 2];
            foreach (int size in sizes)
            {
                int[] arr = pool.Rent(size);
                Assert.True(arr.Length >= size);
                pool.Return(arr);
            }
        }

        /// <summary>
        /// Tests that fastest array pool return clear ref type
        /// </summary>
        [Fact] public void FastestArrayPool_ReturnClearRefType()
        {
            ArrayPool<object> pool = FastestArrayPool<object>.Shared;
            object[] arr = pool.Rent(20);
            for (int i = 0; i < 10; i++) arr[i] = new object();
            pool.Return(arr, true);
            for (int i = 0; i < 10; i++) Assert.Null(arr[i]);
        }

        /// <summary>
        /// Tests that fastest stack enumerator dispose works
        /// </summary>
        [Fact] public void FastestStack_EnumeratorDispose_Works()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);
            FastestStack<int>.Enumerator e = stack.GetEnumerator();
            e.Dispose();
            Assert.False(e.MoveNext());
        }

        /// <summary>
        /// Tests that game object query enumerator all arities enumeration
        /// </summary>
        [Fact] public void GameObjectQueryEnumerator_AllArities_Enumeration()
        {
            using Scene scene = new();
            GameObject c8 = scene.Create(new Position(), new Velocity(), new Health(), new Transform(),
                                  new TestComponent(), new AnotherComponent(), new Damage(), new Armor());
            Query q8 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>,
                                   With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();
            foreach (GameObjectRefTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> tuple in q8.EnumerateWithEntities<Position, Velocity, Health, Transform,
                                                          TestComponent, AnotherComponent, Damage, Armor>())
            {
                Assert.Equal(c8, tuple.GameObject);
            }
        }

        /// <summary>
        /// Tests that scene query with not and include disabled works
        /// </summary>
        [Fact] public void Scene_QueryWithNotAndIncludeDisabled_Works()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Create(new Position(), new Velocity());
            Query query = scene.Query<With<Position>, Not<Velocity>, IncludeDisabled>();
            Assert.NotNull(query);
        }

        /// <summary>
        /// Tests that scene default archetype is not null
        /// </summary>
        [Fact] public void Scene_DefaultArchetype_IsNotNull()
        {
            using Scene scene = new();
            Assert.NotNull(scene.DefaultArchetype);
        }

        /// <summary>
        /// Tests that scene dispose while locked no throw
        /// </summary>
        [Fact] public void Scene_Dispose_WhileLocked_NoThrow()
        {
            Scene scene = new();
            scene.EnterDisallowState();
            scene.Dispose();
        }

        /// <summary>
        /// Tests that component id equality works
        /// </summary>
        [Fact] public void ComponentId_Equality_Works()
        {
            ComponentId id1 = Component<Position>.Id;
            ComponentId id2 = Component<Position>.Id;
            Assert.Equal(id1, id2);
            Assert.True(id1 == id2);
            Assert.False(id1 != id2);
        }

        /// <summary>
        /// Tests that component id equality operator works
        /// </summary>
        [Fact] public void ComponentId_EqualityOperator_Works()
        {
            ComponentId id1 = Component<Position>.Id;
            ComponentId id2 = Component<Velocity>.Id;
            Assert.True(id1 != id2);
        }
    }
}
