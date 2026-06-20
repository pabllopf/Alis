// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JointCollectionTest.cs
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
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The joint collection test class
    /// </summary>
    public class JointCollectionTest
    {
        /// <summary>
        /// Tests that collection should expose joints added through world
        /// </summary>
        [Fact]
        public void Collection_ShouldExposeJointsAddedThroughWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);

            Joint joint = JointFactory.CreateDistanceJoint(world, bodyA, bodyB);

            Assert.Single(world.JointList);
            Assert.True(world.JointList.Contains(joint));
        }

        /// <summary>
        /// Tests that collection should be read only from i collection interface
        /// </summary>
        [Fact]
        public void Collection_ShouldBeReadOnlyFromICollectionInterface()
        {
            JointCollection collection = new WorldPhysic(Vector2F.Zero).JointList;

            Assert.True(collection.IsReadOnly);
            Assert.Throws<NotSupportedException>(() => ((ICollection<Joint>) collection).Clear());
        }

        /// <summary>
        /// Tests that collection enumerator should iterate all joints
        /// </summary>
        [Fact]
        public void Collection_Enumerator_ShouldIterateAllJoints()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyC = world.CreateCircle(0.5f, 1.0f, new Vector2F(2.0f, 0.0f), BodyType.Dynamic);
            JointFactory.CreateDistanceJoint(world, bodyA, bodyB);
            JointFactory.CreateDistanceJoint(world, bodyB, bodyC);

            int count = 0;
            foreach (Joint _ in world.JointList)
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        /// Tests that contains returns true for joint in collection
        /// </summary>
        [Fact]
        public void Contains_WithJointInCollection_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            Joint joint = JointFactory.CreateDistanceJoint(world, bodyA, bodyB);

            bool result = world.JointList.Contains(joint);

            Assert.True(result);
        }

        /// <summary>
        /// Tests that contains returns false for joint not in collection
        /// </summary>
        [Fact]
        public void Contains_WithJointNotInCollection_ReturnsFalse()
        {
            JointCollection collection = new JointCollection(new WorldPhysic(Vector2F.Zero));
            Joint joint = new DistanceJoint();

            bool result = collection.Contains(joint);

            Assert.False(result);
        }

        /// <summary>
        /// Tests that index of returns correct index for existing joint
        /// </summary>
        [Fact]
        public void IndexOf_ExistingJoint_ReturnsCorrectIndex()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            Joint joint = JointFactory.CreateDistanceJoint(world, bodyA, bodyB);

            int index = world.JointList.IndexOf(joint);

            Assert.Equal(0, index);
        }

        /// <summary>
        /// Tests that index of returns minus one for missing joint
        /// </summary>
        [Fact]
        public void IndexOf_MissingJoint_ReturnsMinusOne()
        {
            JointCollection collection = new JointCollection(new WorldPhysic(Vector2F.Zero));
            Joint joint = new DistanceJoint();

            Assert.Equal(-1, collection.IndexOf(joint));
        }

        /// <summary>
        /// Tests that count reflects number of joints
        /// </summary>
        [Fact]
        public void Count_ReflectsNumberOfJoints()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyC = world.CreateCircle(0.5f, 1.0f, new Vector2F(2.0f, 0.0f), BodyType.Dynamic);

            Assert.Equal(0, world.JointList.Count);
            JointFactory.CreateDistanceJoint(world, bodyA, bodyB);
            Assert.Equal(1, world.JointList.Count);
            JointFactory.CreateDistanceJoint(world, bodyB, bodyC);
            Assert.Equal(2, world.JointList.Count);
        }

        /// <summary>
        /// Tests that get indexer returns correct joint
        /// </summary>
        [Fact]
        public void GetIndexer_ReturnsCorrectJoint()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            Joint joint = JointFactory.CreateDistanceJoint(world, bodyA, bodyB);

            Assert.Equal(joint, world.JointList[0]);
        }

        /// <summary>
        /// Tests that set indexer via i list throws not supported exception
        /// </summary>
        [Fact]
        public void SetIndexerViaIList_ThrowsNotSupportedException()
        {
            JointCollection collection = new JointCollection(new WorldPhysic(Vector2F.Zero));

            Assert.Throws<NotSupportedException>(() => ((IList<Joint>)collection)[0] = null!);
        }

        /// <summary>
        /// Tests that collection add via i collection throws not supported exception
        /// </summary>
        [Fact]
        public void AddViaICollection_ThrowsNotSupportedException()
        {
            JointCollection collection = new JointCollection(new WorldPhysic(Vector2F.Zero));

            Assert.Throws<NotSupportedException>(() => ((ICollection<Joint>)collection).Add(null!));
        }

        /// <summary>
        /// Tests that collection remove via i collection throws not supported exception
        /// </summary>
        [Fact]
        public void RemoveViaICollection_ThrowsNotSupportedException()
        {
            JointCollection collection = new JointCollection(new WorldPhysic(Vector2F.Zero));

            Assert.Throws<NotSupportedException>(() => ((ICollection<Joint>)collection).Remove(null!));
        }

        /// <summary>
        /// Tests that collection insert via i list throws not supported exception
        /// </summary>
        [Fact]
        public void InsertViaIList_ThrowsNotSupportedException()
        {
            JointCollection collection = new JointCollection(new WorldPhysic(Vector2F.Zero));

            Assert.Throws<NotSupportedException>(() => ((IList<Joint>)collection).Insert(0, null!));
        }

        /// <summary>
        /// Tests that collection remove at via i list throws not supported exception
        /// </summary>
        [Fact]
        public void RemoveAtViaIList_ThrowsNotSupportedException()
        {
            JointCollection collection = new JointCollection(new WorldPhysic(Vector2F.Zero));

            Assert.Throws<NotSupportedException>(() => ((IList<Joint>)collection).RemoveAt(0));
        }

        /// <summary>
        /// Tests that collection copy to copies joints to array
        /// </summary>
        [Fact]
        public void CopyTo_CopiesJointsToArray()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-2.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyC = world.CreateCircle(0.5f, 1.0f, new Vector2F(2.0f, 0.0f), BodyType.Dynamic);
            JointFactory.CreateDistanceJoint(world, bodyA, bodyB);
            JointFactory.CreateDistanceJoint(world, bodyB, bodyC);

            Joint[] array = new Joint[2];
            world.JointList.CopyTo(array, 0);

            Assert.Equal(2, array.Length);
            Assert.NotNull(array[0]);
            Assert.NotNull(array[1]);
        }

        /// <summary>
        /// Tests that generic enumerable get enumerator returns typed enumerator
        /// </summary>
        [Fact]
        public void GenericEnumerable_GetEnumerator_ReturnsTypedEnumerator()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            JointFactory.CreateDistanceJoint(world, bodyA, bodyB);

            IEnumerator<Joint> enumerator = ((IEnumerable<Joint>)world.JointList).GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.NotNull(enumerator.Current);
        }

        /// <summary>
        /// Tests that non generic enumerable get enumerator returns enumerator
        /// </summary>
        [Fact]
        public void NonGenericEnumerable_GetEnumerator_ReturnsEnumerator()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-1.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            JointFactory.CreateDistanceJoint(world, bodyA, bodyB);

            IEnumerator enumerator = ((IEnumerable)world.JointList).GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.NotNull(enumerator.Current);
        }

        /// <summary>
        /// Tests that enumerator move next returns false when exhausted
        /// </summary>
        [Fact]
        public void Enumerator_MoveNext_ReturnsFalseWhenExhausted()
        {
            JointCollection collection = new JointCollection(new WorldPhysic(Vector2F.Zero));
            JointCollection.JointEnumerator enumerator = collection.GetEnumerator();

            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        /// Tests that enumerator current throws when collection modified
        /// </summary>
        [Fact]
        public void Enumerator_Current_WhenCollectionModified_ThrowsInvalidOperation()
        {
            JointCollection collection = new JointCollection(new WorldPhysic(Vector2F.Zero));
            JointCollection.JointEnumerator enumerator = collection.GetEnumerator();

            collection.List.Add(new DistanceJoint());
            collection.GenerationStamp++;

            Assert.Throws<InvalidOperationException>(() => enumerator.Current);
        }

        /// <summary>
        /// Tests that enumerator move next throws when collection modified
        /// </summary>
        [Fact]
        public void Enumerator_MoveNext_WhenCollectionModified_ThrowsInvalidOperation()
        {
            JointCollection collection = new JointCollection(new WorldPhysic(Vector2F.Zero));
            JointCollection.JointEnumerator enumerator = collection.GetEnumerator();

            collection.List.Add(new DistanceJoint());
            collection.GenerationStamp++;

            Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());
        }

        /// <summary>
        /// Tests that enumerator dispose clears references
        /// </summary>
        [Fact]
        public void Enumerator_Dispose_ClearsReferences()
        {
            JointCollection collection = new JointCollection(new WorldPhysic(Vector2F.Zero));
            JointCollection.JointEnumerator enumerator = collection.GetEnumerator();

            ((IDisposable)enumerator).Dispose();
        }

        /// <summary>
        /// Tests that enumerator reset works
        /// </summary>
        [Fact]
        public void Enumerator_Reset_Works()
        {
            JointCollection collection = new JointCollection(new WorldPhysic(Vector2F.Zero));
            IEnumerator enumerator = collection.GetEnumerator();

            enumerator.Reset();
        }

        /// <summary>
        /// Tests that non generic enumerator current throws when collection modified
        /// </summary>
        [Fact]
        public void NonGenericEnumerator_Current_WhenCollectionModified_ThrowsInvalidOperation()
        {
            JointCollection collection = new JointCollection(new WorldPhysic(Vector2F.Zero));
            IEnumerator enumerator = ((IEnumerable)collection).GetEnumerator();

            collection.List.Add(new DistanceJoint());
            collection.GenerationStamp++;

            Assert.Throws<InvalidOperationException>(() => enumerator.Current);
        }
    }
}

