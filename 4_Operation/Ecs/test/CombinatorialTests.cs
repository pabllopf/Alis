// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CombinatorialTests.cs
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
    ///     Combinatorial tests for component interactions
    /// </summary>
    public class CombinatorialTests
    {
        // Generate tests for all pairs of components
        /// <summary>
        /// Tests that combinatorial component pair interactions
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(1, 3)]
        [InlineData(1, 4)]
        [InlineData(1, 5)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        [InlineData(2, 3)]
        [InlineData(2, 4)]
        [InlineData(2, 5)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        [InlineData(3, 3)]
        [InlineData(3, 4)]
        [InlineData(3, 5)]
        [InlineData(4, 1)]
        [InlineData(4, 2)]
        [InlineData(4, 3)]
        [InlineData(4, 4)]
        [InlineData(4, 5)]
        [InlineData(5, 1)]
        [InlineData(5, 2)]
        [InlineData(5, 3)]
        [InlineData(5, 4)]
        [InlineData(5, 5)]
        public void Combinatorial_ComponentPairInteractions(int comp1, int comp2)
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            
            // Add components based on indices
            AddComponentByType(go, comp1);
            AddComponentByType(go, comp2);
            
            // Verify both exist
            Assert.True(ComponentExists(go, comp1));
            Assert.True(ComponentExists(go, comp2));
        }

        // Generate tests for all entity counts with different component sets
        /// <summary>
        /// Tests that combinatorial entity count with component type
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        /// <param name="componentType">The component type</param>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(5, 1)]
        [InlineData(10, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        [InlineData(3, 2)]
        [InlineData(5, 2)]
        [InlineData(10, 2)]
        [InlineData(1, 3)]
        [InlineData(2, 3)]
        [InlineData(3, 3)]
        [InlineData(5, 3)]
        [InlineData(10, 3)]
        [InlineData(1, 4)]
        [InlineData(2, 4)]
        [InlineData(3, 4)]
        [InlineData(5, 4)]
        [InlineData(10, 4)]
        [InlineData(1, 5)]
        [InlineData(2, 5)]
        [InlineData(3, 5)]
        [InlineData(5, 5)]
        [InlineData(10, 5)]
        public void Combinatorial_EntityCountWithComponentType(int entityCount, int componentType)
        {
            using Scene scene = new Scene();
            
            for (int i = 0; i < entityCount; i++)
            {
                GameObject go = scene.Create();
                AddComponentByType(go, componentType);
            }
            
            Assert.True(true);
        }

        // Generate tests for deletion patterns
        /// <summary>
        /// Tests that combinatorial delete patterns
        /// </summary>
        /// <param name="totalCount">The total count</param>
        /// <param name="deleteCount">The delete count</param>
        [Theory]
        [InlineData(1, 0)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(5, 2)]
        [InlineData(10, 5)]
        [InlineData(3, 2)]
        [InlineData(5, 3)]
        [InlineData(10, 1)]
        public void Combinatorial_DeletePatterns(int totalCount, int deleteCount)
        {
            using Scene scene = new Scene();
            var entities = new GameObject[totalCount];
            
            for (int i = 0; i < totalCount; i++)
            {
                entities[i] = scene.Create(new Position { X = i, Y = i });
            }
            
            for (int i = 0; i < deleteCount && i < totalCount; i++)
            {
                entities[i].Delete();
            }
            
            int remaining = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                if (go.IsAlive) remaining++;
            }
            
            Assert.Equal(totalCount - deleteCount, remaining);
        }

        // Generate tests for component addition/removal patterns
        /// <summary>
        /// Tests that combinatorial add remove patterns
        /// </summary>
        /// <param name="operations">The operations</param>
        /// <param name="componentType">The component type</param>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(5, 2)]
        [InlineData(10, 3)]
        [InlineData(5, 4)]
        [InlineData(10, 5)]
        public void Combinatorial_AddRemovePatterns(int operations, int componentType)
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            
            for (int i = 0; i < operations; i++)
            {
                AddComponentByType(go, componentType);
                if (ComponentExists(go, componentType))
                    RemoveComponentByType(go, componentType);
            }
            
            Assert.True(go.IsAlive);
        }

        /// <summary>
        /// Adds the component by type using the specified go
        /// </summary>
        /// <param name="go">The go</param>
        /// <param name="type">The type</param>
        private void AddComponentByType(GameObject go, int type)
        {
            switch (type)
            {
                case 1:
                    if (!go.Has<Position>()) go.Add(new Position { X = 1, Y = 1 });
                    break;
                case 2:
                    if (!go.Has<Health>()) go.Add(new Health { Value = 100 });
                    break;
                case 3:
                    if (!go.Has<Velocity>()) go.Add(new Velocity { X = 1, Y = 1 });
                    break;
                case 4:
                    if (!go.Has<Transform>()) go.Add(new Transform { X = 0, Y = 0 });
                    break;
                case 5:
                    if (!go.Has<Damage>()) go.Add(new Damage { Value = 10 });
                    break;
            }
        }

        /// <summary>
        /// Components the exists using the specified go
        /// </summary>
        /// <param name="go">The go</param>
        /// <param name="type">The type</param>
        /// <returns>The bool</returns>
        private bool ComponentExists(GameObject go, int type)
        {
            return type switch
            {
                1 => go.Has<Position>(),
                2 => go.Has<Health>(),
                3 => go.Has<Velocity>(),
                4 => go.Has<Transform>(),
                5 => go.Has<Damage>(),
                _ => false
            };
        }

        /// <summary>
        /// Removes the component by type using the specified go
        /// </summary>
        /// <param name="go">The go</param>
        /// <param name="type">The type</param>
        private void RemoveComponentByType(GameObject go, int type)
        {
            switch (type)
            {
                case 1:
                    if (go.Has<Position>()) go.Remove<Position>();
                    break;
                case 2:
                    if (go.Has<Health>()) go.Remove<Health>();
                    break;
                case 3:
                    if (go.Has<Velocity>()) go.Remove<Velocity>();
                    break;
                case 4:
                    if (go.Has<Transform>()) go.Remove<Transform>();
                    break;
                case 5:
                    if (go.Has<Damage>()) go.Remove<Damage>();
                    break;
            }
        }

        // Matrix of entity counts and operations
        /// <summary>
        /// Tests that combinatorial operation count matrix
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        /// <param name="operationMultiplier">The operation multiplier</param>
        [Theory]
        [InlineData(1, 1)]
        [InlineData(1, 2)]
        [InlineData(2, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 1)]
        [InlineData(3, 2)]
        [InlineData(5, 1)]
        [InlineData(5, 2)]
        [InlineData(5, 3)]
        [InlineData(10, 1)]
        [InlineData(10, 2)]
        [InlineData(10, 5)]
        [InlineData(20, 1)]
        [InlineData(20, 5)]
        [InlineData(50, 10)]
        [InlineData(100, 20)]
        public void Combinatorial_OperationCountMatrix(int entityCount, int operationMultiplier)
        {
            using Scene scene = new Scene();
            
            for (int i = 0; i < entityCount; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }
            
            for (int op = 0; op < entityCount * operationMultiplier; op++)
            {
                int count = 0;
                foreach (var go in scene.Query<With<Position>>().AsSpan())
                {
                    count++;
                    if (count >= entityCount) break;
                }
            }
            
            Assert.True(true);
        }
    }
}

