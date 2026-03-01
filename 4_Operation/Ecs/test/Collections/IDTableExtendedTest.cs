// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IDTableExtendedTest.cs
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
    ///     Extended tests for IdTable to validate indexed storage,
    ///     capacity management, and sparse access patterns.
    /// </summary>
    public class IdTableExtendedTest
    {
        /// <summary>
        ///     Test that IdTable can be created successfully.
        /// </summary>
        [Fact]
        public void Constructor_Default_CreatedSuccessfully()
        {
            // Arrange & Act
            var table = new IdTable<int>();

            // Assert
            Assert.NotNull(table);
        }

        /// <summary>
        ///     Test that IdTable.Create and Take work correctly.
        /// </summary>
        [Fact]
        public void CreateAndTake_StoreAndRetrieve_Works()
        {
            // Arrange
            var table = new IdTable<int>();

            // Act
            ref int slot = ref table.Create(out int index);
            slot = 42;
            int retrieved = table.Take(index);

            // Assert
            Assert.Equal(42, retrieved);
        }

        /// <summary>
        ///     Test that IdTable handles multiple sequential inserts.
        /// </summary>
        [Fact]
        public void Create_MultipleSequential_AllAccessible()
        {
            // Arrange
            var table = new IdTable<string>();

            // Act
            var indices = new int[100];
            for (int i = 0; i < 100; i++)
            {
                ref string str = ref table.Create(out indices[i]);
                str = $"Item_{i}";
            }

            // Assert
            for (int i = 0; i < 100; i++)
            {
                string retrieved = table.Take(indices[i]);
                Assert.Equal($"Item_{i}", retrieved);
            }
        }

        /// <summary>
        ///     Test that IdTable handles multiple creates and takes.
        /// </summary>
        [Fact]
        public void CreateAndTake_Multiple_AllStoredCorrectly()
        {
            // Arrange
            var table = new IdTable<long>();
            var indices = new int[4];
            long[] values = { 10, 100, 500, 1000 };

            // Act
            for (int i = 0; i < values.Length; i++)
            {
                ref long val = ref table.Create(out indices[i]);
                val = values[i] * 10;
            }

            // Assert
            for (int i = 0; i < values.Length; i++)
            {
                long retrieved = table.Take(indices[i]);
                Assert.Equal(values[i] * 10, retrieved);
            }
        }

        /// <summary>
        ///     Test that IdTable handles large index values through multiple creates.
        /// </summary>
        [Fact]
        public void Create_ManyElements_AllAccessible()
        {
            // Arrange
            var table = new IdTable<int>();
            var indices = new int[1000];

            // Act
            for (int i = 0; i < 1000; i++)
            {
                ref int val = ref table.Create(out indices[i]);
                val = i * 2;
            }

            // Assert
            for (int i = 0; i < 1000; i++)
            {
                int retrieved = table.Take(indices[i]);
                Assert.Equal(i * 2, retrieved);
            }
        }

        /// <summary>
        ///     Test that IdTable with reference types maintains proper references.
        /// </summary>
        [Fact]
        public void Create_ReferenceType_MaintainReferences()
        {
            // Arrange
            var table = new IdTable<object>();
            var obj1 = new { ID = 1 };
            var obj2 = new { ID = 2 };

            // Act
            ref object ref1 = ref table.Create(out int index1);
            ref1 = obj1;
            ref object ref2 = ref table.Create(out int index2);
            ref2 = obj2;

            // Assert
            Assert.Same(obj1, table.Take(index1));
            Assert.Same(obj2, table.Take(index2));
        }

        /// <summary>
        ///     Test that IdTable handles multiple creates with different types.
        /// </summary>
        [Fact]
        public void Create_DifferentValueTypes_WorksCorrectly()
        {
            // Arrange
            var intTable = new IdTable<int>();
            var stringTable = new IdTable<string>();
            var doubleTable = new IdTable<double>();

            // Act
            ref int intVal = ref intTable.Create(out int intIdx);
            intVal = 42;
            
            ref string strVal = ref stringTable.Create(out int strIdx);
            strVal = "test";
            
            ref double dblVal = ref doubleTable.Create(out int dblIdx);
            dblVal = 3.14;

            // Assert
            Assert.Equal(42, intTable.Take(intIdx));
            Assert.Equal("test", stringTable.Take(strIdx));
            Assert.Equal(3.14, doubleTable.Take(dblIdx));
        }
    }
}

