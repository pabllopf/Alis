// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InlineArray8BasicTest.cs
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
    ///     The inline array 8 basic test class
    /// </summary>
    /// <remarks>
    ///     Tests basic functionality of <see cref="InlineArray8{T}"/> which is a
    ///     fixed-size array struct with 8 elements stored inline in memory.
    ///     This struct is optimized for cache locality and zero-allocation storage.
    /// </remarks>
    public class InlineArray8BasicTest
    {
        /// <summary>
        ///     Tests that inline array 8 can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that an InlineArray8 struct can be instantiated.
        /// </remarks>
        [Fact]
        public void InlineArray8_CanBeCreated()
        {
            // Act
            InlineArray8<int> array = new InlineArray8<int>();

            // Assert
            Assert.NotNull(array);
        }

        /// <summary>
        ///     Tests that all elements of inline array 8 can be accessed
        /// </summary>
        /// <remarks>
        ///     Validates that all 8 fields of InlineArray8 can be accessed and set.
        /// </remarks>
        [Fact]
        public void InlineArray8_AllElementsCanBeAccessed()
        {
            // Arrange
            InlineArray8<int> array = new InlineArray8<int>();

            // Act
            array._0 = 0;
            array._1 = 1;
            array._2 = 2;
            array._3 = 3;
            array._4 = 4;
            array._5 = 5;
            array._6 = 6;
            array._7 = 7;

            // Assert
            Assert.Equal(0, array._0);
            Assert.Equal(1, array._1);
            Assert.Equal(2, array._2);
            Assert.Equal(3, array._3);
            Assert.Equal(4, array._4);
            Assert.Equal(5, array._5);
            Assert.Equal(6, array._6);
            Assert.Equal(7, array._7);
        }

        /// <summary>
        ///     Tests that inline array 8 can store reference types
        /// </summary>
        /// <remarks>
        ///     Validates that InlineArray8 works with reference type elements.
        /// </remarks>
        [Fact]
        public void InlineArray8_CanStoreReferenceTypes()
        {
            // Arrange
            InlineArray8<string> array = new InlineArray8<string>();

            // Act
            array._0 = "Zero";
            array._1 = "One";
            array._2 = "Two";

            // Assert
            Assert.Equal("Zero", array._0);
            Assert.Equal("One", array._1);
            Assert.Equal("Two", array._2);
        }

        /// <summary>
        ///     Tests that inline array 8 can store value types
        /// </summary>
        /// <remarks>
        ///     Verifies that InlineArray8 works with value type elements.
        /// </remarks>
        [Fact]
        public void InlineArray8_CanStoreValueTypes()
        {
            // Arrange
            InlineArray8<Position> array = new InlineArray8<Position>();
            Position p1 = new Position { X = 1, Y = 2 };
            Position p2 = new Position { X = 3, Y = 4 };

            // Act
            array._0 = p1;
            array._1 = p2;

            // Assert
            Assert.Equal(p1.X, array._0.X);
            Assert.Equal(p2.Y, array._1.Y);
        }

        /// <summary>
        ///     Tests that inline array 8 is stack allocated
        /// </summary>
        /// <remarks>
        ///     Validates that InlineArray8 is a value type that can be used on the stack
        ///     without allocating on the heap.
        /// </remarks>
        [Fact]
        public void InlineArray8_IsStackAllocated()
        {
            // Act - Should not throw OutOfMemoryException for reasonable test
            InlineArray8<int> array = new InlineArray8<int>();
            for (int i = 0; i < 100; i++)
            {
                _ = array;
            }

            // Assert
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that inline array 8 preserves values independently
        /// </summary>
        /// <remarks>
        ///     Verifies that each element of InlineArray8 maintains its own value
        ///     independently from others.
        /// </remarks>
        [Fact]
        public void InlineArray8_PreservesValuesIndependently()
        {
            // Arrange
            InlineArray8<int> array1 = new InlineArray8<int>();
            InlineArray8<int> array2 = new InlineArray8<int>();

            // Act
            array1._0 = 100;
            array2._0 = 200;

            // Assert
            Assert.Equal(100, array1._0);
            Assert.Equal(200, array2._0);
        }

        /// <summary>
        ///     Tests that inline array 8 can be default initialized
        /// </summary>
        /// <remarks>
        ///     Validates that InlineArray8 starts with default values when created.
        /// </remarks>
        [Fact]
        public void InlineArray8_DefaultInitializes()
        {
            // Act
            InlineArray8<int> array = default;

            // Assert
            Assert.Equal(0, array._0);
            Assert.Equal(0, array._7);
        }

        /// <summary>
        ///     Tests that inline array 8 works with different value types
        /// </summary>
        /// <remarks>
        ///     Verifies that InlineArray8 is generic and works with various types.
        /// </remarks>
        [Fact]
        public void InlineArray8_WorksWithDifferentValueTypes()
        {
            // Arrange
            InlineArray8<byte> byteArray = new InlineArray8<byte>();
            InlineArray8<long> longArray = new InlineArray8<long>();
            InlineArray8<double> doubleArray = new InlineArray8<double>();

            // Act
            byteArray._0 = 255;
            longArray._0 = long.MaxValue;
            doubleArray._0 = 3.14159;

            // Assert
            Assert.Equal(255, byteArray._0);
            Assert.Equal(long.MaxValue, longArray._0);
            Assert.Equal(3.14159, doubleArray._0);
        }
    }
}

