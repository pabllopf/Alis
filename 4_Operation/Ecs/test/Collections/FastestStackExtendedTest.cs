// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestStackExtendedTest.cs
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
    ///     Extended tests for FastestStack to validate comprehensive LIFO behavior,
    ///     capacity management, and edge cases.
    /// </summary>
    public class FastestStackExtendedTest
    {
        /// <summary>
        ///     Test that FastestStack properly handles initial capacity specification.
        /// </summary>
        [Fact]
        public void Constructor_WithCapacity_CapacitySet()
        {
            // Arrange & Act
            var stack = new FastestStack<int>(100);

            // Assert
            Assert.Equal(100, stack.Capacity);
            Assert.Equal(0, stack.Count);
        }

        /// <summary>
        ///     Test that FastestStack raises exception for negative capacity.
        /// </summary>
        [Fact]
        public void Constructor_NegativeCapacity_ThrowsArgumentOutOfRange()
        {
            // Act & Assert
            Assert.Throws<System.ArgumentOutOfRangeException>(() => new FastestStack<int>(-1));
        }

        /// <summary>
        ///     Test that FastestStack properly handles Push and Pop operations.
        /// </summary>
        [Fact]
        public void PushAndPop_MultipleValues_CorrectLIFOOrder()
        {
            // Arrange
            var stack = new FastestStack<int>();

            // Act
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // Assert
            Assert.Equal(30, stack.Pop());
            Assert.Equal(20, stack.Pop());
            Assert.Equal(10, stack.Pop());
        }

        /// <summary>
        ///     Test that FastestStack.Peek returns the top element without removing it.
        /// </summary>
        [Fact]
        public void Peek_WithElements_ReturnsTopWithoutRemoving()
        {
            // Arrange
            var stack = new FastestStack<string>();
            stack.Push("first");
            stack.Push("second");

            // Act
            string peeked = stack.Peek();

            // Assert
            Assert.Equal("second", peeked);
            Assert.Equal(2, stack.Count);
            Assert.Equal("second", stack.Pop());
        }

        /// <summary>
        ///     Test that FastestStack.TryPop returns false when empty.
        /// </summary>
        [Fact]
        public void TryPop_EmptyStack_ReturnsFalse()
        {
            // Arrange
            var stack = new FastestStack<int>();

            // Act
            bool result = stack.TryPop(out int value);

            // Assert
            Assert.False(result);
            Assert.Equal(0, value);
        }

        /// <summary>
        ///     Test that FastestStack.TryPop returns true with correct value when not empty.
        /// </summary>
        [Fact]
        public void TryPop_WithElements_ReturnsTrueWithValue()
        {
            // Arrange
            var stack = new FastestStack<int>();
            stack.Push(42);

            // Act
            bool result = stack.TryPop(out int value);

            // Assert
            Assert.True(result);
            Assert.Equal(42, value);
            Assert.Equal(0, stack.Count);
        }

        /// <summary>
        ///     Test that FastestStack.Clear empties the stack.
        /// </summary>
        [Fact]
        public void Clear_WithElements_StackEmpty()
        {
            // Arrange
            var stack = new FastestStack<int>();
            for (int i = 0; i < 50; i++)
            {
                stack.Push(i);
            }

            // Act
            stack.Clear();

            // Assert
            Assert.Equal(0, stack.Count);
            Assert.True(stack.TryPop(out _) == false);
        }

        /// <summary>
        ///     Test that FastestStack with large number of elements maintains proper LIFO order.
        /// </summary>
        [Fact]
        public void PushPop_LargeNumberOfElements_MaintainsOrder()
        {
            // Arrange
            var stack = new FastestStack<int>();

            // Act
            for (int i = 0; i < 1000; i++)
            {
                stack.Push(i);
            }

            // Assert
            for (int i = 999; i >= 0; i--)
            {
                Assert.Equal(i, stack.Pop());
            }
        }

        /// <summary>
        ///     Test that FastestStack properly expands capacity when needed.
        /// </summary>
        [Fact]
        public void Push_BeyondInitialCapacity_CapacityExpands()
        {
            // Arrange
            var stack = new FastestStack<int>(10);
            int initialCapacity = stack.Capacity;

            // Act
            for (int i = 0; i < 20; i++)
            {
                stack.Push(i);
            }

            // Assert
            Assert.True(stack.Capacity >= 20);
            Assert.Equal(20, stack.Count);
        }

        /// <summary>
        ///     Test that FastestStack.Any returns correct state.
        /// </summary>
        [Fact]
        public void Any_EmptyVsNonEmpty_CorrectState()
        {
            // Arrange
            var stack = new FastestStack<int>();

            // Act & Assert
            Assert.False(stack.Any);

            stack.Push(1);
            Assert.True(stack.Any);

            stack.Clear();
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Test that FastestStack with value types works correctly.
        /// </summary>
        [Fact]
        public void Push_ValueTypes_StoresAndRetrievesCorrectly()
        {
            // Arrange
            var stack = new FastestStack<System.Guid>();
            var guid1 = System.Guid.NewGuid();
            var guid2 = System.Guid.NewGuid();

            // Act
            stack.Push(guid1);
            stack.Push(guid2);

            // Assert
            Assert.Equal(guid2, stack.Pop());
            Assert.Equal(guid1, stack.Pop());
        }

        /// <summary>
        ///     Test that FastestStack works with Contains check.
        /// </summary>
        [Fact]
        public void Contains_AddedItems_ReturnsTrue()
        {
            // Arrange
            var stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // Act & Assert
            Assert.Contains(10, stack);
            Assert.Contains(20, stack);
            Assert.Contains(30, stack);
            Assert.DoesNotContain(40, stack);
        }
    }
}

