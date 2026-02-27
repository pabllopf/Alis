// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestTableExtendedTest.cs
// 
//  Author:GitHub Copilot
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
    ///     Extended tests for FastestTable to validate dynamic resizing behavior,
    ///     sparse access patterns, and performance characteristics.
    /// </summary>
    public class FastestTableExtendedTest
    {
        /// <summary>
        ///     Test that FastestTable automatically expands when accessing beyond capacity.
        /// </summary>
        [Fact]
        public void Index_BeyondCapacity_AutomaticallyExpands()
        {
            // Arrange
            var table = new FastestTable<int>(10);

            // Act
            ref int value = ref table[100];
            value = 42;

            // Assert
            Assert.Equal(42, table[100]);
            Assert.True(table._buffer.Length > 100);
        }

        /// <summary>
        ///     Test that FastestTable handles consecutive reads and writes correctly.
        /// </summary>
        [Fact]
        public void ReadWrite_ConsecutiveOperations_DataConsistent()
        {
            // Arrange
            var table = new FastestTable<string>(50);

            // Act
            for (int i = 0; i < 100; i++)
            {
                ref string str = ref table[i];
                str = $"Value_{i}";
            }

            // Assert
            for (int i = 0; i < 100; i++)
            {
                Assert.Equal($"Value_{i}", table[i]);
            }
        }

        /// <summary>
        ///     Test that FastestTable properly handles sparse index access.
        /// </summary>
        [Fact]
        public void Index_SparseAccess_AllIndexesAccessible()
        {
            // Arrange
            var table = new FastestTable<long>(10);
            int[] sparseIndices = { 5, 50, 500, 5000 };

            // Act
            for (int i = 0; i < sparseIndices.Length; i++)
            {
                ref long val = ref table[sparseIndices[i]];
                val = (long)sparseIndices[i] * 100;
            }

            // Assert
            for (int i = 0; i < sparseIndices.Length; i++)
            {
                Assert.Equal((long)sparseIndices[i] * 100, table[sparseIndices[i]]);
            }
        }

        /// <summary>
        ///     Test that FastestTable.EnsureCapacity works correctly.
        /// </summary>
        [Fact]
        public void EnsureCapacity_PreallocateSpace_ReducesExpansions()
        {
            // Arrange
            var table = new FastestTable<int>(10);

            // Act
            table.EnsureCapacity(1000);

            // Assert
            Assert.True(table._buffer.Length >= 1000);
        }

        /// <summary>
        ///     Test that FastestTable.UnsafeIndexNoResize works without expanding.
        /// </summary>
        [Fact]
        public void UnsafeIndexNoResize_WithinCapacity_Succeeds()
        {
            // Arrange
            var table = new FastestTable<int>(100);

            // Act
            ref int value = ref table.UnsafeIndexNoResize(50);
            value = 123;

            // Assert
            Assert.Equal(123, table.UnsafeIndexNoResize(50));
        }

        /// <summary>
        ///     Test that FastestTable properly initializes with Empty.
        /// </summary>
        [Fact]
        public void Empty_DefaultTable_HasEmptyBuffer()
        {
            // Arrange & Act
            var emptyTable = FastestTable<int>.Empty;

            // Assert
            Assert.NotNull(emptyTable._buffer);
            Assert.Equal(0, emptyTable._buffer.Length);
        }

        /// <summary>
        ///     Test that FastestTable handles large index values gracefully.
        /// </summary>
        [Fact]
        public void Index_LargeIndexValue_BufferExpandsAppropriately()
        {
            // Arrange
            var table = new FastestTable<int>(10);
            int largeIndex = 100000;

            // Act
            ref int value = ref table[largeIndex];
            value = 999;

            // Assert
            Assert.Equal(999, table[largeIndex]);
            Assert.True(table._buffer.Length > largeIndex);
        }

        /// <summary>
        ///     Test that FastestTable with reference types maintains proper references.
        /// </summary>
        [Fact]
        public void Index_ReferenceType_MaintainsReferenceIntegrity()
        {
            // Arrange
            var table = new FastestTable<object>(10);
            var obj1 = new { ID = 1 };
            var obj2 = new { ID = 2 };

            // Act
            ref object ref1 = ref table[0];
            ref1 = obj1;
            ref object ref2 = ref table[10];
            ref2 = obj2;

            // Assert
            Assert.Same(obj1, table[0]);
            Assert.Same(obj2, table[10]);
        }

        /// <summary>
        ///     Test that FastestTable capacity is always power of 2.
        /// </summary>
        [Fact]
        public void Capacity_AlwaysPowerOfTwo_Valid()
        {
            // Arrange & Act
            var table1 = new FastestTable<int>(10);
            var table2 = new FastestTable<int>(100);
            var table3 = new FastestTable<int>(1023);

            // Assert - Check that length is power of 2
            Assert.True(IsPowerOfTwo(table1._buffer.Length));
            Assert.True(IsPowerOfTwo(table2._buffer.Length));
            Assert.True(IsPowerOfTwo(table3._buffer.Length));
        }

        /// <summary>
        ///     Test that repeated resizing maintains data integrity.
        /// </summary>
        [Fact]
        public void MultipleResizings_DataIntegrity_Maintained()
        {
            // Arrange
            var table = new FastestTable<int>(2);

            // Act
            for (int i = 0; i < 1000; i++)
            {
                ref int val = ref table[i];
                val = i * 2;
            }

            // Assert
            for (int i = 0; i < 1000; i++)
            {
                Assert.Equal(i * 2, table[i]);
            }
        }

        /// <summary>
        ///     Helper method to check if a number is power of 2.
        /// </summary>
        private static bool IsPowerOfTwo(int value)
        {
            return value > 0 && (value & (value - 1)) == 0;
        }
    }
}

