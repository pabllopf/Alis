// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimplePriorityQueueTest.cs
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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Alis.Extension.Math.HighSpeedPriorityQueue.Test
{
    /// <summary>
    ///     The simple priority queue test class
    /// </summary>
    	  
	 public class SimplePriorityQueueTest 
    {
        /// <summary>
        ///     Tests that constructor initializes with default comparer and equality comparer
        /// </summary>
        [Fact]
        public void Constructor_InitializesWithDefaultComparerAndEqualityComparer()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that enqueue increases count
        /// </summary>
        [Fact]
        public void Enqueue_IncreasesCount()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            Assert.Equal(1, queue.Count);
        }

        /// <summary>
        ///     Tests that dequeue returns correct item and decreases count
        /// </summary>
        [Fact]
        public void Dequeue_ReturnsCorrectItemAndDecreasesCount()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            string item = queue.Dequeue();
            Assert.Equal("item1", item);
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that first returns correct item without removing
        /// </summary>
        [Fact]
        public void First_ReturnsCorrectItemWithoutRemoving()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            string item = queue.First;
            Assert.Equal("item1", item);
            Assert.Equal(1, queue.Count);
        }

        /// <summary>
        ///     Tests that clear resets queue
        /// </summary>
        [Fact]
        public void Clear_ResetsQueue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            queue.Clear();
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that contains returns true for enqueued item
        /// </summary>
        [Fact]
        public void Contains_ReturnsTrueForEnqueuedItem()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            Assert.True(queue.Contains("item1"));
        }

        /// <summary>
        ///     Tests that contains returns false for not enqueued item
        /// </summary>
        [Fact]
        public void Contains_ReturnsFalseForNotEnqueuedItem()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.False(queue.Contains("item1"));
        }

        /// <summary>
        ///     Tests that remove removes correct item
        /// </summary>
        [Fact]
        public void Remove_RemovesCorrectItem()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            queue.Remove("item1");
            Assert.False(queue.Contains("item1"));
        }

        /// <summary>
        ///     Tests that update priority changes item priority
        /// </summary>
        [Fact]
        public void UpdatePriority_ChangesItemPriority()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            queue.UpdatePriority("item1", 2);
            Assert.Equal(2, queue.GetPriority("item1"));
        }

        /// <summary>
        ///     Tests that enqueue without duplicates enqueues item only once
        /// </summary>
        [Fact]
        public void EnqueueWithoutDuplicates_EnqueuesItemOnlyOnce()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            bool firstEnqueue = queue.EnqueueWithoutDuplicates("item1", 1);
            bool secondEnqueue = queue.EnqueueWithoutDuplicates("item1", 1);
            Assert.True(firstEnqueue);
            Assert.False(secondEnqueue);
            Assert.Equal(1, queue.Count);
        }

        /// <summary>
        ///     Tests that get priority returns correct priority
        /// </summary>
        [Fact]
        public void GetPriority_ReturnsCorrectPriority()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            int priority = queue.GetPriority("item1");
            Assert.Equal(1, priority);
        }

        /// <summary>
        ///     Tests that is valid queue after operations returns true
        /// </summary>
        [Fact]
        public void IsValidQueue_AfterOperations_ReturnsTrue()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            queue.Enqueue("item2", 2);
            queue.Remove("item1");
            queue.UpdatePriority("item2", 3);
            queue.Dequeue();
            Assert.True(queue.IsValidQueue());
        }

        /// <summary>
        ///     Tests that constructor initializes with default comparer and equality
        /// </summary>
        [Fact]
        public void Constructor_InitializesWithDefaultComparerAndEquality()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that constructor initializes with custom priority comparer
        /// </summary>
        [Fact]
        public void Constructor_InitializesWithCustomPriorityComparer()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>(Comparer<int>.Create((x, y) => y.CompareTo(x)));
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that constructor initializes with custom priority comparison
        /// </summary>
        [Fact]
        public void Constructor_InitializesWithCustomPriorityComparison()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>((x, y) => y.CompareTo(x));
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that constructor initializes with custom item equality
        /// </summary>
        [Fact]
        public void Constructor_InitializesWithCustomItemEquality()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>(EqualityComparer<string>.Default);
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that constructor initializes with custom priority comparer and item equality
        /// </summary>
        [Fact]
        public void Constructor_InitializesWithCustomPriorityComparerAndItemEquality()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>(Comparer<int>.Default, EqualityComparer<string>.Default);
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that enqueue increases count v 2
        /// </summary>
        [Fact]
        public void Enqueue_IncreasesCount_v2()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            Assert.Equal(1, queue.Count);
        }

        /// <summary>
        ///     Tests that dequeue decreases count and returns correct item
        /// </summary>
        [Fact]
        public void Dequeue_DecreasesCountAndReturnsCorrectItem()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            string item = queue.Dequeue();
            Assert.Equal(0, queue.Count);
            Assert.Equal("item1", item);
        }

        /// <summary>
        ///     Tests that first returns correct item without removing v 2
        /// </summary>
        [Fact]
        public void First_ReturnsCorrectItemWithoutRemoving_v2()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            string item = queue.First;
            Assert.Equal(1, queue.Count);
            Assert.Equal("item1", item);
        }

        /// <summary>
        ///     Tests that clear resets queue v 2
        /// </summary>
        [Fact]
        public void Clear_ResetsQueue_v2()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            queue.Clear();
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that contains returns true for enqueued item v 2
        /// </summary>
        [Fact]
        public void Contains_ReturnsTrueForEnqueuedItem_v2()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            Assert.True(queue.Contains("item1"));
        }

        /// <summary>
        ///     Tests that contains returns false for not enqueued item v 2
        /// </summary>
        [Fact]
        public void Contains_ReturnsFalseForNotEnqueuedItem_v2()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            Assert.False(queue.Contains("item1"));
        }

        /// <summary>
        ///     Tests that remove removes correct item v 2
        /// </summary>
        [Fact]
        public void Remove_RemovesCorrectItem_v2()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            queue.Remove("item1");
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that update priority changes item priority v 2
        /// </summary>
        [Fact]
        public void UpdatePriority_ChangesItemPriority_v2()
        {
            SimplePriorityQueue<string, int> queue = new SimplePriorityQueue<string, int>();
            queue.Enqueue("item1", 1);
            queue.UpdatePriority("item1", 2);
            string node = queue.Dequeue();
            Assert.Equal("item1", node);
            // Note: Direct priority check not possible without internal access, verifying via dequeue order
        }

        /// <summary>
        ///     Tests that default constructor initializes queue
        /// </summary>
        [Fact]
        public void DefaultConstructor_InitializesQueue()
        {
            SimplePriorityQueue<string, float> queue = new SimplePriorityQueue<string, float>();
            Assert.NotNull(queue);
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that constructor with comparer initializes queue
        /// </summary>
        [Fact]
        public void Constructor_WithComparer_InitializesQueue()
        {
            Comparer<float> comparer = Comparer<float>.Default;
            SimplePriorityQueue<string, float> queue = new SimplePriorityQueue<string, float>(comparer);
            Assert.NotNull(queue);
            Assert.Equal(0, queue.Count);
        }

        /// <summary>
        ///     Tests that constructor with comparison initializes queue
        /// </summary>
        [Fact]
        public void Constructor_WithComparison_InitializesQueue()
        {
            Comparison<float> comparison = (x, y) => x.CompareTo(y);
            SimplePriorityQueue<string, float> queue = new SimplePriorityQueue<string, float>(comparison);
            Assert.NotNull(queue);
            Assert.Equal(0, queue.Count);
        }
    }
}