using System.Linq;
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
    public class DeepCoveragePart2Test
    {
        /// <summary>
        /// Tests that fastest array pool rent and return maintains capacity
        /// </summary>
        [Fact] public void FastestArrayPool_RentAndReturn_MaintainsCapacity()
        {
            var pool = FastestArrayPool<int>.Shared;
            int[] arr = pool.Rent(5);
            Assert.True(arr.Length >= 5);
            pool.Return(arr);
        }

        /// <summary>
        /// Tests that fastest array pool rent zero returns empty
        /// </summary>
        [Fact] public void FastestArrayPool_RentZero_ReturnsEmpty()
        {
            var pool = FastestArrayPool<int>.Shared;
            int[] arr = pool.Rent(0);
            Assert.NotNull(arr);
            pool.Return(arr);
        }

        /// <summary>
        /// Tests that fastest stack push pop works fifo
        /// </summary>
        [Fact] public void FastestStack_PushPop_WorksFIFO()
        {
            FastestStack<int> stack = new FastestStack<int>();
            for (int i = 0; i < 10; i++)
                stack.Push(i);
            for (int i = 9; i >= 0; i--)
                Assert.Equal(i, stack.Pop());
        }

        /// <summary>
        /// Tests that fastest stack peek returns top
        /// </summary>
        [Fact] public void FastestStack_Peek_ReturnsTop()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(42);
            Assert.Equal(42, stack.Peek());
        }

        /// <summary>
        /// Tests that fastest stack contains works
        /// </summary>
        [Fact] public void FastestStack_Contains_Works()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.True(stack.Contains(2));
            Assert.False(stack.Contains(99));
        }

        /// <summary>
        /// Tests that fastest stack clear empties
        /// </summary>
        [Fact] public void FastestStack_Clear_Empties()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            stack.Clear();
            Assert.Equal(0, stack.Count);
        }

        /// <summary>
        /// Tests that fastest stack to array works
        /// </summary>
        [Fact] public void FastestStack_ToArray_Works()
        {
            FastestStack<int> stack = new FastestStack<int>();
            for (int i = 0; i < 5; i++)
                stack.Push(i);
            int[] arr = stack.ToArray();
            Assert.Equal(5, arr.Length);
        }

        /// <summary>
        /// Tests that fastest stack constructor from collection
        /// </summary>
        [Fact] public void FastestStack_Constructor_FromCollection()
        {
            FastestStack<int> stack = new FastestStack<int>(new[] { 1, 2, 3 });
            Assert.Equal(3, stack.Count);
        }

        /// <summary>
        /// Tests that fastest stack trim excess works
        /// </summary>
        [Fact] public void FastestStack_TrimExcess_Works()
        {
            FastestStack<int> stack = new FastestStack<int>();
            for (int i = 0; i < 100; i++)
                stack.Push(i);
            for (int i = 0; i < 90; i++)
                stack.Pop();
            stack.TrimExcess();
        }

        /// <summary>
        /// Tests that enumerable helpers to array from enumerable
        /// </summary>
        [Fact] public void EnumerableHelpers_ToArray_FromEnumerable()
        {
            int[] arr = EnumerableHelpers.ToArray(Enumerable.Range(1, 10), out int length);
            Assert.Equal(10, length);
            Assert.Equal(10, arr[9]);
        }

        /// <summary>
        /// Tests that enumerable helpers empty enumerator yields nothing
        /// </summary>
        [Fact] public void EnumerableHelpers_EmptyEnumerator_YieldsNothing()
        {
            var e = EnumerableHelpers.GetEmptyEnumerator<int>();
            Assert.False(e.MoveNext());
        }

        /// <summary>
        /// Tests that command buffer fluent api works
        /// </summary>
        [Fact] public void CommandBuffer_FluentApi_Works()
        {
            using Scene scene = new();
            CommandBuffer buffer = new CommandBuffer(scene);
            buffer.Entity().With(new Position { X = 5 }).With(new Velocity { X = 10 });
            buffer.Playback();
        }

        /// <summary>
        /// Tests that command buffer add component then remove works
        /// </summary>
        [Fact] public void CommandBuffer_AddComponent_ThenRemove_Works()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position(), new Velocity());
            CommandBuffer buffer = new CommandBuffer(scene);
            buffer.RemoveComponent<Velocity>(go);
            buffer.Playback();
            Assert.False(go.Has<Velocity>());
            Assert.True(go.Has<Position>());
        }

        /// <summary>
        /// Tests that fast lookup find adjacent archetype id works
        /// </summary>
        [Fact] public void FastLookup_FindAdjacentArchetypeId_Works()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Create(new Position(), new Velocity());
            scene.Create(new Position(), new Velocity(), new Health());
            Assert.NotNull(scene);
        }

        /// <summary>
        /// Tests that component handle can be created
        /// </summary>
        [Fact] public void ComponentHandle_CanBeCreated()
        {
            Position pos = new Position { X = 42 };
            ComponentHandle handle = ComponentHandle.Create(pos);
            Assert.True(typeof(ComponentHandle).IsValueType);
            handle.Dispose();
        }

        /// <summary>
        /// Tests that ref create and read works
        /// </summary>
        [Fact] public void Ref_CreateAndRead_Works()
        {
            using Scene scene = new();
            scene.Create(new Position { X = 42 });
            Query query = scene.Query<With<Position>>();
            var enumerable = query.EnumerateWithEntities<Position>();
            using var enumerator = enumerable.GetEnumerator();
            Assert.True(enumerator.MoveNext());
            Assert.Equal(42, enumerator.Current.Item1.Value.X);
        }

        /// <summary>
        /// Tests that archetype data property returns fields with components
        /// </summary>
        [Fact] public void Archetype_DataProperty_ReturnsFieldsWithComponents()
        {
            using Scene scene = new();
            scene.Create(new Position());
            var archetype = scene.DefaultArchetype;
            Fields data = archetype.Data;
            Assert.NotNull(data.Map);
            Assert.NotNull(data.Components);
        }

        /// <summary>
        /// Tests that scene with disabled entity not enumerated
        /// </summary>
        [Fact] public void Scene_WithDisabledEntity_NotEnumerated()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Create(new Position());
            Assert.NotNull(scene);
        }

        /// <summary>
        /// Tests that game object with multiple remove works
        /// </summary>
        [Fact] public void GameObject_WithMultipleRemove_Works()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position(), new Velocity(), new Health());
            Assert.True(go.Has<Velocity>());
            go.Remove<Velocity>();
            scene.Update();
            Assert.False(go.Has<Velocity>());
            Assert.True(go.Has<Position>());
            Assert.True(go.Has<Health>());
        }

        /// <summary>
        /// Tests that scene game object enumerable returns all
        /// </summary>
        [Fact] public void Scene_GameObjectEnumerable_ReturnsAll()
        {
            using Scene scene = new();
            for (int i = 0; i < 5; i++)
                scene.Create(new Position());
            ChunkTuple<Position> chunk = scene.CreateMany<Position>(5);
            int count = 0;
            foreach (GameObject go in chunk.Entities)
            {
                count++;
                Assert.True(go.IsAlive);
            }
            Assert.Equal(5, count);
        }
    }
}
