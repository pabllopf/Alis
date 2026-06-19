// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerCollectionTest.cs
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
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The controller collection test class
    /// </summary>
    public class ControllerCollectionTest
    {
        /// <summary>
        /// Tests that collection should expose controllers added through world
        /// </summary>
        [Fact]
        public void Collection_ShouldExposeControllersAddedThroughWorld()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            GravityController controller = new GravityController(1.0f);

            world.Add(controller);

            Assert.Single(world.ControllerList);
            Assert.True(world.ControllerList.Contains(controller));
        }

        /// <summary>
        /// Tests that collection should be read only from i collection interface
        /// </summary>
        [Fact]
        public void Collection_ShouldBeReadOnlyFromICollectionInterface()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ControllerCollection collection = world.ControllerList;

            Assert.True(collection.IsReadOnly);
            Assert.Throws<NotSupportedException>(() => ((ICollection<Controller>) collection).Add(new GravityController(1.0f)));
            Assert.Throws<NotSupportedException>(() => ((ICollection<Controller>) collection).Clear());
        }

        /// <summary>
        /// Tests that collection enumerator should iterate all controllers
        /// </summary>
        [Fact]
        public void Collection_Enumerator_ShouldIterateAllControllers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.Add(new GravityController(1.0f));
            world.Add(new VelocityLimitController());

            int count = 0;
            foreach (Controller _ in world.ControllerList)
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        /// Tests that collection remove via i collection throws not supported exception
        /// </summary>
        [Fact]
        public void Collection_RemoveViaICollection_ThrowsNotSupportedException()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ControllerCollection collection = world.ControllerList;
            Controller controller = new GravityController(1.0f);

            Assert.Throws<NotSupportedException>(() => ((ICollection<Controller>)collection).Remove(controller));
        }

        /// <summary>
        /// Tests that collection copy to copies controllers to array
        /// </summary>
        [Fact]
        public void Collection_CopyTo_CopiesControllersToArray()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.Add(new GravityController(1.0f));
            world.Add(new VelocityLimitController());

            Controller[] array = new Controller[2];
            world.ControllerList.CopyTo(array, 0);

            Assert.Equal(2, array.Length);
            Assert.NotNull(array[0]);
            Assert.NotNull(array[1]);
        }

        /// <summary>
        /// Tests that collection insert via i list throws not supported exception
        /// </summary>
        [Fact]
        public void Collection_InsertViaIList_ThrowsNotSupportedException()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ControllerCollection collection = world.ControllerList;
            Controller controller = new GravityController(1.0f);

            Assert.Throws<NotSupportedException>(() => ((IList<Controller>)collection).Insert(0, controller));
        }

        /// <summary>
        /// Tests that collection remove at via i list throws not supported exception
        /// </summary>
        [Fact]
        public void Collection_RemoveAtViaIList_ThrowsNotSupportedException()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ControllerCollection collection = world.ControllerList;

            Assert.Throws<NotSupportedException>(() => ((IList<Controller>)collection).RemoveAt(0));
        }

        /// <summary>
        /// Tests that collection set indexer via i list throws not supported exception
        /// </summary>
        [Fact]
        public void Collection_SetIndexerViaIList_ThrowsNotSupportedException()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ControllerCollection collection = world.ControllerList;
            Controller controller = new GravityController(1.0f);

            Assert.Throws<NotSupportedException>(() => ((IList<Controller>)collection)[0] = controller);
        }

        /// <summary>
        /// Tests that collection index of existing controller returns correct index
        /// </summary>
        [Fact]
        public void Collection_IndexOf_ExistingController_ReturnsCorrectIndex()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            GravityController controller = new GravityController(1.0f);
            world.Add(controller);

            int index = world.ControllerList.IndexOf(controller);

            Assert.Equal(0, index);
        }

        /// <summary>
        /// Tests that collection index of missing controller returns minus one
        /// </summary>
        [Fact]
        public void Collection_IndexOf_MissingController_ReturnsMinusOne()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ControllerCollection collection = world.ControllerList;
            Controller controller = new GravityController(1.0f);

            Assert.Equal(-1, collection.IndexOf(controller));
        }

        /// <summary>
        /// Tests that collection count reflects number of controllers
        /// </summary>
        [Fact]
        public void Collection_Count_ReflectsNumberOfControllers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            Assert.Equal(0, world.ControllerList.Count);

            world.Add(new GravityController(1.0f));
            Assert.Equal(1, world.ControllerList.Count);

            world.Add(new VelocityLimitController());
            Assert.Equal(2, world.ControllerList.Count);
        }

        /// <summary>
        /// Tests that collection get indexer returns correct controller
        /// </summary>
        [Fact]
        public void Collection_GetIndexer_ReturnsCorrectController()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            GravityController controller = new GravityController(1.0f);
            world.Add(controller);

            Assert.Equal(controller, world.ControllerList[0]);
        }

        /// <summary>
        /// Tests that collection typed enumerator move next returns false when exhausted
        /// </summary>
        [Fact]
        public void Collection_Enumerator_MoveNext_ReturnsFalseWhenExhausted()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ControllerCollection collection = world.ControllerList;
            ControllerEnumerator enumerator = collection.GetEnumerator();

            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        /// Tests that collection enumerator reset via i enumerator interface works
        /// </summary>
        [Fact]
        public void Collection_Enumerator_ResetViaIEnumerator_Works()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ControllerCollection collection = world.ControllerList;
            ControllerEnumerator enumerator = collection.GetEnumerator();

            IEnumerator boxed = enumerator;
            boxed.Reset();
        }

        /// <summary>
        /// Tests that enumerator current throws invalid operation when collection modified
        /// </summary>
        [Fact]
        public void Enumerator_Current_WhenCollectionModified_ThrowsInvalidOperation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ControllerCollection collection = world.ControllerList;
            ControllerEnumerator enumerator = collection.GetEnumerator();

            collection.List.Add(new GravityController(1.0f));
            collection.GenerationStamp++;

            Assert.Throws<InvalidOperationException>(() => enumerator.Current);
        }

        /// <summary>
        /// Tests that enumerator move next throws invalid operation when collection modified
        /// </summary>
        [Fact]
        public void Enumerator_MoveNext_WhenCollectionModified_ThrowsInvalidOperation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ControllerCollection collection = world.ControllerList;
            ControllerEnumerator enumerator = collection.GetEnumerator();

            collection.List.Add(new GravityController(1.0f));
            collection.GenerationStamp++;

            Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());
        }

        /// <summary>
        /// Tests that collection enumerator dispose clears references
        /// </summary>
        [Fact]
        public void Collection_Enumerator_Dispose_ClearsReferences()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ControllerCollection collection = world.ControllerList;
            ControllerEnumerator enumerator = collection.GetEnumerator();

            ((IDisposable)enumerator).Dispose();
        }

        /// <summary>
        /// Tests that non-generic IEnumerable.GetEnumerator returns a ControllerEnumerator
        /// </summary>
        [Fact]
        public void Collection_NonGenericEnumerable_GetEnumerator_ReturnsControllerEnumerator()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            ControllerCollection collection = world.ControllerList;
            System.Collections.IEnumerable nonGeneric = collection;

            System.Collections.IEnumerator result = nonGeneric.GetEnumerator();

            Assert.IsType<ControllerEnumerator>(result);
        }
    }
}

