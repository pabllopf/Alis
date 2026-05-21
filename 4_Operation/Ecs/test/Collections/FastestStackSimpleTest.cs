

using System;
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
            FastestStack<int> stack = new FastestStack<int>();

            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

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
            FastestStack<int> stack = new FastestStack<int>();

            bool result = stack.TryPop(out int value);

            Assert.False(result);
            Assert.Equal(0, value);
        }

        /// <summary>
        ///     Test that FastestStack.TryPop returns true with correct value when not empty.
        /// </summary>
        [Fact]
        public void TryPop_WithElements_ReturnsTrueWithValue()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(42);

            bool result = stack.TryPop(out int value);

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
            FastestStack<int> stack = new FastestStack<int>();
            for (int i = 0; i < 50; i++)
            {
                stack.Push(i);
            }

            stack.Clear();

            Assert.Equal(0, stack.Count);
            Assert.True(!stack.TryPop(out _));
        }

        /// <summary>
        ///     Test that FastestStack with large number of elements maintains proper LIFO order.
        /// </summary>
        [Fact]
        public void PushPop_LargeNumberOfElements_MaintainsOrder()
        {
            FastestStack<int> stack = new FastestStack<int>();

            for (int i = 0; i < 1000; i++)
            {
                stack.Push(i);
            }

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
            FastestStack<int> stack = new FastestStack<int>();

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
            FastestStack<Guid> stack = new FastestStack<Guid>();
            Guid guid1 = Guid.NewGuid();
            Guid guid2 = Guid.NewGuid();

            stack.Push(guid1);
            stack.Push(guid2);

            Assert.Equal(guid2, stack.Pop());
            Assert.Equal(guid1, stack.Pop());
        }
    }
}