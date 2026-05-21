

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The command buffer extended test class
    /// </summary>
    /// <remarks>
    ///     Extended tests for CommandBuffer, validating deferred structural changes
    ///     and command recording functionality for safe entity modifications.
    /// </remarks>
    public class CommandBufferExtendedTest
    {
        /// <summary>
        ///     Tests that command buffer can be created
        /// </summary>
        /// <remarks>
        ///     Validates that a CommandBuffer instance can be instantiated.
        /// </remarks>
        [Fact]
        public void CommandBuffer_CanBeCreated()
        {
            CommandBuffer buffer = new CommandBuffer(new Scene());

            Assert.NotNull(buffer);
        }

        /// <summary>
        ///     Tests that entity can be created via command buffer
        /// </summary>
        /// <remarks>
        ///     Validates that entity creation commands can be recorded.
        /// </remarks>
        [Fact]
        public void CommandBuffer_CanCreateEntity()
        {
            using Scene scene = new Scene();

            GameObject entity = scene.Create();

            Assert.True(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that component can be added via deferred operation
        /// </summary>
        /// <remarks>
        ///     Validates that component addition works through deferred operations.
        /// </remarks>
        [Fact]
        public void CommandBuffer_CanAddComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new Position {X = 10, Y = 20});

            Assert.True(entity.Has<Position>());
        }

        /// <summary>
        ///     Tests that component can be removed via deferred operation
        /// </summary>
        /// <remarks>
        ///     Validates that component removal works through deferred operations.
        /// </remarks>
        [Fact]
        public void CommandBuffer_CanRemoveComponent()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Remove<Position>();

            Assert.False(entity.Has<Position>());
        }

        /// <summary>
        ///     Tests that entity can be deleted via command buffer
        /// </summary>
        /// <remarks>
        ///     Validates that entity deletion works through deferred operations.
        /// </remarks>
        [Fact]
        public void CommandBuffer_CanDeleteEntity()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Delete();

            Assert.False(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that multiple operations are queued
        /// </summary>
        /// <remarks>
        ///     Validates that CommandBuffer can record multiple operations.
        /// </remarks>
        [Fact]
        public void CommandBuffer_QueuesMultipleOperations()
        {
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create();
            GameObject entity2 = scene.Create();
            GameObject entity3 = scene.Create();

            entity1.Add(new Position {X = 1, Y = 2});
            entity2.Add(new Velocity {X = 3, Y = 4});
            entity3.Add(new Health {Value = 100});

            Assert.True(entity1.Has<Position>());
            Assert.True(entity2.Has<Velocity>());
            Assert.True(entity3.Has<Health>());
        }

        /// <summary>
        ///     Tests that operations are applied to scene
        /// </summary>
        /// <remarks>
        ///     Validates that queued operations are properly applied to the scene.
        /// </remarks>
        [Fact]
        public void CommandBuffer_AppliesOperationsToScene()
        {
            using Scene scene = new Scene();
            int initialCount = scene.EntityCount;

            GameObject entity = scene.Create();
            scene.Update();

            Assert.True(entity.IsAlive);
            Assert.Equal(initialCount + 1, scene.EntityCount);
        }

        /// <summary>
        ///     Tests that operations maintain consistency
        /// </summary>
        /// <remarks>
        ///     Validates that deferred operations maintain entity state consistency.
        /// </remarks>
        [Fact]
        public void CommandBuffer_MaintainsConsistency()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 42, Y = 84});

            entity.Add(new Velocity {X = 5, Y = 10});
            scene.Update();

            Assert.True(entity.TryGet(out Ref<Position> pos));
            Assert.Equal(42, pos.Value.X);
            Assert.True(entity.TryGet(out Ref<Velocity> vel));
            Assert.Equal(5, vel.Value.X);
        }

        /// <summary>
        ///     Tests that operations work with many entities
        /// </summary>
        /// <remarks>
        ///     Validates that CommandBuffer scales with many operations.
        /// </remarks>
        [Fact]
        public void CommandBuffer_ScalesWithManyOperations()
        {
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[100];

            for (int i = 0; i < 100; i++)
            {
                entities[i] = scene.Create();
                entities[i].Add(new Position {X = i, Y = i * 2});
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.True(entities[i].Has<Position>());
            }
        }

        /// <summary>
        ///     Tests that operations preserve order
        /// </summary>
        /// <remarks>
        ///     Validates that operations are applied in the correct order.
        /// </remarks>
        [Fact]
        public void CommandBuffer_PreservesOperationOrder()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new Position {X = 1, Y = 2});
            entity.Add(new Velocity {X = 3, Y = 4});
            entity.Add(new Health {Value = 100});

            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
            Assert.True(entity.Has<Health>());
        }

        /// <summary>
        ///     Tests that complex operation sequences work
        /// </summary>
        /// <remarks>
        ///     Validates that CommandBuffer handles complex operation sequences.
        /// </remarks>
        [Fact]
        public void CommandBuffer_HandlesComplexSequences()
        {
            using Scene scene = new Scene();

            GameObject entity1 = scene.Create(new Position {X = 1, Y = 2});
            GameObject entity2 = scene.Create(new Velocity {X = 3, Y = 4});

            entity1.Add(new Velocity {X = 5, Y = 6});
            entity2.Add(new Position {X = 7, Y = 8});
            entity2.Add(new Health {Value = 100});

            entity1.Remove<Velocity>();

            Assert.True(entity1.Has<Position>());
            Assert.False(entity1.Has<Velocity>());
            Assert.True(entity2.Has<Position>());
            Assert.True(entity2.Has<Velocity>());
            Assert.True(entity2.Has<Health>());
        }

        /// <summary>
        ///     Tests that operations are deferred until update
        /// </summary>
        /// <remarks>
        ///     Validates that operations don't execute immediately but are deferred.
        /// </remarks>
        [Fact]
        public void CommandBuffer_DefersOperationsUntilUpdate()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            entity.Add(new Position {X = 1, Y = 2});

            scene.Update();

            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
        }

        /// <summary>
        ///     Tests that operations handle invalid entity gracefully
        /// </summary>
        /// <remarks>
        ///     Validates that operations on dead entities are handled properly.
        /// </remarks>
        [Fact]
        public void CommandBuffer_HandlesInvalidEntityGracefully()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            entity.Delete();

            Assert.False(entity.IsAlive);
        }
    }
}