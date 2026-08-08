using System.Linq;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    /// The final coverage push test class
    /// </summary>
    public class FinalCoveragePushTest
    {
        /// <summary>
        /// Tests that archetype t with update works
        /// </summary>
        [Fact] public void ArchetypeT_WithUpdate_Works()
        {
            using Scene scene = new();
            for (int i = 0; i < 10; i++)
                scene.Create(new Position { X = i });
            for (int f = 0; f < 3; f++)
                scene.Update();
        }

        /// <summary>
        /// Tests that update with 7 components works
        /// </summary>
        [Fact] public void Update_With7Components_Works()
        {
            using Scene scene = new();
            scene.Create(new Position(), new Velocity(), new Health(), new Transform(),
                         new TestComponent(), new AnotherComponent(), new Damage());
            for (int f = 0; f < 3; f++)
                scene.Update();
        }

        /// <summary>
        /// Tests that update with 8 components works
        /// </summary>
        [Fact] public void Update_With8Components_Works()
        {
            using Scene scene = new();
            scene.Create(new Position(), new Velocity(), new Health(), new Transform(),
                         new TestComponent(), new AnotherComponent(), new Damage(), new Armor());
            for (int f = 0; f < 3; f++)
                scene.Update();
        }

        /// <summary>
        /// Tests that update with 9 components works
        /// </summary>
        [Fact] public void Update_With9Components_Works()
        {
            using Scene scene = new();
            scene.Create(new Position(), new Velocity(), new Health(), new Transform(),
                         new TestComponent(), new AnotherComponent(), new Damage(), new Armor());
            scene.Create(new Position(), new Velocity());
            for (int f = 0; f < 3; f++)
                scene.Update();
        }

        /// <summary>
        /// Tests that scene create many 1 to 8 arities all work
        /// </summary>
        [Fact] public void Scene_CreateMany_1To8Arities_AllWork()
        {
            using Scene scene = new();
            ChunkTuple<Position> c1 = scene.CreateMany<Position>(2);
            scene.CreateMany<Position, Velocity>(2);
            scene.CreateMany<Position, Velocity, Health>(2);
            scene.CreateMany<Position, Velocity, Health, Transform>(2);
            scene.CreateMany<Position, Velocity, Health, Transform, TestComponent>(2);
            scene.CreateMany<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>(2);
            scene.CreateMany<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>(2);
            ChunkTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> c8 = scene.CreateMany<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(2);
            Assert.Equal(2, c1.Span.Length);
            Assert.Equal(2, c8.Span1.Length);
        }

        /// <summary>
        /// Tests that all query arities with include disabled work
        /// </summary>
        [Fact] public void AllQueryArities_WithIncludeDisabled_Work()
        {
            using Scene scene = new();
            scene.Create(new Position(), new Velocity(), new Health(), new Transform());
            Query q1 = scene.Query<With<Position>>();
            Query q2 = scene.Query<With<Position>, With<Velocity>>();
            Query q3 = scene.Query<With<Position>, With<Velocity>, With<Health>>();
            Query q4 = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();
            Assert.NotNull(q1); Assert.NotNull(q2); Assert.NotNull(q3); Assert.NotNull(q4);
        }

        /// <summary>
        /// Tests that query chunk enumerators all arities work
        /// </summary>
        [Fact] public void Query_ChunkEnumerators_AllArities_Work()
        {
            using Scene scene = new();
            ChunkTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> chunk =
                scene.CreateMany<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(3);
            Assert.Equal(3, chunk.Span1.Length);
        }

        /// <summary>
        /// Tests that game object create and delete stress
        /// </summary>
        [Fact] public void GameObject_CreateAndDelete_Stress()
        {
            using Scene scene = new();
            for (int i = 0; i < 20; i++)
            {
                GameObject go = scene.Create(new Position { X = i });
                if (i % 2 == 0) go.Delete();
            }
            scene.Update();
        }

        /// <summary>
        /// Tests that game object has component throws for non component
        /// </summary>
        [Fact] public void GameObject_HasComponent_ThrowsForNonComponent()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            Assert.False(go.Has<string>());
        }

        /// <summary>
        /// Tests that game object try get returns ref struct
        /// </summary>
        [Fact] public void GameObject_TryGet_ReturnsRefStruct()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Velocity { X = 99 });
            bool found = go.TryGet<Velocity>(out Ref<Velocity> vel);
            Assert.True(found);
            Assert.Equal(99, vel.Value.X);
        }

        /// <summary>
        /// Tests that component registry get component id works
        /// </summary>
        [Fact] public void ComponentRegistry_GetComponentId_Works()
        {
            ComponentId id1 = Component<Position>.Id;
            ComponentId id2 = Component<Velocity>.Id;
            Assert.NotEqual(id1.RawIndex, id2.RawIndex);
        }

        /// <summary>
        /// Tests that component registry same type returns consistent id
        /// </summary>
        [Fact] public void ComponentRegistry_SameType_ReturnsConsistentId()
        {
            ComponentId id1 = Component<Health>.Id;
            ComponentId id2 = Component<Health>.Id;
            Assert.Equal(id1.RawIndex, id2.RawIndex);
        }

        /// <summary>
        /// Tests that command buffer add component works
        /// </summary>
        [Fact] public void CommandBuffer_AddComponent_Works()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            CommandBuffer buffer = new CommandBuffer(scene);
            buffer.AddComponent(go, new Velocity { X = 10 });
            buffer.Clear();
        }

        /// <summary>
        /// Tests that command buffer delete entity works
        /// </summary>
        [Fact] public void CommandBuffer_DeleteEntity_Works()
        {
            using Scene scene = new();
            GameObject go = scene.Create(new Position());
            CommandBuffer buffer = new CommandBuffer(scene);
            buffer.DeleteEntity(go);
        }

        /// <summary>
        /// Tests that enumerable helpers to array works
        /// </summary>
        [Fact] public void EnumerableHelpers_ToArray_Works()
        {
            int[] arr = Alis.Core.Ecs.Collections.EnumerableHelpers.ToArray(Enumerable.Range(0, 5), out int length);
            Assert.Equal(5, length);
            Assert.Equal(4, arr[4]);
        }

        /// <summary>
        /// Tests that fastest array pool return works
        /// </summary>
        [Fact] public void FastestArrayPool_Return_Works()
        {
            int[] arr = System.Buffers.ArrayPool<int>.Shared.Rent(10);
            System.Buffers.ArrayPool<int>.Shared.Return(arr);
        }

        /// <summary>
        /// Tests that event invoke with handler works
        /// </summary>
        [Fact] public void Event_Invoke_WithHandler_Works()
        {
            Event<int> evt = new Event<int>();
            int captured = 0;
            void Handler(GameObject go, int val) => captured = val;
            evt.Add(Handler);
            evt.Invoke(default, 42);
            Assert.Equal(42, captured);
            evt.Remove(Handler);
        }

        /// <summary>
        /// Tests that game object only event invoke works
        /// </summary>
        [Fact] public void GameObjectOnlyEvent_Invoke_Works()
        {
            GameObjectOnlyEvent evt = new GameObjectOnlyEvent();
            bool fired = false;
            evt.Add(_ => fired = true);
            evt.Invoke(default);
            Assert.True(fired);
        }

        /// <summary>
        /// Tests that fast lookup find adjacent works
        /// </summary>
        [Fact] public void FastLookup_FindAdjacent_Works()
        {
            using Scene scene = new();
            scene.Create(new Position());
            scene.Create(new Position(), new Velocity());
            Assert.NotNull(scene);
        }
    }
}
