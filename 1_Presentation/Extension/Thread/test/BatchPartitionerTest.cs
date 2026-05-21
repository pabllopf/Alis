

using System.Linq;
using Alis.Extension.Thread.Scheduling;
using Xunit;

namespace Alis.Extension.Thread.Test
{
    /// <summary>
    ///     The batch partitioner test class
    /// </summary>
    public class BatchPartitionerTest
    {
        /// <summary>
        ///     Tests that create partitions divides work correctly
        /// </summary>
        [Fact]
        public void CreatePartitions_DividesWorkCorrectly()
        {
            const int totalCount = 100;
            const int partitionCount = 4;

            BatchPartition[] partitions = BatchPartitioner.CreatePartitions(totalCount, partitionCount);

            Assert.Equal(4, partitions.Length);
            int totalItems = partitions.Sum(p => p.Length);
            Assert.Equal(totalCount, totalItems);
        }

        /// <summary>
        ///     Tests that create partitions handles uneven division
        /// </summary>
        [Fact]
        public void CreatePartitions_HandlesUnevenDivision()
        {
            const int totalCount = 103;
            const int partitionCount = 4;

            BatchPartition[] partitions = BatchPartitioner.CreatePartitions(totalCount, partitionCount);

            Assert.Equal(4, partitions.Length);
            int totalItems = partitions.Sum(p => p.Length);
            Assert.Equal(totalCount, totalItems);

            for (int i = 0; i < partitions.Length - 1; i++)
            {
                Assert.Equal(partitions[i].EndIndex, partitions[i + 1].StartIndex);
            }
        }

        /// <summary>
        ///     Tests that create balanced partitions respects minimum size
        /// </summary>
        [Fact]
        public void CreateBalancedPartitions_RespectsMinimumSize()
        {
            const int totalCount = 50;
            const int maxPartitions = 10;
            const int minSize = 20;

            BatchPartition[] partitions = BatchPartitioner.CreateBalancedPartitions(totalCount, maxPartitions, minSize);

            Assert.Equal(2, partitions.Length); // 50 / 20 = 2 partitions max
            int totalItems = partitions.Sum(p => p.Length);
            Assert.Equal(totalCount, totalItems);
        }

        /// <summary>
        ///     Tests that create balanced partitions creates single partition for small count
        /// </summary>
        [Fact]
        public void CreateBalancedPartitions_CreatesSinglePartitionForSmallCount()
        {
            const int totalCount = 10;
            const int maxPartitions = 4;
            const int minSize = 20;

            BatchPartition[] partitions = BatchPartitioner.CreateBalancedPartitions(totalCount, maxPartitions, minSize);

            Assert.Single(partitions);
            Assert.Equal(0, partitions[0].StartIndex);
            Assert.Equal(10, partitions[0].Length);
        }
    }
}