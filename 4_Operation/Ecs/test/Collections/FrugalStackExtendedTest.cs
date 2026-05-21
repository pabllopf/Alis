// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrugalStackExtendedTest.cs
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
    ///     Extended tests for FrugalStack to validate memory efficiency,
    ///     push-pop cycles, and edge case handling.
    /// </summary>
    public class FrugalStackExtendedTest
    {
        /// <summary>
        ///     Test that FrugalStack can be created.
        /// </summary>
        [Fact]
        public void Constructor_Default_StackCreated()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            Assert.NotNull(stack);
        }

        /// <summary>
        ///     Test that FrugalStack.Push and Pop maintain LIFO order.
        /// </summary>
        [Fact]
        public void PushAndPop_MultipleValues_CorrectLIFOOrder()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            stack.Push(100);
            stack.Push(200);
            stack.Push(300);

            Assert.Equal(300, stack.Pop());
            Assert.Equal(200, stack.Pop());
            Assert.Equal(100, stack.Pop());
        }

        /// <summary>
        ///     Test that FrugalStack.TryPop returns false when stack is empty.
        /// </summary>
        [Fact]
        public void TryPop_EmptyStack_ReturnsFalse()
        {
            FrugalStack<string> stack = new FrugalStack<string>();

            bool result = stack.TryPop(out string value);

            Assert.False(result);
            Assert.Null(value);
        }

        /// <summary>
        ///     Test that FrugalStack.TryPop returns true and correct value when not empty.
        /// </summary>
        [Fact]
        public void TryPop_WithElements_ReturnsTrueWithValue()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(42);

            bool result = stack.TryPop(out int value);

            Assert.True(result);
            Assert.Equal(42, value);
        }

        /// <summary>
        ///     Test that FrugalStack.Remove works correctly.
        /// </summary>
        [Fact]
        public void Remove_ExistingElement_RemovedSuccessfully()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            stack.Remove(20);

            int val1 = stack.Pop();
            int val2 = stack.Pop();
            Assert.Equal(30, val1);
            Assert.Equal(10, val2);
        }

        /// <summary>
        ///     Test that FrugalStack with multiple push and pop operations works.
        /// </summary>
        [Fact]
        public void Push_MultipleElements_AllAccessible()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            for (int i = 0; i < 50; i++)
            {
                stack.Push(i);
            }

            for (int i = 49; i >= 0; i--)
            {
                Assert.Equal(i, stack.Pop());
            }
        }

        /// <summary>
        ///     Test that FrugalStack properly tracks Any property.
        /// </summary>
        [Fact]
        public void Any_AfterPushAndPop_TracksEmptyState()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            Assert.False(stack.Any);

            stack.Push(42);
            Assert.True(stack.Any);

            stack.Pop();
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Test that FrugalStack with reference types maintains proper references.
        /// </summary>
        [Fact]
        public void Push_ReferenceType_MaintainReferences()
        {
            FrugalStack<object> stack = new FrugalStack<object>();
            var obj1 = new {Value = 1};
            var obj2 = new {Value = 2};

            stack.Push(obj1);
            stack.Push(obj2);

            Assert.Same(obj2, stack.Pop());
            Assert.Same(obj1, stack.Pop());
        }

        /// <summary>
        ///     Test that FrugalStack maintains proper state with multiple push/pop cycles.
        /// </summary>
        [Fact]
        public void PushPopCycles_MultipleOperations_CorrectState()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            stack.Push(1);
            Assert.True(stack.Any);

            stack.Push(2);
            Assert.True(stack.Any);

            int val = stack.Pop();
            Assert.Equal(2, val);
            Assert.True(stack.Any);

            stack.Pop();
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Test that FrugalStack handles different value types.
        /// </summary>
        [Fact]
        public void Push_DifferentValueTypes_WorksCorrectly()
        {
            FrugalStack<int> intStack = new FrugalStack<int>();
            FrugalStack<string> stringStack = new FrugalStack<string>();
            FrugalStack<double> doubleStack = new FrugalStack<double>();

            intStack.Push(42);
            stringStack.Push("test");
            doubleStack.Push(3.14);

            Assert.Equal(42, intStack.Pop());
            Assert.Equal("test", stringStack.Pop());
            Assert.Equal(3.14, doubleStack.Pop());
        }

        /// <summary>
        ///     Test that FrugalStack properly handles repeated push/pop on same instance.
        /// </summary>
        [Fact]
        public void RepeatedOperations_SameInstance_MaintainsCorrectBehavior()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            stack.Push(10);
            Assert.Equal(10, stack.Pop());

            stack.Push(20);
            Assert.Equal(20, stack.Pop());

            stack.Push(30);
            Assert.Equal(30, stack.Pop());
        }
    }
}