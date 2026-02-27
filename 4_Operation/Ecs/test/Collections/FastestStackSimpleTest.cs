// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestStackSimpleTest.cs
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
    ///     Simple tests for FastestStack to validate basic LIFO behavior.
    /// </summary>
    public class FastestStackSimpleTest
    {
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
    }
}

