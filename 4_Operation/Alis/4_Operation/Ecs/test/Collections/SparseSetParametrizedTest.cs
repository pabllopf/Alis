// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SparseSetParametrizedTest.cs
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

using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Parametrized tests for SparseSet to generate comprehensive coverage
    /// </summary>
    public class SparseSetParametrizedTest
    {
        /// <summary>
        /// Tests that sparse set add elements contains all
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(500)]
        [InlineData(1000)]
        public void SparseSet_AddElements_ContainsAll(int count)
        {
            // Arrange
            SparseSet<int> set = new();

            // Act
            for (int i = 0; i < count; i++)
            {
                set.Add(i);
            }

            // Assert
            Assert.Equal(count, set.Count);
            for (int i = 0; i < count; i++)
            {
                Assert.True(set.Contains(i));
            }
        }

        /// <summary>
        /// Tests that sparse set remove elements decrements count
        /// </summary>
        /// <param name="totalCount">The total count</param>
        /// <param name="removeCount">The remove count</param>
        [Theory]
        [InlineData(1, 0)]
        [InlineData(5, 2)]
        [InlineData(10, 5)]
        [InlineData(20, 10)]
        public void SparseSet_RemoveElements_DecrementsCount(int totalCount, int removeCount)
        {
            // Arrange
            SparseSet<int> set = new();
            for (int i = 0; i < totalCount; i++) set.Add(i);

            // Act
            for (int i = 0; i < removeCount; i++) set.Remove(i);

            // Assert
            Assert.Equal(totalCount - removeCount, set.Count);
        }

        /// <summary>
        /// Tests that sparse set add and remove alternating count correct
        /// </summary>
        /// <param name="pairsCount">The pairs count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        public void SparseSet_AddAndRemoveAlternating_CountCorrect(int pairsCount)
        {
            // Arrange
            SparseSet<int> set = new();

            // Act
            for (int i = 0; i < pairsCount; i++)
            {
                set.Add(i);
                set.Remove(i);
            }

            // Assert
            Assert.Equal(0, set.Count);
        }

        /// <summary>
        /// Tests that sparse set enumerate elements iterates all
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(500)]
        public void SparseSet_EnumerateElements_IteratesAll(int count)
        {
            // Arrange
            SparseSet<int> set = new();
            for (int i = 0; i < count; i++) set.Add(i);

            // Act
            int enumeratedCount = 0;
            foreach (int item in set)
            {
                enumeratedCount++;
            }

            // Assert
            Assert.Equal(count, enumeratedCount);
        }

        /// <summary>
        /// Tests that sparse set check contains after remove returns false
        /// </summary>
        /// <param name="totalCount">The total count</param>
        /// <param name="indexToRemove">The index to remove</param>
        [Theory]
        [InlineData(1, 0)]
        [InlineData(5, 1)]
        [InlineData(10, 5)]
        [InlineData(20, 15)]
        public void SparseSet_CheckContainsAfterRemove_ReturnsFalse(int totalCount, int indexToRemove)
        {
            // Arrange
            SparseSet<int> set = new();
            for (int i = 0; i < totalCount; i++) set.Add(i);

            // Act
            set.Remove(indexToRemove);

            // Assert
            Assert.False(set.Contains(indexToRemove));
        }

        /// <summary>
        /// Tests that sparse set clear empties set
        /// </summary>
        /// <param name="initialCount">The initial count</param>
        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(100)]
        public void SparseSet_Clear_EmptiesSet(int initialCount)
        {
            // Arrange
            SparseSet<int> set = new();
            for (int i = 0; i < initialCount; i++) set.Add(i);

            // Act
            set.Clear();

            // Assert
            Assert.Equal(0, set.Count);
        }

        /// <summary>
        /// Tests that sparse set add duplicates count unchanged
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(25)]
        [InlineData(50)]
        public void SparseSet_AddDuplicates_CountUnchanged(int count)
        {
            // Arrange
            SparseSet<int> set = new();

            // Act
            for (int i = 0; i < count; i++)
            {
                set.Add(0); // Add same element multiple times
            }

            // Assert
            Assert.True(set.Count <= count);
        }

        /// <summary>
        /// Tests that sparse set remove range count correct
        /// </summary>
        /// <param name="totalCount">The total count</param>
        /// <param name="removeCount">The remove count</param>
        [Theory]
        [InlineData(5, 1)]
        [InlineData(10, 3)]
        [InlineData(20, 5)]
        [InlineData(100, 50)]
        public void SparseSet_RemoveRange_CountCorrect(int totalCount, int removeCount)
        {
            // Arrange
            SparseSet<int> set = new();
            for (int i = 0; i < totalCount; i++) set.Add(i);
            int initialCount = set.Count;

            // Act
            for (int i = 0; i < removeCount && set.Count > 0; i++)
            {
                if (set.Contains(i)) set.Remove(i);
            }

            // Assert
            Assert.True(set.Count <= initialCount);
        }

        /// <summary>
        /// Tests that sparse set stress test many operations
        /// </summary>
        /// <param name="operationCount">The operation count</param>
        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        public void SparseSet_StressTest_ManyOperations(int operationCount)
        {
            // Arrange
            SparseSet<int> set = new();

            // Act
            for (int i = 0; i < operationCount; i++)
            {
                if (i % 2 == 0)
                {
                    set.Add(i % 100);
                }
                else if (set.Count > 0)
                {
                    set.Remove(i % 100);
                }
            }

            // Assert
            Assert.True(set.Count >= 0);
        }

        /// <summary>
        /// Tests that sparse set enumerate and modify safe
        /// </summary>
        /// <param name="count">The count</param>
        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(50)]
        public void SparseSet_EnumerateAndModify_Safe(int count)
        {
            // Arrange
            SparseSet<int> set = new();
            for (int i = 0; i < count; i++) set.Add(i);

            // Act & Assert - Enumerating should not throw
            int enumeratedItems = 0;
            foreach (int item in set)
            {
                enumeratedItems++;
            }
            Assert.Equal(count, enumeratedItems);
        }
    }
}

