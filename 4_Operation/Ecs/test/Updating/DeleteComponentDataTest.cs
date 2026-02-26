// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DeleteComponentDataTest.cs
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

using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     The delete component data test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="DeleteComponentData"/> record struct which represents
    ///     metadata about component deletion operations (source and destination indices).
    /// </remarks>
    public class DeleteComponentDataTest
    {
        /// <summary>
        ///     Tests that delete component data can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that DeleteComponentData can be instantiated with valid indices.
        /// </remarks>
        [Fact]
        public void DeleteComponentData_CanBeCreated()
        {
            // Arrange & Act
            DeleteComponentData data = new DeleteComponentData(5, 10);

            // Assert
            Assert.NotNull(data);
            Assert.Equal(5, data.ToIndex);
            Assert.Equal(10, data.FromIndex);
        }

        /// <summary>
        ///     Tests that delete component data fields are preserved
        /// </summary>
        /// <remarks>
        ///     Validates that both fields are correctly stored and retrieved.
        /// </remarks>
        [Fact]
        public void DeleteComponentData_FieldsArePreserved()
        {
            // Arrange
            int toIndex = 42;
            int fromIndex = 99;

            // Act
            DeleteComponentData data = new DeleteComponentData(toIndex, fromIndex);

            // Assert
            Assert.Equal(toIndex, data.ToIndex);
            Assert.Equal(fromIndex, data.FromIndex);
        }

        /// <summary>
        ///     Tests that delete component data with zero indices
        /// </summary>
        /// <remarks>
        ///     Tests creation with zero indices.
        /// </remarks>
        [Fact]
        public void DeleteComponentData_WithZeroIndices()
        {
            // Act
            DeleteComponentData data = new DeleteComponentData(0, 0);

            // Assert
            Assert.Equal(0, data.ToIndex);
            Assert.Equal(0, data.FromIndex);
        }

        /// <summary>
        ///     Tests that delete component data with negative indices
        /// </summary>
        /// <remarks>
        ///     Confirms that negative indices can be stored.
        /// </remarks>
        [Fact]
        public void DeleteComponentData_WithNegativeIndices()
        {
            // Act
            DeleteComponentData data = new DeleteComponentData(-1, -5);

            // Assert
            Assert.Equal(-1, data.ToIndex);
            Assert.Equal(-5, data.FromIndex);
        }

        /// <summary>
        ///     Tests that delete component data with max int values
        /// </summary>
        /// <remarks>
        ///     Validates that maximum int values can be stored.
        /// </remarks>
        [Fact]
        public void DeleteComponentData_WithMaxIntValues()
        {
            // Act
            DeleteComponentData data = new DeleteComponentData(int.MaxValue, int.MaxValue);

            // Assert
            Assert.Equal(int.MaxValue, data.ToIndex);
            Assert.Equal(int.MaxValue, data.FromIndex);
        }

        /// <summary>
        ///     Tests that delete component data is record struct
        /// </summary>
        /// <remarks>
        ///     Confirms that DeleteComponentData behaves as a record struct.
        /// </remarks>
        [Fact]
        public void DeleteComponentData_IsRecordStruct()
        {
            // Arrange & Act
            DeleteComponentData data1 = new DeleteComponentData(5, 10);
            DeleteComponentData data2 = new DeleteComponentData(5, 10);

            // Assert
            Assert.Equal(data1, data2);
        }

        /// <summary>
        ///     Tests that delete component data with different indices are not equal
        /// </summary>
        /// <remarks>
        ///     Validates that records with different values are not equal.
        /// </remarks>
        [Fact]
        public void DeleteComponentData_WithDifferentIndicesAreNotEqual()
        {
            // Arrange & Act
            DeleteComponentData data1 = new DeleteComponentData(5, 10);
            DeleteComponentData data2 = new DeleteComponentData(5, 11);
            DeleteComponentData data3 = new DeleteComponentData(6, 10);

            // Assert
            Assert.NotEqual(data1, data2);
            Assert.NotEqual(data1, data3);
        }
    }
}

