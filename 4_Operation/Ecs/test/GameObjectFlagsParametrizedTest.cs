// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectFlagsParametrizedTest.cs
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

using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Parametrized tests for GameObject flags and state management
    /// </summary>
    public class GameObjectFlagsParametrizedTest
    {
        /// <summary>
        ///     Tests that game object flags new entity is alive
        /// </summary>
        [Fact]
        public void GameObjectFlags_NewEntity_IsAlive()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity = scene.Create();

            // Assert
            Assert.True(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that game object flags new entity is not null
        /// </summary>
        [Fact]
        public void GameObjectFlags_NewEntity_IsNotNull()
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            GameObject entity = scene.Create();

            // Assert
            Assert.False(entity.IsNull);
        }

        /// <summary>
        ///     Tests that game object flags deleted entity is not alive
        /// </summary>
        [Fact]
        public void GameObjectFlags_DeletedEntity_IsNotAlive()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            entity.Delete();

            // Assert
            Assert.False(entity.IsAlive);
        }


        /// <summary>
        ///     Tests that game object flags multiple entities alive all are alive
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10)]
        public void GameObjectFlags_MultipleEntitiesAlive_AllAreAlive(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            var entities = new GameObject[entityCount];

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create();
            }

            // Assert
            for (int i = 0; i < entityCount; i++)
            {
                Assert.True(entities[i].IsAlive);
                Assert.False(entities[i].IsNull);
            }
        }

        /// <summary>
        ///     Tests that game object flags delete multiple entities all are null
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10)]
        public void GameObjectFlags_DeleteMultipleEntities_AllAreNull(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            var entities = new GameObject[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create();
            }

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                entities[i].Delete();
            }

            // Assert
            for (int i = 0; i < entityCount; i++)
            {
                Assert.False(entities[i].IsNull);
            }
        }

        /// <summary>
        ///     Tests that game object flags null constant is null
        /// </summary>
        [Fact]
        public void GameObjectFlags_NullConstant_IsNull()
        {
            // Arrange & Act
            GameObject nullEntity = GameObject.Null;

            // Assert
            Assert.True(nullEntity.IsNull);
            Assert.False(nullEntity.IsAlive);
        }

        /// <summary>
        ///     Tests that game object flags default game object is null
        /// </summary>
        [Fact]
        public void GameObjectFlags_DefaultGameObject_IsNull()
        {
            // Arrange & Act
            GameObject defaultEntity = new GameObject();

            // Assert
            Assert.True(defaultEntity.IsNull);
        }

        /// <summary>
        ///     Tests that game object flags flags consistent after component operations
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(10), InlineData(50)]
        public void GameObjectFlags_FlagsConsistent_AfterComponentOperations(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            var entities = new GameObject[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create();
            }

            // Act - Add components
            for (int i = 0; i < entityCount; i++)
            {
                entities[i].Add(new Position {X = 1, Y = 1});
            }

            // Assert
            for (int i = 0; i < entityCount; i++)
            {
                Assert.True(entities[i].IsAlive);
                Assert.False(entities[i].IsNull);
            }
        }

        /// <summary>
        ///     Tests that game object flags delete partially and check works
        /// </summary>
        /// <param name="totalCount">The total count</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10)]
        public void GameObjectFlags_DeletePartiallyAndCheck_Works(int totalCount)
        {
            // Arrange
            using Scene scene = new Scene();
            var entities = new GameObject[totalCount];
            for (int i = 0; i < totalCount; i++)
            {
                entities[i] = scene.Create();
            }

            // Act
            for (int i = 0; i < totalCount / 2; i++)
            {
                entities[i].Delete();
            }

            // Assert
            for (int i = 0; i < totalCount / 2; i++)
            {
                Assert.False(entities[i].IsAlive);
            }

            for (int i = totalCount / 2; i < totalCount; i++)
            {
                Assert.True(entities[i].IsAlive);
            }
        }

        /// <summary>
        ///     Tests that game object flags compare deleted with null both not alive
        /// </summary>
        [Fact]
        public void GameObjectFlags_CompareDeletedWithNull_BothNotAlive()
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject created = scene.Create();
            GameObject nullGo = GameObject.Null;

            // Act
            created.Delete();

            // Assert
            Assert.False(created.IsAlive);
            Assert.False(nullGo.IsAlive);
        }

        /// <summary>
        ///     Tests that game object flags stress test many creates and deletes
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(10), InlineData(50)]
        public void GameObjectFlags_StressTest_ManyCreatesAndDeletes(int count)
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            for (int i = 0; i < count; i++)
            {
                GameObject entity = scene.Create();
                Assert.True(entity.IsAlive);
                entity.Delete();
                Assert.False(entity.IsAlive);
            }

            // Assert
            Assert.True(true);
        }
    }
}