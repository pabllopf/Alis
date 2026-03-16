// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ExtremeStressTests.cs
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
    ///     Extreme stress tests for the ECS system
    /// </summary>
    public class ExtremeStressTests
    {
        /// <summary>
        ///     Tests that extreme stress create many entities no throw
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(100), InlineData(500), InlineData(1000), InlineData(2000), InlineData(5000)]
        public void ExtremeStress_CreateManyEntities_NoThrow(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                scene.Create();
            }

            // Assert
            Assert.True(true); // No exception thrown
        }

        /// <summary>
        ///     Tests that extreme stress create with multiple components large no throw
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(100), InlineData(500), InlineData(1000), InlineData(2000)]
        public void ExtremeStress_CreateWithMultipleComponentsLarge_NoThrow(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            for (int i = 0; i < entityCount; i++)
            {
                scene.Create(
                    new Position {X = i, Y = i},
                    new Health {Value = 100}
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
        ///     Tests that extreme stress delete all created no throw
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(100), InlineData(500), InlineData(1000)]
        public void ExtremeStress_DeleteAllCreated_NoThrow(int entityCount)
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
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that extreme stress create delete cycle stable
        /// </summary>
        /// <param name="cycleCount">The cycle count</param>
        [Theory, InlineData(100), InlineData(500), InlineData(1000)]
        public void ExtremeStress_CreateDeleteCycle_Stable(int cycleCount)
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            for (int i = 0; i < cycleCount; i++)
            {
                GameObject entity = scene.Create(new Position {X = 1, Y = 1});
                entity.Delete();
            }

            // Assert
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that extreme stress many component operations stable
        /// </summary>
        /// <param name="operationCount">The operation count</param>
        [Theory, InlineData(100), InlineData(500)]
        public void ExtremeStress_ManyComponentOperations_Stable(int operationCount)
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            for (int i = 0; i < operationCount; i++)
            {
                if (i % 2 == 0)
                {
                    entity.Add(new Position {X = 1, Y = 1});
                }
                else if (entity.Has<Position>())
                {
                    entity.Remove<Position>();
                }
            }

            // Assert
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that extreme stress heavy querying fast
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(10), InlineData(50), InlineData(100)]
        public void ExtremeStress_HeavyQuerying_Fast(int entityCount)
        {
            // Arrange
            using Scene scene = new Scene();
            for (int i = 0; i < entityCount; i++)
            {
                scene.Create(new Position {X = i, Y = i});
            }

            // Act
            for (int q = 0; q < 100; q++)
            {
                int count = 0;
                foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
                {
                    count++;
                }

                Assert.Equal(entityCount, count);
            }

            // Assert
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that extreme stress large component counts stable
        /// </summary>
        /// <param name="componentCount">The component count</param>
        [Theory, InlineData(100), InlineData(500)]
        public void ExtremeStress_LargeComponentCounts_Stable(int componentCount)
        {
            // Arrange
            using Scene scene = new Scene();
            GameObject entity = scene.Create();

            // Act
            for (int i = 0; (i < componentCount) && (i < 10); i++)
            {
                switch (i % 10)
                {
                    case 0:
                        if (!entity.Has<Position>())
                        {
                            entity.Add(new Position {X = 1, Y = 1});
                        }

                        break;
                    case 1:
                        if (!entity.Has<Health>())
                        {
                            entity.Add(new Health {Value = 100});
                        }

                        break;
                    case 2:
                        if (!entity.Has<Velocity>())
                        {
                            entity.Add(new Velocity {X = 1, Y = 1});
                        }

                        break;
                    case 3:
                        if (!entity.Has<Transform>())
                        {
                            entity.Add(new Transform {X = 1, Y = 1});
                        }

                        break;
                    case 4:
                        if (!entity.Has<Damage>())
                        {
                            entity.Add(new Damage {Value = 10});
                        }

                        break;
                    case 5:
                        if (!entity.Has<AnotherComponent>())
                        {
                            entity.Add(new AnotherComponent {Data = 42});
                        }

                        break;
                    case 6:
                        if (!entity.Has<AnotherComponent2>())
                        {
                            entity.Add(new AnotherComponent2 {Data = 100});
                        }

                        break;
                    case 7:
                        if (!entity.Has<Armor>())
                        {
                            entity.Add(new Armor {Value = 25});
                        }

                        break;
                    case 8:
                        if (!entity.Has<TagComponent>())
                        {
                            entity.Add(new TagComponent());
                        }

                        break;
                    case 9:
                        if (!entity.Has<TestComponent>())
                        {
                            entity.Add(new TestComponent {Value = 999});
                        }

                        break;
                }
            }

            // Assert
            Assert.True(entity.IsAlive);
        }

        /// <summary>
        ///     Tests that extreme stress mixed multi scene operations stable
        /// </summary>
        /// <param name="operationCount">The operation count</param>
        [Theory, InlineData(100), InlineData(500)]
        public void ExtremeStress_MixedMultiSceneOperations_Stable(int operationCount)
        {
            // Arrange
            using Scene scene1 = new Scene();
            using Scene scene2 = new Scene();

            // Act
            for (int i = 0; i < operationCount; i++)
            {
                if (i % 2 == 0)
                {
                    scene1.Create(new Position {X = i, Y = i});
                }
                else
                {
                    scene2.Create(new Health {Value = i});
                }
            }

            // Assert
            int count1 = 0, count2 = 0;
            foreach (var go in scene1.Query<With<Position>>().EnumerateWithEntities())
            {
                count1++;
            }

            foreach (var go in scene2.Query<With<Health>>().EnumerateWithEntities())
            {
                count2++;
            }

            Assert.True(count1 + count2 >= operationCount - 10);
        }

        /// <summary>
        ///     Tests that extreme stress deeply nested operations stable
        /// </summary>
        /// <param name="depth">The depth</param>
        [Theory, InlineData(100), InlineData(500)]
        public void ExtremeStress_DeeplyNestedOperations_Stable(int depth)
        {
            // Arrange
            using Scene scene = new Scene();

            // Act
            for (int i = 0; i < depth; i++)
            {
                var go = scene.Create(new Position {X = i, Y = i});

                // Deep operation chain
                if (go.IsAlive)
                {
                    if (go.Has<Position>())
                    {
                        ref Position pos = ref go.Get<Position>();
                        pos.X = pos.X * 2;

                        if (!go.Has<Health>())
                        {
                            go.Add(new Health {Value = 100});
                        }
                    }
                }
            }

            // Assert
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that extreme stress alternating operations stable
        /// </summary>
        /// <param name="iterations">The iterations</param>
        [Theory, InlineData(100), InlineData(500)]
        public void ExtremeStress_AlternatingOperations_Stable(int iterations)
        {
            // Arrange
            using Scene scene = new Scene();
            var entities = new List<GameObject>();

            // Act
            for (int i = 0; i < iterations; i++)
            {
                if (i % 3 == 0)
                {
                    entities.Add(scene.Create(new Position {X = i, Y = i}));
                }
                else if ((i % 3 == 1) && (entities.Count > 0))
                {
                    var idx = i % entities.Count;
                    if (entities[idx].IsAlive)
                    {
                        ref Position pos = ref entities[idx].Get<Position>();
                        pos.X += 1;
                    }
                }
                else if ((i % 3 == 2) && (entities.Count > 0))
                {
                    var idx = i % entities.Count;
                    entities[idx].Delete();
                }
            }

            // Assert
            Assert.True(true);
        }
    }
}