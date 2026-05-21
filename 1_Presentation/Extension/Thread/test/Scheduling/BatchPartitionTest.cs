

using System.Reflection;
using Alis.Extension.Thread.Scheduling;
using Xunit;

namespace Alis.Extension.Thread.Test.Scheduling
{
    /// <summary>
    ///     The batch partition test class
    /// </summary>
    public class BatchPartitionTest
    {
        /// <summary>
        ///     Tests that batch partition can be instantiated
        /// </summary>
        [Fact]
        public void BatchPartition_CanBeInstantiated()
        {
            BatchPartition partition = new BatchPartition(10, 20);

            Assert.Equal(10, partition.StartIndex);
            Assert.Equal(20, partition.Length);
        }

        /// <summary>
        ///     Tests that start index is stored correctly
        /// </summary>
        [Fact]
        public void StartIndex_IsStoredCorrectly()
        {
            BatchPartition partition = new BatchPartition(100, 50);

            Assert.Equal(100, partition.StartIndex);
        }

        /// <summary>
        ///     Tests that length is stored correctly
        /// </summary>
        [Fact]
        public void Length_IsStoredCorrectly()
        {
            BatchPartition partition = new BatchPartition(100, 50);

            Assert.Equal(50, partition.Length);
        }

        /// <summary>
        ///     Tests that end index is calculated correctly
        /// </summary>
        [Fact]
        public void EndIndex_IsCalculatedCorrectly()
        {
            BatchPartition partition = new BatchPartition(10, 20);

            Assert.Equal(30, partition.EndIndex);
        }

        /// <summary>
        ///     Tests that end index with zero length
        /// </summary>
        [Fact]
        public void EndIndex_WithZeroLength()
        {
            BatchPartition partition = new BatchPartition(10, 0);

            Assert.Equal(10, partition.EndIndex);
        }

        /// <summary>
        ///     Tests that partition with zero start index
        /// </summary>
        [Fact]
        public void Partition_WithZeroStartIndex()
        {
            BatchPartition partition = new BatchPartition(0, 100);

            Assert.Equal(0, partition.StartIndex);
            Assert.Equal(100, partition.Length);
            Assert.Equal(100, partition.EndIndex);
        }

        /// <summary>
        ///     Tests that partition with negative start index
        /// </summary>
        [Fact]
        public void Partition_WithNegativeStartIndex()
        {
            BatchPartition partition = new BatchPartition(-5, 10);

            Assert.Equal(-5, partition.StartIndex);
            Assert.Equal(10, partition.Length);
            Assert.Equal(5, partition.EndIndex);
        }

        /// <summary>
        ///     Tests that partition with negative length
        /// </summary>
        [Fact]
        public void Partition_WithNegativeLength()
        {
            BatchPartition partition = new BatchPartition(10, -5);

            Assert.Equal(10, partition.StartIndex);
            Assert.Equal(-5, partition.Length);
            Assert.Equal(5, partition.EndIndex);
        }

        /// <summary>
        ///     Tests that partition with maximum integer values
        /// </summary>
        [Fact]
        public void Partition_WithMaxIntegerValues()
        {
            BatchPartition partition = new BatchPartition(int.MaxValue, 0);

            Assert.Equal(int.MaxValue, partition.StartIndex);
            Assert.Equal(0, partition.Length);
            Assert.Equal(int.MaxValue, partition.EndIndex);
        }

        /// <summary>
        ///     Tests that partition is readonly struct
        /// </summary>
        [Fact]
        public void Partition_IsReadonlyStruct()
        {
            BatchPartition partition1 = new BatchPartition(10, 20);
            BatchPartition partition2 = new BatchPartition(10, 20);

            Assert.Equal(partition1.StartIndex, partition2.StartIndex);
            Assert.Equal(partition1.Length, partition2.Length);
            Assert.Equal(partition1.EndIndex, partition2.EndIndex);
        }

        /// <summary>
        ///     Tests that multiple partitions are independent
        /// </summary>
        [Fact]
        public void MultiplePartitions_AreIndependent()
        {
            BatchPartition partition1 = new BatchPartition(0, 10);
            BatchPartition partition2 = new BatchPartition(10, 10);
            BatchPartition partition3 = new BatchPartition(20, 10);

            Assert.Equal(0, partition1.StartIndex);
            Assert.Equal(10, partition1.Length);
            Assert.Equal(10, partition1.EndIndex);

            Assert.Equal(10, partition2.StartIndex);
            Assert.Equal(10, partition2.Length);
            Assert.Equal(20, partition2.EndIndex);

            Assert.Equal(20, partition3.StartIndex);
            Assert.Equal(10, partition3.Length);
            Assert.Equal(30, partition3.EndIndex);
        }

        /// <summary>
        ///     Tests that partition can represent continuous ranges
        /// </summary>
        [Fact]
        public void Partition_CanRepresentContinuousRanges()
        {
            BatchPartition[] partitions = new[]
            {
                new BatchPartition(0, 25),
                new BatchPartition(25, 25),
                new BatchPartition(50, 25),
                new BatchPartition(75, 25)
            };

            for (int i = 0; i < partitions.Length - 1; i++)
            {
                Assert.Equal(partitions[i].EndIndex, partitions[i + 1].StartIndex);
            }
        }

        /// <summary>
        ///     Tests that partition can represent overlapping ranges
        /// </summary>
        [Fact]
        public void Partition_CanRepresentOverlappingRanges()
        {
            BatchPartition partition1 = new BatchPartition(0, 20);
            BatchPartition partition2 = new BatchPartition(10, 20);

            Assert.True(partition1.EndIndex > partition2.StartIndex);
        }

        /// <summary>
        ///     Tests that partition with large values
        /// </summary>
        [Fact]
        public void Partition_WithLargeValues()
        {
            BatchPartition partition = new BatchPartition(1000000, 500000);

            Assert.Equal(1000000, partition.StartIndex);
            Assert.Equal(500000, partition.Length);
            Assert.Equal(1500000, partition.EndIndex);
        }

        /// <summary>
        ///     Tests that partition properties are immutable
        /// </summary>
        [Fact]
        public void Partition_PropertiesAreImmutable()
        {
            BatchPartition partition = new BatchPartition(10, 20);

            int startIndex = partition.StartIndex;
            int length = partition.Length;
            int endIndex = partition.EndIndex;

            PropertyInfo startProperty = typeof(BatchPartition).GetProperty(nameof(BatchPartition.StartIndex));
            PropertyInfo lengthProperty = typeof(BatchPartition).GetProperty(nameof(BatchPartition.Length));
            PropertyInfo endProperty = typeof(BatchPartition).GetProperty(nameof(BatchPartition.EndIndex));

            Assert.NotNull(startProperty);
            Assert.NotNull(lengthProperty);
            Assert.NotNull(endProperty);
            Assert.Null(startProperty.SetMethod);
            Assert.Null(lengthProperty.SetMethod);
            Assert.Null(endProperty.SetMethod);
        }

        /// <summary>
        ///     Tests that partition can be used in collections
        /// </summary>
        [Fact]
        public void Partition_CanBeUsedInCollections()
        {
            BatchPartition[] partitions = new BatchPartition[3];
            partitions[0] = new BatchPartition(0, 10);
            partitions[1] = new BatchPartition(10, 10);
            partitions[2] = new BatchPartition(20, 10);

            Assert.Equal(3, partitions.Length);
            Assert.Equal(0, partitions[0].StartIndex);
            Assert.Equal(10, partitions[1].StartIndex);
            Assert.Equal(20, partitions[2].StartIndex);
        }

        /// <summary>
        ///     Tests that partition covers full range calculation
        /// </summary>
        [Fact]
        public void Partition_CoversFullRangeCalculation()
        {
            const int totalItems = 100;
            BatchPartition[] partitions = new[]
            {
                new BatchPartition(0, 25),
                new BatchPartition(25, 25),
                new BatchPartition(50, 25),
                new BatchPartition(75, 25)
            };

            int coveredItems = 0;
            foreach (BatchPartition partition in partitions)
            {
                coveredItems += partition.Length;
            }

            Assert.Equal(totalItems, coveredItems);
            Assert.Equal(totalItems, partitions[partitions.Length - 1].EndIndex);
        }
    }
}