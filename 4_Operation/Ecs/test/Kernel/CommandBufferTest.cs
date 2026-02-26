// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CommandBufferTest.cs
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

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The command buffer test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="CommandBuffer"/> class which stores a set of structural
    ///     changes that can be applied to a Scene for deferred entity operations.
    /// </remarks>
    public class CommandBufferTest
    {
        /// <summary>
        ///     Tests that command buffer can be created with scene
        /// </summary>
        /// <remarks>
        ///     Verifies that a CommandBuffer can be instantiated with a Scene.
        /// </remarks>
        [Fact]
        public void CommandBuffer_CanBeCreatedWithScene()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            CommandBuffer buffer = new CommandBuffer(scene);

            // Assert
            Assert.NotNull(buffer);
        }

        /// <summary>
        ///     Tests that command buffer starts inactive
        /// </summary>
        /// <remarks>
        ///     Validates that a new CommandBuffer starts in inactive state.
        /// </remarks>
        [Fact]
        public void CommandBuffer_StartsInactive()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            CommandBuffer buffer = new CommandBuffer(scene);

            // Assert
            Assert.False(buffer.HasBufferItems);
        }

        /// <summary>
        ///     Tests that delete entity adds to buffer
        /// </summary>
        /// <remarks>
        ///     Tests that DeleteEntity method adds the operation to the buffer.
        /// </remarks>
        [Fact]
        public void DeleteEntity_AddsToBuffer()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 42 });

            // Act
            buffer.DeleteEntity(entity);

            // Assert
            Assert.True(buffer.HasBufferItems);
        }

        /// <summary>
        ///     Tests that add component adds to buffer
        /// </summary>
        /// <remarks>
        ///     Tests that AddComponent method adds the operation to the buffer.
        /// </remarks>
        [Fact]
        public void AddComponent_AddsToBuffer()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 10 });

            // Act
            buffer.AddComponent(entity, new AnotherComponent { Name = "Test" });

            // Assert
            Assert.True(buffer.HasBufferItems);
        }

        /// <summary>
        ///     Tests that remove component adds to buffer
        /// </summary>
        /// <remarks>
        ///     Tests that RemoveComponent method adds the operation to the buffer.
        /// </remarks>
        [Fact]
        public void RemoveComponent_AddsToBuffer()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 20 });

            // Act
            buffer.RemoveComponent<TestComponent>(entity);

            // Assert
            Assert.True(buffer.HasBufferItems);
        }

        /// <summary>
        ///     Tests that clear removes all commands
        /// </summary>
        /// <remarks>
        ///     Validates that Clear method removes all buffered commands.
        /// </remarks>
        [Fact]
        public void Clear_RemovesAllCommands()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 30 });
            buffer.DeleteEntity(entity);

            // Act
            buffer.Clear();

            // Assert
            Assert.False(buffer.HasBufferItems);
        }

        /// <summary>
        ///     Tests that playback applies delete entity command
        /// </summary>
        /// <remarks>
        ///     Tests that Playback method applies the DeleteEntity command to the scene.
        /// </remarks>
        [Fact]
        public void Playback_AppliesDeleteEntityCommand()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 40 });
            buffer.DeleteEntity(entity);

            // Act
            buffer.Playback();

            // Assert
            Assert.False(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that playback applies add component command
        /// </summary>
        /// <remarks>
        ///     Tests that Playback method applies the AddComponent command to the scene.
        /// </remarks>
        [Fact]
        public void Playback_AppliesAddComponentCommand()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 50 });
            buffer.AddComponent(entity, new AnotherComponent { Name = "Added" });

            // Act
            buffer.Playback();

            // Assert
            Assert.True(entity.Has<AnotherComponent>());
        }

        /// <summary>
        ///     Tests that playback applies remove component command
        /// </summary>
        /// <remarks>
        ///     Tests that Playback method applies the RemoveComponent command to the scene.
        /// </remarks>
        [Fact]
        public void Playback_AppliesRemoveComponentCommand()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 60 }, new AnotherComponent { Name = "ToRemove" });
            buffer.RemoveComponent<AnotherComponent>(entity);

            // Act
            buffer.Playback();

            // Assert
            Assert.False(entity.Has<AnotherComponent>());
        }

        /// <summary>
        ///     Tests that playback returns true when commands were applied
        /// </summary>
        /// <remarks>
        ///     Validates that Playback returns true when at least one command was applied.
        /// </remarks>
        [Fact]
        public void Playback_ReturnsTrueWhenCommandsWereApplied()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 70 });
            buffer.DeleteEntity(entity);

            // Act
            bool result = buffer.Playback();

            // Assert
            Assert.True(result);
        }

        /// <summary>
        ///     Tests that playback returns false when buffer is empty
        /// </summary>
        /// <remarks>
        ///     Validates that Playback returns false when the buffer has no commands.
        /// </remarks>
        [Fact]
        public void Playback_ReturnsFalseWhenBufferIsEmpty()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);

            // Act
            bool result = buffer.Playback();

            // Assert
            Assert.False(result);
        }

        /// <summary>
        ///     Tests that command buffer can handle multiple commands
        /// </summary>
        /// <remarks>
        ///     Tests that CommandBuffer can handle multiple buffered commands.
        /// </remarks>
        [Fact]
        public void CommandBuffer_CanHandleMultipleCommands()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity1 = scene.Create(new TestComponent { Value = 1 });
            GameObject entity2 = scene.Create(new TestComponent { Value = 2 });

            // Act
            buffer.DeleteEntity(entity1);
            buffer.AddComponent(entity2, new AnotherComponent { Name = "Test" });
            buffer.Playback();

            // Assert
            Assert.False(entity1.IsAlive);
            Assert.True(entity2.Has<AnotherComponent>());
        }

        /// <summary>
        ///     Tests that command buffer clears after playback
        /// </summary>
        /// <remarks>
        ///     Validates that the buffer is cleared after successful playback.
        /// </remarks>
        [Fact]
        public void CommandBuffer_ClearsAfterPlayback()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 80 });
            buffer.DeleteEntity(entity);

            // Act
            buffer.Playback();

            // Assert
            Assert.False(buffer.HasBufferItems);
        }

        /// <summary>
        ///     Tests that remove component with component id works
        /// </summary>
        /// <remarks>
        ///     Tests that RemoveComponent overload with ComponentId works correctly.
        /// </remarks>
        [Fact]
        public void RemoveComponent_WithComponentId_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 90 });

            // Act
            buffer.RemoveComponent(entity, Component<TestComponent>.Id);
            buffer.Playback();

            // Assert
            Assert.False(entity.Has<TestComponent>());
        }

        /// <summary>
        ///     Tests that command buffer can queue multiple operations on same entity
        /// </summary>
        /// <remarks>
        ///     Tests that multiple operations can be queued for the same entity.
        /// </remarks>
        [Fact]
        public void CommandBuffer_CanQueueMultipleOperationsOnSameEntity()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 100 });

            // Act
            buffer.AddComponent(entity, new AnotherComponent { Name = "First" });
            buffer.RemoveComponent<TestComponent>(entity);
            buffer.Playback();

            // Assert
            Assert.True(entity.Has<AnotherComponent>());
            Assert.False(entity.Has<TestComponent>());
        }

        /// <summary>
        ///     Tests that command buffer handles entity lifecycle correctly
        /// </summary>
        /// <remarks>
        ///     Validates that CommandBuffer properly handles entity creation and deletion.
        /// </remarks>
        [Fact]
        public void CommandBuffer_HandlesEntityLifecycleCorrectly()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 110 });
            int initialCount = scene.EntityCount;

            // Act
            buffer.DeleteEntity(entity);
            buffer.Playback();

            // Assert
            Assert.Equal(initialCount - 1, scene.EntityCount);
        }

        /// <summary>
        ///     Tests that add component with type parameter works
        /// </summary>
        /// <remarks>
        ///     Tests that AddComponent overload with Type parameter works correctly.
        /// </remarks>
        [Fact]
        public void AddComponent_WithTypeParameter_Works()
        {
            // Arrange
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 120 });
            AnotherComponent component2 = new AnotherComponent { Name = "TypeTest" };

            // Act
            buffer.AddComponent(entity, typeof(AnotherComponent), component2);
            buffer.Playback();

            // Assert
            Assert.True(entity.Has<AnotherComponent>());
        }
    }
}

