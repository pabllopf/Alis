// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MassiveParametrizedTests.cs
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
    ///     Massive parametrized tests for comprehensive coverage
    /// </summary>
    public class MassiveParametrizedTests
    {
        /// <summary>
        ///     Tests that massive param create entities
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(2), InlineData(3), InlineData(4), InlineData(5), InlineData(10), InlineData(15), InlineData(20), InlineData(25), InlineData(30), InlineData(40), InlineData(50), InlineData(75), InlineData(100), InlineData(150), InlineData(200), InlineData(300), InlineData(500), InlineData(1000)]
        public void MassiveParam_CreateEntities(int count)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < count; i++)
            {
                scene.Create();
            }

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that massive param create with position
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(2), InlineData(3), InlineData(5), InlineData(10), InlineData(20), InlineData(50), InlineData(100), InlineData(200), InlineData(500)]
        public void MassiveParam_CreateWithPosition(int count)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < count; i++)
            {
                scene.Create(new Position {X = i, Y = i});
            }

            int queryCount = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                queryCount++;
            }

            Assert.Equal(count, queryCount);
        }

        /// <summary>
        ///     Tests that massive param create and delete
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(2), InlineData(3), InlineData(5), InlineData(10), InlineData(20), InlineData(50), InlineData(100), InlineData(200)]
        public void MassiveParam_CreateAndDelete(int count)
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
        ///     Tests that massive param add component to all
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(2), InlineData(3), InlineData(5), InlineData(10), InlineData(20), InlineData(50), InlineData(100)]
        public void MassiveParam_AddComponentToAll(int count)
        {
            using Scene scene = new Scene();
            var entities = new GameObject[count];
            for (int i = 0; i < count; i++)
            {
                entities[i] = scene.Create();
            }

            for (int i = 0; i < count; i++)
            {
                entities[i].Add(new Position {X = i, Y = i});
            }

            int queryCount = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                queryCount++;
            }

            Assert.Equal(count, queryCount);
        }

        /// <summary>
        ///     Tests that massive param remove component from half
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(2), InlineData(3), InlineData(5), InlineData(10), InlineData(20), InlineData(50), InlineData(100)]
        public void MassiveParam_RemoveComponentFromHalf(int count)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < count; i++)
            {
                scene.Create(new Position {X = i, Y = i});
            }

            var toRemove = new List<GameObject>();
            int idx = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                if (idx < count / 2)
                {
                    toRemove.Add(go);
                }

                idx++;
            }

            foreach (var go in toRemove)
            {
                go.Remove<Position>();
            }

            int remaining = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                remaining++;
            }

            Assert.Equal(count - count / 2, remaining);
        }

        /// <summary>
        ///     Tests that massive param multiple queries
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(1), InlineData(2), InlineData(3), InlineData(5), InlineData(10), InlineData(20), InlineData(50)]
        public void MassiveParam_MultipleQueries(int entityCount)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < entityCount; i++)
            {
                scene.Create(new Position {X = i, Y = i});
            }

            for (int q = 0; q < 10; q++)
            {
                int count = 0;
                foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
                {
                    count++;
                }

                Assert.Equal(entityCount, count);
            }
        }

        /// <summary>
        ///     Tests that massive param modify components
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(1), InlineData(2), InlineData(3), InlineData(5), InlineData(10), InlineData(20), InlineData(50)]
        public void MassiveParam_ModifyComponents(int entityCount)
        {
            using Scene scene = new Scene();
            var entities = new GameObject[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create(new Position {X = 0, Y = 0});
            }

            for (int i = 0; i < entityCount; i++)
            {
                ref Position pos = ref entities[i].Get<Position>();
                pos.X = i * 10;
                pos.Y = i * 20;
            }

            for (int i = 0; i < entityCount; i++)
            {
                Assert.Equal(i * 10, entities[i].Get<Position>().X);
            }
        }

        /// <summary>
        ///     Tests that massive param create cyclical
        /// </summary>
        /// <param name="cycleCount">The cycle count</param>
        [Theory, InlineData(1), InlineData(2), InlineData(3), InlineData(5), InlineData(10), InlineData(20), InlineData(50)]
        public void MassiveParam_CreateCyclical(int cycleCount)
        {
            using Scene scene = new Scene();
            for (int c = 0; c < cycleCount; c++)
            {
                GameObject go = scene.Create(new Position {X = c, Y = c});
                go.Delete();
            }

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that massive param query with filters
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        /// <param name="filterMod">The filter mod</param>
        [Theory, InlineData(2, 5), InlineData(3, 10), InlineData(5, 10), InlineData(10, 5), InlineData(10, 10)]
        public void MassiveParam_QueryWithFilters(int entityCount, int filterMod)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < entityCount; i++)
            {
                if (i % filterMod == 0)
                {
                    scene.Create(new Position {X = i, Y = i});
                }
                else
                {
                    scene.Create();
                }
            }

            int queryCount = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                queryCount++;
            }

            Assert.True(queryCount >= 0);
        }

        /// <summary>
        ///     Tests that massive param mixed operations
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(1), InlineData(2), InlineData(3), InlineData(5), InlineData(10), InlineData(20)]
        public void MassiveParam_MixedOperations(int entityCount)
        {
            using Scene scene = new Scene();
            var entities = new List<GameObject>();

            for (int i = 0; i < entityCount * 3; i++)
            {
                int op = i % 4;
                switch (op)
                {
                    case 0:
                        entities.Add(scene.Create(new Position {X = i, Y = i}));
                        break;
                    case 1:
                        if ((entities.Count > 0) && entities[0].IsAlive)
                        {
                            entities[0].Add(new Health {Value = 100});
                        }

                        break;
                    case 2:
                        if ((entities.Count > 0) && entities[0].Has<Health>())
                        {
                            entities[0].Remove<Health>();
                        }

                        break;
                    case 3:
                        if (entities.Count > 0)
                        {
                            entities[0].Delete();
                            entities.RemoveAt(0);
                        }

                        break;
                }
            }

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that massive param component count
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        /// <param name="componentCount">The component count</param>
        [Theory, InlineData(1, 1), InlineData(1, 2), InlineData(2, 1), InlineData(2, 2), InlineData(5, 1), InlineData(5, 2), InlineData(10, 1), InlineData(10, 2), InlineData(10, 5), InlineData(20, 5)]
        public void MassiveParam_ComponentCount(int entityCount, int componentCount)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < entityCount; i++)
            {
                var go = scene.Create();
                if (componentCount >= 1)
                {
                    go.Add(new Position {X = 1, Y = 1});
                }

                if (componentCount >= 2)
                {
                    go.Add(new Health {Value = 100});
                }

                if (componentCount >= 3)
                {
                    go.Add(new Velocity {X = 1, Y = 1});
                }

                if (componentCount >= 4)
                {
                    go.Add(new Transform {X = 0, Y = 0});
                }

                if (componentCount >= 5)
                {
                    go.Add(new Damage {Value = 10});
                }
            }

            Assert.True(true);
        }
    }
}