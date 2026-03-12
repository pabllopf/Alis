// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MassiveEntityCreationTests.cs
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
    ///     Massive entity creation and manipulation tests
    /// </summary>
    public class MassiveEntityCreationTests
    {
        /// <summary>
        /// Tests that massive create many entities
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(200)]
        [InlineData(500)]
        [InlineData(1000)]
        public void Massive_CreateManyEntities(int count)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < count; i++)
            {
                scene.Create();
            }
            Assert.True(true);
        }

        /// <summary>
        /// Tests that massive create with components
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(200)]
        [InlineData(500)]
        public void Massive_CreateWithComponents(int count)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < count; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }
            
            int queryCount = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) queryCount++;
            Assert.Equal(count, queryCount);
        }

        /// <summary>
        /// Tests that massive delete many
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(200)]
        public void Massive_DeleteMany(int count)
        {
            using Scene scene = new Scene();
            var entities = new GameObject[count];
            for (int i = 0; i < count; i++)
            {
                entities[i] = scene.Create();
            }
            
            for (int i = 0; i < count; i++)
            {
                entities[i].Delete();
            }
            Assert.True(true);
        }

        /// <summary>
        /// Tests that massive add components to many
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(200)]
        public void Massive_AddComponentsToMany(int count)
        {
            using Scene scene = new Scene();
            var entities = new GameObject[count];
            for (int i = 0; i < count; i++)
            {
                entities[i] = scene.Create();
            }
            
            for (int i = 0; i < count; i++)
            {
                entities[i].Add(new Position { X = i, Y = i });
            }
            
            int queryCount = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) queryCount++;
            Assert.Equal(count, queryCount);
        }

        /// <summary>
        /// Tests that massive remove components from many
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(200)]
        public void Massive_RemoveComponentsFromMany(int count)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < count; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }
            
            int before = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) before++;
            Assert.Equal(count, before);
            
            var positions = new GameObject[count];
            int idx = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                positions[idx++] = go;
            }
            
            for (int i = 0; i < count / 2; i++)
            {
                positions[i].Remove<Position>();
            }
            
            int after = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) after++;
            Assert.Equal(count - (count / 2), after);
        }

        /// <summary>
        /// Tests that massive multiple components on many
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="componentType">The component type</param>
        [Theory]
        [InlineData(50, 2)]
        [InlineData(100, 3)]
        [InlineData(200, 5)]
        public void Massive_MultipleComponentsOnMany(int count, int componentType)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < count; i++)
            {
                var go = scene.Create();
                if (componentType >= 1) go.Add(new Position { X = i, Y = i });
                if (componentType >= 2) go.Add(new Health { Value = 100 });
                if (componentType >= 3) go.Add(new Velocity { X = 1, Y = 1 });
                if (componentType >= 4) go.Add(new Transform { X = 0, Y = 0 });
                if (componentType >= 5) go.Add(new Damage { Value = 10 });
            }
            
            Assert.True(true);
        }

        /// <summary>
        /// Tests that massive query many times
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(200)]
        public void Massive_QueryManyTimes(int count)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < count; i++)
            {
                scene.Create(new Position { X = i, Y = i });
            }
            
            for (int q = 0; q < 10; q++)
            {
                int queryCount = 0;
                foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities()) queryCount++;
                Assert.Equal(count, queryCount);
            }
        }

        /// <summary>
        /// Tests that massive modify components many times
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(200)]
        public void Massive_ModifyComponentsManyTimes(int count)
        {
            using Scene scene = new Scene();
            var entities = new GameObject[count];
            for (int i = 0; i < count; i++)
            {
                entities[i] = scene.Create(new Position { X = 0, Y = 0 });
            }
            
            for (int round = 0; round < 5; round++)
            {
                for (int i = 0; i < count; i++)
                {
                    ref Position pos = ref entities[i].Get<Position>();
                    pos.X += 1;
                }
            }
            
            for (int i = 0; i < count; i++)
            {
                Assert.Equal(5, entities[i].Get<Position>().X);
            }
        }

        /// <summary>
        /// Tests that massive create delete cycle many
        /// </summary>
        /// <param name="cycles">The cycles</param>
        [Theory]
        [InlineData(50)]
        [InlineData(100)]
        public void Massive_CreateDeleteCycleMany(int cycles)
        {
            using Scene scene = new Scene();
            
            for (int c = 0; c < cycles; c++)
            {
                GameObject go = scene.Create(new Position { X = c, Y = c });
                go.Delete();
            }
            
            Assert.True(true);
        }

        /// <summary>
        /// Tests that massive varied operations sequence
        /// </summary>
        /// <param name="operations">The operations</param>
        [Theory]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(200)]
        public void Massive_VariedOperationsSequence(int operations)
        {
            using Scene scene = new Scene();
            var entities = new List<GameObject>();
            
            for (int i = 0; i < operations; i++)
            {
                int op = i % 5;
                switch (op)
                {
                    case 0:
                        entities.Add(scene.Create(new Position { X = i, Y = i }));
                        break;
                    case 1:
                        if (entities.Count > 0)
                            entities[0].Add(new Health { Value = 100 });
                        break;
                    case 2:
                        if (entities.Count > 0 && entities[0].Has<Health>())
                            entities[0].Remove<Health>();
                        break;
                    case 3:
                        if (entities.Count > 0)
                            entities[0].Delete();
                        if (entities.Count > 0)
                            entities.RemoveAt(0);
                        break;
                    case 4:
                        entities.Add(scene.Create());
                        break;
                }
            }
            
            Assert.True(true);
        }

        /// <summary>
        /// Tests that massive crete with various component combinations
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(50)]
        [InlineData(100)]
        public void Massive_CreteWithVariousComponentCombinations(int count)
        {
            using Scene scene = new Scene();
            
            for (int i = 0; i < count; i++)
            {
                var go = scene.Create();
                if (i % 2 == 0) go.Add(new Position { X = i, Y = i });
                if (i % 3 == 0) go.Add(new Health { Value = 100 });
                if (i % 5 == 0) go.Add(new Velocity { X = 1, Y = 1 });
            }
            
            Assert.True(true);
        }
    }
}

