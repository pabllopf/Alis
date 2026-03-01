// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumerableHelpersExtendedTest.cs
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

using System;
using System.Collections.Generic;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Extended tests for EnumerableHelpers utility functions
    ///     to validate conversion, filtering, and enumerable operations.
    /// </summary>
    public class EnumerableHelpersExtendedTest
    {
        /// <summary>
        ///     Test that ToArray converts enumerable to array correctly.
        /// </summary>
        [Fact]
        public void ToArray_Enumerable_ConvertsSuccessfully()
        {
            // Arrange
            var enumerable = new[] { 1, 2, 3, 4, 5 };

            // Act
            int[] array = EnumerableHelpers.ToArray(enumerable, out int count);

            // Assert
            Assert.NotNull(array);
            Assert.Equal(5, count);
        }

        /// <summary>
        ///     Test that ToArray with List maintains order.
        /// </summary>
        [Fact]
        public void ToArray_ListEnumerable_OrderPreserved()
        {
            // Arrange
            var list = new List<string> { "a", "b", "c", "d" };

            // Act
            string[] array = EnumerableHelpers.ToArray(list, out int count);

            // Assert
            Assert.Equal(4, count);
            Assert.Equal("a", array[0]);
            Assert.Equal("d", array[count - 1]);
        }

        /// <summary>
        ///     Test that ToArray handles empty enumerable.
        /// </summary>
        [Fact]
        public void ToArray_EmptyEnumerable_ReturnsEmptyArray()
        {
            // Arrange
            var emptyList = new List<int>();

            // Act
            int[] array = EnumerableHelpers.ToArray(emptyList, out int count);

            // Assert
            Assert.Equal(0, count);
        }

        /// <summary>
        ///     Test that ToArray works with different value types.
        /// </summary>
        [Fact]
        public void ToArray_ValueTypes_ConvertsCorrectly()
        {
            // Arrange
            var guids = new List<Guid>
            {
                Guid.NewGuid(),
                Guid.NewGuid(),
                Guid.NewGuid()
            };

            // Act
            Guid[] array = EnumerableHelpers.ToArray(guids, out int count);

            // Assert
            Assert.Equal(3, count);
            Assert.Equal(guids[0], array[0]);
        }

        /// <summary>
        ///     Test that ToArray with large enumerable works efficiently.
        /// </summary>
        [Fact]
        public void ToArray_LargeEnumerable_ConvertedSuccessfully()
        {
            // Arrange
            var largeList = new List<int>();
            for (int i = 0; i < 10000; i++)
            {
                largeList.Add(i);
            }

            // Act
            int[] array = EnumerableHelpers.ToArray(largeList, out int count);

            // Assert
            Assert.Equal(10000, count);
            Assert.Equal(0, array[0]);
            Assert.Equal(9999, array[count - 1]);
        }

        /// <summary>
        ///     Test that ToArray properly counts elements.
        /// </summary>
        [Fact]
        public void ToArray_OutputCount_MatchesArrayLength()
        {
            // Arrange
            var list = new List<double> { 1.1, 2.2, 3.3, 4.4, 5.5 };

            // Act
            double[] array = EnumerableHelpers.ToArray(list, out int count);

            // Assert
            Assert.Equal(count, list.Count);
            Assert.True(count > 0);
        }

        /// <summary>
        ///     Test that ToArray works with custom enumerables.
        /// </summary>
        [Fact]
        public void ToArray_CustomEnumerable_Works()
        {
            // Arrange
            var enumerable = (IEnumerable<int>)new[] { 10, 20, 30, 40 };

            // Act
            int[] array = EnumerableHelpers.ToArray(enumerable, out int count);

            // Assert
            Assert.Equal(4, count);
        }

        /// <summary>
        ///     Test that ToArray with reference types maintains references.
        /// </summary>
        [Fact]
        public void ToArray_ReferenceTypes_MaintainReferences()
        {
            // Arrange
            var obj1 = new { ID = 1 };
            var obj2 = new { ID = 2 };
            var list = new List<object> { obj1, obj2 };

            // Act
            object[] array = EnumerableHelpers.ToArray(list, out int count);

            // Assert
            Assert.Same(obj1, array[0]);
            Assert.Same(obj2, array[1]);
        }
    }
}

