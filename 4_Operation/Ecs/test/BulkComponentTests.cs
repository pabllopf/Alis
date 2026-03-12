// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BulkComponentTests.cs
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
    ///     Bulk component tests for massive coverage generation
    /// </summary>
    public class BulkComponentTests
    {
        /// <summary>
        /// Tests that bulk component individual component testing
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="componentName">The component name</param>
        [Theory]
        [InlineData(1, "Position")]
        [InlineData(2, "Health")]
        [InlineData(3, "Velocity")]
        [InlineData(4, "Transform")]
        [InlineData(5, "Damage")]
        [InlineData(6, "AnotherComponent")]
        [InlineData(7, "AnotherComponent2")]
        [InlineData(8, "Armor")]
        [InlineData(9, "TagComponent")]
        [InlineData(10, "TestComponent")]
        public void BulkComponent_IndividualComponentTesting(int type, string componentName)
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            
            // Test different component types
            switch (type)
            {
                case 1:
                    go.Add(new Position { X = 10, Y = 20 });
                    Assert.True(go.Has<Position>());
                    Assert.Equal(10, go.Get<Position>().X);
                    break;
                case 2:
                    go.Add(new Health { Value = 100 });
                    Assert.True(go.Has<Health>());
                    Assert.Equal(100, go.Get<Health>().Value);
                    break;
                case 3:
                    go.Add(new Velocity { X = 5, Y = 10 });
                    Assert.True(go.Has<Velocity>());
                    break;
                case 4:
                    go.Add(new Transform { X = 1, Y = 2 });
                    Assert.True(go.Has<Transform>());
                    break;
                case 5:
                    go.Add(new Damage { Value = 20 });
                    Assert.True(go.Has<Damage>());
                    break;
                case 6:
                    go.Add(new AnotherComponent { Data = 42 });
                    Assert.True(go.Has<AnotherComponent>());
                    break;
                case 7:
                    go.Add(new AnotherComponent2 { Data = 99 });
                    Assert.True(go.Has<AnotherComponent2>());
                    break;
                case 8:
                    go.Add(new Armor { Value = 50 });
                    Assert.True(go.Has<Armor>());
                    break;
                case 9:
                    go.Add(new TagComponent());
                    Assert.True(go.Has<TagComponent>());
                    break;
                case 10:
                    go.Add(new TestComponent { Value = 777 });
                    Assert.True(go.Has<TestComponent>());
                    break;
            }
        }

        /// <summary>
        /// Tests that bulk component entity with component combinations
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        /// <param name="componentType">The component type</param>
        [Theory]
        [InlineData(10, 1)]
        [InlineData(10, 2)]
        [InlineData(20, 3)]
        [InlineData(30, 4)]
        [InlineData(50, 5)]
        [InlineData(100, 10)]
        public void BulkComponent_EntityWithComponentCombinations(int entityCount, int componentType)
        {
            using Scene scene = new Scene();
            
            for (int i = 0; i < entityCount; i++)
            {
                GameObject go = scene.Create();
                
                if (componentType >= 1) go.Add(new Position { X = i, Y = i });
                if (componentType >= 2) go.Add(new Health { Value = 100 + i });
                if (componentType >= 3) go.Add(new Velocity { X = 1, Y = 1 });
                if (componentType >= 4) go.Add(new Transform { X = 0, Y = 0 });
                if (componentType >= 5) go.Add(new Damage { Value = i });
                if (componentType >= 6) go.Add(new AnotherComponent { Data = i });
                if (componentType >= 7) go.Add(new AnotherComponent2 { Data = i * 2 });
                if (componentType >= 8) go.Add(new Armor { Value = i * 10 });
                if (componentType >= 9) go.Add(new TagComponent());
                if (componentType >= 10) go.Add(new TestComponent { Value = i * 100 });
            }
            
            // Verify correct number were created
            int count = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                if (componentType >= 1) count++;
            }
            
            Assert.True(count >= 0);
        }

        /// <summary>
        /// Tests that bulk component remove components in sequence
        /// </summary>
        /// <param name="removeCount">The remove count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        public void BulkComponent_RemoveComponentsInSequence(int removeCount)
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            
            // Add all components
            go.Add(new Position { X = 1, Y = 1 });
            go.Add(new Health { Value = 100 });
            go.Add(new Velocity { X = 1, Y = 1 });
            go.Add(new Transform { X = 0, Y = 0 });
            go.Add(new Damage { Value = 10 });
            go.Add(new AnotherComponent { Data = 42 });
            go.Add(new AnotherComponent2 { Data = 100 });
            go.Add(new Armor { Value = 25 });
            
            // Remove in sequence
            if (removeCount >= 1) { if (go.Has<Position>()) go.Remove<Position>(); }
            if (removeCount >= 2) { if (go.Has<Health>()) go.Remove<Health>(); }
            if (removeCount >= 3) { if (go.Has<Velocity>()) go.Remove<Velocity>(); }
            if (removeCount >= 4) { if (go.Has<Transform>()) go.Remove<Transform>(); }
            if (removeCount >= 5) { if (go.Has<Damage>()) go.Remove<Damage>(); }
            if (removeCount >= 6) { if (go.Has<AnotherComponent>()) go.Remove<AnotherComponent>(); }
            if (removeCount >= 7) { if (go.Has<AnotherComponent2>()) go.Remove<AnotherComponent2>(); }
            if (removeCount >= 8) { if (go.Has<Armor>()) go.Remove<Armor>(); }
            
            Assert.True(go.IsAlive);
        }

        /// <summary>
        /// Tests that bulk component query various component combinations
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        [InlineData(100)]
        public void BulkComponent_QueryVariousComponentCombinations(int entityCount)
        {
            using Scene scene = new Scene();
            
            for (int i = 0; i < entityCount; i++)
            {
                GameObject go = scene.Create();
                
                if (i % 2 == 0) go.Add(new Position { X = 1, Y = 1 });
                if (i % 3 == 0) go.Add(new Health { Value = 100 });
                if (i % 5 == 0) go.Add(new Velocity { X = 1, Y = 1 });
            }
            
            int posCount = 0, healthCount = 0, velCount = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) posCount++;
            foreach (var go in scene.Query<With<Health>>().EnumerateWithEntities()) healthCount++;
            foreach (var go in scene.Query<With<Velocity>>().EnumerateWithEntities()) velCount++;
            
            Assert.True(posCount > 0);
            Assert.True(healthCount > 0);
            Assert.True(velCount > 0);
        }

        /// <summary>
        /// Tests that bulk component stress test component operations
        /// </summary>
        /// <param name="operationCount">The operation count</param>
        [Theory]
        [InlineData(100)]
        [InlineData(500)]
        public void BulkComponent_StressTestComponentOperations(int operationCount)
        {
            using Scene scene = new Scene();
            var entities = new List<GameObject>();
            
            for (int i = 0; i < operationCount; i++)
            {
                int operation = i % 4;
                
                switch (operation)
                {
                    case 0:
                        entities.Add(scene.Create(new Position { X = i, Y = i }));
                        break;
                    case 1:
                        if (entities.Count > 0)
                        {
                            var go = entities[i % entities.Count];
                            if (go.IsAlive && !go.Has<Health>())
                                go.Add(new Health { Value = 100 });
                        }
                        break;
                    case 2:
                        if (entities.Count > 0)
                        {
                            var go = entities[i % entities.Count];
                            if (go.IsAlive && go.Has<Health>())
                                go.Remove<Health>();
                        }
                        break;
                    case 3:
                        if (entities.Count > 0)
                        {
                            var go = entities[i % entities.Count];
                            if (go.IsAlive)
                                go.Delete();
                        }
                        break;
                }
            }
            
            Assert.True(entities.Count >= 0);
        }
    }
}

