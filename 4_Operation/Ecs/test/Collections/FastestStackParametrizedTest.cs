// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestStackParametrizedTest.cs
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
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Parametrized tests for FastestStack collection
    /// </summary>
    public class FastestStackParametrizedTest
    {
        /// <summary>
        ///     Tests that fastest stack push elements count increases
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10), InlineData(50), InlineData(100)]
        public void FastestStack_PushElements_CountIncreases(int count)
        {
            // Arrange
            FastestStack<int> stack = new();

            // Act
            for (int i = 0; i < count; i++)
            {
                stack.Push(i);
            }

            // Assert
            Assert.Equal(count, stack.Count);
        }

        /// <summary>
        ///     Tests that fastest stack push and pop lifo order
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10), InlineData(50)]
        public void FastestStack_PushAndPop_LifoOrder(int count)
        {
            // Arrange
            FastestStack<int> stack = new();
            for (int i = 0; i < count; i++)
            {
                stack.Push(i);
            }

            // Act & Assert
            for (int i = count - 1; i >= 0; i--)
            {
                Assert.Equal(i, stack.Pop());
            }

            Assert.Equal(0, stack.Count);
        }

        /// <summary>
        ///     Tests that fastest stack peek does not remove
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(10), InlineData(50), InlineData(100)]
        public void FastestStack_Peek_DoesNotRemove(int count)
        {
            // Arrange
            FastestStack<int> stack = new();
            for (int i = 0; i < count; i++)
            {
                stack.Push(i);
            }

            // Act
            int peeked = stack.Peek();

            // Assert
            Assert.Equal(count - 1, peeked);
            Assert.Equal(count, stack.Count);
        }

        /// <summary>
        ///     Tests that fastest stack clear empties stack
        /// </summary>
        /// <param name="initialCount">The initial count</param>
        [Theory, InlineData(10), InlineData(50), InlineData(100)]
        public void FastestStack_Clear_EmptiesStack(int initialCount)
        {
            // Arrange
            FastestStack<int> stack = new();
            for (int i = 0; i < initialCount; i++)
            {
                stack.Push(i);
            }

            // Act
            stack.Clear();

            // Assert
            Assert.Equal(0, stack.Count);
        }

        /// <summary>
        ///     Tests that fastest stack try pop succeeds when not empty
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10)]
        public void FastestStack_TryPop_SucceedsWhenNotEmpty(int count)
        {
            // Arrange
            FastestStack<int> stack = new();
            for (int i = 0; i < count; i++)
            {
                stack.Push(i);
            }

            // Act
            bool success = stack.TryPop(out int result);

            // Assert
            Assert.True(success);
            Assert.Equal(count - 1, result);
        }

        /// <summary>
        ///     Tests that fastest stack try pop fails when empty
        /// </summary>
        [Fact]
        public void FastestStack_TryPop_FailsWhenEmpty()
        {
            // Arrange
            FastestStack<int> stack = new();

            // Act
            bool success = stack.TryPop(out int result);

            // Assert
            Assert.False(success);
        }

        /// <summary>
        ///     Tests that fastest stack try peek succeeds when not empty
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(5), InlineData(10), InlineData(20)]
        public void FastestStack_TryPeek_SucceedsWhenNotEmpty(int count)
        {
            // Arrange
            FastestStack<int> stack = new();
            for (int i = 0; i < count; i++)
            {
                stack.Push(i);
            }

            // Act
            bool success = stack.TryPeek(out int result);

            // Assert
            Assert.True(success);
            Assert.Equal(count - 1, result);
        }

        /// <summary>
        ///     Tests that fastest stack try peek fails when empty
        /// </summary>
        [Fact]
        public void FastestStack_TryPeek_FailsWhenEmpty()
        {
            // Arrange
            FastestStack<int> stack = new();

            // Act
            bool success = stack.TryPeek(out int result);

            // Assert
            Assert.False(success);
        }

        /// <summary>
        ///     Tests that fastest stack stress test many push pop
        /// </summary>
        /// <param name="operationCount">The operation count</param>
        [Theory, InlineData(10), InlineData(50)]
        public void FastestStack_StressTest_ManyPushPop(int operationCount)
        {
            // Arrange
            FastestStack<int> stack = new();

            // Act
            for (int i = 0; i < operationCount; i++)
            {
                stack.Push(i);
            }

            for (int i = 0; i < operationCount; i++)
            {
                stack.Pop();
            }

            // Assert
            Assert.Equal(0, stack.Count);
        }

        /// <summary>
        ///     Tests that fastest stack is empty matches count
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(10), InlineData(50), InlineData(100)]
        public void FastestStack_IsEmpty_MatchesCount(int count)
        {
            // Arrange
            FastestStack<int> stack = new();

            // Act & Assert
            Assert.Equal(0, stack.Count);
            for (int i = 0; i < count; i++)
            {
                stack.Push(i);
            }

            Assert.True(stack.Count > 0);
        }
    }
}