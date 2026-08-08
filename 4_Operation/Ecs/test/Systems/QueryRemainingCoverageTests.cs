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
            Ecs.Systems.GameObjectQueryEnumerator<Position>.QueryEnumerable enumerable = query.EnumerateWithEntities<Position>();

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
        /// <summary>
        ///     Verifies that a query with a rule that matches no archetype returns an empty span.
        ///     Exercises the false-return path in <see cref="Query.ArchetypeSatisfiesQuery" />.
        /// </summary>
        [Fact]
        public void ArchetypeSatisfiesQuery_WithUnmatchedRule_ReturnsEmptySpan()
        {
            using Scene scene = new Scene();
            Rule rule = Rule.HasComponent(Component<Position>.Id);
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([rule]);

            Query query = scene.CreateQuery(rules);
            Span<Archetype> archetypes = query.AsSpan();

            Assert.True(archetypes.IsEmpty);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateWithEntities{T1,T2}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateWithEntities_TwoComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            QueryEnumerable<Position, Velocity> enumerable = query.EnumerateWithEntities<Position, Velocity>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateChunks{T1,T2}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateChunks_TwoComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            ChunkQueryEnumerator<Position, Velocity>.QueryEnumerable enumerable = query.EnumerateChunks<Position, Velocity>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateWithEntities{T1,T2,T3}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateWithEntities_ThreeComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            QueryEnumerable<Position, Velocity, Health> enumerable = query.EnumerateWithEntities<Position, Velocity, Health>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.Enumerate{T1,T2,T3,T4}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void Enumerate_FourComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 }, new Transform { X = 5, Y = 6, Rotation = 0 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id),
                Rule.HasComponent(Component<Transform>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            QueryEnumerator<Position, Velocity, Health, Transform>.QueryEnumerable enumerable = query.Enumerate<Position, Velocity, Health, Transform>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateWithEntities{T1,T2,T3,T4}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateWithEntities_FourComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 }, new Transform { X = 5, Y = 6, Rotation = 0 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id),
                Rule.HasComponent(Component<Transform>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            QueryEnumerable<Position, Velocity, Health, Transform> enumerable = query.EnumerateWithEntities<Position, Velocity, Health, Transform>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateChunks{T1,T2,T3,T4}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateChunks_FourComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 }, new Transform { X = 5, Y = 6, Rotation = 0 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id),
                Rule.HasComponent(Component<Transform>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            ChunkQueryEnumerator<Position, Velocity, Health, Transform>.QueryEnumerable enumerable = query.EnumerateChunks<Position, Velocity, Health, Transform>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.Enumerate{T1,T2,T3,T4,T5}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void Enumerate_FiveComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 }, new Transform { X = 5, Y = 6, Rotation = 0 }, new TestComponent { Value = 7, Name = "test" });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id),
                Rule.HasComponent(Component<Transform>.Id),
                Rule.HasComponent(Component<TestComponent>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            QueryEnumerator<Position, Velocity, Health, Transform, TestComponent>.QueryEnumerable enumerable = query.Enumerate<Position, Velocity, Health, Transform, TestComponent>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateWithEntities{T1,T2,T3,T4,T5}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateWithEntities_FiveComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 }, new Transform { X = 5, Y = 6, Rotation = 0 }, new TestComponent { Value = 7, Name = "test" });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id),
                Rule.HasComponent(Component<Transform>.Id),
                Rule.HasComponent(Component<TestComponent>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            QueryEnumerable<Position, Velocity, Health, Transform, TestComponent> enumerable = query.EnumerateWithEntities<Position, Velocity, Health, Transform, TestComponent>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateChunks{T1,T2,T3,T4,T5}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateChunks_FiveComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 }, new Transform { X = 5, Y = 6, Rotation = 0 }, new TestComponent { Value = 7, Name = "test" });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id),
                Rule.HasComponent(Component<Transform>.Id),
                Rule.HasComponent(Component<TestComponent>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            ChunkQueryEnumerator<Position, Velocity, Health, Transform, TestComponent>.QueryEnumerable enumerable = query.EnumerateChunks<Position, Velocity, Health, Transform, TestComponent>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.Enumerate{T1,T2,T3,T4,T5,T6}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void Enumerate_SixComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 }, new Transform { X = 5, Y = 6, Rotation = 0 }, new TestComponent { Value = 7, Name = "test" }, new AnotherComponent { Data = 8, Y = 9, Name = "a" });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id),
                Rule.HasComponent(Component<Transform>.Id),
                Rule.HasComponent(Component<TestComponent>.Id),
                Rule.HasComponent(Component<AnotherComponent>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            QueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>.QueryEnumerable enumerable = query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateWithEntities{T1,T2,T3,T4,T5,T6}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateWithEntities_SixComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 }, new Transform { X = 5, Y = 6, Rotation = 0 }, new TestComponent { Value = 7, Name = "test" }, new AnotherComponent { Data = 8, Y = 9, Name = "a" });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id),
                Rule.HasComponent(Component<Transform>.Id),
                Rule.HasComponent(Component<TestComponent>.Id),
                Rule.HasComponent(Component<AnotherComponent>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> enumerable = query.EnumerateWithEntities<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateChunks{T1,T2,T3,T4,T5,T6}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateChunks_SixComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 }, new Transform { X = 5, Y = 6, Rotation = 0 }, new TestComponent { Value = 7, Name = "test" }, new AnotherComponent { Data = 8, Y = 9, Name = "a" });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id),
                Rule.HasComponent(Component<Transform>.Id),
                Rule.HasComponent(Component<TestComponent>.Id),
                Rule.HasComponent(Component<AnotherComponent>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            ChunkQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>.QueryEnumerable enumerable = query.EnumerateChunks<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.Enumerate{T1,T2,T3,T4,T5,T6,T7}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void Enumerate_SevenComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 }, new Transform { X = 5, Y = 6, Rotation = 0 }, new TestComponent { Value = 7, Name = "test" }, new AnotherComponent { Data = 8, Y = 9, Name = "a" }, new Damage { Value = 10 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id),
                Rule.HasComponent(Component<Transform>.Id),
                Rule.HasComponent(Component<TestComponent>.Id),
                Rule.HasComponent(Component<AnotherComponent>.Id),
                Rule.HasComponent(Component<Damage>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            QueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>.QueryEnumerable enumerable = query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateWithEntities{T1,T2,T3,T4,T5,T6,T7}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateWithEntities_SevenComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 }, new Transform { X = 5, Y = 6, Rotation = 0 }, new TestComponent { Value = 7, Name = "test" }, new AnotherComponent { Data = 8, Y = 9, Name = "a" }, new Damage { Value = 10 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id),
                Rule.HasComponent(Component<Transform>.Id),
                Rule.HasComponent(Component<TestComponent>.Id),
                Rule.HasComponent(Component<AnotherComponent>.Id),
                Rule.HasComponent(Component<Damage>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage> enumerable = query.EnumerateWithEntities<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateChunks{T1,T2,T3,T4,T5,T6,T7}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateChunks_SevenComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 }, new Transform { X = 5, Y = 6, Rotation = 0 }, new TestComponent { Value = 7, Name = "test" }, new AnotherComponent { Data = 8, Y = 9, Name = "a" }, new Damage { Value = 10 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id),
                Rule.HasComponent(Component<Transform>.Id),
                Rule.HasComponent(Component<TestComponent>.Id),
                Rule.HasComponent(Component<AnotherComponent>.Id),
                Rule.HasComponent(Component<Damage>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            ChunkQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>.QueryEnumerable enumerable = query.EnumerateChunks<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.Enumerate{T1,T2,T3,T4,T5,T6,T7,T8}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void Enumerate_EightComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 }, new Transform { X = 5, Y = 6, Rotation = 0 }, new TestComponent { Value = 7, Name = "test" }, new AnotherComponent { Data = 8, Y = 9, Name = "a" }, new Damage { Value = 10 }, new Armor { Value = 11 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id),
                Rule.HasComponent(Component<Transform>.Id),
                Rule.HasComponent(Component<TestComponent>.Id),
                Rule.HasComponent(Component<AnotherComponent>.Id),
                Rule.HasComponent(Component<Damage>.Id),
                Rule.HasComponent(Component<Armor>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            QueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>.QueryEnumerable enumerable = query.Enumerate<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateWithEntities{T1,T2,T3,T4,T5,T6,T7,T8}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateWithEntities_EightComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 }, new Transform { X = 5, Y = 6, Rotation = 0 }, new TestComponent { Value = 7, Name = "test" }, new AnotherComponent { Data = 8, Y = 9, Name = "a" }, new Damage { Value = 10 }, new Armor { Value = 11 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id),
                Rule.HasComponent(Component<Transform>.Id),
                Rule.HasComponent(Component<TestComponent>.Id),
                Rule.HasComponent(Component<AnotherComponent>.Id),
                Rule.HasComponent(Component<Damage>.Id),
                Rule.HasComponent(Component<Armor>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            QueryEnumerable<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> enumerable = query.EnumerateWithEntities<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>();

            Assert.NotNull(enumerable);
        }

        /// <summary>
        ///     Verifies that <see cref="Query.EnumerateChunks{T1,T2,T3,T4,T5,T6,T7,T8}()" /> returns a non-null enumerable.
        /// </summary>
        [Fact]
        public void EnumerateChunks_EightComponents_ReturnsEnumerable()
        {
            using Scene scene = new Scene();
            scene.Create(new Position { X = 1, Y = 2 }, new Velocity { X = 3, Y = 4 }, new Health { Value = 100 }, new Transform { X = 5, Y = 6, Rotation = 0 }, new TestComponent { Value = 7, Name = "test" }, new AnotherComponent { Data = 8, Y = 9, Name = "a" }, new Damage { Value = 10 }, new Armor { Value = 11 });
            FastImmutableArray<Rule> rules = new FastImmutableArray<Rule>([
                Rule.HasComponent(Component<Position>.Id),
                Rule.HasComponent(Component<Velocity>.Id),
                Rule.HasComponent(Component<Health>.Id),
                Rule.HasComponent(Component<Transform>.Id),
                Rule.HasComponent(Component<TestComponent>.Id),
                Rule.HasComponent(Component<AnotherComponent>.Id),
                Rule.HasComponent(Component<Damage>.Id),
                Rule.HasComponent(Component<Armor>.Id)
            ]);

            Query query = scene.CreateQuery(rules);
            ChunkQueryEnumerator<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>.QueryEnumerable enumerable = query.EnumerateChunks<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>();

            Assert.NotNull(enumerable);
        }
    }
}
