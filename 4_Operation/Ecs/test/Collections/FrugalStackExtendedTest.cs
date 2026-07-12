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

using System;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Extended tests for <see cref="FrugalStack{T}" /> struct
    /// </summary>
    public class FrugalStackExtendedTest
    {
        /// <summary>
        ///     Tests that frugal stack is value type
        /// </summary>
        [Fact]
        public void FrugalStack_IsValueType()
        {
            Type type = typeof(FrugalStack<int>);

            Assert.True(type.IsValueType);
        }

        /// <summary>
        ///     Tests that frugal stack has sequential struct layout
        /// </summary>
        [Fact]
        public void FrugalStack_HasSequentialStructLayout()
        {
            StructLayoutAttribute layout = typeof(FrugalStack<int>).StructLayoutAttribute;

            Assert.Equal(LayoutKind.Sequential, layout.Value);
        }

        /// <summary>
        ///     Tests that pop returns last pushed value
        /// </summary>
        [Fact]
        public void Pop_ReturnsLastPushedValue()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            int result = stack.Pop();

            Assert.Equal(3, result);
        }

        /// <summary>
        ///     Tests that try pop returns false when empty
        /// </summary>
        [Fact]
        public void TryPop_ReturnsFalseWhenEmpty()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            bool result = stack.TryPop(out int value);

            Assert.False(result);
            Assert.Equal(default(int), value);
        }

        /// <summary>
        ///     Tests that try pop returns true when has items
        /// </summary>
        [Fact]
        public void TryPop_ReturnsTrueWhenHasItems()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(42);

            bool result = stack.TryPop(out int value);

            Assert.True(result);
            Assert.Equal(42, value);
        }

        /// <summary>
        ///     Tests that remove removes first occurrence
        /// </summary>
        [Fact]
        public void Remove_RemovesFirstOccurrence()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            stack.Remove(2);

            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that remove does nothing if item not found
        /// </summary>
        [Fact]
        public void Remove_DoesNothingIfItemNotFound()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);

            stack.Remove(99);

            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that as span returns correct elements
        /// </summary>
        [Fact]
        public void AsSpan_ReturnsCorrectElements()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            Span<int> span = stack.AsSpan();

            Assert.Equal(3, span.Length);
            Assert.Equal(10, span[0]);
            Assert.Equal(20, span[1]);
            Assert.Equal(30, span[2]);
        }

        /// <summary>
        ///     Tests that as span of empty stack returns empty span
        /// </summary>
        [Fact]
        public void AsSpan_EmptyStack_ReturnsEmptySpan()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            Span<int> span = stack.AsSpan();

            Assert.Equal(0, span.Length);
        }

        /// <summary>
        ///     Tests that any is false after popping all items
        /// </summary>
        [Fact]
        public void Any_IsFalseAfterPoppingAllItems()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);

            stack.Pop();

            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that pop on empty stack throws index out of range
        /// </summary>
        [Fact]
        public void Pop_OnEmptyStack_ThrowsIndexOutOfRange()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            Assert.Throws<IndexOutOfRangeException>(() => stack.Pop());
        }

        /// <summary>
        ///     Tests that frugal stack can store reference types
        /// </summary>
        [Fact]
        public void FrugalStack_CanStoreReferenceTypesExtended()
        {
            FrugalStack<string> stack = new FrugalStack<string>();
            stack.Push("first");
            stack.Push("second");

            string result = stack.Pop();

            Assert.Equal("second", result);
        }

        /// <summary>
        ///     Tests that frugal stack can store custom structs
        /// </summary>
        [Fact]
        public void FrugalStack_CanStoreCustomStructs()
        {
            FrugalStack<Position> stack = new FrugalStack<Position>();
            Position pos = new Position {X = 10, Y = 20};
            stack.Push(pos);

            Position result = stack.Pop();

            Assert.Equal(10, result.X);
            Assert.Equal(20, result.Y);
        }

        /// <summary>
        ///     Tests that frugal stack handles many pushes and pops
        /// </summary>
        [Fact]
        public void FrugalStack_HandlesManyPushesAndPops()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            for (int i = 0; i < 50; i++)
            {
                stack.Push(i);
            }

            for (int i = 49; i >= 0; i--)
            {
                int value = stack.Pop();
                Assert.Equal(i, value);
            }

            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that frugal stack can be copied
        /// </summary>
        [Fact]
        public void FrugalStack_CanBeCopied()
        {
            FrugalStack<int> original = new FrugalStack<int>();
            original.Push(1);
            original.Push(2);

            FrugalStack<int> copy = original;

            Assert.Equal(original.Any, copy.Any);
        }

        /// <summary>
        ///     Tests that frugal stack default has no elements
        /// </summary>
        [Fact]
        public void FrugalStack_Default_HasNoElements()
        {
            FrugalStack<int> defaultStack = default(FrugalStack<int>);

            Assert.False(defaultStack.Any);
        }
    }
}
