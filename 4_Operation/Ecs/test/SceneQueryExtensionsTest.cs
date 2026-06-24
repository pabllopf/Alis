// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneQueryExtensionsTest.cs
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
    ///     Tests for <see cref="SceneQueryExtensions"/> extension methods.
    /// </summary>
    /// <remarks>
    ///     Validates that all arities of <c>Query&lt;T1..TN&gt;()</c> create valid queries
    ///     and correctly cache them on subsequent calls.
    /// </remarks>
    public class SceneQueryExtensionsTest
    {
        /// <summary>
        ///     Tests that Query&lt;T&gt; returns a query that enumerates matching entities.
        /// </summary>
        [Fact]
        public void Query_1_ReturnsQueryThatEnumeratesEntities()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1});

            Query query = scene.Query<With<Position>>();
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that Query&lt;T1, T2&gt; returns a query that enumerates matching entities.
        /// </summary>
        [Fact]
        public void Query_2_ReturnsQueryThatEnumeratesEntities()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1}, new Health {Value = 100});

            Query query = scene.Query<With<Position>, With<Health>>();
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position, Health>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that Query&lt;T1, T2, T3&gt; returns a query that enumerates matching entities.
        /// </summary>
        [Fact]
        public void Query_3_ReturnsQueryThatEnumeratesEntities()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1}, new Health {Value = 100}, new Velocity {X = 1});

            Query query = scene.Query<With<Position>, With<Health>, With<Velocity>>();
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position, Health, Velocity>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that Query&lt;T1, T2, T3, T4&gt; returns a query that enumerates matching entities.
        /// </summary>
        [Fact]
        public void Query_4_ReturnsQueryThatEnumeratesEntities()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1}, new Health {Value = 100}, new Velocity {X = 1}, new Armor {Value = 50});

            Query query = scene.Query<With<Position>, With<Health>, With<Velocity>, With<Armor>>();
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position, Health, Velocity, Armor>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that Query&lt;T1, T2, T3, T4, T5&gt; returns a query that enumerates matching entities.
        /// </summary>
        [Fact]
        public void Query_5_ReturnsQueryThatEnumeratesEntities()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1},
                new Health {Value = 100},
                new Velocity {X = 1},
                new Armor {Value = 50},
                new Damage {Value = 25});

            Query query = scene.Query<With<Position>, With<Health>, With<Velocity>, With<Armor>, With<Damage>>();
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position, Health, Velocity, Armor, Damage>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that Query&lt;T1..T6&gt; returns a query that enumerates matching entities.
        /// </summary>
        [Fact]
        public void Query_6_ReturnsQueryThatEnumeratesEntities()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1},
                new Health {Value = 100},
                new Velocity {X = 1},
                new Armor {Value = 50},
                new Damage {Value = 25},
                new EnemyTag());

            Query query = scene.Query<With<Position>, With<Health>, With<Velocity>, With<Armor>, With<Damage>, With<EnemyTag>>();
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position, Health, Velocity, Armor, Damage, EnemyTag>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that Query&lt;T1..T7&gt; returns a query that enumerates matching entities.
        /// </summary>
        [Fact]
        public void Query_7_ReturnsQueryThatEnumeratesEntities()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1},
                new Health {Value = 100},
                new Velocity {X = 1},
                new Armor {Value = 50},
                new Damage {Value = 25},
                new EnemyTag(),
                new PlayerTag());

            Query query = scene.Query<With<Position>, With<Health>, With<Velocity>, With<Armor>, With<Damage>, With<EnemyTag>, With<PlayerTag>>();
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position, Health, Velocity, Armor, Damage, EnemyTag, PlayerTag>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that Query&lt;T1..T8&gt; returns a query that enumerates matching entities.
        /// </summary>
        [Fact]
        public void Query_8_ReturnsQueryThatEnumeratesEntities()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1},
                new Health {Value = 100},
                new Velocity {X = 1},
                new Armor {Value = 50},
                new Damage {Value = 25},
                new EnemyTag(),
                new PlayerTag(),
                new TagComponent());

            Query query = scene.Query<With<Position>, With<Health>, With<Velocity>, With<Armor>, With<Damage>, With<EnemyTag>, With<PlayerTag>, With<TagComponent>>();
            int count = 0;
            foreach (var _ in query.EnumerateWithEntities<Position, Health, Velocity, Armor, Damage, EnemyTag, PlayerTag, TagComponent>())
            {
                count++;
            }

            Assert.Equal(1, count);
        }

        /// <summary>
        ///     Tests that Query&lt;T&gt; caches the query instance across repeated calls.
        /// </summary>
        [Fact]
        public void Query_1_CachesQueryInstance()
        {
            using Scene scene = new Scene();

            Query first = scene.Query<With<Position>>();
            Query second = scene.Query<With<Position>>();

            Assert.Same(first, second);
        }

        /// <summary>
        ///     Tests that Query&lt;T1, T2&gt; caches the query instance across repeated calls.
        /// </summary>
        [Fact]
        public void Query_2_CachesQueryInstance()
        {
            using Scene scene = new Scene();

            Query first = scene.Query<With<Position>, With<Health>>();
            Query second = scene.Query<With<Position>, With<Health>>();

            Assert.Same(first, second);
        }

        /// <summary>
        ///     Tests that Query&lt;T1, T2, T3&gt; caches the query instance across repeated calls.
        /// </summary>
        [Fact]
        public void Query_3_CachesQueryInstance()
        {
            using Scene scene = new Scene();

            Query first = scene.Query<With<Position>, With<Health>, With<Velocity>>();
            Query second = scene.Query<With<Position>, With<Health>, With<Velocity>>();

            Assert.Same(first, second);
        }

        /// <summary>
        ///     Tests that Query&lt;T1..T4&gt; caches the query instance across repeated calls.
        /// </summary>
        [Fact]
        public void Query_4_CachesQueryInstance()
        {
            using Scene scene = new Scene();

            Query first = scene.Query<With<Position>, With<Health>, With<Velocity>, With<Armor>>();
            Query second = scene.Query<With<Position>, With<Health>, With<Velocity>, With<Armor>>();

            Assert.Same(first, second);
        }

        /// <summary>
        ///     Tests that Query&lt;T1..T5&gt; caches the query instance across repeated calls.
        /// </summary>
        [Fact]
        public void Query_5_CachesQueryInstance()
        {
            using Scene scene = new Scene();

            Query first = scene.Query<With<Position>, With<Health>, With<Velocity>, With<Armor>, With<Damage>>();
            Query second = scene.Query<With<Position>, With<Health>, With<Velocity>, With<Armor>, With<Damage>>();

            Assert.Same(first, second);
        }

        /// <summary>
        ///     Tests that Query&lt;T1..T6&gt; caches the query instance across repeated calls.
        /// </summary>
        [Fact]
        public void Query_6_CachesQueryInstance()
        {
            using Scene scene = new Scene();

            Query first = scene.Query<With<Position>, With<Health>, With<Velocity>, With<Armor>, With<Damage>, With<EnemyTag>>();
            Query second = scene.Query<With<Position>, With<Health>, With<Velocity>, With<Armor>, With<Damage>, With<EnemyTag>>();

            Assert.Same(first, second);
        }

        /// <summary>
        ///     Tests that Query&lt;T1..T7&gt; caches the query instance across repeated calls.
        /// </summary>
        [Fact]
        public void Query_7_CachesQueryInstance()
        {
            using Scene scene = new Scene();

            Query first = scene.Query<With<Position>, With<Health>, With<Velocity>, With<Armor>, With<Damage>, With<EnemyTag>, With<PlayerTag>>();
            Query second = scene.Query<With<Position>, With<Health>, With<Velocity>, With<Armor>, With<Damage>, With<EnemyTag>, With<PlayerTag>>();

            Assert.Same(first, second);
        }

        /// <summary>
        ///     Tests that Query&lt;T1..T8&gt; caches the query instance across repeated calls.
        /// </summary>
        [Fact]
        public void Query_8_CachesQueryInstance()
        {
            using Scene scene = new Scene();

            Query first = scene.Query<With<Position>, With<Health>, With<Velocity>, With<Armor>, With<Damage>, With<EnemyTag>, With<PlayerTag>, With<TagComponent>>();
            Query second = scene.Query<With<Position>, With<Health>, With<Velocity>, With<Armor>, With<Damage>, With<EnemyTag>, With<PlayerTag>, With<TagComponent>>();

            Assert.Same(first, second);
        }

        /// <summary>
        ///     Tests that queries with different type combinations are cached independently.
        /// </summary>
        [Fact]
        public void Query_DifferentTypeCombinations_AreCachedIndependently()
        {
            using Scene scene = new Scene();

            Query single = scene.Query<With<Position>>();
            Query pair = scene.Query<With<Position>, With<Health>>();

            Assert.NotSame(single, pair);
        }

        /// <summary>
        ///     Tests that Query returns empty result for entity without matching component.
        /// </summary>
        [Fact]
        public void Query_ReturnsEmpty_WhenNoMatch()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1});

            Query query = scene.Query<With<Velocity>>();
            int count = 0;
            foreach (Ecs.Systems.GameObjectRefTuple<Velocity> _ in query.EnumerateWithEntities<Velocity>())
            {
                count++;
            }

            Assert.Equal(0, count);
        }
    }
}
