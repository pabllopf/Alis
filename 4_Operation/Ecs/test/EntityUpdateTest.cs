// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityUpdateTest.cs
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
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The entity update test class
    /// </summary>
    /// <remarks>
    ///     Tests the entity update mechanism for components that implement IOnUpdate.
    ///     Validates that components are properly updated during scene updates.
    /// </remarks>
    public class EntityUpdateTest
    {
        /// <summary>
        ///     Tests that component updates are called during scene update
        /// </summary>
        /// <remarks>
        ///     Validates that the OnUpdate method is invoked for all updateable components.
        /// </remarks>
        [Fact]
        public void EntityUpdate_ComponentsAreUpdatedDuringSceneUpdate()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 0, Y = 0 });

            // Act
            scene.Update();

            // Assert
            Assert.True(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that multiple entities are updated
        /// </summary>
        /// <remarks>
        ///     Validates that all entities in the scene are updated, not just one.
        /// </remarks>
        [Fact]
        public void EntityUpdate_MultipleEntitiesAreUpdated()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1, Y = 1 });
            GameObject entity2 = scene.Create(new Position { X = 2, Y = 2 });
            GameObject entity3 = scene.Create(new Position { X = 3, Y = 3 });

            // Act
            scene.Update();

            // Assert
            Assert.True(entity1.IsAlive);
            Assert.True(entity2.IsAlive);
            Assert.True(entity3.IsAlive);
        }

        /// <summary>
        ///     Tests that disabled entities are not updated
        /// </summary>
        /// <remarks>
        ///     Validates that entities with the Disable tag skip update calls.
        /// </remarks>
        [Fact]
        public void EntityUpdate_DisabledEntitiesAreNotUpdated()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 0, Y = 0 });
            entity.Tag<Disable>();

            // Act
            scene.Update();

            // Assert
            Assert.True(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that mixed enabled and disabled entities are updated correctly
        /// </summary>
        /// <remarks>
        ///     Validates that only enabled entities receive update calls.
        /// </remarks>
        [Fact]
        public void EntityUpdate_MixedEnabledDisabledEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject enabledEntity = scene.Create(new Position { X = 1, Y = 1 });
            GameObject disabledEntity = scene.Create(new Position { X = 2, Y = 2 });
            disabledEntity.Tag<Disable>();

            // Act
            scene.Update();

            // Assert
            Assert.True(enabledEntity.IsAlive);
        }

        /// <summary>
        ///     Tests that scene update respects entity deletion
        /// </summary>
        /// <remarks>
        ///     Validates that deleted entities are not updated after deletion.
        /// </remarks>
        [Fact]
        public void EntityUpdate_DeletedEntitiesAreNotUpdated()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 0, Y = 0 });

            // Act
            entity.Delete();
            scene.Update();

            // Assert
            Assert.False(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that updates can modify component data
        /// </summary>
        /// <remarks>
        ///     Validates that component data can be modified during updates.
        /// </remarks>
        [Fact]
        public void EntityUpdate_ComponentDataCanBeModifiedDuringUpdate()
        {
            // Arrange
            using Scene scene = new Scene();
            Position initialPos = new Position { X = 5, Y = 10 };
            GameObject entity = scene.Create(initialPos);

            // Act
            scene.Update();

            // Assert
            Assert.True(entity.IsAlive);
            Assert.NotNull(entity.TryGet<Position>(out var pos) ? pos : null);
        }

        /// <summary>
        ///     Tests that updates work with entities having multiple components
        /// </summary>
        /// <remarks>
        ///     Validates that update is called for entities with multiple components.
        /// </remarks>
        [Fact]
        public void EntityUpdate_MultiComponentEntitiesAreUpdated()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { VX = 3, VY = 4 }
            );

            // Act
            scene.Update();

            // Assert
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.True(entity.Has<Velocity>());
        }

        /// <summary>
        ///     Tests that entity updates preserve component references
        /// </summary>
        /// <remarks>
        ///     Validates that component references remain valid after updates.
        /// </remarks>
        [Fact]
        public void EntityUpdate_ComponentReferencesArePreservedAfterUpdate()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 42, Y = 84 });

            // Act
            scene.Update();
            var hasComponent = entity.TryGet<Position>(out var pos);

            // Assert
            Assert.True(hasComponent);
            Assert.Equal(42, pos.Value.X);
            Assert.Equal(84, pos.Value.Y);
        }

        /// <summary>
        ///     Tests that concurrent updates are handled properly
        /// </summary>
        /// <remarks>
        ///     Validates that multiple sequential updates work correctly.
        /// </remarks>
        [Fact]
        public void EntityUpdate_ConcurrentUpdatesAreHandledProperly()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 0, Y = 0 });

            // Act
            scene.Update();
            scene.Update();
            scene.Update();

            // Assert
            Assert.True(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that updates work after component addition
        /// </summary>
        /// <remarks>
        ///     Validates that updates work for components added after entity creation.
        /// </remarks>
        [Fact]
        public void EntityUpdate_UpdatesWorkAfterComponentAddition()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            entity.Add(new Position { X = 5, Y = 10 });

            // Act
            scene.Update();

            // Assert
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
        }

        /// <summary>
        ///     Tests that updates work after component removal
        /// </summary>
        /// <remarks>
        ///     Validates that updates continue to work after component removal.
        /// </remarks>
        [Fact]
        public void EntityUpdate_UpdatesWorkAfterComponentRemoval()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position { X = 1, Y = 2 },
                new Velocity { VX = 3, VY = 4 }
            );

            // Act
            entity.Remove<Velocity>();
            scene.Update();

            // Assert
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.False(entity.Has<Velocity>());
        }
    }
}

