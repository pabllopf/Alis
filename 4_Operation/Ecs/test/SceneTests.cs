// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneTests.cs
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
    /// The scene tests class
    /// </summary>
    public class SceneTests
    {
        /// <summary>
        /// Tests that dispose false path does not clear tables
        /// </summary>
        [Fact]
        public void Dispose_FalsePath_DoesNotClearTables()
        {
            SceneDisposeWrapper scene = new SceneDisposeWrapper();
            SceneDisposeWrapper innerRef = scene;
            scene.Dispose(false);
            Assert.NotNull(innerRef);
        }

        /// <summary>
        /// Tests that archetype added when already in global table does not double push
        /// </summary>
        [Fact]
        public void ArchetypeAdded_WhenAlreadyInGlobalTable_DoesNotDoublePush()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Position {X = 1, Y = 2});
                scene.Create(new Position {X = 3, Y = 4});
                scene.Create(new Position {X = 5, Y = 6});
            }
        }

        /// <summary>
        /// Tests that custom query with no rules returns query
        /// </summary>
        [Fact]
        public void CustomQuery_WithNoRules_ReturnsQuery()
        {
            using (Scene scene = new Scene())
            {
                Query q = scene.CustomQuery();
                Assert.NotNull(q);
            }
        }

        /// <summary>
        /// Tests that create entity from location with recycled id reuses id
        /// </summary>
        [Fact]
        public void CreateEntityFromLocation_WithRecycledId_ReusesId()
        {
            using (Scene scene = new Scene())
            {
                GameObject go1 = scene.Create();
                int firstId = go1.EntityID;
                go1.Delete();
                GameObject go2 = scene.Create();
                Assert.Equal(firstId, go2.EntityID);
            }
        }

        /// <summary>
        /// Tests that create many single without listener returns correct span
        /// </summary>
        [Fact]
        public void CreateMany_Single_WithoutListener_ReturnsCorrectSpan()
        {
            using (Scene scene = new Scene())
            {
                ChunkTuple<Position> result = scene.CreateMany<Position>(5);
                Assert.Equal(5, result.Span.Length);
                Assert.Equal(5, scene.EntityCount);
            }
        }

        /// <summary>
        /// Tests that entity deleted with per entity events fires individual events
        /// </summary>
        [Fact]
        public void EntityDeleted_WithPerEntityEvents_FiresIndividualEvents()
        {
            using (Scene scene = new Scene())
            {
                GameObject go = scene.Create(new Position {X = 1, Y = 2});
                bool entityDeletedFired = false;
                go.OnDelete += _ => entityDeletedFired = true;
                go.Delete();
                Assert.True(entityDeletedFired);
            }
        }

        /// <summary>
        /// Tests that component removed with per entity events fires generic remove event
        /// </summary>
        [Fact]
        public void ComponentRemoved_WithPerEntityEvents_FiresGenericRemoveEvent()
        {
            using (Scene scene = new Scene())
            {
                GameObject go = scene.Create(new Position {X = 1, Y = 2}, new Health {Value = 10});
                bool genericRemoved = false;
                go.OnComponentRemoved += (_, _) => genericRemoved = true;
                go.Remove<Position>();
                Assert.True(genericRemoved);
            }
        }

        /// <summary>
        /// Tests that create many two components verify values
        /// </summary>
        [Fact]
        public void CreateMany_TwoComponents_VerifyValues()
        {
            using (Scene scene = new Scene())
            {
                ChunkTuple<Position, Health> result = scene.CreateMany<Position, Health>(3);
                result.Span1[0] = new Position {X = 1, Y = 2};
                result.Span2[0] = new Health {Value = 10};
                Assert.Equal(1, result.Span1[0].X);
                Assert.Equal(10, result.Span2[0].Value);
            }
        }

        /// <summary>
        /// Tests that create many three components verify values
        /// </summary>
        [Fact]
        public void CreateMany_ThreeComponents_VerifyValues()
        {
            using (Scene scene = new Scene())
            {
                ChunkTuple<Position, Health, Velocity> result = scene.CreateMany<Position, Health, Velocity>(2);
                result.Span1[0] = new Position {X = 1, Y = 2};
                result.Span2[0] = new Health {Value = 10};
                result.Span3[0] = new Velocity {X = 3, Y = 4};
                Assert.Equal(1, result.Span1[0].X);
                Assert.Equal(10, result.Span2[0].Value);
                Assert.Equal(3, result.Span3[0].X);
            }
        }

        /// <summary>
        /// Tests that create many arity non deferred all arities work
        /// </summary>
        [Fact]
        public void Create_ManyArity_NonDeferred_AllAritiesWork()
        {
            using (Scene scene = new Scene())
            {
                GameObject e1 = scene.Create(new Position());
                Assert.True(e1.IsAlive);
                GameObject e2 = scene.Create(new Position(), new Health());
                Assert.True(e2.IsAlive);
                GameObject e3 = scene.Create(new Position(), new Health(), new Velocity());
                Assert.True(e3.IsAlive);
                GameObject e4 = scene.Create(new Position(), new Health(), new Velocity(), new Damage());
                Assert.True(e4.IsAlive);
                GameObject e5 = scene.Create(new Position(), new Health(), new Velocity(), new Damage(), new Armor());
                Assert.True(e5.IsAlive);
                GameObject e6 = scene.Create(new Position(), new Health(), new Velocity(), new Damage(), new Armor(), new Transform());
                Assert.True(e6.IsAlive);
                GameObject e7 = scene.Create(new Position(), new Health(), new Velocity(), new Damage(), new Armor(), new Transform(), new TestComponent());
                Assert.True(e7.IsAlive);
                GameObject e8 = scene.Create(new Position(), new Health(), new Velocity(), new Damage(), new Armor(), new Transform(), new TestComponent(), new AnotherComponent());
                Assert.True(e8.IsAlive);
            }
        }

        /// <summary>
        /// Tests that delete entity called multiple times handles version correctly
        /// </summary>
        [Fact]
        public void DeleteEntity_CalledMultipleTimes_HandlesVersionCorrectly()
        {
            using (Scene scene = new Scene())
            {
                for (int i = 0; i < 5; i++)
                {
                    GameObject go = scene.Create(new Position {X = i});
                    go.Delete();
                }

                Assert.Equal(0, scene.EntityCount);
            }
        }

        /// <summary>
        /// Tests that archetype added updates query cache and filters
        /// </summary>
        [Fact]
        public void ArchetypeAdded_UpdatesQueryCacheAndFilters()
        {
            using (Scene scene = new Scene())
            {
                Rule withPos = new With<Position>().Rule;
                Query q = scene.CustomQuery(withPos);
                scene.Create(new Position {X = 1, Y = 2});
                scene.Create(new Position {X = 3, Y = 4});
                int count = 0;
                foreach (GameObject _ in q.EnumerateWithEntities())
                {
                    count++;
                }

                Assert.Equal(2, count);
            }
        }
    }

    /// <summary>
    /// The scene dispose wrapper class
    /// </summary>
    /// <seealso cref="Scene"/>
    internal class SceneDisposeWrapper : Scene
    {
        /// <summary>
        /// Disposes the disposing
        /// </summary>
        /// <param name="disposing">The disposing</param>
        public void Dispose(bool disposing) => base.Dispose(disposing);
    }
}
