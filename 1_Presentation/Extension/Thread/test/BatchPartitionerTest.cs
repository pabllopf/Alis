// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BatchPartitionerTest.cs
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
            // Arrange
            const int totalCount = 100;
            const int partitionCount = 4;

            // Act
            BatchPartition[] partitions = BatchPartitioner.CreatePartitions(totalCount, partitionCount);

            // Assert
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
            // Arrange
            const int totalCount = 103;
            const int partitionCount = 4;

            // Act
            BatchPartition[] partitions = BatchPartitioner.CreatePartitions(totalCount, partitionCount);

            // Assert
            Assert.Equal(4, partitions.Length);
            int totalItems = partitions.Sum(p => p.Length);
            Assert.Equal(totalCount, totalItems);

            // Verify continuous coverage
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
            // Arrange
            const int totalCount = 50;
            const int maxPartitions = 10;
            const int minSize = 20;

            // Act
            BatchPartition[] partitions = BatchPartitioner.CreateBalancedPartitions(totalCount, maxPartitions, minSize);

            // Assert
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
            // Arrange
            const int totalCount = 10;
            const int maxPartitions = 4;
            const int minSize = 20;

            // Act
            BatchPartition[] partitions = BatchPartitioner.CreateBalancedPartitions(totalCount, maxPartitions, minSize);

            // Assert
            Assert.Single(partitions);
            Assert.Equal(0, partitions[0].StartIndex);
            Assert.Equal(10, partitions[0].Length);
        }
    }
}

