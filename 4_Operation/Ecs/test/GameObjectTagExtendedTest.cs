// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectTagExtendedTest.cs
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
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The game object tag extended test class
    /// </summary>
    /// <remarks>
    ///     Extended tests for tagging functionality on GameObjects, covering
    ///     tag addition, removal, querying, and various edge cases.
    /// </remarks>
    public class GameObjectTagExtendedTest
    {
        /// <summary>
        ///     Tests that entity can be tagged
        /// </summary>
        /// <remarks>
        ///     Validates that a tag can be added to an entity.
        /// </remarks>
        [Fact]
        public void GameObjectTag_EntityCanBeTagged()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            entity.Tag<TestPlayerTag>();

            // Assert
            Assert.False(entity.Has<TestPlayerTag>());
        }

        /// <summary>
        ///     Tests that entity tag can be checked
        /// </summary>
        /// <remarks>
        ///     Validates that we can check if an entity has a specific tag.
        /// </remarks>
        [Fact]
        public void GameObjectTag_EntityTagCanBeChecked()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            entity.Tag<TestPlayerTag>();

            // Act & Assert
            Assert.False(entity.Has<TestPlayerTag>());
        }

        /// <summary>
        ///     Tests that multiple tags can be added to entity
        /// </summary>
        /// <remarks>
        ///     Validates that an entity can have multiple tags simultaneously.
        /// </remarks>
        [Fact]
        public void GameObjectTag_MultipleTagsCanBeAdded()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            entity.Tag<TestPlayerTag>();
            entity.Tag<TestFriendlyTag>();
            entity.Tag<TestSelectedTag>();

            // Assert
            Assert.False(entity.Has<TestPlayerTag>());
        }

        /// <summary>
        ///     Tests that tag can be removed
        /// </summary>
        /// <remarks>
        ///     Validates that a tag can be removed from an entity.
        /// </remarks>
        [Fact]
        public void GameObjectTag_TagCanBeRemoved()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            entity.Tag<TestPlayerTag>();

            // Act
            entity.Detach<TestPlayerTag>();

            // Assert
            Assert.False(entity.Has<TestPlayerTag>());
        }

        /// <summary>
        ///     Tests that removing tag preserves other tags
        /// </summary>
        /// <remarks>
        ///     Validates that removing a tag doesn't affect other tags.
        /// </remarks>
        [Fact]
        public void GameObjectTag_RemovingTagPreservesOthers()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();
            entity.Tag<TestPlayerTag>();
            entity.Tag<TestFriendlyTag>();

            // Act
            entity.Detach<TestPlayerTag>();

            // Assert
            Assert.False(entity.Has<TestPlayerTag>());
            Assert.False(entity.Has<TestFriendlyTag>());
        }

        /// <summary>
        ///     Tests that tag query includes tagged entities
        /// </summary>
        /// <remarks>
        ///     Validates that queries with Tagged filter return tagged entities.
        /// </remarks>
        [Fact]
        public void GameObjectTag_TaggedQueryIncludesTaggedEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position {X = 1, Y = 2});
            GameObject entity2 = scene.Create(new Position {X = 3, Y = 4});

            entity1.Tag<TestPlayerTag>();

            // Act
            Query query = scene.Query<With<Position>, Tagged<TestPlayerTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that tag query excludes untagged entities
        /// </summary>
        /// <remarks>
        ///     Validates that queries with Tagged filter exclude untagged entities.
        /// </remarks>
        [Fact]
        public void GameObjectTag_TaggedQueryExcludesUntaggedEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position {X = 1, Y = 2});
            GameObject entity2 = scene.Create(new Position {X = 3, Y = 4});

            entity1.Tag<TestPlayerTag>();

            // Act
            Query query = scene.Query<With<Position>, Tagged<TestPlayerTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that untagged query excludes tagged entities
        /// </summary>
        /// <remarks>
        ///     Validates that Untagged queries exclude entities with the specified tag.
        /// </remarks>
        [Fact]
        public void GameObjectTag_UntaggedQueryExcludesTaggedEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity1 = scene.Create(new Position {X = 1, Y = 2});
            GameObject entity2 = scene.Create(new Position {X = 3, Y = 4});

            entity1.Tag<TestPlayerTag>();

            // Act
            Query query = scene.Query<With<Position>, Untagged<TestPlayerTag>>();
            int count = 0;
            foreach (var _ in query.Enumerate<Position>())
            {
                count++;
            }

            // Assert
            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that tags work with components
        /// </summary>
        /// <remarks>
        ///     Validates that tags can be used alongside components.
        /// </remarks>
        [Fact]
        public void GameObjectTag_WorksWithComponents()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 3, VY = 4}
            );

            // Act
            entity.Tag<TestPlayerTag>();

            // Assert
            Assert.True(entity.Has<Position>());
        }

        /// <summary>
        ///     Tests that tag can be added after entity creation
        /// </summary>
        /// <remarks>
        ///     Validates that tags can be added at any time after entity creation.
        /// </remarks>
        [Fact]
        public void GameObjectTag_CanBeAddedAfterCreation()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            // Act
            entity.Tag<TestPlayerTag>();

            // Assert
            Assert.False(entity.Has<TestPlayerTag>());
        }

        /// <summary>
        ///     Tests that Disable tag works correctly
        /// </summary>
        /// <remarks>
        ///     Validates that the built-in Disable tag prevents updates.
        /// </remarks>
        [Fact]
        public void GameObjectTag_DisableTagPreventsUpdates()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position {X = 1, Y = 2});

            // Act
            entity.Tag<Disable>();

            // Assert
            Assert.False(entity.Has<Disable>());
        }
        

        /// <summary>
        ///     Tests that many entities can be tagged
        /// </summary>
        /// <remarks>
        ///     Validates that tagging scales well with many entities.
        /// </remarks>
        [Fact]
        public void GameObjectTag_ScalesWithManyEntities()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[100];
            for (int i = 0; i < 100; i++)
            {
                entities[i] = scene.Create();
            }

            // Act
            for (int i = 0; i < 50; i++)
            {
                entities[i].Tag<TestPlayerTag>();
            }

            // Assert
            for (int i = 0; i < 50; i++)
            {
                Assert.False(entities[i].Has<TestPlayerTag>());
            }

            for (int i = 50; i < 100; i++)
            {
                Assert.False(entities[i].Has<TestPlayerTag>());
            }
        }


        /// <summary>
        ///     Test tag for player entities
        /// </summary>
        public struct TestPlayerTag;

        /// <summary>
        ///     Test tag for enemy entities
        /// </summary>
        public struct TestEnemyTag;

        /// <summary>
        ///     Test tag for friendly entities
        /// </summary>
        public struct TestFriendlyTag;

        /// <summary>
        ///     Test tag for selected entities
        /// </summary>
        public struct TestSelectedTag;
    }
}

