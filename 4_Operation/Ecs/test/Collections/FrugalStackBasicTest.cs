// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrugalStackBasicTest.cs
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
    ///     The frugal stack basic test class
    /// </summary>
    /// <remarks>
    ///     Tests basic functionality of <see cref="FrugalStack{T}" /> which is a
    ///     memory-efficient stack implementation optimized for small collections.
    ///     The frugal stack uses lazy initialization and grows dynamically as needed.
    /// </remarks>
    public class FrugalStackBasicTest
    {
        /// <summary>
        ///     Tests that frugal stack can be created
        /// </summary>
        /// <remarks>
        ///     Verifies that a FrugalStack can be instantiated with the default constructor.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanBeCreated()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            Assert.NotNull(stack);
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that values can be pushed to frugal stack
        /// </summary>
        /// <remarks>
        ///     Validates that items can be added to the stack and the Any property reflects this.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanPushValues()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack initially has no elements
        /// </summary>
        /// <remarks>
        ///     Verifies that a newly created FrugalStack reports having no elements.
        /// </remarks>
        [Fact]
        public void FrugalStack_InitiallyEmpty()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack can store reference types
        /// </summary>
        /// <remarks>
        ///     Validates that FrugalStack works correctly with reference type values.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanStoreReferenceTypes()
        {
            FrugalStack<string> stack = new FrugalStack<string>();

            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");

            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack can store value types
        /// </summary>
        /// <remarks>
        ///     Verifies that FrugalStack handles value types correctly.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanStoreValueTypes()
        {
            FrugalStack<Position> stack = new FrugalStack<Position>();
            Position pos1 = new Position {X = 1, Y = 2};
            Position pos2 = new Position {X = 3, Y = 4};

            stack.Push(pos1);
            stack.Push(pos2);

            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack can handle many pushes
        /// </summary>
        /// <remarks>
        ///     Validates that FrugalStack can grow dynamically to accommodate
        ///     many items beyond initial capacity.
        /// </remarks>
        [Fact]
        public void FrugalStack_CanHandleManyPushes()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            for (int i = 0; i < 100; i++)
            {
                stack.Push(i);
            }

            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that TryPop returns false on empty stack
        /// </summary>
        [Fact]
        public void TryPop_EmptyStack_ReturnsFalse()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            bool result = stack.TryPop(out int value);

            Assert.False(result);
            Assert.Equal(default, value);
        }

        /// <summary>
        ///     Tests that TryPop returns true and popped value on non-empty stack
        /// </summary>
        [Fact]
        public void TryPop_NonEmptyStack_ReturnsTrueAndValue()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(42);

            bool result = stack.TryPop(out int value);

            Assert.True(result);
            Assert.Equal(42, value);
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that Pop returns and removes the top element
        /// </summary>
        [Fact]
        public void Pop_ReturnsAndRemovesTop()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(10);
            stack.Push(20);

            int popped = stack.Pop();

            Assert.Equal(20, popped);
            Assert.True(stack.Any);
            Assert.Equal(10, stack.Pop());
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that Pop clears reference for reference types
        /// </summary>
        [Fact]
        public void Pop_ReferenceType_ClearsSlot()
        {
            FrugalStack<string> stack = new FrugalStack<string>();
            stack.Push("hello");

            string popped = stack.Pop();

            Assert.Equal("hello", popped);
            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that Remove removes existing item
        /// </summary>
        [Fact]
        public void Remove_ExistingItem_RemovesIt()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            stack.Remove(20);

            Assert.Equal(2, stack.AsSpan().Length);
        }

        /// <summary>
        ///     Tests that Remove does nothing for non-existing item
        /// </summary>
        [Fact]
        public void Remove_NonExistingItem_DoesNothing()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(10);
            stack.Push(20);

            stack.Remove(99);

            Assert.Equal(2, stack.AsSpan().Length);
        }

        /// <summary>
        ///     Tests that Pop with many pushes grows and shrinks correctly
        /// </summary>
        [Fact]
        public void PushAndPop_ManyItems_WorksCorrectly()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            for (int i = 0; i < 100; i++)
            {
                stack.Push(i);
            }

            for (int i = 99; i >= 0; i--)
            {
                Assert.Equal(i, stack.Pop());
            }

            Assert.False(stack.Any);
        }
    }
}