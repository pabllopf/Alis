// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestStackTest.cs
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
using System.Collections.Generic;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The fastest stack test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="FastestStack{T}"/> collection which provides
    ///     a high-performance stack implementation for the ECS system.
    /// </remarks>
    public class FastestStackTest
    {
        /// <summary>
        ///     Tests that fastest stack can be created with default constructor
        /// </summary>
        /// <remarks>
        ///     Verifies that a FastestStack can be created with the default constructor
        ///     and starts with zero count.
        /// </remarks>
        [Fact]
        public void FastestStack_CanBeCreatedWithDefaultConstructor()
        {
            // Act
            FastestStack<int> stack = new FastestStack<int>();

            // Assert
            Assert.Equal(0, stack.Count);
        }

        /// <summary>
        ///     Tests that fastest stack can be created with capacity
        /// </summary>
        /// <remarks>
        ///     Validates that a FastestStack can be created with a specific initial capacity.
        /// </remarks>
        [Fact]
        public void FastestStack_CanBeCreatedWithCapacity()
        {
            // Act
            FastestStack<int> stack = new FastestStack<int>(10);

            // Assert
            Assert.Equal(0, stack.Count);
            Assert.Equal(10, stack.Capacity);
        }

        /// <summary>
        ///     Tests that fastest stack can be created from enumerable
        /// </summary>
        /// <remarks>
        ///     Tests that a FastestStack can be initialized from an IEnumerable collection.
        /// </remarks>
        [Fact]
        public void FastestStack_CanBeCreatedFromEnumerable()
        {
            // Arrange
            int[] items = { 1, 2, 3, 4, 5 };

            // Act
            FastestStack<int> stack = new FastestStack<int>(items);

            // Assert
            Assert.Equal(5, stack.Count);
        }

        /// <summary>
        ///     Tests that push adds item to stack
        /// </summary>
        /// <remarks>
        ///     Verifies that Push method correctly adds items to the stack.
        /// </remarks>
        [Fact]
        public void Push_AddsItemToStack()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();

            // Act
            stack.Push(42);

            // Assert
            Assert.Equal(1, stack.Count);
        }

        /// <summary>
        ///     Tests that pop removes and returns top item
        /// </summary>
        /// <remarks>
        ///     Tests that Pop method removes and returns the top item from the stack.
        /// </remarks>
        [Fact]
        public void Pop_RemovesAndReturnsTopItem()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);

            // Act
            int result = stack.Pop();

            // Assert
            Assert.Equal(20, result);
            Assert.Equal(1, stack.Count);
        }

        /// <summary>
        ///     Tests that peek returns top item without removing
        /// </summary>
        /// <remarks>
        ///     Validates that Peek method returns the top item without removing it from the stack.
        /// </remarks>
        [Fact]
        public void Peek_ReturnsTopItemWithoutRemoving()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(15);

            // Act
            int result = stack.Peek();

            // Assert
            Assert.Equal(15, result);
            Assert.Equal(1, stack.Count);
        }

        /// <summary>
        ///     Tests that clear removes all items
        /// </summary>
        /// <remarks>
        ///     Tests that Clear method removes all items from the stack.
        /// </remarks>
        [Fact]
        public void Clear_RemovesAllItems()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act
            stack.Clear();

            // Assert
            Assert.Equal(0, stack.Count);
        }

        /// <summary>
        ///     Tests that any returns true when stack has items
        /// </summary>
        /// <remarks>
        ///     Validates that Any property returns true when stack contains items.
        /// </remarks>
        [Fact]
        public void Any_ReturnsTrueWhenStackHasItems()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);

            // Assert
            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that any returns false when stack is empty
        /// </summary>
        /// <remarks>
        ///     Validates that Any property returns false when stack is empty.
        /// </remarks>
        [Fact]
        public void Any_ReturnsFalseWhenStackIsEmpty()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();

            // Assert
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that can pop returns true when stack has items
        /// </summary>
        /// <remarks>
        ///     Tests that CanPop method returns true when items are available.
        /// </remarks>
        [Fact]
        public void CanPop_ReturnsTrueWhenStackHasItems()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(10);

            // Assert
            Assert.True(stack.CanPop());
        }

        /// <summary>
        ///     Tests that can pop returns false when stack is empty
        /// </summary>
        /// <remarks>
        ///     Tests that CanPop method returns false when stack is empty.
        /// </remarks>
        [Fact]
        public void CanPop_ReturnsFalseWhenStackIsEmpty()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();

            // Assert
            Assert.False(stack.CanPop());
        }

        /// <summary>
        ///     Tests that try peek returns true and value when stack has items
        /// </summary>
        /// <remarks>
        ///     Validates that TryPeek returns true and the correct value when items exist.
        /// </remarks>
        [Fact]
        public void TryPeek_ReturnsTrueAndValueWhenStackHasItems()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(25);

            // Act
            bool result = stack.TryPeek(out int value);

            // Assert
            Assert.True(result);
            Assert.Equal(25, value);
        }

        /// <summary>
        ///     Tests that try peek returns false when stack is empty
        /// </summary>
        /// <remarks>
        ///     Validates that TryPeek returns false when stack is empty.
        /// </remarks>
        [Fact]
        public void TryPeek_ReturnsFalseWhenStackIsEmpty()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();

            // Act
            bool result = stack.TryPeek(out int value);

            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }

        /// <summary>
        ///     Tests that try pop returns true and removes item when stack has items
        /// </summary>
        /// <remarks>
        ///     Tests that TryPop returns true and removes the item when successful.
        /// </remarks>
        [Fact]
        public void TryPop_ReturnsTrueAndRemovesItemWhenStackHasItems()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(30);

            // Act
            bool result = stack.TryPop(out int value);

            // Assert
            Assert.True(result);
            Assert.Equal(30, value);
            Assert.Equal(0, stack.Count);
        }

        /// <summary>
        ///     Tests that try pop returns false when stack is empty
        /// </summary>
        /// <remarks>
        ///     Validates that TryPop returns false when stack is empty.
        /// </remarks>
        [Fact]
        public void TryPop_ReturnsFalseWhenStackIsEmpty()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();

            // Act
            bool result = stack.TryPop(out int value);

            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }

        /// <summary>
        ///     Tests that contains returns true when item exists
        /// </summary>
        /// <remarks>
        ///     Tests that Contains method returns true when the specified item exists in the stack.
        /// </remarks>
        [Fact]
        public void Contains_ReturnsTrueWhenItemExists()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(5);
            stack.Push(10);
            stack.Push(15);

            // Assert
            Assert.True(stack.Contains(10));
        }

        /// <summary>
        ///     Tests that contains returns false when item does not exist
        /// </summary>
        /// <remarks>
        ///     Tests that Contains method returns false when the specified item doesn't exist.
        /// </remarks>
        [Fact]
        public void Contains_ReturnsFalseWhenItemDoesNotExist()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(5);

            // Assert
            Assert.False(stack.Contains(10));
        }

        /// <summary>
        ///     Tests that stack maintains lifo order
        /// </summary>
        /// <remarks>
        ///     Validates that the stack maintains Last-In-First-Out (LIFO) order.
        /// </remarks>
        [Fact]
        public void Stack_MaintainsLifoOrder()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act & Assert
            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
        }

        /// <summary>
        ///     Tests that to array returns correct elements
        /// </summary>
        /// <remarks>
        ///     Tests that ToArray method returns an array with all stack elements.
        /// </remarks>
        [Fact]
        public void ToArray_ReturnsCorrectElements()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            // Act
            int[] array = stack.ToArray();

            // Assert
            Assert.Equal(3, array.Length);
            Assert.Contains(1, array);
            Assert.Contains(2, array);
            Assert.Contains(3, array);
        }

        /// <summary>
        ///     Tests that ensure capacity increases capacity
        /// </summary>
        /// <remarks>
        ///     Tests that EnsureCapacity method properly increases the stack's capacity.
        /// </remarks>
        [Fact]
        public void EnsureCapacity_IncreasesCapacity()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>(5);

            // Act
            stack.EnsureCapacity(20);

            // Assert
            Assert.True(stack.Capacity >= 20);
        }

        /// <summary>
        ///     Tests that trim excess reduces capacity
        /// </summary>
        /// <remarks>
        ///     Tests that TrimExcess method reduces the capacity to match the count.
        /// </remarks>
        [Fact]
        public void TrimExcess_ReducesCapacity()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>(100);
            stack.Push(1);
            stack.Push(2);

            // Act
            stack.TrimExcess();

            // Assert
            Assert.True(stack.Capacity <= 10); // Some threshold based on implementation
        }

        /// <summary>
        ///     Tests that stack can handle reference types
        /// </summary>
        /// <remarks>
        ///     Validates that FastestStack works correctly with reference types.
        /// </remarks>
        [Fact]
        public void Stack_CanHandleReferenceTypes()
        {
            // Arrange
            FastestStack<string> stack = new FastestStack<string>();
            stack.Push("Hello");
            stack.Push("World");

            // Act
            string result = stack.Pop();

            // Assert
            Assert.Equal("World", result);
            Assert.Equal(1, stack.Count);
        }

        /// <summary>
        ///     Tests that stack can handle null values
        /// </summary>
        /// <remarks>
        ///     Tests that FastestStack can store and retrieve null values for reference types.
        /// </remarks>
        [Fact]
        public void Stack_CanHandleNullValues()
        {
            // Arrange
            FastestStack<string> stack = new FastestStack<string>();
            stack.Push(null);

            // Act
            string result = stack.Pop();

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that create static method creates stack with capacity
        /// </summary>
        /// <remarks>
        ///     Tests that the static Create method properly initializes a stack with capacity.
        /// </remarks>
        [Fact]
        public void Create_StaticMethodCreatesStackWithCapacity()
        {
            // Act
            FastestStack<int> stack = FastestStack<int>.Create(15);

            // Assert
            Assert.Equal(0, stack.Count);
            Assert.Equal(15, stack.Capacity);
        }

        /// <summary>
        ///     Tests that stack handles large number of items
        /// </summary>
        /// <remarks>
        ///     Tests that the stack can handle a large number of push and pop operations.
        /// </remarks>
        [Fact]
        public void Stack_HandlesLargeNumberOfItems()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();
            const int itemCount = 10000;

            // Act
            for (int i = 0; i < itemCount; i++)
            {
                stack.Push(i);
            }

            // Assert
            Assert.Equal(itemCount, stack.Count);
            
            for (int i = itemCount - 1; i >= 0; i--)
            {
                Assert.Equal(i, stack.Pop());
            }
        }

        /// <summary>
        ///     Tests that constructor with negative capacity throws exception
        /// </summary>
        /// <remarks>
        ///     Validates that creating a stack with negative capacity throws an exception.
        /// </remarks>
        [Fact]
        public void Constructor_WithNegativeCapacity_ThrowsException()
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new FastestStack<int>(-1));
        }

        /// <summary>
        ///     Tests that constructor with null enumerable throws exception
        /// </summary>
        /// <remarks>
        ///     Validates that creating a stack from a null enumerable throws an exception.
        /// </remarks>
        [Fact]
        public void Constructor_WithNullEnumerable_ThrowsException()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new FastestStack<int>(null));
        }

        /// <summary>
        ///     Tests that as span returns correct span
        /// </summary>
        /// <remarks>
        ///     Tests that AsSpan method returns a span representing the stack's contents.
        /// </remarks>
        [Fact]
        public void AsSpan_ReturnsCorrectSpan()
        {
            // Arrange
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // Act
            Span<int> span = stack.AsSpan();

            // Assert
            Assert.Equal(3, span.Length);
        }
    }
}

