// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TagIDExtendedTest.cs
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

using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The tag id extended test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="TagId"/> struct which represents
    ///     a lightweight identifier for tag types in the ECS system.
    ///     This is an extended test suite with more comprehensive coverage.
    /// </remarks>
    public class TagIdExtendedTest
    {
        /// <summary>
        ///     Tests that tag id can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that TagId can be instantiated with a raw index.
        /// </remarks>
        [Fact]
        public void TagId_CanBeCreated()
        {
            // Act
            TagId tagId = new TagId(0);

            // Assert
            Assert.NotNull(tagId);
        }

        /// <summary>
        ///     Tests that tag id raw index is preserved
        /// </summary>
        /// <remarks>
        ///     Validates that the RawValue field is correctly stored.
        /// </remarks>
        [Fact]
        public void TagId_RawIndexIsPreserved()
        {
            // Act
            TagId tagId = new TagId(42);

            // Assert
            Assert.Equal((ushort)42, tagId.RawValue);
        }

        /// <summary>
        ///     Tests that tag id with zero index
        /// </summary>
        /// <remarks>
        ///     Tests creation with zero index.
        /// </remarks>
        [Fact]
        public void TagId_WithZeroIndex()
        {
            // Act
            TagId tagId = new TagId(0);

            // Assert
            Assert.Equal((ushort)0, tagId.RawValue);
        }

        /// <summary>
        ///     Tests that tag id with max index
        /// </summary>
        /// <remarks>
        ///     Tests creation with maximum ushort index.
        /// </remarks>
        [Fact]
        public void TagId_WithMaxIndex()
        {
            // Act
            TagId tagId = new TagId(ushort.MaxValue);

            // Assert
            Assert.Equal(ushort.MaxValue, tagId.RawValue);
        }

        /// <summary>
        ///     Tests that tag id equals with same index
        /// </summary>
        /// <remarks>
        ///     Tests equality comparison with same index.
        /// </remarks>
        [Fact]
        public void TagId_EqualsWithSameIndex()
        {
            // Arrange
            TagId tagId1 = new TagId(5);
            TagId tagId2 = new TagId(5);

            // Assert
            Assert.True(tagId1.Equals(tagId2));
            Assert.Equal(tagId1, tagId2);
        }

        /// <summary>
        ///     Tests that tag id not equals with different index
        /// </summary>
        /// <remarks>
        ///     Tests inequality comparison with different indices.
        /// </remarks>
        [Fact]
        public void TagId_NotEqualsWithDifferentIndex()
        {
            // Arrange
            TagId tagId1 = new TagId(1);
            TagId tagId2 = new TagId(2);

            // Assert
            Assert.False(tagId1.Equals(tagId2));
            Assert.NotEqual(tagId1, tagId2);
        }

        /// <summary>
        ///     Tests that tag id hash code equals with same index
        /// </summary>
        /// <remarks>
        ///     Validates that hash codes are equal for same indices.
        /// </remarks>
        [Fact]
        public void TagId_HashCodeEqualsWithSameIndex()
        {
            // Arrange
            TagId tagId1 = new TagId(10);
            TagId tagId2 = new TagId(10);

            // Assert
            Assert.Equal(tagId1.GetHashCode(), tagId2.GetHashCode());
        }

        /// <summary>
        ///     Tests that tag id equality operator
        /// </summary>
        /// <remarks>
        ///     Tests the == operator for TagId.
        /// </remarks>
        [Fact]
        public void TagId_EqualityOperator()
        {
            // Arrange
            TagId tagId1 = new TagId(7);
            TagId tagId2 = new TagId(7);
            TagId tagId3 = new TagId(8);

            // Assert
            Assert.True(tagId1 == tagId2);
            Assert.False(tagId1 == tagId3);
        }

        /// <summary>
        ///     Tests that tag id inequality operator
        /// </summary>
        /// <remarks>
        ///     Tests the != operator for TagId.
        /// </remarks>
        [Fact]
        public void TagId_InequalityOperator()
        {
            // Arrange
            TagId tagId1 = new TagId(7);
            TagId tagId2 = new TagId(7);
            TagId tagId3 = new TagId(8);

            // Assert
            Assert.False(tagId1 != tagId2);
            Assert.True(tagId1 != tagId3);
        }
    }
}

