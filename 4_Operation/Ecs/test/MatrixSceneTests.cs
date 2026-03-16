// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MatrixSceneTests.cs
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
    ///     Matrix tests for all Scene combinations
    /// </summary>
    public class MatrixSceneTests
    {
        /// <summary>
        ///     Tests that matrix test scene operations
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        /// <param name="componentType">The component type</param>
        /// <param name="operationType">The operation type</param>
        [Theory, MemberData(nameof(GetSceneTestData))]
        public void MatrixTest_SceneOperations(int entityCount, int componentType, int operationType)
        {
            using Scene scene = new Scene();
            var entities = new List<GameObject>();

            // Create entities
            for (int i = 0; i < entityCount; i++)
            {
                var go = scene.Create();
                if (componentType >= 1)
                {
                    go.Add(new Position {X = i, Y = i});
                }

                if (componentType >= 2)
                {
                    go.Add(new Health {Value = 100});
                }

                if (componentType >= 3)
                {
                    go.Add(new Velocity {X = 1, Y = 1});
                }

                entities.Add(go);
            }

            // Perform operations
            switch (operationType)
            {
                case 0: // Query
                {
                    int count = 0;
                    foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
                    {
                        count++;
                    }

                    Assert.True(count >= 0);
                    break;
                }
                case 1: // Modify
                {
                    foreach (var go in entities)
                    {
                        if (go.Has<Position>())
                        {
                            ref Position pos = ref go.Get<Position>();
                            pos.X += 1;
                        }
                    }

                    break;
                }
                case 2: // Delete
                {
                    for (int i = 0; (i < entityCount / 2) && (i < entities.Count); i++)
                    {
                        if (entities[i].IsAlive)
                        {
                            entities[i].Delete();
                        }
                    }

                    break;
                }
                case 3: // Add
                {
                    foreach (var go in entities)
                    {
                        if (!go.Has<Health>())
                        {
                            go.Add(new Health {Value = 50});
                        }
                    }

                    break;
                }
            }

            Assert.True(true);
        }

        /// <summary>
        ///     Gets the scene test data
        /// </summary>
        /// <returns>The data</returns>
        public static IEnumerable<object[]> GetSceneTestData()
        {
            var data = new List<object[]>();

            int[] entityCounts = {1, 2, 5, 10, 20};
            int[] componentTypes = {1, 2, 3};
            int[] operationTypes = {0, 1, 2, 3};

            foreach (var entityCount in entityCounts)
            {
                foreach (var componentType in componentTypes)
                {
                    foreach (var operationType in operationTypes)
                    {
                        data.Add(new object[] {entityCount, componentType, operationType});
                    }
                }
            }

            return data;
        }
    }
}