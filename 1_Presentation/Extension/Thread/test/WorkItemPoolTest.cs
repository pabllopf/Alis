// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorkItemPoolTest.cs
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

using Alis.Extension.Thread.Core;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    ///     The work item pool test class
    /// </summary>
    public class WorkItemPoolTest
    {
        /// <summary>
        ///     Tests that rent creates new work item when pool is empty
        /// </summary>
        [Fact]
        public void Rent_WhenPoolIsEmpty_CreatesNewWorkItem()
        {
            // Arrange
            WorkItemPool pool = new WorkItemPool();

            // Act
            WorkItem item = pool.Rent();

            // Assert
            Assert.NotNull(item);
        }

        /// <summary>
        ///     Tests that return adds work item to pool
        /// </summary>
        [Fact]
        public void Return_AddsWorkItemToPool()
        {
            // Arrange
            WorkItemPool pool = new WorkItemPool();
            WorkItem item = pool.Rent();
            item.Action = (s, l) => { };
            item.StartIndex = 10;
            item.Length = 20;

            // Act
            pool.Return(item);

            // Assert - should be able to rent the same item
            WorkItem rentedItem = pool.Rent();
            Assert.NotNull(rentedItem);
            Assert.Null(rentedItem.Action); // Should be reset
            Assert.Equal(0, rentedItem.StartIndex);
            Assert.Equal(0, rentedItem.Length);
        }

        /// <summary>
        ///     Tests that clear removes all items from pool
        /// </summary>
        [Fact]
        public void Clear_RemovesAllItemsFromPool()
        {
            // Arrange
            WorkItemPool pool = new WorkItemPool();
            WorkItem item1 = pool.Rent();
            WorkItem item2 = pool.Rent();
            pool.Return(item1);
            pool.Return(item2);

            // Act
            pool.Clear();

            // Assert - renting should create new items
            WorkItem newItem = pool.Rent();
            Assert.NotNull(newItem);
        }

        /// <summary>
        ///     Tests that rent and return cycle works correctly
        /// </summary>
        [Fact]
        public void RentAndReturnCycle_WorksCorrectly()
        {
            // Arrange
            WorkItemPool pool = new WorkItemPool();

            // Act & Assert - Multiple cycles
            for (int i = 0; i < 10; i++)
            {
                WorkItem item = pool.Rent();
                Assert.NotNull(item);
                item.Action = (s, l) => { };
                item.StartIndex = i;
                item.Length = i * 2;
                pool.Return(item);
            }
        }

        /// <summary>
        ///     Tests that pool reuses work items
        /// </summary>
        [Fact]
        public void Pool_ReusesWorkItems()
        {
            // Arrange
            WorkItemPool pool = new WorkItemPool();
            WorkItem original = pool.Rent();

            // Act
            pool.Return(original);
            WorkItem reused = pool.Rent();

            // Assert
            Assert.Same(original, reused);
        }
    }

    /// <summary>
    ///     The work item test class
    /// </summary>
    public class WorkItemTest
    {
        /// <summary>
        ///     Tests that work item can store action
        /// </summary>
        [Fact]
        public void WorkItem_CanStoreAction()
        {
            // Arrange
            WorkItem item = new WorkItem();
            bool executed = false;

            // Act
            item.Action = (s, l) => { executed = true; };
            item.Action(0, 0);

            // Assert
            Assert.True(executed);
        }

        /// <summary>
        ///     Tests that work item can store indices
        /// </summary>
        [Fact]
        public void WorkItem_CanStoreIndices()
        {
            // Arrange
            WorkItem item = new WorkItem();

            // Act
            item.StartIndex = 100;
            item.Length = 200;

            // Assert
            Assert.Equal(100, item.StartIndex);
            Assert.Equal(200, item.Length);
        }

        /// <summary>
        ///     Tests that reset clears all properties
        /// </summary>
        [Fact]
        public void Reset_ClearsAllProperties()
        {
            // Arrange
            WorkItem item = new WorkItem
            {
                Action = (s, l) => { },
                StartIndex = 50,
                Length = 100
            };

            // Act
            item.Reset();

            // Assert
            Assert.Null(item.Action);
            Assert.Equal(0, item.StartIndex);
            Assert.Equal(0, item.Length);
        }
    }
}

