// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RefStructTest.cs
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

using System;
using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     The ref struct test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="Ref{T}"/> ref struct which provides a wrapper
    ///     over references to values for safe component access.
    /// </remarks>
    public class RefStructTest
    {
        /// <summary>
        ///     Tests that ref can be created from array
        /// </summary>
        /// <remarks>
        ///     Verifies that Ref can be instantiated from an array.
        /// </remarks>
        [Fact]
        public void Ref_CanBeCreatedFromArray()
        {
            // Arrange
            int[] arr = { 1, 2, 3, 4, 5 };

            // Act
            Ref<int> refValue = new Ref<int>(arr, 0);

            // Assert
            Assert.Equal(1, refValue.Value);
        }

        /// <summary>
        ///     Tests that ref can access different indices
        /// </summary>
        /// <remarks>
        ///     Validates that Ref correctly accesses different array indices.
        /// </remarks>
        [Fact]
        public void Ref_CanAccessDifferentIndices()
        {
            // Arrange
            int[] arr = { 10, 20, 30, 40, 50 };

            // Act
            Ref<int> ref0 = new Ref<int>(arr, 0);
            Ref<int> ref2 = new Ref<int>(arr, 2);
            Ref<int> ref4 = new Ref<int>(arr, 4);

            // Assert
            Assert.Equal(10, ref0.Value);
            Assert.Equal(30, ref2.Value);
            Assert.Equal(50, ref4.Value);
        }

        /// <summary>
        ///     Tests that ref can modify value
        /// </summary>
        /// <remarks>
        ///     Validates that Ref allows modifying the referenced value.
        /// </remarks>
        [Fact]
        public void Ref_CanModifyValue()
        {
            // Arrange
            int[] arr = { 1, 2, 3 };
            Ref<int> refValue = new Ref<int>(arr, 1);

            // Act
            refValue.Value = 999;

            // Assert
            Assert.Equal(999, arr[1]);
        }

        /// <summary>
        ///     Tests that ref implicit conversion to value
        /// </summary>
        /// <remarks>
        ///     Tests implicit conversion from Ref to T.
        /// </remarks>
        [Fact]
        public void Ref_ImplicitConversionToValue()
        {
            // Arrange
            int[] arr = { 42 };
            Ref<int> refValue = new Ref<int>(arr, 0);

            // Act
            int value = refValue;

            // Assert
            Assert.Equal(42, value);
        }

        /// <summary>
        ///     Tests that ref to string returns value string representation
        /// </summary>
        /// <remarks>
        ///     Validates that ToString() returns the string representation of the value.
        /// </remarks>
        [Fact]
        public void Ref_ToStringReturnsValueStringRepresentation()
        {
            // Arrange
            int[] arr = { 123 };
            Ref<int> refValue = new Ref<int>(arr, 0);

            // Act
            string result = refValue.ToString();

            // Assert
            Assert.Equal("123", result);
        }

        /// <summary>
        ///     Tests that ref with string type
        /// </summary>
        /// <remarks>
        ///     Tests Ref with reference type (string).
        /// </remarks>
        [Fact]
        public void Ref_WithStringType()
        {
            // Arrange
            string[] arr = { "hello", "world" };
            Ref<string> refValue = new Ref<string>(arr, 0);

            // Act & Assert
            Assert.Equal("hello", refValue.Value);
        }

        /// <summary>
        ///     Tests that ref can be created from span
        /// </summary>
        /// <remarks>
        ///     Verifies that Ref can be created from a Span.
        /// </remarks>
        [Fact]
        public void Ref_CanBeCreatedFromSpan()
        {
            // Arrange
            int[] arr = { 1, 2, 3, 4, 5 };
            Span<int> span = arr.AsSpan();

            // Act
            Ref<int> refValue = new Ref<int>(span, 2);

            // Assert
            Assert.Equal(3, refValue.Value);
        }

        /// <summary>
        ///     Tests that ref with null value
        /// </summary>
        /// <remarks>
        ///     Tests Ref with null string value.
        /// </remarks>
        [Fact]
        public void Ref_WithNullValue()
        {
            // Arrange
            string[] arr = { null, "test" };
            Ref<string> refValue = new Ref<string>(arr, 0);

            // Act & Assert
            Assert.Null(refValue.Value);
        }

        /// <summary>
        ///     Tests that ref multiple modifications
        /// </summary>
        /// <remarks>
        ///     Validates multiple modifications through the same Ref.
        /// </remarks>
        [Fact]
        public void Ref_MultipleModifications()
        {
            // Arrange
            int[] arr = { 0 };
            Ref<int> refValue = new Ref<int>(arr, 0);

            // Act
            refValue.Value = 10;
            refValue.Value = 20;
            refValue.Value = 30;

            // Assert
            Assert.Equal(30, arr[0]);
        }
    }
}

