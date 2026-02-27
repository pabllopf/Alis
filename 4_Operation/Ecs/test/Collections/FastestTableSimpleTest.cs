// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestTableSimpleTest.cs
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
    ///     Simple tests for FastestTable to validate dynamic resizing behavior.
    /// </summary>
    public class FastestTableSimpleTest
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
        ///     Test that FastestTable.Empty works correctly.
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
    }
}

