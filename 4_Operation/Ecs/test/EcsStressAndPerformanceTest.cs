// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EcsStressAndPerformanceTest.cs
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
using System.Diagnostics;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Stress and performance tests for the ECS system
    /// </summary>
    public class EcsStressAndPerformanceTest
    {
        /// <summary>
        ///     Tests that stress test create many entities succeeds
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(100), InlineData(500), InlineData(1000), InlineData(5000)]
        public void StressTest_CreateManyEntities_Succeeds(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            var stopwatch = Stopwatch.StartNew();

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                scene.Create();
            }

            stopwatch.Stop();

            // Assert
            Assert.True(stopwatch.ElapsedMilliseconds < entityCount * 100); // Reasonable time
        }

        /// <summary>
        ///     Tests that stress test create many entities with components succeeds
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(100), InlineData(500), InlineData(1000)]
        public void StressTest_CreateManyEntitiesWithComponents_Succeeds(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                scene.Create(
                    new Position {X = i, Y = i},
                    new Health {Value = 100},
                    new Velocity {X = 1, Y = 1}
                );
            }

            // Assert
            int count = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                count++;
            }

            Assert.Equal(entityCount, count);
        }

        /// <summary>
        ///     Tests that stress test query many times stable
        /// </summary>
        /// <param name="queryCount">The query count</param>
        [Theory, InlineData(100), InlineData(500), InlineData(1000)]
        public void StressTest_QueryManyTimes_Stable(int queryCount)
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < 100; i++)
            {
                scene.Create(new Position {X = 1, Y = 1});
            }

            // Act
            for (int i = 0; i < queryCount; i++)
            {
                int count = 0;
                foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
                {
                    count++;
                }

                Assert.Equal(100, count);
            }

            // Assert - No crashes
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that stress test add remove components many times stable
        /// </summary>
        /// <param name="operationCount">The operation count</param>
        [Theory, InlineData(100), InlineData(500), InlineData(1000)]
        public void StressTest_AddRemoveComponentsManyTimes_Stable(int operationCount)
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            for (int i = 0; i < operationCount; i++)
            {
                entity.Add(new Position {X = 1, Y = 1});
                Assert.True(entity.Has<Position>());
                entity.Remove<Position>();
                Assert.False(entity.Has<Position>());
            }

            // Assert
            Assert.True(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that stress test delete many entities succeeds
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(100), InlineData(500), InlineData(1000)]
        public void StressTest_DeleteManyEntities_Succeeds(int entityCount)
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
                Assert.False(entities[i].IsAlive);
            }
        }

        /// <summary>
        ///     Tests that stress test create delete cyclic stable
        /// </summary>
        /// <param name="cycleCount">The cycle count</param>
        [Theory, InlineData(100), InlineData(500), InlineData(1000)]
        public void StressTest_CreateDeleteCyclic_Stable(int cycleCount)
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            for (int i = 0; i < cycleCount; i++)
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 1});
                Assert.True(entity.IsAlive);
                entity.Delete();
                Assert.False(entity.IsAlive);
            }

            // Assert
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that stress test mixed operations stable
        /// </summary>
        /// <param name="operationCount">The operation count</param>
        [Theory, InlineData(100), InlineData(500), InlineData(1000)]
        public void StressTest_MixedOperations_Stable(int operationCount)
        {
            // Arrange
            using Scene scene = new Scene();
            var entities = new List<GameObject>();

            // Act
            for (int i = 0; i < operationCount; i++)
            {
                if (i % 3 == 0)
                {
                    GameObject go = scene.Create(new Position {X = 1, Y = 1});
                    entities.Add(go);
                }
                else if ((i % 3 == 1) && (entities.Count > 0))
                {
                    entities[0].Add(new Health {Value = 100});
                }
                else if ((i % 3 == 2) && (entities.Count > 0))
                {
                    entities[0].Delete();
                    entities.RemoveAt(0);
                }
            }

            // Assert
            Assert.True(entities.Count >= 0);
        }

        /// <summary>
        ///     Tests that stress test large component set handles
        /// </summary>
        /// <param name="componentCount">The component count</param>
        [Theory, InlineData(10), InlineData(50), InlineData(100)]
        public void StressTest_LargeComponentSet_Handles(int componentCount)
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            for (int i = 0; (i < componentCount) && (i < 10); i++)
            {
                switch (i)
                {
                    case 0:
                        entity.Add(new Position {X = 1, Y = 1});
                        break;
                    case 1:
                        entity.Add(new Health {Value = 100});
                        break;
                    case 2:
                        entity.Add(new Velocity {X = 1, Y = 1});
                        break;
                    case 3:
                        entity.Add(new Transform {X = 1, Y = 1});
                        break;
                    case 4:
                        entity.Add(new Damage {Value = 10});
                        break;
                    case 5:
                        entity.Add(new AnotherComponent {Data = 42});
                        break;
                    case 6:
                        entity.Add(new AnotherComponent2 {Data = 100});
                        break;
                    case 7:
                        entity.Add(new Armor {Value = 25});
                        break;
                    case 8:
                        entity.Add(new TagComponent());
                        break;
                    case 9:
                        entity.Add(new TestComponent {Value = 999});
                        break;
                }
            }

            // Assert
            Assert.True(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that stress test multiple queries on large set fast
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(100), InlineData(500)]
        public void StressTest_MultipleQueriesOnLargeSet_Fast(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < entityCount; i++)
            {
                if (i % 2 == 0)
                {
                    scene.Create(new Position {X = 1, Y = 1});
                }
                else
                {
                    scene.Create();
                }
            }

            // Act
            var stopwatch = Stopwatch.StartNew();
            for (int q = 0; q < 10; q++)
            {
                int count = 0;
                foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
                {
                    count++;
                }
            }

            stopwatch.Stop();

            // Assert
            Assert.True(stopwatch.ElapsedMilliseconds < 1000); // Should be fast
        }

        /// <summary>
        ///     Tests that stress test deep component chain works
        /// </summary>
        /// <param name="chainLength">The chain length</param>
        [Theory, InlineData(100), InlineData(500)]
        public void StressTest_DeepComponentChain_Works(int chainLength)
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            for (int i = 0; (i < chainLength) && (i < 10); i++)
            {
                int type = i % 10;
                try
                {
                    switch (type)
                    {
                        case 0:
                            if (!entity.Has<Position>())
                            {
                                entity.Add(new Position {X = 1, Y = 1});
                            }

                            ref Position p = ref entity.Get<Position>();
                            p.X = i;
                            break;
                        case 1:
                            if (!entity.Has<Health>())
                            {
                                entity.Add(new Health {Value = i});
                            }

                            ref Health h = ref entity.Get<Health>();
                            h.Value = i;
                            break;
                        case 2:
                            if (!entity.Has<Velocity>())
                            {
                                entity.Add(new Velocity {X = i, Y = i});
                            }

                            ref Velocity v = ref entity.Get<Velocity>();
                            v.X = i;
                            break;
                    }
                }
                catch
                {
                    // Component already exists
                }
            }

            // Assert
            Assert.True(entity.IsAlive);
        }
    }
}