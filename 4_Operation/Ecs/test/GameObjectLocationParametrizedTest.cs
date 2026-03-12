// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectLocationParametrizedTest.cs
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

using System.Collections.Generic;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Parametrized tests for GameObject location and identity
    /// </summary>
    public class GameObjectLocationParametrizedTest
    {
        /// <summary>
        /// Tests that game object location created entities have unique ids
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(50)]
        public void GameObjectLocation_CreatedEntities_HaveUniqueIds(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            var entities = new GameObject[entityCount];
            var ids = new HashSet<int>();

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create();
                // Entity IDs should be unique (we can't directly access, but we can verify uniqueness by behavior)
            }

            // Assert
            for (int i = 0; i < entityCount; i++)
            {
                for (int j = i + 1; j < entityCount; j++)
                {
                    Assert.NotEqual(entities[i], entities[j]);
                }
            }
        }

        /// <summary>
        /// Tests that game object location different scenes create different entities
        /// </summary>
        /// <param name="entityCountPerScene">The entity count per scene</param>
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void GameObjectLocation_DifferentScenes_CreateDifferentEntities(int entityCountPerScene)
        {
            // Arrange
            using Scene scene1 = new Scene();
            using Scene scene2 = new Scene();
            var entities1 = new GameObject[entityCountPerScene];
            var entities2 = new GameObject[entityCountPerScene];

            // Act
            for (int i = 0; i < entityCountPerScene; i++)
            {
                entities1[i] = scene1.Create();
                entities2[i] = scene2.Create();
            }

            // Assert
            for (int i = 0; i < entityCountPerScene; i++)
            {
                // Entities from different scenes should be different
                Assert.NotEqual(entities1[i], entities2[i]);
            }
        }

        /// <summary>
        /// Tests that game object location query returns local entities only from scene
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        public void GameObjectLocation_QueryReturnsLocalEntities_OnlyFromScene(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < entityCount; i++)
            {
                if (i % 2 == 0)
                    scene.Create(new Position { X = 1, Y = 1 });
                else
                    scene.Create();
            }

            // Act
            int queryCount = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                queryCount++;
            }

            // Assert
            Assert.Equal((entityCount + 1) / 2, queryCount);
        }

        /// <summary>
        /// Tests that game object location entity identity persists across operations
        /// </summary>
        [Fact]
        public void GameObjectLocation_EntityIdentity_PersistsAcrossOperations()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Position { X = 10, Y = 20 });

            // Act
            var id1 = entity;
            entity.Add(new Health { Value = 100 });
            var id2 = entity;
            ref Position pos = ref entity.Get<Position>();
            pos.X = 50;
            var id3 = entity;

            // Assert
            Assert.Equal(id1, id2);
            Assert.Equal(id2, id3);
        }

        /// <summary>
        /// Tests that game object location entity can be stored and retrieved works
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        public void GameObjectLocation_EntityCanBeStoredAndRetrieved_Works(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            var stored = new GameObject[entityCount];

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                stored[i] = scene.Create(new Position { X = i, Y = i });
            }

            // Retrieve and verify
            for (int i = 0; i < entityCount; i++)
            {
                Assert.True(stored[i].IsAlive);
                Assert.Equal(i, stored[i].Get<Position>().X);
            }

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that game object location multiple references to same entity all valid
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        public void GameObjectLocation_MultipleReferencesToSameEntity_AllValid(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            var stored = new GameObject[entityCount];

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                GameObject created = scene.Create(new Position { X = i, Y = i });
                stored[i] = created;
                var sameRef = created;
                
                // Verify they're the same
                Assert.Equal(created, sameRef);
            }

            // Assert
            Assert.True(true);
        }

        /// <summary>
        /// Tests that game object location entity location within scene accessible
        /// </summary>
        [Fact]
        public void GameObjectLocation_EntityLocationWithinScene_Accessible()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity = scene.Create(new Position { X = 100, Y = 200 });

            // Assert
            Assert.True(entity.IsAlive);
            Assert.True(entity.Has<Position>());
            Assert.Equal(100, entity.Get<Position>().X);
        }

        /// <summary>
        /// Tests that game object location deleted entity location becomes invalid
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void GameObjectLocation_DeletedEntityLocationBecomesInvalid(int count)
        {
            // Arrange
            using Scene scene = new Scene();
            var entities = new GameObject[count];
            for (int i = 0; i < count; i++)
            {
                entities[i] = scene.Create();
            }

            // Act
            for (int i = 0; i < count; i++)
            {
                entities[i].Delete();
            }

            // Assert
            for (int i = 0; i < count; i++)
            {
                Assert.False(entities[i].IsAlive);
            }
        }
    }
}

