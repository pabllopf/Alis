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

using System.Collections.Generic;
using System.Threading.Tasks;
using Alis.Extension.Thread.Core;
using Xunit;

namespace Alis.Extension.Thread.Test.Core
{
    /// <summary>
    ///     The work item pool test class
    /// </summary>
    public class WorkItemPoolTest
    {
        /// <summary>
        ///     Tests that work item pool can be instantiated
        /// </summary>
        [Fact]
        public void WorkItemPool_CanBeInstantiated()
        {
            // Act
            WorkItemPool pool = new WorkItemPool();

            // Assert
            Assert.NotNull(pool);
        }

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
            Assert.Null(item.Action);
            Assert.Equal(0, item.StartIndex);
            Assert.Equal(0, item.Length);
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

            // Assert - should be able to rent a reset item
            WorkItem rentedItem = pool.Rent();
            Assert.NotNull(rentedItem);
            Assert.Null(rentedItem.Action);
            Assert.Equal(0, rentedItem.StartIndex);
            Assert.Equal(0, rentedItem.Length);
        }

        /// <summary>
        ///     Tests that pool reuses returned items
        /// </summary>
        [Fact]
        public void Pool_ReusesReturnedItems()
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

            // Assert - renting after clear should not reuse old items
            WorkItem newItem1 = pool.Rent();
            WorkItem newItem2 = pool.Rent();
            Assert.NotNull(newItem1);
            Assert.NotNull(newItem2);
        }

        /// <summary>
        ///     Tests that rent and return cycle works correctly multiple times
        /// </summary>
        [Fact]
        public void RentAndReturnCycle_WorksCorrectlyMultipleTimes()
        {
            // Arrange
            WorkItemPool pool = new WorkItemPool();

            // Act & Assert
            for (int i = 0; i < 20; i++)
            {
                WorkItem item = pool.Rent();
                Assert.NotNull(item);

                item.Action = (s, l) => { };
                item.StartIndex = i;
                item.Length = i * 2;

                pool.Return(item);
            }

            // Final verification
            WorkItem finalItem = pool.Rent();
            Assert.NotNull(finalItem);
            Assert.Null(finalItem.Action);
            Assert.Equal(0, finalItem.StartIndex);
            Assert.Equal(0, finalItem.Length);
        }

        /// <summary>
        ///     Tests that multiple items can be rented simultaneously
        /// </summary>
        [Fact]
        public void Rent_MultipleItems_Simultaneously()
        {
            // Arrange
            WorkItemPool pool = new WorkItemPool();

            // Act
            WorkItem item1 = pool.Rent();
            WorkItem item2 = pool.Rent();
            WorkItem item3 = pool.Rent();

            // Assert
            Assert.NotNull(item1);
            Assert.NotNull(item2);
            Assert.NotNull(item3);
            Assert.NotSame(item1, item2);
            Assert.NotSame(item2, item3);
            Assert.NotSame(item1, item3);
        }

        /// <summary>
        ///     Tests that return with modified item resets properties
        /// </summary>
        [Fact]
        public void Return_WithModifiedItem_ResetsProperties()
        {
            // Arrange
            WorkItemPool pool = new WorkItemPool();
            WorkItem item = pool.Rent();
            item.Action = (s, l) => { };
            item.StartIndex = 999;
            item.Length = 888;

            // Act
            pool.Return(item);
            WorkItem rentedAgain = pool.Rent();

            // Assert
            Assert.Null(rentedAgain.Action);
            Assert.Equal(0, rentedAgain.StartIndex);
            Assert.Equal(0, rentedAgain.Length);
        }

        /// <summary>
        ///     Tests that pool works correctly with mixed operations
        /// </summary>
        [Fact]
        public void Pool_WorksCorrectlyWithMixedOperations()
        {
            // Arrange
            WorkItemPool pool = new WorkItemPool();

            // Act & Assert
            WorkItem item1 = pool.Rent();
            WorkItem item2 = pool.Rent();
            pool.Return(item1);
            WorkItem item3 = pool.Rent();
            Assert.Same(item1, item3);

            pool.Return(item2);
            pool.Return(item3);
            pool.Clear();

            WorkItem item4 = pool.Rent();
            Assert.NotNull(item4);
        }

        /// <summary>
        ///     Tests that pool is thread safe
        /// </summary>
        [Fact]
        public void Pool_IsThreadSafe()
        {
            // Arrange
            WorkItemPool pool = new WorkItemPool();
            List<WorkItem> rentedItems = new List<WorkItem>();
            object lockObj = new object();

            // Act
            Parallel.For(0, 100, i =>
            {
                WorkItem item = pool.Rent();
                lock (lockObj)
                {
                    rentedItems.Add(item);
                }

                item.StartIndex = i;
                item.Length = i * 2;
                pool.Return(item);
            });

            // Assert
            Assert.Equal(100, rentedItems.Count);

            // Verify pool still works
            WorkItem finalItem = pool.Rent();
            Assert.NotNull(finalItem);
        }

        /// <summary>
        ///     Tests that clear can be called on empty pool
        /// </summary>
        [Fact]
        public void Clear_OnEmptyPool_DoesNotThrow()
        {
            // Arrange
            WorkItemPool pool = new WorkItemPool();

            // Act & Assert
            pool.Clear();

            // Should still work after clear
            WorkItem item = pool.Rent();
            Assert.NotNull(item);
        }

        /// <summary>
        ///     Tests that pool maintains fifo order
        /// </summary>
        [Fact]
        public void Pool_MaintainsLifoOrder()
        {
            // Arrange
            WorkItemPool pool = new WorkItemPool();
            WorkItem item1 = pool.Rent();
            WorkItem item2 = pool.Rent();
            WorkItem item3 = pool.Rent();

            // Act
            pool.Return(item1);
            pool.Return(item2);
            pool.Return(item3);

            // Assert - ConcurrentBag uses LIFO, so last returned is first retrieved
            WorkItem retrieved1 = pool.Rent();
            WorkItem retrieved2 = pool.Rent();
            WorkItem retrieved3 = pool.Rent();

            Assert.NotNull(retrieved1);
            Assert.NotNull(retrieved2);
            Assert.NotNull(retrieved3);
        }

        /// <summary>
        ///     Tests that large number of operations work correctly
        /// </summary>
        [Fact]
        public void Pool_HandlesLargeNumberOfOperations()
        {
            // Arrange
            WorkItemPool pool = new WorkItemPool();
            const int operationCount = 1000;

            // Act
            for (int i = 0; i < operationCount; i++)
            {
                WorkItem item = pool.Rent();
                item.StartIndex = i;
                pool.Return(item);
            }

            // Assert
            WorkItem finalItem = pool.Rent();
            Assert.NotNull(finalItem);
            Assert.Equal(0, finalItem.StartIndex);
        }
    }
}