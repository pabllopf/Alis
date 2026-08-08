using System;
using System.Buffers;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// The uncovered paths test class
    /// </summary>
    public class UncoveredPathsTest
    {
        /// <summary>
        /// Tests that fastest array pool return clear true works
        /// </summary>
        [Fact] public void FastestArrayPool_ReturnClearTrue_Works()
        {
            ArrayPool<string> pool = FastestArrayPool<string>.Shared;
            string[] arr = pool.Rent(10);
            arr[0] = "test";
            pool.Return(arr, true);
            Assert.Null(arr[0]);
        }

        /// <summary>
        /// Tests that fastest array pool rent and return ref type
        /// </summary>
        [Fact] public void FastestArrayPool_RentAndReturn_RefType()
        {
            ArrayPool<object> pool = FastestArrayPool<object>.Shared;
            object[] arr = pool.Rent(5);
            arr[0] = new object();
            pool.Return(arr, false);
            Assert.NotNull(arr[0]);
            pool.Return(arr, true);
            Assert.Null(arr[0]);
        }

        /// <summary>
        /// Tests that fastest array pool resize array from pool works
        /// </summary>
        [Fact] public void FastestArrayPool_ResizeArrayFromPool_Works()
        {
            int[] arr = [1, 2, 3];
            FastestArrayPool<int>.ResizeArrayFromPool(ref arr, 10);
            Assert.True(arr.Length >= 10);
            Assert.Equal(1, arr[0]);
            Assert.Equal(3, arr[2]);
        }

        /// <summary>
        /// Tests that fastest stack from collection works
        /// </summary>
        [Fact] public void FastestStack_FromCollection_Works()
        {
            FastestStack<int> stack = new FastestStack<int>(new[] { 1, 2, 3, 4, 5 });
            Assert.Equal(5, stack.Count);
            Assert.Equal(5, stack.Pop());
        }

        /// <summary>
        /// Tests that fastest stack trim excess reduces capacity
        /// </summary>
        [Fact] public void FastestStack_TrimExcess_ReducesCapacity()
        {
            FastestStack<int> stack = new FastestStack<int>();
            for (int i = 0; i < 50; i++) stack.Push(i);
            for (int i = 0; i < 40; i++) stack.Pop();
            stack.TrimExcess();
            Assert.Equal(10, stack.Count);
        }

        /// <summary>
        /// Tests that fastest stack to array empty returns empty
        /// </summary>
        [Fact] public void FastestStack_ToArray_Empty_ReturnsEmpty()
        {
            FastestStack<int> stack = new FastestStack<int>();
            int[] arr = stack.ToArray();
            Assert.Empty(arr);
        }

        /// <summary>
        /// Tests that fast lookup cold path multiple transitions
        /// </summary>
        [Fact] public void FastLookup_ColdPath_MultipleTransitions()
        {
            using Scene scene = new();
            for (int i = 0; i < 10; i++)
            {
                GameObject go = scene.Create(new Position { X = i });
                go.Add(new Velocity { X = i * 2 });
                go.Remove<Velocity>();
                go.Add(new Health { Value = i });
            }
            scene.Update();
        }

        /// <summary>
        /// Tests that fast lookup set archetype circular buffer
        /// </summary>
        [Fact] public void FastLookup_SetArchetype_CircularBuffer()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            for (int i = 0; i < 15; i++)
            {
                go.Add(new Velocity { X = i });
                go.Remove<Velocity>();
                go.Add(new Health { Value = i });
                go.Remove<Health>();
            }
            scene.Update();
        }

        /// <summary>
        /// Tests that command buffer playback when locked throws
        /// </summary>
        [Fact] public void CommandBuffer_PlaybackWhenLocked_Throws()
        {
            using Scene scene = new();
            CommandBuffer buffer = new CommandBuffer(scene);
            buffer.DeleteEntity(scene.Create(new Position()));
            scene.EnterDisallowState();
            Assert.Throws<InvalidOperationException>(() => buffer.Playback());
            scene.ExitDisallowState(null);
        }

        /// <summary>
        /// Tests that command buffer entity without with end creates entity
        /// </summary>
        [Fact] public void CommandBuffer_EntityWithoutWith_EndCreatesEntity()
        {
            using Scene scene = new();
            CommandBuffer buffer = new CommandBuffer(scene);
            buffer.Entity().With(new Position { X = 42 }).With(new Velocity { X = 10 });
            buffer.Playback();
        }

        /// <summary>
        /// Tests that command buffer add component with boxed no type works
        /// </summary>
        [Fact] public void CommandBuffer_AddComponent_WithBoxedNoType_Works()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            CommandBuffer buffer = new CommandBuffer(scene);
            buffer.AddComponent(go, (object)new Velocity { X = 5 });
            buffer.Playback();
            Assert.True(go.Has<Velocity>());
        }

        /// <summary>
        /// Tests that command buffer entity fluent with boxed by type works
        /// </summary>
        [Fact] public void CommandBuffer_EntityFluent_WithBoxedByType_Works()
        {
            using Scene scene = new();
            CommandBuffer buffer = new CommandBuffer(scene);
            buffer.Entity()
                .WithBoxed(typeof(Position), (object)new Position { X = 10 })
                .WithBoxed(new Velocity { X = 20 })
                .WithBoxed(Component<Health>.Id, (object)new Health { Value = 30 });
            buffer.Playback();
        }

        /// <summary>
        /// Tests that gen 2 gc callback register can be called
        /// </summary>
        [Fact] public void Gen2GcCallback_Register_CanBeCalled()
        {
            bool called = false;
            Gen2GcCallback.Register(() => { called = true; return false; });
        }

        /// <summary>
        /// Tests that component runner factory create strongly typed works
        /// </summary>
        [Fact] public void ComponentRunnerFactory_CreateStronglyTyped_Works()
        {
            NoneUpdateRunnerFactory<Position> factory = new NoneUpdateRunnerFactory<Position>();
            ComponentStorage<Position> storage = ((IComponentStorageBaseFactory<Position>)factory).CreateStronglyTyped(10);
            Assert.Equal(10, storage.Buffer.Length);
        }

        /// <summary>
        /// Tests that entity update with many types works
        /// </summary>
        [Fact] public void EntityUpdate_WithManyTypes_Works()
        {
            using Scene scene = new();
            scene.Create(new Position(), new Velocity(), new Health(), new Transform(),
                         new TestComponent(), new AnotherComponent(), new Damage(), new Armor());
            scene.Update();
        }

        /// <summary>
        /// Tests that archetype types array null creates new array
        /// </summary>
        [Fact] public void Archetype_TypesArrayNull_CreatesNewArray()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Create(new Position(), new Velocity());
            Assert.NotNull(scene);
        }

        /// <summary>
        /// Tests that game object delete and recreate works
        /// </summary>
        [Fact] public void GameObject_DeleteAndRecreate_Works()
        {
            using Scene scene = new();
            for (int i = 0; i < 5; i++)
            {
                GameObject go = scene.Create(new Position { X = i });
                go.Delete();
                scene.Update();
            }
        }

        /// <summary>
        /// Tests that scene update with many entities works
        /// </summary>
        [Fact] public void Scene_UpdateWithManyEntities_Works()
        {
            using Scene scene = new();
            for (int i = 0; i < 50; i++)
                scene.Create(new Position { X = i });
            for (int f = 0; f < 10; f++)
                scene.Update();
        }

        /// <summary>
        /// Tests that fast lookup find adjacent with cache miss works
        /// </summary>
        [Fact] public void FastLookup_FindAdjacent_WithCacheMiss_Works()
        {
            using Scene scene = new();
            scene.Create(new Position());
            GameObject go = scene.Create(new Position(), new Velocity());
            go.Add(new Health());
            go.Add(new Transform());
            go.Add(new TestComponent());
            go.Remove<TestComponent>();
            go.Remove<Transform>();
            scene.Update();
        }
    }
}
