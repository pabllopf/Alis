// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FrugalStackRemainingCoverageTests.cs
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
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The frugal stack remaining coverage tests class
    /// </summary>
    public class FrugalStackRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that Any on a new instance returns false
        /// </summary>
        [Fact]
        public void Any_OnNewInstance_ReturnsFalse()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that pushing a single item makes Any true
        /// </summary>
        [Fact]
        public void Push_SingleItem_MakesAnyTrue()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            stack.Push(1);

            Assert.True(stack.Any);
        }

        /// <summary>
        ///     Tests that a single pushed item can be popped
        /// </summary>
        [Fact]
        public void Push_SingleItem_CanBePopped()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(42);

            bool result = stack.TryPop(out int value);

            Assert.True(result);
            Assert.Equal(42, value);
        }

        /// <summary>
        ///     Tests that TryPop on an empty stack returns false
        /// </summary>
        [Fact]
        public void TryPop_OnEmpty_ReturnsFalse()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            Assert.False(stack.TryPop(out _));
        }

        /// <summary>
        ///     Tests that multiple pushed items are popped in LIFO order
        /// </summary>
        [Fact]
        public void Push_MultipleItems_PopInLifoOrder()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
        }

        /// <summary>
        ///     Tests that Pop on a non empty stack returns the last pushed item
        /// </summary>
        [Fact]
        public void Pop_OnNonEmpty_ReturnsLastPushed()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(10);
            stack.Push(20);

            Assert.Equal(20, stack.Pop());
        }

        /// <summary>
        ///     Tests that Pop decrements the next index
        /// </summary>
        [Fact]
        public void Pop_DecrementsNextIndex()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);

            stack.Pop();

            Assert.Equal(1, stack._nextIndex);
        }

        /// <summary>
        ///     Tests that Remove removes the specified item
        /// </summary>
        [Fact]
        public void Remove_RemovesItem()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            stack.Remove(2);

            ReadOnlySpan<int> span = stack.AsSpan();
            Assert.Equal(2, span.Length);
            Assert.Equal(1, span[0]);
            Assert.Equal(3, span[1]);
        }

        /// <summary>
        ///     Tests that Remove removes the first item
        /// </summary>
        [Fact]
        public void Remove_FirstItem_RemovesIt()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            stack.Remove(3);

            ReadOnlySpan<int> span = stack.AsSpan();
            Assert.Equal(2, span.Length);
            Assert.Equal(1, span[0]);
            Assert.Equal(2, span[1]);
        }

        /// <summary>
        ///     Tests that Remove with an item not present does nothing
        /// </summary>
        [Fact]
        public void Remove_ItemNotPresent_DoesNothing()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);

            stack.Remove(99);

            Assert.True(stack.Any);
            Assert.Equal(2, stack.AsSpan().Length);
        }

        /// <summary>
        ///     Tests that AsSpan on an empty stack returns an empty span
        /// </summary>
        [Fact]
        public void AsSpan_OnEmpty_ReturnsEmptySpan()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            Assert.Equal(0, stack.AsSpan().Length);
        }

        /// <summary>
        ///     Tests that AsSpan after pushes returns the pushed items
        /// </summary>
        [Fact]
        public void AsSpan_AfterPushes_ReturnsPushedItems()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            ReadOnlySpan<int> span = stack.AsSpan();

            Assert.Equal(3, span.Length);
            Assert.Equal(1, span[0]);
            Assert.Equal(3, span[2]);
        }

        /// <summary>
        ///     Tests that pushing more than the initial capacity triggers a resize
        /// </summary>
        [Fact]
        public void Push_MoreThanInitialCapacity_TriggersResize()
        {
            FrugalStack<int> stack = new FrugalStack<int>();

            for (int i = 0; i < 10; i++)
            {
                stack.Push(i);
            }

            for (int i = 9; i >= 0; i--)
            {
                Assert.Equal(i, stack.Pop());
            }

            Assert.False(stack.Any);
        }

        /// <summary>
        ///     Tests that Any returns false after all items are popped
        /// </summary>
        [Fact]
        public void Any_AfterAllItemsPopped_ReturnsFalse()
        {
            FrugalStack<int> stack = new FrugalStack<int>();
            stack.Push(1);
            stack.Pop();

            Assert.False(stack.Any);
        }
    }
}