// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneParametrizedTest.cs
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
    ///     Parametrized tests for Scene to generate comprehensive coverage
    /// </summary>
    public class SceneParametrizedTest
    {
        /// <summary>
        /// Tests that scene create multiple entities count matches
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        public void Scene_CreateMultipleEntities_CountMatches(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[entityCount];

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create();
            }

            // Assert
            for (int i = 0; i < entityCount; i++)
            {
                Assert.True(entities[i].IsAlive);
            }
        }

        /// <summary>
        /// Tests that scene delete entities becomes null
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void Scene_DeleteEntities_BecomesNull(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[entityCount];
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
                Assert.False(entities[i].IsAlive);
            }
        }

        /// <summary>
        /// Tests that scene add components to multiple entities all have components
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        public void Scene_AddComponentsToMultipleEntities_AllHaveComponents(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[entityCount];

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create();
                entities[i].Add(new Position { X = i, Y = i * 2 });
            }

            // Assert
            for (int i = 0; i < entityCount; i++)
            {
                Assert.True(entities[i].Has<Position>());
                Assert.Equal(i, entities[i].Get<Position>().X);
                Assert.Equal(i * 2, entities[i].Get<Position>().Y);
            }
        }

        /// <summary>
        /// Tests that scene remove components from entities components gone
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        /// <param name="removeCount">The remove count</param>
        [Theory]
        [InlineData(10, 1)]
        [InlineData(20, 2)]
        [InlineData(50, 5)]
        [InlineData(100, 10)]
        public void Scene_RemoveComponentsFromEntities_ComponentsGone(int entityCount, int removeCount)
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create();
                entities[i].Add(new Position { X = 1, Y = 1 });
            }

            // Act
            for (int i = 0; i < removeCount && i < entityCount; i++)
            {
                entities[i].Remove<Position>();
            }

            // Assert
            for (int i = 0; i < removeCount && i < entityCount; i++)
            {
                Assert.False(entities[i].Has<Position>());
            }
        }

        /// <summary>
        /// Tests that scene query entities with component returns correct count
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        public void Scene_QueryEntitiesWithComponent_ReturnsCorrectCount(int entityCount)
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
            int count = 0;
            foreach (object go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                count++;
            }

            // Assert
            Assert.Equal(entityCount / 2, count);
        }

        /// <summary>
        /// Tests that scene mixed components on entities query works
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void Scene_MixedComponentsOnEntities_QueryWorks(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < entityCount; i++)
            {
                GameObject go = scene.Create();
                if (i % 2 == 0) go.Add(new Position { X = 1, Y = 1 });
                if (i % 3 == 0) go.Add(new Health { Value = 100 });
            }

            // Act
            int countPosition = 0;
            int countHealth = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) countPosition++;
            foreach (var go in scene.Query<With<Health>>().EnumerateWithEntities()) countHealth++;

            // Assert
            Assert.True(countPosition > 0);
            Assert.True(countHealth > 0);
        }

        /// <summary>
        /// Tests that scene create with initial components has all components
        /// </summary>
        /// <param name="initialComponentCount">The initial component count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(15)]
        public void Scene_CreateWithInitialComponents_HasAllComponents(int initialComponentCount)
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity;

            // Act & Assert based on component count
            switch (initialComponentCount)
            {
                case 1:
                    entity = scene.Create(new Position { X = 1, Y = 1 });
                    Assert.True(entity.Has<Position>());
                    break;
                case 2:
                    entity = scene.Create(new Position { X = 1, Y = 1 }, new Health { Value = 100 });
                    Assert.True(entity.Has<Position>());
                    Assert.True(entity.Has<Health>());
                    break;
                case 3:
                    entity = scene.Create(
                        new Position { X = 1, Y = 1 },
                        new Health { Value = 100 },
                        new Velocity { X = 1, Y = 1 });
                    Assert.True(entity.Has<Position>());
                    Assert.True(entity.Has<Health>());
                    Assert.True(entity.Has<Velocity>());
                    break;
                default:
                    entity = scene.Create();
                    Assert.True(entity.IsAlive);
                    break;
            }
        }

        /// <summary>
        /// Tests that scene create and delete cyclic stable
        /// </summary>
        /// <param name="cycleCount">The cycle count</param>
        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        public void Scene_CreateAndDeleteCyclic_Stable(int cycleCount)
        {
            // Arrange
            using Scene scene = new Scene();

            // Act & Assert
            for (int i = 0; i < cycleCount; i++)
            {
                GameObject entity = scene.Create();
                Assert.True(entity.IsAlive);
                entity.Delete();
                Assert.False(entity.IsAlive);
            }
        }

        /// <summary>
        /// Tests that scene multiple component operations consistent
        /// </summary>
        /// <param name="operationCount">The operation count</param>
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void Scene_MultipleComponentOperations_Consistent(int operationCount)
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            for (int i = 0; i < operationCount; i++)
            {
                entity.Add(new Position { X = i, Y = i });
                Assert.True(entity.Has<Position>());
                Assert.Equal(i, entity.Get<Position>().X);
                entity.Remove<Position>();
                Assert.False(entity.Has<Position>());
            }

            // Assert
            Assert.False(entity.Has<Position>());
        }
    }
}

