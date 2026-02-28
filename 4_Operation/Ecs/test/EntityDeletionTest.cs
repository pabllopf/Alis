// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityDeletionTest.cs
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
    ///     Tests for entity deletion and lifecycle
    /// </summary>
    /// <remarks>
    ///     Validates that entities can be deleted and that queries
    ///     correctly reflect deletions.
    /// </remarks>
    public class EntityDeletionTest
    {
        /// <summary>
        ///     Tests that entity can be deleted
        /// </summary>
        [Fact]
        public void GameObject_CanBeDeleted()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10 });
            Assert.True(entity.IsAlive);

            // Act
            int entityDeletedCount = 0;
            scene.EntityDeleted += _ => entityDeletedCount++;
            entity.Delete();

            // Assert
            Assert.False(entity.IsAlive);
            Assert.Equal(1, entityDeletedCount);
        }

        /// <summary>
        ///     Tests that deleted entity is not in queries
        /// </summary>
        [Fact]
        public void Query_ExcludesDeletedEntities()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1 });
            GameObject entity2 = scene.Create(new Position { X = 2 });
            GameObject entity3 = scene.Create(new Position { X = 3 });

            // Act
            entity2.Delete();

            // Assert
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position>())
                count++;

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests deleting multiple entities
        /// </summary>
        [Fact]
        public void Scene_CanDeleteMultipleEntities()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity1 = scene.Create(new Position { X = 1 });
            GameObject entity2 = scene.Create(new Position { X = 2 });
            GameObject entity3 = scene.Create(new Position { X = 3 });
            GameObject entity4 = scene.Create(new Position { X = 4 });

            // Act
            entity1.Delete();
            entity3.Delete();

            // Assert
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position>())
                count++;

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests entity deleted event fires
        /// </summary>
        [Fact]
        public void Scene_EntityDeletedEventFires()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create(new Position());
            int eventCount = 0;

            scene.EntityDeleted += _ => eventCount++;

            // Act
            entity.Delete();

            // Assert
            Assert.Equal(1, eventCount);
        }

        /// <summary>
        ///     Tests that deleted entity raises event with correct entity
        /// </summary>
        [Fact]
        public void Scene_EntityDeletedEventIncludesCorrectEntity()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity = scene.Create(new Position());
            GameObject deletedEntity = default;

            scene.EntityDeleted += go => deletedEntity = go;

            // Act
            entity.Delete();

            // Assert
            Assert.Equal(entity.EntityID, deletedEntity.EntityID);
        }

        /// <summary>
        ///     Tests that all entities can be deleted
        /// </summary>
        [Fact]
        public void Scene_CanDeleteAllEntities()
        {
            // Arrange
            using var scene = new Scene();
            GameObject entity1 = scene.Create(new Position());
            GameObject entity2 = scene.Create(new Position());
            GameObject entity3 = scene.Create(new Position());

            // Act
            entity1.Delete();
            entity2.Delete();
            entity3.Delete();

            // Assert
            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position>())
                count++;

            Assert.Equal(0, count);
        }
    }
}

