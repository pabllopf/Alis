

using System;
using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The body collection test class
    /// </summary>
    public class BodyCollectionTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with world
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithWorld()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));

            BodyCollection collection = new BodyCollection(world);

            Assert.NotNull(collection);
            Assert.Equal(0, collection.Count);
        }

        /// <summary>
        ///     Tests that is read only should return true
        /// </summary>
        [Fact]
        public void IsReadOnly_ShouldReturnTrue()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            BodyCollection collection = new BodyCollection(world);

            Assert.True(collection.IsReadOnly);
        }

        /// <summary>
        ///     Tests that count should return number of bodies
        /// </summary>
        [Fact]
        public void Count_ShouldReturnNumberOfBodies()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            world.CreateBody();
            world.CreateBody();

            Assert.Equal(2, world.BodyList.Count);
        }

        /// <summary>
        ///     Tests that indexer should return body at index
        /// </summary>
        [Fact]
        public void Indexer_ShouldReturnBodyAtIndex()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();

            Body retrievedBody = world.BodyList[0];

            Assert.Equal(body, retrievedBody);
        }

        /// <summary>
        ///     Tests that indexer set should throw not supported exception
        /// </summary>
        [Fact]
        public void IndexerSet_ShouldThrowNotSupportedException()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            world.CreateBody();
            Body newBody = new Body();

            Assert.Throws<NotSupportedException>(() => world.BodyList[0] = newBody);
        }

        /// <summary>
        ///     Tests that contains should return true for existing body
        /// </summary>
        [Fact]
        public void Contains_ShouldReturnTrue_ForExistingBody()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();

            bool contains = world.BodyList.Contains(body);

            Assert.True(contains);
        }

        /// <summary>
        ///     Tests that contains should return false for non existing body
        /// </summary>
        [Fact]
        public void Contains_ShouldReturnFalse_ForNonExistingBody()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = new Body();

            bool contains = world.BodyList.Contains(body);

            Assert.False(contains);
        }

        /// <summary>
        ///     Tests that index of should return correct index
        /// </summary>
        [Fact]
        public void IndexOf_ShouldReturnCorrectIndex()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            world.CreateBody();
            Body body = world.CreateBody();

            int index = world.BodyList.IndexOf(body);

            Assert.Equal(1, index);
        }

        /// <summary>
        ///     Tests that copy to should copy bodies to array
        /// </summary>
        [Fact]
        public void CopyTo_ShouldCopyBodiesToArray()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            world.CreateBody();
            world.CreateBody();
            Body[] array = new Body[2];

            world.BodyList.CopyTo(array, 0);

            Assert.NotNull(array[0]);
            Assert.NotNull(array[1]);
        }

        /// <summary>
        ///     Tests that get enumerator should enumerate bodies
        /// </summary>
        [Fact]
        public void GetEnumerator_ShouldEnumerateBodies()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            world.CreateBody();
            world.CreateBody();
            int count = 0;

            foreach (Body body in world.BodyList)
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that add should throw not supported exception
        /// </summary>
        [Fact]
        public void Add_ShouldThrowNotSupportedException()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = new Body();

            Assert.Throws<NotSupportedException>(() => ((ICollection<Body>) world.BodyList).Add(body));
        }

        /// <summary>
        ///     Tests that remove should throw not supported exception
        /// </summary>
        [Fact]
        public void Remove_ShouldThrowNotSupportedException()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();

            Assert.Throws<NotSupportedException>(() => ((ICollection<Body>) world.BodyList).Remove(body));
        }

        /// <summary>
        ///     Tests that clear should throw not supported exception
        /// </summary>
        [Fact]
        public void Clear_ShouldThrowNotSupportedException()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));

            Assert.Throws<NotSupportedException>(() => ((ICollection<Body>) world.BodyList).Clear());
        }

        /// <summary>
        ///     Tests that insert should throw not supported exception
        /// </summary>
        [Fact]
        public void Insert_ShouldThrowNotSupportedException()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = new Body();

            Assert.Throws<NotSupportedException>(() => ((IList<Body>) world.BodyList).Insert(0, body));
        }

        /// <summary>
        ///     Tests that remove at should throw not supported exception
        /// </summary>
        [Fact]
        public void RemoveAt_ShouldThrowNotSupportedException()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            world.CreateBody();

            Assert.Throws<NotSupportedException>(() => ((IList<Body>) world.BodyList).RemoveAt(0));
        }

        /// <summary>
        ///     Tests that body collection should support linq queries
        /// </summary>
        [Fact]
        public void BodyCollection_ShouldSupportLinqQueries()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            world.CreateBody();
            world.CreateBody();

            int count = world.BodyList.Count(b => b != null);

            Assert.Equal(2, count);
        }
    }
}