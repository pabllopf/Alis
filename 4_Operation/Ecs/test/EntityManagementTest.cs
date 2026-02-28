// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityManagementTest.cs
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

using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The entity management test class
    /// </summary>
    /// <remarks>
    ///     Tests for entity lifecycle management including creation, deletion,
    ///     and state tracking of entities in scenes.
    /// </remarks>
    public class EntityManagementTest
    {
        /// <summary>
        ///     Tests that entities can be created with components
        /// </summary>
        /// <remarks>
        ///     Validates that entities can be created with initial components.
        /// </remarks>
        [Fact]
        public void Entity_CanBeCreatedWithComponent()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity = scene.Create(new Position { X = 5, Y = 10 });

            // Assert
            Assert.False(entity.IsNull);
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
        }

        /// <summary>
        ///     Tests that entities can be deleted
        /// </summary>
        /// <remarks>
        ///     Tests that entities can be deleted and become no longer alive.
        /// </remarks>
        [Fact]
        public void Entity_CanBeDeleted()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 0, Y = 0 });

            // Act
            entity.Delete();

            // Assert
            Assert.False(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that entity count reflects entities in scene
        /// </summary>
        /// <remarks>
        ///     Validates that the scene entity count is accurate.
        /// </remarks>
        [Fact]
        public void Scene_EntityCountIsAccurate()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            int initialCount = scene.EntityCount;
            scene.Create(new Position { X = 0, Y = 0 });
            int afterCreate = scene.EntityCount;
            
            GameObject entity = scene.Create(new Position { X = 1, Y = 1 });
            int afterSecond = scene.EntityCount;
            
            entity.Delete();
            int afterDelete = scene.EntityCount;

            // Assert
            Assert.Equal(0, initialCount);
            Assert.Equal(1, afterCreate);
            Assert.Equal(2, afterSecond);
            Assert.Equal(1, afterDelete);
        }

        /// <summary>
        ///     Tests that null entity is null
        /// </summary>
        /// <remarks>
        ///     Validates that the default entity is null.
        /// </remarks>
        [Fact]
        public void Entity_DefaultIsNull()
        {
            // Act
            GameObject entity = default;

            // Assert
            Assert.True(entity.IsNull);
            Assert.False(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that entity IDs are unique
        /// </summary>
        /// <remarks>
        ///     Validates that each entity receives a unique ID.
        /// </remarks>
        [Fact]
        public void Entity_IdsAreUnique()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity1 = scene.Create(new Position { X = 0, Y = 0 });
            GameObject entity2 = scene.Create(new Position { X = 1, Y = 1 });

            // Assert
            Assert.NotEqual(entity1.EntityID, entity2.EntityID);
        }

        /// <summary>
        ///     Tests that multiple entities with same components work
        /// </summary>
        /// <remarks>
        ///     Validates that multiple entities with identical components
        ///     are handled correctly.
        /// </remarks>
        [Fact]
        public void Scene_CanHaveMultipleEntitiesWithSameComponents()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity1 = scene.Create(new Position { X = 0, Y = 0 });
            GameObject entity2 = scene.Create(new Position { X = 1, Y = 1 });
            GameObject entity3 = scene.Create(new Position { X = 2, Y = 2 });

            // Assert
            Assert.Equal(3, scene.EntityCount);
            Assert.True(entity1.Has<Position>());
            Assert.True(entity2.Has<Position>());
            Assert.True(entity3.Has<Position>());
        }

        /// <summary>
        ///     Tests that bulk entity creation works
        /// </summary>
        /// <remarks>
        ///     Tests that many entities can be created efficiently.
        /// </remarks>
        [Fact]
        public void Scene_CanCreateManyEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            const int count = 100;

            // Act
            for (int i = 0; i < count; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }

            // Assert
            Assert.Equal(count, scene.EntityCount);
        }
    }
}

