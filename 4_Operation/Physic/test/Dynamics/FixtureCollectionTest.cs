// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FixtureCollectionTest.cs
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
using System.Collections;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The fixture collection test class
    /// </summary>
    public class FixtureCollectionTest
    {
        /// <summary>
        /// Tests that collection should expose fixtures added to body
        /// </summary>
        [Fact]
        public void Collection_ShouldExposeFixturesAddedToBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.4f, 1.0f);

            Assert.Single(body.FixtureList);
            Assert.True(body.FixtureList.Contains(fixture));
        }

        /// <summary>
        /// Tests that collection should be read only from i collection interface
        /// </summary>
        [Fact]
        public void Collection_ShouldBeReadOnlyFromICollectionInterface()
        {
            Body body = new Body();
            FixtureCollection collection = new FixtureCollection(body);

            Assert.True(collection.IsReadOnly);
            Assert.Throws<NotSupportedException>(() => ((ICollection<Fixture>) collection).Add(new Fixture(new CircleShape(0.3f, 1.0f))));
            Assert.Throws<NotSupportedException>(() => ((ICollection<Fixture>) collection).Clear());
        }

        /// <summary>
        /// Tests that collection enumerator should iterate fixtures
        /// </summary>
        [Fact]
        public void Collection_Enumerator_ShouldIterateFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.CreateRectangle(0.5f, 0.5f, 1.0f, Vector2F.Zero);

            int count = 0;
            foreach (Fixture _ in body.FixtureList)
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        /// Tests that collection remove via icompatible throws not supported exception
        /// </summary>
        [Fact]
        public void Collection_RemoveViaICollection_ThrowsNotSupportedException()
        {
            Body body = new Body();
            FixtureCollection collection = new FixtureCollection(body);
            Fixture fixture = new Fixture(new CircleShape(0.3f, 1.0f));

            Assert.Throws<NotSupportedException>(() => ((ICollection<Fixture>)collection).Remove(fixture));
        }

        /// <summary>
        /// Tests that collection insert via ilist throws not supported exception
        /// </summary>
        [Fact]
        public void Collection_InsertViaIList_ThrowsNotSupportedException()
        {
            Body body = new Body();
            FixtureCollection collection = new FixtureCollection(body);
            Fixture fixture = new Fixture(new CircleShape(0.3f, 1.0f));

            Assert.Throws<NotSupportedException>(() => ((IList<Fixture>)collection).Insert(0, fixture));
        }

        /// <summary>
        /// Tests that collection remove at via ilist throws not supported exception
        /// </summary>
        [Fact]
        public void Collection_RemoveAtViaIList_ThrowsNotSupportedException()
        {
            Body body = new Body();
            FixtureCollection collection = new FixtureCollection(body);

            Assert.Throws<NotSupportedException>(() => ((IList<Fixture>)collection).RemoveAt(0));
        }

        /// <summary>
        /// Tests that collection set indexer via ilist throws not supported exception
        /// </summary>
        [Fact]
        public void Collection_SetIndexerViaIList_ThrowsNotSupportedException()
        {
            Body body = new Body();
            FixtureCollection collection = new FixtureCollection(body);
            Fixture fixture = new Fixture(new CircleShape(0.3f, 1.0f));

            Assert.Throws<NotSupportedException>(() => ((IList<Fixture>)collection)[0] = fixture);
        }

        /// <summary>
        /// Tests that collection copy to copies fixtures to array
        /// </summary>
        [Fact]
        public void Collection_CopyTo_CopiesFixturesToArray()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.CreateRectangle(0.5f, 0.5f, 1.0f, Vector2F.Zero);

            Fixture[] array = new Fixture[2];
            body.FixtureList.CopyTo(array, 0);

            Assert.Equal(2, array.Length);
            Assert.NotNull(array[0]);
            Assert.NotNull(array[1]);
        }

        /// <summary>
        /// Tests that collection index of returns correct index for existing fixture
        /// </summary>
        [Fact]
        public void Collection_IndexOf_ExistingFixture_ReturnsCorrectIndex()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.5f, 1.0f);

            int index = body.FixtureList.IndexOf(fixture);

            Assert.Equal(0, index);
        }

        /// <summary>
        /// Tests that collection index of missing fixture returns minus one
        /// </summary>
        [Fact]
        public void Collection_IndexOf_MissingFixture_ReturnsMinusOne()
        {
            Body body = new Body();
            FixtureCollection collection = new FixtureCollection(body);
            Fixture fixture = new Fixture(new CircleShape(0.3f, 1.0f));

            Assert.Equal(-1, collection.IndexOf(fixture));
        }

        /// <summary>
        /// Tests that collection count reflects number of fixtures
        /// </summary>
        [Fact]
        public void Collection_Count_ReflectsNumberOfFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Assert.Equal(0, body.FixtureList.Count);

            body.CreateCircle(0.5f, 1.0f);
            Assert.Equal(1, body.FixtureList.Count);

            body.CreateRectangle(0.5f, 0.5f, 1.0f, Vector2F.Zero);
            Assert.Equal(2, body.FixtureList.Count);
        }

        /// <summary>
        /// Tests that collection get indexer returns correct fixture
        /// </summary>
        [Fact]
        public void Collection_GetIndexer_ReturnsCorrectFixture()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.5f, 1.0f);

            Assert.Equal(fixture, body.FixtureList[0]);
        }

        /// <summary>
        /// Tests that collection typed enumerator move next returns false when exhausted
        /// </summary>
        [Fact]
        public void Collection_Enumerator_MoveNext_ReturnsFalseWhenExhausted()
        {
            Body body = new Body();
            FixtureCollection collection = new FixtureCollection(body);
            FixtureCollection.FixtureEnumerator enumerator = collection.GetEnumerator();

            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        /// Tests that collection enumerator reset via i enumerator interface works
        /// </summary>
        [Fact]
        public void Collection_Enumerator_ResetViaIEnumerator_Works()
        {
            Body body = new Body();
            FixtureCollection collection = new FixtureCollection(body);
            FixtureCollection.FixtureEnumerator enumerator = collection.GetEnumerator();

            IEnumerator boxed = enumerator;
            boxed.Reset();
        }

        /// <summary>
        /// Tests that enumerator current throws invalid operation when collection modified during enumeration
        /// </summary>
        [Fact]
        public void Enumerator_Current_WhenCollectionModified_ThrowsInvalidOperation()
        {
            Body body = new Body();
            FixtureCollection collection = new FixtureCollection(body);
            FixtureCollection.FixtureEnumerator enumerator = collection.GetEnumerator();

            collection.List.Add(new Fixture(new CircleShape(0.3f, 1.0f)));
            collection.GenerationStamp++;

            Assert.Throws<InvalidOperationException>(() => enumerator.Current);
        }

        /// <summary>
        /// Tests that enumerator move next throws invalid operation when collection modified
        /// </summary>
        [Fact]
        public void Enumerator_MoveNext_WhenCollectionModified_ThrowsInvalidOperation()
        {
            Body body = new Body();
            FixtureCollection collection = new FixtureCollection(body);
            FixtureCollection.FixtureEnumerator enumerator = collection.GetEnumerator();

            collection.List.Add(new Fixture(new CircleShape(0.3f, 1.0f)));
            collection.GenerationStamp++;

            Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());
        }

        /// <summary>
        /// Tests that collection enumerator dispose clears references
        /// </summary>
        [Fact]
        public void Collection_Enumerator_Dispose_ClearsReferences()
        {
            Body body = new Body();
            FixtureCollection collection = new FixtureCollection(body);
            FixtureCollection.FixtureEnumerator enumerator = collection.GetEnumerator();

            ((IDisposable)enumerator).Dispose();
        }

        /// <summary>
        ///     Tests that generic i enumerable get enumerator returns typed enumerator
        /// </summary>
        [Fact]
        public void GenericEnumerable_GetEnumerator_ReturnsTypedEnumerator()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            IEnumerator<Fixture> enumerator = ((IEnumerable<Fixture>)body.FixtureList).GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.NotNull(enumerator.Current);
        }

        /// <summary>
        ///     Tests that non generic i enumerable get enumerator returns enumerator
        /// </summary>
        [Fact]
        public void NonGenericEnumerable_GetEnumerator_ReturnsEnumerator()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            IEnumerator enumerator = ((IEnumerable)body.FixtureList).GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.NotNull(enumerator.Current);
        }

        /// <summary>
        ///     Tests that non generic enumerator current throws when collection modified
        /// </summary>
        [Fact]
        public void NonGenericEnumerator_Current_WhenCollectionModified_ThrowsInvalidOperation()
        {
            Body body = new Body();
            FixtureCollection collection = new FixtureCollection(body);
            IEnumerator enumerator = ((IEnumerable)collection).GetEnumerator();

            collection.List.Add(new Fixture(new CircleShape(0.3f, 1.0f)));
            collection.GenerationStamp++;

            Assert.Throws<InvalidOperationException>(() => enumerator.Current);
        }
    }
}

