// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BatchPartitionerCoverageTest.cs
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

using System.Linq;
using Alis.Extension.Thread.Scheduling;
using Xunit;

namespace Alis.Extension.Thread.Test.Scheduling
{
    /// <summary>
    ///     Targeted coverage tests for <see cref="BatchPartitioner" />.
    ///     Covers edge cases in CreatePartitions and CreateBalancedPartitions.
    /// </summary>
    public class BatchPartitionerCoverageTest
    {
        /// <summary>
        ///     Tests that CreatePartitions with a single item produces one partition
        ///     covering the Math.Min clamping path when partitionCount > totalCount.
        /// </summary>
        [Fact]
        public void CreatePartitions_SingleItem_ReturnsSinglePartition()
        {
            BatchPartition[] partitions = BatchPartitioner.CreatePartitions(1, 4);

            Assert.Single(partitions);
            Assert.Equal(0, partitions[0].StartIndex);
            Assert.Equal(1, partitions[0].Length);
            Assert.Equal(1, partitions[0].EndIndex);
        }

        /// <summary>
        ///     Tests that CreatePartitions with partitionCount equal to totalCount
        ///     gives each item its own partition (each partition of size 1).
        /// </summary>
        [Fact]
        public void CreatePartitions_PartitionCountEqualsTotalCount_EachPartitionSizeOne()
        {
            BatchPartition[] partitions = BatchPartitioner.CreatePartitions(5, 5);

            Assert.Equal(5, partitions.Length);
            for (int i = 0; i < partitions.Length; i++)
            {
                Assert.Equal(1, partitions[i].Length);
                Assert.Equal(i, partitions[i].StartIndex);
                Assert.Equal(i + 1, partitions[i].EndIndex);
            }
        }

        /// <summary>
        ///     Tests that CreatePartitions with a single partition produces
        ///     one partition covering all items.
        /// </summary>
        [Fact]
        public void CreatePartitions_SinglePartition_CoversAllItems()
        {
            BatchPartition[] partitions = BatchPartitioner.CreatePartitions(100, 1);

            Assert.Single(partitions);
            Assert.Equal(0, partitions[0].StartIndex);
            Assert.Equal(100, partitions[0].Length);
            Assert.Equal(100, partitions[0].EndIndex);
        }

        /// <summary>
        ///     Tests that CreatePartitions distributes the remainder to the first
        ///     partitions. For totalCount=10, partitionCount=3:
        ///     itemsPerPartition=3, remainder=1, so first partition gets 4 items,
        ///     remaining get 3 each.
        /// </summary>
        [Fact]
        public void CreatePartitions_RemainderGoesToFirstPartitions()
        {
            BatchPartition[] partitions = BatchPartitioner.CreatePartitions(10, 3);

            Assert.Equal(3, partitions.Length);
            Assert.Equal(4, partitions[0].Length);
            Assert.Equal(3, partitions[1].Length);
            Assert.Equal(3, partitions[2].Length);
            Assert.Equal(10, partitions.Sum(p => p.Length));
        }

        /// <summary>
        ///     Tests that CreatePartitions with exact division (no remainder)
        ///     produces equal-sized partitions.
        /// </summary>
        [Fact]
        public void CreatePartitions_ExactDivisionNoRemainder_EqualSizedPartitions()
        {
            BatchPartition[] partitions = BatchPartitioner.CreatePartitions(12, 4);

            Assert.Equal(4, partitions.Length);
            foreach (BatchPartition partition in partitions)
            {
                Assert.Equal(3, partition.Length);
            }
        }

        /// <summary>
        ///     Tests that CreatePartitions with a larger remainder distributes
        ///     correctly. For totalCount=20, partitionCount=6:
        ///     itemsPerPartition=3, remainder=2.
        ///     First 2 partitions get 4 items each, remaining 4 get 3 each.
        /// </summary>
        [Fact]
        public void CreatePartitions_LargerRemainder_CorrectDistribution()
        {
            BatchPartition[] partitions = BatchPartitioner.CreatePartitions(20, 6);

            Assert.Equal(6, partitions.Length);
            Assert.Equal(4, partitions[0].Length);
            Assert.Equal(4, partitions[1].Length);
            Assert.Equal(3, partitions[2].Length);
            Assert.Equal(3, partitions[3].Length);
            Assert.Equal(3, partitions[4].Length);
            Assert.Equal(3, partitions[5].Length);
            Assert.Equal(20, partitions.Sum(p => p.Length));

            for (int i = 0; i < partitions.Length - 1; i++)
            {
                Assert.Equal(partitions[i].EndIndex, partitions[i + 1].StartIndex);
            }
        }

        /// <summary>
        ///     Tests that CreateBalancedPartitions with maxPartitionCount=1
        ///     produces a single partition covering all items.
        /// </summary>
        [Fact]
        public void CreateBalancedPartitions_MaxPartitionCountOne_SinglePartition()
        {
            BatchPartition[] partitions = BatchPartitioner.CreateBalancedPartitions(100, 1, 10);

            Assert.Single(partitions);
            Assert.Equal(0, partitions[0].StartIndex);
            Assert.Equal(100, partitions[0].Length);
        }

        /// <summary>
        ///     Tests that CreateBalancedPartitions with maxPartitionCount=0
        ///     still produces at least one partition via the Math.Max(1, actualPartitions) guard.
        /// </summary>
        [Fact]
        public void CreateBalancedPartitions_MaxPartitionCountZero_AtLeastOnePartition()
        {
            BatchPartition[] partitions = BatchPartitioner.CreateBalancedPartitions(100, 0, 10);

            Assert.Single(partitions);
            Assert.Equal(0, partitions[0].StartIndex);
            Assert.Equal(100, partitions[0].Length);
        }

        /// <summary>
        ///     Tests that CreateBalancedPartitions calculates the correct number
        ///     of partitions based on the formula: min(maxPartitionCount, totalCount / minPartitionSize).
        /// </summary>
        [Fact]
        public void CreateBalancedPartitions_CorrectPartitionCount()
        {
            BatchPartition[] partitions = BatchPartitioner.CreateBalancedPartitions(100, 8, 15);

            int expected = 100 / 15;
            expected = expected < 8 ? expected : 8;
            Assert.Equal(expected, partitions.Length);
            Assert.Equal(100, partitions.Sum(p => p.Length));
        }
    }
}
