// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestStackEdgeCaseTest.cs
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
using System.Collections;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Edge case tests for <see cref="FastestStack{T}" /> covering exception paths and boundary conditions.
    /// </summary>
    public class FastestStackEdgeCaseTest
    {
        [Fact]
        public void Peek_OnEmptyStack_ThrowsInvalidOperation()
        {
            FastestStack<int> stack = new FastestStack<int>();
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Pop_OnEmptyStack_ThrowsInvalidOperation()
        {
            FastestStack<int> stack = new FastestStack<int>();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Remove_ExistingElement_RemovesIt()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            stack.Remove(20);

            Assert.Equal(2, stack.Count);
            Assert.False(stack.Contains(20));
        }

        [Fact]
        public void Remove_NonExistingElement_DoesNothing()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);

            stack.Remove(99);

            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void Remove_LastElement_PopsIt()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);

            stack.Remove(20);

            Assert.Equal(1, stack.Count);
            Assert.Equal(10, stack.Peek());
        }

        [Fact]
        public void TrimExcess_WithNegativeCapacity_ThrowsArgumentOutOfRange()
        {
            FastestStack<int> stack = new FastestStack<int>(10);
            stack.Push(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => stack.TrimExcess(-1));
        }

        [Fact]
        public void TrimExcess_WithCapacityLessThanSize_ThrowsArgumentOutOfRange()
        {
            FastestStack<int> stack = new FastestStack<int>(10);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.Throws<ArgumentOutOfRangeException>(() => stack.TrimExcess(2));
        }

        [Fact]
        public void TrimExcess_WithSameCapacity_DoesNothing()
        {
            FastestStack<int> stack = new FastestStack<int>(10);
            stack.Push(1);
            stack.Push(2);

            stack.TrimExcess(10);

            Assert.Equal(10, stack.Capacity);
        }

        [Fact]
        public void EnsureCapacity_WithNegativeCapacity_ThrowsArgumentOutOfRange()
        {
            FastestStack<int> stack = new FastestStack<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => stack.EnsureCapacity(-1));
        }

        [Fact]
        public void CopyTo_WithNullArray_ThrowsArgumentNull()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            Assert.Throws<ArgumentNullException>(() => ((ICollection) stack).CopyTo(null, 0));
        }

        [Fact]
        public void CopyTo_WithMultiDimensionalArray_ThrowsArgumentException()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            Array multiDim = new int[2, 2];
            Assert.Throws<ArgumentException>(() => ((ICollection) stack).CopyTo(multiDim, 0));
        }

        [Fact]
        public void CopyTo_WithNonZeroLowerBound_ThrowsArgumentException()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            Array nonZero = Array.CreateInstance(typeof(int), new[] { 5 }, new[] { 1 });
            Assert.Throws<ArgumentException>(() => ((ICollection) stack).CopyTo(nonZero, 0));
        }

        [Fact]
        public void CopyTo_WithNegativeIndex_ThrowsArgumentOutOfRange()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            int[] target = new int[5];
            Assert.Throws<ArgumentOutOfRangeException>(() => ((ICollection) stack).CopyTo(target, -1));
        }

        [Fact]
        public void CopyTo_WithIndexBeyondArrayLength_ThrowsArgumentOutOfRange()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            int[] target = new int[5];
            Assert.Throws<ArgumentOutOfRangeException>(() => ((ICollection) stack).CopyTo(target, 10));
        }

        [Fact]
        public void CopyTo_WithInsufficientSpace_ThrowsArgumentException()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            int[] target = new int[2];
            Assert.Throws<ArgumentException>(() => ((ICollection) stack).CopyTo(target, 0));
        }

        [Fact]
        public void CopyTo_WithWrongArrayType_ThrowsArgumentException()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            Array target = new string[5];
            Assert.Throws<ArgumentException>(() => ((ICollection) stack).CopyTo(target, 0));
        }

        [Fact]
        public void CopyTo_WithValidParameters_CopiesCorrectly()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            int[] target = new int[5];

            ((ICollection) stack).CopyTo(target, 1);

            Assert.Equal(0, target[0]);
            Assert.Equal(30, target[1]);
            Assert.Equal(20, target[2]);
            Assert.Equal(10, target[3]);
            Assert.Equal(0, target[4]);
        }

        [Fact]
        public void Enumerator_MoveNext_ReturnsElementsInCorrectOrder()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);
            FastestStack<int>.Enumerator enumerator = stack.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(2, enumerator.Current);
            Assert.True(enumerator.MoveNext());
            Assert.Equal(1, enumerator.Current);
            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Enumerator_GetCurrentBeforeMoveNext_ThrowsInvalidOperation()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            FastestStack<int>.Enumerator enumerator = stack.GetEnumerator();

            Assert.Throws<InvalidOperationException>(() => enumerator.Current);
        }

        [Fact]
        public void Enumerator_GetCurrentAfterEnumerationEnded_ThrowsInvalidOperation()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            FastestStack<int>.Enumerator enumerator = stack.GetEnumerator();
            enumerator.MoveNext();
            enumerator.MoveNext();

            Assert.Throws<InvalidOperationException>(() => enumerator.Current);
        }

        [Fact]
        public void Enumerator_Dispose_SetsIndexToMinusOne()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            FastestStack<int>.Enumerator enumerator = stack.GetEnumerator();
            enumerator.Dispose();

            Assert.Throws<InvalidOperationException>(() => enumerator.Current);
        }

        [Fact]
        public void Enumerator_EmptyStack_ReturnsFalseOnMoveNext()
        {
            FastestStack<int> stack = new FastestStack<int>();
            FastestStack<int>.Enumerator enumerator = stack.GetEnumerator();

            Assert.False(enumerator.MoveNext());
        }

        [Fact]
        public void Enumerator_Reset_RestartsEnumeration()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            IEnumerator enumerator = ((IEnumerable) stack).GetEnumerator();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(20, enumerator.Current);

            enumerator.Reset();

            Assert.True(enumerator.MoveNext());
            Assert.Equal(20, enumerator.Current);
        }

        [Fact]
        public void Push_AfterTrimExcess_GrowsCorrectly()
        {
            FastestStack<int> stack = new FastestStack<int>(4);
            stack.Push(1);
            stack.Push(2);
            stack.TrimExcess(2);

            stack.Push(3);

            Assert.Equal(3, stack.Count);
            Assert.Equal(3, stack.Peek());
        }

        [Fact]
        public void Push_BeyondDefaultCapacity_TriggersResize()
        {
            FastestStack<int> stack = new FastestStack<int>();
            for (int i = 0; i < 33; i++)
            {
                stack.Push(i);
            }

            Assert.Equal(33, stack.Count);
            Assert.True(stack.Capacity >= 33);
        }

        [Fact]
        public void Indexer_Get_ReturnsCorrectValue()
        {
            FastestStack<int> stack = new FastestStack<int>(4);
            stack.Push(10);
            stack.Push(20);

            Assert.Equal(10, stack[0]);
            Assert.Equal(20, stack[1]);
        }

        [Fact]
        public void Indexer_Set_ModifiesValue()
        {
            FastestStack<int> stack = new FastestStack<int>(4);
            stack.Push(10);
            stack.Push(20);

            stack[0] = 99;

            Assert.Equal(99, stack[0]);
        }

        [Fact]
        public void ToArray_EmptyStack_ReturnsEmptyArray()
        {
            FastestStack<int> stack = new FastestStack<int>();

            int[] result = stack.ToArray();

            Assert.Empty(result);
        }

        [Fact]
        public void Push_SingleItem_IsPeekable()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(42);

            Assert.Equal(1, stack.Count);
            Assert.Equal(42, stack.Peek());
        }

        [Fact]
        public void Peek_OnEmptyStringStack_ThrowsInvalidOperation()
        {
            FastestStack<string> stack = new FastestStack<string>();
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Pop_OnEmptyStringStack_ThrowsInvalidOperation()
        {
            FastestStack<string> stack = new FastestStack<string>();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void TryPop_WithReferenceType_ClearsSlot()
        {
            FastestStack<string> stack = new FastestStack<string>();
            stack.Push("first");
            stack.Push("second");

            Assert.True(stack.TryPop(out string result));
            Assert.Equal("second", result);

            Assert.True(stack.TryPop(out result));
            Assert.Equal("first", result);

            Assert.False(stack.TryPop(out result));
            Assert.Null(result);
        }

        [Fact]
        public void Enumerator_CurrentBeforeMoveNext_StringStack_Throws()
        {
            FastestStack<string> stack = new FastestStack<string>();
            stack.Push("value");
            FastestStack<string>.Enumerator enumerator = stack.GetEnumerator();

            Assert.Throws<InvalidOperationException>(() => enumerator.Current);
        }

        [Fact]
        public void Contains_AfterRemove_ReturnsFalse()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            stack.Remove(2);

            Assert.False(stack.Contains(2));
        }
    }
}
