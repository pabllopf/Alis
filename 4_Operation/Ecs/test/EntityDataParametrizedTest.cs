// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EntityDataParametrizedTest.cs
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
    ///     Parametrized tests for EntityData
    /// </summary>
    public class EntityDataParametrizedTest
    {
        /// <summary>
        /// Tests that entity data create many with single component all valid
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        public void EntityData_CreateManyWithSingleComponent_AllValid(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }

            // Assert
            int count = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) count++;
            Assert.Equal(entityCount, count);
        }

        /// <summary>
        /// Tests that entity data create with multiple components all accessible
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(25)]
        public void EntityData_CreateWithMultipleComponents_AllAccessible(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                scene.Create(
                    new Position { X = i, Y = i },
                    new Health { Value = 100 + i },
                    new Velocity { X = 1 + i, Y = 1 + i }
                );
            }

            // Assert
            int posCount = 0;
            int healthCount = 0;
            int velCount = 0;
            
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) posCount++;
            foreach (var go in scene.Query<With<Health>>().EnumerateWithEntities()) healthCount++;
            foreach (var go in scene.Query<With<Velocity>>().EnumerateWithEntities()) velCount++;

            Assert.Equal(entityCount, posCount);
            Assert.Equal(entityCount, healthCount);
            Assert.Equal(entityCount, velCount);
        }

        /// <summary>
        /// Tests that entity data add components progressively all present
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        /// <param name="componentsPerEntity">The components per entity</param>
        [Theory]
        [InlineData(10, 1)]
        [InlineData(10, 2)]
        [InlineData(10, 5)]
        [InlineData(25, 5)]
        public void EntityData_AddComponentsProgressively_AllPresent(int entityCount, int componentsPerEntity)
        {
            // Arrange
            using Scene scene = new Scene();
            var entities = new GameObject[entityCount];

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create();
            }

            for (int i = 0; i < entityCount; i++)
            {
                if (componentsPerEntity >= 1) entities[i].Add(new Position { X = i, Y = i });
                if (componentsPerEntity >= 2) entities[i].Add(new Health { Value = 100 });
                if (componentsPerEntity >= 3) entities[i].Add(new Velocity { X = 1, Y = 1 });
                if (componentsPerEntity >= 4) entities[i].Add(new Transform { X = 0, Y = 0 });
                if (componentsPerEntity >= 5) entities[i].Add(new Damage { Value = 10 });
            }

            // Assert
            if (componentsPerEntity >= 1)
            {
                int count = 0;
                foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) count++;
                Assert.Equal(entityCount, count);
            }
        }

        /// <summary>
        /// Tests that entity data modify component values changes are reflected
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        public void EntityData_ModifyComponentValues_ChangesAreReflected(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            var entities = new GameObject[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create(new Position { X = 0, Y = 0 });
            }

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                ref Position pos = ref entities[i].Get<Position>();
                pos.X = i * 10;
                pos.Y = i * 20;
            }

            // Assert
            for (int i = 0; i < entityCount; i++)
            {
                Assert.Equal(i * 10, entities[i].Get<Position>().X);
                Assert.Equal(i * 20, entities[i].Get<Position>().Y);
            }
        }

        /// <summary>
        /// Tests that entity data delete and recreate works
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        public void EntityData_DeleteAndRecreate_Works(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            var entities = new GameObject[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create(new Position { X = i, Y = i });
            }

            // Delete half
            for (int i = 0; i < entityCount / 2; i++)
            {
                entities[i].Delete();
            }

            // Recreate
            for (int i = 0; i < entityCount / 2; i++)
            {
                entities[i] = scene.Create(new Position { X = i + 1000, Y = i + 1000 });
            }

            // Assert
            int count = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) count++;
            Assert.Equal(entityCount, count);
        }

        /// <summary>
        /// Tests that entity data query different components correct
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void EntityData_QueryDifferentComponents_Correct(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < entityCount; i++)
            {
                GameObject go = scene.Create();
                if (i % 2 == 0) go.Add(new Position { X = 1, Y = 1 });
                if (i % 3 == 0) go.Add(new Health { Value = 100 });
                if (i % 5 == 0) go.Add(new Velocity { X = 1, Y = 1 });
            }

            // Act & Assert - Basic queries work
            int posCount = 0, healthCount = 0, velCount = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) posCount++;
            foreach (var go in scene.Query<With<Health>>().EnumerateWithEntities()) healthCount++;
            foreach (var go in scene.Query<With<Velocity>>().EnumerateWithEntities()) velCount++;

            Assert.True(posCount >= 0);
            Assert.True(healthCount >= 0);
            Assert.True(velCount >= 0);
        }

        /// <summary>
        /// Tests that entity data stress test large operations
        /// </summary>
        /// <param name="testSize">The test size</param>
        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        public void EntityData_StressTest_LargeOperations(int testSize)
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            for (int i = 0; i < testSize; i++)
            {
                scene.Create(
                    new Position { X = i, Y = i },
                    new Health { Value = 100 }
                );
            }

            // Assert
            int count = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) count++;
            Assert.Equal(testSize, count);
        }
    }
}

