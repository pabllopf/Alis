// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrugalStackEdgeCaseTest.cs
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
//  See the GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Edge case tests for <see cref="FrugalStack{T}" /> covering growth boundaries,
    ///     reference type cleanup, struct copy behavior, and exception paths.
    /// </summary>
    public class FrugalStackEdgeCaseTest
    {
        [Fact]
        public void Pop_OnEmptyStack_ThrowsIndexOutOfRange()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            Assert.Throws<IndexOutOfRangeException>(() => stack.Pop());
        }

        [Fact]
        public void Push_BeyondInitialCapacity_ResizeTriggers()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(10);
            stack.Push(20);

            Assert.True(stack.Any);
            Assert.Equal(20, stack.Pop());
            Assert.Equal(10, stack.Pop());
        }

        [Fact]
        public void Push_Exact16Items_ResizeUsingMultiplication()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            for (int i = 0; i < 17; i++)
            {
                stack.Push(i);
            }

            Assert.True(stack.Any);
            for (int i = 16; i >= 0; i--)
            {
                Assert.Equal(i, stack.Pop());
            }
        }

        [Fact]
        public void Remove_LastElement_PopsCorrectly()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            stack.Remove(30);

            Assert.Equal(20, stack.Pop());
            Assert.Equal(10, stack.Pop());
            Assert.False(stack.Any);
        }

        [Fact]
        public void Remove_FirstElement_ReplacesWithTop()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            stack.Remove(10);

            Assert.Equal(20, stack.Pop());
            Assert.Equal(30, stack.Pop());
            Assert.False(stack.Any);
        }

        [Fact]
        public void Remove_OnSingleElement_EmptiesStack()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(42);

            stack.Remove(42);

            Assert.False(stack.Any);
        }

        [Fact]
        public void ReferenceType_Pop_ClearsElement()
        {
            FrugalStack<string> stack = new FrugalStack<string>();
            stack.Push("hello");
            stack.Push("world");

            string result = stack.Pop();

            Assert.Equal("world", result);
            Assert.True(stack.Any);
        }

        [Fact]
        public void ReferenceType_Remove_ClearsReference()
        {
            FrugalStack<string> stack = new FrugalStack<string>();
            stack.Push("a");
            stack.Push("b");
            stack.Push("c");

            stack.Remove("b");

            Assert.Equal("c", stack.Pop());
            Assert.Equal("a", stack.Pop());
            Assert.False(stack.Any);
        }

        [Fact]
        public void ReferenceType_TryPop_ReturnsValue()
        {
            FrugalStack<string> stack = new FrugalStack<string>();
            stack.Push("test");

            bool result = stack.TryPop(out string value);

            Assert.True(result);
            Assert.Equal("test", value);
        }

        [Fact]
        public void AsSpan_OnEmptyStack_ReturnsEmpty()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            Span<int> span = stack.AsSpan();

            Assert.True(span.IsEmpty);
        }

        [Fact]
        public void AsSpan_AfterPop_ReflectsRemaining()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Pop();

            Span<int> span = stack.AsSpan();

            Assert.Equal(2, span.Length);
            Assert.Equal(1, span[0]);
            Assert.Equal(2, span[1]);
        }

        [Fact]
        public void Struct_PushOnCopy_DoesNotAffectOriginal()
        {
            FrugalStack<int> original = new FrugalStack<int>();
            original.Push(1);
            original.Push(2);

            FrugalStack<int> copy = original;
            copy.Push(3);

            Assert.Equal(2, original.AsSpan().Length);
            Assert.Equal(3, copy.AsSpan().Length);
        }

        [Fact]
        public void Struct_PopOnCopy_DoesNotAffectOriginal()
        {
            FrugalStack<int> original = new FrugalStack<int>();
            original.Push(10);
            original.Push(20);

            FrugalStack<int> copy = original;
            copy.Pop();

            Assert.Equal(2, original.AsSpan().Length);
            Assert.Equal(1, copy.AsSpan().Length);
        }

        [Fact]
        public void TryPop_OnEmptyReferenceType_ReturnsNull()
        {
            FrugalStack<string> stack = new FrugalStack<string>();

            bool result = stack.TryPop(out string value);

            Assert.False(result);
            Assert.Null(value);
        }

        [Fact]
        public void Push_TryPop_Push_TryPop_Alternating()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            stack.Push(1);
            Assert.True(stack.TryPop(out int v1));
            Assert.Equal(1, v1);

            stack.Push(2);
            Assert.True(stack.TryPop(out int v2));
            Assert.Equal(2, v2);

            Assert.False(stack.TryPop(out _));
        }

        [Fact]
        public void Contains_UsingInlineArray_ReturnsExpected()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(5);
            stack.Push(10);
            stack.Push(15);

            Assert.Contains(10, stack.AsSpan().ToArray());
            Assert.DoesNotContain(99, stack.AsSpan().ToArray());
        }

        [Fact]
        public void Push_ZeroItemsThenPop_StillEmpty()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            Assert.False(stack.Any);
        }

        [Fact]
        public void MultipleRemove_WithDuplicates_RemovesFirstOnly()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(1);
            stack.Push(3);

            stack.Remove(1);

            Assert.Equal(1, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(3, stack.Pop());
            Assert.False(stack.Any);
        }
    }
}
