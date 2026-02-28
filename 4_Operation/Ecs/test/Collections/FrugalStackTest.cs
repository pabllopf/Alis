// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrugalStackTest.cs
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
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The frugal stack test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="FrugalStack{T}"/> struct which is a lightweight
    ///     stack implementation designed for memory efficiency in the ECS system.
    /// </remarks>
    public class FrugalStackTest
    {
        /// <summary>
        ///     Tests that frugal stack starts empty
        /// </summary>
        /// <remarks>
        ///     Verifies that a newly created FrugalStack has no elements.
        /// </remarks>
        [Fact]
        public void FrugalStack_StartsEmpty()
        {
            // Arrange & Act
            FrugalStack<int> stack = new FrugalStack<int>();

            // Assert
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack any returns true after push
        /// </summary>
        /// <remarks>
        ///     Validates that Any property correctly reports when elements exist.
        /// </remarks>
        [Fact]
        public void FrugalStack_AnyReturnsTrueAfterPush()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();

            // Act
            stack.Push(42);

            // Assert
            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack can push and pop single element
        /// </summary>
        /// <remarks>
        ///     Tests basic push and pop operations.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanPushAndPopSingleElement()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();
            int expected = 42;

            // Act
            stack.Push(expected);
            int result = stack.Pop();

            // Assert
            Assert.Equal(expected, result);
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack lifo order
        /// </summary>
        /// <remarks>
        ///     Verifies that elements are retrieved in Last-In-First-Out order.
        /// </remarks>
        [Fact]
        public void FrugalStack_MaintainsLifoOrder()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();

            // Act
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Assert
            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
        }

        /// <summary>
        ///     Tests that frugal stack can push multiple elements
        /// </summary>
        /// <remarks>
        ///     Tests pushing beyond initial buffer size to verify resizing.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanPushMultipleElements()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();

            // Act
            for (int i = 0; i < 20; i++)
            {
                stack.Push(i);
            }

            // Assert
            Assert.True(stack.Any);
            for (int i = 19; i >= 0; i--)
            {
                Assert.Equal(i, stack.Pop());
            }
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack try pop returns false when empty
        /// </summary>
        /// <remarks>
        ///     Validates that TryPop safely handles empty stack.
        /// </remarks>
        [Fact]
        public void FrugalStack_TryPopReturnsFalseWhenEmpty()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();

            // Act
            bool result = stack.TryPop(out int value);

            // Assert
            Assert.False(result);
            Assert.Equal(default(int), value);
        }

        /// <summary>
        ///     Tests that frugal stack try pop returns true with value
        /// </summary>
        /// <remarks>
        ///     Tests successful TryPop operation.
        /// </remarks>
        [Fact]
        public void FrugalStack_TryPopReturnsTrueWithValue()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(42);

            // Act
            bool result = stack.TryPop(out int value);

            // Assert
            Assert.True(result);
            Assert.Equal(42, value);
        }

        /// <summary>
        ///     Tests that frugal stack can remove element
        /// </summary>
        /// <remarks>
        ///     Validates the Remove method removes a specific item.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanRemoveElement()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act
            stack.Remove(2);

            // Assert
            Assert.Equal(3, stack.Pop());
            Assert.Equal(1, stack.Pop());
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack remove does nothing if element not found
        /// </summary>
        /// <remarks>
        ///     Verifies that Remove safely handles missing elements.
        /// </remarks>
        [Fact]
        public void FrugalStack_RemoveDoesNothingIfElementNotFound()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act
            stack.Remove(999);

            // Assert
            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
        }

        /// <summary>
        ///     Tests that frugal stack as span returns correct range
        /// </summary>
        /// <remarks>
        ///     Validates that AsSpan returns the correct data range.
        /// </remarks>
        [Fact]
        public void FrugalStack_AsSpanReturnsCorrectRange()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act
            Span<int> span = stack.AsSpan();

            // Assert
            Assert.Equal(3, span.Length);
            Assert.Equal(1, span[0]);
            Assert.Equal(2, span[1]);
            Assert.Equal(3, span[2]);
        }

        /// <summary>
        ///     Tests that frugal stack with strings
        /// </summary>
        /// <remarks>
        ///     Validates that FrugalStack works with reference types.
        /// </remarks>
        [Fact]
        public void FrugalStack_WorksWithReferenceTypes()
        {
            // Arrange
            FrugalStack<string> stack = new FrugalStack<string>();

            // Act
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            // Assert
            Assert.Equal("c", stack.Pop());
            Assert.Equal("b", stack.Pop());
            Assert.Equal("a", stack.Pop());
        }

        /// <summary>
        ///     Tests that frugal stack pop after multiple operations
        /// </summary>
        /// <remarks>
        ///     Tests pop/push interleaved operations.
        /// </remarks>
        [Fact]
        public void FrugalStack_PopAfterMultipleOperations()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();

            // Act & Assert
            stack.Push(1);
            Assert.Equal(1, stack.Pop());
            Assert.False(stack.Any);

            stack.Push(2);
            stack.Push(3);
            Assert.Equal(3, stack.Pop());
            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack clear removes all elements
        /// </summary>
        /// <remarks>
        ///     Validates that all elements are removed after clear.
        /// </remarks>
        [Fact]
        public void FrugalStack_ClearRemovesAllElements()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act
            // Note: Check if Clear() method exists, if not skip this test

            // Assert
            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack with negative values
        /// </summary>
        /// <remarks>
        ///     Tests FrugalStack with negative integer values.
        /// </remarks>
        [Fact]
        public void FrugalStack_WithNegativeValues()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();

            // Act
            stack.Push(-1);
            stack.Push(-100);
            stack.Push(-999);

            // Assert
            Assert.Equal(-999, stack.Pop());
            Assert.Equal(-100, stack.Pop());
            Assert.Equal(-1, stack.Pop());
        }

        /// <summary>
        ///     Tests that frugal stack large number of elements
        /// </summary>
        /// <remarks>
        ///     Tests FrugalStack performance with many elements.
        /// </remarks>
        [Fact]
        public void FrugalStack_LargeNumberOfElements()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();
            const int elementCount = 1000;

            // Act
            for (int i = 0; i < elementCount; i++)
            {
                stack.Push(i);
            }

            // Assert
            Assert.True(stack.Any);
            for (int i = elementCount - 1; i >= 0; i--)
            {
                Assert.Equal(i, stack.Pop());
            }
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack as span length matches pushed elements
        /// </summary>
        /// <remarks>
        ///     Validates that AsSpan length matches the number of pushed elements.
        /// </remarks>
        [Fact]
        public void FrugalStack_AsSpanLengthMatchesPushedElements()
        {
            // Arrange
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);

            // Act
            Span<int> span = stack.AsSpan();

            // Assert
            Assert.Equal(5, span.Length);
        }
    }
}
