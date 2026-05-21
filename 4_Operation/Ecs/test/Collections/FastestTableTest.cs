// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestTableTest.cs
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
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The fastest table test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="FastestTable{T}" /> collection which provides
    ///     fast table-based storage for the ECS system.
    /// </remarks>
    public class FastestTableTest
    {
        /// <summary>
        ///     Tests that fastest table can be created with capacity
        /// </summary>
        /// <remarks>
        ///     Verifies that a FastestTable can be instantiated with a specific capacity.
        /// </remarks>
        [Fact]
        public void FastestTable_CanBeCreatedWithCapacity()
        {
            FastestTable<int> table = new FastestTable<int>(10);

            Assert.NotNull(table);
        }

        /// <summary>
        ///     Tests that fastest table can store and retrieve values by index
        /// </summary>
        /// <remarks>
        ///     Tests that values can be stored and retrieved using integer indices.
        /// </remarks>
        [Fact]
        public void FastestTable_CanStoreAndRetrieveValuesByIndex()
        {
            FastestTable<int> table = new FastestTable<int>(10);

            table[0] = 42;
            table[5] = 100;

            Assert.Equal(42, table[0]);
            Assert.Equal(100, table[5]);
        }

        /// <summary>
        ///     Tests that fastest table can store reference types
        /// </summary>
        /// <remarks>
        ///     Tests that FastestTable works correctly with reference types.
        /// </remarks>
        [Fact]
        public void FastestTable_CanStoreReferenceTypes()
        {
            FastestTable<string> table = new FastestTable<string>(10);

            table[0] = "Hello";
            table[1] = "World";

            Assert.Equal("Hello", table[0]);
            Assert.Equal("World", table[1]);
        }

        /// <summary>
        ///     Tests that fastest table can store value types
        /// </summary>
        /// <remarks>
        ///     Tests that FastestTable works correctly with value types.
        /// </remarks>
        [Fact]
        public void FastestTable_CanStoreValueTypes()
        {
            FastestTable<double> table = new FastestTable<double>(10);

            table[0] = 3.14;
            table[5] = 2.71;

            Assert.Equal(3.14, table[0]);
            Assert.Equal(2.71, table[5]);
        }

        /// <summary>
        ///     Tests that fastest table can store structs
        /// </summary>
        /// <remarks>
        ///     Validates that FastestTable works with custom struct types.
        /// </remarks>
        [Fact]
        public void FastestTable_CanStoreStructs()
        {
            FastestTable<TestStruct> table = new FastestTable<TestStruct>(10);

            table[0] = new TestStruct {X = 10, Y = 20};

            Assert.Equal(10, table[0].X);
            Assert.Equal(20, table[0].Y);
        }

        /// <summary>
        ///     Tests that fastest table values can be modified through reference
        /// </summary>
        /// <remarks>
        ///     Tests that values in the table can be modified through ref indexer.
        /// </remarks>
        [Fact]
        public void FastestTable_ValuesCanBeModifiedThroughReference()
        {
            FastestTable<int> table = new FastestTable<int>(10);
            table[3] = 50;

            ref int value = ref table[3];
            value = 100;

            Assert.Equal(100, table[3]);
        }

        /// <summary>
        ///     Tests that fastest table can overwrite existing values
        /// </summary>
        /// <remarks>
        ///     Tests that existing values in FastestTable can be overwritten.
        /// </remarks>
        [Fact]
        public void FastestTable_CanOverwriteExistingValues()
        {
            FastestTable<string> table = new FastestTable<string>(10);
            table[5] = "Initial";

            table[5] = "Updated";

            Assert.Equal("Updated", table[5]);
        }

        /// <summary>
        ///     Tests that fastest table handles zero index
        /// </summary>
        /// <remarks>
        ///     Validates that FastestTable can handle index zero correctly.
        /// </remarks>
        [Fact]
        public void FastestTable_HandlesZeroIndex()
        {
            FastestTable<int> table = new FastestTable<int>(10);

            table[0] = 999;

            Assert.Equal(999, table[0]);
        }

        /// <summary>
        ///     Tests that fastest table can store null values for reference types
        /// </summary>
        /// <remarks>
        ///     Tests that FastestTable can store null values for reference types.
        /// </remarks>
        [Fact]
        public void FastestTable_CanStoreNullValuesForReferenceTypes()
        {
            FastestTable<string> table = new FastestTable<string>(10);

            table[5] = null;

            Assert.Null(table[5]);
        }

        /// <summary>
        ///     Tests that fastest table handles multiple consecutive indices
        /// </summary>
        /// <remarks>
        ///     Tests that FastestTable efficiently handles consecutive index assignments.
        /// </remarks>
        [Fact]
        public void FastestTable_HandlesMultipleConsecutiveIndices()
        {
            FastestTable<int> table = new FastestTable<int>(20);

            for (int i = 0; i < 10; i++)
            {
                table[i] = i * 10;
            }

            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(i * 10, table[i]);
            }
        }

        /// <summary>
        ///     Tests that fastest table indexer returns reference
        /// </summary>
        /// <remarks>
        ///     Confirms that the indexer returns a reference that can be modified.
        /// </remarks>
        [Fact]
        public void FastestTable_IndexerReturnsReference()
        {
            FastestTable<int> table = new FastestTable<int>(10);
            table[0] = 10;

            ref int value = ref table[0];
            value += 5;

            Assert.Equal(15, table[0]);
        }

        /// <summary>
        ///     Tests that fastest table can handle complex types
        /// </summary>
        /// <remarks>
        ///     Tests that FastestTable works with complex nested types.
        /// </remarks>
        [Fact]
        public void FastestTable_CanHandleComplexTypes()
        {
            FastestTable<ComplexType> table = new FastestTable<ComplexType>(10);

            table[0] = new ComplexType
            {
                Id = 1,
                Name = "Test",
                Values = new[] {1.0, 2.0, 3.0}
            };

            Assert.Equal(1, table[0].Id);
            Assert.Equal("Test", table[0].Name);
            Assert.Equal(3, table[0].Values.Length);
        }

        /// <summary>
        ///     Tests that fastest table ensure capacity increases size
        /// </summary>
        /// <remarks>
        ///     Tests that EnsureCapacity method properly increases the table's capacity.
        /// </remarks>
        [Fact]
        public void FastestTable_EnsureCapacityIncreasesSize()
        {
            FastestTable<int> table = new FastestTable<int>(5);

            table.EnsureCapacity(20);

            table[19] = 100;
            Assert.Equal(100, table[19]);
        }

        /// <summary>
        ///     Tests that fastest table handles high indices after ensure capacity
        /// </summary>
        /// <remarks>
        ///     Validates that FastestTable properly handles high indices after capacity increase.
        /// </remarks>
        [Fact]
        public void FastestTable_HandlesHighIndicesAfterEnsureCapacity()
        {
            FastestTable<int> table = new FastestTable<int>(10);
            table.EnsureCapacity(100);

            table[99] = 999;

            Assert.Equal(999, table[99]);
        }

        /// <summary>
        ///     Tests that fastest table can be used with default values
        /// </summary>
        /// <remarks>
        ///     Tests that FastestTable properly initializes with default values.
        /// </remarks>
        [Fact]
        public void FastestTable_CanBeUsedWithDefaultValues()
        {
            FastestTable<int> table = new FastestTable<int>(10);

            int value = table[5];

            Assert.Equal(0, value); // Default value for int
        }
    }
}