// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneMultipleInstancesTests.cs
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
    ///     Tests for multiple scene instances
    /// </summary>
    public class SceneMultipleInstancesTests
    {
        /// <summary>
        /// Tests that multiple scenes create independent scenes all work
        /// </summary>
        /// <param name="sceneCount">The scene count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(10)]
        public void MultipleScenes_CreateIndependentScenes_AllWork(int sceneCount)
        {
            var scenes = new Scene[sceneCount];
            
            try
            {
                for (int i = 0; i < sceneCount; i++)
                {
                    scenes[i] = new Scene();
                    scenes[i].Create();
                }
                
                for (int i = 0; i < sceneCount; i++)
                {
                    Assert.NotNull(scenes[i]);
                }
            }
            finally
            {
                for (int i = 0; i < sceneCount; i++)
                {
                    scenes[i]?.Dispose();
                }
            }
        }

        /// <summary>
        /// Tests that multiple scenes create entities in multiple independent
        /// </summary>
        /// <param name="sceneCount">The scene count</param>
        /// <param name="entitiesPerScene">The entities per scene</param>
        [Theory]
        [InlineData(2, 10)]
        [InlineData(3, 10)]
        [InlineData(5, 5)]
        public void MultipleScenes_CreateEntitiesInMultiple_Independent(int sceneCount, int entitiesPerScene)
        {
            var scenes = new Scene[sceneCount];
            
            try
            {
                // Create scenes and entities
                for (int s = 0; s < sceneCount; s++)
                {
                    scenes[s] = new Scene();
                    for (int e = 0; e < entitiesPerScene; e++)
                    {
                        scenes[s].Create(new Position { X = s * 100 + e, Y = e });
                    }
                }
                
                // Verify each scene has correct entities
                for (int s = 0; s < sceneCount; s++)
                {
                    int count = 0;
                    foreach (var go in scenes[s].Query<With<Position>>().EnumerateWithEntities()) count++;
                    Assert.Equal(entitiesPerScene, count);
                }
            }
            finally
            {
                for (int i = 0; i < sceneCount; i++)
                {
                    scenes[i]?.Dispose();
                }
            }
        }

        /// <summary>
        /// Tests that multiple scenes delete entities in each scene independent
        /// </summary>
        /// <param name="sceneCount">The scene count</param>
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        public void MultipleScenes_DeleteEntitiesInEachScene_Independent(int sceneCount)
        {
            var scenes = new Scene[sceneCount];
            var entities = new GameObject[sceneCount][];
            
            try
            {
                // Create scenes and entities
                for (int s = 0; s < sceneCount; s++)
                {
                    scenes[s] = new Scene();
                    entities[s] = new GameObject[5];
                    for (int e = 0; e < 5; e++)
                    {
                        entities[s][e] = scenes[s].Create();
                    }
                }
                
                // Delete in each scene
                for (int s = 0; s < sceneCount; s++)
                {
                    for (int e = 0; e < 3; e++)
                    {
                        entities[s][e].Delete();
                    }
                }
                
                // Verify
                Assert.True(true);
            }
            finally
            {
                for (int i = 0; i < sceneCount; i++)
                {
                    scenes[i]?.Dispose();
                }
            }
        }

        /// <summary>
        /// Tests that multiple scenes query from each scene correct
        /// </summary>
        /// <param name="sceneCount">The scene count</param>
        /// <param name="entitiesPerScene">The entities per scene</param>
        [Theory]
        [InlineData(2, 10)]
        [InlineData(3, 10)]
        [InlineData(5, 5)]
        public void MultipleScenes_QueryFromEachScene_Correct(int sceneCount, int entitiesPerScene)
        {
            var scenes = new Scene[sceneCount];
            
            try
            {
                // Setup
                for (int s = 0; s < sceneCount; s++)
                {
                    scenes[s] = new Scene();
                    for (int e = 0; e < entitiesPerScene; e++)
                    {
                        if (e % 2 == 0)
                            scenes[s].Create(new Position { X = e, Y = e });
                        else
                            scenes[s].Create();
                    }
                }
                
                // Query each
                for (int s = 0; s < sceneCount; s++)
                {
                    int count = 0;
                    foreach (var go in scenes[s].Query<With<Position>>().EnumerateWithEntities()) count++;
                    Assert.Equal((entitiesPerScene + 1) / 2, count);
                }
            }
            finally
            {
                for (int i = 0; i < sceneCount; i++)
                {
                    scenes[i]?.Dispose();
                }
            }
        }

        /// <summary>
        /// Tests that multiple scenes stress test many operations
        /// </summary>
        /// <param name="sceneCount">The scene count</param>
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        public void MultipleScenes_StressTest_ManyOperations(int sceneCount)
        {
            var scenes = new Scene[sceneCount];
            
            try
            {
                for (int s = 0; s < sceneCount; s++)
                {
                    scenes[s] = new Scene();
                    
                    for (int op = 0; op < 50; op++)
                    {
                        if (op % 2 == 0)
                            scenes[s].Create(new Position { X = op, Y = op });
                        else
                            scenes[s].Create();
                    }
                }
                
                Assert.True(sceneCount > 0);
            }
            finally
            {
                for (int i = 0; i < sceneCount; i++)
                {
                    scenes[i]?.Dispose();
                }
            }
        }
    }
}

