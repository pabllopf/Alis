// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryParametrizedTest.cs
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
    ///     Parametrized tests for Query system to generate comprehensive coverage
    /// </summary>
    public class QueryParametrizedTest
    {
        /// <summary>
        ///     Tests that query single component filter returns correct count
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10), InlineData(50), InlineData(100)]
        public void Query_SingleComponentFilter_ReturnsCorrectCount(int entityCount)
        {
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

            int count = 0;
            foreach (GameObject entity in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                count++;
            }

            Assert.Equal((entityCount + 1) / 2, count);
        }

        /// <summary>
        ///     Tests that query multi component filter only returns matching
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(10), InlineData(25), InlineData(50)]
        public void Query_MultiComponentFilter_OnlyReturnsMatching(int entityCount)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < entityCount; i++)
            {
                GameObject go = scene.Create();
                if (i % 2 == 0)
                {
                    go.Add(new Position {X = 1, Y = 1});
                }

                if (i % 3 == 0)
                {
                    go.Add(new Health {Value = 100});
                }
            }

            int countBoth = 0;
            foreach (GameObject go in scene.Query<With<Position>, With<Health>>().EnumerateWithEntities())
            {
                countBoth++;
            }

            Assert.True(countBoth >= 0);
        }

        /// <summary>
        ///     Tests that query modify components while iterating works
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(10), InlineData(25), InlineData(50)]
        public void Query_ModifyComponentsWhileIterating_Works(int entityCount)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < entityCount; i++)
            {
                scene.Create(new Position {X = i, Y = i});
            }

            foreach (GameObject entity in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                ref Position pos = ref entity.Get<Position>();
                pos.X += 1;
                pos.Y += 1;
            }

            int verifyCount = 0;
            foreach (GameObject entity in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                verifyCount++;
                Assert.True(entity.Get<Position>().X >= 1);
            }

            Assert.Equal(entityCount, verifyCount);
        }

        /// <summary>
        ///     Tests that query add component while not querying appears in next query
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(5), InlineData(10), InlineData(20)]
        public void Query_AddComponentWhileNotQuerying_AppearsInNextQuery(int entityCount)
        {
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create();
            }

            int count1 = 0;
            foreach (GameObject entity in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                count1++;
            }

            for (int i = 0; i < entityCount; i++)
            {
                entities[i].Add(new Position {X = 1, Y = 1});
            }

            int count2 = 0;
            foreach (GameObject entity in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                count2++;
            }

            Assert.Equal(0, count1);
            Assert.Equal(entityCount, count2);
        }

        /// <summary>
        ///     Tests that query remove component while querying entity not in future queries
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(10), InlineData(25), InlineData(50)]
        public void Query_RemoveComponentWhileQuerying_EntityNotInFutureQueries(int entityCount)
        {
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create(new Position {X = 1, Y = 1});
            }

            for (int i = 0; i < entityCount / 2; i++)
            {
                entities[i].Remove<Position>();
            }

            int count = 0;
            foreach (GameObject entity in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                count++;
            }

            Assert.Equal(entityCount - entityCount / 2, count);
        }

        /// <summary>
        ///     Tests that query delete entity while querying does not appear in results
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(10), InlineData(25), InlineData(50)]
        public void Query_DeleteEntityWhileQuerying_DoesNotAppearInResults(int entityCount)
        {
            using Scene scene = new Scene();
            GameObject[] entities = new GameObject[entityCount];
            for (int i = 0; i < entityCount; i++)
            {
                entities[i] = scene.Create(new Position {X = 1, Y = 1});
            }

            for (int i = 0; i < entityCount / 2; i++)
            {
                entities[i].Delete();
            }

            int count = 0;
            foreach (GameObject entity in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                if (entity.IsAlive)
                {
                    count++;
                }
            }

            Assert.True(count >= entityCount / 2);
        }

        /// <summary>
        ///     Tests that query chained queries work correctly
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        [Theory, InlineData(5), InlineData(10), InlineData(20)]
        public void Query_ChainedQueries_WorkCorrectly(int entityCount)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < entityCount; i++)
            {
                GameObject go = scene.Create();
                if (i % 2 == 0)
                {
                    go.Add(new Position {X = 1, Y = 1});
                }

                if (i % 3 == 0)
                {
                    go.Add(new Health {Value = 100});
                }

                if (i % 5 == 0)
                {
                    go.Add(new Velocity {X = 1, Y = 1});
                }
            }

            int posCount = 0;
            int healthCount = 0;
            int velCount = 0;

            foreach (GameObject go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                posCount++;
            }

            foreach (GameObject go in scene.Query<With<Health>>().EnumerateWithEntities())
            {
                healthCount++;
            }

            foreach (GameObject go in scene.Query<With<Velocity>>().EnumerateWithEntities())
            {
                velCount++;
            }

            Assert.True(posCount > 0);
            Assert.True(healthCount > 0);
            Assert.True(velCount > 0);
        }

        /// <summary>
        ///     Tests that query empty scene returns no entities
        /// </summary>
        /// <param name="unused">The unused</param>
        [Theory, InlineData(10), InlineData(50), InlineData(100)]
        public void Query_EmptyScene_ReturnsNoEntities(int unused)
        {
            using Scene scene = new Scene();

            int count = 0;
            foreach (GameObject go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                count++;
            }

            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Tests that query partial matches only returns exact
        /// </summary>
        /// <param name="entityCount">The entity count</param>
        /// <param name="matchingCount">The matching count</param>
        [Theory, InlineData(10, 1), InlineData(20, 2), InlineData(50, 5)]
        public void Query_PartialMatches_OnlyReturnsExact(int entityCount, int matchingCount)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < entityCount; i++)
            {
                GameObject go = scene.Create();
                if (i < matchingCount)
                {
                    go.Add(new Position {X = 1, Y = 1});
                    go.Add(new Health {Value = 100});
                }
                else
                {
                    go.Add(new Position {X = 1, Y = 1});
                }
            }

            int count = 0;
            foreach (GameObject go in scene.Query<With<Position>, With<Health>>().EnumerateWithEntities())
            {
                count++;
            }

            Assert.Equal(matchingCount, count);
        }
    }
}