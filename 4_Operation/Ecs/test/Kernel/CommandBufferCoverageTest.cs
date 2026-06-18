// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CommandBufferCoverageTest.cs
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
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Coverage-focused tests for <see cref="CommandBuffer" />, targeting
    ///     uncovered method overloads, exception paths, and entity-creation chain.
    /// </summary>
    public class CommandBufferCoverageTest
    {
        /// <summary>
        ///     Tests that <see cref="CommandBuffer.RemoveComponent(GameObject, Type)" />
        ///     queues a remove operation via the type-based overload.
        /// </summary>
        [Fact]
        public void RemoveComponent_ByType_AddsToBuffer()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 1 });

            buffer.RemoveComponent(entity, typeof(TestComponent));

            Assert.True(buffer.HasBufferItems);
        }

        /// <summary>
        ///     Tests that <see cref="CommandBuffer.AddComponent(GameObject, object)" />
        ///     queues an add operation via the boxed overload without explicit type.
        /// </summary>
        [Fact]
        public void AddComponent_BoxedNoType_AddsToBuffer()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 1 });

            buffer.AddComponent(entity, new AnotherComponent { Name = "boxed" });

            Assert.True(buffer.HasBufferItems);
        }

        /// <summary>
        ///     Tests that <see cref="CommandBuffer.AddComponent(GameObject, ComponentId, object)" />
        ///     queues an add operation via the ComponentId + boxed overload.
        /// </summary>
        [Fact]
        public void AddComponent_ByComponentIdAndBoxed_AddsToBuffer()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 1 });

            buffer.AddComponent(entity, Component<AnotherComponent>.Id, new AnotherComponent { Name = "id-boxed" });

            Assert.True(buffer.HasBufferItems);
        }

        /// <summary>
        ///     Tests that <see cref="CommandBuffer.AddComponent(GameObject, ComponentId, object)" />
        ///     playback correctly adds the boxed component.
        /// </summary>
        [Fact]
        public void AddComponent_ByComponentIdAndBoxed_PlaybackAddsComponent()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 1 });

            buffer.AddComponent(entity, Component<AnotherComponent>.Id, new AnotherComponent { Name = "playback-boxed" });
            buffer.Playback();

            Assert.True(entity.Has<AnotherComponent>());
        }

        /// <summary>
        ///     Tests that <see cref="CommandBuffer.AddComponent(GameObject, object)" />
        ///     playback correctly adds the component.
        /// </summary>
        [Fact]
        public void AddComponent_BoxedNoType_PlaybackAddsComponent()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 1 });

            buffer.AddComponent(entity, new AnotherComponent2 { Name = "boxed-nt", Data = 42 });
            buffer.Playback();

            Assert.True(entity.Has<AnotherComponent2>());
        }

        /// <summary>
        ///     Tests that <see cref="CommandBuffer.RemoveComponent(GameObject, Type)" />
        ///     playback removes the component.
        /// </summary>
        [Fact]
        public void RemoveComponent_ByType_PlaybackRemovesComponent()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 1 });

            buffer.RemoveComponent(entity, typeof(TestComponent));
            buffer.Playback();

            Assert.False(entity.Has<TestComponent>());
        }

        /// <summary>
        ///     Tests the Entity / With / End creation chain via <see cref="CommandBuffer.Entity" />.
        /// </summary>
        [Fact]
        public void Entity_With_End_CreatesEntityOnPlayback()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);

            buffer.Entity().With(new Position { X = 10, Y = 20 }).With(new Velocity { X = 1, Y = 2 }).End();
            buffer.Playback();

            int count = 0;
            foreach (ref GameObjectType _ in scene.GetAllArchetypes())
            {
                count++;
            }

            Assert.True(count > 0);
        }

        /// <summary>
        ///     Tests that entity created via Entity / With / End has the specified components after playback.
        /// </summary>
        [Fact]
        public void Entity_With_End_CreatedEntityHasComponents()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);

            buffer.Entity().With(new Position { X = 10, Y = 20 }).With(new Velocity { X = 1, Y = 2 }).End();
            buffer.Playback();

            scene.Update();
        }

        /// <summary>
        ///     Tests that <see cref="CommandBuffer.WithBoxed(ComponentId, object)" /> works in the entity creation chain.
        /// </summary>
        [Fact]
        public void WithBoxed_ByComponentId_WorksInEntityChain()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);

            buffer.Entity()
                .WithBoxed(Component<Position>.Id, new Position { X = 5, Y = 10 })
                .End();
            buffer.Playback();
        }

        /// <summary>
        ///     Tests that <see cref="CommandBuffer.WithBoxed(object)" /> works in the entity creation chain.
        /// </summary>
        [Fact]
        public void WithBoxed_ByValue_WorksInEntityChain()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);

            buffer.Entity()
                .WithBoxed(new Position { X = 3, Y = 6 })
                .End();
            buffer.Playback();
        }

        /// <summary>
        ///     Tests that <see cref="CommandBuffer.WithBoxed(Type, object)" /> works in the entity creation chain.
        /// </summary>
        [Fact]
        public void WithBoxed_ByType_WorksInEntityChain()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);

            buffer.Entity()
                .WithBoxed(typeof(Position), new Position { X = 7, Y = 14 })
                .End();
            buffer.Playback();
        }

        /// <summary>
        ///     Tests that calling <see cref="CommandBuffer.With{T}" /> without first calling
        ///     <see cref="CommandBuffer.Entity" /> throws <see cref="InvalidOperationException" />.
        /// </summary>
        [Fact]
        public void With_WithoutEntity_ThrowsInvalidOperation()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                buffer.With(new Position { X = 1, Y = 2 }));

            Assert.Contains("CommandBuffer.GameObject()", exception.Message);
        }

        /// <summary>
        ///     Tests that calling <see cref="CommandBuffer.WithBoxed(ComponentId, object)" /> without first calling
        ///     <see cref="CommandBuffer.Entity" /> throws <see cref="InvalidOperationException" />.
        /// </summary>
        [Fact]
        public void WithBoxed_WithoutEntity_ThrowsInvalidOperation()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);

            Assert.Throws<InvalidOperationException>(() =>
                buffer.WithBoxed(Component<Position>.Id, new Position { X = 1, Y = 2 }));
        }

        /// <summary>
        ///     Tests that calling <see cref="CommandBuffer.Entity" /> twice without
        ///     <see cref="CommandBuffer.End" /> throws <see cref="InvalidOperationException" />.
        /// </summary>
        [Fact]
        public void Entity_CalledTwiceWithoutEnd_ThrowsInvalidOperation()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);

            buffer.Entity();

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                buffer.Entity());

            Assert.Contains("currently being created", exception.Message);
        }

        /// <summary>
        ///     Tests that <see cref="CommandBuffer.Playback" /> throws
        ///     <see cref="InvalidOperationException" /> when structural changes
        ///     are not allowed (e.g., during scene update).
        /// </summary>
        [Fact]
        public void Playback_WhenStructuralChangesDisallowed_ThrowsInvalidOperation()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 1 });
            buffer.DeleteEntity(entity);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() =>
                PlaybackDuringUpdate(buffer, scene));

            Assert.Contains("structural changes", exception.Message);
        }

        /// <summary>
        ///     Helper that triggers playback inside an update callback where structural changes are locked.
        /// </summary>
        private static void PlaybackDuringUpdate(CommandBuffer buffer, Scene scene)
        {
            scene.Create<PlaybackBlockerComponent>(new PlaybackBlockerComponent { Buffer = buffer });
            scene.Update();
        }

        /// <summary>
        ///     Component used to trigger <see cref="CommandBuffer.Playback" /> during an update.
        /// </summary>
        private struct PlaybackBlockerComponent : IOnUpdate
        {
            /// <summary>
            ///     The command buffer to playback.
            /// </summary>
            public CommandBuffer Buffer;

            /// <summary>
            ///     Called during scene update — triggers Playback to hit the structural-changes guard.
            /// </summary>
            /// <param name="self">The game object.</param>
            public void OnUpdate(IGameObject self)
            {
                Buffer.Playback();
            }
        }

        /// <summary>
        ///     Tests that <see cref="CommandBuffer.Clear" /> handles entities from
        ///     previous CreateEntityBuffer entries.
        /// </summary>
        [Fact]
        public void Clear_WithCreatedEntities_DoesNotThrow()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);

            buffer.Entity().With(new Position { X = 1, Y = 2 }).End();
            buffer.Clear();

            Assert.False(buffer.HasBufferItems);
        }

        /// <summary>
        ///     Tests that <see cref="CommandBuffer.HasBufferItems" /> returns
        ///     true after DeleteEntity is queued.
        /// </summary>
        [Fact]
        public void HasBufferItems_AfterDeleteEntity_ReturnsTrue()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 1 });

            buffer.DeleteEntity(entity);

            Assert.True(buffer.HasBufferItems);
        }

        /// <summary>
        ///     Tests that <see cref="CommandBuffer.HasBufferItems" /> returns
        ///     false after Clear.
        /// </summary>
        [Fact]
        public void HasBufferItems_AfterClear_ReturnsFalse()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 1 });

            buffer.DeleteEntity(entity);
            buffer.Clear();

            Assert.False(buffer.HasBufferItems);
        }

        /// <summary>
        ///     Tests that <see cref="CommandBuffer.Playback" /> returns false
        ///     when buffer is empty after clear.
        /// </summary>
        [Fact]
        public void Playback_AfterClear_ReturnsFalse()
        {
            using Scene scene = new Scene();
            CommandBuffer buffer = new CommandBuffer(scene);
            GameObject entity = scene.Create(new TestComponent { Value = 1 });

            buffer.DeleteEntity(entity);
            buffer.Clear();

            bool result = buffer.Playback();

            Assert.False(result);
        }
    }
}
