

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
            WorkItemPool pool = new WorkItemPool();

            Assert.NotNull(pool);
        }

        /// <summary>
        ///     Tests that rent creates new work item when pool is empty
        /// </summary>
        [Fact]
        public void Rent_WhenPoolIsEmpty_CreatesNewWorkItem()
        {
            WorkItemPool pool = new WorkItemPool();

            WorkItem item = pool.Rent();

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
            WorkItemPool pool = new WorkItemPool();
            WorkItem item = pool.Rent();
            item.Action = (s, l) => { };
            item.StartIndex = 10;
            item.Length = 20;

            pool.Return(item);

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
            WorkItemPool pool = new WorkItemPool();
            WorkItem original = pool.Rent();

            pool.Return(original);
            WorkItem reused = pool.Rent();

            Assert.Same(original, reused);
        }

        /// <summary>
        ///     Tests that clear removes all items from pool
        /// </summary>
        [Fact]
        public void Clear_RemovesAllItemsFromPool()
        {
            WorkItemPool pool = new WorkItemPool();
            WorkItem item1 = pool.Rent();
            WorkItem item2 = pool.Rent();
            pool.Return(item1);
            pool.Return(item2);

            pool.Clear();

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
            WorkItemPool pool = new WorkItemPool();

            for (int i = 0; i < 20; i++)
            {
                WorkItem item = pool.Rent();
                Assert.NotNull(item);

                item.Action = (s, l) => { };
                item.StartIndex = i;
                item.Length = i * 2;

                pool.Return(item);
            }

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
            WorkItemPool pool = new WorkItemPool();

            WorkItem item1 = pool.Rent();
            WorkItem item2 = pool.Rent();
            WorkItem item3 = pool.Rent();

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
            WorkItemPool pool = new WorkItemPool();
            WorkItem item = pool.Rent();
            item.Action = (s, l) => { };
            item.StartIndex = 999;
            item.Length = 888;

            pool.Return(item);
            WorkItem rentedAgain = pool.Rent();

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
            WorkItemPool pool = new WorkItemPool();

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
            WorkItemPool pool = new WorkItemPool();
            List<WorkItem> rentedItems = new List<WorkItem>();
            object lockObj = new object();

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

            Assert.Equal(100, rentedItems.Count);

            WorkItem finalItem = pool.Rent();
            Assert.NotNull(finalItem);
        }

        /// <summary>
        ///     Tests that clear can be called on empty pool
        /// </summary>
        [Fact]
        public void Clear_OnEmptyPool_DoesNotThrow()
        {
            WorkItemPool pool = new WorkItemPool();

            pool.Clear();

            WorkItem item = pool.Rent();
            Assert.NotNull(item);
        }

        /// <summary>
        ///     Tests that pool maintains fifo order
        /// </summary>
        [Fact]
        public void Pool_MaintainsLifoOrder()
        {
            WorkItemPool pool = new WorkItemPool();
            WorkItem item1 = pool.Rent();
            WorkItem item2 = pool.Rent();
            WorkItem item3 = pool.Rent();

            pool.Return(item1);
            pool.Return(item2);
            pool.Return(item3);

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
            WorkItemPool pool = new WorkItemPool();
            const int operationCount = 1000;

            for (int i = 0; i < operationCount; i++)
            {
                WorkItem item = pool.Rent();
                item.StartIndex = i;
                pool.Return(item);
            }

            WorkItem finalItem = pool.Rent();
            Assert.NotNull(finalItem);
            Assert.Equal(0, finalItem.StartIndex);
        }
    }
}