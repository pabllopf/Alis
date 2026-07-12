// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectEnumeratorTest.cs
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

using System;
using System.Collections.Generic;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     Tests for the <see cref="GameObjectEnumerator" /> type.
    /// </summary>
    public class GameObjectEnumeratorTest
    {
        /// <summary>
        ///     Tests that enumerating a single entity yields exactly one entity.
        /// </summary>
        [Fact]
        public void Enumerate_SingleEntity_YieldsOneEntity()
        {
            using Scene scene = new Scene();

            ChunkTuple<Position> chunk = scene.CreateMany<Position>(1);

            int count = 0;
            foreach (GameObject _ in chunk.Entities)
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that enumerating multiple entities yields the expected count.
        /// </summary>
        [Fact]
        public void Enumerate_MultipleEntities_YieldsExpectedCount()
        {
            using Scene scene = new Scene();

            ChunkTuple<Position> chunk = scene.CreateMany<Position>(5);

            int count = 0;
            foreach (GameObject _ in chunk.Entities)
            {
                count++;
            }

            Assert.Equal(5, count);
        }

        /// <summary>
        ///     Tests that enumerating twice produces the same entity IDs in the same order.
        /// </summary>
        [Fact]
        public void Enumerate_Twice_ProducesSameIds()
        {
            using Scene scene = new Scene();

            ChunkTuple<Position> chunk = scene.CreateMany<Position>(3);

            List<int> firstIds = [];
            foreach (GameObject entity in chunk.Entities)
            {
                firstIds.Add(entity.EntityID);
            }

            List<int> secondIds = [];
            foreach (GameObject entity in chunk.Entities)
            {
                secondIds.Add(entity.EntityID);
            }

            Assert.Equal(firstIds, secondIds);
        }

        /// <summary>
        ///     Tests that enumerating after setting span values returns entities with the correct component data.
        /// </summary>
        [Fact]
        public void Enumerate_AfterSettingSpanValues_ReturnsCorrectComponentData()
        {
            using Scene scene = new Scene();

            ChunkTuple<Position> chunk = scene.CreateMany<Position>(3);

            chunk.Span[0] = new Position {X = 10, Y = 20};
            chunk.Span[1] = new Position {X = 30, Y = 40};
            chunk.Span[2] = new Position {X = 50, Y = 60};

            int[] expectedX = [10, 30, 50];
            int[] expectedY = [20, 40, 60];
            int index = 0;

            foreach (GameObject entity in chunk.Entities)
            {
                Assert.Equal(expectedX[index], entity.Get<Position>().X);
                Assert.Equal(expectedY[index], entity.Get<Position>().Y);
                index++;
            }

            Assert.Equal(3, index);
        }

        /// <summary>
        ///     Tests that current throws when accessed before the first MoveNext call.
        /// </summary>
        [Fact]
        public void Current_AccessedBeforeMoveNext_Throws()
        {
            using Scene scene = new Scene();
            ChunkTuple<Position> chunk = scene.CreateMany<Position>(1);

            GameObjectEnumerator enumerator = chunk.Entities.GetEnumerator();

            bool threw = false;
            try
            {
                _ = enumerator.Current;
            }
            catch (IndexOutOfRangeException)
            {
                threw = true;
            }

            Assert.True(threw);
        }

        /// <summary>
        ///     Tests that enumerating a mixed-archetype scene only enumerates the entities in the requested chunk.
        /// </summary>
        [Fact]
        public void Enumerate_WithPreviousAndNewEntities_EnumeratesOnlyNewOnes()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});
            scene.Create(new Position {X = 3, Y = 4});

            ChunkTuple<Position> chunk = scene.CreateMany<Position>(2);

            int count = 0;
            foreach (GameObject entity in chunk.Entities)
            {
                Assert.Equal(0, entity.Get<Position>().X);
                Assert.Equal(0, entity.Get<Position>().Y);
                count++;
            }

            Assert.Equal(2, count);
        }
    }
}
