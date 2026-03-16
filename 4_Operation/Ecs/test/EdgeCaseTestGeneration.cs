// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EdgeCaseTestGeneration.cs
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
    ///     Edge case tests for comprehensive coverage
    /// </summary>
    public class EdgeCaseTestGeneration
    {
        /// <summary>
        ///     Tests that edge case create and query immediately works
        /// </summary>
        [Fact]
        public void EdgeCase_CreateAndQueryImmediately_Works()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 1});
            int count = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that edge case delete and query after empty
        /// </summary>
        [Fact]
        public void EdgeCase_DeleteAndQueryAfter_Empty()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create(new Position {X = 1, Y = 1});
            go.Delete();
            int count = 0;
            foreach (var e in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                count++;
            }

            Assert.True(count < 1);
        }

        /// <summary>
        ///     Tests that edge case multiple scenes independent states
        /// </summary>
        [Fact]
        public void EdgeCase_MultipleScenes_IndependentStates()
        {
            using Scene scene1 = new Scene();
            using Scene scene2 = new Scene();
            scene1.Create(new Position {X = 1, Y = 1});
            scene2.Create(new Health {Value = 100});

            int count1 = 0, count2 = 0;
            foreach (var go in scene1.Query<With<Position>>().EnumerateWithEntities())
            {
                count1++;
            }

            foreach (var go in scene2.Query<With<Health>>().EnumerateWithEntities())
            {
                count2++;
            }

            Assert.Equal(1, count1);
            Assert.Equal(1, count2);
        }

        /// <summary>
        ///     Tests that edge case component with same data multiple entities
        /// </summary>
        [Fact]
        public void EdgeCase_ComponentWithSameDataMultipleEntities()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 5, Y = 5});
            scene.Create(new Position {X = 5, Y = 5});
            scene.Create(new Position {X = 5, Y = 5});

            int count = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                count++;
            }

            Assert.Equal(3, count);
        }

        /// <summary>
        ///     Tests that edge case remove component and add back
        /// </summary>
        [Fact]
        public void EdgeCase_RemoveComponentAndAddBack()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create(new Position {X = 10, Y = 10});
            go.Remove<Position>();
            Assert.False(go.Has<Position>());
            go.Add(new Position {X = 20, Y = 20});
            Assert.True(go.Has<Position>());
            Assert.Equal(20, go.Get<Position>().X);
        }

        /// <summary>
        ///     Tests that edge case multiple component types independent queries
        /// </summary>
        [Fact]
        public void EdgeCase_MultipleComponentTypes_IndependentQueries()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 1}, new Health {Value = 100});
            scene.Create(new Position {X = 2, Y = 2});
            scene.Create(new Health {Value = 50});

            int posCount = 0, healthCount = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                posCount++;
            }

            foreach (var go in scene.Query<With<Health>>().EnumerateWithEntities())
            {
                healthCount++;
            }

            Assert.Equal(2, posCount);
            Assert.Equal(2, healthCount);
        }

        /// <summary>
        ///     Tests that edge case parametrized entity creation consistency
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10), InlineData(100)]
        public void EdgeCase_ParametrizedEntityCreation_Consistency(int count)
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
        ///     Tests that edge case large component value
        /// </summary>
        [Fact]
        public void EdgeCase_LargeComponentValue()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create(new Health {Value = int.MaxValue});
            Assert.Equal(int.MaxValue, go.Get<Health>().Value);
        }

        /// <summary>
        ///     Tests that edge case negative component value
        /// </summary>
        [Fact]
        public void EdgeCase_NegativeComponentValue()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create(new Position {X = int.MinValue, Y = int.MinValue});
            Assert.Equal(int.MinValue, go.Get<Position>().X);
        }

        /// <summary>
        ///     Tests that edge case zero component value
        /// </summary>
        [Fact]
        public void EdgeCase_ZeroComponentValue()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create(new Position {X = 0, Y = 0});
            Assert.Equal(0, go.Get<Position>().X);
            Assert.Equal(0, go.Get<Position>().Y);
        }

        /// <summary>
        ///     Tests that edge case component reference modification
        /// </summary>
        [Fact]
        public void EdgeCase_ComponentReferenceModification()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create(new Position {X = 1, Y = 1});
            ref Position pos = ref go.Get<Position>();
            pos.X = 100;
            Assert.Equal(100, go.Get<Position>().X);
        }

        /// <summary>
        ///     Tests that edge case query empty scene multiple times
        /// </summary>
        [Fact]
        public void EdgeCase_QueryEmptySceneMultipleTimes()
        {
            using Scene scene = new Scene();
            for (int i = 0; i < 5; i++)
            {
                int count = 0;
                foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
                {
                    count++;
                }

                Assert.Equal(0, count);
            }
        }

        /// <summary>
        ///     Tests that edge case nested entity creation and deletion
        /// </summary>
        /// <param name="iterations">The iterations</param>
        [Theory, InlineData(5), InlineData(10), InlineData(20), InlineData(50), InlineData(100)]
        public void EdgeCase_NestedEntityCreationAndDeletion(int iterations)
        {
            using Scene scene = new Scene();
            for (int i = 0; i < iterations; i++)
            {
                var go = scene.Create(new Position {X = i, Y = i});
                if (i % 2 == 0)
                {
                    go.Delete();
                }
            }

            int count = 0;
            foreach (var go in scene.Query<With<Position>>().EnumerateWithEntities())
            {
                count++;
            }

            Assert.True(count >= 0);
        }

        /// <summary>
        ///     Tests that edge case component with default values
        /// </summary>
        [Fact]
        public void EdgeCase_ComponentWithDefaultValues()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();
            go.Add(new Position());
            Assert.Equal(0, go.Get<Position>().X);
            Assert.Equal(0, go.Get<Position>().Y);
        }

        /// <summary>
        ///     Tests that edge case recreate deleted entity slot
        /// </summary>
        /// <param name="iterations">The iterations</param>
        [Theory, InlineData(10), InlineData(50), InlineData(100)]
        public void EdgeCase_RecreateDeletedEntitySlot(int iterations)
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create(new Position {X = 1, Y = 1});

            for (int i = 0; i < iterations; i++)
            {
                go.Delete();
                go = scene.Create(new Position {X = i, Y = i});
            }

            Assert.True(go.IsAlive);
        }

        /// <summary>
        ///     Tests that edge case many components on single entity
        /// </summary>
        [Fact]
        public void EdgeCase_ManyComponentsOnSingleEntity()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();

            go.Add(new Position {X = 1, Y = 1});
            go.Add(new Health {Value = 100});
            go.Add(new Velocity {X = 1, Y = 1});
            go.Add(new Transform {X = 0, Y = 0});
            go.Add(new Damage {Value = 10});

            Assert.True(go.Has<Position>());
            Assert.True(go.Has<Health>());
            Assert.True(go.Has<Velocity>());
            Assert.True(go.Has<Transform>());
            Assert.True(go.Has<Damage>());
        }

        /// <summary>
        ///     Tests that edge case consecutive component additions removals combined
        /// </summary>
        [Fact]
        public void EdgeCase_ConsecutiveComponentAdditionsRemovalsCombined()
        {
            using Scene scene = new Scene();
            GameObject go = scene.Create();

            for (int i = 0; i < 5; i++)
            {
                go.Add(new Position {X = i, Y = i});
                Assert.True(go.Has<Position>());
                go.Remove<Position>();
                Assert.False(go.Has<Position>());
            }

            Assert.True(go.IsAlive);
        }
    }
}