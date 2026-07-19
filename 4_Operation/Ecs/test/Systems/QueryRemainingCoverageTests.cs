// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:QueryRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     Remaining coverage tests for <see cref="Query" />.
    /// </summary>
    public class QueryRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that <see cref="Scene.CreateQuery" /> with an empty rule array creates a non-null query.
        /// </summary>
        [Fact]
        public void CreateQuery_WithEmptyRules_CreatesQuery()
        {
            using Scene scene = new Scene();
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>(System.Array.Empty<Rule>());

            Query query = scene.CreateQuery(rules);

            Assert.NotNull(query);
        }

        /// <summary>
        ///     Verifies that a query with <see cref="Rule.IncludeDisabledRule" /> matches the default archetype.
        /// </summary>
        [Fact]
        public void CreateQuery_WithIncludeDisabledRule_MatchesDefaultArchetype()
        {
            using Scene scene = new Scene();
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([Rule.IncludeDisabledRule]);

            Query query = scene.CreateQuery(rules);
            Span<Archetype> archetypes = query.AsSpan();

            Assert.False(archetypes.IsEmpty);
        }

        /// <summary>
        ///     Verifies that after creating an entity, a query's <see cref="Query.AsSpan" /> returns non-empty.
        /// </summary>
        [Fact]
        public void CreateEntityThenQuery_AsSpanReturnsNonEmpty()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([Rule.IncludeDisabledRule]);

            Query query = scene.CreateQuery(rules);
            Span<Archetype> archetypes = query.AsSpan();

            Assert.False(archetypes.IsEmpty);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.Enumerate{T}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void Enumerate_SingleComponent_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([Rule.HasComponent(Component<Position>.Id)]);

            Query query = scene.CreateQuery(rules);
            QueryEnumerator<Position>.QueryEnumerable enumerable = query.Enumerate<Position>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.Enumerate{T1,T2}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void Enumerate_TwoComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            QueryEnumerator<Position, Velocity>.QueryEnumerable enumerable = query.Enumerate<Position, Velocity>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.Enumerate{T1,T2,T3}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void Enumerate_ThreeComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            QueryEnumerator<Position, Velocity, Health>.QueryEnumerable enumerable = query.Enumerate<Position, Velocity, Health>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateWithEntities{T}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateWithEntities_SingleComponent_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([Rule.HasComponent(Component<Position>.Id)]);

            Query query = scene.CreateQuery(rules);
            var enumerable = query.EnumerateWithEntities<Position>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateChunks{T}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateChunks_SingleComponent_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([Rule.HasComponent(Component<Position>.Id)]);

            Query query = scene.CreateQuery(rules);
            ChunkQueryEnumerator<Position>.QueryEnumerable enumerable = query.EnumerateChunks<Position>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateWithEntities()" /> (no generic) returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateWithEntities_NoGeneric_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([Rule.IncludeDisabledRule]);

            Query query = scene.CreateQuery(rules);
            GameObjectQueryEnumerator.QueryEnumerable enumerable = query.EnumerateWithEntities();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Rule.Delegate" /> creates a query that can be instantiated.
        /// </summary>
        [Fact]
        public void CreateQuery_WithDelegateRule_CreatesQuery()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 });
            Rule delegateRule = Rule.Delegate(id => id.HasComponent(Component<Position>.Id));
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([delegateRule]);

            Query query = scene.CreateQuery(rules);

            Assert.NotNull(query);
        }
    }
}
