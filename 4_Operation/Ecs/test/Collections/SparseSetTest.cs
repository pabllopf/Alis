// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SparseSetTest.cs
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
    ///     The sparse set test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="SparseSet{T}"/> collection which provides
    ///     efficient sparse array storage for the ECS system.
    /// </remarks>
    public class SparseSetTest
    {
        /// <summary>
        ///     Tests that sparse set can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that a SparseSet can be instantiated with the default constructor.
        /// </remarks>
        [Fact]
        public void SparseSet_CanBeCreated()
        {
            // Act
            SparseSet<int> sparseSet = new SparseSet<int>();

            // Assert
            Assert.NotNull(sparseSet);
        }

        /// <summary>
        ///     Tests that sparse set can store and retrieve value by id
        /// </summary>
        /// <remarks>
        ///     Tests that values can be stored and retrieved using integer IDs.
        /// </remarks>
        [Fact]
        public void SparseSet_CanStoreAndRetrieveValueById()
        {
            // Arrange
            SparseSet<int> sparseSet = new SparseSet<int>();

            // Act
            sparseSet[0] = 42;
            sparseSet[5] = 100;

            // Assert
            Assert.Equal(42, sparseSet[0]);
            Assert.Equal(100, sparseSet[5]);
        }

        /// <summary>
        ///     Tests that sparse set can handle large ids
        /// </summary>
        /// <remarks>
        ///     Validates that SparseSet can handle large ID values efficiently.
        /// </remarks>
        [Fact]
        public void SparseSet_CanHandleLargeIds()
        {
            // Arrange
            SparseSet<string> sparseSet = new SparseSet<string>();

            // Act
            sparseSet[1000] = "Large ID";

            // Assert
            Assert.Equal("Large ID", sparseSet[1000]);
        }

        /// <summary>
        ///     Tests that sparse set can store reference types
        /// </summary>
        /// <remarks>
        ///     Tests that SparseSet works correctly with reference types.
        /// </remarks>
        [Fact]
        public void SparseSet_CanStoreReferenceTypes()
        {
            // Arrange
            SparseSet<string> sparseSet = new SparseSet<string>();

            // Act
            sparseSet[0] = "Hello";
            sparseSet[1] = "World";

            // Assert
            Assert.Equal("Hello", sparseSet[0]);
            Assert.Equal("World", sparseSet[1]);
        }

        /// <summary>
        ///     Tests that sparse set can store value types
        /// </summary>
        /// <remarks>
        ///     Tests that SparseSet works correctly with value types.
        /// </remarks>
        [Fact]
        public void SparseSet_CanStoreValueTypes()
        {
            // Arrange
            SparseSet<double> sparseSet = new SparseSet<double>();

            // Act
            sparseSet[2] = 3.14159;
            sparseSet[7] = 2.71828;

            // Assert
            Assert.Equal(3.14159, sparseSet[2]);
            Assert.Equal(2.71828, sparseSet[7]);
        }


        /// <summary>
        ///     Tests that sparse set can store structs
        /// </summary>
        /// <remarks>
        ///     Validates that SparseSet works with custom struct types.
        /// </remarks>
        [Fact]
        public void SparseSet_CanStoreStructs()
        {
            // Arrange
            SparseSet<TestStruct> sparseSet = new SparseSet<TestStruct>();

            // Act
            sparseSet[0] = new TestStruct { X = 10, Y = 20 };

            // Assert
            Assert.Equal(10, sparseSet[0].X);
            Assert.Equal(20, sparseSet[0].Y);
        }

        /// <summary>
        ///     Tests that sparse set values can be modified through reference
        /// </summary>
        /// <remarks>
        ///     Tests that values in the sparse set can be modified through ref indexer.
        /// </remarks>
        [Fact]
        public void SparseSet_ValuesCanBeModifiedThroughReference()
        {
            // Arrange
            SparseSet<int> sparseSet = new SparseSet<int>();
            sparseSet[3] = 50;

            // Act
            ref int value = ref sparseSet[3];
            value = 100;

            // Assert
            Assert.Equal(100, sparseSet[3]);
        }

        /// <summary>
        ///     Tests that sparse set handles non sequential ids
        /// </summary>
        /// <remarks>
        ///     Validates that SparseSet efficiently handles non-sequential ID patterns.
        /// </remarks>
        [Fact]
        public void SparseSet_HandlesNonSequentialIds()
        {
            // Arrange
            SparseSet<int> sparseSet = new SparseSet<int>();

            // Act
            sparseSet[1] = 10;
            sparseSet[10] = 20;
            sparseSet[100] = 30;
            sparseSet[1000] = 40;

            // Assert
            Assert.Equal(10, sparseSet[1]);
            Assert.Equal(20, sparseSet[10]);
            Assert.Equal(30, sparseSet[100]);
            Assert.Equal(40, sparseSet[1000]);
        }

        /// <summary>
        ///     Tests that sparse set can overwrite existing values
        /// </summary>
        /// <remarks>
        ///     Tests that existing values in SparseSet can be overwritten.
        /// </remarks>
        [Fact]
        public void SparseSet_CanOverwriteExistingValues()
        {
            // Arrange
            SparseSet<string> sparseSet = new SparseSet<string>();
            sparseSet[5] = "Initial";

            // Act
            sparseSet[5] = "Updated";

            // Assert
            Assert.Equal("Updated", sparseSet[5]);
        }

        /// <summary>
        ///     Tests that sparse set handles zero id
        /// </summary>
        /// <remarks>
        ///     Validates that SparseSet can handle ID zero correctly.
        /// </remarks>
        [Fact]
        public void SparseSet_HandlesZeroId()
        {
            // Arrange
            SparseSet<int> sparseSet = new SparseSet<int>();

            // Act
            sparseSet[0] = 999;

            // Assert
            Assert.Equal(999, sparseSet[0]);
        }

        /// <summary>
        ///     Tests that sparse set can store null values for reference types
        /// </summary>
        /// <remarks>
        ///     Tests that SparseSet can store null values for reference types.
        /// </remarks>
        [Fact]
        public void SparseSet_CanStoreNullValuesForReferenceTypes()
        {
            // Arrange
            SparseSet<string> sparseSet = new SparseSet<string>();

            // Act
            sparseSet[5] = null;

            // Assert
            Assert.Null(sparseSet[5]);
        }

        /// <summary>
        ///     Tests that sparse set handles multiple consecutive ids
        /// </summary>
        /// <remarks>
        ///     Tests that SparseSet efficiently handles consecutive ID assignments.
        /// </remarks>
        [Fact]
        public void SparseSet_HandlesMultipleConsecutiveIds()
        {
            // Arrange
            SparseSet<int> sparseSet = new SparseSet<int>();

            // Act
            for (int i = 0; i < 10; i++)
            {
                sparseSet[i] = i * 10;
            }

            // Assert
            for (int i = 0; i < 10; i++)
            {
                Assert.Equal(i * 10, sparseSet[i]);
            }
        }

        /// <summary>
        ///     Tests that sparse set handles sparse access pattern
        /// </summary>
        /// <remarks>
        ///     Validates that SparseSet is efficient with very sparse access patterns.
        /// </remarks>
        [Fact]
        public void SparseSet_HandlesSparseAccessPattern()
        {
            // Arrange
            SparseSet<int> sparseSet = new SparseSet<int>();

            // Act
            sparseSet[0] = 1;
            sparseSet[100] = 2;
            sparseSet[200] = 3;
            sparseSet[5000] = 4;

            // Assert
            Assert.Equal(1, sparseSet[0]);
            Assert.Equal(2, sparseSet[100]);
            Assert.Equal(3, sparseSet[200]);
            Assert.Equal(4, sparseSet[5000]);
        }

        /// <summary>
        ///     Tests that sparse set indexer returns reference
        /// </summary>
        /// <remarks>
        ///     Confirms that the indexer returns a reference that can be modified.
        /// </remarks>
        [Fact]
        public void SparseSet_IndexerReturnsReference()
        {
            // Arrange
            SparseSet<int> sparseSet = new SparseSet<int>();
            sparseSet[0] = 10;

            // Act
            ref int value = ref sparseSet[0];
            value += 5;

            // Assert
            Assert.Equal(15, sparseSet[0]);
        }


        /// <summary>
        ///     Tests that sparse set can handle complex types
        /// </summary>
        /// <remarks>
        ///     Tests that SparseSet works with complex nested types.
        /// </remarks>
        [Fact]
        public void SparseSet_CanHandleComplexTypes()
        {
            // Arrange
            SparseSet<ComplexType> sparseSet = new SparseSet<ComplexType>();

            // Act
            sparseSet[0] = new ComplexType 
            { 
                Id = 1, 
                Name = "Test", 
                Values = new[] { 1.0, 2.0, 3.0 } 
            };

            // Assert
            Assert.Equal(1, sparseSet[0].Id);
            Assert.Equal("Test", sparseSet[0].Name);
            Assert.Equal(3, sparseSet[0].Values.Length);
        }
    }
}

