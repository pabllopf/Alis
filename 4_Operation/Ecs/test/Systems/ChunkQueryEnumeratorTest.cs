// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:ChunkQueryEnumeratorTest.cs
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

namespace Alis.Core.Ecs.Test.Systems
{
    /// <summary>
    ///     Tests for ChunkQueryEnumerator arities 1..8.
    /// </summary>
    public class ChunkQueryEnumeratorTest
    {
        [Fact]
        public void ChunkQueryEnumerator_Arity1_IsRefStruct()
        {
            Assert.True(typeof(ChunkQueryEnumerator<Position>).IsByRefLike);
            Assert.True(typeof(ChunkQueryEnumerator<Position>).IsValueType);
        }

        [Fact]
        public void ChunkQueryEnumerator_Arity1_MoveNextAcrossArchetypes_Works()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2});
            scene.Create(new Position {X = 3, Y = 4}, new Velocity {VX = 9, VY = 9});
            Query query = scene.Query<With<Position>>();

            var enumerable = query.EnumerateChunks<Position>();
            using var enumerator = enumerable.GetEnumerator();

            Assert.False(scene.AllowStructualChanges);

            int chunkCount = 0;
            int entityCount = 0;
            while (enumerator.MoveNext())
            {
                ChunkTuple<Position> current = enumerator.Current;
                chunkCount++;
                entityCount += current.Span.Length;
            }

            Assert.Equal(2, chunkCount);
            Assert.Equal(2, entityCount);
        }

        [Fact]
        public void ChunkQueryEnumerator_Arity2_CurrentMapsBothSpans()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 10, Y = 20}, new Velocity {VX = 30, VY = 40});
            Query query = scene.Query<With<Position>, With<Velocity>>();

            using var enumerator = query.EnumerateChunks<Position, Velocity>().GetEnumerator();

            Assert.True(enumerator.MoveNext());
            ChunkTuple<Position, Velocity> current = enumerator.Current;

            Assert.Equal(1, current.Span1.Length);
            Assert.Equal(1, current.Span2.Length);
            Assert.Equal(10, current.Span1[0].X);
            Assert.Equal(30, current.Span2[0].VX);
        }

        [Fact]
        public void ChunkQueryEnumerator_Arity3_CurrentMapsAllSpans()
        {
            using Scene scene = new Scene();
            scene.Create(new Position {X = 1, Y = 2}, new Velocity {VX = 3, VY = 4}, new Health {Value = 5});
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>>();

            using var enumerator = query.EnumerateChunks<Position, Velocity, Health>().GetEnumerator();

            Assert.True(enumerator.MoveNext());
            ChunkTuple<Position, Velocity, Health> current = enumerator.Current;

            Assert.Equal(1, current.Span1[0].X);
            Assert.Equal(3, current.Span2[0].VX);
            Assert.Equal(5, current.Span3[0].Value);
        }

        [Fact]
        public void ChunkQueryEnumerator_Arity4_CurrentMapsAllSpans()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 3, VY = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8});
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>>();

            using var enumerator = query.EnumerateChunks<Position, Velocity, Health, Transform>().GetEnumerator();

            Assert.True(enumerator.MoveNext());
            ChunkTuple<Position, Velocity, Health, Transform> current = enumerator.Current;

            Assert.Equal(1, current.Span1[0].X);
            Assert.Equal(3, current.Span2[0].VX);
            Assert.Equal(5, current.Span3[0].Value);
            Assert.Equal(8, current.Span4[0].Rotation);
        }

        [Fact]
        public void ChunkQueryEnumerator_Arity5_CurrentMapsAllSpans()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 3, VY = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "n"});
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>>();

            using var enumerator = query.EnumerateChunks<Position, Velocity, Health, Transform, TestComponent>().GetEnumerator();

            Assert.True(enumerator.MoveNext());
            ChunkTuple<Position, Velocity, Health, Transform, TestComponent> current = enumerator.Current;

            Assert.Equal(1, current.Span1[0].X);
            Assert.Equal(3, current.Span2[0].VX);
            Assert.Equal(5, current.Span3[0].Value);
            Assert.Equal(8, current.Span4[0].Rotation);
            Assert.Equal(9, current.Span5[0].Value);
        }

        [Fact]
        public void ChunkQueryEnumerator_Arity6_CurrentMapsAllSpans()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 3, VY = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "n"},
                new AnotherComponent {X = 10, Y = 11, Name = "a"});
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>>();

            using var enumerator = query.EnumerateChunks<Position, Velocity, Health, Transform, TestComponent, AnotherComponent>().GetEnumerator();

            Assert.True(enumerator.MoveNext());
            ChunkTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent> current = enumerator.Current;

            Assert.Equal(1, current.Span1[0].X);
            Assert.Equal(3, current.Span2[0].VX);
            Assert.Equal(5, current.Span3[0].Value);
            Assert.Equal(8, current.Span4[0].Rotation);
            Assert.Equal(9, current.Span5[0].Value);
            Assert.Equal(10, current.Span6[0].X);
        }

        [Fact]
        public void ChunkQueryEnumerator_Arity7_CurrentMapsAllSpans()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 3, VY = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "n"},
                new AnotherComponent {X = 10, Y = 11, Name = "a"},
                new Damage {Amount = 12});
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>>();

            using var enumerator = query.EnumerateChunks<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>().GetEnumerator();

            Assert.True(enumerator.MoveNext());
            ChunkTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage> current = enumerator.Current;

            Assert.Equal(1, current.Span1[0].X);
            Assert.Equal(3, current.Span2[0].VX);
            Assert.Equal(5, current.Span3[0].Value);
            Assert.Equal(8, current.Span4[0].Rotation);
            Assert.Equal(9, current.Span5[0].Value);
            Assert.Equal(10, current.Span6[0].X);
            Assert.Equal(12, current.Span7[0].Amount);
        }

        [Fact]
        public void ChunkQueryEnumerator_Arity8_CurrentMapsAllSpans_AndDisposeRestoresStructuralState()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Position {X = 1, Y = 2},
                new Velocity {VX = 3, VY = 4},
                new Health {Value = 5},
                new Transform {X = 6, Y = 7, Rotation = 8},
                new TestComponent {Value = 9, Name = "n"},
                new AnotherComponent {X = 10, Y = 11, Name = "a"},
                new Damage {Amount = 12},
                new Armor {Defense = 13});
            Query query = scene.Query<With<Position>, With<Velocity>, With<Health>, With<Transform>, With<TestComponent>, With<AnotherComponent>, With<Damage>, With<Armor>>();

            Assert.True(scene.AllowStructualChanges);

            var enumerable = query.EnumerateChunks<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>();
            using var enumerator = enumerable.GetEnumerator();
            Assert.False(scene.AllowStructualChanges);

            Assert.True(enumerator.MoveNext());
            ChunkTuple<Position, Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor> current = enumerator.Current;
            Assert.Equal(1, current.Span1[0].X);
            Assert.Equal(3, current.Span2[0].VX);
            Assert.Equal(5, current.Span3[0].Value);
            Assert.Equal(8, current.Span4[0].Rotation);
            Assert.Equal(9, current.Span5[0].Value);
            Assert.Equal(10, current.Span6[0].X);
            Assert.Equal(12, current.Span7[0].Amount);
            Assert.Equal(13, current.Span8[0].Defense);

            enumerator.Dispose();
            Assert.True(scene.AllowStructualChanges);
        }
    }
}
