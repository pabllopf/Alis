

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
            WorkItemPool pool = new WorkItemPool();

            WorkItem item = pool.Rent();

            Assert.NotNull(item);
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
            WorkItemPool pool = new WorkItemPool();
            WorkItem item1 = pool.Rent();
            WorkItem item2 = pool.Rent();
            pool.Return(item1);
            pool.Return(item2);

            pool.Clear();

            WorkItem newItem = pool.Rent();
            Assert.NotNull(newItem);
        }

        /// <summary>
        ///     Tests that rent and return cycle works correctly
        /// </summary>
        [Fact]
        public void RentAndReturnCycle_WorksCorrectly()
        {
            WorkItemPool pool = new WorkItemPool();

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
            WorkItemPool pool = new WorkItemPool();
            WorkItem original = pool.Rent();

            pool.Return(original);
            WorkItem reused = pool.Rent();

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
            WorkItem item = new WorkItem();
            bool executed = false;

            item.Action = (s, l) => { executed = true; };
            item.Action(0, 0);

            Assert.True(executed);
        }

        /// <summary>
        ///     Tests that work item can store indices
        /// </summary>
        [Fact]
        public void WorkItem_CanStoreIndices()
        {
            WorkItem item = new WorkItem();

            item.StartIndex = 100;
            item.Length = 200;

            Assert.Equal(100, item.StartIndex);
            Assert.Equal(200, item.Length);
        }

        /// <summary>
        ///     Tests that reset clears all properties
        /// </summary>
        [Fact]
        public void Reset_ClearsAllProperties()
        {
            WorkItem item = new WorkItem
            {
                Action = (s, l) => { },
                StartIndex = 50,
                Length = 100
            };

            item.Reset();

            Assert.Null(item.Action);
            Assert.Equal(0, item.StartIndex);
            Assert.Equal(0, item.Length);
        }
    }
}