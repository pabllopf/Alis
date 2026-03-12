// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneCreateManyTest.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     Tests bulk entity creation APIs in <see cref="Scene" />.
    /// </summary>
    public class SceneCreateManyTest
    {
        /// <summary>
        /// Tests that scene create many one component returns expected spans and entities
        /// </summary>
        [Fact]
        public void SceneCreateMany_OneComponent_ReturnsExpectedSpansAndEntities()
        {
            using Scene scene = new Scene();

            ChunkTuple<Position> chunk = scene.CreateMany<Position>(4);

            Assert.Equal(4, chunk.Span.Length);
            Assert.Equal(4, CountEntities(chunk.Entities));
            Assert.Equal(4, scene.EntityCount);
        }

        /// <summary>
        /// Tests that scene create many two components returns expected spans and entities
        /// </summary>
        [Fact]
        public void SceneCreateMany_TwoComponents_ReturnsExpectedSpansAndEntities()
        {
            using Scene scene = new Scene();

            ChunkTuple<Position, Velocity> chunk = scene.CreateMany<Position, Velocity>(3);

            Assert.Equal(3, chunk.Span1.Length);
            Assert.Equal(3, chunk.Span2.Length);
            Assert.Equal(3, CountEntities(chunk.Entities));
            Assert.Equal(3, scene.EntityCount);
        }

        /// <summary>
        /// Tests that scene create many three components returns expected spans and entities
        /// </summary>
        [Fact]
        public void SceneCreateMany_ThreeComponents_ReturnsExpectedSpansAndEntities()
        {
            using Scene scene = new Scene();

            ChunkTuple<Position, Velocity, Health> chunk = scene.CreateMany<Position, Velocity, Health>(2);

            Assert.Equal(2, chunk.Span1.Length);
            Assert.Equal(2, chunk.Span2.Length);
            Assert.Equal(2, chunk.Span3.Length);
            Assert.Equal(2, CountEntities(chunk.Entities));
            Assert.Equal(2, scene.EntityCount);
        }

        /// <summary>
        /// Tests that scene create many four components returns expected spans and entities
        /// </summary>
        [Fact]
        public void SceneCreateMany_FourComponents_ReturnsExpectedSpansAndEntities()
        {
            using Scene scene = new Scene();

            ChunkTuple<Position, Velocity, Health, Transform> chunk = scene.CreateMany<Position, Velocity, Health, Transform>(2);

            Assert.Equal(2, chunk.Span1.Length);
            Assert.Equal(2, chunk.Span2.Length);
            Assert.Equal(2, chunk.Span3.Length);
            Assert.Equal(2, chunk.Span4.Length);
            Assert.Equal(2, CountEntities(chunk.Entities));
        }

        /// <summary>
        /// Tests that scene create many five components returns expected spans and entities
        /// </summary>
        [Fact]
        public void SceneCreateMany_FiveComponents_ReturnsExpectedSpansAndEntities()
        {
            using Scene scene = new Scene();

            ChunkTuple<Position, Velocity, Health, Transform, TestComponent> chunk =
                scene.CreateMany<Position, Velocity, Health, Transform, TestComponent>(2);

            Assert.Equal(2, chunk.Span1.Length);
            Assert.Equal(2, chunk.Span2.Length);
            Assert.Equal(2, chunk.Span3.Length);
            Assert.Equal(2, chunk.Span4.Length);
            Assert.Equal(2, chunk.Span5.Length);
            Assert.Equal(2, CountEntities(chunk.Entities));
        }

        /// <summary>
        /// Tests that scene create many six components returns expected spans and entities
        /// </summary>
        [Fact]
        public void SceneCreateMany_SixComponents_ReturnsExpectedSpansAndEntities()
        {
            using Scene scene = new Scene();

            ChunkTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> chunk =
                scene.CreateMany<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>(2);

            Assert.Equal(2, chunk.Span1.Length);
            Assert.Equal(2, chunk.Span2.Length);
            Assert.Equal(2, chunk.Span3.Length);
            Assert.Equal(2, chunk.Span4.Length);
            Assert.Equal(2, chunk.Span5.Length);
            Assert.Equal(2, chunk.Span6.Length);
            Assert.Equal(2, CountEntities(chunk.Entities));
        }

        /// <summary>
        /// Tests that scene create many seven components returns expected spans and entities
        /// </summary>
        [Fact]
        public void SceneCreateMany_SevenComponents_ReturnsExpectedSpansAndEntities()
        {
            using Scene scene = new Scene();

            ChunkTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage> chunk =
                scene.CreateMany<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>(2);

            Assert.Equal(2, chunk.Span1.Length);
            Assert.Equal(2, chunk.Span2.Length);
            Assert.Equal(2, chunk.Span3.Length);
            Assert.Equal(2, chunk.Span4.Length);
            Assert.Equal(2, chunk.Span5.Length);
            Assert.Equal(2, chunk.Span6.Length);
            Assert.Equal(2, chunk.Span7.Length);
            Assert.Equal(2, CountEntities(chunk.Entities));
        }

        /// <summary>
        /// Tests that scene create many eight components returns expected spans and entities
        /// </summary>
        [Fact]
        public void SceneCreateMany_EightComponents_ReturnsExpectedSpansAndEntities()
        {
            using Scene scene = new Scene();

            ChunkTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> chunk =
                scene.CreateMany<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(2);

            Assert.Equal(2, chunk.Span1.Length);
            Assert.Equal(2, chunk.Span2.Length);
            Assert.Equal(2, chunk.Span3.Length);
            Assert.Equal(2, chunk.Span4.Length);
            Assert.Equal(2, chunk.Span5.Length);
            Assert.Equal(2, chunk.Span6.Length);
            Assert.Equal(2, chunk.Span7.Length);
            Assert.Equal(2, chunk.Span8.Length);
            Assert.Equal(2, CountEntities(chunk.Entities));
        }

        /// <summary>
        /// Tests that scene create many new entities contain requested components
        /// </summary>
        [Fact]
        public void SceneCreateMany_NewEntitiesContainRequestedComponents()
        {
            using Scene scene = new Scene();

            ChunkTuple<Position, Velocity, Health> chunk = scene.CreateMany<Position, Velocity, Health>(3);

            foreach (GameObject entity in chunk.Entities)
            {
                Assert.True(entity.Has<Position>());
                Assert.True(entity.Has<Velocity>());
                Assert.True(entity.Has<Health>());
            }
        }

        /// <summary>
        /// Tests that scene create many can write to returned spans and read back from entities
        /// </summary>
        [Fact]
        public void SceneCreateMany_CanWriteToReturnedSpans_AndReadBackFromEntities()
        {
            using Scene scene = new Scene();

            ChunkTuple<Position, Velocity> chunk = scene.CreateMany<Position, Velocity>(3);

            for (int i = 0; i < chunk.Span1.Length; i++)
            {
                chunk.Span1[i] = new Position {X = i + 10, Y = i + 20};
                chunk.Span2[i] = new Velocity {X = i + 1, Y = i + 2};
            }

            int index = 0;
            foreach (GameObject entity in chunk.Entities)
            {
                Position p = entity.Get<Position>();
                Velocity v = entity.Get<Velocity>();

                Assert.Equal(index + 10, p.X);
                Assert.Equal(index + 20, p.Y);
                Assert.Equal(index + 1, v.X);
                Assert.Equal(index + 2, v.Y);
                index++;
            }
        }

        /// <summary>
        /// Tests that scene create many zero or negative count throws argument out of range exception
        /// </summary>
        [Fact]
        public void SceneCreateMany_ZeroOrNegativeCount_ThrowsArgumentOutOfRangeException()
        {
            using Scene scene = new Scene();

            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position>(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position>(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Velocity>(0));
            Assert.Throws<ArgumentOutOfRangeException>(() => scene.CreateMany<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>(0));
        }

        /// <summary>
        /// Counts the entities using the specified entities
        /// </summary>
        /// <param name="entities">The entities</param>
        /// <returns>The count</returns>
        private static int CountEntities(GameObjectEnumerator.EntityEnumerable entities)
        {
            int count = 0;
            foreach (GameObject _ in entities)
            {
                count++;
            }

            return count;
        }
    }
}

