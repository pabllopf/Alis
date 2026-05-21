

using Alis.Extension.Thread.Core;
using Xunit;

namespace Alis.Extension.Thread.Test.Core
{
    /// <summary>
    ///     The work item test class
    /// </summary>
    public class WorkItemTest
    {
        /// <summary>
        ///     Tests that work item can be instantiated
        /// </summary>
        [Fact]
        public void WorkItem_CanBeInstantiated()
        {
            WorkItem item = new WorkItem();

            Assert.NotNull(item);
            Assert.Null(item.Action);
            Assert.Equal(0, item.StartIndex);
            Assert.Equal(0, item.Length);
        }

        /// <summary>
        ///     Tests that action property can store and execute action
        /// </summary>
        [Fact]
        public void Action_CanStoreAndExecuteAction()
        {
            WorkItem item = new WorkItem();
            int executionCount = 0;
            int receivedStart = -1;
            int receivedLength = -1;

            item.Action = (start, length) =>
            {
                executionCount++;
                receivedStart = start;
                receivedLength = length;
            };
            item.Action(10, 20);

            Assert.Equal(1, executionCount);
            Assert.Equal(10, receivedStart);
            Assert.Equal(20, receivedLength);
        }

        /// <summary>
        ///     Tests that start index can be set and retrieved
        /// </summary>
        [Fact]
        public void StartIndex_CanBeSetAndRetrieved()
        {
            WorkItem item = new WorkItem();

            item.StartIndex = 100;

            Assert.Equal(100, item.StartIndex);
        }

        /// <summary>
        ///     Tests that length can be set and retrieved
        /// </summary>
        [Fact]
        public void Length_CanBeSetAndRetrieved()
        {
            WorkItem item = new WorkItem();

            item.Length = 200;

            Assert.Equal(200, item.Length);
        }

        /// <summary>
        ///     Tests that reset clears action property
        /// </summary>
        [Fact]
        public void Reset_ClearsActionProperty()
        {
            WorkItem item = new WorkItem
            {
                Action = (s, l) => { }
            };

            item.Reset();

            Assert.Null(item.Action);
        }

        /// <summary>
        ///     Tests that reset clears start index
        /// </summary>
        [Fact]
        public void Reset_ClearsStartIndex()
        {
            WorkItem item = new WorkItem
            {
                StartIndex = 50
            };

            item.Reset();

            Assert.Equal(0, item.StartIndex);
        }

        /// <summary>
        ///     Tests that reset clears length
        /// </summary>
        [Fact]
        public void Reset_ClearsLength()
        {
            WorkItem item = new WorkItem
            {
                Length = 100
            };

            item.Reset();

            Assert.Equal(0, item.Length);
        }

        /// <summary>
        ///     Tests that reset clears all properties at once
        /// </summary>
        [Fact]
        public void Reset_ClearsAllPropertiesAtOnce()
        {
            WorkItem item = new WorkItem
            {
                Action = (s, l) => { },
                StartIndex = 75,
                Length = 150
            };

            item.Reset();

            Assert.Null(item.Action);
            Assert.Equal(0, item.StartIndex);
            Assert.Equal(0, item.Length);
        }

        /// <summary>
        ///     Tests that multiple resets work correctly
        /// </summary>
        [Fact]
        public void Reset_MultipleResets_WorkCorrectly()
        {
            WorkItem item = new WorkItem();

            for (int i = 0; i < 5; i++)
            {
                item.Action = (s, l) => { };
                item.StartIndex = i * 10;
                item.Length = i * 20;
                item.Reset();

                Assert.Null(item.Action);
                Assert.Equal(0, item.StartIndex);
                Assert.Equal(0, item.Length);
            }
        }

        /// <summary>
        ///     Tests that work item can store complex action
        /// </summary>
        [Fact]
        public void WorkItem_CanStoreComplexAction()
        {
            WorkItem item = new WorkItem();
            int[] results = new int[10];

            item.Action = (start, length) =>
            {
                for (int i = start; i < start + length; i++)
                {
                    if (i < results.Length)
                    {
                        results[i] = i * 2;
                    }
                }
            };
            item.Action(0, 5);

            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(i * 2, results[i]);
            }
        }

        /// <summary>
        ///     Tests that work item properties are independent
        /// </summary>
        [Fact]
        public void WorkItem_PropertiesAreIndependent()
        {
            WorkItem item1 = new WorkItem();
            WorkItem item2 = new WorkItem();

            item1.StartIndex = 10;
            item1.Length = 20;
            item2.StartIndex = 30;
            item2.Length = 40;

            Assert.Equal(10, item1.StartIndex);
            Assert.Equal(20, item1.Length);
            Assert.Equal(30, item2.StartIndex);
            Assert.Equal(40, item2.Length);
        }

        /// <summary>
        ///     Tests that work item can handle negative indices
        /// </summary>
        [Fact]
        public void WorkItem_CanHandleNegativeIndices()
        {
            WorkItem item = new WorkItem();

            item.StartIndex = -5;
            item.Length = -10;

            Assert.Equal(-5, item.StartIndex);
            Assert.Equal(-10, item.Length);
        }

        /// <summary>
        ///     Tests that work item can handle zero values
        /// </summary>
        [Fact]
        public void WorkItem_CanHandleZeroValues()
        {
            WorkItem item = new WorkItem();

            item.StartIndex = 0;
            item.Length = 0;

            Assert.Equal(0, item.StartIndex);
            Assert.Equal(0, item.Length);
        }

        /// <summary>
        ///     Tests that work item can handle maximum integer values
        /// </summary>
        [Fact]
        public void WorkItem_CanHandleMaxIntegerValues()
        {
            WorkItem item = new WorkItem();

            item.StartIndex = int.MaxValue;
            item.Length = int.MaxValue;

            Assert.Equal(int.MaxValue, item.StartIndex);
            Assert.Equal(int.MaxValue, item.Length);
        }
    }
}